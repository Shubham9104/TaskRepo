
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training1.web.Models;

namespace Training1.web.Model
{
    [Table(name: "Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]

        public string Title { get; set; }

        [Required]
        [DefaultValue(1)]

        public short NumberOfProducts { get; set; }

        [Required]
        [DefaultValue(false)]

        public bool IsEnabled { get; set; }

        #region Navigation Properties to the Category Model

        public int ProductCategoryId { get; set; }


        [ForeignKey(nameof(Product.ProductCategoryId))]
        public Category ProductCategory { get; set; }

        #endregion
    }
    /**********
   *      CREATE TABLE [Books]
   *      (
   *          [BookId] int NOT NULL
   *          , [BookTitle] nvarchar(100) NOT NULL
   *          , [NumberOfCopies] tinyint NOT NULL DEFAULT(1)
   *          , [IsEnabled] bit NOT NULL DEFAULT (0)                      // 0 is FALSE, 1 is TRUE
   *          , [CategoryId] int NOT NULL
   *          
   *          , CONSTRAINT [PK_Books] 
   *              PRIMARY KEY ( [BookId] ASC)
   *          , CONSTRAINT [FK_Books_Categories_CategoryId] 
   *              FOREIGN KEY [CategoryId] REFERENCES [Categories] ( [CategoryId] )
   *      )
   ***/
}

