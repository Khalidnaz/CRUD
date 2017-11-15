using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameReview.Models;
using DbConnect.Tools;
using DbConnect.Adapter;
using System.Data;
using HtmlAgilityPack;
using System.Net;

namespace GameReview.Service
{
    public class ReviewService : BaseService, IReviewService
    {
        public IEnumerable<ReviewDomain> SelectAll()
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Review_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure,

            };
            return Adapter.LoadObject<ReviewDomain>(cmdDef);
        }

        public int Insert(ReviewRequest model)
        {
            int id = 0;
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Review_Insert",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@Title", model.Title, System.Data.SqlDbType.NVarChar, 50),
                    SqlDbParameter.Instance.BuildParameter("@Description", model.Description, System.Data.SqlDbType.NVarChar, 250),
                     SqlDbParameter.Instance.BuildParameter("@Platform", model.Platform, System.Data.SqlDbType.NVarChar, 50),
                      SqlDbParameter.Instance.BuildParameter("@Review", model.Review, System.Data.SqlDbType.NVarChar, 500),
                      SqlDbParameter.Instance.BuildParameter("@Id", id, SqlDbType.Int, paramDirection: ParameterDirection.Output),
                      SqlDbParameter.Instance.BuildParameter("@Price", model.Price, System.Data.SqlDbType.NVarChar, 50)
                }
            };
            Adapter.ExecuteQuery(cmdDef, (collection =>
            {
                int.TryParse(collection["@Id"].ToString(), out id);
            }));
            return id;
        }




        public void Update(ReviewUpdateRequest model)
        {
            Adapter.ExecuteQuery(new DbCmdDef
            {
                DbCommandText = "dbo.Review_Update",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new[]
                {
                     SqlDbParameter.Instance.BuildParameter("@Title", model.Title, System.Data.SqlDbType.NVarChar, 50),
                    SqlDbParameter.Instance.BuildParameter("@Description", model.Description, System.Data.SqlDbType.NVarChar, 250),
                     SqlDbParameter.Instance.BuildParameter("@Platform", model.Platform, System.Data.SqlDbType.NVarChar, 50),
                      SqlDbParameter.Instance.BuildParameter("@Review", model.Review, System.Data.SqlDbType.NVarChar, 500),
                      SqlDbParameter.Instance.BuildParameter("@Id", model.Id, System.Data.SqlDbType.Int),
                         SqlDbParameter.Instance.BuildParameter("@Price", model.Price, System.Data.SqlDbType.NVarChar, 50)
                }
            });

        }

        public void Delete(int id)
        {
            //use this line for delete and update
            Adapter.ExecuteQuery(new DbCmdDef
            {
                DbCommandText = "dbo.Review_Delete",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int)
                }
            });

        }
        //    public string WebScrape(WebScrapingRequest model)
        //    {




        //        //var html = new HtmlDocument();
        //        //html.LoadHtml(new WebClient().DownloadString(""));
        //        //var root = html.DocumentNode;
        //        //var p = root.Descendants()
        //        //    .Where(n => n.GetAttributeValue("class", "").Equals("module-profile-recognition"))
        //        //    .Single()
        //        //    .Descendants("p")
        //        //    .Single();
        //        //var content = p.InnerText;

        //    }
    }
}