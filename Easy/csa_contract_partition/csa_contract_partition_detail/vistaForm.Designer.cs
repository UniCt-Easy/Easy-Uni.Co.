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
using meta_account;
using meta_upb;
using meta_fin;
using meta_sorting;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace csa_contract_partition_detail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensephase 		=> (MetaTable)Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenseview 		=> (MetaTable)Tables["expenseview"];

	///<summary>
	///Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_contractkind 		=> (MetaTable)Tables["csa_contractkind"];

	///<summary>
	///Informazioni annuali su tipo contratto csa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_contractkindyear 		=> (MetaTable)Tables["csa_contractkindyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_contract_partition 		=> (MetaTable)Tables["csa_contract_partition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epexpview 		=> (MetaTable)Tables["epexpview"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account 		=> (accountTable)Tables["account"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finTable fin 		=> (finTable)Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fase_epexp 		=> (MetaTable)Tables["fase_epexp"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting 		=> (sortingTable)Tables["sorting"];

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
	EnforceConstraints = false;

	#region create DataTables
	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new MetaTable("expensephase");
	texpensephase.defineColumn("ct", typeof(DateTime),false);
	texpensephase.defineColumn("cu", typeof(string),false);
	texpensephase.defineColumn("description", typeof(string),false);
	texpensephase.defineColumn("lt", typeof(DateTime),false);
	texpensephase.defineColumn("lu", typeof(string),false);
	texpensephase.defineColumn("nphase", typeof(byte),false);
	Tables.Add(texpensephase);
	texpensephase.defineKey("nphase");

	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new MetaTable("expenseview");
	texpenseview.defineColumn("idexp", typeof(int),false);
	texpenseview.defineColumn("nphase", typeof(byte),false);
	texpenseview.defineColumn("phase", typeof(string),false);
	texpenseview.defineColumn("ymov", typeof(short),false);
	texpenseview.defineColumn("nmov", typeof(int),false);
	texpenseview.defineColumn("parentidexp", typeof(int));
	texpenseview.defineColumn("parentymov", typeof(short));
	texpenseview.defineColumn("parentnmov", typeof(int));
	texpenseview.defineColumn("idformerexpense", typeof(int));
	texpenseview.defineColumn("formerymov", typeof(short));
	texpenseview.defineColumn("formernmov", typeof(int));
	texpenseview.defineColumn("ayear", typeof(short),false);
	texpenseview.defineColumn("idfin", typeof(int));
	texpenseview.defineColumn("codefin", typeof(string));
	texpenseview.defineColumn("finance", typeof(string));
	texpenseview.defineColumn("idupb", typeof(string));
	texpenseview.defineColumn("codeupb", typeof(string));
	texpenseview.defineColumn("upb", typeof(string));
	texpenseview.defineColumn("idsor01", typeof(int));
	texpenseview.defineColumn("idsor02", typeof(int));
	texpenseview.defineColumn("idsor03", typeof(int));
	texpenseview.defineColumn("idsor04", typeof(int));
	texpenseview.defineColumn("idsor05", typeof(int));
	texpenseview.defineColumn("idreg", typeof(int));
	texpenseview.defineColumn("registry", typeof(string));
	texpenseview.defineColumn("cf", typeof(string));
	texpenseview.defineColumn("p_iva", typeof(string));
	texpenseview.defineColumn("idman", typeof(int));
	texpenseview.defineColumn("manager", typeof(string));
	texpenseview.defineColumn("kpay", typeof(int));
	texpenseview.defineColumn("ypay", typeof(short));
	texpenseview.defineColumn("npay", typeof(int));
	texpenseview.defineColumn("paymentadate", typeof(DateTime));
	texpenseview.defineColumn("doc", typeof(string));
	texpenseview.defineColumn("docdate", typeof(DateTime));
	texpenseview.defineColumn("description", typeof(string),false);
	texpenseview.defineColumn("amount", typeof(decimal));
	texpenseview.defineColumn("ayearstartamount", typeof(decimal));
	texpenseview.defineColumn("curramount", typeof(decimal));
	texpenseview.defineColumn("available", typeof(decimal));
	texpenseview.defineColumn("idregistrypaymethod", typeof(int));
	texpenseview.defineColumn("idpaymethod", typeof(int));
	texpenseview.defineColumn("iban", typeof(string));
	texpenseview.defineColumn("cin", typeof(string));
	texpenseview.defineColumn("idbank", typeof(string));
	texpenseview.defineColumn("idcab", typeof(string));
	texpenseview.defineColumn("cc", typeof(string));
	texpenseview.defineColumn("iddeputy", typeof(int));
	texpenseview.defineColumn("deputy", typeof(string));
	texpenseview.defineColumn("refexternaldoc", typeof(string));
	texpenseview.defineColumn("paymentdescr", typeof(string));
	texpenseview.defineColumn("idser", typeof(int));
	texpenseview.defineColumn("service", typeof(string));
	texpenseview.defineColumn("codeser", typeof(string));
	texpenseview.defineColumn("servicestart", typeof(DateTime));
	texpenseview.defineColumn("servicestop", typeof(DateTime));
	texpenseview.defineColumn("ivaamount", typeof(decimal));
	texpenseview.defineColumn("flag", typeof(byte));
	texpenseview.defineColumn("totflag", typeof(byte));
	texpenseview.defineColumn("flagarrear", typeof(string),true,true);
	texpenseview.defineColumn("autokind", typeof(byte));
	texpenseview.defineColumn("idpayment", typeof(int));
	texpenseview.defineColumn("expiration", typeof(DateTime));
	texpenseview.defineColumn("adate", typeof(DateTime),false);
	texpenseview.defineColumn("autocode", typeof(int));
	texpenseview.defineColumn("idclawback", typeof(int));
	texpenseview.defineColumn("clawback", typeof(string));
	texpenseview.defineColumn("clawbackref", typeof(string));
	texpenseview.defineColumn("nbill", typeof(int));
	texpenseview.defineColumn("idpay", typeof(int));
	texpenseview.defineColumn("npaymenttransmission", typeof(int));
	texpenseview.defineColumn("transmissiondate", typeof(DateTime));
	texpenseview.defineColumn("idaccdebit", typeof(string));
	texpenseview.defineColumn("codeaccdebit", typeof(string));
	texpenseview.defineColumn("cigcode", typeof(string));
	texpenseview.defineColumn("cupcode", typeof(string));
	texpenseview.defineColumn("txt", typeof(string));
	texpenseview.defineColumn("cu", typeof(string),false);
	texpenseview.defineColumn("ct", typeof(DateTime),false);
	texpenseview.defineColumn("lu", typeof(string),false);
	texpenseview.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(texpenseview);

	//////////////////// CSA_CONTRACTKIND /////////////////////////////////
	var tcsa_contractkind= new MetaTable("csa_contractkind");
	tcsa_contractkind.defineColumn("idcsa_contractkind", typeof(int),false);
	tcsa_contractkind.defineColumn("contractkindcode", typeof(string),false);
	tcsa_contractkind.defineColumn("ct", typeof(DateTime),false);
	tcsa_contractkind.defineColumn("cu", typeof(string),false);
	tcsa_contractkind.defineColumn("description", typeof(string),false);
	tcsa_contractkind.defineColumn("flagcr", typeof(string),false);
	tcsa_contractkind.defineColumn("flagkeepalive", typeof(string));
	tcsa_contractkind.defineColumn("lt", typeof(DateTime),false);
	tcsa_contractkind.defineColumn("lu", typeof(string),false);
	tcsa_contractkind.defineColumn("active", typeof(string));
	tcsa_contractkind.defineColumn("idunderwriting", typeof(int));
	Tables.Add(tcsa_contractkind);
	tcsa_contractkind.defineKey("idcsa_contractkind");

	//////////////////// CSA_CONTRACTKINDYEAR /////////////////////////////////
	var tcsa_contractkindyear= new MetaTable("csa_contractkindyear");
	tcsa_contractkindyear.defineColumn("idcsa_contractkind", typeof(int),false);
	tcsa_contractkindyear.defineColumn("ayear", typeof(short),false);
	tcsa_contractkindyear.defineColumn("idupb", typeof(string));
	tcsa_contractkindyear.defineColumn("idacc_main", typeof(string));
	tcsa_contractkindyear.defineColumn("idfin_main", typeof(int));
	tcsa_contractkindyear.defineColumn("ct", typeof(DateTime),false);
	tcsa_contractkindyear.defineColumn("cu", typeof(string),false);
	tcsa_contractkindyear.defineColumn("lt", typeof(DateTime),false);
	tcsa_contractkindyear.defineColumn("lu", typeof(string),false);
	tcsa_contractkindyear.defineColumn("idsor_siope_main", typeof(int));
	Tables.Add(tcsa_contractkindyear);
	tcsa_contractkindyear.defineKey("idcsa_contractkind", "ayear");

	//////////////////// CSA_CONTRACT_PARTITION /////////////////////////////////
	var tcsa_contract_partition= new MetaTable("csa_contract_partition");
	tcsa_contract_partition.defineColumn("idcsa_contract", typeof(int),false);
	tcsa_contract_partition.defineColumn("ayear", typeof(short),false);
	tcsa_contract_partition.defineColumn("ndetail", typeof(int),false);
	tcsa_contract_partition.defineColumn("quota", typeof(double));
	tcsa_contract_partition.defineColumn("ct", typeof(DateTime),false);
	tcsa_contract_partition.defineColumn("lt", typeof(DateTime),false);
	tcsa_contract_partition.defineColumn("cu", typeof(string),false);
	tcsa_contract_partition.defineColumn("lu", typeof(string),false);
	tcsa_contract_partition.defineColumn("idepexp", typeof(int));
	tcsa_contract_partition.defineColumn("idupb", typeof(string));
	tcsa_contract_partition.defineColumn("idacc", typeof(string));
	tcsa_contract_partition.defineColumn("idfin", typeof(int));
	tcsa_contract_partition.defineColumn("idexp", typeof(int));
	tcsa_contract_partition.defineColumn("idsor_siope", typeof(int));
	Tables.Add(tcsa_contract_partition);
	tcsa_contract_partition.defineKey("idcsa_contract", "ayear", "ndetail");

	//////////////////// EPEXPVIEW /////////////////////////////////
	var tepexpview= new MetaTable("epexpview");
	tepexpview.defineColumn("idepexp", typeof(int),false);
	tepexpview.defineColumn("yepexp", typeof(short),false);
	tepexpview.defineColumn("nepexp", typeof(int),false);
	tepexpview.defineColumn("nphase", typeof(short),false);
	tepexpview.defineColumn("phase", typeof(string),true,true);
	tepexpview.defineColumn("flagvariation", typeof(string));
	tepexpview.defineColumn("description", typeof(string),false);
	tepexpview.defineColumn("amount", typeof(decimal),false);
	tepexpview.defineColumn("amount2", typeof(decimal));
	tepexpview.defineColumn("amount3", typeof(decimal));
	tepexpview.defineColumn("amount4", typeof(decimal));
	tepexpview.defineColumn("amount5", typeof(decimal));
	tepexpview.defineColumn("amountwithsign", typeof(decimal),true,true);
	tepexpview.defineColumn("amountwithsign2", typeof(decimal),true,true);
	tepexpview.defineColumn("amountwithsign3", typeof(decimal),true,true);
	tepexpview.defineColumn("amountwithsign4", typeof(decimal),true,true);
	tepexpview.defineColumn("amountwithsign5", typeof(decimal),true,true);
	tepexpview.defineColumn("totamount", typeof(decimal),true,true);
	tepexpview.defineColumn("curramount", typeof(decimal));
	tepexpview.defineColumn("curramount2", typeof(decimal));
	tepexpview.defineColumn("curramount3", typeof(decimal));
	tepexpview.defineColumn("curramount4", typeof(decimal));
	tepexpview.defineColumn("curramount5", typeof(decimal));
	tepexpview.defineColumn("totcurramount", typeof(decimal),true,true);
	tepexpview.defineColumn("available", typeof(decimal),true,true);
	tepexpview.defineColumn("available2", typeof(decimal),true,true);
	tepexpview.defineColumn("available3", typeof(decimal),true,true);
	tepexpview.defineColumn("available4", typeof(decimal),true,true);
	tepexpview.defineColumn("available5", typeof(decimal),true,true);
	tepexpview.defineColumn("totavailable", typeof(decimal),true,true);
	tepexpview.defineColumn("totalcost", typeof(decimal),true,true);
	tepexpview.defineColumn("costavailable", typeof(decimal),true,true);
	tepexpview.defineColumn("totaldebit", typeof(decimal),true,true);
	tepexpview.defineColumn("ayear", typeof(short),false);
	tepexpview.defineColumn("idacc", typeof(string),false);
	tepexpview.defineColumn("codeacc", typeof(string),false);
	tepexpview.defineColumn("account", typeof(string),false);
	tepexpview.defineColumn("idupb", typeof(string),false);
	tepexpview.defineColumn("codeupb", typeof(string),false);
	tepexpview.defineColumn("upb", typeof(string),false);
	tepexpview.defineColumn("paridepexp", typeof(int));
	tepexpview.defineColumn("parentyepexp", typeof(short));
	tepexpview.defineColumn("parentnepexp", typeof(int));
	tepexpview.defineColumn("yliv1", typeof(short),true,true);
	tepexpview.defineColumn("nliv1", typeof(int),true,true);
	tepexpview.defineColumn("start", typeof(DateTime));
	tepexpview.defineColumn("stop", typeof(DateTime));
	tepexpview.defineColumn("adate", typeof(DateTime),false);
	tepexpview.defineColumn("idreg", typeof(int));
	tepexpview.defineColumn("registry", typeof(string));
	tepexpview.defineColumn("doc", typeof(string));
	tepexpview.defineColumn("docdate", typeof(DateTime));
	tepexpview.defineColumn("idman", typeof(int));
	tepexpview.defineColumn("manager", typeof(string));
	tepexpview.defineColumn("idrelated", typeof(string));
	tepexpview.defineColumn("flagaccountusage", typeof(int));
	tepexpview.defineColumn("rateiattivi", typeof(string),true,true);
	tepexpview.defineColumn("rateipassivi", typeof(string),true,true);
	tepexpview.defineColumn("riscontiattivi", typeof(string),true,true);
	tepexpview.defineColumn("riscontipassivi", typeof(string),true,true);
	tepexpview.defineColumn("debit", typeof(string),true,true);
	tepexpview.defineColumn("credit", typeof(string),true,true);
	tepexpview.defineColumn("cost", typeof(string),true,true);
	tepexpview.defineColumn("revenue", typeof(string),true,true);
	tepexpview.defineColumn("fixedassets", typeof(string),true,true);
	tepexpview.defineColumn("freeusesurplus", typeof(string),true,true);
	tepexpview.defineColumn("captiveusesurplus", typeof(string),true,true);
	tepexpview.defineColumn("reserve", typeof(string),true,true);
	tepexpview.defineColumn("provision", typeof(string),true,true);
	tepexpview.defineColumn("idaccmotive", typeof(string));
	tepexpview.defineColumn("codemotive", typeof(string));
	tepexpview.defineColumn("lt", typeof(DateTime),false);
	tepexpview.defineColumn("lu", typeof(string),false);
	tepexpview.defineColumn("ct", typeof(DateTime),false);
	tepexpview.defineColumn("cu", typeof(string),false);
	tepexpview.defineColumn("idsor01", typeof(int));
	tepexpview.defineColumn("idsor02", typeof(int));
	tepexpview.defineColumn("idsor03", typeof(int));
	tepexpview.defineColumn("idsor04", typeof(int));
	tepexpview.defineColumn("idsor05", typeof(int));
	Tables.Add(tepexpview);

	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new accountTable();
	taccount.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	Tables.Add(taccount);
	taccount.defineKey("idacc");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb","title","paridupb","idunderwriter","idman","requested","granted","previousappropriation","expiration","txt","rtf","cu","ct","lu","lt","assured","printingorder","active");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// FIN /////////////////////////////////
	var tfin= new finTable();
	tfin.addBaseColumns("ayear","codefin","ct","cu","lt","lu","printingorder","rtf","title","txt","idfin","paridfin","nlevel","flag");
	Tables.Add(tfin);
	tfin.defineKey("idfin");

	//////////////////// FASE_EPEXP /////////////////////////////////
	var tfase_epexp= new MetaTable("fase_epexp");
	tfase_epexp.defineColumn("nphase", typeof(int),false);
	tfase_epexp.defineColumn("descrizione", typeof(string));
	Tables.Add(tfase_epexp);
	tfase_epexp.defineKey("nphase");

	//////////////////// SORTING /////////////////////////////////
	var tsorting= new sortingTable();
	tsorting.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_csa_contractkindyear_csa_contractkind","csa_contractkind","csa_contractkindyear","idcsa_contractkind");
	this.defineRelation("epexpview_csa_contract_partition","epexpview","csa_contract_partition","idepexp","ayear");
	this.defineRelation("expenseview_csa_contract_partition","expenseview","csa_contract_partition","idexp","ayear");
	this.defineRelation("account_csa_contract_partition","account","csa_contract_partition","idacc");
	this.defineRelation("upb_csa_contract_partition","upb","csa_contract_partition","idupb");
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{csa_contract_partition.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_csa_contract_partition",cPar,cChild,false));

	this.defineRelation("fin_csa_contract_partition","fin","csa_contract_partition","idfin");
	#endregion

}
}
}
