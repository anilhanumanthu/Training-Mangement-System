<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserAssessmentPage.aspx.cs" Inherits="UserAssessmentPage" %>

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
        .SubmitButton {
            text-decoration:none;
            font-size:30px;
            background-color:white;
            color:black;
            border-radius:20%;
            padding:10px;
            font-weight:bold;
        }
        .QuestionHolder {  
            height:70vh;margin-top:10vh;
            margin-left:10%;
            width:80%;
            display:inline-block;
            background-color:gainsboro;
            border-radius:20px;
        }
        .leftindicpicbutton{
            background-image:url(leftindicate.png);
            background-size:cover;
            background-repeat:no-repeat;
            margin-top:25vh;
            height:20%;
            width:10%;
            position:relative;
            display:inline-block;
        }
        .rightindicpicbutton{
            background-image:url(rightindicate.png);
            background-size:cover;
            background-repeat:no-repeat;
            margin-top:25vh;
            height:20%;
            width:10%;
            position:relative;
            display:inline-block;
        }
        .present{
            position:relative;
            overflow-wrap: break-word;
            display:inline-block;
            height:100%;
            width:79%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <header>
        <a class="GoBack" href="UserMain.aspx">Go Back</a>
    <asp:Label CssClass="StatusBar" ID="StatusBar" runat="server" Text=""></asp:Label>
    </header>

        <div class="QuestionHolder">
            <span><asp:linkbutton id="leftindicpicbutton" class="leftindicpicbutton" runat="server" OnClick="leftindicpicbutton_Click"></asp:linkbutton></span>
            
            <span class="present">

                <asp:label id="QuestionNumber" runat="server" text="Label"></asp:label>
                <asp:label id="QuestionText" runat="server" text="Label"></asp:label>

                <br /><br />
                
                <asp:RadioButton runat="server" ID="OptionA" value="A" Text="oops1" GroupName="optiongroup"/><br />
                <asp:RadioButton runat="server" ID="OptionB" value="B" Text="oops2" GroupName="optiongroup"/><br />
                <asp:RadioButton runat="server" ID="OptionC" value="C" Text="oops3" GroupName="optiongroup"/><br />
                <asp:RadioButton runat="server" ID="OptionD" value="D" Text="oops4" GroupName="optiongroup"/>

                <asp:gridview id="test" runat="server"></asp:gridview>

            </span>

            <span><asp:linkbutton id="rightindicpicbutton" class="rightindicpicbutton" runat="server" OnClick="rightindicpicbutton_Click"></asp:linkbutton></span>
        </div>
    
                <asp:linkbutton id="SubmitQuestions" class="SubmitButton" runat="server" OnClick="SubmitQuestions_Click">Submit</asp:linkbutton>

</asp:Content>

