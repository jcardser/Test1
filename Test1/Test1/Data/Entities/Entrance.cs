namespace Test1.Data.Entities
{
    public class Entrance
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
