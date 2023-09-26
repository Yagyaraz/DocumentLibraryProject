using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Library_Project.Models
{
    public class DocumentViewModel
    {

        public int Id { get; set; }
        [Required]
        [DisplayName("नाम")]
        public string Name { get; set; }
        [Required]
        [DisplayName("वर्ग")]

        public int Category_Id { get; set; }
        [DisplayName("वर्ग")]

        public string Category_Name { get; set; }
        [Required]
        [DisplayName("अप-वर्ग ")]

        public int Sub_Category_Id { get; set; }
        [DisplayName("अप-वर्ग ")]

        public string Sub_Category_Name { get; set; }
        [Required]
        [DisplayName("कागजातको स्रोत ")]

        public int Document_Source_Id { get; set; }
        [DisplayName("कागजातको स्रोत ")]

        public string Document_Source_Name { get; set; }
        [Required]
        [DisplayName("आर्थिक बर्ष ")]

        public int Fiscal_Year_Id { get; set; }

        [DisplayName("आर्थिक बर्ष ")]
        public string Fiscal_Year_Name { get; set; }
        [Required]
        [DisplayName("प्रदेश")]

        public int State_Id { get; set; }
        [DisplayName("प्रदेश")]
        public string State_Name { get; set; }
        [Required]
        [DisplayName("जिल्ला")]

        public int District_Id { get; set; }

        [DisplayName("जिल्ला")]
        public string District_Name { get; set; }
        [Required]
        [DisplayName("पालिका")]

        public int Palika_Id { get; set; }

        [DisplayName("पालिका")]
        public string Palika_Name { get; set; }
        [Required]
        [DisplayName("कागजातको प्रकार ")]

        public int Document_Type_Id { get; set; }
        [DisplayName("कागजातको प्रकार ")]
        public string Document_Type_Name { get; set; }


        public List<DocumentFileModel> ImageFile { get; set; } = new List<DocumentFileModel>();
    }
}