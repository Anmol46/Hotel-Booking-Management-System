using Microsoft.EntityFrameworkCore;

namespace Models
{

    public class Booking
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string RoomId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int Guests { get; set; }

        public bool Paid { get; set; }

        public bool Completed { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public AppIdentityUser User { get; set; }

    }
}