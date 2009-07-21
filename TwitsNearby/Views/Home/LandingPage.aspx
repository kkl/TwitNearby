<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html  xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>TwitsNearBy</title>
    
    <script type="text/javascript" src="/Scripts/jquery-1.3.2.js"></script>
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=abcdefg&sensor=true"
            type="text/javascript"></script>


    <link rel="stylesheet" href="/Content/mainstyle.css" />
    <%--<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>--%>
    <script type="text/javascript">
        
		
		  //google.load("maps", "2.x");
        //
        $(document).ready(function()
        {

            if (GBrowserIsCompatible())
            {


                var map = new GMap2(document.getElementById("MapDiv"));
                var center = new GLatLng(22.298626203841582, 114.1754150390625);
                map.setCenter(center, 11);
                //$('tweetlat').serializeArray()
//                var marker = new GMarker(center, { draggable: true });

//                GEvent.addListener(marker, "dragend", function()
//                {
//                    $("#Lat").val(marker.getLatLng().lat());
//                    $("#Lng").val(marker.getLatLng().lng());
//                });


//                map.addOverlay(marker);

//                $("#MapDiv").hide();

            }

        });

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
//		    var map = new GMap2(document.getElementById("MapDiv"));
//		    var marker = new GMarker((new GLatLng(lat, lng)), { draggable: false });
//		    map.setCenter(new GLatLng(lat, lng), 17);
//		    map.disableDragging();
//		    map.addOverlay(marker);
//		    map.addControl(new GSmallZoomControl());
//		    $("#" + id).css('background', 'url(../Img/bg_blue.png) top left repeat');
		}
    </script>
</head>

<body>
	<div id="MainContainer">
        <div class="headerFrame">
        	<%--<div class="barFrame">
            	<div class="barItem">
                	<div class="barFont">Nearby</div>
                    <div id="Bar0001" class="barBG"></div>
                </div>
            	<div class="barItem">
                	<div class="barFont">Tweets</div>
                    <div id="Bar0002" class="barBG"></div>
                </div>
                <div class="barItem">
                	<div class="barFont"><% =Html.ActionLink("Login","oAuth","Home") %></div>
                    <div id="Bar0003" class="barBG"></div>
                </div>
                <div class="barItem">
                	<div class="barFont">Help</div>
                    <div id="Bar0004" class="barBG"></div>
                </div>
                <div style="float:right; height:50px;font-size:48px;">
                    TESt
                </div>
            </div>--%>
            <div style="height:100px;">
            
            </div>
            <div id="SubHeaderDiv" style="border:#666 1px solid;">
                <div id="MapDiv" style="height:300px;"></div>  
                <%--<div style="border:red thin solid; position:relative;top:50px;left:0px;height:50px;width:50px;z-index:999;"></div>--%>
            </div>
            <div style="text-align:center;margin-top:20px;">
                <a href="/Home/oAuth"><img src="/Img/Connect_to_twitter.png" /></a>
                <%--<div id="ConnectToTwitterBtn"><% =Html.ActionLink("login","oAuth","Home") %></div>--%>
            </div>
        </div>
        

		<hr />
		<div class="mainFrame ">
                <div class="mainContent">
                  <div class="leftFrame">
                    	<div class="tweetDistrictSmall">Recent activity around Central District</div>
                    	<div class="tweetFrameSmall" id="001" onmouseover="moveMap(this.id)"> 
                        	<div class="tweetPic"><img src="http://s3.amazonaws.com/twitter_production/profile_images/239143966/Sans-titre-1_normal.jpg"/></div>
                            <div class="tweetBodySmall"><span class="tweetUsersSmall"><a>Tortue</a></span> Hooo...watching #MJ funerals. Its coffin just appeared</div>
                            <div class="tweetPhoto"><img class="tweetPreview" src="http://photos-e.ak.fbcdn.net/hphotos-ak-snc1/hs172.snc1/6455_146941620096_644825096_3601372_1335740_n.jpg"  width="300px" height="100px" /></div>
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
                        <div style="background-color:#EEEEEE;height:200px;width:260px;margin:15px;" ></div>
                    </div>
                    <div class="clearFix"></div>
                </div>
        </div>
			
        <%--<hr/>--%>    	
        <div class="footerFrame ">
        	<div style="float:right">
                <div class="footerText">Services </div>
                <div class="footerText">Policy </div>
                <div class="footerText">About Us </div>
                <div class="footerText">Contact Us</div>                                              
            </div>
        </div>        
    </div>
    <div> 
            
       
    </div>
</body>
</html>
