using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationRandomOrg.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebApplicationRandomOrg.Models
{
    public class Coments
    {
        [Key]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Отзыв")]
        public string Subject { get; set; }

    }
}