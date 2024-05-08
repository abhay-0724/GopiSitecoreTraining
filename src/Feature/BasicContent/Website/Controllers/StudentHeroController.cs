using GopiSitecoreTraining.Feature.BasicContent.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GopiSitecoreTraining.Feature.BasicContent.Controllers
{
    public class StudentHeroController : Controller
    {
        // GET: StudentHero
        public ActionResult StudentDetails()
        {
            var contextItem = Sitecore.Context.Item;
            LinkField DepartmentMapped = contextItem.Fields["Student_Department"];
            var linkedDepartment = DepartmentMapped.Value;
            ID linkedDepartmentId = new ID(linkedDepartment);
            var linkedDepartmentItem = Sitecore.Context.Database.GetItem(linkedDepartmentId);

            ImageField titleBackground = contextItem.Fields["BackgroundImage"];
            var imageItem = titleBackground.MediaItem;
            var imagrItemUrl = MediaManager.GetMediaUrl(imageItem);

            Student student = new Student
            {
                Student_Department = linkedDepartmentItem == null? new HtmlString(""): new HtmlString(FieldRenderer.Render(linkedDepartmentItem,"Title")),
                BackgroundImage = imagrItemUrl,
                Student_Name = new HtmlString(FieldRenderer.Render(contextItem, "Student_Name")),
                Student_DOB  = new HtmlString(FieldRenderer.Render(contextItem, "Student_DOB")),
                Student_Address = new HtmlString(FieldRenderer.Render(contextItem, "Student_Address")),

            };
            return View("/Views/GopiSitecoreTraining/BasicContent/StudentHero.cshtml", student);
        }
    }
}