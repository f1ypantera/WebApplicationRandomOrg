using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WebApplicationRandomOrg.Controllers
{
    public class AccountController : Controller
    {
        WebAppDbContext db = new WebAppDbContext();
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
            using (WebAppDbContext db = new WebAppDbContext()) {
                var usr = db.UserAccounts.SingleOrDefault(m => m.UserName == userAccount.UserName && m.Password == userAccount.Password);
                if (usr != null)
                {
                    Session["LoginSuccess"] = userAccount;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["LoginSuccess"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyAccount()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteUser(int AccountId)
        {
            if (ModelState.IsValid)
            {
                using (WebAppDbContext db = new WebAppDbContext())
                {
                    var  deleteUser = db.UserAccounts.Find(AccountId);
                    db.UserAccounts.Remove(deleteUser);
                    db.SaveChanges();
                }
                
                

            }
            return RedirectToAction("Index","Home");
         
        }

        public ActionResult UserView()
        {
            return View(db.UserAccounts);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Edit(UserAccount userAccount)
        {
            db.Entry(userAccount).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }

}