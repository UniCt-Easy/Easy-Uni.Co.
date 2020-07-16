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
using meta_registry;
using meta_assetacquire;
using meta_mandate;
using meta_asset;
using meta_assetloadkind;
using meta_mandatekind;
using meta_upb;
using meta_sorting;
using meta_config;
using meta_manager;
using meta_location;
using meta_assetload;
using meta_list;
using meta_mandatedetail;
using meta_invoicedetail;
using meta_invoice;
using meta_invoicekind;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace assetacquire_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Causali di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetloadmotive 		=> (MetaTable)Tables["assetloadmotive"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Carico dei cespiti da bolla/fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetacquireTable assetacquire 		=> (assetacquireTable)Tables["assetacquire"];

	///<summary>
	///Utilizzo carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetusage 		=> (MetaTable)Tables["assetusage"];

	///<summary>
	///Contratto Passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandateTable mandate 		=> (mandateTable)Tables["mandate"];

	///<summary>
	///Inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory 		=> (MetaTable)Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytreeview 		=> (MetaTable)Tables["inventorytreeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquireview 		=> (MetaTable)Tables["assetacquireview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetusageview 		=> (MetaTable)Tables["assetusageview"];

	///<summary>
	///Tipo utilizzo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetusagekind 		=> (MetaTable)Tables["assetusagekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandatedetailview 		=> (MetaTable)Tables["mandatedetailview"];

	///<summary>
	///Cespiti e accessori
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetTable asset 		=> (assetTable)Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetview1 		=> (MetaTable)Tables["assetview1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetview 		=> (MetaTable)Tables["assetview"];

	///<summary>
	///Tipi di buoni di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetloadkindTable assetloadkind 		=> (assetloadkindTable)Tables["assetloadkind"];

	///<summary>
	///Tipo contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandatekindTable mandatekind 		=> (mandatekindTable)Tables["mandatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview 		=> (MetaTable)Tables["registrymainview"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting1 		=> (sortingTable)Tables["sorting1"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting2 		=> (sortingTable)Tables["sorting2"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting3 		=> (sortingTable)Tables["sorting3"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public managerTable manager 		=> (managerTable)Tables["manager"];

	///<summary>
	///Piano delle Ubicazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public locationTable location 		=> (locationTable)Tables["location"];

	///<summary>
	///Responsabile cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetmanager 		=> (MetaTable)Tables["assetmanager"];

	///<summary>
	///Ubicazione cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetlocation 		=> (MetaTable)Tables["assetlocation"];

	///<summary>
	///Buono di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetloadTable assetload 		=> (assetloadTable)Tables["assetload"];

	///<summary>
	///Campi aggiuntivi per cespiti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable multifieldkind 		=> (MetaTable)Tables["multifieldkind"];

	///<summary>
	///Configurazione multicampo per classificazione inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytreemultifieldkind 		=> (MetaTable)Tables["inventorytreemultifieldkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable submanager 		=> (MetaTable)Tables["submanager"];

	///<summary>
	///Consegnatario cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetsubmanager 		=> (MetaTable)Tables["assetsubmanager"];

	///<summary>
	///Listino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public listTable list 		=> (listTable)Tables["list"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listview 		=> (MetaTable)Tables["listview"];

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
	///Fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoiceTable invoice 		=> (invoiceTable)Tables["invoice"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

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
	//////////////////// ASSETLOADMOTIVE /////////////////////////////////
	var tassetloadmotive= new MetaTable("assetloadmotive");
	tassetloadmotive.defineColumn("idmot", typeof(int),false);
	tassetloadmotive.defineColumn("description", typeof(string),false);
	tassetloadmotive.defineColumn("cu", typeof(string),false);
	tassetloadmotive.defineColumn("ct", typeof(DateTime),false);
	tassetloadmotive.defineColumn("lu", typeof(string),false);
	tassetloadmotive.defineColumn("lt", typeof(DateTime),false);
	tassetloadmotive.defineColumn("active", typeof(string));
	Tables.Add(tassetloadmotive);
	tassetloadmotive.defineKey("idmot");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","annotation","birthdate","gender","surname","forename","foreigncf","active","cu","ct","lu","lt");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ASSETACQUIRE /////////////////////////////////
	var tassetacquire= new assetacquireTable();
	tassetacquire.addBaseColumns("nassetacquire","idmankind","yman","nman","rownum","idreg","flag","idmot","idinv","description","idinventory","idassetload","number","taxable","tax","abatable","taxrate","discount","startnumber","adate","txt","rtf","cu","ct","lu","lt","transmitted","idupb","idsor1","idsor2","idsor3","historicalvalue","idlist","yinv","ninv","idinvkind","invrownum");
	Tables.Add(tassetacquire);
	tassetacquire.defineKey("nassetacquire");

	//////////////////// ASSETUSAGE /////////////////////////////////
	var tassetusage= new MetaTable("assetusage");
	tassetusage.defineColumn("nassetacquire", typeof(int),false);
	tassetusage.defineColumn("idassetusagekind", typeof(int),false);
	tassetusage.defineColumn("cu", typeof(string),false);
	tassetusage.defineColumn("ct", typeof(DateTime),false);
	tassetusage.defineColumn("lu", typeof(string),false);
	tassetusage.defineColumn("lt", typeof(DateTime),false);
	tassetusage.defineColumn("!description", typeof(string));
	tassetusage.defineColumn("usagequota", typeof(decimal));
	tassetusage.defineColumn("transmitted", typeof(string));
	Tables.Add(tassetusage);
	tassetusage.defineKey("nassetacquire", "idassetusagekind");

	//////////////////// MANDATE /////////////////////////////////
	var tmandate= new mandateTable();
	tmandate.addBaseColumns("idmankind","yman","nman","idreg","registryreference","description","idman","deliveryexpiration","deliveryaddress","paymentexpiring","idexpirationkind","idcurrency","exchangerate","doc","docdate","adate","officiallyprinted","cu","ct","lu","lt","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tmandate);
	tmandate.defineKey("idmankind", "yman", "nman");

	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new MetaTable("inventory");
	tinventory.defineColumn("idinventory", typeof(int),false);
	tinventory.defineColumn("description", typeof(string),false);
	tinventory.defineColumn("idinventorykind", typeof(int),false);
	tinventory.defineColumn("idinventoryagency", typeof(int),false);
	tinventory.defineColumn("startnumber", typeof(int));
	tinventory.defineColumn("flag", typeof(byte),false);
	tinventory.defineColumn("cu", typeof(string),false);
	tinventory.defineColumn("ct", typeof(DateTime),false);
	tinventory.defineColumn("lu", typeof(string),false);
	tinventory.defineColumn("lt", typeof(DateTime),false);
	tinventory.defineColumn("active", typeof(string));
	tinventory.defineColumn("idsor01", typeof(int));
	tinventory.defineColumn("idsor02", typeof(int));
	tinventory.defineColumn("idsor03", typeof(int));
	tinventory.defineColumn("idsor04", typeof(int));
	tinventory.defineColumn("idsor05", typeof(int));
	Tables.Add(tinventory);
	tinventory.defineKey("idinventory");

	//////////////////// INVENTORYTREEVIEW /////////////////////////////////
	var tinventorytreeview= new MetaTable("inventorytreeview");
	tinventorytreeview.defineColumn("idinv", typeof(int),false);
	tinventorytreeview.defineColumn("codeinv", typeof(string),false);
	tinventorytreeview.defineColumn("nlevel", typeof(byte),false);
	tinventorytreeview.defineColumn("leveldescr", typeof(string),false);
	tinventorytreeview.defineColumn("paridinv", typeof(int));
	tinventorytreeview.defineColumn("idinv_lev1", typeof(int),false);
	tinventorytreeview.defineColumn("codeinv_lev1", typeof(string),false);
	tinventorytreeview.defineColumn("description", typeof(string),false);
	tinventorytreeview.defineColumn("cu", typeof(string),false);
	tinventorytreeview.defineColumn("ct", typeof(DateTime),false);
	tinventorytreeview.defineColumn("lu", typeof(string),false);
	tinventorytreeview.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tinventorytreeview);
	tinventorytreeview.defineKey("idinv");

	//////////////////// ASSETACQUIREVIEW /////////////////////////////////
	var tassetacquireview= new MetaTable("assetacquireview");
	tassetacquireview.defineColumn("nassetacquire", typeof(int),false);
	tassetacquireview.defineColumn("idmankind", typeof(string));
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
	tassetacquireview.defineColumn("inventory", typeof(string));
	tassetacquireview.defineColumn("idassetloadkind", typeof(int));
	tassetacquireview.defineColumn("assetloadkind", typeof(string));
	tassetacquireview.defineColumn("yassetload", typeof(short));
	tassetacquireview.defineColumn("nassetload", typeof(int));
	tassetacquireview.defineColumn("number", typeof(int),false);
	tassetacquireview.defineColumn("taxable", typeof(decimal));
	tassetacquireview.defineColumn("taxrate", typeof(double));
	tassetacquireview.defineColumn("discount", typeof(double));
	tassetacquireview.defineColumn("total", typeof(decimal),true,true);
	tassetacquireview.defineColumn("startnumber", typeof(int));
	tassetacquireview.defineColumn("adate", typeof(DateTime),false);
	tassetacquireview.defineColumn("flagload", typeof(string),false);
	tassetacquireview.defineColumn("loadkind", typeof(string),false);
	tassetacquireview.defineColumn("ispieceacquire", typeof(string),false);
	tassetacquireview.defineColumn("cu", typeof(string),false);
	tassetacquireview.defineColumn("ct", typeof(DateTime),false);
	tassetacquireview.defineColumn("lu", typeof(string),false);
	tassetacquireview.defineColumn("lt", typeof(DateTime),false);
	tassetacquireview.defineColumn("cost", typeof(decimal));
	tassetacquireview.defineColumn("abatable", typeof(decimal));
	tassetacquireview.defineColumn("transmitted", typeof(string));
	tassetacquireview.defineColumn("idupb", typeof(string));
	tassetacquireview.defineColumn("idsor01", typeof(int));
	tassetacquireview.defineColumn("idsor02", typeof(int));
	tassetacquireview.defineColumn("idsor03", typeof(int));
	tassetacquireview.defineColumn("idsor04", typeof(int));
	tassetacquireview.defineColumn("idsor05", typeof(int));
	tassetacquireview.defineColumn("idlist", typeof(int));
	tassetacquireview.defineColumn("yinv", typeof(short));
	tassetacquireview.defineColumn("ninv", typeof(int));
	tassetacquireview.defineColumn("idinvkind", typeof(int));
	tassetacquireview.defineColumn("invrownum", typeof(int));
	tassetacquireview.defineColumn("invoicekind", typeof(string));
	tassetacquireview.defineColumn("codeupb", typeof(string));
	tassetacquireview.defineColumn("upb", typeof(string));
	tassetacquireview.defineColumn("ratificationdate", typeof(DateTime));
	Tables.Add(tassetacquireview);
	tassetacquireview.defineKey("nassetacquire");

	//////////////////// ASSETUSAGEVIEW /////////////////////////////////
	var tassetusageview= new MetaTable("assetusageview");
	tassetusageview.defineColumn("nassetacquire", typeof(int),false);
	tassetusageview.defineColumn("idassetusagekind", typeof(int),false);
	tassetusageview.defineColumn("assetusagekind", typeof(string),false);
	tassetusageview.defineColumn("usagequota", typeof(decimal));
	tassetusageview.defineColumn("cu", typeof(string),false);
	tassetusageview.defineColumn("ct", typeof(DateTime),false);
	tassetusageview.defineColumn("lu", typeof(string),false);
	tassetusageview.defineColumn("lt", typeof(DateTime),false);
	tassetusageview.defineColumn("transmitted", typeof(string));
	Tables.Add(tassetusageview);
	tassetusageview.defineKey("nassetacquire", "idassetusagekind");

	//////////////////// ASSETUSAGEKIND /////////////////////////////////
	var tassetusagekind= new MetaTable("assetusagekind");
	tassetusagekind.defineColumn("idassetusagekind", typeof(int),false);
	tassetusagekind.defineColumn("description", typeof(string),false);
	Tables.Add(tassetusagekind);
	tassetusagekind.defineKey("idassetusagekind");

	//////////////////// MANDATEDETAILVIEW /////////////////////////////////
	var tmandatedetailview= new MetaTable("mandatedetailview");
	tmandatedetailview.defineColumn("idmankind", typeof(string),false);
	tmandatedetailview.defineColumn("yman", typeof(short),false);
	tmandatedetailview.defineColumn("nman", typeof(int),false);
	tmandatedetailview.defineColumn("rownum", typeof(int),false);
	tmandatedetailview.defineColumn("idinv", typeof(int));
	tmandatedetailview.defineColumn("codeinv", typeof(string));
	tmandatedetailview.defineColumn("inventorytree", typeof(string));
	tmandatedetailview.defineColumn("idreg", typeof(int));
	tmandatedetailview.defineColumn("registry", typeof(string));
	tmandatedetailview.defineColumn("detaildescription", typeof(string));
	tmandatedetailview.defineColumn("annotations", typeof(string));
	tmandatedetailview.defineColumn("number", typeof(decimal));
	tmandatedetailview.defineColumn("taxable", typeof(decimal));
	tmandatedetailview.defineColumn("tax", typeof(decimal));
	tmandatedetailview.defineColumn("taxrate", typeof(double));
	tmandatedetailview.defineColumn("discount", typeof(double));
	tmandatedetailview.defineColumn("assetkind", typeof(string),false);
	tmandatedetailview.defineColumn("cu", typeof(string),false);
	tmandatedetailview.defineColumn("ct", typeof(DateTime),false);
	tmandatedetailview.defineColumn("lu", typeof(string),false);
	tmandatedetailview.defineColumn("lt", typeof(DateTime),false);
	tmandatedetailview.defineColumn("mankind", typeof(string));
	tmandatedetailview.defineColumn("idgroup", typeof(int));
	tmandatedetailview.defineColumn("idsor01", typeof(int));
	tmandatedetailview.defineColumn("idsor02", typeof(int));
	tmandatedetailview.defineColumn("idsor03", typeof(int));
	tmandatedetailview.defineColumn("idsor04", typeof(int));
	tmandatedetailview.defineColumn("idsor05", typeof(int));
	tmandatedetailview.defineColumn("idlocation", typeof(int));
	tmandatedetailview.defineColumn("locationcode", typeof(string));
	tmandatedetailview.defineColumn("location", typeof(string));
	Tables.Add(tmandatedetailview);
	tmandatedetailview.defineKey("yman", "nman", "idmankind", "rownum");

	//////////////////// ASSET /////////////////////////////////
	var tasset= new assetTable();
	tasset.addBaseColumns("idasset","idpiece","nassetacquire","ninventory","idassetunload","idcurrman","idcurrsubman","idcurrlocation","cu","ct","lu","lt","lifestart","transmitted","flag","idasset_prev","idpiece_prev","multifield","amortizationquota","idinventoryamortization","idinventory","rfid");
	tasset.defineColumn("!numeroriga", typeof(int));
	tasset.defineColumn("!ninventory", typeof(int));
	tasset.defineColumn("!location", typeof(string));
	tasset.defineColumn("!manager", typeof(string));
	tasset.defineColumn("!assetdescription", typeof(string));
	tasset.defineColumn("!submanager", typeof(string));
	Tables.Add(tasset);
	tasset.defineKey("idasset", "idpiece");

	//////////////////// ASSETVIEW1 /////////////////////////////////
	var tassetview1= new MetaTable("assetview1");
	tassetview1.defineColumn("ninventory", typeof(int));
	tassetview1.defineColumn("description", typeof(string),false);
	tassetview1.defineColumn("idasset", typeof(int),false);
	tassetview1.defineColumn("idpiece", typeof(int),false);
	tassetview1.defineColumn("idasset_prev", typeof(int));
	tassetview1.defineColumn("idpiece_prev", typeof(int));
	tassetview1.defineColumn("idinventory_prev", typeof(int));
	tassetview1.defineColumn("codeinventory_prev", typeof(string));
	tassetview1.defineColumn("inventory_prev", typeof(string));
	tassetview1.defineColumn("ninventory_prev", typeof(int));
	tassetview1.defineColumn("idasset_next", typeof(int));
	tassetview1.defineColumn("idpiece_next", typeof(int));
	tassetview1.defineColumn("idinventory_next", typeof(int));
	tassetview1.defineColumn("codeinventory_next", typeof(string));
	tassetview1.defineColumn("inventory_next", typeof(string));
	tassetview1.defineColumn("ninventory_next", typeof(int));
	tassetview1.defineColumn("nassetacquire", typeof(int));
	tassetview1.defineColumn("idcurrlocation", typeof(int));
	tassetview1.defineColumn("currlocationcode", typeof(string));
	tassetview1.defineColumn("currlocation", typeof(string));
	tassetview1.defineColumn("idcurrman", typeof(int));
	tassetview1.defineColumn("currmanager", typeof(string));
	tassetview1.defineColumn("idcurrsubman", typeof(int));
	tassetview1.defineColumn("currsubmanager", typeof(string));
	tassetview1.defineColumn("inventorytree", typeof(string));
	tassetview1.defineColumn("idinv", typeof(int));
	tassetview1.defineColumn("codeinv", typeof(string));
	tassetview1.defineColumn("idinventory", typeof(int));
	tassetview1.defineColumn("inventory", typeof(string));
	tassetview1.defineColumn("taxable", typeof(decimal));
	tassetview1.defineColumn("taxrate", typeof(double));
	tassetview1.defineColumn("discount", typeof(double));
	tassetview1.defineColumn("lifestart", typeof(DateTime));
	tassetview1.defineColumn("idassetunload", typeof(int));
	tassetview1.defineColumn("idassetunloadkind", typeof(int));
	tassetview1.defineColumn("yassetunload", typeof(short));
	tassetview1.defineColumn("nassetunload", typeof(int));
	tassetview1.defineColumn("cu", typeof(string),false);
	tassetview1.defineColumn("ct", typeof(DateTime),false);
	tassetview1.defineColumn("lu", typeof(string),false);
	tassetview1.defineColumn("lt", typeof(DateTime),false);
	tassetview1.defineColumn("transmitted", typeof(string));
	tassetview1.defineColumn("flag", typeof(byte),false);
	tassetview1.defineColumn("multifield", typeof(string));
	tassetview1.defineColumn("idsor01", typeof(int));
	tassetview1.defineColumn("idsor02", typeof(int));
	tassetview1.defineColumn("idsor03", typeof(int));
	tassetview1.defineColumn("idsor04", typeof(int));
	tassetview1.defineColumn("idsor05", typeof(int));
	tassetview1.defineColumn("amortizationquota", typeof(double));
	tassetview1.defineColumn("idinventoryamortization", typeof(int));
	tassetview1.defineColumn("rfid", typeof(string));
	Tables.Add(tassetview1);
	tassetview1.defineKey("idasset");

	//////////////////// ASSETVIEW /////////////////////////////////
	var tassetview= new MetaTable("assetview");
	tassetview.defineColumn("ninventory", typeof(int));
	tassetview.defineColumn("description", typeof(string),false);
	tassetview.defineColumn("idasset", typeof(int),false);
	tassetview.defineColumn("idpiece", typeof(int),false);
	tassetview.defineColumn("idasset_prev", typeof(int));
	tassetview.defineColumn("idpiece_prev", typeof(int));
	tassetview.defineColumn("idinventory_prev", typeof(int));
	tassetview.defineColumn("codeinventory_prev", typeof(string));
	tassetview.defineColumn("inventory_prev", typeof(string));
	tassetview.defineColumn("ninventory_prev", typeof(int));
	tassetview.defineColumn("idasset_next", typeof(int));
	tassetview.defineColumn("idpiece_next", typeof(int));
	tassetview.defineColumn("idinventory_next", typeof(int));
	tassetview.defineColumn("codeinventory_next", typeof(string));
	tassetview.defineColumn("inventory_next", typeof(string));
	tassetview.defineColumn("ninventory_next", typeof(int));
	tassetview.defineColumn("nassetacquire", typeof(int));
	tassetview.defineColumn("idcurrlocation", typeof(int));
	tassetview.defineColumn("currlocationcode", typeof(string));
	tassetview.defineColumn("currlocation", typeof(string));
	tassetview.defineColumn("idcurrman", typeof(int));
	tassetview.defineColumn("currmanager", typeof(string));
	tassetview.defineColumn("idcurrsubman", typeof(int));
	tassetview.defineColumn("currsubmanager", typeof(string));
	tassetview.defineColumn("inventorytree", typeof(string));
	tassetview.defineColumn("idinv", typeof(int));
	tassetview.defineColumn("codeinv", typeof(string));
	tassetview.defineColumn("idinventory", typeof(int));
	tassetview.defineColumn("inventory", typeof(string));
	tassetview.defineColumn("taxable", typeof(decimal));
	tassetview.defineColumn("taxrate", typeof(double));
	tassetview.defineColumn("discount", typeof(double));
	tassetview.defineColumn("lifestart", typeof(DateTime));
	tassetview.defineColumn("idassetunload", typeof(int));
	tassetview.defineColumn("idassetunloadkind", typeof(int));
	tassetview.defineColumn("yassetunload", typeof(short));
	tassetview.defineColumn("nassetunload", typeof(int));
	tassetview.defineColumn("cu", typeof(string),false);
	tassetview.defineColumn("ct", typeof(DateTime),false);
	tassetview.defineColumn("lu", typeof(string),false);
	tassetview.defineColumn("lt", typeof(DateTime),false);
	tassetview.defineColumn("transmitted", typeof(string));
	tassetview.defineColumn("flag", typeof(byte),false);
	tassetview.defineColumn("multifield", typeof(string));
	tassetview.defineColumn("idsor01", typeof(int));
	tassetview.defineColumn("idsor02", typeof(int));
	tassetview.defineColumn("idsor03", typeof(int));
	tassetview.defineColumn("idsor04", typeof(int));
	tassetview.defineColumn("idsor05", typeof(int));
	tassetview.defineColumn("amortizationquota", typeof(double));
	tassetview.defineColumn("idinventoryamortization", typeof(int));
	tassetview.defineColumn("rfid", typeof(string));
	Tables.Add(tassetview);
	tassetview.defineKey("idasset", "idpiece");

	//////////////////// ASSETLOADKIND /////////////////////////////////
	var tassetloadkind= new assetloadkindTable();
	tassetloadkind.addBaseColumns("idassetloadkind","description","idinventory","startnumber","cu","ct","lu","lt","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tassetloadkind);
	tassetloadkind.defineKey("idassetloadkind");

	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new mandatekindTable();
	tmandatekind.addBaseColumns("idmankind","description","idupb","cu","ct","lu","lt","linktoasset","linktoinvoice","multireg","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tmandatekind);
	tmandatekind.defineKey("idmankind");

	//////////////////// REGISTRYMAINVIEW /////////////////////////////////
	var tregistrymainview= new MetaTable("registrymainview");
	tregistrymainview.defineColumn("idreg", typeof(int),false);
	tregistrymainview.defineColumn("title", typeof(string),false);
	tregistrymainview.defineColumn("idregistryclass", typeof(string));
	tregistrymainview.defineColumn("registryclass", typeof(string));
	tregistrymainview.defineColumn("surname", typeof(string));
	tregistrymainview.defineColumn("forename", typeof(string));
	tregistrymainview.defineColumn("cf", typeof(string));
	tregistrymainview.defineColumn("p_iva", typeof(string));
	tregistrymainview.defineColumn("residence", typeof(int),false);
	tregistrymainview.defineColumn("residencekind", typeof(string));
	tregistrymainview.defineColumn("annotation", typeof(string));
	tregistrymainview.defineColumn("birthdate", typeof(DateTime));
	tregistrymainview.defineColumn("idcity", typeof(int));
	tregistrymainview.defineColumn("city", typeof(string));
	tregistrymainview.defineColumn("gender", typeof(string));
	tregistrymainview.defineColumn("foreigncf", typeof(string));
	tregistrymainview.defineColumn("idtitle", typeof(string));
	tregistrymainview.defineColumn("qualification", typeof(string));
	tregistrymainview.defineColumn("idmaritalstatus", typeof(string));
	tregistrymainview.defineColumn("maritalstatus", typeof(string));
	tregistrymainview.defineColumn("sortcode", typeof(string));
	tregistrymainview.defineColumn("registrykind", typeof(string));
	tregistrymainview.defineColumn("human", typeof(string));
	tregistrymainview.defineColumn("active", typeof(string),false);
	tregistrymainview.defineColumn("badgecode", typeof(string));
	tregistrymainview.defineColumn("maritalsurname", typeof(string));
	tregistrymainview.defineColumn("idcategory", typeof(string));
	tregistrymainview.defineColumn("extmatricula", typeof(string));
	tregistrymainview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrymainview.defineColumn("cu", typeof(string),false);
	tregistrymainview.defineColumn("ct", typeof(DateTime),false);
	tregistrymainview.defineColumn("lu", typeof(string),false);
	tregistrymainview.defineColumn("lt", typeof(DateTime),false);
	tregistrymainview.defineColumn("location", typeof(string));
	tregistrymainview.defineColumn("idnation", typeof(int));
	tregistrymainview.defineColumn("nation", typeof(string));
	Tables.Add(tregistrymainview);
	tregistrymainview.defineKey("idreg");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb","title","paridupb","idunderwriter","idman","requested","granted","previousappropriation","expiration","cu","ct","lu","lt","assured","printingorder","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new sortingTable();
	tsorting1.TableName = "sorting1";
	tsorting1.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	tsorting1.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting1);
	tsorting1.defineKey("idsor");

	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new sortingTable();
	tsorting2.TableName = "sorting2";
	tsorting2.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	tsorting2.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting2);
	tsorting2.defineKey("idsor");

	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new sortingTable();
	tsorting3.TableName = "sorting3";
	tsorting3.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	tsorting3.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting3);
	tsorting3.defineKey("idsor");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idivapayperiodicity","idregauto","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new managerTable();
	tmanager.addBaseColumns("active","ct","cu","email","iddivision","lt","lu","passwordweb","phonenumber","title","userweb","idman","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// LOCATION /////////////////////////////////
	var tlocation= new locationTable();
	tlocation.addBaseColumns("active","ct","cu","description","locationcode","lt","lu","idman","nlevel","idlocation","paridlocation");
	Tables.Add(tlocation);
	tlocation.defineKey("idlocation");

	//////////////////// ASSETMANAGER /////////////////////////////////
	var tassetmanager= new MetaTable("assetmanager");
	tassetmanager.defineColumn("idasset", typeof(int),false);
	tassetmanager.defineColumn("idassetmanager", typeof(int),false);
	tassetmanager.defineColumn("start", typeof(DateTime));
	tassetmanager.defineColumn("ct", typeof(DateTime),false);
	tassetmanager.defineColumn("cu", typeof(string),false);
	tassetmanager.defineColumn("lt", typeof(DateTime),false);
	tassetmanager.defineColumn("lu", typeof(string),false);
	tassetmanager.defineColumn("idman", typeof(int),false);
	Tables.Add(tassetmanager);
	tassetmanager.defineKey("idasset", "idassetmanager");

	//////////////////// ASSETLOCATION /////////////////////////////////
	var tassetlocation= new MetaTable("assetlocation");
	tassetlocation.defineColumn("idasset", typeof(int),false);
	tassetlocation.defineColumn("idassetlocation", typeof(int),false);
	tassetlocation.defineColumn("start", typeof(DateTime));
	tassetlocation.defineColumn("ct", typeof(DateTime),false);
	tassetlocation.defineColumn("cu", typeof(string),false);
	tassetlocation.defineColumn("lt", typeof(DateTime),false);
	tassetlocation.defineColumn("lu", typeof(string),false);
	tassetlocation.defineColumn("idlocation", typeof(int),false);
	Tables.Add(tassetlocation);
	tassetlocation.defineKey("idasset", "idassetlocation");

	//////////////////// ASSETLOAD /////////////////////////////////
	var tassetload= new assetloadTable();
	tassetload.addBaseColumns("nassetload","yassetload","adate","ct","cu","description","doc","docdate","enactment","enactmentdate","idreg","lt","lu","printdate","ratificationdate","transmitted","idmot","idassetloadkind","idassetload");
	Tables.Add(tassetload);
	tassetload.defineKey("idassetload");

	//////////////////// MULTIFIELDKIND /////////////////////////////////
	var tmultifieldkind= new MetaTable("multifieldkind");
	tmultifieldkind.defineColumn("idmultifieldkind", typeof(int),false);
	tmultifieldkind.defineColumn("fieldname", typeof(string),false);
	tmultifieldkind.defineColumn("systype", typeof(string),false);
	tmultifieldkind.defineColumn("allownull", typeof(string),false);
	tmultifieldkind.defineColumn("lu", typeof(string),false);
	tmultifieldkind.defineColumn("lt", typeof(DateTime),false);
	tmultifieldkind.defineColumn("tag", typeof(string));
	tmultifieldkind.defineColumn("len", typeof(int));
	tmultifieldkind.defineColumn("fieldcode", typeof(string));
	Tables.Add(tmultifieldkind);
	tmultifieldkind.defineKey("idmultifieldkind");

	//////////////////// INVENTORYTREEMULTIFIELDKIND /////////////////////////////////
	var tinventorytreemultifieldkind= new MetaTable("inventorytreemultifieldkind");
	tinventorytreemultifieldkind.defineColumn("idinv", typeof(int),false);
	tinventorytreemultifieldkind.defineColumn("idmultifieldkind", typeof(int),false);
	tinventorytreemultifieldkind.defineColumn("lt", typeof(DateTime));
	tinventorytreemultifieldkind.defineColumn("lu", typeof(string));
	Tables.Add(tinventorytreemultifieldkind);
	tinventorytreemultifieldkind.defineKey("idinv", "idmultifieldkind");

	//////////////////// SUBMANAGER /////////////////////////////////
	var tsubmanager= new MetaTable("submanager");
	tsubmanager.defineColumn("active", typeof(string));
	tsubmanager.defineColumn("ct", typeof(DateTime),false);
	tsubmanager.defineColumn("cu", typeof(string),false);
	tsubmanager.defineColumn("email", typeof(string));
	tsubmanager.defineColumn("lt", typeof(DateTime),false);
	tsubmanager.defineColumn("lu", typeof(string),false);
	tsubmanager.defineColumn("passwordweb", typeof(string));
	tsubmanager.defineColumn("phonenumber", typeof(string));
	tsubmanager.defineColumn("userweb", typeof(string));
	tsubmanager.defineColumn("idman", typeof(int),false);
	tsubmanager.defineColumn("iddivision", typeof(int),false);
	tsubmanager.defineColumn("wantswarn", typeof(string));
	tsubmanager.defineColumn("idsor01", typeof(int));
	tsubmanager.defineColumn("idsor02", typeof(int));
	tsubmanager.defineColumn("idsor03", typeof(int));
	tsubmanager.defineColumn("idsor04", typeof(int));
	tsubmanager.defineColumn("idsor05", typeof(int));
	tsubmanager.defineColumn("newidman", typeof(int));
	tsubmanager.defineColumn("financeactive", typeof(string));
	tsubmanager.defineColumn("title", typeof(string));
	Tables.Add(tsubmanager);
	tsubmanager.defineKey("idman");

	//////////////////// ASSETSUBMANAGER /////////////////////////////////
	var tassetsubmanager= new MetaTable("assetsubmanager");
	tassetsubmanager.defineColumn("idasset", typeof(int),false);
	tassetsubmanager.defineColumn("idassetsubmanager", typeof(int),false);
	tassetsubmanager.defineColumn("ct", typeof(DateTime));
	tassetsubmanager.defineColumn("cu", typeof(string));
	tassetsubmanager.defineColumn("lt", typeof(DateTime));
	tassetsubmanager.defineColumn("lu", typeof(string));
	tassetsubmanager.defineColumn("start", typeof(DateTime));
	tassetsubmanager.defineColumn("idmanager", typeof(int));
	Tables.Add(tassetsubmanager);
	tassetsubmanager.defineKey("idasset", "idassetsubmanager");

	//////////////////// LIST /////////////////////////////////
	var tlist= new listTable();
	tlist.addBaseColumns("idlist","description","intcode","intbarcode","extcode","extbarcode","validitystop","active","idpackage","idunit","unitsforpackage","has_expiry","cu","ct","lu","lt","idlistclass","pic","picext","nmin","ntoreorder","tounload","timesupply","nmaxorder");
	Tables.Add(tlist);
	tlist.defineKey("idlist");

	//////////////////// LISTVIEW /////////////////////////////////
	var tlistview= new MetaTable("listview");
	tlistview.defineColumn("idlist", typeof(int),false);
	tlistview.defineColumn("description", typeof(string),false);
	tlistview.defineColumn("intcode", typeof(string),false);
	tlistview.defineColumn("intbarcode", typeof(string));
	tlistview.defineColumn("extcode", typeof(string));
	tlistview.defineColumn("extbarcode", typeof(string));
	tlistview.defineColumn("validitystop", typeof(DateTime));
	tlistview.defineColumn("active", typeof(string),false);
	tlistview.defineColumn("idpackage", typeof(int));
	tlistview.defineColumn("package", typeof(string));
	tlistview.defineColumn("idunit", typeof(int));
	tlistview.defineColumn("unit", typeof(string));
	tlistview.defineColumn("unitsforpackage", typeof(int));
	tlistview.defineColumn("has_expiry", typeof(string),false);
	tlistview.defineColumn("idlistclass", typeof(string),false);
	tlistview.defineColumn("codelistclass", typeof(string),false);
	tlistview.defineColumn("listclass", typeof(string),false);
	tlistview.defineColumn("pic", typeof(Byte[]));
	tlistview.defineColumn("timesupply", typeof(int));
	tlistview.defineColumn("nmaxorder", typeof(decimal));
	tlistview.defineColumn("authrequired", typeof(string));
	tlistview.defineColumn("assetkind", typeof(string));
	tlistview.defineColumn("flagvisiblekind", typeof(byte));
	Tables.Add(tlistview);
	tlistview.defineKey("idlist");

	//////////////////// MANDATEDETAIL /////////////////////////////////
	var tmandatedetail= new mandatedetailTable();
	tmandatedetail.addBaseColumns("idmankind","yman","nman","rownum","detaildescription","annotations","number","taxable","tax","taxrate","discount","cu","ct","lu","lt","idinv","assetkind","idaccmotive","idivakind","unabatable","flagmixed","idgroup","idlocation");
	Tables.Add(tmandatedetail);
	tmandatedetail.defineKey("idmankind", "yman", "nman", "rownum");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("ninv","rownum","yinv","annotations","competencystart","paymentcompetency","competencystop","ct","cu","detaildescription","discount","idaccmotive","idmankind","idupb","lt","lu","manrownum","nman","number","tax","taxable","unabatable","yman","idestimkind","estimrownum","nestim","yestim","idgroup","idexp_taxable","idexp_iva","idinc_taxable","idinc_iva","ninv_main","yinv_main","idivakind","idinvkind","idsor1","idsor2","idsor3","idintrastatcode","idintrastatmeasure","weight","va3type","intrastatoperationkind","idintrastatservice","idintrastatsupplymethod","idlist","idunit","idpackage","unitsforpackage","npackage","flag","exception12","intra12operationkind","move12","idupb_iva","idinvkind_main","leasing","usedmodesospesometro","resetresidualmandate","idfetransfer","fereferencerule","cupcode","cigcode","idpccdebitstatus","idpccdebitmotive","idcostpartition","expensekind","rounding","idepexp","idepacc","flagbit","idfinmotive","iduniqueformcode");
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("ninv", "rownum", "yinv", "idinvkind");

	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new invoiceTable();
	tinvoice.addBaseColumns("ninv","yinv","active","adate","ct","cu","description","doc","docdate","exchangerate","flagdeferred","idreg","lt","lu","officiallyprinted","packinglistdate","packinglistnum","paymentexpiring","registryreference","rtf","txt","idinvkind","idcurrency","idexpirationkind","idtreasurer","flagintracom","iso_origin","iso_provenance","iso_destination","idcountry_origin","idcountry_destination","idintrastatkind","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","idintrastatpaymethod","iso_payment","flag_ddt","flag","idblacklist","idinvkind_real","yinv_real","ninv_real","autoinvoice","idsor01","idsor02","idsor03","idsor04","idsor05","protocoldate","idfepaymethodcondition","idfepaymethod","nelectronicinvoice","yelectronicinvoice","annotations","arrivalprotocolnum","toincludeinpaymentindicator","resendingpcc","touniqueregister","idstampkind","flag_auto_split_payment","flag_enable_split_payment","idsdi_acquisto","idsdi_vendita","flag_reverse_charge","ipa_acq","rifamm_acq","ipa_ven_emittente","rifamm_ven_emittente","ipa_ven_cliente","rifamm_ven_cliente","ssntipospesa","ssnflagtipospesa","idinvkind_forwarder","yinv_forwarder","ninv_forwarder","flagbit","ssn_nprot");
	Tables.Add(tinvoice);
	tinvoice.defineKey("ninv", "yinv", "idinvkind");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("ct","cu","description","lt","lu","codeinvkind","idinvkind","flag","flag_autodocnumbering","formatstring","active","idinvkind_auto","printingcode","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","notes1","notes2","notes3","ipa_fe","riferimento_amministrazione","enable_fe");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_invoicekind_invoice","invoicekind","invoice","idinvkind");
	this.defineRelation("FK_invoice_invoicedetail","invoice","invoicedetail","ninv","yinv","idinvkind");
	this.defineRelation("FK_invoicekind_invoicedetail","invoicekind","invoicedetail","idinvkind");
	this.defineRelation("mandatemandatedetail","mandate","mandatedetail","idmankind","yman","nman");
	this.defineRelation("mandatekindmandatedetail","mandatekind","mandatedetail","idmankind");
	var cPar = new []{submanager.Columns["idman"]};
	var cChild = new []{assetsubmanager.Columns["idmanager"]};
	Relations.Add(new DataRelation("FK_submanager_assetsubmanager",cPar,cChild,false));

	this.defineRelation("asset_assetsubmanager","asset","assetsubmanager","idasset");
	this.defineRelation("multifieldkind_inventorytreemultifieldkind","multifieldkind","inventorytreemultifieldkind","idmultifieldkind");
	this.defineRelation("location_assetlocation","location","assetlocation","idlocation");
	this.defineRelation("asset_assetlocation","asset","assetlocation","idasset");
	this.defineRelation("manager_assetmanager","manager","assetmanager","idman");
	this.defineRelation("asset_assetmanager","asset","assetmanager","idasset");
	this.defineRelation("assetviewasset","assetview1","asset","idasset");
	this.defineRelation("assetacquireasset","assetacquire","asset","nassetacquire");
	this.defineRelation("mandatekindmandate","mandatekind","mandate","idmankind");
	this.defineRelation("assetusagekindassetusage","assetusagekind","assetusage","idassetusagekind");
	this.defineRelation("assetacquireassetusage","assetacquire","assetusage","nassetacquire");
	this.defineRelation("listview_assetacquire","listview","assetacquire","idlist");
	this.defineRelation("assetload_assetacquire","assetload","assetacquire","idassetload");
	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{assetacquire.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_assetacquire",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{assetacquire.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_assetacquire",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{assetacquire.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1assetacquire",cPar,cChild,false));

	this.defineRelation("upbassetacquire","upb","assetacquire","idupb");
	this.defineRelation("assetloadmotiveassetacquire","assetloadmotive","assetacquire","idmot");
	this.defineRelation("registryassetacquire","registry","assetacquire","idreg");
	this.defineRelation("mandateassetacquire","mandate","assetacquire","idmankind","yman","nman");
	this.defineRelation("inventoryassetacquire","inventory","assetacquire","idinventory");
	this.defineRelation("inventorytreeviewassetacquire","inventorytreeview","assetacquire","idinv");
	this.defineRelation("FK_invoice_assetacquire","invoice","assetacquire","ninv","yinv","idinvkind");
	#endregion

}
}
}
