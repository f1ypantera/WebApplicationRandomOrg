using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;
using System.ComponentModel.DataAnnotations;
using WebApplicationRandomOrg.Filters;

namespace WebApplicationRandomOrg.Controllers
{

    [Authorize(Users = "Admin")]
    public class UserAccountssController : Controller
    {
        private WebAppDbContext db = new WebAppDbContext();

        public async Task<ActionResult> Index()
        {
            var userAccounts = db.UserAccounts.Include(u => u.Role);
            return View(await userAccounts.ToListAsync());
        }

      
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = await db.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

      
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AccountId,UserName,Email,Password,PasswordConfirm,Name,Surname,Year,RoleID")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.UserAccounts.Add(userAccount);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userAccount.RoleID);
            return View(userAccount);
        }

 
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = await db.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userAccount.RoleID);
            return View(userAccount);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AccountId,UserName,Email,Password,PasswordConfirm,Name,Surname,Year,RoleID")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userAccount.RoleID);




            return View(userAccount);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = await db.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }
        public async Task<ActionResult> SelectStaticsByAdmin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = await db.UserAccounts.FindAsync(id);

           
                var result = db.Results.Where(r => r.AccountId == id).Include(r => r.RequestType);

            int GlobalStatistic = await db.Results.Where(r => r.AccountId == id).CountAsync();
            int GlobalStatisticByType1 = await db.Results.Where(r => r.AccountId == id).CountAsync(p => p.RequestTypeID == 1);
            int GlobalStatisticByType2 = await db.Results.Where(r => r.AccountId == id).CountAsync(p => p.RequestTypeID == 2);
            int GlobalStatisticByType3 = await db.Results.Where(r => r.AccountId == id).CountAsync(p => p.RequestTypeID == 3);
            int GlobalStatisticByType4 = await db.Results.Where(r => r.AccountId == id).CountAsync(p => p.RequestTypeID == 4);


            ViewBag.GlobalStatistic = GlobalStatistic;
            ViewBag.GlobalStatisticByType1 = GlobalStatisticByType1;
            ViewBag.GlobalStatisticByType2 = GlobalStatisticByType2;
            ViewBag.GlobalStatisticByType3 = GlobalStatisticByType3;
            ViewBag.GlobalStatisticByType4 = GlobalStatisticByType4;


            return View(await result.ToListAsync());
            
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserAccount userAccount = await db.UserAccounts.FindAsync(id);
            db.UserAccounts.Remove(userAccount);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
