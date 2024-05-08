using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GopiSitecoreTraining.Feature.BasicContent.Models
{
    public class Student
    {
       
        public string BackgroundImage { get; set; }
        public HtmlString Student_Name { get; set; }
        public HtmlString Student_DOB { get; set; }
        public HtmlString Student_Department { get; set; }
        public HtmlString Student_Address { get; set; }
    }
}