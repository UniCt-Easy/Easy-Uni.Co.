
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
[System.Xml.Serialization.XmlRoot("dsmeta_appello_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_appello_default: DataSet {

	#region Table members declaration
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
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prenotappello 		=> (MetaTable)Tables["prenotappello"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegninteg 		=> (MetaTable)Tables["insegninteg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegn 		=> (MetaTable)Tables["insegn"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appelloattivform 		=> (MetaTable)Tables["appelloattivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable studprenotkinddefaultview 		=> (MetaTable)Tables["studprenotkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sessionedefaultview 		=> (MetaTable)Tables["sessionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appelloazionekinddefaultview 		=> (MetaTable)Tables["appelloazionekinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appellokinddefaultview 		=> (MetaTable)Tables["appellokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appello 		=> (MetaTable)Tables["appello"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_appello_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_appello_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_appello_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_appello_default.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("ct", typeof(DateTime),false);
	tsostenimento.defineColumn("cu", typeof(string),false);
	tsostenimento.defineColumn("data", typeof(DateTime),false);
	tsostenimento.defineColumn("domande", typeof(string));
	tsostenimento.defineColumn("ects", typeof(int));
	tsostenimento.defineColumn("giudizio", typeof(string));
	tsostenimento.defineColumn("idappello", typeof(int),false);
	tsostenimento.defineColumn("idattivform", typeof(int));
	tsostenimento.defineColumn("idcorsostudio", typeof(int));
	tsostenimento.defineColumn("iddidprog", typeof(int));
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
	tsostenimento.defineKey("idappello", "idprova", "idreg", "idsostenimento");

	//////////////////// COMMISSREGISTRY_DOCENTI /////////////////////////////////
	var tcommissregistry_docenti= new MetaTable("commissregistry_docenti");
	tcommissregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tcommissregistry_docenti.defineColumn("cu", typeof(string),false);
	tcommissregistry_docenti.defineColumn("idappello", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idcommiss", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idcorsostudio", typeof(int));
	tcommissregistry_docenti.defineColumn("iddidprog", typeof(int));
	tcommissregistry_docenti.defineColumn("idprova", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idreg_docenti", typeof(int),false);
	tcommissregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tcommissregistry_docenti.defineColumn("lu", typeof(string),false);
	Tables.Add(tcommissregistry_docenti);
	tcommissregistry_docenti.defineKey("idappello", "idcommiss", "idprova", "idreg_docenti");

	//////////////////// COMMISS /////////////////////////////////
	var tcommiss= new MetaTable("commiss");
	tcommiss.defineColumn("ct", typeof(DateTime),false);
	tcommiss.defineColumn("cu", typeof(string),false);
	tcommiss.defineColumn("idappello", typeof(int),false);
	tcommiss.defineColumn("idcommiss", typeof(int),false);
	tcommiss.defineColumn("idcorsostudio", typeof(int));
	tcommiss.defineColumn("iddidprog", typeof(int));
	tcommiss.defineColumn("idprova", typeof(int),false);
	tcommiss.defineColumn("idreg_docenti", typeof(int),false);
	tcommiss.defineColumn("lt", typeof(DateTime),false);
	tcommiss.defineColumn("lu", typeof(string),false);
	Tables.Add(tcommiss);
	tcommiss.defineKey("idappello", "idcommiss", "idprova");

	//////////////////// PROVAAULA /////////////////////////////////
	var tprovaaula= new MetaTable("provaaula");
	tprovaaula.defineColumn("ct", typeof(DateTime),false);
	tprovaaula.defineColumn("cu", typeof(string),false);
	tprovaaula.defineColumn("idappello", typeof(int),false);
	tprovaaula.defineColumn("idaula", typeof(int),false);
	tprovaaula.defineColumn("idcorsostudio", typeof(int));
	tprovaaula.defineColumn("iddidprog", typeof(int));
	tprovaaula.defineColumn("idedificio", typeof(int),false);
	tprovaaula.defineColumn("idprova", typeof(int),false);
	tprovaaula.defineColumn("idsede", typeof(int),false);
	tprovaaula.defineColumn("lt", typeof(DateTime),false);
	tprovaaula.defineColumn("lu", typeof(string),false);
	Tables.Add(tprovaaula);
	tprovaaula.defineKey("idappello", "idaula", "idedificio", "idprova", "idsede");

	//////////////////// PROVA /////////////////////////////////
	var tprova= new MetaTable("prova");
	tprova.defineColumn("ct", typeof(DateTime),false);
	tprova.defineColumn("cu", typeof(string),false);
	tprova.defineColumn("idappello", typeof(int),false);
	tprova.defineColumn("idattivform", typeof(int));
	tprova.defineColumn("idcorsostudio", typeof(int));
	tprova.defineColumn("iddidprog", typeof(int));
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
	tprova.defineKey("idappello", "idprova");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// PRENOTAPPELLO /////////////////////////////////
	var tprenotappello= new MetaTable("prenotappello");
	tprenotappello.defineColumn("ct", typeof(DateTime),false);
	tprenotappello.defineColumn("cu", typeof(string),false);
	tprenotappello.defineColumn("data", typeof(DateTime),false);
	tprenotappello.defineColumn("idappello", typeof(int),false);
	tprenotappello.defineColumn("idattivform", typeof(int),false);
	tprenotappello.defineColumn("idiscrizione", typeof(int),false);
	tprenotappello.defineColumn("idpianostudio", typeof(int),false);
	tprenotappello.defineColumn("idpianostudioattivform", typeof(int),false);
	tprenotappello.defineColumn("idprenotappello", typeof(int),false);
	tprenotappello.defineColumn("idprova", typeof(int),false);
	tprenotappello.defineColumn("idreg", typeof(int),false);
	tprenotappello.defineColumn("lt", typeof(DateTime),false);
	tprenotappello.defineColumn("lu", typeof(string),false);
	tprenotappello.defineColumn("!idreg_registry_title", typeof(string));
	Tables.Add(tprenotappello);
	tprenotappello.defineKey("idappello", "idattivform", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idprenotappello", "idprova", "idreg");

	//////////////////// INSEGNINTEG /////////////////////////////////
	var tinsegninteg= new MetaTable("insegninteg");
	tinsegninteg.defineColumn("codice", typeof(string));
	tinsegninteg.defineColumn("denominazione", typeof(string));
	tinsegninteg.defineColumn("idinsegn", typeof(int),false);
	tinsegninteg.defineColumn("idinsegninteg", typeof(int),false);
	Tables.Add(tinsegninteg);
	tinsegninteg.defineKey("idinsegn", "idinsegninteg");

	//////////////////// INSEGN /////////////////////////////////
	var tinsegn= new MetaTable("insegn");
	tinsegn.defineColumn("codice", typeof(string));
	tinsegn.defineColumn("denominazione", typeof(string));
	tinsegn.defineColumn("idinsegn", typeof(int),false);
	Tables.Add(tinsegn);
	tinsegn.defineKey("idinsegn");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
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
	tdidprog.defineColumn("iddidprogsuddannokind", typeof(int),false);
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

	//////////////////// ATTIVFORM /////////////////////////////////
	var tattivform= new MetaTable("attivform");
	tattivform.defineColumn("aa", typeof(string),false);
	tattivform.defineColumn("ct", typeof(DateTime),false);
	tattivform.defineColumn("cu", typeof(string),false);
	tattivform.defineColumn("idattivform", typeof(int),false);
	tattivform.defineColumn("idcorsostudio", typeof(int),false);
	tattivform.defineColumn("iddidprog", typeof(int),false);
	tattivform.defineColumn("iddidproganno", typeof(int),false);
	tattivform.defineColumn("iddidprogcurr", typeof(int),false);
	tattivform.defineColumn("iddidproggrupp", typeof(int));
	tattivform.defineColumn("iddidprogori", typeof(int),false);
	tattivform.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivform.defineColumn("idinsegn", typeof(int),false);
	tattivform.defineColumn("idinsegninteg", typeof(int));
	tattivform.defineColumn("idsede", typeof(int),false);
	tattivform.defineColumn("lt", typeof(DateTime),false);
	tattivform.defineColumn("lu", typeof(string),false);
	tattivform.defineColumn("obbform", typeof(string));
	tattivform.defineColumn("obbform_en", typeof(string));
	tattivform.defineColumn("sortcode", typeof(int));
	tattivform.defineColumn("start", typeof(DateTime));
	tattivform.defineColumn("stop", typeof(DateTime));
	tattivform.defineColumn("tipovalutaz", typeof(string));
	tattivform.defineColumn("title", typeof(string));
	Tables.Add(tattivform);
	tattivform.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// APPELLOATTIVFORM /////////////////////////////////
	var tappelloattivform= new MetaTable("appelloattivform");
	tappelloattivform.defineColumn("aa", typeof(string),false);
	tappelloattivform.defineColumn("ct", typeof(DateTime),false);
	tappelloattivform.defineColumn("cu", typeof(string),false);
	tappelloattivform.defineColumn("idappello", typeof(int),false);
	tappelloattivform.defineColumn("idattivform", typeof(int),false);
	tappelloattivform.defineColumn("idcorsostudio", typeof(int),false);
	tappelloattivform.defineColumn("iddidprog", typeof(int),false);
	tappelloattivform.defineColumn("iddidproganno", typeof(int),false);
	tappelloattivform.defineColumn("iddidprogcurr", typeof(int),false);
	tappelloattivform.defineColumn("iddidprogori", typeof(int),false);
	tappelloattivform.defineColumn("iddidprogporzanno", typeof(int),false);
	tappelloattivform.defineColumn("lt", typeof(DateTime),false);
	tappelloattivform.defineColumn("lu", typeof(string),false);
	tappelloattivform.defineColumn("!idattivform_didprog_title", typeof(string));
	tappelloattivform.defineColumn("!idattivform_didprog_annoaccademico_alias1_aa", typeof(string));
	tappelloattivform.defineColumn("!idattivform_didprog_sede_title", typeof(string));
	tappelloattivform.defineColumn("!idattivform_insegn_denominazione", typeof(string));
	tappelloattivform.defineColumn("!idattivform_insegn_codice", typeof(string));
	tappelloattivform.defineColumn("!idattivform_insegninteg_denominazione", typeof(string));
	tappelloattivform.defineColumn("!idattivform_insegninteg_codice", typeof(string));
	tappelloattivform.defineColumn("!idattivform_attivform_tipovalutaz", typeof(string));
	tappelloattivform.defineColumn("!idattivform_sede_title", typeof(string));
	Tables.Add(tappelloattivform);
	tappelloattivform.defineKey("aa", "idappello", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// STUDPRENOTKINDDEFAULTVIEW /////////////////////////////////
	var tstudprenotkinddefaultview= new MetaTable("studprenotkinddefaultview");
	tstudprenotkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstudprenotkinddefaultview.defineColumn("idstudprenotkind", typeof(int),false);
	tstudprenotkinddefaultview.defineColumn("studprenotkind_active", typeof(string));
	Tables.Add(tstudprenotkinddefaultview);
	tstudprenotkinddefaultview.defineKey("idstudprenotkind");

	//////////////////// SESSIONEDEFAULTVIEW /////////////////////////////////
	var tsessionedefaultview= new MetaTable("sessionedefaultview");
	tsessionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsessionedefaultview.defineColumn("idsessione", typeof(int),false);
	tsessionedefaultview.defineColumn("idsessionekind", typeof(int));
	Tables.Add(tsessionedefaultview);
	tsessionedefaultview.defineKey("idsessione");

	//////////////////// APPELLOAZIONEKINDDEFAULTVIEW /////////////////////////////////
	var tappelloazionekinddefaultview= new MetaTable("appelloazionekinddefaultview");
	tappelloazionekinddefaultview.defineColumn("appelloazionekind_active", typeof(string));
	tappelloazionekinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tappelloazionekinddefaultview.defineColumn("idappelloazionekind", typeof(int),false);
	Tables.Add(tappelloazionekinddefaultview);
	tappelloazionekinddefaultview.defineKey("idappelloazionekind");

	//////////////////// APPELLOKINDDEFAULTVIEW /////////////////////////////////
	var tappellokinddefaultview= new MetaTable("appellokinddefaultview");
	tappellokinddefaultview.defineColumn("appellokind_active", typeof(string));
	tappellokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tappellokinddefaultview.defineColumn("idappellokind", typeof(int),false);
	Tables.Add(tappellokinddefaultview);
	tappellokinddefaultview.defineKey("idappellokind");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// APPELLO /////////////////////////////////
	var tappello= new MetaTable("appello");
	tappello.defineColumn("aa", typeof(string));
	tappello.defineColumn("basevoto", typeof(int));
	tappello.defineColumn("cftoend", typeof(decimal));
	tappello.defineColumn("ct", typeof(DateTime),false);
	tappello.defineColumn("cu", typeof(string),false);
	tappello.defineColumn("description", typeof(string));
	tappello.defineColumn("esteroend", typeof(DateTime));
	tappello.defineColumn("esterostart", typeof(DateTime));
	tappello.defineColumn("idappello", typeof(int),false);
	tappello.defineColumn("idappelloazionekind", typeof(int));
	tappello.defineColumn("idappellokind", typeof(int));
	tappello.defineColumn("idsessione", typeof(int));
	tappello.defineColumn("idstudprenotkind", typeof(int));
	tappello.defineColumn("lavoratori", typeof(string));
	tappello.defineColumn("lt", typeof(DateTime),false);
	tappello.defineColumn("lu", typeof(string),false);
	tappello.defineColumn("minanniiscr", typeof(int));
	tappello.defineColumn("minvoto", typeof(int));
	tappello.defineColumn("passaggio", typeof(string));
	tappello.defineColumn("penotend", typeof(DateTime));
	tappello.defineColumn("posti", typeof(int));
	tappello.defineColumn("prenotstart", typeof(DateTime));
	tappello.defineColumn("prointermedia", typeof(string));
	tappello.defineColumn("publicato", typeof(string));
	tappello.defineColumn("surmanestop", typeof(string));
	tappello.defineColumn("surnamestart", typeof(string));
	Tables.Add(tappello);
	tappello.defineKey("idappello");

	#endregion


	#region DataRelation creation
	var cPar = new []{appello.Columns["idappello"]};
	var cChild = new []{prova.Columns["idappello"]};
	Relations.Add(new DataRelation("FK_prova_appello_idappello",cPar,cChild,false));

	cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"]};
	cChild = new []{sostenimento.Columns["idappello"], sostenimento.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_sostenimento_prova_idappello-idprova",cPar,cChild,false));

	cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"]};
	cChild = new []{commiss.Columns["idappello"], commiss.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_commiss_prova_idappello-idprova",cPar,cChild,false));

	cPar = new []{commiss.Columns["idappello"], commiss.Columns["idcommiss"], commiss.Columns["idprova"]};
	cChild = new []{commissregistry_docenti.Columns["idappello"], commissregistry_docenti.Columns["idcommiss"], commissregistry_docenti.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_commissregistry_docenti_commiss_idappello-idcommiss-idprova",cPar,cChild,false));

	cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"]};
	cChild = new []{provaaula.Columns["idappello"], provaaula.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_provaaula_prova_idappello-idprova",cPar,cChild,false));

	cPar = new []{appello.Columns["idappello"]};
	cChild = new []{prenotappello.Columns["idappello"]};
	Relations.Add(new DataRelation("FK_prenotappello_appello_idappello",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{prenotappello.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_prenotappello_registry_idreg",cPar,cChild,false));

	cPar = new []{appello.Columns["idappello"]};
	cChild = new []{appelloattivform.Columns["idappello"]};
	Relations.Add(new DataRelation("FK_appelloattivform_appello_idappello",cPar,cChild,false));

	cPar = new []{attivform.Columns["idattivform"]};
	cChild = new []{appelloattivform.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_appelloattivform_attivform_idattivform",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{attivform.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_attivform_sede_idsede",cPar,cChild,false));

	cPar = new []{insegninteg.Columns["idinsegninteg"]};
	cChild = new []{attivform.Columns["idinsegninteg"]};
	Relations.Add(new DataRelation("FK_attivform_insegninteg_idinsegninteg",cPar,cChild,false));

	cPar = new []{insegn.Columns["idinsegn"]};
	cChild = new []{attivform.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_attivform_insegn_idinsegn",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{attivform.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_attivform_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{didprog.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_sede_idsede",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{didprog.Columns["aa"]};
	Relations.Add(new DataRelation("FK_didprog_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{studprenotkinddefaultview.Columns["idstudprenotkind"]};
	cChild = new []{appello.Columns["idstudprenotkind"]};
	Relations.Add(new DataRelation("FK_appello_studprenotkinddefaultview_idstudprenotkind",cPar,cChild,false));

	cPar = new []{sessionedefaultview.Columns["idsessione"]};
	cChild = new []{appello.Columns["idsessione"]};
	Relations.Add(new DataRelation("FK_appello_sessionedefaultview_idsessione",cPar,cChild,false));

	cPar = new []{appelloazionekinddefaultview.Columns["idappelloazionekind"]};
	cChild = new []{appello.Columns["idappelloazionekind"]};
	Relations.Add(new DataRelation("FK_appello_appelloazionekinddefaultview_idappelloazionekind",cPar,cChild,false));

	cPar = new []{appellokinddefaultview.Columns["idappellokind"]};
	cChild = new []{appello.Columns["idappellokind"]};
	Relations.Add(new DataRelation("FK_appello_appellokinddefaultview_idappellokind",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{appello.Columns["aa"]};
	Relations.Add(new DataRelation("FK_appello_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
