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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_tri_stu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_istanza_tri_stu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias1 		=> (MetaTable)Tables["diniego_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskinddefaultview 		=> (MetaTable)Tables["statuskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta 		=> (MetaTable)Tables["nullaosta"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiartitolo_segview 		=> (MetaTable)Tables["dichiartitolo_segview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaziendeview 		=> (MetaTable)Tables["registryaziendeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform_alias1 		=> (MetaTable)Tables["attivform_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidante 		=> (MetaTable)Tables["convalidante"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_tri 		=> (MetaTable)Tables["istanza_tri"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanza_tri_stu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_tri_stu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_tri_stu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_tri_stu.xsd";

	#region create DataTables
	//////////////////// DINIEGO_ALIAS1 /////////////////////////////////
	var tdiniego_alias1= new MetaTable("diniego_alias1");
	tdiniego_alias1.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias1.defineColumn("cu", typeof(string),false);
	tdiniego_alias1.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego_alias1.defineColumn("iddidprog", typeof(int),false);
	tdiniego_alias1.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias1.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias1.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias1.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias1.defineColumn("idreg", typeof(int),false);
	tdiniego_alias1.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias1.defineColumn("lu", typeof(string),false);
	tdiniego_alias1.defineColumn("protanno", typeof(int));
	tdiniego_alias1.defineColumn("protnumero", typeof(int));
	tdiniego_alias1.ExtendedProperties["TableForReading"]="diniego";
	Tables.Add(tdiniego_alias1);
	tdiniego_alias1.defineKey("idcorsostudio", "iddidprog", "iddiniego", "idistanza", "idistanzakind", "idreg");

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

	//////////////////// NULLAOSTA /////////////////////////////////
	var tnullaosta= new MetaTable("nullaosta");
	tnullaosta.defineColumn("ct", typeof(DateTime),false);
	tnullaosta.defineColumn("cu", typeof(string),false);
	tnullaosta.defineColumn("data", typeof(DateTime),false);
	tnullaosta.defineColumn("extension", typeof(string));
	tnullaosta.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta.defineColumn("iddidprog", typeof(int),false);
	tnullaosta.defineColumn("idiscrizione", typeof(int));
	tnullaosta.defineColumn("idistanza", typeof(int),false);
	tnullaosta.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta.defineColumn("idreg", typeof(int),false);
	tnullaosta.defineColumn("lt", typeof(DateTime),false);
	tnullaosta.defineColumn("lu", typeof(string),false);
	tnullaosta.defineColumn("protanno", typeof(int));
	tnullaosta.defineColumn("protnumero", typeof(int));
	tnullaosta.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tnullaosta);
	tnullaosta.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// DICHIARTITOLO_SEGVIEW /////////////////////////////////
	var tdichiartitolo_segview= new MetaTable("dichiartitolo_segview");
	tdichiartitolo_segview.defineColumn("aa", typeof(string));
	tdichiartitolo_segview.defineColumn("annoaccademico_aa", typeof(string));
	tdichiartitolo_segview.defineColumn("dichiar_ct", typeof(DateTime),false);
	tdichiartitolo_segview.defineColumn("dichiar_cu", typeof(string),false);
	tdichiartitolo_segview.defineColumn("dichiar_date", typeof(DateTime),false);
	tdichiartitolo_segview.defineColumn("dichiar_extension", typeof(string));
	tdichiartitolo_segview.defineColumn("dichiar_iddichiarkind", typeof(int),false);
	tdichiartitolo_segview.defineColumn("dichiar_lt", typeof(DateTime),false);
	tdichiartitolo_segview.defineColumn("dichiar_lu", typeof(string),false);
	tdichiartitolo_segview.defineColumn("dichiar_protanno", typeof(int));
	tdichiartitolo_segview.defineColumn("dichiar_protnumero", typeof(int));
	tdichiartitolo_segview.defineColumn("dichiar_titolo_ct", typeof(DateTime),false);
	tdichiartitolo_segview.defineColumn("dichiar_titolo_cu", typeof(string),false);
	tdichiartitolo_segview.defineColumn("dichiar_titolo_iddichiar", typeof(int),false);
	tdichiartitolo_segview.defineColumn("dichiar_titolo_idreg", typeof(int),false);
	tdichiartitolo_segview.defineColumn("dichiar_titolo_idtitolostudio", typeof(int),false);
	tdichiartitolo_segview.defineColumn("dichiar_titolo_lt", typeof(DateTime),false);
	tdichiartitolo_segview.defineColumn("dichiar_titolo_lu", typeof(string),false);
	tdichiartitolo_segview.defineColumn("dropdown_title", typeof(string),false);
	tdichiartitolo_segview.defineColumn("iddichiar", typeof(int),false);
	tdichiartitolo_segview.defineColumn("idreg", typeof(int),false);
	tdichiartitolo_segview.defineColumn("istattitolistudio_titolo", typeof(string));
	tdichiartitolo_segview.defineColumn("registry_title", typeof(string));
	tdichiartitolo_segview.defineColumn("titolostudio_voto", typeof(int));
	tdichiartitolo_segview.defineColumn("titolostudio_votolode", typeof(string));
	tdichiartitolo_segview.defineColumn("titolostudio_votosu", typeof(int));
	Tables.Add(tdichiartitolo_segview);
	tdichiartitolo_segview.defineKey("iddichiar", "idreg");

	//////////////////// REGISTRYAZIENDEVIEW /////////////////////////////////
	var tregistryaziendeview= new MetaTable("registryaziendeview");
	tregistryaziendeview.defineColumn("dropdown_title", typeof(string),false);
	tregistryaziendeview.defineColumn("idreg", typeof(int),false);
	tregistryaziendeview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistryaziendeview);
	tregistryaziendeview.defineKey("idreg");

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

	//////////////////// ATTIVFORM_ALIAS1 /////////////////////////////////
	var tattivform_alias1= new MetaTable("attivform_alias1");
	tattivform_alias1.defineColumn("aa", typeof(string),false);
	tattivform_alias1.defineColumn("idattivform", typeof(int),false);
	tattivform_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprog", typeof(int),false);
	tattivform_alias1.defineColumn("iddidproganno", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprogori", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivform_alias1.defineColumn("idsede", typeof(int),false);
	tattivform_alias1.defineColumn("title", typeof(string));
	tattivform_alias1.ExtendedProperties["TableForReading"]="attivform";
	Tables.Add(tattivform_alias1);
	tattivform_alias1.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

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
	Tables.Add(tconvalidato);
	tconvalidato.defineKey("idconvalida", "idconvalidato", "idreg");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

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

	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("idappello", typeof(int),false);
	tsostenimento.defineColumn("idattivform", typeof(int));
	tsostenimento.defineColumn("idprova", typeof(int),false);
	tsostenimento.defineColumn("idreg", typeof(int),false);
	tsostenimento.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento.defineColumn("voto", typeof(decimal));
	tsostenimento.defineColumn("votolode", typeof(string));
	tsostenimento.defineColumn("votosu", typeof(int));
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idappello", "idprova", "idreg", "idsostenimento");

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
	tconvalidante.defineColumn("!idsostenimento_sostenimento_voto", typeof(decimal));
	tconvalidante.defineColumn("!idsostenimento_sostenimento_votosu", typeof(int));
	tconvalidante.defineColumn("!idsostenimento_sostenimento_votolode", typeof(string));
	tconvalidante.defineColumn("!idsostenimento_sostenimento_idattivform_title", typeof(string));
	tconvalidante.defineColumn("!idsostenimento_sostenimento_idreg_title", typeof(string));
	Tables.Add(tconvalidante);
	tconvalidante.defineKey("idconvalida", "idconvalidante", "idreg");

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
	tconvalida.defineColumn("!convalidante", typeof(string));
	tconvalida.defineColumn("!convalidato", typeof(string));
	tconvalida.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tconvalida);
	tconvalida.defineKey("idconvalida", "idreg");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ISTANZA /////////////////////////////////
	var tistanza= new MetaTable("istanza");
	tistanza.defineColumn("aa", typeof(string),false);
	tistanza.defineColumn("ct", typeof(DateTime),false);
	tistanza.defineColumn("cu", typeof(string),false);
	tistanza.defineColumn("data", typeof(DateTime),false);
	tistanza.defineColumn("extension", typeof(string));
	tistanza.defineColumn("idcorsostudio", typeof(int),false);
	tistanza.defineColumn("iddidprog", typeof(int),false);
	tistanza.defineColumn("idiscrizione", typeof(int),false);
	tistanza.defineColumn("idistanza", typeof(int),false);
	tistanza.defineColumn("idistanzakind", typeof(int),false);
	tistanza.defineColumn("idreg_studenti", typeof(int),false);
	tistanza.defineColumn("idstatuskind", typeof(int));
	tistanza.defineColumn("lt", typeof(DateTime),false);
	tistanza.defineColumn("lu", typeof(string),false);
	tistanza.defineColumn("paridistanza", typeof(int));
	tistanza.defineColumn("protanno", typeof(int));
	tistanza.defineColumn("protnumero", typeof(int));
	Tables.Add(tistanza);
	tistanza.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISTANZA_TRI /////////////////////////////////
	var tistanza_tri= new MetaTable("istanza_tri");
	tistanza_tri.defineColumn("aaprimaiscr", typeof(string));
	tistanza_tri.defineColumn("ct", typeof(DateTime),false);
	tistanza_tri.defineColumn("cu", typeof(string),false);
	tistanza_tri.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_tri.defineColumn("iddichiar_titolo", typeof(int));
	tistanza_tri.defineColumn("iddidprog", typeof(int),false);
	tistanza_tri.defineColumn("idiscrizione", typeof(int),false);
	tistanza_tri.defineColumn("idistanza", typeof(int),false);
	tistanza_tri.defineColumn("idistanzakind", typeof(int),false);
	tistanza_tri.defineColumn("idreg", typeof(int),false);
	tistanza_tri.defineColumn("idreg_istituti", typeof(int));
	tistanza_tri.defineColumn("lt", typeof(DateTime),false);
	tistanza_tri.defineColumn("lu", typeof(string),false);
	Tables.Add(tistanza_tri);
	tistanza_tri.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanza_tri.Columns["idistanza"], istanza_tri.Columns["idistanzakind"], istanza_tri.Columns["idreg"]};
	var cChild = new []{diniego_alias1.Columns["idistanza"], diniego_alias1.Columns["idistanzakind"], diniego_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias1_istanza_tri_idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{statuskinddefaultview.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskinddefaultview_idstatuskind",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{nullaosta.Columns["idcorsostudio"], nullaosta.Columns["iddidprog"], nullaosta.Columns["idiscrizione"], nullaosta.Columns["idistanza"], nullaosta.Columns["idistanzakind"], nullaosta.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{dichiartitolo_segview.Columns["iddichiar"]};
	cChild = new []{istanza_tri.Columns["iddichiar_titolo"]};
	Relations.Add(new DataRelation("FK_istanza_tri_dichiartitolo_segview_iddichiar_titolo",cPar,cChild,false));

	cPar = new []{registryaziendeview.Columns["idreg"]};
	cChild = new []{istanza_tri.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_istanza_tri_registryaziendeview_idreg_istituti",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{istanza.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_istanza_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idreg_studenti"]};
	cChild = new []{convalida.Columns["iddidprog"], convalida.Columns["idiscrizione"], convalida.Columns["idistanza"], convalida.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalida_istanza_iddidprog-idiscrizione-idistanza-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{attivform_alias1.Columns["idattivform"]};
	cChild = new []{convalidato.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_convalidato_attivform_alias1_idattivform",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidante.Columns["idconvalida"], convalidante.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidante_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{sostenimento.Columns["idsostenimento"]};
	cChild = new []{convalidante.Columns["idsostenimento"]};
	Relations.Add(new DataRelation("FK_convalidante_sostenimento_idsostenimento",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_registry_idreg",cPar,cChild,false));

	cPar = new []{attivform.Columns["idattivform"]};
	cChild = new []{sostenimento.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_sostenimento_attivform_idattivform",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_tri.Columns["idcorsostudio"], istanza_tri.Columns["iddidprog"], istanza_tri.Columns["idiscrizione"], istanza_tri.Columns["idistanza"], istanza_tri.Columns["idistanzakind"], istanza_tri.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_tri_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	#endregion

}
}
}
