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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_conseg_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_istanza_conseg_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tesikeyword 		=> (MetaTable)Tables["tesikeyword"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tesi 		=> (MetaTable)Tables["tesi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable richitesi 		=> (MetaTable)Tables["richitesi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable relatorekind 		=> (MetaTable)Tables["relatorekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable relatore 		=> (MetaTable)Tables["relatore"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appellosegview 		=> (MetaTable)Tables["appellosegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskinddefaultview 		=> (MetaTable)Tables["statuskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_conseg 		=> (MetaTable)Tables["istanza_conseg"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanza_conseg_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_conseg_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_conseg_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_conseg_seg.xsd";

	#region create DataTables
	//////////////////// TESIKEYWORD /////////////////////////////////
	var ttesikeyword= new MetaTable("tesikeyword");
	ttesikeyword.defineColumn("ct", typeof(DateTime),false);
	ttesikeyword.defineColumn("cu", typeof(string),false);
	ttesikeyword.defineColumn("idistanza", typeof(int),false);
	ttesikeyword.defineColumn("idnation_lang", typeof(int));
	ttesikeyword.defineColumn("idreg", typeof(int),false);
	ttesikeyword.defineColumn("idrichitesi", typeof(int),false);
	ttesikeyword.defineColumn("idtesi", typeof(int),false);
	ttesikeyword.defineColumn("idtesikeyword", typeof(int),false);
	ttesikeyword.defineColumn("keyword", typeof(int),false);
	ttesikeyword.defineColumn("lang", typeof(string));
	ttesikeyword.defineColumn("lt", typeof(DateTime),false);
	ttesikeyword.defineColumn("lu", typeof(string),false);
	Tables.Add(ttesikeyword);
	ttesikeyword.defineKey("idistanza", "idreg", "idrichitesi", "idtesi", "idtesikeyword");

	//////////////////// TESI /////////////////////////////////
	var ttesi= new MetaTable("tesi");
	ttesi.defineColumn("aa", typeof(string));
	ttesi.defineColumn("abstract", typeof(string));
	ttesi.defineColumn("abstract_en", typeof(string));
	ttesi.defineColumn("ct", typeof(DateTime),false);
	ttesi.defineColumn("cu", typeof(string),false);
	ttesi.defineColumn("filestatus", typeof(string));
	ttesi.defineColumn("idattach", typeof(int));
	ttesi.defineColumn("idinsegn", typeof(int));
	ttesi.defineColumn("idistanza", typeof(int),false);
	ttesi.defineColumn("idreg", typeof(int),false);
	ttesi.defineColumn("idrichitesi", typeof(int),false);
	ttesi.defineColumn("idtesi", typeof(int),false);
	ttesi.defineColumn("idtesikind", typeof(int));
	ttesi.defineColumn("lt", typeof(DateTime),false);
	ttesi.defineColumn("lu", typeof(string),false);
	ttesi.defineColumn("title", typeof(string));
	ttesi.defineColumn("title_en", typeof(string));
	Tables.Add(ttesi);
	ttesi.defineKey("idistanza", "idreg", "idrichitesi", "idtesi");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// RICHITESI /////////////////////////////////
	var trichitesi= new MetaTable("richitesi");
	trichitesi.defineColumn("accettata", typeof(string));
	trichitesi.defineColumn("ct", typeof(DateTime),false);
	trichitesi.defineColumn("cu", typeof(string),false);
	trichitesi.defineColumn("idistanza", typeof(int),false);
	trichitesi.defineColumn("idreg", typeof(int),false);
	trichitesi.defineColumn("idreg_docenti", typeof(int),false);
	trichitesi.defineColumn("idrichitesi", typeof(int),false);
	trichitesi.defineColumn("lt", typeof(DateTime),false);
	trichitesi.defineColumn("lu", typeof(string),false);
	trichitesi.defineColumn("!idreg_docenti_registry_title", typeof(string));
	trichitesi.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(trichitesi);
	trichitesi.defineKey("idistanza", "idreg", "idrichitesi");

	//////////////////// RELATOREKIND /////////////////////////////////
	var trelatorekind= new MetaTable("relatorekind");
	trelatorekind.defineColumn("active", typeof(string),false);
	trelatorekind.defineColumn("idrelatorekind", typeof(int),false);
	trelatorekind.defineColumn("title", typeof(string),false);
	Tables.Add(trelatorekind);
	trelatorekind.defineKey("idrelatorekind");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// RELATORE /////////////////////////////////
	var trelatore= new MetaTable("relatore");
	trelatore.defineColumn("ct", typeof(DateTime),false);
	trelatore.defineColumn("cu", typeof(string),false);
	trelatore.defineColumn("idistanza", typeof(int),false);
	trelatore.defineColumn("idreg", typeof(int),false);
	trelatore.defineColumn("idreg_docenti", typeof(int));
	trelatore.defineColumn("idrelatore", typeof(int),false);
	trelatore.defineColumn("idrelatorekind", typeof(int));
	trelatore.defineColumn("lt", typeof(DateTime),false);
	trelatore.defineColumn("lu", typeof(string),false);
	trelatore.defineColumn("!idreg_docenti_registry_title", typeof(string));
	trelatore.defineColumn("!idrelatorekind_relatorekind_title", typeof(string));
	trelatore.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(trelatore);
	trelatore.defineKey("idistanza", "idreg", "idrelatore");

	//////////////////// APPELLOSEGVIEW /////////////////////////////////
	var tappellosegview= new MetaTable("appellosegview");
	tappellosegview.defineColumn("dropdown_title", typeof(string),false);
	tappellosegview.defineColumn("idappello", typeof(int),false);
	Tables.Add(tappellosegview);
	tappellosegview.defineKey("idappello");

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
	tistanza.defineColumn("idcorsostudio", typeof(int));
	tistanza.defineColumn("iddidprog", typeof(int));
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

	//////////////////// ISTANZA_CONSEG /////////////////////////////////
	var tistanza_conseg= new MetaTable("istanza_conseg");
	tistanza_conseg.defineColumn("ct", typeof(DateTime),false);
	tistanza_conseg.defineColumn("cu", typeof(string),false);
	tistanza_conseg.defineColumn("datacompalmalaur", typeof(DateTime));
	tistanza_conseg.defineColumn("fascicolo", typeof(string));
	tistanza_conseg.defineColumn("idappello", typeof(int));
	tistanza_conseg.defineColumn("idistanza", typeof(int),false);
	tistanza_conseg.defineColumn("idistanzakind", typeof(int),false);
	tistanza_conseg.defineColumn("idreg", typeof(int),false);
	tistanza_conseg.defineColumn("idrichitesi", typeof(int));
	tistanza_conseg.defineColumn("lt", typeof(DateTime),false);
	tistanza_conseg.defineColumn("lu", typeof(string),false);
	tistanza_conseg.defineColumn("posizione", typeof(string));
	Tables.Add(tistanza_conseg);
	tistanza_conseg.defineKey("idistanza", "idistanzakind", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idreg_studenti"]};
	var cChild = new []{richitesi.Columns["idistanza"], richitesi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_richitesi_istanza_idistanza-idreg",cPar,cChild,false));

	cPar = new []{richitesi.Columns["idistanza"], richitesi.Columns["idreg"], richitesi.Columns["idrichitesi"]};
	cChild = new []{tesi.Columns["idistanza"], tesi.Columns["idreg"], tesi.Columns["idrichitesi"]};
	Relations.Add(new DataRelation("FK_tesi_richitesi_idistanza-idreg-idrichitesi",cPar,cChild,false));

	cPar = new []{tesi.Columns["idistanza"], tesi.Columns["idreg"], tesi.Columns["idrichitesi"], tesi.Columns["idtesi"]};
	cChild = new []{tesikeyword.Columns["idistanza"], tesikeyword.Columns["idreg"], tesikeyword.Columns["idrichitesi"], tesikeyword.Columns["idtesi"]};
	Relations.Add(new DataRelation("FK_tesikeyword_tesi_idistanza-idreg-idrichitesi-idtesi",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{richitesi.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_richitesi_registry_alias1_idreg_docenti",cPar,cChild,false));

	cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idreg_studenti"]};
	cChild = new []{relatore.Columns["idistanza"], relatore.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_relatore_istanza_idistanza-idreg",cPar,cChild,false));

	cPar = new []{relatorekind.Columns["idrelatorekind"]};
	cChild = new []{relatore.Columns["idrelatorekind"]};
	Relations.Add(new DataRelation("FK_relatore_relatorekind_idrelatorekind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{relatore.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_relatore_registry_idreg_docenti",cPar,cChild,false));

	cPar = new []{appellosegview.Columns["idappello"]};
	cChild = new []{istanza_conseg.Columns["idappello"]};
	Relations.Add(new DataRelation("FK_istanza_conseg_appellosegview_idappello",cPar,cChild,false));

	cPar = new []{statuskinddefaultview.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskinddefaultview_idstatuskind",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{istanza.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{istanza.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_istanza_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{istanza.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_registrystudentiview_idreg_studenti",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_conseg.Columns["idistanza"], istanza_conseg.Columns["idistanzakind"], istanza_conseg.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_conseg_istanza_idistanza-idistanzakind-idreg",cPar,cChild,false));

	#endregion

}
}
}
