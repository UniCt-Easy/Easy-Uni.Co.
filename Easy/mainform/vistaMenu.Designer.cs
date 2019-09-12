/*
    Easy
    Copyright (C) 2019 Universit‡ degli Studi di Catania (www.unict.it)

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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace mainform {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaMenu")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaMenu: DataSet {

	#region Table members declaration
	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable config		{get { return Tables["config"];}}
	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingkind		{get { return Tables["sortingkind"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingapplicabilityview		{get { return Tables["sortingapplicabilityview"];}}
	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomephase		{get { return Tables["incomephase"];}}
	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expensephase		{get { return Tables["expensephase"];}}
	///<summary>
	///Configurazione Pluriennale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable uniconfig		{get { return Tables["uniconfig"];}}
	///<summary>
	///Configurazione delle stampe
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable report		{get { return Tables["report"];}}
	///<summary>
	///Procedure di esportazione su file ASCII o su Microsoft Excel
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable exportfunction		{get { return Tables["exportfunction"];}}
	///<summary>
	///Gestione del Menu
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable menu		{get { return Tables["menu"];}}
	///<summary>
	///Associazione organigramma - modulo stampe
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable flowchartmodulegroup		{get { return Tables["flowchartmodulegroup"];}}
	///<summary>
	///Associazione organigramma - modulo esportazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable flowchartexportmodule		{get { return Tables["flowchartexportmodule"];}}
	///<summary>
	///Visibilit√† voci menu
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable menuvisibility		{get { return Tables["menuvisibility"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaMenu(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaMenu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaMenu";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaMenu.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// CONFIG /////////////////////////////////
	T= new DataTable("config");
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("agencycode", typeof(String)));
	T.Columns.Add( new DataColumn("appname", typeof(String)));
	T.Columns.Add( new DataColumn("appropriationphasecode", typeof(Byte)));
	T.Columns.Add( new DataColumn("assessmentphasecode", typeof(Byte)));
	T.Columns.Add( new DataColumn("asset_flagnumbering", typeof(String)));
	T.Columns.Add( new DataColumn("asset_flagrestart", typeof(String)));
	T.Columns.Add( new DataColumn("assetload_flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("boxpartitiontitle", typeof(String)));
	T.Columns.Add( new DataColumn("finvarofficial_default", typeof(String)));
	T.Columns.Add( new DataColumn("casualcontract_flagrestart", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("currpartitiontitle", typeof(String)));
	T.Columns.Add( new DataColumn("deferredexpensephase", typeof(String)));
	T.Columns.Add( new DataColumn("deferredincomephase", typeof(String)));
	T.Columns.Add( new DataColumn("electronicimport", typeof(String)));
	T.Columns.Add( new DataColumn("electronictrasmission", typeof(String)));
	T.Columns.Add( new DataColumn("expense_expiringdays", typeof(Int16)));
	T.Columns.Add( new DataColumn("expensephase", typeof(Byte)));
	T.Columns.Add( new DataColumn("flagautopayment", typeof(String)));
	T.Columns.Add( new DataColumn("flagautoproceeds", typeof(String)));
	T.Columns.Add( new DataColumn("flagcredit", typeof(String)));
	T.Columns.Add( new DataColumn("flagepexp", typeof(String)));
	T.Columns.Add( new DataColumn("flagfruitful", typeof(String)));
	T.Columns.Add( new DataColumn("flagpayment", typeof(String)));
	T.Columns.Add( new DataColumn("flagproceeds", typeof(String)));
	T.Columns.Add( new DataColumn("flagrefund", typeof(String)));
	T.Columns.Add( new DataColumn("foreignhours", typeof(Int32)));
	T.Columns.Add( new DataColumn("idacc_accruedcost", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_accruedrevenue", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_customer", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredcredit", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferreddebit", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredrevenue", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_ivapayment", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_ivarefund", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_patrimony", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_pl", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_supplier", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_admincar", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_foot", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_owncar", typeof(String)));
	T.Columns.Add( new DataColumn("idclawback", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinexpense", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinexpensesurplus", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinincomesurplus", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinivapayment", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinivarefund", typeof(Int32)));
	T.Columns.Add( new DataColumn("idregauto", typeof(Int32)));
	T.Columns.Add( new DataColumn("importappname", typeof(String)));
	T.Columns.Add( new DataColumn("income_expiringdays", typeof(Int16)));
	T.Columns.Add( new DataColumn("incomephase", typeof(Byte)));
	T.Columns.Add( new DataColumn("linktoinvoice", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("minpayment", typeof(Decimal)));
	T.Columns.Add( new DataColumn("minrefund", typeof(Decimal)));
	T.Columns.Add( new DataColumn("motivelen", typeof(Int16)));
	T.Columns.Add( new DataColumn("motiveprefix", typeof(String)));
	T.Columns.Add( new DataColumn("motiveseparator", typeof(String)));
	T.Columns.Add( new DataColumn("payment_finlevel", typeof(Byte)));
	T.Columns.Add( new DataColumn("payment_flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("payment_flagautoprintdate", typeof(String)));
	T.Columns.Add( new DataColumn("paymentagency", typeof(Int32)));
	T.Columns.Add( new DataColumn("prevpartitiontitle", typeof(String)));
	T.Columns.Add( new DataColumn("proceeds_finlevel", typeof(Byte)));
	T.Columns.Add( new DataColumn("proceeds_flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(String)));
	T.Columns.Add( new DataColumn("profservice_flagrestart", typeof(String)));
	T.Columns.Add( new DataColumn("refundagency", typeof(Int32)));
	T.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(String)));
	T.Columns.Add( new DataColumn("idivapayperiodicity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsortingkind1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsortingkind2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsortingkind3", typeof(Int32)));
	T.Columns.Add( new DataColumn("fin_kind", typeof(Byte)));
	T.Columns.Add( new DataColumn("taxvaliditykind", typeof(Byte)));
	T.Columns.Add( new DataColumn("flag_paymentamount", typeof(Byte)));
	T.Columns.Add( new DataColumn("automanagekind", typeof(Int32)));
	T.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(Int32)));
	T.Columns.Add( new DataColumn("flagbank_grouping", typeof(Int32)));
	T.Columns.Add( new DataColumn("cashvaliditykind", typeof(Byte)));
	T.Columns.Add( new DataColumn("wageimportappname", typeof(String)));
	T.Columns.Add( new DataColumn("balancekind", typeof(Byte)));
	T.Columns.Add( new DataColumn("idpaymethodabi", typeof(Int32)));
	T.Columns.Add( new DataColumn("idpaymethodnoabi", typeof(Int32)));
	T.Columns.Add( new DataColumn("iban_f24", typeof(String)));
	T.Columns.Add( new DataColumn("cudactivitycode", typeof(String)));
	T.Columns.Add( new DataColumn("startivabalance", typeof(Decimal)));
	T.Columns.Add( new DataColumn("flagivapaybyrow", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_unabatable", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_unabatable_refund", typeof(String)));
	T.Columns.Add( new DataColumn("invoice_flagregister", typeof(String)));
	T.Columns.Add( new DataColumn("default_idfinvarstatus", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagivaregphase", typeof(String)));
	T.Columns.Add( new DataColumn("mainflagpayment", typeof(String)));
	T.Columns.Add( new DataColumn("mainflagrefund", typeof(String)));
	T.Columns.Add( new DataColumn("mainidfinivapayment", typeof(Int32)));
	T.Columns.Add( new DataColumn("mainidfinivarefund", typeof(Int32)));
	T.Columns.Add( new DataColumn("mainminpayment", typeof(Decimal)));
	T.Columns.Add( new DataColumn("mainminrefund", typeof(Decimal)));
	T.Columns.Add( new DataColumn("mainpaymentagency", typeof(Int32)));
	T.Columns.Add( new DataColumn("mainrefundagency", typeof(Int32)));
	T.Columns.Add( new DataColumn("mainflagivaregphase", typeof(String)));
	T.Columns.Add( new DataColumn("mainstartivabalance", typeof(Decimal)));
	T.Columns.Add( new DataColumn("mainidacc_unabatable", typeof(String)));
	T.Columns.Add( new DataColumn("mainidacc_unabatable_refund", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_mainivapayment", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_mainivapayment_internal", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_mainivarefund", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_mainivarefund_internal", typeof(String)));
	T.Columns.Add( new DataColumn("flagva3", typeof(String)));
	T.Columns.Add( new DataColumn("flagrefund12", typeof(String)));
	T.Columns.Add( new DataColumn("flagpayment12", typeof(String)));
	T.Columns.Add( new DataColumn("refundagency12", typeof(Int32)));
	T.Columns.Add( new DataColumn("paymentagency12", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinivarefund12", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinivapayment12", typeof(Int32)));
	T.Columns.Add( new DataColumn("minrefund12", typeof(Decimal)));
	T.Columns.Add( new DataColumn("minpayment12", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idacc_ivapayment12", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_ivarefund12", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_mainivarefund12", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_mainivapayment12", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_mainivapayment_internal12", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_mainivarefund_internal12", typeof(String)));
	T.Columns.Add( new DataColumn("startivabalance12", typeof(Decimal)));
	T.Columns.Add( new DataColumn("mainrefundagency12", typeof(Int32)));
	T.Columns.Add( new DataColumn("mainpaymentagency12", typeof(Int32)));
	T.Columns.Add( new DataColumn("mainflagrefund12", typeof(String)));
	T.Columns.Add( new DataColumn("mainflagpayment12", typeof(String)));
	T.Columns.Add( new DataColumn("mainidfinivarefund12", typeof(Int32)));
	T.Columns.Add( new DataColumn("mainidfinivapayment12", typeof(Int32)));
	T.Columns.Add( new DataColumn("mainminrefund12", typeof(Decimal)));
	T.Columns.Add( new DataColumn("mainminpayment12", typeof(Decimal)));
	T.Columns.Add( new DataColumn("mainstartivabalance12", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idreg_csa", typeof(Int32)));
	T.Columns.Add( new DataColumn("finvar_warnmail", typeof(String)));
	T.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_revenue_gross_csa", typeof(String)));
	T.Columns.Add( new DataColumn("idfinincome_gross_csa", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor1_stock", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2_stock", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3_stock", typeof(Int32)));
	T.Columns.Add( new DataColumn("idinpscenter", typeof(String)));
	T.Columns.Add( new DataColumn("idivapayperiodicity_instit", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfin_store", typeof(Int32)));
	T.Columns.Add( new DataColumn("flagpcashautopayment", typeof(String)));
	T.Columns.Add( new DataColumn("flagpcashautoproceeds", typeof(String)));
	T.Columns.Add( new DataColumn("email", typeof(String)));
	T.Columns.Add( new DataColumn("lcard", typeof(String)));
	T.Columns.Add( new DataColumn("booking_on_invoice", typeof(String)));
	T.Columns.Add( new DataColumn("itineration_directauth", typeof(String)));
	T.Columns.Add( new DataColumn("email_f24", typeof(String)));
	T.Columns.Add( new DataColumn("csa_flaggroupby_income", typeof(String)));
	T.Columns.Add( new DataColumn("csa_flaggroupby_expense", typeof(String)));
	T.Columns.Add( new DataColumn("csa_flaglinktoexp", typeof(String)));
	T.Columns.Add( new DataColumn("idsiopeincome_csa", typeof(Int32)));
	T.Columns.Add( new DataColumn("idacc_invoicetoemit", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_invoicetoreceive", typeof(String)));
	T.Columns.Add( new DataColumn("epannualthreeshold", typeof(Decimal)));
	T.Columns.Add( new DataColumn("flagbalance_csa", typeof(String)));
	T.Columns.Add( new DataColumn("flagiva_immediate_or_deferred", typeof(String)));
	T.Columns.Add( new DataColumn("flagenabletransmission", typeof(String)));
	T.Columns.Add( new DataColumn("idpccdebitstatus", typeof(String)));
	T.Columns.Add( new DataColumn("flagsplitpayment", typeof(String)));
	T.Columns.Add( new DataColumn("startivabalancesplit", typeof(Decimal)));
	T.Columns.Add( new DataColumn("paymentagencysplit", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinivapaymentsplit", typeof(Int32)));
	T.Columns.Add( new DataColumn("flagpaymentsplit", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_unabatable_split", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_ivapaymentsplit", typeof(String)));
	T.Columns.Add( new DataColumn("agencynumber", typeof(String)));
	T.Columns.Add( new DataColumn("femode", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_economic_result", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_previous_economic_result", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_bankpaydoc", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_bankprodoc", typeof(String)));
	T.Columns.Add( new DataColumn("csa_flagtransmissionlinking", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_forwarder", typeof(String)));
	T.Columns.Add( new DataColumn("idivakind_forwarder", typeof(Int32)));
	T.Columns.Add( new DataColumn("idaccmotive_grantrevenue", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_grantdeferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_assetrevenue", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	T= new DataTable("sortingkind");
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagdate", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN5", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS5", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv5", typeof(String)));
	T.Columns.Add( new DataColumn("labelfordate", typeof(String)));
	T.Columns.Add( new DataColumn("labeln1", typeof(String)));
	T.Columns.Add( new DataColumn("labeln2", typeof(String)));
	T.Columns.Add( new DataColumn("labeln3", typeof(String)));
	T.Columns.Add( new DataColumn("labeln4", typeof(String)));
	T.Columns.Add( new DataColumn("labeln5", typeof(String)));
	T.Columns.Add( new DataColumn("labels1", typeof(String)));
	T.Columns.Add( new DataColumn("labels2", typeof(String)));
	T.Columns.Add( new DataColumn("labels3", typeof(String)));
	T.Columns.Add( new DataColumn("labels4", typeof(String)));
	T.Columns.Add( new DataColumn("labels5", typeof(String)));
	T.Columns.Add( new DataColumn("labelv1", typeof(String)));
	T.Columns.Add( new DataColumn("labelv2", typeof(String)));
	T.Columns.Add( new DataColumn("labelv3", typeof(String)));
	T.Columns.Add( new DataColumn("labelv4", typeof(String)));
	T.Columns.Add( new DataColumn("labelv5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv5", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nodatelabel", typeof(String)));
	T.Columns.Add( new DataColumn("totalexpression", typeof(String)));
	T.Columns.Add( new DataColumn("nphaseexpense", typeof(Byte)));
	T.Columns.Add( new DataColumn("nphaseincome", typeof(Byte)));
	C= new DataColumn("codesorkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	T.Columns.Add( new DataColumn("idparentkind", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsorkind"]};


	//////////////////// SORTINGAPPLICABILITYVIEW /////////////////////////////////
	T= new DataTable("sortingapplicabilityview");
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codesorkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nphaseincome", typeof(Byte)));
	T.Columns.Add( new DataColumn("incomephase", typeof(String)));
	T.Columns.Add( new DataColumn("nphaseexpense", typeof(Byte)));
	T.Columns.Add( new DataColumn("expensephase", typeof(String)));
	C= new DataColumn("flagcheckavailability", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("flagforced", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("tablename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	Tables.Add(T);

	//////////////////// INCOMEPHASE /////////////////////////////////
	T= new DataTable("incomephase");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nphase", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nphase"]};


	//////////////////// EXPENSEPHASE /////////////////////////////////
	T= new DataTable("expensephase");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nphase", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nphase"]};


	//////////////////// UNICONFIG /////////////////////////////////
	T= new DataTable("uniconfig");
	C= new DataColumn("dummykey", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("expensefinphase", typeof(Byte)));
	T.Columns.Add( new DataColumn("incomefinphase", typeof(Byte)));
	T.Columns.Add( new DataColumn("expenseregphase", typeof(Byte)));
	T.Columns.Add( new DataColumn("incomeregphase", typeof(Byte)));
	C= new DataColumn("flagresearchagency", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsorkind01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsorkind02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsorkind03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsorkind04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsorkind05", typeof(Int32)));
	T.Columns.Add( new DataColumn("sorkind01asfilter", typeof(String)));
	T.Columns.Add( new DataColumn("sorkind02asfilter", typeof(String)));
	T.Columns.Add( new DataColumn("sorkind03asfilter", typeof(String)));
	T.Columns.Add( new DataColumn("sorkind04asfilter", typeof(String)));
	T.Columns.Add( new DataColumn("sorkind05asfilter", typeof(String)));
	T.Columns.Add( new DataColumn("tree_upb_withdescr", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("ep360days", typeof(String)));
	T.Columns.Add( new DataColumn("idente", typeof(Int32)));
	T.Columns.Add( new DataColumn("publicagency", typeof(String)));
	T.Columns.Add( new DataColumn("ssn_codasl", typeof(String)));
	T.Columns.Add( new DataColumn("ssn_codregione", typeof(String)));
	T.Columns.Add( new DataColumn("ssn_codssa", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["dummykey"]};


	//////////////////// REPORT /////////////////////////////////
	T= new DataTable("report");
	C= new DataColumn("modulename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("reportname", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("filename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("groupname", typeof(String)));
	C= new DataColumn("orientation", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("papersize", typeof(String)));
	T.Columns.Add( new DataColumn("sp_doupdate", typeof(String)));
	T.Columns.Add( new DataColumn("timeout", typeof(Int32)));
	T.Columns.Add( new DataColumn("webvisible", typeof(String)));
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("flag_both", typeof(String)));
	T.Columns.Add( new DataColumn("flag_cash", typeof(String)));
	T.Columns.Add( new DataColumn("flag_comp", typeof(String)));
	T.Columns.Add( new DataColumn("flag_credit", typeof(String)));
	T.Columns.Add( new DataColumn("flag_proceeds", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["reportname"]};


	//////////////////// EXPORTFUNCTION /////////////////////////////////
	T= new DataTable("exportfunction");
	C= new DataColumn("procedurename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("fileformat", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	C= new DataColumn("modulename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("timeout", typeof(Int32)));
	T.Columns.Add( new DataColumn("webvisible", typeof(String)));
	T.Columns.Add( new DataColumn("fileextension", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["procedurename"]};


	//////////////////// MENU /////////////////////////////////
	T= new DataTable("menu");
	C= new DataColumn("idmenu", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("edittype", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("menucode", typeof(String)));
	T.Columns.Add( new DataColumn("metadata", typeof(String)));
	T.Columns.Add( new DataColumn("modal", typeof(String)));
	T.Columns.Add( new DataColumn("ordernumber", typeof(Int32)));
	T.Columns.Add( new DataColumn("parameter", typeof(String)));
	T.Columns.Add( new DataColumn("paridmenu", typeof(Int32)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("userid", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idmenu"]};


	//////////////////// FLOWCHARTMODULEGROUP /////////////////////////////////
	T= new DataTable("flowchartmodulegroup");
	C= new DataColumn("idflowchart", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("modulename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("groupname", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idflowchart"], T.Columns["modulename"], T.Columns["groupname"]};


	//////////////////// FLOWCHARTEXPORTMODULE /////////////////////////////////
	T= new DataTable("flowchartexportmodule");
	C= new DataColumn("idflowchart", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("modulename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idflowchart"], T.Columns["modulename"]};


	//////////////////// MENUVISIBILITY /////////////////////////////////
	T= new DataTable("menuvisibility");
	C= new DataColumn("menucode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("visible", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["menucode"]};


	#endregion

}
}
}
