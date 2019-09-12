<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="account_tree.aspx.cs" Inherits="account_tree" Title="" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">

     <div class="row">
        
    <div class="col-md-4 col-xs-12 overflow:hidden">           
        <HelpWeb:hwTreeView ID="accounttree" runat="server" Tag="account.tree">
        
        </HelpWeb:hwTreeView>

    </div>

    <div class="col-md-8 hidden-xs overflow:hidden">           
        <HelpWeb:hwDataGridWeb  runat="server" Tag="TreeNavigator.treenew" ID="account_table"/>
    </div>

    </div>  

</asp:Content>
