
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


namespace no_table_f24ep {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable no_table{get { return this.Tables["no_table"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable license{get { return this.Tables["license"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable config{get { return this.Tables["config"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

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
	T= new DataTable("no_table");
	C= new DataColumn("idnotable", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idnotable"]};
	T.PrimaryKey = key;

	T= new DataTable("license");
	C= new DataColumn("dummykey", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("address1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("address2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("agency", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("agencycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("agencyname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annotations", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cap", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("checkbackup1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("checkbackup2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("checkflag", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("checklic", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("checkman", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("country", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("dbname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("department", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("departmentcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("departmentname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("expiringlic", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("expiringman", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("fax", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("iddb", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("lickind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("licstatus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("location", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mankind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("manstatus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nmsgs", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("p_iva", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("referent", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sent", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("serverbackup1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("serverbackup2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("servername", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("swmorecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("swmoreflag", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["dummykey"]};
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
	T.Columns.Add(new DataColumn("idreg_csa", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("finvar_warnmail", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagdirectcsaclawback", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_revenue_gross_csa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfinincome_gross_csa", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor1_stock", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor2_stock", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor3_stock", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinpscenter", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idivapayperiodicity_instit", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfin_store", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagpcashautopayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagpcashautoproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lcard", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("booking_on_invoice", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
	T.PrimaryKey = key;

}
}
}
