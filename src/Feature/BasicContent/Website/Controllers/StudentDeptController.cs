using GopiSitecoreTraining.Feature.BasicContent.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GopiSitecoreTraining.Feature.BasicContent.Controllers
{
    public class StudentDeptController : Controller
    {
        // GET: StudentDept
        public ActionResult DepartmentDetails()
        {
            var contextItem = Sitecore.Context.Item;
            LinkField DepartmentMapped = contextItem.Fields["Student_Department"];

            var linkedDepartment = DepartmentMapped.Value;
            ID linkedDepartmentId = new ID(linkedDepartment);
            var linkedDepartmentItem = Sitecore.Context.Database.GetItem(linkedDepartmentId);

            Dept dept = new Dept
            {
                DeptName = linkedDepartmentItem.Name,
                DeptUrl = LinkManager.GetItemUrl(linkedDepartmentItem)
            };
            return View("/Views/GopiSitecoreTraining/BasicContent/DeptLink.cshtml",dept);
        }
    }
}