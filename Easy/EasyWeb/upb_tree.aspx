<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="upb_tree.aspx.cs" Inherits="upb_tree" Title="Selezione UPB" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
    
    <div class="row">
        
    <div class="col-md-4 col-xs-12 overflow:hidden">           
        <HelpWeb:hwTreeView ID="upbtree" runat="server" Tag="upb.tree">
        
        </HelpWeb:hwTreeView>

    </div>

    <div class="col-md-8 hidden-xs overflow:hidden">           
        <HelpWeb:hwDataGridWeb  runat="server" Tag="TreeNavigator.tree" ID="upbtable"/>
    </div>

    </div>


</asp:Content>
