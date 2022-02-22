
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
namespace ivapay_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Liquidazione IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapay 		=> Tables["ivapay"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapaydetailview 		=> Tables["ivapaydetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapayincomeview 		=> Tables["ivapayincomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivapayexpenseview 		=> Tables["ivapayexpenseview"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dettliquidazioneivaview_debito 		=> Tables["dettliquidazioneivaview_debito"];

	///<summary>
	///iva di una fattura inserita in liquidazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedeferred 		=> Tables["invoicedeferred"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deferredview_fatture_vendita 		=> Tables["deferredview_fatture_vendita"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deferredview_fatture_acquisti_comm 		=> Tables["deferredview_fatture_acquisti_comm"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deferredview_fatture_acquisti_prom 		=> Tables["deferredview_fatture_acquisti_prom"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deferredview_fatture_acquisti_ist_split 		=> Tables["deferredview_fatture_acquisti_ist_split"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deferredview_fatture_acquisti_ist_intraextra 		=> Tables["deferredview_fatture_acquisti_ist_intraextra"];

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
	tivapay.Columns.Add( new DataColumn("debitamount", typeof(decimal)));
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
	tivapay.Columns.Add( new DataColumn("creditamountdeferred", typeof(decimal)));
	tivapay.Columns.Add( new DataColumn("debitamountdeferred", typeof(decimal)));
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
	tivapay.PrimaryKey =  new DataColumn[]{tivapay.Columns["yivapay"], tivapay.Columns["nivapay"]};


	//////////////////// IVAPAYDETAILVIEW /////////////////////////////////
	var tivapaydetailview= new DataTable("ivapaydetailview");
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	C= new DataColumn("registerclass", typeof(string));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	tivapaydetailview.Columns.Add( new DataColumn("iva", typeof(decimal)));
	tivapaydetailview.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tivapaydetailview.Columns.Add( new DataColumn("prorata", typeof(decimal)));
	tivapaydetailview.Columns.Add( new DataColumn("mixed", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivapaydetailview.Columns.Add(C);
	tivapaydetailview.Columns.Add( new DataColumn("!ivacredit", typeof(decimal)));
	tivapaydetailview.Columns.Add( new DataColumn("ivadeferred", typeof(decimal)));
	tivapaydetailview.Columns.Add( new DataColumn("unabatabledeferred", typeof(decimal)));
	tivapaydetailview.Columns.Add( new DataColumn("ivatotal", typeof(decimal)));
	tivapaydetailview.Columns.Add( new DataColumn("unabatabletotal", typeof(decimal)));
	tivapaydetailview.Columns.Add( new DataColumn("ivanet", typeof(decimal)));
	tivapaydetailview.Columns.Add( new DataColumn("ivanetdeferred", typeof(decimal)));
	tivapaydetailview.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tivapaydetailview.Columns.Add( new DataColumn("department", typeof(string)));
	tivapaydetailview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tivapaydetailview.Columns.Add( new DataColumn("codeivaregisterkind", typeof(string)));
	Tables.Add(tivapaydetailview);
	tivapaydetailview.PrimaryKey =  new DataColumn[]{tivapaydetailview.Columns["yivapay"], tivapaydetailview.Columns["nivapay"], tivapaydetailview.Columns["idivaregisterkind"]};


	//////////////////// IVAPAYINCOMEVIEW /////////////////////////////////
	var tivapayincomeview= new DataTable("ivapayincomeview");
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	tivapayincomeview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	tivapayincomeview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tivapayincomeview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tivapayincomeview.Columns.Add( new DataColumn("finance", typeof(string)));
	tivapayincomeview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tivapayincomeview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tivapayincomeview.Columns.Add( new DataColumn("upb", typeof(string)));
	tivapayincomeview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tivapayincomeview.Columns.Add( new DataColumn("registry", typeof(string)));
	tivapayincomeview.Columns.Add( new DataColumn("idman", typeof(int)));
	tivapayincomeview.Columns.Add( new DataColumn("manager", typeof(string)));
	tivapayincomeview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tivapayincomeview.Columns.Add( new DataColumn("npro", typeof(int)));
	tivapayincomeview.Columns.Add( new DataColumn("doc", typeof(string)));
	tivapayincomeview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	tivapayincomeview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tivapayincomeview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tivapayincomeview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tivapayincomeview.Columns.Add( new DataColumn("available", typeof(decimal)));
	C= new DataColumn("unpartitioned", typeof(decimal));
	C.ReadOnly=true;
	tivapayincomeview.Columns.Add(C);
	tivapayincomeview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tivapayincomeview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tivapayincomeview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tivapayincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayincomeview.Columns.Add(C);
	Tables.Add(tivapayincomeview);
	tivapayincomeview.PrimaryKey =  new DataColumn[]{tivapayincomeview.Columns["yivapay"], tivapayincomeview.Columns["nivapay"], tivapayincomeview.Columns["idinc"]};


	//////////////////// IVAPAYEXPENSEVIEW /////////////////////////////////
	var tivapayexpenseview= new DataTable("ivapayexpenseview");
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	tivapayexpenseview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	tivapayexpenseview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tivapayexpenseview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("finance", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("upb", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tivapayexpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("idman", typeof(int)));
	tivapayexpenseview.Columns.Add( new DataColumn("manager", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("ypay", typeof(short)));
	tivapayexpenseview.Columns.Add( new DataColumn("npay", typeof(int)));
	tivapayexpenseview.Columns.Add( new DataColumn("doc", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	tivapayexpenseview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tivapayexpenseview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tivapayexpenseview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tivapayexpenseview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tivapayexpenseview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	tivapayexpenseview.Columns.Add( new DataColumn("cin", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("idbank", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("idcab", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("cc", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("idser", typeof(int)));
	tivapayexpenseview.Columns.Add( new DataColumn("service", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	tivapayexpenseview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	tivapayexpenseview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	tivapayexpenseview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tivapayexpenseview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tivapayexpenseview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tivapayexpenseview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivapayexpenseview.Columns.Add(C);
	Tables.Add(tivapayexpenseview);
	tivapayexpenseview.PrimaryKey =  new DataColumn[]{tivapayexpenseview.Columns["yivapay"], tivapayexpenseview.Columns["nivapay"], tivapayexpenseview.Columns["idexp"]};


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


	//////////////////// DETTLIQUIDAZIONEIVAVIEW_DEBITO /////////////////////////////////
	var tdettliquidazioneivaview_debito= new DataTable("dettliquidazioneivaview_debito");
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	C= new DataColumn("registerclass", typeof(string));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("iva", typeof(decimal)));
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("prorata", typeof(decimal)));
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("mixed", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tdettliquidazioneivaview_debito.Columns.Add(C);
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("ivadeferred", typeof(decimal)));
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("unabatabledeferred", typeof(decimal)));
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("ivatotal", typeof(decimal)));
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("unabatabletotal", typeof(decimal)));
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("department", typeof(string)));
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tdettliquidazioneivaview_debito.Columns.Add( new DataColumn("codeivaregisterkind", typeof(string)));
	Tables.Add(tdettliquidazioneivaview_debito);
	tdettliquidazioneivaview_debito.PrimaryKey =  new DataColumn[]{tdettliquidazioneivaview_debito.Columns["yivapay"], tdettliquidazioneivaview_debito.Columns["nivapay"], tdettliquidazioneivaview_debito.Columns["idivaregisterkind"]};


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
	tinvoicedeferred.PrimaryKey =  new DataColumn[]{tinvoicedeferred.Columns["yivapay"], tinvoicedeferred.Columns["nivapay"], tinvoicedeferred.Columns["idinvkind"], tinvoicedeferred.Columns["yinv"], tinvoicedeferred.Columns["ninv"]};


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
	tconfig.Columns.Add( new DataColumn("startivabalance12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("flagpayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("paymentagencysplit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapaymentsplit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("startivabalancesplit", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_split", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapaymentsplit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpaymentsplit", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// DEFERREDVIEW_FATTURE_VENDITA /////////////////////////////////
	var tdeferredview_fatture_vendita= new DataTable("deferredview_fatture_vendita");
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	tdeferredview_fatture_vendita.Columns.Add( new DataColumn("ivatotalpayed", typeof(decimal)));
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("flagbuysell", typeof(string));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("flagvariation", typeof(string));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	tdeferredview_fatture_vendita.Columns.Add( new DataColumn("doc", typeof(string)));
	tdeferredview_fatture_vendita.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("taxable", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	tdeferredview_fatture_vendita.Columns.Add( new DataColumn("active", typeof(string)));
	tdeferredview_fatture_vendita.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	tdeferredview_fatture_vendita.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_vendita.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_vendita.Columns.Add(C);
	tdeferredview_fatture_vendita.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tdeferredview_fatture_vendita.Columns.Add( new DataColumn("registerclass", typeof(string)));
	tdeferredview_fatture_vendita.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	Tables.Add(tdeferredview_fatture_vendita);
	tdeferredview_fatture_vendita.PrimaryKey =  new DataColumn[]{tdeferredview_fatture_vendita.Columns["nivapay"], tdeferredview_fatture_vendita.Columns["yivapay"], tdeferredview_fatture_vendita.Columns["idinvkind"], tdeferredview_fatture_vendita.Columns["yinv"], tdeferredview_fatture_vendita.Columns["ninv"], tdeferredview_fatture_vendita.Columns["idivaregisterkind"]};


	//////////////////// DEFERREDVIEW_FATTURE_ACQUISTI_COMM /////////////////////////////////
	var tdeferredview_fatture_acquisti_comm= new DataTable("deferredview_fatture_acquisti_comm");
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	tdeferredview_fatture_acquisti_comm.Columns.Add( new DataColumn("ivatotalpayed", typeof(decimal)));
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("flagbuysell", typeof(string));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("flagvariation", typeof(string));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	tdeferredview_fatture_acquisti_comm.Columns.Add( new DataColumn("doc", typeof(string)));
	tdeferredview_fatture_acquisti_comm.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("taxable", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	tdeferredview_fatture_acquisti_comm.Columns.Add( new DataColumn("active", typeof(string)));
	tdeferredview_fatture_acquisti_comm.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	tdeferredview_fatture_acquisti_comm.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_comm.Columns.Add(C);
	tdeferredview_fatture_acquisti_comm.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tdeferredview_fatture_acquisti_comm.Columns.Add( new DataColumn("registerclass", typeof(string)));
	tdeferredview_fatture_acquisti_comm.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	Tables.Add(tdeferredview_fatture_acquisti_comm);
	tdeferredview_fatture_acquisti_comm.PrimaryKey =  new DataColumn[]{tdeferredview_fatture_acquisti_comm.Columns["nivapay"], tdeferredview_fatture_acquisti_comm.Columns["yivapay"], tdeferredview_fatture_acquisti_comm.Columns["yinv"], tdeferredview_fatture_acquisti_comm.Columns["ninv"], tdeferredview_fatture_acquisti_comm.Columns["idinvkind"], tdeferredview_fatture_acquisti_comm.Columns["idivaregisterkind"]};


	//////////////////// DEFERREDVIEW_FATTURE_ACQUISTI_PROM /////////////////////////////////
	var tdeferredview_fatture_acquisti_prom= new DataTable("deferredview_fatture_acquisti_prom");
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	tdeferredview_fatture_acquisti_prom.Columns.Add( new DataColumn("ivatotalpayed", typeof(decimal)));
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("flagbuysell", typeof(string));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("flagvariation", typeof(string));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	tdeferredview_fatture_acquisti_prom.Columns.Add( new DataColumn("doc", typeof(string)));
	tdeferredview_fatture_acquisti_prom.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("taxable", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	tdeferredview_fatture_acquisti_prom.Columns.Add( new DataColumn("active", typeof(string)));
	tdeferredview_fatture_acquisti_prom.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	tdeferredview_fatture_acquisti_prom.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_prom.Columns.Add(C);
	tdeferredview_fatture_acquisti_prom.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tdeferredview_fatture_acquisti_prom.Columns.Add( new DataColumn("registerclass", typeof(string)));
	tdeferredview_fatture_acquisti_prom.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	Tables.Add(tdeferredview_fatture_acquisti_prom);
	tdeferredview_fatture_acquisti_prom.PrimaryKey =  new DataColumn[]{tdeferredview_fatture_acquisti_prom.Columns["nivapay"], tdeferredview_fatture_acquisti_prom.Columns["yivapay"], tdeferredview_fatture_acquisti_prom.Columns["idinvkind"], tdeferredview_fatture_acquisti_prom.Columns["yinv"], tdeferredview_fatture_acquisti_prom.Columns["ninv"], tdeferredview_fatture_acquisti_prom.Columns["idivaregisterkind"]};


	//////////////////// DEFERREDVIEW_FATTURE_ACQUISTI_IST_SPLIT /////////////////////////////////
	var tdeferredview_fatture_acquisti_ist_split= new DataTable("deferredview_fatture_acquisti_ist_split");
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	tdeferredview_fatture_acquisti_ist_split.Columns.Add( new DataColumn("ivatotalpayed", typeof(decimal)));
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("flagbuysell", typeof(string));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("flagvariation", typeof(string));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	tdeferredview_fatture_acquisti_ist_split.Columns.Add( new DataColumn("doc", typeof(string)));
	tdeferredview_fatture_acquisti_ist_split.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("taxable", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	tdeferredview_fatture_acquisti_ist_split.Columns.Add( new DataColumn("active", typeof(string)));
	tdeferredview_fatture_acquisti_ist_split.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	tdeferredview_fatture_acquisti_ist_split.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_split.Columns.Add(C);
	tdeferredview_fatture_acquisti_ist_split.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tdeferredview_fatture_acquisti_ist_split.Columns.Add( new DataColumn("registerclass", typeof(string)));
	tdeferredview_fatture_acquisti_ist_split.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	Tables.Add(tdeferredview_fatture_acquisti_ist_split);
	tdeferredview_fatture_acquisti_ist_split.PrimaryKey =  new DataColumn[]{tdeferredview_fatture_acquisti_ist_split.Columns["nivapay"], tdeferredview_fatture_acquisti_ist_split.Columns["yivapay"], tdeferredview_fatture_acquisti_ist_split.Columns["idinvkind"], tdeferredview_fatture_acquisti_ist_split.Columns["yinv"], tdeferredview_fatture_acquisti_ist_split.Columns["ninv"], tdeferredview_fatture_acquisti_ist_split.Columns["idivaregisterkind"]};


	//////////////////// DEFERREDVIEW_FATTURE_ACQUISTI_IST_INTRAEXTRA /////////////////////////////////
	var tdeferredview_fatture_acquisti_ist_intraextra= new DataTable("deferredview_fatture_acquisti_ist_intraextra");
	C= new DataColumn("nivapay", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("yivapay", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add( new DataColumn("ivatotalpayed", typeof(decimal)));
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("flagbuysell", typeof(string));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("flagvariation", typeof(string));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add( new DataColumn("doc", typeof(string)));
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("taxable", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add( new DataColumn("active", typeof(string)));
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add(C);
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add( new DataColumn("registerclass", typeof(string)));
	tdeferredview_fatture_acquisti_ist_intraextra.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	Tables.Add(tdeferredview_fatture_acquisti_ist_intraextra);
	tdeferredview_fatture_acquisti_ist_intraextra.PrimaryKey =  new DataColumn[]{tdeferredview_fatture_acquisti_ist_intraextra.Columns["nivapay"], tdeferredview_fatture_acquisti_ist_intraextra.Columns["yivapay"], tdeferredview_fatture_acquisti_ist_intraextra.Columns["idinvkind"], tdeferredview_fatture_acquisti_ist_intraextra.Columns["yinv"], tdeferredview_fatture_acquisti_ist_intraextra.Columns["ninv"], tdeferredview_fatture_acquisti_ist_intraextra.Columns["idivaregisterkind"]};


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
	tinvoicedetaildeferred.Columns.Add( new DataColumn("lt", typeof(string)));
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetaildeferred.Columns.Add(C);
	Tables.Add(tinvoicedetaildeferred);
	tinvoicedetaildeferred.PrimaryKey =  new DataColumn[]{tinvoicedetaildeferred.Columns["idinvkind"], tinvoicedetaildeferred.Columns["yinv"], tinvoicedetaildeferred.Columns["ninv"], tinvoicedetaildeferred.Columns["rownum"], tinvoicedetaildeferred.Columns["yivapay"], tinvoicedetaildeferred.Columns["nivapay"], tinvoicedetaildeferred.Columns["idivaregisterkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	var cChild = new []{invoicedetaildeferred.Columns["yivapay"], invoicedetaildeferred.Columns["nivapay"]};
	Relations.Add(new DataRelation("ivapay_invoicedetaildeferred",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{deferredview_fatture_acquisti_ist_intraextra.Columns["yivapay"], deferredview_fatture_acquisti_ist_intraextra.Columns["nivapay"]};
	Relations.Add(new DataRelation("FK_ivapay_deferredview_fatture_acquisti_ist_intraextra",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{deferredview_fatture_acquisti_ist_split.Columns["yivapay"], deferredview_fatture_acquisti_ist_split.Columns["nivapay"]};
	Relations.Add(new DataRelation("FK_ivapay_deferredview_fatture_acquisti_ist_split",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{deferredview_fatture_acquisti_prom.Columns["yivapay"], deferredview_fatture_acquisti_prom.Columns["nivapay"]};
	Relations.Add(new DataRelation("FK_ivapay_deferredview_fatture_acquisti_prom",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{deferredview_fatture_acquisti_comm.Columns["yivapay"], deferredview_fatture_acquisti_comm.Columns["nivapay"]};
	Relations.Add(new DataRelation("FK_ivapay_deferredview_fatture_acquisti_comm",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{deferredview_fatture_vendita.Columns["yivapay"], deferredview_fatture_vendita.Columns["nivapay"]};
	Relations.Add(new DataRelation("FK_ivapay_deferredview_fatture_vendita",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{invoicedeferred.Columns["yivapay"], invoicedeferred.Columns["nivapay"]};
	Relations.Add(new DataRelation("ivapayinvoicedeferred",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{dettliquidazioneivaview_debito.Columns["yivapay"], dettliquidazioneivaview_debito.Columns["nivapay"]};
	Relations.Add(new DataRelation("ivapaydettliquidazioneivaview_debito",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{ivapayexpenseview.Columns["yivapay"], ivapayexpenseview.Columns["nivapay"]};
	Relations.Add(new DataRelation("ivapayivapayexpenseview",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{ivapayincomeview.Columns["yivapay"], ivapayincomeview.Columns["nivapay"]};
	Relations.Add(new DataRelation("ivapayivapayincomeview",cPar,cChild,false));

	cPar = new []{ivapay.Columns["yivapay"], ivapay.Columns["nivapay"]};
	cChild = new []{ivapaydetailview.Columns["yivapay"], ivapaydetailview.Columns["nivapay"]};
	Relations.Add(new DataRelation("ivapayivapaydetailview",cPar,cChild,false));

	#endregion

}
}
}
