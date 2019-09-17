<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminAddCourseMaterial.aspx.cs" Inherits="AdminAddCourseMaterial" %>

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
            width: 40%;
            background-color: brown;
            display:inline-block;
            float: left;
            overflow:auto;
        }
        .rightContainer {
            height: 90vh;
            width: 60%;
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

    <div class="leftContainer">
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" AutoGenerateSelectButton="True" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" SortExpression="CourseCode" />
                <asp:BoundField DataField="FileName" HeaderText="FileName" SortExpression="FileName" />
                <asp:BoundField DataField="FileLocation" HeaderText="FileLocation" SortExpression="FileLocation" />
            </Columns>
        </asp:GridView>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:userdataConnectionString3 %>" SelectCommand="SELECT [id], [CourseCode], [FileName], [FileLocation] FROM [CourseMaterial]"></asp:SqlDataSource>

    </div>




    <div class="rightContainer">
        <asp:TextBox ID="coursecodemat" placeholder="coursecode" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="Filenamenat" placeholder="Filename" runat="server"></asp:TextBox><br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <asp:Label ID="Statusindicator" runat="server" ForeColor="Red"></asp:Label><br />
        <asp:Button ID="Add_Material" runat="server" Text="Add_Material" OnClick="Add_Material_Click" />
        <asp:Button ID="Delete_Material" runat="server" Text="Delete_Material" OnClick="Delete_Material_Click" />

        <br />

        <iframe id="myframe" style="margin-left:10%;margin-top:2%;" runat="server" height="750" width="750"></iframe>
        
    </div>
    

</asp:Content>

