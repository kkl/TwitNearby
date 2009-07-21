using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TwitsNearby.Models;
using Dimebrain.TweetSharp.Fluent;
using Dimebrain.TweetSharp.Extensions;
using Dimebrain.TweetSharp.Model;
using Microsoft.Practices.Unity;


namespace TwitsNearby.Controllers
{
    public class TweetController : Controller
    {

        [Dependency]
        public IStatusesService StatusesService { get; set; }

        public ActionResult Tweet(string Id, string fmt)
        {            

            var result = StatusesService.RetrieveStatusesFromOwnDB(new Guid(Id));

            if (result == null)
                return new EmptyResult();
            else
            {
                //Get the tweet from Twitter also

                var twitter = FluentTwitter.CreateRequest().Configuration.UseGzipCompression().Statuses()
                .Show(result.StatusID);

                var twitteresponse = twitter.Request();

                //Replace it with the original(longer) text
                TwitterStatus twitterresult = twitteresponse.AsStatus();
                twitterresult.Text = Utility.UtilityTool.FormatTweet(result.Text);                
                if (fmt == "html")
                {
                    IList<TwitterStatus> tws = new List<TwitterStatus>();
                    tws.Add(twitterresult);
                    return PartialView("TweetDetail", tws);
                }
                else
                    return Json(twitterresult);
            }
        
        }

    }
}
