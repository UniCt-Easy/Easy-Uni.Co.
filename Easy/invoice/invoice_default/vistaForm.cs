/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using meta_invoice;
using meta_invoicekind;
using meta_registry;
using meta_invoicedetail;
using meta_ivakind;
using meta_ivaregister;
using meta_ivaregisterkind;
using meta_sorting;
using meta_profservice;
using meta_config;
using meta_treasurer;
using meta_expensesorted;
using meta_expensevar;
using meta_mandatedetail;
using meta_sdi_acquisto;
using meta_sdi_vendita;
using meta_assetacquire;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace invoice_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoiceTable invoice 		=> (invoiceTable)Tables["invoice"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Valuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable currency 		=> (MetaTable)Tables["currency"];

	///<summary>
	/// Tipo Scadenza
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expirationkind 		=> (MetaTable)Tables["expirationkind"];

	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicedetailTable invoicedetail 		=> (invoicedetailTable)Tables["invoicedetail"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivakindTable ivakind 		=> (ivakindTable)Tables["ivakind"];

	///<summary>
	///Registro iva
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivaregisterTable ivaregister 		=> (ivaregisterTable)Tables["ivaregister"];

	///<summary>
	///collegamento tra registri iva e  tipo documento iva
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicekindregisterkind 		=> (MetaTable)Tables["invoicekindregisterkind"];

	///<summary>
	///Registro IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivaregisterkindTable ivaregisterkind 		=> (ivaregisterkindTable)Tables["ivaregisterkind"];

	///<summary>
	///iva di una fattura inserita in liquidazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedeferred 		=> (MetaTable)Tables["invoicedeferred"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting 		=> (sortingTable)Tables["sorting"];

	///<summary>
	///Classificazione documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicesorting 		=> (MetaTable)Tables["invoicesorting"];

	///<summary>
	///Tipo conto, determina il modo in cui è movimentato nelle varie situazioni.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accountkind 		=> (MetaTable)Tables["accountkind"];

	///<summary>
	///informazioni annuali su un tipo documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicekindyear 		=> (MetaTable)Tables["invoicekindyear"];

	///<summary>
	///Parcella Professionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public profserviceTable profservice 		=> (profserviceTable)Tables["profservice"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public treasurerTable treasurer 		=> (treasurerTable)Tables["treasurer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable intrastatnation_provenance 		=> (MetaTable)Tables["intrastatnation_provenance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable intrastatnation_origin 		=> (MetaTable)Tables["intrastatnation_origin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable intrastatnation_destination 		=> (MetaTable)Tables["intrastatnation_destination"];

	///<summary>
	///Natura della transazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable intrastatkind 		=> (MetaTable)Tables["intrastatkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_country_origin 		=> (MetaTable)Tables["geo_country_origin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_country_destination 		=> (MetaTable)Tables["geo_country_destination"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_debit 		=> (MetaTable)Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_crg 		=> (MetaTable)Tables["accmotiveapplied_crg"];

	///<summary>
	/// Natura della transazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable intrastatpaymethod 		=> (MetaTable)Tables["intrastatpaymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable intrastatnation_payment 		=> (MetaTable)Tables["intrastatnation_payment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stockview 		=> (MetaTable)Tables["stockview"];

	///<summary>
	///Merce in Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stock 		=> (MetaTable)Tables["stock"];

	///<summary>
	///Paesi a fiscalità privilegiata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable blacklist 		=> (MetaTable)Tables["blacklist"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicekind_real 		=> (MetaTable)Tables["invoicekind_real"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting01 		=> (MetaTable)Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting02 		=> (MetaTable)Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting03 		=> (MetaTable)Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting04 		=> (MetaTable)Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting05 		=> (MetaTable)Tables["sorting05"];

	///<summary>
	///Classificazione Movimenti di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expensesortedTable expensesorted 		=> (expensesortedTable)Tables["expensesorted"];

	///<summary>
	///Variazione movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expensevarTable expensevar 		=> (expensevarTable)Tables["expensevar"];

	///<summary>
	///Dettaglio contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandatedetailTable mandatedetail 		=> (mandatedetailTable)Tables["mandatedetail"];

	///<summary>
	///Condizioni pagamento fattura elettronica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fepaymethod 		=> (MetaTable)Tables["fepaymethod"];

	///<summary>
	///Condizioni  pagamento fattura elettronica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fepaymethodcondition 		=> (MetaTable)Tables["fepaymethodcondition"];

	///<summary>
	///Registro unico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable uniqueregister 		=> (MetaTable)Tables["uniqueregister"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pccview 		=> (MetaTable)Tables["pccview"];

	///<summary>
	///allegato alla fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoiceattachment 		=> (MetaTable)Tables["invoiceattachment"];

	///<summary>
	///Fattura Elettronica-Acquisto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sdi_acquistoTable sdi_acquisto 		=> (sdi_acquistoTable)Tables["sdi_acquisto"];

	///<summary>
	///Stato fattura in SDI
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sdi_status 		=> (MetaTable)Tables["sdi_status"];

	///<summary>
	///Fatture di vendita selezionate per la trasmissione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sdi_venditaTable sdi_vendita 		=> (sdi_venditaTable)Tables["sdi_vendita"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sdi_statusvendita 		=> (MetaTable)Tables["sdi_statusvendita"];

	///<summary>
	///Stato trasmissione SDI
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sdi_deliverystatus 		=> (MetaTable)Tables["sdi_deliverystatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ipa_ven_emittente 		=> (MetaTable)Tables["ipa_ven_emittente"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rifamm_ven_emittente 		=> (MetaTable)Tables["rifamm_ven_emittente"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoice_bolladoganale 		=> (MetaTable)Tables["invoice_bolladoganale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicekind_forwarder 		=> (MetaTable)Tables["invoicekind_forwarder"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicekind_bolladoganale 		=> (MetaTable)Tables["invoicekind_bolladoganale"];

	///<summary>
	///Carico dei cespiti da bolla/fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetacquireTable assetacquire 		=> (assetacquireTable)Tables["assetacquire"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable profservice_1 		=> (MetaTable)Tables["profservice_1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting_siope 		=> (MetaTable)Tables["sorting_siope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nocigmotive 		=> (MetaTable)Tables["nocigmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_sostituto 		=> (MetaTable)Tables["registry_sostituto"];

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
	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new invoiceTable();
	tinvoice.addBaseColumns("idinvkind","yinv","ninv","idreg","registryreference","description","paymentexpiring","idexpirationkind","idcurrency","exchangerate","doc","docdate","adate","packinglistnum","packinglistdate","flagdeferred","officiallyprinted","txt","rtf","cu","ct","lu","lt","active","idtreasurer","flagintracom","iso_origin","iso_provenance","iso_destination","idcountry_origin","idcountry_destination","idintrastatkind","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","idintrastatpaymethod","iso_payment","flag_ddt","flag","idblacklist","idinvkind_real","yinv_real","ninv_real","autoinvoice","idsor01","idsor02","idsor03","idsor04","idsor05","protocoldate","idfepaymethodcondition","idfepaymethod","nelectronicinvoice","yelectronicinvoice","arrivalprotocolnum","annotations","toincludeinpaymentindicator","resendingpcc","touniqueregister","idstampkind","flag_enable_split_payment","flag_auto_split_payment","idsdi_acquisto","idsdi_vendita","flag_reverse_charge","ipa_acq","rifamm_acq","ipa_ven_emittente","rifamm_ven_emittente","ipa_ven_cliente","rifamm_ven_cliente","ssntipospesa","ssnflagtipospesa","idinvkind_forwarder","yinv_forwarder","ninv_forwarder","flagbit","requested_doc","idnocigmotive","idreg_sostituto","email_ven_cliente","pec_ven_cliente");
	Tables.Add(tinvoice);
	tinvoice.defineKey("idinvkind", "yinv", "ninv");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("idinvkind","flag","description","cu","ct","lu","lt","flag_autodocnumbering","formatstring","active","idinvkind_auto","idsor01","idsor02","idsor03","idsor04","idsor05","ipa_fe","riferimento_amministrazione","codeinvkind","enable_fe");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","annotation","birthdate","gender","surname","forename","foreigncf","active","txt","rtf","cu","ct","lu","lt","badgecode","idcategory","idcentralizedcategory","idmaritalstatus","idtitle","idregistryclass","maritalsurname","idcity","idnation","location","extmatricula","ipa_fe","flag_pa","pec_fe","email_fe","idaccmotivedebit","idaccmotivecredit");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new MetaTable("currency");
	tcurrency.defineColumn("idcurrency", typeof(int),false);
	tcurrency.defineColumn("codecurrency", typeof(string));
	tcurrency.defineColumn("description", typeof(string),false);
	tcurrency.defineColumn("cu", typeof(string),false);
	tcurrency.defineColumn("ct", typeof(DateTime),false);
	tcurrency.defineColumn("lu", typeof(string),false);
	tcurrency.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tcurrency);
	tcurrency.defineKey("idcurrency");

	//////////////////// EXPIRATIONKIND /////////////////////////////////
	var texpirationkind= new MetaTable("expirationkind");
	texpirationkind.defineColumn("idexpirationkind", typeof(short),false);
	texpirationkind.defineColumn("description", typeof(string),false);
	texpirationkind.defineColumn("lu", typeof(string));
	texpirationkind.defineColumn("lt", typeof(DateTime));
	texpirationkind.defineColumn("active", typeof(string));
	Tables.Add(texpirationkind);
	texpirationkind.defineKey("idexpirationkind");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("idinvkind","yinv","ninv","rownum","idivakind","detaildescription","annotations","taxable","tax","unabatable","cu","ct","lu","lt","discount","idmankind","yman","nman","manrownum","number","idupb","idsor1","idsor2","idsor3","competencystart","competencystop","paymentcompetency","idaccmotive","idestimkind","yestim","nestim","estimrownum","idexp_iva","idexp_taxable","idinc_iva","idinc_taxable","idgroup","yinv_main","ninv_main","va3type","idintrastatcode","idintrastatmeasure","weight","intrastatoperationkind","idintrastatservice","idunit","idlist","idpackage","npackage","unitsforpackage","idintrastatsupplymethod","flag","exception12","intra12operationkind","move12","idupb_iva","idinvkind_main","leasing","usedmodesospesometro","resetresidualmandate","idfetransfer","fereferencerule","cupcode","cigcode","idcostpartition","idpccdebitstatus","idpccdebitmotive","expensekind","rounding","idepexp","idepacc","flagbit","iduniqueformcode","idfinmotive","ycon","ncon","codicetipo","codicevalore","idsor_siope","idepexp_pre");
	tinvoicedetail.defineColumn("!tipoiva", typeof(string));
	tinvoicedetail.defineColumn("!aliquota", typeof(double));
	tinvoicedetail.defineColumn("!percindetraibilita", typeof(double));
	tinvoicedetail.defineColumn("!totaleriga", typeof(decimal));
	tinvoicedetail.defineColumn("!imponibile", typeof(decimal));
	tinvoicedetail.defineColumn("!codesorsiope", typeof(string));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("idinvkind", "yinv", "ninv", "rownum");

	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new ivakindTable();
	tivakind.addBaseColumns("idivakind","description","rate","unabatabilitypercentage","cu","ct","lu","lt","active","idivataxablekind","idfenature");
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

	//////////////////// IVAREGISTER /////////////////////////////////
	var tivaregister= new ivaregisterTable();
	tivaregister.addBaseColumns("idivaregisterkind","yivaregister","nivaregister","idinvkind","yinv","ninv","protocolnum","cu","ct","lu","lt");
	tivaregister.defineColumn("!registerkind", typeof(string));
	Tables.Add(tivaregister);
	tivaregister.defineKey("idivaregisterkind", "yivaregister", "nivaregister");

	//////////////////// INVOICEKINDREGISTERKIND /////////////////////////////////
	var tinvoicekindregisterkind= new MetaTable("invoicekindregisterkind");
	tinvoicekindregisterkind.defineColumn("idinvkind", typeof(int),false);
	tinvoicekindregisterkind.defineColumn("idivaregisterkind", typeof(int),false);
	tinvoicekindregisterkind.defineColumn("cu", typeof(string),false);
	tinvoicekindregisterkind.defineColumn("ct", typeof(DateTime),false);
	tinvoicekindregisterkind.defineColumn("lu", typeof(string),false);
	tinvoicekindregisterkind.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tinvoicekindregisterkind);
	tinvoicekindregisterkind.defineKey("idinvkind", "idivaregisterkind");

	//////////////////// IVAREGISTERKIND /////////////////////////////////
	var tivaregisterkind= new ivaregisterkindTable();
	tivaregisterkind.addBaseColumns("idivaregisterkind","description","registerclass","cu","ct","lu","lt","flagactivity","codeivaregisterkind");
	Tables.Add(tivaregisterkind);
	tivaregisterkind.defineKey("idivaregisterkind");

	//////////////////// INVOICEDEFERRED /////////////////////////////////
	var tinvoicedeferred= new MetaTable("invoicedeferred");
	tinvoicedeferred.defineColumn("idinvkind", typeof(int),false);
	tinvoicedeferred.defineColumn("yinv", typeof(short),false);
	tinvoicedeferred.defineColumn("ninv", typeof(int),false);
	tinvoicedeferred.defineColumn("yivapay", typeof(int),false);
	tinvoicedeferred.defineColumn("nivapay", typeof(int),false);
	tinvoicedeferred.defineColumn("totalpayed", typeof(decimal));
	tinvoicedeferred.defineColumn("ivatotalpayed", typeof(decimal));
	tinvoicedeferred.defineColumn("cu", typeof(string),false);
	tinvoicedeferred.defineColumn("ct", typeof(DateTime),false);
	tinvoicedeferred.defineColumn("lu", typeof(string),false);
	tinvoicedeferred.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tinvoicedeferred);
	tinvoicedeferred.defineKey("idinvkind", "yinv", "ninv", "yivapay", "nivapay");

	//////////////////// SORTING /////////////////////////////////
	var tsorting= new sortingTable();
	tsorting.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	//////////////////// INVOICESORTING /////////////////////////////////
	var tinvoicesorting= new MetaTable("invoicesorting");
	tinvoicesorting.defineColumn("idsor", typeof(int),false);
	tinvoicesorting.defineColumn("idinvkind", typeof(int),false);
	tinvoicesorting.defineColumn("yinv", typeof(short),false);
	tinvoicesorting.defineColumn("ninv", typeof(int),false);
	tinvoicesorting.defineColumn("cu", typeof(string),false);
	tinvoicesorting.defineColumn("ct", typeof(DateTime),false);
	tinvoicesorting.defineColumn("lu", typeof(string),false);
	tinvoicesorting.defineColumn("lt", typeof(DateTime),false);
	tinvoicesorting.defineColumn("quota", typeof(double),false);
	tinvoicesorting.defineColumn("!codiceclass", typeof(string));
	tinvoicesorting.defineColumn("!descrizione", typeof(string));
	Tables.Add(tinvoicesorting);
	tinvoicesorting.defineKey("idinvkind", "idsor", "ninv", "yinv");

	//////////////////// ACCOUNTKIND /////////////////////////////////
	var taccountkind= new MetaTable("accountkind");
	taccountkind.defineColumn("idaccountkind", typeof(string),false);
	taccountkind.defineColumn("flagda", typeof(string));
	taccountkind.defineColumn("description", typeof(string),false);
	taccountkind.defineColumn("cu", typeof(string),false);
	taccountkind.defineColumn("ct", typeof(DateTime),false);
	taccountkind.defineColumn("lu", typeof(string),false);
	taccountkind.defineColumn("lt", typeof(DateTime),false);
	taccountkind.defineColumn("active", typeof(string));
	Tables.Add(taccountkind);
	taccountkind.defineKey("idaccountkind");

	//////////////////// INVOICEKINDYEAR /////////////////////////////////
	var tinvoicekindyear= new MetaTable("invoicekindyear");
	tinvoicekindyear.defineColumn("idinvkind", typeof(int),false);
	tinvoicekindyear.defineColumn("ayear", typeof(short),false);
	tinvoicekindyear.defineColumn("idacc", typeof(string));
	tinvoicekindyear.defineColumn("idacc_deferred", typeof(string));
	tinvoicekindyear.defineColumn("idacc_discount", typeof(string));
	tinvoicekindyear.defineColumn("idacc_unabatable", typeof(string));
	tinvoicekindyear.defineColumn("idacc_deferred_intra", typeof(string));
	tinvoicekindyear.defineColumn("idacc_unabatable_intra", typeof(string));
	tinvoicekindyear.defineColumn("idacc_intra", typeof(string));
	tinvoicekindyear.defineColumn("cu", typeof(string),false);
	tinvoicekindyear.defineColumn("ct", typeof(DateTime),false);
	tinvoicekindyear.defineColumn("lu", typeof(string),false);
	tinvoicekindyear.defineColumn("lt", typeof(DateTime),false);
	tinvoicekindyear.defineColumn("idacc_split", typeof(string));
	tinvoicekindyear.defineColumn("idacc_deferred_split", typeof(string));
	tinvoicekindyear.defineColumn("idacc_unabatable_split", typeof(string));
	Tables.Add(tinvoicekindyear);
	tinvoicekindyear.defineKey("idinvkind", "ayear");

	//////////////////// PROFSERVICE /////////////////////////////////
	var tprofservice= new profserviceTable();
	tprofservice.addBaseColumns("ycon","ncon","socialsecurityrate","pensioncontributionrate","ivarate","idreg","idser","feegross","totalcost","ct","cu","adate","stop","start","ndays","ivaamount","lt","lu","ivafieldnumber","txt","rtf","description","docdate","doc","flaginvoiced","idinvkind","idivakind","yinv","ninv","idaccmotive","idupb","idsor1","idsor2","idsor3","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","idsor01","idsor02","idsor03","idsor04","idsor05","idsor_siope","requested_doc");
	Tables.Add(tprofservice);
	tprofservice.defineKey("ycon", "ncon");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idivapayperiodicity","idregauto","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart","flag_autodocnumbering","flagivapaybyrow","idacc_unabatable","startivabalance","refundagency12","paymentagency12","idacc_invoicetoreceive","idacc_invoicetoemit","idpccdebitstatus","flagsplitpayment","femode","idaccmotive_forwarder","idivakind_forwarder","flag");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new treasurerTable();
	ttreasurer.addBaseColumns("idtreasurer","description","flagdefault","cin","idbank","idcab","cc","address","cap","city","country","phoneprefix","phonenumber","faxprefix","faxnumber","idsor01","idsor02","idsor03","idsor04","idsor05","cu","ct","lu","lt","bic","active");
	Tables.Add(ttreasurer);
	ttreasurer.defineKey("idtreasurer");

	//////////////////// INTRASTATNATION_PROVENANCE /////////////////////////////////
	var tintrastatnation_provenance= new MetaTable("intrastatnation_provenance");
	tintrastatnation_provenance.defineColumn("idintrastatnation", typeof(string),false);
	tintrastatnation_provenance.defineColumn("idcurrency", typeof(int));
	tintrastatnation_provenance.defineColumn("description", typeof(string));
	tintrastatnation_provenance.defineColumn("lt", typeof(DateTime));
	tintrastatnation_provenance.defineColumn("lu", typeof(string));
	Tables.Add(tintrastatnation_provenance);
	tintrastatnation_provenance.defineKey("idintrastatnation");

	//////////////////// INTRASTATNATION_ORIGIN /////////////////////////////////
	var tintrastatnation_origin= new MetaTable("intrastatnation_origin");
	tintrastatnation_origin.defineColumn("idintrastatnation", typeof(string),false);
	tintrastatnation_origin.defineColumn("idcurrency", typeof(int));
	tintrastatnation_origin.defineColumn("description", typeof(string));
	tintrastatnation_origin.defineColumn("lt", typeof(DateTime));
	tintrastatnation_origin.defineColumn("lu", typeof(string));
	Tables.Add(tintrastatnation_origin);
	tintrastatnation_origin.defineKey("idintrastatnation");

	//////////////////// INTRASTATNATION_DESTINATION /////////////////////////////////
	var tintrastatnation_destination= new MetaTable("intrastatnation_destination");
	tintrastatnation_destination.defineColumn("idintrastatnation", typeof(string),false);
	tintrastatnation_destination.defineColumn("idcurrency", typeof(int));
	tintrastatnation_destination.defineColumn("description", typeof(string));
	tintrastatnation_destination.defineColumn("lt", typeof(DateTime));
	tintrastatnation_destination.defineColumn("lu", typeof(string));
	Tables.Add(tintrastatnation_destination);
	tintrastatnation_destination.defineKey("idintrastatnation");

	//////////////////// INTRASTATKIND /////////////////////////////////
	var tintrastatkind= new MetaTable("intrastatkind");
	tintrastatkind.defineColumn("idintrastatkind", typeof(string),false);
	tintrastatkind.defineColumn("description", typeof(string),false);
	tintrastatkind.defineColumn("lt", typeof(DateTime));
	tintrastatkind.defineColumn("lu", typeof(string));
	Tables.Add(tintrastatkind);
	tintrastatkind.defineKey("idintrastatkind");

	//////////////////// GEO_COUNTRY_ORIGIN /////////////////////////////////
	var tgeo_country_origin= new MetaTable("geo_country_origin");
	tgeo_country_origin.defineColumn("idcountry", typeof(int),false);
	tgeo_country_origin.defineColumn("idregion", typeof(int));
	tgeo_country_origin.defineColumn("lt", typeof(DateTime));
	tgeo_country_origin.defineColumn("lu", typeof(string));
	tgeo_country_origin.defineColumn("newcountry", typeof(int));
	tgeo_country_origin.defineColumn("oldcountry", typeof(int));
	tgeo_country_origin.defineColumn("province", typeof(string));
	tgeo_country_origin.defineColumn("start", typeof(DateTime));
	tgeo_country_origin.defineColumn("stop", typeof(DateTime));
	tgeo_country_origin.defineColumn("title", typeof(string));
	Tables.Add(tgeo_country_origin);
	tgeo_country_origin.defineKey("idcountry");

	//////////////////// GEO_COUNTRY_DESTINATION /////////////////////////////////
	var tgeo_country_destination= new MetaTable("geo_country_destination");
	tgeo_country_destination.defineColumn("idcountry", typeof(int),false);
	tgeo_country_destination.defineColumn("idregion", typeof(int));
	tgeo_country_destination.defineColumn("lt", typeof(DateTime));
	tgeo_country_destination.defineColumn("lu", typeof(string));
	tgeo_country_destination.defineColumn("newcountry", typeof(int));
	tgeo_country_destination.defineColumn("oldcountry", typeof(int));
	tgeo_country_destination.defineColumn("province", typeof(string));
	tgeo_country_destination.defineColumn("start", typeof(DateTime));
	tgeo_country_destination.defineColumn("stop", typeof(DateTime));
	tgeo_country_destination.defineColumn("title", typeof(string));
	Tables.Add(tgeo_country_destination);
	tgeo_country_destination.defineKey("idcountry");

	//////////////////// ACCMOTIVEAPPLIED_DEBIT /////////////////////////////////
	var taccmotiveapplied_debit= new MetaTable("accmotiveapplied_debit");
	taccmotiveapplied_debit.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_debit.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_debit.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_debit.defineColumn("active", typeof(string));
	taccmotiveapplied_debit.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_debit.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_debit.defineColumn("in_use", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("flagdep", typeof(string));
	taccmotiveapplied_debit.defineColumn("flagamm", typeof(string));
	Tables.Add(taccmotiveapplied_debit);
	taccmotiveapplied_debit.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_CRG /////////////////////////////////
	var taccmotiveapplied_crg= new MetaTable("accmotiveapplied_crg");
	taccmotiveapplied_crg.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_crg.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_crg.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_crg.defineColumn("active", typeof(string));
	taccmotiveapplied_crg.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_crg.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_crg.defineColumn("in_use", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("flagdep", typeof(string));
	taccmotiveapplied_crg.defineColumn("flagamm", typeof(string));
	Tables.Add(taccmotiveapplied_crg);
	taccmotiveapplied_crg.defineKey("idaccmotive");

	//////////////////// INTRASTATPAYMETHOD /////////////////////////////////
	var tintrastatpaymethod= new MetaTable("intrastatpaymethod");
	tintrastatpaymethod.defineColumn("idintrastatpaymethod", typeof(int),false);
	tintrastatpaymethod.defineColumn("code", typeof(string),false);
	tintrastatpaymethod.defineColumn("description", typeof(string),false);
	tintrastatpaymethod.defineColumn("cu", typeof(string),false);
	tintrastatpaymethod.defineColumn("ct", typeof(DateTime),false);
	tintrastatpaymethod.defineColumn("lu", typeof(string),false);
	tintrastatpaymethod.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tintrastatpaymethod);
	tintrastatpaymethod.defineKey("idintrastatpaymethod");

	//////////////////// INTRASTATNATION_PAYMENT /////////////////////////////////
	var tintrastatnation_payment= new MetaTable("intrastatnation_payment");
	tintrastatnation_payment.defineColumn("idintrastatnation", typeof(string),false);
	tintrastatnation_payment.defineColumn("idcurrency", typeof(int));
	tintrastatnation_payment.defineColumn("description", typeof(string));
	tintrastatnation_payment.defineColumn("lt", typeof(DateTime));
	tintrastatnation_payment.defineColumn("lu", typeof(string));
	Tables.Add(tintrastatnation_payment);
	tintrastatnation_payment.defineKey("idintrastatnation");

	//////////////////// STOCKVIEW /////////////////////////////////
	var tstockview= new MetaTable("stockview");
	tstockview.defineColumn("idstock", typeof(int),false);
	tstockview.defineColumn("idstore", typeof(int),false);
	tstockview.defineColumn("store", typeof(string),false);
	tstockview.defineColumn("idlist", typeof(int),false);
	tstockview.defineColumn("number", typeof(decimal),false);
	tstockview.defineColumn("residual", typeof(decimal),true,true);
	tstockview.defineColumn("amount", typeof(decimal));
	tstockview.defineColumn("expiry", typeof(DateTime));
	tstockview.defineColumn("idmankind", typeof(string));
	tstockview.defineColumn("mandatekind", typeof(string));
	tstockview.defineColumn("yman", typeof(short));
	tstockview.defineColumn("nman", typeof(int));
	tstockview.defineColumn("man_idgroup", typeof(int));
	tstockview.defineColumn("idinvkind", typeof(int));
	tstockview.defineColumn("invoicekind", typeof(string));
	tstockview.defineColumn("yinv", typeof(short));
	tstockview.defineColumn("ninv", typeof(int));
	tstockview.defineColumn("inv_idgroup", typeof(int));
	tstockview.defineColumn("idddt_in", typeof(int));
	tstockview.defineColumn("idstoreload_motive", typeof(int));
	tstockview.defineColumn("storeload_motive", typeof(string));
	tstockview.defineColumn("list", typeof(string),false);
	tstockview.defineColumn("intcode", typeof(string),false);
	tstockview.defineColumn("yddt_in", typeof(short));
	tstockview.defineColumn("nddt_in", typeof(string));
	tstockview.defineColumn("authrequired", typeof(string));
	tstockview.defineColumn("flagto_unload", typeof(string));
	tstockview.defineColumn("adate", typeof(DateTime));
	tstockview.defineColumn("idstocklocation", typeof(int));
	tstockview.defineColumn("stocklocationcode", typeof(string));
	tstockview.defineColumn("stocklocation", typeof(string));
	Tables.Add(tstockview);
	tstockview.defineKey("idstock");

	//////////////////// STOCK /////////////////////////////////
	var tstock= new MetaTable("stock");
	tstock.defineColumn("idstock", typeof(int),false);
	tstock.defineColumn("idstore", typeof(int),false);
	tstock.defineColumn("idlist", typeof(int),false);
	tstock.defineColumn("number", typeof(decimal),false);
	tstock.defineColumn("amount", typeof(decimal));
	tstock.defineColumn("expiry", typeof(DateTime));
	tstock.defineColumn("idmankind", typeof(string));
	tstock.defineColumn("yman", typeof(short));
	tstock.defineColumn("nman", typeof(int));
	tstock.defineColumn("man_idgroup", typeof(int));
	tstock.defineColumn("idinvkind", typeof(int));
	tstock.defineColumn("yinv", typeof(short));
	tstock.defineColumn("ninv", typeof(int));
	tstock.defineColumn("inv_idgroup", typeof(int));
	tstock.defineColumn("idddt_in", typeof(int));
	tstock.defineColumn("idstoreload_motive", typeof(int));
	tstock.defineColumn("cu", typeof(string),false);
	tstock.defineColumn("ct", typeof(DateTime),false);
	tstock.defineColumn("lu", typeof(string),false);
	tstock.defineColumn("lt", typeof(DateTime),false);
	tstock.defineColumn("flagto_unload", typeof(string));
	tstock.defineColumn("adate", typeof(DateTime));
	tstock.defineColumn("idstocklocation", typeof(int));
	Tables.Add(tstock);
	tstock.defineKey("idstock");

	//////////////////// BLACKLIST /////////////////////////////////
	var tblacklist= new MetaTable("blacklist");
	tblacklist.defineColumn("idblacklist", typeof(int),false);
	tblacklist.defineColumn("idnation", typeof(int),false);
	tblacklist.defineColumn("description", typeof(string));
	tblacklist.defineColumn("blcode", typeof(string));
	tblacklist.defineColumn("start", typeof(DateTime),false);
	tblacklist.defineColumn("stop", typeof(DateTime));
	tblacklist.defineColumn("lt", typeof(DateTime));
	tblacklist.defineColumn("lu", typeof(string));
	Tables.Add(tblacklist);
	tblacklist.defineKey("idblacklist");

	//////////////////// INVOICEKIND_REAL /////////////////////////////////
	var tinvoicekind_real= new MetaTable("invoicekind_real");
	tinvoicekind_real.defineColumn("ct", typeof(DateTime),false);
	tinvoicekind_real.defineColumn("cu", typeof(string),false);
	tinvoicekind_real.defineColumn("description", typeof(string),false);
	tinvoicekind_real.defineColumn("lt", typeof(DateTime),false);
	tinvoicekind_real.defineColumn("lu", typeof(string),false);
	tinvoicekind_real.defineColumn("codeinvkind", typeof(string),false);
	tinvoicekind_real.defineColumn("idinvkind", typeof(int),false);
	tinvoicekind_real.defineColumn("flag", typeof(byte),false);
	tinvoicekind_real.defineColumn("flag_autodocnumbering", typeof(string));
	tinvoicekind_real.defineColumn("formatstring", typeof(string));
	tinvoicekind_real.defineColumn("active", typeof(string));
	tinvoicekind_real.defineColumn("idinvkind_auto", typeof(int));
	Tables.Add(tinvoicekind_real);
	tinvoicekind_real.defineKey("idinvkind");

	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new MetaTable("sorting01");
	tsorting01.defineColumn("ct", typeof(DateTime),false);
	tsorting01.defineColumn("cu", typeof(string),false);
	tsorting01.defineColumn("defaultN1", typeof(decimal));
	tsorting01.defineColumn("defaultN2", typeof(decimal));
	tsorting01.defineColumn("defaultN3", typeof(decimal));
	tsorting01.defineColumn("defaultN4", typeof(decimal));
	tsorting01.defineColumn("defaultN5", typeof(decimal));
	tsorting01.defineColumn("defaultS1", typeof(string));
	tsorting01.defineColumn("defaultS2", typeof(string));
	tsorting01.defineColumn("defaultS3", typeof(string));
	tsorting01.defineColumn("defaultS4", typeof(string));
	tsorting01.defineColumn("defaultS5", typeof(string));
	tsorting01.defineColumn("defaultv1", typeof(decimal));
	tsorting01.defineColumn("defaultv2", typeof(decimal));
	tsorting01.defineColumn("defaultv3", typeof(decimal));
	tsorting01.defineColumn("defaultv4", typeof(decimal));
	tsorting01.defineColumn("defaultv5", typeof(decimal));
	tsorting01.defineColumn("description", typeof(string),false);
	tsorting01.defineColumn("flagnodate", typeof(string));
	tsorting01.defineColumn("lt", typeof(DateTime),false);
	tsorting01.defineColumn("lu", typeof(string),false);
	tsorting01.defineColumn("movkind", typeof(string));
	tsorting01.defineColumn("printingorder", typeof(string));
	tsorting01.defineColumn("rtf", typeof(Byte[]));
	tsorting01.defineColumn("sortcode", typeof(string),false);
	tsorting01.defineColumn("txt", typeof(string));
	tsorting01.defineColumn("idsorkind", typeof(int),false);
	tsorting01.defineColumn("idsor", typeof(int),false);
	tsorting01.defineColumn("paridsor", typeof(int));
	tsorting01.defineColumn("nlevel", typeof(byte),false);
	tsorting01.defineColumn("start", typeof(short));
	tsorting01.defineColumn("stop", typeof(short));
	Tables.Add(tsorting01);
	tsorting01.defineKey("idsor");

	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new MetaTable("sorting02");
	tsorting02.defineColumn("ct", typeof(DateTime),false);
	tsorting02.defineColumn("cu", typeof(string),false);
	tsorting02.defineColumn("defaultN1", typeof(decimal));
	tsorting02.defineColumn("defaultN2", typeof(decimal));
	tsorting02.defineColumn("defaultN3", typeof(decimal));
	tsorting02.defineColumn("defaultN4", typeof(decimal));
	tsorting02.defineColumn("defaultN5", typeof(decimal));
	tsorting02.defineColumn("defaultS1", typeof(string));
	tsorting02.defineColumn("defaultS2", typeof(string));
	tsorting02.defineColumn("defaultS3", typeof(string));
	tsorting02.defineColumn("defaultS4", typeof(string));
	tsorting02.defineColumn("defaultS5", typeof(string));
	tsorting02.defineColumn("defaultv1", typeof(decimal));
	tsorting02.defineColumn("defaultv2", typeof(decimal));
	tsorting02.defineColumn("defaultv3", typeof(decimal));
	tsorting02.defineColumn("defaultv4", typeof(decimal));
	tsorting02.defineColumn("defaultv5", typeof(decimal));
	tsorting02.defineColumn("description", typeof(string),false);
	tsorting02.defineColumn("flagnodate", typeof(string));
	tsorting02.defineColumn("lt", typeof(DateTime),false);
	tsorting02.defineColumn("lu", typeof(string),false);
	tsorting02.defineColumn("movkind", typeof(string));
	tsorting02.defineColumn("printingorder", typeof(string));
	tsorting02.defineColumn("rtf", typeof(Byte[]));
	tsorting02.defineColumn("sortcode", typeof(string),false);
	tsorting02.defineColumn("txt", typeof(string));
	tsorting02.defineColumn("idsorkind", typeof(int),false);
	tsorting02.defineColumn("idsor", typeof(int),false);
	tsorting02.defineColumn("paridsor", typeof(int));
	tsorting02.defineColumn("nlevel", typeof(byte),false);
	tsorting02.defineColumn("start", typeof(short));
	tsorting02.defineColumn("stop", typeof(short));
	Tables.Add(tsorting02);
	tsorting02.defineKey("idsor");

	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new MetaTable("sorting03");
	tsorting03.defineColumn("ct", typeof(DateTime),false);
	tsorting03.defineColumn("cu", typeof(string),false);
	tsorting03.defineColumn("defaultN1", typeof(decimal));
	tsorting03.defineColumn("defaultN2", typeof(decimal));
	tsorting03.defineColumn("defaultN3", typeof(decimal));
	tsorting03.defineColumn("defaultN4", typeof(decimal));
	tsorting03.defineColumn("defaultN5", typeof(decimal));
	tsorting03.defineColumn("defaultS1", typeof(string));
	tsorting03.defineColumn("defaultS2", typeof(string));
	tsorting03.defineColumn("defaultS3", typeof(string));
	tsorting03.defineColumn("defaultS4", typeof(string));
	tsorting03.defineColumn("defaultS5", typeof(string));
	tsorting03.defineColumn("defaultv1", typeof(decimal));
	tsorting03.defineColumn("defaultv2", typeof(decimal));
	tsorting03.defineColumn("defaultv3", typeof(decimal));
	tsorting03.defineColumn("defaultv4", typeof(decimal));
	tsorting03.defineColumn("defaultv5", typeof(decimal));
	tsorting03.defineColumn("description", typeof(string),false);
	tsorting03.defineColumn("flagnodate", typeof(string));
	tsorting03.defineColumn("lt", typeof(DateTime),false);
	tsorting03.defineColumn("lu", typeof(string),false);
	tsorting03.defineColumn("movkind", typeof(string));
	tsorting03.defineColumn("printingorder", typeof(string));
	tsorting03.defineColumn("rtf", typeof(Byte[]));
	tsorting03.defineColumn("sortcode", typeof(string),false);
	tsorting03.defineColumn("txt", typeof(string));
	tsorting03.defineColumn("idsorkind", typeof(int),false);
	tsorting03.defineColumn("idsor", typeof(int),false);
	tsorting03.defineColumn("paridsor", typeof(int));
	tsorting03.defineColumn("nlevel", typeof(byte),false);
	tsorting03.defineColumn("start", typeof(short));
	tsorting03.defineColumn("stop", typeof(short));
	Tables.Add(tsorting03);
	tsorting03.defineKey("idsor");

	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new MetaTable("sorting04");
	tsorting04.defineColumn("ct", typeof(DateTime),false);
	tsorting04.defineColumn("cu", typeof(string),false);
	tsorting04.defineColumn("defaultN1", typeof(decimal));
	tsorting04.defineColumn("defaultN2", typeof(decimal));
	tsorting04.defineColumn("defaultN3", typeof(decimal));
	tsorting04.defineColumn("defaultN4", typeof(decimal));
	tsorting04.defineColumn("defaultN5", typeof(decimal));
	tsorting04.defineColumn("defaultS1", typeof(string));
	tsorting04.defineColumn("defaultS2", typeof(string));
	tsorting04.defineColumn("defaultS3", typeof(string));
	tsorting04.defineColumn("defaultS4", typeof(string));
	tsorting04.defineColumn("defaultS5", typeof(string));
	tsorting04.defineColumn("defaultv1", typeof(decimal));
	tsorting04.defineColumn("defaultv2", typeof(decimal));
	tsorting04.defineColumn("defaultv3", typeof(decimal));
	tsorting04.defineColumn("defaultv4", typeof(decimal));
	tsorting04.defineColumn("defaultv5", typeof(decimal));
	tsorting04.defineColumn("description", typeof(string),false);
	tsorting04.defineColumn("flagnodate", typeof(string));
	tsorting04.defineColumn("lt", typeof(DateTime),false);
	tsorting04.defineColumn("lu", typeof(string),false);
	tsorting04.defineColumn("movkind", typeof(string));
	tsorting04.defineColumn("printingorder", typeof(string));
	tsorting04.defineColumn("rtf", typeof(Byte[]));
	tsorting04.defineColumn("sortcode", typeof(string),false);
	tsorting04.defineColumn("txt", typeof(string));
	tsorting04.defineColumn("idsorkind", typeof(int),false);
	tsorting04.defineColumn("idsor", typeof(int),false);
	tsorting04.defineColumn("paridsor", typeof(int));
	tsorting04.defineColumn("nlevel", typeof(byte),false);
	tsorting04.defineColumn("start", typeof(short));
	tsorting04.defineColumn("stop", typeof(short));
	Tables.Add(tsorting04);
	tsorting04.defineKey("idsor");

	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new MetaTable("sorting05");
	tsorting05.defineColumn("ct", typeof(DateTime),false);
	tsorting05.defineColumn("cu", typeof(string),false);
	tsorting05.defineColumn("defaultN1", typeof(decimal));
	tsorting05.defineColumn("defaultN2", typeof(decimal));
	tsorting05.defineColumn("defaultN3", typeof(decimal));
	tsorting05.defineColumn("defaultN4", typeof(decimal));
	tsorting05.defineColumn("defaultN5", typeof(decimal));
	tsorting05.defineColumn("defaultS1", typeof(string));
	tsorting05.defineColumn("defaultS2", typeof(string));
	tsorting05.defineColumn("defaultS3", typeof(string));
	tsorting05.defineColumn("defaultS4", typeof(string));
	tsorting05.defineColumn("defaultS5", typeof(string));
	tsorting05.defineColumn("defaultv1", typeof(decimal));
	tsorting05.defineColumn("defaultv2", typeof(decimal));
	tsorting05.defineColumn("defaultv3", typeof(decimal));
	tsorting05.defineColumn("defaultv4", typeof(decimal));
	tsorting05.defineColumn("defaultv5", typeof(decimal));
	tsorting05.defineColumn("description", typeof(string),false);
	tsorting05.defineColumn("flagnodate", typeof(string));
	tsorting05.defineColumn("lt", typeof(DateTime),false);
	tsorting05.defineColumn("lu", typeof(string),false);
	tsorting05.defineColumn("movkind", typeof(string));
	tsorting05.defineColumn("printingorder", typeof(string));
	tsorting05.defineColumn("rtf", typeof(Byte[]));
	tsorting05.defineColumn("sortcode", typeof(string),false);
	tsorting05.defineColumn("txt", typeof(string));
	tsorting05.defineColumn("idsorkind", typeof(int),false);
	tsorting05.defineColumn("idsor", typeof(int),false);
	tsorting05.defineColumn("paridsor", typeof(int));
	tsorting05.defineColumn("nlevel", typeof(byte),false);
	tsorting05.defineColumn("start", typeof(short));
	tsorting05.defineColumn("stop", typeof(short));
	Tables.Add(tsorting05);
	tsorting05.defineKey("idsor");

	//////////////////// EXPENSESORTED /////////////////////////////////
	var texpensesorted= new expensesortedTable();
	texpensesorted.addBaseColumns("idsubclass","amount","ayear","ct","cu","description","flagnodate","lt","lu","paridsor","paridsubclass","rtf","start","stop","tobecontinued","txt","valuen1","valuen2","valuen3","valuen4","valuen5","values1","values2","values3","values4","values5","valuev1","valuev2","valuev3","valuev4","valuev5","idexp","idsor");
	Tables.Add(texpensesorted);
	texpensesorted.defineKey("idsubclass", "idexp", "idsor");

	//////////////////// EXPENSEVAR /////////////////////////////////
	var texpensevar= new expensevarTable();
	texpensevar.addBaseColumns("nvar","adate","amount","ct","cu","description","doc","docdate","lt","lu","rtf","transferkind","txt","yvar","ninv","yinv","idexp","idpayment","autokind","autocode","idinvkind","movkind","kpaymenttransmission","idunderwriting");
	Tables.Add(texpensevar);
	texpensevar.defineKey("nvar", "idexp");

	//////////////////// MANDATEDETAIL /////////////////////////////////
	var tmandatedetail= new mandatedetailTable();
	tmandatedetail.addBaseColumns("idmankind","nman","rownum","yman","annotations","assetkind","competencystart","competencystop","ct","cu","detaildescription","discount","idupb","lt","lu","ninvoiced","number","start","stop","tax","taxable","taxrate","toinvoice","flagmixed","idaccmotive","unabatable","idgroup","idreg","idexp_taxable","idexp_iva","idinv","idivakind","idsor1","idsor2","idsor3","idaccmotiveannulment","flagactivity","va3type","applierannotations","ivanotes","idlist","idunit","idpackage","unitsforpackage","npackage","cupcode","cigcode","flagto_unload","epkind","idcostpartition","idsor_siope");
	Tables.Add(tmandatedetail);
	tmandatedetail.defineKey("idmankind", "nman", "rownum", "yman");

	//////////////////// FEPAYMETHOD /////////////////////////////////
	var tfepaymethod= new MetaTable("fepaymethod");
	tfepaymethod.defineColumn("idfepaymethod", typeof(string),false);
	tfepaymethod.defineColumn("description", typeof(string),false);
	tfepaymethod.defineColumn("cu", typeof(string),false);
	tfepaymethod.defineColumn("ct", typeof(DateTime),false);
	tfepaymethod.defineColumn("lu", typeof(string),false);
	tfepaymethod.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tfepaymethod);
	tfepaymethod.defineKey("idfepaymethod");

	//////////////////// FEPAYMETHODCONDITION /////////////////////////////////
	var tfepaymethodcondition= new MetaTable("fepaymethodcondition");
	tfepaymethodcondition.defineColumn("idfepaymethodcondition", typeof(string),false);
	tfepaymethodcondition.defineColumn("description", typeof(string),false);
	tfepaymethodcondition.defineColumn("cu", typeof(string),false);
	tfepaymethodcondition.defineColumn("ct", typeof(DateTime),false);
	tfepaymethodcondition.defineColumn("lu", typeof(string),false);
	tfepaymethodcondition.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tfepaymethodcondition);
	tfepaymethodcondition.defineKey("idfepaymethodcondition");

	//////////////////// UNIQUEREGISTER /////////////////////////////////
	var tuniqueregister= new MetaTable("uniqueregister");
	tuniqueregister.defineColumn("iduniqueregister", typeof(int),false);
	tuniqueregister.defineColumn("yinv", typeof(short),false);
	tuniqueregister.defineColumn("ninv", typeof(int),false);
	tuniqueregister.defineColumn("idinvkind", typeof(int),false);
	tuniqueregister.defineColumn("ycon", typeof(int));
	tuniqueregister.defineColumn("ncon", typeof(int));
	tuniqueregister.defineColumn("yman", typeof(short));
	tuniqueregister.defineColumn("nman", typeof(int));
	tuniqueregister.defineColumn("idmankind", typeof(string));
	tuniqueregister.defineColumn("ct", typeof(DateTime),false);
	tuniqueregister.defineColumn("cu", typeof(string),false);
	tuniqueregister.defineColumn("lt", typeof(DateTime),false);
	tuniqueregister.defineColumn("lu", typeof(string),false);
	Tables.Add(tuniqueregister);
	tuniqueregister.defineKey("iduniqueregister", "yinv", "ninv", "idinvkind");

	//////////////////// PCCVIEW /////////////////////////////////
	var tpccview= new MetaTable("pccview");
	tpccview.defineColumn("opkind", typeof(string),false);
	tpccview.defineColumn("idpcc", typeof(int),false);
	tpccview.defineColumn("idinvkind", typeof(int));
	tpccview.defineColumn("invoicekind", typeof(string));
	tpccview.defineColumn("yinv", typeof(short));
	tpccview.defineColumn("ninv", typeof(int));
	tpccview.defineColumn("ycon", typeof(int));
	tpccview.defineColumn("ncon", typeof(int));
	tpccview.defineColumn("idmankind", typeof(string));
	tpccview.defineColumn("mandatekind", typeof(string));
	tpccview.defineColumn("yman", typeof(short));
	tpccview.defineColumn("nman", typeof(int));
	Tables.Add(tpccview);
	tpccview.defineKey("idpcc");

	//////////////////// INVOICEATTACHMENT /////////////////////////////////
	var tinvoiceattachment= new MetaTable("invoiceattachment");
	tinvoiceattachment.defineColumn("idinvkind", typeof(int),false);
	tinvoiceattachment.defineColumn("yinv", typeof(short),false);
	tinvoiceattachment.defineColumn("ninv", typeof(int),false);
	tinvoiceattachment.defineColumn("idattachment", typeof(int),false);
	tinvoiceattachment.defineColumn("attachment", typeof(Byte[]));
	tinvoiceattachment.defineColumn("filename", typeof(string));
	tinvoiceattachment.defineColumn("lt", typeof(DateTime));
	tinvoiceattachment.defineColumn("lu", typeof(string));
	tinvoiceattachment.defineColumn("ct", typeof(DateTime));
	tinvoiceattachment.defineColumn("cu", typeof(string));
	Tables.Add(tinvoiceattachment);
	tinvoiceattachment.defineKey("idinvkind", "yinv", "ninv", "idattachment");

	//////////////////// SDI_ACQUISTO /////////////////////////////////
	var tsdi_acquisto= new sdi_acquistoTable();
	tsdi_acquisto.addBaseColumns("idsdi_acquisto","filename","zipfilename","adate","xml","lt","lu","identificativo_sdi","mt","ec","ec_sent","se","dt","flag_unseen","idsdi_status","position","ec_number","title","description","ninvoice","riferimento_amministrazione","codice_ipa","protocoldate","arrivalprotocolnum","rejectreason","mt_prot","ec_prot","se_prot","dt_prot","utente_accettata","utente_rifiutata","data_accettata","data_rifiutata");
	Tables.Add(tsdi_acquisto);
	tsdi_acquisto.defineKey("idsdi_acquisto");

	//////////////////// SDI_STATUS /////////////////////////////////
	var tsdi_status= new MetaTable("sdi_status");
	tsdi_status.defineColumn("idsdi_status", typeof(short),false);
	tsdi_status.defineColumn("ct", typeof(DateTime),false);
	tsdi_status.defineColumn("cu", typeof(string),false);
	tsdi_status.defineColumn("description", typeof(string),false);
	tsdi_status.defineColumn("listingorder", typeof(int));
	tsdi_status.defineColumn("lt", typeof(DateTime),false);
	tsdi_status.defineColumn("lu", typeof(string),false);
	Tables.Add(tsdi_status);
	tsdi_status.defineKey("idsdi_status");

	//////////////////// SDI_VENDITA /////////////////////////////////
	var tsdi_vendita= new sdi_venditaTable();
	tsdi_vendita.addBaseColumns("idsdi_vendita","filename","adate","xml","lt","lu","identificativo_sdi","ns","mc","rc","ne","dt","at","flag_unseen","idsdi_status","idsdi_deliverystatus","position","exported","zipfilename","ns_prot","mc_prot","rc_prot","ne_prot","dt_prot","at_prot","arrivalprotocolnum");
	Tables.Add(tsdi_vendita);
	tsdi_vendita.defineKey("idsdi_vendita");

	//////////////////// SDI_STATUSVENDITA /////////////////////////////////
	var tsdi_statusvendita= new MetaTable("sdi_statusvendita");
	tsdi_statusvendita.defineColumn("idsdi_status", typeof(short),false);
	tsdi_statusvendita.defineColumn("ct", typeof(DateTime),false);
	tsdi_statusvendita.defineColumn("cu", typeof(string),false);
	tsdi_statusvendita.defineColumn("description", typeof(string),false);
	tsdi_statusvendita.defineColumn("listingorder", typeof(int));
	tsdi_statusvendita.defineColumn("lt", typeof(DateTime),false);
	tsdi_statusvendita.defineColumn("lu", typeof(string),false);
	Tables.Add(tsdi_statusvendita);
	tsdi_statusvendita.defineKey("idsdi_status");

	//////////////////// SDI_DELIVERYSTATUS /////////////////////////////////
	var tsdi_deliverystatus= new MetaTable("sdi_deliverystatus");
	tsdi_deliverystatus.defineColumn("idsdi_deliverystatus", typeof(short),false);
	tsdi_deliverystatus.defineColumn("ct", typeof(DateTime),false);
	tsdi_deliverystatus.defineColumn("cu", typeof(string),false);
	tsdi_deliverystatus.defineColumn("description", typeof(string),false);
	tsdi_deliverystatus.defineColumn("listingorder", typeof(int));
	tsdi_deliverystatus.defineColumn("lt", typeof(DateTime),false);
	tsdi_deliverystatus.defineColumn("lu", typeof(string),false);
	Tables.Add(tsdi_deliverystatus);
	tsdi_deliverystatus.defineKey("idsdi_deliverystatus");

	//////////////////// IPA_VEN_EMITTENTE /////////////////////////////////
	var tipa_ven_emittente= new MetaTable("ipa_ven_emittente");
	tipa_ven_emittente.defineColumn("ipa_fe", typeof(string),false);
	tipa_ven_emittente.defineColumn("agencyname", typeof(string),false);
	tipa_ven_emittente.defineColumn("officename", typeof(string),false);
	tipa_ven_emittente.defineColumn("idsor01", typeof(int));
	tipa_ven_emittente.defineColumn("idsor02", typeof(int));
	tipa_ven_emittente.defineColumn("idsor03", typeof(int));
	tipa_ven_emittente.defineColumn("idsor04", typeof(int));
	tipa_ven_emittente.defineColumn("idsor05", typeof(int));
	tipa_ven_emittente.defineColumn("cu", typeof(string));
	tipa_ven_emittente.defineColumn("lu", typeof(string));
	tipa_ven_emittente.defineColumn("ct", typeof(DateTime));
	tipa_ven_emittente.defineColumn("lt", typeof(DateTime));
	tipa_ven_emittente.defineColumn("codiceufficio", typeof(string));
	tipa_ven_emittente.defineColumn("voceindice", typeof(string));
	tipa_ven_emittente.defineColumn("diritto", typeof(string));
	tipa_ven_emittente.defineColumn("nomeufficio", typeof(string));
	tipa_ven_emittente.defineColumn("nomepersona", typeof(string));
	Tables.Add(tipa_ven_emittente);
	tipa_ven_emittente.defineKey("ipa_fe");

	//////////////////// RIFAMM_VEN_EMITTENTE /////////////////////////////////
	var trifamm_ven_emittente= new MetaTable("rifamm_ven_emittente");
	trifamm_ven_emittente.defineColumn("idsdi_rifamm", typeof(string),false);
	trifamm_ven_emittente.defineColumn("codiceufficio", typeof(string));
	trifamm_ven_emittente.defineColumn("voceindice", typeof(string));
	trifamm_ven_emittente.defineColumn("diritto", typeof(string));
	trifamm_ven_emittente.defineColumn("nomeufficio", typeof(string));
	trifamm_ven_emittente.defineColumn("nomepersona", typeof(string));
	trifamm_ven_emittente.defineColumn("idsor01", typeof(int));
	trifamm_ven_emittente.defineColumn("idsor02", typeof(int));
	trifamm_ven_emittente.defineColumn("idsor03", typeof(int));
	trifamm_ven_emittente.defineColumn("idsor04", typeof(int));
	trifamm_ven_emittente.defineColumn("idsor05", typeof(int));
	trifamm_ven_emittente.defineColumn("nomeufficioricevente", typeof(string));
	Tables.Add(trifamm_ven_emittente);
	trifamm_ven_emittente.defineKey("idsdi_rifamm");

	//////////////////// INVOICE_BOLLADOGANALE /////////////////////////////////
	var tinvoice_bolladoganale= new MetaTable("invoice_bolladoganale");
	tinvoice_bolladoganale.defineColumn("ninv", typeof(int),false);
	tinvoice_bolladoganale.defineColumn("yinv", typeof(short),false);
	tinvoice_bolladoganale.defineColumn("active", typeof(string));
	tinvoice_bolladoganale.defineColumn("adate", typeof(DateTime),false);
	tinvoice_bolladoganale.defineColumn("ct", typeof(DateTime),false);
	tinvoice_bolladoganale.defineColumn("cu", typeof(string),false);
	tinvoice_bolladoganale.defineColumn("description", typeof(string),false);
	tinvoice_bolladoganale.defineColumn("doc", typeof(string));
	tinvoice_bolladoganale.defineColumn("docdate", typeof(DateTime));
	tinvoice_bolladoganale.defineColumn("exchangerate", typeof(double));
	tinvoice_bolladoganale.defineColumn("flagdeferred", typeof(string));
	tinvoice_bolladoganale.defineColumn("idreg", typeof(int),false);
	tinvoice_bolladoganale.defineColumn("lt", typeof(DateTime),false);
	tinvoice_bolladoganale.defineColumn("lu", typeof(string),false);
	tinvoice_bolladoganale.defineColumn("officiallyprinted", typeof(string),false);
	tinvoice_bolladoganale.defineColumn("packinglistdate", typeof(DateTime));
	tinvoice_bolladoganale.defineColumn("packinglistnum", typeof(string));
	tinvoice_bolladoganale.defineColumn("paymentexpiring", typeof(short));
	tinvoice_bolladoganale.defineColumn("registryreference", typeof(string));
	tinvoice_bolladoganale.defineColumn("rtf", typeof(Byte[]));
	tinvoice_bolladoganale.defineColumn("txt", typeof(string));
	tinvoice_bolladoganale.defineColumn("idinvkind", typeof(int),false);
	tinvoice_bolladoganale.defineColumn("idcurrency", typeof(int));
	tinvoice_bolladoganale.defineColumn("idexpirationkind", typeof(short));
	tinvoice_bolladoganale.defineColumn("idtreasurer", typeof(int));
	tinvoice_bolladoganale.defineColumn("flagintracom", typeof(string));
	tinvoice_bolladoganale.defineColumn("iso_origin", typeof(string));
	tinvoice_bolladoganale.defineColumn("iso_provenance", typeof(string));
	tinvoice_bolladoganale.defineColumn("iso_destination", typeof(string));
	tinvoice_bolladoganale.defineColumn("idcountry_origin", typeof(int));
	tinvoice_bolladoganale.defineColumn("idcountry_destination", typeof(int));
	tinvoice_bolladoganale.defineColumn("idintrastatkind", typeof(string));
	tinvoice_bolladoganale.defineColumn("idaccmotivedebit", typeof(string));
	tinvoice_bolladoganale.defineColumn("idaccmotivedebit_crg", typeof(string));
	tinvoice_bolladoganale.defineColumn("idaccmotivedebit_datacrg", typeof(DateTime));
	tinvoice_bolladoganale.defineColumn("idintrastatpaymethod", typeof(int));
	tinvoice_bolladoganale.defineColumn("iso_payment", typeof(string));
	tinvoice_bolladoganale.defineColumn("flag_ddt", typeof(string));
	tinvoice_bolladoganale.defineColumn("flag", typeof(int));
	tinvoice_bolladoganale.defineColumn("idblacklist", typeof(int));
	tinvoice_bolladoganale.defineColumn("idinvkind_real", typeof(int));
	tinvoice_bolladoganale.defineColumn("yinv_real", typeof(short));
	tinvoice_bolladoganale.defineColumn("ninv_real", typeof(int));
	tinvoice_bolladoganale.defineColumn("autoinvoice", typeof(string));
	tinvoice_bolladoganale.defineColumn("idsor01", typeof(int));
	tinvoice_bolladoganale.defineColumn("idsor02", typeof(int));
	tinvoice_bolladoganale.defineColumn("idsor03", typeof(int));
	tinvoice_bolladoganale.defineColumn("idsor04", typeof(int));
	tinvoice_bolladoganale.defineColumn("idsor05", typeof(int));
	tinvoice_bolladoganale.defineColumn("protocoldate", typeof(DateTime));
	tinvoice_bolladoganale.defineColumn("idfepaymethodcondition", typeof(string));
	tinvoice_bolladoganale.defineColumn("idfepaymethod", typeof(string));
	tinvoice_bolladoganale.defineColumn("nelectronicinvoice", typeof(int));
	tinvoice_bolladoganale.defineColumn("yelectronicinvoice", typeof(short));
	tinvoice_bolladoganale.defineColumn("annotations", typeof(string));
	tinvoice_bolladoganale.defineColumn("arrivalprotocolnum", typeof(string));
	tinvoice_bolladoganale.defineColumn("toincludeinpaymentindicator", typeof(string));
	tinvoice_bolladoganale.defineColumn("resendingpcc", typeof(string));
	tinvoice_bolladoganale.defineColumn("touniqueregister", typeof(string));
	tinvoice_bolladoganale.defineColumn("idstampkind", typeof(string));
	tinvoice_bolladoganale.defineColumn("flag_auto_split_payment", typeof(string));
	tinvoice_bolladoganale.defineColumn("flag_enable_split_payment", typeof(string));
	tinvoice_bolladoganale.defineColumn("idsdi_acquisto", typeof(int));
	tinvoice_bolladoganale.defineColumn("idsdi_vendita", typeof(int));
	tinvoice_bolladoganale.defineColumn("flag_reverse_charge", typeof(string));
	tinvoice_bolladoganale.defineColumn("ipa_acq", typeof(string));
	tinvoice_bolladoganale.defineColumn("rifamm_acq", typeof(string));
	tinvoice_bolladoganale.defineColumn("ipa_ven_emittente", typeof(string));
	tinvoice_bolladoganale.defineColumn("rifamm_ven_emittente", typeof(string));
	tinvoice_bolladoganale.defineColumn("ipa_ven_cliente", typeof(string));
	tinvoice_bolladoganale.defineColumn("rifamm_ven_cliente", typeof(string));
	tinvoice_bolladoganale.defineColumn("ssntipospesa", typeof(string));
	tinvoice_bolladoganale.defineColumn("ssnflagtipospesa", typeof(string));
	tinvoice_bolladoganale.defineColumn("idinvkind_forwarder", typeof(int));
	tinvoice_bolladoganale.defineColumn("yinv_forwarder", typeof(short));
	tinvoice_bolladoganale.defineColumn("ninv_forwarder", typeof(int));
	tinvoice_bolladoganale.defineColumn("!invkind", typeof(string));
	tinvoice_bolladoganale.defineColumn("flagbit", typeof(int));
	Tables.Add(tinvoice_bolladoganale);
	tinvoice_bolladoganale.defineKey("ninv", "yinv", "idinvkind");

	//////////////////// INVOICEKIND_FORWARDER /////////////////////////////////
	var tinvoicekind_forwarder= new MetaTable("invoicekind_forwarder");
	tinvoicekind_forwarder.defineColumn("ct", typeof(DateTime),false);
	tinvoicekind_forwarder.defineColumn("cu", typeof(string),false);
	tinvoicekind_forwarder.defineColumn("description", typeof(string),false);
	tinvoicekind_forwarder.defineColumn("lt", typeof(DateTime),false);
	tinvoicekind_forwarder.defineColumn("lu", typeof(string),false);
	tinvoicekind_forwarder.defineColumn("codeinvkind", typeof(string),false);
	tinvoicekind_forwarder.defineColumn("idinvkind", typeof(int),false);
	tinvoicekind_forwarder.defineColumn("flag", typeof(byte),false);
	tinvoicekind_forwarder.defineColumn("flag_autodocnumbering", typeof(string));
	tinvoicekind_forwarder.defineColumn("formatstring", typeof(string));
	tinvoicekind_forwarder.defineColumn("active", typeof(string));
	tinvoicekind_forwarder.defineColumn("idinvkind_auto", typeof(int));
	tinvoicekind_forwarder.defineColumn("printingcode", typeof(string));
	tinvoicekind_forwarder.defineColumn("idsor01", typeof(int));
	tinvoicekind_forwarder.defineColumn("idsor02", typeof(int));
	tinvoicekind_forwarder.defineColumn("idsor03", typeof(int));
	tinvoicekind_forwarder.defineColumn("idsor04", typeof(int));
	tinvoicekind_forwarder.defineColumn("idsor05", typeof(int));
	tinvoicekind_forwarder.defineColumn("address", typeof(string));
	tinvoicekind_forwarder.defineColumn("header", typeof(string));
	tinvoicekind_forwarder.defineColumn("notes1", typeof(string));
	tinvoicekind_forwarder.defineColumn("notes2", typeof(string));
	tinvoicekind_forwarder.defineColumn("notes3", typeof(string));
	tinvoicekind_forwarder.defineColumn("ipa_fe", typeof(string));
	tinvoicekind_forwarder.defineColumn("riferimento_amministrazione", typeof(string));
	tinvoicekind_forwarder.defineColumn("enable_fe", typeof(string));
	Tables.Add(tinvoicekind_forwarder);
	tinvoicekind_forwarder.defineKey("idinvkind");

	//////////////////// INVOICEKIND_BOLLADOGANALE /////////////////////////////////
	var tinvoicekind_bolladoganale= new MetaTable("invoicekind_bolladoganale");
	tinvoicekind_bolladoganale.defineColumn("ct", typeof(DateTime),false);
	tinvoicekind_bolladoganale.defineColumn("cu", typeof(string),false);
	tinvoicekind_bolladoganale.defineColumn("description", typeof(string),false);
	tinvoicekind_bolladoganale.defineColumn("lt", typeof(DateTime),false);
	tinvoicekind_bolladoganale.defineColumn("lu", typeof(string),false);
	tinvoicekind_bolladoganale.defineColumn("codeinvkind", typeof(string),false);
	tinvoicekind_bolladoganale.defineColumn("idinvkind", typeof(int),false);
	tinvoicekind_bolladoganale.defineColumn("flag", typeof(byte),false);
	tinvoicekind_bolladoganale.defineColumn("flag_autodocnumbering", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("formatstring", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("active", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("idinvkind_auto", typeof(int));
	tinvoicekind_bolladoganale.defineColumn("printingcode", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("idsor01", typeof(int));
	tinvoicekind_bolladoganale.defineColumn("idsor02", typeof(int));
	tinvoicekind_bolladoganale.defineColumn("idsor03", typeof(int));
	tinvoicekind_bolladoganale.defineColumn("idsor04", typeof(int));
	tinvoicekind_bolladoganale.defineColumn("idsor05", typeof(int));
	tinvoicekind_bolladoganale.defineColumn("address", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("header", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("notes1", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("notes2", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("notes3", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("ipa_fe", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("riferimento_amministrazione", typeof(string));
	tinvoicekind_bolladoganale.defineColumn("enable_fe", typeof(string));
	Tables.Add(tinvoicekind_bolladoganale);
	tinvoicekind_bolladoganale.defineKey("idinvkind");

	//////////////////// ASSETACQUIRE /////////////////////////////////
	var tassetacquire= new assetacquireTable();
	tassetacquire.addBaseColumns("nassetacquire","abatable","adate","ct","cu","description","discount","idmankind","idreg","lt","lu","nman","number","rownum","rtf","startnumber","tax","taxable","taxrate","txt","yman","transmitted","idupb","idinventory","idmot","idinv","idassetload","flag","idsor1","idsor2","idsor3","historicalvalue","idlist","yinv","ninv","idinvkind","invrownum");
	Tables.Add(tassetacquire);
	tassetacquire.defineKey("nassetacquire");

	//////////////////// PROFSERVICE_1 /////////////////////////////////
	var tprofservice_1= new MetaTable("profservice_1");
	tprofservice_1.defineColumn("ycon", typeof(int),false);
	tprofservice_1.defineColumn("ncon", typeof(int),false);
	tprofservice_1.defineColumn("socialsecurityrate", typeof(decimal));
	tprofservice_1.defineColumn("pensioncontributionrate", typeof(decimal));
	tprofservice_1.defineColumn("ivarate", typeof(decimal));
	tprofservice_1.defineColumn("idreg", typeof(int),false);
	tprofservice_1.defineColumn("idser", typeof(int),false);
	tprofservice_1.defineColumn("feegross", typeof(decimal),false);
	tprofservice_1.defineColumn("totalcost", typeof(decimal));
	tprofservice_1.defineColumn("ct", typeof(DateTime),false);
	tprofservice_1.defineColumn("cu", typeof(string),false);
	tprofservice_1.defineColumn("adate", typeof(DateTime),false);
	tprofservice_1.defineColumn("stop", typeof(DateTime),false);
	tprofservice_1.defineColumn("start", typeof(DateTime),false);
	tprofservice_1.defineColumn("ndays", typeof(int),false);
	tprofservice_1.defineColumn("ivaamount", typeof(decimal));
	tprofservice_1.defineColumn("lt", typeof(DateTime),false);
	tprofservice_1.defineColumn("lu", typeof(string),false);
	tprofservice_1.defineColumn("ivafieldnumber", typeof(int));
	tprofservice_1.defineColumn("txt", typeof(string));
	tprofservice_1.defineColumn("rtf", typeof(Byte[]));
	tprofservice_1.defineColumn("description", typeof(string));
	tprofservice_1.defineColumn("docdate", typeof(DateTime));
	tprofservice_1.defineColumn("doc", typeof(string));
	tprofservice_1.defineColumn("flaginvoiced", typeof(string));
	tprofservice_1.defineColumn("idinvkind", typeof(int));
	tprofservice_1.defineColumn("idivakind", typeof(int));
	tprofservice_1.defineColumn("yinv", typeof(short));
	tprofservice_1.defineColumn("ninv", typeof(int));
	tprofservice_1.defineColumn("idaccmotive", typeof(string));
	tprofservice_1.defineColumn("idupb", typeof(string));
	tprofservice_1.defineColumn("idsor1", typeof(int));
	tprofservice_1.defineColumn("idsor2", typeof(int));
	tprofservice_1.defineColumn("idsor3", typeof(int));
	tprofservice_1.defineColumn("idaccmotivedebit", typeof(string));
	tprofservice_1.defineColumn("idaccmotivedebit_crg", typeof(string));
	tprofservice_1.defineColumn("idaccmotivedebit_datacrg", typeof(DateTime));
	tprofservice_1.defineColumn("idsor01", typeof(int));
	tprofservice_1.defineColumn("idsor02", typeof(int));
	tprofservice_1.defineColumn("idsor03", typeof(int));
	tprofservice_1.defineColumn("idsor04", typeof(int));
	tprofservice_1.defineColumn("idsor05", typeof(int));
	tprofservice_1.defineColumn("idsor_siope", typeof(int));
	Tables.Add(tprofservice_1);
	tprofservice_1.defineKey("ycon", "ncon");

	//////////////////// SORTING_SIOPE /////////////////////////////////
	var tsorting_siope= new MetaTable("sorting_siope");
	tsorting_siope.defineColumn("ct", typeof(DateTime),false);
	tsorting_siope.defineColumn("cu", typeof(string),false);
	tsorting_siope.defineColumn("defaultN1", typeof(decimal));
	tsorting_siope.defineColumn("defaultN2", typeof(decimal));
	tsorting_siope.defineColumn("defaultN3", typeof(decimal));
	tsorting_siope.defineColumn("defaultN4", typeof(decimal));
	tsorting_siope.defineColumn("defaultN5", typeof(decimal));
	tsorting_siope.defineColumn("defaultS1", typeof(string));
	tsorting_siope.defineColumn("defaultS2", typeof(string));
	tsorting_siope.defineColumn("defaultS3", typeof(string));
	tsorting_siope.defineColumn("defaultS4", typeof(string));
	tsorting_siope.defineColumn("defaultS5", typeof(string));
	tsorting_siope.defineColumn("defaultv1", typeof(decimal));
	tsorting_siope.defineColumn("defaultv2", typeof(decimal));
	tsorting_siope.defineColumn("defaultv3", typeof(decimal));
	tsorting_siope.defineColumn("defaultv4", typeof(decimal));
	tsorting_siope.defineColumn("defaultv5", typeof(decimal));
	tsorting_siope.defineColumn("description", typeof(string),false);
	tsorting_siope.defineColumn("flagnodate", typeof(string));
	tsorting_siope.defineColumn("lt", typeof(DateTime),false);
	tsorting_siope.defineColumn("lu", typeof(string),false);
	tsorting_siope.defineColumn("movkind", typeof(string));
	tsorting_siope.defineColumn("printingorder", typeof(string));
	tsorting_siope.defineColumn("rtf", typeof(Byte[]));
	tsorting_siope.defineColumn("sortcode", typeof(string),false);
	tsorting_siope.defineColumn("txt", typeof(string));
	tsorting_siope.defineColumn("idsorkind", typeof(int),false);
	tsorting_siope.defineColumn("idsor", typeof(int),false);
	tsorting_siope.defineColumn("paridsor", typeof(int));
	tsorting_siope.defineColumn("nlevel", typeof(byte),false);
	tsorting_siope.defineColumn("start", typeof(short));
	tsorting_siope.defineColumn("stop", typeof(short));
	tsorting_siope.defineColumn("email", typeof(string));
	Tables.Add(tsorting_siope);
	tsorting_siope.defineKey("idsor");

	//////////////////// NOCIGMOTIVE /////////////////////////////////
	var tnocigmotive= new MetaTable("nocigmotive");
	tnocigmotive.defineColumn("idnocigmotive", typeof(int),false);
	tnocigmotive.defineColumn("codenocigmotive", typeof(string),false);
	tnocigmotive.defineColumn("title", typeof(string),false);
	tnocigmotive.defineColumn("active", typeof(string));
	tnocigmotive.defineColumn("cu", typeof(string),false);
	tnocigmotive.defineColumn("ct", typeof(DateTime),false);
	tnocigmotive.defineColumn("lu", typeof(string),false);
	tnocigmotive.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tnocigmotive);
	tnocigmotive.defineKey("idnocigmotive");

	//////////////////// REGISTRY_SOSTITUTO /////////////////////////////////
	var tregistry_sostituto= new MetaTable("registry_sostituto");
	tregistry_sostituto.defineColumn("idreg", typeof(int),false);
	tregistry_sostituto.defineColumn("title", typeof(string),false);
	tregistry_sostituto.defineColumn("cf", typeof(string));
	tregistry_sostituto.defineColumn("p_iva", typeof(string));
	tregistry_sostituto.defineColumn("residence", typeof(int),false);
	tregistry_sostituto.defineColumn("annotation", typeof(string));
	tregistry_sostituto.defineColumn("birthdate", typeof(DateTime));
	tregistry_sostituto.defineColumn("gender", typeof(string));
	tregistry_sostituto.defineColumn("surname", typeof(string));
	tregistry_sostituto.defineColumn("forename", typeof(string));
	tregistry_sostituto.defineColumn("foreigncf", typeof(string));
	tregistry_sostituto.defineColumn("active", typeof(string),false);
	tregistry_sostituto.defineColumn("txt", typeof(string));
	tregistry_sostituto.defineColumn("rtf", typeof(Byte[]));
	tregistry_sostituto.defineColumn("cu", typeof(string),false);
	tregistry_sostituto.defineColumn("ct", typeof(DateTime),false);
	tregistry_sostituto.defineColumn("lu", typeof(string),false);
	tregistry_sostituto.defineColumn("lt", typeof(DateTime),false);
	tregistry_sostituto.defineColumn("badgecode", typeof(string));
	tregistry_sostituto.defineColumn("idcategory", typeof(string));
	tregistry_sostituto.defineColumn("idcentralizedcategory", typeof(string));
	tregistry_sostituto.defineColumn("idmaritalstatus", typeof(string));
	tregistry_sostituto.defineColumn("idtitle", typeof(string));
	tregistry_sostituto.defineColumn("idregistryclass", typeof(string));
	tregistry_sostituto.defineColumn("maritalsurname", typeof(string));
	tregistry_sostituto.defineColumn("idcity", typeof(int));
	tregistry_sostituto.defineColumn("idnation", typeof(int));
	tregistry_sostituto.defineColumn("location", typeof(string));
	tregistry_sostituto.defineColumn("extmatricula", typeof(string));
	tregistry_sostituto.defineColumn("ipa_fe", typeof(string));
	tregistry_sostituto.defineColumn("flag_pa", typeof(string));
	tregistry_sostituto.defineColumn("pec_fe", typeof(string));
	tregistry_sostituto.defineColumn("email_fe", typeof(string));
	Tables.Add(tregistry_sostituto);
	tregistry_sostituto.defineKey("idreg");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_nocigmotive_invoice","nocigmotive","invoice","idnocigmotive");
	var cPar = new []{invoicedetail.Columns["idinvkind"], invoicedetail.Columns["yinv"], invoicedetail.Columns["ninv"], invoicedetail.Columns["idgroup"]};
	var cChild = new []{assetacquire.Columns["idinvkind"], assetacquire.Columns["yinv"], assetacquire.Columns["ninv"], assetacquire.Columns["invrownum"]};
	Relations.Add(new DataRelation("FK_invoicedetail_assetacquire",cPar,cChild,false));

	cPar = new []{invoice.Columns["idinvkind"], invoice.Columns["yinv"], invoice.Columns["ninv"]};
	cChild = new []{invoice_bolladoganale.Columns["idinvkind_forwarder"], invoice_bolladoganale.Columns["yinv_forwarder"], invoice_bolladoganale.Columns["ninv_forwarder"]};
	Relations.Add(new DataRelation("FK_invoice_invoice_forwarder",cPar,cChild,false));

	this.defineRelation("FK_invoicekind_bolladoganale_invoice_bolladoganale","invoicekind_bolladoganale","invoice_bolladoganale","idinvkind");
	this.defineRelation("FK_sdi_statusvendita_sdi_vendita","sdi_statusvendita","sdi_vendita","idsdi_status");
	this.defineRelation("FK_sdi_deliverystatus_sdi_vendita","sdi_deliverystatus","sdi_vendita","idsdi_deliverystatus");
	this.defineRelation("FK_sdi_status_sdi_acquisto","sdi_status","sdi_acquisto","idsdi_status");
	this.defineRelation("invoice_invoiceattachment","invoice","invoiceattachment","idinvkind","yinv","ninv");
	this.defineRelation("FK_invoice_pccview","invoice","pccview","idinvkind","yinv","ninv");
	this.defineRelation("FK_invoice_uniqueregister","invoice","uniqueregister","idinvkind","yinv","ninv");
	cPar = new []{invoicedetail.Columns["idinvkind"], invoicedetail.Columns["yinv"], invoicedetail.Columns["ninv"], invoicedetail.Columns["idgroup"]};
	cChild = new []{stock.Columns["idinvkind"], stock.Columns["yinv"], stock.Columns["ninv"], stock.Columns["inv_idgroup"]};
	Relations.Add(new DataRelation("invoicedetail_stock",cPar,cChild,false));

	this.defineRelation("invoice_stockview","invoice","stockview","idinvkind","yinv","ninv");
	this.defineRelation("invoiceprofservice","invoice","profservice","idinvkind","yinv","ninv");
	this.defineRelation("invoiceinvoicesorting","invoice","invoicesorting","idinvkind","yinv","ninv");
	this.defineRelation("sortinginvoicesorting","sorting","invoicesorting","idsor");
	this.defineRelation("invoiceinvoicedeferred","invoice","invoicedeferred","idinvkind","yinv","ninv");
	this.defineRelation("invoicekindinvoicedeferred","invoicekind","invoicedeferred","idinvkind");
	this.defineRelation("invoiceivaregister","invoice","ivaregister","idinvkind","yinv","ninv");
	this.defineRelation("ivaregisterkindivaregister","ivaregisterkind","ivaregister","idivaregisterkind");
	this.defineRelation("ivakindinvoicedetail","ivakind","invoicedetail","idivakind");
	this.defineRelation("invoiceinvoicedetail","invoice","invoicedetail","idinvkind","yinv","ninv");
	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{invoice.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_invoice",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{invoice.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_invoice",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{invoice.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_invoice",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{invoice.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_invoice",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{invoice.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_invoice",cPar,cChild,false));

	this.defineRelation("blacklist_invoice","blacklist","invoice","idblacklist");
	cPar = new []{accmotiveapplied_crg.Columns["idaccmotive"]};
	cChild = new []{invoice.Columns["idaccmotivedebit_crg"]};
	Relations.Add(new DataRelation("accmotiveapplied_crg_invoice",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{invoice.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("accmotiveapplied_debit_invoice",cPar,cChild,false));

	cPar = new []{geo_country_destination.Columns["idcountry"]};
	cChild = new []{invoice.Columns["idcountry_destination"]};
	Relations.Add(new DataRelation("geo_country_destination_invoice",cPar,cChild,false));

	cPar = new []{geo_country_origin.Columns["idcountry"]};
	cChild = new []{invoice.Columns["idcountry_origin"]};
	Relations.Add(new DataRelation("geo_country_origin_invoice",cPar,cChild,false));

	this.defineRelation("intrastatkind_invoice","intrastatkind","invoice","idintrastatkind");
	cPar = new []{intrastatnation_destination.Columns["idintrastatnation"]};
	cChild = new []{invoice.Columns["iso_destination"]};
	Relations.Add(new DataRelation("intrastatnation_destination_invoice",cPar,cChild,false));

	cPar = new []{intrastatnation_provenance.Columns["idintrastatnation"]};
	cChild = new []{invoice.Columns["iso_provenance"]};
	Relations.Add(new DataRelation("intrastatnation_provenance_invoice",cPar,cChild,false));

	cPar = new []{intrastatnation_origin.Columns["idintrastatnation"]};
	cChild = new []{invoice.Columns["iso_origin"]};
	Relations.Add(new DataRelation("intrastatnation_origin_invoice",cPar,cChild,false));

	this.defineRelation("expirationkindinvoice","expirationkind","invoice","idexpirationkind");
	this.defineRelation("currencyinvoice","currency","invoice","idcurrency");
	this.defineRelation("registryinvoice","registry","invoice","idreg");
	this.defineRelation("invoicekindinvoice","invoicekind","invoice","idinvkind");
	this.defineRelation("treasurerinvoice","treasurer","invoice","idtreasurer");
	this.defineRelation("FK_intrastatpaymethod_invoice","intrastatpaymethod","invoice","idintrastatpaymethod");
	cPar = new []{intrastatnation_payment.Columns["idintrastatnation"]};
	cChild = new []{invoice.Columns["iso_payment"]};
	Relations.Add(new DataRelation("FK_intrastatnation_payment_invoice",cPar,cChild,false));

	cPar = new []{invoicekind_real.Columns["idinvkind"]};
	cChild = new []{invoice.Columns["idinvkind_real"]};
	Relations.Add(new DataRelation("FK_invoicekind_real_invoice",cPar,cChild,false));

	this.defineRelation("FK_fepaymethodcondition_invoice","fepaymethodcondition","invoice","idfepaymethodcondition");
	this.defineRelation("FK_fepaymethod_invoice","fepaymethod","invoice","idfepaymethod");
	this.defineRelation("FK_sdi_acquisto_invoice","sdi_acquisto","invoice","idsdi_acquisto");
	this.defineRelation("FK_sdi_vendita_invoice","sdi_vendita","invoice","idsdi_vendita");
	cPar = new []{ipa_ven_emittente.Columns["ipa_fe"]};
	cChild = new []{invoice.Columns["ipa_ven_emittente"]};
	Relations.Add(new DataRelation("FK_ipa_ven_emittente_invoice",cPar,cChild,false));

	cPar = new []{rifamm_ven_emittente.Columns["idsdi_rifamm"]};
	cChild = new []{invoice.Columns["rifamm_ven_emittente"]};
	Relations.Add(new DataRelation("FK_rifamm_ven_emittente_invoice",cPar,cChild,false));

	this.defineRelation("invoice_profservice1","invoice","profservice_1","idinvkind","yinv","ninv");
	cPar = new []{sorting_siope.Columns["idsor"]};
	cChild = new []{invoicedetail.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siope_invoicedetail",cPar,cChild,false));

	cPar = new []{registry_sostituto.Columns["idreg"]};
	cChild = new []{invoice.Columns["idreg_sostituto"]};
	Relations.Add(new DataRelation("registry_sostituto_invoice",cPar,cChild,false));

	#endregion

}
}
}
