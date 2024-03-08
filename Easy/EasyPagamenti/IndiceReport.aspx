<%@ Page Title="" Language="C#" MasterPageFile="MetaMasterBootstrap.master" CodeFile="IndiceReport.aspx.cs" Inherits="EasyPagamenti.IndiceReport" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
           
<asp:Content ID="Content3" ContentPlaceHolderID="CHP_PC" Runat="Server">
    <div style="text-align:center;">
        <cc1:hwPanel id="MenuPanel"   runat="server" >
            <cc1:hwButton ID="HwMenuButton" style="display:none;"  runat="server" OnClick="HwMenuButton_Click" />
        </cc1:hwPanel>
	</div>	
	
    <script type="text/javascript">
        /* INTUIT */
        var FocusOnStartup = null;
    </script>
</asp:Content>