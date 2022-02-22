
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
[System.Xml.Serialization.XmlRoot("dsmeta_pratica_segstud"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_pratica_segstud: DataSet {

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
	public MetaTable iscrizionebmi 		=> (MetaTable)Tables["iscrizionebmi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidakind 		=> (MetaTable)Tables["convalidakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudio 		=> (MetaTable)Tables["titolostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzakinddefaultview 		=> (MetaTable)Tables["istanzakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias14 		=> (MetaTable)Tables["istanza_alias14"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneseganagstuview_alias1 		=> (MetaTable)Tables["iscrizioneseganagstuview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneseganagstuview 		=> (MetaTable)Tables["iscrizioneseganagstuview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarsegview 		=> (MetaTable)Tables["dichiarsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

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
	tlearningagrstud.defineColumn("idbandomi", typeof(int),false);
	tlearningagrstud.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrstud", typeof(int),false);
	tlearningagrstud.defineColumn("idreg", typeof(int),false);
	Tables.Add(tlearningagrstud);
	tlearningagrstud.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrstud", "idreg");

	//////////////////// ISCRIZIONEBMI /////////////////////////////////
	var tiscrizionebmi= new MetaTable("iscrizionebmi");
	tiscrizionebmi.defineColumn("data", typeof(DateTime));
	tiscrizionebmi.defineColumn("idbandomi", typeof(int),false);
	tiscrizionebmi.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionebmi.defineColumn("idiscrizionebmi", typeof(int),false);
	tiscrizionebmi.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizionebmi);
	tiscrizionebmi.defineKey("idbandomi", "idiscrizionebmi", "idreg");

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
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

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
	tconvalida.defineColumn("!idconvalidakind_convalidakind_title", typeof(string));
	tconvalida.defineColumn("!idiscrizionebmi_iscrizionebmi_data", typeof(DateTime));
	tconvalida.defineColumn("!idiscrizionebmi_iscrizionebmi_idreg_title", typeof(string));
	tconvalida.defineColumn("!idiscrizionebmi_iscrizionebmi_idiscrizione_anno", typeof(int));
	tconvalida.defineColumn("!idiscrizionebmi_iscrizionebmi_idiscrizione_iddidprog", typeof(int));
	tconvalida.defineColumn("!idiscrizionebmi_iscrizionebmi_idiscrizione_aa", typeof(string));
	tconvalida.defineColumn("!idlearningagrtrainer_learningagrtrainer_title", typeof(string));
	Tables.Add(tconvalida);
	tconvalida.defineKey("idconvalida", "idreg");

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
	Tables.Add(ttitolostudio);
	ttitolostudio.defineKey("idreg", "idtitolostudio");

	//////////////////// STATUSKIND /////////////////////////////////
	var tstatuskind= new MetaTable("statuskind");
	tstatuskind.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskind);
	tstatuskind.defineKey("idstatuskind");

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

	//////////////////// ISTANZAKINDDEFAULTVIEW /////////////////////////////////
	var tistanzakinddefaultview= new MetaTable("istanzakinddefaultview");
	tistanzakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tistanzakinddefaultview.defineColumn("idistanzakind", typeof(int),false);
	Tables.Add(tistanzakinddefaultview);
	tistanzakinddefaultview.defineKey("idistanzakind");

	//////////////////// ISTANZA_ALIAS14 /////////////////////////////////
	var tistanza_alias14= new MetaTable("istanza_alias14");
	tistanza_alias14.defineColumn("aa", typeof(string),false);
	tistanza_alias14.defineColumn("data", typeof(DateTime),false);
	tistanza_alias14.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_alias14.defineColumn("iddidprog", typeof(int),false);
	tistanza_alias14.defineColumn("idiscrizione", typeof(int));
	tistanza_alias14.defineColumn("idistanza", typeof(int),false);
	tistanza_alias14.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias14.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias14.defineColumn("paridistanza", typeof(int),false);
	tistanza_alias14.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias14);
	tistanza_alias14.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti", "paridistanza");

	//////////////////// ISCRIZIONESEGANAGSTUVIEW_ALIAS1 /////////////////////////////////
	var tiscrizioneseganagstuview_alias1= new MetaTable("iscrizioneseganagstuview_alias1");
	tiscrizioneseganagstuview_alias1.defineColumn("aa", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("annoaccademico_aa", typeof(string));
	tiscrizioneseganagstuview_alias1.defineColumn("didprog_title", typeof(string));
	tiscrizioneseganagstuview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("idcorsostudio", typeof(int));
	tiscrizioneseganagstuview_alias1.defineColumn("iddidprog", typeof(int));
	tiscrizioneseganagstuview_alias1.defineColumn("idiscrizione", typeof(int),false);
	tiscrizioneseganagstuview_alias1.defineColumn("idreg", typeof(int),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_anno", typeof(int));
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizioneseganagstuview_alias1.defineColumn("sede_title", typeof(string));
	tiscrizioneseganagstuview_alias1.ExtendedProperties["TableForReading"]="iscrizioneseganagstuview";
	Tables.Add(tiscrizioneseganagstuview_alias1);
	tiscrizioneseganagstuview_alias1.defineKey("idiscrizione");

	//////////////////// ISCRIZIONESEGANAGSTUVIEW /////////////////////////////////
	var tiscrizioneseganagstuview= new MetaTable("iscrizioneseganagstuview");
	tiscrizioneseganagstuview.defineColumn("aa", typeof(string),false);
	tiscrizioneseganagstuview.defineColumn("annoaccademico_aa", typeof(string));
	tiscrizioneseganagstuview.defineColumn("didprog_title", typeof(string));
	tiscrizioneseganagstuview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizioneseganagstuview.defineColumn("idcorsostudio", typeof(int));
	tiscrizioneseganagstuview.defineColumn("iddidprog", typeof(int));
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
	tiscrizioneseganagstuview.defineKey("idiscrizione");

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
	tdichiarsegview.defineKey("iddichiar");

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudiolivello", typeof(int));
	tcorsostudiodefaultview.defineColumn("idcorsostudionorma", typeof(int));
	tcorsostudiodefaultview.defineColumn("idstruttura", typeof(int));
	Tables.Add(tcorsostudiodefaultview);
	tcorsostudiodefaultview.defineKey("idcorsostudio");

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
	var cPar = new []{pratica.Columns["iddidprog"], pratica.Columns["idiscrizione"], pratica.Columns["idistanza"], pratica.Columns["idpratica"], pratica.Columns["idreg"], pratica.Columns["iddichiar"], pratica.Columns["idiscrizione_from"]};
	var cChild = new []{convalida.Columns["iddidprog"], convalida.Columns["idiscrizione"], convalida.Columns["idistanza"], convalida.Columns["idpratica"], convalida.Columns["idreg"], convalida.Columns["iddichiar"], convalida.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_convalida_pratica_iddidprog-idiscrizione-idistanza-idpratica-idreg-iddichiar-idiscrizione_from-",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidante.Columns["idconvalida"], convalidante.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidante_convalida_idconvalida-idreg",cPar,cChild,false));

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

	cPar = new []{titolostudio.Columns["idtitolostudio"]};
	cChild = new []{pratica.Columns["idtitolostudio"]};
	Relations.Add(new DataRelation("FK_pratica_titolostudio_idtitolostudio",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{pratica.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_pratica_statuskind_idstatuskind",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{pratica.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pratica_registrystudentiview_idreg",cPar,cChild,false));

	cPar = new []{istanzakinddefaultview.Columns["idistanzakind"]};
	cChild = new []{pratica.Columns["idistanzakind"]};
	Relations.Add(new DataRelation("FK_pratica_istanzakinddefaultview_idistanzakind",cPar,cChild,false));

	cPar = new []{istanza_alias14.Columns["idistanza"]};
	cChild = new []{pratica.Columns["idistanza"]};
	Relations.Add(new DataRelation("FK_pratica_istanza_alias14_idistanza",cPar,cChild,false));

	cPar = new []{iscrizioneseganagstuview.Columns["idiscrizione"]};
	cChild = new []{istanza_alias14.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_istanza_alias14_iscrizioneseganagstuview_idiscrizione",cPar,cChild,false));

	cPar = new []{iscrizioneseganagstuview_alias1.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizioneseganagstuview_alias1_idiscrizione_from",cPar,cChild,false));

	cPar = new []{iscrizioneseganagstuview.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizioneseganagstuview_idiscrizione",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{pratica.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_pratica_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{didprogdefaultview.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_didprogdefaultview_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	cPar = new []{dichiarsegview.Columns["iddichiar"]};
	cChild = new []{pratica.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_pratica_dichiarsegview_iddichiar",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{pratica.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_pratica_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	#endregion

}
}
}
