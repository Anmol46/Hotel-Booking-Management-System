using System.ComponentModel.DataAnnotations;
using Enums;

namespace DtoModel {

    public class CreateRoomViewModel {

        [Required(ErrorMessage = "Room Type is required.")]
        [EnumDataType(typeof(RoomType), ErrorMessage = "Room Type not available.")]
        public RoomType RoomType { get; set; }

        [Required]
        public bool Available { get; set; }

        [Required]
        public long Price { get; set; }

        [Required]
        public int MaxGuests { get; set; }
    }
}