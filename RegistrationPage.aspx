<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistrationPage.aspx.cs" Inherits="RegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function DivChange() {
            document.getElementById('formLabel1').style.display = "block";
            document.getElementById('formLabel2').style.display = "none";
            document.getElementById('formLabel3').style.display = "none";
            document.getElementById('formLabel4').style.display = "none";
            document.getElementById('formLabel5').style.display = "none";
            document.getElementById('formLabel6').style.display = "none";
            document.getElementById('formLabel7').style.display = "none";
            document.getElementById('formLabel8').style.display = "none";
            document.getElementById('formLabel9').style.display = "none";
        }
        function DivChange1() {
            document.getElementById('formLabel1').style.display = "none";
            document.getElementById('formLabel2').style.display = "block";
            document.getElementById('formLabel3').style.display = "none";
            document.getElementById('formLabel4').style.display = "none";
            document.getElementById('formLabel5').style.display = "none";
            document.getElementById('formLabel6').style.display = "none";
            document.getElementById('formLabel7').style.display = "none";
            document.getElementById('formLabel8').style.display = "none";
            document.getElementById('formLabel9').style.display = "none";
        }
        function DivChange2() {
            document.getElementById('formLabel1').style.display = "none";
            document.getElementById('formLabel2').style.display = "none";
            document.getElementById('formLabel3').style.display = "block";
            document.getElementById('formLabel4').style.display = "none";
            document.getElementById('formLabel5').style.display = "none";
            document.getElementById('formLabel6').style.display = "none";
            document.getElementById('formLabel7').style.display = "none";
            document.getElementById('formLabel8').style.display = "none";
            document.getElementById('formLabel9').style.display = "none";
        }
        function DivChange3() {
            document.getElementById('formLabel1').style.display = "none";
            document.getElementById('formLabel2').style.display = "none";
            document.getElementById('formLabel3').style.display = "none";
            document.getElementById('formLabel4').style.display = "block";
            document.getElementById('formLabel5').style.display = "none";
            document.getElementById('formLabel6').style.display = "none";
            document.getElementById('formLabel7').style.display = "none";
            document.getElementById('formLabel8').style.display = "none";
            document.getElementById('formLabel9').style.display = "none";
        }
        function DivChange4() {
            document.getElementById('formLabel1').style.display = "none";
            document.getElementById('formLabel2').style.display = "none";
            document.getElementById('formLabel3').style.display = "none";
            document.getElementById('formLabel4').style.display = "none";
            document.getElementById('formLabel5').style.display = "block";
            document.getElementById('formLabel6').style.display = "none";
            document.getElementById('formLabel7').style.display = "none";
            document.getElementById('formLabel8').style.display = "none";
            document.getElementById('formLabel9').style.display = "none";
        }
        function DivChange5() {
            document.getElementById('formLabel1').style.display = "none";
            document.getElementById('formLabel2').style.display = "none";
            document.getElementById('formLabel3').style.display = "none";
            document.getElementById('formLabel4').style.display = "none";
            document.getElementById('formLabel5').style.display = "none";
            document.getElementById('formLabel6').style.display = "block";
            document.getElementById('formLabel7').style.display = "none";
            document.getElementById('formLabel8').style.display = "none";
            document.getElementById('formLabel9').style.display = "none";
        }
        function DivChange6() {
            document.getElementById('formLabel1').style.display = "none";
            document.getElementById('formLabel2').style.display = "none";
            document.getElementById('formLabel3').style.display = "none";
            document.getElementById('formLabel4').style.display = "none";
            document.getElementById('formLabel5').style.display = "none";
            document.getElementById('formLabel6').style.display = "none";
            document.getElementById('formLabel7').style.display = "block";
            document.getElementById('formLabel8').style.display = "none";
            document.getElementById('formLabel9').style.display = "none";
        }
        function DivChange7() {
            document.getElementById('formLabel1').style.display = "none";
            document.getElementById('formLabel2').style.display = "none";
            document.getElementById('formLabel3').style.display = "none";
            document.getElementById('formLabel4').style.display = "none";
            document.getElementById('formLabel5').style.display = "none";
            document.getElementById('formLabel6').style.display = "none";
            document.getElementById('formLabel7').style.display = "none";
            document.getElementById('formLabel8').style.display = "block";
            document.getElementById('formLabel9').style.display = "none";
        }
        function DivChange8() {
            document.getElementById('formLabel1').style.display = "none";
            document.getElementById('formLabel2').style.display = "none";
            document.getElementById('formLabel3').style.display = "none";
            document.getElementById('formLabel4').style.display = "none";
            document.getElementById('formLabel5').style.display = "none";
            document.getElementById('formLabel6').style.display = "none";
            document.getElementById('formLabel7').style.display = "none";
            document.getElementById('formLabel8').style.display = "none";
            document.getElementById('formLabel9').style.display = "block";
        }
        function UserTyper() {
            document.getElementById('formLabel1').style.display = "none";
        }
    </script>
    <style>
        body{
            margin:0;
            padding:0;
            height:100vh;
            width:100%;
			background-image:url(oo.jpg);
			background-size:cover;
        }
		.heading{
		color:lightgreen;
		font-size:50px;
		font-weight:bold;
		text-align:center;
		text-shadow:3px 5px skyblue;
		}
		.mainContainer{
		width:100%;
		height:30vh;
		}
        .Container{
			display:block;
            position:absolute;
            top:50%;
			background-color:white;
            left:50%;
            height:25vh;
            width:35%;
            transform:translate(-50%,-50%);
        }
        h1{text-shadow:1px 3px black;
            color:white;
			font-size:40px;
        }
		div{border-radius:20px;box-shadow:2px 5px 5px rgb(10,40,30);}
        input,select {
			border:none;
			outline:none;
			border-top-left-radius:20px;
			border-bottom-left-radius:20px;
            color: black;
			text-align:center;
			display:inline-block;
			font-size:30px;
			margin-bottom:20px;
			box-shadow:2px 5px 5px rgb(10,40,30);
        }
		select{margin-left:100px;}
        #RegisterButton {
            border-top-right-radius:20px;
            border-top-left-radius:20px;
            border-bottom-left-radius:20px;
			border-bottom-right-radius:20px;
			font-size:30px;
			padding-right:10px;
			background-color:black;
			color:white;
			display:inline-block;
			cursor:pointer;
			box-shadow:2px 5px 5px rgb(10,40,30);
        }
        span{
			border-top-right-radius:20px;
			border-bottom-right-radius:20px;
			font-size:30px;
			padding-right:10px;
			background-color:black;
			color:white;
			display:inline-block;
			cursor:pointer;
			box-shadow:2px 5px 5px rgb(10,40,30);
        }
		.footery{
		display:block;
		height:20vh;
		width:100%;
		box-shadow:2px 5px 5px rgb(10,40,30);
		}
    </style>
