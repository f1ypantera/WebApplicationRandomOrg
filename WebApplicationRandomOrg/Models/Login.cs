using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationRandomOrg.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationRandomOrg.Models
{
    public class Login
    {

        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int AccountId { get; set; }


        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}