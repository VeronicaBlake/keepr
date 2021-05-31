namespace server.Models
{
    public class VaultKeeps
    {
        public int id { get; set; }
        public string creatorId { get; set; }
        public int vaultId { get; set; }
        public int keepId { get; set; }
    }
}