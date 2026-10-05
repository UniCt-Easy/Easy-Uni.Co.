<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsumeToken.aspx.cs" Inherits="EasyWebReport.Sso_ConsumeToken" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Single Sign-On</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:sans-serif; margin:2em;">
            <h3>Connecting to Single Sign-On...</h3>
            <p>If this page does not redirect automatically, 
               <a href="<%= ResolveUrl("~/Default.aspx") %>">click here</a>.</p>
        </div>
    </form>
</body>
</html>
