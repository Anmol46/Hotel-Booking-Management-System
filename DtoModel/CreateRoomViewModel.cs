using System.ComponentModel.DataAnnotations;

namespace DtoModel {

    public class CreateRoomViewModel {

        [Required(ErrorMessage = "Room Type is required.")]
        public int RoomType { get; set; }

        [Required]
        public bool Available { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public long Price { get; set; }

        [Required]
        public int MaxGuests { get; set; }
    }
}