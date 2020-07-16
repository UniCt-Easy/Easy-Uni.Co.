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
namespace mandatedetail_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Dettaglio contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatedetail 		=> Tables["mandatedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytreeview 		=> Tables["inventorytreeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense_iva 		=> Tables["expense_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense_imponibile 		=> Tables["expense_imponibile"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetail 		=> Tables["invoicedetail"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivakind 		=> Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrymainview 		=> Tables["registrymainview"];

	///<summary>
	///Tipo contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatekind 		=> Tables["mandatekind"];

	///<summary>
	///Contratto Passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandate 		=> Tables["mandate"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive 		=> Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveannulment 		=> Tables["accmotiveannulment"];

	///<summary>
	///Unità di Misura per il carico/scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unit 		=> Tables["unit"];

	///<summary>
	/// Unità di Misura per l'acquisto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable package 		=> Tables["package"];

	///<summary>
	///Classificazione Merceologica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listclass 		=> Tables["listclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listview 		=> Tables["listview"];

	///<summary>
	///Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable store 		=> Tables["store"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stockview 		=> Tables["stockview"];

	///<summary>
	///Ripartizione dei costi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable costpartition 		=> Tables["costpartition"];

	///<summary>
	///trattasi di valori codificati dalla PCC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccdebitmotive 		=> Tables["pccdebitmotive"];

	///<summary>
	///trattasi di valori codificati dalla PCC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccdebitstatus 		=> Tables["pccdebitstatus"];

	///<summary>
	///Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexp 		=> Tables["epexp"];

	///<summary>
	///Accertamento di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epacc 		=> Tables["epacc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable locationview 		=> Tables["locationview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_iva 		=> Tables["upb_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_siope 		=> Tables["sorting_siope"];

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
	//////////////////// MANDATEDETAIL /////////////////////////////////
	var tmandatedetail= new DataTable("mandatedetail");
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tmandatedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	tmandatedetail.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("idinv", typeof(int)));
	C= new DataColumn("assetkind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("toinvoice", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("flagmixed", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idreg", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idaccmotiveannulment", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tmandatedetail.Columns.Add( new DataColumn("va3type", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("ivanotes", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idunit", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("flagto_unload", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("epkind", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("rownum_origin", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idpccdebitmotive", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("expensekind", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idepacc", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idlocation", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tmandatedetail);
	tmandatedetail.PrimaryKey =  new DataColumn[]{tmandatedetail.Columns["idmankind"], tmandatedetail.Columns["yman"], tmandatedetail.Columns["nman"], tmandatedetail.Columns["rownum"]};


	//////////////////// INVENTORYTREEVIEW /////////////////////////////////
	var tinventorytreeview= new DataTable("inventorytreeview");
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	tinventorytreeview.Columns.Add( new DataColumn("paridinv", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	Tables.Add(tinventorytreeview);

	//////////////////// EXPENSE_IVA /////////////////////////////////
	var texpense_iva= new DataTable("expense_iva");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	texpense_iva.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense_iva.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpense_iva.Columns.Add( new DataColumn("idman", typeof(int)));
	texpense_iva.Columns.Add( new DataColumn("doc", typeof(string)));
	texpense_iva.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	texpense_iva.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpense_iva.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense_iva.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	texpense_iva.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_iva.Columns.Add(C);
	texpense_iva.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpense_iva.Columns.Add( new DataColumn("autocode", typeof(int)));
	Tables.Add(texpense_iva);
	texpense_iva.PrimaryKey =  new DataColumn[]{texpense_iva.Columns["idexp"]};


	//////////////////// EXPENSE_IMPONIBILE /////////////////////////////////
	var texpense_imponibile= new DataTable("expense_imponibile");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense_imponibile.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense_imponibile.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense_imponibile.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpense_imponibile.Columns.Add(C);
	texpense_imponibile.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense_imponibile.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpense_imponibile.Columns.Add( new DataColumn("idman", typeof(int)));
	texpense_imponibile.Columns.Add( new DataColumn("doc", typeof(string)));
	texpense_imponibile.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpense_imponibile.Columns.Add(C);
	texpense_imponibile.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpense_imponibile.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense_imponibile.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_imponibile.Columns.Add(C);
	texpense_imponibile.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpense_imponibile.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_imponibile.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpense_imponibile.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpense_imponibile.Columns.Add(C);
	texpense_imponibile.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpense_imponibile.Columns.Add( new DataColumn("autocode", typeof(int)));
	Tables.Add(texpense_imponibile);
	texpense_imponibile.PrimaryKey =  new DataColumn[]{texpense_imponibile.Columns["idexp"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new DataTable("sorting1");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting1);
	tsorting1.PrimaryKey =  new DataColumn[]{tsorting1.Columns["idsor"]};


	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new DataTable("sorting2");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting2);
	tsorting2.PrimaryKey =  new DataColumn[]{tsorting2.Columns["idsor"]};


	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new DataTable("sorting3");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting3);
	tsorting3.PrimaryKey =  new DataColumn[]{tsorting3.Columns["idsor"]};


	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new DataTable("invoicedetail");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("!tipodocumento", typeof(string)));
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	tinvoicedetail.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("yman", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("nman", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.PrimaryKey =  new DataColumn[]{tinvoicedetail.Columns["idinvkind"], tinvoicedetail.Columns["yinv"], tinvoicedetail.Columns["ninv"], tinvoicedetail.Columns["rownum"]};


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


	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new DataTable("ivakind");
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("active", typeof(string)));
	tivakind.Columns.Add( new DataColumn("codeivakind", typeof(string)));
	Tables.Add(tivakind);
	tivakind.PrimaryKey =  new DataColumn[]{tivakind.Columns["idivakind"]};


	//////////////////// REGISTRYMAINVIEW /////////////////////////////////
	var tregistrymainview= new DataTable("registrymainview");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registryclass", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("residencekind", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistrymainview.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("city", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("qualification", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("maritalstatus", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("sortcode", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registrykind", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("human", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("location", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("nation", typeof(string)));
	Tables.Add(tregistrymainview);
	tregistrymainview.PrimaryKey =  new DataColumn[]{tregistrymainview.Columns["idreg"]};


	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new DataTable("mandatekind");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tmandatekind.Columns.Add( new DataColumn("txt", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("email", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("office", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("linktoasset", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("multireg", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("deltaamount", typeof(decimal)));
	tmandatekind.Columns.Add( new DataColumn("deltapercentage", typeof(decimal)));
	tmandatekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("assetkind", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("flag", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idivakind_forced", typeof(int)));
	Tables.Add(tmandatekind);
	tmandatekind.PrimaryKey =  new DataColumn[]{tmandatekind.Columns["idmankind"]};


	//////////////////// MANDATE /////////////////////////////////
	var tmandate= new DataTable("mandate");
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("idreg", typeof(int)));
	tmandate.Columns.Add( new DataColumn("registryreference", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("idman", typeof(int)));
	tmandate.Columns.Add( new DataColumn("deliveryexpiration", typeof(string)));
	tmandate.Columns.Add( new DataColumn("deliveryaddress", typeof(string)));
	tmandate.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tmandate.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tmandate.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tmandate.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tmandate.Columns.Add( new DataColumn("doc", typeof(string)));
	tmandate.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("txt", typeof(string)));
	tmandate.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tmandate.Columns.Add( new DataColumn("applierannotations", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idmandatestatus", typeof(short)));
	tmandate.Columns.Add( new DataColumn("idstore", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmandate.Columns.Add( new DataColumn("flagtenderresult", typeof(string)));
	Tables.Add(tmandate);
	tmandate.PrimaryKey =  new DataColumn[]{tmandate.Columns["idmankind"], tmandate.Columns["yman"], tmandate.Columns["nman"]};


	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new DataTable("accmotive");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	Tables.Add(taccmotive);
	taccmotive.PrimaryKey =  new DataColumn[]{taccmotive.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVEANNULMENT /////////////////////////////////
	var taccmotiveannulment= new DataTable("accmotiveannulment");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveannulment.Columns.Add(C);
	taccmotiveannulment.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveannulment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveannulment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveannulment.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveannulment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveannulment.Columns.Add(C);
	taccmotiveannulment.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotiveannulment.Columns.Add(C);
	Tables.Add(taccmotiveannulment);
	taccmotiveannulment.PrimaryKey =  new DataColumn[]{taccmotiveannulment.Columns["idaccmotive"]};


	//////////////////// UNIT /////////////////////////////////
	var tunit= new DataTable("unit");
	C= new DataColumn("idunit", typeof(int));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	Tables.Add(tunit);
	tunit.PrimaryKey =  new DataColumn[]{tunit.Columns["idunit"]};


	//////////////////// PACKAGE /////////////////////////////////
	var tpackage= new DataTable("package");
	C= new DataColumn("idpackage", typeof(int));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	tpackage.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	Tables.Add(tpackage);
	tpackage.PrimaryKey =  new DataColumn[]{tpackage.Columns["idpackage"]};


	//////////////////// LISTCLASS /////////////////////////////////
	var tlistclass= new DataTable("listclass");
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("codelistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("paridlistclass", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tlistclass.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("flagvisiblekind", typeof(byte)));
	Tables.Add(tlistclass);
	tlistclass.PrimaryKey =  new DataColumn[]{tlistclass.Columns["idlistclass"]};


	//////////////////// LISTVIEW /////////////////////////////////
	var tlistview= new DataTable("listview");
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	C= new DataColumn("intcode", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	tlistview.Columns.Add( new DataColumn("intbarcode", typeof(string)));
	tlistview.Columns.Add( new DataColumn("extcode", typeof(string)));
	tlistview.Columns.Add( new DataColumn("extbarcode", typeof(string)));
	tlistview.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	tlistview.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tlistview.Columns.Add( new DataColumn("idunit", typeof(int)));
	tlistview.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	C= new DataColumn("has_expiry", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	C= new DataColumn("codelistclass", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	C= new DataColumn("listclass", typeof(string));
	C.AllowDBNull=false;
	tlistview.Columns.Add(C);
	tlistview.Columns.Add( new DataColumn("package", typeof(string)));
	tlistview.Columns.Add( new DataColumn("unit", typeof(string)));
	tlistview.Columns.Add( new DataColumn("price", typeof(decimal)));
	Tables.Add(tlistview);
	tlistview.PrimaryKey =  new DataColumn[]{tlistview.Columns["idlist"]};


	//////////////////// STORE /////////////////////////////////
	var tstore= new DataTable("store");
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("deliveryaddress", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	tstore.Columns.Add( new DataColumn("active", typeof(string)));
	tstore.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tstore.Columns.Add( new DataColumn("cu", typeof(string)));
	tstore.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tstore.Columns.Add( new DataColumn("lu", typeof(string)));
	tstore.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tstore);
	tstore.PrimaryKey =  new DataColumn[]{tstore.Columns["idstore"]};


	//////////////////// STOCKVIEW /////////////////////////////////
	var tstockview= new DataTable("stockview");
	C= new DataColumn("idstock", typeof(int));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("store", typeof(string));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("number", typeof(decimal));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("residual", typeof(decimal));
	C.ReadOnly=true;
	tstockview.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	tstockview.Columns.Add( new DataColumn("expiry", typeof(DateTime)));
	tstockview.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tstockview.Columns.Add( new DataColumn("mandatekind", typeof(string)));
	tstockview.Columns.Add( new DataColumn("yman", typeof(short)));
	tstockview.Columns.Add( new DataColumn("nman", typeof(int)));
	tstockview.Columns.Add( new DataColumn("man_idgroup", typeof(int)));
	tstockview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tstockview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	tstockview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tstockview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tstockview.Columns.Add( new DataColumn("inv_idgroup", typeof(int)));
	tstockview.Columns.Add( new DataColumn("idddt_in", typeof(int)));
	tstockview.Columns.Add( new DataColumn("idstoreload_motive", typeof(int)));
	tstockview.Columns.Add( new DataColumn("storeload_motive", typeof(string)));
	C= new DataColumn("list", typeof(string));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	C= new DataColumn("intcode", typeof(string));
	C.AllowDBNull=false;
	tstockview.Columns.Add(C);
	tstockview.Columns.Add( new DataColumn("unit", typeof(string)));
	tstockview.Columns.Add( new DataColumn("yddt_in", typeof(short)));
	tstockview.Columns.Add( new DataColumn("nddt_in", typeof(string)));
	tstockview.Columns.Add( new DataColumn("codelistclass", typeof(string)));
	tstockview.Columns.Add( new DataColumn("listclass", typeof(string)));
	tstockview.Columns.Add( new DataColumn("authrequired", typeof(string)));
	tstockview.Columns.Add( new DataColumn("flagto_unload", typeof(string)));
	tstockview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tstockview.Columns.Add( new DataColumn("idstocklocation", typeof(int)));
	tstockview.Columns.Add( new DataColumn("stocklocationcode", typeof(string)));
	tstockview.Columns.Add( new DataColumn("stocklocation", typeof(string)));
	Tables.Add(tstockview);
	tstockview.PrimaryKey =  new DataColumn[]{tstockview.Columns["idstock"]};


	//////////////////// COSTPARTITION /////////////////////////////////
	var tcostpartition= new DataTable("costpartition");
	C= new DataColumn("idcostpartition", typeof(int));
	C.AllowDBNull=false;
	tcostpartition.Columns.Add(C);
	tcostpartition.Columns.Add( new DataColumn("title", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("kind", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("lu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("cu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("costpartitioncode", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("active", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("description", typeof(string)));
	Tables.Add(tcostpartition);
	tcostpartition.PrimaryKey =  new DataColumn[]{tcostpartition.Columns["idcostpartition"]};


	//////////////////// PCCDEBITMOTIVE /////////////////////////////////
	var tpccdebitmotive= new DataTable("pccdebitmotive");
	C= new DataColumn("idpccdebitmotive", typeof(string));
	C.AllowDBNull=false;
	tpccdebitmotive.Columns.Add(C);
	tpccdebitmotive.Columns.Add( new DataColumn("description", typeof(string)));
	tpccdebitmotive.Columns.Add( new DataColumn("listingorder", typeof(int)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccdebitmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdebitmotive.Columns.Add(C);
	tpccdebitmotive.Columns.Add( new DataColumn("flagstatus", typeof(int)));
	Tables.Add(tpccdebitmotive);
	tpccdebitmotive.PrimaryKey =  new DataColumn[]{tpccdebitmotive.Columns["idpccdebitmotive"]};


	//////////////////// PCCDEBITSTATUS /////////////////////////////////
	var tpccdebitstatus= new DataTable("pccdebitstatus");
	C= new DataColumn("idpccdebitstatus", typeof(string));
	C.AllowDBNull=false;
	tpccdebitstatus.Columns.Add(C);
	tpccdebitstatus.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdebitstatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccdebitstatus.Columns.Add(C);
	tpccdebitstatus.Columns.Add( new DataColumn("listingorder", typeof(int)));
	tpccdebitstatus.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tpccdebitstatus);
	tpccdebitstatus.PrimaryKey =  new DataColumn[]{tpccdebitstatus.Columns["idpccdebitstatus"]};


	//////////////////// EPEXP /////////////////////////////////
	var tepexp= new DataTable("epexp");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	tepexp.Columns.Add( new DataColumn("doc", typeof(string)));
	tepexp.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("idman", typeof(int)));
	tepexp.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepexp.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(int));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	tepexp.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tepexp.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tepexp.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yepexp", typeof(short));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	Tables.Add(tepexp);
	tepexp.PrimaryKey =  new DataColumn[]{tepexp.Columns["idepexp"]};


	//////////////////// EPACC /////////////////////////////////
	var tepacc= new DataTable("epacc");
	C= new DataColumn("idepacc", typeof(int));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("doc", typeof(string)));
	tepacc.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("idman", typeof(int)));
	tepacc.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepacc.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("nepacc", typeof(int));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("paridepacc", typeof(int)));
	tepacc.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tepacc.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yepacc", typeof(short));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("flagvariation", typeof(string)));
	Tables.Add(tepacc);
	tepacc.PrimaryKey =  new DataColumn[]{tepacc.Columns["idepacc"]};


	//////////////////// LOCATIONVIEW /////////////////////////////////
	var tlocationview= new DataTable("locationview");
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("locationcode", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	tlocationview.Columns.Add( new DataColumn("paridlocation", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	tlocationview.Columns.Add( new DataColumn("idman", typeof(int)));
	tlocationview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlocationview.Columns.Add(C);
	tlocationview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tlocationview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tlocationview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tlocationview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tlocationview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tlocationview);
	tlocationview.PrimaryKey =  new DataColumn[]{tlocationview.Columns["idlocation"]};


	//////////////////// UPB_IVA /////////////////////////////////
	var tupb_iva= new DataTable("upb_iva");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	tupb_iva.Columns.Add( new DataColumn("active", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	tupb_iva.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb_iva.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	tupb_iva.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb_iva.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	tupb_iva.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb_iva.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb_iva.Columns.Add(C);
	tupb_iva.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb_iva.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb_iva.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb_iva.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb_iva.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb_iva.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	tupb_iva.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tupb_iva);
	tupb_iva.PrimaryKey =  new DataColumn[]{tupb_iva.Columns["idupb"]};


	//////////////////// SORTING_SIOPE /////////////////////////////////
	var tsorting_siope= new DataTable("sorting_siope");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_siope.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting_siope.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting_siope);
	tsorting_siope.PrimaryKey =  new DataColumn[]{tsorting_siope.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{upb_iva.Columns["idupb"]};
	var cChild = new []{mandatedetail.Columns["idupb_iva"]};
	Relations.Add(new DataRelation("FK_upb_iva_mandatedetail",cPar,cChild,false));

	cPar = new []{mandatedetail.Columns["idmankind"], mandatedetail.Columns["yman"], mandatedetail.Columns["nman"], mandatedetail.Columns["idgroup"]};
	cChild = new []{stockview.Columns["idmankind"], stockview.Columns["yman"], stockview.Columns["nman"], stockview.Columns["man_idgroup"]};
	Relations.Add(new DataRelation("mandatedetail_stockview",cPar,cChild,false));

	cPar = new []{store.Columns["idstore"]};
	cChild = new []{mandate.Columns["idstore"]};
	Relations.Add(new DataRelation("store_mandate",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoicedetail.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekindinvoicedetail",cPar,cChild,false));

	cPar = new []{mandatedetail.Columns["idmankind"], mandatedetail.Columns["yman"], mandatedetail.Columns["nman"], mandatedetail.Columns["rownum"]};
	cChild = new []{invoicedetail.Columns["idmankind"], invoicedetail.Columns["yman"], invoicedetail.Columns["nman"], invoicedetail.Columns["manrownum"]};
	Relations.Add(new DataRelation("mandatedetailinvoicedetail",cPar,cChild,false));

	cPar = new []{epacc.Columns["idepacc"]};
	cChild = new []{mandatedetail.Columns["idepacc"]};
	Relations.Add(new DataRelation("epacc_mandatedetail",cPar,cChild,false));

	cPar = new []{costpartition.Columns["idcostpartition"]};
	cChild = new []{mandatedetail.Columns["idcostpartition"]};
	Relations.Add(new DataRelation("costpartition_mandatedetail",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{mandatedetail.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveappliedmandatedetail",cPar,cChild,false));

	cPar = new []{mandate.Columns["idmankind"], mandate.Columns["yman"], mandate.Columns["nman"]};
	cChild = new []{mandatedetail.Columns["idmankind"], mandatedetail.Columns["yman"], mandatedetail.Columns["nman"]};
	Relations.Add(new DataRelation("mandate_mandatedetail",cPar,cChild,false));

	cPar = new []{registrymainview.Columns["idreg"]};
	cChild = new []{mandatedetail.Columns["idreg"]};
	Relations.Add(new DataRelation("registrymainviewmandatedetail",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{mandatedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("ivakindmandatedetail",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{mandatedetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upbmandatedetail",cPar,cChild,false));

	cPar = new []{expense_imponibile.Columns["idexp"]};
	cChild = new []{mandatedetail.Columns["idexp_taxable"]};
	Relations.Add(new DataRelation("expense_imponibilemandatedetail",cPar,cChild,false));

	cPar = new []{expense_iva.Columns["idexp"]};
	cChild = new []{mandatedetail.Columns["idexp_iva"]};
	Relations.Add(new DataRelation("expense_ivamandatedetail",cPar,cChild,false));

	cPar = new []{inventorytreeview.Columns["idinv"]};
	cChild = new []{mandatedetail.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytreeviewmandatedetail",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{mandatedetail.Columns["idsor1"]};
	Relations.Add(new DataRelation("sortingmandatedetail",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{mandatedetail.Columns["idsor2"]};
	Relations.Add(new DataRelation("sortingmandatedetail1",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{mandatedetail.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3mandatedetail",cPar,cChild,false));

	cPar = new []{accmotiveannulment.Columns["idaccmotive"]};
	cChild = new []{mandatedetail.Columns["idaccmotiveannulment"]};
	Relations.Add(new DataRelation("accmotiveannulment_mandatedetail",cPar,cChild,false));

	cPar = new []{listview.Columns["idlist"]};
	cChild = new []{mandatedetail.Columns["idlist"]};
	Relations.Add(new DataRelation("listview_mandatedetail",cPar,cChild,false));

	cPar = new []{unit.Columns["idunit"]};
	cChild = new []{mandatedetail.Columns["idunit"]};
	Relations.Add(new DataRelation("unit_mandatedetail",cPar,cChild,false));

	cPar = new []{package.Columns["idpackage"]};
	cChild = new []{mandatedetail.Columns["idpackage"]};
	Relations.Add(new DataRelation("package_mandatedetail",cPar,cChild,false));

	cPar = new []{pccdebitmotive.Columns["idpccdebitmotive"]};
	cChild = new []{mandatedetail.Columns["idpccdebitmotive"]};
	Relations.Add(new DataRelation("FK_pccdebitmotive_mandatedetail",cPar,cChild,false));

	cPar = new []{pccdebitstatus.Columns["idpccdebitstatus"]};
	cChild = new []{mandatedetail.Columns["idpccdebitstatus"]};
	Relations.Add(new DataRelation("FK_pccdebitstatus_mandatedetail",cPar,cChild,false));

	cPar = new []{epexp.Columns["idepexp"]};
	cChild = new []{mandatedetail.Columns["idepexp"]};
	Relations.Add(new DataRelation("FK_epexp_mandatedetail",cPar,cChild,false));

	cPar = new []{locationview.Columns["idlocation"]};
	cChild = new []{mandatedetail.Columns["idlocation"]};
	Relations.Add(new DataRelation("locationview_mandatedetail",cPar,cChild,false));

	cPar = new []{sorting_siope.Columns["idsor"]};
	cChild = new []{mandatedetail.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siope_mandatedetail",cPar,cChild,false));

	#endregion

}
}
}
