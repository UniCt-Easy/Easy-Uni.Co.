
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
using meta_assetload;
using meta_assetloadkind;
using meta_registry;
using meta_config;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace assetload_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Buono di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetloadTable assetload 		=> (assetloadTable)Tables["assetload"];

	///<summary>
	///Tipi di buoni di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetloadkindTable assetloadkind 		=> (assetloadkindTable)Tables["assetloadkind"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Causali di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetloadmotive 		=> (MetaTable)Tables["assetloadmotive"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensephase 		=> (MetaTable)Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquireview 		=> (MetaTable)Tables["assetacquireview"];

	///<summary>
	///Movimenti di spesa collegati a buoni di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetloadexpense 		=> (MetaTable)Tables["assetloadexpense"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetamortizationunloadview 		=> (MetaTable)Tables["assetamortizationunloadview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable historypaymentview 		=> (MetaTable)Tables["historypaymentview"];

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
	//////////////////// ASSETLOAD /////////////////////////////////
	var tassetload= new assetloadTable();
	tassetload.addBaseColumns("idassetload","idassetloadkind","yassetload","nassetload","idreg","idmot","doc","docdate","description","enactment","enactmentdate","adate","printdate","ratificationdate","txt","rtf","cu","ct","lu","lt","transmitted");
	Tables.Add(tassetload);
	tassetload.defineKey("idassetload");

	//////////////////// ASSETLOADKIND /////////////////////////////////
	var tassetloadkind= new assetloadkindTable();
	tassetloadkind.addBaseColumns("idassetloadkind","description","idinventory","startnumber","cu","ct","lu","lt","flag","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tassetloadkind);
	tassetloadkind.defineKey("idassetloadkind");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","annotation","birthdate","gender","surname","forename","foreigncf","active","cu","ct","lu","lt","badgecode","idcategory","idcentralizedcategory","idmaritalstatus","idtitle","idregistryclass","maritalsurname","idcity","idnation","location","extmatricula");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ASSETLOADMOTIVE /////////////////////////////////
	var tassetloadmotive= new MetaTable("assetloadmotive");
	tassetloadmotive.defineColumn("idmot", typeof(int),false);
	tassetloadmotive.defineColumn("description", typeof(string),false);
	tassetloadmotive.defineColumn("cu", typeof(string),false);
	tassetloadmotive.defineColumn("ct", typeof(DateTime),false);
	tassetloadmotive.defineColumn("lu", typeof(string),false);
	tassetloadmotive.defineColumn("lt", typeof(DateTime),false);
	tassetloadmotive.defineColumn("idaccmotive", typeof(string));
	tassetloadmotive.defineColumn("active", typeof(string));
	Tables.Add(tassetloadmotive);
	tassetloadmotive.defineKey("idmot");

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

	//////////////////// ASSETACQUIREVIEW /////////////////////////////////
	var tassetacquireview= new MetaTable("assetacquireview");
	tassetacquireview.defineColumn("nassetacquire", typeof(int),false);
	tassetacquireview.defineColumn("yman", typeof(short));
	tassetacquireview.defineColumn("nman", typeof(int));
	tassetacquireview.defineColumn("rownum", typeof(int));
	tassetacquireview.defineColumn("idreg", typeof(int));
	tassetacquireview.defineColumn("registry", typeof(string));
	tassetacquireview.defineColumn("idmot", typeof(int),false);
	tassetacquireview.defineColumn("assetloadmotive", typeof(string));
	tassetacquireview.defineColumn("idinv", typeof(int),false);
	tassetacquireview.defineColumn("codeinv", typeof(string));
	tassetacquireview.defineColumn("inventorytree", typeof(string));
	tassetacquireview.defineColumn("description", typeof(string),false);
	tassetacquireview.defineColumn("idinventory", typeof(int),false);
	tassetacquireview.defineColumn("codeinventory", typeof(string));
	tassetacquireview.defineColumn("inventory", typeof(string));
	tassetacquireview.defineColumn("idassetloadkind", typeof(int));
	tassetacquireview.defineColumn("assetloadkind", typeof(string));
	tassetacquireview.defineColumn("yassetload", typeof(short));
	tassetacquireview.defineColumn("nassetload", typeof(int));
	tassetacquireview.defineColumn("number", typeof(int),false);
	tassetacquireview.defineColumn("taxable", typeof(decimal));
	tassetacquireview.defineColumn("taxrate", typeof(double));
	tassetacquireview.defineColumn("discount", typeof(double));
	tassetacquireview.defineColumn("total", typeof(decimal));
	tassetacquireview.defineColumn("abatable", typeof(decimal));
	tassetacquireview.defineColumn("startnumber", typeof(int));
	tassetacquireview.defineColumn("adate", typeof(DateTime),false);
	tassetacquireview.defineColumn("flag", typeof(byte),false);
	tassetacquireview.defineColumn("flagload", typeof(string),false);
	tassetacquireview.defineColumn("loadkind", typeof(string),false);
	tassetacquireview.defineColumn("ispieceacquire", typeof(string),false);
	tassetacquireview.defineColumn("cu", typeof(string),false);
	tassetacquireview.defineColumn("ct", typeof(DateTime),false);
	tassetacquireview.defineColumn("lu", typeof(string),false);
	tassetacquireview.defineColumn("lt", typeof(DateTime),false);
	tassetacquireview.defineColumn("transmitted", typeof(string));
	tassetacquireview.defineColumn("cost", typeof(decimal));
	tassetacquireview.defineColumn("idupb", typeof(string));
	tassetacquireview.defineColumn("idsor1", typeof(int));
	tassetacquireview.defineColumn("idsor2", typeof(int));
	tassetacquireview.defineColumn("idsor3", typeof(int));
	tassetacquireview.defineColumn("idassetload", typeof(int));
	tassetacquireview.defineColumn("!pieceorasset", typeof(string));
	tassetacquireview.defineColumn("idmankind", typeof(string));
	tassetacquireview.defineColumn("idsor01", typeof(int));
	tassetacquireview.defineColumn("idsor02", typeof(int));
	tassetacquireview.defineColumn("idsor03", typeof(int));
	tassetacquireview.defineColumn("idsor04", typeof(int));
	tassetacquireview.defineColumn("idsor05", typeof(int));
	tassetacquireview.defineColumn("intcode", typeof(string));
	tassetacquireview.defineColumn("list", typeof(string));
	tassetacquireview.defineColumn("yinv", typeof(int));
	tassetacquireview.defineColumn("ninv", typeof(int));
	tassetacquireview.defineColumn("idinvkind", typeof(int));
	tassetacquireview.defineColumn("invrownum", typeof(int));
	tassetacquireview.defineColumn("invoicekind", typeof(string));
	tassetacquireview.defineColumn("cost_discounted", typeof(decimal));
	tassetacquireview.defineColumn("historicalvalue", typeof(decimal));
	tassetacquireview.defineColumn("inventorykind", typeof(string));
	Tables.Add(tassetacquireview);
	tassetacquireview.defineKey("nassetacquire");

	//////////////////// ASSETLOADEXPENSE /////////////////////////////////
	var tassetloadexpense= new MetaTable("assetloadexpense");
	tassetloadexpense.defineColumn("idexp", typeof(int),false);
	tassetloadexpense.defineColumn("ct", typeof(DateTime));
	tassetloadexpense.defineColumn("cu", typeof(string));
	tassetloadexpense.defineColumn("lt", typeof(DateTime));
	tassetloadexpense.defineColumn("lu", typeof(string));
	tassetloadexpense.defineColumn("!ymov", typeof(short));
	tassetloadexpense.defineColumn("!nmov", typeof(int));
	tassetloadexpense.defineColumn("!expensedescription", typeof(string));
	tassetloadexpense.defineColumn("!npay", typeof(string));
	tassetloadexpense.defineColumn("!expensedoc", typeof(string));
	tassetloadexpense.defineColumn("!amount", typeof(string));
	tassetloadexpense.defineColumn("idassetload", typeof(int),false);
	Tables.Add(tassetloadexpense);
	tassetloadexpense.defineKey("idassetload", "idexp");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idivapayperiodicity","idregauto","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// ASSETAMORTIZATIONUNLOADVIEW /////////////////////////////////
	var tassetamortizationunloadview= new MetaTable("assetamortizationunloadview");
	tassetamortizationunloadview.defineColumn("namortization", typeof(int),false);
	tassetamortizationunloadview.defineColumn("idasset", typeof(int),false);
	tassetamortizationunloadview.defineColumn("idpiece", typeof(int));
	tassetamortizationunloadview.defineColumn("idinventoryamortization", typeof(int),false);
	tassetamortizationunloadview.defineColumn("codeinventoryamortization", typeof(string),false);
	tassetamortizationunloadview.defineColumn("inventoryamortization", typeof(string),false);
	tassetamortizationunloadview.defineColumn("idinventory", typeof(int),false);
	tassetamortizationunloadview.defineColumn("inventory", typeof(string),false);
	tassetamortizationunloadview.defineColumn("ninventory", typeof(int));
	tassetamortizationunloadview.defineColumn("idlocation", typeof(int));
	tassetamortizationunloadview.defineColumn("locationcode", typeof(string));
	tassetamortizationunloadview.defineColumn("location", typeof(string));
	tassetamortizationunloadview.defineColumn("idcurrlocation", typeof(int));
	tassetamortizationunloadview.defineColumn("currlocationcode", typeof(string));
	tassetamortizationunloadview.defineColumn("currlocation", typeof(string));
	tassetamortizationunloadview.defineColumn("idman", typeof(int));
	tassetamortizationunloadview.defineColumn("manager", typeof(string));
	tassetamortizationunloadview.defineColumn("idcurrman", typeof(int));
	tassetamortizationunloadview.defineColumn("currmanager", typeof(string));
	tassetamortizationunloadview.defineColumn("nassetacquire", typeof(int),false);
	tassetamortizationunloadview.defineColumn("loaddescription", typeof(string),false);
	tassetamortizationunloadview.defineColumn("description", typeof(string),false);
	tassetamortizationunloadview.defineColumn("assetvalue", typeof(decimal));
	tassetamortizationunloadview.defineColumn("amortizationquota", typeof(double));
	tassetamortizationunloadview.defineColumn("amount", typeof(decimal),true,true);
	tassetamortizationunloadview.defineColumn("adate", typeof(DateTime),false);
	tassetamortizationunloadview.defineColumn("idassetunload", typeof(int));
	tassetamortizationunloadview.defineColumn("idassetunloadkind", typeof(int));
	tassetamortizationunloadview.defineColumn("assetunloadkind", typeof(string));
	tassetamortizationunloadview.defineColumn("yassetunload", typeof(short));
	tassetamortizationunloadview.defineColumn("nassetunload", typeof(int));
	tassetamortizationunloadview.defineColumn("idassetload", typeof(int));
	tassetamortizationunloadview.defineColumn("idassetloadkind", typeof(int));
	tassetamortizationunloadview.defineColumn("assetloadkind", typeof(string));
	tassetamortizationunloadview.defineColumn("yassetload", typeof(short));
	tassetamortizationunloadview.defineColumn("nassetload", typeof(int));
	tassetamortizationunloadview.defineColumn("flag", typeof(byte),false);
	tassetamortizationunloadview.defineColumn("flagunload", typeof(string),true,true);
	tassetamortizationunloadview.defineColumn("flagload", typeof(string),true,true);
	tassetamortizationunloadview.defineColumn("transmitted", typeof(string));
	tassetamortizationunloadview.defineColumn("cu", typeof(string),false);
	tassetamortizationunloadview.defineColumn("ct", typeof(DateTime),false);
	tassetamortizationunloadview.defineColumn("lu", typeof(string),false);
	tassetamortizationunloadview.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tassetamortizationunloadview);
	tassetamortizationunloadview.defineKey("namortization");

	//////////////////// HISTORYPAYMENTVIEW /////////////////////////////////
	var thistorypaymentview= new MetaTable("historypaymentview");
	thistorypaymentview.defineColumn("idexp", typeof(int),false);
	thistorypaymentview.defineColumn("ymov", typeof(short),false);
	thistorypaymentview.defineColumn("nmov", typeof(int),false);
	thistorypaymentview.defineColumn("adate", typeof(DateTime),false);
	thistorypaymentview.defineColumn("idreg", typeof(int));
	thistorypaymentview.defineColumn("idman", typeof(int));
	thistorypaymentview.defineColumn("doc", typeof(string));
	thistorypaymentview.defineColumn("docdate", typeof(DateTime));
	thistorypaymentview.defineColumn("description", typeof(string),false);
	thistorypaymentview.defineColumn("competencydate", typeof(DateTime));
	thistorypaymentview.defineColumn("amount", typeof(decimal));
	thistorypaymentview.defineColumn("curramount", typeof(decimal));
	thistorypaymentview.defineColumn("totflag", typeof(byte));
	thistorypaymentview.defineColumn("flagarrear", typeof(string));
	thistorypaymentview.defineColumn("kpay", typeof(int),false);
	thistorypaymentview.defineColumn("ypay", typeof(short),false);
	thistorypaymentview.defineColumn("npay", typeof(int),false);
	thistorypaymentview.defineColumn("idfin", typeof(int));
	thistorypaymentview.defineColumn("idupb", typeof(string));
	thistorypaymentview.defineColumn("idtreasurer", typeof(int));
	thistorypaymentview.defineColumn("codetreasurer", typeof(string),false);
	Tables.Add(thistorypaymentview);
	thistorypaymentview.defineKey("idexp");

	#endregion


	#region DataRelation creation
	this.defineRelation("assetload_assetamortizationunloadview","assetload","assetamortizationunloadview","idassetload");
	this.defineRelation("assetloadassetloadexpense","assetload","assetloadexpense","idassetload");
	this.defineRelation("historypaymentview_assetloadexpense","historypaymentview","assetloadexpense","idexp");
	this.defineRelation("assetloadassetacquireview","assetload","assetacquireview","idassetload");
	this.defineRelation("assetloadmotiveassetload","assetloadmotive","assetload","idmot");
	this.defineRelation("assetloadkindassetload","assetloadkind","assetload","idassetloadkind");
	this.defineRelation("registryassetload","registry","assetload","idreg");
	#endregion

}
}
}
