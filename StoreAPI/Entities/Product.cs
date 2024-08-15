using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Entities
{
    public class Product
    {

        public int Id { get; set; }

        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int CatId { get; set; }

        [ForeignKey(nameof(CatId))]
        public ProductCategory? Category { get; set; }

    }
}
