﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationRandomOrg.Services;

namespace WebApplicationRandomOrg.Controllers
{
    [Authorize]
    public class GenerateNumberController : Controller
    {
        WebAppDbContext db = new WebAppDbContext();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RandomIntDouble()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RandomInt(int min,int max)
        {
            Random rnd = new Random();
            int res = rnd.Next(min, max);
            ViewBag.output = res;
            
        
           var currentUserName = HttpContext.User.Identity.Name;
           var currentUser = db.UserAccounts.SingleOrDefault((u) => u.UserName == currentUserName);

            var result = new Result()
            {
                OutPutResult = res.ToString(),
                UserAccount = currentUser,
                RequestType = db.RequestTypes.SingleOrDefault((t) => t.RequestTypeID == 1)
            };

            db.Results.Add(result);
            db.SaveChanges();
            

            return View("RandomIntDouble");
        }

        [HttpPost]
        public ActionResult RadndomDouble (double min ,double max)
        {
            Random rnd = new Random();

            double res = rnd.NextDouble() * (max + min) - min;
            ViewBag.output = res;

            var currentUserName = HttpContext.User.Identity.Name;
            var currentUser = db.UserAccounts.SingleOrDefault((u) => u.UserName == currentUserName);

            var result = new Result()
            {
                OutPutResult = res.ToString(),
                UserAccount = currentUser,
                RequestType = db.RequestTypes.SingleOrDefault((t) => t.RequestTypeID == 1)
            };

            db.Results.Add(result);
            db.SaveChanges();
            return View("RandomIntDouble");
        }





    }
}