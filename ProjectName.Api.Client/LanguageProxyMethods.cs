using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectName.Dto;

namespace ProjectName.Api.Client
{
    public static class LanguageProxyMethods
    {
        public static async Task<List<LanguageDto>> Get()
        {
            using (var client = ProjectNameApiClient.Get())
            {
                var response = await client.GetAsync("Language");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LanguageDto>>(json);
            }
        }

        public static async Task<List<LanguageDto>> GetById(int Id)
        {
            using (var client = ProjectNameApiClient.Get())
            {
                var response = await client.GetAsync($"Language/{Id}");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LanguageDto>>(json);
            }
        }

        public static async Task<HttpResponseMessage> Add(LanguageDto data)
        {
            using (var client = ProjectNameApiClient.Get())
            {
                return await client.PostAsync("Language", ProjectNameApiClient.ConvertToContent(data));
            }
        }

        public static async Task<HttpResponseMessage> Update(LanguageDto data)
        {
            using (var client = ProjectNameApiClient.Get())
            {
                return await client.PutAsync("Language", ProjectNameApiClient.ConvertToContent(data));
            }
        }

        public static async Task<HttpResponseMessage> Delete(LanguageDto data)
        {
            using (var client = ProjectNameApiClient.Get())
            {
                return await client.DeleteAsync($"Language/{data.Id}");
            }
        }
    }
}
