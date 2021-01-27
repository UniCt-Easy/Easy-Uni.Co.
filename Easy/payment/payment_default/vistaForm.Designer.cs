
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace payment_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Documento di pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payment 		=> Tables["payment"];

	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable treasurer 		=> Tables["treasurer"];

	///<summary>
	///Trattamento del bollo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stamphandling 		=> Tables["stamphandling"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payment_bankview 		=> Tables["payment_bankview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenselastview 		=> Tables["expenselastview"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

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
	//////////////////// PAYMENT /////////////////////////////////
	var tpayment= new DataTable("payment");
	C= new DataColumn("kpay", typeof(int));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("ypay", typeof(short));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("npay", typeof(int));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	tpayment.Columns.Add( new DataColumn("kpaymenttransmission", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idstamphandling", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	tpayment.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idman", typeof(int)));
	tpayment.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tpayment.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tpayment.Columns.Add( new DataColumn("txt", typeof(string)));
	tpayment.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	tpayment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayment.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tpayment.Columns.Add( new DataColumn("npay_treasurer", typeof(int)));
	Tables.Add(tpayment);
	tpayment.PrimaryKey =  new DataColumn[]{tpayment.Columns["kpay"]};


	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new DataTable("treasurer");
	C= new DataColumn("idtreasurer", typeof(int));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("flagdefault", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("cin", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idbank", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idcab", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cc", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("address", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cap", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("city", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("country", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idsor01", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor02", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor03", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor04", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(ttreasurer);
	ttreasurer.PrimaryKey =  new DataColumn[]{ttreasurer.Columns["idtreasurer"]};


	//////////////////// STAMPHANDLING /////////////////////////////////
	var tstamphandling= new DataTable("stamphandling");
	C= new DataColumn("idstamphandling", typeof(int));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("flagdefault", typeof(string));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	tstamphandling.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tstamphandling);
	tstamphandling.PrimaryKey =  new DataColumn[]{tstamphandling.Columns["idstamphandling"]};


	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new DataTable("expensephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	Tables.Add(texpensephase);
	texpensephase.PrimaryKey =  new DataColumn[]{texpensephase.Columns["nphase"]};


	//////////////////// PAYMENT_BANKVIEW /////////////////////////////////
	var tpayment_bankview= new DataTable("payment_bankview");
	C= new DataColumn("kpay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("ypay", typeof(short));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("npay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("idpay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	tpayment_bankview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	Tables.Add(tpayment_bankview);
	tpayment_bankview.PrimaryKey =  new DataColumn[]{tpayment_bankview.Columns["kpay"], tpayment_bankview.Columns["idpay"]};


	//////////////////// EXPENSELASTVIEW /////////////////////////////////
	var texpenselastview= new DataTable("expenselastview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenselastview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("kpay", typeof(int)));
	C= new DataColumn("ypay", typeof(short));
	C.ReadOnly=true;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenselastview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenselastview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenselastview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenselastview.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenselastview.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("service", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenselastview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenselastview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenselastview.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenselastview.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenselastview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("pagopanoticenum", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("net", typeof(decimal)));
	Tables.Add(texpenselastview);
	texpenselastview.PrimaryKey =  new DataColumn[]{texpenselastview.Columns["idexp"]};


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("automanagekind", typeof(int)));
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appropriationphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("assessmentphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("asset_flagnumbering", typeof(string)));
	tconfig.Columns.Add( new DataColumn("asset_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
	tconfig.Columns.Add( new DataColumn("assetload_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("boxpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
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
	tconfig.Columns.Add( new DataColumn("flag_paymentamount", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flagautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagepexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("taxvaliditykind", typeof(byte)));
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
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
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
	tconfig.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{payment_bankview.Columns["kpay"], payment_bankview.Columns["idpay"]};
	var cChild = new []{expenselastview.Columns["kpay"], expenselastview.Columns["idpay"]};
	Relations.Add(new DataRelation("payment_bankviewexpenselastview",cPar,cChild,false));

	cPar = new []{payment.Columns["kpay"]};
	cChild = new []{expenselastview.Columns["kpay"]};
	Relations.Add(new DataRelation("payment_expenselastview",cPar,cChild,false));

	cPar = new []{payment.Columns["kpay"]};
	cChild = new []{payment_bankview.Columns["kpay"]};
	Relations.Add(new DataRelation("paymentpayment_bankview",cPar,cChild,false));

	cPar = new []{treasurer.Columns["idtreasurer"]};
	cChild = new []{payment.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("treasurerpayment",cPar,cChild,false));

	cPar = new []{stamphandling.Columns["idstamphandling"]};
	cChild = new []{payment.Columns["idstamphandling"]};
	Relations.Add(new DataRelation("stamphandlingpayment",cPar,cChild,false));

	#endregion

}
}
}
