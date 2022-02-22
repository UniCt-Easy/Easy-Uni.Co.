
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
[System.Xml.Serialization.XmlRoot("dsmeta_iscrizionebmi_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_iscrizionebmi_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrdefaultview_alias4 		=> (MetaTable)Tables["cefrdefaultview_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrdefaultview_alias3 		=> (MetaTable)Tables["cefrdefaultview_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrdefaultview_alias2 		=> (MetaTable)Tables["cefrdefaultview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrdefaultview_alias1 		=> (MetaTable)Tables["cefrdefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrdefaultview 		=> (MetaTable)Tables["cefrdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel 		=> (MetaTable)Tables["cefrlanglevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel_alias3 		=> (MetaTable)Tables["cefrlanglevel_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato_alias1 		=> (MetaTable)Tables["convalidato_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida_alias2 		=> (MetaTable)Tables["convalida_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias2 		=> (MetaTable)Tables["registry_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_aziende 		=> (MetaTable)Tables["registry_aziende"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainervalut 		=> (MetaTable)Tables["learningagrtrainervalut"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainerkind 		=> (MetaTable)Tables["learningagrtrainerkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainer 		=> (MetaTable)Tables["learningagrtrainer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_docenti 		=> (MetaTable)Tables["registry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias1 		=> (MetaTable)Tables["geo_nation_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable isced2013 		=> (MetaTable)Tables["isced2013"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable staffagrteaching 		=> (MetaTable)Tables["staffagrteaching"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel_alias2 		=> (MetaTable)Tables["cefrlanglevel_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_istitutiesteri 		=> (MetaTable)Tables["registry_istitutiesteri"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrkind 		=> (MetaTable)Tables["learningagrkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrstud 		=> (MetaTable)Tables["learningagrstud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmirequisito 		=> (MetaTable)Tables["iscrizionebmirequisito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmiattach 		=> (MetaTable)Tables["iscrizionebmiattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmi 		=> (MetaTable)Tables["iscrizionebmi"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_iscrizionebmi_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_iscrizionebmi_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_iscrizionebmi_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_iscrizionebmi_seg.xsd";

	#region create DataTables
	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("lang", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// CEFRDEFAULTVIEW_ALIAS4 /////////////////////////////////
	var tcefrdefaultview_alias4= new MetaTable("cefrdefaultview_alias4");
	tcefrdefaultview_alias4.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias4.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias4.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias4);
	tcefrdefaultview_alias4.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW_ALIAS3 /////////////////////////////////
	var tcefrdefaultview_alias3= new MetaTable("cefrdefaultview_alias3");
	tcefrdefaultview_alias3.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias3.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias3.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias3);
	tcefrdefaultview_alias3.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW_ALIAS2 /////////////////////////////////
	var tcefrdefaultview_alias2= new MetaTable("cefrdefaultview_alias2");
	tcefrdefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias2.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias2.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias2);
	tcefrdefaultview_alias2.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tcefrdefaultview_alias1= new MetaTable("cefrdefaultview_alias1");
	tcefrdefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias1.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias1.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias1);
	tcefrdefaultview_alias1.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW /////////////////////////////////
	var tcefrdefaultview= new MetaTable("cefrdefaultview");
	tcefrdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview.defineColumn("idcefr", typeof(int),false);
	Tables.Add(tcefrdefaultview);
	tcefrdefaultview.defineKey("idcefr");

	//////////////////// CEFRLANGLEVEL /////////////////////////////////
	var tcefrlanglevel= new MetaTable("cefrlanglevel");
	tcefrlanglevel.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel.defineColumn("cu", typeof(string),false);
	tcefrlanglevel.defineColumn("idaccordoscambiomi", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidett", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidettlangkind", typeof(int),false);
	tcefrlanglevel.defineColumn("idcefr_compasc", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_complett", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_scritto", typeof(int));
	tcefrlanglevel.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlanglevel.defineColumn("idiscrizionebmi", typeof(int));
	tcefrlanglevel.defineColumn("idlearningagrstud", typeof(int));
	tcefrlanglevel.defineColumn("idlearningagrtrainer", typeof(int));
	tcefrlanglevel.defineColumn("idnation", typeof(int));
	tcefrlanglevel.defineColumn("lt", typeof(DateTime),false);
	tcefrlanglevel.defineColumn("lu", typeof(string),false);
	Tables.Add(tcefrlanglevel);
	tcefrlanglevel.defineKey("idcefrlanglevel");

	//////////////////// CEFRLANGLEVEL_ALIAS3 /////////////////////////////////
	var tcefrlanglevel_alias3= new MetaTable("cefrlanglevel_alias3");
	tcefrlanglevel_alias3.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel_alias3.defineColumn("cu", typeof(string),false);
	tcefrlanglevel_alias3.defineColumn("idaccordoscambiomi", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idaccordoscambiomidett", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idaccordoscambiomidettlangkind", typeof(int),false);
	tcefrlanglevel_alias3.defineColumn("idcefr_compasc", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefr_complett", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefr_scritto", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlanglevel_alias3.defineColumn("idiscrizionebmi", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idlearningagrstud", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idlearningagrtrainer", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idnation", typeof(int));
	tcefrlanglevel_alias3.defineColumn("lt", typeof(DateTime),false);
	tcefrlanglevel_alias3.defineColumn("lu", typeof(string),false);
	tcefrlanglevel_alias3.ExtendedProperties["TableForReading"]="cefrlanglevel";
	Tables.Add(tcefrlanglevel_alias3);
	tcefrlanglevel_alias3.defineKey("idcefrlanglevel");

	//////////////////// CONVALIDATO_ALIAS1 /////////////////////////////////
	var tconvalidato_alias1= new MetaTable("convalidato_alias1");
	tconvalidato_alias1.defineColumn("changesother", typeof(string));
	tconvalidato_alias1.defineColumn("ct", typeof(DateTime),false);
	tconvalidato_alias1.defineColumn("cu", typeof(string),false);
	tconvalidato_alias1.defineColumn("idattivform", typeof(int),false);
	tconvalidato_alias1.defineColumn("idchanges", typeof(int));
	tconvalidato_alias1.defineColumn("idchangeskind", typeof(int));
	tconvalidato_alias1.defineColumn("idconvalida", typeof(int),false);
	tconvalidato_alias1.defineColumn("idconvalidato", typeof(int),false);
	tconvalidato_alias1.defineColumn("iddichiar", typeof(int));
	tconvalidato_alias1.defineColumn("iddidprog", typeof(int));
	tconvalidato_alias1.defineColumn("idiscrizione", typeof(int));
	tconvalidato_alias1.defineColumn("idiscrizione_from", typeof(int));
	tconvalidato_alias1.defineColumn("idiscrizionebmi", typeof(int));
	tconvalidato_alias1.defineColumn("idistanza", typeof(int));
	tconvalidato_alias1.defineColumn("idlearningagrstud", typeof(int));
	tconvalidato_alias1.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidato_alias1.defineColumn("idpratica", typeof(int));
	tconvalidato_alias1.defineColumn("idreg", typeof(int),false);
	tconvalidato_alias1.defineColumn("lt", typeof(DateTime),false);
	tconvalidato_alias1.defineColumn("lu", typeof(string),false);
	tconvalidato_alias1.ExtendedProperties["TableForReading"]="convalidato";
	Tables.Add(tconvalidato_alias1);
	tconvalidato_alias1.defineKey("idconvalida", "idconvalidato", "idreg");

	//////////////////// CONVALIDA_ALIAS2 /////////////////////////////////
	var tconvalida_alias2= new MetaTable("convalida_alias2");
	tconvalida_alias2.defineColumn("cf", typeof(decimal));
	tconvalida_alias2.defineColumn("cfintegrazione", typeof(decimal));
	tconvalida_alias2.defineColumn("ct", typeof(DateTime),false);
	tconvalida_alias2.defineColumn("cu", typeof(string),false);
	tconvalida_alias2.defineColumn("data", typeof(DateTime));
	tconvalida_alias2.defineColumn("idconvalida", typeof(int),false);
	tconvalida_alias2.defineColumn("idconvalidakind", typeof(int));
	tconvalida_alias2.defineColumn("iddichiar", typeof(int));
	tconvalida_alias2.defineColumn("iddidprog", typeof(int));
	tconvalida_alias2.defineColumn("idiscrizione", typeof(int));
	tconvalida_alias2.defineColumn("idiscrizione_from", typeof(int));
	tconvalida_alias2.defineColumn("idiscrizionebmi", typeof(int));
	tconvalida_alias2.defineColumn("idistanza", typeof(int));
	tconvalida_alias2.defineColumn("idlearningagrstud", typeof(int));
	tconvalida_alias2.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalida_alias2.defineColumn("idpratica", typeof(int));
	tconvalida_alias2.defineColumn("idreg", typeof(int),false);
	tconvalida_alias2.defineColumn("lt", typeof(DateTime),false);
	tconvalida_alias2.defineColumn("lu", typeof(string),false);
	tconvalida_alias2.defineColumn("voto", typeof(decimal));
	tconvalida_alias2.defineColumn("votolode", typeof(string));
	tconvalida_alias2.defineColumn("votosu", typeof(int));
	tconvalida_alias2.ExtendedProperties["TableForReading"]="convalida";
	Tables.Add(tconvalida_alias2);
	tconvalida_alias2.defineKey("idconvalida", "idreg");

	//////////////////// REGISTRY_ALIAS2 /////////////////////////////////
	var tregistry_alias2= new MetaTable("registry_alias2");
	tregistry_alias2.defineColumn("active", typeof(string),false);
	tregistry_alias2.defineColumn("annotation", typeof(string));
	tregistry_alias2.defineColumn("authorization_free", typeof(string));
	tregistry_alias2.defineColumn("badgecode", typeof(string));
	tregistry_alias2.defineColumn("birthdate", typeof(DateTime));
	tregistry_alias2.defineColumn("ccp", typeof(string));
	tregistry_alias2.defineColumn("cf", typeof(string));
	tregistry_alias2.defineColumn("ct", typeof(DateTime),false);
	tregistry_alias2.defineColumn("cu", typeof(string),false);
	tregistry_alias2.defineColumn("email_fe", typeof(string));
	tregistry_alias2.defineColumn("extension", typeof(string));
	tregistry_alias2.defineColumn("extmatricula", typeof(string));
	tregistry_alias2.defineColumn("flag_pa", typeof(string));
	tregistry_alias2.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry_alias2.defineColumn("foreigncf", typeof(string));
	tregistry_alias2.defineColumn("forename", typeof(string));
	tregistry_alias2.defineColumn("gender", typeof(string));
	tregistry_alias2.defineColumn("idaccmotivecredit", typeof(string));
	tregistry_alias2.defineColumn("idaccmotivedebit", typeof(string));
	tregistry_alias2.defineColumn("idcategory", typeof(string));
	tregistry_alias2.defineColumn("idcentralizedcategory", typeof(string));
	tregistry_alias2.defineColumn("idcity", typeof(int));
	tregistry_alias2.defineColumn("idexternal", typeof(int));
	tregistry_alias2.defineColumn("idmaritalstatus", typeof(string));
	tregistry_alias2.defineColumn("idnation", typeof(int));
	tregistry_alias2.defineColumn("idreg", typeof(int),false);
	tregistry_alias2.defineColumn("idregistryclass", typeof(string));
	tregistry_alias2.defineColumn("idregistrykind", typeof(int));
	tregistry_alias2.defineColumn("idtitle", typeof(string));
	tregistry_alias2.defineColumn("ipa_fe", typeof(string));
	tregistry_alias2.defineColumn("ipa_perlapa", typeof(string));
	tregistry_alias2.defineColumn("location", typeof(string));
	tregistry_alias2.defineColumn("lt", typeof(DateTime),false);
	tregistry_alias2.defineColumn("lu", typeof(string),false);
	tregistry_alias2.defineColumn("maritalsurname", typeof(string));
	tregistry_alias2.defineColumn("multi_cf", typeof(string));
	tregistry_alias2.defineColumn("p_iva", typeof(string));
	tregistry_alias2.defineColumn("pec_fe", typeof(string));
	tregistry_alias2.defineColumn("residence", typeof(int),false);
	tregistry_alias2.defineColumn("rtf", typeof(Byte[]));
	tregistry_alias2.defineColumn("sdi_defrifamm", typeof(string));
	tregistry_alias2.defineColumn("sdi_norifamm", typeof(string));
	tregistry_alias2.defineColumn("surname", typeof(string));
	tregistry_alias2.defineColumn("title", typeof(string),false);
	tregistry_alias2.defineColumn("toredirect", typeof(int));
	tregistry_alias2.defineColumn("txt", typeof(string));
	tregistry_alias2.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias2);
	tregistry_alias2.defineKey("idreg");

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

	//////////////////// LEARNINGAGRTRAINERVALUT /////////////////////////////////
	var tlearningagrtrainervalut= new MetaTable("learningagrtrainervalut");
	tlearningagrtrainervalut.defineColumn("description", typeof(string));
	tlearningagrtrainervalut.defineColumn("idlearningagrtrainervalut", typeof(int),false);
	tlearningagrtrainervalut.defineColumn("title", typeof(string),false);
	Tables.Add(tlearningagrtrainervalut);
	tlearningagrtrainervalut.defineKey("idlearningagrtrainervalut");

	//////////////////// LEARNINGAGRTRAINERKIND /////////////////////////////////
	var tlearningagrtrainerkind= new MetaTable("learningagrtrainerkind");
	tlearningagrtrainerkind.defineColumn("idlearningagrtrainerkind", typeof(int),false);
	tlearningagrtrainerkind.defineColumn("title", typeof(string),false);
	Tables.Add(tlearningagrtrainerkind);
	tlearningagrtrainerkind.defineKey("idlearningagrtrainerkind");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// LEARNINGAGRTRAINER /////////////////////////////////
	var tlearningagrtrainer= new MetaTable("learningagrtrainer");
	tlearningagrtrainer.defineColumn("address", typeof(string));
	tlearningagrtrainer.defineColumn("assicurazienda", typeof(string));
	tlearningagrtrainer.defineColumn("assicuraziendacivile", typeof(string));
	tlearningagrtrainer.defineColumn("assicuraziendaspost", typeof(string));
	tlearningagrtrainer.defineColumn("assicuraziendaviagg", typeof(string));
	tlearningagrtrainer.defineColumn("assicuristituto", typeof(string),false);
	tlearningagrtrainer.defineColumn("assicuristitutocivile", typeof(string));
	tlearningagrtrainer.defineColumn("assicuristitutospost", typeof(string));
	tlearningagrtrainer.defineColumn("assicuristitutoviagg", typeof(string));
	tlearningagrtrainer.defineColumn("cap", typeof(string));
	tlearningagrtrainer.defineColumn("capacitaacquis", typeof(string),false);
	tlearningagrtrainer.defineColumn("ct", typeof(DateTime),false);
	tlearningagrtrainer.defineColumn("cu", typeof(string),false);
	tlearningagrtrainer.defineColumn("ectscf", typeof(int));
	tlearningagrtrainer.defineColumn("ectstitle", typeof(string));
	tlearningagrtrainer.defineColumn("idbandomi", typeof(int),false);
	tlearningagrtrainer.defineColumn("idcity", typeof(int));
	tlearningagrtrainer.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrtrainer.defineColumn("idlearningagrkind", typeof(int),false);
	tlearningagrtrainer.defineColumn("idlearningagrtrainer", typeof(int),false);
	tlearningagrtrainer.defineColumn("idlearningagrtrainerkind", typeof(int),false);
	tlearningagrtrainer.defineColumn("idlearningagrtrainervalut", typeof(int));
	tlearningagrtrainer.defineColumn("idnation", typeof(int));
	tlearningagrtrainer.defineColumn("idreg", typeof(int),false);
	tlearningagrtrainer.defineColumn("idreg_aziende", typeof(int));
	tlearningagrtrainer.defineColumn("location", typeof(string));
	tlearningagrtrainer.defineColumn("lt", typeof(DateTime),false);
	tlearningagrtrainer.defineColumn("lu", typeof(string),false);
	tlearningagrtrainer.defineColumn("oresettimana", typeof(int),false);
	tlearningagrtrainer.defineColumn("pianomonit", typeof(string),false);
	tlearningagrtrainer.defineColumn("pianovalut", typeof(string),false);
	tlearningagrtrainer.defineColumn("programma", typeof(string),false);
	tlearningagrtrainer.defineColumn("registrainemd", typeof(string));
	tlearningagrtrainer.defineColumn("registraintor", typeof(string));
	tlearningagrtrainer.defineColumn("sostaltro", typeof(decimal));
	tlearningagrtrainer.defineColumn("sostazienda", typeof(decimal));
	tlearningagrtrainer.defineColumn("start", typeof(DateTime),false);
	tlearningagrtrainer.defineColumn("stop", typeof(DateTime),false);
	tlearningagrtrainer.defineColumn("title", typeof(string),false);
	tlearningagrtrainer.defineColumn("voto", typeof(int));
	tlearningagrtrainer.defineColumn("!idcity_geo_city_title", typeof(string));
	tlearningagrtrainer.defineColumn("!idlearningagrkind_learningagrkind_title", typeof(string));
	tlearningagrtrainer.defineColumn("!idlearningagrkind_learningagrkind_description", typeof(string));
	tlearningagrtrainer.defineColumn("!idlearningagrtrainerkind_learningagrtrainerkind_title", typeof(string));
	tlearningagrtrainer.defineColumn("!idlearningagrtrainervalut_learningagrtrainervalut_title", typeof(string));
	tlearningagrtrainer.defineColumn("!idlearningagrtrainervalut_learningagrtrainervalut_description", typeof(string));
	tlearningagrtrainer.defineColumn("!idreg_aziende_registry_aziende_title", typeof(string));
	Tables.Add(tlearningagrtrainer);
	tlearningagrtrainer.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

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

	//////////////////// GEO_NATION_ALIAS1 /////////////////////////////////
	var tgeo_nation_alias1= new MetaTable("geo_nation_alias1");
	tgeo_nation_alias1.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias1.defineColumn("title", typeof(string));
	tgeo_nation_alias1.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias1);
	tgeo_nation_alias1.defineKey("idnation");

	//////////////////// ISCED2013 /////////////////////////////////
	var tisced2013= new MetaTable("isced2013");
	tisced2013.defineColumn("detailedfield", typeof(string));
	tisced2013.defineColumn("idisced2013", typeof(int),false);
	Tables.Add(tisced2013);
	tisced2013.defineKey("idisced2013");

	//////////////////// STAFFAGRTEACHING /////////////////////////////////
	var tstaffagrteaching= new MetaTable("staffagrteaching");
	tstaffagrteaching.defineColumn("ct", typeof(DateTime),false);
	tstaffagrteaching.defineColumn("cu", typeof(string),false);
	tstaffagrteaching.defineColumn("idbandomi", typeof(int),false);
	tstaffagrteaching.defineColumn("idisced2013", typeof(int),false);
	tstaffagrteaching.defineColumn("idiscrizionebmi", typeof(int),false);
	tstaffagrteaching.defineColumn("idlivelloeqf", typeof(int),false);
	tstaffagrteaching.defineColumn("idnation", typeof(int));
	tstaffagrteaching.defineColumn("idreg", typeof(int),false);
	tstaffagrteaching.defineColumn("idreg_docenti", typeof(int),false);
	tstaffagrteaching.defineColumn("idreg_resp", typeof(int),false);
	tstaffagrteaching.defineColumn("idreg_respestero", typeof(int));
	tstaffagrteaching.defineColumn("idstaffagrteaching", typeof(int),false);
	tstaffagrteaching.defineColumn("lt", typeof(DateTime),false);
	tstaffagrteaching.defineColumn("lu", typeof(string),false);
	tstaffagrteaching.defineColumn("numore", typeof(int));
	tstaffagrteaching.defineColumn("numstud", typeof(int));
	tstaffagrteaching.defineColumn("obiettivi", typeof(string));
	tstaffagrteaching.defineColumn("programma", typeof(string));
	tstaffagrteaching.defineColumn("risultati", typeof(string));
	tstaffagrteaching.defineColumn("valore", typeof(string));
	tstaffagrteaching.defineColumn("!idisced2013_isced2013_detailedfield", typeof(string));
	tstaffagrteaching.defineColumn("!idnation_geo_nation_title", typeof(string));
	tstaffagrteaching.defineColumn("!idreg_docenti_registry_docenti_title", typeof(string));
	tstaffagrteaching.defineColumn("!idreg_resp_registry_title", typeof(string));
	tstaffagrteaching.defineColumn("!idreg_respestero_registry_title", typeof(string));
	Tables.Add(tstaffagrteaching);
	tstaffagrteaching.defineKey("idbandomi", "idiscrizionebmi", "idreg", "idstaffagrteaching");

	//////////////////// CEFRLANGLEVEL_ALIAS2 /////////////////////////////////
	var tcefrlanglevel_alias2= new MetaTable("cefrlanglevel_alias2");
	tcefrlanglevel_alias2.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel_alias2.defineColumn("cu", typeof(string),false);
	tcefrlanglevel_alias2.defineColumn("idaccordoscambiomi", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idaccordoscambiomidett", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idaccordoscambiomidettlangkind", typeof(int),false);
	tcefrlanglevel_alias2.defineColumn("idcefr_compasc", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefr_complett", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefr_scritto", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlanglevel_alias2.defineColumn("idiscrizionebmi", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idlearningagrstud", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idlearningagrtrainer", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idnation", typeof(int));
	tcefrlanglevel_alias2.defineColumn("lt", typeof(DateTime),false);
	tcefrlanglevel_alias2.defineColumn("lu", typeof(string),false);
	tcefrlanglevel_alias2.ExtendedProperties["TableForReading"]="cefrlanglevel";
	Tables.Add(tcefrlanglevel_alias2);
	tcefrlanglevel_alias2.defineKey("idcefrlanglevel");

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

	//////////////////// CONVALIDA /////////////////////////////////
	var tconvalida= new MetaTable("convalida");
	tconvalida.defineColumn("cf", typeof(decimal));
	tconvalida.defineColumn("cfintegrazione", typeof(decimal));
	tconvalida.defineColumn("ct", typeof(DateTime),false);
	tconvalida.defineColumn("cu", typeof(string),false);
	tconvalida.defineColumn("data", typeof(DateTime));
	tconvalida.defineColumn("idconvalida", typeof(int),false);
	tconvalida.defineColumn("idconvalidakind", typeof(int));
	tconvalida.defineColumn("iddichiar", typeof(int));
	tconvalida.defineColumn("iddidprog", typeof(int));
	tconvalida.defineColumn("idiscrizione", typeof(int));
	tconvalida.defineColumn("idiscrizione_from", typeof(int));
	tconvalida.defineColumn("idiscrizionebmi", typeof(int));
	tconvalida.defineColumn("idistanza", typeof(int));
	tconvalida.defineColumn("idlearningagrstud", typeof(int));
	tconvalida.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalida.defineColumn("idpratica", typeof(int));
	tconvalida.defineColumn("idreg", typeof(int),false);
	tconvalida.defineColumn("lt", typeof(DateTime),false);
	tconvalida.defineColumn("lu", typeof(string),false);
	tconvalida.defineColumn("voto", typeof(decimal));
	tconvalida.defineColumn("votolode", typeof(string));
	tconvalida.defineColumn("votosu", typeof(int));
	Tables.Add(tconvalida);
	tconvalida.defineKey("idconvalida", "idreg");

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

	//////////////////// REGISTRY_ISTITUTIESTERI /////////////////////////////////
	var tregistry_istitutiesteri= new MetaTable("registry_istitutiesteri");
	tregistry_istitutiesteri.defineColumn("city", typeof(string),false);
	tregistry_istitutiesteri.defineColumn("code", typeof(string));
	tregistry_istitutiesteri.defineColumn("ct", typeof(DateTime),false);
	tregistry_istitutiesteri.defineColumn("cu", typeof(string),false);
	tregistry_istitutiesteri.defineColumn("idnace", typeof(string));
	tregistry_istitutiesteri.defineColumn("idreg", typeof(int),false);
	tregistry_istitutiesteri.defineColumn("institutionalcode", typeof(string));
	tregistry_istitutiesteri.defineColumn("lt", typeof(DateTime),false);
	tregistry_istitutiesteri.defineColumn("lu", typeof(string),false);
	tregistry_istitutiesteri.defineColumn("name", typeof(string),false);
	tregistry_istitutiesteri.defineColumn("referencenumber", typeof(string));
	Tables.Add(tregistry_istitutiesteri);
	tregistry_istitutiesteri.defineKey("idreg");

	//////////////////// LEARNINGAGRKIND /////////////////////////////////
	var tlearningagrkind= new MetaTable("learningagrkind");
	tlearningagrkind.defineColumn("description", typeof(string));
	tlearningagrkind.defineColumn("idlearningagrkind", typeof(int),false);
	tlearningagrkind.defineColumn("title", typeof(string));
	Tables.Add(tlearningagrkind);
	tlearningagrkind.defineKey("idlearningagrkind");

	//////////////////// LEARNINGAGRSTUD /////////////////////////////////
	var tlearningagrstud= new MetaTable("learningagrstud");
	tlearningagrstud.defineColumn("ct", typeof(DateTime),false);
	tlearningagrstud.defineColumn("cu", typeof(string),false);
	tlearningagrstud.defineColumn("idbandomi", typeof(int),false);
	tlearningagrstud.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrkind", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrstud", typeof(int),false);
	tlearningagrstud.defineColumn("idreg", typeof(int),false);
	tlearningagrstud.defineColumn("idreg_istitutiesteri", typeof(int));
	tlearningagrstud.defineColumn("lt", typeof(DateTime),false);
	tlearningagrstud.defineColumn("lu", typeof(string),false);
	tlearningagrstud.defineColumn("note", typeof(string));
	tlearningagrstud.defineColumn("start", typeof(DateTime),false);
	tlearningagrstud.defineColumn("stop", typeof(DateTime),false);
	tlearningagrstud.defineColumn("!idlearningagrkind_learningagrkind_title", typeof(string));
	tlearningagrstud.defineColumn("!idlearningagrkind_learningagrkind_description", typeof(string));
	tlearningagrstud.defineColumn("!idreg_istitutiesteri_registry_istitutiesteri_title", typeof(string));
	Tables.Add(tlearningagrstud);
	tlearningagrstud.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrstud", "idreg");

	//////////////////// ISCRIZIONEBMIREQUISITO /////////////////////////////////
	var tiscrizionebmirequisito= new MetaTable("iscrizionebmirequisito");
	tiscrizionebmirequisito.defineColumn("ct", typeof(DateTime),false);
	tiscrizionebmirequisito.defineColumn("cu", typeof(string),false);
	tiscrizionebmirequisito.defineColumn("idbandomi", typeof(int),false);
	tiscrizionebmirequisito.defineColumn("idiscrizionebmi", typeof(int),false);
	tiscrizionebmirequisito.defineColumn("idreg", typeof(int),false);
	tiscrizionebmirequisito.defineColumn("idrequisito", typeof(int),false);
	tiscrizionebmirequisito.defineColumn("lt", typeof(DateTime),false);
	tiscrizionebmirequisito.defineColumn("lu", typeof(string),false);
	Tables.Add(tiscrizionebmirequisito);
	tiscrizionebmirequisito.defineKey("idbandomi", "idiscrizionebmi", "idreg", "idrequisito");

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

	//////////////////// ISCRIZIONEBMIATTACH /////////////////////////////////
	var tiscrizionebmiattach= new MetaTable("iscrizionebmiattach");
	tiscrizionebmiattach.defineColumn("ct", typeof(DateTime),false);
	tiscrizionebmiattach.defineColumn("cu", typeof(string),false);
	tiscrizionebmiattach.defineColumn("idattach", typeof(int),false);
	tiscrizionebmiattach.defineColumn("idbandomi", typeof(int),false);
	tiscrizionebmiattach.defineColumn("idiscrizionebmi", typeof(int),false);
	tiscrizionebmiattach.defineColumn("idreg", typeof(int),false);
	tiscrizionebmiattach.defineColumn("lt", typeof(DateTime),false);
	tiscrizionebmiattach.defineColumn("lu", typeof(string),false);
	tiscrizionebmiattach.defineColumn("title", typeof(string));
	tiscrizionebmiattach.defineColumn("!idattach_attach_filename", typeof(string));
	tiscrizionebmiattach.defineColumn("!idattach_attach_size", typeof(int));
	Tables.Add(tiscrizionebmiattach);
	tiscrizionebmiattach.defineKey("idattach", "idbandomi", "idiscrizionebmi", "idreg");

	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("idcity", typeof(int));
	tregistrystudentiview.defineColumn("idnation", typeof(int));
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("idregistryclass", typeof(string));
	tregistrystudentiview.defineColumn("idtitle", typeof(string));
	tregistrystudentiview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("anno", typeof(int));
	tiscrizionedefaultview.defineColumn("annoaccademico_aa", typeof(string));
	tiscrizionedefaultview.defineColumn("didprog_title", typeof(string));
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int));
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
	tiscrizionedefaultview.defineKey("idiscrizione");

	//////////////////// ISCRIZIONEBMI /////////////////////////////////
	var tiscrizionebmi= new MetaTable("iscrizionebmi");
	tiscrizionebmi.defineColumn("ct", typeof(DateTime),false);
	tiscrizionebmi.defineColumn("cu", typeof(string),false);
	tiscrizionebmi.defineColumn("data", typeof(DateTime));
	tiscrizionebmi.defineColumn("idbandomi", typeof(int),false);
	tiscrizionebmi.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionebmi.defineColumn("idiscrizionebmi", typeof(int),false);
	tiscrizionebmi.defineColumn("idreg", typeof(int),false);
	tiscrizionebmi.defineColumn("lt", typeof(DateTime),false);
	tiscrizionebmi.defineColumn("lu", typeof(string),false);
	Tables.Add(tiscrizionebmi);
	tiscrizionebmi.defineKey("idbandomi", "idiscrizionebmi", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{iscrizionebmi.Columns["idiscrizionebmi"]};
	var cChild = new []{cefrlanglevel.Columns["idiscrizionebmi"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_iscrizionebmi_idiscrizionebmi",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{cefrlanglevel.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{cefrdefaultview_alias4.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_scritto"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefrdefaultview_alias4_idcefr_scritto",cPar,cChild,false));

	cPar = new []{cefrdefaultview_alias3.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_parlprod"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefrdefaultview_alias3_idcefr_parlprod",cPar,cChild,false));

	cPar = new []{cefrdefaultview_alias2.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_parlinter"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefrdefaultview_alias2_idcefr_parlinter",cPar,cChild,false));

	cPar = new []{cefrdefaultview_alias1.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_complett"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefrdefaultview_alias1_idcefr_complett",cPar,cChild,false));

	cPar = new []{cefrdefaultview.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_compasc"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefrdefaultview_idcefr_compasc",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{learningagrtrainer.Columns["idbandomi"], learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idlearningagrtrainer"], learningagrtrainer.Columns["idnation"]};
	cChild = new []{cefrlanglevel_alias3.Columns["idiscrizionebmi"], cefrlanglevel_alias3.Columns["idlearningagrtrainer"], cefrlanglevel_alias3.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_alias3_learningagrtrainer_idiscrizionebmi-idlearningagrtrainer-idnation",cPar,cChild,false));

	cPar = new []{learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idlearningagrtrainer"], learningagrtrainer.Columns["idreg"]};
	cChild = new []{convalida_alias2.Columns["idiscrizionebmi"], convalida_alias2.Columns["idlearningagrtrainer"], convalida_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalida_alias2_learningagrtrainer_idiscrizionebmi-idlearningagrtrainer-idreg",cPar,cChild,false));

	cPar = new []{convalida_alias2.Columns["idconvalida"], convalida_alias2.Columns["idreg"]};
	cChild = new []{convalidato_alias1.Columns["idconvalida"], convalidato_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_alias1_convalida_alias2_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{registry_alias2.Columns["idreg"]};
	cChild = new []{learningagrtrainer.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_registry_alias2_idreg_aziende",cPar,cChild,false));

	cPar = new []{registry_alias2.Columns["idreg"]};
	cChild = new []{registry_aziende.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_aziende_registry_alias2_idreg",cPar,cChild,false));

	cPar = new []{learningagrtrainervalut.Columns["idlearningagrtrainervalut"]};
	cChild = new []{learningagrtrainer.Columns["idlearningagrtrainervalut"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_learningagrtrainervalut_idlearningagrtrainervalut",cPar,cChild,false));

	cPar = new []{learningagrtrainerkind.Columns["idlearningagrtrainerkind"]};
	cChild = new []{learningagrtrainer.Columns["idlearningagrtrainerkind"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_learningagrtrainerkind_idlearningagrtrainerkind",cPar,cChild,false));

	cPar = new []{learningagrkind.Columns["idlearningagrkind"]};
	cChild = new []{learningagrtrainer.Columns["idlearningagrkind"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_learningagrkind_idlearningagrkind",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{learningagrtrainer.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_geo_city_idcity",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{staffagrteaching.Columns["idbandomi"], staffagrteaching.Columns["idiscrizionebmi"], staffagrteaching.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{registry_alias2.Columns["idreg"]};
	cChild = new []{staffagrteaching.Columns["idreg_respestero"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_registry_alias2_idreg_respestero",cPar,cChild,false));

	cPar = new []{registry_alias2.Columns["idreg"]};
	cChild = new []{staffagrteaching.Columns["idreg_resp"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_registry_alias2_idreg_resp",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{staffagrteaching.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_registry_alias1_idreg_docenti",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registry_docenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_docenti_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{geo_nation_alias1.Columns["idnation"]};
	cChild = new []{staffagrteaching.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_geo_nation_alias1_idnation",cPar,cChild,false));

	cPar = new []{isced2013.Columns["idisced2013"]};
	cChild = new []{staffagrteaching.Columns["idisced2013"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_isced2013_idisced2013",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{learningagrstud.Columns["idbandomi"], learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_learningagrstud_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idlearningagrstud"]};
	cChild = new []{cefrlanglevel_alias2.Columns["idiscrizionebmi"], cefrlanglevel_alias2.Columns["idlearningagrstud"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_alias2_learningagrstud_idiscrizionebmi-idlearningagrstud",cPar,cChild,false));

	cPar = new []{learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idlearningagrstud"], learningagrstud.Columns["idreg"]};
	cChild = new []{convalida.Columns["idiscrizionebmi"], convalida.Columns["idlearningagrstud"], convalida.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalida_learningagrstud_idiscrizionebmi-idlearningagrstud-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{learningagrstud.Columns["idreg_istitutiesteri"]};
	Relations.Add(new DataRelation("FK_learningagrstud_registry_idreg_istitutiesteri",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_istitutiesteri.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_istitutiesteri_registry_idreg",cPar,cChild,false));

	cPar = new []{learningagrkind.Columns["idlearningagrkind"]};
	cChild = new []{learningagrstud.Columns["idlearningagrkind"]};
	Relations.Add(new DataRelation("FK_learningagrstud_learningagrkind_idlearningagrkind",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{iscrizionebmirequisito.Columns["idbandomi"], iscrizionebmirequisito.Columns["idiscrizionebmi"], iscrizionebmirequisito.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionebmirequisito_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{iscrizionebmiattach.Columns["idbandomi"], iscrizionebmiattach.Columns["idiscrizionebmi"], iscrizionebmiattach.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionebmiattach_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{iscrizionebmiattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_iscrizionebmiattach_attach_idattach",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{iscrizionebmi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionebmi_registrystudentiview_idreg",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{iscrizionebmi.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_iscrizionebmi_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	#endregion

}
}
}
