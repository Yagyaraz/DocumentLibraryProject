using Library_Project.Interface;
using Library_Project.Models;
using Library_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Project.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = _category.AddCategory(model);
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
            var result = _category.GetAllCategories();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var category = _category.GetCategory(id);
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = _category.GetCategory(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _category.UpdateCategory(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            _category.DeleteCategory(id);
            return RedirectToAction("GetAllRecords");
        }


    }
}

