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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace asset_trasferimento {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Cespiti e accessori
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable asset 		=> Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable locationview 		=> Tables["locationview"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable locationview_alias 		=> Tables["locationview_alias"];

	///<summary>
	///Inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory 		=> Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetview 		=> Tables["assetview"];

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
	public DataTable manager1 		=> Tables["manager1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable managerconsegnatario 		=> Tables["managerconsegnatario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable managerconsegnatario1 		=> Tables["managerconsegnatario1"];

	///<summary>
	///Consegnatario cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetsubmanager 		=> Tables["assetsubmanager"];

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
	tasset.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tasset.Columns.Add( new DataColumn("ninventory", typeof(int)));
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
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	Tables.Add(tasset);
	tasset.PrimaryKey =  new DataColumn[]{tasset.Columns["idasset"], tasset.Columns["idpiece"]};


	//////////////////// LOCATIONVIEW /////////////////////////////////
	var tlocationview= new DataTable("locationview");
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("locationcode", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
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
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
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
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// LOCATIONVIEW_ALIAS /////////////////////////////////
	var tlocationview_alias= new DataTable("locationview_alias");
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tlocationview_alias.Columns.Add(C);
	C= new DataColumn("locationcode", typeof(string));
	C.AllowDBNull=false;
	tlocationview_alias.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tlocationview_alias.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tlocationview_alias.Columns.Add(C);
	tlocationview_alias.Columns.Add( new DataColumn("paridlocation", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlocationview_alias.Columns.Add(C);
	tlocationview_alias.Columns.Add( new DataColumn("idman", typeof(int)));
	tlocationview_alias.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlocationview_alias.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlocationview_alias.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlocationview_alias.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlocationview_alias.Columns.Add(C);
	tlocationview_alias.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tlocationview_alias.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tlocationview_alias.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tlocationview_alias.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tlocationview_alias.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tlocationview_alias);
	tlocationview_alias.PrimaryKey =  new DataColumn[]{tlocationview_alias.Columns["idlocation"]};


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
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
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


	//////////////////// ASSETVIEW /////////////////////////////////
	var tassetview= new DataTable("assetview");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
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
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	tassetview.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tassetview.Columns.Add( new DataColumn("discount", typeof(double)));
	tassetview.Columns.Add( new DataColumn("total", typeof(decimal)));
	tassetview.Columns.Add( new DataColumn("currentvalue", typeof(decimal)));
	tassetview.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetview.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetview.Columns.Add( new DataColumn("nassetunload", typeof(int)));
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
	tassetview.Columns.Add( new DataColumn("cost", typeof(decimal)));
	tassetview.Columns.Add( new DataColumn("abatable", typeof(decimal)));
	tassetview.Columns.Add( new DataColumn("multifield", typeof(string)));
	Tables.Add(tassetview);
	tassetview.PrimaryKey =  new DataColumn[]{tassetview.Columns["idasset"], tassetview.Columns["idpiece"]};


	//////////////////// ASSETLOCATION /////////////////////////////////
	var tassetlocation= new DataTable("assetlocation");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	tassetlocation.Columns.Add( new DataColumn("start", typeof(DateTime)));
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("idassetlocation", typeof(int));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	Tables.Add(tassetlocation);
	tassetlocation.PrimaryKey =  new DataColumn[]{tassetlocation.Columns["idasset"], tassetlocation.Columns["idassetlocation"]};


	//////////////////// ASSETMANAGER /////////////////////////////////
	var tassetmanager= new DataTable("assetmanager");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	tassetmanager.Columns.Add( new DataColumn("start", typeof(DateTime)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("idassetmanager", typeof(int));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	Tables.Add(tassetmanager);
	tassetmanager.PrimaryKey =  new DataColumn[]{tassetmanager.Columns["idasset"], tassetmanager.Columns["idassetmanager"]};


	//////////////////// MANAGER1 /////////////////////////////////
	var tmanager1= new DataTable("manager1");
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	tmanager1.Columns.Add( new DataColumn("email", typeof(string)));
	tmanager1.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager1.Columns.Add( new DataColumn("userweb", typeof(string)));
	tmanager1.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager1.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager1.Columns.Add(C);
	tmanager1.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tmanager1);
	tmanager1.PrimaryKey =  new DataColumn[]{tmanager1.Columns["idman"]};


	//////////////////// MANAGERCONSEGNATARIO /////////////////////////////////
	var tmanagerconsegnatario= new DataTable("managerconsegnatario");
	tmanagerconsegnatario.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	tmanagerconsegnatario.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	tmanagerconsegnatario.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	tmanagerconsegnatario.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	tmanagerconsegnatario.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanagerconsegnatario);
	tmanagerconsegnatario.PrimaryKey =  new DataColumn[]{tmanagerconsegnatario.Columns["idman"]};


	//////////////////// MANAGERCONSEGNATARIO1 /////////////////////////////////
	var tmanagerconsegnatario1= new DataTable("managerconsegnatario1");
	tmanagerconsegnatario1.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagerconsegnatario1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario1.Columns.Add(C);
	tmanagerconsegnatario1.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagerconsegnatario1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario1.Columns.Add(C);
	tmanagerconsegnatario1.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanagerconsegnatario1.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanagerconsegnatario1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario1.Columns.Add(C);
	tmanagerconsegnatario1.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanagerconsegnatario1.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanagerconsegnatario1.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanagerconsegnatario1.Columns.Add(C);
	tmanagerconsegnatario1.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanagerconsegnatario1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanagerconsegnatario1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanagerconsegnatario1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanagerconsegnatario1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanagerconsegnatario1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanagerconsegnatario1.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanagerconsegnatario1.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanagerconsegnatario1);
	tmanagerconsegnatario1.PrimaryKey =  new DataColumn[]{tmanagerconsegnatario1.Columns["idman"]};


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
	Tables.Add(tassetsubmanager);
	tassetsubmanager.PrimaryKey =  new DataColumn[]{tassetsubmanager.Columns["idasset"], tassetsubmanager.Columns["idassetsubmanager"]};


	#endregion

}
}
}
