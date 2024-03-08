
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
using meta_registry;
using meta_geo_nation;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_learningagrtrainer_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_learningagrtrainer_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica_alias2 		=> (MetaTable)Tables["pratica_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainer_alias3 		=> (MetaTable)Tables["learningagrtrainer_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrstud_alias2 		=> (MetaTable)Tables["learningagrstud_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias2 		=> (MetaTable)Tables["istanza_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzakind 		=> (MetaTable)Tables["istanzakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmi_alias2 		=> (MetaTable)Tables["iscrizionebmi_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar_alias2 		=> (MetaTable)Tables["dichiar_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarkind 		=> (MetaTable)Tables["dichiarkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changeskind 		=> (MetaTable)Tables["changeskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changes 		=> (MetaTable)Tables["changes"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainer_alias1 		=> (MetaTable)Tables["learningagrtrainer_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrstud 		=> (MetaTable)Tables["learningagrstud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmi 		=> (MetaTable)Tables["iscrizionebmi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview_alias1 		=> (MetaTable)Tables["iscrizionedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidakind 		=> (MetaTable)Tables["convalidakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaziendeview 		=> (MetaTable)Tables["registryaziendeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public geo_nationTable geo_nation 		=> (geo_nationTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainervalut 		=> (MetaTable)Tables["learningagrtrainervalut"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainerkind 		=> (MetaTable)Tables["learningagrtrainerkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrkind 		=> (MetaTable)Tables["learningagrkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_citydefaultview 		=> (MetaTable)Tables["geo_citydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlangleveldefaultview 		=> (MetaTable)Tables["cefrlangleveldefaultview"];

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

	//////////////////// LEARNINGAGRTRAINER_ALIAS3 /////////////////////////////////
	var tlearningagrtrainer_alias3= new MetaTable("learningagrtrainer_alias3");
	tlearningagrtrainer_alias3.defineColumn("idbandomi", typeof(int),false);
	tlearningagrtrainer_alias3.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrtrainer_alias3.defineColumn("idlearningagrtrainer", typeof(int),false);
	tlearningagrtrainer_alias3.defineColumn("idreg", typeof(int),false);
	tlearningagrtrainer_alias3.defineColumn("title", typeof(string),false);
	tlearningagrtrainer_alias3.ExtendedProperties["TableForReading"]="learningagrtrainer";
	Tables.Add(tlearningagrtrainer_alias3);
	tlearningagrtrainer_alias3.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

	//////////////////// LEARNINGAGRSTUD_ALIAS2 /////////////////////////////////
	var tlearningagrstud_alias2= new MetaTable("learningagrstud_alias2");
	tlearningagrstud_alias2.defineColumn("idbandomi", typeof(int),false);
	tlearningagrstud_alias2.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrstud_alias2.defineColumn("idlearningagrstud", typeof(int),false);
	tlearningagrstud_alias2.defineColumn("idreg", typeof(int),false);
	tlearningagrstud_alias2.ExtendedProperties["TableForReading"]="learningagrstud";
	Tables.Add(tlearningagrstud_alias2);
	tlearningagrstud_alias2.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrstud", "idreg");

	//////////////////// ISTANZA_ALIAS2 /////////////////////////////////
	var tistanza_alias2= new MetaTable("istanza_alias2");
	tistanza_alias2.defineColumn("aa", typeof(string),false);
	tistanza_alias2.defineColumn("data", typeof(DateTime),false);
	tistanza_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_alias2.defineColumn("iddidprog", typeof(int),false);
	tistanza_alias2.defineColumn("idiscrizione", typeof(int));
	tistanza_alias2.defineColumn("idistanza", typeof(int),false);
	tistanza_alias2.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias2.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias2.defineColumn("idstatuskind", typeof(int));
	tistanza_alias2.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias2);
	tistanza_alias2.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// STATUSKIND /////////////////////////////////
	var tstatuskind= new MetaTable("statuskind");
	tstatuskind.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskind);
	tstatuskind.defineKey("idstatuskind");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ISTANZAKIND /////////////////////////////////
	var tistanzakind= new MetaTable("istanzakind");
	tistanzakind.defineColumn("idistanzakind", typeof(int),false);
	tistanzakind.defineColumn("title", typeof(string),false);
	Tables.Add(tistanzakind);
	tistanzakind.defineKey("idistanzakind");

	//////////////////// ISCRIZIONEBMI_ALIAS2 /////////////////////////////////
	var tiscrizionebmi_alias2= new MetaTable("iscrizionebmi_alias2");
	tiscrizionebmi_alias2.defineColumn("idbandomi", typeof(int),false);
	tiscrizionebmi_alias2.defineColumn("idiscrizionebmi", typeof(int),false);
	tiscrizionebmi_alias2.defineColumn("idreg", typeof(int),false);
	tiscrizionebmi_alias2.ExtendedProperties["TableForReading"]="iscrizionebmi";
	Tables.Add(tiscrizionebmi_alias2);
	tiscrizionebmi_alias2.defineKey("idbandomi", "idiscrizionebmi", "idreg");

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

	//////////////////// DICHIAR_ALIAS2 /////////////////////////////////
	var tdichiar_alias2= new MetaTable("dichiar_alias2");
	tdichiar_alias2.defineColumn("aa", typeof(string));
	tdichiar_alias2.defineColumn("date", typeof(DateTime),false);
	tdichiar_alias2.defineColumn("iddichiar", typeof(int),false);
	tdichiar_alias2.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar_alias2.defineColumn("idreg", typeof(int),false);
	tdichiar_alias2.ExtendedProperties["TableForReading"]="dichiar";
	Tables.Add(tdichiar_alias2);
	tdichiar_alias2.defineKey("iddichiar", "idreg");

	//////////////////// DICHIARKIND /////////////////////////////////
	var tdichiarkind= new MetaTable("dichiarkind");
	tdichiarkind.defineColumn("iddichiarkind", typeof(int),false);
	tdichiarkind.defineColumn("title", typeof(string),false);
	Tables.Add(tdichiarkind);
	tdichiarkind.defineKey("iddichiarkind");

	//////////////////// CHANGESKIND /////////////////////////////////
	var tchangeskind= new MetaTable("changeskind");
	tchangeskind.defineColumn("idchangeskind", typeof(int),false);
	tchangeskind.defineColumn("title", typeof(string),false);
	Tables.Add(tchangeskind);
	tchangeskind.defineKey("idchangeskind");

	//////////////////// CHANGES /////////////////////////////////
	var tchanges= new MetaTable("changes");
	tchanges.defineColumn("idchanges", typeof(int),false);
	tchanges.defineColumn("title", typeof(string),false);
	Tables.Add(tchanges);
	tchanges.defineKey("idchanges");

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
	tattivform.defineColumn("title", typeof(string));
	Tables.Add(tattivform);
	tattivform.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

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
	tconvalidato.defineColumn("!idchanges_changes_title", typeof(string));
	tconvalidato.defineColumn("!idchangeskind_changeskind_title", typeof(string));
	tconvalidato.defineColumn("!iddichiar_dichiar_aa", typeof(string));
	tconvalidato.defineColumn("!iddichiar_dichiar_date", typeof(DateTime));
	tconvalidato.defineColumn("!iddichiar_dichiar_iddichiarkind_title", typeof(string));
	tconvalidato.defineColumn("!iddidprog_didprog_title", typeof(string));
	tconvalidato.defineColumn("!iddidprog_didprog_aa", typeof(string));
	tconvalidato.defineColumn("!iddidprog_didprog_idsede_title", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_iscrizione_anno", typeof(int));
	tconvalidato.defineColumn("!idiscrizione_iscrizione_aa", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_iscrizione_iddidprog_title", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_iscrizione_iddidprog_aa", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_iscrizione_iddidprog_idsede", typeof(int));
	tconvalidato.defineColumn("!idiscrizione_from_iscrizione_anno", typeof(int));
	tconvalidato.defineColumn("!idiscrizione_from_iscrizione_aa", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_from_iscrizione_iddidprog_title", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_from_iscrizione_iddidprog_aa", typeof(string));
	tconvalidato.defineColumn("!idiscrizione_from_iscrizione_iddidprog_idsede", typeof(int));
	tconvalidato.defineColumn("!idistanza_istanza_aa", typeof(string));
	tconvalidato.defineColumn("!idistanza_istanza_data", typeof(DateTime));
	tconvalidato.defineColumn("!idistanza_istanza_idistanzakind_title", typeof(string));
	tconvalidato.defineColumn("!idistanza_istanza_idreg_studenti_title", typeof(string));
	tconvalidato.defineColumn("!idistanza_istanza_idstatuskind_title", typeof(string));
	tconvalidato.defineColumn("!idistanza_istanza_iddidprog_title", typeof(string));
	tconvalidato.defineColumn("!idistanza_istanza_iddidprog_aa", typeof(string));
	tconvalidato.defineColumn("!idistanza_istanza_iddidprog_idsede", typeof(int));
	tconvalidato.defineColumn("!idistanza_istanza_idiscrizione_anno", typeof(int));
	tconvalidato.defineColumn("!idistanza_istanza_idiscrizione_iddidprog", typeof(int));
	tconvalidato.defineColumn("!idistanza_istanza_idiscrizione_aa", typeof(string));
	tconvalidato.defineColumn("!idlearningagrtrainer_learningagrtrainer_title", typeof(string));
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

	//////////////////// LEARNINGAGRTRAINER_ALIAS1 /////////////////////////////////
	var tlearningagrtrainer_alias1= new MetaTable("learningagrtrainer_alias1");
	tlearningagrtrainer_alias1.defineColumn("idbandomi", typeof(int),false);
	tlearningagrtrainer_alias1.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrtrainer_alias1.defineColumn("idlearningagrtrainer", typeof(int),false);
	tlearningagrtrainer_alias1.defineColumn("idreg", typeof(int),false);
	tlearningagrtrainer_alias1.defineColumn("title", typeof(string),false);
	tlearningagrtrainer_alias1.ExtendedProperties["TableForReading"]="learningagrtrainer";
	Tables.Add(tlearningagrtrainer_alias1);
	tlearningagrtrainer_alias1.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

	//////////////////// LEARNINGAGRSTUD /////////////////////////////////
	var tlearningagrstud= new MetaTable("learningagrstud");
	tlearningagrstud.defineColumn("idbandomi", typeof(int),false);
	tlearningagrstud.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrstud", typeof(int),false);
	tlearningagrstud.defineColumn("idreg", typeof(int),false);
	Tables.Add(tlearningagrstud);
	tlearningagrstud.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrstud", "idreg");

	//////////////////// ISTANZA /////////////////////////////////
	var tistanza= new MetaTable("istanza");
	tistanza.defineColumn("aa", typeof(string),false);
	tistanza.defineColumn("data", typeof(DateTime),false);
	tistanza.defineColumn("idcorsostudio", typeof(int),false);
	tistanza.defineColumn("iddidprog", typeof(int),false);
	tistanza.defineColumn("idiscrizione", typeof(int));
	tistanza.defineColumn("idistanza", typeof(int),false);
	tistanza.defineColumn("idistanzakind", typeof(int),false);
	tistanza.defineColumn("idreg_studenti", typeof(int),false);
	tistanza.defineColumn("idstatuskind", typeof(int));
	Tables.Add(tistanza);
	tistanza.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISCRIZIONEBMI /////////////////////////////////
	var tiscrizionebmi= new MetaTable("iscrizionebmi");
	tiscrizionebmi.defineColumn("idbandomi", typeof(int),false);
	tiscrizionebmi.defineColumn("idiscrizionebmi", typeof(int),false);
	tiscrizionebmi.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizionebmi);
	tiscrizionebmi.defineKey("idbandomi", "idiscrizionebmi", "idreg");

	//////////////////// ISCRIZIONEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tiscrizionedefaultview_alias1= new MetaTable("iscrizionedefaultview_alias1");
	tiscrizionedefaultview_alias1.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview_alias1.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview_alias1.ExtendedProperties["TableForReading"]="iscrizionedefaultview";
	Tables.Add(tiscrizionedefaultview_alias1);
	tiscrizionedefaultview_alias1.defineKey("idiscrizione");

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
	tdidprogdefaultview.defineColumn("idsede", typeof(int));
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

	//////////////////// CONVALIDAKIND /////////////////////////////////
	var tconvalidakind= new MetaTable("convalidakind");
	tconvalidakind.defineColumn("idconvalidakind", typeof(int),false);
	tconvalidakind.defineColumn("title", typeof(string),false);
	Tables.Add(tconvalidakind);
	tconvalidakind.defineKey("idconvalidakind");

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

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new geo_nationTable();
	tgeo_nation.addBaseColumns("idnation","title");
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

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

	//////////////////// GEO_CITYDEFAULTVIEW /////////////////////////////////
	var tgeo_citydefaultview= new MetaTable("geo_citydefaultview");
	tgeo_citydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgeo_citydefaultview.defineColumn("idcity", typeof(int),false);
	tgeo_citydefaultview.defineColumn("idcountry", typeof(int));
	tgeo_citydefaultview.defineColumn("newcity", typeof(int));
	tgeo_citydefaultview.defineColumn("oldcity", typeof(int));
	Tables.Add(tgeo_citydefaultview);
	tgeo_citydefaultview.defineKey("idcity");

	//////////////////// CEFRLANGLEVELDEFAULTVIEW /////////////////////////////////
	var tcefrlangleveldefaultview= new MetaTable("cefrlangleveldefaultview");
	tcefrlangleveldefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcefrlangleveldefaultview.defineColumn("idcefr_compasc", typeof(int));
	tcefrlangleveldefaultview.defineColumn("idcefr_complett", typeof(int));
	tcefrlangleveldefaultview.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlangleveldefaultview.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlangleveldefaultview.defineColumn("idcefr_scritto", typeof(int));
	tcefrlangleveldefaultview.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlangleveldefaultview.defineColumn("idnation", typeof(int));
	Tables.Add(tcefrlangleveldefaultview);
	tcefrlangleveldefaultview.defineKey("idcefrlanglevel");

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
	tlearningagrtrainer.defineColumn("idcefrlanglevel", typeof(int));
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
	this.defineRelation("FK_convalida_learningagrtrainer_idiscrizionebmi-idlearningagrtrainer-idreg-","learningagrtrainer","convalida","idiscrizionebmi","idlearningagrtrainer","idreg");
	this.defineRelation("FK_convalidato_convalida_idconvalida-idreg","convalida","convalidato","idconvalida","idreg");
	this.defineRelation("FK_convalidato_pratica_alias2_idpratica","pratica_alias2","convalidato","idpratica");
	this.defineRelation("FK_pratica_alias2_didprog_iddidprog","didprog","pratica_alias2","iddidprog");
	this.defineRelation("FK_pratica_alias2_registry_idreg","registry","pratica_alias2","idreg");
	this.defineRelation("FK_convalidato_learningagrtrainer_alias3_idlearningagrtrainer","learningagrtrainer_alias3","convalidato","idlearningagrtrainer");
	this.defineRelation("FK_convalidato_learningagrstud_alias2_idlearningagrstud","learningagrstud_alias2","convalidato","idlearningagrstud");
	this.defineRelation("FK_convalidato_istanza_alias2_idistanza","istanza_alias2","convalidato","idistanza");
	this.defineRelation("FK_istanza_alias2_iscrizione_idiscrizione","iscrizione","istanza_alias2","idiscrizione");
	this.defineRelation("FK_istanza_alias2_didprog_iddidprog","didprog","istanza_alias2","iddidprog");
	this.defineRelation("FK_istanza_alias2_statuskind_idstatuskind","statuskind","istanza_alias2","idstatuskind");
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{istanza_alias2.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_alias2_registry_idreg_studenti",cPar,cChild,false));

	this.defineRelation("FK_istanza_alias2_istanzakind_idistanzakind","istanzakind","istanza_alias2","idistanzakind");
	this.defineRelation("FK_convalidato_iscrizionebmi_alias2_idiscrizionebmi","iscrizionebmi_alias2","convalidato","idiscrizionebmi");
	cPar = new []{iscrizione.Columns["idiscrizione"]};
	cChild = new []{convalidato.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_convalidato_iscrizione_idiscrizione_from",cPar,cChild,false));

	this.defineRelation("FK_convalidato_iscrizione_idiscrizione","iscrizione","convalidato","idiscrizione");
	this.defineRelation("FK_iscrizione_didprog_iddidprog","didprog","iscrizione","iddidprog");
	this.defineRelation("FK_convalidato_didprog_iddidprog","didprog","convalidato","iddidprog");
	this.defineRelation("FK_didprog_sede_idsede","sede","didprog","idsede");
	this.defineRelation("FK_convalidato_dichiar_alias2_iddichiar","dichiar_alias2","convalidato","iddichiar");
	this.defineRelation("FK_dichiar_alias2_dichiarkind_iddichiarkind","dichiarkind","dichiar_alias2","iddichiarkind");
	this.defineRelation("FK_convalidato_changeskind_idchangeskind","changeskind","convalidato","idchangeskind");
	this.defineRelation("FK_convalidato_changes_idchanges","changes","convalidato","idchanges");
	this.defineRelation("FK_convalidato_attivform_idattivform","attivform","convalidato","idattivform");
	this.defineRelation("FK_convalida_pratica_idpratica","pratica","convalida","idpratica");
	this.defineRelation("FK_convalida_learningagrtrainer_alias1_idlearningagrtrainer","learningagrtrainer_alias1","convalida","idlearningagrtrainer");
	this.defineRelation("FK_convalida_learningagrstud_idlearningagrstud","learningagrstud","convalida","idlearningagrstud");
	this.defineRelation("FK_convalida_istanza_idistanza","istanza","convalida","idistanza");
	this.defineRelation("FK_convalida_iscrizionebmi_idiscrizionebmi","iscrizionebmi","convalida","idiscrizionebmi");
	cPar = new []{iscrizionedefaultview_alias1.Columns["idiscrizione"]};
	cChild = new []{convalida.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_convalida_iscrizionedefaultview_alias1_idiscrizione_from",cPar,cChild,false));

	this.defineRelation("FK_convalida_iscrizionedefaultview_idiscrizione","iscrizionedefaultview","convalida","idiscrizione");
	this.defineRelation("FK_convalida_didprogdefaultview_iddidprog","didprogdefaultview","convalida","iddidprog");
	this.defineRelation("FK_convalida_dichiar_iddichiar","dichiar","convalida","iddichiar");
	this.defineRelation("FK_convalida_convalidakind_idconvalidakind","convalidakind","convalida","idconvalidakind");
	cPar = new []{registryaziendeview.Columns["idreg"]};
	cChild = new []{learningagrtrainer.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_learningagrtrainer_registryaziendeview_idreg_aziende",cPar,cChild,false));

	this.defineRelation("FK_learningagrtrainer_geo_nation_idnation","geo_nation","learningagrtrainer","idnation");
	this.defineRelation("FK_learningagrtrainer_learningagrtrainervalut_idlearningagrtrainervalut","learningagrtrainervalut","learningagrtrainer","idlearningagrtrainervalut");
	this.defineRelation("FK_learningagrtrainer_learningagrtrainerkind_idlearningagrtrainerkind","learningagrtrainerkind","learningagrtrainer","idlearningagrtrainerkind");
	this.defineRelation("FK_learningagrtrainer_learningagrkind_idlearningagrkind","learningagrkind","learningagrtrainer","idlearningagrkind");
	this.defineRelation("FK_learningagrtrainer_geo_citydefaultview_idcity","geo_citydefaultview","learningagrtrainer","idcity");
	this.defineRelation("FK_learningagrtrainer_cefrlangleveldefaultview_idcefrlanglevel","cefrlangleveldefaultview","learningagrtrainer","idcefrlanglevel");
	#endregion

}
}
}
