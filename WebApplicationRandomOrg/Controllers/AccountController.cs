using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Security;

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
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                UserAccount userAccount = null;
                using(WebAppDbContext db = new WebAppDbContext())
                {
                    userAccount = db.UserAccounts.FirstOrDefault(u => u.UserName == registration.UserName);
                }
                if(userAccount == null)
                {
                    using (WebAppDbContext db = new WebAppDbContext())
                    {
                        db.UserAccounts.Add(new UserAccount { UserName = registration.UserName, Email = registration.Email, Password = registration.Password ,PasswordConfirm = registration.PasswordConfirm, Name = registration.Name,Surname = registration.Surname, Year = registration.Year });
                        db.SaveChanges();

                        userAccount = db.UserAccounts.Where(u => u.UserName == registration.UserName && u.Password == registration.Password).FirstOrDefault();
                    }
                    if (userAccount != null)
                    {
                        FormsAuthentication.SetAuthCookie(registration.UserName, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }

            }
            return View(registration);

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                UserAccount userAccount = null;
                using (WebAppDbContext db = new WebAppDbContext())
                {
                    userAccount = db.UserAccounts.FirstOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);
                }
                if (userAccount != null)
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
           
            return View(login);
        }

        public ActionResult Logout()
        {
            Session["LoginSuccess"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyAccount()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult DeleteUser()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult DeleteUser(int AccountId)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (WebAppDbContext db = new WebAppDbContext())
        //        {
        //            var  deleteUser = db.UserAccounts.Find(AccountId);
        //            db.UserAccounts.Remove(deleteUser);
        //            db.SaveChanges();
        //        }
                
                

        //    }
        //    return RedirectToAction("Index","Home");
         
        //}

        public ActionResult UserView()
        {
            return View(db.UserAccounts);
        }

        //[HttpGet]
        //public ActionResult Edit()
        //{
            
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Edit(UserAccount userAccount)
        //{
        //    db.Entry(userAccount).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }

}