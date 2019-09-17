<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminSelectedUser.aspx.cs" Inherits="AdminSelectedUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>

        body{
            height:100vh;
            width:100%;
            color:white;
            margin:0;
            padding:0;
            background-image:url(AdminSelectedUserStat.jpg);
            background-size:cover;
        }
        #circle{
            margin-top:3%;margin-left:32%;
        }
        .entire{
            font-weight:bold;
            font-size:50px;
            text-align:center;
            padding-top:10px;
            padding-bottom:10px;
            background-color:rgba(255, 255, 255, 0.25);
        }
        
    </style>
    <script>
        function draw(v)
        {
            var canvas = document.getElementById('circle');
            if (canvas.getContext) {
                var ctx = canvas.getContext('2d');
                var X = canvas.width / 2;
                var Y = canvas.height / 2;
                var R = 175;
                ctx.beginPath();
                ctx.font = "bold 100px verdana, sans-serif ";
                ctx.fillStyle = "white";
                ctx.fillText(v, 150, 250);
                ctx.arc(X, Y, R, 0, v * Math.PI * (1 / 50), false);
                ctx.lineWidth = 35;
                ctx.strokeStyle = '#ffffff';
                ctx.stroke();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <canvas id="circle" width="450" height="450"><asp:Label runat="server" CssClass="PercentageView" ID ="Percentage" ></asp:Label></canvas>

    <br /><br /><br />
    <div class="entire">

    <asp:Label ID="userid" ForeColor="#ff3300" runat="server"></asp:Label>&nbsp;&nbsp;
    <asp:Label ID="Coursecode" ForeColor="#00ff99" runat="server"></asp:Label>&nbsp;&nbsp;
    <asp:Label ID="date" ForeColor="#006699" runat="server"></asp:Label>&nbsp;&nbsp;
    <asp:Label ID="score" ForeColor="#0066ff" runat="server"></asp:Label>&nbsp;&nbsp;
    <asp:Label ID="status" ForeColor="#00ff00" runat="server"></asp:Label>

    </div>

</asp:Content>

