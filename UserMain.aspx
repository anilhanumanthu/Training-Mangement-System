<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserMain.aspx.cs" Inherits="UserMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        body{
            background-image:url(AdminBackgr.jpg);
            background-size:cover;
            padding:0;
            margin:0;
            height:100vh;
            width:100%;
        }
        header{
            height:8vh;
            width:100%;
            box-shadow:2px 5px rgb(10,40,30);
        }
        .StatusLabel{
            margin-left:40%;
            font-size:40px;
            font-weight:bold;
            font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color:white;
            text-shadow:1px 3px black;
        }
        .header1{
            height:0.5vh;
            width:100%;
            background-color:white;
            box-shadow:1px 3px 5px rgb(10,40,30);
        }
        .header2{
            height:1vh;
            width:100%;
            box-shadow:2px 5px rgb(16, 164, 73);
        }
        .Container{
            width:100%;
            height:90vh;
        }
        ::placeholder{
            color:white;
            text-align:center;
            font-size:25px;
        }
        .UserDetails{
            box-shadow:1px 5px 5px rgb(128, 128, 128);
            position:absolute;
            width:25%;
            height:80vh;
            margin-left:2%;
            margin-top:5vh;
            background-color:rgba(0, 0, 0, 0.5);
            color:white;
            font-size:30px;
            text-align:center;
            text-shadow:2px 5px black;
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }
        .UserSkillDetails {
            box-shadow:1px 5px 5px rgb(128, 128, 128);
            position:absolute;
            width:25%;
            height:80vh;
            margin-left:29%;
            margin-top:5vh;
            background-color:rgba(0, 0, 0, 0.5);
            color:white;
            font-size:30px;
            text-align:center;
            text-shadow:2px 5px black;
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }
        .UserCourseDetails{
            box-shadow:1px 5px 5px rgb(128, 128, 128);
            position:absolute;
            width:42%;
            height:80vh;
            margin-left:56%;
            margin-top:5vh;
            background-color:rgba(0, 0, 0, 0.5);
            color:white;
            font-size:30px;
            text-align:center;
            text-shadow:2px 5px black;
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }
        .UserDetailsInner{
            position:absolute;
            width:90%;
            height:94%;
            margin-left:3.5%;
            margin-top:3.5%;
            border: 5px solid white;
        }
        .UserCoursesInner{
            position:absolute;
            width:90%;
            height:90%;
            margin-left:3.5%;
            margin-top:3.5%;
            border: 5px solid white;
        }
        .UserPic{
            background-image:url(usericon.png);
            background-position:center;
            background-size:cover;
            width:90%;
            margin-left:5%;
            margin-top:5%;
            height:90%;
            border-radius:50%;
        }
        .UserPicOuter{
            width:30%;
            height:20%;
            border-radius:50%;
            margin-left:35%;
            margin-top:10%;
            border:2px solid white;
            box-shadow:3px 5px 5px rgb(0,0,0);
        }
        .SearchBar {
            height:25px;
            width:60%;
            text-align:center;
            color:white;
            font-size:25px;
            margin-right:5%;
            border-top:none;
            border-left:none;
            border-right:none;
            border-bottom-color:white;
            background-color:transparent;
        }
        .UserSkillSearchButton {
            text-decoration:none;
            color:black;
            text-shadow:0px 0px 0px;
            background-color:white;
            padding:5px;
            border-radius:15%;
        }
        .GridFixer{
            overflow:auto;
            text-align:left;
            height:75%;
            text-decoration:none;
            text-shadow:0px 0px 0px;
            width:95%;
            margin-left:2.5%;
        }
        .GridFixer1{
            overflow:auto;
            text-align:left;
            font-size:25px;
            text-decoration:none;
            text-shadow:0px 0px 0px;
            width:95%;
            margin-left:2.5%;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <header>
            
        <asp:Label class="StatusLabel" ID="StatusBar" runat="server" Text="Hello User"></asp:Label>
        </header>
        <div class ="header1"></div>
        <div class ="header2"></div>


    <div class="Container">

        <div class="UserDetails" ><div class="UserDetailsInner"><div class="UserPicOuter"><div class="UserPic"></div></div><br />
            <asp:Label ID="UserName" runat="server" Text="Admin Name"></asp:Label><br />
            <asp:Label ID="UserID" runat="server" Text="Admin ID"></asp:Label>
            <div class="GridFixer1">
                <asp:GridView ID="CoursesAccepted" CellPadding="5" HeaderStyle-BackColor="SlateGray" GridLines="None" runat="server"></asp:GridView>
            </div>
        </div>
        </div>

        <div class="UserSkillDetails" ><div class="UserDetailsInner"><br />

            <asp:TextBox ID="UserSkillSearch" CssClass="SearchBar" placeholder="Enter the Skill" runat="server"></asp:TextBox><asp:LinkButton CssClass="UserSkillSearchButton" ID="UserSkillSearchButton" runat="server" OnClick="UserSkillSearchButton_Click">Search</asp:LinkButton><br />
            <br />
            <div class="GridFixer"><asp:GridView CellPadding="5" ID="UserSkillSearchResult" runat="server" GridLines="None" OnRowCommand="UserSkillSearchResult_RowCommand">
                <Columns>
                    <asp:CommandField SelectText="Ok" ShowHeader="True" ShowSelectButton="True" ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Red" />
                </Columns>
                </asp:GridView></div>
            

        </div>
        </div>

        <div class="UserCourseDetails" ><div class="UserCoursesInner"><br />
            <div class="GridFixer"><asp:GridView CellPadding="5" ID="UserCourseDetailsView" runat="server" GridLines="None" OnRowCommand="UserCourseDetailsView_RowCommand">
                <Columns>
                    <asp:CommandField SelectText="Ok" ShowHeader="True" ShowSelectButton="True" ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Red" />
                </Columns>
                </asp:GridView>

        </div>
        </div>
        </div>



        </div>

</asp:Content>

