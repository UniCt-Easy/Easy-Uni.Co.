<%@ Page Title="" Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="listclass_tree.aspx.cs" Inherits="listclass_tree" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
    <table width="950px">
<tr>
    <td style="width: 20%" valign="top">
        <cc1:hwTreeView ID="listclasstree" runat="server" Tag="listclass.treenew">
        
        </cc1:hwTreeView>
    </td>
    <td style="width: 79%" valign="top">
        <cc1:hwDataGridWeb Width="730px" Height="100%"  runat="server" Tag="TreeNavigator.treenew" ID="listclass_table"/>
    </td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="JScriptBeforeLibs" Runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="JScriptAfterLibs" Runat="Server">
</asp:Content>

