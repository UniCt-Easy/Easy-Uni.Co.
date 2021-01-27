
<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="location_tree.aspx.cs" Inherits="location_tree" Title="Selezione Ubicazione" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<script runat="server">

  
</script>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
    
    <div class="row">

        <div class="col-12 hidden-xs overflow:hidden">           
            <HelpWeb:hwDataGridWeb  runat="server" Tag="TreeNavigator.default" ID="locationtable"/>
        </div>
        
        <div class="col-12">
            <HelpWeb:hwTreeView ID="locationtree" runat="server" Tag="locationview.tree">
            </HelpWeb:hwTreeView>
        </div>

    </div>


</asp:Content>
