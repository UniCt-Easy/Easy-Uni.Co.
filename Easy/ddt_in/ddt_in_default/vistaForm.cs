
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
namespace ddt_in_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Bolla di Ingresso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ddt_in 		=> Tables["ddt_in"];

	///<summary>
	///Merce in Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stock 		=> Tables["stock"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Causali Bolla in Ingresso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ddt_in_motive 		=> Tables["ddt_in_motive"];

	///<summary>
	///Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable store 		=> Tables["store"];

	///<summary>
	///Tipo contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatekind 		=> Tables["mandatekind"];

	///<summary>
	/// Causali Ingresso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable storeload_motive 		=> Tables["storeload_motive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listview 		=> Tables["listview"];

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
	//////////////////// DDT_IN /////////////////////////////////
	var tddt_in= new DataTable("ddt_in");
	C= new DataColumn("idddt_in", typeof(int));
	C.AllowDBNull=false;
	tddt_in.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tddt_in.Columns.Add(C);
	C= new DataColumn("yddt_in", typeof(short));
	C.AllowDBNull=false;
	tddt_in.Columns.Add(C);
	C= new DataColumn("nddt_in", typeof(string));
	C.AllowDBNull=false;
	tddt_in.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tddt_in.Columns.Add(C);
	tddt_in.Columns.Add( new DataColumn("terms", typeof(string)));
	tddt_in.Columns.Add( new DataColumn("idddt_in_motive", typeof(int)));
	tddt_in.Columns.Add( new DataColumn("idstore", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tddt_in.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tddt_in.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tddt_in.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tddt_in.Columns.Add(C);
	tddt_in.Columns.Add( new DataColumn("txt", typeof(string)));
	tddt_in.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	Tables.Add(tddt_in);
	tddt_in.PrimaryKey =  new DataColumn[]{tddt_in.Columns["idddt_in"]};


	//////////////////// STOCK /////////////////////////////////
	var tstock= new DataTable("stock");
	C= new DataColumn("idstock", typeof(int));
	C.AllowDBNull=false;
	tstock.Columns.Add(C);
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tstock.Columns.Add(C);
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tstock.Columns.Add(C);
	C= new DataColumn("number", typeof(decimal));
	C.AllowDBNull=false;
	tstock.Columns.Add(C);
	tstock.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tstock.Columns.Add( new DataColumn("expiry", typeof(DateTime)));
	tstock.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tstock.Columns.Add( new DataColumn("yman", typeof(short)));
	tstock.Columns.Add( new DataColumn("nman", typeof(int)));
	tstock.Columns.Add( new DataColumn("man_idgroup", typeof(int)));
	tstock.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tstock.Columns.Add( new DataColumn("yinv", typeof(short)));
	tstock.Columns.Add( new DataColumn("ninv", typeof(int)));
	tstock.Columns.Add( new DataColumn("inv_idgroup", typeof(int)));
	C= new DataColumn("idddt_in", typeof(int));
	C.AllowDBNull=false;
	tstock.Columns.Add(C);
	tstock.Columns.Add( new DataColumn("idstoreload_motive", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstock.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstock.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstock.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstock.Columns.Add(C);
	tstock.Columns.Add( new DataColumn("!list", typeof(string)));
	tstock.Columns.Add( new DataColumn("!tipoordine", typeof(string)));
	tstock.Columns.Add( new DataColumn("!tipoiva", typeof(string)));
	tstock.Columns.Add( new DataColumn("!codiceinterno", typeof(string)));
	tstock.Columns.Add( new DataColumn("!unitacarico", typeof(string)));
	tstock.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tstock.Columns.Add( new DataColumn("flagto_unload", typeof(string)));
	tstock.Columns.Add( new DataColumn("idstocklocation", typeof(int)));
	Tables.Add(tstock);
	tstock.PrimaryKey =  new DataColumn[]{tstock.Columns["idddt_in"], tstock.Columns["idstock"]};


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


	//////////////////// DDT_IN_MOTIVE /////////////////////////////////
	var tddt_in_motive= new DataTable("ddt_in_motive");
	C= new DataColumn("idddt_in_motive", typeof(int));
	C.AllowDBNull=false;
	tddt_in_motive.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tddt_in_motive.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tddt_in_motive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tddt_in_motive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tddt_in_motive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tddt_in_motive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tddt_in_motive.Columns.Add(C);
	tddt_in_motive.Columns.Add( new DataColumn("idstoreload_motive", typeof(int)));
	Tables.Add(tddt_in_motive);
	tddt_in_motive.PrimaryKey =  new DataColumn[]{tddt_in_motive.Columns["idddt_in_motive"]};


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


	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new DataTable("mandatekind");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tmandatekind.Columns.Add( new DataColumn("txt", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("email", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("office", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("linktoasset", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("multireg", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("deltaamount", typeof(decimal)));
	tmandatekind.Columns.Add( new DataColumn("deltapercentage", typeof(decimal)));
	tmandatekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tmandatekind.Columns.Add( new DataColumn("name_c", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("name_l", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("name_r", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("title_c", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("title_l", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("title_r", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("notes1", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("notes2", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("notes3", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("warnmail", typeof(string)));
	Tables.Add(tmandatekind);
	tmandatekind.PrimaryKey =  new DataColumn[]{tmandatekind.Columns["idmankind"]};


	//////////////////// STORELOAD_MOTIVE /////////////////////////////////
	var tstoreload_motive= new DataTable("storeload_motive");
	C= new DataColumn("idstoreload_motive", typeof(int));
	C.AllowDBNull=false;
	tstoreload_motive.Columns.Add(C);
	tstoreload_motive.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstoreload_motive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstoreload_motive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstoreload_motive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstoreload_motive.Columns.Add(C);
	Tables.Add(tstoreload_motive);
	tstoreload_motive.PrimaryKey =  new DataColumn[]{tstoreload_motive.Columns["idstoreload_motive"]};


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
	Tables.Add(tlistview);
	tlistview.PrimaryKey =  new DataColumn[]{tlistview.Columns["idlist"]};


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
	var cPar = new []{listview.Columns["idlist"]};
	var cChild = new []{stock.Columns["idlist"]};
	Relations.Add(new DataRelation("FK_listview_stock",cPar,cChild,false));

	cPar = new []{mandatekind.Columns["idmankind"]};
	cChild = new []{stock.Columns["idmankind"]};
	Relations.Add(new DataRelation("FK_mandatekind_stock",cPar,cChild,false));

	cPar = new []{ddt_in.Columns["idddt_in"]};
	cChild = new []{stock.Columns["idddt_in"]};
	Relations.Add(new DataRelation("ddt_in_stock",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{ddt_in.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_ddt_in",cPar,cChild,false));

	cPar = new []{ddt_in_motive.Columns["idddt_in_motive"]};
	cChild = new []{ddt_in.Columns["idddt_in_motive"]};
	Relations.Add(new DataRelation("ddt_in_motive_ddt_in",cPar,cChild,false));

	cPar = new []{store.Columns["idstore"]};
	cChild = new []{ddt_in.Columns["idstore"]};
	Relations.Add(new DataRelation("store_ddt_in",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{stock.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekind_stock",cPar,cChild,false));

	#endregion

}
}
}
