namespace SmartHotel.Clients.Core.Models
{
    public class Chat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public List<Messages> Messages { get; set; }

        public override string ToString() => $"{Name}";

    }
}
