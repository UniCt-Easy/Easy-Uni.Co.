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
namespace asset_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Cespiti e accessori
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable asset 		=> Tables["asset"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetacquireview 		=> Tables["assetacquireview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytreeview 		=> Tables["inventorytreeview"];

	///<summary>
	///Tipi di buoni di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadkind 		=> Tables["assetloadkind"];

	///<summary>
	///Tipi di buoni di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunloadkind 		=> Tables["assetunloadkind"];

	///<summary>
	///Inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory 		=> Tables["inventory"];

	///<summary>
	///Buono di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunload 		=> Tables["assetunload"];

	///<summary>
	///Piano delle Ubicazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable location 		=> Tables["location"];

	///<summary>
	///Ubicazione cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetlocation 		=> Tables["assetlocation"];

	///<summary>
	///Responsabile cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetmanager 		=> Tables["assetmanager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory1 		=> Tables["inventory1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory2 		=> Tables["inventory2"];

	///<summary>
	///Causali di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadmotive 		=> Tables["assetloadmotive"];

	///<summary>
	///Causali di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunloadmotive 		=> Tables["assetunloadmotive"];

	///<summary>
	///Campi aggiuntivi per cespiti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable multifieldkind 		=> Tables["multifieldkind"];

	///<summary>
	///Configurazione multicampo per classificazione inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytreemultifieldkind 		=> Tables["inventorytreemultifieldkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetamortizationview 		=> Tables["assetamortizationview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetview4 		=> Tables["assetview4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetview 		=> Tables["assetview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable asset1 		=> Tables["asset1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager1 		=> Tables["manager1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable locationview 		=> Tables["locationview"];

	///<summary>
	///Consegnatario cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetsubmanager 		=> Tables["assetsubmanager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable submanager 		=> Tables["submanager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable currsubmanager 		=> Tables["currsubmanager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listview 		=> Tables["listview"];

	///<summary>
	///Tipo Ammortamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventoryamortization 		=> Tables["inventoryamortization"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive 		=> Tables["accmotive"];

	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	///<summary>
	///Risconto contributo conto impianti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetgrantdetail 		=> Tables["assetgrantdetail"];

	///<summary>
	///Attribuzione di un contributo conto impianti ad un cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetgrant 		=> Tables["assetgrant"];

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
	//////////////////// ASSET /////////////////////////////////
	var tasset= new DataTable("asset");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tasset.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tasset.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	tasset.Columns.Add( new DataColumn("txt", typeof(string)));
	tasset.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tasset.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	tasset.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tasset.Columns.Add( new DataColumn("multifield", typeof(string)));
	tasset.Columns.Add( new DataColumn("idinventoryamortization", typeof(int)));
	tasset.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	tasset.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tasset.Columns.Add( new DataColumn("idinventory", typeof(int)));
	tasset.Columns.Add( new DataColumn("rfid", typeof(string)));
	Tables.Add(tasset);
	tasset.PrimaryKey =  new DataColumn[]{tasset.Columns["idasset"], tasset.Columns["idpiece"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// ASSETACQUIREVIEW /////////////////////////////////
	var tassetacquireview= new DataTable("assetacquireview");
	C= new DataColumn("nassetacquire", typeof(int));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("yman", typeof(short)));
	tassetacquireview.Columns.Add( new DataColumn("nman", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("rownum", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("registry", typeof(string)));
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("assetloadmotive", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("codeinv", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("inventorytree", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("inventory", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("assetloadkind", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetacquireview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetacquireview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tassetacquireview.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("flagload", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("loadkind", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("cost", typeof(decimal)));
	tassetacquireview.Columns.Add( new DataColumn("abatable", typeof(decimal)));
	tassetacquireview.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tassetacquireview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("ispieceacquire", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idlist", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("intcode", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("list", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	Tables.Add(tassetacquireview);
	tassetacquireview.PrimaryKey =  new DataColumn[]{tassetacquireview.Columns["nassetacquire"]};


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
	tassetloadkind.Columns.Add( new DataColumn("active", typeof(string)));
	tassetloadkind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tassetloadkind);
	tassetloadkind.PrimaryKey =  new DataColumn[]{tassetloadkind.Columns["idassetloadkind"]};


	//////////////////// ASSETUNLOADKIND /////////////////////////////////
	var tassetunloadkind= new DataTable("assetunloadkind");
	C= new DataColumn("idassetunloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	tassetunloadkind.Columns.Add( new DataColumn("idinventory", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	tassetunloadkind.Columns.Add( new DataColumn("active", typeof(string)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tassetunloadkind);
	tassetunloadkind.PrimaryKey =  new DataColumn[]{tassetunloadkind.Columns["idassetunloadkind"]};


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


	//////////////////// ASSETUNLOAD /////////////////////////////////
	var tassetunload= new DataTable("assetunload");
	C= new DataColumn("idassetunloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("yassetunload", typeof(short));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("nassetunload", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	tassetunload.Columns.Add( new DataColumn("idreg", typeof(int)));
	tassetunload.Columns.Add( new DataColumn("idmot", typeof(int)));
	tassetunload.Columns.Add( new DataColumn("doc", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("description", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("enactment", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	tassetunload.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("idassetunload", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	Tables.Add(tassetunload);
	tassetunload.PrimaryKey =  new DataColumn[]{tassetunload.Columns["idassetunload"]};


	//////////////////// LOCATION /////////////////////////////////
	var tlocation= new DataTable("location");
	tlocation.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("locationcode", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	tlocation.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	tlocation.Columns.Add( new DataColumn("paridlocation", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tlocation);
	tlocation.PrimaryKey =  new DataColumn[]{tlocation.Columns["idlocation"]};


	//////////////////// ASSETLOCATION /////////////////////////////////
	var tassetlocation= new DataTable("assetlocation");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("idassetlocation", typeof(int));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	tassetlocation.Columns.Add( new DataColumn("start", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	tassetlocation.Columns.Add( new DataColumn("!locationcode", typeof(string)));
	tassetlocation.Columns.Add( new DataColumn("!description", typeof(string)));
	Tables.Add(tassetlocation);
	tassetlocation.PrimaryKey =  new DataColumn[]{tassetlocation.Columns["idasset"], tassetlocation.Columns["idassetlocation"]};


	//////////////////// ASSETMANAGER /////////////////////////////////
	var tassetmanager= new DataTable("assetmanager");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("idassetmanager", typeof(int));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	tassetmanager.Columns.Add( new DataColumn("start", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	tassetmanager.Columns.Add( new DataColumn("!manager", typeof(string)));
	Tables.Add(tassetmanager);
	tassetmanager.PrimaryKey =  new DataColumn[]{tassetmanager.Columns["idasset"], tassetmanager.Columns["idassetmanager"]};


	//////////////////// INVENTORY1 /////////////////////////////////
	var tinventory1= new DataTable("inventory1");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventory1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventory1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventory1.Columns.Add(C);
	tinventory1.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventory1.Columns.Add(C);
	C= new DataColumn("idinventorykind", typeof(int));
	C.AllowDBNull=false;
	tinventory1.Columns.Add(C);
	C= new DataColumn("codeinventory", typeof(string));
	C.AllowDBNull=false;
	tinventory1.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tinventory1.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinventory1.Columns.Add(C);
	tinventory1.Columns.Add( new DataColumn("active", typeof(string)));
	tinventory1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinventory1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinventory1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinventory1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinventory1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinventory1);
	tinventory1.PrimaryKey =  new DataColumn[]{tinventory1.Columns["idinventory"]};


	//////////////////// INVENTORY2 /////////////////////////////////
	var tinventory2= new DataTable("inventory2");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory2.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventory2.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventory2.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventory2.Columns.Add(C);
	tinventory2.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventory2.Columns.Add(C);
	C= new DataColumn("idinventorykind", typeof(int));
	C.AllowDBNull=false;
	tinventory2.Columns.Add(C);
	C= new DataColumn("codeinventory", typeof(string));
	C.AllowDBNull=false;
	tinventory2.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tinventory2.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinventory2.Columns.Add(C);
	tinventory2.Columns.Add( new DataColumn("active", typeof(string)));
	tinventory2.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinventory2.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinventory2.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinventory2.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinventory2.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinventory2);
	tinventory2.PrimaryKey =  new DataColumn[]{tinventory2.Columns["idinventory"]};


	//////////////////// ASSETLOADMOTIVE /////////////////////////////////
	var tassetloadmotive= new DataTable("assetloadmotive");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	tassetloadmotive.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	C= new DataColumn("codemot", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	tassetloadmotive.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tassetloadmotive);
	tassetloadmotive.PrimaryKey =  new DataColumn[]{tassetloadmotive.Columns["idmot"]};


	//////////////////// ASSETUNLOADMOTIVE /////////////////////////////////
	var tassetunloadmotive= new DataTable("assetunloadmotive");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("codemot", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	tassetunloadmotive.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tassetunloadmotive);
	tassetunloadmotive.PrimaryKey =  new DataColumn[]{tassetunloadmotive.Columns["idmot"]};


	//////////////////// MULTIFIELDKIND /////////////////////////////////
	var tmultifieldkind= new DataTable("multifieldkind");
	C= new DataColumn("idmultifieldkind", typeof(int));
	C.AllowDBNull=false;
	tmultifieldkind.Columns.Add(C);
	C= new DataColumn("fieldname", typeof(string));
	C.AllowDBNull=false;
	tmultifieldkind.Columns.Add(C);
	C= new DataColumn("systype", typeof(string));
	C.AllowDBNull=false;
	tmultifieldkind.Columns.Add(C);
	C= new DataColumn("allownull", typeof(string));
	C.AllowDBNull=false;
	tmultifieldkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmultifieldkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmultifieldkind.Columns.Add(C);
	tmultifieldkind.Columns.Add( new DataColumn("tag", typeof(string)));
	tmultifieldkind.Columns.Add( new DataColumn("len", typeof(int)));
	tmultifieldkind.Columns.Add( new DataColumn("fieldcode", typeof(string)));
	tmultifieldkind.Columns.Add( new DataColumn("tabname", typeof(string)));
	tmultifieldkind.Columns.Add( new DataColumn("ordernumber", typeof(short)));
	Tables.Add(tmultifieldkind);
	tmultifieldkind.PrimaryKey =  new DataColumn[]{tmultifieldkind.Columns["idmultifieldkind"]};


	//////////////////// INVENTORYTREEMULTIFIELDKIND /////////////////////////////////
	var tinventorytreemultifieldkind= new DataTable("inventorytreemultifieldkind");
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tinventorytreemultifieldkind.Columns.Add(C);
	C= new DataColumn("idmultifieldkind", typeof(int));
	C.AllowDBNull=false;
	tinventorytreemultifieldkind.Columns.Add(C);
	tinventorytreemultifieldkind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tinventorytreemultifieldkind.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tinventorytreemultifieldkind);
	tinventorytreemultifieldkind.PrimaryKey =  new DataColumn[]{tinventorytreemultifieldkind.Columns["idinv"], tinventorytreemultifieldkind.Columns["idmultifieldkind"]};


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
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetamortizationview.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(string));
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
	Tables.Add(tassetamortizationview);
	tassetamortizationview.PrimaryKey =  new DataColumn[]{tassetamortizationview.Columns["namortization"]};


	//////////////////// ASSETVIEW4 /////////////////////////////////
	var tassetview4= new DataTable("assetview4");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("idinventory_prev", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("codeinventory_prev", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("inventory_prev", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("ninventory_prev", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("idasset_next", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("idpiece_next", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("idinventory_next", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("codeinventory_next", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("inventory_next", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("ninventory_next", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("yearstart", typeof(int));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("currmanager", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("currsubmanager", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("inventorytree_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("codeinventory", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetview4.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("idloadmot", typeof(int));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("loadmotive", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("loaddescription", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	tassetview4.Columns.Add( new DataColumn("loaddate", typeof(DateTime)));
	tassetview4.Columns.Add( new DataColumn("loaddoc", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("loaddocdate", typeof(DateTime)));
	tassetview4.Columns.Add( new DataColumn("loadenactment", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("loadenactmentdate", typeof(DateTime)));
	tassetview4.Columns.Add( new DataColumn("loadprintdate", typeof(DateTime)));
	tassetview4.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetview4.Columns.Add( new DataColumn("taxrate", typeof(double)));
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("abatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("cost", typeof(decimal));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("revals", typeof(decimal));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("revals_pending", typeof(decimal));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("subtractions", typeof(decimal));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("currentvalue", typeof(decimal));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetview4.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("unloaddate", typeof(DateTime)));
	tassetview4.Columns.Add( new DataColumn("idunloadmot", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("unloadmotive", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("unloaddescription", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("unloaddoc", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("unloaddocdate", typeof(DateTime)));
	tassetview4.Columns.Add( new DataColumn("unloadenactment", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("unloadenactmentdate", typeof(DateTime)));
	tassetview4.Columns.Add( new DataColumn("unloadratificationdate", typeof(DateTime)));
	tassetview4.Columns.Add( new DataColumn("unloadregistry", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(string));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("flagtransf", typeof(string));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flagload", typeof(string));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("loadkind", typeof(string));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("multifield", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("is_unloaded", typeof(string));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	C= new DataColumn("is_loaded", typeof(string));
	C.ReadOnly=true;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("idupb", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("inventoryagency", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	tassetview4.Columns.Add( new DataColumn("idlist", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("intcode", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("list", typeof(string)));
	tassetview4.Columns.Add( new DataColumn("idinventoryamortization", typeof(int)));
	tassetview4.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	tassetview4.Columns.Add( new DataColumn("historical", typeof(decimal)));
	C= new DataColumn("ispiece", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	C= new DataColumn("inventorykindvisible", typeof(string));
	C.AllowDBNull=false;
	tassetview4.Columns.Add(C);
	Tables.Add(tassetview4);

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
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventorykindvisible", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("rfid", typeof(string)));
	Tables.Add(tassetview);
	tassetview.PrimaryKey =  new DataColumn[]{tassetview.Columns["idasset"], tassetview.Columns["idpiece"]};


	//////////////////// ASSET1 /////////////////////////////////
	var tasset1= new DataTable("asset1");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tasset1.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tasset1.Columns.Add(C);
	tasset1.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tasset1.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tasset1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tasset1.Columns.Add(C);
	tasset1.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tasset1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tasset1.Columns.Add(C);
	tasset1.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tasset1.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tasset1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tasset1.Columns.Add( new DataColumn("txt", typeof(string)));
	tasset1.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tasset1.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tasset1.Columns.Add(C);
	tasset1.Columns.Add( new DataColumn("multifield", typeof(string)));
	tasset1.Columns.Add( new DataColumn("rfid", typeof(string)));
	Tables.Add(tasset1);
	tasset1.PrimaryKey =  new DataColumn[]{tasset1.Columns["idasset"], tasset1.Columns["idpiece"]};


	//////////////////// MANAGER1 /////////////////////////////////
	var tmanager1= new DataTable("manager1");
	tmanager1.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	tmanager1.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	tmanager1.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager1.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	tmanager1.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager1.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	tmanager1.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanager1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanager1.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanager1.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanager1);
	tmanager1.PrimaryKey =  new DataColumn[]{tmanager1.Columns["idman"]};


	//////////////////// LOCATIONVIEW /////////////////////////////////
	var tlocationview= new DataTable("locationview");
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("locationcode", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	tlocationview.Columns.Add( new DataColumn("newlocationcode", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	tlocationview.Columns.Add( new DataColumn("paridlocation", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	tlocationview.Columns.Add( new DataColumn("idman", typeof(int)));
	tlocationview.Columns.Add( new DataColumn("manager", typeof(string)));
	tlocationview.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	tlocationview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tlocationview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tlocationview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tlocationview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tlocationview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tlocationview);
	tlocationview.PrimaryKey =  new DataColumn[]{tlocationview.Columns["idlocation"]};


	//////////////////// ASSETSUBMANAGER /////////////////////////////////
	var tassetsubmanager= new DataTable("assetsubmanager");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetsubmanager.Columns.Add(C);
	C= new DataColumn("idassetsubmanager", typeof(int));
	C.AllowDBNull=false;
	tassetsubmanager.Columns.Add(C);
	tassetsubmanager.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tassetsubmanager.Columns.Add( new DataColumn("cu", typeof(string)));
	tassetsubmanager.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tassetsubmanager.Columns.Add( new DataColumn("lu", typeof(string)));
	tassetsubmanager.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tassetsubmanager.Columns.Add( new DataColumn("idmanager", typeof(int)));
	tassetsubmanager.Columns.Add( new DataColumn("!submanager", typeof(string)));
	Tables.Add(tassetsubmanager);
	tassetsubmanager.PrimaryKey =  new DataColumn[]{tassetsubmanager.Columns["idasset"], tassetsubmanager.Columns["idassetsubmanager"]};


	//////////////////// SUBMANAGER /////////////////////////////////
	var tsubmanager= new DataTable("submanager");
	tsubmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsubmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsubmanager.Columns.Add(C);
	tsubmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsubmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsubmanager.Columns.Add(C);
	tsubmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tsubmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tsubmanager.Columns.Add(C);
	tsubmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tsubmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tsubmanager.Columns.Add(C);
	tsubmanager.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tsubmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsubmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsubmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsubmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsubmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tsubmanager.Columns.Add( new DataColumn("newidman", typeof(int)));
	tsubmanager.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tsubmanager);
	tsubmanager.PrimaryKey =  new DataColumn[]{tsubmanager.Columns["idman"]};


	//////////////////// CURRSUBMANAGER /////////////////////////////////
	var tcurrsubmanager= new DataTable("currsubmanager");
	tcurrsubmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcurrsubmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcurrsubmanager.Columns.Add(C);
	tcurrsubmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcurrsubmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcurrsubmanager.Columns.Add(C);
	tcurrsubmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tcurrsubmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tcurrsubmanager.Columns.Add(C);
	tcurrsubmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tcurrsubmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tcurrsubmanager.Columns.Add(C);
	tcurrsubmanager.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tcurrsubmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tcurrsubmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tcurrsubmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tcurrsubmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tcurrsubmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tcurrsubmanager.Columns.Add( new DataColumn("newidman", typeof(int)));
	tcurrsubmanager.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tcurrsubmanager);
	tcurrsubmanager.PrimaryKey =  new DataColumn[]{tcurrsubmanager.Columns["idman"]};


	//////////////////// LISTVIEW /////////////////////////////////
	var tlistview= new DataTable("listview");
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	C= new DataColumn("intcode", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	tlistview.Columns.Add( new DataColumn("intbarcode", typeof(string)));
	tlistview.Columns.Add( new DataColumn("extcode", typeof(string)));
	tlistview.Columns.Add( new DataColumn("extbarcode", typeof(string)));
	tlistview.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	tlistview.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tlistview.Columns.Add( new DataColumn("package", typeof(string)));
	tlistview.Columns.Add( new DataColumn("idunit", typeof(int)));
	tlistview.Columns.Add( new DataColumn("unit", typeof(string)));
	tlistview.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	C= new DataColumn("has_expiry", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	C= new DataColumn("codelistclass", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	C= new DataColumn("listclass", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	tlistview.Columns.Add( new DataColumn("pic", typeof(Byte[])));
	tlistview.Columns.Add( new DataColumn("timesupply", typeof(int)));
	tlistview.Columns.Add( new DataColumn("nmaxorder", typeof(decimal)));
	tlistview.Columns.Add( new DataColumn("authrequired", typeof(string)));
	tlistview.Columns.Add( new DataColumn("assetkind", typeof(string)));
	tlistview.Columns.Add( new DataColumn("flagvisiblekind", typeof(byte)));
	Tables.Add(tlistview);
	tlistview.PrimaryKey =  new DataColumn[]{tlistview.Columns["idlist"]};


	//////////////////// INVENTORYAMORTIZATION /////////////////////////////////
	var tinventoryamortization= new DataTable("inventoryamortization");
	tinventoryamortization.Columns.Add( new DataColumn("age", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("codeinventoryamortization", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("idinventoryamortization", typeof(int));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	tinventoryamortization.Columns.Add( new DataColumn("active", typeof(string)));
	tinventoryamortization.Columns.Add( new DataColumn("valuemin", typeof(decimal)));
	tinventoryamortization.Columns.Add( new DataColumn("valuemax", typeof(decimal)));
	tinventoryamortization.Columns.Add( new DataColumn("agemax", typeof(int)));
	Tables.Add(tinventoryamortization);
	tinventoryamortization.PrimaryKey =  new DataColumn[]{tinventoryamortization.Columns["idinventoryamortization"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


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


	//////////////////// ASSETGRANTDETAIL /////////////////////////////////
	var tassetgrantdetail= new DataTable("assetgrantdetail");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetgrantdetail.Columns.Add(C);
	C= new DataColumn("idgrant", typeof(int));
	C.AllowDBNull=false;
	tassetgrantdetail.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tassetgrantdetail.Columns.Add(C);
	tassetgrantdetail.Columns.Add( new DataColumn("ydetail", typeof(short)));
	tassetgrantdetail.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tassetgrantdetail.Columns.Add( new DataColumn("idgrantload", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetgrantdetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetgrantdetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetgrantdetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetgrantdetail.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetgrantdetail.Columns.Add(C);
	tassetgrantdetail.Columns.Add( new DataColumn("!Assetgrant", typeof(string)));
	Tables.Add(tassetgrantdetail);
	tassetgrantdetail.PrimaryKey =  new DataColumn[]{tassetgrantdetail.Columns["idasset"], tassetgrantdetail.Columns["idgrant"], tassetgrantdetail.Columns["iddetail"], tassetgrantdetail.Columns["idpiece"]};


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
	tassetgrant.Columns.Add( new DataColumn("!codeMotive", typeof(string)));
	tassetgrant.Columns.Add( new DataColumn("!titleMotive", typeof(string)));
	tassetgrant.Columns.Add( new DataColumn("!codeunderwriting", typeof(string)));
	tassetgrant.Columns.Add( new DataColumn("!titleunderwriting", typeof(string)));
	Tables.Add(tassetgrant);
	tassetgrant.PrimaryKey =  new DataColumn[]{tassetgrant.Columns["idasset"], tassetgrant.Columns["idgrant"], tassetgrant.Columns["idpiece"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{asset.Columns["idasset"], asset.Columns["idpiece"]};
	var cChild = new []{assetgrantdetail.Columns["idasset"], assetgrantdetail.Columns["idpiece"]};
	Relations.Add(new DataRelation("asset_assetgrantdetail",cPar,cChild,false));

	cPar = new []{submanager.Columns["idman"]};
	cChild = new []{assetsubmanager.Columns["idmanager"]};
	Relations.Add(new DataRelation("FK_submanager_assetsubmanager",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetsubmanager.Columns["idasset"]};
	Relations.Add(new DataRelation("FK_asset_assetsubmanager",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{asset1.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_asset1",cPar,cChild,false));

	cPar = new []{currsubmanager.Columns["idman"]};
	cChild = new []{assetview.Columns["idcurrsubman"]};
	Relations.Add(new DataRelation("FK_currsubmanager_assetview",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"], asset.Columns["idpiece"]};
	cChild = new []{assetview.Columns["idasset"], assetview.Columns["idpiece"]};
	Relations.Add(new DataRelation("asset_assetview",cPar,cChild,false));

	cPar = new []{manager1.Columns["idman"]};
	cChild = new []{assetview.Columns["idcurrman"]};
	Relations.Add(new DataRelation("manager1_assetview",cPar,cChild,false));

	cPar = new []{locationview.Columns["idlocation"]};
	cChild = new []{assetview.Columns["idcurrlocation"]};
	Relations.Add(new DataRelation("locationview_assetview",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{assetview.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_assetview",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetview4.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetview4",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"], asset.Columns["idpiece"]};
	cChild = new []{assetamortizationview.Columns["idasset"], assetamortizationview.Columns["idpiece"]};
	Relations.Add(new DataRelation("asset_assetamortizationview",cPar,cChild,false));

	cPar = new []{inventorytreeview.Columns["idinv"]};
	cChild = new []{inventorytreemultifieldkind.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytreeview_inventorytreemultifieldkind",cPar,cChild,false));

	cPar = new []{multifieldkind.Columns["idmultifieldkind"]};
	cChild = new []{inventorytreemultifieldkind.Columns["idmultifieldkind"]};
	Relations.Add(new DataRelation("multifieldkind_inventorytreemultifieldkind",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetmanager.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetmanager",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{assetmanager.Columns["idman"]};
	Relations.Add(new DataRelation("manager_assetmanager",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetlocation.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetlocation",cPar,cChild,false));

	cPar = new []{location.Columns["idlocation"]};
	cChild = new []{assetlocation.Columns["idlocation"]};
	Relations.Add(new DataRelation("location_assetlocation",cPar,cChild,false));

	cPar = new []{assetunloadkind.Columns["idassetunloadkind"]};
	cChild = new []{assetunload.Columns["idassetunloadkind"]};
	Relations.Add(new DataRelation("assetunloadkindassetunload",cPar,cChild,false));

	cPar = new []{assetunloadmotive.Columns["idmot"]};
	cChild = new []{assetunload.Columns["idmot"]};
	Relations.Add(new DataRelation("assetunloadmotive_assetunload",cPar,cChild,false));

	cPar = new []{inventorytreeview.Columns["idinv"]};
	cChild = new []{assetacquireview.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytreeviewassetacquireview",cPar,cChild,false));

	cPar = new []{assetloadkind.Columns["idassetloadkind"]};
	cChild = new []{assetacquireview.Columns["idassetloadkind"]};
	Relations.Add(new DataRelation("assetloadkindassetacquireview",cPar,cChild,false));

	cPar = new []{inventory.Columns["idinventory"]};
	cChild = new []{assetacquireview.Columns["idinventory"]};
	Relations.Add(new DataRelation("inventoryassetacquireview",cPar,cChild,false));

	cPar = new []{assetloadmotive.Columns["idmot"]};
	cChild = new []{assetacquireview.Columns["idmot"]};
	Relations.Add(new DataRelation("assetloadmotive_assetacquireview",cPar,cChild,false));

	cPar = new []{listview.Columns["idlist"]};
	cChild = new []{assetacquireview.Columns["idlist"]};
	Relations.Add(new DataRelation("listview_assetacquireview",cPar,cChild,false));

	cPar = new []{inventoryamortization.Columns["idinventoryamortization"]};
	cChild = new []{asset.Columns["idinventoryamortization"]};
	Relations.Add(new DataRelation("FK_inventoryamortization_asset",cPar,cChild,false));

	cPar = new []{assetunload.Columns["idassetunload"]};
	cChild = new []{asset.Columns["idassetunload"]};
	Relations.Add(new DataRelation("assetunloadasset",cPar,cChild,false));

	cPar = new []{assetacquireview.Columns["nassetacquire"]};
	cChild = new []{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("assetacquireviewasset",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"], asset.Columns["idpiece"]};
	cChild = new []{assetgrant.Columns["idasset"], assetgrant.Columns["idpiece"]};
	Relations.Add(new DataRelation("asset_assetgrant",cPar,cChild,false));

	cPar = new []{underwriting.Columns["idunderwriting"]};
	cChild = new []{assetgrant.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("underwriting_assetgrant",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{assetgrant.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotive_assetgrant",cPar,cChild,false));

	cPar = new []{assetgrant.Columns["idasset"], assetgrant.Columns["idpiece"], assetgrant.Columns["idgrant"]};
	cChild = new []{assetgrantdetail.Columns["idasset"], assetgrantdetail.Columns["idpiece"], assetgrantdetail.Columns["idgrant"]};
	Relations.Add(new DataRelation("assetgrantdetail_assetgrant",cPar,cChild,false));

	#endregion

}
}
}
