using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpecials.MVVM.Models
{
    public class Specials
    {
        [Required]
        public string RestaurantName { get; set; }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string SpecialName { get; set; }
        [Required]
        public string Dates { get; set; }
        [Required]
        public string FullAdress { get; set; }
        [Required]
        public float FullPrice { get; set; }
        [Required]
        public float DiscountedPrice { get; set; }
        public string? ImageString { get; set; }
        public ImageSource? Image_Source { get; set; }
        public string SpecialDescription { get; set; }
    }
}
