<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminAddCourseQuestions.aspx.cs" Inherits="AdminAddCourseQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        body{
            background-image:url(addqst.jpg);
            background-size:cover;
            margin:0;
            padding:0;
        }
        table{
            margin-top:20vh;
            margin-left:30%;
        }
        td{
            color:white;
            font-weight:bold;
            font-size:25px;
            padding-right:50px;
            font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif
        }
        .box{
            border-left-color:transparent;
            border-right-color:transparent;
            border-top-color:transparent;
            color:forestgreen;
            font-weight:bold;
            font-size:25px;
            outline:none;
            background-color:transparent;
            border-bottom-color:white;
        }
        .Sub{
            color:white;
            outline:none;
            border:none;
            padding:15px;
            font-size:25px;
            text-shadow:2px 2px 5px blue;
            border-radius:25%;
            background-color:cornflowerblue;
        }
        ::placeholder{
            color:forestgreen;
            font-weight:bold;
            font-size:25px;
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
    <a class="GoBack" href="AdminMainPage.aspx">Go Back</a>

    <table>
        <tr><td><asp:Label ID="CourseLabel" runat="server" Text="COURSE CODE"></asp:Label></td><td><asp:DropDownList CssClass="box" ID="CourseCodeDropList" runat="server"></asp:DropDownList></td></tr>
        <tr><td><asp:Label ID="QuestionLabel" runat="server" Text="QUESTION"></asp:Label></td><td><asp:TextBox CssClass="box" placeholder="Enter the Question" ID="QuestionBox" runat="server"></asp:TextBox></td></tr>
        <tr><td><asp:Label ID="OptionLabel1" runat="server" Text="OPTION 1"></asp:Label></td><td><asp:TextBox ID="Option1Box" placeholder="Enter the First Option" CssClass="box" runat="server"></asp:TextBox></td></tr>
        <tr><td><asp:Label ID="OptionLabel2" runat="server" Text="OPTION 2"></asp:Label></td><td><asp:TextBox ID="Option2Box" CssClass="box" placeholder="Enter the Second Option" runat="server"></asp:TextBox></td></tr>
        <tr><td><asp:Label ID="OptionLabel3" runat="server" Text="OPTION 3"></asp:Label></td><td><asp:TextBox ID="Option3Box" CssClass="box" placeholder="Enter the Third Option" runat="server"></asp:TextBox></td></tr>
        <tr><td><asp:Label ID="OptionLabel4" runat="server" Text="OPTION 4"></asp:Label></td><td><asp:TextBox ID="Option4Box" CssClass="box" placeholder="Enter the Fourth Option" runat="server"></asp:TextBox></td></tr>
        <tr><td><asp:Label ID="OptionLabel" runat="server" Text="Correct Option"></asp:Label></td><td><asp:DropDownList CssClass="box" ID="CorrectOptionDropList" runat="server">
        <asp:ListItem>A</asp:ListItem>
        <asp:ListItem>B</asp:ListItem>
        <asp:ListItem>C</asp:ListItem>
        <asp:ListItem>D</asp:ListItem>
    </asp:DropDownList></td></tr>
        <tr><td></td></tr>
        <tr><td><asp:Button CssClass="Sub" ID="SubmitQuestion" runat="server" Text="CREATE QUESTION" OnClick="SubmitQuestion_Click" /></td></tr>
        <tr><td><asp:Label ID="statuslabel" runat="server" Text=""></asp:Label></td></tr>
    </table>

    <asp:GridView ID="QuestionsData" runat="server" AutoGenerateSelectButton="True" OnRowCommand="QuestionsData_RowCommand" >
    </asp:GridView>

    </asp:Content>

