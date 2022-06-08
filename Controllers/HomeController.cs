using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21528498_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            //Checks if there user chose a file
            if (files != null && files.ContentLength > 0)
            {
                //gets the file name
                var fileName = Path.GetFileName(files.FileName);

                //requests the radio buttons from the view
                string option = Request["rButton"];
                
                //if statements to check which radio button the user checked
                if (option == "Documents")
                {
                    //storing the files in their specific folder, the documents folder
                    var path = Path.Combine(Server.MapPath("~/Media/documents"), fileName);
                    files.SaveAs(path);

                }
                else if(option == "Image")
                {
                    //storing the files in their specific folder, the images folder
                    var path = Path.Combine(Server.MapPath("~/Media/images"), fileName);
                    files.SaveAs(path);
                }
                else if (option == "Video")
                {
                    //storing the files in their specific folder, the videos folder
                    var path = Path.Combine(Server.MapPath("~/Media/videos"), fileName);
                    files.SaveAs(path);
                }



            }
            
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {

            return View();
        }
    }
}