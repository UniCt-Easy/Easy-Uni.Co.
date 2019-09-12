/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using meta_payment;
using meta_treasurer;
using meta_manager;
using meta_registry;
using meta_paymenttransmission;
using meta_expensevar;
using meta_banktransaction;
using meta_sortingkind;
using meta_expensesorted;
using meta_config;
using meta_fin;
using meta_paydisposition;
using meta_paydispositiondetail;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace payment_docmultiplo {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Documento di pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public paymentTable payment 		=> (paymentTable)Tables["payment"];

	///<summary>
	///Trattamento del bollo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stamphandling 		=> (MetaTable)Tables["stamphandling"];

	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public treasurerTable treasurer 		=> (treasurerTable)Tables["treasurer"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public managerTable manager 		=> (managerTable)Tables["manager"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensephase 		=> (MetaTable)Tables["expensephase"];

	///<summary>
	///Distinta di trasmissione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public paymenttransmissionTable paymenttransmission 		=> (paymenttransmissionTable)Tables["paymenttransmission"];

	///<summary>
	///Variazione movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expensevarTable expensevar 		=> (expensevarTable)Tables["expensevar"];

	///<summary>
	///Movimento bancario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public banktransactionTable banktransaction 		=> (banktransactionTable)Tables["banktransaction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable payment_bankview 		=> (MetaTable)Tables["payment_bankview"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingkindTable sortingkind 		=> (sortingkindTable)Tables["sortingkind"];

	///<summary>
	///Classificazione Movimenti di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expensesortedTable expensesorted 		=> (expensesortedTable)Tables["expensesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenselastview 		=> (MetaTable)Tables["expenselastview"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finTable fin 		=> (finTable)Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expense1 		=> (MetaTable)Tables["expense1"];

	///<summary>
	///Disposizione di Pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public paydispositionTable paydisposition 		=> (paydispositionTable)Tables["paydisposition"];

	///<summary>
	///Disposizione di Pagamento - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public paydispositiondetailTable paydispositiondetail 		=> (paydispositiondetailTable)Tables["paydispositiondetail"];

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
	//////////////////// PAYMENT /////////////////////////////////
	var tpayment= new paymentTable();
	tpayment.addBaseColumns("kpay","ypay","npay","kpaymenttransmission","idstamphandling","idtreasurer","flag","idreg","idfin","idman","adate","printdate","txt","rtf","cu","ct","lu","lt","annulmentdate","idsor01","idsor02","idsor03","idsor04","idsor05","npay_treasurer");
	Tables.Add(tpayment);
	tpayment.defineKey("kpay");

	//////////////////// STAMPHANDLING /////////////////////////////////
	var tstamphandling= new MetaTable("stamphandling");
	tstamphandling.defineColumn("idstamphandling", typeof(int),false);
	tstamphandling.defineColumn("description", typeof(string),false);
	tstamphandling.defineColumn("flagdefault", typeof(string),false);
	tstamphandling.defineColumn("cu", typeof(string),false);
	tstamphandling.defineColumn("ct", typeof(DateTime),false);
	tstamphandling.defineColumn("lu", typeof(string),false);
	tstamphandling.defineColumn("lt", typeof(DateTime),false);
	tstamphandling.defineColumn("active", typeof(string));
	Tables.Add(tstamphandling);
	tstamphandling.defineKey("idstamphandling");

	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new treasurerTable();
	ttreasurer.addBaseColumns("idtreasurer","description","flagdefault","cin","idbank","idcab","cc","address","cap","city","country","phoneprefix","phonenumber","faxprefix","faxnumber","idsor01","idsor02","idsor03","idsor04","idsor05","cu","ct","lu","lt","active");
	Tables.Add(ttreasurer);
	ttreasurer.defineKey("idtreasurer");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new managerTable();
	tmanager.addBaseColumns("idman","title","iddivision","email","phonenumber","userweb","passwordweb","txt","rtf","cu","ct","lu","lt","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","annotation","birthdate","gender","surname","forename","foreigncf","active","txt","rtf","cu","ct","lu","lt");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new MetaTable("expensephase");
	texpensephase.defineColumn("nphase", typeof(byte),false);
	texpensephase.defineColumn("description", typeof(string),false);
	texpensephase.defineColumn("cu", typeof(string),false);
	texpensephase.defineColumn("ct", typeof(DateTime),false);
	texpensephase.defineColumn("lu", typeof(string),false);
	texpensephase.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(texpensephase);
	texpensephase.defineKey("nphase");

	//////////////////// PAYMENTTRANSMISSION /////////////////////////////////
	var tpaymenttransmission= new paymenttransmissionTable();
	tpaymenttransmission.addBaseColumns("kpaymenttransmission","ypaymenttransmission","npaymenttransmission","idman","idtreasurer","transmissiondate","cu","ct","lu","lt");
	Tables.Add(tpaymenttransmission);
	tpaymenttransmission.defineKey("kpaymenttransmission");

	//////////////////// EXPENSEVAR /////////////////////////////////
	var texpensevar= new expensevarTable();
	texpensevar.addBaseColumns("nvar","idexp","yvar","description","amount","doc","autokind","idpayment","docdate","adate","txt","rtf","cu","ct","lu","lt","idinvkind","ninv","yinv");
	Tables.Add(texpensevar);
	texpensevar.defineKey("nvar", "idexp");

	//////////////////// BANKTRANSACTION /////////////////////////////////
	var tbanktransaction= new banktransactionTable();
	tbanktransaction.addBaseColumns("yban","nban","kpay","kind","bankreference","transactiondate","valuedate","amount","kpro","cu","ct","lu","lt","idexp","idinc","idpay","idpro","idbankimport");
	tbanktransaction.defineColumn("!nmov", typeof(int));
	Tables.Add(tbanktransaction);
	tbanktransaction.defineKey("yban", "nban", "kpay");

	//////////////////// PAYMENT_BANKVIEW /////////////////////////////////
	var tpayment_bankview= new MetaTable("payment_bankview");
	tpayment_bankview.defineColumn("kpay", typeof(int),false);
	tpayment_bankview.defineColumn("ypay", typeof(short),false);
	tpayment_bankview.defineColumn("npay", typeof(int),false);
	tpayment_bankview.defineColumn("idpay", typeof(int),false);
	tpayment_bankview.defineColumn("idreg", typeof(int),false);
	tpayment_bankview.defineColumn("registry", typeof(string),false);
	tpayment_bankview.defineColumn("description", typeof(string));
	tpayment_bankview.defineColumn("amount", typeof(decimal),false);
	tpayment_bankview.defineColumn("ct", typeof(DateTime),false);
	tpayment_bankview.defineColumn("cu", typeof(string),false);
	tpayment_bankview.defineColumn("lt", typeof(DateTime),false);
	tpayment_bankview.defineColumn("lu", typeof(string),false);
	Tables.Add(tpayment_bankview);
	tpayment_bankview.defineKey("kpay", "idpay");

	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new sortingkindTable();
	tsortingkind.addBaseColumns("idsorkind","active","ct","cu","description","flagdate","flag","forcedN1","forcedN2","forcedN3","forcedN4","forcedN5","forcedS1","forcedS2","forcedS3","forcedS4","forcedS5","forcedv1","forcedv2","forcedv3","forcedv4","forcedv5","labelfordate","labeln1","labeln2","labeln3","labeln4","labeln5","labels1","labels2","labels3","labels4","labels5","labelv1","labelv2","labelv3","labelv4","labelv5","lockedN1","lockedN2","lockedN3","lockedN4","lockedN5","lockedS1","lockedS2","lockedS3","lockedS4","lockedS5","lockedv1","lockedv2","lockedv3","lockedv4","lockedv5","lt","lu","nodatelabel","nphaseexpense","nphaseincome","totalexpression");
	Tables.Add(tsortingkind);
	tsortingkind.defineKey("idsorkind");

	//////////////////// EXPENSESORTED /////////////////////////////////
	var texpensesorted= new expensesortedTable();
	texpensesorted.addBaseColumns("idexp","idsor","idsubclass","amount","ayear","ct","cu","description","flagnodate","lt","lu","paridsor","paridsubclass","rtf","start","stop","tobecontinued","txt","valuen1","valuen2","valuen3","valuen4","valuen5","values1","values2","values3","values4","values5","valuev1","valuev2","valuev3","valuev4","valuev5");
	Tables.Add(texpensesorted);
	texpensesorted.defineKey("idexp", "idsor", "idsubclass");

	//////////////////// EXPENSELASTVIEW /////////////////////////////////
	var texpenselastview= new MetaTable("expenselastview");
	texpenselastview.defineColumn("idexp", typeof(int),false);
	texpenselastview.defineColumn("nphase", typeof(byte),false);
	texpenselastview.defineColumn("phase", typeof(string),false);
	texpenselastview.defineColumn("ymov", typeof(short),false);
	texpenselastview.defineColumn("nmov", typeof(int),false);
	texpenselastview.defineColumn("parentidexp", typeof(int));
	texpenselastview.defineColumn("parentymov", typeof(short));
	texpenselastview.defineColumn("parentnmov", typeof(int));
	texpenselastview.defineColumn("idformerexpense", typeof(int));
	texpenselastview.defineColumn("ayear", typeof(short),false);
	texpenselastview.defineColumn("idfin", typeof(int));
	texpenselastview.defineColumn("codefin", typeof(string));
	texpenselastview.defineColumn("finance", typeof(string));
	texpenselastview.defineColumn("idupb", typeof(string));
	texpenselastview.defineColumn("codeupb", typeof(string));
	texpenselastview.defineColumn("upb", typeof(string));
	texpenselastview.defineColumn("idreg", typeof(int));
	texpenselastview.defineColumn("registry", typeof(string));
	texpenselastview.defineColumn("idman", typeof(int));
	texpenselastview.defineColumn("manager", typeof(string));
	texpenselastview.defineColumn("kpay", typeof(int));
	texpenselastview.defineColumn("ypay", typeof(short),true,true);
	texpenselastview.defineColumn("npay", typeof(int));
	texpenselastview.defineColumn("paymentadate", typeof(DateTime));
	texpenselastview.defineColumn("doc", typeof(string));
	texpenselastview.defineColumn("docdate", typeof(DateTime));
	texpenselastview.defineColumn("description", typeof(string),false);
	texpenselastview.defineColumn("amount", typeof(decimal));
	texpenselastview.defineColumn("ayearstartamount", typeof(decimal));
	texpenselastview.defineColumn("curramount", typeof(decimal));
	texpenselastview.defineColumn("available", typeof(decimal));
	texpenselastview.defineColumn("idregistrypaymethod", typeof(int));
	texpenselastview.defineColumn("idpaymethod", typeof(int));
	texpenselastview.defineColumn("iban", typeof(string));
	texpenselastview.defineColumn("cin", typeof(string));
	texpenselastview.defineColumn("idbank", typeof(string));
	texpenselastview.defineColumn("idcab", typeof(string));
	texpenselastview.defineColumn("cc", typeof(string));
	texpenselastview.defineColumn("iddeputy", typeof(int));
	texpenselastview.defineColumn("deputy", typeof(string));
	texpenselastview.defineColumn("refexternaldoc", typeof(string));
	texpenselastview.defineColumn("biccode", typeof(string));
	texpenselastview.defineColumn("paymethod_flag", typeof(int));
	texpenselastview.defineColumn("paymethod_allowdeputy", typeof(string));
	texpenselastview.defineColumn("extracode", typeof(string));
	texpenselastview.defineColumn("paymentdescr", typeof(string));
	texpenselastview.defineColumn("idser", typeof(int));
	texpenselastview.defineColumn("service", typeof(string));
	texpenselastview.defineColumn("servicestart", typeof(DateTime));
	texpenselastview.defineColumn("servicestop", typeof(DateTime));
	texpenselastview.defineColumn("ivaamount", typeof(decimal));
	texpenselastview.defineColumn("flag", typeof(byte));
	texpenselastview.defineColumn("totflag", typeof(byte));
	texpenselastview.defineColumn("flagarrear", typeof(string),true,true);
	texpenselastview.defineColumn("autokind", typeof(byte));
	texpenselastview.defineColumn("idpayment", typeof(int));
	texpenselastview.defineColumn("expiration", typeof(DateTime));
	texpenselastview.defineColumn("adate", typeof(DateTime),false);
	texpenselastview.defineColumn("autocode", typeof(int));
	texpenselastview.defineColumn("idclawback", typeof(int));
	texpenselastview.defineColumn("clawback", typeof(string));
	texpenselastview.defineColumn("nbill", typeof(int));
	texpenselastview.defineColumn("idpay", typeof(int));
	texpenselastview.defineColumn("txt", typeof(string));
	texpenselastview.defineColumn("cu", typeof(string),false);
	texpenselastview.defineColumn("ct", typeof(DateTime),false);
	texpenselastview.defineColumn("lu", typeof(string),false);
	texpenselastview.defineColumn("lt", typeof(DateTime),false);
	texpenselastview.defineColumn("idsor01", typeof(int));
	texpenselastview.defineColumn("idsor02", typeof(int));
	texpenselastview.defineColumn("idsor03", typeof(int));
	texpenselastview.defineColumn("idsor04", typeof(int));
	texpenselastview.defineColumn("idsor05", typeof(int));
	texpenselastview.defineColumn("idchargehandling", typeof(int));
	texpenselastview.defineColumn("net", typeof(decimal));
	Tables.Add(texpenselastview);
	texpenselastview.defineKey("idexp");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","automanagekind","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","flag_autodocnumbering","assetload_flag","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flag_paymentamount","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","taxvaliditykind","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idivapayperiodicity","idregauto","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","flagbank_grouping","fin_kind","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// FIN /////////////////////////////////
	var tfin= new finTable();
	tfin.addBaseColumns("ayear","codefin","ct","cu","lt","lu","printingorder","rtf","title","txt","nlevel","idfin","paridfin","flag");
	Tables.Add(tfin);
	tfin.defineKey("idfin");

	//////////////////// EXPENSE1 /////////////////////////////////
	var texpense1= new MetaTable("expense1");
	texpense1.defineColumn("adate", typeof(DateTime),false);
	texpense1.defineColumn("ct", typeof(DateTime),false);
	texpense1.defineColumn("cu", typeof(string),false);
	texpense1.defineColumn("description", typeof(string),false);
	texpense1.defineColumn("doc", typeof(string));
	texpense1.defineColumn("docdate", typeof(DateTime));
	texpense1.defineColumn("expiration", typeof(DateTime));
	texpense1.defineColumn("idreg", typeof(int));
	texpense1.defineColumn("lt", typeof(DateTime),false);
	texpense1.defineColumn("lu", typeof(string),false);
	texpense1.defineColumn("nmov", typeof(int),false);
	texpense1.defineColumn("rtf", typeof(Byte[]));
	texpense1.defineColumn("txt", typeof(string));
	texpense1.defineColumn("ymov", typeof(short),false);
	texpense1.defineColumn("idclawback", typeof(int));
	texpense1.defineColumn("idman", typeof(int));
	texpense1.defineColumn("nphase", typeof(byte),false);
	texpense1.defineColumn("idexp", typeof(int),false);
	texpense1.defineColumn("parentidexp", typeof(int));
	texpense1.defineColumn("idpayment", typeof(int));
	texpense1.defineColumn("idformerexpense", typeof(int));
	texpense1.defineColumn("autokind", typeof(byte));
	texpense1.defineColumn("autocode", typeof(int));
	Tables.Add(texpense1);
	texpense1.defineKey("idexp");

	//////////////////// PAYDISPOSITION /////////////////////////////////
	var tpaydisposition= new paydispositionTable();
	tpaydisposition.addBaseColumns("idpaydisposition","ayear","description","motive","kpay","ct","cu","lt","lu");
	Tables.Add(tpaydisposition);
	tpaydisposition.defineKey("idpaydisposition");

	//////////////////// PAYDISPOSITIONDETAIL /////////////////////////////////
	var tpaydispositiondetail= new paydispositiondetailTable();
	tpaydispositiondetail.addBaseColumns("idpaydisposition","iddetail","surname","forename","gender","birthdate","idcity","idnation","cf","address","location","cap","abi","cab","motive","amount","ct","cu","lt","lu");
	Tables.Add(tpaydispositiondetail);
	tpaydispositiondetail.defineKey("idpaydisposition", "iddetail");

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

	#endregion


	#region DataRelation creation
	this.defineRelation("paydisposition_paydispositiondetail","paydisposition","paydispositiondetail","idpaydisposition");
	this.defineRelation("payment_paydisposition","payment","paydisposition","kpay");
	this.defineRelation("paymentexpenselastview","payment","expenselastview","kpay");
	this.defineRelation("expenseview_expensesorted","expenselastview","expensesorted","idexp");
	this.defineRelation("paymentpayment_bankview","payment","payment_bankview","kpay");
	this.defineRelation("expense1_banktransaction","expense1","banktransaction","idexp");
	this.defineRelation("paymentbanktransaction","payment","banktransaction","kpay");
	this.defineRelation("expenseviewexpensevar","expenselastview","expensevar","idexp");
	var cPar = new []{sorting05.Columns["idsor"]};
	var cChild = new []{payment.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_payment",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{payment.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_payment",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{payment.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_payment",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{payment.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_payment",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{payment.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_payment",cPar,cChild,false));

	this.defineRelation("registrypayment","registry","payment","idreg");
	this.defineRelation("treasurerpayment","treasurer","payment","idtreasurer");
	this.defineRelation("stamphandlingpayment","stamphandling","payment","idstamphandling");
	this.defineRelation("managerpayment","manager","payment","idman");
	this.defineRelation("paymenttransmissionpayment","paymenttransmission","payment","kpaymenttransmission");
	this.defineRelation("fin_payment","fin","payment","idfin");
	#endregion

}
}
}
