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
    public class SubCategoryController : Controller
    {
        private readonly ISubCategory _subcategory;
        public SubCategoryController(ISubCategory subcategory)
        {
            _subcategory = subcategory;
        }
        public ActionResult Create()
        {
            using (var con = new DLMSDatabaseEntities())
            {
                ViewBag.CategoryList = new SelectList(con.Category.Where(x=>x.IsDelete==false).ToList(), "Id", "Name");
            }
            return View();

        }

        [HttpPost]
        public ActionResult Create(SubCategoryVIewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = _subcategory.AddSubCategory(model);
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
            var result = _subcategory.GetAllSubCategories();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var category = _subcategory.GetSubCategory(id);
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            using (var con = new DLMSDatabaseEntities())
            {
                ViewBag.CategoryList = new SelectList(con.Category.ToList(), "Id", "Name");
            }
            var category = _subcategory.GetSubCategory(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(SubCategoryVIewModel model)
        {
            if (ModelState.IsValid)
            {
                _subcategory.UpdateSubCategory(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            _subcategory.DeleteSubCategory(id);
            return RedirectToAction("GetAllRecords");
        }
    }
}