using Library_Project.Interface;
using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Repository
{
    public class SubCategoryRepository:ISubCategory
    {
        private readonly DLMSDatabaseEntities _context = new DLMSDatabaseEntities();
        public SubCategoryRepository(DLMSDatabaseEntities context)
        {
            _context = context;
        }
        public int AddSubCategory(SubCategoryVIewModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                
                Sub_Category scat = new Sub_Category()
                {
                    Name = model.Name,
                    Category_Id = model.Category_Id,
                    IsDelete = false

                };

                context.Sub_Category.Add(scat);
                context.SaveChanges();
                return scat.Id;
            }
        }

        public List<SubCategoryVIewModel> GetAllSubCategories()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Sub_Category.Where(x=>x.IsDelete==false)
                    .Select(x => new SubCategoryVIewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category_Id = x.Category_Id,
                        Category_Name = x.Category.Name


                    }).ToList();

                return result;
            }

        }

        public SubCategoryVIewModel GetSubCategory(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Sub_Category
                    .Where(x => x.Id == id && x.IsDelete==false)
                    .Select(x => new SubCategoryVIewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category_Id = x.Category_Id,
                        Category_Name = x.Category.Name



                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateSubCategory(int id, SubCategoryVIewModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var subcategory = context.Sub_Category.FirstOrDefault(x => x.Id == id);
                if (subcategory != null)
                {
                    subcategory.Name = model.Name;
                    subcategory.Category_Id = model.Category_Id;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteSubCategory(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var subcategory = context.Sub_Category.FirstOrDefault(x => x.Id == id);
                if (subcategory != null && subcategory.IsDelete==false)
                {
                    subcategory.IsDelete = true;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}