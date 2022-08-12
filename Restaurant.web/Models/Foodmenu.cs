
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.web.Models;

namespace Restaurant.web.Model
{
    [Table(name: "FoodMenu")]
    public class Foodmenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int FoodId { get; set; }

        [Required]
        [StringLength(100)]

        public string FoodName { get; set; }
        public int FoodcategoryId { get; set; }
        [ForeignKey(nameof(Foodmenu.FoodcategoryId))]
        public FoodCategory FoodCategory { get; set; }

        [Required]
        [DefaultValue(1)]

        public short Quantity { get; set; }

        [Required]
        [DefaultValue(false)]
        [Display(Name ="Avaialble")]
        public bool Confirmed { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Orders> Orders { get; set; }

        


    }
}

