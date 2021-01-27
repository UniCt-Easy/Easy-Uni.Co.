
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
using meta_mandatedetail;
using meta_expense;
using meta_upb;
using meta_sorting;
using meta_invoicedetail;
using meta_invoicekind;
using meta_accmotiveapplied;
using meta_ivakind;
using meta_mandatekind;
using meta_epexp;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace mandatedetail_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Dettaglio contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandatedetailTable mandatedetail 		=> (mandatedetailTable)Tables["mandatedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytreeview 		=> (MetaTable)Tables["inventorytreeview"];

	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenseTable expense_iva 		=> (expenseTable)Tables["expense_iva"];

	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenseTable expense_imponibile 		=> (expenseTable)Tables["expense_imponibile"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting1 		=> (sortingTable)Tables["sorting1"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting2 		=> (sortingTable)Tables["sorting2"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting3 		=> (sortingTable)Tables["sorting3"];

	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicedetailTable invoicedetail 		=> (invoicedetailTable)Tables["invoicedetail"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied 		=> (accmotiveappliedTable)Tables["accmotiveapplied"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivakindTable ivakind 		=> (ivakindTable)Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview 		=> (MetaTable)Tables["registrymainview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveappliedannulment 		=> (MetaTable)Tables["accmotiveappliedannulment"];

	///<summary>
	///Classificazione Merceologica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listclass 		=> (MetaTable)Tables["listclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listview 		=> (MetaTable)Tables["listview"];

	///<summary>
	///Unità di Misura per il carico/scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable unit 		=> (MetaTable)Tables["unit"];

	///<summary>
	/// Unità di Misura per l'acquisto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable package 		=> (MetaTable)Tables["package"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stockview 		=> (MetaTable)Tables["stockview"];

	///<summary>
	///Tipo contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandatekindTable mandatekind 		=> (mandatekindTable)Tables["mandatekind"];

	///<summary>
	///trattasi di valori codificati dalla PCC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pccdebitmotive 		=> (MetaTable)Tables["pccdebitmotive"];

	///<summary>
	///trattasi di valori codificati dalla PCC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pccdebitstatus 		=> (MetaTable)Tables["pccdebitstatus"];

	///<summary>
	///Ripartizione dei costi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costpartition 		=> (MetaTable)Tables["costpartition"];

	///<summary>
	///Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public epexpTable epexp 		=> (epexpTable)Tables["epexp"];

	///<summary>
	///Accertamento di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epacc 		=> (MetaTable)Tables["epacc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable locationview 		=> (MetaTable)Tables["locationview"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb_iva 		=> (upbTable)Tables["upb_iva"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting_siope 		=> (sortingTable)Tables["sorting_siope"];

	///<summary>
	///Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public epexpTable pre_epexp 		=> (epexpTable)Tables["pre_epexp"];

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
	//////////////////// MANDATEDETAIL /////////////////////////////////
	var tmandatedetail= new mandatedetailTable();
	tmandatedetail.addBaseColumns("yman","nman","rownum","detaildescription","annotations","number","taxable","taxrate","discount","start","stop","cu","ct","lu","lt","idinv","assetkind","idexp_iva","idexp_taxable","idupb","toinvoice","idsor1","idsor2","idsor3","idmankind","competencystart","competencystop","tax","idaccmotive","idivakind","unabatable","flagmixed","idreg","idgroup","idaccmotiveannulment","flagactivity","va3type","ivanotes","idlist","idunit","idpackage","npackage","unitsforpackage","cupcode","flagto_unload","cigcode","epkind","rownum_origin","contractamount","idavcp","idavcp_choice","avcp_startcontract","avcp_stopcontract","avcp_description","idcostpartition","idpccdebitstatus","idpccdebitmotive","expensekind","idepexp","idepacc","idlocation","idupb_iva","idsor_siope","idepexp_pre");
	Tables.Add(tmandatedetail);
	tmandatedetail.defineKey("yman", "nman", "rownum", "idmankind");

	//////////////////// INVENTORYTREEVIEW /////////////////////////////////
	var tinventorytreeview= new MetaTable("inventorytreeview");
	tinventorytreeview.defineColumn("idinv", typeof(int),false);
	tinventorytreeview.defineColumn("codeinv", typeof(string),false);
	tinventorytreeview.defineColumn("nlevel", typeof(byte),false);
	tinventorytreeview.defineColumn("leveldescr", typeof(string),false);
	tinventorytreeview.defineColumn("paridinv", typeof(int));
	tinventorytreeview.defineColumn("description", typeof(string),false);
	tinventorytreeview.defineColumn("cu", typeof(string),false);
	tinventorytreeview.defineColumn("ct", typeof(DateTime),false);
	tinventorytreeview.defineColumn("lu", typeof(string),false);
	tinventorytreeview.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tinventorytreeview);
	tinventorytreeview.defineKey("idinv");

	//////////////////// EXPENSE_IVA /////////////////////////////////
	var texpense_iva= new expenseTable();
	texpense_iva.TableName = "expense_iva";
	texpense_iva.addBaseColumns("idexp","nphase","ymov","nmov","parentidexp","idreg","idman","doc","docdate","description","autokind","idpayment","expiration","adate","txt","cu","ct","lu","lt","idformerexpense","autocode");
	texpense_iva.ExtendedProperties["TableForReading"]="expense";
	Tables.Add(texpense_iva);
	texpense_iva.defineKey("idexp");

	//////////////////// EXPENSE_IMPONIBILE /////////////////////////////////
	var texpense_imponibile= new expenseTable();
	texpense_imponibile.TableName = "expense_imponibile";
	texpense_imponibile.addBaseColumns("idexp","nphase","ymov","nmov","parentidexp","idreg","idman","doc","docdate","description","autokind","idpayment","expiration","adate","txt","cu","ct","lu","lt","idformerexpense","autocode");
	texpense_imponibile.ExtendedProperties["TableForReading"]="expense";
	Tables.Add(texpense_imponibile);
	texpense_imponibile.defineKey("idexp");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb","title","paridupb","idunderwriter","idman","requested","granted","previousappropriation","expiration","txt","rtf","cu","ct","lu","lt","assured","printingorder","active","cupcode","idsor01","idsor02","idsor03","idsor04","idsor05","flagactivity","flagkind","newcodeupb");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

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

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("idinvkind","yinv","ninv","rownum","idivakind","detaildescription","annotations","taxable","tax","unabatable","cu","ct","lu","lt","discount","idmankind","yman","nman","manrownum","number","idupb","idsor1","idsor2","idsor3","competencystart","competencystop");
	tinvoicedetail.defineColumn("!tipodocumento", typeof(string));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("idinvkind", "yinv", "ninv", "rownum");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("idinvkind","flag","description","cu","ct","lu","lt","active");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	var taccmotiveapplied= new accmotiveappliedTable();
	taccmotiveapplied.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagdep","flagamm","expensekind");
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.defineKey("idaccmotive");

	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new ivakindTable();
	tivakind.addBaseColumns("idivakind","ct","cu","description","lt","lu","rate","unabatabilitypercentage","active","flag","codeivakind");
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

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
	taccmotiveappliedannulment.defineColumn("idepoperation", typeof(string),false);
	taccmotiveappliedannulment.defineColumn("epoperation", typeof(string));
	taccmotiveappliedannulment.defineColumn("in_use", typeof(string));
	taccmotiveappliedannulment.defineColumn("flagdep", typeof(string));
	taccmotiveappliedannulment.defineColumn("flagamm", typeof(string));
	Tables.Add(taccmotiveappliedannulment);
	taccmotiveappliedannulment.defineKey("idaccmotive");

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
	tlistclass.defineColumn("flagvisiblekind", typeof(byte));
	Tables.Add(tlistclass);
	tlistclass.defineKey("idlistclass");

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
	tlistview.defineColumn("idunit", typeof(int));
	tlistview.defineColumn("unitsforpackage", typeof(int));
	tlistview.defineColumn("has_expiry", typeof(string),false);
	tlistview.defineColumn("idlistclass", typeof(string),false);
	tlistview.defineColumn("codelistclass", typeof(string),false);
	tlistview.defineColumn("listclass", typeof(string),false);
	tlistview.defineColumn("package", typeof(string));
	tlistview.defineColumn("unit", typeof(string));
	tlistview.defineColumn("price", typeof(decimal));
	Tables.Add(tlistview);
	tlistview.defineKey("idlist");

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

	//////////////////// PACKAGE /////////////////////////////////
	var tpackage= new MetaTable("package");
	tpackage.defineColumn("idpackage", typeof(int),false);
	tpackage.defineColumn("description", typeof(string));
	tpackage.defineColumn("cu", typeof(string),false);
	tpackage.defineColumn("ct", typeof(DateTime),false);
	tpackage.defineColumn("lu", typeof(string),false);
	tpackage.defineColumn("lt", typeof(DateTime),false);
	tpackage.defineColumn("active", typeof(string),false);
	Tables.Add(tpackage);
	tpackage.defineKey("idpackage");

	//////////////////// STOCKVIEW /////////////////////////////////
	var tstockview= new MetaTable("stockview");
	tstockview.defineColumn("idstock", typeof(int),false);
	tstockview.defineColumn("idstore", typeof(int),false);
	tstockview.defineColumn("store", typeof(string),false);
	tstockview.defineColumn("idlist", typeof(int),false);
	tstockview.defineColumn("number", typeof(decimal),false);
	tstockview.defineColumn("residual", typeof(decimal),true,true);
	tstockview.defineColumn("amount", typeof(decimal),false);
	tstockview.defineColumn("expiry", typeof(DateTime));
	tstockview.defineColumn("idmankind", typeof(string));
	tstockview.defineColumn("mandatekind", typeof(string));
	tstockview.defineColumn("yman", typeof(short));
	tstockview.defineColumn("nman", typeof(int));
	tstockview.defineColumn("man_idgroup", typeof(int));
	tstockview.defineColumn("idinvkind", typeof(int));
	tstockview.defineColumn("invoicekind", typeof(string));
	tstockview.defineColumn("yinv", typeof(short));
	tstockview.defineColumn("ninv", typeof(int));
	tstockview.defineColumn("inv_idgroup", typeof(int));
	tstockview.defineColumn("idddt_in", typeof(int));
	tstockview.defineColumn("idstoreload_motive", typeof(int));
	tstockview.defineColumn("storeload_motive", typeof(string));
	tstockview.defineColumn("list", typeof(string),false);
	tstockview.defineColumn("intcode", typeof(string),false);
	tstockview.defineColumn("unit", typeof(string));
	tstockview.defineColumn("yddt_in", typeof(short));
	tstockview.defineColumn("nddt_in", typeof(string));
	tstockview.defineColumn("codelistclass", typeof(string));
	tstockview.defineColumn("listclass", typeof(string));
	tstockview.defineColumn("authrequired", typeof(string));
	tstockview.defineColumn("flagto_unload", typeof(string));
	tstockview.defineColumn("adate", typeof(DateTime));
	tstockview.defineColumn("idstocklocation", typeof(int));
	tstockview.defineColumn("stocklocationcode", typeof(string));
	tstockview.defineColumn("stocklocation", typeof(string));
	Tables.Add(tstockview);
	tstockview.defineKey("idstock");

	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new mandatekindTable();
	tmandatekind.addBaseColumns("idmankind","active","ct","cu","description","idupb","lt","lu","rtf","txt","email","faxnumber","office","phonenumber","linktoasset","linktoinvoice","multireg","deltaamount","deltapercentage","flag_autodocnumbering","flagactivity","name_c","name_l","name_r","title_c","title_l","title_r","notes1","notes2","notes3","warnmail","isrequest","idsor01","idsor02","idsor03","idsor04","idsor05","assetkind","dangermail","address","header","flag","touniqueregister","idivakind_forced");
	Tables.Add(tmandatekind);
	tmandatekind.defineKey("idmankind");

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

	//////////////////// LOCATIONVIEW /////////////////////////////////
	var tlocationview= new MetaTable("locationview");
	tlocationview.defineColumn("idlocation", typeof(int),false);
	tlocationview.defineColumn("locationcode", typeof(string),false);
	tlocationview.defineColumn("active", typeof(string),false);
	tlocationview.defineColumn("nlevel", typeof(byte),false);
	tlocationview.defineColumn("leveldescr", typeof(string),false);
	tlocationview.defineColumn("paridlocation", typeof(int));
	tlocationview.defineColumn("description", typeof(string),false);
	tlocationview.defineColumn("idman", typeof(int));
	tlocationview.defineColumn("manager", typeof(string));
	tlocationview.defineColumn("cu", typeof(string),false);
	tlocationview.defineColumn("ct", typeof(DateTime),false);
	tlocationview.defineColumn("lu", typeof(string),false);
	tlocationview.defineColumn("lt", typeof(DateTime),false);
	tlocationview.defineColumn("idsor01", typeof(int));
	tlocationview.defineColumn("idsor02", typeof(int));
	tlocationview.defineColumn("idsor03", typeof(int));
	tlocationview.defineColumn("idsor04", typeof(int));
	tlocationview.defineColumn("idsor05", typeof(int));
	Tables.Add(tlocationview);
	tlocationview.defineKey("idlocation");

	//////////////////// UPB_IVA /////////////////////////////////
	var tupb_iva= new upbTable();
	tupb_iva.TableName = "upb_iva";
	tupb_iva.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idman","idunderwriter","cupcode","idsor01","idsor02","idsor03","idsor04","idsor05","flagactivity","flagkind","newcodeupb","idtreasurer","start","stop","cigcode","idepupbkind","flag");
	tupb_iva.ExtendedProperties["TableForReading"]="upb";
	Tables.Add(tupb_iva);
	tupb_iva.defineKey("idupb");

	//////////////////// SORTING_SIOPE /////////////////////////////////
	var tsorting_siope= new sortingTable();
	tsorting_siope.TableName = "sorting_siope";
	tsorting_siope.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email");
	tsorting_siope.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting_siope);
	tsorting_siope.defineKey("idsor");

	//////////////////// PRE_EPEXP /////////////////////////////////
	var tpre_epexp= new epexpTable();
	tpre_epexp.TableName = "pre_epexp";
	tpre_epexp.addBaseColumns("idepexp","adate","ct","cu","description","doc","docdate","idman","idreg","idrelated","lt","lu","nepexp","nphase","paridepexp","rtf","start","stop","txt","yepexp");
	tpre_epexp.ExtendedProperties["TableForReading"]="epexp";
	Tables.Add(tpre_epexp);
	tpre_epexp.defineKey("idepexp");

	#endregion


	#region DataRelation creation
	var cPar = new []{sorting_siope.Columns["idsor"]};
	var cChild = new []{mandatedetail.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("FK_sorting_siope_mandatedetail",cPar,cChild,false));

	cPar = new []{upb_iva.Columns["idupb"]};
	cChild = new []{mandatedetail.Columns["idupb_iva"]};
	Relations.Add(new DataRelation("FK_upb_iva_mandatedetail",cPar,cChild,false));

	cPar = new []{mandatedetail.Columns["yman"], mandatedetail.Columns["nman"], mandatedetail.Columns["idgroup"], mandatedetail.Columns["idmankind"]};
	cChild = new []{stockview.Columns["yman"], stockview.Columns["nman"], stockview.Columns["man_idgroup"], stockview.Columns["idmankind"]};
	Relations.Add(new DataRelation("mandatedetail_stockview",cPar,cChild,false));

	this.defineRelation("invoicekindinvoicedetail","invoicekind","invoicedetail","idinvkind");
	cPar = new []{mandatedetail.Columns["yman"], mandatedetail.Columns["nman"], mandatedetail.Columns["rownum"], mandatedetail.Columns["idmankind"]};
	cChild = new []{invoicedetail.Columns["yman"], invoicedetail.Columns["nman"], invoicedetail.Columns["manrownum"], invoicedetail.Columns["idmankind"]};
	Relations.Add(new DataRelation("mandatedetailinvoicedetail",cPar,cChild,false));

	this.defineRelation("FK_epexp_mandatedetail","epexp","mandatedetail","idepexp");
	this.defineRelation("FK_pccdebitmotive_mandatedetail","pccdebitmotive","mandatedetail","idpccdebitmotive");
	this.defineRelation("FK_pccdebitstatus_mandatedetail","pccdebitstatus","mandatedetail","idpccdebitstatus");
	this.defineRelation("FK_unit_mandatedetail","unit","mandatedetail","idunit");
	this.defineRelation("FK_package_mandatedetail","package","mandatedetail","idpackage");
	this.defineRelation("FK_listview_mandatedetail","listview","mandatedetail","idlist");
	this.defineRelation("registrymainviewmandatedetail","registrymainview","mandatedetail","idreg");
	this.defineRelation("ivakindmandatedetail","ivakind","mandatedetail","idivakind");
	this.defineRelation("accmotiveappliedmandatedetail","accmotiveapplied","mandatedetail","idaccmotive");
	cPar = new []{expense_imponibile.Columns["idexp"]};
	cChild = new []{mandatedetail.Columns["idexp_taxable"]};
	Relations.Add(new DataRelation("expense_imponibilemandatedetail",cPar,cChild,false));

	cPar = new []{expense_iva.Columns["idexp"]};
	cChild = new []{mandatedetail.Columns["idexp_iva"]};
	Relations.Add(new DataRelation("expense_ivamandatedetail",cPar,cChild,false));

	this.defineRelation("inventorytreeviewmandatedetail","inventorytreeview","mandatedetail","idinv");
	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{mandatedetail.Columns["idsor1"]};
	Relations.Add(new DataRelation("sortingmandatedetail",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{mandatedetail.Columns["idsor2"]};
	Relations.Add(new DataRelation("sortingmandatedetail1",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{mandatedetail.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3mandatedetail",cPar,cChild,false));

	cPar = new []{accmotiveappliedannulment.Columns["idaccmotive"]};
	cChild = new []{mandatedetail.Columns["idaccmotiveannulment"]};
	Relations.Add(new DataRelation("accmotiveappliedannulment_mandatedetail",cPar,cChild,false));

	this.defineRelation("mandatekind_mandatedetail","mandatekind","mandatedetail","idmankind");
	this.defineRelation("costpartition_mandatedetail","costpartition","mandatedetail","idcostpartition");
	cPar = new []{mandatekind.Columns["idivakind_forced"]};
	cChild = new []{mandatedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("mandatekind_mandatedetail1",cPar,cChild,false));

	this.defineRelation("epacc_mandatedetail","epacc","mandatedetail","idepacc");
	this.defineRelation("upbmandatedetail","upb","mandatedetail","idupb");
	this.defineRelation("locationview_mandatedetail","locationview","mandatedetail","idlocation");
	cPar = new []{pre_epexp.Columns["idepexp"]};
	cChild = new []{mandatedetail.Columns["idepexp_pre"]};
	Relations.Add(new DataRelation("pre_epexp_mandatedetail",cPar,cChild,false));

	#endregion

}
}
}
