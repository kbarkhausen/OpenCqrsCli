using System.ComponentModel.DataAnnotations.Schema;

namespace OpenCqrsCli.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }
    }
}
