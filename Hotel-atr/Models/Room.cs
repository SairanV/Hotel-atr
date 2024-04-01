using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_atr.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
