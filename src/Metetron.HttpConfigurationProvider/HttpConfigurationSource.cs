using Microsoft.Extensions.Configuration;

namespace Metetron.HttpConfigurationProvider
{
    public class HttpConfigurationSource : IConfigurationSource
    {
        private readonly string _requestUri;

        public HttpConfigurationSource(string requestUri)
        {
            _requestUri = requestUri;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new HttpConfigurationProvider(_requestUri);
        }
    }
}