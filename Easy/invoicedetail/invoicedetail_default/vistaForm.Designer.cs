
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
namespace invoicedetail_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivakind 		=> Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetail 		=> Tables["invoicedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatekind 		=> Tables["mandatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatekind 		=> Tables["estimatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense_iva 		=> Tables["expense_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense_taxable 		=> Tables["expense_taxable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable income_iva 		=> Tables["income_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable income_taxable 		=> Tables["income_taxable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoice 		=> Tables["invoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive 		=> Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatmeasure 		=> Tables["intrastatmeasure"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatcode 		=> Tables["intrastatcode"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekindregisterkind 		=> Tables["invoicekindregisterkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivaregisterkind 		=> Tables["ivaregisterkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatservice 		=> Tables["intrastatservice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatsupplymethod 		=> Tables["intrastatsupplymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unit 		=> Tables["unit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable package 		=> Tables["package"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listclass 		=> Tables["listclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listview 		=> Tables["listview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_iva 		=> Tables["upb_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind1 		=> Tables["invoicekind1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fetransfer 		=> Tables["fetransfer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable costpartition 		=> Tables["costpartition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccdebitmotive 		=> Tables["pccdebitmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccdebitstatus 		=> Tables["pccdebitstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexp 		=> Tables["epexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetaildeferred 		=> Tables["invoicedetaildeferred"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epacc 		=> Tables["epacc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotive_income 		=> Tables["finmotive_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_siopee 		=> Tables["sorting_siopee"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_siopes 		=> Tables["sorting_siopes"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotive_iva_income 		=> Tables["finmotive_iva_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tassonomia_pagopa 		=> Tables["tassonomia_pagopa"];

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
	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new DataTable("ivakind");
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("active", typeof(string)));
	tivakind.Columns.Add( new DataColumn("idivataxablekind", typeof(int)));
	tivakind.Columns.Add( new DataColumn("codeivakind", typeof(string)));
	tivakind.Columns.Add( new DataColumn("flag", typeof(int)));
	tivakind.Columns.Add( new DataColumn("annotations", typeof(string)));
	tivakind.Columns.Add( new DataColumn("idfenature", typeof(string)));
	Tables.Add(tivakind);
	tivakind.PrimaryKey =  new DataColumn[]{tivakind.Columns["idivakind"]};


	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new DataTable("invoicedetail");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	tinvoicedetail.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("yman", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("nman", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("paymentcompetency", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("yestim", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("nestim", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("estimrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("yinv_main", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("ninv_main", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("va3type", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatcode", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatmeasure", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("weight", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("intrastatoperationkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatservice", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatsupplymethod", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idunit", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("flag", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("exception12", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("intra12operationkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("move12", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idinvkind_main", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("leasing", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("usedmodesospesometro", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idfetransfer", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("fereferencerule", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idpccdebitmotive", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("rounding", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idepacc", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("flagbit", typeof(byte)));
	tinvoicedetail.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("iduniqueformcode", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("ycon", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("ncon", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("codicetipo", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("codicevalore", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idtassonomia", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idfinmotive_iva", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("rownum_main", typeof(int)));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.PrimaryKey =  new DataColumn[]{tinvoicedetail.Columns["idinvkind"], tinvoicedetail.Columns["yinv"], tinvoicedetail.Columns["ninv"], tinvoicedetail.Columns["rownum"]};


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
	tmandatekind.Columns.Add( new DataColumn("active", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	Tables.Add(tmandatekind);
	tmandatekind.PrimaryKey =  new DataColumn[]{tmandatekind.Columns["idmankind"]};


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
	testimatekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	Tables.Add(testimatekind);
	testimatekind.PrimaryKey =  new DataColumn[]{testimatekind.Columns["idestimkind"]};


	//////////////////// EXPENSE_IVA /////////////////////////////////
	var texpense_iva= new DataTable("expense_iva");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	texpense_iva.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpense_iva.Columns.Add( new DataColumn("autokind", typeof(byte)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	texpense_iva.Columns.Add( new DataColumn("doc", typeof(string)));
	texpense_iva.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpense_iva.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	texpense_iva.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpense_iva.Columns.Add( new DataColumn("idman", typeof(int)));
	texpense_iva.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense_iva.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	texpense_iva.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense_iva.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	texpense_iva.Columns.Add( new DataColumn("idclawback", typeof(int)));
	Tables.Add(texpense_iva);
	texpense_iva.PrimaryKey =  new DataColumn[]{texpense_iva.Columns["idexp"]};


	//////////////////// EXPENSE_TAXABLE /////////////////////////////////
	var texpense_taxable= new DataTable("expense_taxable");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense_taxable.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_taxable.Columns.Add(C);
	texpense_taxable.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpense_taxable.Columns.Add( new DataColumn("autokind", typeof(byte)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_taxable.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpense_taxable.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpense_taxable.Columns.Add(C);
	texpense_taxable.Columns.Add( new DataColumn("doc", typeof(string)));
	texpense_taxable.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpense_taxable.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	texpense_taxable.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpense_taxable.Columns.Add( new DataColumn("idman", typeof(int)));
	texpense_taxable.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense_taxable.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_taxable.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpense_taxable.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpense_taxable.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense_taxable.Columns.Add(C);
	texpense_taxable.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense_taxable.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense_taxable.Columns.Add(C);
	texpense_taxable.Columns.Add( new DataColumn("idclawback", typeof(int)));
	Tables.Add(texpense_taxable);
	texpense_taxable.PrimaryKey =  new DataColumn[]{texpense_taxable.Columns["idexp"]};


	//////////////////// INCOME_IVA /////////////////////////////////
	var tincome_iva= new DataTable("income_iva");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincome_iva.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincome_iva.Columns.Add(C);
	tincome_iva.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincome_iva.Columns.Add( new DataColumn("autokind", typeof(byte)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincome_iva.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincome_iva.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincome_iva.Columns.Add(C);
	tincome_iva.Columns.Add( new DataColumn("doc", typeof(string)));
	tincome_iva.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tincome_iva.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tincome_iva.Columns.Add( new DataColumn("idman", typeof(int)));
	tincome_iva.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincome_iva.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincome_iva.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincome_iva.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincome_iva.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincome_iva.Columns.Add(C);
	tincome_iva.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincome_iva.Columns.Add(C);
	Tables.Add(tincome_iva);
	tincome_iva.PrimaryKey =  new DataColumn[]{tincome_iva.Columns["idinc"]};


	//////////////////// INCOME_TAXABLE /////////////////////////////////
	var tincome_taxable= new DataTable("income_taxable");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincome_taxable.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincome_taxable.Columns.Add(C);
	tincome_taxable.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincome_taxable.Columns.Add( new DataColumn("autokind", typeof(byte)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincome_taxable.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincome_taxable.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincome_taxable.Columns.Add(C);
	tincome_taxable.Columns.Add( new DataColumn("doc", typeof(string)));
	tincome_taxable.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tincome_taxable.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tincome_taxable.Columns.Add( new DataColumn("idman", typeof(int)));
	tincome_taxable.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincome_taxable.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincome_taxable.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincome_taxable.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincome_taxable.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincome_taxable.Columns.Add(C);
	tincome_taxable.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincome_taxable.Columns.Add(C);
	Tables.Add(tincome_taxable);
	tincome_taxable.PrimaryKey =  new DataColumn[]{tincome_taxable.Columns["idinc"]};


	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new DataTable("invoice");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("doc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoice.Columns.Add( new DataColumn("flagdeferred", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("packinglistnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("registryreference", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tinvoice.Columns.Add( new DataColumn("txt", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_origin", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_provenance", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_destination", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idcountry_origin", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idcountry_destination", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idintrastatkind", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinvoice);
	tinvoice.PrimaryKey =  new DataColumn[]{tinvoice.Columns["idinvkind"], tinvoice.Columns["yinv"], tinvoice.Columns["ninv"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
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
	tinvoicekind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new DataTable("accmotive");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	Tables.Add(taccmotive);
	taccmotive.PrimaryKey =  new DataColumn[]{taccmotive.Columns["idaccmotive"]};


	//////////////////// INTRASTATMEASURE /////////////////////////////////
	var tintrastatmeasure= new DataTable("intrastatmeasure");
	C= new DataColumn("idintrastatmeasure", typeof(int));
	C.AllowDBNull=false;
	tintrastatmeasure.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatmeasure.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatmeasure.Columns.Add(C);
	tintrastatmeasure.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tintrastatmeasure.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tintrastatmeasure);
	tintrastatmeasure.PrimaryKey =  new DataColumn[]{tintrastatmeasure.Columns["idintrastatmeasure"]};


	//////////////////// INTRASTATCODE /////////////////////////////////
	var tintrastatcode= new DataTable("intrastatcode");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	tintrastatcode.Columns.Add( new DataColumn("idintrastatmeasure", typeof(int)));
	tintrastatcode.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tintrastatcode.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idintrastatcode", typeof(int));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	Tables.Add(tintrastatcode);
	tintrastatcode.PrimaryKey =  new DataColumn[]{tintrastatcode.Columns["idintrastatcode"]};


	//////////////////// INVOICEKINDREGISTERKIND /////////////////////////////////
	var tinvoicekindregisterkind= new DataTable("invoicekindregisterkind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	Tables.Add(tinvoicekindregisterkind);
	tinvoicekindregisterkind.PrimaryKey =  new DataColumn[]{tinvoicekindregisterkind.Columns["idinvkind"], tinvoicekindregisterkind.Columns["idivaregisterkind"]};


	//////////////////// IVAREGISTERKIND /////////////////////////////////
	var tivaregisterkind= new DataTable("ivaregisterkind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("registerclass", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	tivaregisterkind.Columns.Add( new DataColumn("idivaregisterkindunified", typeof(string)));
	tivaregisterkind.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	C= new DataColumn("codeivaregisterkind", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	Tables.Add(tivaregisterkind);
	tivaregisterkind.PrimaryKey =  new DataColumn[]{tivaregisterkind.Columns["idivaregisterkind"]};


	//////////////////// INTRASTATSERVICE /////////////////////////////////
	var tintrastatservice= new DataTable("intrastatservice");
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("idintrastatservice", typeof(int));
	C.AllowDBNull=false;
	C.ReadOnly=true;
	tintrastatservice.Columns.Add(C);
	Tables.Add(tintrastatservice);
	tintrastatservice.PrimaryKey =  new DataColumn[]{tintrastatservice.Columns["idintrastatservice"]};


	//////////////////// INTRASTATSUPPLYMETHOD /////////////////////////////////
	var tintrastatsupplymethod= new DataTable("intrastatsupplymethod");
	C= new DataColumn("idintrastatsupplymethod", typeof(int));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	Tables.Add(tintrastatsupplymethod);
	tintrastatsupplymethod.PrimaryKey =  new DataColumn[]{tintrastatsupplymethod.Columns["idintrastatsupplymethod"]};


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
	Tables.Add(tlistclass);
	tlistclass.PrimaryKey =  new DataColumn[]{tlistclass.Columns["idlistclass"]};


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
	tlistview.Columns.Add( new DataColumn("price", typeof(decimal)));
	tlistview.Columns.Add( new DataColumn("idtassonomia", typeof(int)));
	Tables.Add(tlistview);
	tlistview.PrimaryKey =  new DataColumn[]{tlistview.Columns["idlist"]};


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
	Tables.Add(tupb_iva);
	tupb_iva.PrimaryKey =  new DataColumn[]{tupb_iva.Columns["idupb"]};


	//////////////////// INVOICEKIND1 /////////////////////////////////
	var tinvoicekind1= new DataTable("invoicekind1");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind1.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind1.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind1.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicekind1.Columns.Add(C);
	tinvoicekind1.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	tinvoicekind1.Columns.Add( new DataColumn("formatstring", typeof(string)));
	tinvoicekind1.Columns.Add( new DataColumn("active", typeof(string)));
	tinvoicekind1.Columns.Add( new DataColumn("idinvkind_auto", typeof(int)));
	tinvoicekind1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoicekind1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoicekind1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoicekind1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoicekind1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinvoicekind1);
	tinvoicekind1.PrimaryKey =  new DataColumn[]{tinvoicekind1.Columns["idinvkind"]};


	//////////////////// FETRANSFER /////////////////////////////////
	var tfetransfer= new DataTable("fetransfer");
	C= new DataColumn("idfetransfer", typeof(string));
	C.AllowDBNull=false;
	tfetransfer.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tfetransfer.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfetransfer.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfetransfer.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfetransfer.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfetransfer.Columns.Add(C);
	Tables.Add(tfetransfer);

	//////////////////// COSTPARTITION /////////////////////////////////
	var tcostpartition= new DataTable("costpartition");
	C= new DataColumn("idcostpartition", typeof(int));
	C.AllowDBNull=false;
	tcostpartition.Columns.Add(C);
	tcostpartition.Columns.Add( new DataColumn("title", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("kind", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("lu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("cu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("costpartitioncode", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("active", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("description", typeof(string)));
	Tables.Add(tcostpartition);
	tcostpartition.PrimaryKey =  new DataColumn[]{tcostpartition.Columns["idcostpartition"]};


	//////////////////// PCCDEBITMOTIVE /////////////////////////////////
	var tpccdebitmotive= new DataTable("pccdebitmotive");
	C= new DataColumn("idpccdebitmotive", typeof(string));
	C.AllowDBNull=false;
	tpccdebitmotive.Columns.Add(C);
	tpccdebitmotive.Columns.Add( new DataColumn("description", typeof(string)));
	tpccdebitmotive.Columns.Add( new DataColumn("listingorder", typeof(int)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccdebitmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdebitmotive.Columns.Add(C);
	tpccdebitmotive.Columns.Add( new DataColumn("flagstatus", typeof(int)));
	Tables.Add(tpccdebitmotive);
	tpccdebitmotive.PrimaryKey =  new DataColumn[]{tpccdebitmotive.Columns["idpccdebitmotive"]};


	//////////////////// PCCDEBITSTATUS /////////////////////////////////
	var tpccdebitstatus= new DataTable("pccdebitstatus");
	C= new DataColumn("idpccdebitstatus", typeof(string));
	C.AllowDBNull=false;
	tpccdebitstatus.Columns.Add(C);
	tpccdebitstatus.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdebitstatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccdebitstatus.Columns.Add(C);
	tpccdebitstatus.Columns.Add( new DataColumn("listingorder", typeof(int)));
	tpccdebitstatus.Columns.Add( new DataColumn("flag", typeof(int)));
	tpccdebitstatus.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tpccdebitstatus);
	tpccdebitstatus.PrimaryKey =  new DataColumn[]{tpccdebitstatus.Columns["idpccdebitstatus"]};


	//////////////////// EPEXP /////////////////////////////////
	var tepexp= new DataTable("epexp");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	tepexp.Columns.Add( new DataColumn("doc", typeof(string)));
	tepexp.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("idman", typeof(int)));
	tepexp.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepexp.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(int));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	tepexp.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tepexp.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tepexp.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yepexp", typeof(short));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	Tables.Add(tepexp);
	tepexp.PrimaryKey =  new DataColumn[]{tepexp.Columns["idepexp"]};


	//////////////////// INVOICEDETAILDEFERRED /////////////////////////////////
	var tinvoicedetaildeferred= new DataTable("invoicedetaildeferred");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	tinvoicedetaildeferred.Columns.Add( new DataColumn("ivatotalpayed", typeof(decimal)));
	tinvoicedetaildeferred.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetaildeferred.Columns.Add( new DataColumn("cu", typeof(string)));
	tinvoicedetaildeferred.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tinvoicedetaildeferred.Columns.Add( new DataColumn("lu", typeof(string)));
	tinvoicedetaildeferred.Columns.Add( new DataColumn("lt", typeof(string)));
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	Tables.Add(tinvoicedetaildeferred);
	tinvoicedetaildeferred.PrimaryKey =  new DataColumn[]{tinvoicedetaildeferred.Columns["idinvkind"], tinvoicedetaildeferred.Columns["yinv"], tinvoicedetaildeferred.Columns["ninv"], tinvoicedetaildeferred.Columns["rownum"], tinvoicedetaildeferred.Columns["yivapay"], tinvoicedetaildeferred.Columns["nivapay"], tinvoicedetaildeferred.Columns["idivaregisterkind"]};


	//////////////////// EPACC /////////////////////////////////
	var tepacc= new DataTable("epacc");
	C= new DataColumn("idepacc", typeof(int));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("doc", typeof(string)));
	tepacc.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("idman", typeof(int)));
	tepacc.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepacc.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("nepacc", typeof(int));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("paridepacc", typeof(int)));
	tepacc.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tepacc.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yepacc", typeof(short));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("flagvariation", typeof(string)));
	Tables.Add(tepacc);
	tepacc.PrimaryKey =  new DataColumn[]{tepacc.Columns["idepacc"]};


	//////////////////// FINMOTIVE_INCOME /////////////////////////////////
	var tfinmotive_income= new DataTable("finmotive_income");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_income.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_income.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_income.Columns.Add(C);
	tfinmotive_income.Columns.Add( new DataColumn("paridfinmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_income.Columns.Add(C);
	tfinmotive_income.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotive_income.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotive_income.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotive_income.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tfinmotive_income);
	tfinmotive_income.PrimaryKey =  new DataColumn[]{tfinmotive_income.Columns["idfinmotive"]};


	//////////////////// SORTING_SIOPEE /////////////////////////////////
	var tsorting_siopee= new DataTable("sorting_siopee");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siopee.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopee.Columns.Add(C);
	tsorting_siopee.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_siopee.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopee.Columns.Add(C);
	tsorting_siopee.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siopee.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopee.Columns.Add(C);
	tsorting_siopee.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_siopee.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_siopee.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopee.Columns.Add(C);
	tsorting_siopee.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_siopee.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_siopee.Columns.Add(C);
	tsorting_siopee.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_siopee.Columns.Add(C);
	tsorting_siopee.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_siopee.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting_siopee.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting_siopee);
	tsorting_siopee.PrimaryKey =  new DataColumn[]{tsorting_siopee.Columns["idsor"]};


	//////////////////// SORTING_SIOPES /////////////////////////////////
	var tsorting_siopes= new DataTable("sorting_siopes");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siopes.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopes.Columns.Add(C);
	tsorting_siopes.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_siopes.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopes.Columns.Add(C);
	tsorting_siopes.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siopes.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopes.Columns.Add(C);
	tsorting_siopes.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_siopes.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_siopes.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopes.Columns.Add(C);
	tsorting_siopes.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_siopes.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_siopes.Columns.Add(C);
	tsorting_siopes.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_siopes.Columns.Add(C);
	tsorting_siopes.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_siopes.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting_siopes.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting_siopes);
	tsorting_siopes.PrimaryKey =  new DataColumn[]{tsorting_siopes.Columns["idsor"]};


	//////////////////// FINMOTIVE_IVA_INCOME /////////////////////////////////
	var tfinmotive_iva_income= new DataTable("finmotive_iva_income");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_iva_income.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_iva_income.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_iva_income.Columns.Add(C);
	tfinmotive_iva_income.Columns.Add( new DataColumn("paridfinmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_iva_income.Columns.Add(C);
	tfinmotive_iva_income.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotive_iva_income.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotive_iva_income.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotive_iva_income.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tfinmotive_iva_income);
	tfinmotive_iva_income.PrimaryKey =  new DataColumn[]{tfinmotive_iva_income.Columns["idfinmotive"]};


	//////////////////// TASSONOMIA_PAGOPA /////////////////////////////////
	var ttassonomia_pagopa= new DataTable("tassonomia_pagopa");
	C= new DataColumn("idtassonomia", typeof(int));
	C.AllowDBNull=false;
	ttassonomia_pagopa.Columns.Add(C);
	C= new DataColumn("versione", typeof(int));
	C.AllowDBNull=false;
	ttassonomia_pagopa.Columns.Add(C);
	C= new DataColumn("causale", typeof(string));
	C.AllowDBNull=false;
	ttassonomia_pagopa.Columns.Add(C);
	C= new DataColumn("descrizione", typeof(string));
	C.AllowDBNull=false;
	ttassonomia_pagopa.Columns.Add(C);
	ttassonomia_pagopa.Columns.Add( new DataColumn("start", typeof(DateTime)));
	ttassonomia_pagopa.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttassonomia_pagopa.Columns.Add(C);
	ttassonomia_pagopa.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	ttassonomia_pagopa.Columns.Add( new DataColumn("lu", typeof(string)));
	ttassonomia_pagopa.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	ttassonomia_pagopa.Columns.Add( new DataColumn("title", typeof(string)));
	ttassonomia_pagopa.Columns.Add( new DataColumn("motivoriscossione", typeof(string)));
	Tables.Add(ttassonomia_pagopa);
	ttassonomia_pagopa.PrimaryKey =  new DataColumn[]{ttassonomia_pagopa.Columns["idtassonomia"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{invoicekind.Columns["idinvkind"]};
	var cChild = new []{invoicedetaildeferred.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoicekind_invoicedetaildeferred",cPar,cChild,false));

	cPar = new []{invoicedetail.Columns["idinvkind"], invoicedetail.Columns["yinv"], invoicedetail.Columns["ninv"], invoicedetail.Columns["rownum"]};
	cChild = new []{invoicedetaildeferred.Columns["idinvkind"], invoicedetaildeferred.Columns["yinv"], invoicedetaildeferred.Columns["ninv"], invoicedetaildeferred.Columns["rownum"]};
	Relations.Add(new DataRelation("FK_invoicedetail_invoicedetaildeferred",cPar,cChild,false));

	cPar = new []{epacc.Columns["idepacc"]};
	cChild = new []{invoicedetail.Columns["idepacc"]};
	Relations.Add(new DataRelation("FK_epacc_invoicedetail",cPar,cChild,false));

	cPar = new []{pccdebitstatus.Columns["idpccdebitstatus"]};
	cChild = new []{invoicedetail.Columns["idpccdebitstatus"]};
	Relations.Add(new DataRelation("FK_pccdebitstatus_invoicedetail",cPar,cChild,false));

	cPar = new []{pccdebitmotive.Columns["idpccdebitmotive"]};
	cChild = new []{invoicedetail.Columns["idpccdebitmotive"]};
	Relations.Add(new DataRelation("FK_pccdebitmotive_invoicedetail",cPar,cChild,false));

	cPar = new []{fetransfer.Columns["idfetransfer"]};
	cChild = new []{invoicedetail.Columns["idfetransfer"]};
	Relations.Add(new DataRelation("FK_transferfe_invoicedetail",cPar,cChild,false));

	cPar = new []{upb_iva.Columns["idupb"]};
	cChild = new []{invoicedetail.Columns["idupb_iva"]};
	Relations.Add(new DataRelation("FK_upb_iva_invoicedetail",cPar,cChild,false));

	cPar = new []{listview.Columns["idlist"]};
	cChild = new []{invoicedetail.Columns["idlist"]};
	Relations.Add(new DataRelation("FK_listview_invoicedetail",cPar,cChild,false));

	cPar = new []{package.Columns["idpackage"]};
	cChild = new []{invoicedetail.Columns["idpackage"]};
	Relations.Add(new DataRelation("FK_package_invoicedetail",cPar,cChild,false));

	cPar = new []{unit.Columns["idunit"]};
	cChild = new []{invoicedetail.Columns["idunit"]};
	Relations.Add(new DataRelation("FK_unit_invoicedetail",cPar,cChild,false));

	cPar = new []{intrastatsupplymethod.Columns["idintrastatsupplymethod"]};
	cChild = new []{invoicedetail.Columns["idintrastatsupplymethod"]};
	Relations.Add(new DataRelation("FK_intrastatsupplymethod_invoicedetail",cPar,cChild,false));

	cPar = new []{intrastatservice.Columns["idintrastatservice"]};
	cChild = new []{invoicedetail.Columns["idintrastatservice"]};
	Relations.Add(new DataRelation("FK_intrastatservice_invoicedetail",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{invoicedetail.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotive_invoicedetail",cPar,cChild,false));

	cPar = new []{invoice.Columns["idinvkind"], invoice.Columns["yinv"], invoice.Columns["ninv"]};
	cChild = new []{invoicedetail.Columns["idinvkind"], invoicedetail.Columns["yinv"], invoicedetail.Columns["ninv"]};
	Relations.Add(new DataRelation("invoice_invoicedetail",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{invoicedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("ivakindinvoicedetail",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{invoicedetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upbinvoicedetail",cPar,cChild,false));

	cPar = new []{mandatekind.Columns["idmankind"]};
	cChild = new []{invoicedetail.Columns["idmankind"]};
	Relations.Add(new DataRelation("mandatekindinvoicedetail",cPar,cChild,false));

	cPar = new []{estimatekind.Columns["idestimkind"]};
	cChild = new []{invoicedetail.Columns["idestimkind"]};
	Relations.Add(new DataRelation("estimatekindinvoicedetail",cPar,cChild,false));

	cPar = new []{expense_iva.Columns["idexp"]};
	cChild = new []{invoicedetail.Columns["idexp_iva"]};
	Relations.Add(new DataRelation("expense_ivainvoicedetail",cPar,cChild,false));

	cPar = new []{expense_taxable.Columns["idexp"]};
	cChild = new []{invoicedetail.Columns["idexp_taxable"]};
	Relations.Add(new DataRelation("expense_taxableinvoicedetail",cPar,cChild,false));

	cPar = new []{income_iva.Columns["idinc"]};
	cChild = new []{invoicedetail.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("incomeinvoicedetail",cPar,cChild,false));

	cPar = new []{income_taxable.Columns["idinc"]};
	cChild = new []{invoicedetail.Columns["idinc_taxable"]};
	Relations.Add(new DataRelation("income_taxableinvoicedetail",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{invoicedetail.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1invoicedetail",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{invoicedetail.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2invoicedetail",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{invoicedetail.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3invoicedetail",cPar,cChild,false));

	cPar = new []{intrastatcode.Columns["idintrastatcode"]};
	cChild = new []{invoicedetail.Columns["idintrastatcode"]};
	Relations.Add(new DataRelation("intrastatcode_invoicedetail",cPar,cChild,false));

	cPar = new []{intrastatmeasure.Columns["idintrastatmeasure"]};
	cChild = new []{invoicedetail.Columns["idintrastatmeasure"]};
	Relations.Add(new DataRelation("intrastatmeasure_invoicedetail",cPar,cChild,false));

	cPar = new []{invoicekind1.Columns["idinvkind"]};
	cChild = new []{invoicedetail.Columns["idinvkind_main"]};
	Relations.Add(new DataRelation("invoicekind1_invoicedetail",cPar,cChild,false));

	cPar = new []{costpartition.Columns["idcostpartition"]};
	cChild = new []{invoicedetail.Columns["idcostpartition"]};
	Relations.Add(new DataRelation("costpartition_invoicedetail",cPar,cChild,false));

	cPar = new []{epexp.Columns["idepexp"]};
	cChild = new []{invoicedetail.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexp_invoicedetail",cPar,cChild,false));

	cPar = new []{finmotive_income.Columns["idfinmotive"]};
	cChild = new []{invoicedetail.Columns["idfinmotive"]};
	Relations.Add(new DataRelation("finmotive_income_invoicedetail",cPar,cChild,false));

	cPar = new []{sorting_siopee.Columns["idsor"]};
	cChild = new []{invoicedetail.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siope_invoicedetail",cPar,cChild,false));

	cPar = new []{sorting_siopes.Columns["idsor"]};
	cChild = new []{invoicedetail.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siopes_invoicedetail",cPar,cChild,false));

	cPar = new []{finmotive_iva_income.Columns["idfinmotive"]};
	cChild = new []{invoicedetail.Columns["idfinmotive_iva"]};
	Relations.Add(new DataRelation("finmotive_iva_invoicedetail",cPar,cChild,false));

	cPar = new []{tassonomia_pagopa.Columns["idtassonomia"]};
	cChild = new []{invoicedetail.Columns["idtassonomia"]};
	Relations.Add(new DataRelation("tassonomia_pagopa_invoicedetail",cPar,cChild,false));

	#endregion

}
}
}
