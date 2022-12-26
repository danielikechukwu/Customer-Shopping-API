using System.ComponentModel.DataAnnotations;

namespace ConstumerShoppingMVC.Models
{
    public class ProductViewModel
    {
        [Display(Name="ID")]
        public int Id { get; set; }

        [Display(Name = "Picture Image")]
        public string? ImageURL { get; set; }

        [Display(Name = "Picture Name")]
        public string? Name { get; set; }

        [Display(Name = "Picture Price")]
        public double? Price { get; set; }
    }
}
