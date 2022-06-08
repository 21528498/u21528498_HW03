using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21528498_HW03.Models;

namespace u21528498_HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            //This is to access the images stored in the Image folder
            string[] filePath = Directory.GetFiles(Server.MapPath("~/Media/images"));
            
            //A list to store the retrieved images 
            List<FileModel> files = new List<FileModel>();

            foreach (string file in filePath)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(file) });
            }
            return View(files);
        }
        
        //This is to allow the user to download the images into their computer
        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        //This is to allow the user to delete files from the folder 
        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/Media/images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
    
}