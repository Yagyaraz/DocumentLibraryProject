using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Interface
{
    public interface ICategory
    {
        int AddCategory(CategoryViewModel model);
        List<CategoryViewModel> GetAllCategories();
        CategoryViewModel GetCategory(int id);
        bool UpdateCategory(int id, CategoryViewModel model);
        bool DeleteCategory(int id);

    }
}