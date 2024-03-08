
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace f24ordinario_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24ordinario 		=> Tables["f24ordinario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fiscaltaxregion 		=> Tables["fiscaltaxregion"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable license 		=> Tables["license"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable monthname 		=> Tables["monthname"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxpayview 		=> Tables["taxpayview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapay 		=> Tables["ivapay"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24ordinariodetail 		=> Tables["f24ordinariodetail"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// F24ORDINARIO /////////////////////////////////
	var tf24ordinario= new DataTable("f24ordinario");
	C= new DataColumn("idf24ordinario", typeof(int));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	tf24ordinario.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("nmonth", typeof(int));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("paymentdate", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	tf24ordinario.Columns.Add( new DataColumn("taxpay_start", typeof(DateTime)));
	tf24ordinario.Columns.Add( new DataColumn("taxpay_stop", typeof(DateTime)));
	Tables.Add(tf24ordinario);
	tf24ordinario.PrimaryKey =  new DataColumn[]{tf24ordinario.Columns["idf24ordinario"]};


	//////////////////// FISCALTAXREGION /////////////////////////////////
	var tfiscaltaxregion= new DataTable("fiscaltaxregion");
	C= new DataColumn("idfiscaltaxregion", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	Tables.Add(tfiscaltaxregion);

	//////////////////// LICENSE /////////////////////////////////
	var tlicense= new DataTable("license");
	C= new DataColumn("dummykey", typeof(string));
	C.AllowDBNull=false;
	tlicense.Columns.Add(C);
	tlicense.Columns.Add( new DataColumn("address1", typeof(string)));
	tlicense.Columns.Add( new DataColumn("address2", typeof(string)));
	tlicense.Columns.Add( new DataColumn("agency", typeof(string)));
	tlicense.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tlicense.Columns.Add( new DataColumn("agencyname", typeof(string)));
	tlicense.Columns.Add( new DataColumn("annotations", typeof(string)));
	tlicense.Columns.Add( new DataColumn("cap", typeof(string)));
	tlicense.Columns.Add( new DataColumn("cf", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkbackup1", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkbackup2", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkflag", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checklic", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkman", typeof(string)));
	tlicense.Columns.Add( new DataColumn("country", typeof(string)));
	tlicense.Columns.Add( new DataColumn("dbname", typeof(string)));
	tlicense.Columns.Add( new DataColumn("department", typeof(string)));
	tlicense.Columns.Add( new DataColumn("departmentcode", typeof(string)));
	tlicense.Columns.Add( new DataColumn("departmentname", typeof(string)));
	tlicense.Columns.Add( new DataColumn("email", typeof(string)));
	tlicense.Columns.Add( new DataColumn("expiringlic", typeof(DateTime)));
	tlicense.Columns.Add( new DataColumn("expiringman", typeof(DateTime)));
	tlicense.Columns.Add( new DataColumn("fax", typeof(string)));
	tlicense.Columns.Add( new DataColumn("idcity", typeof(int)));
	tlicense.Columns.Add( new DataColumn("iddb", typeof(int)));
	tlicense.Columns.Add( new DataColumn("idreg", typeof(int)));
	tlicense.Columns.Add( new DataColumn("lickind", typeof(string)));
	tlicense.Columns.Add( new DataColumn("licstatus", typeof(string)));
	tlicense.Columns.Add( new DataColumn("location", typeof(string)));
	tlicense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tlicense.Columns.Add( new DataColumn("lu", typeof(string)));
	tlicense.Columns.Add( new DataColumn("mankind", typeof(string)));
	tlicense.Columns.Add( new DataColumn("manstatus", typeof(string)));
	tlicense.Columns.Add( new DataColumn("nmsgs", typeof(int)));
	tlicense.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tlicense.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tlicense.Columns.Add( new DataColumn("referent", typeof(string)));
	tlicense.Columns.Add( new DataColumn("sent", typeof(string)));
	tlicense.Columns.Add( new DataColumn("serverbackup1", typeof(string)));
	tlicense.Columns.Add( new DataColumn("serverbackup2", typeof(string)));
	tlicense.Columns.Add( new DataColumn("servername", typeof(string)));
	tlicense.Columns.Add( new DataColumn("swmorecode", typeof(string)));
	tlicense.Columns.Add( new DataColumn("swmoreflag", typeof(int)));
	Tables.Add(tlicense);
	tlicense.PrimaryKey =  new DataColumn[]{tlicense.Columns["dummykey"]};


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appropriationphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("assessmentphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("asset_flagnumbering", typeof(string)));
	tconfig.Columns.Add( new DataColumn("asset_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("assetload_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("boxpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("finvarofficial_default", typeof(string)));
	tconfig.Columns.Add( new DataColumn("casualcontract_flagrestart", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("currpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredexpensephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredincomephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronicimport", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronictrasmission", typeof(string)));
	tconfig.Columns.Add( new DataColumn("expense_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("expensephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flagautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagepexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("foreignhours", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_customer", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferreddebit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_patrimony", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_pl", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_supplier", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_admincar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_foot", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_owncar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idclawback", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpense", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpensesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinincomesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
	tconfig.Columns.Add( new DataColumn("importappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("income_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("incomephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("minpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("motivelen", typeof(short)));
	tconfig.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	tconfig.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	tconfig.Columns.Add( new DataColumn("payment_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("paymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("taxvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flag_paymentamount", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("automanagekind", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("wageimportappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("balancekind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("idpaymethodabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idpaymethodnoabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("iban_f24", typeof(string)));
	tconfig.Columns.Add( new DataColumn("cudactivitycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("startivabalance", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("flagivapaybyrow", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_refund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("invoice_flagregister", typeof(string)));
	tconfig.Columns.Add( new DataColumn("default_idfinvarstatus", typeof(short)));
	tconfig.Columns.Add( new DataColumn("flagivaregphase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainidfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainminpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainminrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainpaymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainrefundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainflagivaregphase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainstartivabalance", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainidacc_unabatable", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidacc_unabatable_refund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment_internal", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund_internal", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagva3", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("paymentagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("minrefund12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minpayment12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment_internal12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund_internal12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("startivabalance12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainrefundagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainpaymentagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainflagrefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagpayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidfinivarefund12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainidfinivapayment12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainminrefund12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainminpayment12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainstartivabalance12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("idreg_csa", typeof(int)));
	tconfig.Columns.Add( new DataColumn("finvar_warnmail", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_revenue_gross_csa", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idfinincome_gross_csa", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor1_stock", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor2_stock", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor3_stock", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idinpscenter", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity_instit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfin_store", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flagpcashautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpcashautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("email", typeof(string)));
	tconfig.Columns.Add( new DataColumn("lcard", typeof(string)));
	tconfig.Columns.Add( new DataColumn("booking_on_invoice", typeof(string)));
	tconfig.Columns.Add( new DataColumn("itineration_directauth", typeof(string)));
	tconfig.Columns.Add( new DataColumn("email_f24", typeof(string)));
	tconfig.Columns.Add( new DataColumn("csa_flaggroupby_income", typeof(string)));
	tconfig.Columns.Add( new DataColumn("csa_flaggroupby_expense", typeof(string)));
	tconfig.Columns.Add( new DataColumn("csa_flaglinktoexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idsiopeincome_csa", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idacc_invoicetoemit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_invoicetoreceive", typeof(string)));
	tconfig.Columns.Add( new DataColumn("epannualthreeshold", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("flagbalance_csa", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagiva_immediate_or_deferred", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagenabletransmission", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagsplitpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("startivabalancesplit", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("paymentagencysplit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapaymentsplit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flagpaymentsplit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_split", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapaymentsplit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("agencynumber", typeof(string)));
	tconfig.Columns.Add( new DataColumn("femode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_economic_result", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_previous_economic_result", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_bankpaydoc", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_bankprodoc", typeof(string)));
	tconfig.Columns.Add( new DataColumn("csa_flagtransmissionlinking", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_forwarder", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idivakind_forwarder", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_grantrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_grantdeferredcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_assetrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_prorata_cost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_prorata_revenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeivaexp", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeiva12exp", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeivasplitexp", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeivainc", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeiva12inc", typeof(int)));
	tconfig.Columns.Add( new DataColumn("csa_nominativo", typeof(string)));
	tconfig.Columns.Add( new DataColumn("csa_idchargehandling", typeof(int)));
	tconfig.Columns.Add( new DataColumn("csa_flag", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flag", typeof(int)));
	tconfig.Columns.Add( new DataColumn("assignedrequirement", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("risconta_ammortamenti_futuri", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_estera", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeivavendita", typeof(int)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// MONTHNAME /////////////////////////////////
	var tmonthname= new DataTable("monthname");
	C= new DataColumn("code", typeof(int));
	C.AllowDBNull=false;
	tmonthname.Columns.Add(C);
	tmonthname.Columns.Add( new DataColumn("cfvalue", typeof(string)));
	tmonthname.Columns.Add( new DataColumn("title", typeof(string)));
	Tables.Add(tmonthname);
	tmonthname.PrimaryKey =  new DataColumn[]{tmonthname.Columns["code"]};


	//////////////////// TAXPAYVIEW /////////////////////////////////
	var ttaxpayview= new DataTable("taxpayview");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("taxkind", typeof(string));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("ytaxpay", typeof(short));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("ntaxpay", typeof(int));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	ttaxpayview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	ttaxpayview.Columns.Add( new DataColumn("idf24ep", typeof(int)));
	ttaxpayview.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	ttaxpayview.Columns.Add( new DataColumn("idf24ordinario", typeof(int)));
	ttaxpayview.Columns.Add( new DataColumn("fiscaltaxcodef24ord", typeof(string)));
	Tables.Add(ttaxpayview);
	ttaxpayview.PrimaryKey =  new DataColumn[]{ttaxpayview.Columns["taxcode"], ttaxpayview.Columns["ytaxpay"], ttaxpayview.Columns["ntaxpay"]};


	//////////////////// IVAPAY /////////////////////////////////
	var tivapay= new DataTable("ivapay");
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	tivapay.Columns.Add( new DataColumn("assesmentdate", typeof(DateTime)));
	tivapay.Columns.Add( new DataColumn("creditamount", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("creditamountdeferred", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("dateivapay", typeof(DateTime));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	tivapay.Columns.Add( new DataColumn("debitamount", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("debitamountdeferred", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	tivapay.Columns.Add( new DataColumn("mixed", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("paymentamount", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("paymentdetails", typeof(string)));
	C= new DataColumn("paymentkind", typeof(string));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	tivapay.Columns.Add( new DataColumn("prorata", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("refundamount", typeof(decimal)));
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	tivapay.Columns.Add( new DataColumn("totalcredit", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("totaldebit", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("ivaintrastat12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("taxableintrastat12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("creditamount12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("creditamountdeferred12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("debitamount12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("debitamountdeferred12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("paymentamount12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("refundamount12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("totalcredit12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("totaldebit12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("flag", typeof(byte)));
	tivapay.Columns.Add( new DataColumn("prev_debit", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("prev_debit12", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("totaldebitsplit", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("paymentamountsplit", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("debitamountsplit", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("debitamountdeferredsplit", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("taxablesplit", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("ivasplit", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("prev_debitsplit", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("startcredit_applied", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("advancecomputemethod", typeof(string)));
	tivapay.Columns.Add( new DataColumn("idf24ep", typeof(int)));
	tivapay.Columns.Add( new DataColumn("idf24ordinario", typeof(int)));
	Tables.Add(tivapay);
	tivapay.PrimaryKey =  new DataColumn[]{tivapay.Columns["nivapay"], tivapay.Columns["yivapay"]};


	//////////////////// F24ORDINARIODETAIL /////////////////////////////////
	var tf24ordinariodetail= new DataTable("f24ordinariodetail");
	C= new DataColumn("idf24ordinario", typeof(int));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	C= new DataColumn("codicetributo", typeof(string));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	tf24ordinariodetail.Columns.Add( new DataColumn("codiceufficio", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("codiceatto", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("riferimentoa", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("riferimentob", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("importoadebito", typeof(decimal)));
	tf24ordinariodetail.Columns.Add( new DataColumn("importoacredito", typeof(decimal)));
	tf24ordinariodetail.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("ravvedimentooperoso", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("immobilivariati", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("accontosaldo", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("numeroimmobili", typeof(int)));
	tf24ordinariodetail.Columns.Add( new DataColumn("detrazioneabitazione", typeof(decimal)));
	tf24ordinariodetail.Columns.Add( new DataColumn("idaltrienti", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("idcodicesedealtrienti", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("codiceposizione", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	tf24ordinariodetail.Columns.Add( new DataColumn("idprovincia", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("identificativooperazione", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("identelocale", typeof(int)));
	tf24ordinariodetail.Columns.Add( new DataColumn("catastalecomune", typeof(string)));
	C= new DataColumn("idf24sezione", typeof(string));
	C.AllowDBNull=false;
	tf24ordinariodetail.Columns.Add(C);
	tf24ordinariodetail.Columns.Add( new DataColumn("codiceditta", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("cc_codiceditta", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("numerodiriferimento", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("causaleinail", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("codicesedeinail", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("!f24sezione", typeof(string)));
	tf24ordinariodetail.Columns.Add( new DataColumn("!regionefiscale", typeof(string)));
	Tables.Add(tf24ordinariodetail);
	tf24ordinariodetail.PrimaryKey =  new DataColumn[]{tf24ordinariodetail.Columns["idf24ordinario"], tf24ordinariodetail.Columns["iddetail"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{monthname.Columns["code"]};
	var cChild = new []{f24ordinario.Columns["nmonth"]};
	Relations.Add(new DataRelation("monthname_f24ordinario",cPar,cChild,false));

	cPar = new []{f24ordinario.Columns["idf24ordinario"]};
	cChild = new []{taxpayview.Columns["idf24ordinario"]};
	Relations.Add(new DataRelation("f24ordinario_taxpayview",cPar,cChild,false));

	cPar = new []{f24ordinario.Columns["idf24ordinario"]};
	cChild = new []{ivapay.Columns["idf24ordinario"]};
	Relations.Add(new DataRelation("f24ordinario_ivapay",cPar,cChild,false));

	cPar = new []{f24ordinario.Columns["idf24ordinario"]};
	cChild = new []{f24ordinariodetail.Columns["idf24ordinario"]};
	Relations.Add(new DataRelation("f24ordinario_f24ordinariodetail",cPar,cChild,false));

	cPar = new []{fiscaltaxregion.Columns["idfiscaltaxregion"]};
	cChild = new []{f24ordinariodetail.Columns["idfiscaltaxregion"]};
	Relations.Add(new DataRelation("fiscaltaxregion_f24ordinariodetail",cPar,cChild,false));

	#endregion

}
}
}
