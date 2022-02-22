<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePageProgetti.aspx.cs" Inherits="Backend.saml.HomePageProgetti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div class="row">
                <div class="text-center col-md-12">
					<h2><asp:HyperLink Style="text-align: center;" ID="HyperLink2" runat="server" Font-Size="Medium"
                        Target="_blank" NavigateUrl="~/saml/DefaultSAML.aspx">AUTENTICAZIONE CAS</asp:HyperLink></h2><br/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
