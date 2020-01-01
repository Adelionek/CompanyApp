using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompanyApp.Models.ViewModel
{
    public class UserSingupView
    {
        [Key]
        public int userID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string passwd { get; set; }

        //public int role_id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Date of birth")]
        public System.DateTime dateOfBirth { get; set; }
    }

    public class UserLoginView
    {
        [Key]
        public int userID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string passwd { get; set; }

    }

    public class UserProfileView
    {
        [Key]
        public int userID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }


    }


    public class UserDataView
    {

    }
}

