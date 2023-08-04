using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary1.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9 ]+$", ErrorMessage = "Title contains alphabets and number only.")]
        public string Title { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z ]+$", ErrorMessage = "Author name must contains alphabets only.")]
        public string Author { get; set; }

        public string Genre { get; set; }
        [Required]
        [Range(0, 500)]
        public int QuantityInStock { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Upload Image")]
        public string CoverImage { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
