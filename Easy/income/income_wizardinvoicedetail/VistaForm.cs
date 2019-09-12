/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace income_wizardinvoicedetail {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("VistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class VistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registry		{get { return Tables["registry"];}}
	///<summary>
	///Movimento di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable income		{get { return Tables["income"];}}
	///<summary>
	///Informazioni annuali su mov. di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomeyear		{get { return Tables["incomeyear"];}}
	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable fin		{get { return Tables["fin"];}}
	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomephase		{get { return Tables["incomephase"];}}
	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable upb		{get { return Tables["upb"];}}
	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable invoicedetail		{get { return Tables["invoicedetail"];}}
	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable ivakind		{get { return Tables["ivakind"];}}
	///<summary>
	///Contratto attivo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable estimate		{get { return Tables["estimate"];}}
	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable estimatekind		{get { return Tables["estimatekind"];}}
	///<summary>
	///Contabilizzazione contratto attivo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomeestimate		{get { return Tables["incomeestimate"];}}
	///<summary>
	///Dettaglio contratto attivo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable estimatedetail		{get { return Tables["estimatedetail"];}}
	///<summary>
	///Contabilizzazione contratto attivo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomeinvoice		{get { return Tables["incomeinvoice"];}}
	///<summary>
	///Fattura
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable invoice		{get { return Tables["invoice"];}}
	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable invoicekind		{get { return Tables["invoicekind"];}}
	///<summary>
	///Classificazione Movimenti di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomesorted		{get { return Tables["incomesorted"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable tipomovimento		{get { return Tables["tipomovimento"];}}
	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable config		{get { return Tables["config"];}}
	///<summary>
	///Movimento di entrata - Dettaglio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomelast		{get { return Tables["incomelast"];}}
	///<summary>
	///Partita pendente
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable bill		{get { return Tables["bill"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable billview		{get { return Tables["billview"];}}
	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable account		{get { return Tables["account"];}}
	///<summary>
	///dettagli di una fattura inseriti in liquidazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable invoicedetaildeferred		{get { return Tables["invoicedetaildeferred"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public VistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected VistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "VistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/VistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// REGISTRY /////////////////////////////////
	T= new DataTable("registry");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("badgecode", typeof(String)));
	T.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("extmatricula", typeof(String)));
	T.Columns.Add( new DataColumn("foreigncf", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("gender", typeof(String)));
	T.Columns.Add( new DataColumn("idcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idcentralizedcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idmaritalstatus", typeof(String)));
	T.Columns.Add( new DataColumn("idnation", typeof(Int32)));
	T.Columns.Add( new DataColumn("idregistryclass", typeof(String)));
	T.Columns.Add( new DataColumn("idtitle", typeof(String)));
	T.Columns.Add( new DataColumn("location", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("maritalsurname", typeof(String)));
	T.Columns.Add( new DataColumn("p_iva", typeof(String)));
	C= new DataColumn("residence", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"]};


	//////////////////// INCOME /////////////////////////////////
	T= new DataTable("income");
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nmov", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("ymov", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	C= new DataColumn("nphase", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpayment", typeof(Int32)));
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("parentidinc", typeof(Int32)));
	T.Columns.Add( new DataColumn("autokind", typeof(Byte)));
	T.Columns.Add( new DataColumn("autocode", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"]};


	//////////////////// INCOMEYEAR /////////////////////////////////
	T= new DataTable("incomeyear");
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(Int32)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"], T.Columns["ayear"]};


	//////////////////// FIN /////////////////////////////////
	T= new DataTable("fin");
	C= new DataColumn("idfin", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codefin", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("paridfin", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idfin"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	T= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nphase"]};


	//////////////////// UPB /////////////////////////////////
	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("assured", typeof(String)));
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	T.Columns.Add( new DataColumn("granted", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("idunderwriter", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridupb", typeof(String)));
	T.Columns.Add( new DataColumn("previousappropriation", typeof(Decimal)));
	T.Columns.Add( new DataColumn("previousassessment", typeof(Decimal)));
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("requested", typeof(Decimal)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idupb"]};


	//////////////////// INVOICEDETAIL /////////////////////////////////
	T= new DataTable("invoicedetail");
	T.Columns.Add( new DataColumn("!codeupb", typeof(String)));
	T.Columns.Add( new DataColumn("!disponibile", typeof(Decimal)));
	T.Columns.Add( new DataColumn("!idinctolink", typeof(String)));
	T.Columns.Add( new DataColumn("!monoestimate", typeof(String)));
	T.Columns.Add( new DataColumn("!tipoiva", typeof(String)));
	T.Columns.Add( new DataColumn("!totaleriga", typeof(Decimal)));
	T.Columns.Add( new DataColumn("!aliquota", typeof(Decimal)));
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ninv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("rownum", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yinv", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotations", typeof(String)));
	T.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	T.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("detaildescription", typeof(String)));
	T.Columns.Add( new DataColumn("discount", typeof(Double)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(String)));
	C= new DataColumn("idivakind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idmankind", typeof(String)));
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("manrownum", typeof(Int32)));
	T.Columns.Add( new DataColumn("nman", typeof(Int32)));
	T.Columns.Add( new DataColumn("number", typeof(Decimal)));
	T.Columns.Add( new DataColumn("tax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxable", typeof(Decimal)));
	T.Columns.Add( new DataColumn("unabatable", typeof(Decimal)));
	T.Columns.Add( new DataColumn("yman", typeof(Int16)));
	T.Columns.Add( new DataColumn("idestimkind", typeof(String)));
	T.Columns.Add( new DataColumn("estimrownum", typeof(Int32)));
	T.Columns.Add( new DataColumn("nestim", typeof(Int32)));
	T.Columns.Add( new DataColumn("yestim", typeof(Int16)));
	T.Columns.Add( new DataColumn("idexp_iva", typeof(Int32)));
	T.Columns.Add( new DataColumn("idexp_taxable", typeof(Int32)));
	T.Columns.Add( new DataColumn("idinc_iva", typeof(Int32)));
	T.Columns.Add( new DataColumn("idinc_taxable", typeof(Int32)));
	T.Columns.Add( new DataColumn("idgroup", typeof(Int32)));
	T.Columns.Add( new DataColumn("va3type", typeof(String)));
	T.Columns.Add( new DataColumn("idintrastatcode", typeof(Int32)));
	T.Columns.Add( new DataColumn("idintrastatmeasure", typeof(Int32)));
	T.Columns.Add( new DataColumn("weight", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idlist", typeof(Int32)));
	T.Columns.Add( new DataColumn("idpackage", typeof(Int32)));
	T.Columns.Add( new DataColumn("idunit", typeof(Int32)));
	T.Columns.Add( new DataColumn("npackage", typeof(Decimal)));
	T.Columns.Add( new DataColumn("unitsforpackage", typeof(Int32)));
	T.Columns.Add( new DataColumn("intra12operationkind", typeof(String)));
	T.Columns.Add( new DataColumn("intrastatoperationkind", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("move12", typeof(String)));
	T.Columns.Add( new DataColumn("exception12", typeof(String)));
	T.Columns.Add( new DataColumn("idupb_iva", typeof(String)));
	T.Columns.Add( new DataColumn("!codeupb_iva", typeof(String)));
	T.Columns.Add( new DataColumn("rounding", typeof(String)));
	T.Columns.Add( new DataColumn("idepexp", typeof(Int32)));
	T.Columns.Add( new DataColumn("idepacc", typeof(Int32)));
	T.Columns.Add( new DataColumn("cigcode", typeof(String)));
	T.Columns.Add( new DataColumn("iduniqueformcode", typeof(String)));
	T.Columns.Add( new DataColumn("idfinmotive", typeof(String)));
	T.Columns.Add( new DataColumn("idsor_siope", typeof(Int32)));
	T.Columns.Add( new DataColumn("idpccdebitstatus", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinvkind"], T.Columns["ninv"], T.Columns["rownum"], T.Columns["yinv"]};


	//////////////////// IVAKIND /////////////////////////////////
	T= new DataTable("ivakind");
	C= new DataColumn("idivakind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("rate", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idivakind"]};


	//////////////////// ESTIMATE /////////////////////////////////
	T= new DataTable("estimate");
	C= new DataColumn("idestimkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yestim", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nestim", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("deliveryaddress", typeof(String)));
	T.Columns.Add( new DataColumn("deliveryexpiration", typeof(String)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("exchangerate", typeof(Double)));
	T.Columns.Add( new DataColumn("idcurrency", typeof(Int32)));
	T.Columns.Add( new DataColumn("idexpirationkind", typeof(Int16)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paymentexpiring", typeof(Int16)));
	T.Columns.Add( new DataColumn("registryreference", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("cigcode", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idestimkind"], T.Columns["yestim"], T.Columns["nestim"]};


	//////////////////// ESTIMATEKIND /////////////////////////////////
	T= new DataTable("estimatekind");
	C= new DataColumn("idestimkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("email", typeof(String)));
	T.Columns.Add( new DataColumn("faxnumber", typeof(String)));
	T.Columns.Add( new DataColumn("office", typeof(String)));
	T.Columns.Add( new DataColumn("phonenumber", typeof(String)));
	T.Columns.Add( new DataColumn("linktoinvoice", typeof(String)));
	T.Columns.Add( new DataColumn("multireg", typeof(String)));
	T.Columns.Add( new DataColumn("deltaamount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("deltapercentage", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idestimkind"]};


	//////////////////// INCOMEESTIMATE /////////////////////////////////
	T= new DataTable("incomeestimate");
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idestimkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nestim", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yestim", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"], T.Columns["idestimkind"], T.Columns["nestim"], T.Columns["yestim"]};


	//////////////////// ESTIMATEDETAIL /////////////////////////////////
	T= new DataTable("estimatedetail");
	C= new DataColumn("idestimkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yestim", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nestim", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("rownum", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotations", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("detaildescription", typeof(String)));
	T.Columns.Add( new DataColumn("discount", typeof(Double)));
	T.Columns.Add( new DataColumn("idinc_iva", typeof(Int32)));
	T.Columns.Add( new DataColumn("idinc_taxable", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ninvoiced", typeof(Decimal)));
	T.Columns.Add( new DataColumn("number", typeof(Decimal)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("tax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxable", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxrate", typeof(Double)));
	T.Columns.Add( new DataColumn("toinvoice", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(String)));
	T.Columns.Add( new DataColumn("idivakind", typeof(Int32)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("idgroup", typeof(Int32)));
	T.Columns.Add( new DataColumn("!totale", typeof(Decimal)));
	T.Columns.Add( new DataColumn("!assegnato", typeof(Decimal)));
	T.Columns.Add( new DataColumn("epkind", typeof(String)));
	T.Columns.Add( new DataColumn("cigcode", typeof(String)));
	T.Columns.Add( new DataColumn("idsor_siope", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idestimkind"], T.Columns["yestim"], T.Columns["nestim"], T.Columns["rownum"]};


	//////////////////// INCOMEINVOICE /////////////////////////////////
	T= new DataTable("incomeinvoice");
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ninv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yinv", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"], T.Columns["idinvkind"], T.Columns["ninv"], T.Columns["yinv"]};


	//////////////////// INVOICE /////////////////////////////////
	T= new DataTable("invoice");
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ninv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yinv", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("exchangerate", typeof(Double)));
	T.Columns.Add( new DataColumn("flagdeferred", typeof(String)));
	T.Columns.Add( new DataColumn("idcurrency", typeof(Int32)));
	T.Columns.Add( new DataColumn("idexpirationkind", typeof(Int16)));
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("packinglistnum", typeof(String)));
	T.Columns.Add( new DataColumn("paymentexpiring", typeof(Int16)));
	T.Columns.Add( new DataColumn("registryreference", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("idblacklist", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinvkind"], T.Columns["yinv"], T.Columns["ninv"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	T= new DataTable("invoicekind");
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinvkind"]};


	//////////////////// INCOMESORTED /////////////////////////////////
	T= new DataTable("incomesorted");
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("ayear", typeof(Int16)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	T.Columns.Add( new DataColumn("paridsubclass", typeof(Int16)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("tobecontinued", typeof(String)));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("valuen1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuen2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuen3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuen4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuen5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("values1", typeof(String)));
	T.Columns.Add( new DataColumn("values2", typeof(String)));
	T.Columns.Add( new DataColumn("values3", typeof(String)));
	T.Columns.Add( new DataColumn("values4", typeof(String)));
	T.Columns.Add( new DataColumn("values5", typeof(String)));
	T.Columns.Add( new DataColumn("valuev1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuev2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuev3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuev4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuev5", typeof(Decimal)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"], T.Columns["idsor"], T.Columns["idsubclass"]};


	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	T= new DataTable("tipomovimento");
	C= new DataColumn("idtipo", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("descrizione", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idtipo"]};


	//////////////////// CONFIG /////////////////////////////////
	T= new DataTable("config");
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("agencycode", typeof(String)));
	T.Columns.Add( new DataColumn("appname", typeof(String)));
	T.Columns.Add( new DataColumn("appropriationphasecode", typeof(Byte)));
	T.Columns.Add( new DataColumn("assessmentphasecode", typeof(Byte)));
	T.Columns.Add( new DataColumn("asset_flagnumbering", typeof(String)));
	T.Columns.Add( new DataColumn("asset_flagrestart", typeof(String)));
	T.Columns.Add( new DataColumn("assetload_flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("boxpartitiontitle", typeof(String)));
	T.Columns.Add( new DataColumn("cashvaliditykind", typeof(Byte)));
	T.Columns.Add( new DataColumn("casualcontract_flagrestart", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("currpartitiontitle", typeof(String)));
	T.Columns.Add( new DataColumn("deferredexpensephase", typeof(String)));
	T.Columns.Add( new DataColumn("deferredincomephase", typeof(String)));
	T.Columns.Add( new DataColumn("electronicimport", typeof(String)));
	T.Columns.Add( new DataColumn("electronictrasmission", typeof(String)));
	T.Columns.Add( new DataColumn("expense_expiringdays", typeof(Int16)));
	T.Columns.Add( new DataColumn("expensephase", typeof(Byte)));
	T.Columns.Add( new DataColumn("flagautopayment", typeof(String)));
	T.Columns.Add( new DataColumn("flagautoproceeds", typeof(String)));
	T.Columns.Add( new DataColumn("flagcredit", typeof(String)));
	T.Columns.Add( new DataColumn("flagepexp", typeof(String)));
	T.Columns.Add( new DataColumn("flagfruitful", typeof(String)));
	T.Columns.Add( new DataColumn("flagpayment", typeof(String)));
	T.Columns.Add( new DataColumn("flagproceeds", typeof(String)));
	T.Columns.Add( new DataColumn("flagrefund", typeof(String)));
	T.Columns.Add( new DataColumn("foreignhours", typeof(Int32)));
	T.Columns.Add( new DataColumn("idacc_accruedcost", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_accruedrevenue", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_customer", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredcredit", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferreddebit", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredrevenue", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_ivapayment", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_ivarefund", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_patrimony", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_pl", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_supplier", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_admincar", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_foot", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_owncar", typeof(String)));
	T.Columns.Add( new DataColumn("idclawback", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinexpense", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinexpensesurplus", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinincomesurplus", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinivapayment", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinivarefund", typeof(Int32)));
	T.Columns.Add( new DataColumn("idivapayperiodicity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idregauto", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsortingkind1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsortingkind2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsortingkind3", typeof(Int32)));
	T.Columns.Add( new DataColumn("importappname", typeof(String)));
	T.Columns.Add( new DataColumn("income_expiringdays", typeof(Int16)));
	T.Columns.Add( new DataColumn("incomephase", typeof(Byte)));
	T.Columns.Add( new DataColumn("linktoinvoice", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("minpayment", typeof(Decimal)));
	T.Columns.Add( new DataColumn("minrefund", typeof(Decimal)));
	T.Columns.Add( new DataColumn("motivelen", typeof(Int16)));
	T.Columns.Add( new DataColumn("motiveprefix", typeof(String)));
	T.Columns.Add( new DataColumn("motiveseparator", typeof(String)));
	T.Columns.Add( new DataColumn("payment_finlevel", typeof(Byte)));
	T.Columns.Add( new DataColumn("payment_flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("payment_flagautoprintdate", typeof(String)));
	T.Columns.Add( new DataColumn("paymentagency", typeof(Int32)));
	T.Columns.Add( new DataColumn("prevpartitiontitle", typeof(String)));
	T.Columns.Add( new DataColumn("proceeds_finlevel", typeof(Byte)));
	T.Columns.Add( new DataColumn("proceeds_flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(String)));
	T.Columns.Add( new DataColumn("profservice_flagrestart", typeof(String)));
	T.Columns.Add( new DataColumn("refundagency", typeof(Int32)));
	T.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"]};


	//////////////////// INCOMELAST /////////////////////////////////
	T= new DataTable("incomelast");
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpro", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nbill", typeof(Int32)));
	T.Columns.Add( new DataColumn("kpro", typeof(Int32)));
	T.Columns.Add( new DataColumn("idacccredit", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"]};


	//////////////////// BILL /////////////////////////////////
	T= new DataTable("bill");
	C= new DataColumn("ybill", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nbill", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("billkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("registry", typeof(String)));
	T.Columns.Add( new DataColumn("covered", typeof(Decimal)));
	T.Columns.Add( new DataColumn("total", typeof(Decimal)));
	T.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("motive", typeof(String)));
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nbill"]};


	//////////////////// BILLVIEW /////////////////////////////////
	T= new DataTable("billview");
	C= new DataColumn("ybill", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nbill", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("billkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("registry", typeof(String)));
	T.Columns.Add( new DataColumn("motive", typeof(String)));
	T.Columns.Add( new DataColumn("total", typeof(Decimal)));
	T.Columns.Add( new DataColumn("covered", typeof(Decimal)));
	T.Columns.Add( new DataColumn("toregularize", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);

	//////////////////// ACCOUNT /////////////////////////////////
	T= new DataTable("account");
	C= new DataColumn("idacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagregistry", typeof(String)));
	T.Columns.Add( new DataColumn("flagtransitory", typeof(String)));
	T.Columns.Add( new DataColumn("flagupb", typeof(String)));
	T.Columns.Add( new DataColumn("idaccountkind", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridacc", typeof(String)));
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("idpatrimony", typeof(String)));
	T.Columns.Add( new DataColumn("idplaccount", typeof(String)));
	T.Columns.Add( new DataColumn("flagprofit", typeof(String)));
	T.Columns.Add( new DataColumn("flagloss", typeof(String)));
	T.Columns.Add( new DataColumn("placcount_sign", typeof(String)));
	T.Columns.Add( new DataColumn("patrimony_sign", typeof(String)));
	T.Columns.Add( new DataColumn("flagcompetency", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idacc"]};


	//////////////////// INVOICEDETAILDEFERRED /////////////////////////////////
	T= new DataTable("invoicedetaildeferred");
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yinv", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ninv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("rownum", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yivapay", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nivapay", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ivatotalpayed", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxable", typeof(Decimal)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(String)));
	C= new DataColumn("idivaregisterkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinvkind"], T.Columns["yinv"], T.Columns["ninv"], T.Columns["rownum"], T.Columns["yivapay"], T.Columns["nivapay"], T.Columns["idivaregisterkind"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[4]{invoicedetail.Columns["idinvkind"], invoicedetail.Columns["ninv"], invoicedetail.Columns["rownum"], invoicedetail.Columns["yinv"]};
	CChild = new DataColumn[4]{invoicedetaildeferred.Columns["idinvkind"], invoicedetaildeferred.Columns["ninv"], invoicedetaildeferred.Columns["rownum"], invoicedetaildeferred.Columns["yinv"]};
	Relations.Add(new DataRelation("invoicedetail_invoicedetaildeferred",CPar,CChild,false));

	CPar = new DataColumn[1]{account.Columns["idacc"]};
	CChild = new DataColumn[1]{incomelast.Columns["idacccredit"]};
	Relations.Add(new DataRelation("FK_account_incomelast",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomelast.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomelast",CPar,CChild,false));

	CPar = new DataColumn[1]{bill.Columns["nbill"]};
	CChild = new DataColumn[1]{incomelast.Columns["nbill"]};
	Relations.Add(new DataRelation("bill_incomelast",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomesorted.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomesorted",CPar,CChild,false));

	CPar = new DataColumn[1]{invoicekind.Columns["idinvkind"]};
	CChild = new DataColumn[1]{invoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekind_invoice",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomeinvoice.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomeinvoice",CPar,CChild,false));

	CPar = new DataColumn[3]{invoice.Columns["idinvkind"], invoice.Columns["yinv"], invoice.Columns["ninv"]};
	CChild = new DataColumn[3]{incomeinvoice.Columns["idinvkind"], incomeinvoice.Columns["yinv"], incomeinvoice.Columns["ninv"]};
	Relations.Add(new DataRelation("invoice_incomeinvoice",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{estimatedetail.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("income_estimatedetail1",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{estimatedetail.Columns["idinc_taxable"]};
	Relations.Add(new DataRelation("income_estimatedetail",CPar,CChild,false));

	CPar = new DataColumn[3]{estimate.Columns["idestimkind"], estimate.Columns["yestim"], estimate.Columns["nestim"]};
	CChild = new DataColumn[3]{estimatedetail.Columns["idestimkind"], estimatedetail.Columns["yestim"], estimatedetail.Columns["nestim"]};
	Relations.Add(new DataRelation("estimate_estimatedetail",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomeestimate.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomeestimate",CPar,CChild,false));

	CPar = new DataColumn[1]{estimatekind.Columns["idestimkind"]};
	CChild = new DataColumn[1]{estimate.Columns["idestimkind"]};
	Relations.Add(new DataRelation("estimatekind_estimate",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{invoicedetail.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("income_invoicedetail1",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{invoicedetail.Columns["idinc_taxable"]};
	Relations.Add(new DataRelation("income_invoicedetail",CPar,CChild,false));

	CPar = new DataColumn[3]{invoice.Columns["idinvkind"], invoice.Columns["yinv"], invoice.Columns["ninv"]};
	CChild = new DataColumn[3]{invoicedetail.Columns["idinvkind"], invoicedetail.Columns["yinv"], invoicedetail.Columns["ninv"]};
	Relations.Add(new DataRelation("invoice_invoicedetail",CPar,CChild,false));

	CPar = new DataColumn[1]{ivakind.Columns["idivakind"]};
	CChild = new DataColumn[1]{invoicedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("ivakind_invoicedetail",CPar,CChild,false));

	CPar = new DataColumn[1]{upb.Columns["idupb"]};
	CChild = new DataColumn[1]{invoicedetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_invoicedetail",CPar,CChild,false));

	CPar = new DataColumn[1]{upb.Columns["idupb"]};
	CChild = new DataColumn[1]{incomeyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_incomeyear",CPar,CChild,false));

	CPar = new DataColumn[1]{fin.Columns["idfin"]};
	CChild = new DataColumn[1]{incomeyear.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_incomeyear",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomeyear.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomeyear",CPar,CChild,false));

	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{income.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_income",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{income.Columns["parentidinc"]};
	Relations.Add(new DataRelation("income_income",CPar,CChild,false));

	#endregion

}
}
}
