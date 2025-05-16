using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormsApp.Models{
    public class Product{

        [BindNever]
        [Display(Name = "Urun ID")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]  //max 50 karakter
        [Display(Name = "Urun Adı")]
        public string? Name { get; set; }

        [Required]
        [Range(0,150000)]
        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }

        [Required]
        [Display(Name = "Resim")]
        public string? Image { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
    }
}