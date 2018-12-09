//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiharNewsLive.ModelsWithDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_NewsInfoTable
    {
        public int NewsID { get; set; }
        public int NewsType { get; set; }
        public int NewsSubCategoryID { get; set; }
        public string NewsTitle { get; set; }
        public string HeadlineImagePath { get; set; }
        public string HeadLine { get; set; }
        public string NewsDescription { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string Images4 { get; set; }
        public string Images5 { get; set; }
        public string Location { get; set; }
        public int NoOfView { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    
        public virtual M_MasterTables M_MasterTables { get; set; }
        public virtual M_NewsSubCategoryMaster M_NewsSubCategoryMaster { get; set; }
    }
}