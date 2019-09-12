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
using meta_proceeds;
using meta_fin;
using meta_manager;
using meta_treasurer;
using meta_proceedstransmission;
using meta_registry;
using meta_incomevar;
using meta_banktransaction;
using meta_sortingkind;
using meta_incomesorted;
using meta_config;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace proceeds_reversalemultipla {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Documento di incasso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public proceedsTable proceeds 		=> (proceedsTable)Tables["proceeds"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finTable fin 		=> (finTable)Tables["fin"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public managerTable manager 		=> (managerTable)Tables["manager"];

	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public treasurerTable treasurer 		=> (treasurerTable)Tables["treasurer"];

	///<summary>
	///Distinta di trasmissione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public proceedstransmissionTable proceedstransmission 		=> (proceedstransmissionTable)Tables["proceedstransmission"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomelastview 		=> (MetaTable)Tables["incomelastview"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomephase 		=> (MetaTable)Tables["incomephase"];

	///<summary>
	///Variazione movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomevarTable incomevar 		=> (incomevarTable)Tables["incomevar"];

	///<summary>
	///Movimento bancario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public banktransactionTable banktransaction 		=> (banktransactionTable)Tables["banktransaction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable proceeds_bankview 		=> (MetaTable)Tables["proceeds_bankview"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingkindTable sortingkind 		=> (sortingkindTable)Tables["sortingkind"];

	///<summary>
	///Classificazione Movimenti di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomesortedTable incomesorted 		=> (incomesortedTable)Tables["incomesorted"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable income1 		=> (MetaTable)Tables["income1"];

	///<summary>
	///Trattamento del bollo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stamphandling 		=> (MetaTable)Tables["stamphandling"];

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
	//////////////////// PROCEEDS /////////////////////////////////
	var tproceeds= new proceedsTable();
	tproceeds.addBaseColumns("kpro","ypro","npro","npro_treasurer","kproceedstransmission","idtreasurer","flag","idreg","idfin","idman","adate","printdate","txt","rtf","cu","ct","lu","lt","annulmentdate","idstamphandling","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tproceeds);
	tproceeds.defineKey("kpro");

	//////////////////// FIN /////////////////////////////////
	var tfin= new finTable();
	tfin.addBaseColumns("idfin","ayear","codefin","ct","cu","lt","lu","printingorder","rtf","title","txt","nlevel","paridfin","flag");
	Tables.Add(tfin);
	tfin.defineKey("idfin");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new managerTable();
	tmanager.addBaseColumns("idman","title","iddivision","email","phonenumber","userweb","passwordweb","txt","rtf","cu","ct","lu","lt","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new treasurerTable();
	ttreasurer.addBaseColumns("idtreasurer","description","flagdefault","cin","idbank","idcab","cc","address","cap","city","country","phoneprefix","phonenumber","faxprefix","faxnumber","flagfruitful","idsor01","idsor02","idsor03","idsor04","idsor05","cu","ct","lu","lt","active");
	Tables.Add(ttreasurer);
	ttreasurer.defineKey("idtreasurer");

	//////////////////// PROCEEDSTRANSMISSION /////////////////////////////////
	var tproceedstransmission= new proceedstransmissionTable();
	tproceedstransmission.addBaseColumns("kproceedstransmission","yproceedstransmission","nproceedstransmission","idman","idtreasurer","transmissiondate","cu","ct","lu","lt");
	Tables.Add(tproceedstransmission);
	tproceedstransmission.defineKey("kproceedstransmission");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","annotation","birthdate","gender","surname","forename","foreigncf","active","txt","rtf","cu","ct","lu","lt");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// INCOMELASTVIEW /////////////////////////////////
	var tincomelastview= new MetaTable("incomelastview");
	tincomelastview.defineColumn("idinc", typeof(int),false);
	tincomelastview.defineColumn("nphase", typeof(byte),false);
	tincomelastview.defineColumn("phase", typeof(string),false);
	tincomelastview.defineColumn("ymov", typeof(short),false);
	tincomelastview.defineColumn("nmov", typeof(int),false);
	tincomelastview.defineColumn("parentymov", typeof(short));
	tincomelastview.defineColumn("parentnmov", typeof(int));
	tincomelastview.defineColumn("parentidinc", typeof(int));
	tincomelastview.defineColumn("ayear", typeof(short),false);
	tincomelastview.defineColumn("idfin", typeof(int));
	tincomelastview.defineColumn("codefin", typeof(string));
	tincomelastview.defineColumn("finance", typeof(string));
	tincomelastview.defineColumn("idupb", typeof(string));
	tincomelastview.defineColumn("codeupb", typeof(string));
	tincomelastview.defineColumn("upb", typeof(string));
	tincomelastview.defineColumn("idreg", typeof(int));
	tincomelastview.defineColumn("registry", typeof(string));
	tincomelastview.defineColumn("idman", typeof(int));
	tincomelastview.defineColumn("manager", typeof(string));
	tincomelastview.defineColumn("kpro", typeof(int));
	tincomelastview.defineColumn("ypro", typeof(short));
	tincomelastview.defineColumn("npro", typeof(int));
	tincomelastview.defineColumn("doc", typeof(string));
	tincomelastview.defineColumn("docdate", typeof(DateTime));
	tincomelastview.defineColumn("description", typeof(string),false);
	tincomelastview.defineColumn("amount", typeof(decimal));
	tincomelastview.defineColumn("ayearstartamount", typeof(decimal));
	tincomelastview.defineColumn("curramount", typeof(decimal));
	tincomelastview.defineColumn("available", typeof(decimal));
	tincomelastview.defineColumn("unpartitioned", typeof(decimal));
	tincomelastview.defineColumn("flag", typeof(byte));
	tincomelastview.defineColumn("totflag", typeof(byte),false);
	tincomelastview.defineColumn("flagarrear", typeof(string));
	tincomelastview.defineColumn("autokind", typeof(byte));
	tincomelastview.defineColumn("autocode", typeof(int));
	tincomelastview.defineColumn("idpayment", typeof(int));
	tincomelastview.defineColumn("expiration", typeof(DateTime));
	tincomelastview.defineColumn("adate", typeof(DateTime),false);
	tincomelastview.defineColumn("nbill", typeof(int));
	tincomelastview.defineColumn("idpro", typeof(int));
	tincomelastview.defineColumn("cu", typeof(string),false);
	tincomelastview.defineColumn("ct", typeof(DateTime),false);
	tincomelastview.defineColumn("lu", typeof(string),false);
	tincomelastview.defineColumn("lt", typeof(DateTime),false);
	tincomelastview.defineColumn("idsor01", typeof(int));
	tincomelastview.defineColumn("idsor02", typeof(int));
	tincomelastview.defineColumn("idsor03", typeof(int));
	tincomelastview.defineColumn("idsor04", typeof(int));
	tincomelastview.defineColumn("idsor05", typeof(int));
	Tables.Add(tincomelastview);
	tincomelastview.defineKey("idinc");

	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new MetaTable("incomephase");
	tincomephase.defineColumn("nphase", typeof(byte),false);
	tincomephase.defineColumn("description", typeof(string),false);
	tincomephase.defineColumn("cu", typeof(string),false);
	tincomephase.defineColumn("ct", typeof(DateTime),false);
	tincomephase.defineColumn("lu", typeof(string),false);
	tincomephase.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tincomephase);
	tincomephase.defineKey("nphase");

	//////////////////// INCOMEVAR /////////////////////////////////
	var tincomevar= new incomevarTable();
	tincomevar.addBaseColumns("idinc","nvar","yvar","description","amount","doc","docdate","adate","txt","rtf","cu","ct","lu","lt","autokind","idinvkind","ninv","yinv");
	Tables.Add(tincomevar);
	tincomevar.defineKey("idinc", "nvar");

	//////////////////// BANKTRANSACTION /////////////////////////////////
	var tbanktransaction= new banktransactionTable();
	tbanktransaction.addBaseColumns("yban","nban","kpro","kind","bankreference","transactiondate","valuedate","amount","kpay","cu","ct","lu","lt","idexp","idinc","idpay","idpro","idbankimport");
	tbanktransaction.defineColumn("!nmov", typeof(int));
	Tables.Add(tbanktransaction);
	tbanktransaction.defineKey("yban", "nban", "kpro");

	//////////////////// PROCEEDS_BANKVIEW /////////////////////////////////
	var tproceeds_bankview= new MetaTable("proceeds_bankview");
	tproceeds_bankview.defineColumn("kpro", typeof(int),false);
	tproceeds_bankview.defineColumn("ypro", typeof(short),false);
	tproceeds_bankview.defineColumn("npro", typeof(int),false);
	tproceeds_bankview.defineColumn("idpro", typeof(int),false);
	tproceeds_bankview.defineColumn("idreg", typeof(int),false);
	tproceeds_bankview.defineColumn("registry", typeof(string),false);
	tproceeds_bankview.defineColumn("description", typeof(string));
	tproceeds_bankview.defineColumn("amount", typeof(decimal),false);
	tproceeds_bankview.defineColumn("ct", typeof(DateTime),false);
	tproceeds_bankview.defineColumn("cu", typeof(string),false);
	tproceeds_bankview.defineColumn("lt", typeof(DateTime),false);
	tproceeds_bankview.defineColumn("lu", typeof(string),false);
	Tables.Add(tproceeds_bankview);
	tproceeds_bankview.defineKey("kpro", "idpro");

	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new sortingkindTable();
	tsortingkind.addBaseColumns("idsorkind","active","ct","cu","description","flagdate","flag","forcedN1","forcedN2","forcedN3","forcedN4","forcedN5","forcedS1","forcedS2","forcedS3","forcedS4","forcedS5","forcedv1","forcedv2","forcedv3","forcedv4","forcedv5","labelfordate","labeln1","labeln2","labeln3","labeln4","labeln5","labels1","labels2","labels3","labels4","labels5","labelv1","labelv2","labelv3","labelv4","labelv5","lockedN1","lockedN2","lockedN3","lockedN4","lockedN5","lockedS1","lockedS2","lockedS3","lockedS4","lockedS5","lockedv1","lockedv2","lockedv3","lockedv4","lockedv5","lt","lu","nodatelabel","nphaseexpense","nphaseincome","totalexpression");
	Tables.Add(tsortingkind);
	tsortingkind.defineKey("idsorkind");

	//////////////////// INCOMESORTED /////////////////////////////////
	var tincomesorted= new incomesortedTable();
	tincomesorted.addBaseColumns("idinc","idsor","idsubclass","amount","ayear","ct","cu","description","flagnodate","lt","lu","paridsor","paridsubclass","rtf","start","stop","tobecontinued","txt","valuen1","valuen2","valuen3","valuen4","valuen5","values1","values2","values3","values4","values5","valuev1","valuev2","valuev3","valuev4","valuev5");
	Tables.Add(tincomesorted);
	tincomesorted.defineKey("idinc", "idsor", "idsubclass");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","automanagekind","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","flag_autodocnumbering","assetload_flag","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flag_paymentamount","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","taxvaliditykind","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idivapayperiodicity","idregauto","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","flagbank_grouping","fin_kind","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// INCOME1 /////////////////////////////////
	var tincome1= new MetaTable("income1");
	tincome1.defineColumn("adate", typeof(DateTime),false);
	tincome1.defineColumn("ct", typeof(DateTime),false);
	tincome1.defineColumn("cu", typeof(string),false);
	tincome1.defineColumn("description", typeof(string),false);
	tincome1.defineColumn("doc", typeof(string));
	tincome1.defineColumn("docdate", typeof(DateTime));
	tincome1.defineColumn("expiration", typeof(DateTime));
	tincome1.defineColumn("idreg", typeof(int));
	tincome1.defineColumn("lt", typeof(DateTime),false);
	tincome1.defineColumn("lu", typeof(string),false);
	tincome1.defineColumn("nmov", typeof(int),false);
	tincome1.defineColumn("rtf", typeof(Byte[]));
	tincome1.defineColumn("txt", typeof(string));
	tincome1.defineColumn("ymov", typeof(short),false);
	tincome1.defineColumn("idman", typeof(int));
	tincome1.defineColumn("nphase", typeof(byte),false);
	tincome1.defineColumn("idpayment", typeof(int));
	tincome1.defineColumn("idinc", typeof(int),false);
	tincome1.defineColumn("parentidinc", typeof(int));
	tincome1.defineColumn("autokind", typeof(byte));
	tincome1.defineColumn("autocode", typeof(int));
	Tables.Add(tincome1);
	tincome1.defineKey("idinc");

	//////////////////// STAMPHANDLING /////////////////////////////////
	var tstamphandling= new MetaTable("stamphandling");
	tstamphandling.defineColumn("active", typeof(string));
	tstamphandling.defineColumn("ct", typeof(DateTime),false);
	tstamphandling.defineColumn("cu", typeof(string),false);
	tstamphandling.defineColumn("description", typeof(string),false);
	tstamphandling.defineColumn("flagdefault", typeof(string),false);
	tstamphandling.defineColumn("lt", typeof(DateTime),false);
	tstamphandling.defineColumn("lu", typeof(string),false);
	tstamphandling.defineColumn("handlingbankcode", typeof(string));
	tstamphandling.defineColumn("idstamphandling", typeof(int),false);
	Tables.Add(tstamphandling);
	tstamphandling.defineKey("idstamphandling");

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
	this.defineRelation("incomelastview_incomesorted","incomelastview","incomesorted","idinc");
	this.defineRelation("proceedsproceeds_bankview","proceeds","proceeds_bankview","kpro");
	this.defineRelation("income1_banktransaction","income1","banktransaction","idinc");
	this.defineRelation("proceedsbanktransaction","proceeds","banktransaction","kpro");
	this.defineRelation("incomelastviewincomevar","incomelastview","incomevar","idinc");
	this.defineRelation("proceedsincomelastview","proceeds","incomelastview","kpro");
	var cPar = new []{sorting05.Columns["idsor"]};
	var cChild = new []{proceeds.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_proceeds",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{proceeds.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_proceeds",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{proceeds.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_proceeds",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{proceeds.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_proceeds",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{proceeds.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_proceeds",cPar,cChild,false));

	this.defineRelation("treasurerproceeds","treasurer","proceeds","idtreasurer");
	this.defineRelation("finproceeds","fin","proceeds","idfin");
	this.defineRelation("registryproceeds","registry","proceeds","idreg");
	this.defineRelation("managerproceeds","manager","proceeds","idman");
	this.defineRelation("proceedstransmissionproceeds","proceedstransmission","proceeds","kproceedstransmission");
	this.defineRelation("FK_stamphandling_proceeds","stamphandling","proceeds","idstamphandling");
	#endregion

}
}
}
