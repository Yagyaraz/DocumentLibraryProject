using Antlr.Runtime.Misc;
using Library_Project.Interface;
using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Repository
{
    public class FiscalYearRepository:IFiscalYear
    {
        private readonly DLMSDatabaseEntities _context = new DLMSDatabaseEntities();
        public FiscalYearRepository(DLMSDatabaseEntities context)
        {
            _context = context;
        }
        public int AddFiscalYear(FiscalYearViewModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                Fiscal_Year fy = new Fiscal_Year()
                {
                    Name = model.Name,
                    Active = model.Active,
                    IsDelete=false

                };

                context.Fiscal_Year.Add(fy);
                context.SaveChanges();
                return fy.Id;
            }
        }

        public List<FiscalYearViewModel> GetAllFiscalYear()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Fiscal_Year.Where(x=>x.IsDelete==false)
                    .Select(x => new FiscalYearViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Active = x.Active


                    }).ToList();

                return result;
            }

        }

        public FiscalYearViewModel GetFiscalYear(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Fiscal_Year
                    .Where(x => x.Id == id && x.IsDelete==false)
                    .Select(x => new FiscalYearViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Active = x.Active


                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateFiscalYear(int id, FiscalYearViewModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var fiscal = context.Fiscal_Year.FirstOrDefault(x => x.Id == id);
                if (fiscal != null)
                {
                    fiscal.Name = model.Name;
                    fiscal.Active = model.Active;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteFiscalYear(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var fiscal = context.Fiscal_Year.FirstOrDefault(x => x.Id == id);
                if (fiscal != null)
                {
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}