<%@ Page Title="" Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="sceglimagazzino.aspx.cs" Inherits="sceglimagazzino" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <cc1:hwPanel GroupingText="Scegli la sezione d'interesse" CssClass="gbox scheduler-border form-group text-center" ID="grpMagazzino" runat="server" Tag="">
                <cc1:hwLabel runat="server" ID="lblMagazzino" Text="Selezionare il dipartimento desiderato:"></cc1:hwLabel>
                <cc1:hwDropDownList runat="server" TabIndex="10" ID="cmbmagazzino" CssClass="input-md form-control"></cc1:hwDropDownList>
            </cc1:hwPanel>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <cc1:hwLabel runat="server" ID="labError"></cc1:hwLabel>
        </div>
    </div>

    <div class="row">
        <div class="col-md-8 col-md-offset-2" Style="text-align: right;">
            <cc1:hwButton class="btn btn-success min100" runat="server" ID="btnok" Text="Ok" OnClick="btnok_Click" />
            <cc1:hwButton class="btn btn-info min100" runat="server" ID="btncancel" Text="Annulla" OnClick="btncancel_Click" />
        </div>
    </div>
    
</asp:Content>