using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeworkRAI.Models;

namespace HomeworkRAI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View( (List<User>)Session["Users"] );
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var selectedUser = GetUserById(id);
            return View(selectedUser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                Session["UsersCount"] = ((int)Session["UsersCount"]) + 1;

                int id = ((int)Session["UsersCount"]);
                user.Id = id;

                ((List<User>)Session["Users"]).Add(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var selectedUser = GetUserById(id);
            return View(selectedUser);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var updatedUser = GetUserById(id);
                updatedUser.Login = user.Login;
                updatedUser.Password = user.Password;
                updatedUser.Email = user.Email;
                 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var fileList = (List<File>) Session["Files"];
            var selectedUser = GetUserById(id);

            foreach (var file in fileList)
            {
                file.AccesssPrivilages.Remove(id);
            }
            fileList.RemoveAll(x => x.UserId == id);
            
            return View(selectedUser);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var userList = (List<User>) Session["Users"];
                userList.Remove(GetUserById(id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private User GetUserById(int id)
        {
            var userList = (List<User>)Session["Users"];
            return userList.Single(x => x.Id == id);
        }
    }
}
