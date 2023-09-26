using System.ComponentModel.DataAnnotations;

namespace DtoModel
{

    public class UpdateRoomPriceViewModel
    {
        [Required]
        public string RoomId { get; set; }

        [Required]
        public long NewPrice { get; set; }
    }
}