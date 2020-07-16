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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace income_wizardestimatedetail {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomephase		{get { return Tables["incomephase"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable tipomovimento		{get { return Tables["tipomovimento"];}}
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
	///U.P.B.
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable upb		{get { return Tables["upb"];}}
	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable fin		{get { return Tables["fin"];}}
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registry		{get { return Tables["registry"];}}
	///<summary>
	///Contabilizzazione contratto attivo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomeestimate		{get { return Tables["incomeestimate"];}}
	///<summary>
	///Contratto attivo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable estimate		{get { return Tables["estimate"];}}
	///<summary>
	///Dettaglio contratto attivo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable estimatedetail		{get { return Tables["estimatedetail"];}}
	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable estimatekind		{get { return Tables["estimatekind"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registry1		{get { return Tables["registry1"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registry2		{get { return Tables["registry2"];}}
	///<summary>
	///Classificazione Movimenti di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomesorted		{get { return Tables["incomesorted"];}}
	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingkind		{get { return Tables["sortingkind"];}}
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
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// INCOMEPHASE /////////////////////////////////
	T= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
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
	T.PrimaryKey =  new DataColumn[]{T.Columns["nphase"]};


	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	T= new DataTable("tipomovimento");
	C= new DataColumn("idtipo", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("descrizione", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idtipo"]};


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
	T.Columns.Add( new DataColumn("idunderwriting", typeof(Int32)));
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
	T.Columns.Add( new DataColumn("idfin", typeof(Int32)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
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
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"], T.Columns["ayear"]};


	//////////////////// UPB /////////////////////////////////
	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridupb", typeof(String)));
	T.Columns.Add( new DataColumn("idunderwriter", typeof(Int32)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("requested", typeof(Decimal)));
	T.Columns.Add( new DataColumn("granted", typeof(Decimal)));
	T.Columns.Add( new DataColumn("previousappropriation", typeof(Decimal)));
	T.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
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
	T.Columns.Add( new DataColumn("assured", typeof(String)));
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idupb"]};


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


	//////////////////// REGISTRY /////////////////////////////////
	T= new DataTable("registry");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	T.Columns.Add( new DataColumn("p_iva", typeof(String)));
	C= new DataColumn("residence", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("gender", typeof(String)));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("foreigncf", typeof(String)));
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
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
	T.Columns.Add( new DataColumn("badgecode", typeof(String)));
	T.Columns.Add( new DataColumn("idcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idcentralizedcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idmaritalstatus", typeof(String)));
	T.Columns.Add( new DataColumn("idtitle", typeof(String)));
	T.Columns.Add( new DataColumn("idregistryclass", typeof(String)));
	T.Columns.Add( new DataColumn("maritalsurname", typeof(String)));
	T.Columns.Add( new DataColumn("idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idnation", typeof(Int32)));
	T.Columns.Add( new DataColumn("location", typeof(String)));
	T.Columns.Add( new DataColumn("extmatricula", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"]};


	//////////////////// INCOMEESTIMATE /////////////////////////////////
	T= new DataTable("incomeestimate");
	C= new DataColumn("idestimkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yestim", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nestim", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(Int16)));
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
	T.PrimaryKey =  new DataColumn[]{T.Columns["idestimkind"], T.Columns["yestim"], T.Columns["nestim"], T.Columns["idinc"]};


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
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("registryreference", typeof(String)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("deliveryexpiration", typeof(String)));
	T.Columns.Add( new DataColumn("deliveryaddress", typeof(String)));
	T.Columns.Add( new DataColumn("paymentexpiring", typeof(Int16)));
	T.Columns.Add( new DataColumn("idexpirationkind", typeof(Int16)));
	T.Columns.Add( new DataColumn("idcurrency", typeof(Int32)));
	T.Columns.Add( new DataColumn("exchangerate", typeof(Double)));
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
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
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("flagintracom", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivecredit", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivecredit_crg", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivecredit_datacrg", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("idunderwriting", typeof(Int32)));
	T.Columns.Add( new DataColumn("cigcode", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idestimkind"], T.Columns["yestim"], T.Columns["nestim"]};


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
	T.Columns.Add( new DataColumn("detaildescription", typeof(String)));
	T.Columns.Add( new DataColumn("annotations", typeof(String)));
	T.Columns.Add( new DataColumn("number", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxable", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxrate", typeof(Double)));
	T.Columns.Add( new DataColumn("discount", typeof(Double)));
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
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idinc_iva", typeof(Int32)));
	T.Columns.Add( new DataColumn("idinc_taxable", typeof(Int32)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("toinvoice", typeof(String)));
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	T.Columns.Add( new DataColumn("!codeupb", typeof(String)));
	T.Columns.Add( new DataColumn("tax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("!registry", typeof(String)));
	T.Columns.Add( new DataColumn("idgroup", typeof(Int32)));
	T.Columns.Add( new DataColumn("ninvoiced", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idivakind", typeof(Int32)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(String)));
	T.Columns.Add( new DataColumn("!totaleriga", typeof(Decimal)));
	T.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	T.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("epkind", typeof(String)));
	T.Columns.Add( new DataColumn("idupb_iva", typeof(String)));
	T.Columns.Add( new DataColumn("!codeupb_iva", typeof(String)));
	T.Columns.Add( new DataColumn("cigcode", typeof(String)));
	T.Columns.Add( new DataColumn("idfinmotive", typeof(String)));
	T.Columns.Add( new DataColumn("iduniqueformcode", typeof(String)));
	T.Columns.Add( new DataColumn("nform", typeof(String)));
	T.Columns.Add( new DataColumn("idlist", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor_siope", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idestimkind"], T.Columns["yestim"], T.Columns["nestim"], T.Columns["rownum"]};


	//////////////////// ESTIMATEKIND /////////////////////////////////
	T= new DataTable("estimatekind");
	C= new DataColumn("idestimkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
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
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idestimkind"]};


	//////////////////// REGISTRY1 /////////////////////////////////
	T= new DataTable("registry1");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	T.Columns.Add( new DataColumn("p_iva", typeof(String)));
	C= new DataColumn("residence", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("gender", typeof(String)));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("foreigncf", typeof(String)));
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
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
	T.Columns.Add( new DataColumn("badgecode", typeof(String)));
	T.Columns.Add( new DataColumn("idcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idcentralizedcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idmaritalstatus", typeof(String)));
	T.Columns.Add( new DataColumn("idtitle", typeof(String)));
	T.Columns.Add( new DataColumn("idregistryclass", typeof(String)));
	T.Columns.Add( new DataColumn("maritalsurname", typeof(String)));
	T.Columns.Add( new DataColumn("idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idnation", typeof(Int32)));
	T.Columns.Add( new DataColumn("location", typeof(String)));
	T.Columns.Add( new DataColumn("extmatricula", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"]};


	//////////////////// REGISTRY2 /////////////////////////////////
	T= new DataTable("registry2");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	T.Columns.Add( new DataColumn("p_iva", typeof(String)));
	C= new DataColumn("residence", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("gender", typeof(String)));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("foreigncf", typeof(String)));
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
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
	T.Columns.Add( new DataColumn("badgecode", typeof(String)));
	T.Columns.Add( new DataColumn("idcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idcentralizedcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idmaritalstatus", typeof(String)));
	T.Columns.Add( new DataColumn("idtitle", typeof(String)));
	T.Columns.Add( new DataColumn("idregistryclass", typeof(String)));
	T.Columns.Add( new DataColumn("maritalsurname", typeof(String)));
	T.Columns.Add( new DataColumn("idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idnation", typeof(Int32)));
	T.Columns.Add( new DataColumn("location", typeof(String)));
	T.Columns.Add( new DataColumn("extmatricula", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"]};


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


	//////////////////// SORTINGKIND /////////////////////////////////
	T= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(Int32));
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
	T.Columns.Add( new DataColumn("flagdate", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN5", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS5", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv5", typeof(String)));
	T.Columns.Add( new DataColumn("labelfordate", typeof(String)));
	T.Columns.Add( new DataColumn("labeln1", typeof(String)));
	T.Columns.Add( new DataColumn("labeln2", typeof(String)));
	T.Columns.Add( new DataColumn("labeln3", typeof(String)));
	T.Columns.Add( new DataColumn("labeln4", typeof(String)));
	T.Columns.Add( new DataColumn("labeln5", typeof(String)));
	T.Columns.Add( new DataColumn("labels1", typeof(String)));
	T.Columns.Add( new DataColumn("labels2", typeof(String)));
	T.Columns.Add( new DataColumn("labels3", typeof(String)));
	T.Columns.Add( new DataColumn("labels4", typeof(String)));
	T.Columns.Add( new DataColumn("labels5", typeof(String)));
	T.Columns.Add( new DataColumn("labelv1", typeof(String)));
	T.Columns.Add( new DataColumn("labelv2", typeof(String)));
	T.Columns.Add( new DataColumn("labelv3", typeof(String)));
	T.Columns.Add( new DataColumn("labelv4", typeof(String)));
	T.Columns.Add( new DataColumn("labelv5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv5", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nodatelabel", typeof(String)));
	T.Columns.Add( new DataColumn("nphaseexpense", typeof(Byte)));
	T.Columns.Add( new DataColumn("nphaseincome", typeof(Byte)));
	T.Columns.Add( new DataColumn("totalexpression", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsorkind"]};


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


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomelast.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomelast",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomesorted.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomesorted",CPar,CChild,false));

	CPar = new DataColumn[1]{registry2.Columns["idreg"]};
	CChild = new DataColumn[1]{estimatedetail.Columns["idreg"]};
	Relations.Add(new DataRelation("registry2estimatedetail",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{estimatedetail.Columns["idinc_taxable"]};
	Relations.Add(new DataRelation("incomeestimatedetail1",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{estimatedetail.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("incomeestimatedetail",CPar,CChild,false));

	CPar = new DataColumn[3]{estimate.Columns["idestimkind"], estimate.Columns["yestim"], estimate.Columns["nestim"]};
	CChild = new DataColumn[3]{estimatedetail.Columns["idestimkind"], estimatedetail.Columns["yestim"], estimatedetail.Columns["nestim"]};
	Relations.Add(new DataRelation("estimateestimatedetail",CPar,CChild,false));

	CPar = new DataColumn[1]{registry1.Columns["idreg"]};
	CChild = new DataColumn[1]{estimate.Columns["idreg"]};
	Relations.Add(new DataRelation("registry1estimate",CPar,CChild,false));

	CPar = new DataColumn[1]{estimatekind.Columns["idestimkind"]};
	CChild = new DataColumn[1]{estimate.Columns["idestimkind"]};
	Relations.Add(new DataRelation("estimatekindestimate",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomeestimate.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeincomeestimate",CPar,CChild,false));

	CPar = new DataColumn[3]{estimate.Columns["idestimkind"], estimate.Columns["yestim"], estimate.Columns["nestim"]};
	CChild = new DataColumn[3]{incomeestimate.Columns["idestimkind"], incomeestimate.Columns["yestim"], incomeestimate.Columns["nestim"]};
	Relations.Add(new DataRelation("estimateincomeestimate",CPar,CChild,false));

	CPar = new DataColumn[1]{fin.Columns["idfin"]};
	CChild = new DataColumn[1]{incomeyear.Columns["idfin"]};
	Relations.Add(new DataRelation("finincomeyear",CPar,CChild,false));

	CPar = new DataColumn[1]{upb.Columns["idupb"]};
	CChild = new DataColumn[1]{incomeyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upbincomeyear",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomeyear.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeincomeyear",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{income.Columns["parentidinc"]};
	Relations.Add(new DataRelation("incomeincome",CPar,CChild,false));

	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{income.Columns["idreg"]};
	Relations.Add(new DataRelation("registryincome",CPar,CChild,false));

	#endregion

}
}
}
