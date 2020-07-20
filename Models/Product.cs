using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public enum Available
    {
        Yes,
        No
    }

    public class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product Id")]
        public int productId { get; set; }

        [Required]
        [ForeignKey("fKey")]
        [Display(Name = "User Id")]
        public int userId { get; set; }
        public virtual User fKey { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string productName { get; set; }


        [Required(ErrorMessage = "Takes value as Yes or No")]
        [Display(Name = "Availability")]
        public Available availability { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]
        public int price { get; set; }


    }
}
