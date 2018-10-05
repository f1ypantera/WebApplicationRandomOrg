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
using System.Net;

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
                        db.UserAccounts.Add(new UserAccount { UserName = registration.UserName, Email = registration.Email, Password = registration.Password, PasswordConfirm = registration.PasswordConfirm, Name = registration.Name, Surname = registration.Surname, Year = registration.Year ,RoleID = 2 });
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
        
        public ActionResult Edit()
        {
            var username = HttpContext.User.Identity.Name;
       
            UserAccount userAccount = db.UserAccounts.FirstOrDefault((a) => a.UserName == username);
         
            return View(userAccount);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,UserName,Email,Password,PasswordConfirm,Name,Surname,Year,RoleID,Role")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(userAccount);
        }

        public ActionResult Delete()
        {
            var username = HttpContext.User.Identity.Name;
            UserAccount userAccount = db.UserAccounts.FirstOrDefault((a) => a.UserName == username);

            return View(userAccount);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "AccountId,UserName,Email,Password,PasswordConfirm,Name,Surname,Year,RoleID")] UserAccount userAccount)
        {
            var username = HttpContext.User.Identity.Name;
            userAccount = db.UserAccounts.FirstOrDefault((a) => a.UserName == username);
            db.UserAccounts.Remove(userAccount);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }






        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }

}