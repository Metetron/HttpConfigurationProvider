using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Metetron.HttpConfigurationProvider.Models;
using Microsoft.Extensions.Configuration;

namespace Metetron.HttpConfigurationProvider
{
    public class HttpConfigurationProvider : ConfigurationProvider
    {
        private readonly string _requestUri;

        public HttpConfigurationProvider(string requestUri)
        {
            _requestUri = requestUri;
        }

        public async override void Load()
        {
            var configuration = await LoadSettingsFromServerAsync();

            AddSettingsToConfiguration(configuration);
        }

        private async Task<AppConfiguration> LoadSettingsFromServerAsync()
        {
            var data = await new HttpClient().GetAsync(_requestUri);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var content = await data.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<AppConfiguration>(content, options);
        }

        private void AddSettingsToConfiguration(AppConfiguration configuration)
        {
            foreach (var setting in configuration.Settings)
            {
                Data.Add(setting.Name, setting.Value);
            }
        }
    }
}