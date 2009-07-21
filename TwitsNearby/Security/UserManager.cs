using System.Web;
using Dimebrain.TweetSharp.Model;


namespace TwitsNearby.Security
{
    /// <summary>     
    /// This is a very basic security implementation for demonstration purposes only.     
    /// By holding the twitter username and password in Session, we can pass these through      
    /// to Twitter with requests that require them.     
    /// No authentication is performed until a request is made against Twitter.     
    /// </summary>     
    public static class UserManager     
    {         
        public static bool HasCredentials { get { return !(AccessToken==null); } } 

        public static void GrantToken(OAuthToken access)
        {
            HttpContext.Current.Session["accessToken"] = access;                        
        }

        public static OAuthToken GetToken()
        {
            return (OAuthToken)HttpContext.Current.Session["accessToken"];
        }
        
        
        public static OAuthToken AccessToken
        {            
            get             
            {                 
                var accessToken = HttpContext.Current.Session["accessToken"] as OAuthToken;
                return accessToken;
            }
        }

        public static string HTMLVisible()
        {
            if (HasCredentials)
                return "";
            else
                return "style='display:none'";
        }

        public static string ShortHTMLVisible()
        {
            if (HasCredentials)
                return "";
            else
                return " display:none";
        }
 
    } 
}
