using System.ComponentModel.DataAnnotations;

namespace CMS_Shopping_Cart.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum lengrh is 2")]
        [RegularExpression(@"^[a-zA-Z-]+$", ErrorMessage = "Only letters are allowed!")]
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Sorting { get; set; }

    }
}
