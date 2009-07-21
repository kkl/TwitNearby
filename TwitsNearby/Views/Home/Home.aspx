<%@ Page Language="C#"  MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Dimebrain.TweetSharp.Model.TwitterStatus>>" %>
<%@ Import Namespace="TwitsNearby.Security" %>
<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
    <script type="text/javascript">


    //google.load("maps", "2.x");


    //Jquery with Google Map

        $(document).ready(function() {

            if (GBrowserIsCompatible()) {


                var map = new GMap2(document.getElementById("MapDiv"));
                var center = new GLatLng(22.298626203841582, 114.1754150390625);
                map.setCenter(center, 11);

                var marker = new GMarker(center, { draggable: true });

                GEvent.addListener(marker, "dragend", function() {
                    $("#Lat").val(marker.getLatLng().lat());
                    $("#Lng").val(marker.getLatLng().lng());                     
                });


                map.addOverlay(marker);

                $("#MapDiv").hide();

            }

        });

//    GMap V2, Call this function when the page has been loaded
//    function initialize() {
//        var map = new GMap2(document.getElementById("MapDiv"));
//        map.setCenter(new GLatLng(22.298626203841582, 114.1754150390625), 11);

//        var marker = new GMarker(center, { draggable: true });

//        map.addOverlay(marker);

//        document.getElementById("MapDiv").style.display = 'none';
//        //$("#MapDiv").hide();

//    }


    
//GMap V3, Hope it could work later
//    function initialize() {
//        var latlng = new google.maps.LatLng(22.298626203841582, 114.1754150390625);
//        var myOptions = {
//            zoom: 12,
//            center: latlng,
//            mapTypeId: google.maps.MapTypeId.ROADMAP
//        };
//        var map = new google.maps.Map(document.getElementById("MapDiv"), myOptions);

//        var marker = new google.maps.Marker({
//            position: myLatLng,
//            map: map
//        });

//        $("#MapDiv").hide();
//        
//    }


    function ShowMap(thisid) {
        
        if ($("#"+thisid).attr('checked'))
            $("#MapDiv").show()
        else
            $("#MapDiv").hide();
    }


    function ReplyOnClick(id)
    {
        var tweetsBoxVal = removeAnchor($("#TweetsBox").val());
        var user = removeAnchor($("#" + id + " a").html());
        $("#TweetsBox").val(tweetsBoxVal + "@" + user + " ");
        $("#ReplyTo").val(id);
    }

    function RTOnClick(id)
    {
        var tweets = removeAnchor($("#" + id + " .tweetTxt").html());
        var user = removeAnchor($("#" + id + " a").html());
        $("#TweetsBox").val("RT @" + user + " " + tweets);        
    }

    function favOnClick(id)
    {
        var tweets = removeAnchor($("#" + id).html());
        var user = removeAnchor($("#" + id + " .tweetUsers").html());
        $("#TweetsBox").val("RT @" + user + " " + tweets);
    }
    
    function isFav()
    {
    
    }
    function removeAnchor(txt) {    
            
        var removeahref = (txt.replace(/<a href=.*?>/g, ""));
        
        return removeahref.replace(/<\/a>/g,"");

    }

    function ClearTextbox(content) {
        $("#TweetsBox").val("");
        $("#Lat").val("");
        $("#Lng").val("");
        $("#ReplyTo").val("");        
    }    
    
    </script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
   <div <% =UserManager.HTMLVisible() %>>
   <% using (Ajax.BeginForm("Update", new AjaxOptions { UpdateTargetId = "AddedTweet",  OnSuccess = "ClearTextbox" }))
   { %>
    <%=Html.TextArea("TweetsBox", null, new { rows = "5", cols = "100", style = "margin-left:20px;margin-bottom:10px;" + UserManager.ShortHTMLVisible() })%>	
    <br/>                        
    <input id="ChkShowMap" type="checkbox" <% =UserManager.HTMLVisible() %> onclick="ShowMap(this.id);" /><span>Show Map</span>
    <input id="Lat" name="Lat" type="hidden" />
    <input id="Lng" name="Lng" type="hidden" />
    <input id="ReplyTo" name="ReplyTo" type="hidden" />
	<input id="TweetsBoxSubmit" type="submit" value="Update" <% =UserManager.HTMLVisible() %> style="float:right;margin-bottom:20px;margin-right:20px;"/>
	
    <br/>                     
   <% } %>                    
   </div>   
   <div id="MapDiv"></div>
   <div style="height:20px;width:800px;border-bottom:dashed 1px #666;">
    	&nbsp;
   </div>   
   <div id="AddedTweet"></div>                   
   <% Html.RenderPartial("TweetDetail"); %>
    <!--<hr style="border:dashed thin #666666"/>-->
    
    
	<!--<div class="leftFrame">
    </div>
	<div class="rightFrame">
    	<div id="MapDiv" ></div>
    </div>-->

</asp:Content>