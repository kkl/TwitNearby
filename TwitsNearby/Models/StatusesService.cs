using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitsNearby.Utility;
using Dimebrain.TweetSharp.Model;
using System.Text.RegularExpressions;
using System.Configuration;
using Dimebrain.TweetSharp.Fluent;
using Dimebrain.TweetSharp.Extensions;
using TwitsNearby.Security;


namespace TwitsNearby.Models
{
    public class StatusesService :IStatusesService
    {
        #region IStatusesService Members

        public void AddStatusesToOwnDB(Guid id, long statusid, double? lat, double? lng, string text)
        {
            using (TwitsNearByEntities tw = new TwitsNearByEntities())
            {
                tw.AddToStatuses(new Statuses() {ID=id, StatusID = statusid, Latitude =lat, Longtitude =lng, Text = text });
                tw.SaveChanges();                
            }
        }
      
        public Statuses RetrieveStatusesFromOwnDB(Guid id)
        {
            using (TwitsNearByEntities tw = new TwitsNearByEntities())
            {
                return (from a in tw.Statuses where a.ID == id select a).FirstOrDefault();
            }
        }

        public Statuses RetrieveStatusesFromOwnDB(long tweetId)
        {
            using (TwitsNearByEntities tw = new TwitsNearByEntities())
            {
                return (from a in tw.Statuses where a.StatusID == tweetId select a).FirstOrDefault();
            }
        }


        public void FormatTweetForNearBy(IList<TwitterStatus> statuses)
        {
            Regex reg = new Regex("...");
            for (int i = 0; i < statuses.Count; i++)
            {                
                if (reg.Match(statuses[i].Text).Success)
                {
                    var result = RetrieveStatusesFromOwnDB(statuses[i].Id);
                    if (result != null)
                        statuses[i].Text = result.Text;
                }

                statuses[i].Text = UtilityTool.FormatTweet(statuses[i].Text);
            }

        }

        public TwitterStatus AddStatuses(double? lat, double? lng, string text, long replyTo)
        {
            Guid key = new Guid();

            //Location LatLng
            if (lat != null)
            {
                key = Guid.NewGuid();
                
                string mapurl = ConfigurationManager.AppSettings["mapurl"];

                mapurl = mapurl + "?q=" + lat.ToString() + ',' + lng.ToString();

                text = text + "Map: " + UtilityTool.ShortUrl(mapurl);
            }

            //LatLng must be saved also
            string orgtext = text;

            if (text.Length > 140)
            {
                //If map function generated the key, no need to regeneration
                if (key != null)
                    key = Guid.NewGuid();
                string tweetlongerurl = "http://" + HttpContext.Current.Request.Url.Authority + "/Tweet/" + key.ToString();
                text = text.Substring(0, 110) + " ... " + UtilityTool.ShortUrl(tweetlongerurl);
            }
        
            ITwitterLeafNode twitter;

            var access = UserManager.AccessToken;

            if (replyTo != 0)
                twitter = FluentTwitter.CreateRequest().AuthenticateWith(access.Token, access.TokenSecret)
                   .Statuses().Update(text).InReplyToStatus(replyTo).AsJson();
            else
                twitter = FluentTwitter.CreateRequest().AuthenticateWith(access.Token, access.TokenSecret)
                   .Statuses().Update(text).AsJson();


            var response = twitter.Request();

            if ((orgtext.Length > 140) || (lat != null))
                AddStatusesToOwnDB(key, response.AsStatus().Id, lat, lng, orgtext);

            return response.AsStatus();
        }    

        public IList<TwitterStatus> RetrieveStatusesByUser(string userid)
        {
            var twitter = FluentTwitter.CreateRequest().Configuration.UseGzipCompression().
                    Statuses().OnUserTimeline().For(userid).AsJson();
            string response = twitter.Request();
            var statuses = response.AsStatuses();
            if (response.AsError() == null)
            {
                IList<TwitterStatus> resultstatuses;
                resultstatuses = statuses.ToList();

                FormatTweetForNearBy(resultstatuses);

                return resultstatuses;
            }
            else
                return null;
        }

        public IList<TwitterStatus> RetrieveStatusesByUser(OAuthToken access)
        {
            var twitter = FluentTwitter.CreateRequest().Configuration.UseGzipCompression().
                   AuthenticateWith(access.Token, access.TokenSecret)
                   .Statuses().OnFriendsTimeline().AsJson();
            string response = twitter.Request();
            var statuses = response.AsStatuses();

            IList<TwitterStatus> resultstatuses;
            resultstatuses = statuses.ToList();

            FormatTweetForNearBy(resultstatuses);

            return resultstatuses;
        }

        #endregion
    }
}
