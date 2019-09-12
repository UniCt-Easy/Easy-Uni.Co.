/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace pettycashoperation_wizardinvoicedetail {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Operazione fondo economale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable pettycashoperation		{get { return Tables["pettycashoperation"];}}
	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable config		{get { return Tables["config"];}}
	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable upb		{get { return Tables["upb"];}}
	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable fin		{get { return Tables["fin"];}}
	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expense		{get { return Tables["expense"];}}
	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expensephase		{get { return Tables["expensephase"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable tipomovimento		{get { return Tables["tipomovimento"];}}
	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable manager		{get { return Tables["manager"];}}
	///<summary>
	///Fondo economale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable pettycash		{get { return Tables["pettycash"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expenseview		{get { return Tables["expenseview"];}}
	///<summary>
	///Associazione fattura con p.spesa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable pettycashoperationinvoice		{get { return Tables["pettycashoperationinvoice"];}}
	///<summary>
	///Fattura
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable invoice		{get { return Tables["invoice"];}}
	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable invoicedetail		{get { return Tables["invoicedetail"];}}
	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable invoicekind		{get { return Tables["invoicekind"];}}
	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable ivakind		{get { return Tables["ivakind"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable pettycashoperationview		{get { return Tables["pettycashoperationview"];}}
	///<summary>
	///Configurazione fondo economale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable pettycashsetup		{get { return Tables["pettycashsetup"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// PETTYCASHOPERATION /////////////////////////////////
	T= new DataTable("pettycashoperation");
	C= new DataColumn("noperation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yoperation", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nrestore", typeof(Int32)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("yrestore", typeof(Int16)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("idaccmotive_debit", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_cost", typeof(String)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idexp", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfin", typeof(Int32)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	C= new DataColumn("idpettycash", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["noperation"], T.Columns["yoperation"], T.Columns["idpettycash"]};


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
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"]};


	//////////////////// UPB /////////////////////////////////
	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("assured", typeof(String)));
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	T.Columns.Add( new DataColumn("granted", typeof(Decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridupb", typeof(String)));
	T.Columns.Add( new DataColumn("previousappropriation", typeof(Decimal)));
	T.Columns.Add( new DataColumn("previousassessment", typeof(Decimal)));
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("requested", typeof(Decimal)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("idunderwriter", typeof(Int32)));
	T.Columns.Add( new DataColumn("cupcode", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idupb"]};


	//////////////////// FIN /////////////////////////////////
	T= new DataTable("fin");
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codefin", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idfin", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridfin", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idfin"]};


	//////////////////// EXPENSE /////////////////////////////////
	T= new DataTable("expense");
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nmov", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("ymov", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idclawback", typeof(Int32)));
	C= new DataColumn("idexp", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("parentidexp", typeof(Int32)));
	T.Columns.Add( new DataColumn("idpayment", typeof(Int32)));
	T.Columns.Add( new DataColumn("idformerexpense", typeof(Int32)));
	C= new DataColumn("nphase", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("autokind", typeof(Byte)));
	T.Columns.Add( new DataColumn("autocode", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idexp"]};


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


	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	T= new DataTable("tipomovimento");
	C= new DataColumn("idtipo", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("descrizione", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idtipo"]};


	//////////////////// MANAGER /////////////////////////////////
	T= new DataTable("manager");
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("email", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("passwordweb", typeof(String)));
	T.Columns.Add( new DataColumn("phonenumber", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("userweb", typeof(String)));
	C= new DataColumn("idman", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idman"]};


	//////////////////// PETTYCASH /////////////////////////////////
	T= new DataTable("pettycash");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("pettycode", typeof(String)));
	C= new DataColumn("idpettycash", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idpettycash"]};


	//////////////////// EXPENSEVIEW /////////////////////////////////
	T= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nphase", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("phase", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ymov", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nmov", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("parentidexp", typeof(Int32)));
	T.Columns.Add( new DataColumn("parentymov", typeof(Int16)));
	T.Columns.Add( new DataColumn("parentnmov", typeof(Int32)));
	T.Columns.Add( new DataColumn("idformerexpense", typeof(Int32)));
	T.Columns.Add( new DataColumn("formerymov", typeof(Int16)));
	T.Columns.Add( new DataColumn("formernmov", typeof(Int32)));
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(Int32)));
	T.Columns.Add( new DataColumn("codefin", typeof(String)));
	T.Columns.Add( new DataColumn("finance", typeof(String)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("codeupb", typeof(String)));
	T.Columns.Add( new DataColumn("upb", typeof(String)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("registry", typeof(String)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(String)));
	T.Columns.Add( new DataColumn("kpay", typeof(Int32)));
	T.Columns.Add( new DataColumn("ypay", typeof(Int16)));
	T.Columns.Add( new DataColumn("npay", typeof(Int32)));
	T.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("ayearstartamount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idregistrypaymethod", typeof(Int32)));
	T.Columns.Add( new DataColumn("idpaymethod", typeof(Int32)));
	T.Columns.Add( new DataColumn("iban", typeof(String)));
	T.Columns.Add( new DataColumn("cin", typeof(String)));
	T.Columns.Add( new DataColumn("idbank", typeof(String)));
	T.Columns.Add( new DataColumn("idcab", typeof(String)));
	T.Columns.Add( new DataColumn("cc", typeof(String)));
	T.Columns.Add( new DataColumn("iddeputy", typeof(Int32)));
	T.Columns.Add( new DataColumn("deputy", typeof(String)));
	T.Columns.Add( new DataColumn("refexternaldoc", typeof(String)));
	T.Columns.Add( new DataColumn("paymentdescr", typeof(String)));
	T.Columns.Add( new DataColumn("idser", typeof(Int32)));
	T.Columns.Add( new DataColumn("service", typeof(String)));
	T.Columns.Add( new DataColumn("codeser", typeof(String)));
	T.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	T.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("ivaamount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("totflag", typeof(Byte)));
	C= new DataColumn("flagarrear", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("autokind", typeof(Byte)));
	T.Columns.Add( new DataColumn("idpayment", typeof(Int32)));
	T.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("autocode", typeof(Int32)));
	T.Columns.Add( new DataColumn("idclawback", typeof(Int32)));
	T.Columns.Add( new DataColumn("clawback", typeof(String)));
	T.Columns.Add( new DataColumn("clawbackref", typeof(String)));
	T.Columns.Add( new DataColumn("nbill", typeof(Int32)));
	T.Columns.Add( new DataColumn("idpay", typeof(Int32)));
	T.Columns.Add( new DataColumn("npaymenttransmission", typeof(Int32)));
	T.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idaccdebit", typeof(String)));
	T.Columns.Add( new DataColumn("codeaccdebit", typeof(String)));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
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
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);

	//////////////////// PETTYCASHOPERATIONINVOICE /////////////////////////////////
	T= new DataTable("pettycashoperationinvoice");
	C= new DataColumn("yoperation", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("noperation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yinv", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ninv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idpettycash", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["yoperation"], T.Columns["noperation"], T.Columns["yinv"], T.Columns["ninv"], T.Columns["idpettycash"], T.Columns["idinvkind"]};


	//////////////////// INVOICE /////////////////////////////////
	T= new DataTable("invoice");
	C= new DataColumn("ninv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yinv", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("exchangerate", typeof(Double)));
	T.Columns.Add( new DataColumn("flagdeferred", typeof(String)));
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("packinglistnum", typeof(String)));
	T.Columns.Add( new DataColumn("paymentexpiring", typeof(Int16)));
	T.Columns.Add( new DataColumn("registryreference", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idcurrency", typeof(Int32)));
	T.Columns.Add( new DataColumn("idexpirationkind", typeof(Int16)));
	T.Columns.Add( new DataColumn("idtreasurer", typeof(Int32)));
	T.Columns.Add( new DataColumn("flagintracom", typeof(String)));
	T.Columns.Add( new DataColumn("iso_origin", typeof(String)));
	T.Columns.Add( new DataColumn("iso_provenance", typeof(String)));
	T.Columns.Add( new DataColumn("iso_destination", typeof(String)));
	T.Columns.Add( new DataColumn("idcountry_origin", typeof(Int32)));
	T.Columns.Add( new DataColumn("idcountry_destination", typeof(Int32)));
	T.Columns.Add( new DataColumn("idintrastatkind", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idintrastatpaymethod", typeof(Int32)));
	T.Columns.Add( new DataColumn("iso_payment", typeof(String)));
	T.Columns.Add( new DataColumn("idblacklist", typeof(Int32)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ninv"], T.Columns["yinv"], T.Columns["idinvkind"]};


	//////////////////// INVOICEDETAIL /////////////////////////////////
	T= new DataTable("invoicedetail");
	C= new DataColumn("ninv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("rownum", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yinv", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotations", typeof(String)));
	T.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	T.Columns.Add( new DataColumn("paymentcompetency", typeof(DateTime)));
	T.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("detaildescription", typeof(String)));
	T.Columns.Add( new DataColumn("discount", typeof(Double)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(String)));
	T.Columns.Add( new DataColumn("idmankind", typeof(String)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("manrownum", typeof(Int32)));
	T.Columns.Add( new DataColumn("nman", typeof(Int32)));
	T.Columns.Add( new DataColumn("number", typeof(Decimal)));
	T.Columns.Add( new DataColumn("tax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxable", typeof(Decimal)));
	T.Columns.Add( new DataColumn("unabatable", typeof(Decimal)));
	T.Columns.Add( new DataColumn("yman", typeof(Int16)));
	T.Columns.Add( new DataColumn("idestimkind", typeof(String)));
	T.Columns.Add( new DataColumn("estimrownum", typeof(Int32)));
	T.Columns.Add( new DataColumn("nestim", typeof(Int32)));
	T.Columns.Add( new DataColumn("yestim", typeof(Int16)));
	T.Columns.Add( new DataColumn("idgroup", typeof(Int32)));
	T.Columns.Add( new DataColumn("idexp_taxable", typeof(Int32)));
	T.Columns.Add( new DataColumn("idexp_iva", typeof(Int32)));
	T.Columns.Add( new DataColumn("idinc_taxable", typeof(Int32)));
	T.Columns.Add( new DataColumn("idinc_iva", typeof(Int32)));
	T.Columns.Add( new DataColumn("ninv_main", typeof(Int32)));
	T.Columns.Add( new DataColumn("yinv_main", typeof(Int16)));
	C= new DataColumn("idivakind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	T.Columns.Add( new DataColumn("idintrastatcode", typeof(Int32)));
	T.Columns.Add( new DataColumn("idintrastatmeasure", typeof(Int32)));
	T.Columns.Add( new DataColumn("weight", typeof(Decimal)));
	T.Columns.Add( new DataColumn("va3type", typeof(String)));
	T.Columns.Add( new DataColumn("intrastatoperationkind", typeof(String)));
	T.Columns.Add( new DataColumn("idintrastatservice", typeof(Int32)));
	T.Columns.Add( new DataColumn("idintrastatsupplymethod", typeof(Int32)));
	T.Columns.Add( new DataColumn("!aliquota", typeof(Decimal)));
	T.Columns.Add( new DataColumn("!totaleriga", typeof(Decimal)));
	T.Columns.Add( new DataColumn("!codeupb", typeof(String)));
	T.Columns.Add( new DataColumn("!idfin", typeof(Int32)));
	T.Columns.Add( new DataColumn("!idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("!idexp", typeof(Int32)));
	T.Columns.Add( new DataColumn("!percindetraibilita", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idlist", typeof(Int32)));
	T.Columns.Add( new DataColumn("idunit", typeof(Int32)));
	T.Columns.Add( new DataColumn("idpackage", typeof(Int32)));
	T.Columns.Add( new DataColumn("npackage", typeof(Decimal)));
	T.Columns.Add( new DataColumn("unitsforpackage", typeof(Int32)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ninv"], T.Columns["rownum"], T.Columns["yinv"], T.Columns["idinvkind"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	T= new DataTable("invoicekind");
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
	C= new DataColumn("codeinvkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(String)));
	T.Columns.Add( new DataColumn("formatstring", typeof(String)));
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinvkind"]};


	//////////////////// IVAKIND /////////////////////////////////
	T= new DataTable("ivakind");
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
	C= new DataColumn("rate", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idivataxablekind", typeof(Int32)));
	C= new DataColumn("idivakind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("codeivakind", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idivakind"]};


	//////////////////// PETTYCASHOPERATIONVIEW /////////////////////////////////
	T= new DataTable("pettycashoperationview");
	C= new DataColumn("yoperation", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("noperation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idpettycash", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("pettycash", typeof(String)));
	T.Columns.Add( new DataColumn("pettycode", typeof(String)));
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("kind", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("registry", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_cost", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive_cost", typeof(String)));
	T.Columns.Add( new DataColumn("motive_cost", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_debit", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive_debit", typeof(String)));
	T.Columns.Add( new DataColumn("motive_debit", typeof(String)));
	C= new DataColumn("flagdocumented", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(Int32)));
	C= new DataColumn("finpart", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("codefin", typeof(String)));
	T.Columns.Add( new DataColumn("finance", typeof(String)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("codeupb", typeof(String)));
	T.Columns.Add( new DataColumn("upb", typeof(String)));
	T.Columns.Add( new DataColumn("yrestore", typeof(Int16)));
	T.Columns.Add( new DataColumn("nrestore", typeof(Int32)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
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
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(String)));
	T.Columns.Add( new DataColumn("idexp", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("!nmov", typeof(Int32)));
	T.Columns.Add( new DataColumn("!ymov", typeof(Int32)));
	T.Columns.Add( new DataColumn("!phase", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["yoperation"], T.Columns["noperation"], T.Columns["idpettycash"]};


	//////////////////// PETTYCASHSETUP /////////////////////////////////
	T= new DataTable("pettycashsetup");
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("registrymanager", typeof(Int32)));
	T.Columns.Add( new DataColumn("autoclassify", typeof(String)));
	T.Columns.Add( new DataColumn("idacc", typeof(String)));
	T.Columns.Add( new DataColumn("idfinexpense", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinincome", typeof(Int32)));
	C= new DataColumn("idpettycash", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idpettycash"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[3]{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	CChild = new DataColumn[3]{invoicedetail.Columns["ninv"], invoicedetail.Columns["yinv"], invoicedetail.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoicedetail_invoice",CPar,CChild,false));

	CPar = new DataColumn[1]{ivakind.Columns["idivakind"]};
	CChild = new DataColumn[1]{invoicedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("FK_invoicedetail_ivakind",CPar,CChild,false));

	CPar = new DataColumn[1]{invoicekind.Columns["idinvkind"]};
	CChild = new DataColumn[1]{invoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoice_invoicekind",CPar,CChild,false));

	CPar = new DataColumn[3]{pettycashoperation.Columns["noperation"], pettycashoperation.Columns["yoperation"], pettycashoperation.Columns["idpettycash"]};
	CChild = new DataColumn[3]{pettycashoperationinvoice.Columns["noperation"], pettycashoperationinvoice.Columns["yoperation"], pettycashoperationinvoice.Columns["idpettycash"]};
	Relations.Add(new DataRelation("FK_pettycashoperation_pettycashoperationinvoice",CPar,CChild,false));

	CPar = new DataColumn[3]{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	CChild = new DataColumn[3]{pettycashoperationinvoice.Columns["ninv"], pettycashoperationinvoice.Columns["yinv"], pettycashoperationinvoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoice_pettycashoperationinvoice",CPar,CChild,false));

	CPar = new DataColumn[1]{pettycash.Columns["idpettycash"]};
	CChild = new DataColumn[1]{pettycashoperation.Columns["idpettycash"]};
	Relations.Add(new DataRelation("FK_pettycash_pettycashoperation",CPar,CChild,false));

	CPar = new DataColumn[1]{expenseview.Columns["idexp"]};
	CChild = new DataColumn[1]{pettycashoperation.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_expenseview_pettycashoperation",CPar,CChild,false));

	CPar = new DataColumn[1]{manager.Columns["idman"]};
	CChild = new DataColumn[1]{pettycashoperation.Columns["idman"]};
	Relations.Add(new DataRelation("FK_manager_pettycashoperation",CPar,CChild,false));

	CPar = new DataColumn[1]{upb.Columns["idupb"]};
	CChild = new DataColumn[1]{pettycashoperation.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_pettycashoperation",CPar,CChild,false));

	CPar = new DataColumn[1]{fin.Columns["idfin"]};
	CChild = new DataColumn[1]{pettycashoperation.Columns["idfin"]};
	Relations.Add(new DataRelation("FK_fin_pettycashoperation",CPar,CChild,false));

	#endregion

}
}
}
