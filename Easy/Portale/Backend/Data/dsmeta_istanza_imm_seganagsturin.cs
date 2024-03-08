
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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_imm_seganagsturin"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_istanza_imm_seganagsturin: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias2 		=> (MetaTable)Tables["diniego_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta_alias3 		=> (MetaTable)Tables["nullaosta_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori 		=> (MetaTable)Tables["didprogori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr_alias1 		=> (MetaTable)Tables["didprogcurr_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta_imm_alias3 		=> (MetaTable)Tables["nullaosta_imm_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarkind 		=> (MetaTable)Tables["dichiarkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzadichiar 		=> (MetaTable)Tables["istanzadichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind_alias1 		=> (MetaTable)Tables["statuskind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias14 		=> (MetaTable)Tables["istanza_alias14"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogoridefaultview 		=> (MetaTable)Tables["didprogoridefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_imm_alias2 		=> (MetaTable)Tables["istanza_imm_alias2"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanza_imm_seganagsturin(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_imm_seganagsturin (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_imm_seganagsturin";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_imm_seganagsturin.xsd";

	#region create DataTables
	//////////////////// DINIEGO_ALIAS2 /////////////////////////////////
	var tdiniego_alias2= new MetaTable("diniego_alias2");
	tdiniego_alias2.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("cu", typeof(string),false);
	tdiniego_alias2.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego_alias2.defineColumn("iddidprog", typeof(int));
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
	tdiniego_alias2.defineKey("idcorsostudio", "iddiniego", "idistanza", "idistanzakind", "idreg");

	//////////////////// NULLAOSTA_ALIAS3 /////////////////////////////////
	var tnullaosta_alias3= new MetaTable("nullaosta_alias3");
	tnullaosta_alias3.defineColumn("ct", typeof(DateTime),false);
	tnullaosta_alias3.defineColumn("cu", typeof(string),false);
	tnullaosta_alias3.defineColumn("data", typeof(DateTime),false);
	tnullaosta_alias3.defineColumn("extension", typeof(string));
	tnullaosta_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta_alias3.defineColumn("iddidprog", typeof(int),false);
	tnullaosta_alias3.defineColumn("idiscrizione", typeof(int));
	tnullaosta_alias3.defineColumn("idistanza", typeof(int),false);
	tnullaosta_alias3.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta_alias3.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta_alias3.defineColumn("idreg", typeof(int),false);
	tnullaosta_alias3.defineColumn("lt", typeof(DateTime),false);
	tnullaosta_alias3.defineColumn("lu", typeof(string),false);
	tnullaosta_alias3.defineColumn("protanno", typeof(int));
	tnullaosta_alias3.defineColumn("protnumero", typeof(int));
	tnullaosta_alias3.ExtendedProperties["TableForReading"]="nullaosta";
	Tables.Add(tnullaosta_alias3);
	tnullaosta_alias3.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// DIDPROGORI /////////////////////////////////
	var tdidprogori= new MetaTable("didprogori");
	tdidprogori.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori.defineColumn("iddidprog", typeof(int),false);
	tdidprogori.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori.defineColumn("title", typeof(string));
	Tables.Add(tdidprogori);
	tdidprogori.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGCURR_ALIAS1 /////////////////////////////////
	var tdidprogcurr_alias1= new MetaTable("didprogcurr_alias1");
	tdidprogcurr_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("title", typeof(string));
	tdidprogcurr_alias1.ExtendedProperties["TableForReading"]="didprogcurr";
	Tables.Add(tdidprogcurr_alias1);
	tdidprogcurr_alias1.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// NULLAOSTA_IMM_ALIAS3 /////////////////////////////////
	var tnullaosta_imm_alias3= new MetaTable("nullaosta_imm_alias3");
	tnullaosta_imm_alias3.defineColumn("annoimm", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("ct", typeof(DateTime),false);
	tnullaosta_imm_alias3.defineColumn("cu", typeof(string),false);
	tnullaosta_imm_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("iddidprog", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("iddidprogcurr", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("iddidprogori", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idistanza", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idreg", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("lt", typeof(DateTime),false);
	tnullaosta_imm_alias3.defineColumn("lu", typeof(string),false);
	tnullaosta_imm_alias3.defineColumn("parttime", typeof(string),false);
	tnullaosta_imm_alias3.defineColumn("!iddidprogcurr_didprogcurr_title", typeof(string));
	tnullaosta_imm_alias3.defineColumn("!iddidprogori_didprogori_title", typeof(string));
	tnullaosta_imm_alias3.ExtendedProperties["TableForReading"]="nullaosta_imm";
	Tables.Add(tnullaosta_imm_alias3);
	tnullaosta_imm_alias3.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// DICHIARKIND /////////////////////////////////
	var tdichiarkind= new MetaTable("dichiarkind");
	tdichiarkind.defineColumn("iddichiarkind", typeof(int),false);
	tdichiarkind.defineColumn("title", typeof(string),false);
	Tables.Add(tdichiarkind);
	tdichiarkind.defineKey("iddichiarkind");

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("ct", typeof(DateTime),false);
	tdichiar.defineColumn("cu", typeof(string),false);
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("extension", typeof(string));
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	tdichiar.defineColumn("lt", typeof(DateTime),false);
	tdichiar.defineColumn("lu", typeof(string),false);
	tdichiar.defineColumn("protanno", typeof(int));
	tdichiar.defineColumn("protnumero", typeof(int));
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

	//////////////////// ISTANZADICHIAR /////////////////////////////////
	var tistanzadichiar= new MetaTable("istanzadichiar");
	tistanzadichiar.defineColumn("ct", typeof(DateTime),false);
	tistanzadichiar.defineColumn("cu", typeof(string),false);
	tistanzadichiar.defineColumn("idcorsostudio", typeof(int),false);
	tistanzadichiar.defineColumn("iddichiar", typeof(int),false);
	tistanzadichiar.defineColumn("iddidprog", typeof(int),false);
	tistanzadichiar.defineColumn("idistanza", typeof(int),false);
	tistanzadichiar.defineColumn("idistanzakind", typeof(int),false);
	tistanzadichiar.defineColumn("idreg", typeof(int),false);
	tistanzadichiar.defineColumn("lt", typeof(DateTime),false);
	tistanzadichiar.defineColumn("lu", typeof(string),false);
	tistanzadichiar.defineColumn("!iddichiar_annoaccademico_alias1_aa", typeof(string));
	tistanzadichiar.defineColumn("!iddichiar_dichiarkind_title", typeof(string));
	tistanzadichiar.defineColumn("!iddichiar_dichiar_date", typeof(DateTime));
	Tables.Add(tistanzadichiar);
	tistanzadichiar.defineKey("idcorsostudio", "iddichiar", "iddidprog", "idistanza", "idistanzakind", "idreg");

	//////////////////// STATUSKIND_ALIAS1 /////////////////////////////////
	var tstatuskind_alias1= new MetaTable("statuskind_alias1");
	tstatuskind_alias1.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind_alias1.defineColumn("title", typeof(string),false);
	tstatuskind_alias1.ExtendedProperties["TableForReading"]="statuskind";
	Tables.Add(tstatuskind_alias1);
	tstatuskind_alias1.defineKey("idstatuskind");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// ISTANZA_ALIAS14 /////////////////////////////////
	var tistanza_alias14= new MetaTable("istanza_alias14");
	tistanza_alias14.defineColumn("aa", typeof(string),false);
	tistanza_alias14.defineColumn("ct", typeof(DateTime),false);
	tistanza_alias14.defineColumn("cu", typeof(string),false);
	tistanza_alias14.defineColumn("data", typeof(DateTime),false);
	tistanza_alias14.defineColumn("extension", typeof(string));
	tistanza_alias14.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_alias14.defineColumn("iddidprog", typeof(int),false);
	tistanza_alias14.defineColumn("idiscrizione", typeof(int));
	tistanza_alias14.defineColumn("idistanza", typeof(int),false);
	tistanza_alias14.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias14.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias14.defineColumn("idstatuskind", typeof(int));
	tistanza_alias14.defineColumn("lt", typeof(DateTime),false);
	tistanza_alias14.defineColumn("lu", typeof(string),false);
	tistanza_alias14.defineColumn("paridistanza", typeof(int),false);
	tistanza_alias14.defineColumn("protanno", typeof(int),false);
	tistanza_alias14.defineColumn("protnumero", typeof(int),false);
	tistanza_alias14.defineColumn("!idstatuskind_statuskind_title", typeof(string));
	tistanza_alias14.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias14);
	tistanza_alias14.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti", "paridistanza");

	//////////////////// DIDPROGORIDEFAULTVIEW /////////////////////////////////
	var tdidprogoridefaultview= new MetaTable("didprogoridefaultview");
	tdidprogoridefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogoridefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprogori", typeof(int),false);
	Tables.Add(tdidprogoridefaultview);
	tdidprogoridefaultview.defineKey("iddidprogori");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("codice", typeof(string));
	tdidprogcurr.defineColumn("codicemiur", typeof(string));
	tdidprogcurr.defineColumn("ct", typeof(DateTime),false);
	tdidprogcurr.defineColumn("cu", typeof(string),false);
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("lt", typeof(DateTime),false);
	tdidprogcurr.defineColumn("lu", typeof(string),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// STATUSKIND /////////////////////////////////
	var tstatuskind= new MetaTable("statuskind");
	tstatuskind.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskind);
	tstatuskind.defineKey("idstatuskind");

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
	tistanza.defineColumn("protanno", typeof(int),false);
	tistanza.defineColumn("protnumero", typeof(int),false);
	Tables.Add(tistanza);
	tistanza.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISTANZA_IMM_ALIAS2 /////////////////////////////////
	var tistanza_imm_alias2= new MetaTable("istanza_imm_alias2");
	tistanza_imm_alias2.defineColumn("ct", typeof(DateTime),false);
	tistanza_imm_alias2.defineColumn("cu", typeof(string));
	tistanza_imm_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_imm_alias2.defineColumn("iddidprog", typeof(int),false);
	tistanza_imm_alias2.defineColumn("iddidprogcurr", typeof(int));
	tistanza_imm_alias2.defineColumn("iddidprogori", typeof(int));
	tistanza_imm_alias2.defineColumn("idistanza", typeof(int),false);
	tistanza_imm_alias2.defineColumn("idistanzakind", typeof(int),false);
	tistanza_imm_alias2.defineColumn("idreg", typeof(int),false);
	tistanza_imm_alias2.defineColumn("lt", typeof(DateTime),false);
	tistanza_imm_alias2.defineColumn("lu", typeof(string),false);
	tistanza_imm_alias2.defineColumn("motivrit", typeof(string));
	tistanza_imm_alias2.defineColumn("parttime", typeof(string));
	tistanza_imm_alias2.defineColumn("pre", typeof(string));
	tistanza_imm_alias2.ExtendedProperties["TableForReading"]="istanza_imm";
	Tables.Add(tistanza_imm_alias2);
	tistanza_imm_alias2.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	var cChild = new []{diniego_alias2.Columns["idcorsostudio"], diniego_alias2.Columns["iddidprog"], diniego_alias2.Columns["idistanza"], diniego_alias2.Columns["idistanzakind"], diniego_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias2_istanza_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{nullaosta_alias3.Columns["idcorsostudio"], nullaosta_alias3.Columns["iddidprog"], nullaosta_alias3.Columns["idistanza"], nullaosta_alias3.Columns["idistanzakind"], nullaosta_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_alias3_istanza_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{nullaosta_alias3.Columns["idcorsostudio"], nullaosta_alias3.Columns["iddidprog"], nullaosta_alias3.Columns["idistanza"], nullaosta_alias3.Columns["idistanzakind"], nullaosta_alias3.Columns["idnullaosta"], nullaosta_alias3.Columns["idreg"]};
	cChild = new []{nullaosta_imm_alias3.Columns["idcorsostudio"], nullaosta_imm_alias3.Columns["iddidprog"], nullaosta_imm_alias3.Columns["idistanza"], nullaosta_imm_alias3.Columns["idistanzakind"], nullaosta_imm_alias3.Columns["idnullaosta"], nullaosta_imm_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_imm_alias3_nullaosta_alias3_idcorsostudio-iddidprog-idistanza-idistanzakind-idnullaosta-idreg",cPar,cChild,false));

	cPar = new []{didprogori.Columns["iddidprogori"]};
	cChild = new []{nullaosta_imm_alias3.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_nullaosta_imm_alias3_didprogori_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr_alias1.Columns["iddidprogcurr"]};
	cChild = new []{nullaosta_imm_alias3.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_nullaosta_imm_alias3_didprogcurr_alias1_iddidprogcurr",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanzadichiar.Columns["idcorsostudio"], istanzadichiar.Columns["iddidprog"], istanzadichiar.Columns["idistanza"], istanzadichiar.Columns["idistanzakind"], istanzadichiar.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanzadichiar_istanza_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{dichiar.Columns["iddichiar"]};
	cChild = new []{istanzadichiar.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_istanzadichiar_dichiar_iddichiar",cPar,cChild,false));

	cPar = new []{dichiarkind.Columns["iddichiarkind"]};
	cChild = new []{dichiar.Columns["iddichiarkind"]};
	Relations.Add(new DataRelation("FK_dichiar_dichiarkind_iddichiarkind",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{dichiar.Columns["aa"]};
	Relations.Add(new DataRelation("FK_dichiar_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_alias14.Columns["idcorsostudio"], istanza_alias14.Columns["iddidprog"], istanza_alias14.Columns["paridistanza"], istanza_alias14.Columns["idistanzakind"], istanza_alias14.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_alias14_istanza_idcorsostudio-iddidprog-paridistanza-idistanzakind-idreg_studenti-",cPar,cChild,false));

	cPar = new []{statuskind_alias1.Columns["idstatuskind"]};
	cChild = new []{istanza_alias14.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_alias14_statuskind_alias1_idstatuskind",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{istanza_alias14.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_alias14_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{didprogoridefaultview.Columns["iddidprogori"]};
	cChild = new []{istanza_imm_alias2.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_istanza_imm_alias2_didprogoridefaultview_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{didprogoridefaultview.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_didprogoridefaultview_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{istanza_imm_alias2.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_istanza_imm_alias2_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskind_idstatuskind",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{istanza.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_imm_alias2.Columns["idcorsostudio"], istanza_imm_alias2.Columns["iddidprog"], istanza_imm_alias2.Columns["idistanza"], istanza_imm_alias2.Columns["idistanzakind"], istanza_imm_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_imm_alias2_istanza_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg-",cPar,cChild,false));

	#endregion

}
}
}
