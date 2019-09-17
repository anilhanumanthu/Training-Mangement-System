<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminCourseDetails.aspx.cs" Inherits="AdminCourseDetails" %>

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
        ::placeholder {
         color: white;
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
            color:white;
            margin-left:5%;
            font-weight:bold;
            background-color:black;
            border-radius:10px;
            padding:10px;
        }
        .updatebutton {
            text-decoration:none;
            font-size:30px;
            color:white;
            margin-left:5%;
            font-weight:bold;
            background-color:black;
            border-radius:10px;
            padding:10px;
        }
        .Viewer{
            margin-top:5%;
            margin-left:5%;
            width:90%;
            height:75%;
            background-color:black;
        }
        .Editor{
            margin-top:5%;
            margin-left:5%;
            width:90%;
            height:75%;
            background-color:black;
        }
        .Deletor{
            margin-top:5%;
            margin-left:5%;
            color:white;
            width:90%;
            height:75%;
            background-color:black;
        }
        td{
            font-size:25px;
            color:white;
            font-weight:bold;
            padding-top:10px;
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

        <asp:LinkButton class="GoBack" ID="ViewLinkButton" runat="server" OnClick="ViewLinkButton_Click">View</asp:LinkButton>
        <asp:LinkButton class="GoBack" ID="EditLinkButton" runat="server" OnClick="EditLinkButton_Click">Edit</asp:LinkButton>
        <asp:LinkButton class="GoBack" ID="DeleteLinkButton" runat="server" OnClick="DeleteLinkButton_Click">Delete</asp:LinkButton>

        <div id="Viewer" class="Viewer" runat="server">
            <table>
                <tr><td><span style="color:red;">CourseCode is :</span></td><td><asp:Label ID="CourseCodeDet" runat="server" Text=""></asp:Label></td></tr>
                <tr><td><span style="color:red;">CourseDescription is :</span></td><td><asp:Label ID="CourseDescriptionDet" runat="server" Text=""></asp:Label></td></tr>
                <tr><td><span style="color:red;">SkillName is :</span></td><td><asp:Label ID="SkillNameDet" runat="server" Text=""></asp:Label></td></tr>
                <tr><td><span style="color:red;">CourseDate is :</span></td><td><asp:Label ID="CourseDateDet" runat="server" Text=""></asp:Label></td></tr>
                <tr><td><span style="color:red;">CourseTime is :</span></td><td><asp:Label ID="CourseTimeDet" runat="server" Text=""></asp:Label></td></tr>
                <tr><td><span style="color:red;">CourseAddedBy is :</span></td><td><asp:Label ID="CourseAddedByDet" runat="server" Text=""></asp:Label></td></tr>
                <tr><td><span style="color:red;">OtherReferences are :</span></td><td><asp:Label ID="OtherReferencesDet" runat="server" Text=""></asp:Label></td></tr>
            </table>
            
        </div>


        <div id="Editor" class="Editor" runat="server">
            
            <table>
                <tr><td><span style="color:red;">CourseCode is :</span></td><td><asp:TextBox ID="CourseInsert" runat="server"></asp:TextBox></td></tr>
                <tr><td><span style="color:red;">CourseDescription is :</span></td><td><asp:TextBox ID="CourseDescriptionInsert" runat="server"></asp:TextBox></td></tr>
                <tr><td><span style="color:red;">OtherReferences are :</span></td><td><asp:TextBox ID="OtherReferenceInsert" runat="server"></asp:TextBox></td></tr>
                <tr><td colspan="2"><asp:Button CssClass="updatebutton" ID="UpdateCourse" runat="server" Text="Update" OnClick="UpdateCourse_Click" /></td></tr>
            </table>
            
            </div>
        <div id="Deleted" class="Deletor" runat="server">Course Has been Deleted!!!</div>
    </div>
</asp:Content>

