﻿<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="mandatedetail_default_new02.aspx.cs" Inherits="mandatedetail_default_new02"  Title="Dettaglio Richiesta d'ordine" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >
	
<ul id="mainTabControl" class="nav nav-tabs nav-justified">
    <li><a data-toggle="tab" href="#tabmain">Principale</a></li>
    <li><a data-toggle="tab" href="#tabAnalitico">Analitico</a></li>
</ul>

<div class="tab-content">
    <div id="tabmain" class="tab-pane fade in active">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend></legend>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-lg-4 col-sm-6">
                                    <cc1:hwButton runat="server" ID="BtnListino" Text="Listino" Tag="elencaListino" TabIndex="10" CssClass="w-100 btn btn-primary" />
                                </div>
                                <div class="col-lg-4 col-sm-6">
                                    <cc1:hwButton runat="server" ID="btnCercaListino" Text="Cerca Listino" Tag="filtraListino" TabIndex="10" CssClass="w-100 btn btn-primary" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwTextBox runat="server" ID="txtListino" CssClass="form-control" Tag="listview.intcode" TabIndex="20"></cc1:hwTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwTextBox runat="server" ReadOnly="true" CssClass="form-control" TextMode="multiLine" ID="txtDescrizioneListino" Tag="listview.description" TabIndex="-1"></cc1:hwTextBox>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-7">
                                    <label for="cmbUnitaMisuraAcquisto">U.tà di misura imballo</label>
                                </div>
                                <div class="col-md-5">
                                    <cc1:hwDropDownList runat="server" ID="cmbUnitaMisuraAcquisto" CssClass="input-md form-control" Width="100%" Enabled="false" Tag="listview.idpackage" TabIndex="-1"></cc1:hwDropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-7">
                                    <label for="txtCoeffConversione">Coeff. di Conversione</label>
                                </div>
                                <div class="col-md-5">
                                    <cc1:hwTextBox runat="server" ID="txtCoeffConversione" CssClass="c_CoeffConversione form-control" ReadOnly="true" Tag="listview.unitsforpackage" TabIndex="-1"></cc1:hwTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-7">
                                    <label for="cmbUnitaMisuraCS">U.tà di Misura</label>
                                </div>
                                <div class="col-md-5">
                                    <cc1:hwDropDownList runat="server" ID="cmbUnitaMisuraCS" CssClass="form-control" Enabled="false" Tag="listview.idunit" TabIndex="-1"></cc1:hwDropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-12">
                <cc1:hwPanel GroupingText="Progetto-UPB" CssClass="gbox scheduler-border form-group" ID="PanelUpb" runat="server" Tag="AutoManage.txtCodiceUPB.tree.(active=\'S\')">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-4 col-lg-3">
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwButton ID="btnUpb" runat="server" Text="Progetto-UPB" class="btn btn-primary" Tag="manage.upbyearview.tree" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwTextBox TabIndex="20" ID="txtCodiceUPB" CssClass="form-control input-md" Tag="upb.codeupb?x" runat="server"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8 col-lg-9">
                                <cc1:hwTextBox runat="server" ID="txtDescrUPB" Tag="upb.title" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" ReadOnly="True"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>
                </cc1:hwPanel>
            </div>
        </div>

    
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-8">
                        <div class="row">
                            <div class="col-md-12">
                                <label for="txtDetailDescription">Descrizione</label>
                            </div>
                            <div class="col-md-12">
                                <cc1:hwTextBox runat="server" TabIndex="50" ID="txtDetailDescription" Rows="4" CssClass="form-control" Tag="mandatedetail.detaildescription" TextMode="MultiLine"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwLabel runat="server" ID="lblQuantita" Text="Quantità"></cc1:hwLabel>
                                    </div>
                                    <div class="col-md-12">
                                        <cc1:hwTextBox ID="txtQuantitaConfezioni" CssClass="c_QuantitaConfezioni form-control" TabIndex="40" runat="server" Tag="mandatedetail.npackage.N"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwLabel runat="server" ID="lblTotQuantOrd" Text="Totale quantità ordinata"></cc1:hwLabel>
                                    </div>
                                    <div class="col-md-12">
                                        <cc1:hwTextBox runat="server" ID="number" CssClass="c_number form-control" Tag="mandatedetail.number.N" TabIndex="-1"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-8">
                        <div class="row">
                            <div class="col-md-12">
                                <label for="idivakind">Tipo IVA</label>
                            </div>
                            <div class="col-md-12">
                                <cc1:hwDropDownList TabIndex="60" ID="idivakind" runat="server" CssClass="input-md form-control" AutoPostBack="True" Tag="mandatedetail.idivakind"></cc1:hwDropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label for="ivanotes">Note sul tipo IVA:</label>
                            </div>
                            <div class="col-md-12">
                                <cc1:hwTextBox TabIndex="70" runat="server" ID="ivanotes" Rows="3" CssClass="input-md form-control" TextMode="MultiLine" Tag="mandatedetail.ivanotes"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label for="taxrate">Aliquota</label>
                                    </div>
                                    <div class="col-md-12">
                                        <cc1:hwTextBox ID="taxrate" CssClass="c_taxrate input-md form-control" TabIndex="-1" Style="text-align: right;" runat="server" Tag="mandatedetail.taxrate.fixed.4..%.100" ReadOnly="True"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label for="unabatabilitypercentage">% Indetraibilità</label>
                                    </div>
                                    <div class="col-md-12">
                                        <cc1:hwTextBox TabIndex="-1" ID="unabatabilitypercentage" CssClass="c_unabatabilitypercentage input-md form-control" runat="server" Style="text-align: right;" Tag="ivakind.unabatabilitypercentage.fixed.4..%.100" ReadOnly="True"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Valore unitario in valuta</legend>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="taxable">Importo unitario</label>
                                </div>
                                <div class="col-md-12">
                                    <cc1:hwTextBox ID="taxable" CssClass="c_taxable form-control" runat="server" TabIndex="80" Tag="mandatedetail.taxable.fixed.5...1"></cc1:hwTextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="discount">Sconto</label>
                                </div>
                                <div class="col-md-12">
                                    <cc1:hwTextBox ID="discount" runat="server" CssClass="c_discount input-md form-control" TabIndex="90" Tag="mandatedetail.discount.fixed.4..%.100"></cc1:hwTextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="taxabletotval">Importo Totale(iva esclusa)</label>
                                </div>
                                <div class="col-md-12">
                                    <cc1:hwTextBox ID="taxabletotval" CssClass="c_taxabletotval input-md form-control" Style="text-align: right" runat="server" TabIndex="-1" ReadOnly="True"></cc1:hwTextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
	
        <div class="row">
	        <div class="col-md-4 col-lg-3">
		        <label for="txtDataInizioCompetenza">Data Inizio Competenza</label>
		        <cc1:hwTextBox ID="txtDataInizioCompetenza" runat="server"  CssClass="form-control" Tag="mandatedetail.competencystart"></cc1:hwTextBox>           
	        </div>
	        <div class="col-md-4 col-lg-3">
		        <label for="txtDataFineCompetenza">Data Fine Competenza</label>
		        <cc1:hwTextBox ID="txtDataFineCompetenza" runat="server" CssClass="form-control" Tag="mandatedetail.competencystop"></cc1:hwTextBox>           
	        </div>
        </div>

        <br />
        <br />

        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Valore totale in Euro</legend>
                    <div class="row">
                        <div class="col-md-4 col-lg-3">
                            <label for="taxable">Imponibile</label>
                            <cc1:hwTextBox ID="taxabletotal" CssClass="c_taxabletotal input-md form-control" Style="text-align: right" runat="server" TabIndex="-1"></cc1:hwTextBox>
                        </div>
                        <div class="col-md-4 col-lg-3">
                            <label for="tax">Iva</label>
                            <cc1:hwTextBox ID="tax" CssClass="c_tax input-md form-control" runat="server" TabIndex="100" Tag="mandatedetail.tax.fixed.2...1"></cc1:hwTextBox>
                        </div>
                        <div class="col-md-4 col-lg-3">
                            <label for="unabatable">Iva indetraibile</label>
                            <cc1:hwTextBox ID="impindeduceur" CssClass="c_impindeduceur input-md form-control" TabIndex="110" runat="server" Tag="mandatedetail.unabatable.n" ReadOnly="False"></cc1:hwTextBox>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Attività</legend>
                    <div class="row">
                        <div class="col-md-6 col-lg-3">
                            <cc1:hwRadioButton TabIndex="130" ID="rdbQualsiasi" AutoPostBack="true" runat="server" Tag="mandatedetail.flagactivity:4"  OnCheckedChanged="rdbQualsiasi_CheckedChanged" Text=" Qualsiasi / Non specificata" />
                        </div>
                        <div class="col-md-6 col-lg-3">
                            <cc1:hwRadioButton TabIndex="140" ID="rdbIstituzionale" AutoPostBack="true" runat="server" Tag="mandatedetail.flagactivity:1" OnCheckedChanged="rdbQualsiasi_CheckedChanged"  Text=" Istituzionale" />
                        </div>
                        <div class="col-md-6 col-lg-3">
                            <cc1:hwRadioButton TabIndex="150" ID="rdbCommerciale" AutoPostBack="true" runat="server" Tag="mandatedetail.flagactivity:2" OnCheckedChanged="rdbQualsiasi_CheckedChanged" Text=" Commerciale" />
                        </div>
                        <div class="col-md-6 col-lg-3">
                            <cc1:hwRadioButton TabIndex="160" ID="rdbPromiscua" AutoPostBack="true" runat="server" Tag="mandatedetail.flagactivity:3" OnCheckedChanged="rdbQualsiasi_CheckedChanged" Text=" Promiscuo" />
                        </div>

                    </div>
                </fieldset>
            </div>
        </div>
   <%-- modifiche luigi task 8179--%>   
        
        <div class="row">
            <div class="col-md-12">
                <cc1:hwPanel GroupingText="Ubicazione" CssClass="gbox scheduler-border form-group" ID="HwPanel1" runat="server" Tag="AutoManage.txtlocation.tree">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-4 col-lg-3">
                                <div class="row">
                                    <div class="col-md-12">
                                <cc1:hwButton ID="btnUbicazione" runat="server" Text="Ubicazione" class="btn btn-block" Tag="manage.locationview.tree.(active='S')" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                <cc1:hwTextBox TabIndex="20" ID="txtlocation" CssClass="form-control input-md" Tag="locationview.locationcode?x" runat="server"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8 col-lg-9">
                        <cc1:hwTextBox runat="server" ID="txtDescUbicazione" Tag="locationview.description" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" ReadOnly="True"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>
                </cc1:hwPanel>
            </div>
        </div>
    <%--fine modifiche--%>

        <div class="row">
            <div class="col-md-3">
                <div class="row">
                    <div class="col-md-12">
                        <label for="cupcode">CUP</label>
                        <cc1:hwTextBox runat="server" Tag="mandatedetail.cupcode" CssClass="input-md form-control" ID="cupcode" TabIndex="180"></cc1:hwTextBox>
                    </div>
	            </div>
            </div>
            <div class="col-md-3 offset-md-3 align-self-end">
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwCheckBox ID="HwCheckBox1" runat="server" TabIndex="25" Tag="mandatedetail.flagto_invoice:S:N" CssClass="input-md form-control" Text="Scarico immediato" />
                    </div>
	            </div>
            </div>
        </div>
	</div>

	<div id="tabAnalitico" class="tab-pane fade">
		<div title="Analitico">
			<asp:Panel ID="PanelAnalitico" runat="server">
                <div class="row">
                    <div class="col-md-12">
                        <fieldset>
                            <legend>Analitico</legend>
                            <div class="row grp">
                                <div class="col-lg-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <!-- Classificazione 1-->

                                            <cc1:hwPanel GroupingText="Classificazione 1" CssClass="gbox stdfieldset form-group" ID="gboxclass1" runat="server" Tag="AutoManage.txtCodice1.treeclassmovimenti">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <div class="col-12">
                                                                <cc1:hwButton runat="server" ID="btnCodice1" Tag="manage.sorting1.tree" TabIndex="400" class="btn btn-primary" Text="Codice"></cc1:hwButton>
                                                                <cc1:hwTextBox runat="server" ID="txtCodice1" CssClass="form-control input-md" Tag="sorting1.sortcode?x" TabIndex="410"></cc1:hwTextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <div class="col-12">
                                                                <cc1:hwTextBox runat="server" ID="txtDenom1" CssClass="form-control input-md" Tag="sorting1.description" TextMode="MultiLine" Rows="3" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </cc1:hwPanel>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <!-- Classificazione 2-->
                                            <cc1:hwPanel GroupingText="Classificazione 2" CssClass="gbox stdfieldset form-group" ID="gboxclass2" runat="server" Tag="AutoManage.txtCodice2.treeclassmovimenti">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <div class="col-12">
                                                                <cc1:hwButton runat="server" ID="btnCodice2" Tag="manage.sorting2.tree" TabIndex="400" class="btn btn-primary" Text="Codice"></cc1:hwButton>
                                                                <cc1:hwTextBox runat="server" ID="txtCodice2" CssClass="form-control input-md" Tag="sorting2.sortcode?x" TabIndex="410"></cc1:hwTextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <div class="col-12">
                                                                <cc1:hwTextBox runat="server" ID="txtDenom2" CssClass="form-control input-md" Tag="sorting2.description" TextMode="MultiLine" Rows="3" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </cc1:hwPanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <!-- Classificazione 3-->
                                    <cc1:hwPanel GroupingText="Classificazione 3" CssClass="gbox stdfieldset form-group" ID="gboxclass3" runat="server" Tag="AutoManage.txtCodice3.treeclassmovimenti">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <cc1:hwButton runat="server" ID="btnCodice3" Tag="manage.sorting3.tree" TabIndex="400" class="btn btn-primary" Text="Codice"></cc1:hwButton>
                                                        <cc1:hwTextBox runat="server" ID="txtCodice3" CssClass="form-control input-md" Tag="sorting3.sortcode?x" TabIndex="410"></cc1:hwTextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-12">
                                                <cc1:hwTextBox runat="server" ID="txtDenom3" CssClass="form-control input-md" Tag="sorting3.description" TextMode="MultiLine" Rows="3" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                    </cc1:hwPanel>
                                </div>
                            </div>
                        </fieldset>
                    </div>

                </div><!-- chiude sezione Classificazioni Analitiche-->
			</asp:Panel>
		</div>
	</div>
