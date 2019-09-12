<%@ Page language="c#" MasterPageFile="~/MetaMaster.master" Inherits="EasyWebReport.Messaggio" CodeFile="Messaggio.aspx.cs" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
		<center>
		<br />
		<br />
		<br />
		
			<asp:Label id="lblMessaggio" style="font-family: Arial, Microsoft Sans Serif; font-size: 21px; font-weight: bold;"
				runat="server"></asp:Label>
        </center>
            <center>
                &nbsp;</center>
            <center>
		<br />
		<br />		
            <asp:Button runat="server" id="ImageButton1" style="width: 150px; height: 40px; background-color: #aaaaaa;border: 1px solid gray;font-size: 14px;font-family: Microsoft Sans Serif, Arial;z-index: 107; " Text="Vai alla Homepage"></asp:Button >
        <br />
        <br />
            </center>
</asp:Content>
