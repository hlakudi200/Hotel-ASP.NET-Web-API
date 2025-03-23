using System.ComponentModel.DataAnnotations;
using Core.Interfaces;


namespace Core.Entities
{
    public class Room : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public bool Booked { get; set; }

         
        //List of Features 

        //
    }

}
