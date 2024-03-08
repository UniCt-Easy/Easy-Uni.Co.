
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
namespace showcase_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable showcase 		=> Tables["showcase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable showcasedetail 		=> Tables["showcasedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable store 		=> Tables["store"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listview 		=> Tables["listview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatekind 		=> Tables["estimatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_iva1 		=> Tables["upb_iva1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable showcasedetail_related 		=> Tables["showcasedetail_related"];

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
	//////////////////// SHOWCASE /////////////////////////////////
	var tshowcase= new DataTable("showcase");
	C= new DataColumn("idshowcase", typeof(int));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	tshowcase.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tshowcase.Columns.Add( new DataColumn("flagldapvisibility", typeof(int)));
	Tables.Add(tshowcase);
	tshowcase.PrimaryKey =  new DataColumn[]{tshowcase.Columns["idshowcase"]};


	//////////////////// SHOWCASEDETAIL /////////////////////////////////
	var tshowcasedetail= new DataTable("showcasedetail");
	C= new DataColumn("idshowcase", typeof(int));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	tshowcasedetail.Columns.Add( new DataColumn("!intcode", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("!listclass", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("title", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("!description", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("unitprice", typeof(decimal)));
	tshowcasedetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("availability", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	tshowcasedetail.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("!codeinvkind", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tshowcasedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tshowcasedetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("!codeupb_iva", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("!tassonomia", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	Tables.Add(tshowcasedetail);
	tshowcasedetail.PrimaryKey =  new DataColumn[]{tshowcasedetail.Columns["idshowcase"], tshowcasedetail.Columns["idlist"]};


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
	tlistview.Columns.Add( new DataColumn("idtassonomia", typeof(int)));
	tlistview.Columns.Add( new DataColumn("codicetassonomia", typeof(string)));
	tlistview.Columns.Add( new DataColumn("tassonomia", typeof(string)));
	Tables.Add(tlistview);
	tlistview.PrimaryKey =  new DataColumn[]{tlistview.Columns["idlist"]};


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
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
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
	tupb.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


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


	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new DataTable("estimatekind");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	testimatekind.Columns.Add( new DataColumn("txt", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("email", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("office", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("multireg", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("deltaamount", typeof(decimal)));
	testimatekind.Columns.Add( new DataColumn("deltapercentage", typeof(decimal)));
	testimatekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("address", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("header", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("idivakind_forced", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(testimatekind);
	testimatekind.PrimaryKey =  new DataColumn[]{testimatekind.Columns["idestimkind"]};


	//////////////////// UPB_IVA1 /////////////////////////////////
	var tupb_iva1= new DataTable("upb_iva1");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_iva1.Columns.Add(C);
	tupb_iva1.Columns.Add( new DataColumn("active", typeof(string)));
	tupb_iva1.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_iva1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_iva1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb_iva1.Columns.Add(C);
	tupb_iva1.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb_iva1.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_iva1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb_iva1.Columns.Add(C);
	tupb_iva1.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb_iva1.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb_iva1.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb_iva1.Columns.Add(C);
	tupb_iva1.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb_iva1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb_iva1.Columns.Add(C);
	tupb_iva1.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb_iva1.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb_iva1.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb_iva1.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb_iva1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb_iva1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb_iva1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb_iva1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb_iva1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb_iva1.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb_iva1.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb_iva1.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb_iva1.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb_iva1.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb_iva1.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb_iva1.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb_iva1.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	tupb_iva1.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tupb_iva1);
	tupb_iva1.PrimaryKey =  new DataColumn[]{tupb_iva1.Columns["idupb"]};


	//////////////////// SHOWCASEDETAIL_RELATED /////////////////////////////////
	var tshowcasedetail_related= new DataTable("showcasedetail_related");
	C= new DataColumn("idshowcase", typeof(int));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	C= new DataColumn("idlist_related", typeof(int));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	tshowcasedetail_related.Columns.Add( new DataColumn("availability", typeof(int)));
	tshowcasedetail_related.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tshowcasedetail_related.Columns.Add( new DataColumn("title", typeof(string)));
	tshowcasedetail_related.Columns.Add( new DataColumn("unitprice", typeof(decimal)));
	tshowcasedetail_related.Columns.Add( new DataColumn("idupb", typeof(string)));
	tshowcasedetail_related.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tshowcasedetail_related.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tshowcasedetail_related.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tshowcasedetail_related.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tshowcasedetail_related.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tshowcasedetail_related.Columns.Add( new DataColumn("idsor3", typeof(int)));
	Tables.Add(tshowcasedetail_related);
	tshowcasedetail_related.PrimaryKey =  new DataColumn[]{tshowcasedetail_related.Columns["idshowcase"], tshowcasedetail_related.Columns["idlist"], tshowcasedetail_related.Columns["rownum"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{showcase.Columns["idshowcase"]};
	var cChild = new []{showcasedetail.Columns["idshowcase"]};
	Relations.Add(new DataRelation("FK_showcase_showcasedetail",cPar,cChild,false));

	cPar = new []{store.Columns["idstore"]};
	cChild = new []{showcase.Columns["idstore"]};
	Relations.Add(new DataRelation("FK_store_showcase",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{showcasedetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_showcasedetail",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{showcasedetail.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekind_showcasedetail",cPar,cChild,false));

	cPar = new []{estimatekind.Columns["idestimkind"]};
	cChild = new []{showcasedetail.Columns["idestimkind"]};
	Relations.Add(new DataRelation("estimatekind_showcasedetail",cPar,cChild,false));

	cPar = new []{upb_iva1.Columns["idupb"]};
	cChild = new []{showcasedetail.Columns["idupb_iva"]};
	Relations.Add(new DataRelation("upb_iva_showcasedetail",cPar,cChild,false));

	cPar = new []{listview.Columns["idlist"]};
	cChild = new []{showcasedetail.Columns["idlist"]};
	Relations.Add(new DataRelation("listview_showcasedetail",cPar,cChild,false));

	cPar = new []{showcase.Columns["idshowcase"]};
	cChild = new []{showcasedetail_related.Columns["idshowcase"]};
	Relations.Add(new DataRelation("showcase_showcasedetail_related",cPar,cChild,false));

	cPar = new []{showcasedetail.Columns["idshowcase"], showcasedetail.Columns["idlist"]};
	cChild = new []{showcasedetail_related.Columns["idshowcase"], showcasedetail_related.Columns["idlist"]};
	Relations.Add(new DataRelation("showcasedetail_showcasedetail_related",cPar,cChild,false));

	#endregion

}
}
}
