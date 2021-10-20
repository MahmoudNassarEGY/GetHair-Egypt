using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetHair_Egypt.Models
{
    [MetadataType(typeof(ClientMetaData))]
    public partial class Client
    {
        // Add methods or add new property
       [NotMapped]
        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Email and Confirm Email must match")]
        public string confEmail { get; set; }
        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string confPassword { get; set; }
      
    }

    public class ClientMetaData
    {
        //edit properties

        public int UserID { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FName { get; set; }
        [Required]

        [Display(Name = "Last Name")]
        public string LName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public Nullable<System.DateTime> DOB { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must be at least 8 charactrs and maximum 15 characters")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})", ErrorMessage = "Password must contain at least 1 uppercase letter, 1 lowercase letter, 1 number and 1 special character")]
        public string Password { get; set; }
    }
}