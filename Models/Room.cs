namespace Models
{
    public class Room
    {

        public int RoomType { get; set; }

        public string RoomId { get; set; }

        public bool Available { get; set; }

        public long Price { get; set; }

        public int MaxGuests { get; set; }

        public void UpdatePrice(long NewPrice)
        {
            this.Price = NewPrice;
        }

        public void UpdateAvailability(bool Availability)
        {
            this.Available = Availability;
        }
    }
}