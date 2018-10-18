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
using System.Data.SqlClient;

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

            int GlobalStatistic = await db.Results.Where(r => r.AccountId == currentUser.AccountId).CountAsync();
            int GlobalStatisticByType1 = await db.Results.Where(r => r.AccountId == currentUser.AccountId).CountAsync(p => p.RequestTypeID == 1);
            int GlobalStatisticByType2 = await db.Results.Where(r => r.AccountId == currentUser.AccountId).CountAsync(p => p.RequestTypeID == 2);
            int GlobalStatisticByType3 = await db.Results.Where(r => r.AccountId == currentUser.AccountId).CountAsync(p => p.RequestTypeID == 3);
            int GlobalStatisticByType4 = await db.Results.Where(r => r.AccountId == currentUser.AccountId).CountAsync(p => p.RequestTypeID == 4);
            int GlobalStatisticByType5 = await db.Results.Where(r => r.AccountId == currentUser.AccountId).CountAsync(p => p.RequestTypeID == 5);

            ViewBag.GlobalStatistic = GlobalStatistic;
            ViewBag.GlobalStatisticByType1 = GlobalStatisticByType1;
            ViewBag.GlobalStatisticByType2 = GlobalStatisticByType2;
            ViewBag.GlobalStatisticByType3 = GlobalStatisticByType3;
            ViewBag.GlobalStatisticByType4 = GlobalStatisticByType4;
            ViewBag.GlobalStatisticByType5 = GlobalStatisticByType5;

            return View(await result.ToListAsync());
           
           
        }

        public async Task<ActionResult> GlobalStatistic()
        {
            var results = db.Results.Include(r => r.RequestType).Include(r => r.UserAccount);

            int GlobalStatistic = await db.Results.CountAsync();
            int GlobalStatisticByType1 = await db.Results.CountAsync(p=>p.RequestTypeID == 1);
            int GlobalStatisticByType2 = await db.Results.CountAsync(p => p.RequestTypeID == 2);
            int GlobalStatisticByType3 = await db.Results.CountAsync(p => p.RequestTypeID == 3);
            int GlobalStatisticByType4 = await db.Results.CountAsync(p => p.RequestTypeID == 4);
            int GlobalStatisticByType5 = await db.Results.CountAsync(p => p.RequestTypeID == 5);


            ViewBag.GlobalStatistic = GlobalStatistic;
            ViewBag.GlobalStatisticByType1 = GlobalStatisticByType1;
            ViewBag.GlobalStatisticByType2 = GlobalStatisticByType2;
            ViewBag.GlobalStatisticByType3 = GlobalStatisticByType3;
            ViewBag.GlobalStatisticByType4 = GlobalStatisticByType4;
            ViewBag.GlobalStatisticByType5 = GlobalStatisticByType5;

            return View(await results.ToListAsync());
        }

        public async Task<ActionResult> GlobalStatisticByUserType()
        {
            var results = db.Results.Include(r => r.RequestType).Include(r => r.UserAccount);

            return View(await results.ToListAsync());
        }

    }
}