/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace mainivapay_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mainivapay{get { return this.Tables["mainivapay"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mainivapaydetailview{get { return this.Tables["mainivapaydetailview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensephase{get { return this.Tables["expensephase"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomephase{get { return this.Tables["incomephase"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable config{get { return this.Tables["config"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mainivapayincomeview{get { return this.Tables["mainivapayincomeview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mainivapayexpenseview{get { return this.Tables["mainivapayexpenseview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable dettliquidazioneivaview_debito{get { return this.Tables["dettliquidazioneivaview_debito"];}}

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

	T= new DataTable("mainivapaydetailview");
	C= new DataColumn("ymainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nmonth", typeof(System.Int32), ""));
	C= new DataColumn("idivaregisterkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeivaregisterkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("registerclass", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("iva", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivadeferred", typeof(System.Decimal), ""));
	C= new DataColumn("ivatotal", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("unabatable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unabatabledeferred", typeof(System.Decimal), ""));
	C= new DataColumn("unabatabletotal", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("prorata", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mixed", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivanet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivanetdeferred", typeof(System.Decimal), ""));
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

	T.Columns.Add(new DataColumn("!ivacredit", typeof(System.Decimal), ""));
	C= new DataColumn("iddbdepartment", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("department", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("referenceyear", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagactivity", typeof(System.Int16), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["ymainivapay"], 	T.Columns["nmainivapay"], 	T.Columns["idivaregisterkind"], 	T.Columns["iddbdepartment"]};
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
	T.Columns.Add(new DataColumn("idacc_mainivapayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment_internal", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund_internal", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainstartivabalance12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainflagpayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainflagrefund12", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("mainivapayincomeview");
	C= new DataColumn("ymainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinc", typeof(System.Int32), "");
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

	T.Columns.Add(new DataColumn("parentidinc", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentymov", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("parentnmov", typeof(System.Int32), ""));
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
	C= new DataColumn("unpartitioned", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flag", typeof(System.Byte), ""));
	C= new DataColumn("totflag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagarrear", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ymainivapay"], 	T.Columns["nmainivapay"], 	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("mainivapayexpenseview");
	C= new DataColumn("ymainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("netamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("totalamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayearstartamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idpaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentdescr", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idser", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("service", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("servicestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("servicestop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ivaamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("totflag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("flagarrear", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ymainivapay"], 	T.Columns["nmainivapay"], 	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("dettliquidazioneivaview_debito");
	C= new DataColumn("ymainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmainivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nmonth", typeof(System.Int32), ""));
	C= new DataColumn("idivaregisterkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeivaregisterkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("registerclass", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("iva", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivadeferred", typeof(System.Decimal), ""));
	C= new DataColumn("ivatotal", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("unabatable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unabatabledeferred", typeof(System.Decimal), ""));
	C= new DataColumn("unabatabletotal", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("prorata", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mixed", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivanet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivanetdeferred", typeof(System.Decimal), ""));
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

	T.Columns.Add(new DataColumn("department", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("referenceyear", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagactivity", typeof(System.Int16), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["ymainivapay"], 	T.Columns["nmainivapay"], 	T.Columns["idivaregisterkind"], 	T.Columns["iddbdepartment"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["mainivapay"];
TChild= Tables["dettliquidazioneivaview_debito"];
CPar = new DataColumn[2]{TPar.Columns["ymainivapay"], TPar.Columns["nmainivapay"]};
CChild = new DataColumn[2]{TChild.Columns["ymainivapay"], TChild.Columns["nmainivapay"]};
Relations.Add(new DataRelation("FK_mainivapay_dettliquidazioneivaview_debito",CPar,CChild));

TPar= Tables["mainivapay"];
TChild= Tables["mainivapayexpenseview"];
CPar = new DataColumn[2]{TPar.Columns["ymainivapay"], TPar.Columns["nmainivapay"]};
CChild = new DataColumn[2]{TChild.Columns["ymainivapay"], TChild.Columns["nmainivapay"]};
Relations.Add(new DataRelation("FK_mainivapay_mainivapayexpenseview",CPar,CChild));

TPar= Tables["mainivapay"];
TChild= Tables["mainivapayincomeview"];
CPar = new DataColumn[2]{TPar.Columns["ymainivapay"], TPar.Columns["nmainivapay"]};
CChild = new DataColumn[2]{TChild.Columns["ymainivapay"], TChild.Columns["nmainivapay"]};
Relations.Add(new DataRelation("FK_mainivapay_mainivapayincomeview",CPar,CChild));

TPar= Tables["mainivapay"];
TChild= Tables["mainivapaydetailview"];
CPar = new DataColumn[2]{TPar.Columns["ymainivapay"], TPar.Columns["nmainivapay"]};
CChild = new DataColumn[2]{TChild.Columns["ymainivapay"], TChild.Columns["nmainivapay"]};
Relations.Add(new DataRelation("FK_mainivapay_mainivapaydetailview",CPar,CChild));

}
}
}
