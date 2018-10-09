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
    public class StatisticsByUser
    {

        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int StatisticsByUserID { get; set; }

        [ForeignKey("UserAccount")]
        public int AccountId { get; set; }
        public UserAccount UserAccount { get; set; }


        [ForeignKey("RequestType")]
        public int RequestTypeID { get; set; }
        public RequestType RequestType { get; set; }

        public int Quantity { get; set; }
    }
}