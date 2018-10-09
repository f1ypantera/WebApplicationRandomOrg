using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationRandomOrg.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WebApplicationRandomOrg.Models
{
    public class UserAccount
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int AccountId { get; set; }

        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите свой Имейл")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Введите правильный Имейл")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Потвердите пароль")]
        public string PasswordConfirm { get; set; }


        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Год Рождения")]

        public int Year { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int RoleID { get; set; }

        public string RoleName { get; set; }

    }
    public class UserDbIniziallizer : CreateDatabaseIfNotExists<WebAppDbContext>
    {
        protected override void Seed(WebAppDbContext db)
        {
            Role admin = new Role { RoleName = "Admin" };
            Role users = new Role { RoleName = "Users" };

            db.Roles.Add(admin);
            db.Roles.Add(users);

            db.UserAccounts.Add(new UserAccount
            {
                AccountId = 1,
                UserName = "Ira",
                Email = "Ira@gmail.com",
                Password = "123456",
                PasswordConfirm = "123456",
                Name = "Ира",
                Surname = "Репникова",
                Year = 1996,
                RoleID = 1
            });

            base.Seed(db);
        }
    }
}


  
