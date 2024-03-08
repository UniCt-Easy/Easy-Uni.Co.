
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
using meta_ivakind;
using meta_invoicedetail;
using meta_sorting;
using meta_upb;
using meta_mandatekind;
using meta_accmotiveapplied;
using meta_estimatekind;
using meta_expense;
using meta_income;
using meta_invoicekind;
using meta_epexp;
using meta_tassonomia_pagopa;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace invoicedetail_singleAi {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivakindTable ivakind 		=> (ivakindTable)Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicedetailTable invoicedetail 		=> (invoicedetailTable)Tables["invoicedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting1 		=> (sortingTable)Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting2 		=> (sortingTable)Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting3 		=> (sortingTable)Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandatekindTable mandatekind 		=> (mandatekindTable)Tables["mandatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied 		=> (accmotiveappliedTable)Tables["accmotiveapplied"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatekindTable estimatekind 		=> (estimatekindTable)Tables["estimatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenseTable expense_iva 		=> (expenseTable)Tables["expense_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenseTable expense_taxable 		=> (expenseTable)Tables["expense_taxable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomeTable income_iva 		=> (incomeTable)Tables["income_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomeTable income_taxable 		=> (incomeTable)Tables["income_taxable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable intrastatmeasure 		=> (MetaTable)Tables["intrastatmeasure"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable intrastatcode 		=> (MetaTable)Tables["intrastatcode"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable intrastatservice 		=> (MetaTable)Tables["intrastatservice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable intrastatsupplymethod 		=> (MetaTable)Tables["intrastatsupplymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listview 		=> (MetaTable)Tables["listview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable package 		=> (MetaTable)Tables["package"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable unit 		=> (MetaTable)Tables["unit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listclass 		=> (MetaTable)Tables["listclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb_iva 		=> (upbTable)Tables["upb_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fetransfer 		=> (MetaTable)Tables["fetransfer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pccdebitmotive 		=> (MetaTable)Tables["pccdebitmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pccdebitstatus 		=> (MetaTable)Tables["pccdebitstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costpartition 		=> (MetaTable)Tables["costpartition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public epexpTable epexp 		=> (epexpTable)Tables["epexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedetaildeferred 		=> (MetaTable)Tables["invoicedetaildeferred"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epacc 		=> (MetaTable)Tables["epacc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotive_income 		=> (MetaTable)Tables["finmotive_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting_siope 		=> (sortingTable)Tables["sorting_siope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public epexpTable epexp_pre 		=> (epexpTable)Tables["epexp_pre"];

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
	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new ivakindTable();
	tivakind.addBaseColumns("idivakind","description","rate","unabatabilitypercentage","cu","ct","lu","lt","active","idivataxablekind","flag","idfenature");
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("idinvkind","yinv","ninv","rownum","idivakind","detaildescription","annotations","taxable","tax","unabatable","cu","ct","lu","lt","discount","idmankind","yman","nman","manrownum","number","idupb","idsor1","idsor2","idsor3","competencystart","competencystop","paymentcompetency","idaccmotive","idestimkind","yestim","nestim","estimrownum","idexp_iva","idexp_taxable","idinc_iva","idinc_taxable","idgroup","yinv_main","ninv_main","va3type","idintrastatcode","idintrastatmeasure","weight","intrastatoperationkind","idintrastatservice","idintrastatsupplymethod","idlist","idunit","idpackage","unitsforpackage","npackage","flag","exception12","intra12operationkind","move12","idupb_iva","idinvkind_main","leasing","usedmodesospesometro","resetresidualmandate","idfetransfer","fereferencerule","cupcode","cigcode","idcostpartition","idpccdebitmotive","idpccdebitstatus","expensekind","rounding","idepexp","idepacc","flagbit","idfinmotive","iduniqueformcode","ycon","ncon","codicetipo","codicevalore","idsor_siope","idepexp_pre","idtassonomia","idfinmotive_iva","rownum_main");
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("idinvkind", "yinv", "ninv", "rownum");

	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new sortingTable();
	tsorting1.TableName = "sorting1";
	tsorting1.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	tsorting1.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting1);
	tsorting1.defineKey("idsor");

	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new sortingTable();
	tsorting2.TableName = "sorting2";
	tsorting2.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	tsorting2.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting2);
	tsorting2.defineKey("idsor");

	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new sortingTable();
	tsorting3.TableName = "sorting3";
	tsorting3.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	tsorting3.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting3);
	tsorting3.defineKey("idsor");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb","title","paridupb","idunderwriter","idman","requested","granted","previousappropriation","expiration","txt","rtf","cu","ct","lu","lt","assured","printingorder","active");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new mandatekindTable();
	tmandatekind.addBaseColumns("idmankind","description","idupb","rtf","txt","cu","ct","lu","lt","active");
	Tables.Add(tmandatekind);
	tmandatekind.defineKey("idmankind");

	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	var taccmotiveapplied= new accmotiveappliedTable();
	taccmotiveapplied.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","expensekind");
	taccmotiveapplied.defineColumn("!priority", typeof(string));
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.defineKey("idaccmotive");

	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new estimatekindTable();
	testimatekind.addBaseColumns("idestimkind","active","ct","cu","description","idupb","lt","lu","rtf","txt","email","faxnumber","office","phonenumber");
	Tables.Add(testimatekind);
	testimatekind.defineKey("idestimkind");

	//////////////////// EXPENSE_IVA /////////////////////////////////
	var texpense_iva= new expenseTable();
	texpense_iva.TableName = "expense_iva";
	texpense_iva.addBaseColumns("adate","ct","cu","description","doc","docdate","expiration","idreg","lt","lu","nmov","txt","ymov","idclawback","idman","nphase","idexp","parentidexp","idpayment","idformerexpense","autokind","autocode");
	texpense_iva.ExtendedProperties["TableForReading"]="expense";
	Tables.Add(texpense_iva);
	texpense_iva.defineKey("idexp");

	//////////////////// EXPENSE_TAXABLE /////////////////////////////////
	var texpense_taxable= new expenseTable();
	texpense_taxable.TableName = "expense_taxable";
	texpense_taxable.addBaseColumns("adate","ct","cu","description","doc","docdate","expiration","idreg","lt","lu","nmov","txt","ymov","idclawback","idman","nphase","idexp","parentidexp","idpayment","idformerexpense","autokind","autocode");
	texpense_taxable.ExtendedProperties["TableForReading"]="expense";
	Tables.Add(texpense_taxable);
	texpense_taxable.defineKey("idexp");

	//////////////////// INCOME_IVA /////////////////////////////////
	var tincome_iva= new incomeTable();
	tincome_iva.TableName = "income_iva";
	tincome_iva.addBaseColumns("adate","ct","cu","description","doc","docdate","expiration","idreg","lt","lu","nmov","ymov","idman","nphase","idpayment","idinc","parentidinc","autokind","autocode");
	tincome_iva.ExtendedProperties["TableForReading"]="income";
	Tables.Add(tincome_iva);
	tincome_iva.defineKey("idinc");

	//////////////////// INCOME_TAXABLE /////////////////////////////////
	var tincome_taxable= new incomeTable();
	tincome_taxable.TableName = "income_taxable";
	tincome_taxable.addBaseColumns("adate","ct","cu","description","doc","docdate","expiration","idreg","lt","lu","nmov","ymov","idman","nphase","idpayment","idinc","parentidinc","autokind","autocode");
	tincome_taxable.ExtendedProperties["TableForReading"]="income";
	Tables.Add(tincome_taxable);
	tincome_taxable.defineKey("idinc");

	//////////////////// INTRASTATMEASURE /////////////////////////////////
	var tintrastatmeasure= new MetaTable("intrastatmeasure");
	tintrastatmeasure.defineColumn("idintrastatmeasure", typeof(int),false);
	tintrastatmeasure.defineColumn("code", typeof(string),false);
	tintrastatmeasure.defineColumn("description", typeof(string),false);
	tintrastatmeasure.defineColumn("lt", typeof(DateTime));
	tintrastatmeasure.defineColumn("lu", typeof(string));
	Tables.Add(tintrastatmeasure);
	tintrastatmeasure.defineKey("idintrastatmeasure");

	//////////////////// INTRASTATCODE /////////////////////////////////
	var tintrastatcode= new MetaTable("intrastatcode");
	tintrastatcode.defineColumn("ayear", typeof(short),false);
	tintrastatcode.defineColumn("code", typeof(string),false);
	tintrastatcode.defineColumn("description", typeof(string),false);
	tintrastatcode.defineColumn("idintrastatmeasure", typeof(int));
	tintrastatcode.defineColumn("lt", typeof(DateTime));
	tintrastatcode.defineColumn("lu", typeof(string));
	tintrastatcode.defineColumn("idintrastatcode", typeof(int),false);
	Tables.Add(tintrastatcode);
	tintrastatcode.defineKey("idintrastatcode");

	//////////////////// INTRASTATSERVICE /////////////////////////////////
	var tintrastatservice= new MetaTable("intrastatservice");
	tintrastatservice.defineColumn("description", typeof(string),false);
	tintrastatservice.defineColumn("code", typeof(string),false);
	tintrastatservice.defineColumn("cu", typeof(string),false);
	tintrastatservice.defineColumn("ct", typeof(DateTime),false);
	tintrastatservice.defineColumn("lu", typeof(string),false);
	tintrastatservice.defineColumn("lt", typeof(DateTime),false);
	tintrastatservice.defineColumn("ayear", typeof(short),false);
	tintrastatservice.defineColumn("idintrastatservice", typeof(int),false,true);
	Tables.Add(tintrastatservice);
	tintrastatservice.defineKey("idintrastatservice");

	//////////////////// INTRASTATSUPPLYMETHOD /////////////////////////////////
	var tintrastatsupplymethod= new MetaTable("intrastatsupplymethod");
	tintrastatsupplymethod.defineColumn("idintrastatsupplymethod", typeof(int),false);
	tintrastatsupplymethod.defineColumn("code", typeof(string),false);
	tintrastatsupplymethod.defineColumn("description", typeof(string),false);
	tintrastatsupplymethod.defineColumn("cu", typeof(string),false);
	tintrastatsupplymethod.defineColumn("ct", typeof(DateTime),false);
	tintrastatsupplymethod.defineColumn("lu", typeof(string),false);
	tintrastatsupplymethod.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tintrastatsupplymethod);
	tintrastatsupplymethod.defineKey("idintrastatsupplymethod");

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
	tlistview.defineColumn("price", typeof(decimal));
	tlistview.defineColumn("idtassonomia", typeof(int));
	Tables.Add(tlistview);
	tlistview.defineKey("idlist");

	//////////////////// PACKAGE /////////////////////////////////
	var tpackage= new MetaTable("package");
	tpackage.defineColumn("idpackage", typeof(int),false);
	tpackage.defineColumn("description", typeof(string),false);
	tpackage.defineColumn("cu", typeof(string),false);
	tpackage.defineColumn("ct", typeof(DateTime),false);
	tpackage.defineColumn("lu", typeof(string),false);
	tpackage.defineColumn("lt", typeof(DateTime),false);
	tpackage.defineColumn("active", typeof(string),false);
	Tables.Add(tpackage);
	tpackage.defineKey("idpackage");

	//////////////////// UNIT /////////////////////////////////
	var tunit= new MetaTable("unit");
	tunit.defineColumn("idunit", typeof(int),false);
	tunit.defineColumn("description", typeof(string),false);
	tunit.defineColumn("cu", typeof(string),false);
	tunit.defineColumn("ct", typeof(DateTime),false);
	tunit.defineColumn("lu", typeof(string),false);
	tunit.defineColumn("lt", typeof(DateTime),false);
	tunit.defineColumn("active", typeof(string),false);
	Tables.Add(tunit);
	tunit.defineKey("idunit");

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
	Tables.Add(tlistclass);
	tlistclass.defineKey("idlistclass");

	//////////////////// UPB_IVA /////////////////////////////////
	var tupb_iva= new upbTable();
	tupb_iva.TableName = "upb_iva";
	tupb_iva.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idman","idunderwriter","cupcode");
	tupb_iva.ExtendedProperties["TableForReading"]="upb";
	Tables.Add(tupb_iva);
	tupb_iva.defineKey("idupb");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("ct","cu","description","lt","lu","codeinvkind","idinvkind","flag","flag_autodocnumbering","formatstring","active","idinvkind_auto");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// FETRANSFER /////////////////////////////////
	var tfetransfer= new MetaTable("fetransfer");
	tfetransfer.defineColumn("idfetransfer", typeof(string),false);
	tfetransfer.defineColumn("description", typeof(string),false);
	tfetransfer.defineColumn("cu", typeof(string),false);
	tfetransfer.defineColumn("ct", typeof(DateTime),false);
	tfetransfer.defineColumn("lu", typeof(string),false);
	tfetransfer.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tfetransfer);

	//////////////////// PCCDEBITMOTIVE /////////////////////////////////
	var tpccdebitmotive= new MetaTable("pccdebitmotive");
	tpccdebitmotive.defineColumn("idpccdebitmotive", typeof(string),false);
	tpccdebitmotive.defineColumn("description", typeof(string));
	tpccdebitmotive.defineColumn("listingorder", typeof(int));
	tpccdebitmotive.defineColumn("lu", typeof(string),false);
	tpccdebitmotive.defineColumn("lt", typeof(DateTime),false);
	tpccdebitmotive.defineColumn("flagstatus", typeof(int));
	Tables.Add(tpccdebitmotive);
	tpccdebitmotive.defineKey("idpccdebitmotive");

	//////////////////// PCCDEBITSTATUS /////////////////////////////////
	var tpccdebitstatus= new MetaTable("pccdebitstatus");
	tpccdebitstatus.defineColumn("idpccdebitstatus", typeof(string),false);
	tpccdebitstatus.defineColumn("description", typeof(string));
	tpccdebitstatus.defineColumn("lt", typeof(DateTime),false);
	tpccdebitstatus.defineColumn("lu", typeof(string),false);
	tpccdebitstatus.defineColumn("listingorder", typeof(int));
	tpccdebitstatus.defineColumn("flag", typeof(int));
	tpccdebitstatus.defineColumn("active", typeof(string));
	Tables.Add(tpccdebitstatus);
	tpccdebitstatus.defineKey("idpccdebitstatus");

	//////////////////// COSTPARTITION /////////////////////////////////
	var tcostpartition= new MetaTable("costpartition");
	tcostpartition.defineColumn("idcostpartition", typeof(int),false);
	tcostpartition.defineColumn("title", typeof(string));
	tcostpartition.defineColumn("kind", typeof(string));
	tcostpartition.defineColumn("lt", typeof(DateTime));
	tcostpartition.defineColumn("lu", typeof(string));
	tcostpartition.defineColumn("ct", typeof(DateTime));
	tcostpartition.defineColumn("cu", typeof(string));
	tcostpartition.defineColumn("costpartitioncode", typeof(string));
	tcostpartition.defineColumn("active", typeof(string));
	tcostpartition.defineColumn("description", typeof(string));
	Tables.Add(tcostpartition);
	tcostpartition.defineKey("idcostpartition");

	//////////////////// EPEXP /////////////////////////////////
	var tepexp= new epexpTable();
	tepexp.addBaseColumns("idepexp","adate","ct","cu","description","doc","docdate","idman","idreg","idrelated","lt","lu","nepexp","nphase","paridepexp","rtf","start","stop","txt","yepexp");
	Tables.Add(tepexp);
	tepexp.defineKey("idepexp");

	//////////////////// INVOICEDETAILDEFERRED /////////////////////////////////
	var tinvoicedetaildeferred= new MetaTable("invoicedetaildeferred");
	tinvoicedetaildeferred.defineColumn("idinvkind", typeof(int),false);
	tinvoicedetaildeferred.defineColumn("yinv", typeof(short),false);
	tinvoicedetaildeferred.defineColumn("ninv", typeof(int),false);
	tinvoicedetaildeferred.defineColumn("rownum", typeof(int),false);
	tinvoicedetaildeferred.defineColumn("yivapay", typeof(int),false);
	tinvoicedetaildeferred.defineColumn("nivapay", typeof(int),false);
	tinvoicedetaildeferred.defineColumn("ivatotalpayed", typeof(decimal));
	tinvoicedetaildeferred.defineColumn("taxable", typeof(decimal));
	tinvoicedetaildeferred.defineColumn("cu", typeof(string));
	tinvoicedetaildeferred.defineColumn("ct", typeof(DateTime));
	tinvoicedetaildeferred.defineColumn("lu", typeof(string));
	tinvoicedetaildeferred.defineColumn("lt", typeof(string));
	tinvoicedetaildeferred.defineColumn("idivaregisterkind", typeof(int),false);
	Tables.Add(tinvoicedetaildeferred);
	tinvoicedetaildeferred.defineKey("idinvkind", "yinv", "ninv", "rownum", "yivapay", "nivapay", "idivaregisterkind");

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

	//////////////////// EPEXP_PRE /////////////////////////////////
	var tepexp_pre= new epexpTable();
	tepexp_pre.TableName = "epexp_pre";
	tepexp_pre.addBaseColumns("idepexp","adate","ct","cu","description","doc","docdate","idman","idreg","idrelated","lt","lu","nepexp","nphase","paridepexp","rtf","start","stop","txt","yepexp");
	tepexp_pre.ExtendedProperties["TableForReading"]="epexp";
	Tables.Add(tepexp_pre);
	tepexp_pre.defineKey("idepexp");

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
	this.defineRelation("FK_invoicekind_invoicedetaildeferred","invoicekind","invoicedetaildeferred","idinvkind");
	this.defineRelation("FK_invoicedetail_invoicedetaildeferred","invoicedetail","invoicedetaildeferred","idinvkind","yinv","ninv","rownum");
	this.defineRelation("FK_epacc_invoicedetail","epacc","invoicedetail","idepacc");
	this.defineRelation("FK_epexp_invoicedetail","epexp","invoicedetail","idepexp");
	this.defineRelation("FK_pccdebitstatus_invoicedetail","pccdebitstatus","invoicedetail","idpccdebitstatus");
	this.defineRelation("FK_pccdebitmotive_invoicedetail","pccdebitmotive","invoicedetail","idpccdebitmotive");
	this.defineRelation("FK_fetransfer_invoicedetail","fetransfer","invoicedetail","idfetransfer");
	var cPar = new []{upb_iva.Columns["idupb"]};
	var cChild = new []{invoicedetail.Columns["idupb_iva"]};
	Relations.Add(new DataRelation("FK_upb_iva_invoicedetail",cPar,cChild,false));

	this.defineRelation("FK_package_invoicedetail","package","invoicedetail","idpackage");
	this.defineRelation("FK_unit_invoicedetail","unit","invoicedetail","idunit");
	this.defineRelation("FK_listview_invoicedetail","listview","invoicedetail","idlist");
	this.defineRelation("FK_intrastatsupplymethod_invoicedetail","intrastatsupplymethod","invoicedetail","idintrastatsupplymethod");
	this.defineRelation("FK_intrastatservice_invoicedetail","intrastatservice","invoicedetail","idintrastatservice");
	this.defineRelation("ivakindinvoicedetail","ivakind","invoicedetail","idivakind");
	this.defineRelation("upbinvoicedetail","upb","invoicedetail","idupb");
	this.defineRelation("mandatekindinvoicedetail","mandatekind","invoicedetail","idmankind");
	this.defineRelation("estimatekindinvoicedetail","estimatekind","invoicedetail","idestimkind");
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

	this.defineRelation("accmotiveapplied_invoicedetail","accmotiveapplied","invoicedetail","idaccmotive");
	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{invoicedetail.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1invoicedetail",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{invoicedetail.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2invoicedetail",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{invoicedetail.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3invoicedetail",cPar,cChild,false));

	this.defineRelation("intrastatmeasure_invoicedetail","intrastatmeasure","invoicedetail","idintrastatmeasure");
	this.defineRelation("intrastatcode_invoicedetail","intrastatcode","invoicedetail","idintrastatcode");
	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoicedetail.Columns["idinvkind_main"]};
	Relations.Add(new DataRelation("invoicekind_invoicedetail",cPar,cChild,false));

	this.defineRelation("costpartition_invoicedetail","costpartition","invoicedetail","idcostpartition");
	this.defineRelation("finmotive_income_invoicedetail","finmotive_income","invoicedetail","idfinmotive");
	cPar = new []{sorting_siope.Columns["idsor"]};
	cChild = new []{invoicedetail.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siope_invoicedetail",cPar,cChild,false));

	cPar = new []{epexp_pre.Columns["idepexp"]};
	cChild = new []{invoicedetail.Columns["idepexp_pre"]};
	Relations.Add(new DataRelation("epexp_pre_invoicedetail",cPar,cChild,false));

	this.defineRelation("tassonomia_pagopa_invoicedetail","tassonomia_pagopa","invoicedetail","idtassonomia");
	cPar = new []{finmotive_iva_income.Columns["idfinmotive"]};
	cChild = new []{invoicedetail.Columns["idfinmotive_iva"]};
	Relations.Add(new DataRelation("finmotive_iva_income_invoicedetail",cPar,cChild,false));

	#endregion

}
}
}
