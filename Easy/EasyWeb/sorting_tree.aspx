<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="sorting_tree.aspx.cs" Inherits="sorting_tree" Title="Selezione classificazione" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
   
    <div class="row">
        
    <div class="col-md-4 col-xs-12 overflow:hidden">           
         <HelpWeb:hwTreeView ID="sortingtree" runat="server" Tag="sorting.tree">
        
        </HelpWeb:hwTreeView>

    </div>

    <div class="col-md-8 hidden-xs overflow:hidden">           
        <HelpWeb:hwDataGridWeb  runat="server" Tag="TreeNavigator.tree" ID="sortingtable"/>
    </div>

    </div>    


</asp:Content>

