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
    
    public partial class Palika
    {
        public Palika()
        {
            this.Document = new HashSet<Document>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int District_Id { get; set; }
    
        public virtual District District { get; set; }
        public virtual ICollection<Document> Document { get; set; }
    }
}
