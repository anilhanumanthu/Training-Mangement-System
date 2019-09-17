<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserPresentTestCalculus.aspx.cs" Inherits="UserPresentTestCalculus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        header {
            width: 100%;
            height: 10vh;
            background-color: chocolate;
        }
        body {
            margin: 0;
            padding: 0;
            height: 100vh;
            width: 100%;
        }
        .StatusBar {
            font-weight:bold;
            text-shadow:2px 3px rgb(128, 128, 128);
            margin-left:40%;
            line-height:100px;
            font-size:30px;
            color:white;
        }
        .GoBack {
            text-decoration:none;
            font-size:30px;
            display:inline-block;
            color:white;
            margin-left:5%;
            font-weight:bold;
            background-color:black;
            border-radius:10px;
            padding:10px;
        }
        .new{
            margin-left:30%;
            background-color:whitesmoke;
            font-size:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <header>
        <a class="GoBack" href="UserMain.aspx">Go Back</a>
    <asp:Label CssClass="StatusBar" ID="StatusBar" runat="server" Text=""></asp:Label>
    </header>

    <br /><br /><br />
    <asp:GridView CssClass="new" ID="afterAnswered" runat="server">
        <EditRowStyle BorderColor="#FF6600" />
        <HeaderStyle BackColor="#999999" BorderColor="#FF6600" />
    </asp:GridView>

</asp:Content>

