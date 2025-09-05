using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// The namespace MUST match the folder structure.
namespace MvcWebApp_Wk3v2.Features.Product
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty; // Initialized to prevent null warning

        [Required]
        [Range(0.01, 10000.00)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}

