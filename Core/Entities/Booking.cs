using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Interfaces;


namespace Core.Entities
{
    public class Booking:IEntity
    {
        [Key] 
        public int Id { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client client { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room room { get; set; } 
        public int persons { get; set; }    
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }   
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }


}
