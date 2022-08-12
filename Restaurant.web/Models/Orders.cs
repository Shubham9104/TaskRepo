using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.web.Model;

namespace Restaurant.web.Models
{
    [Table(name: "Orders")]
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        [DefaultValue(1)]

        public short Quantity { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]

        public string OrderName { get; set; }

        #region Navigation Properties to the Book Model
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Orders.CustomerId))]
        public Customers Customers { get; set; }

        public int FoodId { get; set; }

        [ForeignKey(nameof(Orders.FoodId))]
        public Foodmenu Foodmenu { get; set; }



        #endregion
    }
}
