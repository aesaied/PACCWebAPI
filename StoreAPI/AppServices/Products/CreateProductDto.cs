using System.ComponentModel.DataAnnotations;

namespace StoreAPI.AppServices.Products
{
    public class CreateProductDto
    {
        //public int Id { get; set; }

        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int CatId { get; set; }
    }
}