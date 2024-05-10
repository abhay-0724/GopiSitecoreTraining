using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GopiSitecoreTraining.Feature.BasicContent.Models
{
    public class DepartmentCarousel
    {
        public HtmlString CarouselTitle { get; set; }
        public HtmlString CarouselDescription { get; set; }

        public string CarouselImage { get; set; }
        public string CarouselImageAlt { get; set; }
        public string IsActive { get; set;  } = string.Empty;
    }
}