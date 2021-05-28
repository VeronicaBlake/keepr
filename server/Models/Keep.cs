using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Keep : DbItem
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        public string Description { get; set; }
        public string Img { get; set; } = "https://place-hold.it/300x500";
        public int Views { get; set; } = 0;
        public int Shares { get; set; } = 0;
        public int Keeps { get; set; } = 0;
        public int CreatorId { get; set; }
        public Profile Creator { get; set; }

    }
}