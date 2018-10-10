using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;

namespace WebApplicationRandomOrg.Controllers
{
    [Authorize]
    public class GenerateNumberController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RandomInteger()
        {
      
            return View();
        }
    }
}