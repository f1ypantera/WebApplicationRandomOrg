using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationRandomOrg.Controllers
{
    public class GenerateNumberController : Controller
    {
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}