using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Vault : DbItem
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        public string Description { get; set; }
        public string Img { get; set; } = "https://place-hold.it/300x500";
        public bool isPrivate { get; set; }
        public string creatorId { get; set; }
        public Profile Creator { get; set; }

    }
}