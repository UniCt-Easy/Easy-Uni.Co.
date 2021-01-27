
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
namespace servicetrasmission_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Assegnazione Automatica del Pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable servicepayment 		=> Tables["servicepayment"];

	///<summary>
	///Banca dati degli Incarichi - Anagrafe Prestazioni e Pubblicazione sito web istituzionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable serviceregistry 		=> Tables["serviceregistry"];

	///<summary>
	///Trasmissione Anagrafe delle Prestazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable servicetrasmission 		=> Tables["servicetrasmission"];

	///<summary>
	///Tipo trasmissione anagrafe prestazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable servicetrasmissionkind 		=> Tables["servicetrasmissionkind"];

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


	//////////////////// SERVICEREGISTRY /////////////////////////////////
	var tserviceregistry= new DataTable("serviceregistry");
	C= new DataColumn("yservreg", typeof(int));
	C.AllowDBNull=false;
	tserviceregistry.Columns.Add(C);
	C= new DataColumn("nservreg", typeof(int));
	C.AllowDBNull=false;
	tserviceregistry.Columns.Add(C);
	tserviceregistry.Columns.Add( new DataColumn("id_service", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("employkind", typeof(string)));
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
	tserviceregistry.Columns.Add( new DataColumn("codicepaipa", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("codiceaooipa", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("codiceuoipa", typeof(string)));
	tserviceregistry.Columns.Add( new DataColumn("dichiarazione_incarichi", typeof(Byte[])));
	Tables.Add(tserviceregistry);
	tserviceregistry.PrimaryKey =  new DataColumn[]{tserviceregistry.Columns["yservreg"], tserviceregistry.Columns["nservreg"]};


	//////////////////// SERVICETRASMISSION /////////////////////////////////
	var tservicetrasmission= new DataTable("servicetrasmission");
	C= new DataColumn("idtrasmission", typeof(int));
	C.AllowDBNull=false;
	tservicetrasmission.Columns.Add(C);
	tservicetrasmission.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tservicetrasmission.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservicetrasmission.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservicetrasmission.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservicetrasmission.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservicetrasmission.Columns.Add(C);
	tservicetrasmission.Columns.Add( new DataColumn("idservicetrasmissionkind", typeof(short)));
	tservicetrasmission.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tservicetrasmission.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tservicetrasmission.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tservicetrasmission.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tservicetrasmission.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tservicetrasmission);
	tservicetrasmission.PrimaryKey =  new DataColumn[]{tservicetrasmission.Columns["idtrasmission"]};


	//////////////////// SERVICETRASMISSIONKIND /////////////////////////////////
	var tservicetrasmissionkind= new DataTable("servicetrasmissionkind");
	C= new DataColumn("idservicetrasmissionkind", typeof(short));
	C.AllowDBNull=false;
	tservicetrasmissionkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservicetrasmissionkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservicetrasmissionkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tservicetrasmissionkind.Columns.Add(C);
	tservicetrasmissionkind.Columns.Add( new DataColumn("listingorder", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservicetrasmissionkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservicetrasmissionkind.Columns.Add(C);
	Tables.Add(tservicetrasmissionkind);
	tservicetrasmissionkind.PrimaryKey =  new DataColumn[]{tservicetrasmissionkind.Columns["idservicetrasmissionkind"]};


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


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting02.Columns["idsor"]};
	var cChild = new []{servicetrasmission.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_servicetrasmission",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{servicetrasmission.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_servicetrasmission",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{servicetrasmission.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_servicetrasmission",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{servicetrasmission.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_servicetrasmission",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{servicetrasmission.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_servicetrasmission",cPar,cChild,false));

	cPar = new []{servicetrasmissionkind.Columns["idservicetrasmissionkind"]};
	cChild = new []{servicetrasmission.Columns["idservicetrasmissionkind"]};
	Relations.Add(new DataRelation("FK_servicetrasmissionkind_servicetrasmission",cPar,cChild,false));

	cPar = new []{serviceregistry.Columns["yservreg"], serviceregistry.Columns["nservreg"]};
	cChild = new []{servicepayment.Columns["yservreg"], servicepayment.Columns["nservreg"]};
	Relations.Add(new DataRelation("serviceregistry_servicepayment",cPar,cChild,false));

	#endregion

}
}
}
