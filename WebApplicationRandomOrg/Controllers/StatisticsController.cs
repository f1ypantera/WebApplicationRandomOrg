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
    public class StatisticsController : Controller
    {
        WebAppDbContext db = new WebAppDbContext();
        

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> SelectStaticsByUserAsync()
        {
            var currentUserName = HttpContext.User.Identity.Name;
            var currentUser = await db.UserAccounts.SingleOrDefaultAsync((u) => u.UserName == currentUserName);      
                var result = db.Results.Where(r => r.AccountId == currentUser.AccountId).Include(r => r.RequestType);
                return View(await result.ToListAsync());
           
           
        }

        public async Task<ActionResult> GlobalStatistic()
        {
            var results = db.Results.Include(r => r.RequestType).Include(r => r.UserAccount);
            return View(await results.ToListAsync());
        }




        }
}