
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
namespace expensevar_detail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	///<summary>
	///Variazione movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensevar 		=> Tables["expensevar"];

	///<summary>
	///Distinta di trasmissione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable paymenttransmission 		=> Tables["paymenttransmission"];

	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoiceavailable 		=> Tables["invoiceavailable"];

	///<summary>
	///Fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoice 		=> Tables["invoice"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetail_iva_nc 		=> Tables["invoicedetail_iva_nc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetail_taxable_nc 		=> Tables["invoicedetail_taxable_nc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tipomovimento 		=> Tables["tipomovimento"];

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


	//////////////////// EXPENSEVAR /////////////////////////////////
	var texpensevar= new DataTable("expensevar");
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	texpensevar.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensevar.Columns.Add( new DataColumn("doc", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpensevar.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	texpensevar.Columns.Add( new DataColumn("txt", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	texpensevar.Columns.Add( new DataColumn("transferkind", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("movkind", typeof(short)));
	texpensevar.Columns.Add( new DataColumn("kpaymenttransmission", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("yinv", typeof(short)));
	texpensevar.Columns.Add( new DataColumn("ninv", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("idunderwrinting", typeof(int)));
	Tables.Add(texpensevar);
	texpensevar.PrimaryKey =  new DataColumn[]{texpensevar.Columns["nvar"], texpensevar.Columns["idexp"]};


	//////////////////// PAYMENTTRANSMISSION /////////////////////////////////
	var tpaymenttransmission= new DataTable("paymenttransmission");
	C= new DataColumn("npaymenttransmission", typeof(int));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("ypaymenttransmission", typeof(short));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	tpaymenttransmission.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	tpaymenttransmission.Columns.Add( new DataColumn("idman", typeof(int)));
	tpaymenttransmission.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("kpaymenttransmission", typeof(int));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	tpaymenttransmission.Columns.Add( new DataColumn("flagmailsent", typeof(string)));
	tpaymenttransmission.Columns.Add( new DataColumn("transmissionkind", typeof(string)));
	Tables.Add(tpaymenttransmission);
	tpaymenttransmission.PrimaryKey =  new DataColumn[]{tpaymenttransmission.Columns["kpaymenttransmission"]};


	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new DataTable("underwriting");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("active", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("doc", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	Tables.Add(tunderwriting);
	tunderwriting.PrimaryKey =  new DataColumn[]{tunderwriting.Columns["idunderwriting"]};


	//////////////////// INVOICEAVAILABLE /////////////////////////////////
	var tinvoiceavailable= new DataTable("invoiceavailable");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("flagbuysell", typeof(string));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("flagvariation", typeof(string));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	tinvoiceavailable.Columns.Add( new DataColumn("registryreference", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	tinvoiceavailable.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tinvoiceavailable.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tinvoiceavailable.Columns.Add( new DataColumn("doc", typeof(string)));
	tinvoiceavailable.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	tinvoiceavailable.Columns.Add( new DataColumn("packinglistnum", typeof(string)));
	tinvoiceavailable.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoiceavailable.Columns.Add(C);
	tinvoiceavailable.Columns.Add( new DataColumn("taxabletotal", typeof(decimal)));
	tinvoiceavailable.Columns.Add( new DataColumn("ivatotal", typeof(decimal)));
	tinvoiceavailable.Columns.Add( new DataColumn("linkedamount", typeof(decimal)));
	tinvoiceavailable.Columns.Add( new DataColumn("residual", typeof(decimal)));
	tinvoiceavailable.Columns.Add( new DataColumn("active", typeof(string)));
	tinvoiceavailable.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoiceavailable.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoiceavailable.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoiceavailable.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoiceavailable.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinvoiceavailable);
	tinvoiceavailable.PrimaryKey =  new DataColumn[]{tinvoiceavailable.Columns["idinvkind"], tinvoiceavailable.Columns["yinv"], tinvoiceavailable.Columns["ninv"]};


	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new DataTable("invoice");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
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
	tinvoice.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
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
	tinvoice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinvoice);
	tinvoice.PrimaryKey =  new DataColumn[]{tinvoice.Columns["idinvkind"], tinvoice.Columns["yinv"], tinvoice.Columns["ninv"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	tinvoicekind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// INVOICEDETAIL_IVA_NC /////////////////////////////////
	var tinvoicedetail_iva_nc= new DataTable("invoicedetail_iva_nc");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("flagbuysell", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("flagvariation", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("ivakind", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("number", typeof(decimal)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("discount", typeof(double)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("mankind", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("yman", typeof(short)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("nman", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("mandetaildescription", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idupb", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idexp_ivamand", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idexp_taxablemand", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idinc_ivaestim", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idinc_taxableestim", typeof(int)));
	C= new DataColumn("taxable_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("iva_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("unabatable_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("rowtotal", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_iva_nc.Columns.Add(C);
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("estimkind", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("yestim", typeof(short)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("nestim", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("estimrownum", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("estimatedetaildescription", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("va3type", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idlist", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idunit", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("idinvkind_main", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("yinv_main", typeof(short)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("ninv_main", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("ycon", typeof(int)));
	tinvoicedetail_iva_nc.Columns.Add( new DataColumn("ncon", typeof(int)));
	Tables.Add(tinvoicedetail_iva_nc);
	tinvoicedetail_iva_nc.PrimaryKey =  new DataColumn[]{tinvoicedetail_iva_nc.Columns["idinvkind"], tinvoicedetail_iva_nc.Columns["yinv"], tinvoicedetail_iva_nc.Columns["ninv"], tinvoicedetail_iva_nc.Columns["rownum"]};


	//////////////////// INVOICEDETAIL_TAXABLE_NC /////////////////////////////////
	var tinvoicedetail_taxable_nc= new DataTable("invoicedetail_taxable_nc");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("flagbuysell", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("flagvariation", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("ivakind", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("number", typeof(decimal)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("discount", typeof(double)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("mankind", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("yman", typeof(short)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("nman", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("mandetaildescription", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idupb", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idexp_ivamand", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idexp_taxablemand", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idinc_ivaestim", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idinc_taxableestim", typeof(int)));
	C= new DataColumn("taxable_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("iva_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("unabatable_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("rowtotal", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_taxable_nc.Columns.Add(C);
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("estimkind", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("yestim", typeof(short)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("nestim", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("estimrownum", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("estimatedetaildescription", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("va3type", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idlist", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idunit", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("idinvkind_main", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("yinv_main", typeof(short)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("ninv_main", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("ycon", typeof(int)));
	tinvoicedetail_taxable_nc.Columns.Add( new DataColumn("ncon", typeof(int)));
	Tables.Add(tinvoicedetail_taxable_nc);
	tinvoicedetail_taxable_nc.PrimaryKey =  new DataColumn[]{tinvoicedetail_taxable_nc.Columns["idinvkind"], tinvoicedetail_taxable_nc.Columns["yinv"], tinvoicedetail_taxable_nc.Columns["ninv"], tinvoicedetail_taxable_nc.Columns["rownum"]};


	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	var ttipomovimento= new DataTable("tipomovimento");
	C= new DataColumn("idtipo", typeof(short));
	C.AllowDBNull=false;
	ttipomovimento.Columns.Add(C);
	ttipomovimento.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(ttipomovimento);
	ttipomovimento.PrimaryKey =  new DataColumn[]{ttipomovimento.Columns["idtipo"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{underwriting.Columns["idunderwriting"]};
	var cChild = new []{expensevar.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("FK_underwriting_expensevar",cPar,cChild,false));

	cPar = new []{paymenttransmission.Columns["kpaymenttransmission"]};
	cChild = new []{expensevar.Columns["kpaymenttransmission"]};
	Relations.Add(new DataRelation("paymenttransmission_expensevar",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{expensevar.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekind_expensevar",cPar,cChild,false));

	cPar = new []{invoice.Columns["idinvkind"], invoice.Columns["yinv"], invoice.Columns["ninv"]};
	cChild = new []{expensevar.Columns["idinvkind"], expensevar.Columns["yinv"], expensevar.Columns["ninv"]};
	Relations.Add(new DataRelation("invoice_expensevar",cPar,cChild,false));

	cPar = new []{tipomovimento.Columns["idtipo"]};
	cChild = new []{expensevar.Columns["movkind"]};
	Relations.Add(new DataRelation("tipomovimento_expensevar",cPar,cChild,false));

	cPar = new []{invoiceavailable.Columns["idinvkind"], invoiceavailable.Columns["yinv"], invoiceavailable.Columns["ninv"]};
	cChild = new []{expensevar.Columns["idinvkind"], expensevar.Columns["yinv"], expensevar.Columns["ninv"]};
	Relations.Add(new DataRelation("invoiceavailable_expensevar",cPar,cChild,false));

	cPar = new []{expensevar.Columns["idexp"], expensevar.Columns["idinvkind"], expensevar.Columns["yinv"], expensevar.Columns["ninv"]};
	cChild = new []{invoicedetail_iva_nc.Columns["idexp_iva"], invoicedetail_iva_nc.Columns["idinvkind"], invoicedetail_iva_nc.Columns["yinv"], invoicedetail_iva_nc.Columns["ninv"]};
	Relations.Add(new DataRelation("expensevar_invoicedetail_iva",cPar,cChild,false));

	cPar = new []{expensevar.Columns["idexp"], expensevar.Columns["idinvkind"], expensevar.Columns["yinv"], expensevar.Columns["ninv"]};
	cChild = new []{invoicedetail_taxable_nc.Columns["idexp_iva"], invoicedetail_taxable_nc.Columns["idinvkind"], invoicedetail_taxable_nc.Columns["yinv"], invoicedetail_taxable_nc.Columns["ninv"]};
	Relations.Add(new DataRelation("expensevar_invoicedetail_taxable1",cPar,cChild,false));

	cPar = new []{expensevar.Columns["idexp"], expensevar.Columns["idinvkind"], expensevar.Columns["yinv"], expensevar.Columns["ninv"]};
	cChild = new []{invoicedetail_taxable_nc.Columns["idexp_taxable"], invoicedetail_taxable_nc.Columns["idinvkind"], invoicedetail_taxable_nc.Columns["yinv"], invoicedetail_taxable_nc.Columns["ninv"]};
	Relations.Add(new DataRelation("expensevar_invoicedetail_taxable",cPar,cChild,false));

	#endregion

}
}
}
