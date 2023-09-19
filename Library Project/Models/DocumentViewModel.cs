using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Models
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int PalikaId { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentSourceId { get; set; }
        public int CategoryId { get; set; }
        public int SubCatId { get; set; }
        public int YearId { get; set; }
        public int WardId { get; set; }
    }
}