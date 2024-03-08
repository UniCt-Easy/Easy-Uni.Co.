
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
namespace assetacquire_massive {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("DS"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class DS: DataSet {

	#region Table members declaration
	///<summary>
	///Carico dei cespiti da bolla/fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetacquire 		=> Tables["assetacquire"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Causali di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadmotive 		=> Tables["assetloadmotive"];

	///<summary>
	///Inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory 		=> Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytreeview 		=> Tables["inventorytreeview"];

	///<summary>
	///Cespiti e accessori
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable asset 		=> Tables["asset"];

	///<summary>
	///Contratto Passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandate 		=> Tables["mandate"];

	///<summary>
	///Dettaglio contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatedetail 		=> Tables["mandatedetail"];

	///<summary>
	///Tipo contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatekind 		=> Tables["mandatekind"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	///<summary>
	///Tipi di buoni di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadkind 		=> Tables["assetloadkind"];

	///<summary>
	///Buono di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetload 		=> Tables["assetload"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

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

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable locationview 		=> Tables["locationview"];

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
	public DataTable managercespiti 		=> Tables["managercespiti"];

	///<summary>
	///Consegnatario cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetsubmanager 		=> Tables["assetsubmanager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable managerconsegnatario 		=> Tables["managerconsegnatario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager1 		=> Tables["manager1"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public DS(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected DS (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "DS";
	Prefix = "";
	Namespace = "http://tempuri.org/DS.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// ASSETACQUIRE /////////////////////////////////
	var tassetacquire= new DataTable("assetacquire");
	C= new DataColumn("nassetacquire", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("abatable", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("discount", typeof(double)));
	tassetacquire.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tassetacquire.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("nman", typeof(int)));
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("rownum", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetacquire.Columns.Add( new DataColumn("startnumber", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tassetacquire.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetacquire.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tassetacquire.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetacquire.Columns.Add( new DataColumn("yman", typeof(short)));
	tassetacquire.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tassetacquire.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("idassetload", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("!idman", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("!idlocation", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("!idmanager", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("idlist", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("yinv", typeof(short)));
	tassetacquire.Columns.Add( new DataColumn("ninv", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("invrownum", typeof(UInt32)));
	Tables.Add(tassetacquire);
	tassetacquire.PrimaryKey =  new DataColumn[]{tassetacquire.Columns["nassetacquire"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// ASSETLOADMOTIVE /////////////////////////////////
	var tassetloadmotive= new DataTable("assetloadmotive");
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	tassetloadmotive.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tassetloadmotive);
	tassetloadmotive.PrimaryKey =  new DataColumn[]{tassetloadmotive.Columns["idmot"]};


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
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
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
	tasset.Columns.Add( new DataColumn("idassetunload", typeof(int)));
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
	tasset.Columns.Add( new DataColumn("!numeroriga", typeof(int)));
	tasset.Columns.Add( new DataColumn("!ninventory", typeof(int)));
	tasset.Columns.Add( new DataColumn("!location", typeof(string)));
	tasset.Columns.Add( new DataColumn("!manager", typeof(string)));
	tasset.Columns.Add( new DataColumn("!assetdescription", typeof(string)));
	tasset.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	tasset.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("multifield", typeof(string)));
	tasset.Columns.Add( new DataColumn("!submanager", typeof(string)));
	tasset.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tasset.Columns.Add( new DataColumn("idinventory", typeof(int)));
	Tables.Add(tasset);
	tasset.PrimaryKey =  new DataColumn[]{tasset.Columns["idasset"], tasset.Columns["idpiece"]};


	//////////////////// MANDATE /////////////////////////////////
	var tmandate= new DataTable("mandate");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("idreg", typeof(int)));
	tmandate.Columns.Add( new DataColumn("registryreference", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("idman", typeof(int)));
	tmandate.Columns.Add( new DataColumn("deliveryexpiration", typeof(string)));
	tmandate.Columns.Add( new DataColumn("deliveryaddress", typeof(string)));
	tmandate.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tmandate.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tmandate.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tmandate.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tmandate.Columns.Add( new DataColumn("doc", typeof(string)));
	tmandate.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("txt", typeof(string)));
	tmandate.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmandate);
	tmandate.PrimaryKey =  new DataColumn[]{tmandate.Columns["idmankind"], tmandate.Columns["yman"], tmandate.Columns["nman"]};


	//////////////////// MANDATEDETAIL /////////////////////////////////
	var tmandatedetail= new DataTable("mandatedetail");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tmandatedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("idinv", typeof(int)));
	C= new DataColumn("assetkind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("flagmixed", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idlocation", typeof(int)));
	Tables.Add(tmandatedetail);
	tmandatedetail.PrimaryKey =  new DataColumn[]{tmandatedetail.Columns["idmankind"], tmandatedetail.Columns["yman"], tmandatedetail.Columns["nman"], tmandatedetail.Columns["rownum"]};


	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new DataTable("mandatekind");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("idupb", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tmandatekind.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("linktoasset", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("multireg", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmandatekind);
	tmandatekind.PrimaryKey =  new DataColumn[]{tmandatekind.Columns["idmankind"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new DataTable("sorting1");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting1);
	tsorting1.PrimaryKey =  new DataColumn[]{tsorting1.Columns["idsor"]};


	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new DataTable("sorting2");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting2);
	tsorting2.PrimaryKey =  new DataColumn[]{tsorting2.Columns["idsor"]};


	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new DataTable("sorting3");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting3);
	tsorting3.PrimaryKey =  new DataColumn[]{tsorting3.Columns["idsor"]};


	//////////////////// ASSETLOADKIND /////////////////////////////////
	var tassetloadkind= new DataTable("assetloadkind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	tassetloadkind.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("codeassetloadkind", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("idassetloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
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
	tassetload.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetload.Columns.Add( new DataColumn("txt", typeof(string)));
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


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appropriationphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("assessmentphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("asset_flagnumbering", typeof(string)));
	tconfig.Columns.Add( new DataColumn("asset_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("assetload_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("boxpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("finvarofficial_default", typeof(string)));
	tconfig.Columns.Add( new DataColumn("casualcontract_flagrestart", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("currpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredexpensephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredincomephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronicimport", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronictrasmission", typeof(string)));
	tconfig.Columns.Add( new DataColumn("expense_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("expensephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flagautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagepexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("foreignhours", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_customer", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferreddebit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_patrimony", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_pl", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_supplier", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_admincar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_foot", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_owncar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idclawback", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpense", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpensesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinincomesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
	tconfig.Columns.Add( new DataColumn("importappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("income_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("incomephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("minpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("motivelen", typeof(short)));
	tconfig.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	tconfig.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	tconfig.Columns.Add( new DataColumn("payment_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("paymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("taxvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flag_paymentamount", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("automanagekind", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("wageimportappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("balancekind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("idpaymethodabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idpaymethodnoabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("iban_f24", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


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
	Tables.Add(tassetmanager);
	tassetmanager.PrimaryKey =  new DataColumn[]{tassetmanager.Columns["idasset"], tassetmanager.Columns["idassetmanager"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


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
	Tables.Add(tlocationview);
	tlocationview.PrimaryKey =  new DataColumn[]{tlocationview.Columns["idlocation"]};


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


	//////////////////// MANAGERCESPITI /////////////////////////////////
	var tmanagercespiti= new DataTable("managercespiti");
	tmanagercespiti.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagercespiti.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanagercespiti.Columns.Add(C);
	tmanagercespiti.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagercespiti.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanagercespiti.Columns.Add(C);
	tmanagercespiti.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanagercespiti.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanagercespiti.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanagercespiti.Columns.Add(C);
	tmanagercespiti.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanagercespiti.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanagercespiti.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanagercespiti.Columns.Add(C);
	tmanagercespiti.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanagercespiti.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanagercespiti.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanagercespiti.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanagercespiti.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanagercespiti.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanagercespiti.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanagercespiti.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanagercespiti);
	tmanagercespiti.PrimaryKey =  new DataColumn[]{tmanagercespiti.Columns["idman"]};


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


	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	tinvoicekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("formatstring", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("active", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("idinvkind_auto", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("printingcode", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("address", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("header", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes1", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes2", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes3", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("riferimento_amministrazione", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("enable_fe", typeof(string)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{asset.Columns["idasset"]};
	var cChild = new []{assetsubmanager.Columns["idasset"]};
	Relations.Add(new DataRelation("FK_asset_assetsubmanager",cPar,cChild,false));

	cPar = new []{managerconsegnatario.Columns["idman"]};
	cChild = new []{assetsubmanager.Columns["idmanager"]};
	Relations.Add(new DataRelation("FK_managerconsegnatario_assetsubmanager",cPar,cChild,false));

	cPar = new []{inventorytreeview.Columns["idinv"]};
	cChild = new []{inventorytreemultifieldkind.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytreeview_inventorytreemultifieldkind",cPar,cChild,false));

	cPar = new []{multifieldkind.Columns["idmultifieldkind"]};
	cChild = new []{inventorytreemultifieldkind.Columns["idmultifieldkind"]};
	Relations.Add(new DataRelation("multifieldkind_inventorytreemultifieldkind",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetmanager.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetmanager",cPar,cChild,false));

	cPar = new []{managercespiti.Columns["idman"]};
	cChild = new []{assetmanager.Columns["idman"]};
	Relations.Add(new DataRelation("FK_managercespiti_assetmanager",cPar,cChild,false));

	cPar = new []{locationview.Columns["idlocation"]};
	cChild = new []{assetlocation.Columns["idlocation"]};
	Relations.Add(new DataRelation("locationview_assetlocation",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetlocation.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetlocation",cPar,cChild,false));

	cPar = new []{assetloadkind.Columns["idassetloadkind"]};
	cChild = new []{assetload.Columns["idassetloadkind"]};
	Relations.Add(new DataRelation("assetloadkind_assetload",cPar,cChild,false));

	cPar = new []{mandate.Columns["idmankind"], mandate.Columns["yman"], mandate.Columns["nman"]};
	cChild = new []{mandatedetail.Columns["idmankind"], mandatedetail.Columns["yman"], mandatedetail.Columns["nman"]};
	Relations.Add(new DataRelation("mandate_mandatedetail",cPar,cChild,false));

	cPar = new []{mandatekind.Columns["idmankind"]};
	cChild = new []{mandate.Columns["idmankind"]};
	Relations.Add(new DataRelation("mandatekind_mandate",cPar,cChild,false));

	cPar = new []{assetacquire.Columns["nassetacquire"]};
	cChild = new []{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("assetacquireasset",cPar,cChild,false));

	cPar = new []{locationview.Columns["idlocation"]};
	cChild = new []{assetacquire.Columns["!idlocation"]};
	Relations.Add(new DataRelation("locationview_assetacquire",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{assetacquire.Columns["!idman"]};
	Relations.Add(new DataRelation("manager_assetacquire",cPar,cChild,false));

	cPar = new []{assetload.Columns["idassetload"]};
	cChild = new []{assetacquire.Columns["idassetload"]};
	Relations.Add(new DataRelation("assetload_assetacquire",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{assetacquire.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_assetacquire",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{assetacquire.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_assetacquire",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{assetacquire.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1_assetacquire",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{assetacquire.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_assetacquire",cPar,cChild,false));

	cPar = new []{mandate.Columns["idmankind"], mandate.Columns["yman"], mandate.Columns["nman"]};
	cChild = new []{assetacquire.Columns["idmankind"], assetacquire.Columns["yman"], assetacquire.Columns["nman"]};
	Relations.Add(new DataRelation("mandate_assetacquire",cPar,cChild,false));

	cPar = new []{inventorytreeview.Columns["idinv"]};
	cChild = new []{assetacquire.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytreeview_assetacquire",cPar,cChild,false));

	cPar = new []{inventory.Columns["idinventory"]};
	cChild = new []{assetacquire.Columns["idinventory"]};
	Relations.Add(new DataRelation("inventory_assetacquire",cPar,cChild,false));

	cPar = new []{assetloadmotive.Columns["idmot"]};
	cChild = new []{assetacquire.Columns["idmot"]};
	Relations.Add(new DataRelation("assetloadmotive_assetacquire",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{assetacquire.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_assetacquire",cPar,cChild,false));

	cPar = new []{manager1.Columns["idman"]};
	cChild = new []{assetacquire.Columns["!idmanager"]};
	Relations.Add(new DataRelation("FK_manager1_assetacquire",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{assetacquire.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekind_assetacquire",cPar,cChild,false));

	#endregion

}
}
}
