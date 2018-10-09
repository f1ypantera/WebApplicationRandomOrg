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
    public class GlobalStatisctic
    {


        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int GlabalStatiscticId { get; set; }

        [ForeignKey("RequestType")]
        public int RequestTypeID { get; set; }
        public RequestType RequestType { get; set; }

        public int TotalByType { get; set; }
        public int OverallTotal { get; set; }
    }
}