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
[System.Xml.Serialization.XmlRoot("dsmeta_convalidatoview_seganagstu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_convalidatoview_seganagstu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentodefaultview 		=> (MetaTable)Tables["sostenimentodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudiodocentiview 		=> (MetaTable)Tables["titolostudiodocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesitodefaultview 		=> (MetaTable)Tables["sostenimentoesitodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable provadefaultview 		=> (MetaTable)Tables["provadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformdefaultview 		=> (MetaTable)Tables["attivformdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appellodefaultview 		=> (MetaTable)Tables["appellodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidatoview 		=> (MetaTable)Tables["convalidatoview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_convalidatoview_seganagstu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_convalidatoview_seganagstu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_convalidatoview_seganagstu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_convalidatoview_seganagstu.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTODEFAULTVIEW /////////////////////////////////
	var tsostenimentodefaultview= new MetaTable("sostenimentodefaultview");
	tsostenimentodefaultview.defineColumn("annoaccademico_aa", typeof(string));
	tsostenimentodefaultview.defineColumn("annoaccademico_titolostudio_aa", typeof(string));
	tsostenimentodefaultview.defineColumn("attivform_title", typeof(string));
	tsostenimentodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsostenimentodefaultview.defineColumn("idappello", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idattivform", typeof(int));
	tsostenimentodefaultview.defineColumn("idiscrizione", typeof(int));
	tsostenimentodefaultview.defineColumn("idprova", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idreg", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idsostenimento", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idtitolostudio", typeof(int));
	tsostenimentodefaultview.defineColumn("iscrizione_anno", typeof(int));
	tsostenimentodefaultview.defineColumn("iscrizione_iddidprog", typeof(int));
	tsostenimentodefaultview.defineColumn("istattitolistudio_titolo", typeof(string));
	tsostenimentodefaultview.defineColumn("registry_title", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_ct", typeof(DateTime),false);
	tsostenimentodefaultview.defineColumn("sostenimento_cu", typeof(string),false);
	tsostenimentodefaultview.defineColumn("sostenimento_data", typeof(DateTime),false);
	tsostenimentodefaultview.defineColumn("sostenimento_domande", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_ects", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_giudizio", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_idcorsostudio", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_iddidprog", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_idsostenimentoesito", typeof(int),false);
	tsostenimentodefaultview.defineColumn("sostenimento_insecod", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_insedesc", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_livello", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_lt", typeof(DateTime),false);
	tsostenimentodefaultview.defineColumn("sostenimento_lu", typeof(string),false);
	tsostenimentodefaultview.defineColumn("sostenimento_paridsostenimento", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_protanno", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_protnumero", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_voto", typeof(decimal));
	tsostenimentodefaultview.defineColumn("sostenimento_votolode", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_votosu", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimentoesito_title", typeof(string));
	tsostenimentodefaultview.defineColumn("titolostudio_voto", typeof(int));
	tsostenimentodefaultview.defineColumn("titolostudio_votolode", typeof(string));
	tsostenimentodefaultview.defineColumn("titolostudio_votosu", typeof(int));
	Tables.Add(tsostenimentodefaultview);
	tsostenimentodefaultview.defineKey("idappello", "idprova", "idreg", "idsostenimento");

	//////////////////// TITOLOSTUDIODOCENTIVIEW /////////////////////////////////
	var ttitolostudiodocentiview= new MetaTable("titolostudiodocentiview");
	ttitolostudiodocentiview.defineColumn("aa", typeof(string),false);
	ttitolostudiodocentiview.defineColumn("attach_filename", typeof(string));
	ttitolostudiodocentiview.defineColumn("dropdown_title", typeof(string),false);
	ttitolostudiodocentiview.defineColumn("idattach", typeof(int));
	ttitolostudiodocentiview.defineColumn("idistattitolistudio", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("idreg", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("idreg_istituti", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("idtitolostudio", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("istattitolistudio_titolo", typeof(string));
	ttitolostudiodocentiview.defineColumn("registryistituti_title", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_conseguito", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_ct", typeof(DateTime));
	ttitolostudiodocentiview.defineColumn("titolostudio_cu", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_data", typeof(DateTime));
	ttitolostudiodocentiview.defineColumn("titolostudio_giudizio", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_lt", typeof(DateTime));
	ttitolostudiodocentiview.defineColumn("titolostudio_lu", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_voto", typeof(int));
	ttitolostudiodocentiview.defineColumn("titolostudio_votolode", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_votosu", typeof(int));
	Tables.Add(ttitolostudiodocentiview);
	ttitolostudiodocentiview.defineKey("idreg", "idtitolostudio");

	//////////////////// SOSTENIMENTOESITODEFAULTVIEW /////////////////////////////////
	var tsostenimentoesitodefaultview= new MetaTable("sostenimentoesitodefaultview");
	tsostenimentoesitodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsostenimentoesitodefaultview.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimentoesitodefaultview.defineColumn("sostenimentoesito_active", typeof(string));
	tsostenimentoesitodefaultview.defineColumn("sostenimentoesito_description", typeof(string),false);
	tsostenimentoesitodefaultview.defineColumn("sostenimentoesito_lt", typeof(DateTime));
	tsostenimentoesitodefaultview.defineColumn("sostenimentoesito_lu", typeof(string));
	tsostenimentoesitodefaultview.defineColumn("sostenimentoesito_sortcode", typeof(int),false);
	tsostenimentoesitodefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tsostenimentoesitodefaultview);
	tsostenimentoesitodefaultview.defineKey("idsostenimentoesito");

	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("accmotive_codemotive", typeof(string));
	tregistrydefaultview.defineColumn("accmotive_registry_codemotive", typeof(string));
	tregistrydefaultview.defineColumn("accmotive_registry_title", typeof(string));
	tregistrydefaultview.defineColumn("accmotive_title", typeof(string));
	tregistrydefaultview.defineColumn("category_description", typeof(string));
	tregistrydefaultview.defineColumn("centralizedcategory_description", typeof(string));
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("geo_city_title", typeof(string));
	tregistrydefaultview.defineColumn("geo_nation_title", typeof(string));
	tregistrydefaultview.defineColumn("idaccmotivecredit", typeof(string));
	tregistrydefaultview.defineColumn("idaccmotivedebit", typeof(string));
	tregistrydefaultview.defineColumn("idcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcity", typeof(int));
	tregistrydefaultview.defineColumn("idnation", typeof(int));
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("idregistryclass", typeof(string));
	tregistrydefaultview.defineColumn("idtitle", typeof(string));
	tregistrydefaultview.defineColumn("maritalstatus_description", typeof(string));
	tregistrydefaultview.defineColumn("registry_active", typeof(string));
	tregistrydefaultview.defineColumn("registry_annotation", typeof(string));
	tregistrydefaultview.defineColumn("registry_authorization_free", typeof(string));
	tregistrydefaultview.defineColumn("registry_badgecode", typeof(string));
	tregistrydefaultview.defineColumn("registry_birthdate", typeof(DateTime));
	tregistrydefaultview.defineColumn("registry_ccp", typeof(string));
	tregistrydefaultview.defineColumn("registry_cf", typeof(string));
	tregistrydefaultview.defineColumn("registry_ct", typeof(DateTime),false);
	tregistrydefaultview.defineColumn("registry_cu", typeof(string),false);
	tregistrydefaultview.defineColumn("registry_email_fe", typeof(string));
	tregistrydefaultview.defineColumn("registry_extension", typeof(string));
	tregistrydefaultview.defineColumn("registry_extmatricula", typeof(string));
	tregistrydefaultview.defineColumn("registry_flag_pa", typeof(string));
	tregistrydefaultview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistrydefaultview.defineColumn("registry_foreigncf", typeof(string));
	tregistrydefaultview.defineColumn("registry_forename", typeof(string));
	tregistrydefaultview.defineColumn("registry_gender", typeof(string));
	tregistrydefaultview.defineColumn("registry_idexternal", typeof(int));
	tregistrydefaultview.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistrydefaultview.defineColumn("registry_idregistrykind", typeof(int));
	tregistrydefaultview.defineColumn("registry_ipa_fe", typeof(string));
	tregistrydefaultview.defineColumn("registry_ipa_perlapa", typeof(string));
	tregistrydefaultview.defineColumn("registry_location", typeof(string));
	tregistrydefaultview.defineColumn("registry_lt", typeof(DateTime),false);
	tregistrydefaultview.defineColumn("registry_lu", typeof(string),false);
	tregistrydefaultview.defineColumn("registry_maritalsurname", typeof(string));
	tregistrydefaultview.defineColumn("registry_multi_cf", typeof(string));
	tregistrydefaultview.defineColumn("registry_p_iva", typeof(string));
	tregistrydefaultview.defineColumn("registry_pec_fe", typeof(string));
	tregistrydefaultview.defineColumn("registry_rtf", typeof(Byte[]));
	tregistrydefaultview.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistrydefaultview.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistrydefaultview.defineColumn("registry_surname", typeof(string));
	tregistrydefaultview.defineColumn("registry_toredirect", typeof(int));
	tregistrydefaultview.defineColumn("registry_txt", typeof(string));
	tregistrydefaultview.defineColumn("registryclass_description", typeof(string));
	tregistrydefaultview.defineColumn("registrykind_description", typeof(string));
	tregistrydefaultview.defineColumn("residence", typeof(int),false);
	tregistrydefaultview.defineColumn("residence_description", typeof(string));
	tregistrydefaultview.defineColumn("title", typeof(string),false);
	tregistrydefaultview.defineColumn("title_description", typeof(string));
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// PROVADEFAULTVIEW /////////////////////////////////
	var tprovadefaultview= new MetaTable("provadefaultview");
	tprovadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tprovadefaultview.defineColumn("idappello", typeof(int),false);
	tprovadefaultview.defineColumn("idprova", typeof(int),false);
	tprovadefaultview.defineColumn("idquestionario", typeof(int));
	tprovadefaultview.defineColumn("idreg_docenti", typeof(int));
	tprovadefaultview.defineColumn("prova_ct", typeof(DateTime),false);
	tprovadefaultview.defineColumn("prova_cu", typeof(string),false);
	tprovadefaultview.defineColumn("prova_idattivform", typeof(int));
	tprovadefaultview.defineColumn("prova_idcorsostudio", typeof(int));
	tprovadefaultview.defineColumn("prova_iddidprog", typeof(int));
	tprovadefaultview.defineColumn("prova_idvalutazionekind", typeof(int));
	tprovadefaultview.defineColumn("prova_lt", typeof(DateTime),false);
	tprovadefaultview.defineColumn("prova_lu", typeof(string),false);
	tprovadefaultview.defineColumn("prova_programma", typeof(string));
	tprovadefaultview.defineColumn("prova_start", typeof(DateTime));
	tprovadefaultview.defineColumn("prova_stop", typeof(DateTime));
	tprovadefaultview.defineColumn("questionario_title", typeof(string));
	tprovadefaultview.defineColumn("title", typeof(string));
	tprovadefaultview.defineColumn("valutazionekind_title", typeof(string));
	Tables.Add(tprovadefaultview);
	tprovadefaultview.defineKey("idappello", "idprova");

	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("anno", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_aa", typeof(string));
	tiscrizionedefaultview.defineColumn("didprog_idsede", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_title", typeof(string));
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizionedefaultview.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizionedefaultview.defineColumn("registry_title", typeof(string));
	tiscrizionedefaultview.defineColumn("sede_title", typeof(string));
	Tables.Add(tiscrizionedefaultview);
	tiscrizionedefaultview.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("aa", typeof(string));
	tdidprogdefaultview.defineColumn("appellokind_title", typeof(string));
	tdidprogdefaultview.defineColumn("areadidattica_title", typeof(string));
	tdidprogdefaultview.defineColumn("convenzione_title", typeof(string));
	tdidprogdefaultview.defineColumn("corsostudio_annoistituz", typeof(int));
	tdidprogdefaultview.defineColumn("corsostudio_title", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_annosolare", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_attribdebiti", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_ciclo", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_codice", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_codicemiur", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_dataconsmaxiscr", typeof(DateTime));
	tdidprogdefaultview.defineColumn("didprog_freqobbl", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_iddidprognumchiusokind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_iddidprogsuddannokind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_iderogazkind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_idsede", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_idtitolokind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_immatoltreauth", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_modaccesso", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_modaccesso_en", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_obbformativi", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_obbformativi_en", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_preimmatoltreauth", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_progesamamm", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_prospoccupaz", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_provafinaledesc", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_regolamentotax", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_regolamentotaxurl", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_startiscrizioni", typeof(DateTime));
	tdidprogdefaultview.defineColumn("didprog_stopiscrizioni", typeof(DateTime));
	tdidprogdefaultview.defineColumn("didprog_title_en", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_utenzasost", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_website", typeof(string));
	tdidprogdefaultview.defineColumn("didprognumchiusokind_title", typeof(string));
	tdidprogdefaultview.defineColumn("didprogsuddannokind_title", typeof(string));
	tdidprogdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdefaultview.defineColumn("erogazkind_title", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlang_lang", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlang2_lang", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlangvis_lang", typeof(string));
	tdidprogdefaultview.defineColumn("graduatoria_title", typeof(string));
	tdidprogdefaultview.defineColumn("idareadidattica", typeof(int));
	tdidprogdefaultview.defineColumn("idconvenzione", typeof(int));
	tdidprogdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogdefaultview.defineColumn("idgraduatoria", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_lang", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_lang2", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_langvis", typeof(int));
	tdidprogdefaultview.defineColumn("idreg_docenti", typeof(int));
	tdidprogdefaultview.defineColumn("idsessione", typeof(int));
	tdidprogdefaultview.defineColumn("registrydocenti_title", typeof(string));
	tdidprogdefaultview.defineColumn("sede_title", typeof(string));
	tdidprogdefaultview.defineColumn("sessione_idappellokind", typeof(int));
	tdidprogdefaultview.defineColumn("sessione_idsessionekind", typeof(int));
	tdidprogdefaultview.defineColumn("sessione_start", typeof(DateTime));
	tdidprogdefaultview.defineColumn("sessione_stop", typeof(DateTime));
	tdidprogdefaultview.defineColumn("sessionekind_title", typeof(string));
	tdidprogdefaultview.defineColumn("title", typeof(string));
	tdidprogdefaultview.defineColumn("titolokind_title", typeof(string));
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("idcorsostudio", "iddidprog");

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("corsostudio_almalaureasurvey", typeof(string));
	tcorsostudiodefaultview.defineColumn("corsostudio_annoistituz", typeof(int));
	tcorsostudiodefaultview.defineColumn("corsostudio_basevoto", typeof(int));
	tcorsostudiodefaultview.defineColumn("corsostudio_codice", typeof(string));
	tcorsostudiodefaultview.defineColumn("corsostudio_codicemiur", typeof(string));
	tcorsostudiodefaultview.defineColumn("corsostudio_codicemiurlungo", typeof(string));
	tcorsostudiodefaultview.defineColumn("corsostudio_crediti", typeof(int));
	tcorsostudiodefaultview.defineColumn("corsostudio_ct", typeof(DateTime),false);
	tcorsostudiodefaultview.defineColumn("corsostudio_cu", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("corsostudio_durata", typeof(int));
	tcorsostudiodefaultview.defineColumn("corsostudio_idcorsostudiokind", typeof(int),false);
	tcorsostudiodefaultview.defineColumn("corsostudio_idduratakind", typeof(int));
	tcorsostudiodefaultview.defineColumn("corsostudio_lt", typeof(DateTime),false);
	tcorsostudiodefaultview.defineColumn("corsostudio_lu", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("corsostudio_obbform", typeof(string));
	tcorsostudiodefaultview.defineColumn("corsostudio_sboccocc", typeof(string));
	tcorsostudiodefaultview.defineColumn("corsostudio_title_en", typeof(string));
	tcorsostudiodefaultview.defineColumn("corsostudiokind_title", typeof(string));
	tcorsostudiodefaultview.defineColumn("corsostudiolivello_title", typeof(string));
	tcorsostudiodefaultview.defineColumn("corsostudionorma_title", typeof(string));
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("duratakind_title", typeof(string));
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudiolivello", typeof(int));
	tcorsostudiodefaultview.defineColumn("idcorsostudionorma", typeof(int));
	tcorsostudiodefaultview.defineColumn("idstruttura", typeof(int));
	tcorsostudiodefaultview.defineColumn("struttura_idstrutturakind", typeof(int));
	tcorsostudiodefaultview.defineColumn("struttura_title", typeof(string));
	tcorsostudiodefaultview.defineColumn("strutturakind_title", typeof(string));
	tcorsostudiodefaultview.defineColumn("title", typeof(string));
	Tables.Add(tcorsostudiodefaultview);
	tcorsostudiodefaultview.defineKey("idcorsostudio");

	//////////////////// CONVALIDATO /////////////////////////////////
	var tconvalidato= new MetaTable("convalidato");
	tconvalidato.defineColumn("changesother", typeof(string));
	tconvalidato.defineColumn("ct", typeof(DateTime),false);
	tconvalidato.defineColumn("cu", typeof(string),false);
	tconvalidato.defineColumn("idattivform", typeof(int),false);
	tconvalidato.defineColumn("idchanges", typeof(int));
	tconvalidato.defineColumn("idchangeskind", typeof(int));
	tconvalidato.defineColumn("idconvalida", typeof(int),false);
	tconvalidato.defineColumn("idconvalidato", typeof(int),false);
	tconvalidato.defineColumn("iddichiar", typeof(int));
	tconvalidato.defineColumn("iddidprog", typeof(int));
	tconvalidato.defineColumn("idiscrizione", typeof(int));
	tconvalidato.defineColumn("idiscrizione_from", typeof(int));
	tconvalidato.defineColumn("idiscrizionebmi", typeof(int));
	tconvalidato.defineColumn("idistanza", typeof(int));
	tconvalidato.defineColumn("idlearningagrstud", typeof(int));
	tconvalidato.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidato.defineColumn("idpratica", typeof(int));
	tconvalidato.defineColumn("idreg", typeof(int),false);
	tconvalidato.defineColumn("lt", typeof(DateTime),false);
	tconvalidato.defineColumn("lu", typeof(string),false);
	Tables.Add(tconvalidato);
	tconvalidato.defineKey("idconvalida", "idconvalidato", "idreg");

	//////////////////// ATTIVFORMDEFAULTVIEW /////////////////////////////////
	var tattivformdefaultview= new MetaTable("attivformdefaultview");
	tattivformdefaultview.defineColumn("aa", typeof(string),false);
	tattivformdefaultview.defineColumn("attivform_ct", typeof(DateTime),false);
	tattivformdefaultview.defineColumn("attivform_cu", typeof(string),false);
	tattivformdefaultview.defineColumn("attivform_iddidproggrupp", typeof(int));
	tattivformdefaultview.defineColumn("attivform_lt", typeof(DateTime),false);
	tattivformdefaultview.defineColumn("attivform_lu", typeof(string),false);
	tattivformdefaultview.defineColumn("attivform_obbform", typeof(string));
	tattivformdefaultview.defineColumn("attivform_obbform_en", typeof(string));
	tattivformdefaultview.defineColumn("attivform_sortcode", typeof(int));
	tattivformdefaultview.defineColumn("attivform_start", typeof(DateTime));
	tattivformdefaultview.defineColumn("attivform_stop", typeof(DateTime));
	tattivformdefaultview.defineColumn("attivform_tipovalutaz", typeof(string));
	tattivformdefaultview.defineColumn("didproganno_title", typeof(string));
	tattivformdefaultview.defineColumn("didprogcurr_title", typeof(string));
	tattivformdefaultview.defineColumn("didproggrupp_title", typeof(string));
	tattivformdefaultview.defineColumn("didprogori_title", typeof(string));
	tattivformdefaultview.defineColumn("didprogporzanno_title", typeof(string));
	tattivformdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tattivformdefaultview.defineColumn("idattivform", typeof(int),false);
	tattivformdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprog", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidproganno", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogori", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformdefaultview.defineColumn("idinsegn", typeof(int),false);
	tattivformdefaultview.defineColumn("idinsegninteg", typeof(int));
	tattivformdefaultview.defineColumn("idsede", typeof(int),false);
	tattivformdefaultview.defineColumn("insegn_codice", typeof(string));
	tattivformdefaultview.defineColumn("insegn_denominazione", typeof(string));
	tattivformdefaultview.defineColumn("insegninteg_codice", typeof(string));
	tattivformdefaultview.defineColumn("insegninteg_denominazione", typeof(string));
	tattivformdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tattivformdefaultview);
	tattivformdefaultview.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// APPELLODEFAULTVIEW /////////////////////////////////
	var tappellodefaultview= new MetaTable("appellodefaultview");
	tappellodefaultview.defineColumn("aa", typeof(string));
	tappellodefaultview.defineColumn("appello_basevoto", typeof(int));
	tappellodefaultview.defineColumn("appello_cftoend", typeof(decimal));
	tappellodefaultview.defineColumn("appello_ct", typeof(DateTime),false);
	tappellodefaultview.defineColumn("appello_cu", typeof(string),false);
	tappellodefaultview.defineColumn("appello_esteroend", typeof(DateTime));
	tappellodefaultview.defineColumn("appello_esterostart", typeof(DateTime));
	tappellodefaultview.defineColumn("appello_idappelloazionekind", typeof(int));
	tappellodefaultview.defineColumn("appello_idappellokind", typeof(int));
	tappellodefaultview.defineColumn("appello_idstudprenotkind", typeof(int));
	tappellodefaultview.defineColumn("appello_lavoratori", typeof(string));
	tappellodefaultview.defineColumn("appello_lt", typeof(DateTime),false);
	tappellodefaultview.defineColumn("appello_lu", typeof(string),false);
	tappellodefaultview.defineColumn("appello_minanniiscr", typeof(int));
	tappellodefaultview.defineColumn("appello_minvoto", typeof(int));
	tappellodefaultview.defineColumn("appello_passaggio", typeof(string));
	tappellodefaultview.defineColumn("appello_penotend", typeof(DateTime));
	tappellodefaultview.defineColumn("appello_posti", typeof(int));
	tappellodefaultview.defineColumn("appello_prenotstart", typeof(DateTime));
	tappellodefaultview.defineColumn("appello_prointermedia", typeof(string));
	tappellodefaultview.defineColumn("appello_publicato", typeof(string));
	tappellodefaultview.defineColumn("appello_surmanestop", typeof(string));
	tappellodefaultview.defineColumn("appello_surnamestart", typeof(string));
	tappellodefaultview.defineColumn("appelloazionekind_title", typeof(string));
	tappellodefaultview.defineColumn("appellokind_sessione_title", typeof(string));
	tappellodefaultview.defineColumn("appellokind_title", typeof(string));
	tappellodefaultview.defineColumn("description", typeof(string));
	tappellodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tappellodefaultview.defineColumn("idappello", typeof(int),false);
	tappellodefaultview.defineColumn("idsessione", typeof(int));
	tappellodefaultview.defineColumn("sessione_idappellokind", typeof(int));
	tappellodefaultview.defineColumn("sessione_idsessionekind", typeof(int));
	tappellodefaultview.defineColumn("sessione_start", typeof(DateTime));
	tappellodefaultview.defineColumn("sessione_stop", typeof(DateTime));
	tappellodefaultview.defineColumn("sessionekind_title", typeof(string));
	tappellodefaultview.defineColumn("studprenotkind_title", typeof(string));
	Tables.Add(tappellodefaultview);
	tappellodefaultview.defineKey("idappello");

	//////////////////// CONVALIDATOVIEW /////////////////////////////////
	var tconvalidatoview= new MetaTable("convalidatoview");
	tconvalidatoview.defineColumn("ct", typeof(DateTime),false);
	tconvalidatoview.defineColumn("cu", typeof(string),false);
	tconvalidatoview.defineColumn("data", typeof(DateTime));
	tconvalidatoview.defineColumn("domande", typeof(int));
	tconvalidatoview.defineColumn("ects", typeof(int));
	tconvalidatoview.defineColumn("giudizio", typeof(int));
	tconvalidatoview.defineColumn("idappello", typeof(int));
	tconvalidatoview.defineColumn("idattivform", typeof(int),false);
	tconvalidatoview.defineColumn("idconvalidato", typeof(int),false);
	tconvalidatoview.defineColumn("idcorsostudio", typeof(int));
	tconvalidatoview.defineColumn("iddidprog", typeof(int));
	tconvalidatoview.defineColumn("idiscrizione", typeof(int));
	tconvalidatoview.defineColumn("idprova", typeof(int));
	tconvalidatoview.defineColumn("idreg", typeof(int),false);
	tconvalidatoview.defineColumn("idsostenimentoesito", typeof(int),false);
	tconvalidatoview.defineColumn("idtitolostudio", typeof(int));
	tconvalidatoview.defineColumn("insecod", typeof(string));
	tconvalidatoview.defineColumn("insedesc", typeof(string));
	tconvalidatoview.defineColumn("livello", typeof(int));
	tconvalidatoview.defineColumn("lt", typeof(DateTime),false);
	tconvalidatoview.defineColumn("lu", typeof(string),false);
	tconvalidatoview.defineColumn("paridsostenimento", typeof(int));
	tconvalidatoview.defineColumn("protanno", typeof(int));
	tconvalidatoview.defineColumn("protnumero", typeof(int));
	tconvalidatoview.defineColumn("voto", typeof(decimal));
	tconvalidatoview.defineColumn("votolode", typeof(string));
	tconvalidatoview.defineColumn("votosu", typeof(int));
	Tables.Add(tconvalidatoview);
	tconvalidatoview.defineKey("idconvalidato");

	#endregion


	#region DataRelation creation
	var cPar = new []{sostenimentodefaultview.Columns["idsostenimento"]};
	var cChild = new []{convalidatoview.Columns["paridsostenimento"]};
	Relations.Add(new DataRelation("FK_convalidatoview_sostenimentodefaultview_paridsostenimento",cPar,cChild,false));

	cPar = new []{titolostudiodocentiview.Columns["idtitolostudio"]};
	cChild = new []{convalidatoview.Columns["idtitolostudio"]};
	Relations.Add(new DataRelation("FK_convalidatoview_titolostudiodocentiview_idtitolostudio",cPar,cChild,false));

	cPar = new []{sostenimentoesitodefaultview.Columns["idsostenimentoesito"]};
	cChild = new []{convalidatoview.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_convalidatoview_sostenimentoesitodefaultview_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{convalidatoview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidatoview_registrydefaultview_idreg",cPar,cChild,false));

	cPar = new []{provadefaultview.Columns["idprova"]};
	cChild = new []{convalidatoview.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_convalidatoview_provadefaultview_idprova",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{convalidatoview.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_convalidatoview_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{convalidatoview.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_convalidatoview_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{convalidatoview.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_convalidatoview_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	cPar = new []{convalidato.Columns["idconvalidato"]};
	cChild = new []{convalidatoview.Columns["idconvalidato"]};
	Relations.Add(new DataRelation("FK_convalidatoview_convalidato_idconvalidato",cPar,cChild,false));

	cPar = new []{attivformdefaultview.Columns["idattivform"]};
	cChild = new []{convalidatoview.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_convalidatoview_attivformdefaultview_idattivform",cPar,cChild,false));

	cPar = new []{appellodefaultview.Columns["idappello"]};
	cChild = new []{convalidatoview.Columns["idappello"]};
	Relations.Add(new DataRelation("FK_convalidatoview_appellodefaultview_idappello",cPar,cChild,false));

	#endregion

}
}
}
