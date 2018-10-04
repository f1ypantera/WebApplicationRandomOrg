using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationRandomOrg.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationRandomOrg.Models
{
    public class Registration
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
    }
}