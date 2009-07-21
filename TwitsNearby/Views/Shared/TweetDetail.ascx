<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Dimebrain.TweetSharp.Model.TwitterStatus>>" %>
<%@ Import Namespace="Dimebrain.TweetSharp.Model" %>
<%@ Import Namespace="TwitsNearby.Security" %>
<link rel="stylesheet" href="/Content/mainstyle.css" />
                	<!--<div class="tweetHR"></div>-->                                    	
                   	<%  foreach (var item in ViewData.Model) 
                      { %>                      
                	<div class="tweetFrame">                	
                    	<div class="tweetPic"><img src=" <% =Html.Encode(item.User.ProfileImageUrl) %>"/></div>
                        <div id="<% =item.Id %>" class="tweetBody"><span class="tweetUsers"> <a href="<% = HttpContext.Current.Request.Url.AbsolutePath + Html.Encode(item.User.ScreenName) %>"><% =Html.Encode(item.User.ScreenName) %></a></span><span class="tweetTxt"> <% =item.Text %></span></div>
                        <div class="tweetBottom">
                            <div class="tweetHistory"><% =item.CreatedDate %><span class="tweetLocation">He is now @Festival Walk (5km from you)</span></div>
                            <div class="tweetReply" <% =UserManager.HTMLVisible() %> onclick="ReplyOnClick('<% =item.Id %>')"></div>
                            <div class="tweetRT" <% =UserManager.HTMLVisible() %> onclick = "RTOnClick('<% =item.Id %>')"></div>
                            <div class="tweetFav" <% =UserManager.HTMLVisible() %> onclick="favOnClick('0001')"></div>
                        </div>
                    </div>
<% } %>
 
                    