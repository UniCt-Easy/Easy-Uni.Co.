
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
namespace showcasedetail_related_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listview 		=> Tables["listview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable showcasedetail_related 		=> Tables["showcasedetail_related"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivakind 		=> Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_iva 		=> Tables["upb_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listview_related 		=> Tables["listview_related"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable showcasedetail 		=> Tables["showcasedetail"];

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
	tlistview.Columns.Add( new DataColumn("idtassonomia", typeof(string)));
	tlistview.Columns.Add( new DataColumn("codicetassonomia", typeof(string)));
	tlistview.Columns.Add( new DataColumn("tassonomia", typeof(string)));
	Tables.Add(tlistview);
	tlistview.PrimaryKey =  new DataColumn[]{tlistview.Columns["idlist"]};


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
	tshowcasedetail_related.Columns.Add( new DataColumn("idlist_related", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tshowcasedetail_related.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
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


	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new DataTable("ivakind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("active", typeof(string)));
	tivakind.Columns.Add( new DataColumn("idivataxablekind", typeof(int)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("codeivakind", typeof(string)));
	tivakind.Columns.Add( new DataColumn("flag", typeof(int)));
	tivakind.Columns.Add( new DataColumn("annotations", typeof(string)));
	tivakind.Columns.Add( new DataColumn("idfenature", typeof(string)));
	Tables.Add(tivakind);
	tivakind.PrimaryKey =  new DataColumn[]{tivakind.Columns["idivakind"]};


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


	//////////////////// UPB_IVA /////////////////////////////////
	var tupb_iva= new DataTable("upb_iva");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	tupb_iva.Columns.Add( new DataColumn("active", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	tupb_iva.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb_iva.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	tupb_iva.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb_iva.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	tupb_iva.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb_iva.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	tupb_iva.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb_iva.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb_iva.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb_iva.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb_iva.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tupb_iva);
	tupb_iva.PrimaryKey =  new DataColumn[]{tupb_iva.Columns["idupb"]};


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
	tsorting3.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tsorting1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tsorting2.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting2);
	tsorting2.PrimaryKey =  new DataColumn[]{tsorting2.Columns["idsor"]};


	//////////////////// LISTVIEW_RELATED /////////////////////////////////
	var tlistview_related= new DataTable("listview_related");
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tlistview_related.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlistview_related.Columns.Add(C);
	C= new DataColumn("intcode", typeof(string));
	C.AllowDBNull=false;
	tlistview_related.Columns.Add(C);
	tlistview_related.Columns.Add( new DataColumn("intbarcode", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("extcode", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("extbarcode", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlistview_related.Columns.Add(C);
	tlistview_related.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tlistview_related.Columns.Add( new DataColumn("package", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("idunit", typeof(int)));
	tlistview_related.Columns.Add( new DataColumn("unit", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	C= new DataColumn("has_expiry", typeof(string));
	C.AllowDBNull=false;
	tlistview_related.Columns.Add(C);
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlistview_related.Columns.Add(C);
	C= new DataColumn("codelistclass", typeof(string));
	C.AllowDBNull=false;
	tlistview_related.Columns.Add(C);
	C= new DataColumn("listclass", typeof(string));
	C.AllowDBNull=false;
	tlistview_related.Columns.Add(C);
	tlistview_related.Columns.Add( new DataColumn("pic", typeof(Byte[])));
	tlistview_related.Columns.Add( new DataColumn("timesupply", typeof(int)));
	tlistview_related.Columns.Add( new DataColumn("nmaxorder", typeof(decimal)));
	tlistview_related.Columns.Add( new DataColumn("authrequired", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("assetkind", typeof(string)));
	C= new DataColumn("assetkinddescr", typeof(string));
	C.ReadOnly=true;
	tlistview_related.Columns.Add(C);
	tlistview_related.Columns.Add( new DataColumn("flagvisiblekind", typeof(byte)));
	tlistview_related.Columns.Add( new DataColumn("idinv", typeof(int)));
	tlistview_related.Columns.Add( new DataColumn("codeinv", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("inventorytree", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("codemotive", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("accmotive", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("price", typeof(decimal)));
	tlistview_related.Columns.Add( new DataColumn("insinfo", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("descrforuser", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("ntoreorder", typeof(decimal)));
	tlistview_related.Columns.Add( new DataColumn("idtassonomia", typeof(int)));
	tlistview_related.Columns.Add( new DataColumn("tassonomia", typeof(string)));
	tlistview_related.Columns.Add( new DataColumn("codicetassonomia", typeof(string)));
	Tables.Add(tlistview_related);
	tlistview_related.PrimaryKey =  new DataColumn[]{tlistview_related.Columns["idlist"]};


	//////////////////// SHOWCASEDETAIL /////////////////////////////////
	var tshowcasedetail= new DataTable("showcasedetail");
	C= new DataColumn("idshowcase", typeof(int));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
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
	tshowcasedetail.Columns.Add( new DataColumn("availability", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("title", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("unitprice", typeof(decimal)));
	tshowcasedetail.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tshowcasedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tshowcasedetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	Tables.Add(tshowcasedetail);
	tshowcasedetail.PrimaryKey =  new DataColumn[]{tshowcasedetail.Columns["idshowcase"], tshowcasedetail.Columns["idlist"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{upb.Columns["idupb"]};
	var cChild = new []{showcasedetail_related.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_showcasedetail_related",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{showcasedetail_related.Columns["idivakind"]};
	Relations.Add(new DataRelation("ivakind_showcasedetail_related",cPar,cChild,false));

	cPar = new []{upb_iva.Columns["idupb"]};
	cChild = new []{showcasedetail_related.Columns["idupb_iva"]};
	Relations.Add(new DataRelation("upb_iva_showcasedetail_related",cPar,cChild,false));

	cPar = new []{listview.Columns["idlist"]};
	cChild = new []{showcasedetail_related.Columns["idlist"]};
	Relations.Add(new DataRelation("listview_showcasedetail_related",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{showcasedetail_related.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1_showcasedetail_related",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{showcasedetail_related.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_showcasedetail_related",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{showcasedetail_related.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_showcasedetail_related",cPar,cChild,false));

	cPar = new []{listview_related.Columns["idlist"]};
	cChild = new []{showcasedetail_related.Columns["idlist_related"]};
	Relations.Add(new DataRelation("listview1_showcasedetail_related",cPar,cChild,false));

	cPar = new []{showcasedetail.Columns["idshowcase"], showcasedetail.Columns["idlist"]};
	cChild = new []{showcasedetail_related.Columns["idshowcase"], showcasedetail_related.Columns["idlist"]};
	Relations.Add(new DataRelation("showcasedetail_showcasedetail_related",cPar,cChild,false));

	#endregion

}
}
}
