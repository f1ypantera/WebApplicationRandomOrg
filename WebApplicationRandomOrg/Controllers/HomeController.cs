using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ninject;
using System.Threading.Tasks;

namespace WebApplicationRandomOrg.Controllers
{
    
    public class HomeController : Controller
    {
        WebAppDbContext db = new WebAppDbContext();

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult About()
        {

            return View();
        }
        [HttpGet]
        public ActionResult CommentsMethod()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CommentsMethod(Coments coments)
        {
            if (ModelState.IsValid)
            {                
                using(WebAppDbContext db = new WebAppDbContext())
                {
                    db.Comentss.Add(new Coments { FirstName = coments.FirstName, LastName = coments.LastName, Subject = coments.Subject });
                 
                    await db.SaveChangesAsync();
                }
              
            }
            else
            {
                ModelState.AddModelError("", "Не правильно введен фидбек");
            }
            ViewBag.message = "Спасибо за отзыв";
            return View("Index");
        }
    }
}