
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
namespace expenselast_elenco {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense 		=> Tables["expense"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Movimento di spesa - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenselast 		=> Tables["expenselast"];

	///<summary>
	///Documento di pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payment 		=> Tables["payment"];

	///<summary>
	///Partita pendente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bill 		=> Tables["bill"];

	///<summary>
	///totalizzatore sui mov. di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensetotal 		=> Tables["expensetotal"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenselastview 		=> Tables["expenselastview"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable billview 		=> Tables["billview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payment_bankview 		=> Tables["payment_bankview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable banktransactionview 		=> Tables["banktransactionview"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

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
	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new DataTable("expense");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpense.Columns.Add( new DataColumn("idman", typeof(int)));
	texpense.Columns.Add( new DataColumn("doc", typeof(string)));
	texpense.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpense.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpense.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("txt", typeof(string)));
	texpense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	Tables.Add(texpense);
	texpense.PrimaryKey =  new DataColumn[]{texpense.Columns["idexp"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// EXPENSELAST /////////////////////////////////
	var texpenselast= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenselast.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idaccdebit", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("biccode", typeof(string)));
	C= new DataColumn("paymethod_flag", typeof(int));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	Tables.Add(texpenselast);
	texpenselast.PrimaryKey =  new DataColumn[]{texpenselast.Columns["idexp"]};


	//////////////////// PAYMENT /////////////////////////////////
	var tpayment= new DataTable("payment");
	C= new DataColumn("npay", typeof(int));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("ypay", typeof(short));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	tpayment.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tpayment.Columns.Add( new DataColumn("annulmentdate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	tpayment.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpayment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	tpayment.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tpayment.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tpayment.Columns.Add( new DataColumn("txt", typeof(string)));
	tpayment.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idman", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idstamphandling", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("kpay", typeof(int));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	tpayment.Columns.Add( new DataColumn("kpaymenttransmission", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tpayment.Columns.Add( new DataColumn("external_reference", typeof(string)));
	tpayment.Columns.Add( new DataColumn("npay_treasurer", typeof(int)));
	Tables.Add(tpayment);
	tpayment.PrimaryKey =  new DataColumn[]{tpayment.Columns["kpay"]};


	//////////////////// BILL /////////////////////////////////
	var tbill= new DataTable("bill");
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	tbill.Columns.Add( new DataColumn("registry", typeof(string)));
	tbill.Columns.Add( new DataColumn("covered", typeof(decimal)));
	tbill.Columns.Add( new DataColumn("total", typeof(decimal)));
	tbill.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbill.Columns.Add( new DataColumn("active", typeof(string)));
	tbill.Columns.Add( new DataColumn("motive", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	tbill.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbill.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbill.Columns.Add( new DataColumn("reduction", typeof(decimal)));
	tbill.Columns.Add( new DataColumn("banknum", typeof(int)));
	tbill.Columns.Add( new DataColumn("idbank", typeof(string)));
	Tables.Add(tbill);
	tbill.PrimaryKey =  new DataColumn[]{tbill.Columns["ybill"], tbill.Columns["nbill"], tbill.Columns["billkind"]};


	//////////////////// EXPENSETOTAL /////////////////////////////////
	var texpensetotal= new DataTable("expensetotal");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpensetotal.Columns.Add(C);
	texpensetotal.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpensetotal.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensetotal.Columns.Add(C);
	texpensetotal.Columns.Add( new DataColumn("flag", typeof(byte)));
	Tables.Add(texpensetotal);
	texpensetotal.PrimaryKey =  new DataColumn[]{texpensetotal.Columns["ayear"], texpensetotal.Columns["idexp"]};


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
	texpenselastview.Columns.Add( new DataColumn("ypay", typeof(short)));
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
	C= new DataColumn("linkedincome", typeof(decimal));
	C.ReadOnly=true;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("net", typeof(decimal));
	C.ReadOnly=true;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("performed", typeof(decimal));
	C.ReadOnly=true;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("notperformed", typeof(decimal));
	C.ReadOnly=true;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("service", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("codeser", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenselastview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenselastview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
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
	texpenselastview.Columns.Add( new DataColumn("clawbackref", typeof(string)));
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
	texpenselastview.Columns.Add( new DataColumn("pagopanoticenum", typeof(string)));
	Tables.Add(texpenselastview);
	texpenselastview.PrimaryKey =  new DataColumn[]{texpenselastview.Columns["idexp"]};


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
	tmanager.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanager.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanager.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// BILLVIEW /////////////////////////////////
	var tbillview= new DataTable("billview");
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	tbillview.Columns.Add( new DataColumn("active", typeof(string)));
	tbillview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbillview.Columns.Add( new DataColumn("registry", typeof(string)));
	tbillview.Columns.Add( new DataColumn("motive", typeof(string)));
	tbillview.Columns.Add( new DataColumn("total", typeof(decimal)));
	tbillview.Columns.Add( new DataColumn("covered", typeof(decimal)));
	tbillview.Columns.Add( new DataColumn("toregularize", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	tbillview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbillview.Columns.Add( new DataColumn("treasurer", typeof(string)));
	tbillview.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbillview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tbillview);
	tbillview.PrimaryKey =  new DataColumn[]{tbillview.Columns["ybill"], tbillview.Columns["nbill"], tbillview.Columns["billkind"]};


	//////////////////// PAYMENT_BANKVIEW /////////////////////////////////
	var tpayment_bankview= new DataTable("payment_bankview");
	C= new DataColumn("ypay", typeof(short));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("npay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("idpay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("kpay", typeof(int));
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
	C= new DataColumn("performed", typeof(decimal));
	C.ReadOnly=true;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("notperformed", typeof(decimal));
	C.ReadOnly=true;
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
	tpayment_bankview.PrimaryKey =  new DataColumn[]{tpayment_bankview.Columns["idpay"], tpayment_bankview.Columns["kpay"]};


	//////////////////// BANKTRANSACTIONVIEW /////////////////////////////////
	var tbanktransactionview= new DataTable("banktransactionview");
	C= new DataColumn("yban", typeof(short));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("nban", typeof(int));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("kind", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	tbanktransactionview.Columns.Add( new DataColumn("bankreference", typeof(string)));
	tbanktransactionview.Columns.Add( new DataColumn("transactiondate", typeof(DateTime)));
	tbanktransactionview.Columns.Add( new DataColumn("valuedate", typeof(DateTime)));
	tbanktransactionview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tbanktransactionview.Columns.Add( new DataColumn("kpay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("ypay", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("npay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("kpro", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("npro", typeof(int)));
	C= new DataColumn("income", typeof(decimal));
	C.ReadOnly=true;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("expense", typeof(decimal));
	C.ReadOnly=true;
	tbanktransactionview.Columns.Add(C);
	tbanktransactionview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("yexp", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("nexp", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("idinc", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("yinc", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("ninc", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("idpay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("idpro", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("idbankimport", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("motive", typeof(string)));
	tbanktransactionview.Columns.Add( new DataColumn("nbill", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	tbanktransactionview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("registry", typeof(string)));
	tbanktransactionview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tbanktransactionview.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("idtreasurer", typeof(int));
	C.ReadOnly=true;
	tbanktransactionview.Columns.Add(C);
	Tables.Add(tbanktransactionview);
	tbanktransactionview.PrimaryKey =  new DataColumn[]{tbanktransactionview.Columns["yban"], tbanktransactionview.Columns["nban"]};


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
	tupb.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	tupb.Columns.Add( new DataColumn("flag", typeof(int)));
	tupb.Columns.Add( new DataColumn("uesiopecode", typeof(string)));
	tupb.Columns.Add( new DataColumn("cofogmpcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("ri_ra_quota", typeof(string)));
	tupb.Columns.Add( new DataColumn("ri_rb_quota", typeof(string)));
	tupb.Columns.Add( new DataColumn("ri_sa_quota", typeof(decimal)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{expense.Columns["idexp"]};
	var cChild = new []{expenselast.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenselast",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{expense.Columns["idreg"]};
	Relations.Add(new DataRelation("registryexpense",cPar,cChild,false));

	cPar = new []{expensetotal.Columns["idexp"]};
	cChild = new []{expenselast.Columns["idexp"]};
	Relations.Add(new DataRelation("expensetotal_expenselast",cPar,cChild,false));

	cPar = new []{bill.Columns["nbill"]};
	cChild = new []{expenselast.Columns["nbill"]};
	Relations.Add(new DataRelation("bill_expenselast",cPar,cChild,false));

	cPar = new []{payment.Columns["kpay"]};
	cChild = new []{expenselast.Columns["kpay"]};
	Relations.Add(new DataRelation("payment_expenselast",cPar,cChild,false));

	cPar = new []{expensephase.Columns["nphase"]};
	cChild = new []{expense.Columns["nphase"]};
	Relations.Add(new DataRelation("expensephase_expense",cPar,cChild,false));

	cPar = new []{expenselastview.Columns["idexp"]};
	cChild = new []{expense.Columns["idexp"]};
	Relations.Add(new DataRelation("expenselastview_expense",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{expense.Columns["idman"]};
	Relations.Add(new DataRelation("manager_expense",cPar,cChild,false));

	cPar = new []{expenselast.Columns["idpay"], expenselast.Columns["kpay"]};
	cChild = new []{payment_bankview.Columns["idpay"], payment_bankview.Columns["kpay"]};
	Relations.Add(new DataRelation("expenselast_payment_bankview",cPar,cChild,false));

	cPar = new []{banktransactionview.Columns["idexp"]};
	cChild = new []{expenselast.Columns["idexp"]};
	Relations.Add(new DataRelation("banktransactionview_expenselast",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{expenselastview.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_expenselastview",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{expenselastview.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_expenselastview",cPar,cChild,false));

	#endregion

}
}
}
