namespace server.Models
{
    public class VaultKeeps : Keep
    {
        public string creatorId { get; set; }
        public int vaultId { get; set; }
        public int keepId { get; set; }
    }
}