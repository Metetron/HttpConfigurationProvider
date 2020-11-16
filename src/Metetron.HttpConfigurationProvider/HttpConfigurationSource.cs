using Microsoft.Extensions.Configuration;

namespace Metetron.HttpConfigurationProvider
{
    public class HttpConfigurationSource : IConfigurationSource
    {
        private readonly HttpConfigurationSourceSettings _settings;

        public HttpConfigurationSource(HttpConfigurationSourceSettings settings)
        {
            _settings = settings;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new HttpConfigurationProvider(_settings);
        }
    }
}