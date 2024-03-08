
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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_rein_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_istanza_rein_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidante 		=> (MetaTable)Tables["convalidante"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudio 		=> (MetaTable)Tables["titolostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istattitolistudio 		=> (MetaTable)Tables["istattitolistudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind_alias1 		=> (MetaTable)Tables["statuskind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarkind 		=> (MetaTable)Tables["dichiarkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias3 		=> (MetaTable)Tables["diniego_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta_alias4 		=> (MetaTable)Tables["nullaosta_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudiodocentiview 		=> (MetaTable)Tables["titolostudiodocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview_alias1 		=> (MetaTable)Tables["iscrizionedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzaseganagstusonpreview 		=> (MetaTable)Tables["istanzaseganagstusonpreview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_rein 		=> (MetaTable)Tables["istanza_rein"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanza_rein_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_rein_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_rein_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_rein_seg.xsd";

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
	Tables.Add(tconvalida);
	tconvalida.defineKey("idconvalida", "idreg");

	//////////////////// TITOLOSTUDIO /////////////////////////////////
	var ttitolostudio= new MetaTable("titolostudio");
	ttitolostudio.defineColumn("aa", typeof(string),false);
	ttitolostudio.defineColumn("idistattitolistudio", typeof(int),false);
	ttitolostudio.defineColumn("idreg", typeof(int),false);
	ttitolostudio.defineColumn("idtitolostudio", typeof(int),false);
	ttitolostudio.defineColumn("voto", typeof(int));
	ttitolostudio.defineColumn("votolode", typeof(string));
	ttitolostudio.defineColumn("votosu", typeof(int));
	Tables.Add(ttitolostudio);
	ttitolostudio.defineKey("idreg", "idtitolostudio");

	//////////////////// ISTATTITOLISTUDIO /////////////////////////////////
	var tistattitolistudio= new MetaTable("istattitolistudio");
	tistattitolistudio.defineColumn("idistattitolistudio", typeof(int),false);
	tistattitolistudio.defineColumn("titolo", typeof(string),false);
	Tables.Add(tistattitolistudio);
	tistattitolistudio.defineKey("idistattitolistudio");

	//////////////////// STATUSKIND_ALIAS1 /////////////////////////////////
	var tstatuskind_alias1= new MetaTable("statuskind_alias1");
	tstatuskind_alias1.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind_alias1.defineColumn("title", typeof(string),false);
	tstatuskind_alias1.ExtendedProperties["TableForReading"]="statuskind";
	Tables.Add(tstatuskind_alias1);
	tstatuskind_alias1.defineKey("idstatuskind");

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

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

	//////////////////// DICHIARKIND /////////////////////////////////
	var tdichiarkind= new MetaTable("dichiarkind");
	tdichiarkind.defineColumn("iddichiarkind", typeof(int),false);
	tdichiarkind.defineColumn("title", typeof(string),false);
	Tables.Add(tdichiarkind);
	tdichiarkind.defineKey("iddichiarkind");

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
	tpratica.defineColumn("!iddichiar_dichiar_aa", typeof(string));
	tpratica.defineColumn("!iddichiar_dichiar_date", typeof(DateTime));
	tpratica.defineColumn("!iddichiar_dichiar_iddichiarkind_title", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_anno", typeof(int));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_aa", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_iddidprog_title", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_iddidprog_aa", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_iddidprog_idsede", typeof(int));
	tpratica.defineColumn("!idstatuskind_statuskind_title", typeof(string));
	tpratica.defineColumn("!idtitolostudio_titolostudio_voto", typeof(int));
	tpratica.defineColumn("!idtitolostudio_titolostudio_votosu", typeof(int));
	tpratica.defineColumn("!idtitolostudio_titolostudio_votolode", typeof(string));
	tpratica.defineColumn("!idtitolostudio_titolostudio_aa", typeof(string));
	tpratica.defineColumn("!idtitolostudio_titolostudio_idistattitolistudio_titolo", typeof(string));
	Tables.Add(tpratica);
	tpratica.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// DINIEGO_ALIAS3 /////////////////////////////////
	var tdiniego_alias3= new MetaTable("diniego_alias3");
	tdiniego_alias3.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias3.defineColumn("cu", typeof(string),false);
	tdiniego_alias3.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego_alias3.defineColumn("iddidprog", typeof(int));
	tdiniego_alias3.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias3.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias3.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias3.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias3.defineColumn("idreg", typeof(int),false);
	tdiniego_alias3.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias3.defineColumn("lu", typeof(string),false);
	tdiniego_alias3.defineColumn("protanno", typeof(int));
	tdiniego_alias3.defineColumn("protnumero", typeof(int));
	tdiniego_alias3.ExtendedProperties["TableForReading"]="diniego";
	Tables.Add(tdiniego_alias3);
	tdiniego_alias3.defineKey("idcorsostudio", "iddiniego", "idistanza", "idistanzakind", "idreg");

	//////////////////// NULLAOSTA_ALIAS4 /////////////////////////////////
	var tnullaosta_alias4= new MetaTable("nullaosta_alias4");
	tnullaosta_alias4.defineColumn("ct", typeof(DateTime),false);
	tnullaosta_alias4.defineColumn("cu", typeof(string),false);
	tnullaosta_alias4.defineColumn("data", typeof(DateTime),false);
	tnullaosta_alias4.defineColumn("extension", typeof(string));
	tnullaosta_alias4.defineColumn("idcorsostudio", typeof(int));
	tnullaosta_alias4.defineColumn("iddidprog", typeof(int));
	tnullaosta_alias4.defineColumn("idiscrizione", typeof(int));
	tnullaosta_alias4.defineColumn("idistanza", typeof(int),false);
	tnullaosta_alias4.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta_alias4.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta_alias4.defineColumn("idreg", typeof(int),false);
	tnullaosta_alias4.defineColumn("lt", typeof(DateTime),false);
	tnullaosta_alias4.defineColumn("lu", typeof(string),false);
	tnullaosta_alias4.defineColumn("protanno", typeof(int));
	tnullaosta_alias4.defineColumn("protnumero", typeof(int));
	tnullaosta_alias4.ExtendedProperties["TableForReading"]="nullaosta";
	Tables.Add(tnullaosta_alias4);
	tnullaosta_alias4.defineKey("idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// TITOLOSTUDIODOCENTIVIEW /////////////////////////////////
	var ttitolostudiodocentiview= new MetaTable("titolostudiodocentiview");
	ttitolostudiodocentiview.defineColumn("aa", typeof(string),false);
	ttitolostudiodocentiview.defineColumn("dropdown_title", typeof(string),false);
	ttitolostudiodocentiview.defineColumn("idattach", typeof(int));
	ttitolostudiodocentiview.defineColumn("idistattitolistudio", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("idreg", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("idreg_istituti", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("idtitolostudio", typeof(int),false);
	Tables.Add(ttitolostudiodocentiview);
	ttitolostudiodocentiview.defineKey("idtitolostudio");

	//////////////////// ISCRIZIONEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tiscrizionedefaultview_alias1= new MetaTable("iscrizionedefaultview_alias1");
	tiscrizionedefaultview_alias1.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("anno", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("annoaccademico_aa", typeof(string));
	tiscrizionedefaultview_alias1.defineColumn("didprog_title", typeof(string));
	tiscrizionedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview_alias1.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizionedefaultview_alias1.defineColumn("registry_title", typeof(string));
	tiscrizionedefaultview_alias1.defineColumn("sede_title", typeof(string));
	tiscrizionedefaultview_alias1.ExtendedProperties["TableForReading"]="iscrizionedefaultview";
	Tables.Add(tiscrizionedefaultview_alias1);
	tiscrizionedefaultview_alias1.defineKey("idiscrizione");

	//////////////////// ISTANZASEGANAGSTUSONPREVIEW /////////////////////////////////
	var tistanzaseganagstusonpreview= new MetaTable("istanzaseganagstusonpreview");
	tistanzaseganagstusonpreview.defineColumn("aa", typeof(string),false);
	tistanzaseganagstusonpreview.defineColumn("dropdown_title", typeof(string),false);
	tistanzaseganagstusonpreview.defineColumn("idcorsostudio", typeof(int));
	tistanzaseganagstusonpreview.defineColumn("iddidprog", typeof(int));
	tistanzaseganagstusonpreview.defineColumn("idistanza", typeof(int),false);
	tistanzaseganagstusonpreview.defineColumn("idistanzakind", typeof(int),false);
	tistanzaseganagstusonpreview.defineColumn("idreg_studenti", typeof(int),false);
	tistanzaseganagstusonpreview.defineColumn("paridistanza", typeof(int));
	Tables.Add(tistanzaseganagstusonpreview);
	tistanzaseganagstusonpreview.defineKey("idistanza");

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

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("aa", typeof(string));
	tdidprogdefaultview.defineColumn("areadidattica_title", typeof(string));
	tdidprogdefaultview.defineColumn("convenzione_title", typeof(string));
	tdidprogdefaultview.defineColumn("corsostudio_annoistituz", typeof(int));
	tdidprogdefaultview.defineColumn("corsostudio_title", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_annosolare", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_attribdebiti", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_ciclo", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_codice", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_codicemiur", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_dataconsmaxiscr", typeof(DateTime));
	tdidprogdefaultview.defineColumn("didprog_freqobbl", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_iddidprognumchiusokind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_iddidprogsuddannokind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_iderogazkind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_idsede", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_idtitolokind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_immatoltreauth", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_modaccesso", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_modaccesso_en", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_obbformativi", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_obbformativi_en", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_preimmatoltreauth", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_progesamamm", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_prospoccupaz", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_provafinaledesc", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_regolamentotax", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_regolamentotaxurl", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_startiscrizioni", typeof(DateTime));
	tdidprogdefaultview.defineColumn("didprog_stopiscrizioni", typeof(DateTime));
	tdidprogdefaultview.defineColumn("didprog_title_en", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_utenzasost", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_website", typeof(string));
	tdidprogdefaultview.defineColumn("didprognumchiusokind_title", typeof(string));
	tdidprogdefaultview.defineColumn("didprogsuddannokind_title", typeof(string));
	tdidprogdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdefaultview.defineColumn("erogazkind_title", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlang_title", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlang2_title", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlangvis_title", typeof(string));
	tdidprogdefaultview.defineColumn("graduatoria_title", typeof(string));
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
	tdidprogdefaultview.defineColumn("registrydocenti_title", typeof(string));
	tdidprogdefaultview.defineColumn("sede_title", typeof(string));
	tdidprogdefaultview.defineColumn("sessione_start", typeof(DateTime));
	tdidprogdefaultview.defineColumn("sessione_stop", typeof(DateTime));
	tdidprogdefaultview.defineColumn("sessionekind_title", typeof(string));
	tdidprogdefaultview.defineColumn("title", typeof(string));
	tdidprogdefaultview.defineColumn("titolokind_title", typeof(string));
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("iddidprog");

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudiolivello", typeof(int));
	tcorsostudiodefaultview.defineColumn("idcorsostudionorma", typeof(int));
	tcorsostudiodefaultview.defineColumn("idstruttura", typeof(int));
	Tables.Add(tcorsostudiodefaultview);
	tcorsostudiodefaultview.defineKey("idcorsostudio");

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
	tistanza.defineColumn("protanno", typeof(int),false);
	tistanza.defineColumn("protnumero", typeof(int),false);
	Tables.Add(tistanza);
	tistanza.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISTANZA_REIN /////////////////////////////////
	var tistanza_rein= new MetaTable("istanza_rein");
	tistanza_rein.defineColumn("aa_rindec", typeof(string));
	tistanza_rein.defineColumn("ct", typeof(DateTime),false);
	tistanza_rein.defineColumn("cu", typeof(string),false);
	tistanza_rein.defineColumn("darindec", typeof(string));
	tistanza_rein.defineColumn("datarindec", typeof(DateTime));
	tistanza_rein.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_rein.defineColumn("iddidprog", typeof(int),false);
	tistanza_rein.defineColumn("idiscrizione", typeof(int),false);
	tistanza_rein.defineColumn("idiscrizione_from", typeof(int));
	tistanza_rein.defineColumn("idistanza", typeof(int),false);
	tistanza_rein.defineColumn("idistanzakind", typeof(int),false);
	tistanza_rein.defineColumn("idreg", typeof(int),false);
	tistanza_rein.defineColumn("idtitolostudio", typeof(int));
	tistanza_rein.defineColumn("lt", typeof(DateTime),false);
	tistanza_rein.defineColumn("lu", typeof(string),false);
	Tables.Add(tistanza_rein);
	tistanza_rein.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	var cChild = new []{pratica.Columns["idcorsostudio"], pratica.Columns["iddidprog"], pratica.Columns["idiscrizione"], pratica.Columns["idistanza"], pratica.Columns["idistanzakind"], pratica.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pratica_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{pratica.Columns["iddidprog"], pratica.Columns["idiscrizione"], pratica.Columns["idistanza"], pratica.Columns["idpratica"], pratica.Columns["idreg"], pratica.Columns["iddichiar"], pratica.Columns["idiscrizione_from"]};
	cChild = new []{convalida.Columns["iddidprog"], convalida.Columns["idiscrizione"], convalida.Columns["idistanza"], convalida.Columns["idpratica"], convalida.Columns["idreg"], convalida.Columns["iddichiar"], convalida.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_convalida_pratica_iddidprog-idiscrizione-idistanza-idpratica-idreg-iddichiar-idiscrizione_from-",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidante.Columns["idconvalida"], convalidante.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidante_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{titolostudio.Columns["idtitolostudio"]};
	cChild = new []{pratica.Columns["idtitolostudio"]};
	Relations.Add(new DataRelation("FK_pratica_titolostudio_idtitolostudio",cPar,cChild,false));

	cPar = new []{istattitolistudio.Columns["idistattitolistudio"]};
	cChild = new []{titolostudio.Columns["idistattitolistudio"]};
	Relations.Add(new DataRelation("FK_titolostudio_istattitolistudio_idistattitolistudio",cPar,cChild,false));

	cPar = new []{statuskind_alias1.Columns["idstatuskind"]};
	cChild = new []{pratica.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_pratica_statuskind_alias1_idstatuskind",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizione_idiscrizione_from",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{dichiar.Columns["iddichiar"]};
	cChild = new []{pratica.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_pratica_dichiar_iddichiar",cPar,cChild,false));

	cPar = new []{dichiarkind.Columns["iddichiarkind"]};
	cChild = new []{dichiar.Columns["iddichiarkind"]};
	Relations.Add(new DataRelation("FK_dichiar_dichiarkind_iddichiarkind",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{diniego_alias3.Columns["idcorsostudio"], diniego_alias3.Columns["iddidprog"], diniego_alias3.Columns["idiscrizione"], diniego_alias3.Columns["idistanza"], diniego_alias3.Columns["idistanzakind"], diniego_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias3_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{nullaosta_alias4.Columns["idcorsostudio"], nullaosta_alias4.Columns["iddidprog"], nullaosta_alias4.Columns["idiscrizione"], nullaosta_alias4.Columns["idistanza"], nullaosta_alias4.Columns["idistanzakind"], nullaosta_alias4.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_alias4_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{titolostudiodocentiview.Columns["idtitolostudio"]};
	cChild = new []{istanza_rein.Columns["idtitolostudio"]};
	Relations.Add(new DataRelation("FK_istanza_rein_titolostudiodocentiview_idtitolostudio",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview_alias1.Columns["idiscrizione"]};
	cChild = new []{istanza_rein.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_istanza_rein_iscrizionedefaultview_alias1_idiscrizione_from",cPar,cChild,false));

	cPar = new []{istanzaseganagstusonpreview.Columns["idistanza"]};
	cChild = new []{istanza.Columns["paridistanza"]};
	Relations.Add(new DataRelation("FK_istanza_istanzaseganagstusonpreview_paridistanza",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskind_idstatuskind",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{istanza.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_registrystudentiview_idreg_studenti",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{istanza.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_istanza_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{istanza.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{istanza.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_istanza_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_rein.Columns["idcorsostudio"], istanza_rein.Columns["iddidprog"], istanza_rein.Columns["idiscrizione"], istanza_rein.Columns["idistanza"], istanza_rein.Columns["idistanzakind"], istanza_rein.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_rein_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg-",cPar,cChild,false));

	#endregion

}
}
}
