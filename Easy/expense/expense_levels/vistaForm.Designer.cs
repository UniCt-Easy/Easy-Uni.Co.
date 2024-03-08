
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
using meta_expense;
using meta_registry;
using meta_expenseyear;
using meta_manager;
using meta_expensesorted;
using meta_sorting;
using meta_sortingkind;
using meta_expensevar;
using meta_mandate;
using meta_itineration;
using meta_invoice;
using meta_invoicekind;
using meta_payroll;
using meta_casualcontract;
using meta_profservice;
using meta_service;
using meta_wageaddition;
using meta_upb;
using meta_finview;
using meta_bill;
using meta_mandatekind;
using meta_expenselast;
using meta_config;
using meta_payment;
using meta_geo_city;
using meta_account;
using meta_underwriting;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace expense_levels {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenseTable expense 		=> (expenseTable)Tables["expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenseclawback 		=> (MetaTable)Tables["expenseclawback"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable clawback 		=> (MetaTable)Tables["clawback"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypaymethod 		=> (MetaTable)Tables["registrypaymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensetotal 		=> (MetaTable)Tables["expensetotal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensetax 		=> (MetaTable)Tables["expensetax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tax 		=> (MetaTable)Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenseyearTable expenseyear 		=> (expenseyearTable)Tables["expenseyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensephase 		=> (MetaTable)Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public managerTable manager 		=> (managerTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expensesortedTable expensesorted 		=> (expensesortedTable)Tables["expensesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting 		=> (sortingTable)Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingkindTable sortingkind 		=> (sortingkindTable)Tables["sortingkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable paymethod 		=> (MetaTable)Tables["paymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expensevarTable expensevar 		=> (expensevarTable)Tables["expensevar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandateTable mandate 		=> (mandateTable)Tables["mandate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenselastmandatedetail 		=> (MetaTable)Tables["expenselastmandatedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensemandate 		=> (MetaTable)Tables["expensemandate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenseitineration 		=> (MetaTable)Tables["expenseitineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public itinerationTable itineration 		=> (itinerationTable)Tables["itineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationtaxview 		=> (MetaTable)Tables["itinerationtaxview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipomovimento 		=> (MetaTable)Tables["tipomovimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomephase 		=> (MetaTable)Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoiceTable invoice 		=> (invoiceTable)Tables["invoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenseinvoice 		=> (MetaTable)Tables["expenseinvoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoiceexpenselinked 		=> (MetaTable)Tables["invoiceexpenselinked"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensepayroll 		=> (MetaTable)Tables["expensepayroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public payrollTable payroll 		=> (payrollTable)Tables["payroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable payrolltax 		=> (MetaTable)Tables["payrolltax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensecasualcontract 		=> (MetaTable)Tables["expensecasualcontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public casualcontractTable casualcontract 		=> (casualcontractTable)Tables["casualcontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenseprofservice 		=> (MetaTable)Tables["expenseprofservice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public profserviceTable profservice 		=> (profserviceTable)Tables["profservice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable profservicetax 		=> (MetaTable)Tables["profservicetax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public serviceTable service 		=> (serviceTable)Tables["service"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensewageaddition 		=> (MetaTable)Tables["expensewageaddition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public wageadditionTable wageaddition 		=> (wageadditionTable)Tables["wageaddition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable wageadditiontax 		=> (MetaTable)Tables["wageadditiontax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable finview 		=> (finviewTable)Tables["finview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable deputy 		=> (MetaTable)Tables["deputy"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable clawback_expense 		=> (MetaTable)Tables["clawback_expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public billTable bill 		=> (billTable)Tables["bill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandatekindTable mandatekind 		=> (mandatekindTable)Tables["mandatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandatedetail_iva 		=> (MetaTable)Tables["mandatedetail_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandatedetail_taxable 		=> (MetaTable)Tables["mandatedetail_taxable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedetail_iva 		=> (MetaTable)Tables["invoicedetail_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedetail_taxable 		=> (MetaTable)Tables["invoicedetail_taxable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expenselastTable expenselast 		=> (expenselastTable)Tables["expenselast"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable billview 		=> (MetaTable)Tables["billview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public paymentTable payment 		=> (paymentTable)Tables["payment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable formerexpense 		=> (MetaTable)Tables["formerexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensetaxcorrige 		=> (MetaTable)Tables["expensetaxcorrige"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public geo_cityTable geo_city 		=> (geo_cityTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fiscaltaxregion 		=> (MetaTable)Tables["fiscaltaxregion"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensetaxofficial 		=> (MetaTable)Tables["expensetaxofficial"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account 		=> (accountTable)Tables["account"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public underwritingTable underwriting 		=> (underwritingTable)Tables["underwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable underwritingappropriation 		=> (MetaTable)Tables["underwritingappropriation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable underwritingpayment 		=> (MetaTable)Tables["underwritingpayment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable underwriting_var 		=> (MetaTable)Tables["underwriting_var"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable lookup_tiporigaf24ep 		=> (MetaTable)Tables["lookup_tiporigaf24ep"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable monthname2 		=> (MetaTable)Tables["monthname2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable monthname1 		=> (MetaTable)Tables["monthname1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensebill 		=> (MetaTable)Tables["expensebill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable chargehandling 		=> (MetaTable)Tables["chargehandling"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bill1 		=> (MetaTable)Tables["bill1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedetail_iva_nc 		=> (MetaTable)Tables["invoicedetail_iva_nc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedetail_taxable_nc 		=> (MetaTable)Tables["invoicedetail_taxable_nc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable income_linked 		=> (MetaTable)Tables["income_linked"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandatedetail_pagamenti 		=> (MetaTable)Tables["mandatedetail_pagamenti"];

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
	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new expenseTable();
	texpense.addBaseColumns("idexp","nphase","ymov","nmov","parentidexp","idreg","idman","doc","docdate","description","expiration","adate","txt","rtf","cu","ct","lu","lt","idclawback","autokind","autocode","idformerexpense","idpayment","cupcode","cigcode","external_reference","idinc_linked","flag");
	Tables.Add(texpense);
	texpense.defineKey("idexp");

	//////////////////// EXPENSECLAWBACK /////////////////////////////////
	var texpenseclawback= new MetaTable("expenseclawback");
	texpenseclawback.defineColumn("idexp", typeof(int),false);
	texpenseclawback.defineColumn("idclawback", typeof(int),false);
	texpenseclawback.defineColumn("amount", typeof(decimal));
	texpenseclawback.defineColumn("cu", typeof(string),false);
	texpenseclawback.defineColumn("ct", typeof(DateTime),false);
	texpenseclawback.defineColumn("lu", typeof(string),false);
	texpenseclawback.defineColumn("lt", typeof(DateTime),false);
	texpenseclawback.defineColumn("!clawbackref", typeof(string));
	texpenseclawback.defineColumn("fiscaltaxcode", typeof(string));
	texpenseclawback.defineColumn("identifying_marks", typeof(string));
	texpenseclawback.defineColumn("code", typeof(string));
	texpenseclawback.defineColumn("tiporiga", typeof(string));
	texpenseclawback.defineColumn("rifb_month", typeof(int));
	texpenseclawback.defineColumn("rifb_year", typeof(int));
	texpenseclawback.defineColumn("rifa_month", typeof(int));
	texpenseclawback.defineColumn("rifa_year", typeof(int));
	texpenseclawback.defineColumn("rifa", typeof(string));
	texpenseclawback.defineColumn("!rifa_monthname", typeof(string));
	texpenseclawback.defineColumn("!rifb_monthname", typeof(string));
	Tables.Add(texpenseclawback);
	texpenseclawback.defineKey("idexp", "idclawback");

	//////////////////// CLAWBACK /////////////////////////////////
	var tclawback= new MetaTable("clawback");
	tclawback.defineColumn("idclawback", typeof(int),false);
	tclawback.defineColumn("description", typeof(string),false);
	tclawback.defineColumn("cu", typeof(string),false);
	tclawback.defineColumn("ct", typeof(DateTime),false);
	tclawback.defineColumn("lu", typeof(string),false);
	tclawback.defineColumn("lt", typeof(DateTime),false);
	tclawback.defineColumn("clawbackref", typeof(string));
	tclawback.defineColumn("active", typeof(string));
	tclawback.defineColumn("flagf24ep", typeof(string));
	Tables.Add(tclawback);
	tclawback.defineKey("idclawback");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","annotation","birthdate","gender","surname","forename","foreigncf","active","idregistryclass","txt","rtf","cu","ct","lu","lt");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	var tregistrypaymethod= new MetaTable("registrypaymethod");
	tregistrypaymethod.defineColumn("regmodcode", typeof(string),false);
	tregistrypaymethod.defineColumn("idreg", typeof(int),false);
	tregistrypaymethod.defineColumn("idpaymethod", typeof(int));
	tregistrypaymethod.defineColumn("iban", typeof(string));
	tregistrypaymethod.defineColumn("cin", typeof(string));
	tregistrypaymethod.defineColumn("idbank", typeof(string));
	tregistrypaymethod.defineColumn("idcab", typeof(string));
	tregistrypaymethod.defineColumn("cc", typeof(string));
	tregistrypaymethod.defineColumn("paymentdescr", typeof(string));
	tregistrypaymethod.defineColumn("paymentexpiring", typeof(short));
	tregistrypaymethod.defineColumn("idexpirationkind", typeof(short));
	tregistrypaymethod.defineColumn("flagstandard", typeof(string));
	tregistrypaymethod.defineColumn("txt", typeof(string));
	tregistrypaymethod.defineColumn("rtf", typeof(Byte[]));
	tregistrypaymethod.defineColumn("cu", typeof(string),false);
	tregistrypaymethod.defineColumn("ct", typeof(DateTime),false);
	tregistrypaymethod.defineColumn("lu", typeof(string),false);
	tregistrypaymethod.defineColumn("lt", typeof(DateTime),false);
	tregistrypaymethod.defineColumn("iddeputy", typeof(int));
	tregistrypaymethod.defineColumn("refexternaldoc", typeof(string));
	tregistrypaymethod.defineColumn("idregistrypaymethod", typeof(int),false);
	tregistrypaymethod.defineColumn("active", typeof(string));
	tregistrypaymethod.defineColumn("biccode", typeof(string));
	tregistrypaymethod.defineColumn("extracode", typeof(string));
	tregistrypaymethod.defineColumn("flag", typeof(int));
	tregistrypaymethod.defineColumn("idchargehandling", typeof(int));
	tregistrypaymethod.defineColumn("requested_doc", typeof(int));
	tregistrypaymethod.defineColumn("ccdedicato_stop", typeof(DateTime));
	Tables.Add(tregistrypaymethod);
	tregistrypaymethod.defineKey("idreg", "idregistrypaymethod");

	//////////////////// EXPENSETOTAL /////////////////////////////////
	var texpensetotal= new MetaTable("expensetotal");
	texpensetotal.defineColumn("ayear", typeof(short),false);
	texpensetotal.defineColumn("idexp", typeof(int),false);
	texpensetotal.defineColumn("curramount", typeof(decimal));
	texpensetotal.defineColumn("available", typeof(decimal));
	Tables.Add(texpensetotal);
	texpensetotal.defineKey("ayear", "idexp");

	//////////////////// EXPENSETAX /////////////////////////////////
	var texpensetax= new MetaTable("expensetax");
	texpensetax.defineColumn("taxcode", typeof(int),false);
	texpensetax.defineColumn("!descrizione", typeof(string));
	texpensetax.defineColumn("idexp", typeof(int),false);
	texpensetax.defineColumn("nbracket", typeof(int),false);
	texpensetax.defineColumn("taxablegross", typeof(decimal));
	texpensetax.defineColumn("exemptionquota", typeof(decimal));
	texpensetax.defineColumn("abatements", typeof(decimal));
	texpensetax.defineColumn("taxablenumerator", typeof(decimal));
	texpensetax.defineColumn("taxabledenominator", typeof(decimal));
	texpensetax.defineColumn("employrate", typeof(decimal));
	texpensetax.defineColumn("employnumerator", typeof(decimal));
	texpensetax.defineColumn("employdenominator", typeof(decimal));
	texpensetax.defineColumn("adminrate", typeof(decimal));
	texpensetax.defineColumn("adminnumerator", typeof(decimal));
	texpensetax.defineColumn("admindenominator", typeof(decimal));
	texpensetax.defineColumn("employtax", typeof(decimal));
	texpensetax.defineColumn("admintax", typeof(decimal));
	texpensetax.defineColumn("competencydate", typeof(DateTime));
	texpensetax.defineColumn("cu", typeof(string),false);
	texpensetax.defineColumn("ct", typeof(DateTime),false);
	texpensetax.defineColumn("lu", typeof(string),false);
	texpensetax.defineColumn("lt", typeof(DateTime),false);
	texpensetax.defineColumn("taxablenet", typeof(decimal));
	texpensetax.defineColumn("ytaxpay", typeof(short));
	texpensetax.defineColumn("ntaxpay", typeof(int));
	texpensetax.defineColumn("!taxref", typeof(string));
	texpensetax.defineColumn("ayear", typeof(short));
	texpensetax.defineColumn("idinc", typeof(int));
	texpensetax.defineColumn("idcity", typeof(int));
	texpensetax.defineColumn("idfiscaltaxregion", typeof(string));
	Tables.Add(texpensetax);
	texpensetax.defineKey("taxcode", "idexp", "nbracket");

	//////////////////// TAX /////////////////////////////////
	var ttax= new MetaTable("tax");
	ttax.defineColumn("taxcode", typeof(int),false);
	ttax.defineColumn("taxref", typeof(string));
	ttax.defineColumn("description", typeof(string),false);
	ttax.defineColumn("taxkind", typeof(short));
	ttax.defineColumn("fiscaltaxcode", typeof(string));
	ttax.defineColumn("flagunabatable", typeof(string));
	ttax.defineColumn("cu", typeof(string),false);
	ttax.defineColumn("ct", typeof(DateTime),false);
	ttax.defineColumn("lu", typeof(string),false);
	ttax.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(ttax);
	ttax.defineKey("taxcode");

	//////////////////// EXPENSEYEAR /////////////////////////////////
	var texpenseyear= new expenseyearTable();
	texpenseyear.addBaseColumns("ayear","idexp","idfin","idupb","amount","cu","ct","lu","lt");
	Tables.Add(texpenseyear);
	texpenseyear.defineKey("ayear", "idexp");

	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new MetaTable("expensephase");
	texpensephase.defineColumn("nphase", typeof(byte),false);
	texpensephase.defineColumn("description", typeof(string),false);
	texpensephase.defineColumn("cu", typeof(string),false);
	texpensephase.defineColumn("ct", typeof(DateTime),false);
	texpensephase.defineColumn("lu", typeof(string),false);
	texpensephase.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(texpensephase);
	texpensephase.defineKey("nphase");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new managerTable();
	tmanager.addBaseColumns("idman","title","iddivision","email","phonenumber","userweb","passwordweb","txt","rtf","cu","ct","lu","lt","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// EXPENSESORTED /////////////////////////////////
	var texpensesorted= new expensesortedTable();
	texpensesorted.addBaseColumns("idsor","idexp","idsubclass","amount","valuen1","valuen2","valuen3","valuen4","valuen5","values1","values2","values3","values4","values5","valuev1","valuev2","valuev3","valuev4","valuev5","ayear","description","txt","rtf","cu","ct","lu","lt","flagnodate","tobecontinued","start","stop","paridsor","paridsubclass");
	texpensesorted.defineColumn("!percentuale", typeof(string));
	texpensesorted.defineColumn("!codice", typeof(string));
	texpensesorted.defineColumn("!descr", typeof(string));
	texpensesorted.defineColumn("!idsorkind", typeof(int));
	Tables.Add(texpensesorted);
	texpensesorted.defineKey("idexp", "idsor", "idsubclass");

	//////////////////// SORTING /////////////////////////////////
	var tsorting= new sortingTable();
	tsorting.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultn1","defaultn2","defaultn3","defaultn4","defaultn5","defaults1","defaults2","defaults3","defaults4","defaults5","flagnodate","movkind","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new sortingkindTable();
	tsortingkind.addBaseColumns("active","ct","cu","description","flagdate","forcedN1","forcedN2","forcedN3","forcedN4","forcedN5","forcedS1","forcedS2","forcedS3","forcedS4","forcedS5","forcedv1","forcedv2","forcedv3","forcedv4","forcedv5","labelfordate","labeln1","labeln2","labeln3","labeln4","labeln5","labels1","labels2","labels3","labels4","labels5","labelv1","labelv2","labelv3","labelv4","labelv5","lockedN1","lockedN2","lockedN3","lockedN4","lockedN5","lockedS1","lockedS2","lockedS3","lockedS4","lockedS5","lockedv1","lockedv2","lockedv3","lockedv4","lockedv5","lt","lu","nodatelabel","totalexpression","nphaseexpense","nphaseincome","codesorkind","idsorkind","flag","allowedS1","allowedS2","allowedS3","allowedS4","allowedS5");
	tsortingkind.defineColumn("!importo", typeof(decimal));
	Tables.Add(tsortingkind);
	tsortingkind.defineKey("idsorkind");

	//////////////////// PAYMETHOD /////////////////////////////////
	var tpaymethod= new MetaTable("paymethod");
	tpaymethod.defineColumn("idpaymethod", typeof(int),false);
	tpaymethod.defineColumn("description", typeof(string),false);
	tpaymethod.defineColumn("cu", typeof(string),false);
	tpaymethod.defineColumn("ct", typeof(DateTime),false);
	tpaymethod.defineColumn("lu", typeof(string),false);
	tpaymethod.defineColumn("lt", typeof(DateTime),false);
	tpaymethod.defineColumn("allowdeputy", typeof(string));
	tpaymethod.defineColumn("footerpaymentadvice", typeof(string));
	tpaymethod.defineColumn("flag", typeof(int),false);
	Tables.Add(tpaymethod);
	tpaymethod.defineKey("idpaymethod");

	//////////////////// EXPENSEVAR /////////////////////////////////
	var texpensevar= new expensevarTable();
	texpensevar.addBaseColumns("nvar","idexp","yvar","description","amount","doc","autocode","autokind","idpayment","docdate","adate","transferkind","txt","rtf","cu","ct","lu","lt","idinvkind","ninv","yinv","kpaymenttransmission","idunderwriting","movkind");
	texpensevar.defineColumn("!codeunderwriting", typeof(string));
	texpensevar.defineColumn("!underwriting", typeof(string));
	Tables.Add(texpensevar);
	texpensevar.defineKey("nvar", "idexp");

	//////////////////// MANDATE /////////////////////////////////
	var tmandate= new mandateTable();
	tmandate.addBaseColumns("idmankind","yman","nman","idreg","registryreference","description","idman","deliveryexpiration","deliveryaddress","paymentexpiring","idexpirationkind","idcurrency","exchangerate","doc","docdate","adate","officiallyprinted","cu","ct","lu","lt","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","applierannotations","idmandatestatus","cigcode","idsor01","idsor02","idsor03","idsor04","idsor05","requested_doc","flagbit");
	Tables.Add(tmandate);
	tmandate.defineKey("idmankind", "yman", "nman");

	//////////////////// EXPENSELASTMANDATEDETAIL /////////////////////////////////
	var texpenselastmandatedetail= new MetaTable("expenselastmandatedetail");
	texpenselastmandatedetail.defineColumn("idexp", typeof(int),false);
	texpenselastmandatedetail.defineColumn("idmankind", typeof(string),false);
	texpenselastmandatedetail.defineColumn("yman", typeof(short),false);
	texpenselastmandatedetail.defineColumn("nman", typeof(int),false);
	texpenselastmandatedetail.defineColumn("rownum", typeof(int),false);
	texpenselastmandatedetail.defineColumn("amount", typeof(decimal),false);
	texpenselastmandatedetail.defineColumn("lt", typeof(DateTime),false);
	texpenselastmandatedetail.defineColumn("lu", typeof(string),false);
	texpenselastmandatedetail.defineColumn("ct", typeof(DateTime),false);
	texpenselastmandatedetail.defineColumn("cu", typeof(string),false);
	texpenselastmandatedetail.defineColumn("originalamount", typeof(decimal));
	texpenselastmandatedetail.defineColumn("!mankind", typeof(string));
	texpenselastmandatedetail.defineColumn("!description", typeof(string));
	Tables.Add(texpenselastmandatedetail);
	texpenselastmandatedetail.defineKey("idexp", "idmankind", "yman", "nman", "rownum");

	//////////////////// EXPENSEMANDATE /////////////////////////////////
	var texpensemandate= new MetaTable("expensemandate");
	texpensemandate.defineColumn("idmankind", typeof(string),false);
	texpensemandate.defineColumn("yman", typeof(short),false);
	texpensemandate.defineColumn("nman", typeof(int),false);
	texpensemandate.defineColumn("idexp", typeof(int),false);
	texpensemandate.defineColumn("movkind", typeof(short));
	texpensemandate.defineColumn("cu", typeof(string),false);
	texpensemandate.defineColumn("ct", typeof(DateTime),false);
	texpensemandate.defineColumn("lu", typeof(string),false);
	texpensemandate.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(texpensemandate);
	texpensemandate.defineKey("idmankind", "yman", "nman", "idexp");

	//////////////////// EXPENSEITINERATION /////////////////////////////////
	var texpenseitineration= new MetaTable("expenseitineration");
	texpenseitineration.defineColumn("idexp", typeof(int),false);
	texpenseitineration.defineColumn("movkind", typeof(short));
	texpenseitineration.defineColumn("cu", typeof(string),false);
	texpenseitineration.defineColumn("ct", typeof(DateTime),false);
	texpenseitineration.defineColumn("lu", typeof(string),false);
	texpenseitineration.defineColumn("lt", typeof(DateTime),false);
	texpenseitineration.defineColumn("iditineration", typeof(int),false);
	Tables.Add(texpenseitineration);
	texpenseitineration.defineKey("idexp", "iditineration");

	//////////////////// ITINERATION /////////////////////////////////
	var titineration= new itinerationTable();
	titineration.addBaseColumns("yitineration","nitineration","description","idreg","idser","authorizationdate","start","stop","adate","admincarkmcost","owncarkmcost","footkmcost","admincarkm","owncarkm","footkm","grossfactor","netfee","totalgross","total","totadvance","cu","ct","lu","lt","completed","idaccmotive","idsor1","idsor2","idsor3","idupb","iditineration","idaccmotivedebit","applierannotations","idaccmotivedebit_crg","idman","idsor01","idsor02","idsor03","idsor04","idsor05","idsor_siope","datecompleted");
	Tables.Add(titineration);
	titineration.defineKey("iditineration");

	//////////////////// ITINERATIONTAXVIEW /////////////////////////////////
	var titinerationtaxview= new MetaTable("itinerationtaxview");
	titinerationtaxview.defineColumn("yitineration", typeof(short),false);
	titinerationtaxview.defineColumn("nitineration", typeof(int),false);
	titinerationtaxview.defineColumn("taxcode", typeof(int),false);
	titinerationtaxview.defineColumn("description", typeof(string),false);
	titinerationtaxview.defineColumn("taxkind", typeof(short));
	titinerationtaxview.defineColumn("taxablenumerator", typeof(decimal));
	titinerationtaxview.defineColumn("taxabledenominator", typeof(decimal));
	titinerationtaxview.defineColumn("adminrate", typeof(decimal));
	titinerationtaxview.defineColumn("adminnumerator", typeof(decimal));
	titinerationtaxview.defineColumn("admindenominator", typeof(decimal));
	titinerationtaxview.defineColumn("employrate", typeof(decimal));
	titinerationtaxview.defineColumn("employnumerator", typeof(decimal));
	titinerationtaxview.defineColumn("employdenominator", typeof(decimal));
	titinerationtaxview.defineColumn("admintax", typeof(decimal));
	titinerationtaxview.defineColumn("employtax", typeof(decimal));
	titinerationtaxview.defineColumn("taxable", typeof(decimal));
	titinerationtaxview.defineColumn("flagunabatable", typeof(string));
	titinerationtaxview.defineColumn("cu", typeof(string),false);
	titinerationtaxview.defineColumn("ct", typeof(DateTime),false);
	titinerationtaxview.defineColumn("lu", typeof(string),false);
	titinerationtaxview.defineColumn("lt", typeof(DateTime),false);
	titinerationtaxview.defineColumn("iditineration", typeof(int),false);
	Tables.Add(titinerationtaxview);
	titinerationtaxview.defineKey("taxcode", "iditineration");

	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	var ttipomovimento= new MetaTable("tipomovimento");
	ttipomovimento.defineColumn("idtipo", typeof(int),false);
	ttipomovimento.defineColumn("descrizione", typeof(string));
	Tables.Add(ttipomovimento);
	ttipomovimento.defineKey("idtipo");

	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new MetaTable("incomephase");
	tincomephase.defineColumn("nphase", typeof(byte),false);
	tincomephase.defineColumn("description", typeof(string),false);
	tincomephase.defineColumn("cu", typeof(string),false);
	tincomephase.defineColumn("ct", typeof(DateTime),false);
	tincomephase.defineColumn("lu", typeof(string),false);
	tincomephase.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tincomephase);
	tincomephase.defineKey("nphase");

	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new invoiceTable();
	tinvoice.addBaseColumns("idinvkind","yinv","ninv","idreg","registryreference","description","paymentexpiring","idexpirationkind","idcurrency","exchangerate","doc","docdate","adate","packinglistnum","packinglistdate","officiallyprinted","cu","ct","lu","lt","active","idaccmotivedebit_crg","idaccmotivedebit","idaccmotivedebit_datacrg","idsor01","idsor02","idsor03","idsor04","idsor05","flag_enable_split_payment","flag_auto_split_payment","flagdeferred","requested_doc","flagintracom","flagbit");
	Tables.Add(tinvoice);
	tinvoice.defineKey("idinvkind", "yinv", "ninv");

	//////////////////// EXPENSEINVOICE /////////////////////////////////
	var texpenseinvoice= new MetaTable("expenseinvoice");
	texpenseinvoice.defineColumn("idinvkind", typeof(int),false);
	texpenseinvoice.defineColumn("yinv", typeof(short),false);
	texpenseinvoice.defineColumn("ninv", typeof(int),false);
	texpenseinvoice.defineColumn("idexp", typeof(int),false);
	texpenseinvoice.defineColumn("movkind", typeof(short));
	texpenseinvoice.defineColumn("cu", typeof(string),false);
	texpenseinvoice.defineColumn("ct", typeof(DateTime),false);
	texpenseinvoice.defineColumn("lu", typeof(string),false);
	texpenseinvoice.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(texpenseinvoice);
	texpenseinvoice.defineKey("idinvkind", "yinv", "ninv", "idexp");

	//////////////////// INVOICEEXPENSELINKED /////////////////////////////////
	var tinvoiceexpenselinked= new MetaTable("invoiceexpenselinked");
	tinvoiceexpenselinked.defineColumn("idinvkind", typeof(int),false);
	tinvoiceexpenselinked.defineColumn("invoicekind", typeof(string),false);
	tinvoiceexpenselinked.defineColumn("yinv", typeof(short),false);
	tinvoiceexpenselinked.defineColumn("ninv", typeof(int),false);
	tinvoiceexpenselinked.defineColumn("flag", typeof(byte),false);
	tinvoiceexpenselinked.defineColumn("flagbuysell", typeof(string),false);
	tinvoiceexpenselinked.defineColumn("flagvariation", typeof(string),false);
	tinvoiceexpenselinked.defineColumn("idreg", typeof(int),false);
	tinvoiceexpenselinked.defineColumn("registry", typeof(string),false);
	tinvoiceexpenselinked.defineColumn("registryreference", typeof(string));
	tinvoiceexpenselinked.defineColumn("description", typeof(string),false);
	tinvoiceexpenselinked.defineColumn("paymentexpiring", typeof(short));
	tinvoiceexpenselinked.defineColumn("idexpirationkind", typeof(string));
	tinvoiceexpenselinked.defineColumn("idcurrency", typeof(int));
	tinvoiceexpenselinked.defineColumn("currency", typeof(string));
	tinvoiceexpenselinked.defineColumn("exchangerate", typeof(double));
	tinvoiceexpenselinked.defineColumn("doc", typeof(string));
	tinvoiceexpenselinked.defineColumn("docdate", typeof(DateTime));
	tinvoiceexpenselinked.defineColumn("adate", typeof(DateTime),false);
	tinvoiceexpenselinked.defineColumn("packinglistnum", typeof(string));
	tinvoiceexpenselinked.defineColumn("packinglistdate", typeof(DateTime));
	tinvoiceexpenselinked.defineColumn("officiallyprinted", typeof(string),false);
	tinvoiceexpenselinked.defineColumn("txt", typeof(string));
	tinvoiceexpenselinked.defineColumn("cu", typeof(string),false);
	tinvoiceexpenselinked.defineColumn("ct", typeof(DateTime),false);
	tinvoiceexpenselinked.defineColumn("lu", typeof(string),false);
	tinvoiceexpenselinked.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tinvoiceexpenselinked);
	tinvoiceexpenselinked.defineKey("idinvkind", "yinv", "ninv");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("idinvkind","description","cu","ct","lu","lt","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// EXPENSEPAYROLL /////////////////////////////////
	var texpensepayroll= new MetaTable("expensepayroll");
	texpensepayroll.defineColumn("idpayroll", typeof(int),false);
	texpensepayroll.defineColumn("idexp", typeof(int),false);
	texpensepayroll.defineColumn("cu", typeof(string));
	texpensepayroll.defineColumn("ct", typeof(DateTime));
	texpensepayroll.defineColumn("lu", typeof(string));
	texpensepayroll.defineColumn("lt", typeof(DateTime));
	Tables.Add(texpensepayroll);
	texpensepayroll.defineKey("idpayroll", "idexp");

	//////////////////// PAYROLL /////////////////////////////////
	var tpayroll= new payrollTable();
	tpayroll.addBaseColumns("idpayroll","fiscalyear","npayroll","flagbalance","disbursementdate","idresidence","workingdays","feegross","flagcomputed","idcon","currentrounding","lu","lt","cu","ct","enabletaxrelief","start","stop","netfee","idupb");
	Tables.Add(tpayroll);
	tpayroll.defineKey("idpayroll");

	//////////////////// PAYROLLTAX /////////////////////////////////
	var tpayrolltax= new MetaTable("payrolltax");
	tpayrolltax.defineColumn("idpayroll", typeof(int),false);
	tpayrolltax.defineColumn("idpayrolltax", typeof(int),false);
	tpayrolltax.defineColumn("taxcode", typeof(int));
	tpayrolltax.defineColumn("taxablegross", typeof(decimal));
	tpayrolltax.defineColumn("deduction", typeof(decimal));
	tpayrolltax.defineColumn("abatements", typeof(decimal));
	tpayrolltax.defineColumn("cu", typeof(string));
	tpayrolltax.defineColumn("ct", typeof(DateTime));
	tpayrolltax.defineColumn("lu", typeof(string));
	tpayrolltax.defineColumn("lt", typeof(DateTime));
	tpayrolltax.defineColumn("taxablenumerator", typeof(decimal));
	tpayrolltax.defineColumn("taxabledenominator", typeof(decimal));
	tpayrolltax.defineColumn("employrate", typeof(decimal));
	tpayrolltax.defineColumn("employnumerator", typeof(decimal));
	tpayrolltax.defineColumn("employdenominator", typeof(decimal));
	tpayrolltax.defineColumn("adminrate", typeof(decimal));
	tpayrolltax.defineColumn("adminnumerator", typeof(decimal));
	tpayrolltax.defineColumn("admindenominator", typeof(decimal));
	tpayrolltax.defineColumn("employtax", typeof(decimal));
	tpayrolltax.defineColumn("admintax", typeof(decimal));
	tpayrolltax.defineColumn("taxablenet", typeof(decimal));
	tpayrolltax.defineColumn("employtaxgross", typeof(decimal));
	tpayrolltax.defineColumn("annualtaxabletotal", typeof(decimal));
	tpayrolltax.defineColumn("annualpayedemploytax", typeof(decimal));
	tpayrolltax.defineColumn("idcity", typeof(int));
	tpayrolltax.defineColumn("idfiscaltaxregion", typeof(string));
	Tables.Add(tpayrolltax);
	tpayrolltax.defineKey("idpayroll", "idpayrolltax");

	//////////////////// EXPENSECASUALCONTRACT /////////////////////////////////
	var texpensecasualcontract= new MetaTable("expensecasualcontract");
	texpensecasualcontract.defineColumn("ycon", typeof(int),false);
	texpensecasualcontract.defineColumn("idexp", typeof(int),false);
	texpensecasualcontract.defineColumn("ncon", typeof(int),false);
	texpensecasualcontract.defineColumn("ct", typeof(DateTime),false);
	texpensecasualcontract.defineColumn("cu", typeof(string),false);
	texpensecasualcontract.defineColumn("lt", typeof(DateTime),false);
	texpensecasualcontract.defineColumn("lu", typeof(string),false);
	Tables.Add(texpensecasualcontract);
	texpensecasualcontract.defineKey("ycon", "idexp", "ncon");

	//////////////////// CASUALCONTRACT /////////////////////////////////
	var tcasualcontract= new casualcontractTable();
	tcasualcontract.addBaseColumns("ycon","ncon","idreg","idser","feegross","ct","cu","adate","stop","start","ndays","lt","lu","description","completed","idaccmotive","idsor1","idsor2","idsor3","idupb","idaccmotivedebit","idaccmotivedebit_crg","idsor_siope","requested_doc");
	Tables.Add(tcasualcontract);
	tcasualcontract.defineKey("ycon", "ncon");

	//////////////////// EXPENSEPROFSERVICE /////////////////////////////////
	var texpenseprofservice= new MetaTable("expenseprofservice");
	texpenseprofservice.defineColumn("ycon", typeof(int),false);
	texpenseprofservice.defineColumn("idexp", typeof(int),false);
	texpenseprofservice.defineColumn("ncon", typeof(int),false);
	texpenseprofservice.defineColumn("ct", typeof(DateTime),false);
	texpenseprofservice.defineColumn("cu", typeof(string),false);
	texpenseprofservice.defineColumn("lt", typeof(DateTime),false);
	texpenseprofservice.defineColumn("lu", typeof(string),false);
	texpenseprofservice.defineColumn("movkind", typeof(short),false);
	Tables.Add(texpenseprofservice);
	texpenseprofservice.defineKey("ycon", "idexp", "ncon");

	//////////////////// PROFSERVICE /////////////////////////////////
	var tprofservice= new profserviceTable();
	tprofservice.addBaseColumns("ycon","ncon","socialsecurityrate","pensioncontributionrate","ivarate","idreg","idser","feegross","totalcost","totalgross","ct","cu","adate","stop","start","ndays","ivaamount","lt","lu","idupb","ivafieldnumber","description","doc","docdate","idaccmotivedebit","idaccmotivedebit_crg","idsor01","idsor02","idsor03","idsor04","idsor05","idinvkind","yinv","ninv","idsor_siope","requested_doc");
	Tables.Add(tprofservice);
	tprofservice.defineKey("ycon", "ncon");

	//////////////////// PROFSERVICETAX /////////////////////////////////
	var tprofservicetax= new MetaTable("profservicetax");
	tprofservicetax.defineColumn("taxcode", typeof(int),false);
	tprofservicetax.defineColumn("ycon", typeof(int),false);
	tprofservicetax.defineColumn("ncon", typeof(int),false);
	tprofservicetax.defineColumn("adminrate", typeof(decimal));
	tprofservicetax.defineColumn("employrate", typeof(decimal));
	tprofservicetax.defineColumn("ct", typeof(DateTime),false);
	tprofservicetax.defineColumn("cu", typeof(string),false);
	tprofservicetax.defineColumn("deduction", typeof(decimal));
	tprofservicetax.defineColumn("taxablegross", typeof(decimal));
	tprofservicetax.defineColumn("taxablenet", typeof(decimal));
	tprofservicetax.defineColumn("lt", typeof(DateTime),false);
	tprofservicetax.defineColumn("lu", typeof(string),false);
	tprofservicetax.defineColumn("admindenominator", typeof(decimal));
	tprofservicetax.defineColumn("employdenominator", typeof(decimal));
	tprofservicetax.defineColumn("taxabledenominator", typeof(decimal));
	tprofservicetax.defineColumn("adminnumerator", typeof(decimal));
	tprofservicetax.defineColumn("employnumerator", typeof(decimal));
	tprofservicetax.defineColumn("taxablenumerator", typeof(decimal));
	tprofservicetax.defineColumn("admintax", typeof(decimal));
	tprofservicetax.defineColumn("employtax", typeof(decimal));
	tprofservicetax.defineColumn("employtaxgross", typeof(decimal));
	Tables.Add(tprofservicetax);
	tprofservicetax.defineKey("taxcode", "ycon", "ncon");

	//////////////////// SERVICE /////////////////////////////////
	var tservice= new serviceTable();
	tservice.addBaseColumns("idser","description","flagonlyfiscalabatement","ivaamount","certificatekind","cu","ct","lu","lt","active","flagapplyabatements","idmotive","itinerationvisible","flagalwaysinfiscalmodels","module","allowedit","requested_doc");
	Tables.Add(tservice);
	tservice.defineKey("idser");

	//////////////////// EXPENSEWAGEADDITION /////////////////////////////////
	var texpensewageaddition= new MetaTable("expensewageaddition");
	texpensewageaddition.defineColumn("ycon", typeof(int),false);
	texpensewageaddition.defineColumn("ncon", typeof(int),false);
	texpensewageaddition.defineColumn("idexp", typeof(int),false);
	texpensewageaddition.defineColumn("ct", typeof(DateTime),false);
	texpensewageaddition.defineColumn("cu", typeof(string),false);
	texpensewageaddition.defineColumn("lt", typeof(DateTime),false);
	texpensewageaddition.defineColumn("lu", typeof(string),false);
	Tables.Add(texpensewageaddition);
	texpensewageaddition.defineKey("ycon", "ncon", "idexp");

	//////////////////// WAGEADDITION /////////////////////////////////
	var twageaddition= new wageadditionTable();
	twageaddition.addBaseColumns("ycon","ncon","idreg","idser","feegross","ct","cu","adate","stop","start","description","ndays","lt","lu","completed","idaccmotive","idsor1","idsor2","idsor3","idaccmotivedebit_crg","idaccmotivedebit","idupb","idsor01","idsor02","idsor03","idsor04","idsor05","idsor_siope");
	Tables.Add(twageaddition);
	twageaddition.defineKey("ycon", "ncon");

	//////////////////// WAGEADDITIONTAX /////////////////////////////////
	var twageadditiontax= new MetaTable("wageadditiontax");
	twageadditiontax.defineColumn("taxcode", typeof(int),false);
	twageadditiontax.defineColumn("ycon", typeof(int),false);
	twageadditiontax.defineColumn("ncon", typeof(int),false);
	twageadditiontax.defineColumn("adminrate", typeof(decimal));
	twageadditiontax.defineColumn("employrate", typeof(decimal));
	twageadditiontax.defineColumn("ct", typeof(DateTime),false);
	twageadditiontax.defineColumn("cu", typeof(string),false);
	twageadditiontax.defineColumn("taxable", typeof(decimal));
	twageadditiontax.defineColumn("lt", typeof(DateTime),false);
	twageadditiontax.defineColumn("lu", typeof(string),false);
	twageadditiontax.defineColumn("admindenominator", typeof(decimal));
	twageadditiontax.defineColumn("employdenominator", typeof(decimal));
	twageadditiontax.defineColumn("taxabledenominator", typeof(decimal));
	twageadditiontax.defineColumn("adminnumerator", typeof(decimal));
	twageadditiontax.defineColumn("employnumerator", typeof(decimal));
	twageadditiontax.defineColumn("taxablenumerator", typeof(decimal));
	twageadditiontax.defineColumn("admintax", typeof(decimal));
	twageadditiontax.defineColumn("employtax", typeof(decimal));
	Tables.Add(twageadditiontax);
	twageadditiontax.defineKey("taxcode", "ycon", "ncon");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb","title","paridupb","idunderwriter","idman","requested","granted","previousappropriation","expiration","cu","ct","lu","lt","assured","printingorder","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// FINVIEW /////////////////////////////////
	var tfinview= new finviewTable();
	tfinview.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tfinview);
	tfinview.defineKey("idfin", "idupb");

	//////////////////// DEPUTY /////////////////////////////////
	var tdeputy= new MetaTable("deputy");
	tdeputy.defineColumn("idreg", typeof(int),false);
	tdeputy.defineColumn("title", typeof(string),false);
	tdeputy.defineColumn("cf", typeof(string));
	tdeputy.defineColumn("p_iva", typeof(string));
	tdeputy.defineColumn("residence", typeof(int),false);
	tdeputy.defineColumn("annotation", typeof(string));
	tdeputy.defineColumn("birthdate", typeof(DateTime));
	tdeputy.defineColumn("gender", typeof(string));
	tdeputy.defineColumn("surname", typeof(string));
	tdeputy.defineColumn("forename", typeof(string));
	tdeputy.defineColumn("foreigncf", typeof(string));
	tdeputy.defineColumn("active", typeof(string),false);
	tdeputy.defineColumn("txt", typeof(string));
	tdeputy.defineColumn("rtf", typeof(Byte[]));
	tdeputy.defineColumn("cu", typeof(string),false);
	tdeputy.defineColumn("ct", typeof(DateTime),false);
	tdeputy.defineColumn("lu", typeof(string),false);
	tdeputy.defineColumn("lt", typeof(DateTime),false);
	tdeputy.defineColumn("badgecode", typeof(string));
	tdeputy.defineColumn("idcategory", typeof(string));
	tdeputy.defineColumn("idcentralizedcategory", typeof(string));
	tdeputy.defineColumn("idmaritalstatus", typeof(string));
	tdeputy.defineColumn("idtitle", typeof(string));
	tdeputy.defineColumn("idregistryclass", typeof(string));
	tdeputy.defineColumn("maritalsurname", typeof(string));
	tdeputy.defineColumn("idcity", typeof(int));
	tdeputy.defineColumn("idnation", typeof(int));
	tdeputy.defineColumn("location", typeof(string));
	tdeputy.defineColumn("extmatricula", typeof(string));
	Tables.Add(tdeputy);
	tdeputy.defineKey("idreg");

	//////////////////// CLAWBACK_EXPENSE /////////////////////////////////
	var tclawback_expense= new MetaTable("clawback_expense");
	tclawback_expense.defineColumn("idclawback", typeof(int),false);
	tclawback_expense.defineColumn("ct", typeof(DateTime),false);
	tclawback_expense.defineColumn("cu", typeof(string),false);
	tclawback_expense.defineColumn("description", typeof(string),false);
	tclawback_expense.defineColumn("lt", typeof(DateTime),false);
	tclawback_expense.defineColumn("lu", typeof(string),false);
	tclawback_expense.defineColumn("active", typeof(string));
	tclawback_expense.defineColumn("flagf24ep", typeof(string));
	Tables.Add(tclawback_expense);
	tclawback_expense.defineKey("idclawback");

	//////////////////// BILL /////////////////////////////////
	var tbill= new billTable();
	tbill.addBaseColumns("ybill","nbill","billkind","registry","covered","total","adate","active","motive","cu","ct","lu","lt","idtreasurer","regularizationnote");
	Tables.Add(tbill);
	tbill.defineKey("ybill", "nbill", "billkind");

	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new mandatekindTable();
	tmandatekind.addBaseColumns("idmankind","active","ct","cu","description","idupb","lt","lu","email","faxnumber","office","phonenumber","linktoasset","linktoinvoice","multireg","deltaamount","deltapercentage","idsor01","idsor02","idsor03","idsor04","idsor05","requested_doc");
	Tables.Add(tmandatekind);
	tmandatekind.defineKey("idmankind");

	//////////////////// MANDATEDETAIL_IVA /////////////////////////////////
	var tmandatedetail_iva= new MetaTable("mandatedetail_iva");
	tmandatedetail_iva.defineColumn("idmankind", typeof(string),false);
	tmandatedetail_iva.defineColumn("yman", typeof(short),false);
	tmandatedetail_iva.defineColumn("nman", typeof(int),false);
	tmandatedetail_iva.defineColumn("rownum", typeof(int),false);
	tmandatedetail_iva.defineColumn("idgroup", typeof(int));
	tmandatedetail_iva.defineColumn("mankind", typeof(string),false);
	tmandatedetail_iva.defineColumn("idinv", typeof(int));
	tmandatedetail_iva.defineColumn("codeinv", typeof(string));
	tmandatedetail_iva.defineColumn("inventorytree", typeof(string));
	tmandatedetail_iva.defineColumn("idreg", typeof(int));
	tmandatedetail_iva.defineColumn("registry", typeof(string));
	tmandatedetail_iva.defineColumn("detaildescription", typeof(string));
	tmandatedetail_iva.defineColumn("annotations", typeof(string));
	tmandatedetail_iva.defineColumn("number", typeof(decimal));
	tmandatedetail_iva.defineColumn("taxable", typeof(decimal));
	tmandatedetail_iva.defineColumn("taxrate", typeof(double));
	tmandatedetail_iva.defineColumn("tax", typeof(decimal));
	tmandatedetail_iva.defineColumn("discount", typeof(double));
	tmandatedetail_iva.defineColumn("assetkind", typeof(string),false);
	tmandatedetail_iva.defineColumn("start", typeof(DateTime));
	tmandatedetail_iva.defineColumn("stop", typeof(DateTime));
	tmandatedetail_iva.defineColumn("idexp_taxable", typeof(int));
	tmandatedetail_iva.defineColumn("idexp_iva", typeof(int));
	tmandatedetail_iva.defineColumn("taxable_euro", typeof(decimal),true,true);
	tmandatedetail_iva.defineColumn("iva_euro", typeof(decimal),true,true);
	tmandatedetail_iva.defineColumn("rowtotal", typeof(decimal),true,true);
	tmandatedetail_iva.defineColumn("idupb", typeof(string));
	tmandatedetail_iva.defineColumn("cu", typeof(string),false);
	tmandatedetail_iva.defineColumn("ct", typeof(DateTime),false);
	tmandatedetail_iva.defineColumn("lu", typeof(string),false);
	tmandatedetail_iva.defineColumn("lt", typeof(DateTime),false);
	tmandatedetail_iva.defineColumn("idaccmotive", typeof(string));
	tmandatedetail_iva.defineColumn("idivakind", typeof(int));
	tmandatedetail_iva.defineColumn("unabatable", typeof(decimal));
	tmandatedetail_iva.defineColumn("flagmixed", typeof(string));
	tmandatedetail_iva.defineColumn("toinvoice", typeof(string));
	tmandatedetail_iva.defineColumn("exchangerate", typeof(double));
	tmandatedetail_iva.defineColumn("va3type", typeof(string));
	tmandatedetail_iva.defineColumn("idlist", typeof(int));
	tmandatedetail_iva.defineColumn("idunit", typeof(int));
	tmandatedetail_iva.defineColumn("idpackage", typeof(int));
	tmandatedetail_iva.defineColumn("npackage", typeof(decimal));
	tmandatedetail_iva.defineColumn("unitsforpackage", typeof(int));
	tmandatedetail_iva.defineColumn("idpccdebitmotive", typeof(string));
	tmandatedetail_iva.defineColumn("idpccdebitstatus", typeof(string));
	tmandatedetail_iva.defineColumn("expensekind", typeof(string));
	tmandatedetail_iva.defineColumn("idlocation", typeof(int));
	tmandatedetail_iva.defineColumn("idsor_siope", typeof(int));
	tmandatedetail_iva.defineColumn("idupb_iva", typeof(string));
	Tables.Add(tmandatedetail_iva);
	tmandatedetail_iva.defineKey("idmankind", "yman", "nman", "rownum");

	//////////////////// MANDATEDETAIL_TAXABLE /////////////////////////////////
	var tmandatedetail_taxable= new MetaTable("mandatedetail_taxable");
	tmandatedetail_taxable.defineColumn("idmankind", typeof(string),false);
	tmandatedetail_taxable.defineColumn("yman", typeof(short),false);
	tmandatedetail_taxable.defineColumn("nman", typeof(int),false);
	tmandatedetail_taxable.defineColumn("rownum", typeof(int),false);
	tmandatedetail_taxable.defineColumn("idgroup", typeof(int));
	tmandatedetail_taxable.defineColumn("mankind", typeof(string),false);
	tmandatedetail_taxable.defineColumn("idinv", typeof(int));
	tmandatedetail_taxable.defineColumn("codeinv", typeof(string));
	tmandatedetail_taxable.defineColumn("inventorytree", typeof(string));
	tmandatedetail_taxable.defineColumn("idreg", typeof(int));
	tmandatedetail_taxable.defineColumn("registry", typeof(string));
	tmandatedetail_taxable.defineColumn("detaildescription", typeof(string));
	tmandatedetail_taxable.defineColumn("annotations", typeof(string));
	tmandatedetail_taxable.defineColumn("number", typeof(decimal));
	tmandatedetail_taxable.defineColumn("taxable", typeof(decimal));
	tmandatedetail_taxable.defineColumn("taxrate", typeof(double));
	tmandatedetail_taxable.defineColumn("tax", typeof(decimal));
	tmandatedetail_taxable.defineColumn("discount", typeof(double));
	tmandatedetail_taxable.defineColumn("assetkind", typeof(string),false);
	tmandatedetail_taxable.defineColumn("start", typeof(DateTime));
	tmandatedetail_taxable.defineColumn("stop", typeof(DateTime));
	tmandatedetail_taxable.defineColumn("idexp_taxable", typeof(int));
	tmandatedetail_taxable.defineColumn("idexp_iva", typeof(int));
	tmandatedetail_taxable.defineColumn("taxable_euro", typeof(decimal),true,true);
	tmandatedetail_taxable.defineColumn("iva_euro", typeof(decimal),true,true);
	tmandatedetail_taxable.defineColumn("rowtotal", typeof(decimal),true,true);
	tmandatedetail_taxable.defineColumn("idupb", typeof(string));
	tmandatedetail_taxable.defineColumn("cu", typeof(string),false);
	tmandatedetail_taxable.defineColumn("ct", typeof(DateTime),false);
	tmandatedetail_taxable.defineColumn("lu", typeof(string),false);
	tmandatedetail_taxable.defineColumn("lt", typeof(DateTime),false);
	tmandatedetail_taxable.defineColumn("idaccmotive", typeof(string));
	tmandatedetail_taxable.defineColumn("idivakind", typeof(int));
	tmandatedetail_taxable.defineColumn("unabatable", typeof(decimal));
	tmandatedetail_taxable.defineColumn("flagmixed", typeof(string));
	tmandatedetail_taxable.defineColumn("toinvoice", typeof(string));
	tmandatedetail_taxable.defineColumn("exchangerate", typeof(double));
	tmandatedetail_taxable.defineColumn("va3type", typeof(string));
	tmandatedetail_taxable.defineColumn("idlist", typeof(int));
	tmandatedetail_taxable.defineColumn("idunit", typeof(int));
	tmandatedetail_taxable.defineColumn("idpackage", typeof(int));
	tmandatedetail_taxable.defineColumn("npackage", typeof(decimal));
	tmandatedetail_taxable.defineColumn("unitsforpackage", typeof(int));
	tmandatedetail_taxable.defineColumn("idpccdebitmotive", typeof(string));
	tmandatedetail_taxable.defineColumn("idpccdebitstatus", typeof(string));
	tmandatedetail_taxable.defineColumn("expensekind", typeof(string));
	tmandatedetail_taxable.defineColumn("idlocation", typeof(int));
	tmandatedetail_taxable.defineColumn("idsor_siope", typeof(int));
	Tables.Add(tmandatedetail_taxable);
	tmandatedetail_taxable.defineKey("idmankind", "yman", "nman", "rownum");

	//////////////////// INVOICEDETAIL_IVA /////////////////////////////////
	var tinvoicedetail_iva= new MetaTable("invoicedetail_iva");
	tinvoicedetail_iva.defineColumn("idinvkind", typeof(int),false);
	tinvoicedetail_iva.defineColumn("invoicekind", typeof(string),false);
	tinvoicedetail_iva.defineColumn("yinv", typeof(short),false);
	tinvoicedetail_iva.defineColumn("ninv", typeof(int),false);
	tinvoicedetail_iva.defineColumn("idgroup", typeof(int));
	tinvoicedetail_iva.defineColumn("flag", typeof(byte),false);
	tinvoicedetail_iva.defineColumn("flagbuysell", typeof(string),false);
	tinvoicedetail_iva.defineColumn("flagvariation", typeof(string),false);
	tinvoicedetail_iva.defineColumn("rownum", typeof(int),false);
	tinvoicedetail_iva.defineColumn("detaildescription", typeof(string));
	tinvoicedetail_iva.defineColumn("idivakind", typeof(int),false);
	tinvoicedetail_iva.defineColumn("ivakind", typeof(string),false);
	tinvoicedetail_iva.defineColumn("rate", typeof(decimal),false);
	tinvoicedetail_iva.defineColumn("unabatabilitypercentage", typeof(decimal),false);
	tinvoicedetail_iva.defineColumn("number", typeof(decimal));
	tinvoicedetail_iva.defineColumn("taxable", typeof(decimal));
	tinvoicedetail_iva.defineColumn("discount", typeof(double));
	tinvoicedetail_iva.defineColumn("tax", typeof(decimal));
	tinvoicedetail_iva.defineColumn("unabatable", typeof(decimal));
	tinvoicedetail_iva.defineColumn("exchangerate", typeof(double));
	tinvoicedetail_iva.defineColumn("annotations", typeof(string));
	tinvoicedetail_iva.defineColumn("idmankind", typeof(string));
	tinvoicedetail_iva.defineColumn("mankind", typeof(string));
	tinvoicedetail_iva.defineColumn("yman", typeof(short));
	tinvoicedetail_iva.defineColumn("nman", typeof(int));
	tinvoicedetail_iva.defineColumn("manrownum", typeof(int));
	tinvoicedetail_iva.defineColumn("mandetaildescription", typeof(string));
	tinvoicedetail_iva.defineColumn("adate", typeof(DateTime),false);
	tinvoicedetail_iva.defineColumn("idexp_iva", typeof(int));
	tinvoicedetail_iva.defineColumn("idexp_taxable", typeof(int));
	tinvoicedetail_iva.defineColumn("idinc_iva", typeof(int));
	tinvoicedetail_iva.defineColumn("idinc_taxable", typeof(int));
	tinvoicedetail_iva.defineColumn("taxable_euro", typeof(decimal),true,true);
	tinvoicedetail_iva.defineColumn("iva_euro", typeof(decimal),true,true);
	tinvoicedetail_iva.defineColumn("rowtotal", typeof(decimal),true,true);
	tinvoicedetail_iva.defineColumn("cu", typeof(string),false);
	tinvoicedetail_iva.defineColumn("ct", typeof(DateTime),false);
	tinvoicedetail_iva.defineColumn("lu", typeof(string),false);
	tinvoicedetail_iva.defineColumn("lt", typeof(DateTime),false);
	tinvoicedetail_iva.defineColumn("idupb", typeof(string));
	tinvoicedetail_iva.defineColumn("idexp_taxablemand", typeof(int));
	tinvoicedetail_iva.defineColumn("idexp_ivamand", typeof(int));
	tinvoicedetail_iva.defineColumn("idestimkind", typeof(string));
	tinvoicedetail_iva.defineColumn("estimkind", typeof(string));
	tinvoicedetail_iva.defineColumn("estimatedetaildescription", typeof(string));
	tinvoicedetail_iva.defineColumn("yestim", typeof(short));
	tinvoicedetail_iva.defineColumn("nestim", typeof(int));
	tinvoicedetail_iva.defineColumn("estimrownum", typeof(int));
	tinvoicedetail_iva.defineColumn("va3type", typeof(string));
	tinvoicedetail_iva.defineColumn("idlist", typeof(int));
	tinvoicedetail_iva.defineColumn("idunit", typeof(int));
	tinvoicedetail_iva.defineColumn("idpackage", typeof(int));
	tinvoicedetail_iva.defineColumn("npackage", typeof(decimal));
	tinvoicedetail_iva.defineColumn("unitsforpackage", typeof(int));
	tinvoicedetail_iva.defineColumn("idupb_iva", typeof(string));
	tinvoicedetail_iva.defineColumn("idpccdebitmotive", typeof(string));
	tinvoicedetail_iva.defineColumn("idpccdebitstatus", typeof(string));
	tinvoicedetail_iva.defineColumn("expensekind", typeof(string));
	tinvoicedetail_iva.defineColumn("idaccmotive", typeof(string));
	tinvoicedetail_iva.defineColumn("ycon", typeof(int));
	tinvoicedetail_iva.defineColumn("ncon", typeof(int));
	tinvoicedetail_iva.defineColumn("idsor_siope", typeof(int));
	tinvoicedetail_iva.defineColumn("codesor_siope", typeof(string));
	tinvoicedetail_iva.defineColumn("intra12operationkind", typeof(string));
	tinvoicedetail_iva.defineColumn("intrastatoperationkind", typeof(string));
	Tables.Add(tinvoicedetail_iva);
	tinvoicedetail_iva.defineKey("idinvkind", "yinv", "ninv", "rownum");

	//////////////////// INVOICEDETAIL_TAXABLE /////////////////////////////////
	var tinvoicedetail_taxable= new MetaTable("invoicedetail_taxable");
	tinvoicedetail_taxable.defineColumn("idinvkind", typeof(int),false);
	tinvoicedetail_taxable.defineColumn("invoicekind", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("yinv", typeof(short),false);
	tinvoicedetail_taxable.defineColumn("ninv", typeof(int),false);
	tinvoicedetail_taxable.defineColumn("idgroup", typeof(int));
	tinvoicedetail_taxable.defineColumn("flag", typeof(byte),false);
	tinvoicedetail_taxable.defineColumn("flagbuysell", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("flagvariation", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("rownum", typeof(int),false);
	tinvoicedetail_taxable.defineColumn("detaildescription", typeof(string));
	tinvoicedetail_taxable.defineColumn("idivakind", typeof(int),false);
	tinvoicedetail_taxable.defineColumn("ivakind", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("rate", typeof(decimal),false);
	tinvoicedetail_taxable.defineColumn("unabatabilitypercentage", typeof(decimal),false);
	tinvoicedetail_taxable.defineColumn("number", typeof(decimal));
	tinvoicedetail_taxable.defineColumn("taxable", typeof(decimal));
	tinvoicedetail_taxable.defineColumn("discount", typeof(double));
	tinvoicedetail_taxable.defineColumn("tax", typeof(decimal));
	tinvoicedetail_taxable.defineColumn("unabatable", typeof(decimal));
	tinvoicedetail_taxable.defineColumn("exchangerate", typeof(double));
	tinvoicedetail_taxable.defineColumn("annotations", typeof(string));
	tinvoicedetail_taxable.defineColumn("idmankind", typeof(string));
	tinvoicedetail_taxable.defineColumn("mankind", typeof(string));
	tinvoicedetail_taxable.defineColumn("yman", typeof(short));
	tinvoicedetail_taxable.defineColumn("nman", typeof(int));
	tinvoicedetail_taxable.defineColumn("manrownum", typeof(int));
	tinvoicedetail_taxable.defineColumn("mandetaildescription", typeof(string));
	tinvoicedetail_taxable.defineColumn("adate", typeof(DateTime),false);
	tinvoicedetail_taxable.defineColumn("idexp_iva", typeof(int));
	tinvoicedetail_taxable.defineColumn("idexp_taxable", typeof(int));
	tinvoicedetail_taxable.defineColumn("idinc_iva", typeof(int));
	tinvoicedetail_taxable.defineColumn("idinc_taxable", typeof(int));
	tinvoicedetail_taxable.defineColumn("taxable_euro", typeof(decimal),true,true);
	tinvoicedetail_taxable.defineColumn("iva_euro", typeof(decimal),true,true);
	tinvoicedetail_taxable.defineColumn("rowtotal", typeof(decimal),true,true);
	tinvoicedetail_taxable.defineColumn("cu", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("ct", typeof(DateTime),false);
	tinvoicedetail_taxable.defineColumn("lu", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("lt", typeof(DateTime),false);
	tinvoicedetail_taxable.defineColumn("idupb", typeof(string));
	tinvoicedetail_taxable.defineColumn("idexp_taxablemand", typeof(int));
	tinvoicedetail_taxable.defineColumn("idexp_ivamand", typeof(int));
	tinvoicedetail_taxable.defineColumn("idestimkind", typeof(string));
	tinvoicedetail_taxable.defineColumn("estimkind", typeof(string));
	tinvoicedetail_taxable.defineColumn("estimatedetaildescription", typeof(string));
	tinvoicedetail_taxable.defineColumn("yestim", typeof(short));
	tinvoicedetail_taxable.defineColumn("nestim", typeof(int));
	tinvoicedetail_taxable.defineColumn("estimrownum", typeof(int));
	tinvoicedetail_taxable.defineColumn("va3type", typeof(string));
	tinvoicedetail_taxable.defineColumn("idlist", typeof(int));
	tinvoicedetail_taxable.defineColumn("idunit", typeof(int));
	tinvoicedetail_taxable.defineColumn("idpackage", typeof(int));
	tinvoicedetail_taxable.defineColumn("npackage", typeof(decimal));
	tinvoicedetail_taxable.defineColumn("unitsforpackage", typeof(int));
	tinvoicedetail_taxable.defineColumn("idupb_iva", typeof(string));
	tinvoicedetail_taxable.defineColumn("idpccdebitmotive", typeof(string));
	tinvoicedetail_taxable.defineColumn("idpccdebitstatus", typeof(string));
	tinvoicedetail_taxable.defineColumn("expensekind", typeof(string));
	tinvoicedetail_taxable.defineColumn("idaccmotive", typeof(string));
	tinvoicedetail_taxable.defineColumn("ycon", typeof(int));
	tinvoicedetail_taxable.defineColumn("ncon", typeof(int));
	tinvoicedetail_taxable.defineColumn("idsor_siope", typeof(int));
	tinvoicedetail_taxable.defineColumn("codesor_siope", typeof(string));
	tinvoicedetail_taxable.defineColumn("intra12operationkind", typeof(string));
	tinvoicedetail_taxable.defineColumn("intrastatoperationkind", typeof(string));
	Tables.Add(tinvoicedetail_taxable);
	tinvoicedetail_taxable.defineKey("idinvkind", "yinv", "ninv", "rownum");

	//////////////////// EXPENSELAST /////////////////////////////////
	var texpenselast= new expenselastTable();
	texpenselast.addBaseColumns("idexp","cc","cin","flag","iban","idbank","idcab","iddeputy","idpaymethod","idser","ivaamount","kpay","paymentdescr","servicestart","servicestop","nbill","idpay","idregistrypaymethod","refexternaldoc","cu","ct","lu","lt","idaccdebit","biccode","paymethod_flag","paymethod_allowdeputy","extracode","idchargehandling","pagopanoticenum");
	Tables.Add(texpenselast);
	texpenselast.defineKey("idexp");

	//////////////////// BILLVIEW /////////////////////////////////
	var tbillview= new MetaTable("billview");
	tbillview.defineColumn("ybill", typeof(short),false);
	tbillview.defineColumn("nbill", typeof(int),false);
	tbillview.defineColumn("billkind", typeof(string),false);
	tbillview.defineColumn("active", typeof(string));
	tbillview.defineColumn("adate", typeof(DateTime));
	tbillview.defineColumn("registry", typeof(string));
	tbillview.defineColumn("motive", typeof(string));
	tbillview.defineColumn("total", typeof(decimal));
	tbillview.defineColumn("covered", typeof(decimal));
	tbillview.defineColumn("toregularize", typeof(decimal));
	tbillview.defineColumn("cu", typeof(string),false);
	tbillview.defineColumn("ct", typeof(DateTime),false);
	tbillview.defineColumn("lu", typeof(string),false);
	tbillview.defineColumn("lt", typeof(DateTime),false);
	tbillview.defineColumn("idtreasurer", typeof(int));
	tbillview.defineColumn("treasurer", typeof(string));
	tbillview.defineColumn("regularizationnote", typeof(string));
	tbillview.defineColumn("idsor01", typeof(int));
	tbillview.defineColumn("idsor02", typeof(int));
	tbillview.defineColumn("idsor03", typeof(int));
	tbillview.defineColumn("idsor04", typeof(int));
	tbillview.defineColumn("idsor05", typeof(int));
	Tables.Add(tbillview);
	tbillview.defineKey("ybill", "nbill", "billkind");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idregauto","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart","idivapayperiodicity","idsortingkind1","idsortingkind2","idsortingkind3","fin_kind","taxvaliditykind","flag_paymentamount","automanagekind","flag_autodocnumbering","flagbank_grouping","cashvaliditykind","flag");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// PAYMENT /////////////////////////////////
	var tpayment= new paymentTable();
	tpayment.addBaseColumns("npay","npay_treasurer","ypay","adate","annulmentdate","ct","cu","idreg","lt","lu","printdate","rtf","txt","idfin","idman","idstamphandling","idtreasurer","flag","kpay","kpaymenttransmission","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tpayment);
	tpayment.defineKey("kpay");

	//////////////////// FORMEREXPENSE /////////////////////////////////
	var tformerexpense= new MetaTable("formerexpense");
	tformerexpense.defineColumn("adate", typeof(DateTime),false);
	tformerexpense.defineColumn("ct", typeof(DateTime),false);
	tformerexpense.defineColumn("cu", typeof(string),false);
	tformerexpense.defineColumn("description", typeof(string),false);
	tformerexpense.defineColumn("doc", typeof(string));
	tformerexpense.defineColumn("docdate", typeof(DateTime));
	tformerexpense.defineColumn("expiration", typeof(DateTime));
	tformerexpense.defineColumn("idreg", typeof(int));
	tformerexpense.defineColumn("lt", typeof(DateTime),false);
	tformerexpense.defineColumn("lu", typeof(string),false);
	tformerexpense.defineColumn("nmov", typeof(int),false);
	tformerexpense.defineColumn("rtf", typeof(Byte[]));
	tformerexpense.defineColumn("txt", typeof(string));
	tformerexpense.defineColumn("ymov", typeof(short),false);
	tformerexpense.defineColumn("idclawback", typeof(int));
	tformerexpense.defineColumn("idexp", typeof(int),false);
	tformerexpense.defineColumn("parentidexp", typeof(int));
	tformerexpense.defineColumn("idpayment", typeof(int));
	tformerexpense.defineColumn("idformerexpense", typeof(int));
	tformerexpense.defineColumn("nphase", typeof(byte),false);
	tformerexpense.defineColumn("idman", typeof(int));
	tformerexpense.defineColumn("autokind", typeof(byte));
	tformerexpense.defineColumn("autocode", typeof(int));
	Tables.Add(tformerexpense);
	tformerexpense.defineKey("idexp");

	//////////////////// EXPENSETAXCORRIGE /////////////////////////////////
	var texpensetaxcorrige= new MetaTable("expensetaxcorrige");
	texpensetaxcorrige.defineColumn("idexp", typeof(int),false);
	texpensetaxcorrige.defineColumn("idexpensetaxcorrige", typeof(int),false);
	texpensetaxcorrige.defineColumn("taxcode", typeof(int),false);
	texpensetaxcorrige.defineColumn("ayear", typeof(short),false);
	texpensetaxcorrige.defineColumn("employamount", typeof(decimal));
	texpensetaxcorrige.defineColumn("adminamount", typeof(decimal));
	texpensetaxcorrige.defineColumn("idcity", typeof(int));
	texpensetaxcorrige.defineColumn("idfiscaltaxregion", typeof(string));
	texpensetaxcorrige.defineColumn("linkedidinc", typeof(int));
	texpensetaxcorrige.defineColumn("linkedidexp", typeof(int));
	texpensetaxcorrige.defineColumn("ytaxpay", typeof(short));
	texpensetaxcorrige.defineColumn("ntaxpay", typeof(int));
	texpensetaxcorrige.defineColumn("adate", typeof(DateTime));
	texpensetaxcorrige.defineColumn("ct", typeof(DateTime),false);
	texpensetaxcorrige.defineColumn("cu", typeof(string),false);
	texpensetaxcorrige.defineColumn("lt", typeof(DateTime),false);
	texpensetaxcorrige.defineColumn("lu", typeof(string),false);
	texpensetaxcorrige.defineColumn("!taxref", typeof(string));
	texpensetaxcorrige.defineColumn("!description", typeof(string));
	texpensetaxcorrige.defineColumn("!city", typeof(string));
	texpensetaxcorrige.defineColumn("!fiscaltaxregion", typeof(string));
	Tables.Add(texpensetaxcorrige);
	texpensetaxcorrige.defineKey("idexp", "idexpensetaxcorrige");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new geo_cityTable();
	tgeo_city.addBaseColumns("idcity","title");
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// FISCALTAXREGION /////////////////////////////////
	var tfiscaltaxregion= new MetaTable("fiscaltaxregion");
	tfiscaltaxregion.defineColumn("idfiscaltaxregion", typeof(string),false);
	tfiscaltaxregion.defineColumn("title", typeof(string),false);
	tfiscaltaxregion.defineColumn("active", typeof(string),false);
	Tables.Add(tfiscaltaxregion);
	tfiscaltaxregion.defineKey("idfiscaltaxregion");

	//////////////////// EXPENSETAXOFFICIAL /////////////////////////////////
	var texpensetaxofficial= new MetaTable("expensetaxofficial");
	texpensetaxofficial.defineColumn("idexp", typeof(int),false);
	texpensetaxofficial.defineColumn("idexpensetaxofficial", typeof(int),false);
	texpensetaxofficial.defineColumn("taxcode", typeof(int),false);
	texpensetaxofficial.defineColumn("nbracket", typeof(int),false);
	texpensetaxofficial.defineColumn("ayear", typeof(short),false);
	texpensetaxofficial.defineColumn("taxabledenominator", typeof(decimal));
	texpensetaxofficial.defineColumn("taxablenumerator", typeof(decimal));
	texpensetaxofficial.defineColumn("taxablegross", typeof(decimal));
	texpensetaxofficial.defineColumn("exemptionquota", typeof(decimal));
	texpensetaxofficial.defineColumn("taxablenet", typeof(decimal));
	texpensetaxofficial.defineColumn("adminrate", typeof(decimal));
	texpensetaxofficial.defineColumn("admindenominator", typeof(decimal));
	texpensetaxofficial.defineColumn("adminnumerator", typeof(decimal));
	texpensetaxofficial.defineColumn("admintax", typeof(decimal));
	texpensetaxofficial.defineColumn("employrate", typeof(decimal));
	texpensetaxofficial.defineColumn("employdenominator", typeof(decimal));
	texpensetaxofficial.defineColumn("employnumerator", typeof(decimal));
	texpensetaxofficial.defineColumn("employtax", typeof(decimal));
	texpensetaxofficial.defineColumn("abatements", typeof(decimal));
	texpensetaxofficial.defineColumn("start", typeof(DateTime));
	texpensetaxofficial.defineColumn("stop", typeof(DateTime));
	texpensetaxofficial.defineColumn("ct", typeof(DateTime),false);
	texpensetaxofficial.defineColumn("cu", typeof(string),false);
	texpensetaxofficial.defineColumn("lt", typeof(DateTime),false);
	texpensetaxofficial.defineColumn("lu", typeof(string),false);
	texpensetaxofficial.defineColumn("idcity", typeof(int));
	texpensetaxofficial.defineColumn("idfiscaltaxregion", typeof(string));
	texpensetaxofficial.defineColumn("!taxref", typeof(string));
	texpensetaxofficial.defineColumn("!description", typeof(string));
	Tables.Add(texpensetaxofficial);
	texpensetaxofficial.defineKey("idexp", "idexpensetaxofficial");

	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new accountTable();
	taccount.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	Tables.Add(taccount);
	taccount.defineKey("idacc");

	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new underwritingTable();
	tunderwriting.addBaseColumns("idunderwriting","idunderwriter","idsor01","idsor02","idsor03","idsor04","idsor05","cu","ct","lu","lt","title","active","doc","docdate","codeunderwriting");
	Tables.Add(tunderwriting);
	tunderwriting.defineKey("idunderwriting");

	//////////////////// UNDERWRITINGAPPROPRIATION /////////////////////////////////
	var tunderwritingappropriation= new MetaTable("underwritingappropriation");
	tunderwritingappropriation.defineColumn("idunderwriting", typeof(int),false);
	tunderwritingappropriation.defineColumn("idexp", typeof(int),false);
	tunderwritingappropriation.defineColumn("amount", typeof(decimal),false);
	tunderwritingappropriation.defineColumn("ct", typeof(DateTime),false);
	tunderwritingappropriation.defineColumn("cu", typeof(string),false);
	tunderwritingappropriation.defineColumn("lt", typeof(DateTime),false);
	tunderwritingappropriation.defineColumn("lu", typeof(string),false);
	tunderwritingappropriation.defineColumn("!underwriting", typeof(string));
	tunderwritingappropriation.defineColumn("!codeunderwriting", typeof(string));
	Tables.Add(tunderwritingappropriation);
	tunderwritingappropriation.defineKey("idunderwriting", "idexp");

	//////////////////// UNDERWRITINGPAYMENT /////////////////////////////////
	var tunderwritingpayment= new MetaTable("underwritingpayment");
	tunderwritingpayment.defineColumn("idunderwriting", typeof(int),false);
	tunderwritingpayment.defineColumn("idexp", typeof(int),false);
	tunderwritingpayment.defineColumn("amount", typeof(decimal),false);
	tunderwritingpayment.defineColumn("ct", typeof(DateTime),false);
	tunderwritingpayment.defineColumn("cu", typeof(string),false);
	tunderwritingpayment.defineColumn("lt", typeof(DateTime),false);
	tunderwritingpayment.defineColumn("lu", typeof(string),false);
	tunderwritingpayment.defineColumn("!underwriting", typeof(string));
	tunderwritingpayment.defineColumn("!codeunderwriting", typeof(string));
	Tables.Add(tunderwritingpayment);
	tunderwritingpayment.defineKey("idunderwriting", "idexp");

	//////////////////// UNDERWRITING_VAR /////////////////////////////////
	var tunderwriting_var= new MetaTable("underwriting_var");
	tunderwriting_var.defineColumn("idunderwriting", typeof(int),false);
	tunderwriting_var.defineColumn("idunderwriter", typeof(int));
	tunderwriting_var.defineColumn("idsor01", typeof(int));
	tunderwriting_var.defineColumn("idsor02", typeof(int));
	tunderwriting_var.defineColumn("idsor03", typeof(int));
	tunderwriting_var.defineColumn("idsor04", typeof(int));
	tunderwriting_var.defineColumn("idsor05", typeof(int));
	tunderwriting_var.defineColumn("cu", typeof(string),false);
	tunderwriting_var.defineColumn("ct", typeof(DateTime),false);
	tunderwriting_var.defineColumn("lu", typeof(string),false);
	tunderwriting_var.defineColumn("lt", typeof(DateTime),false);
	tunderwriting_var.defineColumn("title", typeof(string),false);
	tunderwriting_var.defineColumn("active", typeof(string));
	tunderwriting_var.defineColumn("doc", typeof(string));
	tunderwriting_var.defineColumn("docdate", typeof(DateTime));
	tunderwriting_var.defineColumn("codeunderwriting", typeof(string));
	Tables.Add(tunderwriting_var);
	tunderwriting_var.defineKey("idunderwriting");

	//////////////////// LOOKUP_TIPORIGAF24EP /////////////////////////////////
	var tlookup_tiporigaf24ep= new MetaTable("lookup_tiporigaf24ep");
	tlookup_tiporigaf24ep.defineColumn("tiporiga", typeof(string),false);
	tlookup_tiporigaf24ep.defineColumn("description", typeof(string));
	Tables.Add(tlookup_tiporigaf24ep);
	tlookup_tiporigaf24ep.defineKey("tiporiga");

	//////////////////// MONTHNAME2 /////////////////////////////////
	var tmonthname2= new MetaTable("monthname2");
	tmonthname2.defineColumn("code", typeof(int),false);
	tmonthname2.defineColumn("cfvalue", typeof(string));
	tmonthname2.defineColumn("title", typeof(string));
	Tables.Add(tmonthname2);
	tmonthname2.defineKey("code");

	//////////////////// MONTHNAME1 /////////////////////////////////
	var tmonthname1= new MetaTable("monthname1");
	tmonthname1.defineColumn("code", typeof(int),false);
	tmonthname1.defineColumn("cfvalue", typeof(string));
	tmonthname1.defineColumn("title", typeof(string));
	Tables.Add(tmonthname1);
	tmonthname1.defineKey("code");

	//////////////////// EXPENSEBILL /////////////////////////////////
	var texpensebill= new MetaTable("expensebill");
	texpensebill.defineColumn("idexp", typeof(int),false);
	texpensebill.defineColumn("ybill", typeof(short),false);
	texpensebill.defineColumn("nbill", typeof(int),false);
	texpensebill.defineColumn("amount", typeof(decimal),false);
	texpensebill.defineColumn("ct", typeof(DateTime),false);
	texpensebill.defineColumn("cu", typeof(string),false);
	texpensebill.defineColumn("lt", typeof(DateTime),false);
	texpensebill.defineColumn("lu", typeof(string),false);
	texpensebill.defineColumn("!anagrafica", typeof(string));
	texpensebill.defineColumn("!data", typeof(string));
	texpensebill.defineColumn("!causale", typeof(string));
	Tables.Add(texpensebill);
	texpensebill.defineKey("idexp", "ybill", "nbill");

	//////////////////// CHARGEHANDLING /////////////////////////////////
	var tchargehandling= new MetaTable("chargehandling");
	tchargehandling.defineColumn("active", typeof(string));
	tchargehandling.defineColumn("ct", typeof(DateTime),false);
	tchargehandling.defineColumn("cu", typeof(string),false);
	tchargehandling.defineColumn("description", typeof(string),false);
	tchargehandling.defineColumn("lt", typeof(DateTime),false);
	tchargehandling.defineColumn("lu", typeof(string),false);
	tchargehandling.defineColumn("handlingbankcode", typeof(string));
	tchargehandling.defineColumn("flag", typeof(int));
	tchargehandling.defineColumn("idchargehandling", typeof(int),false);
	tchargehandling.defineColumn("motive", typeof(string));
	tchargehandling.defineColumn("payment_kind", typeof(string));
	Tables.Add(tchargehandling);
	tchargehandling.defineKey("idchargehandling");

	//////////////////// BILL1 /////////////////////////////////
	var tbill1= new MetaTable("bill1");
	tbill1.defineColumn("ybill", typeof(short),false);
	tbill1.defineColumn("nbill", typeof(int),false);
	tbill1.defineColumn("billkind", typeof(string),false);
	tbill1.defineColumn("registry", typeof(string));
	tbill1.defineColumn("covered", typeof(decimal));
	tbill1.defineColumn("total", typeof(decimal));
	tbill1.defineColumn("adate", typeof(DateTime));
	tbill1.defineColumn("active", typeof(string));
	tbill1.defineColumn("motive", typeof(string));
	tbill1.defineColumn("ct", typeof(DateTime),false);
	tbill1.defineColumn("cu", typeof(string),false);
	tbill1.defineColumn("lt", typeof(DateTime),false);
	tbill1.defineColumn("lu", typeof(string),false);
	tbill1.defineColumn("idtreasurer", typeof(int));
	tbill1.defineColumn("regularizationnote", typeof(string));
	tbill1.defineColumn("reduction", typeof(decimal));
	tbill1.defineColumn("banknum", typeof(int));
	tbill1.defineColumn("idbank", typeof(string));
	Tables.Add(tbill1);
	tbill1.defineKey("ybill", "nbill", "billkind");

	//////////////////// INVOICEDETAIL_IVA_NC /////////////////////////////////
	var tinvoicedetail_iva_nc= new MetaTable("invoicedetail_iva_nc");
	tinvoicedetail_iva_nc.defineColumn("ninv", typeof(int),false);
	tinvoicedetail_iva_nc.defineColumn("rownum", typeof(int),false);
	tinvoicedetail_iva_nc.defineColumn("yinv", typeof(short),false);
	tinvoicedetail_iva_nc.defineColumn("annotations", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("competencystart", typeof(DateTime));
	tinvoicedetail_iva_nc.defineColumn("paymentcompetency", typeof(DateTime));
	tinvoicedetail_iva_nc.defineColumn("competencystop", typeof(DateTime));
	tinvoicedetail_iva_nc.defineColumn("ct", typeof(DateTime),false);
	tinvoicedetail_iva_nc.defineColumn("cu", typeof(string),false);
	tinvoicedetail_iva_nc.defineColumn("detaildescription", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("discount", typeof(double));
	tinvoicedetail_iva_nc.defineColumn("idaccmotive", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idmankind", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idupb", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("lt", typeof(DateTime),false);
	tinvoicedetail_iva_nc.defineColumn("lu", typeof(string),false);
	tinvoicedetail_iva_nc.defineColumn("manrownum", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("nman", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("number", typeof(decimal));
	tinvoicedetail_iva_nc.defineColumn("tax", typeof(decimal));
	tinvoicedetail_iva_nc.defineColumn("taxable", typeof(decimal));
	tinvoicedetail_iva_nc.defineColumn("unabatable", typeof(decimal));
	tinvoicedetail_iva_nc.defineColumn("yman", typeof(short));
	tinvoicedetail_iva_nc.defineColumn("idestimkind", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("estimrownum", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("nestim", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("yestim", typeof(short));
	tinvoicedetail_iva_nc.defineColumn("idgroup", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idexp_taxable", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idexp_iva", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idinc_taxable", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idinc_iva", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("ninv_main", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("yinv_main", typeof(short));
	tinvoicedetail_iva_nc.defineColumn("idivakind", typeof(int),false);
	tinvoicedetail_iva_nc.defineColumn("idinvkind", typeof(int),false);
	tinvoicedetail_iva_nc.defineColumn("idsor1", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idsor2", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idsor3", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idintrastatcode", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idintrastatmeasure", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("weight", typeof(decimal));
	tinvoicedetail_iva_nc.defineColumn("va3type", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("intrastatoperationkind", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idintrastatservice", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idintrastatsupplymethod", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idlist", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idunit", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idpackage", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("unitsforpackage", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("npackage", typeof(decimal));
	tinvoicedetail_iva_nc.defineColumn("flag", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("exception12", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("intra12operationkind", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("move12", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idupb_iva", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idinvkind_main", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("leasing", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("usedmodesospesometro", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idfetransfer", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("fereferencerule", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("cupcode", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("cigcode", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idpccdebitstatus", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idpccdebitmotive", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idcostpartition", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("expensekind", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("rounding", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idepexp", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idepacc", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("flagbit", typeof(byte));
	tinvoicedetail_iva_nc.defineColumn("idfinmotive", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("iduniqueformcode", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("ycon", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("ncon", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("codicevalore", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("codicetipo", typeof(string));
	tinvoicedetail_iva_nc.defineColumn("idsor_siope", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("idepexp_pre", typeof(int));
	tinvoicedetail_iva_nc.defineColumn("rownum_main", typeof(int));
	Tables.Add(tinvoicedetail_iva_nc);
	tinvoicedetail_iva_nc.defineKey("ninv", "rownum", "yinv", "idinvkind");

	//////////////////// INVOICEDETAIL_TAXABLE_NC /////////////////////////////////
	var tinvoicedetail_taxable_nc= new MetaTable("invoicedetail_taxable_nc");
	tinvoicedetail_taxable_nc.defineColumn("ninv", typeof(int),false);
	tinvoicedetail_taxable_nc.defineColumn("rownum", typeof(int),false);
	tinvoicedetail_taxable_nc.defineColumn("yinv", typeof(short),false);
	tinvoicedetail_taxable_nc.defineColumn("annotations", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("competencystart", typeof(DateTime));
	tinvoicedetail_taxable_nc.defineColumn("paymentcompetency", typeof(DateTime));
	tinvoicedetail_taxable_nc.defineColumn("competencystop", typeof(DateTime));
	tinvoicedetail_taxable_nc.defineColumn("ct", typeof(DateTime),false);
	tinvoicedetail_taxable_nc.defineColumn("cu", typeof(string),false);
	tinvoicedetail_taxable_nc.defineColumn("detaildescription", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("discount", typeof(double));
	tinvoicedetail_taxable_nc.defineColumn("idaccmotive", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idmankind", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idupb", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("lt", typeof(DateTime),false);
	tinvoicedetail_taxable_nc.defineColumn("lu", typeof(string),false);
	tinvoicedetail_taxable_nc.defineColumn("manrownum", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("nman", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("number", typeof(decimal));
	tinvoicedetail_taxable_nc.defineColumn("tax", typeof(decimal));
	tinvoicedetail_taxable_nc.defineColumn("taxable", typeof(decimal));
	tinvoicedetail_taxable_nc.defineColumn("unabatable", typeof(decimal));
	tinvoicedetail_taxable_nc.defineColumn("yman", typeof(short));
	tinvoicedetail_taxable_nc.defineColumn("idestimkind", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("estimrownum", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("nestim", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("yestim", typeof(short));
	tinvoicedetail_taxable_nc.defineColumn("idgroup", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idexp_taxable", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idexp_iva", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idinc_taxable", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idinc_iva", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("ninv_main", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("yinv_main", typeof(short));
	tinvoicedetail_taxable_nc.defineColumn("idivakind", typeof(int),false);
	tinvoicedetail_taxable_nc.defineColumn("idinvkind", typeof(int),false);
	tinvoicedetail_taxable_nc.defineColumn("idsor1", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idsor2", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idsor3", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idintrastatcode", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idintrastatmeasure", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("weight", typeof(decimal));
	tinvoicedetail_taxable_nc.defineColumn("va3type", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("intrastatoperationkind", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idintrastatservice", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idintrastatsupplymethod", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idlist", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idunit", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idpackage", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("unitsforpackage", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("npackage", typeof(decimal));
	tinvoicedetail_taxable_nc.defineColumn("flag", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("exception12", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("intra12operationkind", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("move12", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idupb_iva", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idinvkind_main", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("leasing", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("usedmodesospesometro", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idfetransfer", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("fereferencerule", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("cupcode", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("cigcode", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idpccdebitstatus", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idpccdebitmotive", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idcostpartition", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("expensekind", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("rounding", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idepexp", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idepacc", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("flagbit", typeof(byte));
	tinvoicedetail_taxable_nc.defineColumn("idfinmotive", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("iduniqueformcode", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("ycon", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("ncon", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("codicevalore", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("codicetipo", typeof(string));
	tinvoicedetail_taxable_nc.defineColumn("idsor_siope", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("idepexp_pre", typeof(int));
	tinvoicedetail_taxable_nc.defineColumn("rownum_main", typeof(int));
	Tables.Add(tinvoicedetail_taxable_nc);
	tinvoicedetail_taxable_nc.defineKey("ninv", "rownum", "yinv", "idinvkind");

	//////////////////// INCOME_LINKED /////////////////////////////////
	var tincome_linked= new MetaTable("income_linked");
	tincome_linked.defineColumn("adate", typeof(DateTime),false);
	tincome_linked.defineColumn("ct", typeof(DateTime),false);
	tincome_linked.defineColumn("cu", typeof(string),false);
	tincome_linked.defineColumn("description", typeof(string),false);
	tincome_linked.defineColumn("doc", typeof(string));
	tincome_linked.defineColumn("docdate", typeof(DateTime));
	tincome_linked.defineColumn("expiration", typeof(DateTime));
	tincome_linked.defineColumn("idreg", typeof(int));
	tincome_linked.defineColumn("lt", typeof(DateTime),false);
	tincome_linked.defineColumn("lu", typeof(string),false);
	tincome_linked.defineColumn("nmov", typeof(int),false);
	tincome_linked.defineColumn("rtf", typeof(Byte[]));
	tincome_linked.defineColumn("txt", typeof(string));
	tincome_linked.defineColumn("ymov", typeof(short),false);
	tincome_linked.defineColumn("idpayment", typeof(int));
	tincome_linked.defineColumn("idinc", typeof(int),false);
	tincome_linked.defineColumn("parentidinc", typeof(int));
	tincome_linked.defineColumn("nphase", typeof(byte),false);
	tincome_linked.defineColumn("idman", typeof(int));
	tincome_linked.defineColumn("autokind", typeof(byte));
	tincome_linked.defineColumn("autocode", typeof(int));
	tincome_linked.defineColumn("cupcode", typeof(string));
	tincome_linked.defineColumn("idunderwriting", typeof(int));
	tincome_linked.defineColumn("external_reference", typeof(string));
	Tables.Add(tincome_linked);
	tincome_linked.defineKey("idinc");

	//////////////////// MANDATEDETAIL_PAGAMENTI /////////////////////////////////
	var tmandatedetail_pagamenti= new MetaTable("mandatedetail_pagamenti");
	tmandatedetail_pagamenti.defineColumn("idmankind", typeof(string),false);
	tmandatedetail_pagamenti.defineColumn("nman", typeof(int),false);
	tmandatedetail_pagamenti.defineColumn("rownum", typeof(int),false);
	tmandatedetail_pagamenti.defineColumn("yman", typeof(short),false);
	tmandatedetail_pagamenti.defineColumn("annotations", typeof(string));
	tmandatedetail_pagamenti.defineColumn("assetkind", typeof(string),false);
	tmandatedetail_pagamenti.defineColumn("competencystart", typeof(DateTime));
	tmandatedetail_pagamenti.defineColumn("competencystop", typeof(DateTime));
	tmandatedetail_pagamenti.defineColumn("ct", typeof(DateTime),false);
	tmandatedetail_pagamenti.defineColumn("cu", typeof(string),false);
	tmandatedetail_pagamenti.defineColumn("detaildescription", typeof(string));
	tmandatedetail_pagamenti.defineColumn("discount", typeof(double));
	tmandatedetail_pagamenti.defineColumn("idupb", typeof(string));
	tmandatedetail_pagamenti.defineColumn("lt", typeof(DateTime),false);
	tmandatedetail_pagamenti.defineColumn("lu", typeof(string),false);
	tmandatedetail_pagamenti.defineColumn("ninvoiced", typeof(decimal));
	tmandatedetail_pagamenti.defineColumn("number", typeof(decimal));
	tmandatedetail_pagamenti.defineColumn("start", typeof(DateTime));
	tmandatedetail_pagamenti.defineColumn("stop", typeof(DateTime));
	tmandatedetail_pagamenti.defineColumn("tax", typeof(decimal));
	tmandatedetail_pagamenti.defineColumn("taxable", typeof(decimal));
	tmandatedetail_pagamenti.defineColumn("taxrate", typeof(double));
	tmandatedetail_pagamenti.defineColumn("toinvoice", typeof(string));
	tmandatedetail_pagamenti.defineColumn("flagmixed", typeof(string));
	tmandatedetail_pagamenti.defineColumn("idaccmotive", typeof(string));
	tmandatedetail_pagamenti.defineColumn("unabatable", typeof(decimal));
	tmandatedetail_pagamenti.defineColumn("idgroup", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idreg", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idexp_taxable", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idexp_iva", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idinv", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idivakind", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idsor1", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idsor2", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idsor3", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idaccmotiveannulment", typeof(string));
	tmandatedetail_pagamenti.defineColumn("flagactivity", typeof(short));
	tmandatedetail_pagamenti.defineColumn("va3type", typeof(string));
	tmandatedetail_pagamenti.defineColumn("applierannotations", typeof(string));
	tmandatedetail_pagamenti.defineColumn("ivanotes", typeof(string));
	tmandatedetail_pagamenti.defineColumn("idlist", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idunit", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idpackage", typeof(int));
	tmandatedetail_pagamenti.defineColumn("unitsforpackage", typeof(int));
	tmandatedetail_pagamenti.defineColumn("npackage", typeof(decimal));
	tmandatedetail_pagamenti.defineColumn("cupcode", typeof(string));
	tmandatedetail_pagamenti.defineColumn("cigcode", typeof(string));
	tmandatedetail_pagamenti.defineColumn("flagto_unload", typeof(string));
	tmandatedetail_pagamenti.defineColumn("epkind", typeof(string));
	tmandatedetail_pagamenti.defineColumn("rownum_origin", typeof(int));
	tmandatedetail_pagamenti.defineColumn("contractamount", typeof(decimal));
	tmandatedetail_pagamenti.defineColumn("idavcp", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idavcp_choice", typeof(int));
	tmandatedetail_pagamenti.defineColumn("avcp_startcontract", typeof(DateTime));
	tmandatedetail_pagamenti.defineColumn("avcp_stopcontract", typeof(DateTime));
	tmandatedetail_pagamenti.defineColumn("avcp_description", typeof(string));
	tmandatedetail_pagamenti.defineColumn("idpccdebitmotive", typeof(string));
	tmandatedetail_pagamenti.defineColumn("idpccdebitstatus", typeof(string));
	tmandatedetail_pagamenti.defineColumn("idcostpartition", typeof(int));
	tmandatedetail_pagamenti.defineColumn("expensekind", typeof(string));
	tmandatedetail_pagamenti.defineColumn("idepexp", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idepacc", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idlocation", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idupb_iva", typeof(string));
	tmandatedetail_pagamenti.defineColumn("idsor_siope", typeof(int));
	tmandatedetail_pagamenti.defineColumn("idepexp_pre", typeof(int));
	tmandatedetail_pagamenti.defineColumn("rownum_main", typeof(int));
	Tables.Add(tmandatedetail_pagamenti);
	tmandatedetail_pagamenti.defineKey("idmankind", "nman", "rownum", "yman");

	#endregion


	#region DataRelation creation
	this.defineRelation("expense_expensebill","expense","expensebill","idexp");
	this.defineRelation("FK_bill1_expensebill","bill1","expensebill","ybill","nbill");
	this.defineRelation("underwriting_underwritingpayment","underwriting","underwritingpayment","idunderwriting");
	this.defineRelation("expense_underwritingpayment","expense","underwritingpayment","idexp");
	this.defineRelation("underwriting_underwritingexpense","underwriting","underwritingappropriation","idunderwriting");
	this.defineRelation("expense_underwritingappropriation","expense","underwritingappropriation","idexp");
	this.defineRelation("expenseexpensetaxofficial","expense","expensetaxofficial","idexp");
	this.defineRelation("taxexpensetaxofficial","tax","expensetaxofficial","taxcode");
	this.defineRelation("fiscaltaxregionexpensetaxcorrige","fiscaltaxregion","expensetaxcorrige","idfiscaltaxregion");
	this.defineRelation("geo_cityexpensetaxcorrige","geo_city","expensetaxcorrige","idcity");
	this.defineRelation("taxexpensetaxcorrige","tax","expensetaxcorrige","taxcode");
	this.defineRelation("expenseexpensetaxcorrige","expense","expensetaxcorrige","idexp");
	var cPar = new []{account.Columns["idacc"]};
	var cChild = new []{expenselast.Columns["idaccdebit"]};
	Relations.Add(new DataRelation("account_expenselast",cPar,cChild,false));

	this.defineRelation("expense_expenselast","expense","expenselast","idexp");
	cPar = new []{deputy.Columns["idreg"]};
	cChild = new []{expenselast.Columns["iddeputy"]};
	Relations.Add(new DataRelation("deputy_expenselast",cPar,cChild,false));

	this.defineRelation("service_expenselast","service","expenselast","idser");
	this.defineRelation("bill_expenselast","bill","expenselast","nbill");
	this.defineRelation("payment_expenselast","payment","expenselast","kpay");
	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{invoicedetail_taxable.Columns["idexp_taxable"]};
	Relations.Add(new DataRelation("expenseinvoicedetail_taxable",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{invoicedetail_taxable.Columns["idexp_iva"]};
	Relations.Add(new DataRelation("expenseinvoicedetail_taxable1",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{invoicedetail_iva.Columns["idexp_iva"]};
	Relations.Add(new DataRelation("expenseinvoicedetail_iva",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{mandatedetail_taxable.Columns["idexp_iva"]};
	Relations.Add(new DataRelation("expensemandatedetail_taxable1",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{mandatedetail_taxable.Columns["idexp_taxable"]};
	Relations.Add(new DataRelation("expensemandatedetail_taxable",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{mandatedetail_iva.Columns["idexp_iva"]};
	Relations.Add(new DataRelation("expensemandatedetail_iva",cPar,cChild,false));

	this.defineRelation("wageadditionwageadditionexpensetax","wageaddition","wageadditiontax","ycon","ncon");
	this.defineRelation("expenseexpensewageaddition","expense","expensewageaddition","idexp");
	this.defineRelation("wageadditionexpensewageaddition","wageaddition","expensewageaddition","ycon","ncon");
	this.defineRelation("profserviceprofservicetax","profservice","profservicetax","ycon","ncon");
	this.defineRelation("profserviceexpenseprofservice","profservice","expenseprofservice","ycon","ncon");
	this.defineRelation("expenseexpenseprofservice","expense","expenseprofservice","idexp");
	this.defineRelation("expenseexpensecasualcontract","expense","expensecasualcontract","idexp");
	this.defineRelation("casualcontractexpensecasualcontract","casualcontract","expensecasualcontract","ycon","ncon");
	this.defineRelation("payrollpayrolltax","payroll","payrolltax","idpayroll");
	this.defineRelation("expenseexpensepayroll","expense","expensepayroll","idexp");
	this.defineRelation("payrollexpensepayroll","payroll","expensepayroll","idpayroll");
	this.defineRelation("invoiceexpenseinvoice","invoice","expenseinvoice","idinvkind","yinv","ninv");
	this.defineRelation("expenseexpenseinvoice","expense","expenseinvoice","idexp");
	this.defineRelation("invoicekindinvoice","invoicekind","invoice","idinvkind");
	this.defineRelation("itineration_itinerationtaxview","itineration","itinerationtaxview","iditineration");
	this.defineRelation("expenseexpenseitineration","expense","expenseitineration","idexp");
	this.defineRelation("itineration_expenseitineration","itineration","expenseitineration","iditineration");
	this.defineRelation("expenseexpensemandate","expense","expensemandate","idexp");
	this.defineRelation("mandateexpensemandate","mandate","expensemandate","idmankind","yman","nman");
	this.defineRelation("mandatekindmandate","mandatekind","mandate","idmankind");
	this.defineRelation("underwriting_var_expensevar","underwriting_var","expensevar","idunderwriting");
	this.defineRelation("expenseexpensevar","expense","expensevar","idexp");
	cPar = new []{expense.Columns["nphase"]};
	cChild = new []{sortingkind.Columns["nphaseexpense"]};
	Relations.Add(new DataRelation("expensesortingkind",cPar,cChild,false));

	this.defineRelation("expenseexpensesorted","expense","expensesorted","idexp");
	this.defineRelation("sortingexpensesorted","sorting","expensesorted","idsor");
	this.defineRelation("expenseexpenseyear","expense","expenseyear","idexp");
	this.defineRelation("upbexpenseyear","upb","expenseyear","idupb");
	this.defineRelation("finviewexpenseyear","finview","expenseyear","idfin","idupb");
	this.defineRelation("taxexpensetax","tax","expensetax","taxcode");
	this.defineRelation("expenseexpensetax","expense","expensetax","idexp");
	this.defineRelation("expenseexpensetotal","expense","expensetotal","idexp");
	this.defineRelation("clawbackexpenseclawback","clawback","expenseclawback","idclawback");
	this.defineRelation("expenseexpenseclawback","expense","expenseclawback","idexp");
	cPar = new []{monthname1.Columns["code"]};
	cChild = new []{expenseclawback.Columns["rifa_month"]};
	Relations.Add(new DataRelation("monthname1_expenseclawback",cPar,cChild,false));

	this.defineRelation("lookup_tiporigaf24ep_expenseclawback","lookup_tiporigaf24ep","expenseclawback","tiporiga");
	cPar = new []{monthname2.Columns["code"]};
	cChild = new []{expenseclawback.Columns["rifb_month"]};
	Relations.Add(new DataRelation("monthname2_expenseclawback",cPar,cChild,false));

	cPar = new []{formerexpense.Columns["idexp"]};
	cChild = new []{expense.Columns["idformerexpense"]};
	Relations.Add(new DataRelation("formerexpense_expense",cPar,cChild,false));

	this.defineRelation("registryexpense","registry","expense","idreg");
	this.defineRelation("managerexpense","manager","expense","idman");
	this.defineRelation("expensephaseexpense","expensephase","expense","nphase");
	this.defineRelation("clawback_expenseexpense","clawback_expense","expense","idclawback");
	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{invoicedetail_taxable_nc.Columns["idexp_taxable"]};
	Relations.Add(new DataRelation("expense_invoicedetail_taxable_nc",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{invoicedetail_iva_nc.Columns["idexp_iva"]};
	Relations.Add(new DataRelation("expense_invoicedetail_iva_nc",cPar,cChild,false));

	cPar = new []{expensevar.Columns["idexp"], expensevar.Columns["idinvkind"], expensevar.Columns["yinv"], expensevar.Columns["ninv"]};
	cChild = new []{invoicedetail_taxable_nc.Columns["idexp_taxable"], invoicedetail_taxable_nc.Columns["idinvkind"], invoicedetail_taxable_nc.Columns["yinv"], invoicedetail_taxable_nc.Columns["ninv"]};
	Relations.Add(new DataRelation("expensevar_invoicedetail_taxable_nc",cPar,cChild,false));

	cPar = new []{expensevar.Columns["idexp"], expensevar.Columns["idinvkind"], expensevar.Columns["yinv"], expensevar.Columns["ninv"]};
	cChild = new []{invoicedetail_iva_nc.Columns["idexp_iva"], invoicedetail_iva_nc.Columns["idinvkind"], invoicedetail_iva_nc.Columns["yinv"], invoicedetail_iva_nc.Columns["ninv"]};
	Relations.Add(new DataRelation("expensevar_invoicedetail_iva_nc",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{invoicedetail_taxable_nc.Columns["idexp_iva"]};
	Relations.Add(new DataRelation("expense_invoicedetail_taxable_nc1",cPar,cChild,false));

	cPar = new []{expensevar.Columns["idexp"], expensevar.Columns["idinvkind"], expensevar.Columns["yinv"], expensevar.Columns["ninv"]};
	cChild = new []{invoicedetail_taxable_nc.Columns["idexp_iva"], invoicedetail_taxable_nc.Columns["idinvkind"], invoicedetail_taxable_nc.Columns["yinv"], invoicedetail_taxable_nc.Columns["ninv"]};
	Relations.Add(new DataRelation("expensevar_invoicedetail_taxable_nc1",cPar,cChild,false));

	cPar = new []{income_linked.Columns["idinc"]};
	cChild = new []{expense.Columns["idinc_linked"]};
	Relations.Add(new DataRelation("income_expense",cPar,cChild,false));

	this.defineRelation("expense_expenselastmandatedetail","expense","expenselastmandatedetail","idexp");
	this.defineRelation("mandatedetail_taxable_expenselastmandatedetail","mandatedetail_taxable","expenselastmandatedetail","idmankind","yman","nman","rownum");
	this.defineRelation("mandatekind_expenselastmandatedetail","mandatekind","expenselastmandatedetail","idmankind");
	this.defineRelation("mandatedetail_pagamenti_expenselastmandatedetail","mandatedetail_pagamenti","expenselastmandatedetail","idmankind","nman","rownum","yman");
	#endregion

}
}
}
