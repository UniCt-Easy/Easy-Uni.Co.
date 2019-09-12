<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="fin_treeall.aspx.cs" Inherits="fin_treeall" Title="Selezione voce di bilancio" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
  
    <div class="row">
        
    <div class="col-md-4 col-xs-12 overflow:hidden">           
        <HelpWeb:hwTreeView ID="fintree" runat="server" Tag="fin.tree">
        
        </HelpWeb:hwTreeView>

    </div>

    <div class="col-md-8 hidden-xs overflow:hidden">           
        <HelpWeb:hwDataGridWeb  runat="server" Tag="TreeNavigator.tree" ID="fintable"/>
    </div>

    </div>       

</asp:Content>
