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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_tru_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_istanza_tru_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias2 		=> (MetaTable)Tables["diniego_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta 		=> (MetaTable)Tables["nullaosta"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskinddefaultview 		=> (MetaTable)Tables["statuskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneattiveviewdefaultview 		=> (MetaTable)Tables["iscrizioneattiveviewdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_tru 		=> (MetaTable)Tables["istanza_tru"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanza_tru_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_tru_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_tru_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_tru_seg.xsd";

	#region create DataTables
	//////////////////// DINIEGO_ALIAS2 /////////////////////////////////
	var tdiniego_alias2= new MetaTable("diniego_alias2");
	tdiniego_alias2.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("cu", typeof(string),false);
	tdiniego_alias2.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego_alias2.defineColumn("iddidprog", typeof(int),false);
	tdiniego_alias2.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias2.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias2.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias2.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias2.defineColumn("idreg", typeof(int),false);
	tdiniego_alias2.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("lu", typeof(string),false);
	tdiniego_alias2.defineColumn("protanno", typeof(int));
	tdiniego_alias2.defineColumn("protnumero", typeof(int));
	tdiniego_alias2.ExtendedProperties["TableForReading"]="diniego";
	Tables.Add(tdiniego_alias2);
	tdiniego_alias2.defineKey("idcorsostudio", "iddidprog", "iddiniego", "idistanza", "idistanzakind", "idreg");

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
	Tables.Add(tnullaosta);
	tnullaosta.defineKey("idistanza", "idistanzakind", "idnullaosta", "idreg");

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

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("aa", typeof(string));
	tdidprogdefaultview.defineColumn("appellokind_title", typeof(string));
	tdidprogdefaultview.defineColumn("areadidattica_title", typeof(string));
	tdidprogdefaultview.defineColumn("convenzione_title", typeof(string));
	tdidprogdefaultview.defineColumn("corsostudio_annoistituz", typeof(int));
	tdidprogdefaultview.defineColumn("corsostudio_idcorsostudiokind", typeof(int));
	tdidprogdefaultview.defineColumn("corsostudio_idcorsostudiolivello", typeof(int));
	tdidprogdefaultview.defineColumn("corsostudio_title", typeof(string));
	tdidprogdefaultview.defineColumn("corsostudiokind_didprog_title", typeof(string));
	tdidprogdefaultview.defineColumn("corsostudiokind_title", typeof(string));
	tdidprogdefaultview.defineColumn("corsostudiolivello_didprog_title", typeof(string));
	tdidprogdefaultview.defineColumn("corsostudiolivello_title", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_annosolare", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_attribdebiti", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_ciclo", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_codice", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_codicemiur", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_dataconsmaxiscr", typeof(DateTime));
	tdidprogdefaultview.defineColumn("didprog_freqobbl", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_idcorsostudiokind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_idcorsostudiolivello", typeof(int));
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
	tdidprogdefaultview.defineColumn("geo_nationlang_lang", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlang2_lang", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlangvis_lang", typeof(string));
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
	tdidprogdefaultview.defineColumn("sessione_idappellokind", typeof(int));
	tdidprogdefaultview.defineColumn("sessione_idsessionekind", typeof(int));
	tdidprogdefaultview.defineColumn("sessione_start", typeof(DateTime));
	tdidprogdefaultview.defineColumn("sessione_stop", typeof(DateTime));
	tdidprogdefaultview.defineColumn("sessionekind_title", typeof(string));
	tdidprogdefaultview.defineColumn("title", typeof(string));
	tdidprogdefaultview.defineColumn("titolokind_title", typeof(string));
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ISCRIZIONEATTIVEVIEWDEFAULTVIEW /////////////////////////////////
	var tiscrizioneattiveviewdefaultview= new MetaTable("iscrizioneattiveviewdefaultview");
	tiscrizioneattiveviewdefaultview.defineColumn("aa", typeof(string),false);
	tiscrizioneattiveviewdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizioneattiveviewdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizioneattiveviewdefaultview.defineColumn("iddidprog", typeof(int),false);
	tiscrizioneattiveviewdefaultview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizioneattiveviewdefaultview.defineColumn("idreg", typeof(int),false);
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_anno", typeof(int));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_conseguimento_data", typeof(DateTime));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_dataconsmaxiscr", typeof(DateTime));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_decadenza_data", typeof(DateTime));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_didprog_aa", typeof(string));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_didprog_idsede", typeof(int));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_didprog_title", typeof(string));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_dropdown_title_int", typeof(string),false);
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_immatoltreauth", typeof(string));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_iscrizione_ct", typeof(DateTime),false);
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_iscrizione_cu", typeof(string),false);
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_iscrizione_data", typeof(DateTime));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_iscrizione_lt", typeof(DateTime),false);
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_iscrizione_lu", typeof(string),false);
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_iscrizione_matricola", typeof(string));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_last_renew_anno", typeof(int));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_last_renew_annofc", typeof(int));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_last_renew_annopt", typeof(int));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_registry_title", typeof(string));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_rinuncia_data", typeof(DateTime));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_sede_title", typeof(string));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_sospensione_data", typeof(DateTime));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_startiscrizioni", typeof(DateTime));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_status", typeof(string),false);
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_stopiscrizioni", typeof(DateTime));
	tiscrizioneattiveviewdefaultview.defineColumn("iscrizioneattiveview_trasferimento_data", typeof(DateTime));
	tiscrizioneattiveviewdefaultview.defineColumn("last_renew_aa", typeof(string));
	Tables.Add(tiscrizioneattiveviewdefaultview);
	tiscrizioneattiveviewdefaultview.defineKey("aa", "idcorsostudio", "iddidprog", "idiscrizione", "idreg");

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
	tistanza.defineColumn("idiscrizione", typeof(int));
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
	tistanza.defineKey("idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISTANZA_TRU /////////////////////////////////
	var tistanza_tru= new MetaTable("istanza_tru");
	tistanza_tru.defineColumn("ct", typeof(DateTime),false);
	tistanza_tru.defineColumn("cu", typeof(string),false);
	tistanza_tru.defineColumn("idistanza", typeof(int),false);
	tistanza_tru.defineColumn("idistanzakind", typeof(int),false);
	tistanza_tru.defineColumn("idreg", typeof(int),false);
	tistanza_tru.defineColumn("idreg_istituti", typeof(int),false);
	tistanza_tru.defineColumn("lt", typeof(DateTime),false);
	tistanza_tru.defineColumn("lu", typeof(string),false);
	Tables.Add(tistanza_tru);
	tistanza_tru.defineKey("idistanza", "idistanzakind", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	var cChild = new []{diniego_alias2.Columns["idistanza"], diniego_alias2.Columns["idistanzakind"], diniego_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias2_istanza_idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{nullaosta.Columns["idistanza"], nullaosta.Columns["idistanzakind"], nullaosta.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_istanza_idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{statuskinddefaultview.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskinddefaultview_idstatuskind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{istanza_tru.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_istanza_tru_registry_idreg_istituti",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{istanza.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{iscrizioneattiveviewdefaultview.Columns["idiscrizione"]};
	cChild = new []{istanza.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_istanza_iscrizioneattiveviewdefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{istanza.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_registrystudentiview_idreg_studenti",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_tru.Columns["idistanza"], istanza_tru.Columns["idistanzakind"], istanza_tru.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_tru_istanza_idistanza-idistanzakind-idreg",cPar,cChild,false));

	#endregion

}
}
}
