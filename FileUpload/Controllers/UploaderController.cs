using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace FileUpload.Controllers
{
    public class UploaderController : Controller
    {

        public JsonResult UploadImage(HttpPostedFileBase uploadedFile)
        {
            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {
                string filePath = Server.MapPath("/App_Data/Upload/Images");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = Path.Combine(filePath, uploadedFile.FileName);
                if (System.IO.File.Exists(fileName))
                    System.IO.File.Delete(fileName);
                uploadedFile.SaveAs(fileName);
                return Json(new
                {
                    success = true,
                    message = "上传成功"
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = "无效的文件"
                }, JsonRequestBehavior.AllowGet);
            }
           
        }
    }
}