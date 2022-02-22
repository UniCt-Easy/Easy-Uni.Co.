
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_publicaz_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_publicaz_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias3 		=> (MetaTable)Tables["registry_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_istituti 		=> (MetaTable)Tables["registry_istituti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsuale 		=> (MetaTable)Tables["classconsorsuale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_docenti 		=> (MetaTable)Tables["registry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable publicazregistry_docenti 		=> (MetaTable)Tables["publicazregistry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable numerodip 		=> (MetaTable)Tables["numerodip"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable naturagiur 		=> (MetaTable)Tables["naturagiur"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nace 		=> (MetaTable)Tables["nace"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ateco 		=> (MetaTable)Tables["ateco"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclass 		=> (MetaTable)Tables["registryclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias2 		=> (MetaTable)Tables["geo_nation_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_aziende 		=> (MetaTable)Tables["registry_aziende"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable publicazregistry_aziende 		=> (MetaTable)Tables["publicazregistry_aziende"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable publicazkind 		=> (MetaTable)Tables["publicazkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable publicazkindpublicaz 		=> (MetaTable)Tables["publicazkindpublicaz"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable publicazkeyword 		=> (MetaTable)Tables["publicazkeyword"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto 		=> (MetaTable)Tables["progetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias1 		=> (MetaTable)Tables["geo_nation_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_alias1 		=> (MetaTable)Tables["geo_city_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable publicaz 		=> (MetaTable)Tables["publicaz"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_publicaz_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_publicaz_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_publicaz_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_publicaz_default.xsd";

	#region create DataTables
	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("annotation", typeof(string));
	tregistry_alias1.defineColumn("authorization_free", typeof(string));
	tregistry_alias1.defineColumn("badgecode", typeof(string));
	tregistry_alias1.defineColumn("birthdate", typeof(DateTime),false);
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
	tregistry_alias1.defineColumn("forename", typeof(string),false);
	tregistry_alias1.defineColumn("gender", typeof(string),false);
	tregistry_alias1.defineColumn("idaccmotivecredit", typeof(string));
	tregistry_alias1.defineColumn("idaccmotivedebit", typeof(string));
	tregistry_alias1.defineColumn("idcategory", typeof(string));
	tregistry_alias1.defineColumn("idcentralizedcategory", typeof(string));
	tregistry_alias1.defineColumn("idcity", typeof(int),false);
	tregistry_alias1.defineColumn("idexternal", typeof(int));
	tregistry_alias1.defineColumn("idmaritalstatus", typeof(string));
	tregistry_alias1.defineColumn("idnation", typeof(int));
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("idregistryclass", typeof(string));
	tregistry_alias1.defineColumn("idregistrykind", typeof(int));
	tregistry_alias1.defineColumn("idtitle", typeof(string));
	tregistry_alias1.defineColumn("ipa_fe", typeof(string));
	tregistry_alias1.defineColumn("ipa_perlapa", typeof(string));
	tregistry_alias1.defineColumn("location", typeof(string));
	tregistry_alias1.defineColumn("lt", typeof(DateTime),false);
	tregistry_alias1.defineColumn("lu", typeof(string),false);
	tregistry_alias1.defineColumn("maritalsurname", typeof(string));
	tregistry_alias1.defineColumn("multi_cf", typeof(string));
	tregistry_alias1.defineColumn("p_iva", typeof(string));
	tregistry_alias1.defineColumn("pec_fe", typeof(string));
	tregistry_alias1.defineColumn("residence", typeof(int),false);
	tregistry_alias1.defineColumn("rtf", typeof(Byte[]));
	tregistry_alias1.defineColumn("sdi_defrifamm", typeof(string));
	tregistry_alias1.defineColumn("sdi_norifamm", typeof(string));
	tregistry_alias1.defineColumn("surname", typeof(string),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.defineColumn("toredirect", typeof(int));
	tregistry_alias1.defineColumn("txt", typeof(string));
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("codice", typeof(string),false);
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	//////////////////// REGISTRY_ALIAS3 /////////////////////////////////
	var tregistry_alias3= new MetaTable("registry_alias3");
	tregistry_alias3.defineColumn("active", typeof(string),false);
	tregistry_alias3.defineColumn("annotation", typeof(string));
	tregistry_alias3.defineColumn("authorization_free", typeof(string));
	tregistry_alias3.defineColumn("badgecode", typeof(string));
	tregistry_alias3.defineColumn("birthdate", typeof(DateTime));
	tregistry_alias3.defineColumn("ccp", typeof(string));
	tregistry_alias3.defineColumn("cf", typeof(string));
	tregistry_alias3.defineColumn("ct", typeof(DateTime),false);
	tregistry_alias3.defineColumn("cu", typeof(string),false);
	tregistry_alias3.defineColumn("email_fe", typeof(string));
	tregistry_alias3.defineColumn("extension", typeof(string));
	tregistry_alias3.defineColumn("extmatricula", typeof(string));
	tregistry_alias3.defineColumn("flag_pa", typeof(string));
	tregistry_alias3.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry_alias3.defineColumn("foreigncf", typeof(string));
	tregistry_alias3.defineColumn("forename", typeof(string));
	tregistry_alias3.defineColumn("gender", typeof(string));
	tregistry_alias3.defineColumn("idaccmotivecredit", typeof(string));
	tregistry_alias3.defineColumn("idaccmotivedebit", typeof(string));
	tregistry_alias3.defineColumn("idcategory", typeof(string));
	tregistry_alias3.defineColumn("idcentralizedcategory", typeof(string));
	tregistry_alias3.defineColumn("idcity", typeof(int));
	tregistry_alias3.defineColumn("idexternal", typeof(int));
	tregistry_alias3.defineColumn("idmaritalstatus", typeof(string));
	tregistry_alias3.defineColumn("idnation", typeof(int));
	tregistry_alias3.defineColumn("idreg", typeof(int),false);
	tregistry_alias3.defineColumn("idregistryclass", typeof(string));
	tregistry_alias3.defineColumn("idregistrykind", typeof(int));
	tregistry_alias3.defineColumn("idtitle", typeof(string));
	tregistry_alias3.defineColumn("ipa_fe", typeof(string));
	tregistry_alias3.defineColumn("ipa_perlapa", typeof(string));
	tregistry_alias3.defineColumn("location", typeof(string));
	tregistry_alias3.defineColumn("lt", typeof(DateTime),false);
	tregistry_alias3.defineColumn("lu", typeof(string),false);
	tregistry_alias3.defineColumn("maritalsurname", typeof(string));
	tregistry_alias3.defineColumn("multi_cf", typeof(string));
	tregistry_alias3.defineColumn("p_iva", typeof(string));
	tregistry_alias3.defineColumn("pec_fe", typeof(string));
	tregistry_alias3.defineColumn("residence", typeof(int),false);
	tregistry_alias3.defineColumn("rtf", typeof(Byte[]));
	tregistry_alias3.defineColumn("sdi_defrifamm", typeof(string));
	tregistry_alias3.defineColumn("sdi_norifamm", typeof(string));
	tregistry_alias3.defineColumn("surname", typeof(string));
	tregistry_alias3.defineColumn("title", typeof(string),false);
	tregistry_alias3.defineColumn("toredirect", typeof(int));
	tregistry_alias3.defineColumn("txt", typeof(string));
	tregistry_alias3.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias3);
	tregistry_alias3.defineKey("idreg");

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

	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("active", typeof(string),false);
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// CLASSCONSORSUALE /////////////////////////////////
	var tclassconsorsuale= new MetaTable("classconsorsuale");
	tclassconsorsuale.defineColumn("active", typeof(string),false);
	tclassconsorsuale.defineColumn("idclassconsorsuale", typeof(int),false);
	tclassconsorsuale.defineColumn("title", typeof(string),false);
	Tables.Add(tclassconsorsuale);
	tclassconsorsuale.defineKey("idclassconsorsuale");

	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
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

	//////////////////// REGISTRY_DOCENTI /////////////////////////////////
	var tregistry_docenti= new MetaTable("registry_docenti");
	tregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tregistry_docenti.defineColumn("cu", typeof(string),false);
	tregistry_docenti.defineColumn("cv", typeof(string));
	tregistry_docenti.defineColumn("idclassconsorsuale", typeof(int));
	tregistry_docenti.defineColumn("idcontrattokind", typeof(int));
	tregistry_docenti.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistry_docenti.defineColumn("idreg", typeof(int),false);
	tregistry_docenti.defineColumn("idreg_istituti", typeof(int));
	tregistry_docenti.defineColumn("idsasd", typeof(int));
	tregistry_docenti.defineColumn("idstruttura", typeof(int));
	tregistry_docenti.defineColumn("indicebibliometrico", typeof(int));
	tregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tregistry_docenti.defineColumn("lu", typeof(string),false);
	tregistry_docenti.defineColumn("matricola", typeof(string));
	tregistry_docenti.defineColumn("ricevimento", typeof(string));
	tregistry_docenti.defineColumn("soggiorno", typeof(string));
	Tables.Add(tregistry_docenti);
	tregistry_docenti.defineKey("idreg");

	//////////////////// PUBLICAZREGISTRY_DOCENTI /////////////////////////////////
	var tpublicazregistry_docenti= new MetaTable("publicazregistry_docenti");
	tpublicazregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tpublicazregistry_docenti.defineColumn("cu", typeof(string),false);
	tpublicazregistry_docenti.defineColumn("idpublicaz", typeof(int),false);
	tpublicazregistry_docenti.defineColumn("idreg_docenti", typeof(int),false);
	tpublicazregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tpublicazregistry_docenti.defineColumn("lu", typeof(string),false);
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_registry_alias1_title", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_registry_alias1_cf", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_registry_alias1_p_iva", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_registry_alias1_active", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_registry_docenti_matricola", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_sasd_codice", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_sasd_title", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_struttura_title", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_struttura_strutturakind_title", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_registry_alias3_title", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_classconsorsuale_title", typeof(string));
	tpublicazregistry_docenti.defineColumn("!idreg_docenti_contrattokind_title", typeof(string));
	Tables.Add(tpublicazregistry_docenti);
	tpublicazregistry_docenti.defineKey("idpublicaz", "idreg_docenti");

	//////////////////// NUMERODIP /////////////////////////////////
	var tnumerodip= new MetaTable("numerodip");
	tnumerodip.defineColumn("active", typeof(string),false);
	tnumerodip.defineColumn("idnumerodip", typeof(int),false);
	tnumerodip.defineColumn("title", typeof(string),false);
	Tables.Add(tnumerodip);
	tnumerodip.defineKey("idnumerodip");

	//////////////////// NATURAGIUR /////////////////////////////////
	var tnaturagiur= new MetaTable("naturagiur");
	tnaturagiur.defineColumn("active", typeof(string),false);
	tnaturagiur.defineColumn("idnaturagiur", typeof(int),false);
	tnaturagiur.defineColumn("title", typeof(string),false);
	Tables.Add(tnaturagiur);
	tnaturagiur.defineKey("idnaturagiur");

	//////////////////// NACE /////////////////////////////////
	var tnace= new MetaTable("nace");
	tnace.defineColumn("activity", typeof(string),false);
	tnace.defineColumn("idnace", typeof(string),false);
	Tables.Add(tnace);
	tnace.defineKey("idnace");

	//////////////////// ATECO /////////////////////////////////
	var tateco= new MetaTable("ateco");
	tateco.defineColumn("codice", typeof(string));
	tateco.defineColumn("idateco", typeof(int),false);
	tateco.defineColumn("title", typeof(string));
	Tables.Add(tateco);
	tateco.defineKey("idateco");

	//////////////////// REGISTRYCLASS /////////////////////////////////
	var tregistryclass= new MetaTable("registryclass");
	tregistryclass.defineColumn("active", typeof(string));
	tregistryclass.defineColumn("description", typeof(string),false);
	tregistryclass.defineColumn("idregistryclass", typeof(string),false);
	Tables.Add(tregistryclass);
	tregistryclass.defineKey("idregistryclass");

	//////////////////// GEO_NATION_ALIAS2 /////////////////////////////////
	var tgeo_nation_alias2= new MetaTable("geo_nation_alias2");
	tgeo_nation_alias2.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias2.defineColumn("title", typeof(string));
	tgeo_nation_alias2.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias2);
	tgeo_nation_alias2.defineKey("idnation");

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
	tregistry.defineColumn("forename", typeof(string));
	tregistry.defineColumn("gender", typeof(string));
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("ipa_perlapa", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("surname", typeof(string));
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// REGISTRY_AZIENDE /////////////////////////////////
	var tregistry_aziende= new MetaTable("registry_aziende");
	tregistry_aziende.defineColumn("ct", typeof(DateTime),false);
	tregistry_aziende.defineColumn("cu", typeof(string),false);
	tregistry_aziende.defineColumn("idateco", typeof(int));
	tregistry_aziende.defineColumn("idnace", typeof(string));
	tregistry_aziende.defineColumn("idnaturagiur", typeof(int));
	tregistry_aziende.defineColumn("idnumerodip", typeof(int));
	tregistry_aziende.defineColumn("idreg", typeof(int),false);
	tregistry_aziende.defineColumn("lt", typeof(DateTime),false);
	tregistry_aziende.defineColumn("lu", typeof(string),false);
	tregistry_aziende.defineColumn("pic", typeof(string));
	tregistry_aziende.defineColumn("title_en", typeof(string));
	tregistry_aziende.defineColumn("txt_en", typeof(string));
	Tables.Add(tregistry_aziende);
	tregistry_aziende.defineKey("idreg");

	//////////////////// PUBLICAZREGISTRY_AZIENDE /////////////////////////////////
	var tpublicazregistry_aziende= new MetaTable("publicazregistry_aziende");
	tpublicazregistry_aziende.defineColumn("ct", typeof(DateTime),false);
	tpublicazregistry_aziende.defineColumn("cu", typeof(string),false);
	tpublicazregistry_aziende.defineColumn("idpublicaz", typeof(int),false);
	tpublicazregistry_aziende.defineColumn("idreg_aziende", typeof(int),false);
	tpublicazregistry_aziende.defineColumn("lt", typeof(DateTime),false);
	tpublicazregistry_aziende.defineColumn("lu", typeof(string),false);
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_registry_title", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_registryclass_description", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_registry_cf", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_registry_p_iva", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_registry_active", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_geo_nation_alias2_title", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_registry_flag_pa", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_ateco_codice", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_ateco_title", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_naturagiur_title", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_numerodip_title", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_nace_idnace", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_nace_activity", typeof(string));
	tpublicazregistry_aziende.defineColumn("!idreg_aziende_registry_aziende_pic", typeof(string));
	Tables.Add(tpublicazregistry_aziende);
	tpublicazregistry_aziende.defineKey("idpublicaz", "idreg_aziende");

	//////////////////// PUBLICAZKIND /////////////////////////////////
	var tpublicazkind= new MetaTable("publicazkind");
	tpublicazkind.defineColumn("active", typeof(string),false);
	tpublicazkind.defineColumn("ct", typeof(DateTime),false);
	tpublicazkind.defineColumn("cu", typeof(string),false);
	tpublicazkind.defineColumn("idpublicazkind", typeof(int),false);
	tpublicazkind.defineColumn("lt", typeof(DateTime),false);
	tpublicazkind.defineColumn("lu", typeof(string),false);
	tpublicazkind.defineColumn("sortcode", typeof(int));
	tpublicazkind.defineColumn("subtitle", typeof(string));
	tpublicazkind.defineColumn("title", typeof(string));
	Tables.Add(tpublicazkind);
	tpublicazkind.defineKey("idpublicazkind");

	//////////////////// PUBLICAZKINDPUBLICAZ /////////////////////////////////
	var tpublicazkindpublicaz= new MetaTable("publicazkindpublicaz");
	tpublicazkindpublicaz.defineColumn("ct", typeof(DateTime),false);
	tpublicazkindpublicaz.defineColumn("cu", typeof(string),false);
	tpublicazkindpublicaz.defineColumn("idpublicaz", typeof(int),false);
	tpublicazkindpublicaz.defineColumn("idpublicazkind", typeof(int),false);
	tpublicazkindpublicaz.defineColumn("lt", typeof(DateTime),false);
	tpublicazkindpublicaz.defineColumn("lu", typeof(string),false);
	tpublicazkindpublicaz.defineColumn("!idpublicazkind_publicazkind_title", typeof(string));
	tpublicazkindpublicaz.defineColumn("!idpublicazkind_publicazkind_subtitle", typeof(string));
	tpublicazkindpublicaz.defineColumn("!idpublicazkind_publicazkind_sortcode", typeof(int));
	tpublicazkindpublicaz.defineColumn("!idpublicazkind_publicazkind_active", typeof(string));
	Tables.Add(tpublicazkindpublicaz);
	tpublicazkindpublicaz.defineKey("idpublicaz", "idpublicazkind");

	//////////////////// PUBLICAZKEYWORD /////////////////////////////////
	var tpublicazkeyword= new MetaTable("publicazkeyword");
	tpublicazkeyword.defineColumn("ct", typeof(DateTime),false);
	tpublicazkeyword.defineColumn("cu", typeof(string),false);
	tpublicazkeyword.defineColumn("idpublicaz", typeof(int),false);
	tpublicazkeyword.defineColumn("idpublicazkeyword", typeof(int),false);
	tpublicazkeyword.defineColumn("keyword", typeof(string),false);
	tpublicazkeyword.defineColumn("lt", typeof(DateTime),false);
	tpublicazkeyword.defineColumn("lu", typeof(string),false);
	tpublicazkeyword.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tpublicazkeyword);
	tpublicazkeyword.defineKey("idpublicazkeyword");

	//////////////////// PROGETTO /////////////////////////////////
	var tprogetto= new MetaTable("progetto");
	tprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogetto.defineColumn("titolobreve", typeof(string));
	Tables.Add(tprogetto);
	tprogetto.defineKey("idprogetto");

	//////////////////// GEO_NATION_ALIAS1 /////////////////////////////////
	var tgeo_nation_alias1= new MetaTable("geo_nation_alias1");
	tgeo_nation_alias1.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias1.defineColumn("title", typeof(string));
	tgeo_nation_alias1.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias1);
	tgeo_nation_alias1.defineKey("idnation");

	//////////////////// GEO_CITY_ALIAS1 /////////////////////////////////
	var tgeo_city_alias1= new MetaTable("geo_city_alias1");
	tgeo_city_alias1.defineColumn("idcity", typeof(int),false);
	tgeo_city_alias1.defineColumn("title", typeof(string));
	tgeo_city_alias1.ExtendedProperties["TableForReading"]="geo_city";
	Tables.Add(tgeo_city_alias1);
	tgeo_city_alias1.defineKey("idcity");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{publicaz.Columns["idpublicaz"]};
	var cChild = new []{publicazregistry_docenti.Columns["idpublicaz"]};
	Relations.Add(new DataRelation("FK_publicazregistry_docenti_publicaz_idpublicaz",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{publicazregistry_docenti.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_publicazregistry_docenti_registry_alias1_idreg_docenti",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registry_docenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_docenti_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{registry_docenti.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_registry_docenti_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{registry_docenti.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_registry_docenti_sasd_idsasd",cPar,cChild,false));

	cPar = new []{registry_alias3.Columns["idreg"]};
	cChild = new []{registry_docenti.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_registry_docenti_registry_alias3_idreg_istituti",cPar,cChild,false));

	cPar = new []{registry_alias3.Columns["idreg"]};
	cChild = new []{registry_istituti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_istituti_registry_alias3_idreg",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{registry_docenti.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_registry_docenti_contrattokind_idcontrattokind",cPar,cChild,false));

	cPar = new []{classconsorsuale.Columns["idclassconsorsuale"]};
	cChild = new []{registry_docenti.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_registry_docenti_classconsorsuale_idclassconsorsuale",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{publicaz.Columns["idpublicaz"]};
	cChild = new []{publicazregistry_aziende.Columns["idpublicaz"]};
	Relations.Add(new DataRelation("FK_publicazregistry_aziende_publicaz_idpublicaz",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{publicazregistry_aziende.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_publicazregistry_aziende_registry_idreg_aziende",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_aziende.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_aziende_registry_idreg",cPar,cChild,false));

	cPar = new []{numerodip.Columns["idnumerodip"]};
	cChild = new []{registry_aziende.Columns["idnumerodip"]};
	Relations.Add(new DataRelation("FK_registry_aziende_numerodip_idnumerodip",cPar,cChild,false));

	cPar = new []{naturagiur.Columns["idnaturagiur"]};
	cChild = new []{registry_aziende.Columns["idnaturagiur"]};
	Relations.Add(new DataRelation("FK_registry_aziende_naturagiur_idnaturagiur",cPar,cChild,false));

	cPar = new []{nace.Columns["idnace"]};
	cChild = new []{registry_aziende.Columns["idnace"]};
	Relations.Add(new DataRelation("FK_registry_aziende_nace_idnace",cPar,cChild,false));

	cPar = new []{ateco.Columns["idateco"]};
	cChild = new []{registry_aziende.Columns["idateco"]};
	Relations.Add(new DataRelation("FK_registry_aziende_ateco_idateco",cPar,cChild,false));

	cPar = new []{registryclass.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("FK_registry_registryclass_idregistryclass",cPar,cChild,false));

	cPar = new []{geo_nation_alias2.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_alias2_idnation",cPar,cChild,false));

	cPar = new []{publicaz.Columns["idpublicaz"]};
	cChild = new []{publicazkindpublicaz.Columns["idpublicaz"]};
	Relations.Add(new DataRelation("FK_publicazkindpublicaz_publicaz_idpublicaz",cPar,cChild,false));

	cPar = new []{publicazkind.Columns["idpublicazkind"]};
	cChild = new []{publicazkindpublicaz.Columns["idpublicazkind"]};
	Relations.Add(new DataRelation("FK_publicazkindpublicaz_publicazkind_idpublicazkind",cPar,cChild,false));

	cPar = new []{publicaz.Columns["idpublicaz"]};
	cChild = new []{publicazkeyword.Columns["idpublicaz"]};
	Relations.Add(new DataRelation("FK_publicazkeyword_publicaz_idpublicaz",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{publicaz.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_publicaz_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{geo_nation_alias1.Columns["idnation"]};
	cChild = new []{publicaz.Columns["idnation_lang"]};
	Relations.Add(new DataRelation("FK_publicaz_geo_nation_alias1_idnation_lang",cPar,cChild,false));

	cPar = new []{geo_city_alias1.Columns["idcity"]};
	cChild = new []{publicaz.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_publicaz_geo_city_alias1_idcity",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{publicaz.Columns["idnation_ed"]};
	Relations.Add(new DataRelation("FK_publicaz_geo_nation_idnation_ed",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{publicaz.Columns["idcity_ed"]};
	Relations.Add(new DataRelation("FK_publicaz_geo_city_idcity_ed",cPar,cChild,false));

	#endregion

}
}
}
