
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
[System.Xml.Serialization.XmlRoot("dsmeta_affidamento_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_affidamento_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdaffini 		=> (MetaTable)Tables["sasdaffini"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable lezione 		=> (MetaTable)Tables["lezione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiperssd 		=> (MetaTable)Tables["getdocentiperssd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable orakind 		=> (MetaTable)Tables["orakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristicaora 		=> (MetaTable)Tables["affidamentocaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppo 		=> (MetaTable)Tables["sasdgruppo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadisc 		=> (MetaTable)Tables["ambitoareadisc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristica 		=> (MetaTable)Tables["affidamentocaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentoattach 		=> (MetaTable)Tables["affidamentoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable erogazkinddefaultview 		=> (MetaTable)Tables["erogazkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentokinddefaultview 		=> (MetaTable)Tables["affidamentokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamento 		=> (MetaTable)Tables["affidamento"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_affidamento_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_affidamento_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_affidamento_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_affidamento_default.xsd";

	#region create DataTables
	//////////////////// SASDAFFINI /////////////////////////////////
	var tsasdaffini= new MetaTable("sasdaffini");
	tsasdaffini.defineColumn("affinita", typeof(int),false);
	tsasdaffini.defineColumn("idsasd", typeof(int),false);
	tsasdaffini.defineColumn("idsasd_affine", typeof(int),false);
	Tables.Add(tsasdaffini);
	tsasdaffini.defineKey("idsasd", "idsasd_affine");

	//////////////////// LEZIONE /////////////////////////////////
	var tlezione= new MetaTable("lezione");
	tlezione.defineColumn("!title", typeof(string));
	tlezione.defineColumn("aa", typeof(string),false);
	tlezione.defineColumn("ct", typeof(DateTime),false);
	tlezione.defineColumn("cu", typeof(string),false);
	tlezione.defineColumn("idaffidamento", typeof(int),false);
	tlezione.defineColumn("idattivform", typeof(int),false);
	tlezione.defineColumn("idaula", typeof(int),false);
	tlezione.defineColumn("idcanale", typeof(int),false);
	tlezione.defineColumn("idcorsostudio", typeof(int),false);
	tlezione.defineColumn("iddidprog", typeof(int),false);
	tlezione.defineColumn("iddidproganno", typeof(int),false);
	tlezione.defineColumn("iddidprogcurr", typeof(int),false);
	tlezione.defineColumn("iddidprogori", typeof(int),false);
	tlezione.defineColumn("iddidprogporzanno", typeof(int),false);
	tlezione.defineColumn("idedificio", typeof(int),false);
	tlezione.defineColumn("idlezione", typeof(int),false);
	tlezione.defineColumn("idreg_docenti", typeof(int),false);
	tlezione.defineColumn("idsede", typeof(int),false);
	tlezione.defineColumn("lt", typeof(DateTime),false);
	tlezione.defineColumn("lu", typeof(string),false);
	tlezione.defineColumn("nonsvolta", typeof(string));
	tlezione.defineColumn("stage", typeof(string));
	tlezione.defineColumn("start", typeof(DateTime),false);
	tlezione.defineColumn("stop", typeof(DateTime),false);
	tlezione.defineColumn("visita", typeof(string));
	Tables.Add(tlezione);
	tlezione.defineKey("aa", "idaffidamento", "idattivform", "idaula", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idedificio", "idlezione", "idreg_docenti", "idsede");

	//////////////////// GETDOCENTIPERSSD /////////////////////////////////
	var tgetdocentiperssd= new MetaTable("getdocentiperssd");
	tgetdocentiperssd.defineColumn("aa", typeof(string),false);
	tgetdocentiperssd.defineColumn("cognome", typeof(string));
	tgetdocentiperssd.defineColumn("contratto", typeof(string),false);
	tgetdocentiperssd.defineColumn("costoorario", typeof(decimal));
	tgetdocentiperssd.defineColumn("idreg", typeof(int),false);
	tgetdocentiperssd.defineColumn("idsasd", typeof(int),false);
	tgetdocentiperssd.defineColumn("iniziocontratto", typeof(DateTime),false);
	tgetdocentiperssd.defineColumn("matricola", typeof(string));
	tgetdocentiperssd.defineColumn("nome", typeof(string));
	tgetdocentiperssd.defineColumn("oremaxdida", typeof(int));
	tgetdocentiperssd.defineColumn("oremindida", typeof(int));
	tgetdocentiperssd.defineColumn("oreperaaaffidamento", typeof(int));
	tgetdocentiperssd.defineColumn("oreperaacontratto", typeof(int));
	tgetdocentiperssd.defineColumn("parttime", typeof(decimal));
	tgetdocentiperssd.defineColumn("ssd", typeof(string),false);
	tgetdocentiperssd.defineColumn("struttura", typeof(string));
	tgetdocentiperssd.defineColumn("tempodefinito", typeof(string),false);
	tgetdocentiperssd.defineColumn("terminecontratto", typeof(DateTime),false);
	Tables.Add(tgetdocentiperssd);
	tgetdocentiperssd.defineKey("aa", "idreg");

	//////////////////// ORAKIND /////////////////////////////////
	var torakind= new MetaTable("orakind");
	torakind.defineColumn("active", typeof(string));
	torakind.defineColumn("idorakind", typeof(int),false);
	torakind.defineColumn("title", typeof(string));
	Tables.Add(torakind);
	torakind.defineKey("idorakind");

	//////////////////// AFFIDAMENTOCARATTERISTICAORA /////////////////////////////////
	var taffidamentocaratteristicaora= new MetaTable("affidamentocaratteristicaora");
	taffidamentocaratteristicaora.defineColumn("aa", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("ct", typeof(DateTime),false);
	taffidamentocaratteristicaora.defineColumn("cu", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamento", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamentocaratteristica", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamentocaratteristicaora", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idattivform", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idcanale", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprog", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidproganno", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogori", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idorakind", typeof(int));
	taffidamentocaratteristicaora.defineColumn("lt", typeof(DateTime),false);
	taffidamentocaratteristicaora.defineColumn("lu", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("ora", typeof(int));
	taffidamentocaratteristicaora.defineColumn("ripetizioni", typeof(int));
	taffidamentocaratteristicaora.defineColumn("!idorakind_orakind_title", typeof(string));
	Tables.Add(taffidamentocaratteristicaora);
	taffidamentocaratteristicaora.defineKey("aa", "idaffidamento", "idaffidamentocaratteristica", "idaffidamentocaratteristicaora", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// TIPOATTFORM /////////////////////////////////
	var ttipoattform= new MetaTable("tipoattform");
	ttipoattform.defineColumn("description", typeof(string));
	ttipoattform.defineColumn("idtipoattform", typeof(int),false);
	ttipoattform.defineColumn("title", typeof(string),false);
	Tables.Add(ttipoattform);
	ttipoattform.defineKey("idtipoattform");

	//////////////////// SASDGRUPPO /////////////////////////////////
	var tsasdgruppo= new MetaTable("sasdgruppo");
	tsasdgruppo.defineColumn("idsasdgruppo", typeof(int),false);
	tsasdgruppo.defineColumn("idtipoattform", typeof(int),false);
	tsasdgruppo.defineColumn("title", typeof(string));
	Tables.Add(tsasdgruppo);
	tsasdgruppo.defineKey("idsasdgruppo", "idtipoattform");

	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("codice", typeof(string),false);
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	//////////////////// AMBITOAREADISC /////////////////////////////////
	var tambitoareadisc= new MetaTable("ambitoareadisc");
	tambitoareadisc.defineColumn("idambitoareadisc", typeof(int),false);
	tambitoareadisc.defineColumn("title", typeof(string),false);
	Tables.Add(tambitoareadisc);
	tambitoareadisc.defineKey("idambitoareadisc");

	//////////////////// AFFIDAMENTOCARATTERISTICA /////////////////////////////////
	var taffidamentocaratteristica= new MetaTable("affidamentocaratteristica");
	taffidamentocaratteristica.defineColumn("aa", typeof(string),false);
	taffidamentocaratteristica.defineColumn("cf", typeof(decimal));
	taffidamentocaratteristica.defineColumn("ct", typeof(DateTime),false);
	taffidamentocaratteristica.defineColumn("cu", typeof(string),false);
	taffidamentocaratteristica.defineColumn("idaffidamento", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idaffidamentocaratteristica", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idambitoareadisc", typeof(int));
	taffidamentocaratteristica.defineColumn("idattivform", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idcanale", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprog", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidproganno", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogori", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idsasd", typeof(int));
	taffidamentocaratteristica.defineColumn("idsasdgruppo", typeof(int));
	taffidamentocaratteristica.defineColumn("idtipoattform", typeof(int));
	taffidamentocaratteristica.defineColumn("json", typeof(string));
	taffidamentocaratteristica.defineColumn("lt", typeof(DateTime),false);
	taffidamentocaratteristica.defineColumn("lu", typeof(string),false);
	taffidamentocaratteristica.defineColumn("profess", typeof(string),false);
	taffidamentocaratteristica.defineColumn("title", typeof(string));
	taffidamentocaratteristica.defineColumn("!idambitoareadisc_ambitoareadisc_title", typeof(string));
	taffidamentocaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	taffidamentocaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	taffidamentocaratteristica.defineColumn("!idsasdgruppo_sasdgruppo_title", typeof(string));
	taffidamentocaratteristica.defineColumn("!idtipoattform_tipoattform_title", typeof(string));
	taffidamentocaratteristica.defineColumn("!idtipoattform_tipoattform_description", typeof(string));
	taffidamentocaratteristica.defineColumn("!affidamentocaratteristicaora", typeof(string));
	Tables.Add(taffidamentocaratteristica);
	taffidamentocaratteristica.defineKey("aa", "idaffidamento", "idaffidamentocaratteristica", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// AFFIDAMENTOATTACH /////////////////////////////////
	var taffidamentoattach= new MetaTable("affidamentoattach");
	taffidamentoattach.defineColumn("aa", typeof(string),false);
	taffidamentoattach.defineColumn("ct", typeof(DateTime),false);
	taffidamentoattach.defineColumn("cu", typeof(string),false);
	taffidamentoattach.defineColumn("idaffidamento", typeof(int),false);
	taffidamentoattach.defineColumn("idattach", typeof(int),false);
	taffidamentoattach.defineColumn("idattivform", typeof(int),false);
	taffidamentoattach.defineColumn("idcanale", typeof(int),false);
	taffidamentoattach.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprog", typeof(int),false);
	taffidamentoattach.defineColumn("iddidproganno", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprogori", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentoattach.defineColumn("idreg_docenti", typeof(int));
	taffidamentoattach.defineColumn("lt", typeof(DateTime),false);
	taffidamentoattach.defineColumn("lu", typeof(string),false);
	taffidamentoattach.defineColumn("!idattach_attach_filename", typeof(string));
	taffidamentoattach.defineColumn("!idattach_attach_size", typeof(int));
	Tables.Add(taffidamentoattach);
	taffidamentoattach.defineKey("aa", "idaffidamento", "idattach", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

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

	//////////////////// EROGAZKINDDEFAULTVIEW /////////////////////////////////
	var terogazkinddefaultview= new MetaTable("erogazkinddefaultview");
	terogazkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	terogazkinddefaultview.defineColumn("erogazkind_active", typeof(string));
	terogazkinddefaultview.defineColumn("erogazkind_ans", typeof(string));
	terogazkinddefaultview.defineColumn("erogazkind_description", typeof(string));
	terogazkinddefaultview.defineColumn("erogazkind_lt", typeof(DateTime),false);
	terogazkinddefaultview.defineColumn("erogazkind_lu", typeof(string),false);
	terogazkinddefaultview.defineColumn("erogazkind_sortcode", typeof(int),false);
	terogazkinddefaultview.defineColumn("iderogazkind", typeof(int),false);
	terogazkinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(terogazkinddefaultview);
	terogazkinddefaultview.defineKey("iderogazkind");

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

	//////////////////// AFFIDAMENTO /////////////////////////////////
	var taffidamento= new MetaTable("affidamento");
	taffidamento.defineColumn("aa", typeof(string),false);
	taffidamento.defineColumn("ct", typeof(DateTime),false);
	taffidamento.defineColumn("cu", typeof(string),false);
	taffidamento.defineColumn("freqobbl", typeof(string));
	taffidamento.defineColumn("frequenzaminima", typeof(int));
	taffidamento.defineColumn("frequenzaminimadebito", typeof(int));
	taffidamento.defineColumn("gratuito", typeof(string),false);
	taffidamento.defineColumn("idaffidamento", typeof(int),false);
	taffidamento.defineColumn("idaffidamentokind", typeof(int),false);
	taffidamento.defineColumn("idattivform", typeof(int),false);
	taffidamento.defineColumn("idcanale", typeof(int),false);
	taffidamento.defineColumn("idcorsostudio", typeof(int),false);
	taffidamento.defineColumn("iddidprog", typeof(int),false);
	taffidamento.defineColumn("iddidproganno", typeof(int),false);
	taffidamento.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamento.defineColumn("iddidprogori", typeof(int),false);
	taffidamento.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamento.defineColumn("iderogazkind", typeof(int));
	taffidamento.defineColumn("idreg_docenti", typeof(int));
	taffidamento.defineColumn("idsede", typeof(int),false);
	taffidamento.defineColumn("json", typeof(string));
	taffidamento.defineColumn("jsonancestor", typeof(string));
	taffidamento.defineColumn("lt", typeof(DateTime),false);
	taffidamento.defineColumn("lu", typeof(string),false);
	taffidamento.defineColumn("orariric", typeof(string));
	taffidamento.defineColumn("orariric_en", typeof(string));
	taffidamento.defineColumn("paridaffidamento", typeof(int));
	taffidamento.defineColumn("prog", typeof(string));
	taffidamento.defineColumn("prog_en", typeof(string));
	taffidamento.defineColumn("riferimento", typeof(string),false);
	taffidamento.defineColumn("start", typeof(DateTime));
	taffidamento.defineColumn("stop", typeof(DateTime));
	taffidamento.defineColumn("testi", typeof(string));
	taffidamento.defineColumn("testi_en", typeof(string));
	taffidamento.defineColumn("title", typeof(string));
	taffidamento.defineColumn("urlcorso", typeof(string));
	Tables.Add(taffidamento);
	taffidamento.defineKey("aa", "idaffidamento", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	#endregion


	#region DataRelation creation
	var cPar = new []{affidamento.Columns["aa"], affidamento.Columns["idaffidamento"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"]};
	var cChild = new []{lezione.Columns["aa"], lezione.Columns["idaffidamento"], lezione.Columns["idattivform"], lezione.Columns["idcanale"], lezione.Columns["idcorsostudio"], lezione.Columns["iddidprog"], lezione.Columns["iddidproganno"], lezione.Columns["iddidprogcurr"], lezione.Columns["iddidprogori"], lezione.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_lezione_affidamento_aa-idaffidamento-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{getdocentiperssd.Columns["aa"]};
	cChild = new []{affidamento.Columns["aa"]};
	Relations.Add(new DataRelation("FK_affidamento_getdocentiperssd_aa",cPar,cChild,false));

	cPar = new []{affidamento.Columns["aa"], affidamento.Columns["idaffidamento"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"]};
	cChild = new []{affidamentocaratteristica.Columns["aa"], affidamentocaratteristica.Columns["idaffidamento"], affidamentocaratteristica.Columns["idattivform"], affidamentocaratteristica.Columns["idcanale"], affidamentocaratteristica.Columns["idcorsostudio"], affidamentocaratteristica.Columns["iddidprog"], affidamentocaratteristica.Columns["iddidproganno"], affidamentocaratteristica.Columns["iddidprogcurr"], affidamentocaratteristica.Columns["iddidprogori"], affidamentocaratteristica.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_affidamento_aa-idaffidamento-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{affidamentocaratteristica.Columns["aa"], affidamentocaratteristica.Columns["idaffidamento"], affidamentocaratteristica.Columns["idaffidamentocaratteristica"], affidamentocaratteristica.Columns["idattivform"], affidamentocaratteristica.Columns["idcanale"], affidamentocaratteristica.Columns["idcorsostudio"], affidamentocaratteristica.Columns["iddidprog"], affidamentocaratteristica.Columns["iddidproganno"], affidamentocaratteristica.Columns["iddidprogcurr"], affidamentocaratteristica.Columns["iddidprogori"], affidamentocaratteristica.Columns["iddidprogporzanno"]};
	cChild = new []{affidamentocaratteristicaora.Columns["aa"], affidamentocaratteristicaora.Columns["idaffidamento"], affidamentocaratteristicaora.Columns["idaffidamentocaratteristica"], affidamentocaratteristicaora.Columns["idattivform"], affidamentocaratteristicaora.Columns["idcanale"], affidamentocaratteristicaora.Columns["idcorsostudio"], affidamentocaratteristicaora.Columns["iddidprog"], affidamentocaratteristicaora.Columns["iddidproganno"], affidamentocaratteristicaora.Columns["iddidprogcurr"], affidamentocaratteristicaora.Columns["iddidprogori"], affidamentocaratteristicaora.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristicaora_affidamentocaratteristica_aa-idaffidamento-idaffidamentocaratteristica-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{orakind.Columns["idorakind"]};
	cChild = new []{affidamentocaratteristicaora.Columns["idorakind"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristicaora_orakind_idorakind",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{affidamentocaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	cPar = new []{sasdgruppo.Columns["idsasdgruppo"]};
	cChild = new []{affidamentocaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_sasdgruppo_idsasdgruppo",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{affidamentocaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_sasd_idsasd",cPar,cChild,false));

	cPar = new []{ambitoareadisc.Columns["idambitoareadisc"]};
	cChild = new []{affidamentocaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_ambitoareadisc_idambitoareadisc",cPar,cChild,false));

	cPar = new []{affidamento.Columns["aa"], affidamento.Columns["idaffidamento"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"]};
	cChild = new []{affidamentoattach.Columns["aa"], affidamentoattach.Columns["idaffidamento"], affidamentoattach.Columns["idattivform"], affidamentoattach.Columns["idcanale"], affidamentoattach.Columns["idcorsostudio"], affidamentoattach.Columns["iddidprog"], affidamentoattach.Columns["iddidproganno"], affidamentoattach.Columns["iddidprogcurr"], affidamentoattach.Columns["iddidprogori"], affidamentoattach.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamentoattach_affidamento_aa-idaffidamento-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{affidamentoattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_affidamentoattach_attach_idattach",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{affidamento.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_affidamento_sede_idsede",cPar,cChild,false));

	cPar = new []{registrydocentiview.Columns["idreg"]};
	cChild = new []{affidamento.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_affidamento_registrydocentiview_idreg_docenti",cPar,cChild,false));

	cPar = new []{erogazkinddefaultview.Columns["iderogazkind"]};
	cChild = new []{affidamento.Columns["iderogazkind"]};
	Relations.Add(new DataRelation("FK_affidamento_erogazkinddefaultview_iderogazkind",cPar,cChild,false));

	cPar = new []{affidamentokinddefaultview.Columns["idaffidamentokind"]};
	cChild = new []{affidamento.Columns["idaffidamentokind"]};
	Relations.Add(new DataRelation("FK_affidamento_affidamentokinddefaultview_idaffidamentokind",cPar,cChild,false));

	#endregion

}
}
}
