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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace ivapay_wizard_calcolo {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Liquidazione IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapay 		=> Tables["ivapay"];

	///<summary>
	///Dettaglio liquidazione iva
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapaydetail 		=> Tables["ivapaydetail"];

	///<summary>
	///Peridiocità della liquidazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapayperiodicity 		=> Tables["ivapayperiodicity"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	///<summary>
	///Movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable income 		=> Tables["income"];

	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense 		=> Tables["expense"];

	///<summary>
	///Contabilizzazione liq. iva a credito
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapayincome 		=> Tables["ivapayincome"];

	///<summary>
	///Contabilizzazione liq. iva a debito
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapayexpense 		=> Tables["ivapayexpense"];

	///<summary>
	///Informazioni annuali su mov. di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeyear 		=> Tables["incomeyear"];

	///<summary>
	///Informazioni annuali su movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseyear 		=> Tables["expenseyear"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///Prorata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable iva_prorata 		=> Tables["iva_prorata"];

	///<summary>
	///Promiscuo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable iva_mixed 		=> Tables["iva_mixed"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Documento di pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payment 		=> Tables["payment"];

	///<summary>
	///Documento di incasso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceeds 		=> Tables["proceeds"];

	///<summary>
	///iva di una fattura inserita in liquidazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedeferred 		=> Tables["invoicedeferred"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	///<summary>
	///informazioni annuali su un tipo documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekindyear 		=> Tables["invoicekindyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Movimento di entrata - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomelast 		=> Tables["incomelast"];

	///<summary>
	///Movimento di spesa - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenselast 		=> Tables["expenselast"];

	///<summary>
	///Girofondo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable moneytransfer 		=> Tables["moneytransfer"];

	///<summary>
	///Registro IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivaregisterkind 		=> Tables["ivaregisterkind"];

	///<summary>
	///dettagli di una fattura inseriti in liquidazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetaildeferred 		=> Tables["invoicedetaildeferred"];

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
	//////////////////// IVAPAY /////////////////////////////////
	var tivapay= new DataTable("ivapay");
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("paymentkind", typeof(string));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	tivapay.Columns.Add( new DataColumn("creditamount", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("creditamountdeferred", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("debitamount", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("debitamountdeferred", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("refundamount", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("paymentamount", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("prorata", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("mixed", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("paymentdetails", typeof(string)));
	C= new DataColumn("dateivapay", typeof(DateTime));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	tivapay.Columns.Add( new DataColumn("assesmentdate", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivapay.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
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
	Tables.Add(tivapay);
	tivapay.PrimaryKey =  new DataColumn[]{tivapay.Columns["yivapay"], tivapay.Columns["nivapay"]};


	//////////////////// IVAPAYDETAIL /////////////////////////////////
	var tivapaydetail= new DataTable("ivapaydetail");
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tivapaydetail.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tivapaydetail.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tivapaydetail.Columns.Add(C);
	tivapaydetail.Columns.Add( new DataColumn("iva", typeof(decimal)));
	tivapaydetail.Columns.Add( new DataColumn("ivadeferred", typeof(decimal)));
	tivapaydetail.Columns.Add( new DataColumn("ivanet", typeof(decimal)));
	tivapaydetail.Columns.Add( new DataColumn("ivanetdeferred", typeof(decimal)));
	tivapaydetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tivapaydetail.Columns.Add( new DataColumn("unabatabledeferred", typeof(decimal)));
	tivapaydetail.Columns.Add( new DataColumn("prorata", typeof(decimal)));
	tivapaydetail.Columns.Add( new DataColumn("mixed", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivapaydetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivapaydetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivapaydetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivapaydetail.Columns.Add(C);
	tivapaydetail.Columns.Add( new DataColumn("taxable12", typeof(decimal)));
	tivapaydetail.Columns.Add( new DataColumn("taxabledeferred12", typeof(decimal)));
	tivapaydetail.Columns.Add( new DataColumn("taxabledeferredsplit", typeof(decimal)));
	tivapaydetail.Columns.Add( new DataColumn("taxablesplit", typeof(decimal)));
	Tables.Add(tivapaydetail);
	tivapaydetail.PrimaryKey =  new DataColumn[]{tivapaydetail.Columns["yivapay"], tivapaydetail.Columns["nivapay"], tivapaydetail.Columns["idivaregisterkind"]};


	//////////////////// IVAPAYPERIODICITY /////////////////////////////////
	var tivapayperiodicity= new DataTable("ivapayperiodicity");
	C= new DataColumn("idivapayperiodicity", typeof(int));
	C.AllowDBNull=false;
	tivapayperiodicity.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivapayperiodicity.Columns.Add(C);
	C= new DataColumn("periodicity", typeof(int));
	C.AllowDBNull=false;
	tivapayperiodicity.Columns.Add(C);
	C= new DataColumn("periodicmonth", typeof(int));
	C.AllowDBNull=false;
	tivapayperiodicity.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivapayperiodicity.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayperiodicity.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivapayperiodicity.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayperiodicity.Columns.Add(C);
	tivapayperiodicity.Columns.Add( new DataColumn("periodicday", typeof(int)));
	Tables.Add(tivapayperiodicity);
	tivapayperiodicity.PrimaryKey =  new DataColumn[]{tivapayperiodicity.Columns["idivapayperiodicity"]};


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


	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	Tables.Add(tincomephase);
	tincomephase.PrimaryKey =  new DataColumn[]{tincomephase.Columns["nphase"]};


	//////////////////// INCOME /////////////////////////////////
	var tincome= new DataTable("income");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	tincome.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincome.Columns.Add( new DataColumn("idman", typeof(int)));
	tincome.Columns.Add( new DataColumn("doc", typeof(string)));
	tincome.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincome.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincome.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("txt", typeof(string)));
	tincome.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	Tables.Add(tincome);
	tincome.PrimaryKey =  new DataColumn[]{tincome.Columns["idinc"]};


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
	texpense.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpense.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpense.Columns.Add( new DataColumn("autocode", typeof(int)));
	Tables.Add(texpense);
	texpense.PrimaryKey =  new DataColumn[]{texpense.Columns["idexp"]};


	//////////////////// IVAPAYINCOME /////////////////////////////////
	var tivapayincome= new DataTable("ivapayincome");
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tivapayincome.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tivapayincome.Columns.Add(C);
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tivapayincome.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivapayincome.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayincome.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivapayincome.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayincome.Columns.Add(C);
	Tables.Add(tivapayincome);
	tivapayincome.PrimaryKey =  new DataColumn[]{tivapayincome.Columns["yivapay"], tivapayincome.Columns["nivapay"], tivapayincome.Columns["idinc"]};


	//////////////////// IVAPAYEXPENSE /////////////////////////////////
	var tivapayexpense= new DataTable("ivapayexpense");
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tivapayexpense.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tivapayexpense.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tivapayexpense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivapayexpense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayexpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivapayexpense.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayexpense.Columns.Add(C);
	Tables.Add(tivapayexpense);
	tivapayexpense.PrimaryKey =  new DataColumn[]{tivapayexpense.Columns["yivapay"], tivapayexpense.Columns["nivapay"], tivapayexpense.Columns["idexp"]};


	//////////////////// INCOMEYEAR /////////////////////////////////
	var tincomeyear= new DataTable("incomeyear");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	tincomeyear.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomeyear.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomeyear.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	Tables.Add(tincomeyear);
	tincomeyear.PrimaryKey =  new DataColumn[]{tincomeyear.Columns["idinc"], tincomeyear.Columns["ayear"]};


	//////////////////// EXPENSEYEAR /////////////////////////////////
	var texpenseyear= new DataTable("expenseyear");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	texpenseyear.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseyear.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseyear.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	Tables.Add(texpenseyear);
	texpenseyear.PrimaryKey =  new DataColumn[]{texpenseyear.Columns["ayear"], texpenseyear.Columns["idexp"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// IVA_PRORATA /////////////////////////////////
	var tiva_prorata= new DataTable("iva_prorata");
	C= new DataColumn("nprorata", typeof(int));
	C.AllowDBNull=false;
	tiva_prorata.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tiva_prorata.Columns.Add(C);
	tiva_prorata.Columns.Add( new DataColumn("prorata", typeof(decimal)));
	tiva_prorata.Columns.Add( new DataColumn("lu", typeof(string)));
	tiva_prorata.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tiva_prorata);
	tiva_prorata.PrimaryKey =  new DataColumn[]{tiva_prorata.Columns["nprorata"]};


	//////////////////// IVA_MIXED /////////////////////////////////
	var tiva_mixed= new DataTable("iva_mixed");
	C= new DataColumn("nmixed", typeof(int));
	C.AllowDBNull=false;
	tiva_mixed.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tiva_mixed.Columns.Add(C);
	tiva_mixed.Columns.Add( new DataColumn("mixed", typeof(decimal)));
	tiva_mixed.Columns.Add( new DataColumn("lu", typeof(string)));
	tiva_mixed.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tiva_mixed);
	tiva_mixed.PrimaryKey =  new DataColumn[]{tiva_mixed.Columns["nmixed"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// PAYMENT /////////////////////////////////
	var tpayment= new DataTable("payment");
	C= new DataColumn("ypay", typeof(short));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("npay", typeof(int));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
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
	tpayment.Columns.Add( new DataColumn("annulmentdate", typeof(DateTime)));
	C= new DataColumn("kpay", typeof(int));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	Tables.Add(tpayment);
	tpayment.PrimaryKey =  new DataColumn[]{tpayment.Columns["kpay"]};


	//////////////////// PROCEEDS /////////////////////////////////
	var tproceeds= new DataTable("proceeds");
	C= new DataColumn("ypro", typeof(short));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("npro", typeof(int));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("idreg", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idfin", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tproceeds.Columns.Add( new DataColumn("txt", typeof(string)));
	tproceeds.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("annulmentdate", typeof(DateTime)));
	C= new DataColumn("kpro", typeof(int));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("idstamphandling", typeof(int)));
	Tables.Add(tproceeds);
	tproceeds.PrimaryKey =  new DataColumn[]{tproceeds.Columns["kpro"]};


	//////////////////// INVOICEDEFERRED /////////////////////////////////
	var tinvoicedeferred= new DataTable("invoicedeferred");
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tinvoicedeferred.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tinvoicedeferred.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedeferred.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedeferred.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedeferred.Columns.Add(C);
	tinvoicedeferred.Columns.Add( new DataColumn("totalpayed", typeof(decimal)));
	tinvoicedeferred.Columns.Add( new DataColumn("ivatotalpayed", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedeferred.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedeferred.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedeferred.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedeferred.Columns.Add(C);
	Tables.Add(tinvoicedeferred);
	tinvoicedeferred.PrimaryKey =  new DataColumn[]{tinvoicedeferred.Columns["idinvkind"], tinvoicedeferred.Columns["yinv"], tinvoicedeferred.Columns["ninv"], tinvoicedeferred.Columns["yivapay"], tinvoicedeferred.Columns["nivapay"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
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
	tinvoicekind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// INVOICEKINDYEAR /////////////////////////////////
	var tinvoicekindyear= new DataTable("invoicekindyear");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	tinvoicekindyear.Columns.Add( new DataColumn("idacc", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_deferred", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_discount", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_unabatable", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_intra", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_deferred_intra", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_unabatable_intra", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_split", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_unabatable_split", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_deferred_split", typeof(string)));
	Tables.Add(tinvoicekindyear);
	tinvoicekindyear.PrimaryKey =  new DataColumn[]{tinvoicekindyear.Columns["ayear"], tinvoicekindyear.Columns["idinvkind"]};


	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("!livprecedente", typeof(string)));
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
	C= new DataColumn("ypay", typeof(short));
	C.ReadOnly=true;
	texpenseview.Columns.Add(C);
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
	texpenseview.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpay", typeof(int)));
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
	Tables.Add(texpenseview);

	//////////////////// INCOMEVIEW /////////////////////////////////
	var tincomeview= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("!livprecedente", typeof(string)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("upb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("registry", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idman", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("manager", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("npro", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("unpartitioned", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("totflag", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomeview.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	Tables.Add(tincomeview);

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
	tconfig.Columns.Add( new DataColumn("idacc_unabatable", typeof(string)));
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
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("startivabalance", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("flagivapaybyrow", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_refund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagivaregphase", typeof(string)));
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
	tconfig.Columns.Add( new DataColumn("flagpaymentsplit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("paymentagencysplit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapaymentsplit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("startivabalancesplit", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_split", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapaymentsplit", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// INCOMELAST /////////////////////////////////
	var tincomelast= new DataTable("incomelast");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	tincomelast.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	tincomelast.Columns.Add( new DataColumn("nbill", typeof(int)));
	Tables.Add(tincomelast);
	tincomelast.PrimaryKey =  new DataColumn[]{tincomelast.Columns["idinc"]};


	//////////////////// EXPENSELAST /////////////////////////////////
	var texpenselast= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("cin", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	Tables.Add(texpenselast);
	texpenselast.PrimaryKey =  new DataColumn[]{texpenselast.Columns["idexp"]};


	//////////////////// MONEYTRANSFER /////////////////////////////////
	var tmoneytransfer= new DataTable("moneytransfer");
	C= new DataColumn("ytransfer", typeof(short));
	C.AllowDBNull=false;
	tmoneytransfer.Columns.Add(C);
	C= new DataColumn("ntransfer", typeof(int));
	C.AllowDBNull=false;
	tmoneytransfer.Columns.Add(C);
	C= new DataColumn("idtreasurersource", typeof(int));
	C.AllowDBNull=false;
	tmoneytransfer.Columns.Add(C);
	C= new DataColumn("idtreasurerdest", typeof(int));
	C.AllowDBNull=false;
	tmoneytransfer.Columns.Add(C);
	tmoneytransfer.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tmoneytransfer.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tmoneytransfer.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmoneytransfer.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmoneytransfer.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmoneytransfer.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmoneytransfer.Columns.Add(C);
	tmoneytransfer.Columns.Add( new DataColumn("nproceedspart", typeof(int)));
	tmoneytransfer.Columns.Add( new DataColumn("yproceedspart", typeof(short)));
	tmoneytransfer.Columns.Add( new DataColumn("yvar", typeof(short)));
	tmoneytransfer.Columns.Add( new DataColumn("nvar", typeof(int)));
	tmoneytransfer.Columns.Add( new DataColumn("rownum", typeof(int)));
	tmoneytransfer.Columns.Add( new DataColumn("transferkind", typeof(string)));
	Tables.Add(tmoneytransfer);
	tmoneytransfer.PrimaryKey =  new DataColumn[]{tmoneytransfer.Columns["ytransfer"], tmoneytransfer.Columns["ntransfer"]};


	//////////////////// IVAREGISTERKIND /////////////////////////////////
	var tivaregisterkind= new DataTable("ivaregisterkind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("registerclass", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	tivaregisterkind.Columns.Add( new DataColumn("idivaregisterkindunified", typeof(string)));
	tivaregisterkind.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	C= new DataColumn("codeivaregisterkind", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	tivaregisterkind.Columns.Add( new DataColumn("compensation", typeof(string)));
	tivaregisterkind.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	Tables.Add(tivaregisterkind);
	tivaregisterkind.PrimaryKey =  new DataColumn[]{tivaregisterkind.Columns["idivaregisterkind"]};


	//////////////////// INVOICEDETAILDEFERRED /////////////////////////////////
	var tinvoicedetaildeferred= new DataTable("invoicedetaildeferred");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	C= new DataColumn("yinv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	tinvoicedetaildeferred.Columns.Add( new DataColumn("ivatotalpayed", typeof(decimal)));
	tinvoicedetaildeferred.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetaildeferred.Columns.Add( new DataColumn("cu", typeof(string)));
	tinvoicedetaildeferred.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tinvoicedetaildeferred.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	tinvoicedetaildeferred.Columns.Add( new DataColumn("lt", typeof(string)));
	Tables.Add(tinvoicedetaildeferred);
	tinvoicedetaildeferred.PrimaryKey =  new DataColumn[]{tinvoicedetaildeferred.Columns["idinvkind"], tinvoicedetaildeferred.Columns["yinv"], tinvoicedetaildeferred.Columns["ninv"], tinvoicedetaildeferred.Columns["rownum"], tinvoicedetaildeferred.Columns["yivapay"], tinvoicedetaildeferred.Columns["nivapay"], tinvoicedetaildeferred.Columns["idivaregisterkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	var cChild = new []{invoicedetaildeferred.Columns["yivapay"], invoicedetaildeferred.Columns["nivapay"]};
	Relations.Add(new DataRelation("FK_ivapay_invoicedetaildeferred",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenselast.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenselast",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomelast.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomelast",cPar,cChild,false));

	cPar = new []{ivapayperiodicity.Columns["idivapayperiodicity"]};
	cChild = new []{config.Columns["idivapayperiodicity"]};
	Relations.Add(new DataRelation("ivapayperiodicity_config",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoicekindyear.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekindinvoicekindyear",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{invoicedeferred.Columns["yivapay"], invoicedeferred.Columns["nivapay"]};
	Relations.Add(new DataRelation("ivapayinvoicedeferred",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{expenseyear.Columns["idfin"]};
	Relations.Add(new DataRelation("finexpenseyear",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseyear.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpenseyear",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{expenseyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upbexpenseyear",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{incomeyear.Columns["idfin"]};
	Relations.Add(new DataRelation("finincomeyear",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomeyear.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeincomeyear",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{incomeyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upbincomeyear",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{ivapayexpense.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseivapayexpense",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{ivapayexpense.Columns["yivapay"], ivapayexpense.Columns["nivapay"]};
	Relations.Add(new DataRelation("ivapayivapayexpense",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{ivapayincome.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeivapayincome",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{ivapayincome.Columns["yivapay"], ivapayincome.Columns["nivapay"]};
	Relations.Add(new DataRelation("ivapayivapayincome",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expense.Columns["parentidexp"]};
	Relations.Add(new DataRelation("expenseexpense",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{expense.Columns["idreg"]};
	Relations.Add(new DataRelation("registryexpense",cPar,cChild,false));

	cPar = new []{expensephase.Columns["nphase"]};
	cChild = new []{expense.Columns["nphase"]};
	Relations.Add(new DataRelation("expensephaseexpense",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{income.Columns["parentidinc"]};
	Relations.Add(new DataRelation("incomeincome",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{income.Columns["idreg"]};
	Relations.Add(new DataRelation("registryincome",cPar,cChild,false));

	cPar = new []{incomephase.Columns["nphase"]};
	cChild = new []{income.Columns["nphase"]};
	Relations.Add(new DataRelation("incomephaseincome",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{ivapaydetail.Columns["yivapay"], ivapaydetail.Columns["nivapay"]};
	Relations.Add(new DataRelation("ivapayivapaydetail",cPar,cChild,false));

	#endregion

}
}
}
