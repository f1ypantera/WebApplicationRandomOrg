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
        public DbSet<Role> Roles { get; set; }

        public System.Data.Entity.DbSet<WebApplicationRandomOrg.Models.Registration> Registrations { get; set; }

        public System.Data.Entity.DbSet<WebApplicationRandomOrg.Models.Login> Logins { get; set; }
    }

    public class UserDbIniziallizer: DropCreateDatabaseAlways<WebAppDbContext>
    {
        protected override void Seed(WebAppDbContext db)
        {
            db.Roles.Add(new Role { RoleID = 1, RoleName = "Admin" });
            db.Roles.Add(new Role { RoleID = 2, RoleName = "User" });

            db.UserAccounts.Add(new UserAccount { AccountId = 1,UserName = "Ira" , Email = "Ira@gmail.com" , Password = "123456" , PasswordConfirm = "123456",
                Name = "Ира", Surname = "Репникова" , Year = 1996,RoleID = 1
            });

            base.Seed(db);
        }
    }
}