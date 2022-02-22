
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using meta_estimatedetail;
using meta_upb;
using meta_ivakind;
using meta_invoicedetail;
using meta_invoicekind;
using meta_sorting;
using meta_accmotiveapplied;
using meta_income;
using meta_tassonomia_pagopa;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace estimatedetail_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatedetailTable estimatedetail 		=> (estimatedetailTable)Tables["estimatedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivakindTable ivakind 		=> (ivakindTable)Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicedetailTable invoicedetail 		=> (invoicedetailTable)Tables["invoicedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting1 		=> (sortingTable)Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting2 		=> (sortingTable)Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting3 		=> (sortingTable)Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied 		=> (accmotiveappliedTable)Tables["accmotiveapplied"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomeTable income_imponibile 		=> (incomeTable)Tables["income_imponibile"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomeTable income_iva 		=> (incomeTable)Tables["income_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview 		=> (MetaTable)Tables["registrymainview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveappliedannulment 		=> (MetaTable)Tables["accmotiveappliedannulment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable revenuepartition 		=> (MetaTable)Tables["revenuepartition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb_iva 		=> (upbTable)Tables["upb_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listview 		=> (MetaTable)Tables["listview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listclass 		=> (MetaTable)Tables["listclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epacc 		=> (MetaTable)Tables["epacc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotive_income 		=> (MetaTable)Tables["finmotive_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting_siope 		=> (sortingTable)Tables["sorting_siope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pre_epacc 		=> (MetaTable)Tables["pre_epacc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public tassonomia_pagopaTable tassonomia_pagopa 		=> (tassonomia_pagopaTable)Tables["tassonomia_pagopa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotive_iva_income 		=> (MetaTable)Tables["finmotive_iva_income"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// ESTIMATEDETAIL /////////////////////////////////
	var testimatedetail= new estimatedetailTable();
	testimatedetail.addBaseColumns("idestimkind","nestim","rownum","yestim","annotations","ct","cu","detaildescription","discount","idinc_iva","idinc_taxable","idsor1","idsor2","idsor3","idupb","lt","lu","ninvoiced","number","start","stop","tax","taxable","taxrate","toinvoice","idaccmotive","idivakind","idreg","idgroup","competencystart","competencystop","idaccmotiveannulment","epkind","idrevenuepartition","idupb_iva","idepacc","idlist","cigcode","iduniqueformcode","nform","idfinmotive","flag","proceedsexpiring","idsor_siope","idepacc_pre","rownum_main","idtassonomia","idfinmotive_iva","cupcode");
	Tables.Add(testimatedetail);
	testimatedetail.defineKey("idestimkind", "nestim", "rownum", "yestim");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","idman","idunderwriter","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idsor01","idsor02","idsor03","idsor04","idsor05","cupcode");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new ivakindTable();
	tivakind.addBaseColumns("idivakind","ct","cu","description","lt","lu","rate","unabatabilitypercentage","active","flag");
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("idinvkind","ninv","rownum","yinv","annotations","competencystart","competencystop","ct","cu","detaildescription","discount","idaccmotive","idivakind","idmankind","idsor1","idsor2","idsor3","idupb","lt","lu","manrownum","nman","number","tax","taxable","unabatable","yman","idestimkind","yestim","nestim","estimrownum","idgroup","idfinmotive_iva");
	tinvoicedetail.defineColumn("!tipodocumento", typeof(string));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("idinvkind", "ninv", "rownum", "yinv");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("idinvkind","ct","cu","description","lt","lu","active");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new sortingTable();
	tsorting1.TableName = "sorting1";
	tsorting1.addBaseColumns("idsor","idsorkind","ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","nlevel","paridsor","printingorder","rtf","sortcode","txt");
	tsorting1.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting1);
	tsorting1.defineKey("idsor");

	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new sortingTable();
	tsorting2.TableName = "sorting2";
	tsorting2.addBaseColumns("idsor","idsorkind","ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","nlevel","paridsor","printingorder","rtf","sortcode","txt");
	tsorting2.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting2);
	tsorting2.defineKey("idsor");

	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new sortingTable();
	tsorting3.TableName = "sorting3";
	tsorting3.addBaseColumns("idsor","idsorkind","ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","nlevel","paridsor","printingorder","rtf","sortcode","txt");
	tsorting3.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting3);
	tsorting3.defineKey("idsor");

	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	var taccmotiveapplied= new accmotiveappliedTable();
	taccmotiveapplied.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagdep","flagamm");
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.defineKey("idaccmotive");

	//////////////////// INCOME_IMPONIBILE /////////////////////////////////
	var tincome_imponibile= new incomeTable();
	tincome_imponibile.TableName = "income_imponibile";
	tincome_imponibile.addBaseColumns("idinc","nphase","ymov","nmov","parentidinc","idreg","idman","doc","docdate","description","autokind","autocode","idpayment","expiration","adate","cu","ct","lu","lt");
	tincome_imponibile.ExtendedProperties["TableForReading"]="income";
	Tables.Add(tincome_imponibile);
	tincome_imponibile.defineKey("idinc");

	//////////////////// INCOME_IVA /////////////////////////////////
	var tincome_iva= new incomeTable();
	tincome_iva.TableName = "income_iva";
	tincome_iva.addBaseColumns("idinc","nphase","ymov","nmov","parentidinc","idreg","idman","doc","docdate","description","autokind","autocode","idpayment","expiration","adate","cu","ct","lu","lt");
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
	var tupb_iva= new upbTable();
	tupb_iva.TableName = "upb_iva";
	tupb_iva.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idman","idunderwriter","cupcode","idsor01","idsor02","idsor03","idsor04","idsor05","flagactivity","flagkind","newcodeupb","idtreasurer","start","stop","cigcode","idepupbkind");
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
	tlistview.defineColumn("idtassonomia", typeof(int));
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
	var tsorting_siope= new sortingTable();
	tsorting_siope.TableName = "sorting_siope";
	tsorting_siope.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email");
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

	//////////////////// TASSONOMIA_PAGOPA /////////////////////////////////
	var ttassonomia_pagopa= new tassonomia_pagopaTable();
	ttassonomia_pagopa.addBaseColumns("idtassonomia","versione","causale","descrizione","start","stop","cu","ct","lu","lt","title","motivoriscossione");
	Tables.Add(ttassonomia_pagopa);
	ttassonomia_pagopa.defineKey("idtassonomia");

	//////////////////// FINMOTIVE_IVA_INCOME /////////////////////////////////
	var tfinmotive_iva_income= new MetaTable("finmotive_iva_income");
	tfinmotive_iva_income.defineColumn("idfinmotive", typeof(string),false);
	tfinmotive_iva_income.defineColumn("active", typeof(string),false);
	tfinmotive_iva_income.defineColumn("codemotive", typeof(string),false);
	tfinmotive_iva_income.defineColumn("paridfinmotive", typeof(string));
	tfinmotive_iva_income.defineColumn("title", typeof(string),false);
	tfinmotive_iva_income.defineColumn("lt", typeof(DateTime));
	tfinmotive_iva_income.defineColumn("lu", typeof(string));
	tfinmotive_iva_income.defineColumn("ct", typeof(DateTime));
	tfinmotive_iva_income.defineColumn("cu", typeof(string));
	Tables.Add(tfinmotive_iva_income);
	tfinmotive_iva_income.defineKey("idfinmotive");

	#endregion


	#region DataRelation creation
	var cPar = new []{estimatedetail.Columns["idestimkind"], estimatedetail.Columns["nestim"], estimatedetail.Columns["rownum"], estimatedetail.Columns["yestim"]};
	var cChild = new []{invoicedetail.Columns["idestimkind"], invoicedetail.Columns["nestim"], invoicedetail.Columns["estimrownum"], invoicedetail.Columns["yestim"]};
	Relations.Add(new DataRelation("estimatedetailinvoicedetail",cPar,cChild,false));

	this.defineRelation("invoicekindinvoicedetail","invoicekind","invoicedetail","idinvkind");
	this.defineRelation("FK_epacc_estimatedetail","epacc","estimatedetail","idepacc");
	this.defineRelation("FK_listview_estimatedetail","listview","estimatedetail","idlist");
	cPar = new []{upb_iva.Columns["idupb"]};
	cChild = new []{estimatedetail.Columns["idupb_iva"]};
	Relations.Add(new DataRelation("FK_upb_iva_estimatedetail",cPar,cChild,false));

	this.defineRelation("registrymainviewestimatedetail","registrymainview","estimatedetail","idreg");
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

	this.defineRelation("upbestimatedetail","upb","estimatedetail","idupb");
	this.defineRelation("ivakindestimatedetail","ivakind","estimatedetail","idivakind");
	this.defineRelation("accmotiveappliedestimatedetail","accmotiveapplied","estimatedetail","idaccmotive");
	cPar = new []{accmotiveappliedannulment.Columns["idaccmotive"]};
	cChild = new []{estimatedetail.Columns["idaccmotiveannulment"]};
	Relations.Add(new DataRelation("accmotiveappliedannulment_estimatedetail",cPar,cChild,false));

	this.defineRelation("revenuepartition_estimatedetail","revenuepartition","estimatedetail","idrevenuepartition");
	this.defineRelation("finmotive_income_estimatedetail","finmotive_income","estimatedetail","idfinmotive");
	cPar = new []{sorting_siope.Columns["idsor"]};
	cChild = new []{estimatedetail.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siope_estimatedetail",cPar,cChild,false));

	cPar = new []{pre_epacc.Columns["idepacc"]};
	cChild = new []{estimatedetail.Columns["idepacc_pre"]};
	Relations.Add(new DataRelation("pre_epacc_estimatedetail",cPar,cChild,false));

	this.defineRelation("tassonomia_pagopa_estimatedetail","tassonomia_pagopa","estimatedetail","idtassonomia");
	cPar = new []{finmotive_iva_income.Columns["idfinmotive"]};
	cChild = new []{estimatedetail.Columns["idfinmotive_iva"]};
	Relations.Add(new DataRelation("finmotive_iva_income_estimatedetail",cPar,cChild,false));

	#endregion

}
}
}
