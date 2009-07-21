<%@ Page Title="" MasterPageFile="~/Views/Shared/Site.Master" Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
    <script type="text/javascript">
        
		
		  //google.load("maps", "2.x");
   
		// Call this function when the page has been loaded
		function initialize() {
		var map = new GMap2(document.getElementById("MapDiv"));
		var lat = $("#001"+ " " + ".tweetLat").val();
		var lng = $("#001" +" " + ".tweetLng").val();
        map.setCenter(new GLatLng(lat, lng), 13);				
		}

		function moveMap(id)
		{
		    //var lat = "22.329583";
		    //var lng = "114.178848";
		    $(".tweetFrameSmall").css('background', '');
		    var lat = $("#" + id + " " + ".tweetLat").val();
		    var lng = $("#" + id + " " + ".tweetLng").val();
		    var map = new GMap2(document.getElementById("MapDiv"));
		    var marker = new GMarker((new GLatLng(lat, lng)), { draggable: false });
		    map.setCenter(new GLatLng(lat, lng), 17);
		    map.disableDragging();
		    map.addOverlay(marker);
		    map.addControl(new GSmallZoomControl());
		    $("#" + id).css('background', 'url(../Img/bg_blue.png) top left repeat');
		}
    </script>
</asp:Content> 
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    
                    <div class="leftFrame">
                    	<div class="tweetDistrictSmall">Recent activity around Central District</div>
                    	<div class="tweetFrameSmall" id="001" onmouseover="moveMap(this.id)"> 
                        	<div class="tweetPic"><img src="http://s3.amazonaws.com/twitter_production/profile_images/239143966/Sans-titre-1_normal.jpg"/></div>
                            <div class="tweetBodySmall"><span class="tweetUsersSmall"><a>Tortue</a></span> Hooo...watching #MJ funerals. Its coffin just appeared</div>
                            <div class="tweetBottomSmall">12 minutes ago<span class="tweetLocation">@Stanley Street (5km from you)</span></div>
                            <input type="hidden" value="22.215017" class="tweetLat" />
                            <input type="hidden" value="114.214897"  class="tweetLng" />
                        </div>
                        <div class="tweetFrameSmall" id="002" onmouseover="moveMap(this.id)"> 
                        	<div class="tweetPic"><img src="http://s3.amazonaws.com/twitter_production/profile_images/246248433/when_i_was_young_normal.jpg"/></div>
                            <div class="tweetBodySmall"><span class="tweetUsersSmall"><a>ViannaK</a></span> Goodbye MJ, will miss you a lot...</div>
                            <div class="tweetBottomSmall">12 minutes ago<span class="tweetLocation">@Starbrucks (5km from you)</span></div>
                            <input type="hidden" value="22.284777" class="tweetLat" />
                            <input type="hidden" value="114.154488"  class="tweetLng" />
                        </div>
                        <div class="tweetFrameSmall" id="003" onmouseover="moveMap(this.id)"> 
                        	<div class="tweetPic"><img src="http://s3.amazonaws.com/twitter_production/profile_images/281778320/green_5194_yup_normal.jpg"/></div>
                            <div class="tweetBodySmall"><span class="tweetUsersSmall"><a>elliotschimel</a></span> Help Daniella raise money for the Leukemia Lymphoma Society. Pls donate ($5 would be amazing!) at <a>http://bit.ly/ptUMn</a>. Thank you!</div>
                            <div class="tweetBottomSmall">12 minutes ago<span class="tweetLocation">@Elements (5km from you)</span></div>
                             <input type="hidden" value="22.303922" class="tweetLat" />
                            <input type="hidden" value="114.161296"  class="tweetLng" />
                        </div>
                        <div class="tweetFrameSmall" id="004" onmouseover="moveMap(this.id)"> 
                        	<div class="tweetPic"><img src="http://s3.amazonaws.com/twitter_production/profile_images/239143966/Sans-titre-1_normal.jpg"/></div>
                            <div class="tweetBodySmall"><span class="tweetUsersSmall"><a>Tortue</a></span> Hooo...watching #MJ funerals. Its coffin just appeared</div>
                            <div class="tweetBottomSmall">12 minutes ago<span class="tweetLocation">@Festival Walk (5km from you)</span></div>
                             <input type="hidden" value="22.337111" class="tweetLat" />
                            <input type="hidden" value="114.174964"  class="tweetLng" />
                        </div>

                    </div>
                    
                    <div class="rightFrame">
                        <div id="MapDiv" style="width:300px;height:250px;text-align:center;" ><img src="/Img/ajax-loader.gif" /></div>
                    </div>
                    <div class="clearFix"></div>
</asp:Content>			
