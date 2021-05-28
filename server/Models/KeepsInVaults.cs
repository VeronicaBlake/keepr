namespace server.Models
{
    public class KeepsInVaults : DbItem
    {
        public string CreatorId { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }
    }
}