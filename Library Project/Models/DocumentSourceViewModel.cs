using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Project.Models
{
    public class DocumentSourceViewModel
    {

        public int Id { get; set; }
        [Required]
        [DisplayName("नाम")]
        public string Name { get; set; }
    }
}