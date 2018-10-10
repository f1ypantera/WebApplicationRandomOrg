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

namespace WebApplicationRandomOrg.Services
{
    public class AccountService
    {
        WebAppDbContext db = new WebAppDbContext();

        public UserAccount GetCurrentUser()
        {
            var user = HttpContext.Current.User.Identity.Name;
            var currentUser  = db.UserAccounts.SingleOrDefault((a) => a.UserName == user);
            return currentUser;
            
        }
    }
}