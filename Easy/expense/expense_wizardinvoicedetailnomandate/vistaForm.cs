
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using meta_invoicedetail;
using meta_invoicekind;
using meta_ivakind;
using meta_expense;
using meta_registry;
using meta_expenseyear;
using meta_fin;
using meta_upb;
using meta_invoice;
using meta_expenselast;
using meta_bill;
using meta_account;
using meta_config;
using meta_expensesorted;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace expense_wizardinvoicedetailnomandate {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicedetailTable invoicedetail 		=> (invoicedetailTable)Tables["invoicedetail"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensephase 		=> (MetaTable)Tables["expensephase"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivakindTable ivakind 		=> (ivakindTable)Tables["ivakind"];

	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenseTable expense 		=> (expenseTable)Tables["expense"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Informazioni annuali su movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenseyearTable expenseyear 		=> (expenseyearTable)Tables["expenseyear"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finTable fin 		=> (finTable)Tables["fin"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipomovimento 		=> (MetaTable)Tables["tipomovimento"];

	///<summary>
	///Fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoiceTable invoice 		=> (invoiceTable)Tables["invoice"];

	///<summary>
	///Contabilizzazione fattura acquisto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenseinvoice 		=> (MetaTable)Tables["expenseinvoice"];

	///<summary>
	///Movimento di spesa - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenselastTable expenselast 		=> (expenselastTable)Tables["expenselast"];

	///<summary>
	///Partita pendente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public billTable bill 		=> (billTable)Tables["bill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable billview 		=> (MetaTable)Tables["billview"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account 		=> (accountTable)Tables["account"];

	///<summary>
	///Dettaglio Recuperi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenseclawback 		=> (MetaTable)Tables["expenseclawback"];

	///<summary>
	///Tipi di recupero
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable clawback 		=> (MetaTable)Tables["clawback"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	///<summary>
	///dettagli di una fattura inseriti in liquidazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedetaildeferred 		=> (MetaTable)Tables["invoicedetaildeferred"];

	///<summary>
	///Classificazione Movimenti di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expensesortedTable expensesorted 		=> (expensesortedTable)Tables["expensesorted"];

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
	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("idinvkind","yinv","ninv","rownum","idgroup","idivakind","detaildescription","annotations","taxable","tax","unabatable","cu","ct","lu","lt","discount","idmankind","yman","nman","manrownum","number","idupb","idsor1","idsor2","idsor3","competencystart","competencystop","idexp_taxable","idexp_iva","idaccmotive","idestimkind","estimrownum","nestim","yestim","idintrastatcode","idintrastatmeasure","weight","va3type","idlist","idpackage","idunit","npackage","unitsforpackage","flag","intrastatoperationkind","intra12operationkind","exception12","move12","idupb_iva","idintrastatservice","idintrastatsupplymethod","leasing","usedmodesospesometro","resetresidualmandate","idcostpartition","idpccdebitmotive","idpccdebitstatus","expensekind","rounding","idepexp","idepacc","ycon","ncon","idsor_siope");
	tinvoicedetail.defineColumn("!codeupb", typeof(string));
	tinvoicedetail.defineColumn("!disponibile", typeof(decimal));
	tinvoicedetail.defineColumn("!idexptolink", typeof(string));
	tinvoicedetail.defineColumn("!monomandate", typeof(string));
	tinvoicedetail.defineColumn("!tipoiva", typeof(string));
	tinvoicedetail.defineColumn("!totaleriga", typeof(decimal));
	tinvoicedetail.defineColumn("!aliquota", typeof(decimal));
	tinvoicedetail.defineColumn("!codeupb_iva", typeof(string));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("idinvkind", "yinv", "ninv", "rownum");

	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new MetaTable("expensephase");
	texpensephase.defineColumn("nphase", typeof(byte),false);
	texpensephase.defineColumn("ct", typeof(DateTime),false);
	texpensephase.defineColumn("cu", typeof(string),false);
	texpensephase.defineColumn("description", typeof(string),false);
	texpensephase.defineColumn("lt", typeof(DateTime),false);
	texpensephase.defineColumn("lu", typeof(string),false);
	Tables.Add(texpensephase);
	texpensephase.defineKey("nphase");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("idinvkind","flag","ct","cu","description","lt","lu","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new ivakindTable();
	tivakind.addBaseColumns("idivakind","ct","cu","description","lt","lu","rate","unabatabilitypercentage","active");
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new expenseTable();
	texpense.addBaseColumns("adate","ct","cu","description","doc","docdate","expiration","idreg","lt","lu","nmov","rtf","txt","ymov","idclawback","idman","nphase","idexp","parentidexp","idpayment","idformerexpense","autokind","autocode");
	Tables.Add(texpense);
	texpense.defineKey("idexp");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","active","annotation","badgecode","birthdate","cf","ct","cu","extmatricula","foreigncf","forename","gender","idcategory","idcentralizedcategory","idcity","idmaritalstatus","idnation","idregistryclass","idtitle","location","lt","lu","maritalsurname","p_iva","residence","rtf","surname","title","txt");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// EXPENSEYEAR /////////////////////////////////
	var texpenseyear= new expenseyearTable();
	texpenseyear.addBaseColumns("ayear","idexp","amount","ct","cu","idfin","idupb","lt","lu");
	Tables.Add(texpenseyear);
	texpenseyear.defineKey("ayear", "idexp");

	//////////////////// FIN /////////////////////////////////
	var tfin= new finTable();
	tfin.addBaseColumns("idfin","ayear","flag","codefin","paridfin","nlevel","printingorder","title","cu","ct","lu","lt");
	Tables.Add(tfin);
	tfin.defineKey("idfin");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","idman","idunderwriter","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	var ttipomovimento= new MetaTable("tipomovimento");
	ttipomovimento.defineColumn("idtipo", typeof(string),false);
	ttipomovimento.defineColumn("descrizione", typeof(string),false);
	Tables.Add(ttipomovimento);
	ttipomovimento.defineKey("idtipo");

	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new invoiceTable();
	tinvoice.addBaseColumns("idinvkind","ninv","yinv","active","adate","ct","cu","description","doc","docdate","exchangerate","flagdeferred","idcurrency","idexpirationkind","idreg","lt","lu","officiallyprinted","packinglistdate","packinglistnum","paymentexpiring","registryreference","rtf","txt","idaccmotivedebit","idaccmotivedebit_crg","flag","idblacklist","idsor01","idsor02","idsor03","idsor04","idsor05","flag_enable_split_payment","flag_auto_split_payment","requested_doc","flagbit","flagintracom");
	Tables.Add(tinvoice);
	tinvoice.defineKey("idinvkind", "ninv", "yinv");

	//////////////////// EXPENSEINVOICE /////////////////////////////////
	var texpenseinvoice= new MetaTable("expenseinvoice");
	texpenseinvoice.defineColumn("idexp", typeof(int),false);
	texpenseinvoice.defineColumn("idinvkind", typeof(int),false);
	texpenseinvoice.defineColumn("ninv", typeof(int),false);
	texpenseinvoice.defineColumn("yinv", typeof(short),false);
	texpenseinvoice.defineColumn("ct", typeof(DateTime),false);
	texpenseinvoice.defineColumn("cu", typeof(string),false);
	texpenseinvoice.defineColumn("lt", typeof(DateTime),false);
	texpenseinvoice.defineColumn("lu", typeof(string),false);
	texpenseinvoice.defineColumn("movkind", typeof(short));
	Tables.Add(texpenseinvoice);
	texpenseinvoice.defineKey("idexp", "idinvkind", "ninv", "yinv");

	//////////////////// EXPENSELAST /////////////////////////////////
	var texpenselast= new expenselastTable();
	texpenselast.addBaseColumns("idexp","cc","cin","ct","cu","flag","idbank","idcab","iddeputy","idpay","idpaymethod","idregistrypaymethod","idser","ivaamount","lt","lu","nbill","paymentdescr","servicestart","servicestop","refexternaldoc","kpay","iban","idaccdebit","biccode","paymethod_flag","paymethod_allowdeputy","extracode","idchargehandling");
	Tables.Add(texpenselast);
	texpenselast.defineKey("idexp");

	//////////////////// BILL /////////////////////////////////
	var tbill= new billTable();
	tbill.addBaseColumns("ybill","nbill","billkind","registry","covered","total","adate","active","motive","cu","ct","lu","lt");
	Tables.Add(tbill);
	tbill.defineKey("nbill");

	//////////////////// BILLVIEW /////////////////////////////////
	var tbillview= new MetaTable("billview");
	tbillview.defineColumn("ybill", typeof(short),false);
	tbillview.defineColumn("nbill", typeof(int),false);
	tbillview.defineColumn("billkind", typeof(string),false);
	tbillview.defineColumn("active", typeof(string));
	tbillview.defineColumn("adate", typeof(DateTime));
	tbillview.defineColumn("registry", typeof(string));
	tbillview.defineColumn("motive", typeof(string));
	tbillview.defineColumn("total", typeof(decimal));
	tbillview.defineColumn("covered", typeof(decimal));
	tbillview.defineColumn("cu", typeof(string),false);
	tbillview.defineColumn("ct", typeof(DateTime),false);
	tbillview.defineColumn("lu", typeof(string),false);
	tbillview.defineColumn("lt", typeof(DateTime),false);
	tbillview.defineColumn("idtreasurer", typeof(int));
	tbillview.defineColumn("treasurer", typeof(string));
	tbillview.defineColumn("regularizationnote", typeof(string));
	tbillview.defineColumn("idsor01", typeof(int));
	tbillview.defineColumn("idsor02", typeof(int));
	tbillview.defineColumn("idsor03", typeof(int));
	tbillview.defineColumn("idsor04", typeof(int));
	tbillview.defineColumn("idsor05", typeof(int));
	Tables.Add(tbillview);

	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new accountTable();
	taccount.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	Tables.Add(taccount);
	taccount.defineKey("idacc");

	//////////////////// EXPENSECLAWBACK /////////////////////////////////
	var texpenseclawback= new MetaTable("expenseclawback");
	texpenseclawback.defineColumn("idexp", typeof(int),false);
	texpenseclawback.defineColumn("idclawback", typeof(int),false);
	texpenseclawback.defineColumn("amount", typeof(decimal));
	texpenseclawback.defineColumn("cu", typeof(string),false);
	texpenseclawback.defineColumn("ct", typeof(DateTime),false);
	texpenseclawback.defineColumn("lu", typeof(string),false);
	texpenseclawback.defineColumn("lt", typeof(DateTime),false);
	texpenseclawback.defineColumn("!clawbackref", typeof(string));
	texpenseclawback.defineColumn("fiscaltaxcode", typeof(string));
	texpenseclawback.defineColumn("identifying_marks", typeof(string));
	texpenseclawback.defineColumn("code", typeof(string));
	texpenseclawback.defineColumn("tiporiga", typeof(string));
	texpenseclawback.defineColumn("rifb_month", typeof(int));
	texpenseclawback.defineColumn("rifb_year", typeof(int));
	texpenseclawback.defineColumn("rifa_month", typeof(int));
	texpenseclawback.defineColumn("rifa_year", typeof(int));
	texpenseclawback.defineColumn("rifa", typeof(string));
	Tables.Add(texpenseclawback);
	texpenseclawback.defineKey("idexp", "idclawback");

	//////////////////// CLAWBACK /////////////////////////////////
	var tclawback= new MetaTable("clawback");
	tclawback.defineColumn("idclawback", typeof(int),false);
	tclawback.defineColumn("description", typeof(string),false);
	tclawback.defineColumn("cu", typeof(string),false);
	tclawback.defineColumn("ct", typeof(DateTime),false);
	tclawback.defineColumn("lu", typeof(string),false);
	tclawback.defineColumn("lt", typeof(DateTime),false);
	tclawback.defineColumn("clawbackref", typeof(string));
	tclawback.defineColumn("active", typeof(string));
	tclawback.defineColumn("flagf24ep", typeof(string));
	Tables.Add(tclawback);
	tclawback.defineKey("idclawback");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idregauto","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart","idivapayperiodicity","idsortingkind1","idsortingkind2","idsortingkind3","fin_kind","taxvaliditykind","flag_paymentamount","automanagekind","flag_autodocnumbering","flagbank_grouping","cashvaliditykind");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// INVOICEDETAILDEFERRED /////////////////////////////////
	var tinvoicedetaildeferred= new MetaTable("invoicedetaildeferred");
	tinvoicedetaildeferred.defineColumn("idinvkind", typeof(int),false);
	tinvoicedetaildeferred.defineColumn("yinv", typeof(short),false);
	tinvoicedetaildeferred.defineColumn("ninv", typeof(int),false);
	tinvoicedetaildeferred.defineColumn("rownum", typeof(int),false);
	tinvoicedetaildeferred.defineColumn("yivapay", typeof(short),false);
	tinvoicedetaildeferred.defineColumn("nivapay", typeof(int),false);
	tinvoicedetaildeferred.defineColumn("ivatotalpayed", typeof(decimal));
	tinvoicedetaildeferred.defineColumn("taxable", typeof(decimal));
	tinvoicedetaildeferred.defineColumn("cu", typeof(string));
	tinvoicedetaildeferred.defineColumn("ct", typeof(DateTime));
	tinvoicedetaildeferred.defineColumn("lu", typeof(string));
	tinvoicedetaildeferred.defineColumn("lt", typeof(string));
	tinvoicedetaildeferred.defineColumn("idivaregisterkind", typeof(int),false);
	Tables.Add(tinvoicedetaildeferred);
	tinvoicedetaildeferred.defineKey("idinvkind", "yinv", "ninv", "rownum", "yivapay", "nivapay", "idivaregisterkind");

	//////////////////// EXPENSESORTED /////////////////////////////////
	var texpensesorted= new expensesortedTable();
	texpensesorted.addBaseColumns("idsor","idexp","idsubclass","amount","valuen1","valuen2","valuen3","valuen4","valuen5","values1","values2","values3","values4","values5","valuev1","valuev2","valuev3","valuev4","valuev5","ayear","description","txt","rtf","cu","ct","lu","lt","flagnodate","tobecontinued","start","stop","paridsor","paridsubclass");
	Tables.Add(texpensesorted);
	texpensesorted.defineKey("idexp", "idsor", "idsubclass");

	#endregion


	#region DataRelation creation
	this.defineRelation("invoicedetail_invoicedetaildeferred","invoicedetail","invoicedetaildeferred","idinvkind","yinv","ninv","rownum");
	this.defineRelation("expense_expenseclawback","expense","expenseclawback","idexp");
	this.defineRelation("clawback_expenseclawback","clawback","expenseclawback","idclawback");
	var cPar = new []{account.Columns["idacc"]};
	var cChild = new []{expenselast.Columns["idaccdebit"]};
	Relations.Add(new DataRelation("account_expenselast",cPar,cChild,false));

	this.defineRelation("bill_expenselast","bill","expenselast","nbill");
	this.defineRelation("expense_expenselast","expense","expenselast","idexp");
	this.defineRelation("FK_expense_expenseinvoice","expense","expenseinvoice","idexp");
	this.defineRelation("FK_invoice_expenseinvoice","invoice","expenseinvoice","idinvkind","ninv","yinv");
	this.defineRelation("invoicekind_invoice","invoicekind","invoice","idinvkind");
	this.defineRelation("upb_expenseyear","upb","expenseyear","idupb");
	this.defineRelation("fin_expenseyear","fin","expenseyear","idfin");
	this.defineRelation("expense_expenseyear","expense","expenseyear","idexp");
	this.defineRelation("registry_expense","registry","expense","idreg");
	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expense.Columns["parentidexp"]};
	Relations.Add(new DataRelation("expense_expense",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{invoicedetail.Columns["idexp_iva"]};
	Relations.Add(new DataRelation("expense_invoicedetail1",cPar,cChild,false));

	this.defineRelation("invoice_invoicedetail","invoice","invoicedetail","idinvkind","ninv","yinv");
	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{invoicedetail.Columns["idexp_taxable"]};
	Relations.Add(new DataRelation("expense_invoicedetail",cPar,cChild,false));

	this.defineRelation("ivakind_invoicedetail","ivakind","invoicedetail","idivakind");
	this.defineRelation("expense_expensesorted","expense","expensesorted","idexp");
	#endregion

}
}
}
