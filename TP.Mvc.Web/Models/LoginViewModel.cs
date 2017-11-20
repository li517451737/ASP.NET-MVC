using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Mvc.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType =typeof(ModelResource),ErrorMessageResourceName ="UserName")]
        public string UserName { get; set; }

    }
}