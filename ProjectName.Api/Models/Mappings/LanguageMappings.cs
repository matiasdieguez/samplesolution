using System.Collections.Generic;
using System.Linq;
using ProjectName.Dto;
using ProjectName.Api.Models.Entities;

namespace ProjectName.Api.Models.Mappings
{
    public static class LanguageMappings
    {
        public static List<LanguageDto> ToDto(this List<Language> data)
        {
            var list = data.Select(c => c.ToDto()).ToList();
            return list;
        }

        public static List<Language> FromDto(this List<LanguageDto> data)
        {
            var list = data.Select(c => c.FromDto()).ToList();
            return list;
        }

        public static LanguageDto ToDto(this Language data)
        {
            return new LanguageDto
            {
                Id = data.Id,
                Active = data.Active,
                Name = data.Name
            };
        }

        public static Language FromDto(this LanguageDto data)
        {
            return new Language
            {
                Id = data.Id,
                Active = data.Active,
                Name = data.Name
            };
        }

        public static void FromDto(this Language originalData, LanguageDto newData)
        {
            originalData.Id = newData.Id;
            originalData.Active = newData.Active;
            originalData.Name = newData.Name;
            
        }
    }
}