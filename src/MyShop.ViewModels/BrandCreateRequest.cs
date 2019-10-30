using System.ComponentModel.DataAnnotations;

namespace MyShop.ViewModels
{
    public class BrandCreateRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
