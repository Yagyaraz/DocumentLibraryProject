using Library_Project.Interface;
using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Project.Controllers
{
    [Authorize]
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentType _documenttype;
        public DocumentTypeController(IDocumentType documenttype)
        {
            _documenttype = documenttype;
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DocumentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = _documenttype.AddDocumentType(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Added";
                    return RedirectToAction("getallrecords");
                }
            }
            return View(model);
        }

        public ActionResult GetAllRecords()
        {
            var result = _documenttype.GetAllDocumentTypes();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var category = _documenttype.GetDocumentType(id);
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = _documenttype.GetDocumentType(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(DocumentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _documenttype.UpdateDocumentType(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            _documenttype.DeleteDocumentType(id);
            return RedirectToAction("GetAllRecords");
        }
    }
}