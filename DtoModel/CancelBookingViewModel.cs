using System.ComponentModel.DataAnnotations;

namespace DtoModel
{

    public class CancelBookingViewModel
    {
        [Required]
        public string BookingId { get; set; }
    }
}