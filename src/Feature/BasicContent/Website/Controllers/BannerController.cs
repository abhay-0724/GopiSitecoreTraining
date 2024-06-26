﻿using GopiSitecoreTraining.Feature.BasicContent.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GopiSitecoreTraining.Feature.BasicContent.Controllers
{
    public class BannerController : Controller
    {
        // GET: Banner
        public ActionResult GetBannerDetails()
        {
            var renderingItem = RenderingContext.Current.Rendering.Item;
            Banner banner = new Banner()
            {
                BannerTitle = new HtmlString(FieldRenderer.Render(renderingItem, "BannerTitle")),
                BannerDesc = new HtmlString(FieldRenderer.Render(renderingItem, "BannerDesc")),
                BannerImage = new HtmlString(FieldRenderer.Render(renderingItem, "BannerImage")),
            };
            return View("/Views/GopiSitecoreTraining/BasicContent/Banner.cshtml",banner);
        }
    }
}