</head>
<body onload="DivChange()">
    <form id="form1" runat="server">
    
        <div class="mainContainer">
<div class="heading">Registration</div>
<div class="Container">
    
        <div id="formLabel1" style="background-color:#065535;">
            <h1>Enter Your First Name:</h1><br />
            <asp:TextBox ID="FNameRegister" runat="server" placeholder="First_Name"></asp:TextBox>
            <span onclick="DivChange1()">Next</span>
        </div>
        <div id="formLabel2" style="background-color:#133337;">
            <h1>Enter Your Last Name:</h1><br />
            <asp:TextBox ID="LNameRegister" runat="server" placeholder="Last_Name"></asp:TextBox>
            <span onclick="DivChange2()">Next</span>
        </div>
        <div id="formLabel3" style="background-color:#ff4040;">
            <h1>Enter Your Age:</h1><br />
            <asp:TextBox ID="AgeRegister" runat="server" placeholder="Age" TextMode="Number"></asp:TextBox>
            <span onclick="DivChange3()">Next</span>
        </div>
        <div id="formLabel4" style="background-color:#ccff00;">
            <h1>Enter Your Gender:</h1><br />
            <asp:DropDownList ID="GenderDropRegister" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem Value="FeMale">Fe-Male</asp:ListItem>
            </asp:DropDownList>
            <span onclick="DivChange4()" runat="server">Next</span>
         </div>
        <div id="formLabel5" style="background-color:#008080;">
            <h1>Enter Your Contact-Number:</h1><br />
            <asp:TextBox ID="ContactTelRegister" runat="server" placeholder="Contact-Number" TextMode="Phone"></asp:TextBox>
            <span onclick="DivChange5()">Next</span>
        </div>
        <div id="formLabel6" style="background-color:#ff7f50;">
            <h1>Enter Your UserID:</h1><br />
            <asp:TextBox ID="UserIDRegister" runat="server" placeholder="UserID"></asp:TextBox>
            <span onclick="DivChange6()">Next</span>
        </div>
        <div id="formLabel7" style="background-color:#ffff66;">
            <h1>Enter Your Password:</h1><br />
            <asp:TextBox ID="PasswordRegister" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            <span onclick="DivChange7()">Next</span>
        </div>
        <div id="formLabel8" style="background-color:#ff1493;">
            <h1>Enter Your E-Mail id:</h1><br />
            <asp:TextBox ID="MailIDRegister" runat="server" placeholder="E-Mail ID">@gmail.com</asp:TextBox>
            <span onclick="DivChange8()">Next</span>
        </div>
        <div id="formLabel9" style="background-color:#0099cc;">
            <h1>Enter Your User-Type:</h1><br />
			<asp:DropDownList ID="UserTypeDropRegister" runat="server" Visible="True">
                <asp:ListItem Value="A">Admin-A</asp:ListItem>
                <asp:ListItem Value="U">User-U</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="UserTypeDropRegister1" runat="server" Visible="False">
                <asp:ListItem Value="U">User-U</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click1" />
        </div>
</div>
</div>
        <span><asp:Label ID="StatusRegistration" runat="server" Text=""></asp:Label></span>
<footer class="footery"></footer>
<div class="footery"></div>
<div class="footery"></div>

    </form>
</body>
</html>
