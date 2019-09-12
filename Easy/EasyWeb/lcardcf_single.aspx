<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" 
        CodeFile="lcardcf_single.aspx.cs" Inherits="lcardcf_single" Title="Utente Card" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
<div style='position:relative;width:412px;height:373px;'>
    <asp:Label ID="labCF" runat="server" Style=" left: 12px; position: absolute;
        top: 20px" Text="Inserire il codice fiscale della persona da abilitare all'uso della card" Width="369px"></asp:Label>
    <HelpWeb:hwTextBox ID="txtCF" runat="server" Style=" left: 12px;
        width: 371px; position: absolute; top: 40px" TabIndex="1" Tag="lcardcf.cf" Width="1px"></HelpWeb:hwTextBox>
        </div>
</asp:Content>


