<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historical.aspx.cs" Inherits="weeklyreport.Historical" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


        <div class="jumbotron">
        <asp:Image ID="Image1" ImageAlign="Right" ImageUrl ="~/docxellentlogo.png" runat="server" />
        <br />
        <br />
        <h1>Client Usage Statistics</h1>  
        <p class="lead">Select Client from the Dropdown list to view Most Recent Report Results</p>
        <br />


    </div>
   &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;  <asp:Label ID="LabelDropDownListClients" runat="server" Text="Select Client: " Font-Bold="True"></asp:Label>
       
           
     <asp:DropDownList ID="DropDownListClients"  AutoPostBack="true"  OnSelectedIndexChanged="myListDropDown_Change"  runat="server"></asp:DropDownList> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
    
      &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;  <asp:Label ID="LabelDropDownListDate" runat="server" Text="Select Date Range: " Font-Bold="True"></asp:Label>
    

       <asp:DropDownList ID="DropDownListDate"  AutoPostBack="true"  OnSelectedIndexChanged="myListDropDown_Change"  runat="server"></asp:DropDownList> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
      
  

    <div class="row">
        <div class="col-md-4">
            <h2>Top10 Active ContentTypes</h2>
            <p>
                <asp:GridView ID ="Top10MostActiveContentTypes"   CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            </p>
           

        </div>
        <div class="col-md-4">
            <h2>Top10 Users (Most Logins)</h2>
            <p>
                <asp:GridView ID="Top10UsersMostLogins"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            
            </p>

        </div>
        <div class="col-md-4">
            <h2>Top10 Content Creators</h2>
            <p>
               <asp:GridView ID="Top10ContentCreators"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            </p>

        </div>
    </div>

   <!-- show a second row -->

       <div class="row">
        <div class="col-md-4">
                     <h2>top10 Popular CT</h2>
            <p>
<asp:GridView ID="top10MostPopularContentTypes"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            </p>
             <!-- <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p> -->
        </div>
        <div class="col-md-4">
            <h2>Busiest Times</h2>
            <p>
                <asp:GridView ID="BusiestTimes"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            </p>

        </div>
        <div class="col-md-4">
            <h2>Slowest Times</h2>
            <p>
               <asp:GridView ID="TopSlowestTimes"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            </p>

        </div>
    </div>
    
       <div class="row">
        <div class="col-md-4">
            <h2>Users/Last login Data</h2>
            <p>
                <asp:GridView ID="UsersandLastLogin"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"    runat="server"></asp:GridView>
            </p>
           

        </div>
        <div class="col-md-4">
            <h2>Users/Last login Data</h2>
            <p>
                <asp:GridView ID="AvgNumUsersDuringBusinessHoursByYear"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            
            </p>

        </div>
        <div class="col-md-4">
            <h2>Users/Last login Data</h2>
            <p>
               <asp:GridView ID="AvgNumUsersDuringBusinessHoursByMonth"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            </p>

        </div>
    </div>

            <div class="row">
        <div class="col-md-4">
            <h2>Users/Last login Data</h2>
            <p>
                <asp:GridView ID="AvgNumUsersDuringBusinessHoursByWeek"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            </p>
           

        </div>
        <div class="col-md-4">
            <h2>License Unavailable</h2>
            <p>
                <asp:GridView ID="LoginsWithNoLicenses"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            
            </p>

        </div>
        <div class="col-md-4">
            <h2>User Notified</h2>
            <p>
               <asp:GridView ID="License_Notify_User"  CssClass="Grid"  AlternatingRowStyle-CssClass="alt"   runat="server"></asp:GridView>
            </p>

        </div>
    </div>


</asp:Content>
