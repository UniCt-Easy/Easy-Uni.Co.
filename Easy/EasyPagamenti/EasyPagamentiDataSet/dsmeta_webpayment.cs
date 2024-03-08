
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using meta_registryreference;
using meta_webpayment;
using meta_webpaymentdetail;
using meta_list;
using meta_flussocrediti;
using meta_flussocreditidetail;
using meta_registry;
using meta_invoice;
using meta_invoicedetail;
using meta_ivaregister;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace EasyPagamentiDataSet {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_webpayment"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_webpayment: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryreferenceTable registryreference 		=> (registryreferenceTable)Tables["registryreference"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public webpaymentTable webpayment 		=> (webpaymentTable)Tables["webpayment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public webpaymentdetailTable webpaymentdetail 		=> (webpaymentdetailTable)Tables["webpaymentdetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public listTable list 		=> (listTable)Tables["list"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable store 		=> (MetaTable)Tables["store"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable webpaymentview 		=> (MetaTable)Tables["webpaymentview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable webpaymentstatus 		=> (MetaTable)Tables["webpaymentstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditiTable flussocrediti 		=> (flussocreditiTable)Tables["flussocrediti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditidetailTable flussocreditidetail 		=> (flussocreditidetailTable)Tables["flussocreditidetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable currency 		=> (MetaTable)Tables["currency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable showcasedetail 		=> (MetaTable)Tables["showcasedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listclass 		=> (MetaTable)Tables["listclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoiceTable invoice 		=> (invoiceTable)Tables["invoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicedetailTable invoicedetail 		=> (invoicedetailTable)Tables["invoicedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivaregisterTable ivaregister 		=> (ivaregisterTable)Tables["ivaregister"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable report 		=> (MetaTable)Tables["report"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_webpayment(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_webpayment (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_webpayment";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_webpayment.xsd";

	#region create DataTables
	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new registryreferenceTable();
	tregistryreference.addBaseColumns("idreg","idregistryreference","referencename","ct","cu","email","faxnumber","flagdefault","lt","lu","mobilenumber","passwordweb","phonenumber","registryreferencerole","rtf","txt","userweb","skypenumber","msnnumber","activeweb","iterweb","saltweb");
	Tables.Add(tregistryreference);
	tregistryreference.defineKey("idreg", "idregistryreference");

	//////////////////// WEBPAYMENT /////////////////////////////////
	var twebpayment= new webpaymentTable();
	twebpayment.addBaseColumns("idwebpayment","cf","ct","cu","email","forename","idcustomuser","idlcard","idman","lt","lu","nwebpayment","surname","ywebpayment","idwebpaymentstatus","idreg","idflussocrediti","qrcode","iuv","adate");
	Tables.Add(twebpayment);
	twebpayment.defineKey("idwebpayment");

	//////////////////// WEBPAYMENTDETAIL /////////////////////////////////
	var twebpaymentdetail= new webpaymentdetailTable();
	twebpaymentdetail.addBaseColumns("idwebpayment","idlist","idstore","ct","cu","idsor1","idsor2","idsor3","lt","lu","number","price","iddetail","idupb","idestimkind","paymentexpiring","idivakind","tax","annotations","idinvkind","competencystart","competencystop","idupb_iva","flag_showcase");
	twebpaymentdetail.defineColumn("!list", typeof(string));
	twebpaymentdetail.defineColumn("!store", typeof(string));
	twebpaymentdetail.defineColumn("!totale", typeof(decimal));
	Tables.Add(twebpaymentdetail);
	twebpaymentdetail.defineKey("idwebpayment", "iddetail");

	//////////////////// LIST /////////////////////////////////
	var tlist= new listTable();
	tlist.addBaseColumns("idlist","description","intcode","intbarcode","extcode","extbarcode","validitystop","active","idpackage","idunit","unitsforpackage","has_expiry","cu","ct","lu","lt","idlistclass","pic","picext","nmin","ntoreorder","tounload","timesupply","nmaxorder","price","insinfo","descrforuser","idtassonomia");
	Tables.Add(tlist);
	tlist.defineKey("idlist");

	//////////////////// STORE /////////////////////////////////
	var tstore= new MetaTable("store");
	tstore.defineColumn("idstore", typeof(int),false);
	tstore.defineColumn("description", typeof(string),false);
	tstore.defineColumn("deliveryaddress", typeof(string),false);
	tstore.defineColumn("active", typeof(string),false);
	tstore.defineColumn("cu", typeof(string),false);
	tstore.defineColumn("ct", typeof(DateTime),false);
	tstore.defineColumn("lu", typeof(string),false);
	tstore.defineColumn("lt", typeof(DateTime),false);
	tstore.defineColumn("email", typeof(string));
	tstore.defineColumn("idupb", typeof(string));
	tstore.defineColumn("idsor01", typeof(int));
	tstore.defineColumn("idsor02", typeof(int));
	tstore.defineColumn("idsor03", typeof(int));
	tstore.defineColumn("idsor04", typeof(int));
	tstore.defineColumn("idsor05", typeof(int));
	tstore.defineColumn("virtual", typeof(string));
	tstore.defineColumn("idestimkind", typeof(string));
	Tables.Add(tstore);
	tstore.defineKey("idstore");

	//////////////////// WEBPAYMENTVIEW /////////////////////////////////
	var twebpaymentview= new MetaTable("webpaymentview");
	twebpaymentview.defineColumn("idwebpayment", typeof(int),false);
	twebpaymentview.defineColumn("ywebpayment", typeof(short),false);
	twebpaymentview.defineColumn("nwebpayment", typeof(int));
	twebpaymentview.defineColumn("forename", typeof(string));
	twebpaymentview.defineColumn("surname", typeof(string));
	twebpaymentview.defineColumn("cf", typeof(string));
	twebpaymentview.defineColumn("idcustomuser", typeof(string));
	twebpaymentview.defineColumn("idwebpaymentstatus", typeof(short));
	twebpaymentview.defineColumn("webpaymentstatus", typeof(string));
	twebpaymentview.defineColumn("adate", typeof(DateTime));
	Tables.Add(twebpaymentview);
	twebpaymentview.defineKey("idwebpayment");

	//////////////////// WEBPAYMENTSTATUS /////////////////////////////////
	var twebpaymentstatus= new MetaTable("webpaymentstatus");
	twebpaymentstatus.defineColumn("idwebpaymentstatus", typeof(short),false);
	twebpaymentstatus.defineColumn("ct", typeof(DateTime),false);
	twebpaymentstatus.defineColumn("cu", typeof(string),false);
	twebpaymentstatus.defineColumn("description", typeof(string),false);
	twebpaymentstatus.defineColumn("listingorder", typeof(int));
	twebpaymentstatus.defineColumn("lt", typeof(DateTime),false);
	twebpaymentstatus.defineColumn("lu", typeof(string),false);
	Tables.Add(twebpaymentstatus);
	twebpaymentstatus.defineKey("idwebpaymentstatus");

	//////////////////// FLUSSOCREDITI /////////////////////////////////
	var tflussocrediti= new flussocreditiTable();
	tflussocrediti.addBaseColumns("idflusso","cu","ct","lu","lt","datacreazioneflusso","flusso","istransmitted","idsor01","idsor02","idsor03","idsor04","idsor05","filename","progday","docdate","idestimkind");
	Tables.Add(tflussocrediti);
	tflussocrediti.defineKey("idflusso");

	//////////////////// FLUSSOCREDITIDETAIL /////////////////////////////////
	var tflussocreditidetail= new flussocreditidetailTable();
	tflussocreditidetail.addBaseColumns("idflusso","iddetail","cu","ct","lu","lt","importoversamento","idestimkind","yestim","nestim","rownum","idinvkind","yinv","ninv","invrownum","idfinmotive","iduniqueformcode","idaccmotiverevenue","idaccmotivecredit","idaccmotiveundotax","idaccmotiveundotaxpost","idupb","idreg","stop","competencystart","competencystop","description","nform","expirationdate","barcodevalue","barcodeimage","qrcodevalue","qrcodeimage","cf","iuv","annulment","flag","idunivoco","codiceavviso","idivakind","tax","number","idlist","p_iva","annotations","idupb_iva","flag_showcase","codicetassonomia","idfinmotive_iva","idsor1","idsor2","idsor3");
	Tables.Add(tflussocreditidetail);
	tflussocreditidetail.defineKey("idflusso", "iddetail");

	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new MetaTable("currency");
	tcurrency.defineColumn("ct", typeof(DateTime),false);
	tcurrency.defineColumn("cu", typeof(string),false);
	tcurrency.defineColumn("description", typeof(string),false);
	tcurrency.defineColumn("lt", typeof(DateTime),false);
	tcurrency.defineColumn("lu", typeof(string),false);
	tcurrency.defineColumn("codecurrency", typeof(string));
	tcurrency.defineColumn("idcurrency", typeof(int),false);
	Tables.Add(tcurrency);
	tcurrency.defineKey("idcurrency");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","active","annotation","badgecode","birthdate","cf","ct","cu","extmatricula","foreigncf","forename","gender","idcategory","idcentralizedcategory","idcity","idmaritalstatus","idnation","idregistryclass","idtitle","location","lt","lu","maritalsurname","p_iva","rtf","surname","title","txt","residence","idregistrykind","authorization_free","multi_cf","toredirect","idaccmotivedebit","idaccmotivecredit","ccp","flagbankitaliaproceeds","idexternal","ipa_fe","flag_pa","sdi_norifamm","sdi_defrifamm");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// SHOWCASEDETAIL /////////////////////////////////
	var tshowcasedetail= new MetaTable("showcasedetail");
	tshowcasedetail.defineColumn("idshowcase", typeof(int),false);
	tshowcasedetail.defineColumn("idlist", typeof(int),false);
	tshowcasedetail.defineColumn("cu", typeof(string),false);
	tshowcasedetail.defineColumn("ct", typeof(DateTime),false);
	tshowcasedetail.defineColumn("lu", typeof(string),false);
	tshowcasedetail.defineColumn("lt", typeof(DateTime),false);
	tshowcasedetail.defineColumn("availability", typeof(int));
	tshowcasedetail.defineColumn("idivakind", typeof(int));
	tshowcasedetail.defineColumn("title", typeof(string));
	tshowcasedetail.defineColumn("unitprice", typeof(decimal));
	tshowcasedetail.defineColumn("idestimkind", typeof(string));
	tshowcasedetail.defineColumn("idupb", typeof(string));
	tshowcasedetail.defineColumn("idinvkind", typeof(int));
	tshowcasedetail.defineColumn("competencystart", typeof(DateTime));
	tshowcasedetail.defineColumn("competencystop", typeof(DateTime));
	tshowcasedetail.defineColumn("idupb_iva", typeof(string));
	tshowcasedetail.defineColumn("idsor1", typeof(int));
	tshowcasedetail.defineColumn("idsor2", typeof(int));
	tshowcasedetail.defineColumn("idsor3", typeof(int));
	Tables.Add(tshowcasedetail);
	tshowcasedetail.defineKey("idshowcase", "idlist");

	//////////////////// LISTCLASS /////////////////////////////////
	var tlistclass= new MetaTable("listclass");
	tlistclass.defineColumn("idlistclass", typeof(string),false);
	tlistclass.defineColumn("active", typeof(string),false);
	tlistclass.defineColumn("codelistclass", typeof(string),false);
	tlistclass.defineColumn("paridlistclass", typeof(string));
	tlistclass.defineColumn("printingorder", typeof(string),false);
	tlistclass.defineColumn("title", typeof(string),false);
	tlistclass.defineColumn("rtf", typeof(Byte[]));
	tlistclass.defineColumn("txt", typeof(string));
	tlistclass.defineColumn("ct", typeof(DateTime),false);
	tlistclass.defineColumn("cu", typeof(string),false);
	tlistclass.defineColumn("lt", typeof(DateTime),false);
	tlistclass.defineColumn("lu", typeof(string),false);
	tlistclass.defineColumn("authrequired", typeof(string));
	tlistclass.defineColumn("idaccmotive", typeof(string));
	tlistclass.defineColumn("idinv", typeof(int));
	tlistclass.defineColumn("assetkind", typeof(string));
	tlistclass.defineColumn("va3type", typeof(string));
	tlistclass.defineColumn("flag", typeof(int));
	tlistclass.defineColumn("idintrastatsupplymethod", typeof(int));
	tlistclass.defineColumn("intra12operationkind", typeof(string));
	tlistclass.defineColumn("flagvisiblekind", typeof(byte));
	tlistclass.defineColumn("idfinmotive", typeof(string));
	tlistclass.defineColumn("idaccmotivecredit", typeof(string));
	tlistclass.defineColumn("idfinmotive_iva", typeof(string));
	Tables.Add(tlistclass);
	tlistclass.defineKey("idlistclass");

	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new invoiceTable();
	tinvoice.addBaseColumns("ninv","yinv","active","adate","ct","cu","description","doc","docdate","exchangerate","flagdeferred","idreg","lt","lu","officiallyprinted","packinglistdate","packinglistnum","paymentexpiring","registryreference","rtf","txt","idinvkind","idcurrency","idexpirationkind","idtreasurer","flagintracom","iso_origin","iso_provenance","iso_destination","idcountry_origin","idcountry_destination","idintrastatkind","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","idintrastatpaymethod","iso_payment","flag_ddt","flag","idblacklist","idinvkind_real","yinv_real","ninv_real","autoinvoice","idsor01","idsor02","idsor03","idsor04","idsor05","protocoldate","idfepaymethodcondition","idfepaymethod","nelectronicinvoice","yelectronicinvoice","annotations","arrivalprotocolnum","toincludeinpaymentindicator","resendingpcc","touniqueregister","idstampkind","flag_auto_split_payment","flag_enable_split_payment","idsdi_acquisto","idsdi_vendita","flag_reverse_charge","ipa_acq","rifamm_acq","ipa_ven_emittente","rifamm_ven_emittente","ipa_ven_cliente","rifamm_ven_cliente","ssntipospesa","ssnflagtipospesa","idinvkind_forwarder","yinv_forwarder","ninv_forwarder","flagbit","ssn_nprot","requested_doc");
	Tables.Add(tinvoice);
	tinvoice.defineKey("ninv", "yinv", "idinvkind");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("ninv","rownum","yinv","annotations","competencystart","paymentcompetency","competencystop","ct","cu","detaildescription","discount","idaccmotive","idmankind","idupb","lt","lu","manrownum","nman","number","tax","taxable","unabatable","yman","idestimkind","estimrownum","nestim","yestim","idgroup","idexp_taxable","idexp_iva","idinc_taxable","idinc_iva","ninv_main","yinv_main","idivakind","idinvkind","idsor1","idsor2","idsor3","idintrastatcode","idintrastatmeasure","weight","va3type","intrastatoperationkind","idintrastatservice","idintrastatsupplymethod","idlist","idunit","idpackage","unitsforpackage","npackage","flag","exception12","intra12operationkind","move12","idupb_iva","idinvkind_main","leasing","usedmodesospesometro","resetresidualmandate","idfetransfer","fereferencerule","cupcode","cigcode","idpccdebitstatus","idpccdebitmotive","idcostpartition","expensekind","rounding","idepexp","idepacc","flagbit","idfinmotive","iduniqueformcode","ycon","ncon","codicevalore","codicetipo","idsor_siope","idtassonomia","idfinmotive_iva");
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("ninv", "rownum", "yinv", "idinvkind");

	//////////////////// IVAREGISTER /////////////////////////////////
	var tivaregister= new ivaregisterTable();
	tivaregister.addBaseColumns("nivaregister","yivaregister","ct","cu","lt","lu","ninv","protocolnum","yinv","idinvkind","idivaregisterkind");
	Tables.Add(tivaregister);
	tivaregister.defineKey("nivaregister", "yivaregister", "idivaregisterkind");

	//////////////////// REPORT /////////////////////////////////
	var treport= new MetaTable("report");
	treport.defineColumn("modulename", typeof(string),false);
	treport.defineColumn("reportname", typeof(string),false);
	treport.defineColumn("description", typeof(string),false);
	treport.defineColumn("filename", typeof(string),false);
	treport.defineColumn("groupname", typeof(string));
	treport.defineColumn("orientation", typeof(string),false);
	treport.defineColumn("papersize", typeof(string));
	treport.defineColumn("sp_doupdate", typeof(string));
	treport.defineColumn("timeout", typeof(int));
	treport.defineColumn("webvisible", typeof(string));
	treport.defineColumn("active", typeof(string));
	treport.defineColumn("flag_both", typeof(string));
	treport.defineColumn("flag_cash", typeof(string));
	treport.defineColumn("flag_comp", typeof(string));
	treport.defineColumn("flag_credit", typeof(string));
	treport.defineColumn("flag_proceeds", typeof(string));
	Tables.Add(treport);
	treport.defineKey("reportname");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_registryreference_webpayment","registryreference","webpayment","idreg");
	this.defineRelation("list_webpaymentdetail","list","webpaymentdetail","idlist");
	this.defineRelation("store_webpaymentdetail","store","webpaymentdetail","idstore");
	this.defineRelation("webpayment_webpaymentdetail","webpayment","webpaymentdetail","idwebpayment");
	this.defineRelation("webpaymentstatus_webpayment","webpaymentstatus","webpayment","idwebpaymentstatus");
	var cPar = new []{flussocrediti.Columns["idflusso"]};
	var cChild = new []{webpayment.Columns["idflussocrediti"]};
	Relations.Add(new DataRelation("flussocrediti_webpayment",cPar,cChild,false));

	this.defineRelation("flussocrediti_flussocreditidetail","flussocrediti","flussocreditidetail","idflusso");
	this.defineRelation("list_showcasedetail","list","showcasedetail","idlist");
	this.defineRelation("listclass_list","listclass","list","idlistclass");
	this.defineRelation("invoice_invoicedetail","invoice","invoicedetail","ninv","yinv","idinvkind");
	this.defineRelation("invoice_ivaregister","invoice","ivaregister","yinv","ninv","idinvkind");
	#endregion

}
}
}
