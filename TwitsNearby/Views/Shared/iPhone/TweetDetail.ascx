<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Dimebrain.TweetSharp.Model.TwitterStatus>>" %>
<%@ Import Namespace="Dimebrain.TweetSharp.Model" %>
<%@ Import Namespace="TwitsNearby.Security" %>
  	<%  foreach (var item in ViewData.Model) 
                      { %>                      
                	<li>                 	
                	    <img src="<% =item.User.ProfileImageUrl %>" alt="<% =item.User.ScreenName %>"/>
                	    <span><% =item.User.ScreenName %></span>
                        <br /><% =item.Text  %>            	
                	</li>
<% } %>

