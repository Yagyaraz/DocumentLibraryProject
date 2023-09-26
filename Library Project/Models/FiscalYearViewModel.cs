using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Project.Models
{
    public class FiscalYearViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]

        public bool Active { get; set; }
    }
}