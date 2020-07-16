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

using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace proceedspart_detail {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Assegnazione incasso al bilancio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable proceedspart		{get { return Tables["proceedspart"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable finview		{get { return Tables["finview"];}}
	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable upb		{get { return Tables["upb"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable proceedspartview		{get { return Tables["proceedspartview"];}}
	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable config		{get { return Tables["config"];}}
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
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// PROCEEDSPART /////////////////////////////////
	T= new DataTable("proceedspart");
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nproceedspart", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idfin", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yproceedspart", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
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
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("!codeupb", typeof(String)));
	T.Columns.Add( new DataColumn("!upb", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"], T.Columns["nproceedspart"]};


	//////////////////// FINVIEW /////////////////////////////////
	T= new DataTable("finview");
	C= new DataColumn("idfin", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("finpart", typeof(String)));
	C= new DataColumn("codefin", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridfin", typeof(Int32)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(String)));
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("prevision", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("currentprevision", typeof(Decimal)));
	T.Columns.Add( new DataColumn("availableprevision", typeof(Decimal)));
	T.Columns.Add( new DataColumn("previousprevision", typeof(Decimal)));
	T.Columns.Add( new DataColumn("secondaryprev", typeof(Decimal)));
	T.Columns.Add( new DataColumn("currentsecondaryprev", typeof(Decimal)));
	T.Columns.Add( new DataColumn("availablesecondaryprev", typeof(Decimal)));
	T.Columns.Add( new DataColumn("previoussecondaryprev", typeof(Decimal)));
	T.Columns.Add( new DataColumn("currentarrears", typeof(Decimal)));
	T.Columns.Add( new DataColumn("previousarrears", typeof(Decimal)));
	T.Columns.Add( new DataColumn("prevision2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("prevision3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("prevision4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("prevision5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("upb", typeof(String));
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
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idfin"]};


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


	//////////////////// PROCEEDSPARTVIEW /////////////////////////////////
	T= new DataTable("proceedspartview");
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nproceedspart", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yproceedspart", typeof(Int16));
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
	C= new DataColumn("idfin", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codefin", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("finance", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("upb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("financeincome", typeof(String)));
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
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"], T.Columns["nproceedspart"]};


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
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{finview.Columns["idfin"]};
	CChild = new DataColumn[1]{proceedspart.Columns["idfin"]};
	Relations.Add(new DataRelation("finviewproceedspart",CPar,CChild,false));

	CPar = new DataColumn[1]{upb.Columns["idupb"]};
	CChild = new DataColumn[1]{proceedspart.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_proceedspart",CPar,CChild,false));

	#endregion

}
}
}
