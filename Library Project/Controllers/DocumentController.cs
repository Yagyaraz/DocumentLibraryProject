using Library_Project.Interface;
using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Project.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IDocument _document;
        public DocumentController(IDocument document)
        {
            _document = document;
        }
        public ActionResult Create()
        {
            using (var con = new DLMSDatabaseEntities())
            {
                ViewBag.CategoryList = new SelectList(con.Category.ToList(), "Id", "Name");
                ViewBag.SubCategoryList = new SelectList(con.Sub_Category.ToList(), "Id", "Name");
                ViewBag.DocumentSource = new SelectList(con.Document_Source.ToList(), "Id", "Name");
                ViewBag.FiscalYear = new SelectList(con.Fiscal_Year.ToList(), "Id", "Name");
                ViewBag.StateList = new SelectList(con.State.ToList(), "Id", "Name");
                ViewBag.DistrictList = new SelectList(con.District.ToList(), "Id", "Name");
                ViewBag.PalikaList = new SelectList(con.Palika.ToList(), "Id", "Name");
                ViewBag.DocumentType = new SelectList(con.Document_Type.ToList(), "Id", "Name");



            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(DocumentViewModel model)
        {
            int id = _document.AddDocument(model);
            if (id > 0)
            {
                ModelState.Clear();
                ViewBag.IsSuccess = "Data Added";
                foreach (var item in model.ImageFile)
                {
                    var imagePath = "/File/";


                    using (var con = new DLMSDatabaseEntities())
                    {
                        if ( item!= null)
                        {


                            var fileName = Path.GetFileName(item.ImageFile.FileName);
                            var path = Path.Combine(Server.MapPath(imagePath), fileName);
                            item.ImageFile.SaveAs(path);
                            item.File_Path = imagePath + item.Name;
                            Document_File document_File = new Document_File()
                            {
                                File_Path = item.File_Path,
                                Name = fileName,
                            };
                            con.Document_File.Add(document_File);
                            con.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("GetAllRecords");

            }

            return View(model);
        }

        public ActionResult GetAllRecords()
        {
            var result = _document.GetAllDocuments();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var doc = _document.GetDocument(id);
            return View(doc);
        }

        public ActionResult Edit(int id)
        {
            using (var con = new DLMSDatabaseEntities())
            {
                ViewBag.CategoryList = new SelectList(con.Category.ToList(), "Id", "Name");
                ViewBag.SubCategoryList = new SelectList(con.Sub_Category.ToList(), "Id", "Name");
                ViewBag.DocumentSource = new SelectList(con.Document_Source.ToList(), "Id", "Name");
                ViewBag.FiscalYear = new SelectList(con.Fiscal_Year.ToList(), "Id", "Name");
                ViewBag.StateList = new SelectList(con.State.ToList(), "Id", "Name");
                ViewBag.DistrictList = new SelectList(con.District.ToList(), "Id", "Name");
                ViewBag.PalikaList = new SelectList(con.Palika.ToList(), "Id", "Name");
                ViewBag.DocumentType = new SelectList(con.Document_Type.ToList(), "Id", "Name");


            }
            var doc = _document.GetDocument(id);
            return View(doc);
        }


        [HttpPost]
        public ActionResult Edit(DocumentViewModel model)
        {
            if (ModelState.IsValid)
            {
                _document.UpdateDocument(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            _document.DeleteDocument(id);
            return RedirectToAction("GetAllRecords");
        }

        [HttpPost]
        public ActionResult Upload(DocumentFileModel model)
        {

            var imagePath = "/File/";

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
            return View();
        }
        public PartialViewResult Index()
        {
            return PartialView("_image", new DocumentFileModel());
        }
    }
}