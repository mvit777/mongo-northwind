using MV.Framework.interfaces;
using Newtonsoft.Json.Linq;

namespace NorthWindClient5.Services;
    public class FSConfigService : IConfigService
    {
        private string _rawJson;
        
        public async void SetConfigJson(string filePath)
        {
            _rawJson= await ReadTextFile(filePath);
        }
        public async Task<string> ReadTextFile(string filePath)
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
            using StreamReader reader = new StreamReader(fileStream);

            return await reader.ReadToEndAsync();
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

