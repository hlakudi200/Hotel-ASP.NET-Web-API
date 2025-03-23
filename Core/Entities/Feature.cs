using System.ComponentModel.DataAnnotations;
using Core.Interfaces;


namespace Core.Entities
{
    public class Feature : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string FeatureName { get; set; } = string.Empty;
    }


}
