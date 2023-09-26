using Library_Project.Interface;
using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;

namespace Library_Project.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly DLMSDatabaseEntities _context = new DLMSDatabaseEntities();
        public CategoryRepository(DLMSDatabaseEntities context)
        {
            _context = context;
        }

        public int AddCategory(CategoryViewModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                Category cat = new Category()
                {
                    Name = model.Name,
                    IsDelete=false,
                };

                context.Category.Add(cat);
                context.SaveChanges();
                return cat.Id;
            }
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Category.Where(x=>x.IsDelete==false)
                    .Select(x => new CategoryViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).ToList();

                return result;
            }

        }

        public CategoryViewModel GetCategory(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Category.Where(x => x.Id == id && x.IsDelete==false)
                    .Select(x => new CategoryViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateCategory(int id, CategoryViewModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var category = context.Category.FirstOrDefault(x => x.Id == id);
                if (category != null)
                {
                    category.Name = model.Name;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var category = context.Category.FirstOrDefault(x => x.Id == id);
                if (category != null && category.IsDelete==false)
                {
                    category.IsDelete = true;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            

        }
    }
}