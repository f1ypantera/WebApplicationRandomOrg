using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplicationRandomOrg.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationRandomOrg.Models
{
    public class Result
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ResultId { get; set; }

        [ForeignKey("UserAccount")]
        public int AccountId { get; set; }
        public UserAccount UserAccount { get; set; }


        [ForeignKey("RequestType")]
        public int RequestTypeID { get; set; }
        [Display(Name = "Тип запроса")]
        public RequestType RequestType { get; set; }
        [Display(Name = "Результат")]
        public string OutPutResult { get; set; }



    }
}