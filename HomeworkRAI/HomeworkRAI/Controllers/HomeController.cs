using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeworkRAI.Models;

namespace HomeworkRAI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Users"] = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Login = "Czapek",
                    Password = "czapek",
                    Email = "czapek@gmail.com"
                },

                new User()
                {
                    Id = 2,
                    Login = "Czapek2",
                    Password = "czapek2",
                    Email = "czapek2@gmail.com"
                },

                new User()
                {
                    Id = 3,
                    Login = "Czapek3",
                    Password = "czapek3",
                    Email = "czapek3@gmail.com"
                },

                new User()
                {
                    Id = 4,
                    Login = "Czapek4",
                    Password = "czapek4",
                    Email = "czapek4@gmail.com"
                },
            };

            Session["UsersCount"] = 4;


            Session["Files"] = new List<File>
            {
                new File
                {
                  Id = 1,
                  AccesssPrivilages  = new List<int> {1,2},
                  MimeType = "type/mime",
                  Name = "Kappa1",
                  UserId = 1
                },

                new File
                {
                  Id = 2,
                  AccesssPrivilages  = new List<int> {1,2},
                  MimeType = "type/mime",
                  Name = "Kappa2",
                  UserId = 2
                },

                new File
                {
                  Id = 3,
                  AccesssPrivilages  = new List<int> {1,2},
                  MimeType = "type/mime",
                  Name = "Kappa3",
                  UserId = 3
                },

                new File
                {
                  Id = 4,
                  AccesssPrivilages  = new List<int> {1,2},
                  MimeType = "type/mime",
                  Name = "Kapp4",
                  UserId = 4
                }
            };

            Session["FilesCount"] = 4;


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