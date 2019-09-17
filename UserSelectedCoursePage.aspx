<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserSelectedCoursePage.aspx.cs" Inherits="UserSelectedCoursePage" %>

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
            font-size:20px;
            display:inline-block;
            float: left;
            overflow:auto;
        }
        .rightContainer {
            height: 90vh;
            width: 80%;
            background-color: aliceblue;
            display:inline-block;
            float: right;
            
        }
        ::placeholder {
         color: black;
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
        .CourseDataButton{
            text-decoration:none;
            font-size:30px;
            display:inline-block;
            color:white;
            margin-left:5%;
            margin-top:10%;
            font-weight:bold;
            background-color:black;
            border-radius:10px;
            padding:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <header>
        <a class="GoBack" href="UserMain.aspx">Go Back</a>
    <asp:Label CssClass="StatusBar" ID="StatusBar" runat="server" Text=""></asp:Label>
    </header>

    <div class="leftContainer">
        
        <asp:LinkButton CssClass="CourseDataButton" ID="TakeCourse" runat="server" OnClick="TakeCourse_Click">Take-Course</asp:LinkButton>

        <asp:GridView ID="CourseDataMaterial" HeaderStyle-BackColor="White" GridLines="None" RowStyle-ForeColor="White" runat="server" OnRowCommand="CourseDataMaterial_RowCommand">
            <Columns>
                <asp:CommandField HeaderText="Select" ShowHeader="True" ControlStyle-ForeColor="YellowGreen" ShowSelectButton="True" />
            </Columns>
<HeaderStyle BackColor="White"></HeaderStyle>

<RowStyle ForeColor="White"></RowStyle>
        </asp:GridView>

        <asp:LinkButton CssClass="CourseDataButton" ID="TakeAssessment" runat="server" OnClick="TakeAssessment_Click">Take-Assesment</asp:LinkButton>

    </div>




    <div class="rightContainer">

        <br />

        <iframe id="myframe" style="margin-left:10%;margin-top:2%;" visible="false" runat="server" height="750" width="1200"></iframe>
        
    </div>

</asp:Content>

