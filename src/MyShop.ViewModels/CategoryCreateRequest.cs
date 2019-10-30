using System.ComponentModel.DataAnnotations;

namespace MyShop.ViewModels
{
    public class CategoryCreateRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
