
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
using meta_registry;
using meta_account;
using meta_epexp;
using meta_upb;
using meta_manager;
using meta_mandatedetail;
using meta_invoicedetail;
using meta_accmotive;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace epexp_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account 		=> (accountTable)Tables["account"];

	///<summary>
	///Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public epexpTable epexp 		=> (epexpTable)Tables["epexp"];

	///<summary>
	///Imputazione annuale impegno di budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epexpyear 		=> (MetaTable)Tables["epexpyear"];

	///<summary>
	///Variazione movimento Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epexpvar 		=> (MetaTable)Tables["epexpvar"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public managerTable manager 		=> (managerTable)Tables["manager"];

	///<summary>
	///Classificazione Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epexpsorting 		=> (MetaTable)Tables["epexpsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingview 		=> (MetaTable)Tables["sortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epexpsortingview 		=> (MetaTable)Tables["epexpsortingview"];

	///<summary>
	///Dettaglio contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandatedetailTable mandatedetail 		=> (mandatedetailTable)Tables["mandatedetail"];

	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicedetailTable invoicedetail 		=> (invoicedetailTable)Tables["invoicedetail"];

	///<summary>
	///Totalizzatore su impegno di budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epexptotal 		=> (MetaTable)Tables["epexptotal"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveTable accmotive 		=> (accmotiveTable)Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epexpview 		=> (MetaTable)Tables["epexpview"];

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
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","active","annotation","badgecode","birthdate","cf","ct","cu","extmatricula","foreigncf","forename","gender","idcategory","idcentralizedcategory","idmaritalstatus","idnation","idregistryclass","idtitle","location","lt","lu","maritalsurname","p_iva","residence","rtf","surname","title","txt");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new accountTable();
	taccount.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt");
	Tables.Add(taccount);
	taccount.defineKey("idacc");

	//////////////////// EPEXP /////////////////////////////////
	var tepexp= new epexpTable();
	tepexp.addBaseColumns("yepexp","nepexp","description","idreg","start","stop","txt","rtf","adate","ct","cu","lt","lu","doc","docdate","idrelated","idepexp","paridepexp","nphase","idman","flagvariation","idaccmotive");
	Tables.Add(tepexp);
	tepexp.defineKey("idepexp");

	//////////////////// EPEXPYEAR /////////////////////////////////
	var tepexpyear= new MetaTable("epexpyear");
	tepexpyear.defineColumn("idepexp", typeof(int),false);
	tepexpyear.defineColumn("ayear", typeof(short),false);
	tepexpyear.defineColumn("idupb", typeof(string),false);
	tepexpyear.defineColumn("idacc", typeof(string),false);
	tepexpyear.defineColumn("amount", typeof(decimal),false);
	tepexpyear.defineColumn("amount2", typeof(decimal));
	tepexpyear.defineColumn("amount3", typeof(decimal));
	tepexpyear.defineColumn("amount4", typeof(decimal));
	tepexpyear.defineColumn("amount5", typeof(decimal));
	tepexpyear.defineColumn("lt", typeof(DateTime));
	tepexpyear.defineColumn("lu", typeof(string));
	tepexpyear.defineColumn("ct", typeof(DateTime));
	tepexpyear.defineColumn("cu", typeof(string));
	Tables.Add(tepexpyear);
	tepexpyear.defineKey("idepexp", "ayear");

	//////////////////// EPEXPVAR /////////////////////////////////
	var tepexpvar= new MetaTable("epexpvar");
	tepexpvar.defineColumn("idepexp", typeof(int),false);
	tepexpvar.defineColumn("nvar", typeof(int),false);
	tepexpvar.defineColumn("adate", typeof(DateTime),false);
	tepexpvar.defineColumn("amount", typeof(decimal),false);
	tepexpvar.defineColumn("description", typeof(string),false);
	tepexpvar.defineColumn("ct", typeof(DateTime),false);
	tepexpvar.defineColumn("cu", typeof(string),false);
	tepexpvar.defineColumn("lt", typeof(DateTime),false);
	tepexpvar.defineColumn("lu", typeof(string),false);
	tepexpvar.defineColumn("amount2", typeof(decimal));
	tepexpvar.defineColumn("amount3", typeof(decimal));
	tepexpvar.defineColumn("amount4", typeof(decimal));
	tepexpvar.defineColumn("amount5", typeof(decimal));
	tepexpvar.defineColumn("yvar", typeof(short),false);
	Tables.Add(tepexpvar);
	tepexpvar.defineKey("idepexp", "nvar");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idman","idunderwriter","cupcode","idsor01","idsor02","idsor03","idsor04","idsor05","flagactivity","flagkind","newcodeupb","idtreasurer","start","stop","cigcode");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new managerTable();
	tmanager.addBaseColumns("active","ct","cu","email","lt","lu","passwordweb","phonenumber","rtf","title","txt","userweb","idman","iddivision","wantswarn","idsor01","idsor02","idsor03","idsor04","idsor05","newidman","financeactive");
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// EPEXPSORTING /////////////////////////////////
	var tepexpsorting= new MetaTable("epexpsorting");
	tepexpsorting.defineColumn("amount", typeof(decimal),false);
	tepexpsorting.defineColumn("adate", typeof(DateTime),false);
	tepexpsorting.defineColumn("description", typeof(string));
	tepexpsorting.defineColumn("ct", typeof(DateTime),false);
	tepexpsorting.defineColumn("cu", typeof(string),false);
	tepexpsorting.defineColumn("lt", typeof(DateTime),false);
	tepexpsorting.defineColumn("lu", typeof(string),false);
	tepexpsorting.defineColumn("idsor", typeof(int),false);
	tepexpsorting.defineColumn("idepexp", typeof(int),false);
	tepexpsorting.defineColumn("ayear", typeof(short),false);
	tepexpsorting.defineColumn("rownum", typeof(int),false);
	tepexpsorting.defineColumn("!percentuale", typeof(string));
	tepexpsorting.defineColumn("!sortingkind", typeof(string));
	tepexpsorting.defineColumn("!sortcode", typeof(string));
	tepexpsorting.defineColumn("!sorting", typeof(string));
	tepexpsorting.defineColumn("kind", typeof(string));
	Tables.Add(tepexpsorting);
	tepexpsorting.defineKey("idepexp", "rownum");

	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new MetaTable("sortingview");
	tsortingview.defineColumn("sortingkind", typeof(string),false);
	tsortingview.defineColumn("idsor", typeof(int),false);
	tsortingview.defineColumn("sortcode", typeof(string),false);
	tsortingview.defineColumn("description", typeof(string),false);
	Tables.Add(tsortingview);
	tsortingview.defineKey("idsor");

	//////////////////// EPEXPSORTINGVIEW /////////////////////////////////
	var tepexpsortingview= new MetaTable("epexpsortingview");
	tepexpsortingview.defineColumn("idepexp", typeof(int),false);
	tepexpsortingview.defineColumn("rownum", typeof(int),false);
	tepexpsortingview.defineColumn("yepexp", typeof(short),false);
	tepexpsortingview.defineColumn("nepexp", typeof(int),false);
	tepexpsortingview.defineColumn("nphase", typeof(short),false);
	tepexpsortingview.defineColumn("description", typeof(string));
	tepexpsortingview.defineColumn("amount", typeof(decimal),false);
	tepexpsortingview.defineColumn("ayear", typeof(short),false);
	tepexpsortingview.defineColumn("adate", typeof(DateTime),false);
	tepexpsortingview.defineColumn("idsorkind", typeof(int),false);
	tepexpsortingview.defineColumn("idsor", typeof(int),false);
	tepexpsortingview.defineColumn("sortingkind", typeof(string),false);
	tepexpsortingview.defineColumn("sortcode", typeof(string),false);
	tepexpsortingview.defineColumn("sorting", typeof(string),false);
	tepexpsortingview.defineColumn("lt", typeof(DateTime),false);
	tepexpsortingview.defineColumn("lu", typeof(string),false);
	tepexpsortingview.defineColumn("ct", typeof(DateTime),false);
	tepexpsortingview.defineColumn("cu", typeof(string),false);
	tepexpsortingview.defineColumn("kind", typeof(string));
	Tables.Add(tepexpsortingview);
	tepexpsortingview.defineKey("idepexp", "rownum");

	//////////////////// MANDATEDETAIL /////////////////////////////////
	var tmandatedetail= new mandatedetailTable();
	tmandatedetail.addBaseColumns("idmankind","nman","rownum","yman","annotations","assetkind","competencystart","competencystop","ct","cu","detaildescription","discount","idupb","lt","lu","ninvoiced","number","start","stop","tax","taxable","taxrate","toinvoice","flagmixed","idaccmotive","unabatable","idgroup","idreg","idexp_taxable","idexp_iva","idinv","idivakind","idsor1","idsor2","idsor3","idaccmotiveannulment","flagactivity","va3type","applierannotations","ivanotes","idlist","idunit","idpackage","unitsforpackage","npackage","cupcode","cigcode","flagto_unload","epkind","rownum_origin","contractamount","idavcp","idavcp_choice","avcp_startcontract","avcp_stopcontract","avcp_description","idpccdebitmotive","idpccdebitstatus","idcostpartition","expensekind","idepexp");
	Tables.Add(tmandatedetail);
	tmandatedetail.defineKey("idmankind", "nman", "rownum", "yman");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("ninv","rownum","yinv","annotations","competencystart","paymentcompetency","competencystop","ct","cu","detaildescription","discount","idaccmotive","idmankind","idupb","lt","lu","manrownum","nman","number","tax","taxable","unabatable","yman","idestimkind","estimrownum","nestim","yestim","idgroup","idexp_taxable","idexp_iva","idinc_taxable","idinc_iva","ninv_main","yinv_main","idivakind","idinvkind","idsor1","idsor2","idsor3","idintrastatcode","idintrastatmeasure","weight","va3type","intrastatoperationkind","idintrastatservice","idintrastatsupplymethod","idlist","idunit","idpackage","unitsforpackage","npackage","flag","exception12","intra12operationkind","move12","idupb_iva","idinvkind_main","leasing","usedmodesospesometro","resetresidualmandate","idfetransfer","fereferencerule","cupcode","cigcode","idpccdebitstatus","idpccdebitmotive","idcostpartition","expensekind","rounding","idepexp","idepacc");
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("ninv", "rownum", "yinv", "idinvkind");

	//////////////////// EPEXPTOTAL /////////////////////////////////
	var tepexptotal= new MetaTable("epexptotal");
	tepexptotal.defineColumn("idepexp", typeof(int),false);
	tepexptotal.defineColumn("ayear", typeof(short),false);
	tepexptotal.defineColumn("available", typeof(decimal));
	tepexptotal.defineColumn("available2", typeof(decimal));
	tepexptotal.defineColumn("available3", typeof(decimal));
	tepexptotal.defineColumn("available4", typeof(decimal));
	tepexptotal.defineColumn("available5", typeof(decimal));
	tepexptotal.defineColumn("curramount", typeof(decimal));
	tepexptotal.defineColumn("curramount2", typeof(decimal));
	tepexptotal.defineColumn("curramount3", typeof(decimal));
	tepexptotal.defineColumn("curramount4", typeof(decimal));
	tepexptotal.defineColumn("curramount5", typeof(decimal));
	Tables.Add(tepexptotal);
	tepexptotal.defineKey("idepexp", "ayear");

	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new accmotiveTable();
	taccmotive.addBaseColumns("idaccmotive","active","codemotive","ct","cu","lt","lu","paridaccmotive","title","flagdep","flagamm","expensekind");
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

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

	#endregion


	#region DataRelation creation
	this.defineRelation("epexp_invoicedetail","epexp","invoicedetail","idepexp");
	this.defineRelation("epexp_mandatedetail","epexp","mandatedetail","idepexp");
	this.defineRelation("epexp_epexpsorting","epexp","epexpsorting","idepexp");
	this.defineRelation("sortingview_epexpsorting","sortingview","epexpsorting","idsor");
	this.defineRelation("epexp_epexpvar","epexp","epexpvar","idepexp");
	this.defineRelation("epexp_epexpyear","epexp","epexpyear","idepexp");
	this.defineRelation("upb_epexpyear","upb","epexpyear","idupb");
	this.defineRelation("account_epexpyear","account","epexpyear","idacc");
	this.defineRelation("manager_epexp","manager","epexp","idman");
	this.defineRelation("registry_epexp","registry","epexp","idreg");
	var cPar = new []{epexp.Columns["idepexp"]};
	var cChild = new []{epexp.Columns["paridepexp"]};
	Relations.Add(new DataRelation("epexp_epexp",cPar,cChild,false));

	this.defineRelation("accmotive_epexp","accmotive","epexp","idaccmotive");
	this.defineRelation("epexp_epexpview","epexp","epexpview","idepexp");
	#endregion

}
}
}
