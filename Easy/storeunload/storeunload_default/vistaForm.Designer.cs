
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace storeunload_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Scarico Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable storeunload 		=> Tables["storeunload"];

	///<summary>
	///Dettaglio scarico magazzino 
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable storeunloaddetail 		=> Tables["storeunloaddetail"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	/// Causali Scarico Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable storeunload_motive 		=> Tables["storeunload_motive"];

	///<summary>
	///Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable store 		=> Tables["store"];

	///<summary>
	///Prenotazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable booking 		=> Tables["booking"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stockview 		=> Tables["stockview"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

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
	//////////////////// STOREUNLOAD /////////////////////////////////
	var tstoreunload= new DataTable("storeunload");
	C= new DataColumn("idstoreunload", typeof(int));
	C.AllowDBNull=false;
	tstoreunload.Columns.Add(C);
	C= new DataColumn("idstoreunload_motive", typeof(int));
	C.AllowDBNull=false;
	tstoreunload.Columns.Add(C);
	C= new DataColumn("ystoreunload", typeof(short));
	C.AllowDBNull=false;
	tstoreunload.Columns.Add(C);
	C= new DataColumn("nstoreunload", typeof(int));
	C.AllowDBNull=false;
	tstoreunload.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tstoreunload.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tstoreunload.Columns.Add(C);
	tstoreunload.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstoreunload.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstoreunload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstoreunload.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstoreunload.Columns.Add(C);
	tstoreunload.Columns.Add( new DataColumn("idddt_out", typeof(int)));
	tstoreunload.Columns.Add( new DataColumn("idstore", typeof(int)));
	tstoreunload.Columns.Add( new DataColumn("txt", typeof(string)));
	tstoreunload.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	Tables.Add(tstoreunload);
	tstoreunload.PrimaryKey =  new DataColumn[]{tstoreunload.Columns["idstoreunload"]};


	//////////////////// STOREUNLOADDETAIL /////////////////////////////////
	var tstoreunloaddetail= new DataTable("storeunloaddetail");
	C= new DataColumn("idstoreunload", typeof(int));
	C.AllowDBNull=false;
	tstoreunloaddetail.Columns.Add(C);
	C= new DataColumn("idstoreunloaddetail", typeof(int));
	C.AllowDBNull=false;
	tstoreunloaddetail.Columns.Add(C);
	C= new DataColumn("idstock", typeof(int));
	C.AllowDBNull=false;
	tstoreunloaddetail.Columns.Add(C);
	C= new DataColumn("number", typeof(decimal));
	C.AllowDBNull=false;
	tstoreunloaddetail.Columns.Add(C);
	tstoreunloaddetail.Columns.Add( new DataColumn("idbooking", typeof(int)));
	tstoreunloaddetail.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tstoreunloaddetail.Columns.Add( new DataColumn("yinv", typeof(short)));
	tstoreunloaddetail.Columns.Add( new DataColumn("ninv", typeof(int)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstoreunloaddetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstoreunloaddetail.Columns.Add(C);
	tstoreunloaddetail.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tstoreunloaddetail.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tstoreunloaddetail.Columns.Add( new DataColumn("rownum", typeof(int)));
	tstoreunloaddetail.Columns.Add( new DataColumn("idman", typeof(int)));
	tstoreunloaddetail.Columns.Add( new DataColumn("!ybooking", typeof(short)));
	tstoreunloaddetail.Columns.Add( new DataColumn("!nbooking", typeof(int)));
	tstoreunloaddetail.Columns.Add( new DataColumn("!intcode", typeof(string)));
	tstoreunloaddetail.Columns.Add( new DataColumn("!list", typeof(string)));
	tstoreunloaddetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tstoreunloaddetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tstoreunloaddetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tstoreunloaddetail.Columns.Add( new DataColumn("!idstore", typeof(int)));
	tstoreunloaddetail.Columns.Add( new DataColumn("!manager", typeof(string)));
	tstoreunloaddetail.Columns.Add( new DataColumn("!store", typeof(string)));
	tstoreunloaddetail.Columns.Add( new DataColumn("!surname", typeof(string)));
	tstoreunloaddetail.Columns.Add( new DataColumn("!forename", typeof(string)));
	Tables.Add(tstoreunloaddetail);
	tstoreunloaddetail.PrimaryKey =  new DataColumn[]{tstoreunloaddetail.Columns["idstoreunload"], tstoreunloaddetail.Columns["idstoreunloaddetail"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// STOREUNLOAD_MOTIVE /////////////////////////////////
	var tstoreunload_motive= new DataTable("storeunload_motive");
	C= new DataColumn("idstoreunload_motive", typeof(int));
	C.AllowDBNull=false;
	tstoreunload_motive.Columns.Add(C);
	tstoreunload_motive.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstoreunload_motive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstoreunload_motive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstoreunload_motive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstoreunload_motive.Columns.Add(C);
	Tables.Add(tstoreunload_motive);
	tstoreunload_motive.PrimaryKey =  new DataColumn[]{tstoreunload_motive.Columns["idstoreunload_motive"]};


	//////////////////// STORE /////////////////////////////////
	var tstore= new DataTable("store");
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("deliveryaddress", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	tstore.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	Tables.Add(tstore);
	tstore.PrimaryKey =  new DataColumn[]{tstore.Columns["idstore"]};


	//////////////////// BOOKING /////////////////////////////////
	var tbooking= new DataTable("booking");
	C= new DataColumn("idbooking", typeof(int));
	C.AllowDBNull=false;
	tbooking.Columns.Add(C);
	tbooking.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("ybooking", typeof(short));
	C.AllowDBNull=false;
	tbooking.Columns.Add(C);
	tbooking.Columns.Add( new DataColumn("nbooking", typeof(int)));
	tbooking.Columns.Add( new DataColumn("forename", typeof(string)));
	tbooking.Columns.Add( new DataColumn("surname", typeof(string)));
	tbooking.Columns.Add( new DataColumn("cf", typeof(string)));
	tbooking.Columns.Add( new DataColumn("cu", typeof(string)));
	tbooking.Columns.Add( new DataColumn("lu", typeof(string)));
	tbooking.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbooking.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tbooking);
	tbooking.PrimaryKey =  new DataColumn[]{tbooking.Columns["idbooking"]};


	//////////////////// STOCKVIEW /////////////////////////////////
	var tstockview= new DataTable("stockview");
	C= new DataColumn("idstock", typeof(int));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("store", typeof(string));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("number", typeof(decimal));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("residual", typeof(decimal));
	C.ReadOnly=true;
	tstockview.Columns.Add(C);
	tstockview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tstockview.Columns.Add( new DataColumn("expiry", typeof(DateTime)));
	tstockview.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tstockview.Columns.Add( new DataColumn("mandatekind", typeof(string)));
	tstockview.Columns.Add( new DataColumn("yman", typeof(short)));
	tstockview.Columns.Add( new DataColumn("nman", typeof(int)));
	tstockview.Columns.Add( new DataColumn("man_idgroup", typeof(int)));
	tstockview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tstockview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	tstockview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tstockview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tstockview.Columns.Add( new DataColumn("inv_idgroup", typeof(int)));
	tstockview.Columns.Add( new DataColumn("idddt_in", typeof(int)));
	tstockview.Columns.Add( new DataColumn("idstoreload_motive", typeof(int)));
	tstockview.Columns.Add( new DataColumn("storeload_motive", typeof(string)));
	C= new DataColumn("list", typeof(string));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("intcode", typeof(string));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	tstockview.Columns.Add( new DataColumn("yddt_in", typeof(short)));
	tstockview.Columns.Add( new DataColumn("nddt_in", typeof(string)));
	tstockview.Columns.Add( new DataColumn("listclass", typeof(string)));
	tstockview.Columns.Add( new DataColumn("authrequired", typeof(string)));
	tstockview.Columns.Add( new DataColumn("codelistclass", typeof(string)));
	Tables.Add(tstockview);
	tstockview.PrimaryKey =  new DataColumn[]{tstockview.Columns["idstock"]};


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
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{manager.Columns["idman"]};
	var cChild = new []{storeunloaddetail.Columns["idman"]};
	Relations.Add(new DataRelation("manager_storeunloaddetail",cPar,cChild,false));

	cPar = new []{stockview.Columns["idstock"]};
	cChild = new []{storeunloaddetail.Columns["idstock"]};
	Relations.Add(new DataRelation("stockview_storeunloaddetail",cPar,cChild,false));

	cPar = new []{booking.Columns["idbooking"]};
	cChild = new []{storeunloaddetail.Columns["idbooking"]};
	Relations.Add(new DataRelation("booking_storeunloaddetail",cPar,cChild,false));

	cPar = new []{storeunload.Columns["idstoreunload"]};
	cChild = new []{storeunloaddetail.Columns["idstoreunload"]};
	Relations.Add(new DataRelation("storeunload_storeunloaddetail",cPar,cChild,false));

	cPar = new []{store.Columns["idstore"]};
	cChild = new []{storeunload.Columns["idstore"]};
	Relations.Add(new DataRelation("store_storeunload",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{storeunload.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_storeunload",cPar,cChild,false));

	cPar = new []{storeunload_motive.Columns["idstoreunload_motive"]};
	cChild = new []{storeunload.Columns["idstoreunload_motive"]};
	Relations.Add(new DataRelation("storeunload_motive_storeunload",cPar,cChild,false));

	#endregion

}
}
}
