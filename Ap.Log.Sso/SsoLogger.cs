using System;
using System.Threading.Tasks;
using GetSso.Client;
using GetSso.Core.Models;

namespace Ap.Logs.Sso
{
    public class SsoLogger : LoggerBase
    {
        private readonly Guid _appId;
        private readonly LogProxy _logProxy;

        public SsoLogger(string ssoUrl, Guid appId)
        {
            _appId = appId;
            _logProxy = new LogProxy(ssoUrl);
        }

        public Task WriteAsync(string token, int type, string message)
        {
            return _logProxy.Add(token, _appId, new LogModel
            {
                Type = type,
                Message = message
            });
        }
    }
}
