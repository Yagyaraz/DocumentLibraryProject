using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Models
{
    public class SubCategoryVIewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}