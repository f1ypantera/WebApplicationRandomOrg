using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationRandomOrg.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplicationRandomOrg.Models
{
    public class RandomDate
    {
        [Key]
        public int KeyId { get; set; }
        [Required]
        [Range(1, 31, ErrorMessage = "Недопустимый день")]
        [Display(Name = "Левая граница дня")]
        public int minDate { get; set; }
        [Required]
        [Display(Name = "Правая граница дня")]
        [Range(1, 31, ErrorMessage = "Недопустимый день")]
        public int maxDate { get; set; }
        [Required]
        [Display(Name = "Левая граница месяца")]
        [Range(1, 12, ErrorMessage = "Недопустимый месяц")]
        public int minMonth { get; set; }
        [Required]
        [Display(Name = "Правая граница месяца")]
        [Range(1, 12, ErrorMessage = "Недопустимый месяц")]
        public int maxMonth { get; set; }
        [Required]
        [Display(Name = "Левая граница года")]
        [Range(0, 2018, ErrorMessage = "Недопустимый год")]
        public int minYear { get; set; }
        [Required]
        [Display(Name = "Правая граница года")]
        [Range(0, 2018, ErrorMessage = "Недопустимый год")]
        public int maxYear { get; set; }


        

    }
}