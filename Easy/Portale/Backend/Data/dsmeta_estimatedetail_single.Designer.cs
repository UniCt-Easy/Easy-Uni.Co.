
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_estimatedetail_single"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_estimatedetail_single: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimatedetail 		=> (MetaTable)Tables["estimatedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb 		=> (MetaTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ivakind 		=> (MetaTable)Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedetail 		=> (MetaTable)Tables["invoicedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicekind 		=> (MetaTable)Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting1 		=> (MetaTable)Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting2 		=> (MetaTable)Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting3 		=> (MetaTable)Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied 		=> (MetaTable)Tables["accmotiveapplied"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable income_imponibile 		=> (MetaTable)Tables["income_imponibile"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable income_iva 		=> (MetaTable)Tables["income_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview 		=> (MetaTable)Tables["registrymainview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveappliedannulment 		=> (MetaTable)Tables["accmotiveappliedannulment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable revenuepartition 		=> (MetaTable)Tables["revenuepartition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb_iva 		=> (MetaTable)Tables["upb_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listview 		=> (MetaTable)Tables["listview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listclass 		=> (MetaTable)Tables["listclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epacc 		=> (MetaTable)Tables["epacc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotive_income 		=> (MetaTable)Tables["finmotive_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting_siope 		=> (MetaTable)Tables["sorting_siope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pre_epacc 		=> (MetaTable)Tables["pre_epacc"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_estimatedetail_single(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_estimatedetail_single (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_estimatedetail_single";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_estimatedetail_single.xsd";

	#region create DataTables
	//////////////////// ESTIMATEDETAIL /////////////////////////////////
	var testimatedetail= new MetaTable("estimatedetail");
	testimatedetail.defineColumn("idestimkind", typeof(string),false);
	testimatedetail.defineColumn("nestim", typeof(int),false);
	testimatedetail.defineColumn("rownum", typeof(int),false);
	testimatedetail.defineColumn("yestim", typeof(short),false);
	testimatedetail.defineColumn("annotations", typeof(string));
	testimatedetail.defineColumn("ct", typeof(DateTime),false);
	testimatedetail.defineColumn("cu", typeof(string),false);
	testimatedetail.defineColumn("detaildescription", typeof(string));
	testimatedetail.defineColumn("discount", typeof(double));
	testimatedetail.defineColumn("idinc_iva", typeof(int));
	testimatedetail.defineColumn("idinc_taxable", typeof(int));
	testimatedetail.defineColumn("idsor1", typeof(int));
	testimatedetail.defineColumn("idsor2", typeof(int));
	testimatedetail.defineColumn("idsor3", typeof(int));
	testimatedetail.defineColumn("idupb", typeof(string));
	testimatedetail.defineColumn("lt", typeof(DateTime),false);
	testimatedetail.defineColumn("lu", typeof(string),false);
	testimatedetail.defineColumn("ninvoiced", typeof(decimal));
	testimatedetail.defineColumn("number", typeof(decimal));
	testimatedetail.defineColumn("start", typeof(DateTime));
	testimatedetail.defineColumn("stop", typeof(DateTime));
	testimatedetail.defineColumn("tax", typeof(decimal));
	testimatedetail.defineColumn("taxable", typeof(decimal));
	testimatedetail.defineColumn("taxrate", typeof(double));
	testimatedetail.defineColumn("toinvoice", typeof(string));
	testimatedetail.defineColumn("idaccmotive", typeof(string));
	testimatedetail.defineColumn("idivakind", typeof(int));
	testimatedetail.defineColumn("idreg", typeof(int));
	testimatedetail.defineColumn("idgroup", typeof(int));
	testimatedetail.defineColumn("competencystart", typeof(DateTime));
	testimatedetail.defineColumn("competencystop", typeof(DateTime));
	testimatedetail.defineColumn("idaccmotiveannulment", typeof(string));
	testimatedetail.defineColumn("epkind", typeof(string));
	testimatedetail.defineColumn("idrevenuepartition", typeof(int));
	testimatedetail.defineColumn("idupb_iva", typeof(string));
	testimatedetail.defineColumn("idepacc", typeof(int));
	testimatedetail.defineColumn("idlist", typeof(int));
	testimatedetail.defineColumn("cigcode", typeof(string));
	testimatedetail.defineColumn("iduniqueformcode", typeof(string));
	testimatedetail.defineColumn("nform", typeof(string));
	testimatedetail.defineColumn("idfinmotive", typeof(string));
	testimatedetail.defineColumn("flag", typeof(int));
	testimatedetail.defineColumn("proceedsexpiring", typeof(DateTime));
	testimatedetail.defineColumn("idsor_siope", typeof(int));
	testimatedetail.defineColumn("idepacc_pre", typeof(int));
	Tables.Add(testimatedetail);
	testimatedetail.defineKey("idestimkind", "nestim", "rownum", "yestim");

	//////////////////// UPB /////////////////////////////////
	var tupb= new MetaTable("upb");
	tupb.defineColumn("idupb", typeof(string),false);
	tupb.defineColumn("active", typeof(string));
	tupb.defineColumn("assured", typeof(string));
	tupb.defineColumn("codeupb", typeof(string),false);
	tupb.defineColumn("ct", typeof(DateTime),false);
	tupb.defineColumn("cu", typeof(string),false);
	tupb.defineColumn("expiration", typeof(DateTime));
	tupb.defineColumn("granted", typeof(decimal));
	tupb.defineColumn("idman", typeof(int));
	tupb.defineColumn("idunderwriter", typeof(int));
	tupb.defineColumn("lt", typeof(DateTime),false);
	tupb.defineColumn("lu", typeof(string),false);
	tupb.defineColumn("paridupb", typeof(string));
	tupb.defineColumn("previousappropriation", typeof(decimal));
	tupb.defineColumn("previousassessment", typeof(decimal));
	tupb.defineColumn("printingorder", typeof(string),false);
	tupb.defineColumn("requested", typeof(decimal));
	tupb.defineColumn("rtf", typeof(Byte[]));
	tupb.defineColumn("title", typeof(string),false);
	tupb.defineColumn("txt", typeof(string));
	tupb.defineColumn("idsor01", typeof(int));
	tupb.defineColumn("idsor02", typeof(int));
	tupb.defineColumn("idsor03", typeof(int));
	tupb.defineColumn("idsor04", typeof(int));
	tupb.defineColumn("idsor05", typeof(int));
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new MetaTable("ivakind");
	tivakind.defineColumn("idivakind", typeof(int),false);
	tivakind.defineColumn("ct", typeof(DateTime),false);
	tivakind.defineColumn("cu", typeof(string),false);
	tivakind.defineColumn("description", typeof(string),false);
	tivakind.defineColumn("lt", typeof(DateTime),false);
	tivakind.defineColumn("lu", typeof(string),false);
	tivakind.defineColumn("rate", typeof(decimal),false);
	tivakind.defineColumn("unabatabilitypercentage", typeof(decimal),false);
	tivakind.defineColumn("active", typeof(string));
	tivakind.defineColumn("flag", typeof(int));
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new MetaTable("invoicedetail");
	tinvoicedetail.defineColumn("idinvkind", typeof(int),false);
	tinvoicedetail.defineColumn("ninv", typeof(int),false);
	tinvoicedetail.defineColumn("rownum", typeof(int),false);
	tinvoicedetail.defineColumn("yinv", typeof(short),false);
	tinvoicedetail.defineColumn("annotations", typeof(string));
	tinvoicedetail.defineColumn("competencystart", typeof(DateTime));
	tinvoicedetail.defineColumn("competencystop", typeof(DateTime));
	tinvoicedetail.defineColumn("ct", typeof(DateTime),false);
	tinvoicedetail.defineColumn("cu", typeof(string),false);
	tinvoicedetail.defineColumn("detaildescription", typeof(string));
	tinvoicedetail.defineColumn("discount", typeof(double));
	tinvoicedetail.defineColumn("idaccmotive", typeof(string));
	tinvoicedetail.defineColumn("idivakind", typeof(int),false);
	tinvoicedetail.defineColumn("idmankind", typeof(string));
	tinvoicedetail.defineColumn("idsor1", typeof(int));
	tinvoicedetail.defineColumn("idsor2", typeof(int));
	tinvoicedetail.defineColumn("idsor3", typeof(int));
	tinvoicedetail.defineColumn("idupb", typeof(string));
	tinvoicedetail.defineColumn("lt", typeof(DateTime),false);
	tinvoicedetail.defineColumn("lu", typeof(string),false);
	tinvoicedetail.defineColumn("manrownum", typeof(int));
	tinvoicedetail.defineColumn("nman", typeof(int));
	tinvoicedetail.defineColumn("number", typeof(decimal));
	tinvoicedetail.defineColumn("tax", typeof(decimal));
	tinvoicedetail.defineColumn("taxable", typeof(decimal));
	tinvoicedetail.defineColumn("unabatable", typeof(decimal));
	tinvoicedetail.defineColumn("yman", typeof(short));
	tinvoicedetail.defineColumn("idestimkind", typeof(string),false);
	tinvoicedetail.defineColumn("yestim", typeof(short));
	tinvoicedetail.defineColumn("nestim", typeof(int));
	tinvoicedetail.defineColumn("estimrownum", typeof(int));
	tinvoicedetail.defineColumn("idgroup", typeof(int));
	tinvoicedetail.defineColumn("!tipodocumento", typeof(string));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("idinvkind", "ninv", "rownum", "yinv");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new MetaTable("invoicekind");
	tinvoicekind.defineColumn("idinvkind", typeof(int),false);
	tinvoicekind.defineColumn("ct", typeof(DateTime),false);
	tinvoicekind.defineColumn("cu", typeof(string),false);
	tinvoicekind.defineColumn("description", typeof(string),false);
	tinvoicekind.defineColumn("lt", typeof(DateTime),false);
	tinvoicekind.defineColumn("lu", typeof(string),false);
	tinvoicekind.defineColumn("active", typeof(string));
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new MetaTable("sorting1");
	tsorting1.defineColumn("idsor", typeof(int),false);
	tsorting1.defineColumn("idsorkind", typeof(int),false);
	tsorting1.defineColumn("ct", typeof(DateTime),false);
	tsorting1.defineColumn("cu", typeof(string),false);
	tsorting1.defineColumn("defaultN1", typeof(decimal));
	tsorting1.defineColumn("defaultN2", typeof(decimal));
	tsorting1.defineColumn("defaultN3", typeof(decimal));
	tsorting1.defineColumn("defaultN4", typeof(decimal));
	tsorting1.defineColumn("defaultN5", typeof(decimal));
	tsorting1.defineColumn("defaultS1", typeof(string));
	tsorting1.defineColumn("defaultS2", typeof(string));
	tsorting1.defineColumn("defaultS3", typeof(string));
	tsorting1.defineColumn("defaultS4", typeof(string));
	tsorting1.defineColumn("defaultS5", typeof(string));
	tsorting1.defineColumn("defaultv1", typeof(decimal));
	tsorting1.defineColumn("defaultv2", typeof(decimal));
	tsorting1.defineColumn("defaultv3", typeof(decimal));
	tsorting1.defineColumn("defaultv4", typeof(decimal));
	tsorting1.defineColumn("defaultv5", typeof(decimal));
	tsorting1.defineColumn("description", typeof(string),false);
	tsorting1.defineColumn("flagnodate", typeof(string));
	tsorting1.defineColumn("lt", typeof(DateTime),false);
	tsorting1.defineColumn("lu", typeof(string),false);
	tsorting1.defineColumn("movkind", typeof(string));
	tsorting1.defineColumn("nlevel", typeof(byte),false);
	tsorting1.defineColumn("paridsor", typeof(int));
	tsorting1.defineColumn("printingorder", typeof(string));
	tsorting1.defineColumn("rtf", typeof(Byte[]));
	tsorting1.defineColumn("sortcode", typeof(string),false);
	tsorting1.defineColumn("txt", typeof(string));
	tsorting1.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting1);
	tsorting1.defineKey("idsor");

	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new MetaTable("sorting2");
	tsorting2.defineColumn("idsor", typeof(int),false);
	tsorting2.defineColumn("idsorkind", typeof(int),false);
	tsorting2.defineColumn("ct", typeof(DateTime),false);
	tsorting2.defineColumn("cu", typeof(string),false);
	tsorting2.defineColumn("defaultN1", typeof(decimal));
	tsorting2.defineColumn("defaultN2", typeof(decimal));
	tsorting2.defineColumn("defaultN3", typeof(decimal));
	tsorting2.defineColumn("defaultN4", typeof(decimal));
	tsorting2.defineColumn("defaultN5", typeof(decimal));
	tsorting2.defineColumn("defaultS1", typeof(string));
	tsorting2.defineColumn("defaultS2", typeof(string));
	tsorting2.defineColumn("defaultS3", typeof(string));
	tsorting2.defineColumn("defaultS4", typeof(string));
	tsorting2.defineColumn("defaultS5", typeof(string));
	tsorting2.defineColumn("defaultv1", typeof(decimal));
	tsorting2.defineColumn("defaultv2", typeof(decimal));
	tsorting2.defineColumn("defaultv3", typeof(decimal));
	tsorting2.defineColumn("defaultv4", typeof(decimal));
	tsorting2.defineColumn("defaultv5", typeof(decimal));
	tsorting2.defineColumn("description", typeof(string),false);
	tsorting2.defineColumn("flagnodate", typeof(string));
	tsorting2.defineColumn("lt", typeof(DateTime),false);
	tsorting2.defineColumn("lu", typeof(string),false);
	tsorting2.defineColumn("movkind", typeof(string));
	tsorting2.defineColumn("nlevel", typeof(byte),false);
	tsorting2.defineColumn("paridsor", typeof(int));
	tsorting2.defineColumn("printingorder", typeof(string));
	tsorting2.defineColumn("rtf", typeof(Byte[]));
	tsorting2.defineColumn("sortcode", typeof(string),false);
	tsorting2.defineColumn("txt", typeof(string));
	tsorting2.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting2);
	tsorting2.defineKey("idsor");

	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new MetaTable("sorting3");
	tsorting3.defineColumn("idsor", typeof(int),false);
	tsorting3.defineColumn("idsorkind", typeof(int),false);
	tsorting3.defineColumn("ct", typeof(DateTime),false);
	tsorting3.defineColumn("cu", typeof(string),false);
	tsorting3.defineColumn("defaultN1", typeof(decimal));
	tsorting3.defineColumn("defaultN2", typeof(decimal));
	tsorting3.defineColumn("defaultN3", typeof(decimal));
	tsorting3.defineColumn("defaultN4", typeof(decimal));
	tsorting3.defineColumn("defaultN5", typeof(decimal));
	tsorting3.defineColumn("defaultS1", typeof(string));
	tsorting3.defineColumn("defaultS2", typeof(string));
	tsorting3.defineColumn("defaultS3", typeof(string));
	tsorting3.defineColumn("defaultS4", typeof(string));
	tsorting3.defineColumn("defaultS5", typeof(string));
	tsorting3.defineColumn("defaultv1", typeof(decimal));
	tsorting3.defineColumn("defaultv2", typeof(decimal));
	tsorting3.defineColumn("defaultv3", typeof(decimal));
	tsorting3.defineColumn("defaultv4", typeof(decimal));
	tsorting3.defineColumn("defaultv5", typeof(decimal));
	tsorting3.defineColumn("description", typeof(string),false);
	tsorting3.defineColumn("flagnodate", typeof(string));
	tsorting3.defineColumn("lt", typeof(DateTime),false);
	tsorting3.defineColumn("lu", typeof(string),false);
	tsorting3.defineColumn("movkind", typeof(string));
	tsorting3.defineColumn("nlevel", typeof(byte),false);
	tsorting3.defineColumn("paridsor", typeof(int));
	tsorting3.defineColumn("printingorder", typeof(string));
	tsorting3.defineColumn("rtf", typeof(Byte[]));
	tsorting3.defineColumn("sortcode", typeof(string),false);
	tsorting3.defineColumn("txt", typeof(string));
	tsorting3.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting3);
	tsorting3.defineKey("idsor");

	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	var taccmotiveapplied= new MetaTable("accmotiveapplied");
	taccmotiveapplied.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied.defineColumn("motive", typeof(string),false);
	taccmotiveapplied.defineColumn("cu", typeof(string),false);
	taccmotiveapplied.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied.defineColumn("lu", typeof(string),false);
	taccmotiveapplied.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied.defineColumn("active", typeof(string));
	taccmotiveapplied.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied.defineColumn("epoperation", typeof(string));
	taccmotiveapplied.defineColumn("in_use", typeof(string));
	taccmotiveapplied.defineColumn("flagdep", typeof(string));
	taccmotiveapplied.defineColumn("flagamm", typeof(string));
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.defineKey("idaccmotive");

	//////////////////// INCOME_IMPONIBILE /////////////////////////////////
	var tincome_imponibile= new MetaTable("income_imponibile");
	tincome_imponibile.defineColumn("idinc", typeof(int),false);
	tincome_imponibile.defineColumn("nphase", typeof(byte),false);
	tincome_imponibile.defineColumn("ymov", typeof(short),false);
	tincome_imponibile.defineColumn("nmov", typeof(int),false);
	tincome_imponibile.defineColumn("parentidinc", typeof(int));
	tincome_imponibile.defineColumn("idreg", typeof(int));
	tincome_imponibile.defineColumn("idman", typeof(int));
	tincome_imponibile.defineColumn("doc", typeof(string));
	tincome_imponibile.defineColumn("docdate", typeof(DateTime));
	tincome_imponibile.defineColumn("description", typeof(string),false);
	tincome_imponibile.defineColumn("autokind", typeof(byte));
	tincome_imponibile.defineColumn("autocode", typeof(int));
	tincome_imponibile.defineColumn("idpayment", typeof(int));
	tincome_imponibile.defineColumn("expiration", typeof(DateTime));
	tincome_imponibile.defineColumn("adate", typeof(DateTime),false);
	tincome_imponibile.defineColumn("cu", typeof(string),false);
	tincome_imponibile.defineColumn("ct", typeof(DateTime),false);
	tincome_imponibile.defineColumn("lu", typeof(string),false);
	tincome_imponibile.defineColumn("lt", typeof(DateTime),false);
	tincome_imponibile.ExtendedProperties["TableForReading"]="income";
	Tables.Add(tincome_imponibile);
	tincome_imponibile.defineKey("idinc");

	//////////////////// INCOME_IVA /////////////////////////////////
	var tincome_iva= new MetaTable("income_iva");
	tincome_iva.defineColumn("idinc", typeof(int),false);
	tincome_iva.defineColumn("nphase", typeof(byte),false);
	tincome_iva.defineColumn("ymov", typeof(short),false);
	tincome_iva.defineColumn("nmov", typeof(int),false);
	tincome_iva.defineColumn("parentidinc", typeof(int));
	tincome_iva.defineColumn("idreg", typeof(int));
	tincome_iva.defineColumn("idman", typeof(int));
	tincome_iva.defineColumn("doc", typeof(string));
	tincome_iva.defineColumn("docdate", typeof(DateTime));
	tincome_iva.defineColumn("description", typeof(string),false);
	tincome_iva.defineColumn("autokind", typeof(byte));
	tincome_iva.defineColumn("autocode", typeof(int));
	tincome_iva.defineColumn("idpayment", typeof(int));
	tincome_iva.defineColumn("expiration", typeof(DateTime));
	tincome_iva.defineColumn("adate", typeof(DateTime),false);
	tincome_iva.defineColumn("cu", typeof(string),false);
	tincome_iva.defineColumn("ct", typeof(DateTime),false);
	tincome_iva.defineColumn("lu", typeof(string),false);
	tincome_iva.defineColumn("lt", typeof(DateTime),false);
	tincome_iva.ExtendedProperties["TableForReading"]="income";
	Tables.Add(tincome_iva);
	tincome_iva.defineKey("idinc");

	//////////////////// REGISTRYMAINVIEW /////////////////////////////////
	var tregistrymainview= new MetaTable("registrymainview");
	tregistrymainview.defineColumn("idreg", typeof(int),false);
	tregistrymainview.defineColumn("title", typeof(string),false);
	tregistrymainview.defineColumn("idregistryclass", typeof(string));
	tregistrymainview.defineColumn("registryclass", typeof(string));
	tregistrymainview.defineColumn("surname", typeof(string));
	tregistrymainview.defineColumn("forename", typeof(string));
	tregistrymainview.defineColumn("cf", typeof(string));
	tregistrymainview.defineColumn("p_iva", typeof(string));
	tregistrymainview.defineColumn("residence", typeof(int),false);
	tregistrymainview.defineColumn("residencekind", typeof(string));
	tregistrymainview.defineColumn("annotation", typeof(string));
	tregistrymainview.defineColumn("birthdate", typeof(DateTime));
	tregistrymainview.defineColumn("idcity", typeof(int));
	tregistrymainview.defineColumn("city", typeof(string));
	tregistrymainview.defineColumn("gender", typeof(string));
	tregistrymainview.defineColumn("foreigncf", typeof(string));
	tregistrymainview.defineColumn("idtitle", typeof(string));
	tregistrymainview.defineColumn("qualification", typeof(string));
	tregistrymainview.defineColumn("idmaritalstatus", typeof(string));
	tregistrymainview.defineColumn("maritalstatus", typeof(string));
	tregistrymainview.defineColumn("sortcode", typeof(string));
	tregistrymainview.defineColumn("registrykind", typeof(string));
	tregistrymainview.defineColumn("human", typeof(string));
	tregistrymainview.defineColumn("active", typeof(string),false);
	tregistrymainview.defineColumn("badgecode", typeof(string));
	tregistrymainview.defineColumn("maritalsurname", typeof(string));
	tregistrymainview.defineColumn("idcategory", typeof(string));
	tregistrymainview.defineColumn("extmatricula", typeof(string));
	tregistrymainview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrymainview.defineColumn("cu", typeof(string),false);
	tregistrymainview.defineColumn("ct", typeof(DateTime),false);
	tregistrymainview.defineColumn("lu", typeof(string),false);
	tregistrymainview.defineColumn("lt", typeof(DateTime),false);
	tregistrymainview.defineColumn("location", typeof(string));
	tregistrymainview.defineColumn("idnation", typeof(int));
	tregistrymainview.defineColumn("nation", typeof(string));
	Tables.Add(tregistrymainview);
	tregistrymainview.defineKey("idreg");

	//////////////////// ACCMOTIVEAPPLIEDANNULMENT /////////////////////////////////
	var taccmotiveappliedannulment= new MetaTable("accmotiveappliedannulment");
	taccmotiveappliedannulment.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveappliedannulment.defineColumn("paridaccmotive", typeof(string));
	taccmotiveappliedannulment.defineColumn("codemotive", typeof(string),false);
	taccmotiveappliedannulment.defineColumn("motive", typeof(string),false);
	taccmotiveappliedannulment.defineColumn("cu", typeof(string),false);
	taccmotiveappliedannulment.defineColumn("ct", typeof(DateTime),false);
	taccmotiveappliedannulment.defineColumn("lu", typeof(string),false);
	taccmotiveappliedannulment.defineColumn("lt", typeof(DateTime),false);
	taccmotiveappliedannulment.defineColumn("active", typeof(string));
	taccmotiveappliedannulment.defineColumn("idepoperation", typeof(string));
	taccmotiveappliedannulment.defineColumn("epoperation", typeof(string));
	taccmotiveappliedannulment.defineColumn("in_use", typeof(string));
	taccmotiveappliedannulment.defineColumn("flagdep", typeof(string));
	taccmotiveappliedannulment.defineColumn("flagamm", typeof(string));
	Tables.Add(taccmotiveappliedannulment);
	taccmotiveappliedannulment.defineKey("idaccmotive");

	//////////////////// REVENUEPARTITION /////////////////////////////////
	var trevenuepartition= new MetaTable("revenuepartition");
	trevenuepartition.defineColumn("idrevenuepartition", typeof(int),false);
	trevenuepartition.defineColumn("title", typeof(string));
	trevenuepartition.defineColumn("kind", typeof(string));
	trevenuepartition.defineColumn("lt", typeof(DateTime));
	trevenuepartition.defineColumn("lu", typeof(string));
	trevenuepartition.defineColumn("ct", typeof(DateTime));
	trevenuepartition.defineColumn("cu", typeof(string));
	trevenuepartition.defineColumn("revenuepartitioncode", typeof(string));
	trevenuepartition.defineColumn("active", typeof(string));
	trevenuepartition.defineColumn("description", typeof(string));
	Tables.Add(trevenuepartition);
	trevenuepartition.defineKey("idrevenuepartition");

	//////////////////// UPB_IVA /////////////////////////////////
	var tupb_iva= new MetaTable("upb_iva");
	tupb_iva.defineColumn("idupb", typeof(string),false);
	tupb_iva.defineColumn("active", typeof(string));
	tupb_iva.defineColumn("assured", typeof(string));
	tupb_iva.defineColumn("codeupb", typeof(string),false);
	tupb_iva.defineColumn("ct", typeof(DateTime),false);
	tupb_iva.defineColumn("cu", typeof(string),false);
	tupb_iva.defineColumn("expiration", typeof(DateTime));
	tupb_iva.defineColumn("granted", typeof(decimal));
	tupb_iva.defineColumn("lt", typeof(DateTime),false);
	tupb_iva.defineColumn("lu", typeof(string),false);
	tupb_iva.defineColumn("paridupb", typeof(string));
	tupb_iva.defineColumn("previousappropriation", typeof(decimal));
	tupb_iva.defineColumn("previousassessment", typeof(decimal));
	tupb_iva.defineColumn("printingorder", typeof(string),false);
	tupb_iva.defineColumn("requested", typeof(decimal));
	tupb_iva.defineColumn("rtf", typeof(Byte[]));
	tupb_iva.defineColumn("title", typeof(string),false);
	tupb_iva.defineColumn("txt", typeof(string));
	tupb_iva.defineColumn("idman", typeof(int));
	tupb_iva.defineColumn("idunderwriter", typeof(int));
	tupb_iva.defineColumn("cupcode", typeof(string));
	tupb_iva.defineColumn("idsor01", typeof(int));
	tupb_iva.defineColumn("idsor02", typeof(int));
	tupb_iva.defineColumn("idsor03", typeof(int));
	tupb_iva.defineColumn("idsor04", typeof(int));
	tupb_iva.defineColumn("idsor05", typeof(int));
	tupb_iva.defineColumn("flagactivity", typeof(short));
	tupb_iva.defineColumn("flagkind", typeof(byte));
	tupb_iva.defineColumn("newcodeupb", typeof(string));
	tupb_iva.defineColumn("idtreasurer", typeof(int));
	tupb_iva.defineColumn("start", typeof(DateTime));
	tupb_iva.defineColumn("stop", typeof(DateTime));
	tupb_iva.defineColumn("cigcode", typeof(string));
	tupb_iva.defineColumn("idepupbkind", typeof(int));
	tupb_iva.ExtendedProperties["TableForReading"]="upb";
	Tables.Add(tupb_iva);
	tupb_iva.defineKey("idupb");

	//////////////////// LISTVIEW /////////////////////////////////
	var tlistview= new MetaTable("listview");
	tlistview.defineColumn("idlist", typeof(int),false);
	tlistview.defineColumn("description", typeof(string),false);
	tlistview.defineColumn("intcode", typeof(string),false);
	tlistview.defineColumn("intbarcode", typeof(string));
	tlistview.defineColumn("extcode", typeof(string));
	tlistview.defineColumn("extbarcode", typeof(string));
	tlistview.defineColumn("validitystop", typeof(DateTime));
	tlistview.defineColumn("active", typeof(string),false);
	tlistview.defineColumn("idpackage", typeof(int));
	tlistview.defineColumn("package", typeof(string));
	tlistview.defineColumn("idunit", typeof(int));
	tlistview.defineColumn("unit", typeof(string));
	tlistview.defineColumn("unitsforpackage", typeof(int));
	tlistview.defineColumn("has_expiry", typeof(string),false);
	tlistview.defineColumn("idlistclass", typeof(string),false);
	tlistview.defineColumn("codelistclass", typeof(string),false);
	tlistview.defineColumn("listclass", typeof(string),false);
	tlistview.defineColumn("pic", typeof(Byte[]));
	tlistview.defineColumn("timesupply", typeof(int));
	tlistview.defineColumn("nmaxorder", typeof(decimal));
	tlistview.defineColumn("authrequired", typeof(string));
	tlistview.defineColumn("assetkind", typeof(string));
	tlistview.defineColumn("flagvisiblekind", typeof(byte));
	Tables.Add(tlistview);
	tlistview.defineKey("idlist");

	//////////////////// LISTCLASS /////////////////////////////////
	var tlistclass= new MetaTable("listclass");
	tlistclass.defineColumn("idlistclass", typeof(string),false);
	tlistclass.defineColumn("active", typeof(string),false);
	tlistclass.defineColumn("codelistclass", typeof(string),false);
	tlistclass.defineColumn("paridlistclass", typeof(string));
	tlistclass.defineColumn("printingorder", typeof(string),false);
	tlistclass.defineColumn("title", typeof(string),false);
	tlistclass.defineColumn("rtf", typeof(Byte[]));
	tlistclass.defineColumn("txt", typeof(string));
	tlistclass.defineColumn("ct", typeof(DateTime),false);
	tlistclass.defineColumn("cu", typeof(string),false);
	tlistclass.defineColumn("lt", typeof(DateTime),false);
	tlistclass.defineColumn("lu", typeof(string),false);
	tlistclass.defineColumn("authrequired", typeof(string));
	tlistclass.defineColumn("idaccmotive", typeof(string));
	tlistclass.defineColumn("idinv", typeof(int));
	tlistclass.defineColumn("assetkind", typeof(string));
	tlistclass.defineColumn("va3type", typeof(string));
	tlistclass.defineColumn("flag", typeof(int));
	tlistclass.defineColumn("idintrastatsupplymethod", typeof(int));
	tlistclass.defineColumn("intra12operationkind", typeof(string));
	tlistclass.defineColumn("flagvisiblekind", typeof(byte));
	Tables.Add(tlistclass);
	tlistclass.defineKey("idlistclass");

	//////////////////// EPACC /////////////////////////////////
	var tepacc= new MetaTable("epacc");
	tepacc.defineColumn("idepacc", typeof(int),false);
	tepacc.defineColumn("adate", typeof(DateTime),false);
	tepacc.defineColumn("ct", typeof(DateTime),false);
	tepacc.defineColumn("cu", typeof(string),false);
	tepacc.defineColumn("description", typeof(string),false);
	tepacc.defineColumn("doc", typeof(string));
	tepacc.defineColumn("docdate", typeof(DateTime));
	tepacc.defineColumn("idman", typeof(int));
	tepacc.defineColumn("idreg", typeof(int));
	tepacc.defineColumn("idrelated", typeof(string));
	tepacc.defineColumn("lt", typeof(DateTime),false);
	tepacc.defineColumn("lu", typeof(string),false);
	tepacc.defineColumn("nepacc", typeof(int),false);
	tepacc.defineColumn("nphase", typeof(short),false);
	tepacc.defineColumn("paridepacc", typeof(int));
	tepacc.defineColumn("rtf", typeof(Byte[]));
	tepacc.defineColumn("start", typeof(DateTime));
	tepacc.defineColumn("stop", typeof(DateTime));
	tepacc.defineColumn("txt", typeof(string));
	tepacc.defineColumn("yepacc", typeof(short),false);
	tepacc.defineColumn("flagvariation", typeof(string));
	Tables.Add(tepacc);
	tepacc.defineKey("idepacc");

	//////////////////// FINMOTIVE_INCOME /////////////////////////////////
	var tfinmotive_income= new MetaTable("finmotive_income");
	tfinmotive_income.defineColumn("idfinmotive", typeof(string),false);
	tfinmotive_income.defineColumn("active", typeof(string),false);
	tfinmotive_income.defineColumn("codemotive", typeof(string),false);
	tfinmotive_income.defineColumn("paridfinmotive", typeof(string));
	tfinmotive_income.defineColumn("title", typeof(string),false);
	tfinmotive_income.defineColumn("lt", typeof(DateTime));
	tfinmotive_income.defineColumn("lu", typeof(string));
	tfinmotive_income.defineColumn("ct", typeof(DateTime));
	tfinmotive_income.defineColumn("cu", typeof(string));
	tfinmotive_income.ExtendedProperties["TableForReading"]="finmotive";
	Tables.Add(tfinmotive_income);
	tfinmotive_income.defineKey("idfinmotive");

	//////////////////// SORTING_SIOPE /////////////////////////////////
	var tsorting_siope= new MetaTable("sorting_siope");
	tsorting_siope.defineColumn("ct", typeof(DateTime),false);
	tsorting_siope.defineColumn("cu", typeof(string),false);
	tsorting_siope.defineColumn("defaultN1", typeof(decimal));
	tsorting_siope.defineColumn("defaultN2", typeof(decimal));
	tsorting_siope.defineColumn("defaultN3", typeof(decimal));
	tsorting_siope.defineColumn("defaultN4", typeof(decimal));
	tsorting_siope.defineColumn("defaultN5", typeof(decimal));
	tsorting_siope.defineColumn("defaultS1", typeof(string));
	tsorting_siope.defineColumn("defaultS2", typeof(string));
	tsorting_siope.defineColumn("defaultS3", typeof(string));
	tsorting_siope.defineColumn("defaultS4", typeof(string));
	tsorting_siope.defineColumn("defaultS5", typeof(string));
	tsorting_siope.defineColumn("defaultv1", typeof(decimal));
	tsorting_siope.defineColumn("defaultv2", typeof(decimal));
	tsorting_siope.defineColumn("defaultv3", typeof(decimal));
	tsorting_siope.defineColumn("defaultv4", typeof(decimal));
	tsorting_siope.defineColumn("defaultv5", typeof(decimal));
	tsorting_siope.defineColumn("description", typeof(string),false);
	tsorting_siope.defineColumn("flagnodate", typeof(string));
	tsorting_siope.defineColumn("lt", typeof(DateTime),false);
	tsorting_siope.defineColumn("lu", typeof(string),false);
	tsorting_siope.defineColumn("movkind", typeof(string));
	tsorting_siope.defineColumn("printingorder", typeof(string));
	tsorting_siope.defineColumn("rtf", typeof(Byte[]));
	tsorting_siope.defineColumn("sortcode", typeof(string),false);
	tsorting_siope.defineColumn("txt", typeof(string));
	tsorting_siope.defineColumn("idsorkind", typeof(int),false);
	tsorting_siope.defineColumn("idsor", typeof(int),false);
	tsorting_siope.defineColumn("paridsor", typeof(int));
	tsorting_siope.defineColumn("nlevel", typeof(byte),false);
	tsorting_siope.defineColumn("start", typeof(short));
	tsorting_siope.defineColumn("stop", typeof(short));
	tsorting_siope.defineColumn("email", typeof(string));
	tsorting_siope.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting_siope);
	tsorting_siope.defineKey("idsor");

	//////////////////// PRE_EPACC /////////////////////////////////
	var tpre_epacc= new MetaTable("pre_epacc");
	tpre_epacc.defineColumn("idepacc", typeof(int),false);
	tpre_epacc.defineColumn("adate", typeof(DateTime),false);
	tpre_epacc.defineColumn("ct", typeof(DateTime),false);
	tpre_epacc.defineColumn("cu", typeof(string),false);
	tpre_epacc.defineColumn("description", typeof(string),false);
	tpre_epacc.defineColumn("doc", typeof(string));
	tpre_epacc.defineColumn("docdate", typeof(DateTime));
	tpre_epacc.defineColumn("idman", typeof(int));
	tpre_epacc.defineColumn("idreg", typeof(int));
	tpre_epacc.defineColumn("idrelated", typeof(string));
	tpre_epacc.defineColumn("lt", typeof(DateTime),false);
	tpre_epacc.defineColumn("lu", typeof(string),false);
	tpre_epacc.defineColumn("nepacc", typeof(int),false);
	tpre_epacc.defineColumn("nphase", typeof(short),false);
	tpre_epacc.defineColumn("paridepacc", typeof(int));
	tpre_epacc.defineColumn("rtf", typeof(Byte[]));
	tpre_epacc.defineColumn("start", typeof(DateTime));
	tpre_epacc.defineColumn("stop", typeof(DateTime));
	tpre_epacc.defineColumn("txt", typeof(string));
	tpre_epacc.defineColumn("yepacc", typeof(short),false);
	tpre_epacc.defineColumn("flagvariation", typeof(string));
	tpre_epacc.ExtendedProperties["TableForReading"]="epacc";
	Tables.Add(tpre_epacc);
	tpre_epacc.defineKey("idepacc");

	#endregion


	#region DataRelation creation
	var cPar = new []{estimatedetail.Columns["idestimkind"], estimatedetail.Columns["nestim"], estimatedetail.Columns["rownum"], estimatedetail.Columns["yestim"]};
	var cChild = new []{invoicedetail.Columns["idestimkind"], invoicedetail.Columns["nestim"], invoicedetail.Columns["estimrownum"], invoicedetail.Columns["yestim"]};
	Relations.Add(new DataRelation("estimatedetailinvoicedetail",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoicedetail.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekindinvoicedetail",cPar,cChild,false));

	cPar = new []{epacc.Columns["idepacc"]};
	cChild = new []{estimatedetail.Columns["idepacc"]};
	Relations.Add(new DataRelation("FK_epacc_estimatedetail",cPar,cChild,false));

	cPar = new []{listview.Columns["idlist"]};
	cChild = new []{estimatedetail.Columns["idlist"]};
	Relations.Add(new DataRelation("FK_listview_estimatedetail",cPar,cChild,false));

	cPar = new []{upb_iva.Columns["idupb"]};
	cChild = new []{estimatedetail.Columns["idupb_iva"]};
	Relations.Add(new DataRelation("FK_upb_iva_estimatedetail",cPar,cChild,false));

	cPar = new []{registrymainview.Columns["idreg"]};
	cChild = new []{estimatedetail.Columns["idreg"]};
	Relations.Add(new DataRelation("registrymainviewestimatedetail",cPar,cChild,false));

	cPar = new []{income_iva.Columns["idinc"]};
	cChild = new []{estimatedetail.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("income_ivaestimatedetail",cPar,cChild,false));

	cPar = new []{income_imponibile.Columns["idinc"]};
	cChild = new []{estimatedetail.Columns["idinc_taxable"]};
	Relations.Add(new DataRelation("income_imponibileestimatedetail",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{estimatedetail.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3invoicedetail",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{estimatedetail.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2invoicedetail",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{estimatedetail.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1invoicedetail",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{estimatedetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upbestimatedetail",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{estimatedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("ivakindestimatedetail",cPar,cChild,false));

	cPar = new []{accmotiveapplied.Columns["idaccmotive"]};
	cChild = new []{estimatedetail.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveappliedestimatedetail",cPar,cChild,false));

	cPar = new []{accmotiveappliedannulment.Columns["idaccmotive"]};
	cChild = new []{estimatedetail.Columns["idaccmotiveannulment"]};
	Relations.Add(new DataRelation("accmotiveappliedannulment_estimatedetail",cPar,cChild,false));

	cPar = new []{revenuepartition.Columns["idrevenuepartition"]};
	cChild = new []{estimatedetail.Columns["idrevenuepartition"]};
	Relations.Add(new DataRelation("revenuepartition_estimatedetail",cPar,cChild,false));

	cPar = new []{finmotive_income.Columns["idfinmotive"]};
	cChild = new []{estimatedetail.Columns["idfinmotive"]};
	Relations.Add(new DataRelation("finmotive_income_estimatedetail",cPar,cChild,false));

	cPar = new []{sorting_siope.Columns["idsor"]};
	cChild = new []{estimatedetail.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siope_estimatedetail",cPar,cChild,false));

	cPar = new []{pre_epacc.Columns["idepacc"]};
	cChild = new []{estimatedetail.Columns["idepacc_pre"]};
	Relations.Add(new DataRelation("pre_epacc_estimatedetail",cPar,cChild,false));

	#endregion

}
}
}
