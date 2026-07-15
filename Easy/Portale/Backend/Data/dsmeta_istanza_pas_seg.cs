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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_pas_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_istanza_pas_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidante 		=> (MetaTable)Tables["convalidante"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta 		=> (MetaTable)Tables["nullaosta"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias4 		=> (MetaTable)Tables["diniego_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzaimm_segview_alias1 		=> (MetaTable)Tables["istanzaimm_segview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskinddefaultview 		=> (MetaTable)Tables["statuskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneseganagstuview_alias1 		=> (MetaTable)Tables["iscrizioneseganagstuview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneseganagstuview 		=> (MetaTable)Tables["iscrizioneseganagstuview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_pas 		=> (MetaTable)Tables["istanza_pas"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanza_pas_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_pas_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_pas_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_pas_seg.xsd";

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
	tconvalida.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tconvalida);
	tconvalida.defineKey("idconvalida", "idreg");

	//////////////////// STATUSKIND /////////////////////////////////
	var tstatuskind= new MetaTable("statuskind");
	tstatuskind.defineColumn("ct", typeof(DateTime),false);
	tstatuskind.defineColumn("cu", typeof(string),false);
	tstatuskind.defineColumn("delibera", typeof(string),false);
	tstatuskind.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind.defineColumn("istanze", typeof(string),false);
	tstatuskind.defineColumn("istanzedelibera", typeof(string),false);
	tstatuskind.defineColumn("lt", typeof(DateTime),false);
	tstatuskind.defineColumn("lu", typeof(string),false);
	tstatuskind.defineColumn("pratica", typeof(string),false);
	tstatuskind.defineColumn("sortcode", typeof(int),false);
	tstatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskind);
	tstatuskind.defineKey("idstatuskind");

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
	tpratica.defineColumn("!idiscrizione_from_iscrizione_anno", typeof(int));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_aa", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_iddidprog_title", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_iddidprog_aa", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_iddidprog_idsede", typeof(int));
	tpratica.defineColumn("!idstatuskind_statuskind_title", typeof(string));
	Tables.Add(tpratica);
	tpratica.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// NULLAOSTA /////////////////////////////////
	var tnullaosta= new MetaTable("nullaosta");
	tnullaosta.defineColumn("ct", typeof(DateTime),false);
	tnullaosta.defineColumn("cu", typeof(string),false);
	tnullaosta.defineColumn("data", typeof(DateTime),false);
	tnullaosta.defineColumn("extension", typeof(string));
	tnullaosta.defineColumn("idcorsostudio", typeof(int));
	tnullaosta.defineColumn("iddidprog", typeof(int));
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
	tnullaosta.defineKey("idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// DINIEGO_ALIAS4 /////////////////////////////////
	var tdiniego_alias4= new MetaTable("diniego_alias4");
	tdiniego_alias4.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias4.defineColumn("cu", typeof(string),false);
	tdiniego_alias4.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias4.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego_alias4.defineColumn("iddidprog", typeof(int));
	tdiniego_alias4.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias4.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias4.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias4.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias4.defineColumn("idreg", typeof(int),false);
	tdiniego_alias4.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias4.defineColumn("lu", typeof(string),false);
	tdiniego_alias4.defineColumn("protanno", typeof(int));
	tdiniego_alias4.defineColumn("protnumero", typeof(int));
	tdiniego_alias4.ExtendedProperties["TableForReading"]="diniego";
	tdiniego_alias4.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tdiniego_alias4);
	tdiniego_alias4.defineKey("idcorsostudio", "iddiniego", "idistanza", "idistanzakind", "idreg");

	//////////////////// ISTANZAIMM_SEGVIEW_ALIAS1 /////////////////////////////////
	var tistanzaimm_segview_alias1= new MetaTable("istanzaimm_segview_alias1");
	tistanzaimm_segview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tistanzaimm_segview_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tistanzaimm_segview_alias1.defineColumn("iddidprog", typeof(int),false);
	tistanzaimm_segview_alias1.defineColumn("idistanza", typeof(int),false);
	tistanzaimm_segview_alias1.defineColumn("idistanzakind", typeof(int),false);
	tistanzaimm_segview_alias1.defineColumn("idreg_studenti", typeof(int),false);
	tistanzaimm_segview_alias1.ExtendedProperties["TableForReading"]="istanzaimm_segview";
	Tables.Add(tistanzaimm_segview_alias1);
	tistanzaimm_segview_alias1.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti");

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

	//////////////////// ISCRIZIONESEGANAGSTUVIEW_ALIAS1 /////////////////////////////////
	var tiscrizioneseganagstuview_alias1= new MetaTable("iscrizioneseganagstuview_alias1");
	tiscrizioneseganagstuview_alias1.defineColumn("aa", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("didprog_aa", typeof(string));
	tiscrizioneseganagstuview_alias1.defineColumn("didprog_idsede", typeof(int));
	tiscrizioneseganagstuview_alias1.defineColumn("didprog_title", typeof(string));
	tiscrizioneseganagstuview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iddidprog", typeof(int),false);
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
	tiscrizioneseganagstuview_alias1.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idsede", typeof(int),false);
	tdidprog.defineColumn("title", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

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

	//////////////////// ISTANZA_PAS /////////////////////////////////
	var tistanza_pas= new MetaTable("istanza_pas");
	tistanza_pas.defineColumn("ct", typeof(DateTime),false);
	tistanza_pas.defineColumn("cu", typeof(string),false);
	tistanza_pas.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_pas.defineColumn("iddidprog", typeof(int),false);
	tistanza_pas.defineColumn("idiscrizione", typeof(int),false);
	tistanza_pas.defineColumn("idiscrizione_from", typeof(int));
	tistanza_pas.defineColumn("idistanza", typeof(int),false);
	tistanza_pas.defineColumn("idistanzakind", typeof(int),false);
	tistanza_pas.defineColumn("idreg", typeof(int),false);
	tistanza_pas.defineColumn("lt", typeof(DateTime),false);
	tistanza_pas.defineColumn("lu", typeof(string),false);
	Tables.Add(tistanza_pas);
	tistanza_pas.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	var cChild = new []{pratica.Columns["idcorsostudio"], pratica.Columns["iddidprog"], pratica.Columns["idiscrizione"], pratica.Columns["idistanza"], pratica.Columns["idistanzakind"], pratica.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pratica_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{pratica.Columns["idreg"], pratica.Columns["iddidprog"], pratica.Columns["idiscrizione"], pratica.Columns["idiscrizione_from"], pratica.Columns["idistanza"], pratica.Columns["idpratica"]};
	cChild = new []{convalida.Columns["idreg"], convalida.Columns["iddidprog"], convalida.Columns["idiscrizione"], convalida.Columns["idiscrizione_from"], convalida.Columns["idistanza"], convalida.Columns["idpratica"]};
	Relations.Add(new DataRelation("FK_convalida_pratica_idreg-iddidprog-idiscrizione-idiscrizione_from-idistanza-idpratica",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidante.Columns["idconvalida"], convalidante.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidante_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{pratica.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_pratica_statuskind_idstatuskind",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizione_idiscrizione_from",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{nullaosta.Columns["idcorsostudio"], nullaosta.Columns["iddidprog"], nullaosta.Columns["idiscrizione"], nullaosta.Columns["idistanza"], nullaosta.Columns["idistanzakind"], nullaosta.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{diniego_alias4.Columns["idcorsostudio"], diniego_alias4.Columns["iddidprog"], diniego_alias4.Columns["idiscrizione"], diniego_alias4.Columns["idistanza"], diniego_alias4.Columns["idistanzakind"], diniego_alias4.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias4_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanzaimm_segview_alias1.Columns["idistanza"]};
	cChild = new []{istanza.Columns["paridistanza"]};
	Relations.Add(new DataRelation("FK_istanza_istanzaimm_segview_alias1_paridistanza",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{istanzaimm_segview_alias1.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanzaimm_segview_alias1_registrystudentiview_idreg",cPar,cChild,false));

	cPar = new []{statuskinddefaultview.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskinddefaultview_idstatuskind",cPar,cChild,false));

	cPar = new []{iscrizioneseganagstuview_alias1.Columns["idiscrizione"]};
	cChild = new []{istanza.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_istanza_iscrizioneseganagstuview_alias1_idiscrizione",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{istanza.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{iscrizioneseganagstuview.Columns["idiscrizione"]};
	cChild = new []{istanza_pas.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_istanza_pas_iscrizioneseganagstuview_idiscrizione_from",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{istanza.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_registrystudentiview_idreg_studenti",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_pas.Columns["idcorsostudio"], istanza_pas.Columns["iddidprog"], istanza_pas.Columns["idiscrizione"], istanza_pas.Columns["idistanza"], istanza_pas.Columns["idistanzakind"], istanza_pas.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_pas_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	#endregion

}
}
}
