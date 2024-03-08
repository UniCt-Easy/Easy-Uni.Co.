
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
[System.Xml.Serialization.XmlRoot("dsmeta_learningagrtrainer_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_learningagrtrainer_seg: DataSet {

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
	public MetaTable pratica_alias2 		=> (MetaTable)Tables["pratica_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaziendeview 		=> (MetaTable)Tables["registryaziendeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainervalut 		=> (MetaTable)Tables["learningagrtrainervalut"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainerkind 		=> (MetaTable)Tables["learningagrtrainerkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrkind 		=> (MetaTable)Tables["learningagrkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainer 		=> (MetaTable)Tables["learningagrtrainer"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_learningagrtrainer_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_learningagrtrainer_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_learningagrtrainer_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_learningagrtrainer_seg.xsd";

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

	//////////////////// PRATICA_ALIAS2 /////////////////////////////////
	var tpratica_alias2= new MetaTable("pratica_alias2");
	tpratica_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tpratica_alias2.defineColumn("iddidprog", typeof(int),false);
	tpratica_alias2.defineColumn("idiscrizione", typeof(int),false);
	tpratica_alias2.defineColumn("idistanza", typeof(int),false);
	tpratica_alias2.defineColumn("idistanzakind", typeof(int),false);
	tpratica_alias2.defineColumn("idpratica", typeof(int),false);
	tpratica_alias2.defineColumn("idreg", typeof(int),false);
	tpratica_alias2.ExtendedProperties["TableForReading"]="pratica";
	Tables.Add(tpratica_alias2);
	tpratica_alias2.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

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

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idsede", typeof(int));
	tdidprog.defineColumn("title", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

	//////////////////// ATTIVFORM /////////////////////////////////
	var tattivform= new MetaTable("attivform");
	tattivform.defineColumn("aa", typeof(string),false);
	tattivform.defineColumn("idattivform", typeof(int),false);
	tattivform.defineColumn("idcorsostudio", typeof(int),false);
	tattivform.defineColumn("iddidprog", typeof(int),false);
	tattivform.defineColumn("iddidproganno", typeof(int),false);
	tattivform.defineColumn("iddidprogcurr", typeof(int),false);
	tattivform.defineColumn("iddidprogori", typeof(int),false);
	tattivform.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivform.defineColumn("idsede", typeof(int),false);
	tattivform.defineColumn("title", typeof(string));
	Tables.Add(tattivform);
	tattivform.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

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
	tconvalidato.defineColumn("!idattivform_attivform_title", typeof(string));
	tconvalidato.defineColumn("!iddidprog_didprog_title", typeof(string));
	tconvalidato.defineColumn("!iddidprog_didprog_aa", typeof(string));
	tconvalidato.defineColumn("!iddidprog_didprog_idsede_title", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_iscrizione_anno", typeof(int));
	tconvalidato.defineColumn("!idiscrizione_iscrizione_aa", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_iscrizione_iddidprog_title", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_iscrizione_iddidprog_aa", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_iscrizione_iddidprog_idsede", typeof(int));
	tconvalidato.defineColumn("!idpratica_pratica_idreg_title", typeof(string));
	tconvalidato.defineColumn("!idpratica_pratica_iddidprog_title", typeof(string));
	tconvalidato.defineColumn("!idpratica_pratica_iddidprog_aa", typeof(string));
	tconvalidato.defineColumn("!idpratica_pratica_iddidprog_idsede", typeof(int));
	Tables.Add(tconvalidato);
	tconvalidato.defineKey("idconvalida", "idconvalidato", "idreg");

	//////////////////// PRATICA /////////////////////////////////
	var tpratica= new MetaTable("pratica");
	tpratica.defineColumn("idcorsostudio", typeof(int),false);
	tpratica.defineColumn("iddidprog", typeof(int),false);
	tpratica.defineColumn("idiscrizione", typeof(int),false);
	tpratica.defineColumn("idistanza", typeof(int),false);
	tpratica.defineColumn("idistanzakind", typeof(int),false);
	tpratica.defineColumn("idpratica", typeof(int),false);
	tpratica.defineColumn("idreg", typeof(int),false);
	Tables.Add(tpratica);
	tpratica.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizionedefaultview);
	tiscrizionedefaultview.defineKey("idiscrizione");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("aa", typeof(string));
	tdidprogdefaultview.defineColumn("dropdown_title", typeof(string),false);
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
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("iddidprog");

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

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

	//////////////////// REGISTRYAZIENDEVIEW /////////////////////////////////
	var tregistryaziendeview= new MetaTable("registryaziendeview");
	tregistryaziendeview.defineColumn("dropdown_title", typeof(string),false);
	tregistryaziendeview.defineColumn("idateco", typeof(int));
	tregistryaziendeview.defineColumn("idcategory", typeof(string));
	tregistryaziendeview.defineColumn("idcity", typeof(int));
	tregistryaziendeview.defineColumn("idnace", typeof(string));
	tregistryaziendeview.defineColumn("idnation", typeof(int));
	tregistryaziendeview.defineColumn("idnaturagiur", typeof(int));
	tregistryaziendeview.defineColumn("idnumerodip", typeof(int));
	tregistryaziendeview.defineColumn("idreg", typeof(int),false);
	tregistryaziendeview.defineColumn("idregistryclass", typeof(string));
	tregistryaziendeview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistryaziendeview);
	tregistryaziendeview.defineKey("idreg");

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

	//////////////////// LEARNINGAGRKIND /////////////////////////////////
	var tlearningagrkind= new MetaTable("learningagrkind");
	tlearningagrkind.defineColumn("description", typeof(string));
	tlearningagrkind.defineColumn("idlearningagrkind", typeof(int),false);
	tlearningagrkind.defineColumn("title", typeof(string));
	Tables.Add(tlearningagrkind);
	tlearningagrkind.defineKey("idlearningagrkind");

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
	Tables.Add(tlearningagrtrainer);
	tlearningagrtrainer.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idlearningagrtrainer"], learningagrtrainer.Columns["idnation"]};
	var cChild = new []{cefrlanglevel.Columns["idiscrizionebmi"], cefrlanglevel.Columns["idlearningagrtrainer"], cefrlanglevel.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_learningagrtrainer_idiscrizionebmi-idlearningagrtrainer-idnation",cPar,cChild,false));

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

	cPar = new []{learningagrtrainer.Columns["idiscrizionebmi"], learningagrtrainer.Columns["idlearningagrtrainer"], learningagrtrainer.Columns["idreg"]};
	cChild = new []{convalida.Columns["idiscrizionebmi"], convalida.Columns["idlearningagrtrainer"], convalida.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalida_learningagrtrainer_idiscrizionebmi-idlearningagrtrainer-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{pratica_alias2.Columns["idpratica"]};
	cChild = new []{convalidato.Columns["idpratica"]};
	Relations.Add(new DataRelation("FK_convalidato_pratica_alias2_idpratica",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{pratica_alias2.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_pratica_alias2_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{pratica_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pratica_alias2_registry_idreg",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"]};
	cChild = new []{convalidato.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_convalidato_iscrizione_idiscrizione",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{convalidato.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_convalidato_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{didprog.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_sede_idsede",cPar,cChild,false));

	cPar = new []{attivform.Columns["idattivform"]};
	cChild = new []{convalidato.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_convalidato_attivform_idattivform",cPar,cChild,false));

	cPar = new []{pratica.Columns["idpratica"]};
	cChild = new []{convalida.Columns["idpratica"]};
	Relations.Add(new DataRelation("FK_convalida_pratica_idpratica",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{convalida.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_convalida_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{convalida.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_convalida_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{dichiar.Columns["iddichiar"]};
	cChild = new []{convalida.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_convalida_dichiar_iddichiar",cPar,cChild,false));

	cPar = new []{registryaziendeview.Columns["idreg"]};
	cChild = new []{learningagrtrainer.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_registryaziendeview_idreg_aziende",cPar,cChild,false));

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

	#endregion

}
}
}
