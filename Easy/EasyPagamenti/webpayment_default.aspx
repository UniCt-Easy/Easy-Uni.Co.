<%@ Page Title="" Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="webpayment_default.aspx.cs" Inherits="webpayment_default" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >

    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-3 col-md-1 mb-5 pt-8">
                    <label for="txtywebpayment">Esercizio</label>
                </div>
                <div class="col-3 col-md-2 mb-5">
                    <cc1:hwTextBox runat="server" ID="txtywebpayment" CssClass="form-control" Tag="webpayment.ywebpayment.year" TabIndex="2"></cc1:hwTextBox>
                </div>
                <div class="col-3 col-md-1 mb-5 pt-8">
                    <label for="txtnwebpayment">Numero</label>
                </div>
                <div class="col-3 col-md-2 mb-5">
                    <cc1:hwTextBox runat="server" ID="txtnwebpayment" CssClass="form-control" Tag="webpayment.nwebpayment" TabIndex="3"></cc1:hwTextBox>
                </div>
                <div class="col-3 col-md-1 mb-5 pt-8">
                    <label for="DrpStatus">Stato Corrente</label>
                </div>
                <div class="col-9 col-md-5 mb-5">
                    <cc1:hwDropDownList ID="DrpStatus" CssClass="form-control" Tag="webpayment.idwebpaymentstatus?webpaymentview.idwebpaymentstatus" runat="server" AutoPostBack="True" TabIndex="40"></cc1:hwDropDownList>
                </div>
            </div>
        </div>
    </div>

    <div class="row mb-25" id="campi" runat="server" style="margin-top: 25px;">
		<div class="col-4 col-md-2 col-xl-2 mb-5 pt-8">
			<asp:Label ID="lblNome" TabIndex="99" runat="server">Nome:</asp:Label>
		</div>
		<div class="col-8 col-md-4 col-xl-2 mb-5">
			<cc1:hwTextBox ID="txtNome" runat="server" MaxLength="50" TabIndex="4" CssClass="form-control"></cc1:hwTextBox>
		</div>
		<div class="col-4 col-md-2 col-xl-2 mb-5 pt-8">
			<asp:Label ID="lblCognome" TabIndex="99" runat="server">Cognome:</asp:Label>
		</div>
		<div class="col-8 col-md-4 col-xl-2 mb-5">
			<cc1:hwTextBox ID="txtCognome" runat="server" MaxLength="50" TabIndex="5" CssClass="form-control"></cc1:hwTextBox>
		</div>
		<div class="col-4 col-md-2 col-xl-2 mb-5 pt-8">
			<asp:Label ID="lblDenominazione" TabIndex="99" runat="server">Denominazione:</asp:Label>
		</div>
		<div class="col-8 col-md-4 col-xl-2 mb-5">
			<cc1:hwTextBox ID="txtDenominazione" runat="server" MaxLength="50" TabIndex="5" CssClass="form-control"></cc1:hwTextBox>
		</div>
		<div class="col-4 col-md-2 col-xl-2 mb-5 pt-8">
			<asp:Label ID="lblPartitaIva" TabIndex="99" runat="server">Partita IVA:</asp:Label>
		</div>
		<div class="col-8 col-md-4 col-xl-2 mb-5">
			<cc1:hwTextBox ID="txtPartitaIva" runat="server" MaxLength="50" TabIndex="7" CssClass="form-control"></cc1:hwTextBox>
		</div>
		<div class="col-4 col-md-2 col-xl-2 mb-5 pt-8">
			<asp:Label ID="lblData" TabIndex="100" runat="server">Data:</asp:Label>
		</div>
		<div class="col-8 col-md-4 col-xl-2 mb-5">
			<cc1:hwTextBox runat="server" ID="txtData" Tag="webpayment.adate" TabIndex="70" CssClass="form-control"></cc1:hwTextBox>
		</div>
		<div class="col-4 col-md-2 col-xl-2 mb-5 pt-8">
			<asp:Label ID="lblMail" TabIndex="99" runat="server">Email:</asp:Label>
		</div>
		<div class="col-8 col-md-4 col-xl-2 mb-5">
			<cc1:hwTextBox ID="txtEmail" runat="server" MaxLength="200" TabIndex="3" CssClass="form-control"></cc1:hwTextBox>
		</div>
		<div class="col-4 col-md-2 col-xl-2 mb-5 pt-8">
			<asp:Label ID="lblCodiceFiscale" TabIndex="99" runat="server">Codice Fiscale:</asp:Label>
		</div>
		<div class="col-8 col-md-4 col-xl-2 mb-5">
			<cc1:hwTextBox ID="txtCodiceFiscale" runat="server" MaxLength="50" TabIndex="8" CssClass="form-control"></cc1:hwTextBox>
		</div>
        <!-- <div style="width:150px;float:right;">(*)campi obbligatori</div> -->
    </div>


    <div class="row mb-25">
        <div class="col-md-12">
			<div class="row">
				<div class="col-4 col-lg-2">
					<cc1:hwButton runat="server" ID="btndelete" Tag="delete" TabIndex="7" class="btn btn-block" Text="Elimina" />
					<cc1:hwButton runat="server" ID="btnedit" Tag="edit.singlepagamenti" TabIndex="6" class="btn  btn-block" Text="Modifica" />
					<cc1:hwButton runat="server" ID="btnvetrina" Tag="vetrina" TabIndex="8" class="btn  btn-block" Text="Cataloghi" Style="background-color: #ff9966; color: Black;" />
				</div>
				<div class="col-lg-10">
					<cc1:hwDataGridWeb runat="server" ID="detailgrid" Tag="webpaymentdetail.list.single" />
				</div>
			</div>
		</div>
    </div>

    <div class="row mb-25">
        <div class="col-3 col-md-2 col-xl-2 pt-8">
            <asp:Label ID="lblquantita_totale" TabIndex="99" runat="server">Q.tà totale:</asp:Label>
        </div>
        <div class="col-3 col-md-4 col-xl-2">
            <cc1:hwTextBox ID="txtquantita_totale" runat="server" MaxLength="50" TabIndex="3" CssClass="form-control"></cc1:hwTextBox>
        </div>
        <div class="col-3 col-md-2 col-xl-2 pt-8">
            <asp:Label ID="lblprezzototale" TabIndex="99" runat="server" Font-Bold="True">Totale generale:</asp:Label>
        </div>
        <div class="col-3 col-md-4 col-xl-2">
            <cc1:hwTextBox ID="txtprezzototale" runat="server" MaxLength="50" TabIndex="3" Font-Bold="True" CssClass="form-control"></cc1:hwTextBox>
        </div>
    </div>


    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-4">
                    <cc1:hwButton ID="SalvaBozza" runat="server" Style="width: 100%;" Tag="SalvaBozza" Text="Salva Prenotazione"></cc1:hwButton>
                </div>
                <div class="col-md-8">
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-4">
                    <cc1:hwButton ID="ProcediPagamento" runat="server" Style="width: 100%;" Tag="ProcediPagamento" Text="Procedi all'acquisto"></cc1:hwButton>
                </div>
                <div class="col-md-8">
                </div>
            </div>
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-4">
            <cc1:hwButton ID="Scaricapdf" runat="server"  Tag="Scaricapdf" Text="Scarica avviso di pagamento PagoPa" data-toggle="tooltip" data-placement="top" title="Scaricare l'avviso di pagamento da utilizzare presso gli intermediari abilitati e per il pagamento on-line"></cc1:hwButton>
                </div>
                <div class="col-md-8">
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-4">
                    <cc1:hwButton ID="ProcediPagamentoOnLine"  runat="server" Tag="ProcediPagamentoOnLine" Text="Procedi al pagamento on-line"></cc1:hwButton>
                </div>
                <div class="col-md-8">
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-4">
                    <cc1:hwButton ID="ScaricaFatture"  Style="width: 100%;" runat="server" Tag="ScaricaFatture" Text="Scarica le fatture" Visible="false"></cc1:hwButton>
                </div>
                <div class="col-md-8">
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-4">
                    <cc1:hwButton ID="StampaCarrello"  Style="width: 100%;" runat="server" Tag="StampaCarrello" Text="Stampa del carrello"></cc1:hwButton>
                </div>
                <div class="col-md-8">
                </div>
            </div>
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-4">
                    <cc1:hwButton ID="StampaRicevutaTelematica"  Style="width: 100%;" runat="server" Tag="StampaRicevutaTelematica" Text="Stampa della Ricevuta Telematica"></cc1:hwButton>
                </div>
                <div class="col-md-8">
                </div>
            </div>
        </div>
    </div>

    <div style="white-space:nowrap; line-height:2.4rem; color:#333; border:1px solid #dee2e6; background-color:#fffae5; border-radius:8px; font-size:.9rem; font-style:italic; text-align:center; margin-top:10px;">Si consiglia di aprire i pdf con Adobe Acrobat Reader</div>
</asp:Content>