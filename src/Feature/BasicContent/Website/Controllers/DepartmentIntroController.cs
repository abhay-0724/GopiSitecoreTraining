using GopiSitecoreTraining.Feature.BasicContent.Models;
using Sitecore.Data.Fields;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GopiSitecoreTraining.Feature.BasicContent.Controllers
{
    public class DepartmentIntroController : Controller
    {
        // GET: DepartmentIntro
        public ActionResult IntroDetails()
        {
            var contextItem = Sitecore.Context.Item;
            ImageField titleBackground = contextItem.Fields["TitleBackground"];
            var imageItem = titleBackground.MediaItem;
            var imagrItemUrl = MediaManager.GetMediaUrl(imageItem);

            Department dept = new Department
            {
                Title = new HtmlString(FieldRenderer.Render(contextItem, "Title")),
                DepartmentEthos = new HtmlString(FieldRenderer.Render(contextItem, "DepartmentEthos")),
                TitleBackground = imagrItemUrl,
                DepartmentLogo = new HtmlString(FieldRenderer.Render(contextItem, "DepartmentLogo")),

            };
            return View("/Views/GopiSitecoreTraining/BasicContent/DepartmentIntro.cshtml",dept);
        }
    }
}