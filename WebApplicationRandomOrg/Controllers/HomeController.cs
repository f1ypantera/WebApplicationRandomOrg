using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ninject;

namespace WebApplicationRandomOrg.Controllers
{


    public class HomeController : Controller
    {


      
        
        public HomeController()
        {
           
        }


        public ActionResult Index()
        {
          

            return View();
        }

       
      



    }
}