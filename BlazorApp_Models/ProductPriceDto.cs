using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp_DataAccess;

namespace BlazorApp_Models
{
    public class ProductPriceDto
    {
        public int PriceId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Pris må være større enn 1.")]
        public double Price { get; set; }
    }
}
