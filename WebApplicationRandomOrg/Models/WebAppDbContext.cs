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
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<StatisticsByUser> StatisticsByUsers { get; set; }
        public DbSet<GlobalStatisctic> GlobalStatisctics { get; set; }
 


        public System.Data.Entity.DbSet<WebApplicationRandomOrg.Models.Registration> Registrations { get; set; }
        public System.Data.Entity.DbSet<WebApplicationRandomOrg.Models.Login> Logins { get; set; }


        public class UserDbIniziallizer : CreateDatabaseIfNotExists<WebAppDbContext>
        {
            protected override void Seed(WebAppDbContext db)
            {

                db.Roles.Add(new Role { RoleID = 1, RoleName = "Admin" });
                db.Roles.Add(new Role { RoleID = 2, RoleName = "Users" });

                db.RequestTypes.Add(new RequestType { RequestTypeID = 1, NameType = "RandomNumber" });
                db.RequestTypes.Add(new RequestType { RequestTypeID = 2, NameType = "RandomPassword" });
                db.RequestTypes.Add(new RequestType { RequestTypeID = 3, NameType = "ListOfRandomNumbers" });
                db.RequestTypes.Add(new RequestType { RequestTypeID = 4, NameType = "ListOfRandomPasswords" });
                db.RequestTypes.Add(new RequestType { RequestTypeID = 5, NameType = "RandomWord" });
                db.RequestTypes.Add(new RequestType { RequestTypeID = 6, NameType = "Date" });
                db.RequestTypes.Add(new RequestType { RequestTypeID = 7, NameType = "RandomPointOnTheMap" });

                db.UserAccounts.Add(new UserAccount
                {
                    AccountId = 1,
                    UserName = "Admin",
                    Email = "Admin@gmail.com",
                    Password = "123456",
                    PasswordConfirm = "123456",
                    Name = "Admin",
                    Surname = "Admin",
                    Year = 1992,
                    RoleID = 1

                });

                base.Seed(db);
            }
        }
    }

   
}