using FFLogs.NET.Models;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using System.Net;
using System.Text.Json;

namespace FFLogs.NET.Helpers {
    internal class BaseAPIClient {
        public string BaseUri { get; init; }
        public string APIName { get; init; }

        internal RestClient _restClient;

        public BaseAPIClient(string baseUri, string apiName) {
            BaseUri = baseUri;
            APIName = apiName;
            _restClient = GetBaseRestClient();
        }

        private RestClient GetBaseRestClient(IAuthenticator? authenticator = null) {
            IWebProxy? proxy = WebRequest.DefaultWebProxy;
            if (proxy is not null) proxy.Credentials = CredentialCache.DefaultCredentials;
            var restClientOptions = new RestClientOptions(BaseUri) { Proxy = proxy, Authenticator = authenticator };
            return new RestClient(restClientOptions);
        }

        private protected RestRequest CreateRestClientQuery(string query) {
            var request = new RestRequest(BaseUri, Method.Post);
            request.AddParameter("query", query);
            return request;
        }

        internal void AddOAuthToken(OAuthToken? token) {
            if (token is { Error: null }) {
                var OAuth2Token = new OAuth2AuthorizationRequestHeaderAuthenticator(token.AccessToken, token.TokenType);
                _restClient = GetBaseRestClient(OAuth2Token);
                //_client.AddDefaultHeader("Authorization", $"Bearer {token.AccessToken}");
            }
            else {
                throw new Exception($"OAuth2 Token Exception \"{token.Error}\": {token.ErrorDescription} - {token.ErrorMessage}");
            }
        }

        internal async Task<OAuthToken?> FetchTokenFromAPI(string clientId, string clientSecret) {
            var request = new RestRequest("https://www.fflogs.com/oauth/token", Method.Post);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", clientId);
            request.AddParameter("client_secret", clientSecret);

            var token = await GetData<OAuthToken>(request);

            return token;
        }

        internal async Task<TOutput> GetData<TOutput>(RestRequest restRequest) {
            string? content = await GetContent(restRequest);
            if (content is null) throw new NullReferenceException(nameof(content));

            TOutput? output = JsonSerializer.Deserialize<TOutput>(content);
            if (output is null) throw new NullReferenceException(nameof(output));

            return output;
        }

        internal async Task<TOutput> GetData<TOutput>(string query) {
            var restRequest = CreateRestClientQuery(query);
            string? content = await GetContent(restRequest);
            if (content is null) throw new NullReferenceException(nameof(content));

            TOutput? output = JsonSerializer.Deserialize<TOutput>(content);
            if (output is null) throw new NullReferenceException(nameof(output));

            return output;
        }

        private async Task<string?> GetContent(RestRequest restRequest) {
            var response = await _restClient.ExecuteAsync(restRequest);
            return response.Content;
        }
    }
}