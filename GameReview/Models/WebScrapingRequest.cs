using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameReview.Models
{
    public class WebScrapingRequest
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
    }
}