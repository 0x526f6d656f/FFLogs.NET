using FFLogs.NET.Attributes;
using FFLogs.NET.Helpers;
using FFLogs.NET.Models;
using FFLogs.NET.Options;

namespace FFLogs.NET {
    public class FFLogsClient {
        private readonly BaseAPIClient _apiClient;

        public bool Authenticated => _apiClient._restClient.Options.Authenticator is not null;

        public FFLogsClient() {
            _apiClient = new BaseAPIClient(apiName: "FFLogs v2", baseUri: "https://www.fflogs.com/api/v2/client");
        }

        public async Task AuthenticateAsync(string clientId,
                                       string clientSecret) {
            var token = await _apiClient.FetchTokenFromAPI(clientId, clientSecret);
            _apiClient.AddOAuthToken(token);
        }

        [OAuth2AuthenticationRequired]
        public async Task<List<Zone>> GetZonesAsync() {
            var query = await _apiClient.GetData<Query>(QueryHelper.GetZonesQuery());
            return query.Data.WorldData.Expansions
                .SelectMany(expansion => expansion.Zones)
                .ToList();
        }

        [OAuth2AuthenticationRequired]
        public async Task<List<Job>> GetJobsAsync() {
            var query = await _apiClient.GetData<Query>(QueryHelper.GetJobDataQuery());

            return query.Data.GameData.Classes
                .SelectMany(x => x.Jobs)
                .ToList();
        }

        [OAuth2AuthenticationRequired]
        public async Task<List<FightRanking>> GetEncounterFightRankingsAsync(int encounterId, FightRankingOptions? rankingOptions = null) {
            var query = await _apiClient.GetData<Query>(QueryHelper.GetEncounterFightRankingsQuery(encounterId, rankingOptions ?? FightRankingOptions.DefaultOptions));

            return query.Data.WorldData.Encounter.FightRankings.Rankings;
        }

        [OAuth2AuthenticationRequired]
        public async Task<List<CharacterRanking>> GetEncounterCharacterRankingsAsync(int encounterId, CharacterRankingOptions? rankingOptions = null) {
            var query = await _apiClient.GetData<Query>(QueryHelper.GetEncountercharacterRankingsQuery(encounterId, rankingOptions ?? CharacterRankingOptions.DefaultOptions));

            return query.Data.WorldData.Encounter.CharacterRankings.Rankings;
        }
    }
}
