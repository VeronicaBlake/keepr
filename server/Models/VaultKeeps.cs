namespace server.Models
{
    public class VaultKeeps : DbItem
    {
        public string creatorId { get; set; }
        public string vaultId { get; set; }
        public string keepid { get; set; }
    }
}