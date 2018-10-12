using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Web.Security;
using System.Web.Helpers;


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
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
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

        [Display(Name = "Статус")]
        public string RoleName { get; set; }


    }

  

}


  
