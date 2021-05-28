namespace server.Models
{
    public class Vault : DbItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isPrivate { get; set; }
        public string creatorId { get; set; }
        public Profile Creator { get; set; }

    }
}