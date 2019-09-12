<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="itinerationflights_default.aspx.cs" Inherits="itinerationflights_default"  Title="Tratta"%>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CHP_PC" Runat="Server" >
    <div class="row">
        <div class="col-md-3">
            <label for="txtDenominazione">Num. tratta</label>
        </div>
        <div class="col-md-3">
            <cc1:hwTextBox runat="server" TabIndex="20"  CssClass="form-control" ID="txtNumero" Tag="itinerationflights.idflights"></cc1:hwTextBox>
        </div>
                <div class="col-md-6">
                    </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <label for="txtDa">Da</label>
        </div>
        <div class="col-md-6">
            <cc1:hwTextBox ID="txtDa" runat="server" CssClass="form-control" Tag="itinerationflights.fromlocation"></cc1:hwTextBox>
        </div>
        <div class="col-md-3">
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <label for="txtA">A</label>
        </div>
        <div class="col-md-6">
            <cc1:hwTextBox ID="txtA" runat="server" CssClass="form-control" Tag="itinerationflights.tolocation"></cc1:hwTextBox>
        </div>
        <div class="col-md-3">
        </div>
    </div>



</asp:Content>

