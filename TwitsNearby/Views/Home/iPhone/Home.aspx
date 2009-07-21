<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Northwind Explorer</title>
    <meta name="viewport" content="width=320; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;"/>
    <style type="text/css" media="screen">@import "/Content/iui/iui.css";</style>
    <script type="application/x-javascript" src="/Scripts/iui/iui.js"></script>

</head>
<body>
     <div class="toolbar">
        <h1 id="pageTitle"></h1>
        <a id="backButton" class="button" href="#"></a>
    </div>
     
     <ul id="home" title="Music" selected="true">   
     <% Html.RenderPartial("iphone/TweetDetail"); %>
     </ul>
</body>
</html>

