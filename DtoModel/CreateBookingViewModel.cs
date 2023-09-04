using System.ComponentModel.DataAnnotations;

namespace DtoModel
{

    public class CreateBookingViewModel
    {

        [Required]
        public string UserId { get; set; }

        [Required]
        public string RoomId { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        public int Guests { get; set; }

        [Required]
        public bool Paid { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerPhone { get; set; }
    }
}