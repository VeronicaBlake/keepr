namespace server.Models
{
    public class Keep : DbItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int Views { get; set; }
        public int Shares { get; set; }
        public int Keeps { get; set; }
        public int CreatorId { get; set; }
        public Profile Creator { get; set; }

    }
}