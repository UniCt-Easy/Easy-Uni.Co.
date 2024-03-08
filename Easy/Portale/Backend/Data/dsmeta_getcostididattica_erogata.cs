
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_getcostididattica_erogata"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_getcostididattica_erogata: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable positiondefaultview 		=> (MetaTable)Tables["positiondefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentokinddefaultview 		=> (MetaTable)Tables["affidamentokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegnintegdefaultview 		=> (MetaTable)Tables["insegnintegdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegndefaultview 		=> (MetaTable)Tables["insegndefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sededefaultview 		=> (MetaTable)Tables["sededefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getcostididattica 		=> (MetaTable)Tables["getcostididattica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_getcostididattica_erogata(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_getcostididattica_erogata (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_getcostididattica_erogata";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_getcostididattica_erogata.xsd";

	#region create DataTables
	//////////////////// REGISTRYDOCENTIVIEW /////////////////////////////////
	var tregistrydocentiview= new MetaTable("registrydocentiview");
	tregistrydocentiview.defineColumn("accmotive_codemotive", typeof(string));
	tregistrydocentiview.defineColumn("accmotive_registry_codemotive", typeof(string));
	tregistrydocentiview.defineColumn("accmotive_registry_title", typeof(string));
	tregistrydocentiview.defineColumn("accmotive_title", typeof(string));
	tregistrydocentiview.defineColumn("classconsorsuale_title", typeof(string));
	tregistrydocentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydocentiview.defineColumn("fonteindicebibliometrico_title", typeof(string));
	tregistrydocentiview.defineColumn("geo_city_title", typeof(string));
	tregistrydocentiview.defineColumn("geo_nation_title", typeof(string));
	tregistrydocentiview.defineColumn("idaccmotivecredit", typeof(string));
	tregistrydocentiview.defineColumn("idaccmotivedebit", typeof(string));
	tregistrydocentiview.defineColumn("idcity", typeof(int));
	tregistrydocentiview.defineColumn("idclassconsorsuale", typeof(int));
	tregistrydocentiview.defineColumn("idnation", typeof(int));
	tregistrydocentiview.defineColumn("idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("idreg_istituti", typeof(int));
	tregistrydocentiview.defineColumn("idsasd", typeof(int));
	tregistrydocentiview.defineColumn("idstruttura", typeof(int));
	tregistrydocentiview.defineColumn("maritalstatus_description", typeof(string));
	tregistrydocentiview.defineColumn("registry_active", typeof(string));
	tregistrydocentiview.defineColumn("registry_annotation", typeof(string));
	tregistrydocentiview.defineColumn("registry_authorization_free", typeof(string));
	tregistrydocentiview.defineColumn("registry_badgecode", typeof(string));
	tregistrydocentiview.defineColumn("registry_birthdate", typeof(DateTime));
	tregistrydocentiview.defineColumn("registry_ccp", typeof(string));
	tregistrydocentiview.defineColumn("registry_cf", typeof(string));
	tregistrydocentiview.defineColumn("registry_ct", typeof(DateTime),false);
	tregistrydocentiview.defineColumn("registry_cu", typeof(string),false);
	tregistrydocentiview.defineColumn("registry_docenti_ct", typeof(DateTime),false);
	tregistrydocentiview.defineColumn("registry_docenti_cu", typeof(string),false);
	tregistrydocentiview.defineColumn("registry_docenti_cv", typeof(string));
	tregistrydocentiview.defineColumn("registry_docenti_idfonteindicebibliometrico", typeof(int));
	tregistrydocentiview.defineColumn("registry_docenti_idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("registry_docenti_indicebibliometrico", typeof(int));
	tregistrydocentiview.defineColumn("registry_docenti_lt", typeof(DateTime),false);
	tregistrydocentiview.defineColumn("registry_docenti_lu", typeof(string),false);
	tregistrydocentiview.defineColumn("registry_docenti_matricola", typeof(string));
	tregistrydocentiview.defineColumn("registry_docenti_ricevimento", typeof(string));
	tregistrydocentiview.defineColumn("registry_docenti_soggiorno", typeof(string));
	tregistrydocentiview.defineColumn("registry_email_fe", typeof(string));
	tregistrydocentiview.defineColumn("registry_extension", typeof(string));
	tregistrydocentiview.defineColumn("registry_extmatricula", typeof(string));
	tregistrydocentiview.defineColumn("registry_flag_pa", typeof(string));
	tregistrydocentiview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistrydocentiview.defineColumn("registry_foreigncf", typeof(string));
	tregistrydocentiview.defineColumn("registry_forename", typeof(string));
	tregistrydocentiview.defineColumn("registry_gender", typeof(string));
	tregistrydocentiview.defineColumn("registry_idcategory", typeof(string));
	tregistrydocentiview.defineColumn("registry_idcentralizedcategory", typeof(string));
	tregistrydocentiview.defineColumn("registry_idexternal", typeof(int));
	tregistrydocentiview.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistrydocentiview.defineColumn("registry_idregistryclass", typeof(string));
	tregistrydocentiview.defineColumn("registry_idregistrykind", typeof(int));
	tregistrydocentiview.defineColumn("registry_idtitle", typeof(string));
	tregistrydocentiview.defineColumn("registry_ipa_fe", typeof(string));
	tregistrydocentiview.defineColumn("registry_ipa_perlapa", typeof(string));
	tregistrydocentiview.defineColumn("registry_location", typeof(string));
	tregistrydocentiview.defineColumn("registry_lt", typeof(DateTime),false);
	tregistrydocentiview.defineColumn("registry_lu", typeof(string),false);
	tregistrydocentiview.defineColumn("registry_maritalsurname", typeof(string));
	tregistrydocentiview.defineColumn("registry_multi_cf", typeof(string));
	tregistrydocentiview.defineColumn("registry_p_iva", typeof(string));
	tregistrydocentiview.defineColumn("registry_pec_fe", typeof(string));
	tregistrydocentiview.defineColumn("registry_residence", typeof(int),false);
	tregistrydocentiview.defineColumn("registry_rtf", typeof(Byte[]));
	tregistrydocentiview.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistrydocentiview.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistrydocentiview.defineColumn("registry_surname", typeof(string));
	tregistrydocentiview.defineColumn("registry_toredirect", typeof(int));
	tregistrydocentiview.defineColumn("registry_txt", typeof(string));
	tregistrydocentiview.defineColumn("registryclass_description", typeof(string));
	tregistrydocentiview.defineColumn("registryistituti_title", typeof(string));
	tregistrydocentiview.defineColumn("residence_description", typeof(string));
	tregistrydocentiview.defineColumn("sasd_codice", typeof(string));
	tregistrydocentiview.defineColumn("sasd_title", typeof(string));
	tregistrydocentiview.defineColumn("struttura_idstrutturakind", typeof(int));
	tregistrydocentiview.defineColumn("struttura_title", typeof(string));
	tregistrydocentiview.defineColumn("strutturakind_title", typeof(string));
	tregistrydocentiview.defineColumn("title", typeof(string),false);
	tregistrydocentiview.defineColumn("title_description", typeof(string));
	Tables.Add(tregistrydocentiview);
	tregistrydocentiview.defineKey("idreg");

	//////////////////// POSITIONDEFAULTVIEW /////////////////////////////////
	var tpositiondefaultview= new MetaTable("positiondefaultview");
	tpositiondefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpositiondefaultview.defineColumn("idposition", typeof(int),false);
	tpositiondefaultview.defineColumn("position_active", typeof(string));
	tpositiondefaultview.defineColumn("position_assegnoaggiuntivo", typeof(string));
	tpositiondefaultview.defineColumn("position_codeposition", typeof(string),false);
	tpositiondefaultview.defineColumn("position_costolordoannuo", typeof(decimal));
	tpositiondefaultview.defineColumn("position_costolordoannuooneri", typeof(decimal));
	tpositiondefaultview.defineColumn("position_ct", typeof(DateTime),false);
	tpositiondefaultview.defineColumn("position_cu", typeof(string),false);
	tpositiondefaultview.defineColumn("position_description", typeof(string),false);
	tpositiondefaultview.defineColumn("position_elementoperequativo", typeof(string));
	tpositiondefaultview.defineColumn("position_foreignclass", typeof(string));
	tpositiondefaultview.defineColumn("position_indennitadiateneo", typeof(string));
	tpositiondefaultview.defineColumn("position_indennitadiposizione", typeof(string));
	tpositiondefaultview.defineColumn("position_indvacancacontrattuale", typeof(string));
	tpositiondefaultview.defineColumn("position_livello", typeof(string));
	tpositiondefaultview.defineColumn("position_lt", typeof(DateTime),false);
	tpositiondefaultview.defineColumn("position_lu", typeof(string),false);
	tpositiondefaultview.defineColumn("position_maxincomeclass", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxcompitididatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxcompitididatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxdidatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxdidatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxgg", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxtempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxtempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremincompitididatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremincompitididatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremindidatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremindidatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremintempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremintempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_orestraordinariemax", typeof(int));
	tpositiondefaultview.defineColumn("position_parttime", typeof(string));
	tpositiondefaultview.defineColumn("position_printingorder", typeof(int));
	tpositiondefaultview.defineColumn("position_puntiorganico", typeof(decimal));
	tpositiondefaultview.defineColumn("position_siglaesportazione", typeof(string));
	tpositiondefaultview.defineColumn("position_siglaimportazione", typeof(string));
	tpositiondefaultview.defineColumn("position_tempdef", typeof(string));
	tpositiondefaultview.defineColumn("position_tipoente", typeof(string));
	tpositiondefaultview.defineColumn("position_tipopersonale", typeof(string));
	tpositiondefaultview.defineColumn("position_totaletredicesima", typeof(string));
	tpositiondefaultview.defineColumn("position_tredicesimaindennitaintegrativaspeciale", typeof(string));
	tpositiondefaultview.defineColumn("title", typeof(string));
	Tables.Add(tpositiondefaultview);
	tpositiondefaultview.defineKey("idposition");

	//////////////////// AFFIDAMENTOKINDDEFAULTVIEW /////////////////////////////////
	var taffidamentokinddefaultview= new MetaTable("affidamentokinddefaultview");
	taffidamentokinddefaultview.defineColumn("affidamentokind_active", typeof(string));
	taffidamentokinddefaultview.defineColumn("affidamentokind_costoora", typeof(decimal));
	taffidamentokinddefaultview.defineColumn("affidamentokind_costoorariodacontratto", typeof(string));
	taffidamentokinddefaultview.defineColumn("affidamentokind_ct", typeof(DateTime),false);
	taffidamentokinddefaultview.defineColumn("affidamentokind_cu", typeof(string),false);
	taffidamentokinddefaultview.defineColumn("affidamentokind_description", typeof(string),false);
	taffidamentokinddefaultview.defineColumn("affidamentokind_lt", typeof(DateTime),false);
	taffidamentokinddefaultview.defineColumn("affidamentokind_lu", typeof(string),false);
	taffidamentokinddefaultview.defineColumn("affidamentokind_sortcode", typeof(int),false);
	taffidamentokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	taffidamentokinddefaultview.defineColumn("idaffidamentokind", typeof(int),false);
	taffidamentokinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(taffidamentokinddefaultview);
	taffidamentokinddefaultview.defineKey("idaffidamentokind");

	//////////////////// INSEGNINTEGDEFAULTVIEW /////////////////////////////////
	var tinsegnintegdefaultview= new MetaTable("insegnintegdefaultview");
	tinsegnintegdefaultview.defineColumn("denominazione", typeof(string));
	tinsegnintegdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinsegnintegdefaultview.defineColumn("idinsegn", typeof(int),false);
	tinsegnintegdefaultview.defineColumn("idinsegninteg", typeof(int),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_codice", typeof(string));
	tinsegnintegdefaultview.defineColumn("insegninteg_ct", typeof(DateTime),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_cu", typeof(string),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_denominazione_en", typeof(string));
	tinsegnintegdefaultview.defineColumn("insegninteg_lt", typeof(DateTime),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_lu", typeof(string),false);
	Tables.Add(tinsegnintegdefaultview);
	tinsegnintegdefaultview.defineKey("idinsegn", "idinsegninteg");

	//////////////////// INSEGNDEFAULTVIEW /////////////////////////////////
	var tinsegndefaultview= new MetaTable("insegndefaultview");
	tinsegndefaultview.defineColumn("corsostudio_annoistituz", typeof(int));
	tinsegndefaultview.defineColumn("corsostudio_title", typeof(string));
	tinsegndefaultview.defineColumn("corsostudiokind_title", typeof(string));
	tinsegndefaultview.defineColumn("denominazione", typeof(string));
	tinsegndefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinsegndefaultview.defineColumn("idcorsostudio", typeof(int));
	tinsegndefaultview.defineColumn("idinsegn", typeof(int),false);
	tinsegndefaultview.defineColumn("idstruttura", typeof(int));
	tinsegndefaultview.defineColumn("insegn_codice", typeof(string));
	tinsegndefaultview.defineColumn("insegn_ct", typeof(DateTime),false);
	tinsegndefaultview.defineColumn("insegn_cu", typeof(string),false);
	tinsegndefaultview.defineColumn("insegn_denominazione_en", typeof(string));
	tinsegndefaultview.defineColumn("insegn_idcorsostudiokind", typeof(int));
	tinsegndefaultview.defineColumn("insegn_lt", typeof(DateTime),false);
	tinsegndefaultview.defineColumn("insegn_lu", typeof(string),false);
	tinsegndefaultview.defineColumn("struttura_idstrutturakind", typeof(int));
	tinsegndefaultview.defineColumn("struttura_title", typeof(string));
	tinsegndefaultview.defineColumn("strutturakind_title", typeof(string));
	Tables.Add(tinsegndefaultview);
	tinsegndefaultview.defineKey("idinsegn");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("codice", typeof(string));
	tdidprogcurr.defineColumn("codicemiur", typeof(string));
	tdidprogcurr.defineColumn("ct", typeof(DateTime),false);
	tdidprogcurr.defineColumn("cu", typeof(string),false);
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("lt", typeof(DateTime),false);
	tdidprogcurr.defineColumn("lu", typeof(string),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("aa", typeof(string));
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
	tdidprogdefaultview.defineColumn("sessione_idsessionekind", typeof(int));
	tdidprogdefaultview.defineColumn("sessione_start", typeof(DateTime));
	tdidprogdefaultview.defineColumn("sessione_stop", typeof(DateTime));
	tdidprogdefaultview.defineColumn("sessionekind_title", typeof(string));
	tdidprogdefaultview.defineColumn("title", typeof(string));
	tdidprogdefaultview.defineColumn("titolokind_title", typeof(string));
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// SEDEDEFAULTVIEW /////////////////////////////////
	var tsededefaultview= new MetaTable("sededefaultview");
	tsededefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsededefaultview.defineColumn("geo_city_title", typeof(string));
	tsededefaultview.defineColumn("geo_nation_title", typeof(string));
	tsededefaultview.defineColumn("idcity", typeof(int));
	tsededefaultview.defineColumn("idnation", typeof(int));
	tsededefaultview.defineColumn("idsede", typeof(int),false);
	tsededefaultview.defineColumn("sede_address", typeof(string));
	tsededefaultview.defineColumn("sede_annotations", typeof(string));
	tsededefaultview.defineColumn("sede_cap", typeof(string));
	tsededefaultview.defineColumn("sede_ct", typeof(DateTime),false);
	tsededefaultview.defineColumn("sede_cu", typeof(string),false);
	tsededefaultview.defineColumn("sede_idreg", typeof(int));
	tsededefaultview.defineColumn("sede_idsedemiur", typeof(int));
	tsededefaultview.defineColumn("sede_latitude", typeof(decimal));
	tsededefaultview.defineColumn("sede_longitude", typeof(decimal));
	tsededefaultview.defineColumn("sede_lt", typeof(DateTime),false);
	tsededefaultview.defineColumn("sede_lu", typeof(string),false);
	tsededefaultview.defineColumn("title", typeof(string));
	Tables.Add(tsededefaultview);
	tsededefaultview.defineKey("idsede");

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

	//////////////////// GETCOSTIDIDATTICA /////////////////////////////////
	var tgetcostididattica= new MetaTable("getcostididattica");
	tgetcostididattica.defineColumn("aa", typeof(string),false);
	tgetcostididattica.defineColumn("aaprogrammata", typeof(string));
	tgetcostididattica.defineColumn("affidamento", typeof(string),false);
	tgetcostididattica.defineColumn("corsostudio", typeof(string));
	tgetcostididattica.defineColumn("costo", typeof(decimal));
	tgetcostididattica.defineColumn("costoorariodacontratto", typeof(string),false);
	tgetcostididattica.defineColumn("curriculum", typeof(string));
	tgetcostididattica.defineColumn("docente", typeof(string));
	tgetcostididattica.defineColumn("idaffidamento", typeof(int),false);
	tgetcostididattica.defineColumn("idaffidamentokind", typeof(int),false);
	tgetcostididattica.defineColumn("idcorsostudio", typeof(int),false);
	tgetcostididattica.defineColumn("iddidprog", typeof(int),false);
	tgetcostididattica.defineColumn("iddidprogcurr", typeof(int),false);
	tgetcostididattica.defineColumn("idinsegn", typeof(int),false);
	tgetcostididattica.defineColumn("idinsegninteg", typeof(int));
	tgetcostididattica.defineColumn("idposition", typeof(int),false);
	tgetcostididattica.defineColumn("idreg_docenti", typeof(int));
	tgetcostididattica.defineColumn("idsede", typeof(int),false);
	tgetcostididattica.defineColumn("insegnamento", typeof(string));
	tgetcostididattica.defineColumn("modulo", typeof(string));
	tgetcostididattica.defineColumn("ruolo", typeof(string),false);
	tgetcostididattica.defineColumn("sede", typeof(string));
	Tables.Add(tgetcostididattica);
	tgetcostididattica.defineKey("aa", "idaffidamento", "idcorsostudio", "iddidprog", "iddidprogcurr", "idposition", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrydocentiview.Columns["idreg"]};
	var cChild = new []{getcostididattica.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_getcostididattica_registrydocentiview_idreg_docenti",cPar,cChild,false));

	cPar = new []{positiondefaultview.Columns["idposition"]};
	cChild = new []{getcostididattica.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_getcostididattica_positiondefaultview_idposition",cPar,cChild,false));

	cPar = new []{affidamentokinddefaultview.Columns["idaffidamentokind"]};
	cChild = new []{getcostididattica.Columns["idaffidamentokind"]};
	Relations.Add(new DataRelation("FK_getcostididattica_affidamentokinddefaultview_idaffidamentokind",cPar,cChild,false));

	cPar = new []{insegnintegdefaultview.Columns["idinsegninteg"]};
	cChild = new []{getcostididattica.Columns["idinsegninteg"]};
	Relations.Add(new DataRelation("FK_getcostididattica_insegnintegdefaultview_idinsegninteg",cPar,cChild,false));

	cPar = new []{insegndefaultview.Columns["idinsegn"]};
	cChild = new []{getcostididattica.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_getcostididattica_insegndefaultview_idinsegn",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{getcostididattica.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_getcostididattica_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{getcostididattica.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_getcostididattica_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{getcostididattica.Columns["aa"]};
	Relations.Add(new DataRelation("FK_getcostididattica_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{sededefaultview.Columns["idsede"]};
	cChild = new []{getcostididattica.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_getcostididattica_sededefaultview_idsede",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{getcostididattica.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_getcostididattica_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	#endregion

}
}
}
