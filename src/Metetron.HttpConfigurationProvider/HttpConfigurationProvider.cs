using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Metetron.HttpConfigurationProvider.Models;
using Microsoft.Extensions.Configuration;

namespace Metetron.HttpConfigurationProvider
{
    public class HttpConfigurationProvider : ConfigurationProvider
    {
        private readonly HttpConfigurationSourceSettings _settings;

        public HttpConfigurationProvider(HttpConfigurationSourceSettings settings)
        {
            _settings = settings;
        }

        public async override void Load()
        {
            var configuration = await LoadSettingsFromServerAsync();

            AddSettingsToConfiguration(configuration);
        }

        private async Task<AppConfiguration> LoadSettingsFromServerAsync()
        {
            var content = JsonSerializer.Serialize(new { appName = _settings.AppName, hostName = _settings.HostName });
            var data = await new HttpClient().PostAsync(_settings.ServerUri, new StringContent(content));

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var response = await data.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<AppConfiguration>(response, options);
        }

        private void AddSettingsToConfiguration(AppConfiguration configuration)
        {
            foreach (var setting in configuration.Settings)
            {
                Data.Add(setting.Key, setting.Value);
            }
        }
    }
}