
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
[System.Xml.Serialization.XmlRoot("vistaForm_webpaymentdetail"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm_webpaymentdetail: DataSet {

	#region Table members declaration
	///<summary>
	///Dett. pagamento web
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable webpaymentdetail 		=> Tables["webpaymentdetail"];

	///<summary>
	///Listino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable list 		=> Tables["list"];

	///<summary>
	///Classificazione Merceologica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listclass 		=> Tables["listclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	///<summary>
	///Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable store 		=> Tables["store"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable webpaymentdetailview 		=> Tables["webpaymentdetailview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm_webpaymentdetail(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm_webpaymentdetail (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm_webpaymentdetail";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm_webpaymentdetail.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// WEBPAYMENTDETAIL /////////////////////////////////
	var twebpaymentdetail= new DataTable("webpaymentdetail");
	C= new DataColumn("idwebpayment", typeof(int));
	C.AllowDBNull=false;
	twebpaymentdetail.Columns.Add(C);
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	twebpaymentdetail.Columns.Add(C);
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	twebpaymentdetail.Columns.Add(C);
	twebpaymentdetail.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	twebpaymentdetail.Columns.Add( new DataColumn("cu", typeof(string)));
	twebpaymentdetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	twebpaymentdetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	twebpaymentdetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	twebpaymentdetail.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	twebpaymentdetail.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("number", typeof(decimal));
	C.AllowDBNull=false;
	twebpaymentdetail.Columns.Add(C);
	twebpaymentdetail.Columns.Add( new DataColumn("price", typeof(decimal)));
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	twebpaymentdetail.Columns.Add(C);
	twebpaymentdetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	twebpaymentdetail.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	twebpaymentdetail.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	twebpaymentdetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	twebpaymentdetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	twebpaymentdetail.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	twebpaymentdetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	twebpaymentdetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	twebpaymentdetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	twebpaymentdetail.Columns.Add( new DataColumn("flag_showcase", typeof(int)));
	Tables.Add(twebpaymentdetail);
	twebpaymentdetail.PrimaryKey =  new DataColumn[]{twebpaymentdetail.Columns["idwebpayment"], twebpaymentdetail.Columns["iddetail"]};


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
	tlist.Columns.Add( new DataColumn("nmin", typeof(decimal)));
	tlist.Columns.Add( new DataColumn("ntoreorder", typeof(decimal)));
	tlist.Columns.Add( new DataColumn("tounload", typeof(string)));
	tlist.Columns.Add( new DataColumn("timesupply", typeof(int)));
	tlist.Columns.Add( new DataColumn("nmaxorder", typeof(decimal)));
	tlist.Columns.Add( new DataColumn("price", typeof(decimal)));
	Tables.Add(tlist);
	tlist.PrimaryKey =  new DataColumn[]{tlist.Columns["idlist"]};


	//////////////////// LISTCLASS /////////////////////////////////
	var tlistclass= new DataTable("listclass");
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("codelistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("paridlistclass", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tlistclass.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("authrequired", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("idinv", typeof(int)));
	tlistclass.Columns.Add( new DataColumn("assetkind", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("va3type", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("flag", typeof(int)));
	tlistclass.Columns.Add( new DataColumn("idintrastatsupplymethod", typeof(int)));
	tlistclass.Columns.Add( new DataColumn("intra12operationkind", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("flagvisiblekind", typeof(byte)));
	tlistclass.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	Tables.Add(tlistclass);
	tlistclass.PrimaryKey =  new DataColumn[]{tlistclass.Columns["idlistclass"]};


	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new DataTable("sorting3");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
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
	tsorting3.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting3.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting3.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting3);
	tsorting3.PrimaryKey =  new DataColumn[]{tsorting3.Columns["idsor"]};


	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new DataTable("sorting1");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
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
	tsorting1.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting1.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting1.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting1);
	tsorting1.PrimaryKey =  new DataColumn[]{tsorting1.Columns["idsor"]};


	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new DataTable("sorting2");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
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
	tsorting2.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting2.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting2.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting2);
	tsorting2.PrimaryKey =  new DataColumn[]{tsorting2.Columns["idsor"]};


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
	tstore.Columns.Add( new DataColumn("email", typeof(string)));
	tstore.Columns.Add( new DataColumn("idupb", typeof(string)));
	tstore.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tstore.Columns.Add( new DataColumn("virtual", typeof(string)));
	tstore.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	Tables.Add(tstore);
	tstore.PrimaryKey =  new DataColumn[]{tstore.Columns["idstore"]};


	//////////////////// WEBPAYMENTDETAILVIEW /////////////////////////////////
	var twebpaymentdetailview= new DataTable("webpaymentdetailview");
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	twebpaymentdetailview.Columns.Add(C);
	C= new DataColumn("store", typeof(string));
	C.AllowDBNull=false;
	twebpaymentdetailview.Columns.Add(C);
	C= new DataColumn("idwebpayment", typeof(int));
	C.AllowDBNull=false;
	twebpaymentdetailview.Columns.Add(C);
	C= new DataColumn("ywebpayment", typeof(short));
	C.AllowDBNull=false;
	twebpaymentdetailview.Columns.Add(C);
	twebpaymentdetailview.Columns.Add( new DataColumn("nwebpayment", typeof(int)));
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	twebpaymentdetailview.Columns.Add(C);
	C= new DataColumn("list", typeof(string));
	C.AllowDBNull=false;
	twebpaymentdetailview.Columns.Add(C);
	C= new DataColumn("intcode", typeof(string));
	C.AllowDBNull=false;
	twebpaymentdetailview.Columns.Add(C);
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	twebpaymentdetailview.Columns.Add(C);
	twebpaymentdetailview.Columns.Add( new DataColumn("codelistclass", typeof(string)));
	twebpaymentdetailview.Columns.Add( new DataColumn("listclass", typeof(string)));
	C= new DataColumn("number", typeof(decimal));
	C.AllowDBNull=false;
	twebpaymentdetailview.Columns.Add(C);
	twebpaymentdetailview.Columns.Add( new DataColumn("price", typeof(decimal)));
	twebpaymentdetailview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	twebpaymentdetailview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	twebpaymentdetailview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	twebpaymentdetailview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	twebpaymentdetailview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	twebpaymentdetailview.Columns.Add( new DataColumn("cu", typeof(string)));
	twebpaymentdetailview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	twebpaymentdetailview.Columns.Add( new DataColumn("lu", typeof(string)));
	twebpaymentdetailview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	twebpaymentdetailview.Columns.Add(C);
	twebpaymentdetailview.Columns.Add( new DataColumn("flag_showcase", typeof(int)));
	Tables.Add(twebpaymentdetailview);
	twebpaymentdetailview.PrimaryKey =  new DataColumn[]{twebpaymentdetailview.Columns["idwebpayment"], twebpaymentdetailview.Columns["iddetail"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting3.Columns["idsor"]};
	var cChild = new []{webpaymentdetail.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_webpaymentdetail",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{webpaymentdetail.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_webpaymentdetail",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{webpaymentdetail.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1_webpaymentdetail",cPar,cChild,false));

	cPar = new []{list.Columns["idlist"]};
	cChild = new []{webpaymentdetail.Columns["idlist"]};
	Relations.Add(new DataRelation("list_webpaymentdetail",cPar,cChild,false));

	cPar = new []{listclass.Columns["idlistclass"]};
	cChild = new []{list.Columns["idlistclass"]};
	Relations.Add(new DataRelation("listclass_list",cPar,cChild,false));

	cPar = new []{store.Columns["idstore"]};
	cChild = new []{webpaymentdetail.Columns["idstore"]};
	Relations.Add(new DataRelation("store_webpaymentdetail",cPar,cChild,false));

	#endregion

}
}
}
