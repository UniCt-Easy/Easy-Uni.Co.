
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
namespace paymenttransmission_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable treasurer 		=> Tables["treasurer"];

	///<summary>
	///Distinta di trasmissione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable paymenttransmission 		=> Tables["paymenttransmission"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable paymentview 		=> Tables["paymentview"];

	///<summary>
	///Tipo conto, determina il modo in cui Ã¨ movimentato nelle varie situazioni.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountkind 		=> Tables["accountkind"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensevarview 		=> Tables["expensevarview"];

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
	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


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
	ttreasurer.Columns.Add( new DataColumn("idaccmotive_payment", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idaccmotive_proceeds", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("agencycodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("annotations", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cabcodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagedisp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(ttreasurer);
	ttreasurer.PrimaryKey =  new DataColumn[]{ttreasurer.Columns["idtreasurer"]};


	//////////////////// PAYMENTTRANSMISSION /////////////////////////////////
	var tpaymenttransmission= new DataTable("paymenttransmission");
	C= new DataColumn("kpaymenttransmission", typeof(int));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("ypaymenttransmission", typeof(short));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("npaymenttransmission", typeof(int));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	tpaymenttransmission.Columns.Add( new DataColumn("idman", typeof(int)));
	tpaymenttransmission.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tpaymenttransmission.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	tpaymenttransmission.Columns.Add( new DataColumn("flagmailsent", typeof(string)));
	tpaymenttransmission.Columns.Add( new DataColumn("transmissionkind", typeof(string)));
	tpaymenttransmission.Columns.Add( new DataColumn("streamdate", typeof(DateTime)));
	tpaymenttransmission.Columns.Add( new DataColumn("bankdate", typeof(DateTime)));
	tpaymenttransmission.Columns.Add( new DataColumn("flagtransmissionenabled", typeof(string)));
	tpaymenttransmission.Columns.Add( new DataColumn("noep", typeof(string)));
	Tables.Add(tpaymenttransmission);
	tpaymenttransmission.PrimaryKey =  new DataColumn[]{tpaymenttransmission.Columns["kpaymenttransmission"]};


	//////////////////// PAYMENTVIEW /////////////////////////////////
	var tpaymentview= new DataTable("paymentview");
	C= new DataColumn("kpay", typeof(int));
	C.AllowDBNull=false;
	tpaymentview.Columns.Add(C);
	C= new DataColumn("ypay", typeof(short));
	C.AllowDBNull=false;
	tpaymentview.Columns.Add(C);
	C= new DataColumn("npay", typeof(int));
	C.AllowDBNull=false;
	tpaymentview.Columns.Add(C);
	tpaymentview.Columns.Add( new DataColumn("npay_treasurer", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("idstamphandling", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("stamphandling", typeof(string)));
	tpaymentview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("kind", typeof(string)));
	tpaymentview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("registry", typeof(string)));
	tpaymentview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tpaymentview.Columns.Add( new DataColumn("finance", typeof(string)));
	tpaymentview.Columns.Add( new DataColumn("idman", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("manager", typeof(string)));
	tpaymentview.Columns.Add( new DataColumn("kpaymenttransmission", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("ypaymenttransmission", typeof(short)));
	tpaymentview.Columns.Add( new DataColumn("npaymenttransmission", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	tpaymentview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tpaymentview.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tpaymentview.Columns.Add( new DataColumn("annulmentdate", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpaymentview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymentview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpaymentview.Columns.Add(C);
	tpaymentview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpaymentview.Columns.Add( new DataColumn("total", typeof(decimal)));
	tpaymentview.Columns.Add( new DataColumn("performed", typeof(decimal)));
	tpaymentview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tpaymentview.Columns.Add( new DataColumn("net", typeof(decimal)));
	Tables.Add(tpaymentview);
	tpaymentview.PrimaryKey =  new DataColumn[]{tpaymentview.Columns["kpay"]};


	//////////////////// ACCOUNTKIND /////////////////////////////////
	var taccountkind= new DataTable("accountkind");
	C= new DataColumn("idaccountkind", typeof(string));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	taccountkind.Columns.Add( new DataColumn("flagda", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	taccountkind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(taccountkind);
	taccountkind.PrimaryKey =  new DataColumn[]{taccountkind.Columns["idaccountkind"]};


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
	tconfig.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	ttax.Columns.Add( new DataColumn("active", typeof(string)));
	ttax.Columns.Add( new DataColumn("appliancebasis", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	ttax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	ttax.Columns.Add( new DataColumn("geoappliance", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_pay", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	ttax.Columns.Add( new DataColumn("taxkind", typeof(short)));
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("maintaxcode", typeof(int)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// EXPENSEVARVIEW /////////////////////////////////
	var texpensevarview= new DataTable("expensevarview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	texpensevarview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensevarview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpensevarview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpensevarview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	texpensevarview.Columns.Add( new DataColumn("transferkind", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	texpensevarview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("upb", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("codeinvkind", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("yinv", typeof(short)));
	texpensevarview.Columns.Add( new DataColumn("ninv", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("movkind", typeof(short)));
	texpensevarview.Columns.Add( new DataColumn("kpaymenttransmission", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("ypay", typeof(short)));
	texpensevarview.Columns.Add( new DataColumn("npay", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idman", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("!varkind", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("kpaymenttransmission_orig", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("underwriting", typeof(string)));
	Tables.Add(texpensevarview);
	texpensevarview.PrimaryKey =  new DataColumn[]{texpensevarview.Columns["idexp"], texpensevarview.Columns["nvar"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{paymenttransmission.Columns["kpaymenttransmission"]};
	var cChild = new []{expensevarview.Columns["kpaymenttransmission"]};
	Relations.Add(new DataRelation("paymenttransmission_expensevarview",cPar,cChild,false));

	cPar = new []{paymenttransmission.Columns["kpaymenttransmission"]};
	cChild = new []{paymentview.Columns["kpaymenttransmission"]};
	Relations.Add(new DataRelation("paymenttransmissionpaymentview",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{paymenttransmission.Columns["idman"]};
	Relations.Add(new DataRelation("managerpaymenttransmission",cPar,cChild,false));

	cPar = new []{treasurer.Columns["idtreasurer"]};
	cChild = new []{paymenttransmission.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("treasurerpaymenttransmission",cPar,cChild,false));

	#endregion

}
}
}
