using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Filters;


namespace WebApplicationRandomOrg.Models
{
    public class WebAppDbContext:DbContext

    {

        public WebAppDbContext() : base("WebAppDbContext")
        {
        }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public System.Data.Entity.DbSet<WebApplicationRandomOrg.Models.Registration> Registrations { get; set; }

        public System.Data.Entity.DbSet<WebApplicationRandomOrg.Models.Login> Logins { get; set; }
    }
}