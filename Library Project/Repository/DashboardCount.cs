using Library_Project.Interface;
using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Library_Project.Repository
{
    public class DashboardCount:IDashboardCount
    {
        public DashboardCountModel DashCount()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                DashboardCountModel model = new DashboardCountModel()
                {
                    CategoryCount = context.Category.Count(),
                    SubCategoryCount = context.Sub_Category.Count(),
                    DocumentCount = context.Document.Count(),
                    DocumentTypeCount = context.Document_Type.Count(),
                    DocumentSourceCount = context.Document_Source.Count(),
                    FiscalYearCount = context.Fiscal_Year.Count()

                };
                return model;
            }




        }

        public DashboardCountModel SendData()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                DashboardCountModel model = new DashboardCountModel()
                {
                    CategoryCount = context.Category.Where(x => x.IsDelete == false).Count(),
                    SubCategoryCount = context.Sub_Category.Where(x => x.IsDelete == false).Count(),
                    DocumentSourceCount = context.Document_Source.Where(x => x.IsDelete == false).Count(),
                    DocumentCount = context.Document.Where(x => x.IsDelete == false).Count(),
                    DocumentTypeCount = context.Document_Type.Where(x => x.IsDelete == false).Count(),
                    FiscalYearCount = context.Fiscal_Year.Where(x=>x.IsDelete == false).Count(),

                };
                return model;
            }
        }
    }
}
