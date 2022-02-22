
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
namespace serviceregistry_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Banca dati degli Incarichi - Anagrafe Prestazioni e Pubblicazione sito web istituzionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable serviceregistry 		=> Tables["serviceregistry"];

	///<summary>
	///Qualifica (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable apmanager 		=> Tables["apmanager"];

	///<summary>
	///Tipologia Consulente (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable consultingkind 		=> Tables["consultingkind"];

	///<summary>
	///Tipo Rapporto (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable apcontractkind 		=> Tables["apcontractkind"];

	///<summary>
	///Attività Economica (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable financialactivity 		=> Tables["financialactivity"];

	///<summary>
	///Tipologia Conferente (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable apregistrykind 		=> Tables["apregistrykind"];

	///<summary>
	///Tipologia Incarico (per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable apactivitykind 		=> Tables["apactivitykind"];

	///<summary>
	///Modalità di Acquisizione Incarico(per anagrafe prestazioni)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable acquirekind 		=> Tables["acquirekind"];

	///<summary>
	///Lista Dipartimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable department 		=> Tables["department"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Comuni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_city 		=> Tables["geo_city"];

	///<summary>
	///Assegnazione Automatica del Pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable servicepayment 		=> Tables["servicepayment"];

	///<summary>
	///Codice Ente, dati prelevati dal sito perlaPA, usati nell'anagrafe prestazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable serviceagency 		=> Tables["serviceagency"];

	///<summary>
	///Riferimento  normativo incarico anagrafe prestazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable referencerule 		=> Tables["referencerule"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable apfinancialactivityview 		=> Tables["apfinancialactivityview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable conferente 		=> Tables["conferente"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_city_conferente 		=> Tables["geo_city_conferente"];

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
	///Tipologia Incarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable serviceregistrykind 		=> Tables["serviceregistrykind"];

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
	//////////////////// SERVICEREGISTRY /////////////////////////////////
	var tserviceregistry= new DataTable("serviceregistry");
	C= new DataColumn("yservreg", typeof(int));
	C.AllowDBNull=false;
	tserviceregistry.Columns.Add(C);
	C= new DataColumn("nservreg", typeof(int));
	C.AllowDBNull=false;
	tserviceregistry.Columns.Add(C);
	tserviceregistry.Columns.Add( new DataColumn("id_service", typeof(string)));
	C= new DataColumn("employkind", typeof(string));
	C.AllowDBNull=false;
	tserviceregistry.Columns.Add(C);
	tserviceregistry.Columns.Add( new DataColumn("iddepartment", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("is_annulled", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("is_delivered", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("is_changed", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("idconsultingkind", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("title", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("codcity", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tserviceregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("referencesemester", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("pa_code", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("idacquirekind", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("idapcontractkind", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("idfinancialactivity", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("description", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tserviceregistry.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tserviceregistry.Columns.Add( new DataColumn("servicevariation", typeof(string)));
	C= new DataColumn("expectedamount", typeof(decimal));
	C.AllowDBNull=false;
	tserviceregistry.Columns.Add(C);
	tserviceregistry.Columns.Add( new DataColumn("payment", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("ypay", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("idapmanager", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("idapregistrykind", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("idapactivitykind", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("pa_cf", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("pa_title", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("authorizationdate", typeof(DateTime)));
	tserviceregistry.Columns.Add( new DataColumn("officeduty", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("referencerule", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tserviceregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tserviceregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tserviceregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tserviceregistry.Columns.Add(C);
	tserviceregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tserviceregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("idreg", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("is_blocked", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("regulation", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("paragraph", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("article", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("articlenumber", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("referencedate", typeof(DateTime)));
	tserviceregistry.Columns.Add( new DataColumn("idreferencerule", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("idapfinancialactivity", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("rulespecifics", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("expectationsdate", typeof(DateTime)));
	tserviceregistry.Columns.Add( new DataColumn("senderreporting", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("flaghuman", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("conferring_piva", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("conferring_forename", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("conferring_surname", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("conferring_flagforeign", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("conferring_birthdate", typeof(DateTime)));
	tserviceregistry.Columns.Add( new DataColumn("conferring_gender", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("conferring_codcity", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("conferring_idcity", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("idconferring", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("conferringstructure", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("ordinancelink", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("authorizingstructure", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("authorizinglink", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("actreference", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("announcementlink", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("otherservice", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("professionalservice", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("componentsvariable", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("idserviceregistrykind", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("employtime", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("notes", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tserviceregistry.Columns.Add( new DataColumn("certinterestconflicts", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("website_annulled", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("perla_error", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("dichiarazione_incarichi", typeof(Byte[])));
	tserviceregistry.Columns.Add( new DataColumn("codicepaipa", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("codiceaooipa", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("codiceuoipa", typeof(string)));
	Tables.Add(tserviceregistry);
	tserviceregistry.PrimaryKey =  new DataColumn[]{tserviceregistry.Columns["yservreg"], tserviceregistry.Columns["nservreg"]};


	//////////////////// APMANAGER /////////////////////////////////
	var tapmanager= new DataTable("apmanager");
	C= new DataColumn("idapmanager", typeof(string));
	C.AllowDBNull=false;
	tapmanager.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tapmanager.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tapmanager.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tapmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tapmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tapmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tapmanager.Columns.Add(C);
	tapmanager.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tapmanager);
	tapmanager.PrimaryKey =  new DataColumn[]{tapmanager.Columns["idapmanager"], tapmanager.Columns["ayear"]};


	//////////////////// CONSULTINGKIND /////////////////////////////////
	var tconsultingkind= new DataTable("consultingkind");
	C= new DataColumn("idconsultingkind", typeof(string));
	C.AllowDBNull=false;
	tconsultingkind.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tconsultingkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tconsultingkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tconsultingkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tconsultingkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tconsultingkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tconsultingkind.Columns.Add(C);
	tconsultingkind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tconsultingkind);
	tconsultingkind.PrimaryKey =  new DataColumn[]{tconsultingkind.Columns["idconsultingkind"], tconsultingkind.Columns["ayear"]};


	//////////////////// APCONTRACTKIND /////////////////////////////////
	var tapcontractkind= new DataTable("apcontractkind");
	C= new DataColumn("idapcontractkind", typeof(string));
	C.AllowDBNull=false;
	tapcontractkind.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tapcontractkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tapcontractkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tapcontractkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tapcontractkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tapcontractkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tapcontractkind.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tapcontractkind.Columns.Add(C);
	Tables.Add(tapcontractkind);
	tapcontractkind.PrimaryKey =  new DataColumn[]{tapcontractkind.Columns["idapcontractkind"], tapcontractkind.Columns["ayear"]};


	//////////////////// FINANCIALACTIVITY /////////////////////////////////
	var tfinancialactivity= new DataTable("financialactivity");
	C= new DataColumn("idfinancialactivity", typeof(string));
	C.AllowDBNull=false;
	tfinancialactivity.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tfinancialactivity.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tfinancialactivity.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinancialactivity.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinancialactivity.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinancialactivity.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinancialactivity.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfinancialactivity.Columns.Add(C);
	Tables.Add(tfinancialactivity);
	tfinancialactivity.PrimaryKey =  new DataColumn[]{tfinancialactivity.Columns["idfinancialactivity"], tfinancialactivity.Columns["ayear"]};


	//////////////////// APREGISTRYKIND /////////////////////////////////
	var tapregistrykind= new DataTable("apregistrykind");
	C= new DataColumn("idapregistrykind", typeof(string));
	C.AllowDBNull=false;
	tapregistrykind.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tapregistrykind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tapregistrykind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tapregistrykind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tapregistrykind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tapregistrykind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tapregistrykind.Columns.Add(C);
	tapregistrykind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tapregistrykind);
	tapregistrykind.PrimaryKey =  new DataColumn[]{tapregistrykind.Columns["idapregistrykind"], tapregistrykind.Columns["ayear"]};


	//////////////////// APACTIVITYKIND /////////////////////////////////
	var tapactivitykind= new DataTable("apactivitykind");
	C= new DataColumn("idapactivitykind", typeof(string));
	C.AllowDBNull=false;
	tapactivitykind.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tapactivitykind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tapactivitykind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tapactivitykind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tapactivitykind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tapactivitykind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tapactivitykind.Columns.Add(C);
	tapactivitykind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tapactivitykind);
	tapactivitykind.PrimaryKey =  new DataColumn[]{tapactivitykind.Columns["idapactivitykind"], tapactivitykind.Columns["ayear"]};


	//////////////////// ACQUIREKIND /////////////////////////////////
	var tacquirekind= new DataTable("acquirekind");
	C= new DataColumn("idacquirekind", typeof(string));
	C.AllowDBNull=false;
	tacquirekind.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tacquirekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tacquirekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tacquirekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tacquirekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tacquirekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tacquirekind.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tacquirekind.Columns.Add(C);
	Tables.Add(tacquirekind);
	tacquirekind.PrimaryKey =  new DataColumn[]{tacquirekind.Columns["idacquirekind"], tacquirekind.Columns["ayear"]};


	//////////////////// DEPARTMENT /////////////////////////////////
	var tdepartment= new DataTable("department");
	C= new DataColumn("iddepartment", typeof(int));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	tdepartment.Columns.Add( new DataColumn("server", typeof(string)));
	tdepartment.Columns.Add( new DataColumn("db", typeof(string)));
	tdepartment.Columns.Add( new DataColumn("userdep", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	Tables.Add(tdepartment);
	tdepartment.PrimaryKey =  new DataColumn[]{tdepartment.Columns["iddepartment"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new DataTable("geo_city");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_city.Columns.Add(C);
	tgeo_city.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tgeo_city.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_city.Columns.Add( new DataColumn("newcity", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("oldcity", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_city.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_city.Columns.Add( new DataColumn("title", typeof(string)));
	Tables.Add(tgeo_city);
	tgeo_city.PrimaryKey =  new DataColumn[]{tgeo_city.Columns["idcity"]};


	//////////////////// SERVICEPAYMENT /////////////////////////////////
	var tservicepayment= new DataTable("servicepayment");
	C= new DataColumn("yservreg", typeof(int));
	C.AllowDBNull=false;
	tservicepayment.Columns.Add(C);
	C= new DataColumn("nservreg", typeof(int));
	C.AllowDBNull=false;
	tservicepayment.Columns.Add(C);
	C= new DataColumn("ypay", typeof(int));
	C.AllowDBNull=false;
	tservicepayment.Columns.Add(C);
	C= new DataColumn("semesterpay", typeof(int));
	C.AllowDBNull=false;
	tservicepayment.Columns.Add(C);
	tservicepayment.Columns.Add( new DataColumn("payedamount", typeof(decimal)));
	tservicepayment.Columns.Add( new DataColumn("is_delivered", typeof(string)));
	tservicepayment.Columns.Add( new DataColumn("is_changed", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservicepayment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservicepayment.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservicepayment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservicepayment.Columns.Add(C);
	tservicepayment.Columns.Add( new DataColumn("is_blocked", typeof(string)));
	Tables.Add(tservicepayment);
	tservicepayment.PrimaryKey =  new DataColumn[]{tservicepayment.Columns["yservreg"], tservicepayment.Columns["nservreg"], tservicepayment.Columns["ypay"], tservicepayment.Columns["semesterpay"]};


	//////////////////// SERVICEAGENCY /////////////////////////////////
	var tserviceagency= new DataTable("serviceagency");
	C= new DataColumn("pa_code", typeof(string));
	C.AllowDBNull=false;
	tserviceagency.Columns.Add(C);
	C= new DataColumn("pa_title", typeof(string));
	C.AllowDBNull=false;
	tserviceagency.Columns.Add(C);
	C= new DataColumn("pa_cf", typeof(string));
	C.AllowDBNull=false;
	tserviceagency.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tserviceagency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tserviceagency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tserviceagency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tserviceagency.Columns.Add(C);
	tserviceagency.Columns.Add( new DataColumn("codicepaipa", typeof(string)));
	tserviceagency.Columns.Add( new DataColumn("codiceaooipa", typeof(string)));
	tserviceagency.Columns.Add( new DataColumn("codiceuoipa", typeof(string)));
	tserviceagency.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tserviceagency.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tserviceagency.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tserviceagency.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tserviceagency.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tserviceagency);
	tserviceagency.PrimaryKey =  new DataColumn[]{tserviceagency.Columns["pa_code"]};


	//////////////////// REFERENCERULE /////////////////////////////////
	var treferencerule= new DataTable("referencerule");
	C= new DataColumn("idreferencerule", typeof(string));
	C.AllowDBNull=false;
	treferencerule.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	treferencerule.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	treferencerule.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	treferencerule.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	treferencerule.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	treferencerule.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	treferencerule.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	treferencerule.Columns.Add(C);
	Tables.Add(treferencerule);
	treferencerule.PrimaryKey =  new DataColumn[]{treferencerule.Columns["idreferencerule"]};


	//////////////////// APFINANCIALACTIVITYVIEW /////////////////////////////////
	var tapfinancialactivityview= new DataTable("apfinancialactivityview");
	C= new DataColumn("idapfinancialactivity", typeof(int));
	C.AllowDBNull=false;
	tapfinancialactivityview.Columns.Add(C);
	C= new DataColumn("apfinancialactivitycode", typeof(string));
	C.AllowDBNull=false;
	tapfinancialactivityview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tapfinancialactivityview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tapfinancialactivityview.Columns.Add(C);
	tapfinancialactivityview.Columns.Add( new DataColumn("paridapfinancialactivity", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tapfinancialactivityview.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tapfinancialactivityview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tapfinancialactivityview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tapfinancialactivityview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tapfinancialactivityview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tapfinancialactivityview.Columns.Add(C);
	Tables.Add(tapfinancialactivityview);
	tapfinancialactivityview.PrimaryKey =  new DataColumn[]{tapfinancialactivityview.Columns["idapfinancialactivity"]};


	//////////////////// CONFERENTE /////////////////////////////////
	var tconferente= new DataTable("conferente");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tconferente.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tconferente.Columns.Add(C);
	tconferente.Columns.Add( new DataColumn("annotation", typeof(string)));
	tconferente.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tconferente.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tconferente.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tconferente.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tconferente.Columns.Add(C);
	tconferente.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tconferente.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tconferente.Columns.Add( new DataColumn("forename", typeof(string)));
	tconferente.Columns.Add( new DataColumn("gender", typeof(string)));
	tconferente.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tconferente.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tconferente.Columns.Add( new DataColumn("idcity", typeof(int)));
	tconferente.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tconferente.Columns.Add( new DataColumn("idnation", typeof(int)));
	tconferente.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tconferente.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tconferente.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tconferente.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tconferente.Columns.Add(C);
	tconferente.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tconferente.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tconferente.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tconferente.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tconferente.Columns.Add(C);
	tconferente.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tconferente.Columns.Add(C);
	tconferente.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tconferente.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tconferente.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tconferente.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tconferente.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tconferente.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tconferente.Columns.Add( new DataColumn("ccp", typeof(string)));
	tconferente.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tconferente.Columns.Add( new DataColumn("idexternal", typeof(int)));
	Tables.Add(tconferente);
	tconferente.PrimaryKey =  new DataColumn[]{tconferente.Columns["idreg"]};


	//////////////////// GEO_CITY_CONFERENTE /////////////////////////////////
	var tgeo_city_conferente= new DataTable("geo_city_conferente");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_city_conferente.Columns.Add(C);
	tgeo_city_conferente.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tgeo_city_conferente.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tgeo_city_conferente.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_city_conferente.Columns.Add( new DataColumn("newcity", typeof(int)));
	tgeo_city_conferente.Columns.Add( new DataColumn("oldcity", typeof(int)));
	tgeo_city_conferente.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_city_conferente.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_city_conferente.Columns.Add( new DataColumn("title", typeof(string)));
	Tables.Add(tgeo_city_conferente);
	tgeo_city_conferente.PrimaryKey =  new DataColumn[]{tgeo_city_conferente.Columns["idcity"]};


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
	tsorting01.Columns.Add( new DataColumn("email", typeof(string)));
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
	tsorting02.Columns.Add( new DataColumn("email", typeof(string)));
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
	tsorting03.Columns.Add( new DataColumn("email", typeof(string)));
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
	tsorting04.Columns.Add( new DataColumn("email", typeof(string)));
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
	tsorting05.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


	//////////////////// SERVICEREGISTRYKIND /////////////////////////////////
	var tserviceregistrykind= new DataTable("serviceregistrykind");
	C= new DataColumn("idserviceregistrykind", typeof(int));
	C.AllowDBNull=false;
	tserviceregistrykind.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tserviceregistrykind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tserviceregistrykind.Columns.Add(C);
	C= new DataColumn("totransmit", typeof(string));
	C.AllowDBNull=false;
	tserviceregistrykind.Columns.Add(C);
	C= new DataColumn("topublish", typeof(string));
	C.AllowDBNull=false;
	tserviceregistrykind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tserviceregistrykind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tserviceregistrykind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tserviceregistrykind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tserviceregistrykind.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tserviceregistrykind.Columns.Add(C);
	tserviceregistrykind.Columns.Add( new DataColumn("flagconferringstructure", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagordinancelink", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagauthorizingstructure", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagauthorizinglink", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagactreference", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagannouncementlink", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagotherservice", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagprofessionalservice", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagcomponentsvariable", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagcvattachment", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("employkind", typeof(string)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagemploytime", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("otherservice", typeof(string)));
	tserviceregistrykind.Columns.Add( new DataColumn("professionalservice", typeof(string)));
	tserviceregistrykind.Columns.Add( new DataColumn("componentsvariable", typeof(string)));
	tserviceregistrykind.Columns.Add( new DataColumn("flagcertinterestconflicts", typeof(short)));
	tserviceregistrykind.Columns.Add( new DataColumn("certinterestconflicts", typeof(string)));
	Tables.Add(tserviceregistrykind);
	tserviceregistrykind.PrimaryKey =  new DataColumn[]{tserviceregistrykind.Columns["idserviceregistrykind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{serviceregistry.Columns["yservreg"], serviceregistry.Columns["nservreg"]};
	var cChild = new []{servicepayment.Columns["yservreg"], servicepayment.Columns["nservreg"]};
	Relations.Add(new DataRelation("serviceregistryservicepayment213",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{serviceregistry.Columns["idsor05"]};
	Relations.Add(new DataRelation("FK_sorting05_serviceregistry",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{serviceregistry.Columns["idsor04"]};
	Relations.Add(new DataRelation("FK_sorting04_serviceregistry",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{serviceregistry.Columns["idsor03"]};
	Relations.Add(new DataRelation("FK_sorting03_serviceregistry",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{serviceregistry.Columns["idsor02"]};
	Relations.Add(new DataRelation("FK_sorting02_serviceregistry",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{serviceregistry.Columns["idsor01"]};
	Relations.Add(new DataRelation("FK_sorting01_serviceregistry",cPar,cChild,false));

	cPar = new []{geo_city_conferente.Columns["idcity"]};
	cChild = new []{serviceregistry.Columns["conferring_idcity"]};
	Relations.Add(new DataRelation("FK_geo_city_conferente_serviceregistry",cPar,cChild,false));

	cPar = new []{conferente.Columns["idreg"]};
	cChild = new []{serviceregistry.Columns["idconferring"]};
	Relations.Add(new DataRelation("FK_conferente_serviceregistry",cPar,cChild,false));

	cPar = new []{apfinancialactivityview.Columns["idapfinancialactivity"]};
	cChild = new []{serviceregistry.Columns["idapfinancialactivity"]};
	Relations.Add(new DataRelation("FK_apfinancialactivityview_serviceregistry",cPar,cChild,false));

	cPar = new []{referencerule.Columns["idreferencerule"]};
	cChild = new []{serviceregistry.Columns["idreferencerule"]};
	Relations.Add(new DataRelation("FK_referencerule_serviceregistry",cPar,cChild,false));

	cPar = new []{acquirekind.Columns["idacquirekind"], acquirekind.Columns["ayear"]};
	cChild = new []{serviceregistry.Columns["idacquirekind"], serviceregistry.Columns["yservreg"]};
	Relations.Add(new DataRelation("acquirekindserviceregistry",cPar,cChild,false));

	cPar = new []{financialactivity.Columns["idfinancialactivity"], financialactivity.Columns["ayear"]};
	cChild = new []{serviceregistry.Columns["idfinancialactivity"], serviceregistry.Columns["yservreg"]};
	Relations.Add(new DataRelation("financialactivityserviceregistry",cPar,cChild,false));

	cPar = new []{apcontractkind.Columns["idapcontractkind"], apcontractkind.Columns["ayear"]};
	cChild = new []{serviceregistry.Columns["idapcontractkind"], serviceregistry.Columns["yservreg"]};
	Relations.Add(new DataRelation("apcontractkindserviceregistry",cPar,cChild,false));

	cPar = new []{serviceagency.Columns["pa_code"]};
	cChild = new []{serviceregistry.Columns["pa_code"]};
	Relations.Add(new DataRelation("serviceagencyserviceregistry",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{serviceregistry.Columns["idcity"]};
	Relations.Add(new DataRelation("serviceregistrygeo_city63",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{serviceregistry.Columns["idreg"]};
	Relations.Add(new DataRelation("registryserviceregistry65",cPar,cChild,false));

	cPar = new []{department.Columns["iddepartment"]};
	cChild = new []{serviceregistry.Columns["iddepartment"]};
	Relations.Add(new DataRelation("departmentserviceregistry32",cPar,cChild,false));

	cPar = new []{apactivitykind.Columns["idapactivitykind"]};
	cChild = new []{serviceregistry.Columns["idapactivitykind"]};
	Relations.Add(new DataRelation("apactivitykindserviceregistry",cPar,cChild,false));

	cPar = new []{apregistrykind.Columns["idapregistrykind"]};
	cChild = new []{serviceregistry.Columns["idapregistrykind"]};
	Relations.Add(new DataRelation("apregistrykindserviceregistry",cPar,cChild,false));

	cPar = new []{consultingkind.Columns["idconsultingkind"]};
	cChild = new []{serviceregistry.Columns["idconsultingkind"]};
	Relations.Add(new DataRelation("consultingkindserviceregistry",cPar,cChild,false));

	cPar = new []{apmanager.Columns["idapmanager"]};
	cChild = new []{serviceregistry.Columns["idapmanager"]};
	Relations.Add(new DataRelation("apmanagerserviceregistry12",cPar,cChild,false));

	cPar = new []{serviceregistrykind.Columns["idserviceregistrykind"]};
	cChild = new []{serviceregistry.Columns["idserviceregistrykind"]};
	Relations.Add(new DataRelation("serviceregistrykind_serviceregistry",cPar,cChild,false));

	#endregion

}
}
}
