<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="enactment_default_new02.aspx.cs" Inherits="enactment_default_new02"  Title="Atto amministrativo" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CHP_PC" Runat="Server" >

    <div class="row">
        <div class="col-md-6">
            <fieldset>
                <legend>Atto</legend>
                <div class="row">
                    <div class="col-md-6">
                        <label for="txtEsercizioDocumento">Esercizio:</label>
                        <cc1:hwTextBox runat="server" ReadOnly="true"  CssClass="input-md form-control" style="text-align: right;" TabIndex="10" ID="txtEsercizioDocumento" Tag="enactment.yenactment"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-6">
                        <label for="txtNumeroDocumento">Numero:</label>
                        <cc1:hwTextBox runat="server" TabIndex="20" CssClass="input-md form-control" style="text-align: right;" ID="txtNumeroDocumento" Tag="enactment.nenactment"></cc1:hwTextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <label for="txtNOfficial">Numero Ufficiale:</label>
                        <cc1:hwTextBox TabIndex="30" runat="server"  CssClass="input-md form-control" style="text-align: right;" ID="txtNOfficial" Tag="enactment.nofficial"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-6">
                        <label for="txtDataContabile">Data Contabile:</label>
            <cc1:hwTextBox runat="server"  CssClass="form-control" TabIndex="110" ID="txtDataContabile" Tag="enactment.adate"></cc1:hwTextBox>
                    </div>
                </div>
            </fieldset>
        </div>

        <div class="col-md-3">
            <fieldset id="gboxStato" runat="server">
                <legend>Stato</legend>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwRadioButton runat="server" TabIndex="40" Tag="enactment.idenactmentstatus:1" ID="rdbInAttesa" Text="In attesa di approvazione" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwRadioButton runat="server" TabIndex="50" Tag="enactment.idenactmentstatus:2" ID="rdbApprovato" Text="Approvato" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwRadioButton runat="server" TabIndex="60" Tag="enactment.idenactmentstatus:3" ID="rdbAnnullato" Text="Annullato" />
                    </div>
                </div>
            </fieldset>
        </div>

        <div class="col-md-3 align-self-end">
            <div class="row">
                <div class="col-md-12">
                    <cc1:hwButton runat="server"  class="btn btn-block" TabIndex="70" ID="btnWait" Text="Rimetti in attesa" Tag="do_wait" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <cc1:hwButton runat="server"  class="btn btn-block" TabIndex="80" ID="btnApprova" Text="Approva l'atto" Tag="do_approva" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <cc1:hwButton runat="server"  class="btn btn-block" TabIndex="90" ID="btnAnnulla" Text="Annulla l'atto" Tag="do_annulla" />
                </div>
            </div>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-md-12">
            <label for="txtDescrizione">Descrizione:</label>
            <cc1:hwTextBox runat="server" TabIndex="100"  CssClass="form-control" Tag="enactment.description" ID="txtDescrizione" TextMode="multiLine" Rows="3"></cc1:hwTextBox>
        </div>
    </div>

    <br />
        
    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <legend>Variazioni di Bilancio inserite nell'atto</legend>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwButton runat="server" TabIndex="120" ID="btnCollega" Tag="collega" class="btn" Text="Inserisci" />
                        <cc1:hwButton runat="server" TabIndex="130" ID="btnScollega" Tag="unlink.detail" class="btn" Text="Rimuovi" />
                        <cc1:hwButton runat="server" TabIndex="140" ID="btnModifica" Tag="modifica" class="btn" Text="Modifica" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div id="necessary" runat="server">
                            <cc1:hwDataGridWeb runat="server" TabIndex="150" ID="dgrVariazioni" Tag="finvarview.documentocollegato" />
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>


</asp:Content>

