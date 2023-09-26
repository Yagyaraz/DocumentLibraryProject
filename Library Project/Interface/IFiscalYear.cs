using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Interface
{
    public interface IFiscalYear
    {
        int AddFiscalYear(FiscalYearViewModel model);
        List<FiscalYearViewModel> GetAllFiscalYear();
        FiscalYearViewModel GetFiscalYear(int id);
        bool UpdateFiscalYear(int id, FiscalYearViewModel model);
        bool DeleteFiscalYear(int id);
    }
}