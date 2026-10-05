/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_prova_doc"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_prova_doc: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias4 		=> (MetaTable)Tables["registry_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias3 		=> (MetaTable)Tables["registry_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prenotappello 		=> (MetaTable)Tables["prenotappello"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable commissmembrokind 		=> (MetaTable)Tables["commissmembrokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable commissregistry_docenti 		=> (MetaTable)Tables["commissregistry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable commiss 		=> (MetaTable)Tables["commiss"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable valutazionekinddefaultview 		=> (MetaTable)Tables["valutazionekinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformappelloview 		=> (MetaTable)Tables["attivformappelloview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prova 		=> (MetaTable)Tables["prova"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_prova_doc(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_prova_doc (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_prova_doc";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_prova_doc.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTOESITO /////////////////////////////////
	var tsostenimentoesito= new MetaTable("sostenimentoesito");
	tsostenimentoesito.defineColumn("active", typeof(string),false);
	tsostenimentoesito.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimentoesito.defineColumn("title", typeof(string),false);
	Tables.Add(tsostenimentoesito);
	tsostenimentoesito.defineKey("idsostenimentoesito");

	//////////////////// REGISTRY_ALIAS4 /////////////////////////////////
	var tregistry_alias4= new MetaTable("registry_alias4");
	tregistry_alias4.defineColumn("active", typeof(string),false);
	tregistry_alias4.defineColumn("idreg", typeof(int),false);
	tregistry_alias4.defineColumn("title", typeof(string),false);
	tregistry_alias4.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias4);
	tregistry_alias4.defineKey("idreg");

	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("ct", typeof(DateTime),false);
	tsostenimento.defineColumn("cu", typeof(string),false);
	tsostenimento.defineColumn("data", typeof(DateTime),false);
	tsostenimento.defineColumn("domande", typeof(string));
	tsostenimento.defineColumn("ects", typeof(int));
	tsostenimento.defineColumn("giudizio", typeof(string));
	tsostenimento.defineColumn("idappello", typeof(int),false);
	tsostenimento.defineColumn("idattivform", typeof(int));
	tsostenimento.defineColumn("idcorsostudio", typeof(int));
	tsostenimento.defineColumn("iddidprog", typeof(int));
	tsostenimento.defineColumn("idiscrizione", typeof(int));
	tsostenimento.defineColumn("idprova", typeof(int),false);
	tsostenimento.defineColumn("idreg", typeof(int),false);
	tsostenimento.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento.defineColumn("idtitolostudio", typeof(int));
	tsostenimento.defineColumn("insecod", typeof(string));
	tsostenimento.defineColumn("insedesc", typeof(string));
	tsostenimento.defineColumn("livello", typeof(string));
	tsostenimento.defineColumn("lt", typeof(DateTime),false);
	tsostenimento.defineColumn("lu", typeof(string),false);
	tsostenimento.defineColumn("paridsostenimento", typeof(int));
	tsostenimento.defineColumn("protanno", typeof(int));
	tsostenimento.defineColumn("protnumero", typeof(int));
	tsostenimento.defineColumn("voto", typeof(decimal));
	tsostenimento.defineColumn("votolode", typeof(string));
	tsostenimento.defineColumn("votosu", typeof(int));
	tsostenimento.defineColumn("!idreg_registry_title", typeof(string));
	tsostenimento.defineColumn("!idsostenimentoesito_sostenimentoesito_title", typeof(string));
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idappello", "idprova", "idreg", "idsostenimento");

	//////////////////// REGISTRY_ALIAS3 /////////////////////////////////
	var tregistry_alias3= new MetaTable("registry_alias3");
	tregistry_alias3.defineColumn("active", typeof(string),false);
	tregistry_alias3.defineColumn("idreg", typeof(int),false);
	tregistry_alias3.defineColumn("title", typeof(string),false);
	tregistry_alias3.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias3);
	tregistry_alias3.defineKey("idreg");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idsede", typeof(int),false);
	tdidprog.defineColumn("title", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ISCRIZIONE /////////////////////////////////
	var tiscrizione= new MetaTable("iscrizione");
	tiscrizione.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione.defineColumn("iddidprog", typeof(int),false);
	tiscrizione.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// PRENOTAPPELLO /////////////////////////////////
	var tprenotappello= new MetaTable("prenotappello");
	tprenotappello.defineColumn("ct", typeof(DateTime),false);
	tprenotappello.defineColumn("cu", typeof(string),false);
	tprenotappello.defineColumn("data", typeof(DateTime),false);
	tprenotappello.defineColumn("idappello", typeof(int),false);
	tprenotappello.defineColumn("idattivform", typeof(int),false);
	tprenotappello.defineColumn("idiscrizione", typeof(int),false);
	tprenotappello.defineColumn("idpianostudio", typeof(int),false);
	tprenotappello.defineColumn("idpianostudioattivform", typeof(int),false);
	tprenotappello.defineColumn("idprenotappello", typeof(int),false);
	tprenotappello.defineColumn("idprova", typeof(int),false);
	tprenotappello.defineColumn("idreg", typeof(int),false);
	tprenotappello.defineColumn("lt", typeof(DateTime),false);
	tprenotappello.defineColumn("lu", typeof(string),false);
	tprenotappello.defineColumn("!idiscrizione_iscrizione_iddidprog_title", typeof(string));
	tprenotappello.defineColumn("!idiscrizione_iscrizione_iddidprog_aa", typeof(string));
	tprenotappello.defineColumn("!idiscrizione_iscrizione_iddidprog_idsede", typeof(int));
	tprenotappello.defineColumn("!idreg_registry_title", typeof(string));
	Tables.Add(tprenotappello);
	tprenotappello.defineKey("idappello", "idattivform", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idprenotappello", "idprova", "idreg");

	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("codice", typeof(string),false);
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("active", typeof(string));
	tstruttura.defineColumn("codice", typeof(string));
	tstruttura.defineColumn("codiceipa", typeof(string));
	tstruttura.defineColumn("ct", typeof(DateTime),false);
	tstruttura.defineColumn("cu", typeof(string),false);
	tstruttura.defineColumn("email", typeof(string));
	tstruttura.defineColumn("fax", typeof(string));
	tstruttura.defineColumn("idaoo", typeof(int));
	tstruttura.defineColumn("idreg", typeof(int));
	tstruttura.defineColumn("idsede", typeof(int),false);
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("idupb", typeof(string));
	tstruttura.defineColumn("lt", typeof(DateTime),false);
	tstruttura.defineColumn("lu", typeof(string),false);
	tstruttura.defineColumn("paridstruttura", typeof(int));
	tstruttura.defineColumn("pesoindicatori", typeof(decimal));
	tstruttura.defineColumn("pesoobiettivi", typeof(decimal));
	tstruttura.defineColumn("pesoprogaltreuo", typeof(decimal));
	tstruttura.defineColumn("pesoproguo", typeof(decimal));
	tstruttura.defineColumn("telefono", typeof(string));
	tstruttura.defineColumn("title", typeof(string));
	tstruttura.defineColumn("title_en", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("acronim", typeof(string));
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime));
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("code", typeof(string));
	tregistry.defineColumn("codicemiur", typeof(string));
	tregistry.defineColumn("codiceustat", typeof(string));
	tregistry.defineColumn("ct", typeof(DateTime),false);
	tregistry.defineColumn("cu", typeof(string),false);
	tregistry.defineColumn("email_fe", typeof(string));
	tregistry.defineColumn("extension", typeof(string));
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("flag_pa", typeof(string));
	tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry.defineColumn("foreigncf", typeof(string));
	tregistry.defineColumn("forename", typeof(string),false);
	tregistry.defineColumn("gender", typeof(string),false);
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idanpr", typeof(string));
	tregistry.defineColumn("idateco", typeof(int));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistry.defineColumn("idistitutokind", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnace", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("idnaturagiur", typeof(int));
	tregistry.defineColumn("idnumerodip", typeof(int));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idreg_istituti", typeof(int));
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("idsasd", typeof(int));
	tregistry.defineColumn("idstruttura", typeof(int));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("indicebibliometrico", typeof(int));
	tregistry.defineColumn("institutionalcode", typeof(string));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("ipa_perlapa", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("pic", typeof(string));
	tregistry.defineColumn("referencenumber", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("ricevimento", typeof(string));
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("soggiorno", typeof(string));
	tregistry.defineColumn("surname", typeof(string),false);
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("title_en", typeof(string));
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// COMMISSMEMBROKIND /////////////////////////////////
	var tcommissmembrokind= new MetaTable("commissmembrokind");
	tcommissmembrokind.defineColumn("active", typeof(string),false);
	tcommissmembrokind.defineColumn("idcommissmembrokind", typeof(int),false);
	tcommissmembrokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcommissmembrokind);
	tcommissmembrokind.defineKey("idcommissmembrokind");

	//////////////////// COMMISSREGISTRY_DOCENTI /////////////////////////////////
	var tcommissregistry_docenti= new MetaTable("commissregistry_docenti");
	tcommissregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tcommissregistry_docenti.defineColumn("cu", typeof(string),false);
	tcommissregistry_docenti.defineColumn("idappello", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idcommiss", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idcommissmembrokind", typeof(int));
	tcommissregistry_docenti.defineColumn("idcorsostudio", typeof(int));
	tcommissregistry_docenti.defineColumn("iddidprog", typeof(int));
	tcommissregistry_docenti.defineColumn("idprova", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idreg_docenti", typeof(int),false);
	tcommissregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tcommissregistry_docenti.defineColumn("lu", typeof(string),false);
	tcommissregistry_docenti.defineColumn("!idcommissmembrokind_commissmembrokind_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_sasd_codice", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_sasd_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_struttura_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_struttura_strutturakind_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_cf", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_alias1_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_p_iva", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_active", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_idanpr", typeof(string));
	Tables.Add(tcommissregistry_docenti);
	tcommissregistry_docenti.defineKey("idappello", "idcommiss", "idprova", "idreg_docenti");

	//////////////////// REGISTRYDOCENTIVIEW /////////////////////////////////
	var tregistrydocentiview= new MetaTable("registrydocentiview");
	tregistrydocentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydocentiview.defineColumn("idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydocentiview);
	tregistrydocentiview.defineKey("idreg");

	//////////////////// COMMISS /////////////////////////////////
	var tcommiss= new MetaTable("commiss");
	tcommiss.defineColumn("ct", typeof(DateTime),false);
	tcommiss.defineColumn("cu", typeof(string),false);
	tcommiss.defineColumn("idappello", typeof(int),false);
	tcommiss.defineColumn("idcommiss", typeof(int),false);
	tcommiss.defineColumn("idcorsostudio", typeof(int));
	tcommiss.defineColumn("iddidprog", typeof(int));
	tcommiss.defineColumn("idprova", typeof(int),false);
	tcommiss.defineColumn("idreg_docenti", typeof(int),false);
	tcommiss.defineColumn("lt", typeof(DateTime),false);
	tcommiss.defineColumn("lu", typeof(string),false);
	Tables.Add(tcommiss);
	tcommiss.defineKey("idappello", "idcommiss", "idprova");

	//////////////////// VALUTAZIONEKINDDEFAULTVIEW /////////////////////////////////
	var tvalutazionekinddefaultview= new MetaTable("valutazionekinddefaultview");
	tvalutazionekinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tvalutazionekinddefaultview.defineColumn("idvalutazionekind", typeof(int),false);
	tvalutazionekinddefaultview.defineColumn("title", typeof(string),false);
	tvalutazionekinddefaultview.defineColumn("valutazionekind_active", typeof(string));
	tvalutazionekinddefaultview.defineColumn("valutazionekind_ct", typeof(DateTime),false);
	tvalutazionekinddefaultview.defineColumn("valutazionekind_cu", typeof(string),false);
	tvalutazionekinddefaultview.defineColumn("valutazionekind_description", typeof(string));
	tvalutazionekinddefaultview.defineColumn("valutazionekind_lt", typeof(DateTime),false);
	tvalutazionekinddefaultview.defineColumn("valutazionekind_lu", typeof(string),false);
	tvalutazionekinddefaultview.defineColumn("valutazionekind_sortcode", typeof(int),false);
	Tables.Add(tvalutazionekinddefaultview);
	tvalutazionekinddefaultview.defineKey("idvalutazionekind");

	//////////////////// ATTIVFORMAPPELLOVIEW /////////////////////////////////
	var tattivformappelloview= new MetaTable("attivformappelloview");
	tattivformappelloview.defineColumn("aa", typeof(string),false);
	tattivformappelloview.defineColumn("attivform_ct", typeof(DateTime),false);
	tattivformappelloview.defineColumn("attivform_cu", typeof(string),false);
	tattivformappelloview.defineColumn("attivform_iddidproggrupp", typeof(int));
	tattivformappelloview.defineColumn("attivform_lt", typeof(DateTime),false);
	tattivformappelloview.defineColumn("attivform_lu", typeof(string),false);
	tattivformappelloview.defineColumn("attivform_obbform", typeof(string));
	tattivformappelloview.defineColumn("attivform_obbform_en", typeof(string));
	tattivformappelloview.defineColumn("attivform_sortcode", typeof(int));
	tattivformappelloview.defineColumn("attivform_start", typeof(DateTime));
	tattivformappelloview.defineColumn("attivform_stop", typeof(DateTime));
	tattivformappelloview.defineColumn("attivform_tipovalutaz", typeof(string));
	tattivformappelloview.defineColumn("didprog_aa", typeof(string));
	tattivformappelloview.defineColumn("didprog_idsede", typeof(int));
	tattivformappelloview.defineColumn("didprog_title", typeof(string));
	tattivformappelloview.defineColumn("didproganno_anno", typeof(int));
	tattivformappelloview.defineColumn("didproggrupp_title", typeof(string));
	tattivformappelloview.defineColumn("dropdown_title", typeof(string),false);
	tattivformappelloview.defineColumn("idattivform", typeof(int),false);
	tattivformappelloview.defineColumn("idcorsostudio", typeof(int),false);
	tattivformappelloview.defineColumn("iddidprog", typeof(int),false);
	tattivformappelloview.defineColumn("iddidproganno", typeof(int),false);
	tattivformappelloview.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformappelloview.defineColumn("iddidprogori", typeof(int),false);
	tattivformappelloview.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformappelloview.defineColumn("idinsegn", typeof(int),false);
	tattivformappelloview.defineColumn("idinsegninteg", typeof(int));
	tattivformappelloview.defineColumn("idsede", typeof(int),false);
	tattivformappelloview.defineColumn("insegn_codice", typeof(string));
	tattivformappelloview.defineColumn("insegn_denominazione", typeof(string));
	tattivformappelloview.defineColumn("insegninteg_codice", typeof(string));
	tattivformappelloview.defineColumn("insegninteg_denominazione", typeof(string));
	tattivformappelloview.defineColumn("sede_attivform_title", typeof(string));
	tattivformappelloview.defineColumn("sede_title", typeof(string));
	tattivformappelloview.defineColumn("title", typeof(string));
	Tables.Add(tattivformappelloview);
	tattivformappelloview.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// PROVA /////////////////////////////////
	var tprova= new MetaTable("prova");
	tprova.defineColumn("ct", typeof(DateTime),false);
	tprova.defineColumn("cu", typeof(string),false);
	tprova.defineColumn("idappello", typeof(int),false);
	tprova.defineColumn("idattivform", typeof(int));
	tprova.defineColumn("idcorsostudio", typeof(int));
	tprova.defineColumn("iddidprog", typeof(int));
	tprova.defineColumn("idprova", typeof(int),false);
	tprova.defineColumn("idquestionario", typeof(int));
	tprova.defineColumn("idvalutazionekind", typeof(int));
	tprova.defineColumn("lt", typeof(DateTime),false);
	tprova.defineColumn("lu", typeof(string),false);
	tprova.defineColumn("programma", typeof(string));
	tprova.defineColumn("start", typeof(DateTime),false);
	tprova.defineColumn("stop", typeof(DateTime),false);
	tprova.defineColumn("title", typeof(string),false);
	Tables.Add(tprova);
	tprova.defineKey("idappello", "idprova");

	#endregion


	#region DataRelation creation
	var cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"], prova.Columns["idattivform"]};
	var cChild = new []{sostenimento.Columns["idappello"], sostenimento.Columns["idprova"], sostenimento.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_sostenimento_prova_idappello-idprova-idattivform",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{registry_alias4.Columns["idreg"]};
	cChild = new []{sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_registry_alias4_idreg",cPar,cChild,false));

	cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"]};
	cChild = new []{prenotappello.Columns["idappello"], prenotappello.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_prenotappello_prova_idappello-idprova",cPar,cChild,false));

	cPar = new []{registry_alias3.Columns["idreg"]};
	cChild = new []{prenotappello.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_prenotappello_registry_alias3_idreg",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"]};
	cChild = new []{prenotappello.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_prenotappello_iscrizione_idiscrizione",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"]};
	cChild = new []{commiss.Columns["idappello"], commiss.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_commiss_prova_idappello-idprova",cPar,cChild,false));

	cPar = new []{commiss.Columns["idappello"], commiss.Columns["idcommiss"], commiss.Columns["idprova"]};
	cChild = new []{commissregistry_docenti.Columns["idappello"], commissregistry_docenti.Columns["idcommiss"], commissregistry_docenti.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_commissregistry_docenti_commiss_idappello-idcommiss-idprova",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{commissregistry_docenti.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_commissregistry_docenti_registry_idreg_docenti",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{registry.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_registry_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{registry.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_registry_sasd_idsasd",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_registry_registry_alias1_idreg_istituti",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{commissmembrokind.Columns["idcommissmembrokind"]};
	cChild = new []{commissregistry_docenti.Columns["idcommissmembrokind"]};
	Relations.Add(new DataRelation("FK_commissregistry_docenti_commissmembrokind_idcommissmembrokind",cPar,cChild,false));

	cPar = new []{registrydocentiview.Columns["idreg"]};
	cChild = new []{commiss.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_commiss_registrydocentiview_idreg_docenti",cPar,cChild,false));

	cPar = new []{valutazionekinddefaultview.Columns["idvalutazionekind"]};
	cChild = new []{prova.Columns["idvalutazionekind"]};
	Relations.Add(new DataRelation("FK_prova_valutazionekinddefaultview_idvalutazionekind",cPar,cChild,false));

	cPar = new []{attivformappelloview.Columns["idattivform"]};
	cChild = new []{prova.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_prova_attivformappelloview_idattivform",cPar,cChild,false));

	#endregion

}
}
}
