namespace Models
{
    public class Room
    {

        public int RoomType { get; set; }

        public string RoomId { get; set; }

        public Boolean Available { get; set; }

        public long Price { get; set; }

        public int MaxGuests { get; set; }
    }
}