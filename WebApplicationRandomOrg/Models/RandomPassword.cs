using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationRandomOrg.Models
{
    public class RandomPassword
    {
        public int Id { get; set; }
        public bool includeLowerCase { get; set; }
        public bool includeUpperCase { get; set; }
        public bool includeNumber { get; set; }
        public bool includeSpecial { get; set; }
        public int  lengthofPassword { get; set; }
    }
}