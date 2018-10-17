using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplicationRandomOrg.Models;

namespace WebApplicationRandomOrg.Models
{
    public class RequestType
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int RequestTypeID { get; set;}
        [Display(Name = "Тип запроса")]
        public string NameType { get; set; }
    }
}