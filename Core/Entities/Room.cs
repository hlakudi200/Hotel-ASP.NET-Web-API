using System.Collections.ObjectModel;
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
        public bool Locked { get; set; }
        public Collection<RoomFeature> RoomFeatures { get; set; }
    }

}
