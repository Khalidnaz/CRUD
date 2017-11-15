using GameReview.Models;
using GameReview.Service;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace GameReview.Controllers.API
{//allowanonymous allows people to not be logged in
    [AllowAnonymous]
    [RoutePrefix("api/review")]
    public class ReviewController : ApiController
    {
        IReviewService _ReviewService;

        public ReviewController(IReviewService reviewService)
        {
            _ReviewService = reviewService;
        }

        [Route("reviewList"), HttpGet]
        public HttpResponseMessage GetReviews()
        {
            try
            {
               
                IEnumerable<ReviewDomain> response = _ReviewService.SelectAll();
                //response = _reviewService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                //logError(MethodBase.GetCurrentMethod().Name, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }




        [Route(), HttpPost]
        public HttpResponseMessage Insert(ReviewRequest model)
        {
            try
            {
                int response = _ReviewService.Insert(model);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
    public HttpResponseMessage Update(ReviewUpdateRequest model)
        {
            try
            {
               _ReviewService.Update(model);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _ReviewService.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //webscraping
        [Route("url"), HttpPost]
        public HttpResponseMessage Scrape(WebScrapingRequest model)
        {
            try
            {

                //var html = model.Url;
                //HtmlWeb web = new HtmlWeb();

                //var htmlDoc = web.Load(html);
                //var node = htmlDoc.DocumentNode.SelectSingleNode("//title");

                var html = new HtmlDocument();
                html.LoadHtml(new WebClient().DownloadString(@model.Url));
                var root = html.DocumentNode;
                var p = root.Descendants()
                    .Where(n => n.GetAttributeValue("class", "").Equals("buy1 ats-prodBuy-buyBoxSec"))
                    .Single()
                    .Descendants("h3")
                    .Single();
                @model.Price = p.InnerText;




                return Request.CreateResponse(HttpStatusCode.OK, @model.Price);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


    }

}