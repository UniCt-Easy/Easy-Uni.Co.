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
namespace asset_dettaglio {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	///<summary>
	///Cespiti e accessori
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable asset 		=> Tables["asset"];

	///<summary>
	///Classificazione inventariale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytree 		=> Tables["inventorytree"];

	///<summary>
	///Carico dei cespiti da bolla/fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetacquire 		=> Tables["assetacquire"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetview 		=> Tables["assetview"];

	///<summary>
	///Piano delle Ubicazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable location 		=> Tables["location"];

	///<summary>
	///Responsabile cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetmanager 		=> Tables["assetmanager"];

	///<summary>
	///Ubicazione cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetlocation 		=> Tables["assetlocation"];

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

	///<summary>
	///Consegnatario cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetsubmanager 		=> Tables["assetsubmanager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable submanager 		=> Tables["submanager"];

	///<summary>
	///Tipo Ammortamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventoryamortization 		=> Tables["inventoryamortization"];

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
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// ASSET /////////////////////////////////
	var tasset= new DataTable("asset");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("nassetacquire", typeof(int));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tasset.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	tasset.Columns.Add( new DataColumn("!idlocation", typeof(string)));
	tasset.Columns.Add( new DataColumn("!idman", typeof(int)));
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
	tasset.Columns.Add( new DataColumn("!location", typeof(string)));
	tasset.Columns.Add( new DataColumn("!ninventory", typeof(string)));
	tasset.Columns.Add( new DataColumn("!manager", typeof(string)));
	tasset.Columns.Add( new DataColumn("!numeroriga", typeof(string)));
	tasset.Columns.Add( new DataColumn("!assetdescription", typeof(string)));
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tasset.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tasset.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	tasset.Columns.Add( new DataColumn("multifield", typeof(string)));
	tasset.Columns.Add( new DataColumn("idassetsubmanager", typeof(int)));
	tasset.Columns.Add( new DataColumn("!submanager", typeof(string)));
	tasset.Columns.Add( new DataColumn("idinventoryamortization", typeof(int)));
	tasset.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	tasset.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tasset.Columns.Add( new DataColumn("rfid", typeof(string)));
	Tables.Add(tasset);
	tasset.PrimaryKey =  new DataColumn[]{tasset.Columns["idasset"], tasset.Columns["idpiece"]};


	//////////////////// INVENTORYTREE /////////////////////////////////
	var tinventorytree= new DataTable("inventorytree");
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	tinventorytree.Columns.Add( new DataColumn("paridinv", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	tinventorytree.Columns.Add( new DataColumn("txt", typeof(string)));
	tinventorytree.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	Tables.Add(tinventorytree);
	tinventorytree.PrimaryKey =  new DataColumn[]{tinventorytree.Columns["idinv"]};


	//////////////////// ASSETACQUIRE /////////////////////////////////
	var tassetacquire= new DataTable("assetacquire");
	C= new DataColumn("nassetacquire", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("yman", typeof(short)));
	tassetacquire.Columns.Add( new DataColumn("nman", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("rownum", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetacquire.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tassetacquire.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("startnumber", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetacquire.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("abatable", typeof(decimal)));
	tassetacquire.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tassetacquire.Columns.Add( new DataColumn("transmitted", typeof(string)));
	Tables.Add(tassetacquire);
	tassetacquire.PrimaryKey =  new DataColumn[]{tassetacquire.Columns["nassetacquire"]};


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
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
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
	tassetview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tassetview.Columns.Add( new DataColumn("multifield", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tassetview.Columns.Add( new DataColumn("rfid", typeof(string)));
	Tables.Add(tassetview);
	tassetview.PrimaryKey =  new DataColumn[]{tassetview.Columns["idasset"], tassetview.Columns["idpiece"]};


	//////////////////// LOCATION /////////////////////////////////
	var tlocation= new DataTable("location");
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
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
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	tlocation.Columns.Add( new DataColumn("paridlocation", typeof(int)));
	tlocation.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tlocation.Columns.Add( new DataColumn("txt", typeof(string)));
	tlocation.Columns.Add( new DataColumn("idman", typeof(int)));
	Tables.Add(tlocation);
	tlocation.PrimaryKey =  new DataColumn[]{tlocation.Columns["idlocation"]};


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
	tmultifieldkind.Columns.Add( new DataColumn("ordernumber", typeof(short)));
	tmultifieldkind.Columns.Add( new DataColumn("tabname", typeof(string)));
	tmultifieldkind.Columns.Add( new DataColumn("fieldcode", typeof(string)));
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
	tsubmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tsubmanager.Columns.Add(C);
	tsubmanager.Columns.Add( new DataColumn("txt", typeof(string)));
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


	#endregion


	#region DataRelation creation
	var cPar = new []{asset.Columns["idasset"]};
	var cChild = new []{assetsubmanager.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetsubmanager",cPar,cChild,false));

	cPar = new []{submanager.Columns["idman"]};
	cChild = new []{assetsubmanager.Columns["idmanager"]};
	Relations.Add(new DataRelation("FK_submanager_assetsubmanager",cPar,cChild,false));

	cPar = new []{multifieldkind.Columns["idmultifieldkind"]};
	cChild = new []{inventorytreemultifieldkind.Columns["idmultifieldkind"]};
	Relations.Add(new DataRelation("multifieldkind_inventorytreemultifieldkind",cPar,cChild,false));

	cPar = new []{inventorytree.Columns["idinv"]};
	cChild = new []{inventorytreemultifieldkind.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytree_inventorytreemultifieldkind",cPar,cChild,false));

	cPar = new []{location.Columns["idlocation"]};
	cChild = new []{assetlocation.Columns["idlocation"]};
	Relations.Add(new DataRelation("location_assetlocation",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetlocation.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetlocation",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetmanager.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetmanager",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{assetmanager.Columns["idman"]};
	Relations.Add(new DataRelation("manager_assetmanager",cPar,cChild,false));

	cPar = new []{inventorytree.Columns["idinv"]};
	cChild = new []{assetacquire.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytreeassetacquire",cPar,cChild,false));

	cPar = new []{inventoryamortization.Columns["idinventoryamortization"]};
	cChild = new []{asset.Columns["idinventoryamortization"]};
	Relations.Add(new DataRelation("FK_inventoryamortization_asset",cPar,cChild,false));

	cPar = new []{assetacquire.Columns["nassetacquire"]};
	cChild = new []{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("assetacquireasset",cPar,cChild,false));

	cPar = new []{assetview.Columns["idasset"]};
	cChild = new []{asset.Columns["idasset"]};
	Relations.Add(new DataRelation("assetviewasset",cPar,cChild,false));

	#endregion

}
}
}
