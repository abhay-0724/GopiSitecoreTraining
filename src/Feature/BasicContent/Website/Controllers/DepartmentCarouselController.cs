using GopiSitecoreTraining.Feature.BasicContent.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GopiSitecoreTraining.Feature.BasicContent.Controllers
{
    public class DepartmentCarouselController : Controller
    {
        // GET: DepartmentCarousel
        public ActionResult DepartmentCarousel()
        {
            Item item = Sitecore.Context.Item;
            List<DepartmentCarousel> selectedItemsData = new List<DepartmentCarousel>();
            MultilistField carouselItems = item.Fields["CarouselItems"];
            if(carouselItems != null)
            {
                //selectedItemsData = carouselItems.GetItems()
                //                        .Select(x => new Models.DepartmentCarousel
                //                        {
                //                            CarouselImage = GetImageUrl(x, "CarouselImage"),
                //                            CarouselImageAlt = GetImagealt(x, "CarouselImage"),
                //                        }).ToList();
                //selectedItemsData[0].IsActive = "active";
                int index = 0;
                foreach (var id in carouselItems.TargetIDs)
                {
                    Item selected = Sitecore.Context.Database.GetItem(id);
                    if (selected != null)
                    {
                        ImageField imageField = selected.Fields["CarouselImage"];

                        if (imageField != null && imageField.MediaItem != null)
                        {
                            var imageUrl = MediaManager.GetMediaUrl(imageField.MediaItem);
                            selectedItemsData.Add(new DepartmentCarousel
                            {
                                CarouselImage = imageUrl,
                                CarouselImageAlt = imageField.Alt,
                                IsActive = index == 0 ? "active" : string.Empty,
                                CarouselDescription = new HtmlString(FieldRenderer.Render(item, "CarouselDescription")),
                                CarouselTitle = new HtmlString(FieldRenderer.Render(item, "CarouselTitle"))
                            });
                        }
                    }
                    index++;
                }
            }
            return View("/Views/GopiSitecoreTraining/BasicContent/DepartmentCarousel.cshtml",selectedItemsData);
        }
        //private string GetImageUrl(Item item, string fieldName)
        //{
        //    ImageField imageField = item.Fields[fieldName];
        //    return MediaManager.GetMediaUrl(imageField.MediaItem);
        //}
        //private string GetImagealt(Item item, string fieldName)
        //{
        //    ImageField imageField = item.Fields[fieldName];
        //    return imageField.Alt;
        //}
    }
}