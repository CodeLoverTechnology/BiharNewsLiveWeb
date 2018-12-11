using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiharNewsLive.ModelsWithDb
{
    public class NewsModel
    {
        public int NewsID { get; set; }
        public int NewsTypeID { get; set; }
        public string NewsTypeName { get; set; }
        public int NewsCategoryID { get; set; }
        public string NewsCategoryName { get; set; }
        public int NewsSubCategoryID { get; set; }
        public string NewsSubCategoryName { get; set; }
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

    }
}