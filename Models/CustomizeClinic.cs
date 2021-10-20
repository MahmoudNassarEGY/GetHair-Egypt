using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GetHair_Egypt.Models
{
    [MetadataType(typeof(ClinicMetaData))]
    public partial class Clinic
    {

        //Add methods or add new properties
        [Display(Name = "Confirm Email")]
        [Required]
        [Compare("Email", ErrorMessage ="Email and Confirm Email must match")]
        public string confEmail { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        [Required]
        public string confPassword { get; set; }

    }
    public class ClinicMetaData
    {


        //edit properties
        [Display(Name ="Clinic")]
        [Required]
        public string CName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b", ErrorMessage ="Invalid Email Format")]
        public string Email { get; set; }



        [Display(Name = "Website")]
        public string CUrl { get; set; }

        [Required]
        [StringLength (15 ,MinimumLength = 8, ErrorMessage ="Password must be at least 8 charactrs and maximum 15 characters")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})", ErrorMessage = "Password must contain at least 1 uppercase letter, 1 lowercase letter, 1 number and 1 special character")]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Image 1")]
        [Required]
        public string CImage1 { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Image 2 ")]
        public string CImage2 { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Image 3")]
        public string CImage3 { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Image 4 ")] 
        public string CImage4 { get; set; }

        [Required]
        public string Description { get; set; }
    }
}