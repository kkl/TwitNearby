using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.Configuration;
using Dimebrain.TweetSharp.Extensions;

namespace TwitsNearby.Utility
{
    public static class UtilityTool
    {
        private static string AddPerson(Match m)
        {
            string x = m.ToString();

            x = "<a href=" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/" + x.Trim('@') + ">" + x + "</a>";            
            //x = "<a href=" + HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/" + x.Trim('@') + ">" + x + "</a>";            
            return x;
        }

        private static string AddLink(Match m)
        {
            string x = m.ToString();
            x = "<a href=" + m.ToString() + ">" + m.ToString() + "</a>";
            return x;
        }

        public static string FormatTweet(string data)
        {

            //Must match URL first
            var regexURL = new Regex(@"http://[A-Za-z0-9\._\-\/]*");
            MatchCollection matchesURL = regexURL.Matches(data);
            string linkReady = regexURL.Replace(data, new MatchEvaluator(AddLink));

            var regexPerson = new Regex(@"@[A-Za-z0-9_\-]*");
            MatchCollection matches = regexPerson.Matches(linkReady);
            return regexPerson.Replace(linkReady, new MatchEvaluator(AddPerson));
          
        }

        public static string ShortUrl(string data)
        {
            WebClient wc = new WebClient();
            string shortenurl = wc.DownloadString(ConfigurationManager.AppSettings["shortenUrlApi"] + "&longUrl=" +data
                + "&login=" + ConfigurationManager.AppSettings["bitlyLogin"]+ "&apiKey=" +
                ConfigurationManager.AppSettings["bitlyApiKey"]);

            Regex regex = new Regex(@"shortUrl.*(h.+?)\""");
            //shortenurl = regex.Match(shortenurl).Groups[0].ToString();
            var a = regex.Match(shortenurl);

            return a.Groups[1].ToString();
            
        }
     
    }
}
