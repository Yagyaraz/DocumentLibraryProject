//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sub_Category
    {
        public Sub_Category()
        {
            this.Document = new HashSet<Document>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Category_Id { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Document> Document { get; set; }
    }
}
