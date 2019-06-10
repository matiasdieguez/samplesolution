using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectName.Api.Models.Entities
{
    [Table(ModelConstants.LanguagesTableName, Schema = ModelConstants.dbo)]
    public class Language 
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)] 
        public string Name { get; set; }

        [Required]
        public bool Active { get; set;}
    }
}
