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
[System.Xml.Serialization.XmlRoot("dsmeta_iscrizione_stu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_iscrizione_stu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prova 		=> (MetaTable)Tables["prova"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform_alias2 		=> (MetaTable)Tables["attivform_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prenotappello 		=> (MetaTable)Tables["prenotappello"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform_alias1 		=> (MetaTable)Tables["attivform_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudioattivform 		=> (MetaTable)Tables["pianostudioattivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudiostatus 		=> (MetaTable)Tables["pianostudiostatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias2 		=> (MetaTable)Tables["annoaccademico_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudio 		=> (MetaTable)Tables["pianostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable parttimeinfo 		=> (MetaTable)Tables["parttimeinfo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori 		=> (MetaTable)Tables["didprogori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneanno 		=> (MetaTable)Tables["iscrizioneanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidatoview 		=> (MetaTable)Tables["convalidatoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_iscrizione_stu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_iscrizione_stu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_iscrizione_stu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_iscrizione_stu.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTOESITO /////////////////////////////////
	var tsostenimentoesito= new MetaTable("sostenimentoesito");
	tsostenimentoesito.defineColumn("active", typeof(string),false);
	tsostenimentoesito.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimentoesito.defineColumn("title", typeof(string),false);
	Tables.Add(tsostenimentoesito);
	tsostenimentoesito.defineKey("idsostenimentoesito");

	//////////////////// PROVA /////////////////////////////////
	var tprova= new MetaTable("prova");
	tprova.defineColumn("idappello", typeof(int),false);
	tprova.defineColumn("idprova", typeof(int),false);
	tprova.defineColumn("start", typeof(DateTime),false);
	tprova.defineColumn("title", typeof(string),false);
	Tables.Add(tprova);
	tprova.defineKey("idappello", "idprova");

	//////////////////// ATTIVFORM_ALIAS2 /////////////////////////////////
	var tattivform_alias2= new MetaTable("attivform_alias2");
	tattivform_alias2.defineColumn("aa", typeof(string),false);
	tattivform_alias2.defineColumn("idattivform", typeof(int),false);
	tattivform_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tattivform_alias2.defineColumn("iddidprog", typeof(int),false);
	tattivform_alias2.defineColumn("iddidproganno", typeof(int),false);
	tattivform_alias2.defineColumn("iddidprogcurr", typeof(int),false);
	tattivform_alias2.defineColumn("iddidprogori", typeof(int),false);
	tattivform_alias2.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivform_alias2.defineColumn("idsede", typeof(int),false);
	tattivform_alias2.defineColumn("title", typeof(string));
	tattivform_alias2.ExtendedProperties["TableForReading"]="attivform";
	Tables.Add(tattivform_alias2);
	tattivform_alias2.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

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
	tsostenimento.defineColumn("!idattivform_attivform_title", typeof(string));
	tsostenimento.defineColumn("!idprova_prova_title", typeof(string));
	tsostenimento.defineColumn("!idprova_prova_start", typeof(DateTime));
	tsostenimento.defineColumn("!idsostenimentoesito_sostenimentoesito_title", typeof(string));
	tsostenimento.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idappello", "idprova", "idreg", "idsostenimento");

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
	tprenotappello.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprenotappello);
	tprenotappello.defineKey("idappello", "idattivform", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idprenotappello", "idprova", "idreg");

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

	//////////////////// PIANOSTUDIOATTIVFORM /////////////////////////////////
	var tpianostudioattivform= new MetaTable("pianostudioattivform");
	tpianostudioattivform.defineColumn("anno", typeof(int),false);
	tpianostudioattivform.defineColumn("ct", typeof(DateTime),false);
	tpianostudioattivform.defineColumn("cu", typeof(string),false);
	tpianostudioattivform.defineColumn("idattivform", typeof(int),false);
	tpianostudioattivform.defineColumn("idattivform_scelta", typeof(int),false);
	tpianostudioattivform.defineColumn("idcorsostudio", typeof(int),false);
	tpianostudioattivform.defineColumn("iddidprog", typeof(int),false);
	tpianostudioattivform.defineColumn("idiscrizione", typeof(int),false);
	tpianostudioattivform.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudioattivform.defineColumn("idpianostudio", typeof(int),false);
	tpianostudioattivform.defineColumn("idpianostudioattivform", typeof(int),false);
	tpianostudioattivform.defineColumn("idreg", typeof(int),false);
	tpianostudioattivform.defineColumn("idsostenimento", typeof(int));
	tpianostudioattivform.defineColumn("lt", typeof(DateTime),false);
	tpianostudioattivform.defineColumn("lu", typeof(string),false);
	tpianostudioattivform.defineColumn("!idattivform_attivform_title", typeof(string));
	tpianostudioattivform.defineColumn("!idattivform_scelta_attivform_title", typeof(string));
	Tables.Add(tpianostudioattivform);
	tpianostudioattivform.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idreg");

	//////////////////// PIANOSTUDIOSTATUS /////////////////////////////////
	var tpianostudiostatus= new MetaTable("pianostudiostatus");
	tpianostudiostatus.defineColumn("active", typeof(string),false);
	tpianostudiostatus.defineColumn("idpianostudiostatus", typeof(int),false);
	tpianostudiostatus.defineColumn("title", typeof(string),false);
	Tables.Add(tpianostudiostatus);
	tpianostudiostatus.defineKey("idpianostudiostatus");

	//////////////////// ANNOACCADEMICO_ALIAS2 /////////////////////////////////
	var tannoaccademico_alias2= new MetaTable("annoaccademico_alias2");
	tannoaccademico_alias2.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias2.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias2);
	tannoaccademico_alias2.defineKey("aa");

	//////////////////// PIANOSTUDIO /////////////////////////////////
	var tpianostudio= new MetaTable("pianostudio");
	tpianostudio.defineColumn("aa", typeof(string));
	tpianostudio.defineColumn("ct", typeof(DateTime),false);
	tpianostudio.defineColumn("cu", typeof(string),false);
	tpianostudio.defineColumn("idcorsostudio", typeof(int),false);
	tpianostudio.defineColumn("iddidprog", typeof(int),false);
	tpianostudio.defineColumn("idiscrizione", typeof(int),false);
	tpianostudio.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudio.defineColumn("idpianostudio", typeof(int),false);
	tpianostudio.defineColumn("idpianostudiostatus", typeof(int));
	tpianostudio.defineColumn("idreg", typeof(int),false);
	tpianostudio.defineColumn("lt", typeof(DateTime),false);
	tpianostudio.defineColumn("lu", typeof(string),false);
	tpianostudio.defineColumn("!idpianostudiostatus_pianostudiostatus_title", typeof(string));
	tpianostudio.defineColumn("!pianostudioattivform", typeof(string));
	Tables.Add(tpianostudio);
	tpianostudio.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idpianostudio", "idreg");

	//////////////////// PARTTIMEINFO /////////////////////////////////
	var tparttimeinfo= new MetaTable("parttimeinfo");
	tparttimeinfo.defineColumn("anni", typeof(int));
	tparttimeinfo.defineColumn("annoequiv", typeof(int));
	tparttimeinfo.defineColumn("cf", typeof(decimal));
	tparttimeinfo.defineColumn("cfpregressi", typeof(int));
	tparttimeinfo.defineColumn("ct", typeof(DateTime));
	tparttimeinfo.defineColumn("cu", typeof(string));
	tparttimeinfo.defineColumn("idiscrizione", typeof(int),false);
	tparttimeinfo.defineColumn("idiscrizioneanno", typeof(int),false);
	tparttimeinfo.defineColumn("idparttimeinfo", typeof(int),false);
	tparttimeinfo.defineColumn("idreg", typeof(int),false);
	tparttimeinfo.defineColumn("lt", typeof(DateTime));
	tparttimeinfo.defineColumn("lu", typeof(string));
	tparttimeinfo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tparttimeinfo);
	tparttimeinfo.defineKey("idiscrizione", "idiscrizioneanno", "idparttimeinfo", "idreg");

	//////////////////// DIDPROGORI /////////////////////////////////
	var tdidprogori= new MetaTable("didprogori");
	tdidprogori.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori.defineColumn("iddidprog", typeof(int),false);
	tdidprogori.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori.defineColumn("title", typeof(string));
	Tables.Add(tdidprogori);
	tdidprogori.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// ISCRIZIONEANNO /////////////////////////////////
	var tiscrizioneanno= new MetaTable("iscrizioneanno");
	tiscrizioneanno.defineColumn("aa", typeof(string),false);
	tiscrizioneanno.defineColumn("anno", typeof(int),false);
	tiscrizioneanno.defineColumn("annofc", typeof(int));
	tiscrizioneanno.defineColumn("annopt", typeof(int));
	tiscrizioneanno.defineColumn("ct", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("cu", typeof(string),false);
	tiscrizioneanno.defineColumn("data", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizioneanno.defineColumn("iddidprog", typeof(int),false);
	tiscrizioneanno.defineColumn("iddidprogori", typeof(int),false);
	tiscrizioneanno.defineColumn("idiscrizione", typeof(int),false);
	tiscrizioneanno.defineColumn("idiscrizioneanno", typeof(int),false);
	tiscrizioneanno.defineColumn("idreg", typeof(int),false);
	tiscrizioneanno.defineColumn("lt", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("lu", typeof(string),false);
	tiscrizioneanno.defineColumn("protanno", typeof(int));
	tiscrizioneanno.defineColumn("protnumero", typeof(int));
	tiscrizioneanno.defineColumn("!iddidprogori_didprogori_title", typeof(string));
	tiscrizioneanno.defineColumn("!parttimeinfo", typeof(string));
	Tables.Add(tiscrizioneanno);
	tiscrizioneanno.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idiscrizioneanno", "idreg");

	//////////////////// CONVALIDATOVIEW /////////////////////////////////
	var tconvalidatoview= new MetaTable("convalidatoview");
	tconvalidatoview.defineColumn("ct", typeof(DateTime),false);
	tconvalidatoview.defineColumn("cu", typeof(string),false);
	tconvalidatoview.defineColumn("data", typeof(DateTime));
	tconvalidatoview.defineColumn("domande", typeof(int));
	tconvalidatoview.defineColumn("ects", typeof(int));
	tconvalidatoview.defineColumn("giudizio", typeof(int));
	tconvalidatoview.defineColumn("idappello", typeof(int));
	tconvalidatoview.defineColumn("idattivform", typeof(int),false);
	tconvalidatoview.defineColumn("idconvalidato", typeof(int),false);
	tconvalidatoview.defineColumn("idcorsostudio", typeof(int));
	tconvalidatoview.defineColumn("iddidprog", typeof(int));
	tconvalidatoview.defineColumn("idiscrizione", typeof(int));
	tconvalidatoview.defineColumn("idprova", typeof(int));
	tconvalidatoview.defineColumn("idreg", typeof(int),false);
	tconvalidatoview.defineColumn("idsostenimentoesito", typeof(int),false);
	tconvalidatoview.defineColumn("idtitolostudio", typeof(int));
	tconvalidatoview.defineColumn("insecod", typeof(string));
	tconvalidatoview.defineColumn("insedesc", typeof(string));
	tconvalidatoview.defineColumn("livello", typeof(int));
	tconvalidatoview.defineColumn("lt", typeof(DateTime),false);
	tconvalidatoview.defineColumn("lu", typeof(string),false);
	tconvalidatoview.defineColumn("paridsostenimento", typeof(int));
	tconvalidatoview.defineColumn("protanno", typeof(int));
	tconvalidatoview.defineColumn("protnumero", typeof(int));
	tconvalidatoview.defineColumn("voto", typeof(decimal));
	tconvalidatoview.defineColumn("votolode", typeof(string));
	tconvalidatoview.defineColumn("votosu", typeof(int));
	Tables.Add(tconvalidatoview);
	tconvalidatoview.defineKey("idconvalidato");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdefaultview.defineColumn("iddidprog", typeof(int),false);
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

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
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	var cChild = new []{sostenimento.Columns["idcorsostudio"], sostenimento.Columns["iddidprog"], sostenimento.Columns["idiscrizione"], sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{prova.Columns["idprova"]};
	cChild = new []{sostenimento.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_sostenimento_prova_idprova",cPar,cChild,false));

	cPar = new []{attivform_alias2.Columns["idattivform"]};
	cChild = new []{sostenimento.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_sostenimento_attivform_alias2_idattivform",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	cChild = new []{pianostudio.Columns["idcorsostudio"], pianostudio.Columns["iddidprog"], pianostudio.Columns["idiscrizione"], pianostudio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudio_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{pianostudio.Columns["idcorsostudio"], pianostudio.Columns["iddidprog"], pianostudio.Columns["idiscrizione"], pianostudio.Columns["idpianostudio"], pianostudio.Columns["idreg"]};
	cChild = new []{pianostudioattivform.Columns["idcorsostudio"], pianostudioattivform.Columns["iddidprog"], pianostudioattivform.Columns["idiscrizione"], pianostudioattivform.Columns["idpianostudio"], pianostudioattivform.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_pianostudio_idcorsostudio-iddidprog-idiscrizione-idpianostudio-idreg",cPar,cChild,false));

	cPar = new []{pianostudioattivform.Columns["idiscrizione"], pianostudioattivform.Columns["idpianostudio"], pianostudioattivform.Columns["idpianostudioattivform"], pianostudioattivform.Columns["idreg"], pianostudioattivform.Columns["idattivform"]};
	cChild = new []{prenotappello.Columns["idiscrizione"], prenotappello.Columns["idpianostudio"], prenotappello.Columns["idpianostudioattivform"], prenotappello.Columns["idreg"], prenotappello.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_prenotappello_pianostudioattivform_idiscrizione-idpianostudio-idpianostudioattivform-idreg-idattivform",cPar,cChild,false));

	cPar = new []{attivform_alias1.Columns["idattivform"]};
	cChild = new []{pianostudioattivform.Columns["idattivform_scelta"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_attivform_alias1_idattivform_scelta",cPar,cChild,false));

	cPar = new []{attivform.Columns["idattivform"]};
	cChild = new []{pianostudioattivform.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_attivform_idattivform",cPar,cChild,false));

	cPar = new []{pianostudiostatus.Columns["idpianostudiostatus"]};
	cChild = new []{pianostudio.Columns["idpianostudiostatus"]};
	Relations.Add(new DataRelation("FK_pianostudio_pianostudiostatus_idpianostudiostatus",cPar,cChild,false));

	cPar = new []{annoaccademico_alias2.Columns["aa"]};
	cChild = new []{pianostudio.Columns["aa"]};
	Relations.Add(new DataRelation("FK_pianostudio_annoaccademico_alias2_aa",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	cChild = new []{iscrizioneanno.Columns["idcorsostudio"], iscrizioneanno.Columns["iddidprog"], iscrizioneanno.Columns["idiscrizione"], iscrizioneanno.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizioneanno_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{iscrizioneanno.Columns["idiscrizione"], iscrizioneanno.Columns["idiscrizioneanno"], iscrizioneanno.Columns["idreg"]};
	cChild = new []{parttimeinfo.Columns["idiscrizione"], parttimeinfo.Columns["idiscrizioneanno"], parttimeinfo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_parttimeinfo_iscrizioneanno_idiscrizione-idiscrizioneanno-idreg",cPar,cChild,false));

	cPar = new []{didprogori.Columns["iddidprogori"]};
	cChild = new []{iscrizioneanno.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_iscrizioneanno_didprogori_iddidprogori",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{iscrizioneanno.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizioneanno_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{convalidatoview.Columns["idcorsostudio"], convalidatoview.Columns["iddidprog"], convalidatoview.Columns["idiscrizione"], convalidatoview.Columns["idreg"]};
	cChild = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizione_convalidatoview_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{iscrizione.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
