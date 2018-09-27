using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationRandomOrg.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationRandomOrg.Models
{
    public class UserAccount
    {
        [Key]
        
        public int AccountId { get; set; }

        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Введите свой Имейл")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Введите правильный Имейл")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Year { get; set; }

    }
}