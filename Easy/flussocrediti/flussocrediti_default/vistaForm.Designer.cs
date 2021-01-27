
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_flussocrediti;
using meta_flussocreditidetail;
using meta_sorting;
using meta_config;
using meta_estimatedetail;
using meta_invoicedetail;
using meta_estimatekind;
using meta_invoicekind;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace flussocrediti_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Crediti da comunicare al nodo pagamenti o simili, anche usata per i crediti che ci vengono comunicati dalle segreterie studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditiTable flussocrediti 		=> (flussocreditiTable)Tables["flussocrediti"];

	///<summary>
	///Dettaglio flusso crediti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditidetailTable flussocreditidetail_ca 		=> (flussocreditidetailTable)Tables["flussocreditidetail_ca"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting05 		=> (sortingTable)Tables["sorting05"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting02 		=> (sortingTable)Tables["sorting02"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting03 		=> (sortingTable)Tables["sorting03"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting04 		=> (sortingTable)Tables["sorting04"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting01 		=> (sortingTable)Tables["sorting01"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	///<summary>
	///Dettaglio contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatedetailTable estimatedetail 		=> (estimatedetailTable)Tables["estimatedetail"];

	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicedetailTable invoicedetail 		=> (invoicedetailTable)Tables["invoicedetail"];

	///<summary>
	///Dettaglio flusso crediti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditidetailTable flussocreditidetail_fatt 		=> (flussocreditidetailTable)Tables["flussocreditidetail_fatt"];

	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatekindTable estimatekind 		=> (estimatekindTable)Tables["estimatekind"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatekindTable estimatekind1 		=> (estimatekindTable)Tables["estimatekind1"];

	///<summary>
	///Dettaglio flusso crediti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditidetailTable flussocreditidetail_unlinked 		=> (flussocreditidetailTable)Tables["flussocreditidetail_unlinked"];

	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatekindTable estimatekind2 		=> (estimatekindTable)Tables["estimatekind2"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind1 		=> (invoicekindTable)Tables["invoicekind1"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// FLUSSOCREDITI /////////////////////////////////
	var tflussocrediti= new flussocreditiTable();
	tflussocrediti.addBaseColumns("idflusso","cu","ct","lu","lt","datacreazioneflusso","flusso","istransmitted","idsor01","idsor02","idsor03","idsor04","idsor05","filename","progday","idestimkind","docdate");
	Tables.Add(tflussocrediti);
	tflussocrediti.defineKey("idflusso");

	//////////////////// FLUSSOCREDITIDETAIL_CA /////////////////////////////////
	var tflussocreditidetail_ca= new flussocreditidetailTable();
	tflussocreditidetail_ca.TableName = "flussocreditidetail_ca";
	tflussocreditidetail_ca.addBaseColumns("idflusso","iddetail","cu","ct","lu","lt","importoversamento","idestimkind","yestim","nestim","rownum","idinvkind","yinv","ninv","invrownum","competencystart","competencystop","description","idaccmotivecredit","idaccmotiverevenue","idaccmotiveundotax","idaccmotiveundotaxpost","idfinmotive","idreg","iduniqueformcode","idupb","nform","stop","expirationdate","barcodevalue","barcodeimage","qrcodevalue","qrcodeimage","cf","iuv","annulment","idunivoco","codiceavviso","idsor1","idsor2","idsor3","idivakind","tax","number","p_iva","annotations","flag","idlist");
	tflussocreditidetail_ca.defineColumn("!estimkind", typeof(string));
	tflussocreditidetail_ca.defineColumn("!cliente", typeof(string));
	tflussocreditidetail_ca.ExtendedProperties["TableForPosting"]="flussocreditidetail";
	tflussocreditidetail_ca.ExtendedProperties["TableForReading"]="flussocreditidetail";
	Tables.Add(tflussocreditidetail_ca);
	tflussocreditidetail_ca.defineKey("idflusso", "iddetail");

	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new sortingTable();
	tsorting05.TableName = "sorting05";
	tsorting05.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email");
	tsorting05.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting05);
	tsorting05.defineKey("idsor");

	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new sortingTable();
	tsorting02.TableName = "sorting02";
	tsorting02.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email");
	tsorting02.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting02);
	tsorting02.defineKey("idsor");

	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new sortingTable();
	tsorting03.TableName = "sorting03";
	tsorting03.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email");
	tsorting03.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting03);
	tsorting03.defineKey("idsor");

	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new sortingTable();
	tsorting04.TableName = "sorting04";
	tsorting04.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email");
	tsorting04.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting04);
	tsorting04.defineKey("idsor");

	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new sortingTable();
	tsorting01.TableName = "sorting01";
	tsorting01.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email");
	tsorting01.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting01);
	tsorting01.defineKey("idsor");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","finvarofficial_default","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idregauto","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart","idivapayperiodicity","idsortingkind1","idsortingkind2","idsortingkind3","fin_kind","taxvaliditykind","flag_paymentamount","automanagekind","flag_autodocnumbering","flagbank_grouping","cashvaliditykind","wageimportappname","balancekind","idpaymethodabi","idpaymethodnoabi","iban_f24","cudactivitycode","startivabalance","flagivapaybyrow","idacc_unabatable","idacc_unabatable_refund","invoice_flagregister","default_idfinvarstatus","flagivaregphase","mainflagpayment","mainflagrefund","mainidfinivapayment","mainidfinivarefund","mainminpayment","mainminrefund","mainpaymentagency","mainrefundagency","mainflagivaregphase","mainstartivabalance","mainidacc_unabatable","mainidacc_unabatable_refund","idacc_mainivapayment","idacc_mainivapayment_internal","idacc_mainivarefund","idacc_mainivarefund_internal","flagva3","flagrefund12","flagpayment12","refundagency12","paymentagency12","idfinivarefund12","idfinivapayment12","minrefund12","minpayment12","idacc_ivapayment12","idacc_ivarefund12","idacc_mainivarefund12","idacc_mainivapayment12","idacc_mainivapayment_internal12","idacc_mainivarefund_internal12","startivabalance12","mainrefundagency12","mainpaymentagency12","mainflagrefund12","mainflagpayment12","mainidfinivarefund12","mainidfinivapayment12","mainminrefund12","mainminpayment12","mainstartivabalance12","idreg_csa","finvar_warnmail","flagdirectcsaclawback","idacc_revenue_gross_csa","idfinincome_gross_csa","idsor1_stock","idsor2_stock","idsor3_stock","idinpscenter","idivapayperiodicity_instit","idfin_store","flagpcashautopayment","flagpcashautoproceeds","email","lcard","booking_on_invoice","itineration_directauth","email_f24","csa_flaggroupby_income","csa_flaggroupby_expense","csa_flaglinktoexp","idsiopeincome_csa","idacc_invoicetoemit","idacc_invoicetoreceive","epannualthreeshold","flagbalance_csa","flagiva_immediate_or_deferred","flagenabletransmission","idpccdebitstatus","flagsplitpayment","startivabalancesplit","paymentagencysplit","idfinivapaymentsplit","flagpaymentsplit","idacc_unabatable_split","idacc_ivapaymentsplit","agencynumber","femode","idacc_economic_result","idacc_previous_economic_result","idacc_bankpaydoc","idacc_bankprodoc","csa_flagtransmissionlinking","idaccmotive_forwarder","idivakind_forwarder");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// ESTIMATEDETAIL /////////////////////////////////
	var testimatedetail= new estimatedetailTable();
	testimatedetail.addBaseColumns("idestimkind","yestim","nestim","rownum","annotations","ct","cu","detaildescription","discount","idupb","lt","lu","ninvoiced","number","start","stop","tax","taxable","taxrate","toinvoice","idaccmotive","idreg","idgroup","competencystart","competencystop","idinc_taxable","idinc_iva","idivakind","idsor1","idsor2","idsor3","idaccmotiveannulment","epkind","idrevenuepartition","idepacc","idupb_iva","idlist","cigcode","idfinmotive","iduniqueformcode","flag","proceedsexpiring");
	Tables.Add(testimatedetail);
	testimatedetail.defineKey("idestimkind", "yestim", "nestim", "rownum");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("ninv","rownum","yinv","annotations","competencystart","paymentcompetency","competencystop","ct","cu","detaildescription","discount","idaccmotive","idmankind","idupb","lt","lu","manrownum","nman","number","tax","taxable","unabatable","yman","idestimkind","estimrownum","nestim","yestim","idgroup","idexp_taxable","idexp_iva","idinc_taxable","idinc_iva","ninv_main","yinv_main","idivakind","idinvkind","idsor1","idsor2","idsor3","idintrastatcode","idintrastatmeasure","weight","va3type","intrastatoperationkind","idintrastatservice","idintrastatsupplymethod","idlist","idunit","idpackage","unitsforpackage","npackage","flag","exception12","intra12operationkind","move12","idupb_iva","idinvkind_main","leasing","usedmodesospesometro","resetresidualmandate","idfetransfer","fereferencerule","cupcode","cigcode","idpccdebitstatus","idpccdebitmotive","idcostpartition","expensekind","rounding","idepexp","idepacc","flagbit","idfinmotive","iduniqueformcode");
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("ninv", "rownum", "yinv", "idinvkind");

	//////////////////// FLUSSOCREDITIDETAIL_FATT /////////////////////////////////
	var tflussocreditidetail_fatt= new flussocreditidetailTable();
	tflussocreditidetail_fatt.TableName = "flussocreditidetail_fatt";
	tflussocreditidetail_fatt.addBaseColumns("idflusso","iddetail","cu","ct","lu","lt","importoversamento","idestimkind","yestim","nestim","rownum","idinvkind","yinv","ninv","invrownum","competencystart","competencystop","description","idaccmotivecredit","idaccmotiverevenue","idaccmotiveundotax","idaccmotiveundotaxpost","idfinmotive","idreg","iduniqueformcode","idupb","nform","stop","expirationdate","barcodevalue","barcodeimage","qrcodevalue","qrcodeimage","cf","iuv","annulment","idunivoco","codiceavviso","idsor1","idsor2","idsor3","idivakind","tax","number","p_iva","annotations","flag","idlist");
	tflussocreditidetail_fatt.defineColumn("!invkind", typeof(string));
	tflussocreditidetail_fatt.defineColumn("!cliente", typeof(string));
	tflussocreditidetail_fatt.ExtendedProperties["TableForPosting"]="flussocreditidetail";
	tflussocreditidetail_fatt.ExtendedProperties["TableForReading"]="flussocreditidetail";
	Tables.Add(tflussocreditidetail_fatt);
	tflussocreditidetail_fatt.defineKey("idflusso", "iddetail");

	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new estimatekindTable();
	testimatekind.addBaseColumns("idestimkind","active","ct","cu","description","idupb","lt","lu","rtf","txt","email","faxnumber","office","phonenumber","linktoinvoice","multireg","deltaamount","deltapercentage","flag_autodocnumbering","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","idivakind_forced","flag");
	Tables.Add(testimatekind);
	testimatekind.defineKey("idestimkind");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("ct","cu","description","lt","lu","codeinvkind","idinvkind","flag","flag_autodocnumbering","formatstring","active","idinvkind_auto","printingcode","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","notes1","notes2","notes3","ipa_fe","riferimento_amministrazione","enable_fe");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// ESTIMATEKIND1 /////////////////////////////////
	var testimatekind1= new estimatekindTable();
	testimatekind1.TableName = "estimatekind1";
	testimatekind1.addBaseColumns("idestimkind","active","ct","cu","description","idupb","lt","lu","rtf","txt","email","faxnumber","office","phonenumber","linktoinvoice","multireg","deltaamount","deltapercentage","flag_autodocnumbering","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","idivakind_forced","flag");
	testimatekind1.ExtendedProperties["TableForReading"]="estimatekind";
	Tables.Add(testimatekind1);
	testimatekind1.defineKey("idestimkind");

	//////////////////// FLUSSOCREDITIDETAIL_UNLINKED /////////////////////////////////
	var tflussocreditidetail_unlinked= new flussocreditidetailTable();
	tflussocreditidetail_unlinked.TableName = "flussocreditidetail_unlinked";
	tflussocreditidetail_unlinked.addBaseColumns("idflusso","iddetail","cu","ct","lu","lt","importoversamento","idestimkind","yestim","nestim","rownum","idinvkind","yinv","ninv","invrownum","competencystart","competencystop","description","idaccmotivecredit","idaccmotiverevenue","idaccmotiveundotax","idaccmotiveundotaxpost","idfinmotive","idreg","iduniqueformcode","idupb","nform","stop","expirationdate","barcodevalue","barcodeimage","qrcodevalue","qrcodeimage","cf","iuv","idunivoco","codiceavviso","annulment","idsor1","idsor2","idsor3","idivakind","tax","number","p_iva","annotations","flag","idlist");
	tflussocreditidetail_unlinked.defineColumn("!invkind", typeof(string));
	tflussocreditidetail_unlinked.defineColumn("!cliente", typeof(string));
	tflussocreditidetail_unlinked.ExtendedProperties["TableForPosting"]="flussocreditidetail";
	tflussocreditidetail_unlinked.ExtendedProperties["TableForReading"]="flussocreditidetail";
	Tables.Add(tflussocreditidetail_unlinked);
	tflussocreditidetail_unlinked.defineKey("idflusso", "iddetail");

	//////////////////// ESTIMATEKIND2 /////////////////////////////////
	var testimatekind2= new estimatekindTable();
	testimatekind2.TableName = "estimatekind2";
	testimatekind2.addBaseColumns("idestimkind","active","ct","cu","description","idupb","lt","lu","rtf","txt","email","faxnumber","office","phonenumber","linktoinvoice","multireg","deltaamount","deltapercentage","flag_autodocnumbering","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","idivakind_forced","flag");
	testimatekind2.ExtendedProperties["TableForReading"]="estimatekind";
	Tables.Add(testimatekind2);
	testimatekind2.defineKey("idestimkind");

	//////////////////// INVOICEKIND1 /////////////////////////////////
	var tinvoicekind1= new invoicekindTable();
	tinvoicekind1.TableName = "invoicekind1";
	tinvoicekind1.addBaseColumns("ct","cu","description","lt","lu","codeinvkind","idinvkind","flag","flag_autodocnumbering","formatstring","active","idinvkind_auto","printingcode","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","notes1","notes2","notes3","ipa_fe","riferimento_amministrazione","enable_fe");
	tinvoicekind1.ExtendedProperties["TableForReading"]="invoicekind";
	Tables.Add(tinvoicekind1);
	tinvoicekind1.defineKey("idinvkind");

	#endregion


	#region DataRelation creation
	this.defineRelation("flussocrediti_flussocreditidetail_unlinked","flussocrediti","flussocreditidetail_unlinked","idflusso");
	var cPar = new []{invoicedetail.Columns["ninv"], invoicedetail.Columns["rownum"], invoicedetail.Columns["yinv"], invoicedetail.Columns["idinvkind"]};
	var cChild = new []{flussocreditidetail_fatt.Columns["ninv"], flussocreditidetail_fatt.Columns["invrownum"], flussocreditidetail_fatt.Columns["yinv"], flussocreditidetail_fatt.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoicedetail_flussocreditidetail_fatt",cPar,cChild,false));

	this.defineRelation("FK_invoicekind_flussocreditidetail_fatt","invoicekind","flussocreditidetail_fatt","idinvkind");
	this.defineRelation("FK_flussocrediti_flussocreditidetail_fatt","flussocrediti","flussocreditidetail_fatt","idflusso");
	this.defineRelation("FK_estimatekind1_flussocreditidetail_ca","estimatekind1","flussocreditidetail_ca","idestimkind");
	this.defineRelation("FK_flussocreditidetail_estimatedetail","estimatedetail","flussocreditidetail_ca","idestimkind","yestim","nestim","rownum");
	this.defineRelation("FK_flussocrediti_flussocreditidetail","flussocrediti","flussocreditidetail_ca","idflusso");
	this.defineRelation("FK_estimatekind_estimatedetail","estimatekind","flussocrediti","idestimkind");
	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{flussocrediti.Columns["idsor05"]};
	Relations.Add(new DataRelation("FK_sorting05_flussocrediti",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{flussocrediti.Columns["idsor04"]};
	Relations.Add(new DataRelation("FK_sorting04_flussocrediti",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{flussocrediti.Columns["idsor03"]};
	Relations.Add(new DataRelation("FK_sorting03_flussocrediti",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{flussocrediti.Columns["idsor02"]};
	Relations.Add(new DataRelation("FK_sorting02_flussocrediti",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{flussocrediti.Columns["idsor01"]};
	Relations.Add(new DataRelation("FK_sorting01_flussocrediti",cPar,cChild,false));

	#endregion

}
}
}
