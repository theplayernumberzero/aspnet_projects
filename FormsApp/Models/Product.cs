using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormsApp.Models{
    public class Product{
        [BindNever]
        [Display(Name = "Urun ID")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Urun Adı")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "Resim")]
        public string Image { get; set; } = string.Empty;
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}