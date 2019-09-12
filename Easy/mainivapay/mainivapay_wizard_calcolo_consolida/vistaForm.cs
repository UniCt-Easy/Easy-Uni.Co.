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

namespace mainivapay_wizard_calcolo_consolida {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable iva_mixed{get { return this.Tables["iva_mixed"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable iva_prorata{get { return this.Tables["iva_prorata"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable config{get { return this.Tables["config"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mainivapay{get { return this.Tables["mainivapay"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mainivapaydetail{get { return this.Tables["mainivapaydetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expense{get { return this.Tables["expense"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenselast{get { return this.Tables["expenselast"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensephase{get { return this.Tables["expensephase"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenseyear{get { return this.Tables["expenseyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payment{get { return this.Tables["payment"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable registry{get { return this.Tables["registry"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenseview{get { return this.Tables["expenseview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomeview{get { return this.Tables["incomeview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable income{get { return this.Tables["income"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomeyear{get { return this.Tables["incomeyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomelast{get { return this.Tables["incomelast"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomephase{get { return this.Tables["incomephase"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable fin{get { return this.Tables["fin"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable upb{get { return this.Tables["upb"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable proceeds{get { return this.Tables["proceeds"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoicekind{get { return this.Tables["invoicekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoicekindyear{get { return this.Tables["invoicekindyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mainivapayexpense{get { return this.Tables["mainivapayexpense"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mainivapayincome{get { return this.Tables["mainivapayincome"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaForm(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "vistaForm";
this.Prefix = "";
this.Namespace = "http://tempuri.org/vistaForm.xsd";
this.EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("iva_mixed");
	C= new DataColumn("nmixed", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mixed", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nmixed"]};
	T.PrimaryKey = key;

	T= new DataTable("iva_prorata");
	C= new DataColumn("nprorata", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("prorata", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nprorata"]};
	T.PrimaryKey = key;

	T= new DataTable("config");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("agencycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appropriationphasecode", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("assessmentphasecode", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("asset_flagnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("asset_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("assetload_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("boxpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("finvarofficial_default", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("casualcontract_flagrestart", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("currpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deferredexpensephase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deferredincomephase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("electronicimport", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("electronictrasmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("expense_expiringdays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("expensephase", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("flagautopayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagautoproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagepexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagfruitful", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagpayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagrefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("foreignhours", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idacc_accruedcost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_accruedrevenue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_customer", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredcost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredcredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferreddebit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredrevenue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivapayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivarefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_patrimony", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_pl", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_supplier", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_admincar", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_foot", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_owncar", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idclawback", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinexpense", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinexpensesurplus", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinincomesurplus", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivapayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivarefund", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idregauto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("importappname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("income_expiringdays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("incomephase", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("linktoinvoice", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("minpayment", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("minrefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("motivelen", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("motiveprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motiveseparator", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("payment_finlevel", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("payment_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("payment_flagautoprintdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("prevpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("proceeds_finlevel", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("proceeds_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("proceeds_flagautoprintdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("profservice_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refundagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("wageaddition_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idivapayperiodicity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsortingkind1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsortingkind2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsortingkind3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("fin_kind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("taxvaliditykind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("flag_paymentamount", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("automanagekind", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flag_autodocnumbering", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagbank_grouping", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cashvaliditykind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("wageimportappname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("balancekind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("idpaymethodabi", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpaymethodnoabi", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("iban_f24", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cudactivitycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("startivabalance", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flagivapaybyrow", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_unabatable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_unabatable_refund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("invoice_flagregister", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("default_idfinvarstatus", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagivaregphase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainflagpayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainflagrefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainidfinivapayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainidfinivarefund", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainminpayment", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainminrefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainpaymentagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainrefundagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainflagivaregphase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainstartivabalance", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainidacc_unabatable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainidacc_unabatable_refund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment_internal", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund_internal", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagva3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagrefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagpayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refundagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymentagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivarefund12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivapayment12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("minrefund12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("minpayment12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idacc_ivapayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivarefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment_internal12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund_internal12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("startivabalance12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainrefundagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainpaymentagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainflagrefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainflagpayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainidfinivarefund12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainidfinivapayment12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainminrefund12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainminpayment12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainstartivabalance12", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("mainivapay");
	C= new DataColumn("ymainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("assesmentdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("creditamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("creditamountdeferred", typeof(System.Decimal), ""));
	C= new DataColumn("datemainivapay", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("debitamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("debitamountdeferred", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mixed", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("paymentamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("paymentdetails", typeof(System.String), ""));
	C= new DataColumn("paymentkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("prorata", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("refundamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("totalcredit", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("totaldebit", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("nmonth", typeof(System.Int32), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("referenceyear", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ivaintrastat12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxableintrastat12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("creditamount12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("creditamountdeferred12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("debitamount12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("debitamountdeferred12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("paymentamount12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("refundamount12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("totalcredit12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("totaldebit12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Byte), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ymainivapay"], 	T.Columns["nmainivapay"]};
	T.PrimaryKey = key;

	T= new DataTable("mainivapaydetail");
	C= new DataColumn("nmainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ymainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ivadeferred", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mixed", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prorata", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unabatable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unabatabledeferred", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivanet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivanetdeferred", typeof(System.Decimal), ""));
	C= new DataColumn("idivaregisterkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddbdepartment", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("iva", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxable12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxabledeferred12", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["nmainivapay"], 	T.Columns["ymainivapay"], 	T.Columns["idivaregisterkind"], 	T.Columns["iddbdepartment"]};
	T.PrimaryKey = key;

	T= new DataTable("expense");
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmov", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idclawback", typeof(System.Int32), ""));
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("parentidexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idformerexpense", typeof(System.Int32), ""));
	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iddeputy", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idregistrypaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idser", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ivaamount", typeof(System.Decimal), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymentdescr", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refexternaldoc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("servicestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("servicestop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idpaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("kpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idaccdebit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("biccode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymethod_flag", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymethod_allowdeputy", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("extracode", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("expensephase");
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nphase"]};
	T.PrimaryKey = key;

	T= new DataTable("expenseyear");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ayear"], 	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("payment");
	C= new DataColumn("npay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypay", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("adate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("annulmentdate", typeof(System.DateTime), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("printdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idstamphandling", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("kpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("kpaymenttransmission", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kpay"]};
	T.PrimaryKey = key;

	T= new DataTable("registry");
	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idreg"]};
	T.PrimaryKey = key;

	T= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("phase", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmov", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("parentidexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentymov", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("parentnmov", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idformerexpense", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("formerymov", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("formernmov", typeof(System.Int32), ""));
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codefin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("finance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("upb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("kpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ypay", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("npay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymentadate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayearstartamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idregistrypaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iddeputy", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("deputy", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refexternaldoc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentdescr", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idser", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("service", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeser", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("servicestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("servicestop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ivaamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("totflag", typeof(System.Byte), ""));
	C= new DataColumn("flagarrear", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idclawback", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("clawback", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("clawbackref", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("npaymenttransmission", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("transmissiondate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idaccdebit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeaccdebit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!livprecedente", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!livprecedente", typeof(System.String), ""));
	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("phase", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmov", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("parentymov", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("parentnmov", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentidinc", typeof(System.Int32), ""));
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codefin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("finance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("upb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("kpro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ypro", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("npro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayearstartamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unpartitioned", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Byte), ""));
	C= new DataColumn("totflag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagarrear", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nproceedstransmission", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("transmissiondate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idacccredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeacccredit", typeof(System.String), ""));
	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
	T= new DataTable("income");
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmov", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("parentidinc", typeof(System.Int32), ""));
	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("incomeyear");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idinc"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("incomelast");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idpro", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("kpro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idacccredit", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("incomephase");
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nphase"]};
	T.PrimaryKey = key;

	T= new DataTable("fin");
	C= new DataColumn("codefin", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfin"]};
	T.PrimaryKey = key;

	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idupb"]};
	T.PrimaryKey = key;

	T= new DataTable("proceeds");
	C= new DataColumn("npro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypro", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("annulmentdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("printdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("kpro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("kproceedstransmission", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idstamphandling", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kpro"]};
	T.PrimaryKey = key;

	T= new DataTable("invoicekind");
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeinvkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flag_autodocnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinvkind"]};
	T.PrimaryKey = key;

	T= new DataTable("invoicekindyear");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idacc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferred", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_discount", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idacc_unabatable", typeof(System.String), ""));
	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idacc_intra", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferred_intra", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_unabatable_intra", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ayear"], 	T.Columns["idinvkind"]};
	T.PrimaryKey = key;

	T= new DataTable("mainivapayexpense");
	C= new DataColumn("ymainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ymainivapay"], 	T.Columns["nmainivapay"], 	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("mainivapayincome");
	C= new DataColumn("ymainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ymainivapay"], 	T.Columns["nmainivapay"], 	T.Columns["idinc"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["mainivapay"];
TChild= Tables["mainivapayincome"];
CPar = new DataColumn[2]{TPar.Columns["ymainivapay"], TPar.Columns["nmainivapay"]};
CChild = new DataColumn[2]{TChild.Columns["ymainivapay"], TChild.Columns["nmainivapay"]};
Relations.Add(new DataRelation("FK_mainivapay_mainivapayincome",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["mainivapayincome"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("FK_income_mainivapayincome",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["mainivapayexpense"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("FK_expense_mainivapayexpense",CPar,CChild));

TPar= Tables["mainivapay"];
TChild= Tables["mainivapayexpense"];
CPar = new DataColumn[2]{TPar.Columns["ymainivapay"], TPar.Columns["nmainivapay"]};
CChild = new DataColumn[2]{TChild.Columns["ymainivapay"], TChild.Columns["nmainivapay"]};
Relations.Add(new DataRelation("FK_mainivapay_mainivapayexpense",CPar,CChild));

TPar= Tables["invoicekind"];
TChild= Tables["invoicekindyear"];
CPar = new DataColumn[1]{TPar.Columns["idinvkind"]};
CChild = new DataColumn[1]{TChild.Columns["idinvkind"]};
Relations.Add(new DataRelation("FK_invoicekind_invoicekindyear",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomelast"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("FK_income_incomelast",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomeyear"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("FK_income_incomeyear",CPar,CChild));

TPar= Tables["fin"];
TChild= Tables["incomeyear"];
CPar = new DataColumn[1]{TPar.Columns["idfin"]};
CChild = new DataColumn[1]{TChild.Columns["idfin"]};
Relations.Add(new DataRelation("FK_fin_incomeyear",CPar,CChild));

TPar= Tables["upb"];
TChild= Tables["incomeyear"];
CPar = new DataColumn[1]{TPar.Columns["idupb"]};
CChild = new DataColumn[1]{TChild.Columns["idupb"]};
Relations.Add(new DataRelation("FK_upb_incomeyear",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["parentidinc"]};
Relations.Add(new DataRelation("FK_income_income",CPar,CChild));

TPar= Tables["incomephase"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["nphase"]};
CChild = new DataColumn[1]{TChild.Columns["nphase"]};
Relations.Add(new DataRelation("FK_incomephase_income",CPar,CChild));

TPar= Tables["registry"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["idreg"]};
CChild = new DataColumn[1]{TChild.Columns["idreg"]};
Relations.Add(new DataRelation("FK_registry_income",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expenseyear"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("FK_expense_expenseyear",CPar,CChild));

TPar= Tables["upb"];
TChild= Tables["expenseyear"];
CPar = new DataColumn[1]{TPar.Columns["idupb"]};
CChild = new DataColumn[1]{TChild.Columns["idupb"]};
Relations.Add(new DataRelation("FK_upb_expenseyear",CPar,CChild));

TPar= Tables["fin"];
TChild= Tables["expenseyear"];
CPar = new DataColumn[1]{TPar.Columns["idfin"]};
CChild = new DataColumn[1]{TChild.Columns["idfin"]};
Relations.Add(new DataRelation("FK_fin_expenseyear",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expenselast"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("FK_expense_expenselast",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["parentidexp"]};
Relations.Add(new DataRelation("FK_expense_expense",CPar,CChild));

TPar= Tables["expensephase"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["nphase"]};
CChild = new DataColumn[1]{TChild.Columns["nphase"]};
Relations.Add(new DataRelation("FK_expensephase_expense",CPar,CChild));

TPar= Tables["registry"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["idreg"]};
CChild = new DataColumn[1]{TChild.Columns["idreg"]};
Relations.Add(new DataRelation("FK_registry_expense",CPar,CChild));

TPar= Tables["mainivapay"];
TChild= Tables["mainivapaydetail"];
CPar = new DataColumn[2]{TPar.Columns["ymainivapay"], TPar.Columns["nmainivapay"]};
CChild = new DataColumn[2]{TChild.Columns["ymainivapay"], TChild.Columns["nmainivapay"]};
Relations.Add(new DataRelation("FK_mainivapay_mainivapaydetail",CPar,CChild));

}
}
}
