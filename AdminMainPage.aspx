<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminMainPage.aspx.cs" Inherits="AdminMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        function gill() {
            window.location.assign('AdminSkill.aspx');
        }
    </script>
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
        .PriorityChanger{
            box-shadow:1px 5px 5px rgb(128, 128, 128);
            position:absolute;
            width:22%;
            height:25vh;
            margin-left:5%;
            margin-top:5vh;
            color:white;
            text-align:center;
            text-shadow:1px 2px rgb(26, 221, 18);
            background-color:transparent;
        }
        .PriorityRequestedTextBox{
            width:75%;
            height:5vh;
            border:none;
            text-align:center;
            border-bottom:2px solid white;
            outline:none;
            background-color:transparent;
            color:white;
            font-size:25px;
        }
        ::placeholder{
            color:white;
            text-align:center;
            font-size:25px;
        }
        .PriorityChangerButton{
            text-align:center;
            padding:10px;
            text-shadow:none;
            font-weight:bold;
            font-size:20px;
            background-color:white;
            text-decoration:none;
            color:cornflowerblue;
            border-radius:10px;
            box-shadow:5px 5px 5px rgb(128, 128, 128);
        }
        .AdminDetails{
            box-shadow:1px 5px 5px rgb(128, 128, 128);
            position:absolute;
            width:25%;
            height:55vh;
            margin-left:30%;
            margin-top:5vh;
            background-color:rgba(0, 0, 0, 0.5);
            color:white;
            font-size:30px;
            text-align:center;
            text-shadow:2px 5px black;
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }
        .AdminDetailsInner{
            position:absolute;
            width:90%;
            height:90%;
            margin-left:3.5%;
            margin-top:3.5%;
            border: 5px solid white;
        }
        .AdminPic{
            background-image:url(Admin.png);
            background-position:center;
            background-size:cover;
            width:95%;
            margin-left:2.5%;
            margin-top:2.5%;
            height:95%;
            border-radius:50%;
        }
        .AdminPicOuter{
            width:40%;
            height:40%;
            border-radius:50%;
            margin-left:30%;
            margin-top:10%;
            border:2px solid white;
            box-shadow:3px 5px 5px rgb(0,0,0);
        }
        .SkillSetDetails{
            box-shadow:1px 5px 5px rgb(128, 128, 128);
            background-color:transparent;
            position:absolute;
            width:40%;
            height:35vh;
            color:white;
            text-align:center;
            text-shadow:1px 3px rgb(36, 216, 45);
            margin-left:58%;
            margin-top:5vh;
        }
        .Statistics{
            box-shadow:1px 5px 5px rgb(128, 128, 128);
            position:absolute;
            width:22%;
            height:50vh;
            overflow:auto;
            margin-left:5%;
            margin-top:35vh;
            background-color:yellowgreen;
        }
        .LetsSee{
            box-shadow:1px 5px 5px rgb(128, 128, 128);
            position:absolute;
            width:25%;
            height:20vh;
            margin-left:30%;
            margin-top:65vh;
            background-color:rgba(0, 0, 0, 0.5);
        }
        .CourseDetails{
            box-shadow:1px 5px 5px rgb(128, 128, 128);
            position:absolute;
            width:30%;
            height:40vh;
            margin-left:65%;
            margin-top:45vh;
            overflow:auto;
            background-color:transparent;
        }

        .skill1,.skill2,.skill3 {
            display:inline-block;
            margin-left:3%;
            background-color:rgba(63, 170, 241, 0.50);
            width:20%;
            height:60%;
            border-radius:5%;
        }
        .Addskill {
            display:inline-block;
            margin-left:3%;
            background-color:rgba(63, 170, 241, 0.50);
            width:20%;
            height:40%;
            border-radius:5%;
        }
        .InnerSkillCard {
            margin-top:5%;
            margin-left:5%;
            border:2px solid white;
            display:block;
            width:85%;
            height:90%;
        }
        .SkillSearcher,UserSearcher {
            display:inline-block;
            border-top-color:transparent;
            border-left-color:transparent;
            border-right-color:transparent;
            border-bottom-color:white;
            text-align:center;
            font-size:35px;
            color:white;
            margin-top:2%;
            background-color:transparent;
        }
        .card {
            line-height:200px;
            text-shadow:none;
            font-weight:bold;
            font-size:20px;
        }
        .cardAdd {
            line-height:100px;
            text-shadow:none;
            font-size:100px;
        }
        .Search {
            text-decoration:none;
            font-size:30px;
            color:white;
            font-weight:bold;
            background-color:black;
            border-radius:10px;
            padding:10px;
        }
        .Search1 {
            text-decoration:none;
            font-size:30px;
            margin-left:20%;
            margin-top:5%;
            color:white;
            display:inline-block;
            font-weight:bold;
            background-color:black;
            border-radius:10px;
            padding:10px;
        }
        .skillCardButton {
            color:white;
            text-decoration:none;
            font-weight:bold;
            height:100%;
            width:100%;
        }
        .CourseItem{
            color:black;
            width:100%;
            overflow:scroll;
            font-size:20px;
        }
        .liner{
            text-decoration:underline;
            text-align:left;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <header>
            
        <asp:Label class="StatusLabel" ID="StatusBar" runat="server" Text="Hello Admin"></asp:Label>
        </header>
        <div class ="header1"></div>
        <div class ="header2"></div>


    <div class="Container">

        <div class="PriorityChanger" >
            <h2>Priority Changer</h2>
            <asp:TextBox CssClass="PriorityRequestedTextBox" placeholder="userID" ID="PriorityRequestedID" runat="server"></asp:TextBox>
            <br /><br /><br /><asp:LinkButton CssClass="PriorityChangerButton" ID="PriorityChanger" runat="server" OnClick="PriorityChanger_Click">Change To Admin</asp:LinkButton>
        </div>

        <div class="AdminDetails" ><div class="AdminDetailsInner"><div class="AdminPicOuter"><div class="AdminPic"></div></div><br />

            <asp:Label ID="AdminName" runat="server" Text="Admin Name"></asp:Label><br /><br />
            <asp:Label ID="AdminID" runat="server" Text="Admin ID"></asp:Label>
            
        </div>
        </div>

        <div class="SkillSetDetails"><h2>Skills</h2>
            <div class="skill1"><div class="InnerSkillCard"><asp:LinkButton CssClass="skillCardButton" ID="skillCardButton1" runat="server" OnClick="skillCardButton1_Click"><asp:Label class="card" ID="skillCard1" runat="server" Text="skillCard1"></asp:Label></asp:LinkButton></div></div>
            <div class="skill2"><div class="InnerSkillCard"><asp:LinkButton CssClass="skillCardButton" ID="skillCardButton2" runat="server" OnClick="skillCardButton2_Click"><asp:Label class="card" ID="skillCard2" runat="server" Text="skillCard2"></asp:Label></asp:LinkButton></div></div>
            <div class="skill3"><div class="InnerSkillCard"><asp:LinkButton CssClass="skillCardButton" ID="skillCardButton3" runat="server" OnClick="skillCardButton3_Click"><asp:Label class="card" ID="skillCard3" runat="server" Text="skillCard3"></asp:Label></asp:LinkButton></div></div>
            <div class="Addskill" onclick="gill();"><div class="InnerSkillCard"><asp:Label class="cardAdd" ID="skillCard4" runat="server" Text="+"></asp:Label></div></div>
            
            <asp:TextBox CssClass="SkillSearcher" placeholder="Search for any Other SkillName" ID="SkillSearch" runat="server"></asp:TextBox><asp:LinkButton ID="SkillSearchButton" CssClass="Search" runat="server" OnClick="SkillSearchButton_Click">Search</asp:LinkButton>
        </div>

        <div class="Statistics"><h2>Statistics</h2>
            <asp:TextBox CssClass="PriorityRequestedTextBox" placeholder="Search for any UserID" ID="UserIDSearcher" runat="server"></asp:TextBox><br /><asp:LinkButton ID="UserIDSearcherButton" CssClass="Search" runat="server" OnClick="UserIDSearcherButton_Click">Search</asp:LinkButton><br />
            <br />
            <asp:GridView ID="Adminshowstat" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" HeaderStyle-BackColor="Silver" GridLines="None" AllowSorting="True" OnRowCommand="Adminshowstat_RowCommand">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID"></asp:BoundField>
                    <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" SortExpression="CourseCode"></asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" HeaderText="Choose" ShowHeader="True"></asp:CommandField>
                </Columns>
            </asp:GridView>
            <asp:GridView ID="Adminsearchshowstat" runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="Silver" GridLines="None" AllowSorting="True" OnRowCommand="Adminsearchshowstat_RowCommand">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID"></asp:BoundField>
                    <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" SortExpression="CourseCode"></asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" HeaderText="Choose" ShowHeader="True"></asp:CommandField>
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:userdataConnectionString %>' SelectCommand="SELECT [UserID], [CourseCode],[Status] FROM [Scores]"></asp:SqlDataSource>
        </div>

        <div class="LetsSee">
            <asp:LinkButton ID="AddCourseMaterial" CssClass="Search1" runat="server" OnClick="AddCourseMaterial_Click">AddCourseMaterial</asp:LinkButton><br />
            <asp:LinkButton ID="AddCourseQuestions" CssClass="Search1" runat="server" OnClick="AddCourseQuestions_Click">AddCourseQuestions</asp:LinkButton>
        </div>




        <div class="CourseDetails">
            
            <asp:GridView ID="CoursesGrid" runat="server" GridLines="None" CssClass="CourseItem" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanged="CoursesGrid_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="CourseCode" HeaderStyle-CssClass="liner" HeaderText ="Course Code" />
                    <asp:BoundField DataField="CourseDescription" HeaderStyle-CssClass="liner" HeaderText ="Course Description" />
                </Columns>
            </asp:GridView>

            <a class="Search" href="AdminCourseCreationPage.aspx" style="float:right">Add_Course</a>
            </div>
        

    </div>

</asp:Content>

