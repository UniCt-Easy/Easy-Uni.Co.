
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


using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace electronicinvoice_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Seleziona fatture vendita da trasmettere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable electronicinvoice 		=> Tables["electronicinvoice"];

	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable treasurer 		=> Tables["treasurer"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Informazioni ente contabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable license 		=> Tables["license"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoiceview 		=> Tables["invoiceview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting05 		=> Tables["sorting05"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting01 		=> Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting02 		=> Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting03 		=> Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting04 		=> Tables["sorting04"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Fatture di vendita selezionate per la trasmissione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sdi_vendita 		=> Tables["sdi_vendita"];

	///<summary>
	///Codice IPA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ipa 		=> Tables["ipa"];

	///<summary>
	///Riferimento amministrazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sdi_rifamm 		=> Tables["sdi_rifamm"];

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
	//////////////////// ELECTRONICINVOICE /////////////////////////////////
	var telectronicinvoice= new DataTable("electronicinvoice");
	C= new DataColumn("yelectronicinvoice", typeof(short));
	C.AllowDBNull=false;
	telectronicinvoice.Columns.Add(C);
	C= new DataColumn("nelectronicinvoice", typeof(int));
	C.AllowDBNull=false;
	telectronicinvoice.Columns.Add(C);
	telectronicinvoice.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	telectronicinvoice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	telectronicinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	telectronicinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	telectronicinvoice.Columns.Add(C);
	telectronicinvoice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	telectronicinvoice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	telectronicinvoice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	telectronicinvoice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	telectronicinvoice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	telectronicinvoice.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	telectronicinvoice.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	telectronicinvoice.Columns.Add( new DataColumn("ipa_ven_emittente", typeof(string)));
	telectronicinvoice.Columns.Add( new DataColumn("rifamm_ven_emittente", typeof(string)));
	telectronicinvoice.Columns.Add( new DataColumn("ipa_ven_cliente", typeof(string)));
	telectronicinvoice.Columns.Add( new DataColumn("rifamm_ven_cliente", typeof(string)));
	telectronicinvoice.Columns.Add( new DataColumn("pec_ven_cliente", typeof(string)));
	telectronicinvoice.Columns.Add( new DataColumn("email_ven_cliente", typeof(string)));
	Tables.Add(telectronicinvoice);
	telectronicinvoice.PrimaryKey =  new DataColumn[]{telectronicinvoice.Columns["yelectronicinvoice"], telectronicinvoice.Columns["nelectronicinvoice"]};


	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new DataTable("treasurer");
	ttreasurer.Columns.Add( new DataColumn("address", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("agencycodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cabcodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cap", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cc", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cin", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("city", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("depcodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("description", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	C= new DataColumn("flagdefault", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("idaccmotive_payment", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idaccmotive_proceeds", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idbank", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idcab", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	C= new DataColumn("codetreasurer", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("idtreasurer", typeof(int));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("spexportexp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagmultiexp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("fileextension", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("spexportinc", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("iban", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("bic", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cccbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cincbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idbankcbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idcabcbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("ibancbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("siacodecbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("reccbikind", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("trasmcode", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("motivelen", typeof(short)));
	ttreasurer.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("annotations", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagedisp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idsor01", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor02", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor03", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor04", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor05", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("billcode", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("active", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flag", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("header", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("savepath", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("departmentname_fe", typeof(string)));
	Tables.Add(ttreasurer);
	ttreasurer.PrimaryKey =  new DataColumn[]{ttreasurer.Columns["idtreasurer"]};


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
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


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


	//////////////////// INVOICEVIEW /////////////////////////////////
	var tinvoiceview= new DataTable("invoiceview");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("flagbuysell", typeof(string));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("flagvariation", typeof(string));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	tinvoiceview.Columns.Add( new DataColumn("registryreference", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	tinvoiceview.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tinvoiceview.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tinvoiceview.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("codecurrency", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("currency", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoiceview.Columns.Add( new DataColumn("doc", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	tinvoiceview.Columns.Add( new DataColumn("protocoldate", typeof(DateTime)));
	tinvoiceview.Columns.Add( new DataColumn("packinglistnum", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	tinvoiceview.Columns.Add( new DataColumn("flagdeferred", typeof(string)));
	C= new DataColumn("taxable", typeof(decimal));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	tinvoiceview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoiceview.Columns.Add(C);
	tinvoiceview.Columns.Add( new DataColumn("ycon", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("ncon", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("idintrastatnation_origin", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("intrastatnation_origin", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idintrastatnation_provenance", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("intrastatnation_provenance", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idintrastatnation_destination", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("intrastatnation_destination", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idcountry_origin", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("country_origin", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idcountry_destination", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("country_destination", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idintrastatkind", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("intrastatkind", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idintrastatnation_payment", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("intrastatnation_payment", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idintrastatpaymethod", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("intrastatpaymethod", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("codemotivedebit", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("codemotivedebit_crg", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tinvoiceview.Columns.Add( new DataColumn("flag_invoice", typeof(int)));
	C= new DataColumn("totransmit", typeof(string));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	tinvoiceview.Columns.Add( new DataColumn("idblacklist", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("idblnation", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("blnation", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("blcode", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idinvkind_real", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("invkind_real", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("yinv_real", typeof(short)));
	tinvoiceview.Columns.Add( new DataColumn("ninv_real", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("autoinvoice", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tinvoiceview.Columns.Add(C);
	tinvoiceview.Columns.Add( new DataColumn("nelectronicinvoice", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("yelectronicinvoice", typeof(short)));
	tinvoiceview.Columns.Add( new DataColumn("idfepaymethodcondition", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idfepaymethod", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("idsdi_vendita", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("ipa_acq", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("rifamm_acq", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("ipa_ven_emittente", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("rifamm_ven_emittente", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("ipa_ven_cliente", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("rifamm_ven_cliente", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("flagbit", typeof(int)));
	tinvoiceview.Columns.Add( new DataColumn("email_ven_cliente", typeof(string)));
	tinvoiceview.Columns.Add( new DataColumn("pec_ven_cliente", typeof(string)));
	Tables.Add(tinvoiceview);
	tinvoiceview.PrimaryKey =  new DataColumn[]{tinvoiceview.Columns["idinvkind"], tinvoiceview.Columns["yinv"], tinvoiceview.Columns["ninv"]};


	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new DataTable("sorting05");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting05.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting05.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new DataTable("sorting01");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting01.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting01.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting01);
	tsorting01.PrimaryKey =  new DataColumn[]{tsorting01.Columns["idsor"]};


	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new DataTable("sorting02");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting02.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting02.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting02);
	tsorting02.PrimaryKey =  new DataColumn[]{tsorting02.Columns["idsor"]};


	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new DataTable("sorting03");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting03.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting03.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting03);
	tsorting03.PrimaryKey =  new DataColumn[]{tsorting03.Columns["idsor"]};


	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new DataTable("sorting04");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting04.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting04.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting04);
	tsorting04.PrimaryKey =  new DataColumn[]{tsorting04.Columns["idsor"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("ccp", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idexternal", typeof(int)));
	tregistry.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tregistry.Columns.Add( new DataColumn("email_fe", typeof(string)));
	tregistry.Columns.Add( new DataColumn("pec_fe", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// SDI_VENDITA /////////////////////////////////
	var tsdi_vendita= new DataTable("sdi_vendita");
	C= new DataColumn("idsdi_vendita", typeof(int));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	C= new DataColumn("filename", typeof(string));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	tsdi_vendita.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("xml", typeof(string));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	tsdi_vendita.Columns.Add( new DataColumn("identificativo_sdi", typeof(long)));
	tsdi_vendita.Columns.Add( new DataColumn("ns", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("mc", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("rc", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("ne", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("dt", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("at", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("flag_unseen", typeof(int)));
	tsdi_vendita.Columns.Add( new DataColumn("idsdi_status", typeof(short)));
	tsdi_vendita.Columns.Add( new DataColumn("idsdi_deliverystatus", typeof(short)));
	tsdi_vendita.Columns.Add( new DataColumn("position", typeof(int)));
	C= new DataColumn("exported", typeof(string));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	tsdi_vendita.Columns.Add( new DataColumn("zipfilename", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("idsdi_rifamm", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("issigned", typeof(string)));
	Tables.Add(tsdi_vendita);
	tsdi_vendita.PrimaryKey =  new DataColumn[]{tsdi_vendita.Columns["idsdi_vendita"]};


	//////////////////// IPA /////////////////////////////////
	var tipa= new DataTable("ipa");
	C= new DataColumn("ipa_fe", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	C= new DataColumn("agencyname", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	C= new DataColumn("officename", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	tipa.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tipa.Columns.Add( new DataColumn("cu", typeof(string)));
	tipa.Columns.Add( new DataColumn("lu", typeof(string)));
	tipa.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tipa.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tipa.Columns.Add( new DataColumn("codiceufficio", typeof(string)));
	tipa.Columns.Add( new DataColumn("voceindice", typeof(string)));
	tipa.Columns.Add( new DataColumn("diritto", typeof(string)));
	tipa.Columns.Add( new DataColumn("nomeufficio", typeof(string)));
	tipa.Columns.Add( new DataColumn("nomepersona", typeof(string)));
	tipa.Columns.Add( new DataColumn("cod_amm_aoo", typeof(string)));
	Tables.Add(tipa);
	tipa.PrimaryKey =  new DataColumn[]{tipa.Columns["ipa_fe"]};


	//////////////////// SDI_RIFAMM /////////////////////////////////
	var tsdi_rifamm= new DataTable("sdi_rifamm");
	C= new DataColumn("idsdi_rifamm", typeof(string));
	C.AllowDBNull=false;
	tsdi_rifamm.Columns.Add(C);
	tsdi_rifamm.Columns.Add( new DataColumn("codiceufficio", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("voceindice", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("diritto", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("nomeufficio", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("nomepersona", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsdi_rifamm.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsdi_rifamm.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsdi_rifamm.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsdi_rifamm.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tsdi_rifamm.Columns.Add( new DataColumn("nomeufficioricevente", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("cod_amm_aoo", typeof(string)));
	Tables.Add(tsdi_rifamm);
	tsdi_rifamm.PrimaryKey =  new DataColumn[]{tsdi_rifamm.Columns["idsdi_rifamm"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sdi_vendita.Columns["idsdi_vendita"]};
	var cChild = new []{invoiceview.Columns["idsdi_vendita"]};
	Relations.Add(new DataRelation("FK_sdi_vendita_invoiceview",cPar,cChild,false));

	cPar = new []{electronicinvoice.Columns["yelectronicinvoice"], electronicinvoice.Columns["nelectronicinvoice"]};
	cChild = new []{invoiceview.Columns["yelectronicinvoice"], invoiceview.Columns["nelectronicinvoice"]};
	Relations.Add(new DataRelation("electronicinvoice_invoiceview",cPar,cChild,false));

	cPar = new []{ipa.Columns["ipa_fe"]};
	cChild = new []{electronicinvoice.Columns["ipa_ven_emittente"]};
	Relations.Add(new DataRelation("FK_ipa_electronicinvoice",cPar,cChild,false));

	cPar = new []{sdi_rifamm.Columns["idsdi_rifamm"]};
	cChild = new []{electronicinvoice.Columns["rifamm_ven_emittente"]};
	Relations.Add(new DataRelation("FK_sdi_rifamm_electronicinvoice",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{electronicinvoice.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_electronicinvoice",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{electronicinvoice.Columns["idsor05"]};
	Relations.Add(new DataRelation("FK_sorting05_electronicinvoice",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{electronicinvoice.Columns["idsor04"]};
	Relations.Add(new DataRelation("FK_sorting04_electronicinvoice",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{electronicinvoice.Columns["idsor02"]};
	Relations.Add(new DataRelation("FK_sorting02_electronicinvoice",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{electronicinvoice.Columns["idsor03"]};
	Relations.Add(new DataRelation("FK_sorting03_electronicinvoice",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{electronicinvoice.Columns["idsor01"]};
	Relations.Add(new DataRelation("FK_sorting01_electronicinvoice",cPar,cChild,false));

	cPar = new []{treasurer.Columns["idtreasurer"]};
	cChild = new []{electronicinvoice.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("FK_treasurer_electronicinvoice",cPar,cChild,false));

	#endregion

}
}
}
