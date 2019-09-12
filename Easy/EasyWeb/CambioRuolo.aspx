<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="CambioRuolo.aspx.cs" Inherits="EasyWebReport.CambioRuolo" Title="Cambio ruolo" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >

    <div class="row">
        <div class="col-md-2">
        </div>
        <div class="col-md-8">
            <cc1:hwPanel GroupingText="Cambia Ruolo" CssClass="gbox scheduler-border form-group text-center" ID="grpRuolo" runat="server" Tag="">
                <cc1:hwLabel runat="server" ID="lblRuolo" Text="Selezionare il ruolo desiderato:"></cc1:hwLabel>
                <cc1:hwDropDownList runat="server" TabIndex="10" ID="cmbruolo" CssClass="input-md form-control"></cc1:hwDropDownList>
            </cc1:hwPanel>
        </div>
        <div class="col-md-2">
        </div>
    </div>

    <div class="row">
        <div class="col-md-7">
        </div>
        <div class="col-md-1">
            <cc1:hwButton runat="server" ID="btnok" Text="Ok" OnClick="btnok_Click" />
        </div>
        <div class="col-md-1">
            <cc1:hwButton runat="server" ID="btncancel" Text="Annulla" OnClick="btncancel_Click" />
        </div>
        <div class="col-md-3">
        </div>
    </div>


</asp:Content>
