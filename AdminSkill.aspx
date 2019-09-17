<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminSkill.aspx.cs" Inherits="AdminSkill" %>

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
        .mainContainer {
            top: 50%;
            left: 50%;
            transform: translate(-30%,-50%);
            background-color: brown;
            height:15%;
            width:30%;
            border-radius: 10%;
            position: absolute;
        }
        .SkillBox {
            text-align: center;
            margin-left: 10%;
            font-size: 30px;
            padding: 15px;
            background-color: transparent;
            outline: none;
            color: white;
            border-top-color:transparent;
            border-left-color:transparent;
            border-right-color:transparent;
            border-bottom-color: white;
        }
        ::placeholder {
         color: white;
        }
        .AddSkill,.DeleteSkill {
            text-align: center;
            margin-left:20%;
            font-size: 20px;
            padding: 10px;
            color: white;
            background-color: black;
            border-radius:10%;
            outline: none;
            border: none;
            border-bottom-color: red;
            
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
        .GridBox {
            font-size:30px;
            color:white;
            font-weight:bold;
            padding:20px;
            font-style:italic;
            width:100%;
            text-align:center;
        }
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <header>
        <a class="GoBack" href="AdminMainPage.aspx">Go Back</a>
    <asp:Label CssClass="StatusBar" ID="StatusBar" runat="server" Text=""></asp:Label>
    </header>

    <div class="leftContainer"> <asp:GridView CssClass="GridBox" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SkillName" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="SkillName" HeaderText="SkillName" ReadOnly="True" SortExpression="SkillName" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:userdataConnectionString %>" SelectCommand="SELECT [SkillName] FROM [SkillSet]"></asp:SqlDataSource>
    </div>
    <div class="rightContainer">
        <div class="mainContainer"><br /><asp:TextBox CssClass="SkillBox" ID="SkillBox" placeholder="Enter your skill!!" runat="server"></asp:TextBox><br /><br />
            <asp:LinkButton CssClass="AddSkill" ID="AddSkill" runat="server" OnClick="AddSkill_Click">AddSkill</asp:LinkButton><asp:LinkButton CssClass="DeleteSkill" ID="DeleteSkill" runat="server" OnClick="DeleteSkill_Click">DeleteSkill</asp:LinkButton></div>
    </div>
</asp:Content>