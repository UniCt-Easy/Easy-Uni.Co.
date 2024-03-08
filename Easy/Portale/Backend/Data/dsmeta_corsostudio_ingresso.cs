
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
[System.Xml.Serialization.XmlRoot("dsmeta_corsostudio_ingresso"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_corsostudio_ingresso: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoriaesitipos 		=> (MetaTable)Tables["graduatoriaesitipos"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoriaesiti 		=> (MetaTable)Tables["graduatoriaesiti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable commissregistry_docenti 		=> (MetaTable)Tables["commissregistry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable commiss 		=> (MetaTable)Tables["commiss"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable provaaula 		=> (MetaTable)Tables["provaaula"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prova 		=> (MetaTable)Tables["prova"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias2 		=> (MetaTable)Tables["annoaccademico_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog_alias2 		=> (MetaTable)Tables["didprog_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogaccesso 		=> (MetaTable)Tables["didprogaccesso"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolokinddefaultview 		=> (MetaTable)Tables["titolokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sessionedefaultview 		=> (MetaTable)Tables["sessionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sededefaultview 		=> (MetaTable)Tables["sededefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias2 		=> (MetaTable)Tables["geo_nation_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias1 		=> (MetaTable)Tables["geo_nation_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoria 		=> (MetaTable)Tables["graduatoria"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogsuddannokind 		=> (MetaTable)Tables["didprogsuddannokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprognumchiusokind 		=> (MetaTable)Tables["didprognumchiusokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudio 		=> (MetaTable)Tables["corsostudio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_corsostudio_ingresso(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_corsostudio_ingresso (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_corsostudio_ingresso";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_corsostudio_ingresso.xsd";

	#region create DataTables
	//////////////////// GRADUATORIAESITIPOS /////////////////////////////////
	var tgraduatoriaesitipos= new MetaTable("graduatoriaesitipos");
	tgraduatoriaesitipos.defineColumn("ct", typeof(DateTime),false);
	tgraduatoriaesitipos.defineColumn("cu", typeof(string),false);
	tgraduatoriaesitipos.defineColumn("idcorsostudio", typeof(int),false);
	tgraduatoriaesitipos.defineColumn("idgraduatoriaesiti", typeof(int),false);
	tgraduatoriaesitipos.defineColumn("idgraduatoriaesitipos", typeof(int),false);
	tgraduatoriaesitipos.defineColumn("idreg_studenti", typeof(int));
	tgraduatoriaesitipos.defineColumn("idtipologiastudente", typeof(int));
	tgraduatoriaesitipos.defineColumn("lt", typeof(DateTime),false);
	tgraduatoriaesitipos.defineColumn("lu", typeof(string),false);
	tgraduatoriaesitipos.defineColumn("pos", typeof(int));
	tgraduatoriaesitipos.defineColumn("punteggio", typeof(decimal));
	Tables.Add(tgraduatoriaesitipos);
	tgraduatoriaesitipos.defineKey("idcorsostudio", "idgraduatoriaesiti", "idgraduatoriaesitipos");

	//////////////////// GRADUATORIAESITI /////////////////////////////////
	var tgraduatoriaesiti= new MetaTable("graduatoriaesiti");
	tgraduatoriaesiti.defineColumn("ct", typeof(DateTime),false);
	tgraduatoriaesiti.defineColumn("cu", typeof(string),false);
	tgraduatoriaesiti.defineColumn("datachiusura", typeof(DateTime));
	tgraduatoriaesiti.defineColumn("idcorsostudio", typeof(int),false);
	tgraduatoriaesiti.defineColumn("idgraduatoria", typeof(int),false);
	tgraduatoriaesiti.defineColumn("idgraduatoriaesiti", typeof(int),false);
	tgraduatoriaesiti.defineColumn("idtipologiastudente", typeof(int));
	tgraduatoriaesiti.defineColumn("lt", typeof(DateTime),false);
	tgraduatoriaesiti.defineColumn("lu", typeof(string),false);
	tgraduatoriaesiti.defineColumn("provvisoria", typeof(string),false);
	Tables.Add(tgraduatoriaesiti);
	tgraduatoriaesiti.defineKey("idcorsostudio", "idgraduatoriaesiti");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ISCRIZIONE /////////////////////////////////
	var tiscrizione= new MetaTable("iscrizione");
	tiscrizione.defineColumn("aa", typeof(string),false);
	tiscrizione.defineColumn("anno", typeof(int));
	tiscrizione.defineColumn("ct", typeof(DateTime),false);
	tiscrizione.defineColumn("cu", typeof(string),false);
	tiscrizione.defineColumn("data", typeof(DateTime));
	tiscrizione.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione.defineColumn("iddidprog", typeof(int),false);
	tiscrizione.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione.defineColumn("idreg", typeof(int),false);
	tiscrizione.defineColumn("lt", typeof(DateTime),false);
	tiscrizione.defineColumn("lu", typeof(string),false);
	tiscrizione.defineColumn("matricola", typeof(string));
	tiscrizione.defineColumn("!idreg_registry_title", typeof(string));
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("ct", typeof(DateTime),false);
	tsostenimento.defineColumn("cu", typeof(string),false);
	tsostenimento.defineColumn("data", typeof(DateTime),false);
	tsostenimento.defineColumn("domande", typeof(string));
	tsostenimento.defineColumn("ects", typeof(int));
	tsostenimento.defineColumn("giudizio", typeof(string));
	tsostenimento.defineColumn("idappello", typeof(int));
	tsostenimento.defineColumn("idattivform", typeof(int));
	tsostenimento.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento.defineColumn("iddidprog", typeof(int),false);
	tsostenimento.defineColumn("idiscrizione", typeof(int));
	tsostenimento.defineColumn("idprova", typeof(int),false);
	tsostenimento.defineColumn("idreg", typeof(int),false);
	tsostenimento.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento.defineColumn("idtitolostudio", typeof(int));
	tsostenimento.defineColumn("insecod", typeof(string));
	tsostenimento.defineColumn("insedesc", typeof(string));
	tsostenimento.defineColumn("livello", typeof(string));
	tsostenimento.defineColumn("lt", typeof(DateTime),false);
	tsostenimento.defineColumn("lu", typeof(string),false);
	tsostenimento.defineColumn("paridsostenimento", typeof(int));
	tsostenimento.defineColumn("protanno", typeof(int));
	tsostenimento.defineColumn("protnumero", typeof(int));
	tsostenimento.defineColumn("voto", typeof(decimal));
	tsostenimento.defineColumn("votolode", typeof(string));
	tsostenimento.defineColumn("votosu", typeof(int));
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idcorsostudio", "iddidprog", "idprova", "idreg", "idsostenimento");

	//////////////////// COMMISSREGISTRY_DOCENTI /////////////////////////////////
	var tcommissregistry_docenti= new MetaTable("commissregistry_docenti");
	tcommissregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tcommissregistry_docenti.defineColumn("cu", typeof(string),false);
	tcommissregistry_docenti.defineColumn("idappello", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idcommiss", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idcorsostudio", typeof(int),false);
	tcommissregistry_docenti.defineColumn("iddidprog", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idprova", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idreg_docenti", typeof(int),false);
	tcommissregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tcommissregistry_docenti.defineColumn("lu", typeof(string),false);
	Tables.Add(tcommissregistry_docenti);
	tcommissregistry_docenti.defineKey("idcommiss", "idcorsostudio", "iddidprog", "idprova", "idreg_docenti");

	//////////////////// COMMISS /////////////////////////////////
	var tcommiss= new MetaTable("commiss");
	tcommiss.defineColumn("ct", typeof(DateTime),false);
	tcommiss.defineColumn("cu", typeof(string),false);
	tcommiss.defineColumn("idappello", typeof(int));
	tcommiss.defineColumn("idcommiss", typeof(int),false);
	tcommiss.defineColumn("idcorsostudio", typeof(int),false);
	tcommiss.defineColumn("iddidprog", typeof(int),false);
	tcommiss.defineColumn("idprova", typeof(int),false);
	tcommiss.defineColumn("idreg_docenti", typeof(int),false);
	tcommiss.defineColumn("lt", typeof(DateTime),false);
	tcommiss.defineColumn("lu", typeof(string),false);
	Tables.Add(tcommiss);
	tcommiss.defineKey("idcommiss", "idcorsostudio", "iddidprog", "idprova");

	//////////////////// PROVAAULA /////////////////////////////////
	var tprovaaula= new MetaTable("provaaula");
	tprovaaula.defineColumn("ct", typeof(DateTime),false);
	tprovaaula.defineColumn("cu", typeof(string),false);
	tprovaaula.defineColumn("idappello", typeof(int));
	tprovaaula.defineColumn("idaula", typeof(int),false);
	tprovaaula.defineColumn("idcorsostudio", typeof(int),false);
	tprovaaula.defineColumn("iddidprog", typeof(int),false);
	tprovaaula.defineColumn("idedificio", typeof(int),false);
	tprovaaula.defineColumn("idprova", typeof(int),false);
	tprovaaula.defineColumn("idsede", typeof(int),false);
	tprovaaula.defineColumn("lt", typeof(DateTime),false);
	tprovaaula.defineColumn("lu", typeof(string),false);
	Tables.Add(tprovaaula);
	tprovaaula.defineKey("idaula", "idcorsostudio", "iddidprog", "idedificio", "idprova", "idsede");

	//////////////////// PROVA /////////////////////////////////
	var tprova= new MetaTable("prova");
	tprova.defineColumn("ct", typeof(DateTime),false);
	tprova.defineColumn("cu", typeof(string),false);
	tprova.defineColumn("idappello", typeof(int));
	tprova.defineColumn("idattivform", typeof(int));
	tprova.defineColumn("idcorsostudio", typeof(int),false);
	tprova.defineColumn("iddidprog", typeof(int),false);
	tprova.defineColumn("idprova", typeof(int),false);
	tprova.defineColumn("idquestionario", typeof(int));
	tprova.defineColumn("idvalutazionekind", typeof(int));
	tprova.defineColumn("lt", typeof(DateTime),false);
	tprova.defineColumn("lu", typeof(string),false);
	tprova.defineColumn("programma", typeof(string));
	tprova.defineColumn("start", typeof(DateTime),false);
	tprova.defineColumn("stop", typeof(DateTime),false);
	tprova.defineColumn("title", typeof(string),false);
	Tables.Add(tprova);
	tprova.defineKey("idcorsostudio", "iddidprog", "idprova");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

	//////////////////// ANNOACCADEMICO_ALIAS2 /////////////////////////////////
	var tannoaccademico_alias2= new MetaTable("annoaccademico_alias2");
	tannoaccademico_alias2.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias2.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias2);
	tannoaccademico_alias2.defineKey("aa");

	//////////////////// DIDPROG_ALIAS2 /////////////////////////////////
	var tdidprog_alias2= new MetaTable("didprog_alias2");
	tdidprog_alias2.defineColumn("aa", typeof(string),false);
	tdidprog_alias2.defineColumn("annosolare", typeof(int));
	tdidprog_alias2.defineColumn("attribdebiti", typeof(string));
	tdidprog_alias2.defineColumn("ciclo", typeof(int));
	tdidprog_alias2.defineColumn("codice", typeof(string));
	tdidprog_alias2.defineColumn("codicemiur", typeof(string));
	tdidprog_alias2.defineColumn("dataconsmaxiscr", typeof(DateTime));
	tdidprog_alias2.defineColumn("freqobbl", typeof(string));
	tdidprog_alias2.defineColumn("idareadidattica", typeof(int));
	tdidprog_alias2.defineColumn("idconvenzione", typeof(int));
	tdidprog_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog_alias2.defineColumn("iddidprog", typeof(int),false);
	tdidprog_alias2.defineColumn("iddidprognumchiusokind", typeof(int));
	tdidprog_alias2.defineColumn("iddidprogsuddannokind", typeof(int),false);
	tdidprog_alias2.defineColumn("iderogazkind", typeof(int));
	tdidprog_alias2.defineColumn("idgraduatoria", typeof(int));
	tdidprog_alias2.defineColumn("idnation_lang", typeof(int));
	tdidprog_alias2.defineColumn("idnation_lang2", typeof(int));
	tdidprog_alias2.defineColumn("idnation_langvis", typeof(int));
	tdidprog_alias2.defineColumn("idreg_docenti", typeof(int));
	tdidprog_alias2.defineColumn("idsede", typeof(int));
	tdidprog_alias2.defineColumn("idsessione", typeof(int));
	tdidprog_alias2.defineColumn("idtitolokind", typeof(int));
	tdidprog_alias2.defineColumn("immatoltreauth", typeof(string));
	tdidprog_alias2.defineColumn("modaccesso", typeof(string));
	tdidprog_alias2.defineColumn("modaccesso_en", typeof(string));
	tdidprog_alias2.defineColumn("obbformativi", typeof(string));
	tdidprog_alias2.defineColumn("obbformativi_en", typeof(string));
	tdidprog_alias2.defineColumn("preimmatoltreauth", typeof(string));
	tdidprog_alias2.defineColumn("progesamamm", typeof(string));
	tdidprog_alias2.defineColumn("prospoccupaz", typeof(string));
	tdidprog_alias2.defineColumn("provafinaledesc", typeof(string));
	tdidprog_alias2.defineColumn("regolamentotax", typeof(string));
	tdidprog_alias2.defineColumn("regolamentotaxurl", typeof(string));
	tdidprog_alias2.defineColumn("startiscrizioni", typeof(DateTime));
	tdidprog_alias2.defineColumn("stopiscrizioni", typeof(DateTime));
	tdidprog_alias2.defineColumn("title", typeof(string));
	tdidprog_alias2.defineColumn("title_en", typeof(string));
	tdidprog_alias2.defineColumn("utenzasost", typeof(int));
	tdidprog_alias2.defineColumn("website", typeof(string));
	tdidprog_alias2.ExtendedProperties["TableForReading"]="didprog";
	Tables.Add(tdidprog_alias2);
	tdidprog_alias2.defineKey("idcorsostudio", "iddidprog");

	//////////////////// DIDPROGACCESSO /////////////////////////////////
	var tdidprogaccesso= new MetaTable("didprogaccesso");
	tdidprogaccesso.defineColumn("ct", typeof(DateTime),false);
	tdidprogaccesso.defineColumn("cu", typeof(string),false);
	tdidprogaccesso.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogaccesso.defineColumn("iddidprog", typeof(int),false);
	tdidprogaccesso.defineColumn("iddidprog_acc", typeof(int),false);
	tdidprogaccesso.defineColumn("lt", typeof(DateTime),false);
	tdidprogaccesso.defineColumn("lu", typeof(string),false);
	tdidprogaccesso.defineColumn("!iddidprog_acc_didprog_alias2_title", typeof(string));
	tdidprogaccesso.defineColumn("!iddidprog_acc_annoaccademico_alias2_aa", typeof(string));
	tdidprogaccesso.defineColumn("!iddidprog_acc_sede_title", typeof(string));
	Tables.Add(tdidprogaccesso);
	tdidprogaccesso.defineKey("idcorsostudio", "iddidprog", "iddidprog_acc");

	//////////////////// TITOLOKINDDEFAULTVIEW /////////////////////////////////
	var ttitolokinddefaultview= new MetaTable("titolokinddefaultview");
	ttitolokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	ttitolokinddefaultview.defineColumn("idtitolokind", typeof(int),false);
	ttitolokinddefaultview.defineColumn("titolokind_active", typeof(string));
	Tables.Add(ttitolokinddefaultview);
	ttitolokinddefaultview.defineKey("idtitolokind");

	//////////////////// SESSIONEDEFAULTVIEW /////////////////////////////////
	var tsessionedefaultview= new MetaTable("sessionedefaultview");
	tsessionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsessionedefaultview.defineColumn("idsessione", typeof(int),false);
	Tables.Add(tsessionedefaultview);
	tsessionedefaultview.defineKey("idsessione");

	//////////////////// SEDEDEFAULTVIEW /////////////////////////////////
	var tsededefaultview= new MetaTable("sededefaultview");
	tsededefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsededefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tsededefaultview);
	tsededefaultview.defineKey("idsede");

	//////////////////// GEO_NATION_ALIAS2 /////////////////////////////////
	var tgeo_nation_alias2= new MetaTable("geo_nation_alias2");
	tgeo_nation_alias2.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias2.defineColumn("lang", typeof(string));
	tgeo_nation_alias2.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias2);
	tgeo_nation_alias2.defineKey("idnation");

	//////////////////// GEO_NATION_ALIAS1 /////////////////////////////////
	var tgeo_nation_alias1= new MetaTable("geo_nation_alias1");
	tgeo_nation_alias1.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias1.defineColumn("lang", typeof(string));
	tgeo_nation_alias1.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias1);
	tgeo_nation_alias1.defineKey("idnation");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("lang", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// GRADUATORIA /////////////////////////////////
	var tgraduatoria= new MetaTable("graduatoria");
	tgraduatoria.defineColumn("idgraduatoria", typeof(int),false);
	tgraduatoria.defineColumn("title", typeof(string));
	Tables.Add(tgraduatoria);
	tgraduatoria.defineKey("idgraduatoria");

	//////////////////// DIDPROGSUDDANNOKIND /////////////////////////////////
	var tdidprogsuddannokind= new MetaTable("didprogsuddannokind");
	tdidprogsuddannokind.defineColumn("active", typeof(string));
	tdidprogsuddannokind.defineColumn("iddidprogsuddannokind", typeof(int),false);
	tdidprogsuddannokind.defineColumn("title", typeof(string));
	Tables.Add(tdidprogsuddannokind);
	tdidprogsuddannokind.defineKey("iddidprogsuddannokind");

	//////////////////// DIDPROGNUMCHIUSOKIND /////////////////////////////////
	var tdidprognumchiusokind= new MetaTable("didprognumchiusokind");
	tdidprognumchiusokind.defineColumn("active", typeof(string),false);
	tdidprognumchiusokind.defineColumn("iddidprognumchiusokind", typeof(int),false);
	tdidprognumchiusokind.defineColumn("title", typeof(string),false);
	Tables.Add(tdidprognumchiusokind);
	tdidprognumchiusokind.defineKey("iddidprognumchiusokind");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string));
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
	tdidprog.defineColumn("iddidprogsuddannokind", typeof(int));
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

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// CORSOSTUDIO /////////////////////////////////
	var tcorsostudio= new MetaTable("corsostudio");
	tcorsostudio.defineColumn("almalaureasurvey", typeof(string));
	tcorsostudio.defineColumn("annoistituz", typeof(int));
	tcorsostudio.defineColumn("basevoto", typeof(int));
	tcorsostudio.defineColumn("codice", typeof(string));
	tcorsostudio.defineColumn("codicemiur", typeof(string));
	tcorsostudio.defineColumn("codicemiurlungo", typeof(string));
	tcorsostudio.defineColumn("crediti", typeof(int));
	tcorsostudio.defineColumn("ct", typeof(DateTime),false);
	tcorsostudio.defineColumn("cu", typeof(string),false);
	tcorsostudio.defineColumn("durata", typeof(int));
	tcorsostudio.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudio.defineColumn("idcorsostudiokind", typeof(int),false);
	tcorsostudio.defineColumn("idcorsostudiolivello", typeof(int));
	tcorsostudio.defineColumn("idcorsostudionorma", typeof(int));
	tcorsostudio.defineColumn("idduratakind", typeof(int));
	tcorsostudio.defineColumn("idstruttura", typeof(int));
	tcorsostudio.defineColumn("lt", typeof(DateTime),false);
	tcorsostudio.defineColumn("lu", typeof(string),false);
	tcorsostudio.defineColumn("obbform", typeof(string));
	tcorsostudio.defineColumn("sboccocc", typeof(string));
	tcorsostudio.defineColumn("title", typeof(string));
	tcorsostudio.defineColumn("title_en", typeof(string));
	Tables.Add(tcorsostudio);
	tcorsostudio.defineKey("idcorsostudio");

	#endregion


	#region DataRelation creation
	var cPar = new []{corsostudio.Columns["idcorsostudio"]};
	var cChild = new []{graduatoriaesiti.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_graduatoriaesiti_corsostudio_idcorsostudio",cPar,cChild,false));

	cPar = new []{graduatoriaesiti.Columns["idcorsostudio"], graduatoriaesiti.Columns["idgraduatoriaesiti"]};
	cChild = new []{graduatoriaesitipos.Columns["idcorsostudio"], graduatoriaesitipos.Columns["idgraduatoriaesiti"]};
	Relations.Add(new DataRelation("FK_graduatoriaesitipos_graduatoriaesiti_idcorsostudio-idgraduatoriaesiti",cPar,cChild,false));

	cPar = new []{corsostudio.Columns["idcorsostudio"]};
	cChild = new []{didprog.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_didprog_corsostudio_idcorsostudio",cPar,cChild,false));

	cPar = new []{didprog.Columns["idcorsostudio"], didprog.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_idcorsostudio-iddidprog",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{iscrizione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizione_registry_idreg",cPar,cChild,false));

	cPar = new []{didprog.Columns["idcorsostudio"], didprog.Columns["iddidprog"]};
	cChild = new []{prova.Columns["idcorsostudio"], prova.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_prova_didprog_idcorsostudio-iddidprog",cPar,cChild,false));

	cPar = new []{prova.Columns["idcorsostudio"], prova.Columns["iddidprog"], prova.Columns["idprova"]};
	cChild = new []{sostenimento.Columns["idcorsostudio"], sostenimento.Columns["iddidprog"], sostenimento.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_sostenimento_prova_idcorsostudio-iddidprog-idprova",cPar,cChild,false));

	cPar = new []{prova.Columns["idcorsostudio"], prova.Columns["iddidprog"], prova.Columns["idprova"]};
	cChild = new []{commiss.Columns["idcorsostudio"], commiss.Columns["iddidprog"], commiss.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_commiss_prova_idcorsostudio-iddidprog-idprova",cPar,cChild,false));

	cPar = new []{commiss.Columns["idcommiss"], commiss.Columns["idcorsostudio"], commiss.Columns["iddidprog"], commiss.Columns["idprova"]};
	cChild = new []{commissregistry_docenti.Columns["idcommiss"], commissregistry_docenti.Columns["idcorsostudio"], commissregistry_docenti.Columns["iddidprog"], commissregistry_docenti.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_commissregistry_docenti_commiss_idcommiss-idcorsostudio-iddidprog-idprova",cPar,cChild,false));

	cPar = new []{prova.Columns["idcorsostudio"], prova.Columns["iddidprog"], prova.Columns["idprova"]};
	cChild = new []{provaaula.Columns["idcorsostudio"], provaaula.Columns["iddidprog"], provaaula.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_provaaula_prova_idcorsostudio-iddidprog-idprova",cPar,cChild,false));

	cPar = new []{didprog.Columns["idcorsostudio"], didprog.Columns["iddidprog"]};
	cChild = new []{didprogaccesso.Columns["idcorsostudio"], didprogaccesso.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_didprogaccesso_didprog_idcorsostudio-iddidprog",cPar,cChild,false));

	cPar = new []{didprog_alias2.Columns["iddidprog"]};
	cChild = new []{didprogaccesso.Columns["iddidprog_acc"]};
	Relations.Add(new DataRelation("FK_didprogaccesso_didprog_alias2_iddidprog_acc",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{didprog_alias2.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_alias2_sede_idsede",cPar,cChild,false));

	cPar = new []{annoaccademico_alias2.Columns["aa"]};
	cChild = new []{didprog_alias2.Columns["aa"]};
	Relations.Add(new DataRelation("FK_didprog_alias2_annoaccademico_alias2_aa",cPar,cChild,false));

	cPar = new []{titolokinddefaultview.Columns["idtitolokind"]};
	cChild = new []{didprog.Columns["idtitolokind"]};
	Relations.Add(new DataRelation("FK_didprog_titolokinddefaultview_idtitolokind",cPar,cChild,false));

	cPar = new []{sessionedefaultview.Columns["idsessione"]};
	cChild = new []{didprog.Columns["idsessione"]};
	Relations.Add(new DataRelation("FK_didprog_sessionedefaultview_idsessione",cPar,cChild,false));

	cPar = new []{sededefaultview.Columns["idsede"]};
	cChild = new []{didprog.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_sededefaultview_idsede",cPar,cChild,false));

	cPar = new []{geo_nation_alias2.Columns["idnation"]};
	cChild = new []{didprog.Columns["idnation_langvis"]};
	Relations.Add(new DataRelation("FK_didprog_geo_nation_alias2_idnation_langvis",cPar,cChild,false));

	cPar = new []{geo_nation_alias1.Columns["idnation"]};
	cChild = new []{didprog.Columns["idnation_lang2"]};
	Relations.Add(new DataRelation("FK_didprog_geo_nation_alias1_idnation_lang2",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{didprog.Columns["idnation_lang"]};
	Relations.Add(new DataRelation("FK_didprog_geo_nation_idnation_lang",cPar,cChild,false));

	cPar = new []{graduatoria.Columns["idgraduatoria"]};
	cChild = new []{didprog.Columns["idgraduatoria"]};
	Relations.Add(new DataRelation("FK_didprog_graduatoria_idgraduatoria",cPar,cChild,false));

	cPar = new []{didprogsuddannokind.Columns["iddidprogsuddannokind"]};
	cChild = new []{didprog.Columns["iddidprogsuddannokind"]};
	Relations.Add(new DataRelation("FK_didprog_didprogsuddannokind_iddidprogsuddannokind",cPar,cChild,false));

	cPar = new []{didprognumchiusokind.Columns["iddidprognumchiusokind"]};
	cChild = new []{didprog.Columns["iddidprognumchiusokind"]};
	Relations.Add(new DataRelation("FK_didprog_didprognumchiusokind_iddidprognumchiusokind",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{didprog.Columns["aa"]};
	Relations.Add(new DataRelation("FK_didprog_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{corsostudio.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_corsostudio_strutturadefaultview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
