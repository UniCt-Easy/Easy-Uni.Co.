
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
namespace f24ep_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Modello F24 EP per singolo dipartimento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24ep 		=> Tables["f24ep"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxpayview 		=> Tables["taxpayview"];

	///<summary>
	///Sanzione F24 EP
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24epsanction 		=> Tables["f24epsanction"];

	///<summary>
	///Tipi Sanzioni F24 EP
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24epsanctionkind 		=> Tables["f24epsanctionkind"];

	///<summary>
	///Informazioni ente contabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable license 		=> Tables["license"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Nomi e codici dei mesi nel codice fiscale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable monthname 		=> Tables["monthname"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseclawbackview 		=> Tables["expenseclawbackview"];

	///<summary>
	///Liquidazione IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapay 		=> Tables["ivapay"];

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
	//////////////////// F24EP /////////////////////////////////
	var tf24ep= new DataTable("f24ep");
	C= new DataColumn("idf24ep", typeof(int));
	C.AllowDBNull=false;
	tf24ep.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tf24ep.Columns.Add(C);
	tf24ep.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("paymentdate", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ep.Columns.Add(C);
	C= new DataColumn("taxpay_start", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ep.Columns.Add(C);
	C= new DataColumn("taxpay_stop", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ep.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ep.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24ep.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ep.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24ep.Columns.Add(C);
	C= new DataColumn("nmonth", typeof(int));
	C.AllowDBNull=false;
	tf24ep.Columns.Add(C);
	Tables.Add(tf24ep);
	tf24ep.PrimaryKey =  new DataColumn[]{tf24ep.Columns["idf24ep"]};


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
	Tables.Add(ttaxpayview);
	ttaxpayview.PrimaryKey =  new DataColumn[]{ttaxpayview.Columns["taxcode"], ttaxpayview.Columns["ytaxpay"], ttaxpayview.Columns["ntaxpay"]};


	//////////////////// F24EPSANCTION /////////////////////////////////
	var tf24epsanction= new DataTable("f24epsanction");
	C= new DataColumn("idf24ep", typeof(int));
	C.AllowDBNull=false;
	tf24epsanction.Columns.Add(C);
	C= new DataColumn("idsanction", typeof(int));
	C.AllowDBNull=false;
	tf24epsanction.Columns.Add(C);
	tf24epsanction.Columns.Add( new DataColumn("idcity", typeof(int)));
	tf24epsanction.Columns.Add( new DataColumn("!fiscaltaxcode", typeof(string)));
	tf24epsanction.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tf24epsanction.Columns.Add( new DataColumn("ayear", typeof(short)));
	tf24epsanction.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	C= new DataColumn("idsanctionf24", typeof(int));
	C.AllowDBNull=false;
	tf24epsanction.Columns.Add(C);
	Tables.Add(tf24epsanction);
	tf24epsanction.PrimaryKey =  new DataColumn[]{tf24epsanction.Columns["idf24ep"], tf24epsanction.Columns["idsanctionf24"]};


	//////////////////// F24EPSANCTIONKIND /////////////////////////////////
	var tf24epsanctionkind= new DataTable("f24epsanctionkind");
	C= new DataColumn("idsanction", typeof(int));
	C.AllowDBNull=false;
	tf24epsanctionkind.Columns.Add(C);
	C= new DataColumn("fiscaltaxcode", typeof(string));
	C.AllowDBNull=false;
	tf24epsanctionkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tf24epsanctionkind.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tf24epsanctionkind.Columns.Add(C);
	C= new DataColumn("flagagency", typeof(string));
	C.AllowDBNull=false;
	tf24epsanctionkind.Columns.Add(C);
	Tables.Add(tf24epsanctionkind);
	tf24epsanctionkind.PrimaryKey =  new DataColumn[]{tf24epsanctionkind.Columns["idsanction"]};


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
	tlicense.Columns.Add( new DataColumn("idcity", typeof(int)));
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
	tconfig.Columns.Add( new DataColumn("email_f24", typeof(string)));
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


	//////////////////// EXPENSECLAWBACKVIEW /////////////////////////////////
	var texpenseclawbackview= new DataTable("expenseclawbackview");
	texpenseclawbackview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseclawbackview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseclawbackview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseclawbackview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseclawbackview.Columns.Add(C);
	C= new DataColumn("idclawback", typeof(int));
	C.AllowDBNull=false;
	texpenseclawbackview.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseclawbackview.Columns.Add(C);
	texpenseclawbackview.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	texpenseclawbackview.Columns.Add( new DataColumn("identifying_marks", typeof(string)));
	texpenseclawbackview.Columns.Add( new DataColumn("code", typeof(string)));
	texpenseclawbackview.Columns.Add( new DataColumn("tiporiga", typeof(string)));
	texpenseclawbackview.Columns.Add( new DataColumn("rifb_month", typeof(int)));
	texpenseclawbackview.Columns.Add( new DataColumn("rifb_year", typeof(int)));
	texpenseclawbackview.Columns.Add( new DataColumn("rifa_month", typeof(int)));
	texpenseclawbackview.Columns.Add( new DataColumn("rifa_year", typeof(int)));
	texpenseclawbackview.Columns.Add( new DataColumn("rifa", typeof(string)));
	texpenseclawbackview.Columns.Add( new DataColumn("idunifiedclawback", typeof(int)));
	texpenseclawbackview.Columns.Add( new DataColumn("desctiporiga", typeof(string)));
	texpenseclawbackview.Columns.Add( new DataColumn("rifa_monthname", typeof(string)));
	texpenseclawbackview.Columns.Add( new DataColumn("rifb_monthname", typeof(string)));
	texpenseclawbackview.Columns.Add( new DataColumn("idf24ep", typeof(int)));
	texpenseclawbackview.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	texpenseclawbackview.Columns.Add( new DataColumn("flagf24ep", typeof(string)));
	Tables.Add(texpenseclawbackview);
	texpenseclawbackview.PrimaryKey =  new DataColumn[]{texpenseclawbackview.Columns["idclawback"], texpenseclawbackview.Columns["idexp"]};


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
	Tables.Add(tivapay);
	tivapay.PrimaryKey =  new DataColumn[]{tivapay.Columns["nivapay"], tivapay.Columns["yivapay"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{f24ep.Columns["idf24ep"]};
	var cChild = new []{expenseclawbackview.Columns["idf24ep"]};
	Relations.Add(new DataRelation("f24ep_f24epdetail",cPar,cChild,false));

	cPar = new []{f24ep.Columns["idf24ep"]};
	cChild = new []{f24epsanction.Columns["idf24ep"]};
	Relations.Add(new DataRelation("FK_f24ep_f24epsanction",cPar,cChild,false));

	cPar = new []{f24epsanctionkind.Columns["idsanction"]};
	cChild = new []{f24epsanction.Columns["idsanction"]};
	Relations.Add(new DataRelation("f24epsanctionkind_f24epsanction",cPar,cChild,false));

	cPar = new []{f24ep.Columns["idf24ep"]};
	cChild = new []{taxpayview.Columns["idf24ep"]};
	Relations.Add(new DataRelation("f24ep_taxpayview",cPar,cChild,false));

	cPar = new []{monthname.Columns["code"]};
	cChild = new []{f24ep.Columns["nmonth"]};
	Relations.Add(new DataRelation("monthname_f24ep",cPar,cChild,false));

	cPar = new []{f24ep.Columns["idf24ep"]};
	cChild = new []{ivapay.Columns["idf24ep"]};
	Relations.Add(new DataRelation("f24ep_ivapay",cPar,cChild,false));

	#endregion

}
}
}
