
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
using meta_paydisposition;
using meta_paydispositiondetail;
using meta_payment;
using meta_expenseyear;
using meta_fin;
using meta_upb;
using meta_registry;
using meta_expensesorted;
using meta_sortingkind;
using meta_incomeyear;
using meta_incomesorted;
using meta_expense;
using meta_income;
using meta_config;
using meta_expenselast;
using meta_incomelast;
using meta_sorting;
using meta_incomevar;
using meta_manager;
using meta_treasurer;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace paydisposition_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public paydispositionTable paydisposition 		=> (paydispositionTable)Tables["paydisposition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public paydispositiondetailTable paydispositiondetail 		=> (paydispositiondetailTable)Tables["paydispositiondetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public paymentTable payment 		=> (paymentTable)Tables["payment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable paydispositionview 		=> (MetaTable)Tables["paydispositionview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbimotive 		=> (MetaTable)Tables["cbimotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenseyearTable expenseyear 		=> (expenseyearTable)Tables["expenseyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finTable fin 		=> (finTable)Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensephase 		=> (MetaTable)Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expensesortedTable expensesorted 		=> (expensesortedTable)Tables["expensesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingkindTable sortingkind 		=> (sortingkindTable)Tables["sortingkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomephase 		=> (MetaTable)Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomeyearTable incomeyear 		=> (incomeyearTable)Tables["incomeyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomesortedTable incomesorted 		=> (incomesortedTable)Tables["incomesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenseTable expense 		=> (expenseTable)Tables["expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomeTable income 		=> (incomeTable)Tables["income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenselastTable expenselast 		=> (expenselastTable)Tables["expenselast"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomelastTable incomelast 		=> (incomelastTable)Tables["incomelast"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting 		=> (sortingTable)Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomebill 		=> (MetaTable)Tables["incomebill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomevarTable incomevar 		=> (incomevarTable)Tables["incomevar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public managerTable manager 		=> (managerTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable chargehandling 		=> (MetaTable)Tables["chargehandling"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public treasurerTable treasurer 		=> (treasurerTable)Tables["treasurer"];

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
	//////////////////// PAYDISPOSITION /////////////////////////////////
	var tpaydisposition= new paydispositionTable();
	tpaydisposition.addBaseColumns("idpaydisposition","ayear","description","motive","kpay","ct","cu","lt","lu","idcbimotive");
	Tables.Add(tpaydisposition);
	tpaydisposition.defineKey("idpaydisposition");

	//////////////////// PAYDISPOSITIONDETAIL /////////////////////////////////
	var tpaydispositiondetail= new paydispositiondetailTable();
	tpaydispositiondetail.addBaseColumns("idpaydisposition","iddetail","surname","forename","birthdate","cf","location","province","cap","abi","cab","motive","amount","idcity","idnation","gender","address","ct","cu","lt","lu","email","idcbimotive","iban","cc","cin","flaghuman","title","p_iva","paymentcode","paymethodcode","academicyear","calendaryear","degreekind","degreecode","flagtaxrefund","idexp","flag","idchargehandling");
	tpaydispositiondetail.defineColumn("!ymov", typeof(string));
	tpaydispositiondetail.defineColumn("!nmov", typeof(string));
	tpaydispositiondetail.defineColumn("!phase", typeof(string));
	tpaydispositiondetail.defineColumn("!nphase", typeof(byte));
	Tables.Add(tpaydispositiondetail);
	tpaydispositiondetail.defineKey("idpaydisposition", "iddetail");

	//////////////////// PAYMENT /////////////////////////////////
	var tpayment= new paymentTable();
	tpayment.addBaseColumns("npay","ypay","npay_treasurer","adate","annulmentdate","ct","cu","idreg","lt","lu","printdate","rtf","txt","idfin","idman","idstamphandling","idtreasurer","flag","kpay","kpaymenttransmission","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tpayment);
	tpayment.defineKey("kpay");

	//////////////////// PAYDISPOSITIONVIEW /////////////////////////////////
	var tpaydispositionview= new MetaTable("paydispositionview");
	tpaydispositionview.defineColumn("idpaydisposition", typeof(int),false);
	tpaydispositionview.defineColumn("ayear", typeof(short),false);
	tpaydispositionview.defineColumn("description", typeof(string));
	tpaydispositionview.defineColumn("motive", typeof(string));
	tpaydispositionview.defineColumn("kpay", typeof(int));
	tpaydispositionview.defineColumn("ypay", typeof(short));
	tpaydispositionview.defineColumn("npay", typeof(int));
	tpaydispositionview.defineColumn("total", typeof(decimal),false);
	tpaydispositionview.defineColumn("ct", typeof(DateTime),false);
	tpaydispositionview.defineColumn("cu", typeof(string),false);
	tpaydispositionview.defineColumn("lt", typeof(DateTime),false);
	tpaydispositionview.defineColumn("lu", typeof(string),false);
	Tables.Add(tpaydispositionview);

	//////////////////// CBIMOTIVE /////////////////////////////////
	var tcbimotive= new MetaTable("cbimotive");
	tcbimotive.defineColumn("idcbimotive", typeof(int),false);
	tcbimotive.defineColumn("codemotive", typeof(string),false);
	tcbimotive.defineColumn("description", typeof(string));
	tcbimotive.defineColumn("ct", typeof(DateTime),false);
	tcbimotive.defineColumn("lt", typeof(DateTime),false);
	tcbimotive.defineColumn("cu", typeof(string),false);
	tcbimotive.defineColumn("lu", typeof(string),false);
	Tables.Add(tcbimotive);
	tcbimotive.defineKey("idcbimotive");

	//////////////////// EXPENSEYEAR /////////////////////////////////
	var texpenseyear= new expenseyearTable();
	texpenseyear.addBaseColumns("ayear","idexp","amount","ct","cu","idfin","idupb","lt","lu");
	Tables.Add(texpenseyear);
	texpenseyear.defineKey("ayear", "idexp");

	//////////////////// FIN /////////////////////////////////
	var tfin= new finTable();
	tfin.addBaseColumns("idfin","codefin");
	Tables.Add(tfin);
	tfin.defineKey("idfin");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new MetaTable("expensephase");
	texpensephase.defineColumn("nphase", typeof(byte),false);
	texpensephase.defineColumn("description", typeof(string),false);
	Tables.Add(texpensephase);
	texpensephase.defineKey("nphase");

	//////////////////// EXPENSESORTED /////////////////////////////////
	var texpensesorted= new expensesortedTable();
	texpensesorted.addBaseColumns("idexp","idsor","idsubclass","amount","ayear","ct","cu","description","flagnodate","lt","lu","paridsor","paridsubclass","rtf","start","stop","tobecontinued","txt","valuen1","valuen2","valuen3","valuen4","valuen5","values1","values2","values3","values4","values5","valuev1","valuev2","valuev3","valuev4","valuev5","originalamount");
	Tables.Add(texpensesorted);
	texpensesorted.defineKey("idexp", "idsor", "idsubclass");

	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new sortingkindTable();
	tsortingkind.addBaseColumns("idsorkind","active","ct","cu","description","flagdate","forcedN1","forcedN2","forcedN3","forcedN4","forcedN5","forcedS1","forcedS2","forcedS3","forcedS4","forcedS5","forcedv1","forcedv2","forcedv3","forcedv4","forcedv5","labelfordate","labeln1","labeln2","labeln3","labeln4","labeln5","labels1","labels2","labels3","labels4","labels5","labelv1","labelv2","labelv3","labelv4","labelv5","lockedN1","lockedN2","lockedN3","lockedN4","lockedN5","lockedS1","lockedS2","lockedS3","lockedS4","lockedS5","lockedv1","lockedv2","lockedv3","lockedv4","lockedv5","lt","lu","nodatelabel","nphaseexpense","nphaseincome","totalexpression");
	Tables.Add(tsortingkind);
	tsortingkind.defineKey("idsorkind");

	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new MetaTable("incomephase");
	tincomephase.defineColumn("nphase", typeof(byte),false);
	tincomephase.defineColumn("description", typeof(string),false);
	Tables.Add(tincomephase);
	tincomephase.defineKey("nphase");

	//////////////////// INCOMEYEAR /////////////////////////////////
	var tincomeyear= new incomeyearTable();
	tincomeyear.addBaseColumns("ayear","idinc","amount","ct","cu","idfin","idupb","lt","lu");
	Tables.Add(tincomeyear);
	tincomeyear.defineKey("idinc", "ayear");

	//////////////////// INCOMESORTED /////////////////////////////////
	var tincomesorted= new incomesortedTable();
	tincomesorted.addBaseColumns("idinc","idsor","idsubclass","amount","ayear","ct","cu","description","flagnodate","lt","lu","paridsor","paridsubclass","rtf","start","stop","tobecontinued","txt","valuen1","valuen2","valuen3","valuen4","valuen5","values1","values2","values3","values4","values5","valuev1","valuev2","valuev3","valuev4","valuev5","originalamount");
	Tables.Add(tincomesorted);
	tincomesorted.defineKey("idinc", "idsor", "idsubclass");

	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new expenseTable();
	texpense.addBaseColumns("adate","ct","cu","description","doc","docdate","expiration","idreg","lt","lu","nmov","rtf","txt","ymov","idclawback","idman","nphase","idexp","parentidexp","idpayment","idformerexpense","autokind","autocode");
	Tables.Add(texpense);
	texpense.defineKey("idexp");

	//////////////////// INCOME /////////////////////////////////
	var tincome= new incomeTable();
	tincome.addBaseColumns("adate","ct","cu","description","doc","docdate","expiration","idreg","lt","lu","nmov","rtf","txt","ymov","idman","nphase","idpayment","idinc","parentidinc","autokind","autocode");
	Tables.Add(tincome);
	tincome.defineKey("idinc");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idivapayperiodicity","idregauto","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// EXPENSELAST /////////////////////////////////
	var texpenselast= new expenselastTable();
	texpenselast.addBaseColumns("idexp","cc","cin","ct","cu","flag","iban","idbank","idcab","iddeputy","idpay","idpaymethod","idregistrypaymethod","idser","ivaamount","lt","lu","nbill","paymentdescr","servicestart","servicestop","refexternaldoc","idaccdebit","biccode","paymethod_flag","paymethod_allowdeputy","extracode","idchargehandling");
	Tables.Add(texpenselast);
	texpenselast.defineKey("idexp");

	//////////////////// INCOMELAST /////////////////////////////////
	var tincomelast= new incomelastTable();
	tincomelast.addBaseColumns("idinc","ct","cu","flag","idpro","lt","lu","nbill","idacccredit");
	Tables.Add(tincomelast);
	tincomelast.defineKey("idinc");

	//////////////////// SORTING /////////////////////////////////
	var tsorting= new sortingTable();
	tsorting.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel");
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	//////////////////// INCOMEBILL /////////////////////////////////
	var tincomebill= new MetaTable("incomebill");
	tincomebill.defineColumn("idinc", typeof(int),false);
	tincomebill.defineColumn("ybill", typeof(short),false);
	tincomebill.defineColumn("nbill", typeof(int),false);
	tincomebill.defineColumn("amount", typeof(decimal),false);
	tincomebill.defineColumn("lu", typeof(string),false);
	tincomebill.defineColumn("lt", typeof(DateTime),false);
	tincomebill.defineColumn("cu", typeof(string),false);
	tincomebill.defineColumn("ct", typeof(DateTime),false);
	Tables.Add(tincomebill);
	tincomebill.defineKey("idinc", "ybill", "nbill");

	//////////////////// INCOMEVAR /////////////////////////////////
	var tincomevar= new incomevarTable();
	tincomevar.addBaseColumns("idinc","nvar","yvar","description","amount","doc","docdate","adate","txt","rtf","cu","ct","lu","lt","autokind","idinvkind","ninv","yinv");
	Tables.Add(tincomevar);
	tincomevar.defineKey("idinc", "nvar");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new managerTable();
	tmanager.addBaseColumns("idman","title","iddivision","email","phonenumber","userweb","passwordweb","txt","rtf","cu","ct","lu","lt","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// CHARGEHANDLING /////////////////////////////////
	var tchargehandling= new MetaTable("chargehandling");
	tchargehandling.defineColumn("active", typeof(string));
	tchargehandling.defineColumn("ct", typeof(DateTime),false);
	tchargehandling.defineColumn("cu", typeof(string),false);
	tchargehandling.defineColumn("description", typeof(string),false);
	tchargehandling.defineColumn("lt", typeof(DateTime),false);
	tchargehandling.defineColumn("lu", typeof(string),false);
	tchargehandling.defineColumn("handlingbankcode", typeof(string));
	tchargehandling.defineColumn("flag", typeof(int));
	tchargehandling.defineColumn("idchargehandling", typeof(int),false);
	tchargehandling.defineColumn("motive", typeof(string));
	tchargehandling.defineColumn("payment_kind", typeof(string));
	Tables.Add(tchargehandling);
	tchargehandling.defineKey("idchargehandling");

	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new treasurerTable();
	ttreasurer.addBaseColumns("address","agencycodefortransmission","cabcodefortransmission","cap","cc","cin","city","country","ct","cu","depcodefortransmission","description","faxnumber","faxprefix","flagdefault","idaccmotive_payment","idaccmotive_proceeds","idbank","idcab","lt","lu","phonenumber","phoneprefix","codetreasurer","idtreasurer","spexportexp","flagmultiexp","fileextension","spexportinc","iban","bic","flagfruitful","cccbi","cincbi","idbankcbi","idcabcbi","ibancbi","siacodecbi","reccbikind","trasmcode","flagbank_grouping","motivelen","motiveprefix","motiveseparator","annotations","flagedisp","idsor01","idsor02","idsor03","idsor04","idsor05","billcode","active","flag","header","savepath","departmentname_fe","idstruttura","enable_ndoc_treasurer","flussocrediticode","ftpuser","ftppassword","ftpaddress","pasvmode","ftpport","ftpdir","tramite_bt_code","tramite_agency_code","agency_istat_code");
	Tables.Add(ttreasurer);
	ttreasurer.defineKey("idtreasurer");

	#endregion


	#region DataRelation creation
	this.defineRelation("paydisposition_paydispositiondetail","paydisposition","paydispositiondetail","idpaydisposition");
	this.defineRelation("FK_cbimotive_paydisposition","cbimotive","paydisposition","idcbimotive");
	this.defineRelation("payment_paydisposition","payment","paydisposition","kpay");
	var cPar = new []{expense.Columns["idexp"]};
	var cChild = new []{expense.Columns["parentidexp"]};
	Relations.Add(new DataRelation("expenseexpense",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{income.Columns["parentidinc"]};
	Relations.Add(new DataRelation("income_income",cPar,cChild,false));

	this.defineRelation("income_incomelast","income","incomelast","idinc");
	this.defineRelation("expense_expenselast","expense","expenselast","idexp");
	this.defineRelation("registry_income","registry","income","idreg");
	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{income.Columns["idpayment"]};
	Relations.Add(new DataRelation("expense_income",cPar,cChild,false));

	this.defineRelation("registryexpense","registry","expense","idreg");
	this.defineRelation("income_incomesorted","income","incomesorted","idinc");
	this.defineRelation("income_incomeyear","income","incomeyear","idinc");
	this.defineRelation("expenseexpensesorted","expense","expensesorted","idexp");
	this.defineRelation("finexpenseyear","fin","expenseyear","idfin");
	this.defineRelation("upbexpenseyear","upb","expenseyear","idupb");
	this.defineRelation("expenseexpenseyear","expense","expenseyear","idexp");
	this.defineRelation("income_incomebill","income","incomebill","idinc");
	this.defineRelation("income_incomevar","income","incomevar","idinc");
	this.defineRelation("expense_manager","expense","manager","idman");
	this.defineRelation("expense_paydispositiondetail","expense","paydispositiondetail","idexp");
	this.defineRelation("expensephase_expense","expensephase","expense","nphase");
	this.defineRelation("chargehandling_paydispositiondetail","chargehandling","paydispositiondetail","idchargehandling");
	#endregion

}
}
}
