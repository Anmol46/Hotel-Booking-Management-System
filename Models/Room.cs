namespace Models
{
    public class Room
    {

        public RoomType RoomType { get; set; }

        public string RoomId { get; set; }

        public Boolean Available { get; set; }

        public long Price { get; set; }

        public int MaxGuests { get; set; }
    }
}