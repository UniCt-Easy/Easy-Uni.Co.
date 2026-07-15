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
[System.Xml.Serialization.XmlRoot("dsmeta_pratica_segstud"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_pratica_segstud: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidante 		=> (MetaTable)Tables["convalidante"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainer 		=> (MetaTable)Tables["learningagrtrainer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrstud 		=> (MetaTable)Tables["learningagrstud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmi 		=> (MetaTable)Tables["iscrizionebmi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidakind 		=> (MetaTable)Tables["convalidakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskinddefaultview 		=> (MetaTable)Tables["statuskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudiodocentiview 		=> (MetaTable)Tables["titolostudiodocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneseganagstuview_alias1 		=> (MetaTable)Tables["iscrizioneseganagstuview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarsegview 		=> (MetaTable)Tables["dichiarsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzakinddefaultview 		=> (MetaTable)Tables["istanzakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzasegstuelencoview_alias14 		=> (MetaTable)Tables["istanzasegstuelencoview_alias14"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneseganagstuview 		=> (MetaTable)Tables["iscrizioneseganagstuview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pratica_segstud(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pratica_segstud (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pratica_segstud";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pratica_segstud.xsd";

	#region create DataTables
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
	tconvalidato.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tconvalidato);
	tconvalidato.defineKey("idconvalida", "idconvalidato", "idreg");

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
	tconvalidante.defineColumn("idiscrizionebmi", typeof(int));
	tconvalidante.defineColumn("idistanza", typeof(int));
	tconvalidante.defineColumn("idlearningagrstud", typeof(int));
	tconvalidante.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidante.defineColumn("idpratica", typeof(int));
	tconvalidante.defineColumn("idreg", typeof(int),false);
	tconvalidante.defineColumn("idsostenimento", typeof(int));
	tconvalidante.defineColumn("idtirocinioprogetto", typeof(int));
	tconvalidante.defineColumn("lt", typeof(DateTime),false);
	tconvalidante.defineColumn("lu", typeof(string),false);
	tconvalidante.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tconvalidante);
	tconvalidante.defineKey("idconvalida", "idconvalidante", "idreg");

	//////////////////// LEARNINGAGRTRAINER /////////////////////////////////
	var tlearningagrtrainer= new MetaTable("learningagrtrainer");
	tlearningagrtrainer.defineColumn("idbandomi", typeof(int),false);
	tlearningagrtrainer.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrtrainer.defineColumn("idlearningagrtrainer", typeof(int),false);
	tlearningagrtrainer.defineColumn("idreg", typeof(int),false);
	tlearningagrtrainer.defineColumn("title", typeof(string),false);
	Tables.Add(tlearningagrtrainer);
	tlearningagrtrainer.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

	//////////////////// LEARNINGAGRSTUD /////////////////////////////////
	var tlearningagrstud= new MetaTable("learningagrstud");
	tlearningagrstud.defineColumn("department", typeof(string));
	tlearningagrstud.defineColumn("idbandomi", typeof(int),false);
	tlearningagrstud.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrstud", typeof(int),false);
	tlearningagrstud.defineColumn("idreg", typeof(int),false);
	Tables.Add(tlearningagrstud);
	tlearningagrstud.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrstud", "idreg");

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

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ISCRIZIONEBMI /////////////////////////////////
	var tiscrizionebmi= new MetaTable("iscrizionebmi");
	tiscrizionebmi.defineColumn("data", typeof(DateTime));
	tiscrizionebmi.defineColumn("idbandomi", typeof(int),false);
	tiscrizionebmi.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionebmi.defineColumn("idiscrizionebmi", typeof(int),false);
	tiscrizionebmi.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizionebmi);
	tiscrizionebmi.defineKey("idbandomi", "idiscrizionebmi", "idreg");

	//////////////////// CONVALIDAKIND /////////////////////////////////
	var tconvalidakind= new MetaTable("convalidakind");
	tconvalidakind.defineColumn("active", typeof(string),false);
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
	tconvalida.defineColumn("iddidprog", typeof(int),false);
	tconvalida.defineColumn("idiscrizione", typeof(int),false);
	tconvalida.defineColumn("idiscrizione_from", typeof(int));
	tconvalida.defineColumn("idiscrizionebmi", typeof(int));
	tconvalida.defineColumn("idistanza", typeof(int),false);
	tconvalida.defineColumn("idlearningagrstud", typeof(int));
	tconvalida.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalida.defineColumn("idpratica", typeof(int),false);
	tconvalida.defineColumn("idreg", typeof(int),false);
	tconvalida.defineColumn("lt", typeof(DateTime),false);
	tconvalida.defineColumn("lu", typeof(string),false);
	tconvalida.defineColumn("voto", typeof(decimal));
	tconvalida.defineColumn("votolode", typeof(string));
	tconvalida.defineColumn("votosu", typeof(int));
	tconvalida.defineColumn("!idconvalidakind_convalidakind_title", typeof(string));
	tconvalida.defineColumn("!idiscrizionebmi_iscrizionebmi_data", typeof(DateTime));
	tconvalida.defineColumn("!idiscrizionebmi_iscrizionebmi_idreg_title", typeof(string));
	tconvalida.defineColumn("!idiscrizionebmi_iscrizionebmi_idiscrizione_anno", typeof(int));
	tconvalida.defineColumn("!idiscrizionebmi_iscrizionebmi_idiscrizione_aa", typeof(string));
	tconvalida.defineColumn("!idiscrizionebmi_iscrizionebmi_idiscrizione_iddidprog", typeof(int));
	tconvalida.defineColumn("!idlearningagrstud_learningagrstud_department", typeof(string));
	tconvalida.defineColumn("!idlearningagrtrainer_learningagrtrainer_title", typeof(string));
	tconvalida.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tconvalida);
	tconvalida.defineKey("idconvalida", "iddidprog", "idiscrizione", "idistanza", "idpratica", "idreg");

	//////////////////// STATUSKINDDEFAULTVIEW /////////////////////////////////
	var tstatuskinddefaultview= new MetaTable("statuskinddefaultview");
	tstatuskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstatuskinddefaultview.defineColumn("idstatuskind", typeof(int),false);
	tstatuskinddefaultview.defineColumn("statuskind_ct", typeof(DateTime),false);
	tstatuskinddefaultview.defineColumn("statuskind_cu", typeof(string),false);
	tstatuskinddefaultview.defineColumn("statuskind_delibera", typeof(string));
	tstatuskinddefaultview.defineColumn("statuskind_istanze", typeof(string));
	tstatuskinddefaultview.defineColumn("statuskind_istanzedelibera", typeof(string));
	tstatuskinddefaultview.defineColumn("statuskind_lt", typeof(DateTime),false);
	tstatuskinddefaultview.defineColumn("statuskind_lu", typeof(string),false);
	tstatuskinddefaultview.defineColumn("statuskind_pratica", typeof(string));
	tstatuskinddefaultview.defineColumn("statuskind_sortcode", typeof(int),false);
	tstatuskinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskinddefaultview);
	tstatuskinddefaultview.defineKey("idstatuskind");

	//////////////////// TITOLOSTUDIODOCENTIVIEW /////////////////////////////////
	var ttitolostudiodocentiview= new MetaTable("titolostudiodocentiview");
	ttitolostudiodocentiview.defineColumn("dropdown_title", typeof(string),false);
	ttitolostudiodocentiview.defineColumn("idreg", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("idtitolostudio", typeof(int),false);
	Tables.Add(ttitolostudiodocentiview);
	ttitolostudiodocentiview.defineKey("idreg", "idtitolostudio");

	//////////////////// ISCRIZIONESEGANAGSTUVIEW_ALIAS1 /////////////////////////////////
	var tiscrizioneseganagstuview_alias1= new MetaTable("iscrizioneseganagstuview_alias1");
	tiscrizioneseganagstuview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iddidprog", typeof(int),false);
	tiscrizioneseganagstuview_alias1.defineColumn("idiscrizione", typeof(int),false);
	tiscrizioneseganagstuview_alias1.defineColumn("idreg", typeof(int),false);
	tiscrizioneseganagstuview_alias1.ExtendedProperties["TableForReading"]="iscrizioneseganagstuview";
	Tables.Add(tiscrizioneseganagstuview_alias1);
	tiscrizioneseganagstuview_alias1.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// DICHIARSEGVIEW /////////////////////////////////
	var tdichiarsegview= new MetaTable("dichiarsegview");
	tdichiarsegview.defineColumn("aa", typeof(string));
	tdichiarsegview.defineColumn("dichiar_ct", typeof(DateTime),false);
	tdichiarsegview.defineColumn("dichiar_cu", typeof(string),false);
	tdichiarsegview.defineColumn("dichiar_date", typeof(DateTime),false);
	tdichiarsegview.defineColumn("dichiar_extension", typeof(string));
	tdichiarsegview.defineColumn("dichiar_lt", typeof(DateTime),false);
	tdichiarsegview.defineColumn("dichiar_lu", typeof(string),false);
	tdichiarsegview.defineColumn("dichiar_protanno", typeof(int));
	tdichiarsegview.defineColumn("dichiar_protnumero", typeof(int));
	tdichiarsegview.defineColumn("dichiarkind_title", typeof(string));
	tdichiarsegview.defineColumn("dropdown_title", typeof(string),false);
	tdichiarsegview.defineColumn("iddichiar", typeof(int),false);
	tdichiarsegview.defineColumn("iddichiarkind", typeof(int),false);
	tdichiarsegview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tdichiarsegview);
	tdichiarsegview.defineKey("iddichiar", "idreg");

	//////////////////// ISTANZAKINDDEFAULTVIEW /////////////////////////////////
	var tistanzakinddefaultview= new MetaTable("istanzakinddefaultview");
	tistanzakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tistanzakinddefaultview.defineColumn("idistanzakind", typeof(int),false);
	tistanzakinddefaultview.defineColumn("istanzakind_active", typeof(string));
	tistanzakinddefaultview.defineColumn("istanzakind_ct", typeof(DateTime),false);
	tistanzakinddefaultview.defineColumn("istanzakind_cu", typeof(string),false);
	tistanzakinddefaultview.defineColumn("istanzakind_description", typeof(string));
	tistanzakinddefaultview.defineColumn("istanzakind_lt", typeof(DateTime),false);
	tistanzakinddefaultview.defineColumn("istanzakind_lu", typeof(string),false);
	tistanzakinddefaultview.defineColumn("istanzakind_sortcode", typeof(int),false);
	tistanzakinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tistanzakinddefaultview);
	tistanzakinddefaultview.defineKey("idistanzakind");

	//////////////////// ISTANZASEGSTUELENCOVIEW_ALIAS14 /////////////////////////////////
	var tistanzasegstuelencoview_alias14= new MetaTable("istanzasegstuelencoview_alias14");
	tistanzasegstuelencoview_alias14.defineColumn("aa", typeof(string),false);
	tistanzasegstuelencoview_alias14.defineColumn("dropdown_title", typeof(string),false);
	tistanzasegstuelencoview_alias14.defineColumn("idcorsostudio", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("iddidprog", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("idistanza", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("idistanzakind", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("idreg_studenti", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_ct", typeof(DateTime),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_cu", typeof(string),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_data", typeof(DateTime),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_extension", typeof(string));
	tistanzasegstuelencoview_alias14.defineColumn("istanza_idiscrizione", typeof(int));
	tistanzasegstuelencoview_alias14.defineColumn("istanza_idstatuskind", typeof(int));
	tistanzasegstuelencoview_alias14.defineColumn("istanza_lt", typeof(DateTime),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_lu", typeof(string),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_paridistanza", typeof(int));
	tistanzasegstuelencoview_alias14.defineColumn("istanza_protanno", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_protnumero", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanzakind_title", typeof(string));
	tistanzasegstuelencoview_alias14.defineColumn("registrystudenti_title", typeof(string));
	tistanzasegstuelencoview_alias14.defineColumn("statuskind_title", typeof(string));
	tistanzasegstuelencoview_alias14.ExtendedProperties["TableForReading"]="istanzasegstuelencoview";
	Tables.Add(tistanzasegstuelencoview_alias14);
	tistanzasegstuelencoview_alias14.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdefaultview.defineColumn("iddidprog", typeof(int),false);
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("idcorsostudio", "iddidprog");

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	Tables.Add(tcorsostudiodefaultview);
	tcorsostudiodefaultview.defineKey("idcorsostudio");

	//////////////////// ISCRIZIONESEGANAGSTUVIEW /////////////////////////////////
	var tiscrizioneseganagstuview= new MetaTable("iscrizioneseganagstuview");
	tiscrizioneseganagstuview.defineColumn("aa", typeof(string),false);
	tiscrizioneseganagstuview.defineColumn("didprog_aa", typeof(string));
	tiscrizioneseganagstuview.defineColumn("didprog_idsede", typeof(int));
	tiscrizioneseganagstuview.defineColumn("didprog_title", typeof(string));
	tiscrizioneseganagstuview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizioneseganagstuview.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizioneseganagstuview.defineColumn("iddidprog", typeof(int),false);
	tiscrizioneseganagstuview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizioneseganagstuview.defineColumn("idreg", typeof(int),false);
	tiscrizioneseganagstuview.defineColumn("iscrizione_anno", typeof(int));
	tiscrizioneseganagstuview.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizioneseganagstuview.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizioneseganagstuview.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizioneseganagstuview.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizioneseganagstuview.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizioneseganagstuview.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizioneseganagstuview.defineColumn("sede_title", typeof(string));
	Tables.Add(tiscrizioneseganagstuview);
	tiscrizioneseganagstuview.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

	//////////////////// PRATICA /////////////////////////////////
	var tpratica= new MetaTable("pratica");
	tpratica.defineColumn("ct", typeof(DateTime),false);
	tpratica.defineColumn("cu", typeof(string),false);
	tpratica.defineColumn("idcorsostudio", typeof(int),false);
	tpratica.defineColumn("iddichiar", typeof(int));
	tpratica.defineColumn("iddidprog", typeof(int),false);
	tpratica.defineColumn("idiscrizione", typeof(int),false);
	tpratica.defineColumn("idiscrizione_from", typeof(int));
	tpratica.defineColumn("idistanza", typeof(int),false);
	tpratica.defineColumn("idistanzakind", typeof(int),false);
	tpratica.defineColumn("idpratica", typeof(int),false);
	tpratica.defineColumn("idreg", typeof(int),false);
	tpratica.defineColumn("idstatuskind", typeof(int),false);
	tpratica.defineColumn("idtitolostudio", typeof(int));
	tpratica.defineColumn("lt", typeof(DateTime),false);
	tpratica.defineColumn("lu", typeof(string),false);
	tpratica.defineColumn("protanno", typeof(int));
	tpratica.defineColumn("protnumero", typeof(int));
	Tables.Add(tpratica);
	tpratica.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{pratica.Columns["iddidprog"], pratica.Columns["idiscrizione"], pratica.Columns["idistanza"], pratica.Columns["idpratica"], pratica.Columns["idreg"]};
	var cChild = new []{convalida.Columns["iddidprog"], convalida.Columns["idiscrizione"], convalida.Columns["idistanza"], convalida.Columns["idpratica"], convalida.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalida_pratica_iddidprog-idiscrizione-idistanza-idpratica-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["iddidprog"], convalida.Columns["idiscrizione"], convalida.Columns["idistanza"], convalida.Columns["idpratica"], convalida.Columns["idreg"]};
	cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["iddidprog"], convalidato.Columns["idiscrizione"], convalidato.Columns["idistanza"], convalidato.Columns["idpratica"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-iddidprog-idiscrizione-idistanza-idpratica-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["iddidprog"], convalida.Columns["idiscrizione"], convalida.Columns["idistanza"], convalida.Columns["idpratica"], convalida.Columns["idreg"]};
	cChild = new []{convalidante.Columns["idconvalida"], convalidante.Columns["iddidprog"], convalidante.Columns["idiscrizione"], convalidante.Columns["idistanza"], convalidante.Columns["idpratica"], convalidante.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidante_convalida_idconvalida-iddidprog-idiscrizione-idistanza-idpratica-idreg",cPar,cChild,false));

	cPar = new []{learningagrtrainer.Columns["idlearningagrtrainer"]};
	cChild = new []{convalida.Columns["idlearningagrtrainer"]};
	Relations.Add(new DataRelation("FK_convalida_learningagrtrainer_idlearningagrtrainer",cPar,cChild,false));

	cPar = new []{learningagrstud.Columns["idlearningagrstud"]};
	cChild = new []{convalida.Columns["idlearningagrstud"]};
	Relations.Add(new DataRelation("FK_convalida_learningagrstud_idlearningagrstud",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idiscrizionebmi"]};
	cChild = new []{convalida.Columns["idiscrizionebmi"]};
	Relations.Add(new DataRelation("FK_convalida_iscrizionebmi_idiscrizionebmi",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"]};
	cChild = new []{iscrizionebmi.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_iscrizionebmi_iscrizione_idiscrizione",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{iscrizionebmi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionebmi_registry_idreg",cPar,cChild,false));

	cPar = new []{convalidakind.Columns["idconvalidakind"]};
	cChild = new []{convalida.Columns["idconvalidakind"]};
	Relations.Add(new DataRelation("FK_convalida_convalidakind_idconvalidakind",cPar,cChild,false));

	cPar = new []{statuskinddefaultview.Columns["idstatuskind"]};
	cChild = new []{pratica.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_pratica_statuskinddefaultview_idstatuskind",cPar,cChild,false));

	cPar = new []{titolostudiodocentiview.Columns["idtitolostudio"]};
	cChild = new []{pratica.Columns["idtitolostudio"]};
	Relations.Add(new DataRelation("FK_pratica_titolostudiodocentiview_idtitolostudio",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{titolostudiodocentiview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_titolostudiodocentiview_registrystudentiview_idreg",cPar,cChild,false));

	cPar = new []{iscrizioneseganagstuview_alias1.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizioneseganagstuview_alias1_idiscrizione_from",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{iscrizioneseganagstuview_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizioneseganagstuview_alias1_registrystudentiview_idreg",cPar,cChild,false));

	cPar = new []{dichiarsegview.Columns["iddichiar"]};
	cChild = new []{pratica.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_pratica_dichiarsegview_iddichiar",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{dichiarsegview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_dichiarsegview_registrystudentiview_idreg",cPar,cChild,false));

	cPar = new []{istanzakinddefaultview.Columns["idistanzakind"]};
	cChild = new []{pratica.Columns["idistanzakind"]};
	Relations.Add(new DataRelation("FK_pratica_istanzakinddefaultview_idistanzakind",cPar,cChild,false));

	cPar = new []{istanzasegstuelencoview_alias14.Columns["idistanza"]};
	cChild = new []{pratica.Columns["idistanza"]};
	Relations.Add(new DataRelation("FK_pratica_istanzasegstuelencoview_alias14_idistanza",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{istanzasegstuelencoview_alias14.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanzasegstuelencoview_alias14_registrystudentiview_idreg",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{pratica.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_pratica_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{pratica.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_pratica_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	cPar = new []{iscrizioneseganagstuview.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizioneseganagstuview_idiscrizione",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{iscrizioneseganagstuview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizioneseganagstuview_registrystudentiview_idreg",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{pratica.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pratica_registrystudentiview_idreg",cPar,cChild,false));

	#endregion

}
}
}
