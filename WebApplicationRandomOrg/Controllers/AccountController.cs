using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;



namespace WebApplicationRandomOrg.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                using (WebAppDbContext db = new WebAppDbContext())
                {
                    db.UserAccounts.Add(userAccount);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.message = userAccount.Name + " " + userAccount.Surname + "Успешно зарегестрирован";

            }
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount userAccount)
        {
            
            return View();
        }


    }
}