using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GopiSitecoreTraining.Foundation.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult GetNavigationItems()
        {
            var rootPath = Sitecore.Context.Site.RootPath;
            var homeItem = Sitecore.Context.Database.GetItem(rootPath);
            return View();
        }
    }
}