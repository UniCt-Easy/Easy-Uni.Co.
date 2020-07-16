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
namespace assetgrant_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive 		=> Tables["accmotive"];

	///<summary>
	///Attribuzione di un contributo conto impianti ad un cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetgrant 		=> Tables["assetgrant"];

	///<summary>
	///Inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory 		=> Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetview 		=> Tables["assetview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytreeview 		=> Tables["inventorytreeview"];

	///<summary>
	///Ente inventariale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventoryagency 		=> Tables["inventoryagency"];

	///<summary>
	///Accertamento di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epacc 		=> Tables["epacc"];

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
	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new DataTable("underwriting");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("active", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("codeunderwriting", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("doc", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tunderwriting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	Tables.Add(tunderwriting);
	tunderwriting.PrimaryKey =  new DataColumn[]{tunderwriting.Columns["idunderwriting"]};


	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new DataTable("accmotive");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("flagdep", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("expensekind", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccmotive);
	taccmotive.PrimaryKey =  new DataColumn[]{taccmotive.Columns["idaccmotive"]};


	//////////////////// ASSETGRANT /////////////////////////////////
	var tassetgrant= new DataTable("assetgrant");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetgrant.Columns.Add(C);
	C= new DataColumn("idgrant", typeof(int));
	C.AllowDBNull=false;
	tassetgrant.Columns.Add(C);
	tassetgrant.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tassetgrant.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tassetgrant.Columns.Add(C);
	tassetgrant.Columns.Add( new DataColumn("ygrant", typeof(short)));
	tassetgrant.Columns.Add( new DataColumn("description", typeof(string)));
	tassetgrant.Columns.Add( new DataColumn("doc", typeof(string)));
	tassetgrant.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tassetgrant.Columns.Add( new DataColumn("idgrantload", typeof(int)));
	tassetgrant.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tassetgrant.Columns.Add( new DataColumn("lu", typeof(string)));
	tassetgrant.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tassetgrant.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetgrant.Columns.Add(C);
	tassetgrant.Columns.Add( new DataColumn("idepacc", typeof(int)));
	Tables.Add(tassetgrant);
	tassetgrant.PrimaryKey =  new DataColumn[]{tassetgrant.Columns["idasset"], tassetgrant.Columns["idgrant"], tassetgrant.Columns["idpiece"]};


	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new DataTable("inventory");
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	tinventory.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codeinventory", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("idinventorykind", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	tinventory.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	tinventory.Columns.Add( new DataColumn("startnumber", typeof(int)));
	Tables.Add(tinventory);
	tinventory.PrimaryKey =  new DataColumn[]{tinventory.Columns["idinventory"]};


	//////////////////// ASSETVIEW /////////////////////////////////
	var tassetview= new DataTable("assetview");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idinventory_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("codeinventory_prev", typeof(string)));
	tassetview.Columns.Add( new DataColumn("inventory_prev", typeof(string)));
	tassetview.Columns.Add( new DataColumn("ninventory_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idasset_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idpiece_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idinventory_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("codeinventory_next", typeof(string)));
	tassetview.Columns.Add( new DataColumn("inventory_next", typeof(string)));
	tassetview.Columns.Add( new DataColumn("ninventory_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("yearstart", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tassetview.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetview.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetview.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetview.Columns.Add( new DataColumn("currmanager", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tassetview.Columns.Add( new DataColumn("currsubmanager", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventorytree_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("codeinventory", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("idloadmot", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("loadmotive", typeof(string)));
	tassetview.Columns.Add( new DataColumn("loaddescription", typeof(string)));
	tassetview.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("loaddate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("loaddoc", typeof(string)));
	tassetview.Columns.Add( new DataColumn("loaddocdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("loadenactment", typeof(string)));
	tassetview.Columns.Add( new DataColumn("loadenactmentdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("loadprintdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("abatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("cost", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("revals", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("revals_pending", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("subtractions", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("currentvalue", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetview.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetview.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetview.Columns.Add( new DataColumn("unloaddate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("idunloadmot", typeof(int)));
	tassetview.Columns.Add( new DataColumn("unloadmotive", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloaddescription", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloaddoc", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloaddocdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("unloadenactment", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloadenactmentdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("unloadratificationdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("unloadregistry", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("flagtransf", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flagload", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("loadkind", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("multifield", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("is_unloaded", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("is_loaded", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tassetview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tassetview.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventoryagency", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idlist", typeof(int)));
	tassetview.Columns.Add( new DataColumn("intcode", typeof(string)));
	tassetview.Columns.Add( new DataColumn("list", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idinventoryamortization", typeof(int)));
	tassetview.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	tassetview.Columns.Add( new DataColumn("historical", typeof(decimal)));
	C= new DataColumn("ispiece", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventorykindvisible", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	Tables.Add(tassetview);
	tassetview.PrimaryKey =  new DataColumn[]{tassetview.Columns["idasset"], tassetview.Columns["idpiece"]};


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


	//////////////////// INVENTORYAGENCY /////////////////////////////////
	var tinventoryagency= new DataTable("inventoryagency");
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	tinventoryagency.Columns.Add( new DataColumn("active", typeof(string)));
	tinventoryagency.Columns.Add( new DataColumn("agencycode", typeof(string)));
	C= new DataColumn("codeinventoryagency", typeof(string));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	tinventoryagency.Columns.Add( new DataColumn("name_c", typeof(string)));
	tinventoryagency.Columns.Add( new DataColumn("name_l", typeof(string)));
	tinventoryagency.Columns.Add( new DataColumn("name_r", typeof(string)));
	tinventoryagency.Columns.Add( new DataColumn("title_c", typeof(string)));
	tinventoryagency.Columns.Add( new DataColumn("title_l", typeof(string)));
	tinventoryagency.Columns.Add( new DataColumn("title_r", typeof(string)));
	Tables.Add(tinventoryagency);
	tinventoryagency.PrimaryKey =  new DataColumn[]{tinventoryagency.Columns["idinventoryagency"]};


	//////////////////// EPACC /////////////////////////////////
	var tepacc= new DataTable("epacc");
	C= new DataColumn("idepacc", typeof(int));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("doc", typeof(string)));
	tepacc.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("idman", typeof(int)));
	tepacc.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepacc.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("nepacc", typeof(int));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("paridepacc", typeof(int)));
	tepacc.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tepacc.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yepacc", typeof(short));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("flagvariation", typeof(string)));
	tepacc.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	Tables.Add(tepacc);
	tepacc.PrimaryKey =  new DataColumn[]{tepacc.Columns["idepacc"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{underwriting.Columns["idunderwriting"]};
	var cChild = new []{assetgrant.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("underwriting_assetgrant",cPar,cChild,false));

	cPar = new []{inventorytreeview.Columns["idinv"]};
	cChild = new []{assetview.Columns["idinv"]};
	Relations.Add(new DataRelation("assetview_inventorytreeview",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{assetgrant.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotive_assetgrant",cPar,cChild,false));

	cPar = new []{assetview.Columns["idasset"], assetview.Columns["idpiece"]};
	cChild = new []{assetgrant.Columns["idasset"], assetgrant.Columns["idpiece"]};
	Relations.Add(new DataRelation("assetview_assetgrant",cPar,cChild,false));

	cPar = new []{inventory.Columns["idinventory"]};
	cChild = new []{assetview.Columns["idinventory"]};
	Relations.Add(new DataRelation("inventory_assetview",cPar,cChild,false));

	cPar = new []{inventoryagency.Columns["idinventoryagency"]};
	cChild = new []{assetview.Columns["idinventoryagency"]};
	Relations.Add(new DataRelation("inventoryagency_assetview",cPar,cChild,false));

	cPar = new []{epacc.Columns["idepacc"]};
	cChild = new []{assetgrant.Columns["idepacc"]};
	Relations.Add(new DataRelation("epacc_assetgrant",cPar,cChild,false));

	#endregion

}
}
}
