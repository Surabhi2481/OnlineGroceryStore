using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{


    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "User ID")]
        [Column(Order = 1)]
        public int UserId { get; set; }


        [Required]
        [Display(Name = "Full Name")]
        [Column(Order = 2)]
        [StringLength(25, MinimumLength = 3)]
        public string fullName { get; set; }



        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [Column(Order = 3)]
        public DateTime? dob { get; set; }


        [Required]
        [Display(Name = "Contact Number")]
        [Column(Order = 4)]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string contactNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        [Column(Order = 5)]
        [StringLength(50, MinimumLength = 3)]
        public string address { get; set; }


        [Required]
        [Display(Name = "Password")]
        [Column(Order = 6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$&])\S{6,20}$",
            ErrorMessage = "Minimum length should be 6 containing alphabets, digits, special characters (All Included)")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Column(Order = 7)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$&])\S{6,20}$",
            ErrorMessage = "Minimum length should be 6 containing alphabets, digits, special characters (All Included)")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }


    }
}
