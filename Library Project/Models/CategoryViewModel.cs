using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Project.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("वर्ग")]
        public string Name { get; set; }
    }
}