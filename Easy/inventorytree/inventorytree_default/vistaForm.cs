
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
using meta_inventorytree;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace inventorytree_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Classificazione inventariale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public inventorytreeTable inventorytree 		=> (inventorytreeTable)Tables["inventorytree"];

	///<summary>
	///Classificazione gerarchica inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytreesorting 		=> (MetaTable)Tables["inventorytreesorting"];

	///<summary>
	///Livelli della classificazione inventariale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorysortinglevel 		=> (MetaTable)Tables["inventorysortinglevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytreeview 		=> (MetaTable)Tables["inventorytreeview"];

	///<summary>
	///Tipo Ammortamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventoryamortization 		=> (MetaTable)Tables["inventoryamortization"];

	///<summary>
	///Quota ammortamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorysortingamortizationyear 		=> (MetaTable)Tables["inventorysortingamortizationyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_load 		=> (MetaTable)Tables["accmotiveapplied_load"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_unload 		=> (MetaTable)Tables["accmotiveapplied_unload"];

	///<summary>
	///Configurazione multicampo per classificazione inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytreemultifieldkind 		=> (MetaTable)Tables["inventorytreemultifieldkind"];

	///<summary>
	///Campi aggiuntivi per cespiti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable multifieldkind 		=> (MetaTable)Tables["multifieldkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingview 		=> (MetaTable)Tables["sortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_amortization 		=> (MetaTable)Tables["accmotive_amortization"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_amortization_unload 		=> (MetaTable)Tables["accmotive_amortization_unload"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_discount 		=> (MetaTable)Tables["accmotiveapplied_discount"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_transfer 		=> (MetaTable)Tables["accmotiveapplied_transfer"];

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
	//////////////////// INVENTORYTREE /////////////////////////////////
	var tinventorytree= new inventorytreeTable();
	tinventorytree.addBaseColumns("idinv","codeinv","paridinv","nlevel","description","txt","rtf","cu","ct","lu","lt","idaccmotiveunload","idaccmotiveload","lookupcode","idaccmotivediscount","idaccmotivetransfer");
	Tables.Add(tinventorytree);
	tinventorytree.defineKey("idinv");

	//////////////////// INVENTORYTREESORTING /////////////////////////////////
	var tinventorytreesorting= new MetaTable("inventorytreesorting");
	tinventorytreesorting.defineColumn("idsor", typeof(int),false);
	tinventorytreesorting.defineColumn("idinv", typeof(int),false);
	tinventorytreesorting.defineColumn("cu", typeof(string),false);
	tinventorytreesorting.defineColumn("ct", typeof(DateTime),false);
	tinventorytreesorting.defineColumn("lu", typeof(string),false);
	tinventorytreesorting.defineColumn("lt", typeof(DateTime),false);
	tinventorytreesorting.defineColumn("!codiceclass", typeof(string));
	tinventorytreesorting.defineColumn("!description", typeof(string));
	tinventorytreesorting.defineColumn("!sortingkind", typeof(string));
	Tables.Add(tinventorytreesorting);
	tinventorytreesorting.defineKey("idinv", "idsor");

	//////////////////// INVENTORYSORTINGLEVEL /////////////////////////////////
	var tinventorysortinglevel= new MetaTable("inventorysortinglevel");
	tinventorysortinglevel.defineColumn("nlevel", typeof(byte),false);
	tinventorysortinglevel.defineColumn("description", typeof(string),false);
	tinventorysortinglevel.defineColumn("codelen", typeof(byte),false);
	tinventorysortinglevel.defineColumn("flag", typeof(byte),false);
	tinventorysortinglevel.defineColumn("cu", typeof(string),false);
	tinventorysortinglevel.defineColumn("ct", typeof(DateTime),false);
	tinventorysortinglevel.defineColumn("lu", typeof(string),false);
	tinventorysortinglevel.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tinventorysortinglevel);
	tinventorysortinglevel.defineKey("nlevel");

	//////////////////// INVENTORYTREEVIEW /////////////////////////////////
	var tinventorytreeview= new MetaTable("inventorytreeview");
	tinventorytreeview.defineColumn("idinv", typeof(int),false);
	tinventorytreeview.defineColumn("codeinv", typeof(string),false);
	tinventorytreeview.defineColumn("nlevel", typeof(byte),false);
	tinventorytreeview.defineColumn("leveldescr", typeof(string),false);
	tinventorytreeview.defineColumn("paridinv", typeof(int));
	tinventorytreeview.defineColumn("description", typeof(string),false);
	tinventorytreeview.defineColumn("idinv_lev1", typeof(int),false);
	tinventorytreeview.defineColumn("codeinv_lev1", typeof(string),false);
	tinventorytreeview.defineColumn("lookupcode", typeof(string));
	tinventorytreeview.defineColumn("idaccmotiveunload", typeof(string));
	tinventorytreeview.defineColumn("codemotiveunload", typeof(string));
	tinventorytreeview.defineColumn("motiveunload", typeof(string));
	tinventorytreeview.defineColumn("idaccmotiveload", typeof(string));
	tinventorytreeview.defineColumn("codemotiveload", typeof(string));
	tinventorytreeview.defineColumn("motiveload", typeof(string));
	tinventorytreeview.defineColumn("cu", typeof(string),false);
	tinventorytreeview.defineColumn("ct", typeof(DateTime),false);
	tinventorytreeview.defineColumn("lu", typeof(string),false);
	tinventorytreeview.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tinventorytreeview);

	//////////////////// INVENTORYAMORTIZATION /////////////////////////////////
	var tinventoryamortization= new MetaTable("inventoryamortization");
	tinventoryamortization.defineColumn("idinventoryamortization", typeof(int),false);
	tinventoryamortization.defineColumn("codeinventoryamortization", typeof(string),false);
	tinventoryamortization.defineColumn("description", typeof(string),false);
	tinventoryamortization.defineColumn("flag", typeof(byte),false);
	tinventoryamortization.defineColumn("cu", typeof(string),false);
	tinventoryamortization.defineColumn("ct", typeof(DateTime),false);
	tinventoryamortization.defineColumn("lu", typeof(string),false);
	tinventoryamortization.defineColumn("lt", typeof(DateTime),false);
	tinventoryamortization.defineColumn("active", typeof(string));
	Tables.Add(tinventoryamortization);
	tinventoryamortization.defineKey("idinventoryamortization");

	//////////////////// INVENTORYSORTINGAMORTIZATIONYEAR /////////////////////////////////
	var tinventorysortingamortizationyear= new MetaTable("inventorysortingamortizationyear");
	tinventorysortingamortizationyear.defineColumn("idinv", typeof(int),false);
	tinventorysortingamortizationyear.defineColumn("idinventoryamortization", typeof(int),false);
	tinventorysortingamortizationyear.defineColumn("ayear", typeof(int),false);
	tinventorysortingamortizationyear.defineColumn("!description", typeof(string));
	tinventorysortingamortizationyear.defineColumn("amortizationquota", typeof(double));
	tinventorysortingamortizationyear.defineColumn("cu", typeof(string),false);
	tinventorysortingamortizationyear.defineColumn("ct", typeof(DateTime),false);
	tinventorysortingamortizationyear.defineColumn("lu", typeof(string),false);
	tinventorysortingamortizationyear.defineColumn("lt", typeof(DateTime),false);
	tinventorysortingamortizationyear.defineColumn("idaccmotive", typeof(string));
	tinventorysortingamortizationyear.defineColumn("idaccmotiveunload", typeof(string));
	tinventorysortingamortizationyear.defineColumn("!active", typeof(string));
	tinventorysortingamortizationyear.defineColumn("!codemotive", typeof(string));
	tinventorysortingamortizationyear.defineColumn("!codemotive_unload", typeof(string));
	tinventorysortingamortizationyear.defineColumn("!accmotive", typeof(string));
	tinventorysortingamortizationyear.defineColumn("!accmotive_unload", typeof(string));
	Tables.Add(tinventorysortingamortizationyear);
	tinventorysortingamortizationyear.defineKey("idinv", "idinventoryamortization", "ayear");

	//////////////////// ACCMOTIVEAPPLIED_LOAD /////////////////////////////////
	var taccmotiveapplied_load= new MetaTable("accmotiveapplied_load");
	taccmotiveapplied_load.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_load.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_load.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_load.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_load.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_load.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_load.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_load.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_load.defineColumn("active", typeof(string));
	taccmotiveapplied_load.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_load.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_load.defineColumn("in_use", typeof(string));
	Tables.Add(taccmotiveapplied_load);
	taccmotiveapplied_load.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_UNLOAD /////////////////////////////////
	var taccmotiveapplied_unload= new MetaTable("accmotiveapplied_unload");
	taccmotiveapplied_unload.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_unload.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_unload.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_unload.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_unload.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_unload.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_unload.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_unload.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_unload.defineColumn("active", typeof(string));
	taccmotiveapplied_unload.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_unload.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_unload.defineColumn("in_use", typeof(string));
	Tables.Add(taccmotiveapplied_unload);
	taccmotiveapplied_unload.defineKey("idaccmotive");

	//////////////////// INVENTORYTREEMULTIFIELDKIND /////////////////////////////////
	var tinventorytreemultifieldkind= new MetaTable("inventorytreemultifieldkind");
	tinventorytreemultifieldkind.defineColumn("idinv", typeof(int),false);
	tinventorytreemultifieldkind.defineColumn("idmultifieldkind", typeof(int),false);
	tinventorytreemultifieldkind.defineColumn("lt", typeof(DateTime));
	tinventorytreemultifieldkind.defineColumn("lu", typeof(string));
	Tables.Add(tinventorytreemultifieldkind);
	tinventorytreemultifieldkind.defineKey("idinv", "idmultifieldkind");

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
	tmultifieldkind.defineColumn("fieldcode", typeof(string),false);
	Tables.Add(tmultifieldkind);
	tmultifieldkind.defineKey("idmultifieldkind");

	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new MetaTable("sortingview");
	tsortingview.defineColumn("codesorkind", typeof(string),false);
	tsortingview.defineColumn("idsorkind", typeof(int),false);
	tsortingview.defineColumn("sortingkind", typeof(string),false);
	tsortingview.defineColumn("idsor", typeof(int),false);
	tsortingview.defineColumn("sortcode", typeof(string),false);
	tsortingview.defineColumn("nlevel", typeof(byte),false);
	tsortingview.defineColumn("leveldescr", typeof(string),false);
	tsortingview.defineColumn("paridsor", typeof(int));
	tsortingview.defineColumn("description", typeof(string),false);
	tsortingview.defineColumn("ayear", typeof(short),false);
	tsortingview.defineColumn("incomeprevision", typeof(decimal));
	tsortingview.defineColumn("expenseprevision", typeof(decimal));
	tsortingview.defineColumn("start", typeof(short));
	tsortingview.defineColumn("stop", typeof(short));
	tsortingview.defineColumn("cu", typeof(string),false);
	tsortingview.defineColumn("ct", typeof(DateTime),false);
	tsortingview.defineColumn("lu", typeof(string),false);
	tsortingview.defineColumn("lt", typeof(DateTime),false);
	tsortingview.defineColumn("defaultn1", typeof(decimal));
	tsortingview.defineColumn("defaultn2", typeof(decimal));
	tsortingview.defineColumn("defaultn3", typeof(decimal));
	tsortingview.defineColumn("defaultn4", typeof(decimal));
	tsortingview.defineColumn("defaultn5", typeof(decimal));
	tsortingview.defineColumn("defaults1", typeof(string));
	tsortingview.defineColumn("defaults2", typeof(string));
	tsortingview.defineColumn("defaults3", typeof(string));
	tsortingview.defineColumn("defaults4", typeof(string));
	tsortingview.defineColumn("defaults5", typeof(string));
	tsortingview.defineColumn("flagnodate", typeof(string));
	tsortingview.defineColumn("movkind", typeof(string));
	Tables.Add(tsortingview);
	tsortingview.defineKey("idsor");

	//////////////////// ACCMOTIVE_AMORTIZATION /////////////////////////////////
	var taccmotive_amortization= new MetaTable("accmotive_amortization");
	taccmotive_amortization.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_amortization.defineColumn("codemotive", typeof(string),false);
	taccmotive_amortization.defineColumn("title", typeof(string),false);
	Tables.Add(taccmotive_amortization);
	taccmotive_amortization.defineKey("idaccmotive");

	//////////////////// ACCMOTIVE_AMORTIZATION_UNLOAD /////////////////////////////////
	var taccmotive_amortization_unload= new MetaTable("accmotive_amortization_unload");
	taccmotive_amortization_unload.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_amortization_unload.defineColumn("codemotive", typeof(string),false);
	taccmotive_amortization_unload.defineColumn("title", typeof(string),false);
	Tables.Add(taccmotive_amortization_unload);
	taccmotive_amortization_unload.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_DISCOUNT /////////////////////////////////
	var taccmotiveapplied_discount= new MetaTable("accmotiveapplied_discount");
	taccmotiveapplied_discount.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_discount.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_discount.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_discount.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_discount.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_discount.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_discount.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_discount.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_discount.defineColumn("active", typeof(string));
	taccmotiveapplied_discount.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_discount.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_discount.defineColumn("in_use", typeof(string));
	Tables.Add(taccmotiveapplied_discount);
	taccmotiveapplied_discount.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_TRANSFER /////////////////////////////////
	var taccmotiveapplied_transfer= new MetaTable("accmotiveapplied_transfer");
	taccmotiveapplied_transfer.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_transfer.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_transfer.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_transfer.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_transfer.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_transfer.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_transfer.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_transfer.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_transfer.defineColumn("active", typeof(string));
	taccmotiveapplied_transfer.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_transfer.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_transfer.defineColumn("in_use", typeof(string));
	Tables.Add(taccmotiveapplied_transfer);
	taccmotiveapplied_transfer.defineKey("idaccmotive");

	#endregion


	#region DataRelation creation
	this.defineRelation("multifieldkind_inventorytreemultifieldkind","multifieldkind","inventorytreemultifieldkind","idmultifieldkind");
	this.defineRelation("inventorytree_inventorytreemultifieldkind","inventorytree","inventorytreemultifieldkind","idinv");
	this.defineRelation("inventoryamortizationinventorysortingamortizationyear","inventoryamortization","inventorysortingamortizationyear","idinventoryamortization");
	this.defineRelation("inventorytreeinventorysortingamortizationyear","inventorytree","inventorysortingamortizationyear","idinv");
	this.defineRelation("accmotive_amortization_inventorysortingamortizationyear","accmotive_amortization","inventorysortingamortizationyear","idaccmotive");
	var cPar = new []{accmotive_amortization_unload.Columns["idaccmotive"]};
	var cChild = new []{inventorysortingamortizationyear.Columns["idaccmotiveunload"]};
	Relations.Add(new DataRelation("accmotive_amortization_unload_inventorysortingamortizationyear",cPar,cChild,false));

	this.defineRelation("FK_sortingview_inventorytreesorting","sortingview","inventorytreesorting","idsor");
	this.defineRelation("inventorytreeinventorytreesorting","inventorytree","inventorytreesorting","idinv");
	this.defineRelation("inventorysortinglevelinventorytree","inventorysortinglevel","inventorytree","nlevel");
	cPar = new []{accmotiveapplied_load.Columns["idaccmotive"]};
	cChild = new []{inventorytree.Columns["idaccmotiveload"]};
	Relations.Add(new DataRelation("accmotiveapplied_loadinventorytree",cPar,cChild,false));

	cPar = new []{accmotiveapplied_unload.Columns["idaccmotive"]};
	cChild = new []{inventorytree.Columns["idaccmotiveunload"]};
	Relations.Add(new DataRelation("accmotiveapplied_unloadinventorytree",cPar,cChild,false));

	cPar = new []{inventorytree.Columns["idinv"]};
	cChild = new []{inventorytree.Columns["paridinv"]};
	Relations.Add(new DataRelation("inventorytreeinventorytree",cPar,cChild,false));

	cPar = new []{accmotiveapplied_discount.Columns["idaccmotive"]};
	cChild = new []{inventorytree.Columns["idaccmotivediscount"]};
	Relations.Add(new DataRelation("accmotiveapplied_discount_inventorytree",cPar,cChild,false));

	cPar = new []{accmotiveapplied_transfer.Columns["idaccmotive"]};
	cChild = new []{inventorytree.Columns["idaccmotivetransfer"]};
	Relations.Add(new DataRelation("accmotiveapplied_transfer_inventorytree",cPar,cChild,false));

	#endregion

}
}
}
