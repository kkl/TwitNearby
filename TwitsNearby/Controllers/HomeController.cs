using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dimebrain.TweetSharp.Fluent;
using Dimebrain.TweetSharp.Extensions;
using Dimebrain.TweetSharp.Model;
using Dimebrain.TweetSharp;
using System.Configuration;
using TwitsNearby.Security;
using TwitsNearby.Utility;
using System.Net;
using TwitsNearby.Models;
using Microsoft.Practices.Unity;



namespace TwitsNearby.Controllers
{


    [HandleError]
    public class HomeController : Controller
    {

        private string _consumerKey;
        private string _consumerSecret;
        private string requestToken;
        private OAuthToken access;

        [Dependency]
        public IStatusesService StatusesService { get; set; }

        public ActionResult Nearby()
        {            
            return View();
        }
        public ActionResult LandingPage()
        {
            return View();
        }

        public ActionResult iPhoneHome()
        {            
            IEnumerable<TwitterStatus> statuses = StatusesService.RetrieveStatusesByUser("IamHonger");       
            return View("iphone/home", statuses);
        }

        public ActionResult Home(string id)
        {

            access = UserManager.GetToken();
            if ((HttpContext.Request["oauth_token"] != null) && (access == null))
                oAuthExecute();

            if ((string.IsNullOrEmpty(id)) && (access == null))
                id="iamhonger";
          
            IEnumerable<TwitterStatus> statuses;            

            if (!(string.IsNullOrEmpty(id)))            
                statuses =StatusesService.RetrieveStatusesByUser(id);                
            else            
                //Assume login in already
                statuses = StatusesService.RetrieveStatusesByUser(access);                
                
            if (statuses!=null)
                return View(statuses);
            else
                return Redirect("http://twitter.com/" + id);                   

        }

        public ActionResult About()
        {
            return View();
        }
    
        [AuthorizeAgainstUserManager]
        public ActionResult Update(FormCollection form)
        {
            string text;

            double? lat=null;
            double? lng=null;

            access = (OAuthToken)UserManager.GetToken();

            text= form[0];

            //Get ReplyToID
            long replyTo;

            if (form[1] != "")
            {                
                lat = Math.Round(Convert.ToDouble(form[1]), 6);
                lng = Math.Round(Convert.ToDouble(form[2]), 6);             
            }

            Int64.TryParse(form[3], out replyTo);

            var status = StatusesService.AddStatuses(lat, lng, text, replyTo);
          

            IList<TwitterStatus> statuses = new List<TwitterStatus>();
            statuses.Add(status);

            StatusesService.FormatTweetForNearBy(statuses);
            
            return PartialView("TweetDetail", statuses);            
        }

        public ActionResult oAuth()    
        {               
            oAuthExecute();
            return new EmptyResult();
        }

        private void oAuthExecute()
        {
            _consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            _consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];

            TwitterClientInfo myClientInfo = new TwitterClientInfo();
            myClientInfo.ClientName = "TwistHelloKitty";
            myClientInfo.ClientUrl = "http://www.hellokittyland.com";
            myClientInfo.ClientVersion = "0.0.0.1";
            myClientInfo.ConsumerKey = _consumerKey;
            myClientInfo.ConsumerSecret = _consumerSecret;

            FluentTwitter.SetClientInfo(myClientInfo);

            requestToken = HttpContext.Request["oauth_token"];
                        
            if (requestToken == null && ( Session["accessToken"] == null))
            {
                var request = GetRequestToken();
                // retrieve a URL used to direct the user to authorize, and
                // return to this page with a token
                                
                var authorizeUrl = FluentTwitter.CreateRequest().Authentication.GetAuthorizationUrl(request.Token, "http://localhost:1113");
                Response.Redirect(authorizeUrl);
            }
            else
            {                
                // exchange returned request token for access token
                if (access==null)
                access = GetAccessToken(requestToken);
                UserManager.GrantToken(access);                
                // make an oauth-authenticated call with the access token,
                // and remember you need to persist this token for this user&apos;s auth 
                //var query = FluentTwitter.CreateRequest().AuthenticateWith(_consumerKey, _consumerSecret, access.Token, access.TokenSecret)
                //    .Account().VerifyCredentials().AsXml();
                //// use as normal
                //var response = query.Request();
                //GetResponse(response);
            }
        }

        private void GetResponse(string response)
        {           
            var identity = response.AsUser();
            if (identity != null) 
            {               
                Console.WriteLine(String.Format("{0} authenticated successfully.", identity.ScreenName));  
            }
            else
            { 
                var error = response.AsError(); 
                if (error != null)
                {   
                    //trace.InnerHtml = error.ErrorMessage; 
                }
            }
        }
        
        private OAuthToken GetAccessToken(string requestToken) 
        { 
            var accessToken = FluentTwitter.CreateRequest().Authentication.GetAccessToken(_consumerKey, _consumerSecret, requestToken);
            var response = accessToken.Request();  
            var result = response.AsToken();
            if (result == null)
            { 
                var error = response.AsError(); 
                if (error != null)
                { 
                    throw new Exception(error.ErrorMessage); 
                } 
            }
            return result; 
        }
        
        private OAuthToken GetRequestToken() 
        {
            var requestToken = FluentTwitter.CreateRequest().Authentication.GetRequestToken(_consumerKey, _consumerSecret);
            var response = requestToken.Request();
            var result = response.AsToken();
            if (result == null) 
            {
                var error = response.AsError();
                if (error != null)
                {
                    throw new Exception(error.ErrorMessage); 
                } 
            }
            return result; 
        }
    
    }
}
