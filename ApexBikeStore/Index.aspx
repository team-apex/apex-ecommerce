<%@ Page Title="" Language="C#" MasterPageFile="~/Apex.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ApexBikeStore.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--styling-->
    <link href="Content/site.css" rel="stylesheet" />
    <link href="Content/jquery.bxslider.css" rel="stylesheet" />
    <link href="Content/jquery.cookiebar.css" rel="stylesheet" />
    <!--jquery-->
    <script src="Scripts/jquery.bxslider.min.js"></script>
    <script src="Scripts/jquery.cookiebar.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h4>Welcome to Apex Cycling</h4>
        <asp:Label runat="server" ID="lblCounter"></asp:Label>
        <hr/>
            <ul class="bxslider">
                <li>
                    <h6>Climb the highest mountain..</h6>
                    <img alt="picture" src="Content/Images/slider1.jpg"/>
                </li>
                <li>
                    <h6>Push your limits..</h6>
                    <img alt="picture" src="Content/Images/slider3.jpg"/>
                </li>
                <li>
                    <h6>Choose from a wide range of equipment and clothing..</h6>
                    <img alt="picture" src="Content/Images/slider2.jpg"/>
                </li>
                <li>
                    <h6>From your favourite brands.</h6>
                    <img alt="picture" src="Content/Images/slider4.jpg"/>
                </li>
           </ul>
        <hr/>
        <p>If you are looking for high-quality cycling gear at low prices you've found the right place. 
            Feel free to browse our online store, or call in to our 5,000 square foot retail complex, 
            and if you have any queries don't hesitate to contact one of our dedicated team members.
        </p>
    </div>
    <asp:Label runat="server" ID="lblCount"></asp:Label>
    <div id="side">
        <h5>Find Us</h5>
        <hr/>
        <div id="map-canvas"></div>
        <hr/>
        <div class="thumbs">
           <a href="Store.aspx">
               <div id="store">
                 <img alt="store" src="Content/Images/helmet.JPG"/>
                   <h6>New Products</h6>
               </div>
           </a>
           <a href="About.aspx">
               <div id="winning">
                  <img alt="winning" src="Content/Images/winning.jpg"/>
                   <h6>Quality Services</h6>
               </div>
           </a>
        </div>
        
    </div>
    <!--scripts-->
    <!--slider-->
    <script>
        $(document).ready(function () {
            $('.bxslider').bxSlider({
                auto: true,
                speed: 800,

            });
        });
    </script>
    <script>
        
        function initialize() {
            var mapCanvas = document.getElementById('map-canvas');
            var latLng = new google.maps.LatLng(54.268347, -8.472810);
            var mapOptions = {
                center: latLng,
                zoom: 14,
                marker: latLng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            }
            var map = new google.maps.Map(mapCanvas, mapOptions);
        }
        google.maps.event.addDomListener(window, 'load', initialize);

    </script>
    <script>
        $(document).ready(function() {
            $.cookieBar();
        });
    </script>
</asp:Content>
