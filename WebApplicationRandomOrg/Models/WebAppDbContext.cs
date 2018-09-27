using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace WebApplicationRandomOrg.Models
{
    public class WebAppDbContext:DbContext

    {

        public WebAppDbContext() : base("WebAppDbContext")
        {
        }
        public DbSet<UserAccount> UserAccounts { get; set; }

       
    }
}