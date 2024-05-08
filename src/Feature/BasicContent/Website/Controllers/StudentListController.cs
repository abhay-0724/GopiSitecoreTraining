using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GopiSitecoreTraining.Feature.BasicContent.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;

namespace GopiSitecoreTraining.Feature.BasicContent.Controllers
{
    public class StudentListController : Controller
    {
        // GET: StudentList
        public ActionResult GetListOfStudents()
        {
            var contextItem = Sitecore.Context.Item;
            string StudentsParentItemIdinSitecore = "{BD4B6813-3148-49BA-86EA-E99F5232C421}";
                var studentsParentItem = Sitecore.Context.Database.GetItem(StudentsParentItemIdinSitecore);
            List<StudentListItem> studentsList = studentsParentItem.GetChildren()
                .Where(x => x.Fields["Student_Department"].Value == contextItem.ID.ToString())
                .Select(x => new StudentListItem
                {
                    StudentName = x.Fields["Student_Name"].Value,
                    StudentProfilePageUrl = LinkManager.GetItemUrl(x),
                    StudentProfilePicAlt = GetProfilePicAlt(x, "Student_ProfilePic"),
                    StudentProfilePicUrl = GetProfilePicAlt(x, "Student_ProfilePic")
                }).ToList();
            return View("/Views/GopiSitecoreTraining/BasicContent/ListOfStudents.cshtml",studentsList);
        }
        private string GetProfilePicAlt(Item item, string FieldName)
        {
            ImageField image = item.Fields[FieldName];
            return image.Alt;
        }
        private string GetProfilePicUrl(Item item, string FieldName)
        {
            ImageField image = item.Fields[FieldName];
            return MediaManager.GetMediaUrl(image.MediaItem);
        }


    }
}