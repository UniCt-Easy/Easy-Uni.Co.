/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
namespace serviceregistry_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Banca dati degli Incarichi - Anagrafe Prestazioni e Pubblicazione sito web istituzionale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable serviceregistry		{get { return Tables["serviceregistry"];}}
	///<summary>
	///Qualifica (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable apmanager		{get { return Tables["apmanager"];}}
	///<summary>
	///Tipologia Consulente (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable consultingkind		{get { return Tables["consultingkind"];}}
	///<summary>
	///Tipo Rapporto (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable apcontractkind		{get { return Tables["apcontractkind"];}}
	///<summary>
	///Attività Economica (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable financialactivity		{get { return Tables["financialactivity"];}}
	///<summary>
	///Tipologia Conferente (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable apregistrykind		{get { return Tables["apregistrykind"];}}
	///<summary>
	///Tipologia Incarico (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable apactivitykind		{get { return Tables["apactivitykind"];}}
	///<summary>
	///Modalità di Acquisizione Incarico(per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable acquirekind		{get { return Tables["acquirekind"];}}
	///<summary>
	///Lista Dipartimenti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable department		{get { return Tables["department"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable serviceregistryview		{get { return Tables["serviceregistryview"];}}
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registry		{get { return Tables["registry"];}}
	///<summary>
	///Comuni
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable geo_city		{get { return Tables["geo_city"];}}
	///<summary>
	///Assegnazione Automatica del Pagamento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable servicepayment		{get { return Tables["servicepayment"];}}
	///<summary>
	///Codice Ente, dati prelevati dal sito perlaPA, usati nell'anagrafe prestazioni
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable serviceagency		{get { return Tables["serviceagency"];}}
	///<summary>
	///Riferimento  normativo incarico anagrafe prestazioni
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable referencerule		{get { return Tables["referencerule"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable apfinancialactivityview		{get { return Tables["apfinancialactivityview"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable conferente		{get { return Tables["conferente"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable geo_city_conferente		{get { return Tables["geo_city_conferente"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting01		{get { return Tables["sorting01"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting02		{get { return Tables["sorting02"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting03		{get { return Tables["sorting03"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting04		{get { return Tables["sorting04"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting05		{get { return Tables["sorting05"];}}
	///<summary>
	///Tipologia Incarico
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable serviceregistrykind		{get { return Tables["serviceregistrykind"];}}
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
	//////////////////// SERVICEREGISTRY /////////////////////////////////
	T= new DataTable("serviceregistry");
	C= new DataColumn("yservreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nservreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("id_service", typeof(String)));
	C= new DataColumn("employkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("iddepartment", typeof(Int32)));
	T.Columns.Add( new DataColumn("is_annulled", typeof(String)));
	T.Columns.Add( new DataColumn("is_delivered", typeof(String)));
	T.Columns.Add( new DataColumn("is_changed", typeof(String)));
	T.Columns.Add( new DataColumn("idconsultingkind", typeof(String)));
	T.Columns.Add( new DataColumn("p_iva", typeof(String)));
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	T.Columns.Add( new DataColumn("flagforeign", typeof(String)));
	T.Columns.Add( new DataColumn("title", typeof(String)));
	T.Columns.Add( new DataColumn("codcity", typeof(String)));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("gender", typeof(String)));
	T.Columns.Add( new DataColumn("referencesemester", typeof(Int32)));
	T.Columns.Add( new DataColumn("pa_code", typeof(String)));
	T.Columns.Add( new DataColumn("idacquirekind", typeof(String)));
	T.Columns.Add( new DataColumn("idapcontractkind", typeof(String)));
	T.Columns.Add( new DataColumn("idfinancialactivity", typeof(String)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("servicevariation", typeof(String)));
	C= new DataColumn("expectedamount", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("payment", typeof(String)));
	T.Columns.Add( new DataColumn("ypay", typeof(Int32)));
	T.Columns.Add( new DataColumn("idapmanager", typeof(String)));
	T.Columns.Add( new DataColumn("idapregistrykind", typeof(String)));
	T.Columns.Add( new DataColumn("idapactivitykind", typeof(String)));
	T.Columns.Add( new DataColumn("pa_cf", typeof(String)));
	T.Columns.Add( new DataColumn("pa_title", typeof(String)));
	T.Columns.Add( new DataColumn("authorizationdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("officeduty", typeof(String)));
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("referencerule", typeof(String)));
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
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idrelated", typeof(String)));
	T.Columns.Add( new DataColumn("is_blocked", typeof(String)));
	T.Columns.Add( new DataColumn("regulation", typeof(String)));
	T.Columns.Add( new DataColumn("paragraph", typeof(String)));
	T.Columns.Add( new DataColumn("article", typeof(String)));
	T.Columns.Add( new DataColumn("articlenumber", typeof(String)));
	T.Columns.Add( new DataColumn("referencedate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idreferencerule", typeof(String)));
	T.Columns.Add( new DataColumn("idapfinancialactivity", typeof(Int32)));
	T.Columns.Add( new DataColumn("rulespecifics", typeof(String)));
	T.Columns.Add( new DataColumn("expectationsdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("senderreporting", typeof(String)));
	T.Columns.Add( new DataColumn("flaghuman", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_piva", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_forename", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_surname", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_flagforeign", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("conferring_gender", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_codcity", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idconferring", typeof(Int32)));
	T.Columns.Add( new DataColumn("conferringstructure", typeof(String)));
	T.Columns.Add( new DataColumn("ordinancelink", typeof(String)));
	T.Columns.Add( new DataColumn("authorizingstructure", typeof(String)));
	T.Columns.Add( new DataColumn("authorizinglink", typeof(String)));
	T.Columns.Add( new DataColumn("actreference", typeof(String)));
	T.Columns.Add( new DataColumn("announcementlink", typeof(String)));
	T.Columns.Add( new DataColumn("otherservice", typeof(String)));
	T.Columns.Add( new DataColumn("professionalservice", typeof(String)));
	T.Columns.Add( new DataColumn("componentsvariable", typeof(String)));
	T.Columns.Add( new DataColumn("idserviceregistrykind", typeof(Int32)));
	T.Columns.Add( new DataColumn("employtime", typeof(String)));
	T.Columns.Add( new DataColumn("notes", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("certinterestconflicts", typeof(String)));
	T.Columns.Add( new DataColumn("website_annulled", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["yservreg"], T.Columns["nservreg"]};


	//////////////////// APMANAGER /////////////////////////////////
	T= new DataTable("apmanager");
	C= new DataColumn("idapmanager", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
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
	T.Columns.Add( new DataColumn("active", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idapmanager"], T.Columns["ayear"]};


	//////////////////// CONSULTINGKIND /////////////////////////////////
	T= new DataTable("consultingkind");
	C= new DataColumn("idconsultingkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
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
	T.Columns.Add( new DataColumn("active", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idconsultingkind"], T.Columns["ayear"]};


	//////////////////// APCONTRACTKIND /////////////////////////////////
	T= new DataTable("apcontractkind");
	C= new DataColumn("idapcontractkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
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
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idapcontractkind"], T.Columns["ayear"]};


	//////////////////// FINANCIALACTIVITY /////////////////////////////////
	T= new DataTable("financialactivity");
	C= new DataColumn("idfinancialactivity", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
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
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idfinancialactivity"], T.Columns["ayear"]};


	//////////////////// APREGISTRYKIND /////////////////////////////////
	T= new DataTable("apregistrykind");
	C= new DataColumn("idapregistrykind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
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
	T.Columns.Add( new DataColumn("active", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idapregistrykind"], T.Columns["ayear"]};


	//////////////////// APACTIVITYKIND /////////////////////////////////
	T= new DataTable("apactivitykind");
	C= new DataColumn("idapactivitykind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
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
	T.Columns.Add( new DataColumn("active", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idapactivitykind"], T.Columns["ayear"]};


	//////////////////// ACQUIREKIND /////////////////////////////////
	T= new DataTable("acquirekind");
	C= new DataColumn("idacquirekind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
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
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idacquirekind"], T.Columns["ayear"]};


	//////////////////// DEPARTMENT /////////////////////////////////
	T= new DataTable("department");
	C= new DataColumn("iddepartment", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("server", typeof(String)));
	T.Columns.Add( new DataColumn("db", typeof(String)));
	T.Columns.Add( new DataColumn("userdep", typeof(String)));
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
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["iddepartment"]};


	//////////////////// SERVICEREGISTRYVIEW /////////////////////////////////
	T= new DataTable("serviceregistryview");
	C= new DataColumn("yservreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nservreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("id_service", typeof(String)));
	T.Columns.Add( new DataColumn("employkind", typeof(String)));
	T.Columns.Add( new DataColumn("iddepartment", typeof(Int32)));
	T.Columns.Add( new DataColumn("department", typeof(String)));
	T.Columns.Add( new DataColumn("is_annulled", typeof(String)));
	T.Columns.Add( new DataColumn("is_delivered", typeof(String)));
	T.Columns.Add( new DataColumn("is_changed", typeof(String)));
	T.Columns.Add( new DataColumn("idconsultingkind", typeof(String)));
	T.Columns.Add( new DataColumn("consultingkind", typeof(String)));
	T.Columns.Add( new DataColumn("p_iva", typeof(String)));
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	T.Columns.Add( new DataColumn("flagforeign", typeof(String)));
	T.Columns.Add( new DataColumn("title", typeof(String)));
	T.Columns.Add( new DataColumn("codcity", typeof(String)));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("gender", typeof(String)));
	T.Columns.Add( new DataColumn("referencesemester", typeof(Int32)));
	T.Columns.Add( new DataColumn("pa_code", typeof(String)));
	T.Columns.Add( new DataColumn("idacquirekind", typeof(String)));
	T.Columns.Add( new DataColumn("acquirekind", typeof(String)));
	T.Columns.Add( new DataColumn("idapcontractkind", typeof(String)));
	T.Columns.Add( new DataColumn("apcontractkind", typeof(String)));
	T.Columns.Add( new DataColumn("idfinancialactivity", typeof(String)));
	T.Columns.Add( new DataColumn("financialactivity", typeof(String)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("servicevariation", typeof(String)));
	C= new DataColumn("expectedamount", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("payment", typeof(String)));
	T.Columns.Add( new DataColumn("ypay", typeof(Int32)));
	T.Columns.Add( new DataColumn("idapmanager", typeof(String)));
	T.Columns.Add( new DataColumn("apmanager", typeof(String)));
	T.Columns.Add( new DataColumn("idapregistrykind", typeof(String)));
	T.Columns.Add( new DataColumn("apregistrykind", typeof(String)));
	T.Columns.Add( new DataColumn("idapactivitykind", typeof(String)));
	T.Columns.Add( new DataColumn("apactivitykind", typeof(String)));
	T.Columns.Add( new DataColumn("pa_cf", typeof(String)));
	T.Columns.Add( new DataColumn("pa_title", typeof(String)));
	T.Columns.Add( new DataColumn("authorizationdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("officeduty", typeof(String)));
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("referencerule", typeof(String)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
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
	T.Columns.Add( new DataColumn("city", typeof(String)));
	T.Columns.Add( new DataColumn("idrelated", typeof(String)));
	T.Columns.Add( new DataColumn("is_blocked", typeof(String)));
	T.Columns.Add( new DataColumn("regulation", typeof(String)));
	T.Columns.Add( new DataColumn("idapfinancialactivity", typeof(Int32)));
	T.Columns.Add( new DataColumn("apfinancialactivitycode", typeof(String)));
	T.Columns.Add( new DataColumn("apfinancialactivity", typeof(String)));
	T.Columns.Add( new DataColumn("expectationsdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("rulespecifics", typeof(String)));
	T.Columns.Add( new DataColumn("paragraph", typeof(String)));
	T.Columns.Add( new DataColumn("article", typeof(String)));
	T.Columns.Add( new DataColumn("articlenumber", typeof(String)));
	T.Columns.Add( new DataColumn("referencedate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idreferencerule", typeof(String)));
	T.Columns.Add( new DataColumn("referenceruledescription", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_piva", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_forename", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_surname", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_flagforeign", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("conferring_gender", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_codcity", typeof(String)));
	T.Columns.Add( new DataColumn("conferring_idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idconferring", typeof(Int32)));
	T.Columns.Add( new DataColumn("conferring_city", typeof(String)));
	T.Columns.Add( new DataColumn("employtime", typeof(String)));
	T.Columns.Add( new DataColumn("idserviceregistrykind", typeof(Int32)));
	T.Columns.Add( new DataColumn("serviceregistrykind", typeof(String)));
	T.Columns.Add( new DataColumn("conferringstructure", typeof(String)));
	T.Columns.Add( new DataColumn("ordinancelink", typeof(String)));
	T.Columns.Add( new DataColumn("authorizingstructure", typeof(String)));
	T.Columns.Add( new DataColumn("authorizinglink", typeof(String)));
	T.Columns.Add( new DataColumn("actreference", typeof(String)));
	T.Columns.Add( new DataColumn("announcementlink", typeof(String)));
	T.Columns.Add( new DataColumn("otherservice", typeof(String)));
	T.Columns.Add( new DataColumn("professionalservice", typeof(String)));
	T.Columns.Add( new DataColumn("componentsvariable", typeof(String)));
	T.Columns.Add( new DataColumn("notes", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("certinterestconflicts", typeof(String)));
	T.Columns.Add( new DataColumn("website_annulled", typeof(String)));
	T.Columns.Add( new DataColumn("flaghuman", typeof(String)));
	Tables.Add(T);

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


	//////////////////// GEO_CITY /////////////////////////////////
	T= new DataTable("geo_city");
	C= new DataColumn("idcity", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idcountry", typeof(Int32)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("newcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("oldcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("title", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcity"]};


	//////////////////// SERVICEPAYMENT /////////////////////////////////
	T= new DataTable("servicepayment");
	C= new DataColumn("yservreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nservreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ypay", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("semesterpay", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("payedamount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("is_delivered", typeof(String)));
	T.Columns.Add( new DataColumn("is_changed", typeof(String)));
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
	T.Columns.Add( new DataColumn("is_blocked", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["yservreg"], T.Columns["nservreg"], T.Columns["ypay"], T.Columns["semesterpay"]};


	//////////////////// SERVICEAGENCY /////////////////////////////////
	T= new DataTable("serviceagency");
	C= new DataColumn("pa_code", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("pa_title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("pa_cf", typeof(String));
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
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["pa_code"]};


	//////////////////// REFERENCERULE /////////////////////////////////
	T= new DataTable("referencerule");
	C= new DataColumn("idreferencerule", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
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
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreferencerule"]};


	//////////////////// APFINANCIALACTIVITYVIEW /////////////////////////////////
	T= new DataTable("apfinancialactivityview");
	C= new DataColumn("idapfinancialactivity", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("apfinancialactivitycode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridapfinancialactivity", typeof(Int32)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
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
	T.PrimaryKey =  new DataColumn[]{T.Columns["idapfinancialactivity"]};


	//////////////////// CONFERENTE /////////////////////////////////
	T= new DataTable("conferente");
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
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("residence", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idregistrykind", typeof(Int32)));
	T.Columns.Add( new DataColumn("authorization_free", typeof(String)));
	T.Columns.Add( new DataColumn("multi_cf", typeof(String)));
	T.Columns.Add( new DataColumn("toredirect", typeof(Int32)));
	T.Columns.Add( new DataColumn("idaccmotivedebit", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivecredit", typeof(String)));
	T.Columns.Add( new DataColumn("ccp", typeof(String)));
	T.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(String)));
	T.Columns.Add( new DataColumn("idexternal", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"]};


	//////////////////// GEO_CITY_CONFERENTE /////////////////////////////////
	T= new DataTable("geo_city_conferente");
	C= new DataColumn("idcity", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idcountry", typeof(Int32)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("newcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("oldcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("title", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcity"]};


	//////////////////// SORTING01 /////////////////////////////////
	T= new DataTable("sorting01");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	T.Columns.Add( new DataColumn("email", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SORTING02 /////////////////////////////////
	T= new DataTable("sorting02");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	T.Columns.Add( new DataColumn("email", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SORTING03 /////////////////////////////////
	T= new DataTable("sorting03");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	T.Columns.Add( new DataColumn("email", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SORTING04 /////////////////////////////////
	T= new DataTable("sorting04");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	T.Columns.Add( new DataColumn("email", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SORTING05 /////////////////////////////////
	T= new DataTable("sorting05");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	T.Columns.Add( new DataColumn("email", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SERVICEREGISTRYKIND /////////////////////////////////
	T= new DataTable("serviceregistrykind");
	C= new DataColumn("idserviceregistrykind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("totransmit", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("topublish", typeof(String));
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
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagconferringstructure", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagordinancelink", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagauthorizingstructure", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagauthorizinglink", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagactreference", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagannouncementlink", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagotherservice", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagprofessionalservice", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagcomponentsvariable", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagcvattachment", typeof(Int16)));
	T.Columns.Add( new DataColumn("employkind", typeof(String)));
	T.Columns.Add( new DataColumn("flagemploytime", typeof(Int16)));
	T.Columns.Add( new DataColumn("otherservice", typeof(String)));
	T.Columns.Add( new DataColumn("professionalservice", typeof(String)));
	T.Columns.Add( new DataColumn("componentsvariable", typeof(String)));
	T.Columns.Add( new DataColumn("flagcertinterestconflicts", typeof(Int16)));
	T.Columns.Add( new DataColumn("certinterestconflicts", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idserviceregistrykind"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[2]{serviceregistry.Columns["yservreg"], serviceregistry.Columns["nservreg"]};
	CChild = new DataColumn[2]{servicepayment.Columns["yservreg"], servicepayment.Columns["nservreg"]};
	Relations.Add(new DataRelation("serviceregistryservicepayment213",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting05.Columns["idsor"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idsor05"]};
	Relations.Add(new DataRelation("FK_sorting05_serviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting04.Columns["idsor"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idsor04"]};
	Relations.Add(new DataRelation("FK_sorting04_serviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting03.Columns["idsor"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idsor03"]};
	Relations.Add(new DataRelation("FK_sorting03_serviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting02.Columns["idsor"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idsor02"]};
	Relations.Add(new DataRelation("FK_sorting02_serviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting01.Columns["idsor"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idsor01"]};
	Relations.Add(new DataRelation("FK_sorting01_serviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{geo_city_conferente.Columns["idcity"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["conferring_idcity"]};
	Relations.Add(new DataRelation("FK_geo_city_conferente_serviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{conferente.Columns["idreg"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idconferring"]};
	Relations.Add(new DataRelation("FK_conferente_serviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{apfinancialactivityview.Columns["idapfinancialactivity"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idapfinancialactivity"]};
	Relations.Add(new DataRelation("FK_apfinancialactivityview_serviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{referencerule.Columns["idreferencerule"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idreferencerule"]};
	Relations.Add(new DataRelation("FK_referencerule_serviceregistry",CPar,CChild,false));

	CPar = new DataColumn[2]{acquirekind.Columns["idacquirekind"], acquirekind.Columns["ayear"]};
	CChild = new DataColumn[2]{serviceregistry.Columns["idacquirekind"], serviceregistry.Columns["yservreg"]};
	Relations.Add(new DataRelation("acquirekindserviceregistry",CPar,CChild,false));

	CPar = new DataColumn[2]{financialactivity.Columns["idfinancialactivity"], financialactivity.Columns["ayear"]};
	CChild = new DataColumn[2]{serviceregistry.Columns["idfinancialactivity"], serviceregistry.Columns["yservreg"]};
	Relations.Add(new DataRelation("financialactivityserviceregistry",CPar,CChild,false));

	CPar = new DataColumn[2]{apcontractkind.Columns["idapcontractkind"], apcontractkind.Columns["ayear"]};
	CChild = new DataColumn[2]{serviceregistry.Columns["idapcontractkind"], serviceregistry.Columns["yservreg"]};
	Relations.Add(new DataRelation("apcontractkindserviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{serviceagency.Columns["pa_code"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["pa_code"]};
	Relations.Add(new DataRelation("serviceagencyserviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{geo_city.Columns["idcity"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idcity"]};
	Relations.Add(new DataRelation("serviceregistrygeo_city63",CPar,CChild,false));

	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idreg"]};
	Relations.Add(new DataRelation("registryserviceregistry65",CPar,CChild,false));

	CPar = new DataColumn[1]{department.Columns["iddepartment"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["iddepartment"]};
	Relations.Add(new DataRelation("departmentserviceregistry32",CPar,CChild,false));

	CPar = new DataColumn[1]{apactivitykind.Columns["idapactivitykind"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idapactivitykind"]};
	Relations.Add(new DataRelation("apactivitykindserviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{apregistrykind.Columns["idapregistrykind"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idapregistrykind"]};
	Relations.Add(new DataRelation("apregistrykindserviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{consultingkind.Columns["idconsultingkind"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idconsultingkind"]};
	Relations.Add(new DataRelation("consultingkindserviceregistry",CPar,CChild,false));

	CPar = new DataColumn[1]{apmanager.Columns["idapmanager"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idapmanager"]};
	Relations.Add(new DataRelation("apmanagerserviceregistry12",CPar,CChild,false));

	CPar = new DataColumn[1]{serviceregistrykind.Columns["idserviceregistrykind"]};
	CChild = new DataColumn[1]{serviceregistry.Columns["idserviceregistrykind"]};
	Relations.Add(new DataRelation("serviceregistrykind_serviceregistry",CPar,CChild,false));

	#endregion

}
}
}
