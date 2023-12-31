﻿using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Project.Controllers
{
    [Authorize]
    public class DocumentFileController : Controller
    {

        public ActionResult Upload()
        {
            DocumentFileModel model = new DocumentFileModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Upload(DocumentFileModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Msg"] = "";
                return View(model);
            }
            else
            {
                var imagePath = "/File/";
                if (model.ImageFile != null)

                    using (var con = new DLMSDatabaseEntities())
                    {
                        if (model.ImageFile != null)
                        {


                            var fileName = Path.GetFileName(model.ImageFile.FileName);
                            var path = Path.Combine(Server.MapPath(imagePath), fileName);
                            model.ImageFile.SaveAs(path);
                            model.File_Path = imagePath + model.ImageFile.FileName;
                            Document_File document_File = new Document_File()
                            {
                                File_Path = model.File_Path,
                                Name = fileName,
                            };
                            con.Document_File.Add(document_File);
                            con.SaveChanges();
                        }

                    }
            }
           return View();
        }

    }
}