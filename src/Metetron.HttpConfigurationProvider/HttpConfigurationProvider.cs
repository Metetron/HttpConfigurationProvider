using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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

        public override void Load()
        {
            var settings = LoadSettingsFromServerAsync().GetAwaiter().GetResult();

            AddSettingsToConfiguration(settings);
        }

        private async Task<IEnumerable<KeyValuePair<string, string>>> LoadSettingsFromServerAsync()
        {
            try
            {
                var content = JsonSerializer.Serialize(new { appName = _settings.AppName, hostName = _settings.HostName });
                var data = await new HttpClient().PostAsync(_settings.ServerUri, new StringContent(content, Encoding.UTF8, "application/json"));

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var response = await data.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<IEnumerable<KeyValuePair<string, string>>>(response, options);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Fetching the settings failed, {0}, {1}", e.Message, e.StackTrace);

                return new List<KeyValuePair<string, string>>();
            }
        }

        private void AddSettingsToConfiguration(IEnumerable<KeyValuePair<string, string>> settings)
        {
            foreach (var setting in settings)
            {
                Data.Add(setting.Key, setting.Value);
            }
        }
    }
}