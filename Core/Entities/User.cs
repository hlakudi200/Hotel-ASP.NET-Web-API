using System.ComponentModel.DataAnnotations;
using Core.Interfaces;


namespace Core.Entities
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public  string Email { get; set; }=string.Empty;
        public  string Role { get; set; }=string.Empty ;
        public  string PasswordHash { get; set; }=string.Empty;

    }

   }
