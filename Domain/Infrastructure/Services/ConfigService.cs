﻿using MV.Framework.interfaces;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.Infrastructure.services
{
    public class ConfigService : IConfigService
    {
        private HttpClient _client;
        private string _jsonFilePath;
        private string _rawJson;

        public ConfigService(string jsonFilePath, HttpClient client)
        {
            _client = client;
            _jsonFilePath = jsonFilePath;
        }

        public async Task LoadAsync()
        {
            using var response = await _client.GetAsync(_jsonFilePath);
            _rawJson = await response.Content.ReadAsStringAsync();
        }

        public string GetSetting(string settingName)
        {
            JToken o = JObject.Parse(_rawJson)["Settings"][settingName];

            return o.ToString();
        }

        public string GetBaseUrl()
        {
            JToken o = JObject.Parse(_rawJson)["Api"]["baseUrl"];

            return o.ToString();
        }
        public string GetUrl(string urlName)
        {
            string[] u = urlName.Split(new char[] { '.' });
            JToken o = JObject.Parse(_rawJson)["Api"]["urls"];
            JToken url = o.SelectToken(u[0]).Value<string>(u[1]);

            return url.ToString();
        }
    }
}
