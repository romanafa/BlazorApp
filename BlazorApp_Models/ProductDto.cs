using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        public string Color { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public bool IsCustomersFavorite { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Vennligst velg kategori")]
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
