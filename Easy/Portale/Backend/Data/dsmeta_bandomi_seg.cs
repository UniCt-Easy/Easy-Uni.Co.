
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
[System.Xml.Serialization.XmlRoot("dsmeta_bandomi_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_bandomi_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel_alias2 		=> (MetaTable)Tables["cefrlanglevel_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel_alias1 		=> (MetaTable)Tables["cefrlanglevel_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato_alias1 		=> (MetaTable)Tables["convalidato_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida_alias2 		=> (MetaTable)Tables["convalida_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainer 		=> (MetaTable)Tables["learningagrtrainer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable staffagrteaching 		=> (MetaTable)Tables["staffagrteaching"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel 		=> (MetaTable)Tables["cefrlanglevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrstud 		=> (MetaTable)Tables["learningagrstud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmirequisito 		=> (MetaTable)Tables["iscrizionebmirequisito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmiattach 		=> (MetaTable)Tables["iscrizionebmiattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmi 		=> (MetaTable)Tables["iscrizionebmi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable requisito 		=> (MetaTable)Tables["requisito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomirequisito 		=> (MetaTable)Tables["bandomirequisito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomiallegati 		=> (MetaTable)Tables["bandomiallegati"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_istitutiesteri 		=> (MetaTable)Tables["registry_istitutiesteri"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomiistitutiesteri 		=> (MetaTable)Tables["bandomiistitutiesteri"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomistruttureto 		=> (MetaTable)Tables["bandomistruttureto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomistrutturefrom 		=> (MetaTable)Tables["bandomistrutturefrom"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomiinsegn 		=> (MetaTable)Tables["bandomiinsegn"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegn 		=> (MetaTable)Tables["insegn"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomipropedeut 		=> (MetaTable)Tables["bandomipropedeut"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomididprogfrom 		=> (MetaTable)Tables["bandomididprogfrom"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomididprogto 		=> (MetaTable)Tables["bandomididprogto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable programmami 		=> (MetaTable)Tables["programmami"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoria 		=> (MetaTable)Tables["graduatoria"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable duratakinddefaultview 		=> (MetaTable)Tables["duratakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomobilitaintkinddefaultview 		=> (MetaTable)Tables["bandomobilitaintkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assicurazionedefaultview 		=> (MetaTable)Tables["assicurazionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomisegview 		=> (MetaTable)Tables["accordoscambiomisegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomi 		=> (MetaTable)Tables["bandomi"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_bandomi_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_bandomi_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_bandomi_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_bandomi_seg.xsd";

	#region create DataTables
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

	//////////////////// CEFRLANGLEVEL_ALIAS1 /////////////////////////////////
	var tcefrlanglevel_alias1= new MetaTable("cefrlanglevel_alias1");
	tcefrlanglevel_alias1.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel_alias1.defineColumn("cu", typeof(string),false);
	tcefrlanglevel_alias1.defineColumn("idaccordoscambiomi", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idaccordoscambiomidett", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idaccordoscambiomidettlangkind", typeof(int),false);
	tcefrlanglevel_alias1.defineColumn("idcefr_compasc", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idcefr_complett", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idcefr_scritto", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlanglevel_alias1.defineColumn("idiscrizionebmi", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idlearningagrstud", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idlearningagrtrainer", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idnation", typeof(int));
	tcefrlanglevel_alias1.defineColumn("lt", typeof(DateTime),false);
	tcefrlanglevel_alias1.defineColumn("lu", typeof(string),false);
	tcefrlanglevel_alias1.ExtendedProperties["TableForReading"]="cefrlanglevel";
	Tables.Add(tcefrlanglevel_alias1);
	tcefrlanglevel_alias1.defineKey("idcefrlanglevel");

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
	Tables.Add(tlearningagrtrainer);
	tlearningagrtrainer.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

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
	Tables.Add(tstaffagrteaching);
	tstaffagrteaching.defineKey("idbandomi", "idiscrizionebmi", "idreg", "idstaffagrteaching");

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
	Tables.Add(tiscrizionebmiattach);
	tiscrizionebmiattach.defineKey("idattach", "idbandomi", "idiscrizionebmi", "idreg");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// ISCRIZIONE /////////////////////////////////
	var tiscrizione= new MetaTable("iscrizione");
	tiscrizione.defineColumn("aa", typeof(string),false);
	tiscrizione.defineColumn("anno", typeof(int));
	tiscrizione.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione.defineColumn("iddidprog", typeof(int),false);
	tiscrizione.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

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
	tiscrizionebmi.defineColumn("!idiscrizione_iscrizione_anno", typeof(int));
	tiscrizionebmi.defineColumn("!idiscrizione_iscrizione_aa", typeof(string));
	tiscrizionebmi.defineColumn("!idiscrizione_iscrizione_iddidprog_title", typeof(string));
	tiscrizionebmi.defineColumn("!idiscrizione_iscrizione_iddidprog_aa", typeof(string));
	tiscrizionebmi.defineColumn("!idiscrizione_iscrizione_iddidprog_idsede", typeof(int));
	tiscrizionebmi.defineColumn("!idreg_registry_title", typeof(string));
	Tables.Add(tiscrizionebmi);
	tiscrizionebmi.defineKey("idbandomi", "idiscrizionebmi", "idreg");

	//////////////////// REQUISITO /////////////////////////////////
	var trequisito= new MetaTable("requisito");
	trequisito.defineColumn("active", typeof(string),false);
	trequisito.defineColumn("ct", typeof(DateTime),false);
	trequisito.defineColumn("cu", typeof(string),false);
	trequisito.defineColumn("idrequisito", typeof(int),false);
	trequisito.defineColumn("lt", typeof(DateTime),false);
	trequisito.defineColumn("lu", typeof(string),false);
	trequisito.defineColumn("sortcode", typeof(int),false);
	trequisito.defineColumn("title", typeof(string),false);
	Tables.Add(trequisito);
	trequisito.defineKey("idrequisito");

	//////////////////// BANDOMIREQUISITO /////////////////////////////////
	var tbandomirequisito= new MetaTable("bandomirequisito");
	tbandomirequisito.defineColumn("ct", typeof(DateTime),false);
	tbandomirequisito.defineColumn("cu", typeof(string),false);
	tbandomirequisito.defineColumn("idbandomi", typeof(int),false);
	tbandomirequisito.defineColumn("idrequisito", typeof(int),false);
	tbandomirequisito.defineColumn("lt", typeof(DateTime),false);
	tbandomirequisito.defineColumn("lu", typeof(string),false);
	tbandomirequisito.defineColumn("!idrequisito_requisito_title", typeof(string));
	tbandomirequisito.defineColumn("!idrequisito_requisito_active", typeof(string));
	tbandomirequisito.defineColumn("!idrequisito_requisito_sortcode", typeof(int));
	Tables.Add(tbandomirequisito);
	tbandomirequisito.defineKey("idbandomi", "idrequisito");

	//////////////////// BANDOMIALLEGATI /////////////////////////////////
	var tbandomiallegati= new MetaTable("bandomiallegati");
	tbandomiallegati.defineColumn("ct", typeof(DateTime),false);
	tbandomiallegati.defineColumn("cu", typeof(string),false);
	tbandomiallegati.defineColumn("idbandomi", typeof(int),false);
	tbandomiallegati.defineColumn("idbandomiallegati", typeof(int),false);
	tbandomiallegati.defineColumn("lt", typeof(DateTime),false);
	tbandomiallegati.defineColumn("lu", typeof(string),false);
	tbandomiallegati.defineColumn("title", typeof(string));
	Tables.Add(tbandomiallegati);
	tbandomiallegati.defineKey("idbandomi", "idbandomiallegati");

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

	//////////////////// BANDOMIISTITUTIESTERI /////////////////////////////////
	var tbandomiistitutiesteri= new MetaTable("bandomiistitutiesteri");
	tbandomiistitutiesteri.defineColumn("ct", typeof(DateTime),false);
	tbandomiistitutiesteri.defineColumn("cu", typeof(string),false);
	tbandomiistitutiesteri.defineColumn("idbandomi", typeof(int),false);
	tbandomiistitutiesteri.defineColumn("idreg_istitutiesteri", typeof(int),false);
	tbandomiistitutiesteri.defineColumn("lt", typeof(DateTime),false);
	tbandomiistitutiesteri.defineColumn("lu", typeof(string),false);
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_registry_title", typeof(string));
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_registry_cf", typeof(string));
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_registry_p_iva", typeof(string));
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_registry_active", typeof(string));
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_geo_city_title", typeof(string));
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_geo_nation_title", typeof(string));
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_registry_istitutiesteri_name", typeof(string));
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_registry_istitutiesteri_city", typeof(string));
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_registry_istitutiesteri_code", typeof(string));
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_registry_istitutiesteri_institutionalcode", typeof(string));
	tbandomiistitutiesteri.defineColumn("!idreg_istitutiesteri_registry_istitutiesteri_referencenumber", typeof(string));
	Tables.Add(tbandomiistitutiesteri);
	tbandomiistitutiesteri.defineKey("idbandomi", "idreg_istitutiesteri");

	//////////////////// BANDOMISTRUTTURETO /////////////////////////////////
	var tbandomistruttureto= new MetaTable("bandomistruttureto");
	tbandomistruttureto.defineColumn("ct", typeof(DateTime),false);
	tbandomistruttureto.defineColumn("cu", typeof(string),false);
	tbandomistruttureto.defineColumn("idbandomi", typeof(int),false);
	tbandomistruttureto.defineColumn("idstruttura", typeof(int),false);
	tbandomistruttureto.defineColumn("lt", typeof(DateTime),false);
	tbandomistruttureto.defineColumn("lu", typeof(string),false);
	Tables.Add(tbandomistruttureto);
	tbandomistruttureto.defineKey("idbandomi", "idstruttura");

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
	tstruttura.defineColumn("idreg_resp", typeof(int));
	tstruttura.defineColumn("idsede", typeof(int),false);
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("idupb", typeof(string),false);
	tstruttura.defineColumn("lt", typeof(DateTime),false);
	tstruttura.defineColumn("lu", typeof(string),false);
	tstruttura.defineColumn("paridstruttura", typeof(int));
	tstruttura.defineColumn("telefono", typeof(string));
	tstruttura.defineColumn("title", typeof(string));
	tstruttura.defineColumn("title_en", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// BANDOMISTRUTTUREFROM /////////////////////////////////
	var tbandomistrutturefrom= new MetaTable("bandomistrutturefrom");
	tbandomistrutturefrom.defineColumn("ct", typeof(DateTime),false);
	tbandomistrutturefrom.defineColumn("cu", typeof(string),false);
	tbandomistrutturefrom.defineColumn("idbandomi", typeof(int),false);
	tbandomistrutturefrom.defineColumn("idstruttura", typeof(int),false);
	tbandomistrutturefrom.defineColumn("lt", typeof(DateTime),false);
	tbandomistrutturefrom.defineColumn("lu", typeof(string),false);
	tbandomistrutturefrom.defineColumn("!idstruttura_struttura_title", typeof(string));
	tbandomistrutturefrom.defineColumn("!idstruttura_strutturakind_title", typeof(string));
	tbandomistrutturefrom.defineColumn("!idstruttura_struttura_codice", typeof(string));
	tbandomistrutturefrom.defineColumn("!idstruttura_registry_title", typeof(string));
	tbandomistrutturefrom.defineColumn("!idstruttura_struttura_strutturakind_title", typeof(string));
	Tables.Add(tbandomistrutturefrom);
	tbandomistrutturefrom.defineKey("idbandomi", "idstruttura");

	//////////////////// BANDOMIINSEGN /////////////////////////////////
	var tbandomiinsegn= new MetaTable("bandomiinsegn");
	tbandomiinsegn.defineColumn("ct", typeof(DateTime),false);
	tbandomiinsegn.defineColumn("cu", typeof(string),false);
	tbandomiinsegn.defineColumn("idbandomi", typeof(int),false);
	tbandomiinsegn.defineColumn("idinsegn", typeof(int),false);
	tbandomiinsegn.defineColumn("lt", typeof(DateTime),false);
	tbandomiinsegn.defineColumn("lu", typeof(string),false);
	Tables.Add(tbandomiinsegn);
	tbandomiinsegn.defineKey("idbandomi", "idinsegn");

	//////////////////// INSEGN /////////////////////////////////
	var tinsegn= new MetaTable("insegn");
	tinsegn.defineColumn("codice", typeof(string));
	tinsegn.defineColumn("ct", typeof(DateTime),false);
	tinsegn.defineColumn("cu", typeof(string),false);
	tinsegn.defineColumn("denominazione", typeof(string));
	tinsegn.defineColumn("denominazione_en", typeof(string));
	tinsegn.defineColumn("idcorsostudio", typeof(int));
	tinsegn.defineColumn("idcorsostudiokind", typeof(int));
	tinsegn.defineColumn("idinsegn", typeof(int),false);
	tinsegn.defineColumn("idstruttura", typeof(int));
	tinsegn.defineColumn("lt", typeof(DateTime),false);
	tinsegn.defineColumn("lu", typeof(string),false);
	Tables.Add(tinsegn);
	tinsegn.defineKey("idinsegn");

	//////////////////// BANDOMIPROPEDEUT /////////////////////////////////
	var tbandomipropedeut= new MetaTable("bandomipropedeut");
	tbandomipropedeut.defineColumn("ct", typeof(DateTime),false);
	tbandomipropedeut.defineColumn("cu", typeof(string),false);
	tbandomipropedeut.defineColumn("idbandomi", typeof(int),false);
	tbandomipropedeut.defineColumn("idinsegn", typeof(int),false);
	tbandomipropedeut.defineColumn("lt", typeof(DateTime),false);
	tbandomipropedeut.defineColumn("lu", typeof(string),false);
	tbandomipropedeut.defineColumn("!idinsegn_insegn_codice", typeof(string));
	tbandomipropedeut.defineColumn("!idinsegn_insegn_denominazione", typeof(string));
	Tables.Add(tbandomipropedeut);
	tbandomipropedeut.defineKey("idbandomi", "idinsegn");

	//////////////////// BANDOMIDIDPROGFROM /////////////////////////////////
	var tbandomididprogfrom= new MetaTable("bandomididprogfrom");
	tbandomididprogfrom.defineColumn("ct", typeof(DateTime),false);
	tbandomididprogfrom.defineColumn("cu", typeof(string),false);
	tbandomididprogfrom.defineColumn("idbandomi", typeof(int),false);
	tbandomididprogfrom.defineColumn("iddidprog", typeof(int),false);
	tbandomididprogfrom.defineColumn("lt", typeof(DateTime),false);
	tbandomididprogfrom.defineColumn("lu", typeof(string),false);
	Tables.Add(tbandomididprogfrom);
	tbandomididprogfrom.defineKey("idbandomi", "iddidprog");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("annosolare", typeof(int));
	tdidprog.defineColumn("attribdebiti", typeof(string));
	tdidprog.defineColumn("ciclo", typeof(int));
	tdidprog.defineColumn("codice", typeof(string));
	tdidprog.defineColumn("codicemiur", typeof(string));
	tdidprog.defineColumn("dataconsmaxiscr", typeof(DateTime));
	tdidprog.defineColumn("freqobbl", typeof(string));
	tdidprog.defineColumn("idareadidattica", typeof(int));
	tdidprog.defineColumn("idconvenzione", typeof(int));
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("iddidprognumchiusokind", typeof(int));
	tdidprog.defineColumn("iddidprogsuddannokind", typeof(int),false);
	tdidprog.defineColumn("iderogazkind", typeof(int));
	tdidprog.defineColumn("idgraduatoria", typeof(int));
	tdidprog.defineColumn("idnation_lang", typeof(int));
	tdidprog.defineColumn("idnation_lang2", typeof(int));
	tdidprog.defineColumn("idnation_langvis", typeof(int));
	tdidprog.defineColumn("idreg_docenti", typeof(int));
	tdidprog.defineColumn("idsede", typeof(int));
	tdidprog.defineColumn("idsessione", typeof(int));
	tdidprog.defineColumn("idtitolokind", typeof(int));
	tdidprog.defineColumn("immatoltreauth", typeof(string));
	tdidprog.defineColumn("modaccesso", typeof(string));
	tdidprog.defineColumn("modaccesso_en", typeof(string));
	tdidprog.defineColumn("obbformativi", typeof(string));
	tdidprog.defineColumn("obbformativi_en", typeof(string));
	tdidprog.defineColumn("preimmatoltreauth", typeof(string));
	tdidprog.defineColumn("progesamamm", typeof(string));
	tdidprog.defineColumn("prospoccupaz", typeof(string));
	tdidprog.defineColumn("provafinaledesc", typeof(string));
	tdidprog.defineColumn("regolamentotax", typeof(string));
	tdidprog.defineColumn("regolamentotaxurl", typeof(string));
	tdidprog.defineColumn("startiscrizioni", typeof(DateTime));
	tdidprog.defineColumn("stopiscrizioni", typeof(DateTime));
	tdidprog.defineColumn("title", typeof(string));
	tdidprog.defineColumn("title_en", typeof(string));
	tdidprog.defineColumn("utenzasost", typeof(int));
	tdidprog.defineColumn("website", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// BANDOMIDIDPROGTO /////////////////////////////////
	var tbandomididprogto= new MetaTable("bandomididprogto");
	tbandomididprogto.defineColumn("ct", typeof(DateTime),false);
	tbandomididprogto.defineColumn("cu", typeof(string),false);
	tbandomididprogto.defineColumn("idbandomi", typeof(int),false);
	tbandomididprogto.defineColumn("iddidprog", typeof(int),false);
	tbandomididprogto.defineColumn("lt", typeof(DateTime),false);
	tbandomididprogto.defineColumn("lu", typeof(string),false);
	tbandomididprogto.defineColumn("!iddidprog_didprog_title", typeof(string));
	tbandomididprogto.defineColumn("!iddidprog_annoaccademico_alias1_aa", typeof(string));
	tbandomididprogto.defineColumn("!iddidprog_sede_title", typeof(string));
	Tables.Add(tbandomididprogto);
	tbandomididprogto.defineKey("idbandomi", "iddidprog");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string),false);
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// RESIDENCE /////////////////////////////////
	var tresidence= new MetaTable("residence");
	tresidence.defineColumn("description", typeof(string),false);
	tresidence.defineColumn("idresidence", typeof(int),false);
	Tables.Add(tresidence);
	tresidence.defineKey("idresidence");

	//////////////////// PROGRAMMAMI /////////////////////////////////
	var tprogrammami= new MetaTable("programmami");
	tprogrammami.defineColumn("acronimo", typeof(string));
	tprogrammami.defineColumn("idprogrammami", typeof(int),false);
	Tables.Add(tprogrammami);
	tprogrammami.defineKey("idprogrammami");

	//////////////////// GRADUATORIA /////////////////////////////////
	var tgraduatoria= new MetaTable("graduatoria");
	tgraduatoria.defineColumn("idgraduatoria", typeof(int),false);
	tgraduatoria.defineColumn("title", typeof(string));
	Tables.Add(tgraduatoria);
	tgraduatoria.defineKey("idgraduatoria");

	//////////////////// DURATAKINDDEFAULTVIEW /////////////////////////////////
	var tduratakinddefaultview= new MetaTable("duratakinddefaultview");
	tduratakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tduratakinddefaultview.defineColumn("idduratakind", typeof(int),false);
	Tables.Add(tduratakinddefaultview);
	tduratakinddefaultview.defineKey("idduratakind");

	//////////////////// BANDOMOBILITAINTKINDDEFAULTVIEW /////////////////////////////////
	var tbandomobilitaintkinddefaultview= new MetaTable("bandomobilitaintkinddefaultview");
	tbandomobilitaintkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tbandomobilitaintkinddefaultview.defineColumn("idbandomobilitaintkind", typeof(int),false);
	Tables.Add(tbandomobilitaintkinddefaultview);
	tbandomobilitaintkinddefaultview.defineKey("idbandomobilitaintkind");

	//////////////////// ASSICURAZIONEDEFAULTVIEW /////////////////////////////////
	var tassicurazionedefaultview= new MetaTable("assicurazionedefaultview");
	tassicurazionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tassicurazionedefaultview.defineColumn("idassicurazione", typeof(int),false);
	tassicurazionedefaultview.defineColumn("idattach", typeof(int));
	Tables.Add(tassicurazionedefaultview);
	tassicurazionedefaultview.defineKey("idassicurazione");

	//////////////////// ACCORDOSCAMBIOMISEGVIEW /////////////////////////////////
	var taccordoscambiomisegview= new MetaTable("accordoscambiomisegview");
	taccordoscambiomisegview.defineColumn("aa_start", typeof(string),false);
	taccordoscambiomisegview.defineColumn("aa_stop", typeof(string));
	taccordoscambiomisegview.defineColumn("dropdown_title", typeof(string),false);
	taccordoscambiomisegview.defineColumn("idaccordoscambiomi", typeof(int),false);
	taccordoscambiomisegview.defineColumn("idprogrammami", typeof(int));
	Tables.Add(taccordoscambiomisegview);
	taccordoscambiomisegview.defineKey("idaccordoscambiomi");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// BANDOMI /////////////////////////////////
	var tbandomi= new MetaTable("bandomi");
	tbandomi.defineColumn("aa", typeof(string),false);
	tbandomi.defineColumn("cfminimi", typeof(decimal));
	tbandomi.defineColumn("codice", typeof(string),false);
	tbandomi.defineColumn("ct", typeof(DateTime),false);
	tbandomi.defineColumn("cu", typeof(string),false);
	tbandomi.defineColumn("datariferimentorequisiti", typeof(DateTime));
	tbandomi.defineColumn("durata", typeof(int));
	tbandomi.defineColumn("idaccordoscambiomi", typeof(int),false);
	tbandomi.defineColumn("idassicurazione", typeof(int));
	tbandomi.defineColumn("idbandomi", typeof(int),false);
	tbandomi.defineColumn("idbandomobilitaintkind", typeof(int),false);
	tbandomi.defineColumn("idduratakind", typeof(int));
	tbandomi.defineColumn("idgraduatoria", typeof(int));
	tbandomi.defineColumn("idprogrammami", typeof(int),false);
	tbandomi.defineColumn("idresidence", typeof(int));
	tbandomi.defineColumn("idstruttura", typeof(int),false);
	tbandomi.defineColumn("iscrittonellanno", typeof(string));
	tbandomi.defineColumn("lt", typeof(DateTime),false);
	tbandomi.defineColumn("lu", typeof(string),false);
	tbandomi.defineColumn("maxpreferenze", typeof(int));
	tbandomi.defineColumn("mediaminima", typeof(decimal));
	tbandomi.defineColumn("nessundebito", typeof(string));
	tbandomi.defineColumn("numeroesamiminimo", typeof(int));
	tbandomi.defineColumn("startcandidature", typeof(DateTime),false);
	tbandomi.defineColumn("startgraduatoria", typeof(DateTime),false);
	tbandomi.defineColumn("startpermanenza", typeof(DateTime));
	tbandomi.defineColumn("startpresentazione", typeof(DateTime),false);
	tbandomi.defineColumn("stopcadidature", typeof(DateTime),false);
	tbandomi.defineColumn("stopgraduatoria", typeof(DateTime),false);
	tbandomi.defineColumn("stoppermanenza", typeof(DateTime));
	tbandomi.defineColumn("stoppresentazione", typeof(DateTime),false);
	tbandomi.defineColumn("testodomanda", typeof(string));
	tbandomi.defineColumn("title", typeof(string),false);
	tbandomi.defineColumn("titolodomanda", typeof(string));
	Tables.Add(tbandomi);
	tbandomi.defineKey("idbandomi");

	#endregion


	#region DataRelation creation
	var cPar = new []{bandomi.Columns["idbandomi"]};
	var cChild = new []{iscrizionebmi.Columns["idbandomi"]};
	Relations.Add(new DataRelation("FK_iscrizionebmi_bandomi_idbandomi",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idiscrizionebmi"]};
	cChild = new []{cefrlanglevel_alias2.Columns["idiscrizionebmi"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_alias2_iscrizionebmi_idiscrizionebmi",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{learningagrtrainer.Columns["idbandomi"], learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idlearningagrtrainer"], learningagrtrainer.Columns["idnation"]};
	cChild = new []{cefrlanglevel_alias1.Columns["idiscrizionebmi"], cefrlanglevel_alias1.Columns["idlearningagrtrainer"], cefrlanglevel_alias1.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_alias1_learningagrtrainer_idiscrizionebmi-idlearningagrtrainer-idnation",cPar,cChild,false));

	cPar = new []{learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idlearningagrtrainer"], learningagrtrainer.Columns["idreg"]};
	cChild = new []{convalida_alias2.Columns["idiscrizionebmi"], convalida_alias2.Columns["idlearningagrtrainer"], convalida_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalida_alias2_learningagrtrainer_idiscrizionebmi-idlearningagrtrainer-idreg",cPar,cChild,false));

	cPar = new []{convalida_alias2.Columns["idconvalida"], convalida_alias2.Columns["idreg"]};
	cChild = new []{convalidato_alias1.Columns["idconvalida"], convalidato_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_alias1_convalida_alias2_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{staffagrteaching.Columns["idbandomi"], staffagrteaching.Columns["idiscrizionebmi"], staffagrteaching.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{learningagrstud.Columns["idbandomi"], learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_learningagrstud_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idlearningagrstud"]};
	cChild = new []{cefrlanglevel.Columns["idiscrizionebmi"], cefrlanglevel.Columns["idlearningagrstud"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_learningagrstud_idiscrizionebmi-idlearningagrstud",cPar,cChild,false));

	cPar = new []{learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idlearningagrstud"], learningagrstud.Columns["idreg"]};
	cChild = new []{convalida.Columns["idiscrizionebmi"], convalida.Columns["idlearningagrstud"], convalida.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalida_learningagrstud_idiscrizionebmi-idlearningagrstud-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{iscrizionebmirequisito.Columns["idbandomi"], iscrizionebmirequisito.Columns["idiscrizionebmi"], iscrizionebmirequisito.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionebmirequisito_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idbandomi"], iscrizionebmi.Columns["idiscrizionebmi"], iscrizionebmi.Columns["idreg"]};
	cChild = new []{iscrizionebmiattach.Columns["idbandomi"], iscrizionebmiattach.Columns["idiscrizionebmi"], iscrizionebmiattach.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionebmiattach_iscrizionebmi_idbandomi-idiscrizionebmi-idreg",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{iscrizionebmi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionebmi_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"]};
	cChild = new []{iscrizionebmi.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_iscrizionebmi_iscrizione_idiscrizione",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{bandomi.Columns["idbandomi"]};
	cChild = new []{bandomirequisito.Columns["idbandomi"]};
	Relations.Add(new DataRelation("FK_bandomirequisito_bandomi_idbandomi",cPar,cChild,false));

	cPar = new []{requisito.Columns["idrequisito"]};
	cChild = new []{bandomirequisito.Columns["idrequisito"]};
	Relations.Add(new DataRelation("FK_bandomirequisito_requisito_idrequisito",cPar,cChild,false));

	cPar = new []{bandomi.Columns["idbandomi"]};
	cChild = new []{bandomiallegati.Columns["idbandomi"]};
	Relations.Add(new DataRelation("FK_bandomiallegati_bandomi_idbandomi",cPar,cChild,false));

	cPar = new []{bandomi.Columns["idbandomi"]};
	cChild = new []{bandomiistitutiesteri.Columns["idbandomi"]};
	Relations.Add(new DataRelation("FK_bandomiistitutiesteri_bandomi_idbandomi",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{bandomiistitutiesteri.Columns["idreg_istitutiesteri"]};
	Relations.Add(new DataRelation("FK_bandomiistitutiesteri_registry_idreg_istitutiesteri",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_istitutiesteri.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_istitutiesteri_registry_idreg",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{bandomi.Columns["idbandomi"]};
	cChild = new []{bandomistruttureto.Columns["idbandomi"]};
	Relations.Add(new DataRelation("FK_bandomistruttureto_bandomi_idbandomi",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{bandomistruttureto.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_bandomistruttureto_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{bandomi.Columns["idbandomi"]};
	cChild = new []{bandomistrutturefrom.Columns["idbandomi"]};
	Relations.Add(new DataRelation("FK_bandomistrutturefrom_bandomi_idbandomi",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{bandomistrutturefrom.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_bandomistrutturefrom_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{struttura.Columns["idreg_resp"]};
	Relations.Add(new DataRelation("FK_struttura_registry_idreg_resp",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{bandomi.Columns["idbandomi"]};
	cChild = new []{bandomiinsegn.Columns["idbandomi"]};
	Relations.Add(new DataRelation("FK_bandomiinsegn_bandomi_idbandomi",cPar,cChild,false));

	cPar = new []{insegn.Columns["idinsegn"]};
	cChild = new []{bandomiinsegn.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_bandomiinsegn_insegn_idinsegn",cPar,cChild,false));

	cPar = new []{bandomi.Columns["idbandomi"]};
	cChild = new []{bandomipropedeut.Columns["idbandomi"]};
	Relations.Add(new DataRelation("FK_bandomipropedeut_bandomi_idbandomi",cPar,cChild,false));

	cPar = new []{insegn.Columns["idinsegn"]};
	cChild = new []{bandomipropedeut.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_bandomipropedeut_insegn_idinsegn",cPar,cChild,false));

	cPar = new []{bandomi.Columns["idbandomi"]};
	cChild = new []{bandomididprogfrom.Columns["idbandomi"]};
	Relations.Add(new DataRelation("FK_bandomididprogfrom_bandomi_idbandomi",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{bandomididprogfrom.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_bandomididprogfrom_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{bandomi.Columns["idbandomi"]};
	cChild = new []{bandomididprogto.Columns["idbandomi"]};
	Relations.Add(new DataRelation("FK_bandomididprogto_bandomi_idbandomi",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{bandomididprogto.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_bandomididprogto_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{didprog.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_sede_idsede",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{didprog.Columns["aa"]};
	Relations.Add(new DataRelation("FK_didprog_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{bandomi.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_bandomi_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{bandomi.Columns["idresidence"]};
	Relations.Add(new DataRelation("FK_bandomi_residence_idresidence",cPar,cChild,false));

	cPar = new []{programmami.Columns["idprogrammami"]};
	cChild = new []{bandomi.Columns["idprogrammami"]};
	Relations.Add(new DataRelation("FK_bandomi_programmami_idprogrammami",cPar,cChild,false));

	cPar = new []{graduatoria.Columns["idgraduatoria"]};
	cChild = new []{bandomi.Columns["idgraduatoria"]};
	Relations.Add(new DataRelation("FK_bandomi_graduatoria_idgraduatoria",cPar,cChild,false));

	cPar = new []{duratakinddefaultview.Columns["idduratakind"]};
	cChild = new []{bandomi.Columns["idduratakind"]};
	Relations.Add(new DataRelation("FK_bandomi_duratakinddefaultview_idduratakind",cPar,cChild,false));

	cPar = new []{bandomobilitaintkinddefaultview.Columns["idbandomobilitaintkind"]};
	cChild = new []{bandomi.Columns["idbandomobilitaintkind"]};
	Relations.Add(new DataRelation("FK_bandomi_bandomobilitaintkinddefaultview_idbandomobilitaintkind",cPar,cChild,false));

	cPar = new []{assicurazionedefaultview.Columns["idassicurazione"]};
	cChild = new []{bandomi.Columns["idassicurazione"]};
	Relations.Add(new DataRelation("FK_bandomi_assicurazionedefaultview_idassicurazione",cPar,cChild,false));

	cPar = new []{accordoscambiomisegview.Columns["idaccordoscambiomi"]};
	cChild = new []{bandomi.Columns["idaccordoscambiomi"]};
	Relations.Add(new DataRelation("FK_bandomi_accordoscambiomisegview_idaccordoscambiomi",cPar,cChild,false));

	cPar = new []{programmami.Columns["idprogrammami"]};
	cChild = new []{accordoscambiomisegview.Columns["idprogrammami"]};
	Relations.Add(new DataRelation("FK_accordoscambiomisegview_programmami_idprogrammami",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{bandomi.Columns["aa"]};
	Relations.Add(new DataRelation("FK_bandomi_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
