using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Mvc.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType =typeof(ModelResource),ErrorMessageResourceName ="UserName")]
        public string UserName { get; set; }

        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }

        public DateTime? Birthday { get; set; }


    }
}