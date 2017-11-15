using GameReview.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

//namespace GameReview.Service
//{
//    public class WebScrapingService
//    {

//        public string WebScrape(WebScrapingRequest model)
//        {

//            var html = @"https://www.gamestop.com/";
//            HtmlWeb web = new HtmlWeb();
//            var htmlDoc = web.Load(html);
//            var node = htmlDoc.DocumentNode.SelectSingleNode("//head");
//            return node.InnerHtml;

//        }
//    }
//}