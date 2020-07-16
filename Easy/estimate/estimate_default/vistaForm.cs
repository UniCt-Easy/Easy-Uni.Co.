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
namespace estimate_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimate 		=> Tables["estimate"];

	///<summary>
	///Dettaglio contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatedetail 		=> Tables["estimatedetail"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatekind 		=> Tables["estimatekind"];

	///<summary>
	///Valuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable currency 		=> Tables["currency"];

	///<summary>
	/// Tipo Scadenza
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expirationkind 		=> Tables["expirationkind"];

	///<summary>
	///Classificazione Contratto Attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatesorting 		=> Tables["estimatesorting"];

	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetail 		=> Tables["invoicedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrymainview 		=> Tables["registrymainview"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Variazione movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomevar 		=> Tables["incomevar"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_detail 		=> Tables["upb_detail"];

	///<summary>
	///Classificazione Movimenti di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomesorted 		=> Tables["incomesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_credit 		=> Tables["accmotiveapplied_credit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_crg 		=> Tables["accmotiveapplied_crg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting01 		=> Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting02 		=> Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting03 		=> Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting04 		=> Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting05 		=> Tables["sorting05"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivakind 		=> Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatedetailview 		=> Tables["estimatedetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatesortingview 		=> Tables["estimatesortingview"];

	///<summary>
	///allegato contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimateattachment 		=> Tables["estimateattachment"];

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
	//////////////////// ESTIMATE /////////////////////////////////
	var testimate= new DataTable("estimate");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("deliveryaddress", typeof(string)));
	testimate.Columns.Add( new DataColumn("deliveryexpiration", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("doc", typeof(string)));
	testimate.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	testimate.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	testimate.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	testimate.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	testimate.Columns.Add( new DataColumn("idman", typeof(int)));
	testimate.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	testimate.Columns.Add( new DataColumn("registryreference", typeof(string)));
	testimate.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	testimate.Columns.Add( new DataColumn("txt", typeof(string)));
	testimate.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	testimate.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	testimate.Columns.Add( new DataColumn("idaccmotivecredit_crg", typeof(string)));
	testimate.Columns.Add( new DataColumn("idaccmotivecredit_datacrg", typeof(DateTime)));
	testimate.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor01", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor02", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor03", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor04", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor05", typeof(int)));
	testimate.Columns.Add( new DataColumn("external_reference", typeof(string)));
	testimate.Columns.Add( new DataColumn("cigcode", typeof(string)));
	Tables.Add(testimate);
	testimate.PrimaryKey =  new DataColumn[]{testimate.Columns["idestimkind"], testimate.Columns["nestim"], testimate.Columns["yestim"]};


	//////////////////// ESTIMATEDETAIL /////////////////////////////////
	var testimatedetail= new DataTable("estimatedetail");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	testimatedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	testimatedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	testimatedetail.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	testimatedetail.Columns.Add( new DataColumn("ninvoiced", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("start", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("taxrate", typeof(double)));
	testimatedetail.Columns.Add( new DataColumn("toinvoice", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("!totaleriga", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("idreg", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("idaccmotiveannulment", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("!registry", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("!tipoiva", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("!imponibile", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("!iva", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("epkind", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idrevenuepartition", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idepacc", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("cigcode", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("iduniqueformcode", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("nform", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("flag", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("proceedsexpiring", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idepacc_pre", typeof(int)));
	Tables.Add(testimatedetail);
	testimatedetail.PrimaryKey =  new DataColumn[]{testimatedetail.Columns["idestimkind"], testimatedetail.Columns["nestim"], testimatedetail.Columns["rownum"], testimatedetail.Columns["yestim"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
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
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new DataTable("estimatekind");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	testimatekind.Columns.Add( new DataColumn("txt", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("email", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("office", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("multireg", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idivakind_forced", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(testimatekind);
	testimatekind.PrimaryKey =  new DataColumn[]{testimatekind.Columns["idestimkind"]};


	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new DataTable("currency");
	C= new DataColumn("idcurrency", typeof(int));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	tcurrency.Columns.Add( new DataColumn("codecurrency", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	Tables.Add(tcurrency);
	tcurrency.PrimaryKey =  new DataColumn[]{tcurrency.Columns["idcurrency"]};


	//////////////////// EXPIRATIONKIND /////////////////////////////////
	var texpirationkind= new DataTable("expirationkind");
	C= new DataColumn("idexpirationkind", typeof(short));
	C.AllowDBNull=false;
	texpirationkind.Columns.Add(C);
	texpirationkind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpirationkind.Columns.Add(C);
	texpirationkind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	texpirationkind.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(texpirationkind);
	texpirationkind.PrimaryKey =  new DataColumn[]{texpirationkind.Columns["idexpirationkind"]};


	//////////////////// ESTIMATESORTING /////////////////////////////////
	var testimatesorting= new DataTable("estimatesorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	testimatesorting.Columns.Add(C);
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimatesorting.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimatesorting.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimatesorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimatesorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimatesorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimatesorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimatesorting.Columns.Add(C);
	testimatesorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	testimatesorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	testimatesorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	testimatesorting.Columns.Add( new DataColumn("quota", typeof(double)));
	Tables.Add(testimatesorting);
	testimatesorting.PrimaryKey =  new DataColumn[]{testimatesorting.Columns["idestimkind"], testimatesorting.Columns["idsor"], testimatesorting.Columns["nestim"], testimatesorting.Columns["yestim"]};


	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new DataTable("invoicedetail");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	tinvoicedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("nman", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("yman", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("estimrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("nestim", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("yestim", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.PrimaryKey =  new DataColumn[]{tinvoicedetail.Columns["idinvkind"], tinvoicedetail.Columns["ninv"], tinvoicedetail.Columns["rownum"], tinvoicedetail.Columns["yinv"]};


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
	tregistrymainview.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	Tables.Add(tregistrymainview);
	tregistrymainview.PrimaryKey =  new DataColumn[]{tregistrymainview.Columns["idreg"]};


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
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// INCOMEVAR /////////////////////////////////
	var tincomevar= new DataTable("incomevar");
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomevar.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tincomevar.Columns.Add( new DataColumn("transferkind", typeof(string)));
	tincomevar.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("ninv", typeof(int)));
	tincomevar.Columns.Add( new DataColumn("yinv", typeof(short)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomevar.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tincomevar.Columns.Add( new DataColumn("movkind", typeof(short)));
	Tables.Add(tincomevar);
	tincomevar.PrimaryKey =  new DataColumn[]{tincomevar.Columns["nvar"], tincomevar.Columns["idinc"]};


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


	//////////////////// UPB_DETAIL /////////////////////////////////
	var tupb_detail= new DataTable("upb_detail");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_detail.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_detail.Columns.Add(C);
	Tables.Add(tupb_detail);
	tupb_detail.PrimaryKey =  new DataColumn[]{tupb_detail.Columns["idupb"]};


	//////////////////// INCOMESORTED /////////////////////////////////
	var tincomesorted= new DataTable("incomesorted");
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
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	Tables.Add(tincomesorted);
	tincomesorted.PrimaryKey =  new DataColumn[]{tincomesorted.Columns["idsubclass"], tincomesorted.Columns["idinc"], tincomesorted.Columns["idsor"]};


	//////////////////// ACCMOTIVEAPPLIED_CREDIT /////////////////////////////////
	var taccmotiveapplied_credit= new DataTable("accmotiveapplied_credit");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	taccmotiveapplied_credit.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	taccmotiveapplied_credit.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_credit.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_credit.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	taccmotiveapplied_credit.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied_credit.Columns.Add( new DataColumn("flagamm", typeof(string)));
	Tables.Add(taccmotiveapplied_credit);
	taccmotiveapplied_credit.PrimaryKey =  new DataColumn[]{taccmotiveapplied_credit.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVEAPPLIED_CRG /////////////////////////////////
	var taccmotiveapplied_crg= new DataTable("accmotiveapplied_crg");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	taccmotiveapplied_crg.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	taccmotiveapplied_crg.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_crg.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_crg.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	taccmotiveapplied_crg.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied_crg.Columns.Add( new DataColumn("flagamm", typeof(string)));
	Tables.Add(taccmotiveapplied_crg);
	taccmotiveapplied_crg.PrimaryKey =  new DataColumn[]{taccmotiveapplied_crg.Columns["idaccmotive"]};


	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new DataTable("sortingview");
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	Tables.Add(tsortingview);
	tsortingview.PrimaryKey =  new DataColumn[]{tsortingview.Columns["idsor"]};


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
	Tables.Add(tsorting04);
	tsorting04.PrimaryKey =  new DataColumn[]{tsorting04.Columns["idsor"]};


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
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new DataTable("ivakind");
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	Tables.Add(tivakind);
	tivakind.PrimaryKey =  new DataColumn[]{tivakind.Columns["idivakind"]};


	//////////////////// ESTIMATEDETAILVIEW /////////////////////////////////
	var testimatedetailview= new DataTable("estimatedetailview");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	testimatedetailview.Columns.Add(C);
	testimatedetailview.Columns.Add( new DataColumn("idgroup", typeof(int)));
	C= new DataColumn("estimkind", typeof(string));
	C.AllowDBNull=false;
	testimatedetailview.Columns.Add(C);
	testimatedetailview.Columns.Add( new DataColumn("idreg", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("registry", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("annotations", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("number", typeof(decimal)));
	testimatedetailview.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	testimatedetailview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	testimatedetailview.Columns.Add( new DataColumn("tax", typeof(decimal)));
	testimatedetailview.Columns.Add( new DataColumn("discount", typeof(double)));
	testimatedetailview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	testimatedetailview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	testimatedetailview.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	testimatedetailview.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	testimatedetailview.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	C= new DataColumn("taxable_euro", typeof(decimal));
	C.ReadOnly=true;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("iva_euro", typeof(decimal));
	C.ReadOnly=true;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("rowtotal", typeof(decimal));
	C.ReadOnly=true;
	testimatedetailview.Columns.Add(C);
	testimatedetailview.Columns.Add( new DataColumn("idupb", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimatedetailview.Columns.Add(C);
	testimatedetailview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("codemotive", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("idaccmotiveannulment", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("codemotiveannulment", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("sortcode1", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("sortcode2", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("sortcode3", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("idivakind", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("ivakind", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("toinvoice", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	testimatedetailview.Columns.Add(C);
	testimatedetailview.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("ninvoiced", typeof(decimal)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	testimatedetailview.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	testimatedetailview.Columns.Add(C);
	testimatedetailview.Columns.Add( new DataColumn("epkind", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("idrevenuepartition", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("idepacc", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("idlist", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("intcode", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("list", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("cigcode", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("iduniqueformcode", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("nform", typeof(string)));
	testimatedetailview.Columns.Add( new DataColumn("flag", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("proceedsexpiring", typeof(DateTime)));
	testimatedetailview.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	testimatedetailview.Columns.Add( new DataColumn("idepacc_pre", typeof(int)));
	Tables.Add(testimatedetailview);
	testimatedetailview.PrimaryKey =  new DataColumn[]{testimatedetailview.Columns["idestimkind"], testimatedetailview.Columns["yestim"], testimatedetailview.Columns["nestim"], testimatedetailview.Columns["rownum"]};


	//////////////////// ESTIMATESORTINGVIEW /////////////////////////////////
	var testimatesortingview= new DataTable("estimatesortingview");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	C= new DataColumn("mankind", typeof(string));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	testimatesortingview.Columns.Add( new DataColumn("quota", typeof(double)));
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	C= new DataColumn("sorting", typeof(string));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimatesortingview.Columns.Add(C);
	Tables.Add(testimatesortingview);
	testimatesortingview.PrimaryKey =  new DataColumn[]{testimatesortingview.Columns["idestimkind"], testimatesortingview.Columns["yestim"], testimatesortingview.Columns["nestim"], testimatesortingview.Columns["idsor"]};


	//////////////////// ESTIMATEATTACHMENT /////////////////////////////////
	var testimateattachment= new DataTable("estimateattachment");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimateattachment.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimateattachment.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimateattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	testimateattachment.Columns.Add(C);
	testimateattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	testimateattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	testimateattachment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	testimateattachment.Columns.Add( new DataColumn("lu", typeof(string)));
	testimateattachment.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	testimateattachment.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(testimateattachment);
	testimateattachment.PrimaryKey =  new DataColumn[]{testimateattachment.Columns["idestimkind"], testimateattachment.Columns["yestim"], testimateattachment.Columns["nestim"], testimateattachment.Columns["idattachment"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{estimate.Columns["idestimkind"], estimate.Columns["nestim"], estimate.Columns["yestim"]};
	var cChild = new []{invoicedetail.Columns["idestimkind"], invoicedetail.Columns["nestim"], invoicedetail.Columns["yestim"]};
	Relations.Add(new DataRelation("estimateinvoicedetail",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{estimatesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sortingview_estimatesorting",cPar,cChild,false));

	cPar = new []{estimate.Columns["idestimkind"], estimate.Columns["nestim"], estimate.Columns["yestim"]};
	cChild = new []{estimatesorting.Columns["idestimkind"], estimatesorting.Columns["nestim"], estimatesorting.Columns["yestim"]};
	Relations.Add(new DataRelation("estimateestimatesorting",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{estimatedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("FK_ivakind_estimatedetail",cPar,cChild,false));

	cPar = new []{estimate.Columns["idestimkind"], estimate.Columns["nestim"], estimate.Columns["yestim"]};
	cChild = new []{estimatedetail.Columns["idestimkind"], estimatedetail.Columns["nestim"], estimatedetail.Columns["yestim"]};
	Relations.Add(new DataRelation("estimateestimatedetail",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{estimatedetail.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_estimatedetail",cPar,cChild,false));

	cPar = new []{upb_detail.Columns["idupb"]};
	cChild = new []{estimatedetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_detail_estimatedetail",cPar,cChild,false));

	cPar = new []{underwriting.Columns["idunderwriting"]};
	cChild = new []{estimate.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("FK_underwriting_estimate",cPar,cChild,false));

	cPar = new []{registrymainview.Columns["idreg"]};
	cChild = new []{estimate.Columns["idreg"]};
	Relations.Add(new DataRelation("registrymainviewestimate",cPar,cChild,false));

	cPar = new []{currency.Columns["idcurrency"]};
	cChild = new []{estimate.Columns["idcurrency"]};
	Relations.Add(new DataRelation("currencyestimate",cPar,cChild,false));

	cPar = new []{expirationkind.Columns["idexpirationkind"]};
	cChild = new []{estimate.Columns["idexpirationkind"]};
	Relations.Add(new DataRelation("expirationkindestimate",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{estimate.Columns["idman"]};
	Relations.Add(new DataRelation("managerestimate",cPar,cChild,false));

	cPar = new []{estimatekind.Columns["idestimkind"]};
	cChild = new []{estimate.Columns["idestimkind"]};
	Relations.Add(new DataRelation("estimatekindestimate",cPar,cChild,false));

	cPar = new []{accmotiveapplied_credit.Columns["idaccmotive"]};
	cChild = new []{estimate.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("accmotiveapplied_credit_estimate",cPar,cChild,false));

	cPar = new []{accmotiveapplied_crg.Columns["idaccmotive"]};
	cChild = new []{estimate.Columns["idaccmotivecredit_crg"]};
	Relations.Add(new DataRelation("accmotiveapplied_crg_estimate",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{estimate.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_estimate",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{estimate.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_estimate",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{estimate.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_estimate",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{estimate.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_estimate",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{estimate.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_estimate",cPar,cChild,false));

	cPar = new []{estimate.Columns["idestimkind"], estimate.Columns["nestim"], estimate.Columns["yestim"]};
	cChild = new []{estimateattachment.Columns["idestimkind"], estimateattachment.Columns["nestim"], estimateattachment.Columns["yestim"]};
	Relations.Add(new DataRelation("estimate_estimateattachment",cPar,cChild,false));

	#endregion

}
}
}
