using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeworkRAI.Models;

namespace HomeworkRAI.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            Dictionary<int, string> userIdLoginDictionary = GenerateIdLoginDictionary();
            ViewBag.UserDictionary = userIdLoginDictionary;
            return View((List<File>)Session["Files"]);
        }

        // GET: File/Details/5
        public ActionResult Details(int id)
        {
            Dictionary<int, string> userIdLoginDictionary = GenerateIdLoginDictionary();
            ViewBag.UserDictionary = userIdLoginDictionary;

            var selectedFile = GetFileById(id);

            return View(selectedFile);
        }

        // GET: File/Create
        public ActionResult Create()
        {
            Dictionary<int, string> userIdLoginDictionary = GenerateIdLoginDictionary();
            ViewBag.UserDictionary = userIdLoginDictionary;

            return View();
        }

        // POST: File/Create
        [HttpPost]
        public ActionResult Create(File file)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                Session["FilesCount"] = ((int)Session["FilesCount"]) + 1;

                int id = ((int)Session["FilesCount"]);
                file.Id = id;
                if(file.AccesssPrivilages == null)
                    file.AccesssPrivilages = new List<int>();

                ((List<File>)Session["Files"]).Add(file);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: File/Edit/5
        public ActionResult Edit(int id)
        {
            Dictionary<int, string> userIdLoginDictionary = GenerateIdLoginDictionary();
            ViewBag.UserDictionary = userIdLoginDictionary;

            var selectedFile = GetFileById(id);
            return View(selectedFile);
        }

        // POST: File/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, File file)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var updatedFile = GetFileById(id);
                updatedFile.AccesssPrivilages = file.AccesssPrivilages != null ? file.AccesssPrivilages : new List<int>();
                updatedFile.MimeType = file.MimeType;
                updatedFile.Name = file.Name;
                updatedFile.UserId = file.UserId;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: File/Delete/5
        public ActionResult Delete(int id)
        {
            var selectedFile = GetFileById(id);
            return View(selectedFile);
        }

        // POST: File/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var fileList = (List<File>)Session["Files"];
                fileList.Remove(GetFileById(id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private File GetFileById(int id)
        {
            var fileList = (List<File>)Session["Files"];
            return fileList.Single(x => x.Id == id);
        }

        private Dictionary<int, string> GenerateIdLoginDictionary()
        {
            Dictionary<int, string> userIdLoginDictionary = new Dictionary<int, string>();
            foreach (var user in (List<User>)Session["Users"])
            {
                userIdLoginDictionary.Add(user.Id, user.Login);
            }

            return userIdLoginDictionary;
        }

    }
}
