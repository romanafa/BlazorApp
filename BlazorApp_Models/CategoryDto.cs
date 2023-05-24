using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Navnet mangler.")]
        public string Name { get; set; }
    }
}
