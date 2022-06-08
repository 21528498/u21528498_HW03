using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21528498_HW03.Models;

namespace u21528498_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            //Accessing the folders with videos
            string[] filePath = Directory.GetFiles(Server.MapPath("~/Media/videos"));

            //List to store the videos found in the folder
            List<FileModel> files = new List<FileModel>();

            foreach (string file in filePath)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(file) });
            }
            return View(files);
        }

        //The downloadFile code is to allow the user to download the files into their computer
        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        //The deleteFile code is to allow the user to delete files from the stored files
        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/Media/videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
    
}