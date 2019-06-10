using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using System.Security.Principal;

namespace ProjectName.Localization
{
    public static class Localizer
    {
        public static string Get(Resources key)
        {
            try
            {
                var defaultLanguage = "es";
                var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0,2);

                var cacheService = new ResourcesCache();
                var json = cacheService.GetOrSet("app.resources",
                                    () => File.ReadAllText(AppContext.BaseDirectory + "\\resources.json"));

                var resources = JsonConvert.DeserializeObject<List<ResourceItem>>(json);
                var item = resources.FirstOrDefault(r => r.Culture.ToLower().Contains(culture.ToLower()) && r.Key.ToLower() == key.ToString().ToLower());
                if (item == null)
                {
                    item = resources.FirstOrDefault(r => r.Culture.ToLower().Contains(defaultLanguage.ToLower()) && r.Key.ToLower() == key.ToString().ToLower());
                }
                return item != null ? item.Value : "(N/D)";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            
        }

        public static void RemoveDuplicate()
        {
            var dir = AppContext.BaseDirectory + "\\resources.json";
            var json = File.ReadAllText(dir);
            var list = JsonConvert.DeserializeObject<List<ResourceItem>>(json);
            var distinctManagedObjects = list.GroupBy(x => x.Key).Select(x => x.First());
            json = JsonConvert.SerializeObject(distinctManagedObjects.ToArray());
            File.WriteAllText(dir, json);
        }
    }
}