</div>


</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="JScriptAfterLibs"  runat="server">

<script type="text/javascript">
	function CalcImponibileTot() {
		var ImponibileTot = new Object();
		var SubTotal = new Object();
		var Imponibile = GetObjectFromString("Decimal", $(".c_taxable").val(), "fixed.5...1");
		var quantita = GetObjectFromString("Decimal", $(".c_QuantitaConfezioni").val(), "N");
		var sconto = GetObjectFromString("Double", $(".c_discount").val(), "fixed.4..%.100");

		if (Imponibile == null) Imponibile = new Object();
		if (quantita == null) quantita = new Object();
		if (sconto == null) sconto = new Object();


		if (Imponibile.Obj == null) Imponibile.Obj = 0;
		if (quantita.Obj == null) quantita.Obj = 0;
		if (sconto.Obj == null) sconto.Obj = 0;


		//if(Imponibile.Obj==null||Imponibile==null||quantita==null||quantita.Obj==null||sconto==null||sconto.Obj==null) return;
		SubTotal = Imponibile.Obj * (quantita.Obj) * (1 - sconto.Obj);
		SubTotal.TypeName = "Double";
		ImponibileTot.Obj = SubTotal.toFixed(2);
		ImponibileTot.TypeName = "Double";

		$(".c_taxabletotval").val(StringValue(ImponibileTot, "fixed.2...1"));

		return;
	}

	function CalcIva(tassocambio) {
		var ImponibileTot = GetObjectFromString("Decimal", $(".c_taxabletotval").val(), "fixed.2...1");
		var rate = GetObjectFromString("Double", $(".c_taxrate").val(), "fixed.4..%.100");



		if (ImponibileTot == null) ImponibileTot = new Object();
		if (ImponibileTot.Obj == null) ImponibileTot.Obj = 0;

		if (rate == null) rate = new Object();
		if (typeof rate.Obj === 'undefined') rate.Obj = 0;

		var total = new Object();
		total.Obj = ImponibileTot.Obj * rate.Obj * tassocambio;
		total.TypeName = "Double";

		$(".c_tax").val(StringValue(total, "fixed.2...1"));

	}


	function CalcIvaIndeduc(tassocambio) {
		var Tax = GetObjectFromString("Decimal", $(".c_tax").val(), "fixed.2...1");
		var rateindeduc = GetObjectFromString("Double", $(".c_unabatabilitypercentage").val(), "fixed.4..%.100");

		if (Tax == null) Tax = new Object();
		if (rateindeduc == null) rateindeduc = new Object();
		if (typeof rateindeduc.Obj === 'undefined') rateindeduc.Obj = 0;

		var total = new Object();
		total.Obj = Tax.Obj * rateindeduc.Obj;
		total.TypeName = "Double";

		$(".c_impindeduceur").val(StringValue(total, "fixed.2...1"));

	}

	function CalcTotQuant() {
		var coeffconf = GetObjectFromString("Decimal", $(".c_CoeffConversione").val(), "N");
		var quantitaconf = GetObjectFromString("Decimal", $(".c_QuantitaConfezioni").val(), "N");

		if (coeffconf == null) {
			coeffconf = new Object();
			coeffconf.Obj = 1;
		}
		if (quantitaconf == null) {
			quantitaconf = new Object();
			quantitaconf.Obj = 0;
		}
		var num = new Object();
		num.Obj = coeffconf.Obj * quantitaconf.Obj;
		num.TypeName = "Decimal";

		$(".c_number").val(StringValue(num, "N"));
		return;
	}

	function CalcTaxableTotal(tassocambio) {
		//coeffconv=GetObjectFromString("Decimal",document.getElementById(".txtCoeffConversione.ClientID").value,"N");
		var ImponibileTot = new Object();
		var Imponibile = GetObjectFromString("Decimal", $(".c_taxable").val(), "fixed.5...1");
		var quantita = GetObjectFromString("Decimal", $(".c_QuantitaConfezioni").val(), "N");
		var sconto = GetObjectFromString("Double", $(".c_discount").val(), "fixed.4..%.100");

		if (Imponibile == null) Imponibile = new Object();
		if (quantita == null) quantita = new Object();
		if (sconto == null) sconto = new Object();


		if (Imponibile.Obj == null) Imponibile.Obj = 0;
		if (quantita.Obj == null) quantita.Obj = 0;
		if (sconto.Obj == null) sconto.Obj = 0;


		//if(Imponibile.Obj==null||Imponibile==null||quantita==null||quantita.Obj==null||sconto==null||sconto.Obj==null) return;
		var SubTotal = new Object();
		SubTotal = Imponibile.Obj * (quantita.Obj) * (1 - sconto.Obj);
		SubTotal.TypeName = "Double";
		var ImponibileEur = new Object();
		ImponibileEur.Obj = SubTotal.toFixed(2) * tassocambio;
		ImponibileEur.TypeName = "Double";

		ImponibileEur.Obj = ImponibileEur.Obj.toFixed(2);
		$(".c_taxabletotal").val(StringValue(ImponibileEur, "fixed.2...1"));


	}


</script>
</asp:Content>