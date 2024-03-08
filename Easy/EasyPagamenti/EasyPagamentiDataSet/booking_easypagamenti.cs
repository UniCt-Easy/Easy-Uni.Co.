
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
namespace EasyPagamentiDataSet {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm_booking"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm_booking: DataSet {

	#region Table members declaration
	///<summary>
	///Prenotazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable booking 		=> Tables["booking"];

	///<summary>
	///Dettaglio Prenotazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bookingdetail 		=> Tables["bookingdetail"];

	///<summary>
	///Listino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable list 		=> Tables["list"];

	///<summary>
	///Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable store 		=> Tables["store"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bookingview 		=> Tables["bookingview"];

	///<summary>
	///Card
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable lcard 		=> Tables["lcard"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Indirizzo di anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryaddress 		=> Tables["registryaddress"];

	///<summary>
	///Contatto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryreference 		=> Tables["registryreference"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm_booking(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm_booking (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm_booking";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm_booking.xsd";

	#region create DataTables
	DataColumn C;
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
	tbooking.Columns.Add( new DataColumn("!manager", typeof(string)));
	tbooking.Columns.Add( new DataColumn("idcustomuser", typeof(string)));
	tbooking.Columns.Add( new DataColumn("email", typeof(string)));
	tbooking.Columns.Add( new DataColumn("idlcard", typeof(int)));
	Tables.Add(tbooking);
	tbooking.PrimaryKey =  new DataColumn[]{tbooking.Columns["idbooking"]};


	//////////////////// BOOKINGDETAIL /////////////////////////////////
	var tbookingdetail= new DataTable("bookingdetail");
	C= new DataColumn("idbooking", typeof(int));
	C.AllowDBNull=false;
	tbookingdetail.Columns.Add(C);
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tbookingdetail.Columns.Add(C);
	C= new DataColumn("number", typeof(decimal));
	C.AllowDBNull=false;
	tbookingdetail.Columns.Add(C);
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tbookingdetail.Columns.Add(C);
	tbookingdetail.Columns.Add( new DataColumn("cu", typeof(string)));
	tbookingdetail.Columns.Add( new DataColumn("lu", typeof(string)));
	tbookingdetail.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbookingdetail.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tbookingdetail.Columns.Add( new DataColumn("!list", typeof(string)));
	tbookingdetail.Columns.Add( new DataColumn("!store", typeof(string)));
	tbookingdetail.Columns.Add( new DataColumn("authorized", typeof(string)));
	tbookingdetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tbookingdetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tbookingdetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tbookingdetail.Columns.Add( new DataColumn("price", typeof(decimal)));
	tbookingdetail.Columns.Add( new DataColumn("idstock", typeof(int)));
	Tables.Add(tbookingdetail);
	tbookingdetail.PrimaryKey =  new DataColumn[]{tbookingdetail.Columns["idbooking"], tbookingdetail.Columns["idlist"], tbookingdetail.Columns["idstore"]};


	//////////////////// LIST /////////////////////////////////
	var tlist= new DataTable("list");
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("intcode", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	tlist.Columns.Add( new DataColumn("intbarcode", typeof(string)));
	tlist.Columns.Add( new DataColumn("extcode", typeof(string)));
	tlist.Columns.Add( new DataColumn("extbarcode", typeof(string)));
	tlist.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	tlist.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tlist.Columns.Add( new DataColumn("idunit", typeof(int)));
	tlist.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	C= new DataColumn("has_expiry", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	tlist.Columns.Add( new DataColumn("pic", typeof(Byte[])));
	tlist.Columns.Add( new DataColumn("picext", typeof(string)));
	Tables.Add(tlist);
	tlist.PrimaryKey =  new DataColumn[]{tlist.Columns["idlist"]};


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
	tstore.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tstore);
	tstore.PrimaryKey =  new DataColumn[]{tstore.Columns["idstore"]};


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


	//////////////////// BOOKINGVIEW /////////////////////////////////
	var tbookingview= new DataTable("bookingview");
	C= new DataColumn("idbooking", typeof(int));
	C.AllowDBNull=false;
	tbookingview.Columns.Add(C);
	C= new DataColumn("ybooking", typeof(short));
	C.AllowDBNull=false;
	tbookingview.Columns.Add(C);
	tbookingview.Columns.Add( new DataColumn("nbooking", typeof(int)));
	tbookingview.Columns.Add( new DataColumn("forename", typeof(string)));
	tbookingview.Columns.Add( new DataColumn("surname", typeof(string)));
	tbookingview.Columns.Add( new DataColumn("cf", typeof(string)));
	tbookingview.Columns.Add( new DataColumn("idcustomuser", typeof(string)));
	C= new DataColumn("managertitle", typeof(string));
	C.AllowDBNull=false;
	tbookingview.Columns.Add(C);
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tbookingview.Columns.Add(C);
	Tables.Add(tbookingview);
	tbookingview.PrimaryKey =  new DataColumn[]{tbookingview.Columns["idbooking"]};


	//////////////////// LCARD /////////////////////////////////
	var tlcard= new DataTable("lcard");
	C= new DataColumn("idlcard", typeof(int));
	C.AllowDBNull=false;
	tlcard.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tlcard.Columns.Add(C);
	tlcard.Columns.Add( new DataColumn("description", typeof(string)));
	tlcard.Columns.Add( new DataColumn("ystart", typeof(short)));
	tlcard.Columns.Add( new DataColumn("ystop", typeof(short)));
	tlcard.Columns.Add( new DataColumn("active", typeof(string)));
	tlcard.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlcard.Columns.Add(C);
	tlcard.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tlcard.Columns.Add(C);
	Tables.Add(tlcard);
	tlcard.PrimaryKey =  new DataColumn[]{tlcard.Columns["idlcard"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("ccp", typeof(string)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idexternal", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flag_pa", typeof(string)));
	tregistry.Columns.Add( new DataColumn("sdi_defrifamm", typeof(string)));
	tregistry.Columns.Add( new DataColumn("sdi_norifamm", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new DataTable("registryaddress");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	C= new DataColumn("idaddresskind", typeof(int));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	tregistryaddress.Columns.Add( new DataColumn("active", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("address", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("annotations", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("cap", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistryaddress.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistryaddress.Columns.Add( new DataColumn("location", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("officename", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("recipientagency", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	Tables.Add(tregistryaddress);
	tregistryaddress.PrimaryKey =  new DataColumn[]{tregistryaddress.Columns["idreg"], tregistryaddress.Columns["start"], tregistryaddress.Columns["idaddresskind"]};


	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new DataTable("registryreference");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("idregistryreference", typeof(int));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	tregistryreference.Columns.Add( new DataColumn("email", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("flagdefault", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	tregistryreference.Columns.Add( new DataColumn("mobilenumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("msnnumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	C= new DataColumn("referencename", typeof(string));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	tregistryreference.Columns.Add( new DataColumn("registryreferencerole", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistryreference.Columns.Add( new DataColumn("skypenumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("userweb", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("saltweb", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("iterweb", typeof(int)));
	tregistryreference.Columns.Add( new DataColumn("activeweb", typeof(string)));
	Tables.Add(tregistryreference);
	tregistryreference.PrimaryKey =  new DataColumn[]{tregistryreference.Columns["idreg"], tregistryreference.Columns["idregistryreference"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{list.Columns["idlist"]};
	var cChild = new []{bookingdetail.Columns["idlist"]};
	Relations.Add(new DataRelation("list_bookingdetail",cPar,cChild,false));

	cPar = new []{store.Columns["idstore"]};
	cChild = new []{bookingdetail.Columns["idstore"]};
	Relations.Add(new DataRelation("FK_store_bookingdetail",cPar,cChild,false));

	cPar = new []{booking.Columns["idbooking"]};
	cChild = new []{bookingdetail.Columns["idbooking"]};
	Relations.Add(new DataRelation("FK_booking_bookingdetail",cPar,cChild,false));

	cPar = new []{lcard.Columns["idlcard"]};
	cChild = new []{booking.Columns["idlcard"]};
	Relations.Add(new DataRelation("lcard_booking",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{booking.Columns["idman"]};
	Relations.Add(new DataRelation("FK_manager_booking",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registryaddress",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registryreference",cPar,cChild,false));

	#endregion

}
}
}
