using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace StoreAPI.Entities
{
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PCId { get; set; }

        [StringLength(100)]
        public required string Name { get; set; }


        public virtual ICollection<Product>? Products { get;set; }
    }
}
