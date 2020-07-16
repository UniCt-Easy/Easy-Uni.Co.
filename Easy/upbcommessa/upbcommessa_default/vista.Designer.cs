/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using meta_upbcommessa;
using meta_upb;
using meta_epupbkind;
using meta_epupbkindyear;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace upbcommessa_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Dati su commessa completata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbcommessaTable upbcommessa 		=> (upbcommessaTable)Tables["upbcommessa"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_cost 		=> (MetaTable)Tables["accmotive_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_deferredcost 		=> (MetaTable)Tables["accmotive_deferredcost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_accruals 		=> (MetaTable)Tables["accmotive_accruals"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_revenue 		=> (MetaTable)Tables["accmotive_revenue"];

	///<summary>
	///Tipo UPB nell'economico patrimoniale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public epupbkindTable epupbkind 		=> (epupbkindTable)Tables["epupbkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_cost_original 		=> (MetaTable)Tables["accmotive_cost_original"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_accruals_original 		=> (MetaTable)Tables["accmotive_accruals_original"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_revenue_original 		=> (MetaTable)Tables["accmotive_revenue_original"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_deferredcost_original 		=> (MetaTable)Tables["accmotive_deferredcost_original"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epupbkind_original 		=> (MetaTable)Tables["epupbkind_original"];

	///<summary>
	///Tipo EP dell' upb, informazioni annuali su UPB nell'economico patrimoniale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public epupbkindyearTable epupbkindyear 		=> (epupbkindyearTable)Tables["epupbkindyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable account_deferredcost 		=> (MetaTable)Tables["account_deferredcost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable account_cost 		=> (MetaTable)Tables["account_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable account_revenue 		=> (MetaTable)Tables["account_revenue"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable account_accruals 		=> (MetaTable)Tables["account_accruals"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable account_deferredcost_original 		=> (MetaTable)Tables["account_deferredcost_original"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable account_accruals_original 		=> (MetaTable)Tables["account_accruals_original"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable account_cost_original 		=> (MetaTable)Tables["account_cost_original"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable account_revenue_original 		=> (MetaTable)Tables["account_revenue_original"];

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
	//////////////////// UPBCOMMESSA /////////////////////////////////
	var tupbcommessa= new upbcommessaTable();
	tupbcommessa.addBaseColumns("idupb","ayear","codeupb","title","yearstart","yearstop","idepupbkind","idaccmotive_cost","idaccmotive_revenue","idaccmotive_deferredcost","idaccmotive_accruals","idacc_cost","idacc_revenue","idacc_deferredcost","idacc_accruals","cost","reserve","revenue","accruals","ct","cu","lt","lu");
	Tables.Add(tupbcommessa);
	tupbcommessa.defineKey("idupb", "ayear");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idman","idunderwriter","cupcode","idsor01","idsor02","idsor03","idsor04","idsor05","flagactivity","flagkind","newcodeupb","idtreasurer","start","stop","cigcode","idepupbkind","flag");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// ACCMOTIVE_COST /////////////////////////////////
	var taccmotive_cost= new MetaTable("accmotive_cost");
	taccmotive_cost.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_cost.defineColumn("active", typeof(string));
	taccmotive_cost.defineColumn("codemotive", typeof(string),false);
	taccmotive_cost.defineColumn("ct", typeof(DateTime),false);
	taccmotive_cost.defineColumn("cu", typeof(string),false);
	taccmotive_cost.defineColumn("lt", typeof(DateTime),false);
	taccmotive_cost.defineColumn("lu", typeof(string),false);
	taccmotive_cost.defineColumn("paridaccmotive", typeof(string));
	taccmotive_cost.defineColumn("title", typeof(string),false);
	taccmotive_cost.defineColumn("flagdep", typeof(string));
	taccmotive_cost.defineColumn("flagamm", typeof(string));
	taccmotive_cost.defineColumn("expensekind", typeof(string));
	taccmotive_cost.defineColumn("flag", typeof(int));
	Tables.Add(taccmotive_cost);
	taccmotive_cost.defineKey("idaccmotive");

	//////////////////// ACCMOTIVE_DEFERREDCOST /////////////////////////////////
	var taccmotive_deferredcost= new MetaTable("accmotive_deferredcost");
	taccmotive_deferredcost.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_deferredcost.defineColumn("active", typeof(string));
	taccmotive_deferredcost.defineColumn("codemotive", typeof(string),false);
	taccmotive_deferredcost.defineColumn("ct", typeof(DateTime),false);
	taccmotive_deferredcost.defineColumn("cu", typeof(string),false);
	taccmotive_deferredcost.defineColumn("lt", typeof(DateTime),false);
	taccmotive_deferredcost.defineColumn("lu", typeof(string),false);
	taccmotive_deferredcost.defineColumn("paridaccmotive", typeof(string));
	taccmotive_deferredcost.defineColumn("title", typeof(string),false);
	taccmotive_deferredcost.defineColumn("flagdep", typeof(string));
	taccmotive_deferredcost.defineColumn("flagamm", typeof(string));
	taccmotive_deferredcost.defineColumn("expensekind", typeof(string));
	taccmotive_deferredcost.defineColumn("flag", typeof(int));
	Tables.Add(taccmotive_deferredcost);
	taccmotive_deferredcost.defineKey("idaccmotive");

	//////////////////// ACCMOTIVE_ACCRUALS /////////////////////////////////
	var taccmotive_accruals= new MetaTable("accmotive_accruals");
	taccmotive_accruals.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_accruals.defineColumn("active", typeof(string));
	taccmotive_accruals.defineColumn("codemotive", typeof(string),false);
	taccmotive_accruals.defineColumn("ct", typeof(DateTime),false);
	taccmotive_accruals.defineColumn("cu", typeof(string),false);
	taccmotive_accruals.defineColumn("lt", typeof(DateTime),false);
	taccmotive_accruals.defineColumn("lu", typeof(string),false);
	taccmotive_accruals.defineColumn("paridaccmotive", typeof(string));
	taccmotive_accruals.defineColumn("title", typeof(string),false);
	taccmotive_accruals.defineColumn("flagdep", typeof(string));
	taccmotive_accruals.defineColumn("flagamm", typeof(string));
	taccmotive_accruals.defineColumn("expensekind", typeof(string));
	taccmotive_accruals.defineColumn("flag", typeof(int));
	Tables.Add(taccmotive_accruals);
	taccmotive_accruals.defineKey("idaccmotive");

	//////////////////// ACCMOTIVE_REVENUE /////////////////////////////////
	var taccmotive_revenue= new MetaTable("accmotive_revenue");
	taccmotive_revenue.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_revenue.defineColumn("active", typeof(string));
	taccmotive_revenue.defineColumn("codemotive", typeof(string),false);
	taccmotive_revenue.defineColumn("ct", typeof(DateTime),false);
	taccmotive_revenue.defineColumn("cu", typeof(string),false);
	taccmotive_revenue.defineColumn("lt", typeof(DateTime),false);
	taccmotive_revenue.defineColumn("lu", typeof(string),false);
	taccmotive_revenue.defineColumn("paridaccmotive", typeof(string));
	taccmotive_revenue.defineColumn("title", typeof(string),false);
	taccmotive_revenue.defineColumn("flagdep", typeof(string));
	taccmotive_revenue.defineColumn("flagamm", typeof(string));
	taccmotive_revenue.defineColumn("expensekind", typeof(string));
	taccmotive_revenue.defineColumn("flag", typeof(int));
	Tables.Add(taccmotive_revenue);
	taccmotive_revenue.defineKey("idaccmotive");

	//////////////////// EPUPBKIND /////////////////////////////////
	var tepupbkind= new epupbkindTable();
	tepupbkind.addBaseColumns("idepupbkind","title","description","ct","cu","lt","lu","active","isresource");
	Tables.Add(tepupbkind);
	tepupbkind.defineKey("idepupbkind");

	//////////////////// ACCMOTIVE_COST_ORIGINAL /////////////////////////////////
	var taccmotive_cost_original= new MetaTable("accmotive_cost_original");
	taccmotive_cost_original.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_cost_original.defineColumn("active", typeof(string));
	taccmotive_cost_original.defineColumn("codemotive", typeof(string),false);
	taccmotive_cost_original.defineColumn("ct", typeof(DateTime),false);
	taccmotive_cost_original.defineColumn("cu", typeof(string),false);
	taccmotive_cost_original.defineColumn("lt", typeof(DateTime),false);
	taccmotive_cost_original.defineColumn("lu", typeof(string),false);
	taccmotive_cost_original.defineColumn("paridaccmotive", typeof(string));
	taccmotive_cost_original.defineColumn("title", typeof(string),false);
	taccmotive_cost_original.defineColumn("flagdep", typeof(string));
	taccmotive_cost_original.defineColumn("flagamm", typeof(string));
	taccmotive_cost_original.defineColumn("expensekind", typeof(string));
	taccmotive_cost_original.defineColumn("flag", typeof(int));
	Tables.Add(taccmotive_cost_original);
	taccmotive_cost_original.defineKey("idaccmotive");

	//////////////////// ACCMOTIVE_ACCRUALS_ORIGINAL /////////////////////////////////
	var taccmotive_accruals_original= new MetaTable("accmotive_accruals_original");
	taccmotive_accruals_original.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_accruals_original.defineColumn("active", typeof(string));
	taccmotive_accruals_original.defineColumn("codemotive", typeof(string),false);
	taccmotive_accruals_original.defineColumn("ct", typeof(DateTime),false);
	taccmotive_accruals_original.defineColumn("cu", typeof(string),false);
	taccmotive_accruals_original.defineColumn("lt", typeof(DateTime),false);
	taccmotive_accruals_original.defineColumn("lu", typeof(string),false);
	taccmotive_accruals_original.defineColumn("paridaccmotive", typeof(string));
	taccmotive_accruals_original.defineColumn("title", typeof(string),false);
	taccmotive_accruals_original.defineColumn("flagdep", typeof(string));
	taccmotive_accruals_original.defineColumn("flagamm", typeof(string));
	taccmotive_accruals_original.defineColumn("expensekind", typeof(string));
	taccmotive_accruals_original.defineColumn("flag", typeof(int));
	Tables.Add(taccmotive_accruals_original);
	taccmotive_accruals_original.defineKey("idaccmotive");

	//////////////////// ACCMOTIVE_REVENUE_ORIGINAL /////////////////////////////////
	var taccmotive_revenue_original= new MetaTable("accmotive_revenue_original");
	taccmotive_revenue_original.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_revenue_original.defineColumn("active", typeof(string));
	taccmotive_revenue_original.defineColumn("codemotive", typeof(string),false);
	taccmotive_revenue_original.defineColumn("ct", typeof(DateTime),false);
	taccmotive_revenue_original.defineColumn("cu", typeof(string),false);
	taccmotive_revenue_original.defineColumn("lt", typeof(DateTime),false);
	taccmotive_revenue_original.defineColumn("lu", typeof(string),false);
	taccmotive_revenue_original.defineColumn("paridaccmotive", typeof(string));
	taccmotive_revenue_original.defineColumn("title", typeof(string),false);
	taccmotive_revenue_original.defineColumn("flagdep", typeof(string));
	taccmotive_revenue_original.defineColumn("flagamm", typeof(string));
	taccmotive_revenue_original.defineColumn("expensekind", typeof(string));
	taccmotive_revenue_original.defineColumn("flag", typeof(int));
	Tables.Add(taccmotive_revenue_original);
	taccmotive_revenue_original.defineKey("idaccmotive");

	//////////////////// ACCMOTIVE_DEFERREDCOST_ORIGINAL /////////////////////////////////
	var taccmotive_deferredcost_original= new MetaTable("accmotive_deferredcost_original");
	taccmotive_deferredcost_original.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_deferredcost_original.defineColumn("active", typeof(string));
	taccmotive_deferredcost_original.defineColumn("codemotive", typeof(string),false);
	taccmotive_deferredcost_original.defineColumn("ct", typeof(DateTime),false);
	taccmotive_deferredcost_original.defineColumn("cu", typeof(string),false);
	taccmotive_deferredcost_original.defineColumn("lt", typeof(DateTime),false);
	taccmotive_deferredcost_original.defineColumn("lu", typeof(string),false);
	taccmotive_deferredcost_original.defineColumn("paridaccmotive", typeof(string));
	taccmotive_deferredcost_original.defineColumn("title", typeof(string),false);
	taccmotive_deferredcost_original.defineColumn("flagdep", typeof(string));
	taccmotive_deferredcost_original.defineColumn("flagamm", typeof(string));
	taccmotive_deferredcost_original.defineColumn("expensekind", typeof(string));
	taccmotive_deferredcost_original.defineColumn("flag", typeof(int));
	Tables.Add(taccmotive_deferredcost_original);
	taccmotive_deferredcost_original.defineKey("idaccmotive");

	//////////////////// EPUPBKIND_ORIGINAL /////////////////////////////////
	var tepupbkind_original= new MetaTable("epupbkind_original");
	tepupbkind_original.defineColumn("idepupbkind", typeof(int),false);
	tepupbkind_original.defineColumn("title", typeof(string),false);
	tepupbkind_original.defineColumn("description", typeof(string));
	tepupbkind_original.defineColumn("ct", typeof(DateTime),false);
	tepupbkind_original.defineColumn("cu", typeof(string));
	tepupbkind_original.defineColumn("lt", typeof(DateTime));
	tepupbkind_original.defineColumn("lu", typeof(string));
	tepupbkind_original.defineColumn("active", typeof(string),false);
	tepupbkind_original.defineColumn("isresource", typeof(string));
	Tables.Add(tepupbkind_original);
	tepupbkind_original.defineKey("idepupbkind");

	//////////////////// EPUPBKINDYEAR /////////////////////////////////
	var tepupbkindyear= new epupbkindyearTable();
	tepupbkindyear.addBaseColumns("idepupbkind","ayear","idacc_cost","idacc_revenue","idacc_deferredcost","idacc_accruals","ct","cu","lt","lu","idacc_reserve","adjustmentkind","idaccmotive_cost","idaccmotive_revenue","idaccmotive_deferredcost","idaccmotive_accruals","idaccmotive_reserve");
	Tables.Add(tepupbkindyear);
	tepupbkindyear.defineKey("idepupbkind", "ayear");

	//////////////////// ACCOUNT_DEFERREDCOST /////////////////////////////////
	var taccount_deferredcost= new MetaTable("account_deferredcost");
	taccount_deferredcost.defineColumn("idacc", typeof(string),false);
	taccount_deferredcost.defineColumn("ayear", typeof(short),false);
	taccount_deferredcost.defineColumn("codeacc", typeof(string),false);
	taccount_deferredcost.defineColumn("ct", typeof(DateTime),false);
	taccount_deferredcost.defineColumn("cu", typeof(string),false);
	taccount_deferredcost.defineColumn("flagregistry", typeof(string));
	taccount_deferredcost.defineColumn("flagtransitory", typeof(string));
	taccount_deferredcost.defineColumn("flagupb", typeof(string));
	taccount_deferredcost.defineColumn("idaccountkind", typeof(string));
	taccount_deferredcost.defineColumn("lt", typeof(DateTime),false);
	taccount_deferredcost.defineColumn("lu", typeof(string),false);
	taccount_deferredcost.defineColumn("nlevel", typeof(string),false);
	taccount_deferredcost.defineColumn("paridacc", typeof(string));
	taccount_deferredcost.defineColumn("printingorder", typeof(string),false);
	taccount_deferredcost.defineColumn("rtf", typeof(Byte[]));
	taccount_deferredcost.defineColumn("title", typeof(string),false);
	taccount_deferredcost.defineColumn("txt", typeof(string));
	taccount_deferredcost.defineColumn("idpatrimony", typeof(string));
	taccount_deferredcost.defineColumn("idplaccount", typeof(string));
	taccount_deferredcost.defineColumn("flagprofit", typeof(string));
	taccount_deferredcost.defineColumn("flagloss", typeof(string));
	taccount_deferredcost.defineColumn("placcount_sign", typeof(string));
	taccount_deferredcost.defineColumn("patrimony_sign", typeof(string));
	taccount_deferredcost.defineColumn("flagcompetency", typeof(string));
	taccount_deferredcost.defineColumn("flag", typeof(int));
	taccount_deferredcost.defineColumn("idacc_special", typeof(string));
	taccount_deferredcost.defineColumn("flagenablebudgetprev", typeof(string));
	taccount_deferredcost.defineColumn("flagaccountusage", typeof(int));
	taccount_deferredcost.defineColumn("idsor_economicbudget", typeof(int));
	taccount_deferredcost.defineColumn("economicbudget_sign", typeof(string));
	taccount_deferredcost.defineColumn("idsor_investmentbudget", typeof(int));
	taccount_deferredcost.defineColumn("investmentbudget_sign", typeof(string));
	Tables.Add(taccount_deferredcost);
	taccount_deferredcost.defineKey("idacc");

	//////////////////// ACCOUNT_COST /////////////////////////////////
	var taccount_cost= new MetaTable("account_cost");
	taccount_cost.defineColumn("idacc", typeof(string),false);
	taccount_cost.defineColumn("ayear", typeof(short),false);
	taccount_cost.defineColumn("codeacc", typeof(string),false);
	taccount_cost.defineColumn("ct", typeof(DateTime),false);
	taccount_cost.defineColumn("cu", typeof(string),false);
	taccount_cost.defineColumn("flagregistry", typeof(string));
	taccount_cost.defineColumn("flagtransitory", typeof(string));
	taccount_cost.defineColumn("flagupb", typeof(string));
	taccount_cost.defineColumn("idaccountkind", typeof(string));
	taccount_cost.defineColumn("lt", typeof(DateTime),false);
	taccount_cost.defineColumn("lu", typeof(string),false);
	taccount_cost.defineColumn("nlevel", typeof(string),false);
	taccount_cost.defineColumn("paridacc", typeof(string));
	taccount_cost.defineColumn("printingorder", typeof(string),false);
	taccount_cost.defineColumn("rtf", typeof(Byte[]));
	taccount_cost.defineColumn("title", typeof(string),false);
	taccount_cost.defineColumn("txt", typeof(string));
	taccount_cost.defineColumn("idpatrimony", typeof(string));
	taccount_cost.defineColumn("idplaccount", typeof(string));
	taccount_cost.defineColumn("flagprofit", typeof(string));
	taccount_cost.defineColumn("flagloss", typeof(string));
	taccount_cost.defineColumn("placcount_sign", typeof(string));
	taccount_cost.defineColumn("patrimony_sign", typeof(string));
	taccount_cost.defineColumn("flagcompetency", typeof(string));
	taccount_cost.defineColumn("flag", typeof(int));
	taccount_cost.defineColumn("idacc_special", typeof(string));
	taccount_cost.defineColumn("flagenablebudgetprev", typeof(string));
	taccount_cost.defineColumn("flagaccountusage", typeof(int));
	taccount_cost.defineColumn("idsor_economicbudget", typeof(int));
	taccount_cost.defineColumn("economicbudget_sign", typeof(string));
	taccount_cost.defineColumn("idsor_investmentbudget", typeof(int));
	taccount_cost.defineColumn("investmentbudget_sign", typeof(string));
	Tables.Add(taccount_cost);
	taccount_cost.defineKey("idacc");

	//////////////////// ACCOUNT_REVENUE /////////////////////////////////
	var taccount_revenue= new MetaTable("account_revenue");
	taccount_revenue.defineColumn("idacc", typeof(string),false);
	taccount_revenue.defineColumn("ayear", typeof(short),false);
	taccount_revenue.defineColumn("codeacc", typeof(string),false);
	taccount_revenue.defineColumn("ct", typeof(DateTime),false);
	taccount_revenue.defineColumn("cu", typeof(string),false);
	taccount_revenue.defineColumn("flagregistry", typeof(string));
	taccount_revenue.defineColumn("flagtransitory", typeof(string));
	taccount_revenue.defineColumn("flagupb", typeof(string));
	taccount_revenue.defineColumn("idaccountkind", typeof(string));
	taccount_revenue.defineColumn("lt", typeof(DateTime),false);
	taccount_revenue.defineColumn("lu", typeof(string),false);
	taccount_revenue.defineColumn("nlevel", typeof(string),false);
	taccount_revenue.defineColumn("paridacc", typeof(string));
	taccount_revenue.defineColumn("printingorder", typeof(string),false);
	taccount_revenue.defineColumn("rtf", typeof(Byte[]));
	taccount_revenue.defineColumn("title", typeof(string),false);
	taccount_revenue.defineColumn("txt", typeof(string));
	taccount_revenue.defineColumn("idpatrimony", typeof(string));
	taccount_revenue.defineColumn("idplaccount", typeof(string));
	taccount_revenue.defineColumn("flagprofit", typeof(string));
	taccount_revenue.defineColumn("flagloss", typeof(string));
	taccount_revenue.defineColumn("placcount_sign", typeof(string));
	taccount_revenue.defineColumn("patrimony_sign", typeof(string));
	taccount_revenue.defineColumn("flagcompetency", typeof(string));
	taccount_revenue.defineColumn("flag", typeof(int));
	taccount_revenue.defineColumn("idacc_special", typeof(string));
	taccount_revenue.defineColumn("flagenablebudgetprev", typeof(string));
	taccount_revenue.defineColumn("flagaccountusage", typeof(int));
	taccount_revenue.defineColumn("idsor_economicbudget", typeof(int));
	taccount_revenue.defineColumn("economicbudget_sign", typeof(string));
	taccount_revenue.defineColumn("idsor_investmentbudget", typeof(int));
	taccount_revenue.defineColumn("investmentbudget_sign", typeof(string));
	Tables.Add(taccount_revenue);
	taccount_revenue.defineKey("idacc");

	//////////////////// ACCOUNT_ACCRUALS /////////////////////////////////
	var taccount_accruals= new MetaTable("account_accruals");
	taccount_accruals.defineColumn("idacc", typeof(string),false);
	taccount_accruals.defineColumn("ayear", typeof(short),false);
	taccount_accruals.defineColumn("codeacc", typeof(string),false);
	taccount_accruals.defineColumn("ct", typeof(DateTime),false);
	taccount_accruals.defineColumn("cu", typeof(string),false);
	taccount_accruals.defineColumn("flagregistry", typeof(string));
	taccount_accruals.defineColumn("flagtransitory", typeof(string));
	taccount_accruals.defineColumn("flagupb", typeof(string));
	taccount_accruals.defineColumn("idaccountkind", typeof(string));
	taccount_accruals.defineColumn("lt", typeof(DateTime),false);
	taccount_accruals.defineColumn("lu", typeof(string),false);
	taccount_accruals.defineColumn("nlevel", typeof(string),false);
	taccount_accruals.defineColumn("paridacc", typeof(string));
	taccount_accruals.defineColumn("printingorder", typeof(string),false);
	taccount_accruals.defineColumn("rtf", typeof(Byte[]));
	taccount_accruals.defineColumn("title", typeof(string),false);
	taccount_accruals.defineColumn("txt", typeof(string));
	taccount_accruals.defineColumn("idpatrimony", typeof(string));
	taccount_accruals.defineColumn("idplaccount", typeof(string));
	taccount_accruals.defineColumn("flagprofit", typeof(string));
	taccount_accruals.defineColumn("flagloss", typeof(string));
	taccount_accruals.defineColumn("placcount_sign", typeof(string));
	taccount_accruals.defineColumn("patrimony_sign", typeof(string));
	taccount_accruals.defineColumn("flagcompetency", typeof(string));
	taccount_accruals.defineColumn("flag", typeof(int));
	taccount_accruals.defineColumn("idacc_special", typeof(string));
	taccount_accruals.defineColumn("flagenablebudgetprev", typeof(string));
	taccount_accruals.defineColumn("flagaccountusage", typeof(int));
	taccount_accruals.defineColumn("idsor_economicbudget", typeof(int));
	taccount_accruals.defineColumn("economicbudget_sign", typeof(string));
	taccount_accruals.defineColumn("idsor_investmentbudget", typeof(int));
	taccount_accruals.defineColumn("investmentbudget_sign", typeof(string));
	Tables.Add(taccount_accruals);
	taccount_accruals.defineKey("idacc");

	//////////////////// ACCOUNT_DEFERREDCOST_ORIGINAL /////////////////////////////////
	var taccount_deferredcost_original= new MetaTable("account_deferredcost_original");
	taccount_deferredcost_original.defineColumn("idacc", typeof(string),false);
	taccount_deferredcost_original.defineColumn("ayear", typeof(short),false);
	taccount_deferredcost_original.defineColumn("codeacc", typeof(string),false);
	taccount_deferredcost_original.defineColumn("ct", typeof(DateTime),false);
	taccount_deferredcost_original.defineColumn("cu", typeof(string),false);
	taccount_deferredcost_original.defineColumn("flagregistry", typeof(string));
	taccount_deferredcost_original.defineColumn("flagtransitory", typeof(string));
	taccount_deferredcost_original.defineColumn("flagupb", typeof(string));
	taccount_deferredcost_original.defineColumn("idaccountkind", typeof(string));
	taccount_deferredcost_original.defineColumn("lt", typeof(DateTime),false);
	taccount_deferredcost_original.defineColumn("lu", typeof(string),false);
	taccount_deferredcost_original.defineColumn("nlevel", typeof(string),false);
	taccount_deferredcost_original.defineColumn("paridacc", typeof(string));
	taccount_deferredcost_original.defineColumn("printingorder", typeof(string),false);
	taccount_deferredcost_original.defineColumn("rtf", typeof(Byte[]));
	taccount_deferredcost_original.defineColumn("title", typeof(string),false);
	taccount_deferredcost_original.defineColumn("txt", typeof(string));
	taccount_deferredcost_original.defineColumn("idpatrimony", typeof(string));
	taccount_deferredcost_original.defineColumn("idplaccount", typeof(string));
	taccount_deferredcost_original.defineColumn("flagprofit", typeof(string));
	taccount_deferredcost_original.defineColumn("flagloss", typeof(string));
	taccount_deferredcost_original.defineColumn("placcount_sign", typeof(string));
	taccount_deferredcost_original.defineColumn("patrimony_sign", typeof(string));
	taccount_deferredcost_original.defineColumn("flagcompetency", typeof(string));
	taccount_deferredcost_original.defineColumn("flag", typeof(int));
	taccount_deferredcost_original.defineColumn("idacc_special", typeof(string));
	taccount_deferredcost_original.defineColumn("flagenablebudgetprev", typeof(string));
	taccount_deferredcost_original.defineColumn("flagaccountusage", typeof(int));
	taccount_deferredcost_original.defineColumn("idsor_economicbudget", typeof(int));
	taccount_deferredcost_original.defineColumn("economicbudget_sign", typeof(string));
	taccount_deferredcost_original.defineColumn("idsor_investmentbudget", typeof(int));
	taccount_deferredcost_original.defineColumn("investmentbudget_sign", typeof(string));
	Tables.Add(taccount_deferredcost_original);
	taccount_deferredcost_original.defineKey("idacc");

	//////////////////// ACCOUNT_ACCRUALS_ORIGINAL /////////////////////////////////
	var taccount_accruals_original= new MetaTable("account_accruals_original");
	taccount_accruals_original.defineColumn("idacc", typeof(string),false);
	taccount_accruals_original.defineColumn("ayear", typeof(short),false);
	taccount_accruals_original.defineColumn("codeacc", typeof(string),false);
	taccount_accruals_original.defineColumn("ct", typeof(DateTime),false);
	taccount_accruals_original.defineColumn("cu", typeof(string),false);
	taccount_accruals_original.defineColumn("flagregistry", typeof(string));
	taccount_accruals_original.defineColumn("flagtransitory", typeof(string));
	taccount_accruals_original.defineColumn("flagupb", typeof(string));
	taccount_accruals_original.defineColumn("idaccountkind", typeof(string));
	taccount_accruals_original.defineColumn("lt", typeof(DateTime),false);
	taccount_accruals_original.defineColumn("lu", typeof(string),false);
	taccount_accruals_original.defineColumn("nlevel", typeof(string),false);
	taccount_accruals_original.defineColumn("paridacc", typeof(string));
	taccount_accruals_original.defineColumn("printingorder", typeof(string),false);
	taccount_accruals_original.defineColumn("rtf", typeof(Byte[]));
	taccount_accruals_original.defineColumn("title", typeof(string),false);
	taccount_accruals_original.defineColumn("txt", typeof(string));
	taccount_accruals_original.defineColumn("idpatrimony", typeof(string));
	taccount_accruals_original.defineColumn("idplaccount", typeof(string));
	taccount_accruals_original.defineColumn("flagprofit", typeof(string));
	taccount_accruals_original.defineColumn("flagloss", typeof(string));
	taccount_accruals_original.defineColumn("placcount_sign", typeof(string));
	taccount_accruals_original.defineColumn("patrimony_sign", typeof(string));
	taccount_accruals_original.defineColumn("flagcompetency", typeof(string));
	taccount_accruals_original.defineColumn("flag", typeof(int));
	taccount_accruals_original.defineColumn("idacc_special", typeof(string));
	taccount_accruals_original.defineColumn("flagenablebudgetprev", typeof(string));
	taccount_accruals_original.defineColumn("flagaccountusage", typeof(int));
	taccount_accruals_original.defineColumn("idsor_economicbudget", typeof(int));
	taccount_accruals_original.defineColumn("economicbudget_sign", typeof(string));
	taccount_accruals_original.defineColumn("idsor_investmentbudget", typeof(int));
	taccount_accruals_original.defineColumn("investmentbudget_sign", typeof(string));
	Tables.Add(taccount_accruals_original);
	taccount_accruals_original.defineKey("idacc");

	//////////////////// ACCOUNT_COST_ORIGINAL /////////////////////////////////
	var taccount_cost_original= new MetaTable("account_cost_original");
	taccount_cost_original.defineColumn("idacc", typeof(string),false);
	taccount_cost_original.defineColumn("ayear", typeof(short),false);
	taccount_cost_original.defineColumn("codeacc", typeof(string),false);
	taccount_cost_original.defineColumn("ct", typeof(DateTime),false);
	taccount_cost_original.defineColumn("cu", typeof(string),false);
	taccount_cost_original.defineColumn("flagregistry", typeof(string));
	taccount_cost_original.defineColumn("flagtransitory", typeof(string));
	taccount_cost_original.defineColumn("flagupb", typeof(string));
	taccount_cost_original.defineColumn("idaccountkind", typeof(string));
	taccount_cost_original.defineColumn("lt", typeof(DateTime),false);
	taccount_cost_original.defineColumn("lu", typeof(string),false);
	taccount_cost_original.defineColumn("nlevel", typeof(string),false);
	taccount_cost_original.defineColumn("paridacc", typeof(string));
	taccount_cost_original.defineColumn("printingorder", typeof(string),false);
	taccount_cost_original.defineColumn("rtf", typeof(Byte[]));
	taccount_cost_original.defineColumn("title", typeof(string),false);
	taccount_cost_original.defineColumn("txt", typeof(string));
	taccount_cost_original.defineColumn("idpatrimony", typeof(string));
	taccount_cost_original.defineColumn("idplaccount", typeof(string));
	taccount_cost_original.defineColumn("flagprofit", typeof(string));
	taccount_cost_original.defineColumn("flagloss", typeof(string));
	taccount_cost_original.defineColumn("placcount_sign", typeof(string));
	taccount_cost_original.defineColumn("patrimony_sign", typeof(string));
	taccount_cost_original.defineColumn("flagcompetency", typeof(string));
	taccount_cost_original.defineColumn("flag", typeof(int));
	taccount_cost_original.defineColumn("idacc_special", typeof(string));
	taccount_cost_original.defineColumn("flagenablebudgetprev", typeof(string));
	taccount_cost_original.defineColumn("flagaccountusage", typeof(int));
	taccount_cost_original.defineColumn("idsor_economicbudget", typeof(int));
	taccount_cost_original.defineColumn("economicbudget_sign", typeof(string));
	taccount_cost_original.defineColumn("idsor_investmentbudget", typeof(int));
	taccount_cost_original.defineColumn("investmentbudget_sign", typeof(string));
	Tables.Add(taccount_cost_original);
	taccount_cost_original.defineKey("idacc");

	//////////////////// ACCOUNT_REVENUE_ORIGINAL /////////////////////////////////
	var taccount_revenue_original= new MetaTable("account_revenue_original");
	taccount_revenue_original.defineColumn("idacc", typeof(string),false);
	taccount_revenue_original.defineColumn("ayear", typeof(short),false);
	taccount_revenue_original.defineColumn("codeacc", typeof(string),false);
	taccount_revenue_original.defineColumn("ct", typeof(DateTime),false);
	taccount_revenue_original.defineColumn("cu", typeof(string),false);
	taccount_revenue_original.defineColumn("flagregistry", typeof(string));
	taccount_revenue_original.defineColumn("flagtransitory", typeof(string));
	taccount_revenue_original.defineColumn("flagupb", typeof(string));
	taccount_revenue_original.defineColumn("idaccountkind", typeof(string));
	taccount_revenue_original.defineColumn("lt", typeof(DateTime),false);
	taccount_revenue_original.defineColumn("lu", typeof(string),false);
	taccount_revenue_original.defineColumn("nlevel", typeof(string),false);
	taccount_revenue_original.defineColumn("paridacc", typeof(string));
	taccount_revenue_original.defineColumn("printingorder", typeof(string),false);
	taccount_revenue_original.defineColumn("rtf", typeof(Byte[]));
	taccount_revenue_original.defineColumn("title", typeof(string),false);
	taccount_revenue_original.defineColumn("txt", typeof(string));
	taccount_revenue_original.defineColumn("idpatrimony", typeof(string));
	taccount_revenue_original.defineColumn("idplaccount", typeof(string));
	taccount_revenue_original.defineColumn("flagprofit", typeof(string));
	taccount_revenue_original.defineColumn("flagloss", typeof(string));
	taccount_revenue_original.defineColumn("placcount_sign", typeof(string));
	taccount_revenue_original.defineColumn("patrimony_sign", typeof(string));
	taccount_revenue_original.defineColumn("flagcompetency", typeof(string));
	taccount_revenue_original.defineColumn("flag", typeof(int));
	taccount_revenue_original.defineColumn("idacc_special", typeof(string));
	taccount_revenue_original.defineColumn("flagenablebudgetprev", typeof(string));
	taccount_revenue_original.defineColumn("flagaccountusage", typeof(int));
	taccount_revenue_original.defineColumn("idsor_economicbudget", typeof(int));
	taccount_revenue_original.defineColumn("economicbudget_sign", typeof(string));
	taccount_revenue_original.defineColumn("idsor_investmentbudget", typeof(int));
	taccount_revenue_original.defineColumn("investmentbudget_sign", typeof(string));
	Tables.Add(taccount_revenue_original);
	taccount_revenue_original.defineKey("idacc");

	#endregion


	#region DataRelation creation
	this.defineRelation("upb_upbcommessa","upb","upbcommessa","idupb");
	this.defineRelation("epupbkind_upbcommessa","epupbkind_original","upbcommessa","idepupbkind");
	var cPar = new []{accmotive_accruals.Columns["idaccmotive"]};
	var cChild = new []{epupbkindyear.Columns["idaccmotive_accruals"]};
	Relations.Add(new DataRelation("accmotive_accruals_upbcommessa",cPar,cChild,false));

	cPar = new []{accmotive_cost.Columns["idaccmotive"]};
	cChild = new []{epupbkindyear.Columns["idaccmotive_cost"]};
	Relations.Add(new DataRelation("accmotive_cost_upbcommessa",cPar,cChild,false));

	cPar = new []{accmotive_accruals_original.Columns["idaccmotive"]};
	cChild = new []{upbcommessa.Columns["idaccmotive_accruals"]};
	Relations.Add(new DataRelation("accmotive_accruals_original_upbcommessa",cPar,cChild,false));

	cPar = new []{accmotive_revenue_original.Columns["idaccmotive"]};
	cChild = new []{upbcommessa.Columns["idaccmotive_revenue"]};
	Relations.Add(new DataRelation("accmotive_revenue_original_upbcommessa",cPar,cChild,false));

	cPar = new []{accmotive_cost_original.Columns["idaccmotive"]};
	cChild = new []{upbcommessa.Columns["idaccmotive_cost"]};
	Relations.Add(new DataRelation("accmotive_cost_original_upbcommessa",cPar,cChild,false));

	cPar = new []{accmotive_deferredcost_original.Columns["idaccmotive"]};
	cChild = new []{upbcommessa.Columns["idaccmotive_deferredcost"]};
	Relations.Add(new DataRelation("accmotive_deferredcost_original_upbcommessa",cPar,cChild,false));

	cPar = new []{accmotive_revenue.Columns["idaccmotive"]};
	cChild = new []{epupbkindyear.Columns["idaccmotive_revenue"]};
	Relations.Add(new DataRelation("accmotive_revenue_epupbkindyear",cPar,cChild,false));

	this.defineRelation("epupbkind_upb","epupbkind","upb","idepupbkind");
	this.defineRelation("epupbkind_epupbkindyear","epupbkind","epupbkindyear","idepupbkind");
	cPar = new []{account_cost_original.Columns["idacc"]};
	cChild = new []{upbcommessa.Columns["idacc_cost"]};
	Relations.Add(new DataRelation("account_cost_original_upbcommessa",cPar,cChild,false));

	cPar = new []{account_revenue_original.Columns["idacc"]};
	cChild = new []{upbcommessa.Columns["idacc_revenue"]};
	Relations.Add(new DataRelation("account_revenue_original_upbcommessa",cPar,cChild,false));

	cPar = new []{account_accruals_original.Columns["idacc"]};
	cChild = new []{upbcommessa.Columns["idacc_accruals"]};
	Relations.Add(new DataRelation("account_accruals_original_upbcommessa",cPar,cChild,false));

	cPar = new []{account_accruals.Columns["idacc"]};
	cChild = new []{epupbkindyear.Columns["idacc_accruals"]};
	Relations.Add(new DataRelation("account_accruals_epupbkindyear",cPar,cChild,false));

	cPar = new []{account_revenue.Columns["idacc"]};
	cChild = new []{epupbkindyear.Columns["idacc_revenue"]};
	Relations.Add(new DataRelation("account_revenue_epupbkindyear",cPar,cChild,false));

	cPar = new []{account_deferredcost.Columns["idacc"]};
	cChild = new []{epupbkindyear.Columns["idacc_deferredcost"]};
	Relations.Add(new DataRelation("account_deferredcost_epupbkindyear",cPar,cChild,false));

	cPar = new []{account_cost.Columns["idacc"]};
	cChild = new []{epupbkindyear.Columns["idacc_cost"]};
	Relations.Add(new DataRelation("account_cost_epupbkindyear",cPar,cChild,false));

	cPar = new []{accmotive_deferredcost.Columns["idaccmotive"]};
	cChild = new []{epupbkindyear.Columns["idaccmotive_deferredcost"]};
	Relations.Add(new DataRelation("accmotive_deferredcost_epupbkindyear",cPar,cChild,false));

	cPar = new []{account_deferredcost_original.Columns["idacc"]};
	cChild = new []{upbcommessa.Columns["idacc_deferredcost"]};
	Relations.Add(new DataRelation("account_deferredcost_original_upbcommessa",cPar,cChild,false));

	#endregion

}
}
}
