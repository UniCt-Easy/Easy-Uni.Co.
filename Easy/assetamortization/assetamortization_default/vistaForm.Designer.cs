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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace assetamortization_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory 		=> Tables["inventory"];

	///<summary>
	///Tipo Ammortamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventoryamortization 		=> Tables["inventoryamortization"];

	///<summary>
	///Rivalutazione/Svalutazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetamortization 		=> Tables["assetamortization"];

	///<summary>
	///Tipi di buoni di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunloadkind 		=> Tables["assetunloadkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytreeview 		=> Tables["inventorytreeview"];

	///<summary>
	///Buono di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunload 		=> Tables["assetunload"];

	///<summary>
	///Buono di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetload 		=> Tables["assetload"];

	///<summary>
	///Tipi di buoni di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadkind 		=> Tables["assetloadkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetpieceview 		=> Tables["assetpieceview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetamortizationview 		=> Tables["assetamortizationview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new DataTable("inventory");
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("idinventorykind", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	tinventory.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	tinventory.Columns.Add( new DataColumn("active", typeof(string)));
	tinventory.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinventory);
	tinventory.PrimaryKey =  new DataColumn[]{tinventory.Columns["idinventory"]};


	//////////////////// INVENTORYAMORTIZATION /////////////////////////////////
	var tinventoryamortization= new DataTable("inventoryamortization");
	C= new DataColumn("idinventoryamortization", typeof(int));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	tinventoryamortization.Columns.Add( new DataColumn("age", typeof(int)));
	C= new DataColumn("codeinventoryamortization", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	tinventoryamortization.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tinventoryamortization);
	tinventoryamortization.PrimaryKey =  new DataColumn[]{tinventoryamortization.Columns["idinventoryamortization"]};


	//////////////////// ASSETAMORTIZATION /////////////////////////////////
	var tassetamortization= new DataTable("assetamortization");
	C= new DataColumn("namortization", typeof(int));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	C= new DataColumn("idinventoryamortization", typeof(int));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	tassetamortization.Columns.Add( new DataColumn("idpiece", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	tassetamortization.Columns.Add( new DataColumn("assetvalue", typeof(decimal)));
	tassetamortization.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	tassetamortization.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetamortization.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	tassetamortization.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	tassetamortization.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetamortization.Columns.Add( new DataColumn("idassetload", typeof(int)));
	Tables.Add(tassetamortization);
	tassetamortization.PrimaryKey =  new DataColumn[]{tassetamortization.Columns["namortization"]};


	//////////////////// ASSETUNLOADKIND /////////////////////////////////
	var tassetunloadkind= new DataTable("assetunloadkind");
	C= new DataColumn("idassetunloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	tassetunloadkind.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	tassetunloadkind.Columns.Add( new DataColumn("startnumber", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("active", typeof(string)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tassetunloadkind);
	tassetunloadkind.PrimaryKey =  new DataColumn[]{tassetunloadkind.Columns["idassetunloadkind"]};


	//////////////////// INVENTORYTREEVIEW /////////////////////////////////
	var tinventorytreeview= new DataTable("inventorytreeview");
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	tinventorytreeview.Columns.Add( new DataColumn("paridinv", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	Tables.Add(tinventorytreeview);
	tinventorytreeview.PrimaryKey =  new DataColumn[]{tinventorytreeview.Columns["idinv"]};


	//////////////////// ASSETUNLOAD /////////////////////////////////
	var tassetunload= new DataTable("assetunload");
	C= new DataColumn("nassetunload", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("yassetunload", typeof(short));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	tassetunload.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	tassetunload.Columns.Add( new DataColumn("description", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("doc", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("enactment", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	tassetunload.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetunload.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("idmot", typeof(int)));
	C= new DataColumn("idassetunloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("idassetunload", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	Tables.Add(tassetunload);
	tassetunload.PrimaryKey =  new DataColumn[]{tassetunload.Columns["idassetunload"]};


	//////////////////// ASSETLOAD /////////////////////////////////
	var tassetload= new DataTable("assetload");
	C= new DataColumn("nassetload", typeof(int));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("yassetload", typeof(short));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	tassetload.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	tassetload.Columns.Add( new DataColumn("description", typeof(string)));
	tassetload.Columns.Add( new DataColumn("doc", typeof(string)));
	tassetload.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("enactment", typeof(string)));
	tassetload.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	tassetload.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tassetload.Columns.Add( new DataColumn("idmot", typeof(int)));
	C= new DataColumn("idassetloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("idassetload", typeof(int));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	Tables.Add(tassetload);
	tassetload.PrimaryKey =  new DataColumn[]{tassetload.Columns["idassetload"]};


	//////////////////// ASSETLOADKIND /////////////////////////////////
	var tassetloadkind= new DataTable("assetloadkind");
	C= new DataColumn("idassetloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	tassetloadkind.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	tassetloadkind.Columns.Add( new DataColumn("flag", typeof(byte)));
	tassetloadkind.Columns.Add( new DataColumn("active", typeof(string)));
	tassetloadkind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tassetloadkind);
	tassetloadkind.PrimaryKey =  new DataColumn[]{tassetloadkind.Columns["idassetloadkind"]};


	//////////////////// ASSETPIECEVIEW /////////////////////////////////
	var tassetpieceview= new DataTable("assetpieceview");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("yearstart", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idlocation", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("locationcode", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("location", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("idman", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("manager", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("currmanager", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("inventorytree_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("descriptionmain", typeof(string));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetpieceview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("taxable", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tassetpieceview.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("cost", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("revals", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("revals_pending", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("subtractions", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("currentvalue", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("abatable", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetpieceview.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("is_unloaded", typeof(string));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("is_loaded", typeof(string));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	Tables.Add(tassetpieceview);
	tassetpieceview.PrimaryKey =  new DataColumn[]{tassetpieceview.Columns["idasset"], tassetpieceview.Columns["idpiece"]};


	//////////////////// ASSETAMORTIZATIONVIEW /////////////////////////////////
	var tassetamortizationview= new DataTable("assetamortizationview");
	C= new DataColumn("namortization", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	tassetamortizationview.Columns.Add( new DataColumn("idpiece", typeof(int)));
	C= new DataColumn("idinventoryamortization", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("codeinventoryamortization", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("inventoryamortization", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("official", typeof(string));
	C.ReadOnly=true;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	tassetamortizationview.Columns.Add( new DataColumn("ninventory", typeof(int)));
	C= new DataColumn("loaddescription", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	tassetamortizationview.Columns.Add( new DataColumn("assetvalue", typeof(decimal)));
	tassetamortizationview.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	C= new DataColumn("amount", typeof(decimal));
	C.ReadOnly=true;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	tassetamortizationview.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetamortizationview.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetamortizationview.Columns.Add( new DataColumn("assetunloadkind", typeof(string)));
	tassetamortizationview.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetamortizationview.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetamortizationview.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetamortizationview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetamortizationview.Columns.Add( new DataColumn("assetloadkind", typeof(string)));
	tassetamortizationview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetamortizationview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(string));
	C.ReadOnly=true;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("flagload", typeof(string));
	C.ReadOnly=true;
	tassetamortizationview.Columns.Add(C);
	tassetamortizationview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	tassetamortizationview.Columns.Add( new DataColumn("codeinv", typeof(string)));
	tassetamortizationview.Columns.Add( new DataColumn("inventorytree", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	tassetamortizationview.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetamortizationview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("am_year", typeof(int));
	C.ReadOnly=true;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("ass_year", typeof(int));
	C.ReadOnly=true;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("inventorytree_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	Tables.Add(tassetamortizationview);
	tassetamortizationview.PrimaryKey =  new DataColumn[]{tassetamortizationview.Columns["namortization"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{inventory.Columns["idinventory"]};
	var cChild = new []{assetpieceview.Columns["idinventory"]};
	Relations.Add(new DataRelation("inventory_assetpieceview",cPar,cChild,false));

	cPar = new []{inventorytreeview.Columns["idinv"]};
	cChild = new []{assetpieceview.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytreeview_assetpieceview",cPar,cChild,false));

	cPar = new []{assetamortizationview.Columns["namortization"]};
	cChild = new []{assetamortization.Columns["namortization"]};
	Relations.Add(new DataRelation("assetamortization_assetamortizationview",cPar,cChild,false));

	cPar = new []{assetpieceview.Columns["idasset"], assetpieceview.Columns["idpiece"]};
	cChild = new []{assetamortization.Columns["idasset"], assetamortization.Columns["idpiece"]};
	Relations.Add(new DataRelation("assetpieceview_assetamortization",cPar,cChild,false));

	cPar = new []{assetload.Columns["idassetload"]};
	cChild = new []{assetamortization.Columns["idassetload"]};
	Relations.Add(new DataRelation("assetload_assetamortization",cPar,cChild,false));

	cPar = new []{inventoryamortization.Columns["idinventoryamortization"]};
	cChild = new []{assetamortization.Columns["idinventoryamortization"]};
	Relations.Add(new DataRelation("inventoryamortizationassetamortization",cPar,cChild,false));

	cPar = new []{assetunload.Columns["idassetunload"]};
	cChild = new []{assetamortization.Columns["idassetunload"]};
	Relations.Add(new DataRelation("assetunload_assetamortization",cPar,cChild,false));

	#endregion

}
}
}
