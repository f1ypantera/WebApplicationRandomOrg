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
        WebAppDbContext db = new WebAppDbContext();

        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult CommentsMethod()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CommentsMethod(Coments coments)
        {

            return View();
        }







    }
}