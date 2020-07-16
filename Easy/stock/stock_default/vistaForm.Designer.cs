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
namespace stock_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Merce in Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stock 		=> Tables["stock"];

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
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	///<summary>
	/// Causali Ingresso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable storeload_motive 		=> Tables["storeload_motive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listview 		=> Tables["listview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatedetailview 		=> Tables["mandatedetailview"];

	///<summary>
	/// Unità di Misura per l'acquisto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable package 		=> Tables["package"];

	///<summary>
	///Unità di Misura per il carico/scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unit 		=> Tables["unit"];

	///<summary>
	///Bolla di Ingresso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ddt_in 		=> Tables["ddt_in"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stockview 		=> Tables["stockview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable storeunloaddetailview 		=> Tables["storeunloaddetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stocklocationview 		=> Tables["stocklocationview"];

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
	tstock.Columns.Add( new DataColumn("idddt_in", typeof(int)));
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
	tstock.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tstock.Columns.Add( new DataColumn("flagto_unload", typeof(string)));
	tstock.Columns.Add( new DataColumn("idstocklocation", typeof(int)));
	Tables.Add(tstock);
	tstock.PrimaryKey =  new DataColumn[]{tstock.Columns["idstock"]};


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
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


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
	tlistview.Columns.Add( new DataColumn("pic", typeof(Byte[])));
	Tables.Add(tlistview);
	tlistview.PrimaryKey =  new DataColumn[]{tlistview.Columns["idlist"]};


	//////////////////// MANDATEDETAILVIEW /////////////////////////////////
	var tmandatedetailview= new DataTable("mandatedetailview");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	tmandatedetailview.Columns.Add( new DataColumn("idgroup", typeof(int)));
	C= new DataColumn("mankind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	tmandatedetailview.Columns.Add( new DataColumn("idinv", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("codeinv", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("inventorytree", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("registry", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("annotations", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("number", typeof(decimal)));
	tmandatedetailview.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tmandatedetailview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tmandatedetailview.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tmandatedetailview.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("assetkind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	tmandatedetailview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tmandatedetailview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tmandatedetailview.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	C= new DataColumn("taxable_euro", typeof(decimal));
	C.ReadOnly=true;
	tmandatedetailview.Columns.Add(C);
	C= new DataColumn("iva_euro", typeof(decimal));
	C.ReadOnly=true;
	tmandatedetailview.Columns.Add(C);
	C= new DataColumn("rowtotal", typeof(decimal));
	C.ReadOnly=true;
	tmandatedetailview.Columns.Add(C);
	tmandatedetailview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("upb", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("idman", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	tmandatedetailview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("codemotive", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("idaccmotiveannulment", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("codemotiveannulment", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("sortcode1", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("sortcode2", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("sortcode3", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tmandatedetailview.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tmandatedetailview.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("ivakind", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tmandatedetailview.Columns.Add( new DataColumn("flagmixed", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("toinvoice", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandatedetailview.Columns.Add(C);
	tmandatedetailview.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tmandatedetailview.Columns.Add( new DataColumn("va3type", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("ivanotes", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("idlist", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("intcode", typeof(string)));
	tmandatedetailview.Columns.Add( new DataColumn("idunit", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tmandatedetailview.Columns.Add( new DataColumn("idstore", typeof(int)));
	tmandatedetailview.Columns.Add( new DataColumn("store", typeof(string)));
	Tables.Add(tmandatedetailview);
	tmandatedetailview.PrimaryKey =  new DataColumn[]{tmandatedetailview.Columns["idmankind"], tmandatedetailview.Columns["yman"], tmandatedetailview.Columns["nman"], tmandatedetailview.Columns["rownum"]};


	//////////////////// PACKAGE /////////////////////////////////
	var tpackage= new DataTable("package");
	C= new DataColumn("idpackage", typeof(int));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	Tables.Add(tpackage);
	tpackage.PrimaryKey =  new DataColumn[]{tpackage.Columns["idpackage"]};


	//////////////////// UNIT /////////////////////////////////
	var tunit= new DataTable("unit");
	C= new DataColumn("idunit", typeof(int));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	Tables.Add(tunit);
	tunit.PrimaryKey =  new DataColumn[]{tunit.Columns["idunit"]};


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
	Tables.Add(tddt_in);
	tddt_in.PrimaryKey =  new DataColumn[]{tddt_in.Columns["idddt_in"]};


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
	tstockview.Columns.Add( new DataColumn("codelistclass", typeof(string)));
	tstockview.Columns.Add( new DataColumn("listclass", typeof(string)));
	tstockview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tstockview.Columns.Add( new DataColumn("flagto_unload", typeof(string)));
	tstockview.Columns.Add( new DataColumn("authrequired", typeof(string)));
	tstockview.Columns.Add( new DataColumn("idstocklocation", typeof(int)));
	tstockview.Columns.Add( new DataColumn("stocklocationcode", typeof(string)));
	tstockview.Columns.Add( new DataColumn("stocklocation", typeof(string)));
	tstockview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tstockview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tstockview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tstockview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tstockview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tstockview);
	tstockview.PrimaryKey =  new DataColumn[]{tstockview.Columns["idstock"]};


	//////////////////// STOREUNLOADDETAILVIEW /////////////////////////////////
	var tstoreunloaddetailview= new DataTable("storeunloaddetailview");
	C= new DataColumn("idstoreunload", typeof(int));
	C.AllowDBNull=false;
	tstoreunloaddetailview.Columns.Add(C);
	C= new DataColumn("ystoreunload", typeof(short));
	C.AllowDBNull=false;
	tstoreunloaddetailview.Columns.Add(C);
	C= new DataColumn("nstoreunload", typeof(int));
	C.AllowDBNull=false;
	tstoreunloaddetailview.Columns.Add(C);
	C= new DataColumn("idstoreunloaddetail", typeof(int));
	C.AllowDBNull=false;
	tstoreunloaddetailview.Columns.Add(C);
	C= new DataColumn("idstock", typeof(int));
	C.AllowDBNull=false;
	tstoreunloaddetailview.Columns.Add(C);
	tstoreunloaddetailview.Columns.Add( new DataColumn("idstore", typeof(int)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("storeunload_motive", typeof(string)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("idlist", typeof(int)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("store", typeof(string)));
	C= new DataColumn("number", typeof(decimal));
	C.AllowDBNull=false;
	tstoreunloaddetailview.Columns.Add(C);
	tstoreunloaddetailview.Columns.Add( new DataColumn("idbooking", typeof(int)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("ybooking", typeof(short)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("nbooking", typeof(int)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("forename", typeof(string)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("surname", typeof(string)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("idman", typeof(int)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("manager", typeof(string)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("invkind", typeof(string)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("rownum", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tstoreunloaddetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstoreunloaddetailview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstoreunloaddetailview.Columns.Add(C);
	tstoreunloaddetailview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tstoreunloaddetailview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tstoreunloaddetailview);
	tstoreunloaddetailview.PrimaryKey =  new DataColumn[]{tstoreunloaddetailview.Columns["idstoreunload"], tstoreunloaddetailview.Columns["idstoreunloaddetail"]};


	//////////////////// STOCKLOCATIONVIEW /////////////////////////////////
	var tstocklocationview= new DataTable("stocklocationview");
	C= new DataColumn("idstocklocation", typeof(int));
	C.AllowDBNull=false;
	tstocklocationview.Columns.Add(C);
	C= new DataColumn("stocklocationcode", typeof(string));
	C.AllowDBNull=false;
	tstocklocationview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tstocklocationview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tstocklocationview.Columns.Add(C);
	tstocklocationview.Columns.Add( new DataColumn("paridstocklocation", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tstocklocationview.Columns.Add(C);
	tstocklocationview.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstocklocationview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstocklocationview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstocklocationview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstocklocationview.Columns.Add(C);
	tstocklocationview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tstocklocationview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tstocklocationview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tstocklocationview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tstocklocationview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tstocklocationview);
	tstocklocationview.PrimaryKey =  new DataColumn[]{tstocklocationview.Columns["idstocklocation"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{stock.Columns["idstock"]};
	var cChild = new []{storeunloaddetailview.Columns["idstock"]};
	Relations.Add(new DataRelation("stock_storeunloaddetailview",cPar,cChild,false));

	cPar = new []{stock.Columns["idstock"]};
	cChild = new []{stockview.Columns["idstock"]};
	Relations.Add(new DataRelation("stock_stockview",cPar,cChild,false));

	cPar = new []{unit.Columns["idunit"]};
	cChild = new []{listview.Columns["idunit"]};
	Relations.Add(new DataRelation("FK_unit_listview",cPar,cChild,false));

	cPar = new []{package.Columns["idpackage"]};
	cChild = new []{listview.Columns["idpackage"]};
	Relations.Add(new DataRelation("FK_package_listview",cPar,cChild,false));

	cPar = new []{stocklocationview.Columns["idstocklocation"]};
	cChild = new []{stock.Columns["idstocklocation"]};
	Relations.Add(new DataRelation("FK_stocklocationview_stock",cPar,cChild,false));

	cPar = new []{ddt_in.Columns["idddt_in"]};
	cChild = new []{stock.Columns["idddt_in"]};
	Relations.Add(new DataRelation("FK_ddt_in_stock",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{stock.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoicekind_stock",cPar,cChild,false));

	cPar = new []{store.Columns["idstore"]};
	cChild = new []{stock.Columns["idstore"]};
	Relations.Add(new DataRelation("FK_store_stock",cPar,cChild,false));

	cPar = new []{listview.Columns["idlist"]};
	cChild = new []{stock.Columns["idlist"]};
	Relations.Add(new DataRelation("FK_listview_stock",cPar,cChild,false));

	cPar = new []{mandatedetailview.Columns["idmankind"], mandatedetailview.Columns["yman"], mandatedetailview.Columns["nman"], mandatedetailview.Columns["idgroup"]};
	cChild = new []{stock.Columns["idmankind"], stock.Columns["yman"], stock.Columns["nman"], stock.Columns["man_idgroup"]};
	Relations.Add(new DataRelation("FK_mandatedetailview_stock",cPar,cChild,false));

	cPar = new []{storeload_motive.Columns["idstoreload_motive"]};
	cChild = new []{stock.Columns["idstoreload_motive"]};
	Relations.Add(new DataRelation("FK_storeload_motive_stock",cPar,cChild,false));

	cPar = new []{mandatekind.Columns["idmankind"]};
	cChild = new []{stock.Columns["idmankind"]};
	Relations.Add(new DataRelation("FK_mandatekind_stock",cPar,cChild,false));

	#endregion

}
}
}
