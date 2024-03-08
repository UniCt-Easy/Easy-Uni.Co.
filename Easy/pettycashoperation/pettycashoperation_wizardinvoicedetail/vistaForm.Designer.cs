
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
namespace pettycashoperation_wizardinvoicedetail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashoperation 		=> Tables["pettycashoperation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense 		=> Tables["expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tipomovimento 		=> Tables["tipomovimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycash 		=> Tables["pettycash"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashoperationinvoice 		=> Tables["pettycashoperationinvoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoice 		=> Tables["invoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetail 		=> Tables["invoicedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivakind 		=> Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashoperationview 		=> Tables["pettycashoperationview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashsetup 		=> Tables["pettycashsetup"];

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
	//////////////////// PETTYCASHOPERATION /////////////////////////////////
	var tpettycashoperation= new DataTable("pettycashoperation");
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	tpettycashoperation.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	tpettycashoperation.Columns.Add( new DataColumn("doc", typeof(string)));
	tpettycashoperation.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tpettycashoperation.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	tpettycashoperation.Columns.Add( new DataColumn("nrestore", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tpettycashoperation.Columns.Add( new DataColumn("txt", typeof(string)));
	tpettycashoperation.Columns.Add( new DataColumn("yrestore", typeof(short)));
	tpettycashoperation.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	tpettycashoperation.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	tpettycashoperation.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tpettycashoperation.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tpettycashoperation.Columns.Add( new DataColumn("idexp", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	tpettycashoperation.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor3", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	tpettycashoperation.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tpettycashoperation);
	tpettycashoperation.PrimaryKey =  new DataColumn[]{tpettycashoperation.Columns["noperation"], tpettycashoperation.Columns["yoperation"], tpettycashoperation.Columns["idpettycash"]};


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
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new DataTable("expense");
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("doc", typeof(string)));
	texpense.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpense.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	texpense.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	texpense.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("idclawback", typeof(int)));
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("idman", typeof(int)));
	texpense.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpense.Columns.Add( new DataColumn("autocode", typeof(int)));
	Tables.Add(texpense);
	texpense.PrimaryKey =  new DataColumn[]{texpense.Columns["idexp"]};


	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new DataTable("expensephase");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	Tables.Add(texpensephase);
	texpensephase.PrimaryKey =  new DataColumn[]{texpensephase.Columns["nphase"]};


	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	var ttipomovimento= new DataTable("tipomovimento");
	C= new DataColumn("idtipo", typeof(int));
	C.AllowDBNull=false;
	ttipomovimento.Columns.Add(C);
	ttipomovimento.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(ttipomovimento);
	ttipomovimento.PrimaryKey =  new DataColumn[]{ttipomovimento.Columns["idtipo"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// PETTYCASH /////////////////////////////////
	var tpettycash= new DataTable("pettycash");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	tpettycash.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	tpettycash.Columns.Add( new DataColumn("pettycode", typeof(string)));
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	tpettycash.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tpettycash);
	tpettycash.PrimaryKey =  new DataColumn[]{tpettycash.Columns["idpettycash"]};


	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("formerymov", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("formernmov", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("ypay", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeser", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("clawbackref", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("npaymenttransmission", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("idaccdebit", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeaccdebit", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(texpenseview);

	//////////////////// PETTYCASHOPERATIONINVOICE /////////////////////////////////
	var tpettycashoperationinvoice= new DataTable("pettycashoperationinvoice");
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	Tables.Add(tpettycashoperationinvoice);
	tpettycashoperationinvoice.PrimaryKey =  new DataColumn[]{tpettycashoperationinvoice.Columns["yoperation"], tpettycashoperationinvoice.Columns["noperation"], tpettycashoperationinvoice.Columns["yinv"], tpettycashoperationinvoice.Columns["ninv"], tpettycashoperationinvoice.Columns["idpettycash"], tpettycashoperationinvoice.Columns["idinvkind"]};


	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new DataTable("invoice");
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("doc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoice.Columns.Add( new DataColumn("flagdeferred", typeof(string)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("packinglistnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("registryreference", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tinvoice.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_origin", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_provenance", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_destination", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idcountry_origin", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idcountry_destination", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idintrastatkind", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("idintrastatpaymethod", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("iso_payment", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idblacklist", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("flag", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinvoice);
	tinvoice.PrimaryKey =  new DataColumn[]{tinvoice.Columns["ninv"], tinvoice.Columns["yinv"], tinvoice.Columns["idinvkind"]};


	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new DataTable("invoicedetail");
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("paymentcompetency", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	tinvoicedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("nman", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("yman", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("estimrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("nestim", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("yestim", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("ninv_main", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("yinv_main", typeof(short)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatcode", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatmeasure", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("weight", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("va3type", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("intrastatoperationkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatservice", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatsupplymethod", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("!aliquota", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("!totaleriga", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("!idfin", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("!idman", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("!idexp", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("!percindetraibilita", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idunit", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("flag", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("rownum_main", typeof(int)));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.PrimaryKey =  new DataColumn[]{tinvoicedetail.Columns["ninv"], tinvoicedetail.Columns["rownum"], tinvoicedetail.Columns["yinv"], tinvoicedetail.Columns["idinvkind"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	tinvoicekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("formatstring", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("active", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new DataTable("ivakind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("active", typeof(string)));
	tivakind.Columns.Add( new DataColumn("idivataxablekind", typeof(int)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("codeivakind", typeof(string)));
	tivakind.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tivakind);
	tivakind.PrimaryKey =  new DataColumn[]{tivakind.Columns["idivakind"]};


	//////////////////// PETTYCASHOPERATIONVIEW /////////////////////////////////
	var tpettycashoperationview= new DataTable("pettycashoperationview");
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationview.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationview.Columns.Add(C);
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationview.Columns.Add(C);
	tpettycashoperationview.Columns.Add( new DataColumn("pettycash", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("pettycode", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tpettycashoperationview.Columns.Add(C);
	C= new DataColumn("kind", typeof(string));
	C.ReadOnly=true;
	tpettycashoperationview.Columns.Add(C);
	tpettycashoperationview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpettycashoperationview.Columns.Add( new DataColumn("registry", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("codemotive_cost", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("motive_cost", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("codemotive_debit", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("motive_debit", typeof(string)));
	C= new DataColumn("flagdocumented", typeof(string));
	C.ReadOnly=true;
	tpettycashoperationview.Columns.Add(C);
	tpettycashoperationview.Columns.Add( new DataColumn("idfin", typeof(int)));
	C= new DataColumn("finpart", typeof(string));
	C.ReadOnly=true;
	tpettycashoperationview.Columns.Add(C);
	tpettycashoperationview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("finance", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("upb", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("yrestore", typeof(short)));
	tpettycashoperationview.Columns.Add( new DataColumn("nrestore", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationview.Columns.Add(C);
	tpettycashoperationview.Columns.Add( new DataColumn("doc", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tpettycashoperationview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationview.Columns.Add(C);
	tpettycashoperationview.Columns.Add( new DataColumn("idman", typeof(int)));
	tpettycashoperationview.Columns.Add( new DataColumn("manager", typeof(string)));
	tpettycashoperationview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tpettycashoperationview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tpettycashoperationview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tpettycashoperationview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tpettycashoperationview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tpettycashoperationview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tpettycashoperationview.Columns.Add( new DataColumn("!nmov", typeof(int)));
	tpettycashoperationview.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tpettycashoperationview.Columns.Add( new DataColumn("!phase", typeof(string)));
	Tables.Add(tpettycashoperationview);
	tpettycashoperationview.PrimaryKey =  new DataColumn[]{tpettycashoperationview.Columns["yoperation"], tpettycashoperationview.Columns["noperation"], tpettycashoperationview.Columns["idpettycash"]};


	//////////////////// PETTYCASHSETUP /////////////////////////////////
	var tpettycashsetup= new DataTable("pettycashsetup");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	tpettycashsetup.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	tpettycashsetup.Columns.Add( new DataColumn("registrymanager", typeof(int)));
	tpettycashsetup.Columns.Add( new DataColumn("autoclassify", typeof(string)));
	tpettycashsetup.Columns.Add( new DataColumn("idacc", typeof(string)));
	tpettycashsetup.Columns.Add( new DataColumn("idfinexpense", typeof(int)));
	tpettycashsetup.Columns.Add( new DataColumn("idfinincome", typeof(int)));
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	Tables.Add(tpettycashsetup);
	tpettycashsetup.PrimaryKey =  new DataColumn[]{tpettycashsetup.Columns["ayear"], tpettycashsetup.Columns["idpettycash"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	var cChild = new []{invoicedetail.Columns["ninv"], invoicedetail.Columns["yinv"], invoicedetail.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoicedetail_invoice",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{invoicedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("FK_invoicedetail_ivakind",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoice_invoicekind",cPar,cChild,false));

	cPar = new []{pettycashoperation.Columns["noperation"], pettycashoperation.Columns["yoperation"], pettycashoperation.Columns["idpettycash"]};
	cChild = new []{pettycashoperationinvoice.Columns["noperation"], pettycashoperationinvoice.Columns["yoperation"], pettycashoperationinvoice.Columns["idpettycash"]};
	Relations.Add(new DataRelation("FK_pettycashoperation_pettycashoperationinvoice",cPar,cChild,false));

	cPar = new []{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	cChild = new []{pettycashoperationinvoice.Columns["ninv"], pettycashoperationinvoice.Columns["yinv"], pettycashoperationinvoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoice_pettycashoperationinvoice",cPar,cChild,false));

	cPar = new []{pettycash.Columns["idpettycash"]};
	cChild = new []{pettycashoperation.Columns["idpettycash"]};
	Relations.Add(new DataRelation("FK_pettycash_pettycashoperation",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{pettycashoperation.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_expenseview_pettycashoperation",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{pettycashoperation.Columns["idman"]};
	Relations.Add(new DataRelation("FK_manager_pettycashoperation",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{pettycashoperation.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_pettycashoperation",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{pettycashoperation.Columns["idfin"]};
	Relations.Add(new DataRelation("FK_fin_pettycashoperation",cPar,cChild,false));

	#endregion

}
}
}
