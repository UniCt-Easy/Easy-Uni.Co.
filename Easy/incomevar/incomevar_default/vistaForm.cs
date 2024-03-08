
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
namespace incomevar_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomevar 		=> Tables["incomevar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tipomovimento 		=> Tables["tipomovimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoiceavailable 		=> Tables["invoiceavailable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomesorted 		=> Tables["incomesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable creditpart 		=> Tables["creditpart"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceedspart 		=> Tables["proceedspart"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetail_iva 		=> Tables["invoicedetail_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetail_taxable 		=> Tables["invoicedetail_taxable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoice 		=> Tables["invoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceedstransmission 		=> Tables["proceedstransmission"];

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
	//////////////////// INCOMEVAR /////////////////////////////////
	var tincomevar= new DataTable("incomevar");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomevar.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomevar.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("transferkind", typeof(string)));
	tincomevar.Columns.Add( new DataColumn("txt", typeof(string)));
	tincomevar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomevar.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tincomevar.Columns.Add( new DataColumn("yinv", typeof(short)));
	tincomevar.Columns.Add( new DataColumn("ninv", typeof(int)));
	tincomevar.Columns.Add( new DataColumn("movkind", typeof(short)));
	tincomevar.Columns.Add( new DataColumn("kproceedstransmission", typeof(int)));
	Tables.Add(tincomevar);
	tincomevar.PrimaryKey =  new DataColumn[]{tincomevar.Columns["idinc"], tincomevar.Columns["nvar"]};


	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	var ttipomovimento= new DataTable("tipomovimento");
	C= new DataColumn("idtipo", typeof(short));
	C.AllowDBNull=false;
	ttipomovimento.Columns.Add(C);
	ttipomovimento.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(ttipomovimento);
	ttipomovimento.PrimaryKey =  new DataColumn[]{ttipomovimento.Columns["idtipo"]};


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
	tinvoiceavailable.Columns.Add( new DataColumn("flagbuysell", typeof(string)));
	tinvoiceavailable.Columns.Add( new DataColumn("flagvariation", typeof(string)));
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


	//////////////////// INCOMESORTED /////////////////////////////////
	var tincomesorted= new DataTable("incomesorted");
	tincomesorted.Columns.Add( new DataColumn("!percentuale", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("!idsorkind", typeof(int)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(short));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("ayear", typeof(short)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("description", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("paridsor", typeof(int)));
	tincomesorted.Columns.Add( new DataColumn("paridsubclass", typeof(short)));
	tincomesorted.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tincomesorted.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tincomesorted.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tincomesorted.Columns.Add( new DataColumn("tobecontinued", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("txt", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("valuen1", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen2", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen3", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen4", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen5", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("values1", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values2", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values3", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values4", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values5", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("valuev1", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev2", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev3", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev4", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev5", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("!codice", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("!descr", typeof(string)));
	Tables.Add(tincomesorted);
	tincomesorted.PrimaryKey =  new DataColumn[]{tincomesorted.Columns["idinc"], tincomesorted.Columns["idsor"], tincomesorted.Columns["idsubclass"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("!importo", typeof(decimal)));
	tsortingkind.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


	//////////////////// CREDITPART /////////////////////////////////
	var tcreditpart= new DataTable("creditpart");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("ncreditpart", typeof(int));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	tcreditpart.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	tcreditpart.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tcreditpart.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ycreditpart", typeof(short));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	tcreditpart.Columns.Add( new DataColumn("!codice", typeof(string)));
	tcreditpart.Columns.Add( new DataColumn("!descr", typeof(string)));
	Tables.Add(tcreditpart);
	tcreditpart.PrimaryKey =  new DataColumn[]{tcreditpart.Columns["idinc"], tcreditpart.Columns["ncreditpart"]};


	//////////////////// PROCEEDSPART /////////////////////////////////
	var tproceedspart= new DataTable("proceedspart");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("nproceedspart", typeof(int));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	tproceedspart.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	tproceedspart.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tproceedspart.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yproceedspart", typeof(short));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	tproceedspart.Columns.Add( new DataColumn("!codice", typeof(string)));
	tproceedspart.Columns.Add( new DataColumn("!descr", typeof(string)));
	Tables.Add(tproceedspart);
	tproceedspart.PrimaryKey =  new DataColumn[]{tproceedspart.Columns["idinc"], tproceedspart.Columns["nproceedspart"]};


	//////////////////// INVOICEDETAIL_IVA /////////////////////////////////
	var tinvoicedetail_iva= new DataTable("invoicedetail_iva");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	tinvoicedetail_iva.Columns.Add( new DataColumn("flagbuysell", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("flagvariation", typeof(string)));
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	tinvoicedetail_iva.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("ivakind", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	tinvoicedetail_iva.Columns.Add( new DataColumn("number", typeof(decimal)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("discount", typeof(double)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("mankind", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("yman", typeof(short)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("nman", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("mandetaildescription", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idupb", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	tinvoicedetail_iva.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idexp_ivamand", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idexp_taxablemand", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idinc_ivaestim", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idinc_taxableestim", typeof(int)));
	C= new DataColumn("taxable_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("iva_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("unabatable_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("rowtotal", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_iva.Columns.Add(C);
	tinvoicedetail_iva.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("estimkind", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("yestim", typeof(short)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("nestim", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("estimrownum", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("estimatedetaildescription", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idlist", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idunit", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("idinvkind_main", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("yinv_main", typeof(short)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("ninv_main", typeof(int)));
	tinvoicedetail_iva.Columns.Add( new DataColumn("rownum_main", typeof(int)));
	Tables.Add(tinvoicedetail_iva);
	tinvoicedetail_iva.PrimaryKey =  new DataColumn[]{tinvoicedetail_iva.Columns["idinvkind"], tinvoicedetail_iva.Columns["yinv"], tinvoicedetail_iva.Columns["ninv"], tinvoicedetail_iva.Columns["rownum"]};


	//////////////////// INVOICEDETAIL_TAXABLE /////////////////////////////////
	var tinvoicedetail_taxable= new DataTable("invoicedetail_taxable");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("invoicekind", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	tinvoicedetail_taxable.Columns.Add( new DataColumn("flagbuysell", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("flagvariation", typeof(string)));
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	tinvoicedetail_taxable.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("ivakind", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	tinvoicedetail_taxable.Columns.Add( new DataColumn("number", typeof(decimal)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("discount", typeof(double)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("mankind", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("yman", typeof(short)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("nman", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("mandetaildescription", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idupb", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idexp_ivamand", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idexp_taxablemand", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idinc_ivaestim", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idinc_taxableestim", typeof(int)));
	C= new DataColumn("taxable_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("iva_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("unabatable_euro", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("rowtotal", typeof(decimal));
	C.ReadOnly=true;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail_taxable.Columns.Add(C);
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("estimkind", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("yestim", typeof(short)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("nestim", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("estimrownum", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("estimatedetaildescription", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idlist", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idunit", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("idinvkind_main", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("yinv_main", typeof(short)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("ninv_main", typeof(int)));
	tinvoicedetail_taxable.Columns.Add( new DataColumn("rownum_main", typeof(int)));
	Tables.Add(tinvoicedetail_taxable);
	tinvoicedetail_taxable.PrimaryKey =  new DataColumn[]{tinvoicedetail_taxable.Columns["idinvkind"], tinvoicedetail_taxable.Columns["yinv"], tinvoicedetail_taxable.Columns["ninv"], tinvoicedetail_taxable.Columns["rownum"]};


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
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new DataTable("incomephase");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	Tables.Add(tincomephase);
	tincomephase.PrimaryKey =  new DataColumn[]{tincomephase.Columns["nphase"]};


	//////////////////// INCOMEVIEW /////////////////////////////////
	var tincomeview= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
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
	tincomeview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("kpro", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tincomeview);
	tincomeview.PrimaryKey =  new DataColumn[]{tincomeview.Columns["idinc"], tincomeview.Columns["ayear"]};


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
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// PROCEEDSTRANSMISSION /////////////////////////////////
	var tproceedstransmission= new DataTable("proceedstransmission");
	C= new DataColumn("nproceedstransmission", typeof(int));
	C.AllowDBNull=false;
	tproceedstransmission.Columns.Add(C);
	C= new DataColumn("yproceedstransmission", typeof(short));
	C.AllowDBNull=false;
	tproceedstransmission.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedstransmission.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceedstransmission.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedstransmission.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceedstransmission.Columns.Add(C);
	tproceedstransmission.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	tproceedstransmission.Columns.Add( new DataColumn("idman", typeof(int)));
	tproceedstransmission.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("kproceedstransmission", typeof(int));
	C.AllowDBNull=false;
	tproceedstransmission.Columns.Add(C);
	tproceedstransmission.Columns.Add( new DataColumn("transmissionkind", typeof(string)));
	Tables.Add(tproceedstransmission);
	tproceedstransmission.PrimaryKey =  new DataColumn[]{tproceedstransmission.Columns["kproceedstransmission"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{incomephase.Columns["nphase"]};
	var cChild = new []{incomeview.Columns["nphase"]};
	Relations.Add(new DataRelation("incomephase_incomeview",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekindinvoice",cPar,cChild,false));

	cPar = new []{incomevar.Columns["idinc"]};
	cChild = new []{invoicedetail_taxable.Columns["idinc_taxable"]};
	Relations.Add(new DataRelation("incomevarinvoicedetail_taxable",cPar,cChild,false));

	cPar = new []{incomevar.Columns["idinc"]};
	cChild = new []{invoicedetail_taxable.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("incomevarinvoicedetail_taxable1",cPar,cChild,false));

	cPar = new []{incomevar.Columns["idinc"]};
	cChild = new []{invoicedetail_iva.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("incomevarinvoicedetail_iva",cPar,cChild,false));

	cPar = new []{incomevar.Columns["idinc"]};
	cChild = new []{proceedspart.Columns["idinc"]};
	Relations.Add(new DataRelation("incomevarproceedspart",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{proceedspart.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_proceedspart",cPar,cChild,false));

	cPar = new []{incomevar.Columns["idinc"]};
	cChild = new []{creditpart.Columns["idinc"]};
	Relations.Add(new DataRelation("incomevarcreditpart",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{creditpart.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_creditpart",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{sorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkindsorting",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{incomesorted.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingincomesorted",cPar,cChild,false));

	cPar = new []{incomevar.Columns["idinc"]};
	cChild = new []{incomesorted.Columns["idinc"]};
	Relations.Add(new DataRelation("incomevarincomesorted",cPar,cChild,false));

	cPar = new []{tipomovimento.Columns["idtipo"]};
	cChild = new []{incomevar.Columns["movkind"]};
	Relations.Add(new DataRelation("tipomovimentoincomevar",cPar,cChild,false));

	cPar = new []{invoiceavailable.Columns["idinvkind"], invoiceavailable.Columns["yinv"], invoiceavailable.Columns["ninv"]};
	cChild = new []{incomevar.Columns["idinvkind"], incomevar.Columns["yinv"], incomevar.Columns["ninv"]};
	Relations.Add(new DataRelation("invoiceavailable_incomevar",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{incomevar.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekind_incomevar",cPar,cChild,false));

	cPar = new []{invoice.Columns["idinvkind"], invoice.Columns["yinv"], invoice.Columns["ninv"]};
	cChild = new []{incomevar.Columns["idinvkind"], incomevar.Columns["yinv"], incomevar.Columns["ninv"]};
	Relations.Add(new DataRelation("invoice_incomevar",cPar,cChild,false));

	cPar = new []{incomeview.Columns["idinc"]};
	cChild = new []{incomevar.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeview_incomevar",cPar,cChild,false));

	cPar = new []{proceedstransmission.Columns["kproceedstransmission"]};
	cChild = new []{incomevar.Columns["kproceedstransmission"]};
	Relations.Add(new DataRelation("proceedstransmission_incomevar",cPar,cChild,false));

	#endregion

}
}
}
