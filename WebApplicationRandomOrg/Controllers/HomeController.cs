using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationRandomOrg.Controllers
{
    public class HomeController : Controller
    {

        WebAppDbContext db = new WebAppDbContext();

      
        public ActionResult Index()
        {
          

            return View();
        }

       
      



    }
}