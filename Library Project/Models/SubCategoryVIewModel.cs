using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Project.Models
{
    public class SubCategoryVIewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("नाम")]
        public string Name { get; set; }
        [Required]
        [DisplayName("वर्ग ")]

        public int Category_Id { get; set; }
        [DisplayName("वर्ग ")]
        public string Category_Name { get; set; }
    }
}