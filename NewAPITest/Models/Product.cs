using System.ComponentModel.DataAnnotations.Schema;

namespace NewAPITest.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
    }
}
