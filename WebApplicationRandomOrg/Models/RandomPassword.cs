using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationRandomOrg.Models
{
    public class RandomPassword
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Включить нижний регистр")]
        public bool includeLowerCase { get; set; }
        [Display(Name = "Включить верхний регистр")]
        public bool includeUpperCase { get; set; }
        [Display(Name = "Включить числа")]
        public bool includeNumber { get; set; }
        [Display(Name = "Включить специальные числа")]
        public bool includeSpecial { get; set; }
        [Required]
        [Display(Name = "Длинна пароля")]
        public int  lengthofPassword { get; set; }
    }
}