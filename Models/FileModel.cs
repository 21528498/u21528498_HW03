using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21528498_HW03.Models
{
    public class FileModel
    {
        //Get the file name
        public string FileName { get; set; }
        public HttpPostedFileBase[] Files { get; set; }

    }
}