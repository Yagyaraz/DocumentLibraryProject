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
    public class FiscalYearController : Controller
    {
        private readonly IFiscalYear _fiscalyear;
        public FiscalYearController(IFiscalYear fiscalYear)
        {
            _fiscalyear = fiscalYear;
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FiscalYearViewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = _fiscalyear.AddFiscalYear(model);
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
            var result = _fiscalyear.GetAllFiscalYear();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var fiscal = _fiscalyear.GetFiscalYear(id);
            return View(fiscal);
        }

        public ActionResult Edit(int id)
        {
            var fiscal = _fiscalyear.GetFiscalYear(id);
            return View(fiscal);
        }


        [HttpPost]
        public ActionResult Edit(FiscalYearViewModel model)
        {
            if (ModelState.IsValid)
            {
                _fiscalyear.UpdateFiscalYear(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            _fiscalyear.DeleteFiscalYear(id);
            return RedirectToAction("GetAllRecords");
        }
    }
}