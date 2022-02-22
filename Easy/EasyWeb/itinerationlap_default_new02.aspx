<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="itinerationlap_default_new02.aspx.cs" Inherits="itinerationlap_default_new02" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >

    <div>
        <div class="row">
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-12">
                        <label for="txtDataOraInizio">Data/ora inizio  (GG/MM/AA hh:mm):</label>
                        <cc1:hwTextBox runat="server" ID="txtDataOraInizio" Tag="itinerationlap.starttime.g" CssClass="form-control" TabIndex="1"></cc1:hwTextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <label for="txtDataOraTermine">Data/ora termine (GG/MM/AA hh:mm):</label>
                        <cc1:hwTextBox runat="server" ID="txtDataOraTermine" Tag="itinerationlap.stoptime.g" CssClass="form-control" TabIndex="2"></cc1:hwTextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-12">
                        <label for="txtGiorni">Giorni:</label>
                        <cc1:hwTextBox runat="server" ID="txtGiorni" CssClass="form-control" Style="text-align: right" TabIndex="-1"></cc1:hwTextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <label for="txtOre">Ore:</label>
                        <cc1:hwTextBox runat="server" ID="txtOre" Tag="itinerationlap.hours" CssClass="form-control" TabIndex="-1"></cc1:hwTextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <label for="txtFrazioneGiorni">N. giorni frazionario</label>
                        <cc1:hwTextBox runat="server" ID="txtFrazioneGiorni" Tag="" CssClass="form-control" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-4"></div>
        </div>

        <div class="row">
            <div class="col-md-8">
                <label for="txtDescrizione">Descrizione:</label>
                <cc1:hwTextBox runat="server" ID="txtDescrizione" Tag="itinerationlap.description" CssClass="form-control" TextMode="MultiLine" Rows="4" TabIndex="3"></cc1:hwTextBox>
            </div>
            <div class="col-md-4"></div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <cc1:hwCheckBox AutoPostBack="true" runat="server" ID="chkitaliaestero" ThreeState="false" Tag="itinerationlap.flagitalian:S:N" TabIndex="4" OnCheckedChanged="chkitaliaestero_Click" Text="Italia" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <cc1:hwButton runat="server" ID="btnLocalita" Tag="choose.foreigncountry.default" TabIndex="-1" class="btn btn-primary" Text="Località Estera:" />
            </div>
            <div class="col-md-6">
                <cc1:hwDropDownList runat="server" AutoPostBack="true" ID="cmbLocalita" Tag="itinerationlap.idforeigncountry" CssClass="input-md form-control"  TabIndex="5"></cc1:hwDropDownList>
            </div>
        </div>
        

    </div>
</asp:Content>