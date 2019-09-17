<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminCourseCreationPage.aspx.cs" Inherits="AdminCourseCreationPage" %>

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
        .leftContainer {
            height: 90vh;
            width: 20%;
            background-color: brown;
            display:inline-block;
            float: left;
        }
        .rightContainer {
            height: 90vh;
            width: 80%;
            background-color: aliceblue;
            display:inline-block;
            float: right;
            
        }
        .EachTab{
            text-decoration:none;
            font-size:30px;
            color:white;
            margin-left:5%;
            
            font-weight:bold;
            background-color:black;
            border-radius:10px;
            padding:10px;
        }
        .EachTab1{
            text-decoration:none;
            font-size:30px;
            color:white;
            margin-left:5%;
            height:35%;
            margin-top:5%;
            margin-bottom:5%;
            width:50%;
            font-weight:bold;
            background-color:black;
            border-radius:10px;
            padding:10px;
        }
        .GoBack {
            text-decoration:none;
            font-size:30px;
            color:white;
            margin-left:5%;
            font-weight:bold;
            background-color:black;
            border-radius:10px;
            padding:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <header>
        <a class="GoBack" href="AdminMainPage.aspx">Go Back</a>
    <asp:Label CssClass="StatusBar" ID="StatusBar" runat="server" Text=""></asp:Label>
    </header>

    <div class="leftContainer"></div>



    <div class="rightContainer">

        <asp:TextBox ID="CourseCode" CssClass ="EachTab" runat="server" placeholder="CourseCode"></asp:TextBox><br />
        <asp:TextBox ID="CourseDescription" CssClass ="EachTab1" runat="server" placeholder="CourseDescription"></asp:TextBox><br />
            <asp:DropDownList ID="SkillSetDropDown" CssClass ="EachTab" runat="server"></asp:DropDownList>
        <asp:TextBox ID="Other_Reference" CssClass ="EachTab" runat="server" placeholder="Other_Reference"></asp:TextBox>
        <asp:Button ID="CourseInsertion" CssClass ="EachTab" runat="server" Text="Add Course" OnClick="CourseInsertion_Click" />

    </div>

</asp:Content>