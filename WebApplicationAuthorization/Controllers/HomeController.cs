using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json;
using WebApplicationAuthorization.Models;
using System.IO;

namespace WebApplicationAuthorization.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //MyUser u = new MyUser { Login = "su", Password = "admin" };
            //var jsonUser = JsonConvert.SerializeObject(u);
            ////сохранение в файл
            //using (StreamWriter sw = new StreamWriter(Server.MapPath("~/App_Data/users.txt")))
            //{   
            //    sw.WriteLine(jsonUser);
            //}
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MyUser myUser)
        {
            UsersDb ubd = new UsersDb();
            //построчное чтение и сохранение в лист
            using (StreamReader sr = new StreamReader(Server.MapPath("~/App_Data/users.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var user = JsonConvert.DeserializeObject<MyUser>(line);
                    ubd.Users.Add(user);
                }
            }
            foreach  (var item in ubd.Users)
            {
                if (item.Login == myUser.Login && item.Password == myUser.Password)
                {
                    ViewBag.Logins = ubd.Users; 
                    return View("ShowLogins");   
                }
            }
            ViewBag.Message = "Что-то пошло не так :(";
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}