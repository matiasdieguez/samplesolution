using System;
using System.Net.Http;
using ProjectName.Common.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace ProjectName.Api.Client
{
    public static class ProjectNameApiClient
    {
        public static HttpClient Get()
        {
            var apiUrl = ConfigurationManager.AppSettings["AppConfig:ApiUrl"];
            var apiKey = ConfigurationManager.AppSettings["AppConfig:ApiKey"];
            var client = new HttpClient { BaseAddress = new Uri(apiUrl) };
            client.DefaultRequestHeaders.Add("ApiKey", apiKey);
            return client;
        }

        public static StringContent ConvertToContent<T>(T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            return content;
        }
    }
}
