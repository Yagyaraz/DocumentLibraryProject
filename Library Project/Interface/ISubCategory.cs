using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Interface
{
    public interface ISubCategory
    {
        int AddSubCategory(SubCategoryVIewModel model);
        List<SubCategoryVIewModel> GetAllSubCategories();
        SubCategoryVIewModel GetSubCategory(int id);
        bool UpdateSubCategory(int id, SubCategoryVIewModel model);
        bool DeleteSubCategory(int id);
    }
}