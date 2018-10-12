using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplicationRandomOrg.Models;

namespace WebApplicationRandomOrg.Controllers
{
    [Authorize]
    public class GenerateNumberController : Controller
    {
        WebAppDbContext db = new WebAppDbContext();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RandomIntDouble()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RandomInt(int min,int max)
        {
            Random rnd = new Random();
            int res = rnd.Next(min, max);
            ViewBag.output = res;
            
        
           var currentUserName = HttpContext.User.Identity.Name;
           var currentUser = db.UserAccounts.SingleOrDefault((u) => u.UserName == currentUserName);

            var result = new Result()
            {
                OutPutResult = res.ToString(),
                UserAccount = currentUser,
                RequestType = db.RequestTypes.SingleOrDefault((t) => t.RequestTypeID == 1)
            };

            db.Results.Add(result);
            db.SaveChanges();
            

            return View("RandomIntDouble");
        }

        [HttpPost]
        public ActionResult RadndomDouble (double min ,double max)
        {
            Random rnd = new Random();

            double res = rnd.NextDouble() * (max + min) - min;
            ViewBag.output = res;

            var currentUserName = HttpContext.User.Identity.Name;
            var currentUser = db.UserAccounts.SingleOrDefault((u) => u.UserName == currentUserName);

            var result = new Result()
            {
                OutPutResult = res.ToString(),
                UserAccount = currentUser,
                RequestType = db.RequestTypes.SingleOrDefault((t) => t.RequestTypeID == 1)
            };

            db.Results.Add(result);
            db.SaveChanges();
            return View("RandomIntDouble");
        }



        [HttpGet]
        public ActionResult RandomPassword()
        {

            return View();
        }



        [HttpPost]
        public ActionResult RandomPassword(RandomPassword randomPassword)
        {

            const string LowerCase_Characters = "abcdefghijklmnopqrstuvwxyz";
            const string UpperCase_Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NumberCase_Characters = "0123456789";
            const string Special_Characters = @"!#$%&*@\";           
            const int Password_LENGTH_MIN = 8;
            const int Password_LENGTH_MAX = 128;
            const int Maximum_Identical_Chars = 2;
            

            if (randomPassword.lengthofPassword <Password_LENGTH_MIN || randomPassword.lengthofPassword > Password_LENGTH_MAX)
            {
                ViewBag.Error = "Пароль должен быть не менее 8 символов";
                
            }
            
            string characterSet = "";

            if (randomPassword.includeLowerCase)
            {
                characterSet += LowerCase_Characters;
            }
            if (randomPassword.includeUpperCase)
            {
                characterSet += UpperCase_Characters;

            }
         
            if (randomPassword.includeSpecial)
            {
                characterSet += Special_Characters;
            }
            if (randomPassword.includeNumber)
            {
                characterSet += NumberCase_Characters;

            }

            char[] password = new char[randomPassword.lengthofPassword];

            int characterSetLenght = characterSet.Length;

            Random pass = new Random();

            for (int characterPosition  = 0; characterPosition < randomPassword.lengthofPassword; characterPosition++)
            {
                password[characterPosition] = characterSet[pass.Next(characterSetLenght - 1)];

                

            }

            string ArrayPassword = string.Join(null, password);

            ViewBag.outputPass = ArrayPassword;

            return View();
        }





        [HttpGet]
        public ActionResult ListRandomNumbers()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ListRandomNumbers(int min,int max,int quntityelements)
        {

            List<int> numbers = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i<quntityelements; i++)
            {
                numbers.Add(rnd.Next(min, max));
                
            }

            string ArrayString = String.Join(",", numbers);

            ViewBag.output = ArrayString;

            var currentUserName = HttpContext.User.Identity.Name;
            var currentUser = db.UserAccounts.SingleOrDefault((u) => u.UserName == currentUserName);

            var result = new Result()
            {
                OutPutResult = ArrayString.ToString(),
                UserAccount = currentUser,
                RequestType = db.RequestTypes.SingleOrDefault((t) => t.RequestTypeID == 3)
            };

            db.Results.Add(result);
            db.SaveChanges();


            return View();
        }

        [HttpGet]
        public ActionResult SelectRandomWords()
        {

            return View();
        }



    }
}