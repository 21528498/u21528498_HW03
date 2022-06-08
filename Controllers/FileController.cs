using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21528498_HW03.Models;

namespace u21528498_HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            string[] filePath = Directory.GetFiles(Server.MapPath("~/Media/documents"));
            List<FileModel> files = new List<FileModel>();

            foreach(string file in filePath)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(file) });
            }
            return View(files);
        }
        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }
        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/Media/documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}