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
    public class DocumentSourceController : Controller
    {
        private readonly IDocumentSource _documentsource;
        public DocumentSourceController(IDocumentSource documentsource)
        {
            _documentsource = documentsource;
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DocumentSourceViewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = _documentsource.AddDocumentSource(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Added";
                    return RedirectToAction("GetAllRecords");
                }
            }
            return View(model);
        }

        public ActionResult GetAllRecords()
        {
            var result = _documentsource.GetAllDocumentSource();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var category = _documentsource.GetDocumentSource(id);
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var docsource = _documentsource.GetDocumentSource(id);
            return View(docsource);
        }


        [HttpPost]
        public ActionResult Edit(DocumentSourceViewModel model)
        {
            if (ModelState.IsValid)
            {
                _documentsource.UpdateDocumentSource(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            _documentsource.DeleteDocumentSource(id);
            return RedirectToAction("GetAllRecords");
        }
    }
}
