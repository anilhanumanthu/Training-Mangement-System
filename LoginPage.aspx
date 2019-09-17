<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            margin: 0;
            height: 100vh;
            width: 100%;
            padding: 0;
            font-family: Arial, sans-serif;
            background: url(LoginBackground.png);
            background-size: cover;
        }
        header{
            width:100%;
            height:10vh;
            text-align:center;
            background-color:transparent;
        }
        .mainContainer {
            color: #E9625E;
            position: absolute;
            top: 50%;
            left: 50%;
            width: 50%;
            height: 60vh;
            border-radius: 20px;
            transform: translate(-50%,-50%);
        }
        input {
            padding: 30px;
            margin-left: 120px;
            border: 2px solid rgb(10,40,30);
            border-radius: 20px;
            background-color: transparent;
            text-align: center;
            font-size: 30px;
        }
        .contain {
            margin-top:50px;
            margin-left:150px;
        }
        .status {
            margin-left:250px;
            background-color:transparent;
            text-shadow:2px 5px black;
            color:#E9625E;
            border-radius:20px;
            padding-right:10px;
            font-size:50px;
        }
        ::placeholder {
            color: #E9625E;
            text-decoration: underline;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <header></header>
    <form id="form1" runat="server">
    <div class="mainContainer">
        <asp:Label ID="StatusLogin" CssClass="status" runat="server" Text=""></asp:Label>
        <div class="contain">
            <asp:TextBox ID="UserLogin" runat="server" style="margin-bottom: 25px;" placeholder="UserID"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserLogin" ErrorMessage="Enter the Username"></asp:RequiredFieldValidator>
            <asp:TextBox ID="PassLogin" runat="server" style="margin-bottom: 25px;" placeholder="Password" TextMode="Password" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PassLogin" ErrorMessage="Enter the Password"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="LoginButton" runat="server" Text="Login" style="background-color:#E9625E;color:white;margin-left:280px;text-align:center;padding:15px;font-weight:bold;" OnClick="LoginButton_Click"/>
        </div>
    </div>

    
    <a href="RegistrationPage.aspx" id="RegisterPointer" style="color:#fff;cursor:pointer;float:right;padding-right:150px;font-size:50px">Sign Up!</a>
        
    </form>
    
    </body>
</html>
