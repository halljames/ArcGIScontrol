<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
    <%@ Register Namespace="ArcGisControl" TagPrefix="mc" Assembly="ArcGisControl" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <asp:ScriptManager runat="server" ID="ScriptManager1">
    </asp:ScriptManager>
    <div>
    <mc:ArcGisMap ID="mapDiv" runat="server" geoRSS="https://dl.dropboxusercontent.com/s/hrb042pld1io7i7/rss.xml" CenterLatitude="36.1658" CenterLongitude="-86.7844" Width="700" Height="500">
    </mc:ArcGisMap>
    

    </div>
    
    
</asp:Content>
