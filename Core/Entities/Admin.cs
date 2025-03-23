using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Interfaces;



namespace Core.Entities
{
    public class Admin:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; } 
        public string StaffNo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string IdNumber { get; set; }=string.Empty;
        [EmailAddress]
        public string EmailAddress { get; set; }=string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; } = string.Empty;
    }

}
