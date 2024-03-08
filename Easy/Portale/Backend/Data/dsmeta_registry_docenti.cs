
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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_docenti"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registry_docenti: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_istituti 		=> (MetaTable)Tables["registry_istituti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istattitolistudio 		=> (MetaTable)Tables["istattitolistudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudio 		=> (MetaTable)Tables["titolostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensione 		=> (MetaTable)Tables["sospensione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoitineration 		=> (MetaTable)Tables["rendicontattivitaprogettoitineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage_alias1 		=> (MetaTable)Tables["workpackage_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettokind 		=> (MetaTable)Tables["rendicontattivitaprogettokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto_alias3 		=> (MetaTable)Tables["progetto_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto 		=> (MetaTable)Tables["rendicontattivitaprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontlezionestud 		=> (MetaTable)Tables["rendicontlezionestud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable lezione_alias1 		=> (MetaTable)Tables["lezione_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontaltro 		=> (MetaTable)Tables["rendicontaltro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicont 		=> (MetaTable)Tables["rendicont"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryreference 		=> (MetaTable)Tables["registryreference"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramento 		=> (MetaTable)Tables["inquadramento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatus 		=> (MetaTable)Tables["registrylegalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias5 		=> (MetaTable)Tables["geo_nation_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_alias5 		=> (MetaTable)Tables["geo_city_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable address 		=> (MetaTable)Tables["address"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaddress 		=> (MetaTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto_alias2 		=> (MetaTable)Tables["progetto_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable publicaz 		=> (MetaTable)Tables["publicaz"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable publicazregistry_docenti 		=> (MetaTable)Tables["publicazregistry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotimesheetprogetto 		=> (MetaTable)Tables["progettotimesheetprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias2 		=> (MetaTable)Tables["year_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable timesheettemplate 		=> (MetaTable)Tables["timesheettemplate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal 		=> (MetaTable)Tables["sal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto_alias1 		=> (MetaTable)Tables["progetto_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese_alias1 		=> (MetaTable)Tables["mese_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotimesheet 		=> (MetaTable)Tables["progettotimesheet"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiaryora 		=> (MetaTable)Tables["assetdiaryora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage 		=> (MetaTable)Tables["workpackage"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto 		=> (MetaTable)Tables["progetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquire 		=> (MetaTable)Tables["assetacquire"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory 		=> (MetaTable)Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable asset 		=> (MetaTable)Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiary 		=> (MetaTable)Tables["assetdiary"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentoattach 		=> (MetaTable)Tables["affidamentoattach"];

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
	public MetaTable lezione_alias2 		=> (MetaTable)Tables["lezione_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable erogazkind 		=> (MetaTable)Tables["erogazkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentokind 		=> (MetaTable)Tables["affidamentokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamento 		=> (MetaTable)Tables["affidamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekind 		=> (MetaTable)Tables["mansionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenza 		=> (MetaTable)Tables["afferenza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fonteindicebibliometrico 		=> (MetaTable)Tables["fonteindicebibliometrico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryistitutiview 		=> (MetaTable)Tables["registryistitutiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsualedefaultview 		=> (MetaTable)Tables["classconsorsualedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview_alias1 		=> (MetaTable)Tables["accmotivedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview 		=> (MetaTable)Tables["accmotivedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoorario 		=> (MetaTable)Tables["costoorario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclasspersoneview 		=> (MetaTable)Tables["registryclasspersoneview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable maritalstatus 		=> (MetaTable)Tables["maritalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattostipendioview 		=> (MetaTable)Tables["contrattostipendioview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattostipendioannuoview 		=> (MetaTable)Tables["contrattostipendioannuoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias1 		=> (MetaTable)Tables["year_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind_alias1 		=> (MetaTable)Tables["contrattokind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contratto_alias2 		=> (MetaTable)Tables["contratto_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendioannuo 		=> (MetaTable)Tables["stipendioannuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese 		=> (MetaTable)Tables["mese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contratto 		=> (MetaTable)Tables["contratto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cedolino 		=> (MetaTable)Tables["cedolino"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_docenti(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_docenti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_docenti";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_docenti.xsd";

	#region create DataTables
	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("annotation", typeof(string));
	tregistry_alias1.defineColumn("authorization_free", typeof(string));
	tregistry_alias1.defineColumn("badgecode", typeof(string));
	tregistry_alias1.defineColumn("birthdate", typeof(DateTime));
	tregistry_alias1.defineColumn("ccp", typeof(string));
	tregistry_alias1.defineColumn("cf", typeof(string));
	tregistry_alias1.defineColumn("ct", typeof(DateTime),false);
	tregistry_alias1.defineColumn("cu", typeof(string),false);
	tregistry_alias1.defineColumn("email_fe", typeof(string));
	tregistry_alias1.defineColumn("extension", typeof(string));
	tregistry_alias1.defineColumn("extmatricula", typeof(string));
	tregistry_alias1.defineColumn("flag_pa", typeof(string));
	tregistry_alias1.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry_alias1.defineColumn("foreigncf", typeof(string));
	tregistry_alias1.defineColumn("forename", typeof(string));
	tregistry_alias1.defineColumn("gender", typeof(string));
	tregistry_alias1.defineColumn("idaccmotivecredit", typeof(string));
	tregistry_alias1.defineColumn("idaccmotivedebit", typeof(string));
	tregistry_alias1.defineColumn("idateco", typeof(int));
	tregistry_alias1.defineColumn("idcategory", typeof(string));
	tregistry_alias1.defineColumn("idcentralizedcategory", typeof(string));
	tregistry_alias1.defineColumn("idcity", typeof(int));
	tregistry_alias1.defineColumn("idclassconsorsuale", typeof(int));
	tregistry_alias1.defineColumn("idexternal", typeof(int));
	tregistry_alias1.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistry_alias1.defineColumn("idmaritalstatus", typeof(string));
	tregistry_alias1.defineColumn("idnace", typeof(string));
	tregistry_alias1.defineColumn("idnation", typeof(int));
	tregistry_alias1.defineColumn("idnaturagiur", typeof(int));
	tregistry_alias1.defineColumn("idnumerodip", typeof(int));
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("idreg_istituti", typeof(int));
	tregistry_alias1.defineColumn("idregistryclass", typeof(string));
	tregistry_alias1.defineColumn("idregistrykind", typeof(int));
	tregistry_alias1.defineColumn("idsasd", typeof(int));
	tregistry_alias1.defineColumn("idstruttura", typeof(int));
	tregistry_alias1.defineColumn("idtitle", typeof(string));
	tregistry_alias1.defineColumn("indicebibliometrico", typeof(int));
	tregistry_alias1.defineColumn("ipa_fe", typeof(string));
	tregistry_alias1.defineColumn("ipa_perlapa", typeof(string));
	tregistry_alias1.defineColumn("location", typeof(string));
	tregistry_alias1.defineColumn("lt", typeof(DateTime),false);
	tregistry_alias1.defineColumn("lu", typeof(string),false);
	tregistry_alias1.defineColumn("maritalsurname", typeof(string));
	tregistry_alias1.defineColumn("multi_cf", typeof(string));
	tregistry_alias1.defineColumn("p_iva", typeof(string));
	tregistry_alias1.defineColumn("pec_fe", typeof(string));
	tregistry_alias1.defineColumn("pic", typeof(string));
	tregistry_alias1.defineColumn("residence", typeof(int),false);
	tregistry_alias1.defineColumn("ricevimento", typeof(string));
	tregistry_alias1.defineColumn("rtf", typeof(Byte[]));
	tregistry_alias1.defineColumn("sdi_defrifamm", typeof(string));
	tregistry_alias1.defineColumn("sdi_norifamm", typeof(string));
	tregistry_alias1.defineColumn("soggiorno", typeof(string));
	tregistry_alias1.defineColumn("surname", typeof(string));
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.defineColumn("title_en", typeof(string));
	tregistry_alias1.defineColumn("toredirect", typeof(int));
	tregistry_alias1.defineColumn("txt", typeof(string));
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// REGISTRY_ISTITUTI /////////////////////////////////
	var tregistry_istituti= new MetaTable("registry_istituti");
	tregistry_istituti.defineColumn("codicemiur", typeof(string));
	tregistry_istituti.defineColumn("codiceustat", typeof(string));
	tregistry_istituti.defineColumn("comune", typeof(string));
	tregistry_istituti.defineColumn("ct", typeof(DateTime));
	tregistry_istituti.defineColumn("cu", typeof(string),false);
	tregistry_istituti.defineColumn("idistitutokind", typeof(int),false);
	tregistry_istituti.defineColumn("idistitutoustat", typeof(int));
	tregistry_istituti.defineColumn("idreg", typeof(int),false);
	tregistry_istituti.defineColumn("lt", typeof(DateTime),false);
	tregistry_istituti.defineColumn("lu", typeof(string),false);
	tregistry_istituti.defineColumn("nome", typeof(string));
	tregistry_istituti.defineColumn("sortcode", typeof(int));
	tregistry_istituti.defineColumn("title", typeof(string));
	tregistry_istituti.defineColumn("title_en", typeof(string));
	Tables.Add(tregistry_istituti);
	tregistry_istituti.defineKey("idreg");

	//////////////////// ISTATTITOLISTUDIO /////////////////////////////////
	var tistattitolistudio= new MetaTable("istattitolistudio");
	tistattitolistudio.defineColumn("idistattitolistudio", typeof(int),false);
	tistattitolistudio.defineColumn("titolo", typeof(string),false);
	Tables.Add(tistattitolistudio);
	tistattitolistudio.defineKey("idistattitolistudio");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// TITOLOSTUDIO /////////////////////////////////
	var ttitolostudio= new MetaTable("titolostudio");
	ttitolostudio.defineColumn("aa", typeof(string),false);
	ttitolostudio.defineColumn("conseguito", typeof(string),false);
	ttitolostudio.defineColumn("ct", typeof(DateTime));
	ttitolostudio.defineColumn("cu", typeof(string));
	ttitolostudio.defineColumn("data", typeof(DateTime),false);
	ttitolostudio.defineColumn("giudizio", typeof(string));
	ttitolostudio.defineColumn("idattach", typeof(int));
	ttitolostudio.defineColumn("idistattitolistudio", typeof(int),false);
	ttitolostudio.defineColumn("idreg", typeof(int),false);
	ttitolostudio.defineColumn("idreg_istituti", typeof(int),false);
	ttitolostudio.defineColumn("idtitolostudio", typeof(int),false);
	ttitolostudio.defineColumn("lt", typeof(DateTime));
	ttitolostudio.defineColumn("lu", typeof(string));
	ttitolostudio.defineColumn("voto", typeof(int));
	ttitolostudio.defineColumn("votolode", typeof(string));
	ttitolostudio.defineColumn("votosu", typeof(int));
	ttitolostudio.defineColumn("!idistattitolistudio_istattitolistudio_titolo", typeof(string));
	ttitolostudio.defineColumn("!idreg_istituti_registry_istituti_title", typeof(string));
	Tables.Add(ttitolostudio);
	ttitolostudio.defineKey("idreg", "idtitolostudio");

	//////////////////// SOSPENSIONE /////////////////////////////////
	var tsospensione= new MetaTable("sospensione");
	tsospensione.defineColumn("ct", typeof(DateTime),false);
	tsospensione.defineColumn("cu", typeof(string),false);
	tsospensione.defineColumn("idaula", typeof(int));
	tsospensione.defineColumn("idedificio", typeof(int));
	tsospensione.defineColumn("idreg", typeof(int),false);
	tsospensione.defineColumn("idsede", typeof(int));
	tsospensione.defineColumn("idsospensione", typeof(int),false);
	tsospensione.defineColumn("lt", typeof(DateTime),false);
	tsospensione.defineColumn("lu", typeof(string),false);
	tsospensione.defineColumn("motivo", typeof(string));
	tsospensione.defineColumn("start", typeof(DateTime),false);
	tsospensione.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsospensione);
	tsospensione.defineKey("idreg", "idsospensione");

	//////////////////// RENDICONTATTIVITAPROGETTOITINERATION /////////////////////////////////
	var trendicontattivitaprogettoitineration= new MetaTable("rendicontattivitaprogettoitineration");
	trendicontattivitaprogettoitineration.defineColumn("iditineration", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoitineration.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(trendicontattivitaprogettoitineration);
	trendicontattivitaprogettoitineration.defineKey("iditineration", "idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var trendicontattivitaprogettoora= new MetaTable("rendicontattivitaprogettoora");
	trendicontattivitaprogettoora.defineColumn("!titleancestor", typeof(string));
	trendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("data", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("idconsolidamento", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idsal", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("ore", typeof(int));
	Tables.Add(trendicontattivitaprogettoora);
	trendicontattivitaprogettoora.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// WORKPACKAGE_ALIAS1 /////////////////////////////////
	var tworkpackage_alias1= new MetaTable("workpackage_alias1");
	tworkpackage_alias1.defineColumn("idprogetto", typeof(int),false);
	tworkpackage_alias1.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage_alias1.defineColumn("raggruppamento", typeof(string));
	tworkpackage_alias1.defineColumn("start", typeof(DateTime));
	tworkpackage_alias1.defineColumn("stop", typeof(DateTime));
	tworkpackage_alias1.defineColumn("title", typeof(string),false);
	tworkpackage_alias1.ExtendedProperties["TableForReading"]="workpackage";
	Tables.Add(tworkpackage_alias1);
	tworkpackage_alias1.defineKey("idprogetto", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOKIND /////////////////////////////////
	var trendicontattivitaprogettokind= new MetaTable("rendicontattivitaprogettokind");
	trendicontattivitaprogettokind.defineColumn("active", typeof(string));
	trendicontattivitaprogettokind.defineColumn("idrendicontattivitaprogettokind", typeof(int),false);
	trendicontattivitaprogettokind.defineColumn("title", typeof(string));
	Tables.Add(trendicontattivitaprogettokind);
	trendicontattivitaprogettokind.defineKey("idrendicontattivitaprogettokind");

	//////////////////// PROGETTO_ALIAS3 /////////////////////////////////
	var tprogetto_alias3= new MetaTable("progetto_alias3");
	tprogetto_alias3.defineColumn("idprogetto", typeof(int),false);
	tprogetto_alias3.defineColumn("start", typeof(DateTime));
	tprogetto_alias3.defineColumn("stop", typeof(DateTime));
	tprogetto_alias3.defineColumn("titolobreve", typeof(string));
	tprogetto_alias3.ExtendedProperties["TableForReading"]="progetto";
	Tables.Add(tprogetto_alias3);
	tprogetto_alias3.defineKey("idprogetto");

	//////////////////// RENDICONTATTIVITAPROGETTO /////////////////////////////////
	var trendicontattivitaprogetto= new MetaTable("rendicontattivitaprogetto");
	trendicontattivitaprogetto.defineColumn("!orerendicont", typeof(string));
	trendicontattivitaprogetto.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("datainizioprevista", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("description", typeof(string));
	trendicontattivitaprogetto.defineColumn("iditineration", typeof(int));
	trendicontattivitaprogetto.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idrendicontattivitaprogettokind", typeof(int));
	trendicontattivitaprogetto.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("orepreventivate", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("stop", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("!idprogetto_progetto_titolobreve", typeof(string));
	trendicontattivitaprogetto.defineColumn("!idprogetto_progetto_start", typeof(DateTime));
	trendicontattivitaprogetto.defineColumn("!idprogetto_progetto_stop", typeof(DateTime));
	trendicontattivitaprogetto.defineColumn("!idrendicontattivitaprogettokind_rendicontattivitaprogettokind_title", typeof(string));
	trendicontattivitaprogetto.defineColumn("!idworkpackage_workpackage_raggruppamento", typeof(string));
	trendicontattivitaprogetto.defineColumn("!idworkpackage_workpackage_title", typeof(string));
	trendicontattivitaprogetto.defineColumn("!idworkpackage_workpackage_start", typeof(DateTime));
	trendicontattivitaprogetto.defineColumn("!idworkpackage_workpackage_stop", typeof(DateTime));
	Tables.Add(trendicontattivitaprogetto);
	trendicontattivitaprogetto.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// RENDICONTLEZIONESTUD /////////////////////////////////
	var trendicontlezionestud= new MetaTable("rendicontlezionestud");
	trendicontlezionestud.defineColumn("aa", typeof(string),false);
	trendicontlezionestud.defineColumn("assente", typeof(string),false);
	trendicontlezionestud.defineColumn("ct", typeof(DateTime),false);
	trendicontlezionestud.defineColumn("cu", typeof(string),false);
	trendicontlezionestud.defineColumn("idaffidamento", typeof(int),false);
	trendicontlezionestud.defineColumn("idattivform", typeof(int),false);
	trendicontlezionestud.defineColumn("idaula", typeof(int),false);
	trendicontlezionestud.defineColumn("idcanale", typeof(int),false);
	trendicontlezionestud.defineColumn("idcorsostudio", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprog", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidproganno", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprogcurr", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprogori", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprogporzanno", typeof(int),false);
	trendicontlezionestud.defineColumn("idedificio", typeof(int),false);
	trendicontlezionestud.defineColumn("idlezione", typeof(int),false);
	trendicontlezionestud.defineColumn("idreg_docenti", typeof(int),false);
	trendicontlezionestud.defineColumn("idreg_studenti", typeof(int),false);
	trendicontlezionestud.defineColumn("idsede", typeof(int),false);
	trendicontlezionestud.defineColumn("lt", typeof(DateTime),false);
	trendicontlezionestud.defineColumn("lu", typeof(string),false);
	trendicontlezionestud.defineColumn("notadisciplinare", typeof(string));
	trendicontlezionestud.defineColumn("ritardo", typeof(DateTime));
	trendicontlezionestud.defineColumn("ritardogiustifica", typeof(string));
	Tables.Add(trendicontlezionestud);
	trendicontlezionestud.defineKey("aa", "idaffidamento", "idattivform", "idaula", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idedificio", "idlezione", "idreg_docenti", "idreg_studenti", "idsede");

	//////////////////// LEZIONE_ALIAS1 /////////////////////////////////
	var tlezione_alias1= new MetaTable("lezione_alias1");
	tlezione_alias1.defineColumn("!title", typeof(string));
	tlezione_alias1.defineColumn("aa", typeof(string),false);
	tlezione_alias1.defineColumn("ct", typeof(DateTime),false);
	tlezione_alias1.defineColumn("cu", typeof(string),false);
	tlezione_alias1.defineColumn("idaffidamento", typeof(int),false);
	tlezione_alias1.defineColumn("idattivform", typeof(int),false);
	tlezione_alias1.defineColumn("idaula", typeof(int),false);
	tlezione_alias1.defineColumn("idcanale", typeof(int),false);
	tlezione_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tlezione_alias1.defineColumn("iddidprog", typeof(int),false);
	tlezione_alias1.defineColumn("iddidproganno", typeof(int),false);
	tlezione_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tlezione_alias1.defineColumn("iddidprogori", typeof(int),false);
	tlezione_alias1.defineColumn("iddidprogporzanno", typeof(int),false);
	tlezione_alias1.defineColumn("idedificio", typeof(int),false);
	tlezione_alias1.defineColumn("idlezione", typeof(int),false);
	tlezione_alias1.defineColumn("idreg_docenti", typeof(int),false);
	tlezione_alias1.defineColumn("idsede", typeof(int),false);
	tlezione_alias1.defineColumn("lt", typeof(DateTime),false);
	tlezione_alias1.defineColumn("lu", typeof(string),false);
	tlezione_alias1.defineColumn("nonsvolta", typeof(string));
	tlezione_alias1.defineColumn("stage", typeof(string));
	tlezione_alias1.defineColumn("start", typeof(DateTime),false);
	tlezione_alias1.defineColumn("stop", typeof(DateTime),false);
	tlezione_alias1.defineColumn("visita", typeof(string));
	tlezione_alias1.ExtendedProperties["TableForReading"]="lezione";
	Tables.Add(tlezione_alias1);
	tlezione_alias1.defineKey("aa", "idaffidamento", "idattivform", "idaula", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idedificio", "idlezione", "idreg_docenti", "idsede");

	//////////////////// RENDICONTALTRO /////////////////////////////////
	var trendicontaltro= new MetaTable("rendicontaltro");
	trendicontaltro.defineColumn("!title", typeof(string));
	trendicontaltro.defineColumn("aa", typeof(string),false);
	trendicontaltro.defineColumn("ct", typeof(DateTime),false);
	trendicontaltro.defineColumn("cu", typeof(string),false);
	trendicontaltro.defineColumn("data", typeof(DateTime),false);
	trendicontaltro.defineColumn("idreg_docenti", typeof(int),false);
	trendicontaltro.defineColumn("idrendicontaltro", typeof(int),false);
	trendicontaltro.defineColumn("idrendicontaltrokind", typeof(int),false);
	trendicontaltro.defineColumn("lt", typeof(DateTime),false);
	trendicontaltro.defineColumn("lu", typeof(string),false);
	trendicontaltro.defineColumn("ore", typeof(decimal),false);
	Tables.Add(trendicontaltro);
	trendicontaltro.defineKey("aa", "idreg_docenti", "idrendicontaltro");

	//////////////////// RENDICONT /////////////////////////////////
	var trendicont= new MetaTable("rendicont");
	trendicont.defineColumn("aa", typeof(string),false);
	trendicont.defineColumn("ct", typeof(DateTime),false);
	trendicont.defineColumn("cu", typeof(string),false);
	trendicont.defineColumn("idreg_docenti", typeof(int),false);
	trendicont.defineColumn("lt", typeof(DateTime),false);
	trendicont.defineColumn("lu", typeof(string),false);
	trendicont.defineColumn("title", typeof(string));
	Tables.Add(trendicont);
	trendicont.defineKey("aa", "idreg_docenti");

	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new MetaTable("registryreference");
	tregistryreference.defineColumn("activeweb", typeof(string));
	tregistryreference.defineColumn("ct", typeof(DateTime),false);
	tregistryreference.defineColumn("cu", typeof(string),false);
	tregistryreference.defineColumn("email", typeof(string));
	tregistryreference.defineColumn("faxnumber", typeof(string));
	tregistryreference.defineColumn("flagdefault", typeof(string));
	tregistryreference.defineColumn("idreg", typeof(int),false);
	tregistryreference.defineColumn("idregistryreference", typeof(int),false);
	tregistryreference.defineColumn("iterweb", typeof(int));
	tregistryreference.defineColumn("lt", typeof(DateTime),false);
	tregistryreference.defineColumn("lu", typeof(string),false);
	tregistryreference.defineColumn("mobilenumber", typeof(string));
	tregistryreference.defineColumn("msnnumber", typeof(string));
	tregistryreference.defineColumn("passwordweb", typeof(string));
	tregistryreference.defineColumn("pec", typeof(string));
	tregistryreference.defineColumn("phonenumber", typeof(string));
	tregistryreference.defineColumn("referencename", typeof(string),false);
	tregistryreference.defineColumn("registryreferencerole", typeof(string));
	tregistryreference.defineColumn("rtf", typeof(Byte[]));
	tregistryreference.defineColumn("saltweb", typeof(string));
	tregistryreference.defineColumn("skypenumber", typeof(string));
	tregistryreference.defineColumn("txt", typeof(string));
	tregistryreference.defineColumn("userweb", typeof(string));
	tregistryreference.defineColumn("website", typeof(string));
	Tables.Add(tregistryreference);
	tregistryreference.defineKey("idreg", "idregistryreference");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("title", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// INQUADRAMENTO /////////////////////////////////
	var tinquadramento= new MetaTable("inquadramento");
	tinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tinquadramento.defineColumn("idposition", typeof(int),false);
	tinquadramento.defineColumn("tempdef", typeof(string));
	tinquadramento.defineColumn("title", typeof(string));
	Tables.Add(tinquadramento);
	tinquadramento.defineKey("idinquadramento", "idposition");

	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	var tregistrylegalstatus= new MetaTable("registrylegalstatus");
	tregistrylegalstatus.defineColumn("!anni", typeof(string));
	tregistrylegalstatus.defineColumn("!giorni", typeof(string));
	tregistrylegalstatus.defineColumn("!mesi", typeof(string));
	tregistrylegalstatus.defineColumn("active", typeof(string));
	tregistrylegalstatus.defineColumn("csa_class", typeof(string));
	tregistrylegalstatus.defineColumn("csa_compartment", typeof(string));
	tregistrylegalstatus.defineColumn("csa_role", typeof(string));
	tregistrylegalstatus.defineColumn("ct", typeof(DateTime));
	tregistrylegalstatus.defineColumn("cu", typeof(string));
	tregistrylegalstatus.defineColumn("datarivalutazione", typeof(DateTime));
	tregistrylegalstatus.defineColumn("flagdefault", typeof(string));
	tregistrylegalstatus.defineColumn("iddaliaposition", typeof(int));
	tregistrylegalstatus.defineColumn("idinquadramento", typeof(int));
	tregistrylegalstatus.defineColumn("idposition", typeof(int));
	tregistrylegalstatus.defineColumn("idreg", typeof(int),false);
	tregistrylegalstatus.defineColumn("idregistrylegalstatus", typeof(int),false);
	tregistrylegalstatus.defineColumn("incomeclass", typeof(int));
	tregistrylegalstatus.defineColumn("incomeclassvalidity", typeof(DateTime));
	tregistrylegalstatus.defineColumn("livello", typeof(int));
	tregistrylegalstatus.defineColumn("lt", typeof(DateTime));
	tregistrylegalstatus.defineColumn("lu", typeof(string));
	tregistrylegalstatus.defineColumn("parttime", typeof(decimal));
	tregistrylegalstatus.defineColumn("percentualesufondiateneo", typeof(decimal));
	tregistrylegalstatus.defineColumn("rtf", typeof(Byte[]));
	tregistrylegalstatus.defineColumn("start", typeof(DateTime));
	tregistrylegalstatus.defineColumn("stop", typeof(DateTime));
	tregistrylegalstatus.defineColumn("tempdef", typeof(string));
	tregistrylegalstatus.defineColumn("tempindet", typeof(string));
	tregistrylegalstatus.defineColumn("txt", typeof(string));
	tregistrylegalstatus.defineColumn("!idinquadramento_inquadramento_title", typeof(string));
	tregistrylegalstatus.defineColumn("!idinquadramento_inquadramento_tempdef", typeof(string));
	tregistrylegalstatus.defineColumn("!idposition_position_title", typeof(string));
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.defineKey("idreg", "idregistrylegalstatus");

	//////////////////// GEO_NATION_ALIAS5 /////////////////////////////////
	var tgeo_nation_alias5= new MetaTable("geo_nation_alias5");
	tgeo_nation_alias5.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias5.defineColumn("title", typeof(string));
	tgeo_nation_alias5.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias5);
	tgeo_nation_alias5.defineKey("idnation");

	//////////////////// GEO_CITY_ALIAS5 /////////////////////////////////
	var tgeo_city_alias5= new MetaTable("geo_city_alias5");
	tgeo_city_alias5.defineColumn("idcity", typeof(int),false);
	tgeo_city_alias5.defineColumn("title", typeof(string));
	tgeo_city_alias5.ExtendedProperties["TableForReading"]="geo_city";
	Tables.Add(tgeo_city_alias5);
	tgeo_city_alias5.defineKey("idcity");

	//////////////////// ADDRESS /////////////////////////////////
	var taddress= new MetaTable("address");
	taddress.defineColumn("active", typeof(string));
	taddress.defineColumn("description", typeof(string),false);
	taddress.defineColumn("idaddress", typeof(int),false);
	Tables.Add(taddress);
	taddress.defineKey("idaddress");

	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new MetaTable("registryaddress");
	tregistryaddress.defineColumn("active", typeof(string));
	tregistryaddress.defineColumn("address", typeof(string));
	tregistryaddress.defineColumn("annotations", typeof(string));
	tregistryaddress.defineColumn("cap", typeof(string));
	tregistryaddress.defineColumn("ct", typeof(DateTime));
	tregistryaddress.defineColumn("cu", typeof(string));
	tregistryaddress.defineColumn("flagforeign", typeof(string));
	tregistryaddress.defineColumn("idaddresskind", typeof(int),false);
	tregistryaddress.defineColumn("idcity", typeof(int));
	tregistryaddress.defineColumn("idnation", typeof(int));
	tregistryaddress.defineColumn("idreg", typeof(int),false);
	tregistryaddress.defineColumn("location", typeof(string));
	tregistryaddress.defineColumn("lt", typeof(DateTime));
	tregistryaddress.defineColumn("lu", typeof(string));
	tregistryaddress.defineColumn("officename", typeof(string));
	tregistryaddress.defineColumn("recipientagency", typeof(string));
	tregistryaddress.defineColumn("start", typeof(DateTime),false);
	tregistryaddress.defineColumn("stop", typeof(DateTime));
	tregistryaddress.defineColumn("!idaddresskind_address_description", typeof(string));
	tregistryaddress.defineColumn("!idcity_geo_city_title", typeof(string));
	tregistryaddress.defineColumn("!idnation_geo_nation_title", typeof(string));
	Tables.Add(tregistryaddress);
	tregistryaddress.defineKey("idaddresskind", "idreg", "start");

	//////////////////// PROGETTO_ALIAS2 /////////////////////////////////
	var tprogetto_alias2= new MetaTable("progetto_alias2");
	tprogetto_alias2.defineColumn("idprogetto", typeof(int),false);
	tprogetto_alias2.defineColumn("start", typeof(DateTime));
	tprogetto_alias2.defineColumn("stop", typeof(DateTime));
	tprogetto_alias2.defineColumn("titolobreve", typeof(string),false);
	tprogetto_alias2.ExtendedProperties["TableForReading"]="progetto";
	Tables.Add(tprogetto_alias2);
	tprogetto_alias2.defineKey("idprogetto");

	//////////////////// PUBLICAZ /////////////////////////////////
	var tpublicaz= new MetaTable("publicaz");
	tpublicaz.defineColumn("abstractstring", typeof(string));
	tpublicaz.defineColumn("annocopyright", typeof(int));
	tpublicaz.defineColumn("annopub", typeof(int));
	tpublicaz.defineColumn("ct", typeof(DateTime),false);
	tpublicaz.defineColumn("cu", typeof(string),false);
	tpublicaz.defineColumn("editore", typeof(string));
	tpublicaz.defineColumn("fascicolo", typeof(string));
	tpublicaz.defineColumn("idcity", typeof(int));
	tpublicaz.defineColumn("idcity_ed", typeof(int));
	tpublicaz.defineColumn("idnation_ed", typeof(int));
	tpublicaz.defineColumn("idnation_lang", typeof(int));
	tpublicaz.defineColumn("idprogetto", typeof(int));
	tpublicaz.defineColumn("idpublicaz", typeof(int),false);
	tpublicaz.defineColumn("isbn", typeof(string));
	tpublicaz.defineColumn("lt", typeof(DateTime),false);
	tpublicaz.defineColumn("lu", typeof(string),false);
	tpublicaz.defineColumn("numrivista", typeof(int));
	tpublicaz.defineColumn("pagestart", typeof(int));
	tpublicaz.defineColumn("pagestop", typeof(int));
	tpublicaz.defineColumn("pagetot", typeof(int));
	tpublicaz.defineColumn("title", typeof(string));
	tpublicaz.defineColumn("title2", typeof(string));
	tpublicaz.defineColumn("volume", typeof(string));
	Tables.Add(tpublicaz);
	tpublicaz.defineKey("idpublicaz");

	//////////////////// PUBLICAZREGISTRY_DOCENTI /////////////////////////////////
	var tpublicazregistry_docenti= new MetaTable("publicazregistry_docenti");
	tpublicazregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tpublicazregistry_docenti.defineColumn("cu", typeof(string),false);
	tpublicazregistry_docenti.defineColumn("idpublicaz", typeof(int),false);
	tpublicazregistry_docenti.defineColumn("idreg_docenti", typeof(int),false);
	tpublicazregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tpublicazregistry_docenti.defineColumn("lu", typeof(string),false);
	tpublicazregistry_docenti.defineColumn("!idpublicaz_publicaz_title", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idpublicaz_publicaz_title2", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idpublicaz_publicaz_annopub", typeof(int));
	tpublicazregistry_docenti.defineColumn("!idpublicaz_publicaz_editore", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idpublicaz_progetto_alias2_titolobreve", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idpublicaz_progetto_alias2_start", typeof(DateTime));
	tpublicazregistry_docenti.defineColumn("!idpublicaz_progetto_alias2_stop", typeof(DateTime));
	Tables.Add(tpublicazregistry_docenti);
	tpublicazregistry_docenti.defineKey("idpublicaz", "idreg_docenti");

	//////////////////// PROGETTOTIMESHEETPROGETTO /////////////////////////////////
	var tprogettotimesheetprogetto= new MetaTable("progettotimesheetprogetto");
	tprogettotimesheetprogetto.defineColumn("ct", typeof(DateTime));
	tprogettotimesheetprogetto.defineColumn("cu", typeof(string));
	tprogettotimesheetprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogettotimesheetprogetto.defineColumn("idprogettotimesheet", typeof(int),false);
	tprogettotimesheetprogetto.defineColumn("lt", typeof(DateTime));
	tprogettotimesheetprogetto.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotimesheetprogetto);
	tprogettotimesheetprogetto.defineKey("idprogetto", "idprogettotimesheet");

	//////////////////// YEAR_ALIAS2 /////////////////////////////////
	var tyear_alias2= new MetaTable("year_alias2");
	tyear_alias2.defineColumn("year", typeof(int),false);
	tyear_alias2.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias2);
	tyear_alias2.defineKey("year");

	//////////////////// TIMESHEETTEMPLATE /////////////////////////////////
	var ttimesheettemplate= new MetaTable("timesheettemplate");
	ttimesheettemplate.defineColumn("idtimesheettemplate", typeof(string),false);
	Tables.Add(ttimesheettemplate);
	ttimesheettemplate.defineKey("idtimesheettemplate");

	//////////////////// SAL /////////////////////////////////
	var tsal= new MetaTable("sal");
	tsal.defineColumn("datablocco", typeof(DateTime));
	tsal.defineColumn("idprogetto", typeof(int),false);
	tsal.defineColumn("idsal", typeof(int),false);
	tsal.defineColumn("start", typeof(DateTime));
	tsal.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsal);
	tsal.defineKey("idprogetto", "idsal");

	//////////////////// PROGETTO_ALIAS1 /////////////////////////////////
	var tprogetto_alias1= new MetaTable("progetto_alias1");
	tprogetto_alias1.defineColumn("idprogetto", typeof(int),false);
	tprogetto_alias1.defineColumn("start", typeof(DateTime));
	tprogetto_alias1.defineColumn("stop", typeof(DateTime));
	tprogetto_alias1.defineColumn("titolobreve", typeof(string));
	tprogetto_alias1.ExtendedProperties["TableForReading"]="progetto";
	Tables.Add(tprogetto_alias1);
	tprogetto_alias1.defineKey("idprogetto");

	//////////////////// MESE_ALIAS1 /////////////////////////////////
	var tmese_alias1= new MetaTable("mese_alias1");
	tmese_alias1.defineColumn("idmese", typeof(int),false);
	tmese_alias1.defineColumn("title", typeof(string));
	tmese_alias1.ExtendedProperties["TableForReading"]="mese";
	Tables.Add(tmese_alias1);
	tmese_alias1.defineKey("idmese");

	//////////////////// PROGETTOTIMESHEET /////////////////////////////////
	var tprogettotimesheet= new MetaTable("progettotimesheet");
	tprogettotimesheet.defineColumn("collapseteachingother", typeof(string));
	tprogettotimesheet.defineColumn("ct", typeof(DateTime));
	tprogettotimesheet.defineColumn("cu", typeof(string));
	tprogettotimesheet.defineColumn("idmese", typeof(int));
	tprogettotimesheet.defineColumn("idprogetto", typeof(int));
	tprogettotimesheet.defineColumn("idprogettotimesheet", typeof(int),false);
	tprogettotimesheet.defineColumn("idreg", typeof(int),false);
	tprogettotimesheet.defineColumn("idsal", typeof(int));
	tprogettotimesheet.defineColumn("idtimesheettemplate", typeof(string));
	tprogettotimesheet.defineColumn("intestazioneallsheet", typeof(string));
	tprogettotimesheet.defineColumn("lt", typeof(DateTime));
	tprogettotimesheet.defineColumn("lu", typeof(string));
	tprogettotimesheet.defineColumn("multilinetype", typeof(string));
	tprogettotimesheet.defineColumn("output", typeof(string));
	tprogettotimesheet.defineColumn("riepilogoanno", typeof(string));
	tprogettotimesheet.defineColumn("showactivitiesrow", typeof(string));
	tprogettotimesheet.defineColumn("showotheractivitiesrow", typeof(string));
	tprogettotimesheet.defineColumn("title", typeof(string));
	tprogettotimesheet.defineColumn("withworkpackage", typeof(string));
	tprogettotimesheet.defineColumn("year", typeof(int));
	tprogettotimesheet.defineColumn("!idmese_mese_title", typeof(string));
	tprogettotimesheet.defineColumn("!idprogetto_progetto_titolobreve", typeof(string));
	tprogettotimesheet.defineColumn("!idprogetto_progetto_start", typeof(DateTime));
	tprogettotimesheet.defineColumn("!idprogetto_progetto_stop", typeof(DateTime));
	tprogettotimesheet.defineColumn("!idsal_sal_start", typeof(DateTime));
	tprogettotimesheet.defineColumn("!idsal_sal_stop", typeof(DateTime));
	tprogettotimesheet.defineColumn("!idsal_sal_datablocco", typeof(DateTime));
	Tables.Add(tprogettotimesheet);
	tprogettotimesheet.defineKey("idprogettotimesheet", "idreg");

	//////////////////// ASSETDIARYORA /////////////////////////////////
	var tassetdiaryora= new MetaTable("assetdiaryora");
	tassetdiaryora.defineColumn("!title", typeof(string));
	tassetdiaryora.defineColumn("amount", typeof(decimal));
	tassetdiaryora.defineColumn("ct", typeof(DateTime),false);
	tassetdiaryora.defineColumn("cu", typeof(string),false);
	tassetdiaryora.defineColumn("idassetdiary", typeof(int),false);
	tassetdiaryora.defineColumn("idassetdiaryora", typeof(int),false);
	tassetdiaryora.defineColumn("idsal", typeof(int));
	tassetdiaryora.defineColumn("idworkpackage", typeof(int),false);
	tassetdiaryora.defineColumn("lt", typeof(DateTime),false);
	tassetdiaryora.defineColumn("lu", typeof(string),false);
	tassetdiaryora.defineColumn("start", typeof(DateTime));
	tassetdiaryora.defineColumn("stop", typeof(DateTime));
	Tables.Add(tassetdiaryora);
	tassetdiaryora.defineKey("idassetdiary", "idassetdiaryora", "idworkpackage");

	//////////////////// WORKPACKAGE /////////////////////////////////
	var tworkpackage= new MetaTable("workpackage");
	tworkpackage.defineColumn("idprogetto", typeof(int),false);
	tworkpackage.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage.defineColumn("raggruppamento", typeof(string));
	tworkpackage.defineColumn("title", typeof(string),false);
	Tables.Add(tworkpackage);
	tworkpackage.defineKey("idprogetto", "idworkpackage");

	//////////////////// PROGETTO /////////////////////////////////
	var tprogetto= new MetaTable("progetto");
	tprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogetto.defineColumn("titolobreve", typeof(string));
	Tables.Add(tprogetto);
	tprogetto.defineKey("idprogetto");

	//////////////////// ASSETACQUIRE /////////////////////////////////
	var tassetacquire= new MetaTable("assetacquire");
	tassetacquire.defineColumn("description", typeof(string),false);
	tassetacquire.defineColumn("idinv", typeof(int),false);
	tassetacquire.defineColumn("idupb", typeof(string));
	tassetacquire.defineColumn("nassetacquire", typeof(int),false);
	Tables.Add(tassetacquire);
	tassetacquire.defineKey("nassetacquire");

	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new MetaTable("inventory");
	tinventory.defineColumn("active", typeof(string));
	tinventory.defineColumn("codeinventory", typeof(string),false);
	tinventory.defineColumn("description", typeof(string),false);
	tinventory.defineColumn("idinventory", typeof(int),false);
	Tables.Add(tinventory);
	tinventory.defineKey("idinventory");

	//////////////////// ASSET /////////////////////////////////
	var tasset= new MetaTable("asset");
	tasset.defineColumn("idasset", typeof(int),false);
	tasset.defineColumn("idinventory", typeof(int));
	tasset.defineColumn("idpiece", typeof(int),false);
	tasset.defineColumn("nassetacquire", typeof(int));
	tasset.defineColumn("ninventory", typeof(int));
	tasset.defineColumn("rfid", typeof(string));
	Tables.Add(tasset);
	tasset.defineKey("idasset", "idpiece");

	//////////////////// ASSETDIARY /////////////////////////////////
	var tassetdiary= new MetaTable("assetdiary");
	tassetdiary.defineColumn("ct", typeof(DateTime),false);
	tassetdiary.defineColumn("cu", typeof(string),false);
	tassetdiary.defineColumn("idasset", typeof(int),false);
	tassetdiary.defineColumn("idassetdiary", typeof(int),false);
	tassetdiary.defineColumn("idpiece", typeof(int));
	tassetdiary.defineColumn("idprogetto", typeof(int),false);
	tassetdiary.defineColumn("idreg", typeof(int),false);
	tassetdiary.defineColumn("idworkpackage", typeof(int),false);
	tassetdiary.defineColumn("lt", typeof(DateTime),false);
	tassetdiary.defineColumn("lu", typeof(string),false);
	tassetdiary.defineColumn("orepreventivate", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_ninventory", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idasset", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idpiece", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_rfid", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idinventory_codeinventory", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idinventory_description", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_description", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_idinv", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_idupb", typeof(string));
	tassetdiary.defineColumn("!idprogetto_progetto_titolobreve", typeof(string));
	tassetdiary.defineColumn("!idworkpackage_workpackage_raggruppamento", typeof(string));
	tassetdiary.defineColumn("!idworkpackage_workpackage_title", typeof(string));
	tassetdiary.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tassetdiary);
	tassetdiary.defineKey("idassetdiary", "idworkpackage");

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
	taffidamentoattach.defineColumn("idreg_docenti", typeof(int),false);
	taffidamentoattach.defineColumn("lt", typeof(DateTime),false);
	taffidamentoattach.defineColumn("lu", typeof(string),false);
	Tables.Add(taffidamentoattach);
	taffidamentoattach.defineKey("aa", "idaffidamento", "idattach", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idreg_docenti");

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
	taffidamentocaratteristica.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(taffidamentocaratteristica);
	taffidamentocaratteristica.defineKey("aa", "idaffidamento", "idaffidamentocaratteristica", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// LEZIONE_ALIAS2 /////////////////////////////////
	var tlezione_alias2= new MetaTable("lezione_alias2");
	tlezione_alias2.defineColumn("!title", typeof(string));
	tlezione_alias2.defineColumn("aa", typeof(string),false);
	tlezione_alias2.defineColumn("ct", typeof(DateTime),false);
	tlezione_alias2.defineColumn("cu", typeof(string),false);
	tlezione_alias2.defineColumn("idaffidamento", typeof(int),false);
	tlezione_alias2.defineColumn("idattivform", typeof(int),false);
	tlezione_alias2.defineColumn("idaula", typeof(int),false);
	tlezione_alias2.defineColumn("idcanale", typeof(int),false);
	tlezione_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tlezione_alias2.defineColumn("iddidprog", typeof(int),false);
	tlezione_alias2.defineColumn("iddidproganno", typeof(int),false);
	tlezione_alias2.defineColumn("iddidprogcurr", typeof(int),false);
	tlezione_alias2.defineColumn("iddidprogori", typeof(int),false);
	tlezione_alias2.defineColumn("iddidprogporzanno", typeof(int),false);
	tlezione_alias2.defineColumn("idedificio", typeof(int),false);
	tlezione_alias2.defineColumn("idlezione", typeof(int),false);
	tlezione_alias2.defineColumn("idreg_docenti", typeof(int),false);
	tlezione_alias2.defineColumn("idsede", typeof(int),false);
	tlezione_alias2.defineColumn("lt", typeof(DateTime),false);
	tlezione_alias2.defineColumn("lu", typeof(string),false);
	tlezione_alias2.defineColumn("nonsvolta", typeof(string));
	tlezione_alias2.defineColumn("stage", typeof(string));
	tlezione_alias2.defineColumn("start", typeof(DateTime),false);
	tlezione_alias2.defineColumn("stop", typeof(DateTime),false);
	tlezione_alias2.defineColumn("visita", typeof(string));
	tlezione_alias2.ExtendedProperties["TableForReading"]="lezione";
	Tables.Add(tlezione_alias2);
	tlezione_alias2.defineKey("aa", "idaffidamento", "idattivform", "idaula", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idedificio", "idlezione", "idreg_docenti", "idsede");

	//////////////////// EROGAZKIND /////////////////////////////////
	var terogazkind= new MetaTable("erogazkind");
	terogazkind.defineColumn("active", typeof(string),false);
	terogazkind.defineColumn("iderogazkind", typeof(int),false);
	terogazkind.defineColumn("title", typeof(string),false);
	Tables.Add(terogazkind);
	terogazkind.defineKey("iderogazkind");

	//////////////////// AFFIDAMENTOKIND /////////////////////////////////
	var taffidamentokind= new MetaTable("affidamentokind");
	taffidamentokind.defineColumn("active", typeof(string),false);
	taffidamentokind.defineColumn("idaffidamentokind", typeof(int),false);
	taffidamentokind.defineColumn("title", typeof(string),false);
	Tables.Add(taffidamentokind);
	taffidamentokind.defineKey("idaffidamentokind");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

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
	taffidamento.defineColumn("idreg_docenti", typeof(int),false);
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
	taffidamento.defineColumn("!idaffidamentokind_affidamentokind_title", typeof(string));
	taffidamento.defineColumn("!iderogazkind_erogazkind_title", typeof(string));
	taffidamento.defineColumn("!affidamentocaratteristica", typeof(string));
	Tables.Add(taffidamento);
	taffidamento.defineKey("aa", "idaffidamento", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idreg_docenti");

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
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("title", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// MANSIONEKIND /////////////////////////////////
	var tmansionekind= new MetaTable("mansionekind");
	tmansionekind.defineColumn("idmansionekind", typeof(int),false);
	tmansionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tmansionekind);
	tmansionekind.defineKey("idmansionekind");

	//////////////////// AFFERENZA /////////////////////////////////
	var tafferenza= new MetaTable("afferenza");
	tafferenza.defineColumn("ct", typeof(DateTime),false);
	tafferenza.defineColumn("cu", typeof(string),false);
	tafferenza.defineColumn("idafferenza", typeof(int),false);
	tafferenza.defineColumn("idmansionekind", typeof(int));
	tafferenza.defineColumn("idreg", typeof(int),false);
	tafferenza.defineColumn("idstruttura", typeof(int));
	tafferenza.defineColumn("lt", typeof(DateTime),false);
	tafferenza.defineColumn("lu", typeof(string),false);
	tafferenza.defineColumn("start", typeof(DateTime));
	tafferenza.defineColumn("stop", typeof(DateTime));
	tafferenza.defineColumn("!idmansionekind_mansionekind_title", typeof(string));
	tafferenza.defineColumn("!idstruttura_struttura_title", typeof(string));
	tafferenza.defineColumn("!idstruttura_struttura_idstrutturakind_title", typeof(string));
	Tables.Add(tafferenza);
	tafferenza.defineKey("idafferenza", "idreg");

	//////////////////// FONTEINDICEBIBLIOMETRICO /////////////////////////////////
	var tfonteindicebibliometrico= new MetaTable("fonteindicebibliometrico");
	tfonteindicebibliometrico.defineColumn("active", typeof(string));
	tfonteindicebibliometrico.defineColumn("idfonteindicebibliometrico", typeof(int),false);
	tfonteindicebibliometrico.defineColumn("title", typeof(string));
	Tables.Add(tfonteindicebibliometrico);
	tfonteindicebibliometrico.defineKey("idfonteindicebibliometrico");

	//////////////////// REGISTRYISTITUTIVIEW /////////////////////////////////
	var tregistryistitutiview= new MetaTable("registryistitutiview");
	tregistryistitutiview.defineColumn("dropdown_title", typeof(string),false);
	tregistryistitutiview.defineColumn("idreg", typeof(int),false);
	tregistryistitutiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistryistitutiview);
	tregistryistitutiview.defineKey("idreg");

	//////////////////// CLASSCONSORSUALEDEFAULTVIEW /////////////////////////////////
	var tclassconsorsualedefaultview= new MetaTable("classconsorsualedefaultview");
	tclassconsorsualedefaultview.defineColumn("classconsorsuale_active", typeof(string));
	tclassconsorsualedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tclassconsorsualedefaultview.defineColumn("idclassconsorsuale", typeof(int),false);
	Tables.Add(tclassconsorsualedefaultview);
	tclassconsorsualedefaultview.defineKey("idclassconsorsuale");

	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
	Tables.Add(tsasddefaultview);
	tsasddefaultview.defineKey("idsasd");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// ACCMOTIVEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var taccmotivedefaultview_alias1= new MetaTable("accmotivedefaultview_alias1");
	taccmotivedefaultview_alias1.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview_alias1.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview_alias1.ExtendedProperties["TableForReading"]="accmotivedefaultview";
	Tables.Add(taccmotivedefaultview_alias1);
	taccmotivedefaultview_alias1.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEDEFAULTVIEW /////////////////////////////////
	var taccmotivedefaultview= new MetaTable("accmotivedefaultview");
	taccmotivedefaultview.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview.defineColumn("idaccmotive", typeof(string),false);
	Tables.Add(taccmotivedefaultview);
	taccmotivedefaultview.defineKey("idaccmotive");

	//////////////////// COSTOORARIO /////////////////////////////////
	var tcostoorario= new MetaTable("costoorario");
	tcostoorario.defineColumn("ct", typeof(DateTime),false);
	tcostoorario.defineColumn("cu", typeof(string),false);
	tcostoorario.defineColumn("idcostoorario", typeof(int),false);
	tcostoorario.defineColumn("idreg", typeof(int),false);
	tcostoorario.defineColumn("irap", typeof(decimal));
	tcostoorario.defineColumn("lt", typeof(DateTime),false);
	tcostoorario.defineColumn("lu", typeof(string),false);
	tcostoorario.defineColumn("netto", typeof(decimal));
	tcostoorario.defineColumn("oneri", typeof(decimal));
	tcostoorario.defineColumn("start", typeof(DateTime));
	tcostoorario.defineColumn("stop", typeof(DateTime));
	tcostoorario.defineColumn("totale", typeof(decimal));
	Tables.Add(tcostoorario);
	tcostoorario.defineKey("idcostoorario", "idreg");

	//////////////////// RESIDENCE /////////////////////////////////
	var tresidence= new MetaTable("residence");
	tresidence.defineColumn("active", typeof(string));
	tresidence.defineColumn("coderesidence", typeof(string),false);
	tresidence.defineColumn("description", typeof(string),false);
	tresidence.defineColumn("idresidence", typeof(int),false);
	tresidence.defineColumn("lt", typeof(DateTime));
	tresidence.defineColumn("lu", typeof(string));
	Tables.Add(tresidence);
	tresidence.defineKey("idresidence");

	//////////////////// REGISTRYCLASSPERSONEVIEW /////////////////////////////////
	var tregistryclasspersoneview= new MetaTable("registryclasspersoneview");
	tregistryclasspersoneview.defineColumn("description", typeof(string),false);
	tregistryclasspersoneview.defineColumn("dropdown_title", typeof(string),false);
	tregistryclasspersoneview.defineColumn("idregistryclass", typeof(string),false);
	tregistryclasspersoneview.defineColumn("registryclass_active", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_ct", typeof(DateTime),false);
	tregistryclasspersoneview.defineColumn("registryclass_cu", typeof(string),false);
	tregistryclasspersoneview.defineColumn("registryclass_flagbadgecode", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagbadgecode_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagCF", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagcf_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagcfbutton", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagextmatricula", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagextmatricula_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagfiscalresidence", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagfiscalresidence_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagforeigncf", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagforeigncf_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flaghuman", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flaginfofromcfbutton", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagmaritalstatus", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagmaritalstatus_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagmaritalsurname", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagmaritalsurname_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagothers", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagothers_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagp_iva", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagp_iva_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagqualification", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagqualification_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagresidence", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagresidence_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagtitle", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_flagtitle_forced", typeof(string));
	tregistryclasspersoneview.defineColumn("registryclass_lt", typeof(DateTime),false);
	tregistryclasspersoneview.defineColumn("registryclass_lu", typeof(string),false);
	Tables.Add(tregistryclasspersoneview);
	tregistryclasspersoneview.defineKey("idregistryclass");

	//////////////////// MARITALSTATUS /////////////////////////////////
	var tmaritalstatus= new MetaTable("maritalstatus");
	tmaritalstatus.defineColumn("active", typeof(string));
	tmaritalstatus.defineColumn("ct", typeof(DateTime),false);
	tmaritalstatus.defineColumn("cu", typeof(string),false);
	tmaritalstatus.defineColumn("description", typeof(string),false);
	tmaritalstatus.defineColumn("idmaritalstatus", typeof(string),false);
	tmaritalstatus.defineColumn("lt", typeof(DateTime),false);
	tmaritalstatus.defineColumn("lu", typeof(string),false);
	Tables.Add(tmaritalstatus);
	tmaritalstatus.defineKey("idmaritalstatus");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// CONTRATTOSTIPENDIOVIEW /////////////////////////////////
	var tcontrattostipendioview= new MetaTable("contrattostipendioview");
	tcontrattostipendioview.defineColumn("anno", typeof(int),false);
	tcontrattostipendioview.defineColumn("assegno", typeof(decimal));
	tcontrattostipendioview.defineColumn("caricoente", typeof(decimal));
	tcontrattostipendioview.defineColumn("classe", typeof(int));
	tcontrattostipendioview.defineColumn("ct", typeof(DateTime));
	tcontrattostipendioview.defineColumn("cu", typeof(string));
	tcontrattostipendioview.defineColumn("idinquadramento", typeof(int),false);
	tcontrattostipendioview.defineColumn("idmese", typeof(int),false);
	tcontrattostipendioview.defineColumn("idposition", typeof(int),false);
	tcontrattostipendioview.defineColumn("idreg", typeof(int),false);
	tcontrattostipendioview.defineColumn("idregistrylegalstatus", typeof(int),false);
	tcontrattostipendioview.defineColumn("idstipendio", typeof(int),false);
	tcontrattostipendioview.defineColumn("iis", typeof(decimal));
	tcontrattostipendioview.defineColumn("irap", typeof(decimal));
	tcontrattostipendioview.defineColumn("lordo", typeof(decimal));
	tcontrattostipendioview.defineColumn("lt", typeof(DateTime));
	tcontrattostipendioview.defineColumn("lu", typeof(string));
	tcontrattostipendioview.defineColumn("mese", typeof(string),false);
	tcontrattostipendioview.defineColumn("mesilavorati", typeof(int));
	tcontrattostipendioview.defineColumn("rifnormativo", typeof(string));
	tcontrattostipendioview.defineColumn("scatto", typeof(int));
	tcontrattostipendioview.defineColumn("siglaimportazione", typeof(string));
	tcontrattostipendioview.defineColumn("start", typeof(DateTime),false);
	tcontrattostipendioview.defineColumn("stipendio", typeof(decimal));
	tcontrattostipendioview.defineColumn("stop", typeof(DateTime));
	tcontrattostipendioview.defineColumn("totale", typeof(decimal));
	tcontrattostipendioview.defineColumn("totaleanno", typeof(decimal));
	tcontrattostipendioview.defineColumn("totaletfr", typeof(decimal));
	tcontrattostipendioview.defineColumn("tredicesima", typeof(decimal),false);
	tcontrattostipendioview.defineColumn("validfortredicesima", typeof(string),false);
	Tables.Add(tcontrattostipendioview);
	tcontrattostipendioview.defineKey("anno", "idreg", "idregistrylegalstatus", "idstipendio", "mese");

	//////////////////// CONTRATTOSTIPENDIOANNUOVIEW /////////////////////////////////
	var tcontrattostipendioannuoview= new MetaTable("contrattostipendioannuoview");
	tcontrattostipendioannuoview.defineColumn("caricoente", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("ct", typeof(DateTime));
	tcontrattostipendioannuoview.defineColumn("cu", typeof(string));
	tcontrattostipendioannuoview.defineColumn("idreg", typeof(int),false);
	tcontrattostipendioannuoview.defineColumn("idregistrylegalstatus", typeof(int));
	tcontrattostipendioannuoview.defineColumn("idstipendioannuo", typeof(int));
	tcontrattostipendioannuoview.defineColumn("irap", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("lordo", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("lt", typeof(DateTime));
	tcontrattostipendioannuoview.defineColumn("lu", typeof(string));
	tcontrattostipendioannuoview.defineColumn("totale", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("tredicesima", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("year", typeof(int),false);
	Tables.Add(tcontrattostipendioannuoview);
	tcontrattostipendioannuoview.defineKey("idreg", "year");

	//////////////////// TITLE /////////////////////////////////
	var ttitle= new MetaTable("title");
	ttitle.defineColumn("active", typeof(string));
	ttitle.defineColumn("ct", typeof(DateTime),false);
	ttitle.defineColumn("cu", typeof(string),false);
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("idtitle", typeof(string),false);
	ttitle.defineColumn("lt", typeof(DateTime),false);
	ttitle.defineColumn("lu", typeof(string),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

	//////////////////// YEAR_ALIAS1 /////////////////////////////////
	var tyear_alias1= new MetaTable("year_alias1");
	tyear_alias1.defineColumn("year", typeof(int),false);
	tyear_alias1.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias1);
	tyear_alias1.defineKey("year");

	//////////////////// CONTRATTOKIND_ALIAS1 /////////////////////////////////
	var tcontrattokind_alias1= new MetaTable("contrattokind_alias1");
	tcontrattokind_alias1.defineColumn("active", typeof(string),false);
	tcontrattokind_alias1.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind_alias1.defineColumn("title", typeof(string),false);
	tcontrattokind_alias1.ExtendedProperties["TableForReading"]="contrattokind";
	Tables.Add(tcontrattokind_alias1);
	tcontrattokind_alias1.defineKey("idcontrattokind");

	//////////////////// CONTRATTO_ALIAS2 /////////////////////////////////
	var tcontratto_alias2= new MetaTable("contratto_alias2");
	tcontratto_alias2.defineColumn("idcontratto", typeof(int),false);
	tcontratto_alias2.defineColumn("idcontrattokind", typeof(int),false);
	tcontratto_alias2.defineColumn("idreg", typeof(int),false);
	tcontratto_alias2.defineColumn("start", typeof(DateTime),false);
	tcontratto_alias2.defineColumn("stop", typeof(DateTime));
	tcontratto_alias2.ExtendedProperties["TableForReading"]="contratto";
	Tables.Add(tcontratto_alias2);
	tcontratto_alias2.defineKey("idcontratto", "idreg");

	//////////////////// STIPENDIOANNUO /////////////////////////////////
	var tstipendioannuo= new MetaTable("stipendioannuo");
	tstipendioannuo.defineColumn("caricoente", typeof(decimal));
	tstipendioannuo.defineColumn("ct", typeof(DateTime));
	tstipendioannuo.defineColumn("cu", typeof(string));
	tstipendioannuo.defineColumn("idcontratto", typeof(int));
	tstipendioannuo.defineColumn("idreg", typeof(int),false);
	tstipendioannuo.defineColumn("idregistrylegalstatus", typeof(int),false);
	tstipendioannuo.defineColumn("idstipendioannuo", typeof(int),false);
	tstipendioannuo.defineColumn("irap", typeof(decimal));
	tstipendioannuo.defineColumn("lordo", typeof(decimal));
	tstipendioannuo.defineColumn("lt", typeof(DateTime));
	tstipendioannuo.defineColumn("lu", typeof(string));
	tstipendioannuo.defineColumn("totale", typeof(decimal));
	tstipendioannuo.defineColumn("year", typeof(int),false);
	tstipendioannuo.defineColumn("!idcontratto_contratto_start", typeof(DateTime));
	tstipendioannuo.defineColumn("!idcontratto_contratto_stop", typeof(DateTime));
	tstipendioannuo.defineColumn("!idcontratto_contratto_idcontrattokind_title", typeof(string));
	Tables.Add(tstipendioannuo);
	tstipendioannuo.defineKey("idreg", "idregistrylegalstatus", "idstipendioannuo", "year");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// MESE /////////////////////////////////
	var tmese= new MetaTable("mese");
	tmese.defineColumn("idmese", typeof(int),false);
	tmese.defineColumn("title", typeof(string));
	Tables.Add(tmese);
	tmese.defineKey("idmese");

	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("active", typeof(string),false);
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// CONTRATTO /////////////////////////////////
	var tcontratto= new MetaTable("contratto");
	tcontratto.defineColumn("idcontratto", typeof(int),false);
	tcontratto.defineColumn("idcontrattokind", typeof(int),false);
	tcontratto.defineColumn("idreg", typeof(int),false);
	tcontratto.defineColumn("start", typeof(DateTime),false);
	tcontratto.defineColumn("stop", typeof(DateTime));
	Tables.Add(tcontratto);
	tcontratto.defineKey("idcontratto", "idreg");

	//////////////////// CEDOLINO /////////////////////////////////
	var tcedolino= new MetaTable("cedolino");
	tcedolino.defineColumn("!previdenza", typeof(decimal));
	tcedolino.defineColumn("!tesoro", typeof(decimal));
	tcedolino.defineColumn("!tredicesima", typeof(decimal));
	tcedolino.defineColumn("assegno", typeof(decimal));
	tcedolino.defineColumn("classe", typeof(int));
	tcedolino.defineColumn("data", typeof(DateTime));
	tcedolino.defineColumn("idcedolino", typeof(int),false);
	tcedolino.defineColumn("idcontratto", typeof(int));
	tcedolino.defineColumn("idmese", typeof(int));
	tcedolino.defineColumn("idreg", typeof(int),false);
	tcedolino.defineColumn("idregistrylegalstatus", typeof(int),false);
	tcedolino.defineColumn("iis", typeof(decimal));
	tcedolino.defineColumn("irap", typeof(decimal));
	tcedolino.defineColumn("lordo", typeof(decimal));
	tcedolino.defineColumn("scatto", typeof(int));
	tcedolino.defineColumn("stipendio", typeof(decimal));
	tcedolino.defineColumn("totale", typeof(decimal));
	tcedolino.defineColumn("totalece", typeof(decimal));
	tcedolino.defineColumn("year", typeof(int));
	tcedolino.defineColumn("!idcontratto_contratto_start", typeof(DateTime));
	tcedolino.defineColumn("!idcontratto_contratto_stop", typeof(DateTime));
	tcedolino.defineColumn("!idcontratto_contratto_idcontrattokind_title", typeof(string));
	tcedolino.defineColumn("!idmese_mese_title", typeof(string));
	Tables.Add(tcedolino);
	tcedolino.defineKey("idcedolino", "idreg", "idregistrylegalstatus");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime));
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
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
	tregistry.defineColumn("idateco", typeof(int));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idclassconsorsuale", typeof(int));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idfonteindicebibliometrico", typeof(int));
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

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{titolostudio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_titolostudio_registry_idreg",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{titolostudio.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_titolostudio_registry_alias1_idreg_istituti",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registry_istituti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_istituti_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{istattitolistudio.Columns["idistattitolistudio"]};
	cChild = new []{titolostudio.Columns["idistattitolistudio"]};
	Relations.Add(new DataRelation("FK_titolostudio_istattitolistudio_idistattitolistudio",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{titolostudio.Columns["aa"]};
	Relations.Add(new DataRelation("FK_titolostudio_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{sospensione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sospensione_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_registry_idreg",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"], rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["iditineration"]};
	cChild = new []{rendicontattivitaprogettoitineration.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoitineration.Columns["idworkpackage"], rendicontattivitaprogettoitineration.Columns["idprogetto"], rendicontattivitaprogettoitineration.Columns["iditineration"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoitineration_rendicontattivitaprogetto_idrendicontattivitaprogetto-idworkpackage-idprogetto-iditineration",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"], rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoora.Columns["idworkpackage"], rendicontattivitaprogettoora.Columns["idprogetto"], rendicontattivitaprogettoora.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_rendicontattivitaprogetto_idrendicontattivitaprogetto-idworkpackage-idprogetto-idreg",cPar,cChild,false));

	cPar = new []{workpackage_alias1.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_workpackage_alias1_idworkpackage",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogettokind.Columns["idrendicontattivitaprogettokind"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogettokind"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_rendicontattivitaprogettokind_idrendicontattivitaprogettokind",cPar,cChild,false));

	cPar = new []{progetto_alias3.Columns["idprogetto"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_progetto_alias3_idprogetto",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{rendicont.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_rendicont_registry_idreg_docenti",cPar,cChild,false));

	cPar = new []{rendicont.Columns["aa"], rendicont.Columns["idreg_docenti"]};
	cChild = new []{lezione_alias1.Columns["aa"], lezione_alias1.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_lezione_alias1_rendicont_aa-idreg_docenti",cPar,cChild,false));

	cPar = new []{lezione_alias1.Columns["aa"], lezione_alias1.Columns["idaffidamento"], lezione_alias1.Columns["idattivform"], lezione_alias1.Columns["idaula"], lezione_alias1.Columns["idcanale"], lezione_alias1.Columns["idcorsostudio"], lezione_alias1.Columns["iddidprog"], lezione_alias1.Columns["iddidproganno"], lezione_alias1.Columns["iddidprogcurr"], lezione_alias1.Columns["iddidprogori"], lezione_alias1.Columns["iddidprogporzanno"], lezione_alias1.Columns["idedificio"], lezione_alias1.Columns["idlezione"], lezione_alias1.Columns["idreg_docenti"], lezione_alias1.Columns["idsede"]};
	cChild = new []{rendicontlezionestud.Columns["aa"], rendicontlezionestud.Columns["idaffidamento"], rendicontlezionestud.Columns["idattivform"], rendicontlezionestud.Columns["idaula"], rendicontlezionestud.Columns["idcanale"], rendicontlezionestud.Columns["idcorsostudio"], rendicontlezionestud.Columns["iddidprog"], rendicontlezionestud.Columns["iddidproganno"], rendicontlezionestud.Columns["iddidprogcurr"], rendicontlezionestud.Columns["iddidprogori"], rendicontlezionestud.Columns["iddidprogporzanno"], rendicontlezionestud.Columns["idedificio"], rendicontlezionestud.Columns["idlezione"], rendicontlezionestud.Columns["idreg_docenti"], rendicontlezionestud.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_rendicontlezionestud_lezione_alias1_aa-idaffidamento-idattivform-idaula-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idedificio-idlezione-idreg_docenti-idsede",cPar,cChild,false));

	cPar = new []{rendicont.Columns["aa"], rendicont.Columns["idreg_docenti"]};
	cChild = new []{rendicontaltro.Columns["aa"], rendicontaltro.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_rendicontaltro_rendicont_aa-idreg_docenti",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryreference_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_registry_idreg",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_position_idposition",cPar,cChild,false));

	cPar = new []{inquadramento.Columns["idinquadramento"]};
	cChild = new []{registrylegalstatus.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_inquadramento_idinquadramento",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryaddress_registry_idreg",cPar,cChild,false));

	cPar = new []{geo_nation_alias5.Columns["idnation"]};
	cChild = new []{registryaddress.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registryaddress_geo_nation_alias5_idnation",cPar,cChild,false));

	cPar = new []{geo_city_alias5.Columns["idcity"]};
	cChild = new []{registryaddress.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registryaddress_geo_city_alias5_idcity",cPar,cChild,false));

	cPar = new []{address.Columns["idaddress"]};
	cChild = new []{registryaddress.Columns["idaddresskind"]};
	Relations.Add(new DataRelation("FK_registryaddress_address_idaddresskind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{publicazregistry_docenti.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_publicazregistry_docenti_registry_idreg_docenti",cPar,cChild,false));

	cPar = new []{publicaz.Columns["idpublicaz"]};
	cChild = new []{publicazregistry_docenti.Columns["idpublicaz"]};
	Relations.Add(new DataRelation("FK_publicazregistry_docenti_publicaz_idpublicaz",cPar,cChild,false));

	cPar = new []{progetto_alias2.Columns["idprogetto"]};
	cChild = new []{publicaz.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_publicaz_progetto_alias2_idprogetto",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{progettotimesheet.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_registry_idreg",cPar,cChild,false));

	cPar = new []{progettotimesheet.Columns["idprogettotimesheet"]};
	cChild = new []{progettotimesheetprogetto.Columns["idprogettotimesheet"]};
	Relations.Add(new DataRelation("FK_progettotimesheetprogetto_progettotimesheet_idprogettotimesheet",cPar,cChild,false));

	cPar = new []{year_alias2.Columns["year"]};
	cChild = new []{progettotimesheet.Columns["year"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_year_alias2_year",cPar,cChild,false));

	cPar = new []{timesheettemplate.Columns["idtimesheettemplate"]};
	cChild = new []{progettotimesheet.Columns["idtimesheettemplate"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_timesheettemplate_idtimesheettemplate",cPar,cChild,false));

	cPar = new []{sal.Columns["idsal"]};
	cChild = new []{progettotimesheet.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_sal_idsal",cPar,cChild,false));

	cPar = new []{progetto_alias1.Columns["idprogetto"]};
	cChild = new []{progettotimesheet.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_progetto_alias1_idprogetto",cPar,cChild,false));

	cPar = new []{mese_alias1.Columns["idmese"]};
	cChild = new []{progettotimesheet.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_mese_alias1_idmese",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{assetdiary.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_assetdiary_registry_idreg",cPar,cChild,false));

	cPar = new []{assetdiary.Columns["idassetdiary"], assetdiary.Columns["idworkpackage"]};
	cChild = new []{assetdiaryora.Columns["idassetdiary"], assetdiaryora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_assetdiary_idassetdiary-idworkpackage",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idworkpackage"]};
	cChild = new []{assetdiary.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiary_workpackage_idworkpackage",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{assetdiary.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_assetdiary_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"], asset.Columns["idpiece"]};
	cChild = new []{assetdiary.Columns["idasset"], assetdiary.Columns["idpiece"]};
	Relations.Add(new DataRelation("FK_assetdiary_asset_idasset-idpiece",cPar,cChild,false));

	cPar = new []{assetacquire.Columns["nassetacquire"]};
	cChild = new []{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("FK_asset_assetacquire_nassetacquire",cPar,cChild,false));

	cPar = new []{inventory.Columns["idinventory"]};
	cChild = new []{asset.Columns["idinventory"]};
	Relations.Add(new DataRelation("FK_asset_inventory_idinventory",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{affidamento.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_affidamento_registry_idreg_docenti",cPar,cChild,false));

	cPar = new []{affidamento.Columns["aa"], affidamento.Columns["idaffidamento"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"], affidamento.Columns["idreg_docenti"]};
	cChild = new []{affidamentoattach.Columns["aa"], affidamentoattach.Columns["idaffidamento"], affidamentoattach.Columns["idattivform"], affidamentoattach.Columns["idcanale"], affidamentoattach.Columns["idcorsostudio"], affidamentoattach.Columns["iddidprog"], affidamentoattach.Columns["iddidproganno"], affidamentoattach.Columns["iddidprogcurr"], affidamentoattach.Columns["iddidprogori"], affidamentoattach.Columns["iddidprogporzanno"], affidamentoattach.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_affidamentoattach_affidamento_aa-idaffidamento-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idreg_docenti",cPar,cChild,false));

	cPar = new []{affidamento.Columns["aa"], affidamento.Columns["idaffidamento"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"]};
	cChild = new []{affidamentocaratteristica.Columns["aa"], affidamentocaratteristica.Columns["idaffidamento"], affidamentocaratteristica.Columns["idattivform"], affidamentocaratteristica.Columns["idcanale"], affidamentocaratteristica.Columns["idcorsostudio"], affidamentocaratteristica.Columns["iddidprog"], affidamentocaratteristica.Columns["iddidproganno"], affidamentocaratteristica.Columns["iddidprogcurr"], affidamentocaratteristica.Columns["iddidprogori"], affidamentocaratteristica.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_affidamento_aa-idaffidamento-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{affidamentocaratteristica.Columns["aa"], affidamentocaratteristica.Columns["idaffidamento"], affidamentocaratteristica.Columns["idaffidamentocaratteristica"], affidamentocaratteristica.Columns["idattivform"], affidamentocaratteristica.Columns["idcanale"], affidamentocaratteristica.Columns["idcorsostudio"], affidamentocaratteristica.Columns["iddidprog"], affidamentocaratteristica.Columns["iddidproganno"], affidamentocaratteristica.Columns["iddidprogcurr"], affidamentocaratteristica.Columns["iddidprogori"], affidamentocaratteristica.Columns["iddidprogporzanno"]};
	cChild = new []{affidamentocaratteristicaora.Columns["aa"], affidamentocaratteristicaora.Columns["idaffidamento"], affidamentocaratteristicaora.Columns["idaffidamentocaratteristica"], affidamentocaratteristicaora.Columns["idattivform"], affidamentocaratteristicaora.Columns["idcanale"], affidamentocaratteristicaora.Columns["idcorsostudio"], affidamentocaratteristicaora.Columns["iddidprog"], affidamentocaratteristicaora.Columns["iddidproganno"], affidamentocaratteristicaora.Columns["iddidprogcurr"], affidamentocaratteristicaora.Columns["iddidprogori"], affidamentocaratteristicaora.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristicaora_affidamentocaratteristica_aa-idaffidamento-idaffidamentocaratteristica-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

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

	cPar = new []{affidamento.Columns["aa"], affidamento.Columns["idaffidamento"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"], affidamento.Columns["idreg_docenti"]};
	cChild = new []{lezione_alias2.Columns["aa"], lezione_alias2.Columns["idaffidamento"], lezione_alias2.Columns["idattivform"], lezione_alias2.Columns["idcanale"], lezione_alias2.Columns["idcorsostudio"], lezione_alias2.Columns["iddidprog"], lezione_alias2.Columns["iddidproganno"], lezione_alias2.Columns["iddidprogcurr"], lezione_alias2.Columns["iddidprogori"], lezione_alias2.Columns["iddidprogporzanno"], lezione_alias2.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_lezione_alias2_affidamento_aa-idaffidamento-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idreg_docenti",cPar,cChild,false));

	cPar = new []{erogazkind.Columns["iderogazkind"]};
	cChild = new []{affidamento.Columns["iderogazkind"]};
	Relations.Add(new DataRelation("FK_affidamento_erogazkind_iderogazkind",cPar,cChild,false));

	cPar = new []{affidamentokind.Columns["idaffidamentokind"]};
	cChild = new []{affidamento.Columns["idaffidamentokind"]};
	Relations.Add(new DataRelation("FK_affidamento_affidamentokind_idaffidamentokind",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{affidamento.Columns["aa"]};
	Relations.Add(new DataRelation("FK_affidamento_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{afferenza.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_afferenza_registry_idreg",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{afferenza.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_afferenza_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{mansionekind.Columns["idmansionekind"]};
	cChild = new []{afferenza.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_afferenza_mansionekind_idmansionekind",cPar,cChild,false));

	cPar = new []{fonteindicebibliometrico.Columns["idfonteindicebibliometrico"]};
	cChild = new []{registry.Columns["idfonteindicebibliometrico"]};
	Relations.Add(new DataRelation("FK_registry_fonteindicebibliometrico_idfonteindicebibliometrico",cPar,cChild,false));

	cPar = new []{registryistitutiview.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_registry_registryistitutiview_idreg_istituti",cPar,cChild,false));

	cPar = new []{classconsorsualedefaultview.Columns["idclassconsorsuale"]};
	cChild = new []{registry.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_registry_classconsorsualedefaultview_idclassconsorsuale",cPar,cChild,false));

	cPar = new []{sasddefaultview.Columns["idsasd"]};
	cChild = new []{registry.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_registry_sasddefaultview_idsasd",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{registry.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_registry_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{accmotivedefaultview_alias1.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("FK_registry_accmotivedefaultview_alias1_idaccmotivecredit",cPar,cChild,false));

	cPar = new []{accmotivedefaultview.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("FK_registry_accmotivedefaultview_idaccmotivedebit",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{costoorario.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_costoorario_registry_idreg",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("FK_registry_residence_residence",cPar,cChild,false));

	cPar = new []{registryclasspersoneview.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("FK_registry_registryclasspersoneview_idregistryclass",cPar,cChild,false));

	cPar = new []{maritalstatus.Columns["idmaritalstatus"]};
	cChild = new []{registry.Columns["idmaritalstatus"]};
	Relations.Add(new DataRelation("FK_registry_maritalstatus_idmaritalstatus",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{contrattostipendioview.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_contrattostipendioview_idreg",cPar,cChild,false));

	cPar = new []{contrattostipendioannuoview.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_contrattostipendioannuoview_idreg",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_title_idtitle",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{stipendioannuo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_registry_idreg",cPar,cChild,false));

	cPar = new []{year_alias1.Columns["year"]};
	cChild = new []{stipendioannuo.Columns["year"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_year_alias1_year",cPar,cChild,false));

	cPar = new []{contratto_alias2.Columns["idcontratto"]};
	cChild = new []{stipendioannuo.Columns["idcontratto"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_contratto_alias2_idcontratto",cPar,cChild,false));

	cPar = new []{contrattokind_alias1.Columns["idcontrattokind"]};
	cChild = new []{contratto_alias2.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_contratto_alias2_contrattokind_alias1_idcontrattokind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{cedolino.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_cedolino_registry_idreg",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{cedolino.Columns["year"]};
	Relations.Add(new DataRelation("FK_cedolino_year_year",cPar,cChild,false));

	cPar = new []{mese.Columns["idmese"]};
	cChild = new []{cedolino.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_cedolino_mese_idmese",cPar,cChild,false));

	cPar = new []{contratto.Columns["idcontratto"]};
	cChild = new []{cedolino.Columns["idcontratto"]};
	Relations.Add(new DataRelation("FK_cedolino_contratto_idcontratto",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{contratto.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_contratto_contrattokind_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
