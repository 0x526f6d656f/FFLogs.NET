using MethodDecorator.Fody.Interfaces;
using System.Reflection;

namespace FFLogs.NET.Attributes {
    [AttributeUsage(AttributeTargets.Method)]
    public class OAuth2AuthenticationRequiredAttribute : Attribute, IMethodDecorator {
        private MethodBase? _method;
        private FFLogsClient? _client;

        public void Init(object instance, MethodBase method, object[] args) {
            _method = method;
            _client = (FFLogsClient)instance;
        }

        public void OnEntry() {
            if (_client != null && !_client.Authenticated)
                throw new Exception("need to be authenticated");
        }

        public void OnExit() { }

        public void OnException(Exception exception) { }
    }
}
