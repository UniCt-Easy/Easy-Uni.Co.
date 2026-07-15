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
[System.Xml.Serialization.XmlRoot("dsmeta_iscrizionebmi_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_iscrizionebmi_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias4 		=> (MetaTable)Tables["registry_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias3 		=> (MetaTable)Tables["registry_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias2 		=> (MetaTable)Tables["registry_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias2 		=> (MetaTable)Tables["geo_nation_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable isced2013 		=> (MetaTable)Tables["isced2013"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable eqf_alias1 		=> (MetaTable)Tables["eqf_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable staffagrteaching 		=> (MetaTable)Tables["staffagrteaching"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel_alias3 		=> (MetaTable)Tables["cefrlanglevel_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato_alias1 		=> (MetaTable)Tables["convalidato_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida_alias2 		=> (MetaTable)Tables["convalida_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainervalut 		=> (MetaTable)Tables["learningagrtrainervalut"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainerkind 		=> (MetaTable)Tables["learningagrtrainerkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrkind_alias1 		=> (MetaTable)Tables["learningagrkind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainer 		=> (MetaTable)Tables["learningagrtrainer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel_alias2 		=> (MetaTable)Tables["cefrlanglevel_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidante 		=> (MetaTable)Tables["convalidante"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mobilityperiodtype 		=> (MetaTable)Tables["mobilityperiodtype"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrkind 		=> (MetaTable)Tables["learningagrkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable eqf 		=> (MetaTable)Tables["eqf"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrstud 		=> (MetaTable)Tables["learningagrstud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmirequisito 		=> (MetaTable)Tables["iscrizionebmirequisito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmiattach 		=> (MetaTable)Tables["iscrizionebmiattach"];

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
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

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
	//////////////////// REGISTRY_ALIAS4 /////////////////////////////////
	var tregistry_alias4= new MetaTable("registry_alias4");
	tregistry_alias4.defineColumn("active", typeof(string),false);
	tregistry_alias4.defineColumn("idreg", typeof(int),false);
	tregistry_alias4.defineColumn("title", typeof(string),false);
	tregistry_alias4.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias4);
	tregistry_alias4.defineKey("idreg");

	//////////////////// REGISTRY_ALIAS3 /////////////////////////////////
	var tregistry_alias3= new MetaTable("registry_alias3");
	tregistry_alias3.defineColumn("active", typeof(string),false);
	tregistry_alias3.defineColumn("idreg", typeof(int),false);
	tregistry_alias3.defineColumn("title", typeof(string),false);
	tregistry_alias3.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias3);
	tregistry_alias3.defineKey("idreg");

	//////////////////// REGISTRY_ALIAS2 /////////////////////////////////
	var tregistry_alias2= new MetaTable("registry_alias2");
	tregistry_alias2.defineColumn("active", typeof(string),false);
	tregistry_alias2.defineColumn("idreg", typeof(int),false);
	tregistry_alias2.defineColumn("title", typeof(string),false);
	tregistry_alias2.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias2);
	tregistry_alias2.defineKey("idreg");

	//////////////////// GEO_NATION_ALIAS2 /////////////////////////////////
	var tgeo_nation_alias2= new MetaTable("geo_nation_alias2");
	tgeo_nation_alias2.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias2.defineColumn("title", typeof(string));
	tgeo_nation_alias2.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias2);
	tgeo_nation_alias2.defineKey("idnation");

	//////////////////// ISCED2013 /////////////////////////////////
	var tisced2013= new MetaTable("isced2013");
	tisced2013.defineColumn("active", typeof(string));
	tisced2013.defineColumn("detailedfield", typeof(string));
	tisced2013.defineColumn("idisced2013", typeof(int),false);
	Tables.Add(tisced2013);
	tisced2013.defineKey("idisced2013");

	//////////////////// EQF_ALIAS1 /////////////////////////////////
	var teqf_alias1= new MetaTable("eqf_alias1");
	teqf_alias1.defineColumn("ideqf", typeof(int),false);
	teqf_alias1.defineColumn("level", typeof(int));
	teqf_alias1.ExtendedProperties["TableForReading"]="eqf";
	Tables.Add(teqf_alias1);
	teqf_alias1.defineKey("ideqf");

	//////////////////// STAFFAGRTEACHING /////////////////////////////////
	var tstaffagrteaching= new MetaTable("staffagrteaching");
	tstaffagrteaching.defineColumn("ct", typeof(DateTime),false);
	tstaffagrteaching.defineColumn("cu", typeof(string),false);
	tstaffagrteaching.defineColumn("idbandomi", typeof(int),false);
	tstaffagrteaching.defineColumn("ideqf", typeof(int),false);
	tstaffagrteaching.defineColumn("idisced2013", typeof(int),false);
	tstaffagrteaching.defineColumn("idiscrizionebmi", typeof(int),false);
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
	tstaffagrteaching.defineColumn("!ideqf_eqf_level", typeof(int));
	tstaffagrteaching.defineColumn("!idisced2013_isced2013_detailedfield", typeof(string));
	tstaffagrteaching.defineColumn("!idnation_geo_nation_title", typeof(string));
	tstaffagrteaching.defineColumn("!idreg_docenti_registry_title", typeof(string));
	tstaffagrteaching.defineColumn("!idreg_resp_registry_title", typeof(string));
	tstaffagrteaching.defineColumn("!idreg_respestero_registry_title", typeof(string));
	Tables.Add(tstaffagrteaching);
	tstaffagrteaching.defineKey("idbandomi", "idiscrizionebmi", "idreg", "idstaffagrteaching");

	//////////////////// CEFRLANGLEVEL_ALIAS3 /////////////////////////////////
	var tcefrlanglevel_alias3= new MetaTable("cefrlanglevel_alias3");
	tcefrlanglevel_alias3.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel_alias3.defineColumn("cu", typeof(string),false);
	tcefrlanglevel_alias3.defineColumn("idaccordoscambiomi", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idaccordoscambiomidett", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idaccordoscambiomidettlangkind", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefr_compasc", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefr_complett", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefr_scritto", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlanglevel_alias3.defineColumn("idiscrizionebmi", typeof(int),false);
	tcefrlanglevel_alias3.defineColumn("idlearningagrstud", typeof(int));
	tcefrlanglevel_alias3.defineColumn("idlearningagrtrainer", typeof(int),false);
	tcefrlanglevel_alias3.defineColumn("idnation", typeof(int));
	tcefrlanglevel_alias3.defineColumn("lt", typeof(DateTime),false);
	tcefrlanglevel_alias3.defineColumn("lu", typeof(string),false);
	tcefrlanglevel_alias3.ExtendedProperties["TableForReading"]="cefrlanglevel";
	tcefrlanglevel_alias3.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tcefrlanglevel_alias3);
	tcefrlanglevel_alias3.defineKey("idcefrlanglevel", "idiscrizionebmi", "idlearningagrtrainer");

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
	tconvalidato_alias1.defineColumn("idiscrizionebmi", typeof(int),false);
	tconvalidato_alias1.defineColumn("idistanza", typeof(int));
	tconvalidato_alias1.defineColumn("idlearningagrstud", typeof(int));
	tconvalidato_alias1.defineColumn("idlearningagrtrainer", typeof(int),false);
	tconvalidato_alias1.defineColumn("idpratica", typeof(int));
	tconvalidato_alias1.defineColumn("idreg", typeof(int),false);
	tconvalidato_alias1.defineColumn("lt", typeof(DateTime),false);
	tconvalidato_alias1.defineColumn("lu", typeof(string),false);
	tconvalidato_alias1.ExtendedProperties["TableForReading"]="convalidato";
	Tables.Add(tconvalidato_alias1);
	tconvalidato_alias1.defineKey("idconvalida", "idconvalidato", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

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
	tconvalida_alias2.defineColumn("idiscrizionebmi", typeof(int),false);
	tconvalida_alias2.defineColumn("idistanza", typeof(int));
	tconvalida_alias2.defineColumn("idlearningagrstud", typeof(int));
	tconvalida_alias2.defineColumn("idlearningagrtrainer", typeof(int),false);
	tconvalida_alias2.defineColumn("idpratica", typeof(int));
	tconvalida_alias2.defineColumn("idreg", typeof(int),false);
	tconvalida_alias2.defineColumn("lt", typeof(DateTime),false);
	tconvalida_alias2.defineColumn("lu", typeof(string),false);
	tconvalida_alias2.defineColumn("voto", typeof(decimal));
	tconvalida_alias2.defineColumn("votolode", typeof(string));
	tconvalida_alias2.defineColumn("votosu", typeof(int));
	tconvalida_alias2.ExtendedProperties["TableForReading"]="convalida";
	tconvalida_alias2.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tconvalida_alias2);
	tconvalida_alias2.defineKey("idconvalida", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// LEARNINGAGRTRAINERVALUT /////////////////////////////////
	var tlearningagrtrainervalut= new MetaTable("learningagrtrainervalut");
	tlearningagrtrainervalut.defineColumn("active", typeof(string),false);
	tlearningagrtrainervalut.defineColumn("description", typeof(string));
	tlearningagrtrainervalut.defineColumn("idlearningagrtrainervalut", typeof(int),false);
	tlearningagrtrainervalut.defineColumn("title", typeof(string),false);
	Tables.Add(tlearningagrtrainervalut);
	tlearningagrtrainervalut.defineKey("idlearningagrtrainervalut");

	//////////////////// LEARNINGAGRTRAINERKIND /////////////////////////////////
	var tlearningagrtrainerkind= new MetaTable("learningagrtrainerkind");
	tlearningagrtrainerkind.defineColumn("active", typeof(string),false);
	tlearningagrtrainerkind.defineColumn("idlearningagrtrainerkind", typeof(int),false);
	tlearningagrtrainerkind.defineColumn("title", typeof(string),false);
	Tables.Add(tlearningagrtrainerkind);
	tlearningagrtrainerkind.defineKey("idlearningagrtrainerkind");

	//////////////////// LEARNINGAGRKIND_ALIAS1 /////////////////////////////////
	var tlearningagrkind_alias1= new MetaTable("learningagrkind_alias1");
	tlearningagrkind_alias1.defineColumn("active", typeof(string),false);
	tlearningagrkind_alias1.defineColumn("idlearningagrkind", typeof(int),false);
	tlearningagrkind_alias1.defineColumn("title", typeof(string));
	tlearningagrkind_alias1.ExtendedProperties["TableForReading"]="learningagrkind";
	Tables.Add(tlearningagrkind_alias1);
	tlearningagrkind_alias1.defineKey("idlearningagrkind");

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
	tlearningagrtrainer.defineColumn("!idlearningagrtrainerkind_learningagrtrainerkind_title", typeof(string));
	tlearningagrtrainer.defineColumn("!idlearningagrtrainervalut_learningagrtrainervalut_title", typeof(string));
	tlearningagrtrainer.defineColumn("!idlearningagrtrainervalut_learningagrtrainervalut_description", typeof(string));
	tlearningagrtrainer.defineColumn("!idreg_aziende_registry_title", typeof(string));
	Tables.Add(tlearningagrtrainer);
	tlearningagrtrainer.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

	//////////////////// CEFRLANGLEVEL_ALIAS2 /////////////////////////////////
	var tcefrlanglevel_alias2= new MetaTable("cefrlanglevel_alias2");
	tcefrlanglevel_alias2.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel_alias2.defineColumn("cu", typeof(string),false);
	tcefrlanglevel_alias2.defineColumn("idaccordoscambiomi", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idaccordoscambiomidett", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idaccordoscambiomidettlangkind", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefr_compasc", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefr_complett", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefr_scritto", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlanglevel_alias2.defineColumn("idiscrizionebmi", typeof(int),false);
	tcefrlanglevel_alias2.defineColumn("idlearningagrstud", typeof(int),false);
	tcefrlanglevel_alias2.defineColumn("idlearningagrtrainer", typeof(int));
	tcefrlanglevel_alias2.defineColumn("idnation", typeof(int));
	tcefrlanglevel_alias2.defineColumn("lt", typeof(DateTime),false);
	tcefrlanglevel_alias2.defineColumn("lu", typeof(string),false);
	tcefrlanglevel_alias2.ExtendedProperties["TableForReading"]="cefrlanglevel";
	tcefrlanglevel_alias2.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tcefrlanglevel_alias2);
	tcefrlanglevel_alias2.defineKey("idcefrlanglevel", "idiscrizionebmi", "idlearningagrstud");

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
	tconvalidato.defineColumn("idiscrizionebmi", typeof(int),false);
	tconvalidato.defineColumn("idistanza", typeof(int));
	tconvalidato.defineColumn("idlearningagrstud", typeof(int),false);
	tconvalidato.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidato.defineColumn("idpratica", typeof(int));
	tconvalidato.defineColumn("idreg", typeof(int),false);
	tconvalidato.defineColumn("lt", typeof(DateTime),false);
	tconvalidato.defineColumn("lu", typeof(string),false);
	Tables.Add(tconvalidato);
	tconvalidato.defineKey("idconvalida", "idconvalidato", "idiscrizionebmi", "idlearningagrstud", "idreg");

	//////////////////// CONVALIDANTE /////////////////////////////////
	var tconvalidante= new MetaTable("convalidante");
	tconvalidante.defineColumn("changes", typeof(string));
	tconvalidante.defineColumn("changesother", typeof(string));
	tconvalidante.defineColumn("ct", typeof(DateTime),false);
	tconvalidante.defineColumn("cu", typeof(string),false);
	tconvalidante.defineColumn("idchangeskind", typeof(int));
	tconvalidante.defineColumn("idconvalida", typeof(int),false);
	tconvalidante.defineColumn("idconvalidante", typeof(int),false);
	tconvalidante.defineColumn("iddichiar", typeof(int));
	tconvalidante.defineColumn("iddidprog", typeof(int));
	tconvalidante.defineColumn("idiscrizione", typeof(int));
	tconvalidante.defineColumn("idiscrizione_from", typeof(int));
	tconvalidante.defineColumn("idiscrizionebmi", typeof(int),false);
	tconvalidante.defineColumn("idistanza", typeof(int));
	tconvalidante.defineColumn("idlearningagrstud", typeof(int),false);
	tconvalidante.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidante.defineColumn("idpratica", typeof(int));
	tconvalidante.defineColumn("idreg", typeof(int),false);
	tconvalidante.defineColumn("idsostenimento", typeof(int));
	tconvalidante.defineColumn("idtirocinioprogetto", typeof(int));
	tconvalidante.defineColumn("lt", typeof(DateTime),false);
	tconvalidante.defineColumn("lu", typeof(string),false);
	Tables.Add(tconvalidante);
	tconvalidante.defineKey("idconvalida", "idconvalidante", "idiscrizionebmi", "idlearningagrstud", "idreg");

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
	tconvalida.defineColumn("idiscrizionebmi", typeof(int),false);
	tconvalida.defineColumn("idistanza", typeof(int));
	tconvalida.defineColumn("idlearningagrstud", typeof(int),false);
	tconvalida.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalida.defineColumn("idpratica", typeof(int));
	tconvalida.defineColumn("idreg", typeof(int),false);
	tconvalida.defineColumn("lt", typeof(DateTime),false);
	tconvalida.defineColumn("lu", typeof(string),false);
	tconvalida.defineColumn("voto", typeof(decimal));
	tconvalida.defineColumn("votolode", typeof(string));
	tconvalida.defineColumn("votosu", typeof(int));
	tconvalida.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tconvalida);
	tconvalida.defineKey("idconvalida", "idiscrizionebmi", "idlearningagrstud", "idreg");

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

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// MOBILITYPERIODTYPE /////////////////////////////////
	var tmobilityperiodtype= new MetaTable("mobilityperiodtype");
	tmobilityperiodtype.defineColumn("idmobilityperiodtype", typeof(int),false);
	tmobilityperiodtype.defineColumn("title", typeof(string));
	Tables.Add(tmobilityperiodtype);
	tmobilityperiodtype.defineKey("idmobilityperiodtype");

	//////////////////// LEARNINGAGRKIND /////////////////////////////////
	var tlearningagrkind= new MetaTable("learningagrkind");
	tlearningagrkind.defineColumn("active", typeof(string),false);
	tlearningagrkind.defineColumn("idlearningagrkind", typeof(int),false);
	tlearningagrkind.defineColumn("title", typeof(string));
	Tables.Add(tlearningagrkind);
	tlearningagrkind.defineKey("idlearningagrkind");

	//////////////////// EQF /////////////////////////////////
	var teqf= new MetaTable("eqf");
	teqf.defineColumn("ideqf", typeof(int),false);
	teqf.defineColumn("level", typeof(int));
	Tables.Add(teqf);
	teqf.defineKey("ideqf");

	//////////////////// LEARNINGAGRSTUD /////////////////////////////////
	var tlearningagrstud= new MetaTable("learningagrstud");
	tlearningagrstud.defineColumn("ct", typeof(DateTime),false);
	tlearningagrstud.defineColumn("cu", typeof(string),false);
	tlearningagrstud.defineColumn("department", typeof(string));
	tlearningagrstud.defineColumn("idbandomi", typeof(int),false);
	tlearningagrstud.defineColumn("ideqf", typeof(int));
	tlearningagrstud.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrkind", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrstud", typeof(int),false);
	tlearningagrstud.defineColumn("idmobilityperiodtype", typeof(int));
	tlearningagrstud.defineColumn("idreg", typeof(int),false);
	tlearningagrstud.defineColumn("idreg_istitutiesteri", typeof(int));
	tlearningagrstud.defineColumn("idstruttura", typeof(int));
	tlearningagrstud.defineColumn("lt", typeof(DateTime),false);
	tlearningagrstud.defineColumn("lu", typeof(string),false);
	tlearningagrstud.defineColumn("note", typeof(string));
	tlearningagrstud.defineColumn("start", typeof(DateTime),false);
	tlearningagrstud.defineColumn("stop", typeof(DateTime),false);
	tlearningagrstud.defineColumn("!ideqf_eqf_level", typeof(int));
	tlearningagrstud.defineColumn("!idlearningagrkind_learningagrkind_title", typeof(string));
	tlearningagrstud.defineColumn("!idmobilityperiodtype_mobilityperiodtype_title", typeof(string));
	tlearningagrstud.defineColumn("!idreg_istitutiesteri_registry_title", typeof(string));
	tlearningagrstud.defineColumn("!idstruttura_struttura_title", typeof(string));
	tlearningagrstud.defineColumn("!idstruttura_struttura_idstrutturakind_title", typeof(string));
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
	tattach.defineColumn("size", typeof(long),false);
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

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("lang", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// CEFRDEFAULTVIEW_ALIAS4 /////////////////////////////////
	var tcefrdefaultview_alias4= new MetaTable("cefrdefaultview_alias4");
	tcefrdefaultview_alias4.defineColumn("cefr_active", typeof(string));
	tcefrdefaultview_alias4.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias4.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias4.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias4);
	tcefrdefaultview_alias4.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW_ALIAS3 /////////////////////////////////
	var tcefrdefaultview_alias3= new MetaTable("cefrdefaultview_alias3");
	tcefrdefaultview_alias3.defineColumn("cefr_active", typeof(string));
	tcefrdefaultview_alias3.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias3.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias3.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias3);
	tcefrdefaultview_alias3.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW_ALIAS2 /////////////////////////////////
	var tcefrdefaultview_alias2= new MetaTable("cefrdefaultview_alias2");
	tcefrdefaultview_alias2.defineColumn("cefr_active", typeof(string));
	tcefrdefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias2.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias2.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias2);
	tcefrdefaultview_alias2.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tcefrdefaultview_alias1= new MetaTable("cefrdefaultview_alias1");
	tcefrdefaultview_alias1.defineColumn("cefr_active", typeof(string));
	tcefrdefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias1.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias1.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias1);
	tcefrdefaultview_alias1.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW /////////////////////////////////
	var tcefrdefaultview= new MetaTable("cefrdefaultview");
	tcefrdefaultview.defineColumn("cefr_active", typeof(string));
	tcefrdefaultview.defineColumn("cefr_descriptioncompasc", typeof(string),false);
	tcefrdefaultview.defineColumn("cefr_descriptioncomplett", typeof(string),false);
	tcefrdefaultview.defineColumn("cefr_descriptionparlinter", typeof(string),false);
	tcefrdefaultview.defineColumn("cefr_descriptionparlprod", typeof(string),false);
	tcefrdefaultview.defineColumn("cefr_descriptionscritto", typeof(string),false);
	tcefrdefaultview.defineColumn("cefr_lt", typeof(DateTime),false);
	tcefrdefaultview.defineColumn("cefr_lu", typeof(string),false);
	tcefrdefaultview.defineColumn("cefr_sortcode", typeof(int),false);
	tcefrdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tcefrdefaultview);
	tcefrdefaultview.defineKey("idcefr");

	//////////////////// CEFRLANGLEVEL /////////////////////////////////
	var tcefrlanglevel= new MetaTable("cefrlanglevel");
	tcefrlanglevel.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel.defineColumn("cu", typeof(string),false);
	tcefrlanglevel.defineColumn("idaccordoscambiomi", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidett", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidettlangkind", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_compasc", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_complett", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_scritto", typeof(int));
	tcefrlanglevel.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlanglevel.defineColumn("idiscrizionebmi", typeof(int),false);
	tcefrlanglevel.defineColumn("idlearningagrstud", typeof(int));
	tcefrlanglevel.defineColumn("idlearningagrtrainer", typeof(int));
	tcefrlanglevel.defineColumn("idnation", typeof(int));
	tcefrlanglevel.defineColumn("lt", typeof(DateTime),false);
	tcefrlanglevel.defineColumn("lu", typeof(string),false);
	tcefrlanglevel.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tcefrlanglevel);
	tcefrlanglevel.defineKey("idcefrlanglevel", "idiscrizionebmi");

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

	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

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
	var cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	var cChild = new []{staffagrteaching.Columns["idbandomi"], staffagrteaching.Columns["idiscrizionebmi"], staffagrteaching.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{registry_alias4.Columns["idreg"]};
	cChild = new []{staffagrteaching.Columns["idreg_respestero"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_registry_alias4_idreg_respestero",cPar,cChild,false));

	cPar = new []{registry_alias3.Columns["idreg"]};
	cChild = new []{staffagrteaching.Columns["idreg_resp"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_registry_alias3_idreg_resp",cPar,cChild,false));

	cPar = new []{registry_alias2.Columns["idreg"]};
	cChild = new []{staffagrteaching.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_registry_alias2_idreg_docenti",cPar,cChild,false));

	cPar = new []{geo_nation_alias2.Columns["idnation"]};
	cChild = new []{staffagrteaching.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_geo_nation_alias2_idnation",cPar,cChild,false));

	cPar = new []{isced2013.Columns["idisced2013"]};
	cChild = new []{staffagrteaching.Columns["idisced2013"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_isced2013_idisced2013",cPar,cChild,false));

	cPar = new []{eqf_alias1.Columns["ideqf"]};
	cChild = new []{staffagrteaching.Columns["ideqf"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_eqf_alias1_ideqf",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{learningagrtrainer.Columns["idbandomi"], learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idlearningagrtrainer"], learningagrtrainer.Columns["idnation"]};
	cChild = new []{cefrlanglevel_alias3.Columns["idiscrizionebmi"], cefrlanglevel_alias3.Columns["idlearningagrtrainer"], cefrlanglevel_alias3.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_alias3_learningagrtrainer_idiscrizionebmi-idlearningagrtrainer-idnation",cPar,cChild,false));

	cPar = new []{learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idlearningagrtrainer"], learningagrtrainer.Columns["idreg"]};
	cChild = new []{convalida_alias2.Columns["idiscrizionebmi"], convalida_alias2.Columns["idlearningagrtrainer"], convalida_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalida_alias2_learningagrtrainer_idiscrizionebmi-idlearningagrtrainer-idreg",cPar,cChild,false));

	cPar = new []{convalida_alias2.Columns["idconvalida"], convalida_alias2.Columns["idiscrizionebmi"], convalida_alias2.Columns["idlearningagrtrainer"], convalida_alias2.Columns["idreg"]};
	cChild = new []{convalidato_alias1.Columns["idconvalida"], convalidato_alias1.Columns["idiscrizionebmi"], convalidato_alias1.Columns["idlearningagrtrainer"], convalidato_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_alias1_convalida_alias2_idconvalida-idiscrizionebmi-idlearningagrtrainer-idreg",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{learningagrtrainer.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_registry_alias1_idreg_aziende",cPar,cChild,false));

	cPar = new []{learningagrtrainervalut.Columns["idlearningagrtrainervalut"]};
	cChild = new []{learningagrtrainer.Columns["idlearningagrtrainervalut"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_learningagrtrainervalut_idlearningagrtrainervalut",cPar,cChild,false));

	cPar = new []{learningagrtrainerkind.Columns["idlearningagrtrainerkind"]};
	cChild = new []{learningagrtrainer.Columns["idlearningagrtrainerkind"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_learningagrtrainerkind_idlearningagrtrainerkind",cPar,cChild,false));

	cPar = new []{learningagrkind_alias1.Columns["idlearningagrkind"]};
	cChild = new []{learningagrtrainer.Columns["idlearningagrkind"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_learningagrkind_alias1_idlearningagrkind",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{learningagrtrainer.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_geo_city_idcity",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{learningagrstud.Columns["idbandomi"], learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_learningagrstud_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idlearningagrstud"]};
	cChild = new []{cefrlanglevel_alias2.Columns["idiscrizionebmi"], cefrlanglevel_alias2.Columns["idlearningagrstud"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_alias2_learningagrstud_idiscrizionebmi-idlearningagrstud",cPar,cChild,false));

	cPar = new []{learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idlearningagrstud"], learningagrstud.Columns["idreg"]};
	cChild = new []{convalida.Columns["idiscrizionebmi"], convalida.Columns["idlearningagrstud"], convalida.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalida_learningagrstud_idiscrizionebmi-idlearningagrstud-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idiscrizionebmi"], convalida.Columns["idlearningagrstud"], convalida.Columns["idreg"]};
	cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idiscrizionebmi"], convalidato.Columns["idlearningagrstud"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idiscrizionebmi-idlearningagrstud-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idiscrizionebmi"], convalida.Columns["idlearningagrstud"], convalida.Columns["idreg"]};
	cChild = new []{convalidante.Columns["idconvalida"], convalidante.Columns["idiscrizionebmi"], convalidante.Columns["idlearningagrstud"], convalidante.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidante_convalida_idconvalida-idiscrizionebmi-idlearningagrstud-idreg",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{learningagrstud.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_learningagrstud_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{learningagrstud.Columns["idreg_istitutiesteri"]};
	Relations.Add(new DataRelation("FK_learningagrstud_registry_idreg_istitutiesteri",cPar,cChild,false));

	cPar = new []{mobilityperiodtype.Columns["idmobilityperiodtype"]};
	cChild = new []{learningagrstud.Columns["idmobilityperiodtype"]};
	Relations.Add(new DataRelation("FK_learningagrstud_mobilityperiodtype_idmobilityperiodtype",cPar,cChild,false));

	cPar = new []{learningagrkind.Columns["idlearningagrkind"]};
	cChild = new []{learningagrstud.Columns["idlearningagrkind"]};
	Relations.Add(new DataRelation("FK_learningagrstud_learningagrkind_idlearningagrkind",cPar,cChild,false));

	cPar = new []{eqf.Columns["ideqf"]};
	cChild = new []{learningagrstud.Columns["ideqf"]};
	Relations.Add(new DataRelation("FK_learningagrstud_eqf_ideqf",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{iscrizionebmirequisito.Columns["idbandomi"], iscrizionebmirequisito.Columns["idiscrizionebmi"], iscrizionebmirequisito.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionebmirequisito_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{iscrizionebmiattach.Columns["idbandomi"], iscrizionebmiattach.Columns["idiscrizionebmi"], iscrizionebmiattach.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionebmiattach_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{iscrizionebmiattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_iscrizionebmiattach_attach_idattach",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idiscrizionebmi"]};
	cChild = new []{cefrlanglevel.Columns["idiscrizionebmi"]};
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

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{iscrizionebmi.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_iscrizionebmi_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{iscrizionebmi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionebmi_registrystudentiview_idreg",cPar,cChild,false));

	#endregion

}
}
}
