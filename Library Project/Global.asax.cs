using Library_Project.Interface;
using Library_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace Library_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterComponents();
        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<ICategory, CategoryRepository>();
            container.RegisterType<ISubCategory, SubCategoryRepository>();
            container.RegisterType<IDocumentType, DocumentTypeRepository>();
            container.RegisterType<IDocumentSource,DocumentSourceRepository>();
            container.RegisterType<IFiscalYear, FiscalYearRepository>();
            container.RegisterType<IDocument, DocumentRepository>();
            container.RegisterType<IDashboardCount, DashboardCount>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }


    }

}
