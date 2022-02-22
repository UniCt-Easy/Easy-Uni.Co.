
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_corsostudio_load"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_corsostudio_load: DataSet {

	#region Table members declaration
	///<summary>
	///2.4.2 Corso di studio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudio 		=> (MetaTable)Tables["corsostudio"];

	///<summary>
	///relazione tra  2.4.2 Corso di studio e 2.4.12 Scuola / Classe di laurea
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudioclassescuola 		=> (MetaTable)Tables["corsostudioclassescuola"];

	///<summary>
	///2.4.1 Didattica programmata per un anno accademico di un corso di studio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	///<summary>
	///2.4.10 curriculum
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	///<summary>
	///2.4.13 orientamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori 		=> (MetaTable)Tables["didprogori"];

	///<summary>
	///2.4.14 anno di corso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproganno 		=> (MetaTable)Tables["didproganno"];

	///<summary>
	///2.4.15 porzione d'anno
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzanno 		=> (MetaTable)Tables["didprogporzanno"];

	///<summary>
	///Tutti gli 2.4.7 Insegnamenti dell’istituto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegn 		=> (MetaTable)Tables["insegn"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegninteg 		=> (MetaTable)Tables["insegninteg"];

	///<summary>
	///caratteristiche dell'insegnamento nel vocabolario ovvero sasd e cf
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegncaratteristica 		=> (MetaTable)Tables["insegncaratteristica"];

	///<summary>
	///2.4.17 Canale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale 		=> (MetaTable)Tables["canale"];

	///<summary>
	///2.4.28 attività formativa: insegnamenti/moduli attivati in quella porzione d'anno
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegnintegcaratteristica 		=> (MetaTable)Tables["insegnintegcaratteristica"];

	///<summary>
	///2.4.18 Affidamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamento 		=> (MetaTable)Tables["affidamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristica 		=> (MetaTable)Tables["affidamentocaratteristica"];

	///<summary>
	///2.4.23 Lezione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable lezione 		=> (MetaTable)Tables["lezione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristicaora 		=> (MetaTable)Tables["affidamentocaratteristicaora"];

	///<summary>
	///Caratteristiche dell'2.4.28 attività formativa acquisite all'interno della didattica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformcaratteristica 		=> (MetaTable)Tables["attivformcaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformcaratteristicaora 		=> (MetaTable)Tables["attivformcaratteristicaora"];

	///<summary>
	///2.5.22 Didattica Erogata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diderog 		=> (MetaTable)Tables["diderog"];

	///<summary>
	///2.4.24 Aule
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aula 		=> (MetaTable)Tables["aula"];

	///<summary>
	///2.4.25 Edifici
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable edificio 		=> (MetaTable)Tables["edificio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_corsostudio_load(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_corsostudio_load (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_corsostudio_load";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_corsostudio_load.xsd";

	#region create DataTables
	//////////////////// CORSOSTUDIO /////////////////////////////////
	var tcorsostudio= new MetaTable("corsostudio");
	tcorsostudio.defineColumn("idcorsostudio", typeof(int),false);
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

	//////////////////// CORSOSTUDIOCLASSESCUOLA /////////////////////////////////
	var tcorsostudioclassescuola= new MetaTable("corsostudioclassescuola");
	tcorsostudioclassescuola.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudioclassescuola.defineColumn("idclassescuola", typeof(int),false);
	tcorsostudioclassescuola.defineColumn("ct", typeof(DateTime),false);
	tcorsostudioclassescuola.defineColumn("cu", typeof(string),false);
	tcorsostudioclassescuola.defineColumn("lt", typeof(DateTime),false);
	tcorsostudioclassescuola.defineColumn("lu", typeof(string),false);
	Tables.Add(tcorsostudioclassescuola);
	tcorsostudioclassescuola.defineKey("idcorsostudio", "idclassescuola");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
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
	tdidprog.defineColumn("iddidprognumchiusokind", typeof(int));
	tdidprog.defineColumn("iddidprogsuddannokind", typeof(int));
	tdidprog.defineColumn("iderogazkind", typeof(int));
	tdidprog.defineColumn("idgraduatoria", typeof(int));
	tdidprog.defineColumn("idnation_lang", typeof(int));
	tdidprog.defineColumn("idnation_lang2", typeof(int));
	tdidprog.defineColumn("idnation_langvis", typeof(int));
	tdidprog.defineColumn("idreg_docenti", typeof(int));
	tdidprog.defineColumn("idsede", typeof(int),false);
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
	tdidprog.defineKey("iddidprog", "idcorsostudio");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("codice", typeof(string));
	tdidprogcurr.defineColumn("codicemiur", typeof(string));
	tdidprogcurr.defineColumn("ct", typeof(DateTime),false);
	tdidprogcurr.defineColumn("cu", typeof(string),false);
	tdidprogcurr.defineColumn("lt", typeof(DateTime),false);
	tdidprogcurr.defineColumn("lu", typeof(string),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// DIDPROGORI /////////////////////////////////
	var tdidprogori= new MetaTable("didprogori");
	tdidprogori.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori.defineColumn("iddidprog", typeof(int),false);
	tdidprogori.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori.defineColumn("codice", typeof(string));
	tdidprogori.defineColumn("ct", typeof(DateTime),false);
	tdidprogori.defineColumn("cu", typeof(string),false);
	tdidprogori.defineColumn("lt", typeof(DateTime),false);
	tdidprogori.defineColumn("lu", typeof(string),false);
	tdidprogori.defineColumn("title", typeof(string));
	Tables.Add(tdidprogori);
	tdidprogori.defineKey("iddidprogori", "iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// DIDPROGANNO /////////////////////////////////
	var tdidproganno= new MetaTable("didproganno");
	tdidproganno.defineColumn("iddidproganno", typeof(int),false);
	tdidproganno.defineColumn("iddidprogori", typeof(int),false);
	tdidproganno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidproganno.defineColumn("iddidprog", typeof(int),false);
	tdidproganno.defineColumn("aa", typeof(string),false);
	tdidproganno.defineColumn("idcorsostudio", typeof(int),false);
	tdidproganno.defineColumn("anno", typeof(int));
	tdidproganno.defineColumn("cf", typeof(decimal));
	tdidproganno.defineColumn("ct", typeof(DateTime),false);
	tdidproganno.defineColumn("cu", typeof(string),false);
	tdidproganno.defineColumn("lt", typeof(DateTime),false);
	tdidproganno.defineColumn("lu", typeof(string),false);
	tdidproganno.defineColumn("title", typeof(string));
	Tables.Add(tdidproganno);
	tdidproganno.defineKey("iddidproganno", "iddidprogori", "iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// DIDPROGPORZANNO /////////////////////////////////
	var tdidprogporzanno= new MetaTable("didprogporzanno");
	tdidprogporzanno.defineColumn("iddidprogporzanno", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzanno.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzanno.defineColumn("aa", typeof(string),false);
	tdidprogporzanno.defineColumn("ct", typeof(DateTime),false);
	tdidprogporzanno.defineColumn("cu", typeof(string),false);
	tdidprogporzanno.defineColumn("iddidprogporzannokind", typeof(int));
	tdidprogporzanno.defineColumn("indice", typeof(int));
	tdidprogporzanno.defineColumn("lt", typeof(DateTime),false);
	tdidprogporzanno.defineColumn("lu", typeof(string),false);
	tdidprogporzanno.defineColumn("start", typeof(DateTime));
	tdidprogporzanno.defineColumn("stop", typeof(DateTime));
	tdidprogporzanno.defineColumn("title", typeof(string));
	Tables.Add(tdidprogporzanno);
	tdidprogporzanno.defineKey("iddidprogporzanno", "iddidproganno", "iddidprogori", "iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// INSEGN /////////////////////////////////
	var tinsegn= new MetaTable("insegn");
	tinsegn.defineColumn("idinsegn", typeof(int),false);
	tinsegn.defineColumn("codice", typeof(string));
	tinsegn.defineColumn("ct", typeof(DateTime),false);
	tinsegn.defineColumn("cu", typeof(string),false);
	tinsegn.defineColumn("denominazione", typeof(string));
	tinsegn.defineColumn("denominazione_en", typeof(string));
	tinsegn.defineColumn("idcorsostudio", typeof(int));
	tinsegn.defineColumn("idcorsostudiokind", typeof(int));
	tinsegn.defineColumn("idstruttura", typeof(int));
	tinsegn.defineColumn("lt", typeof(DateTime),false);
	tinsegn.defineColumn("lu", typeof(string),false);
	Tables.Add(tinsegn);
	tinsegn.defineKey("idinsegn");

	//////////////////// INSEGNINTEG /////////////////////////////////
	var tinsegninteg= new MetaTable("insegninteg");
	tinsegninteg.defineColumn("idinsegninteg", typeof(int),false);
	tinsegninteg.defineColumn("idinsegn", typeof(int),false);
	tinsegninteg.defineColumn("codice", typeof(string));
	tinsegninteg.defineColumn("ct", typeof(DateTime),false);
	tinsegninteg.defineColumn("cu", typeof(string),false);
	tinsegninteg.defineColumn("denominazione", typeof(string));
	tinsegninteg.defineColumn("denominazione_en", typeof(string));
	tinsegninteg.defineColumn("lt", typeof(DateTime),false);
	tinsegninteg.defineColumn("lu", typeof(string),false);
	Tables.Add(tinsegninteg);
	tinsegninteg.defineKey("idinsegninteg", "idinsegn");

	//////////////////// INSEGNCARATTERISTICA /////////////////////////////////
	var tinsegncaratteristica= new MetaTable("insegncaratteristica");
	tinsegncaratteristica.defineColumn("idinsegn", typeof(int),false);
	tinsegncaratteristica.defineColumn("idinsegncaratteristica", typeof(int),false);
	tinsegncaratteristica.defineColumn("cf", typeof(decimal));
	tinsegncaratteristica.defineColumn("ct", typeof(DateTime),false);
	tinsegncaratteristica.defineColumn("cu", typeof(string),false);
	tinsegncaratteristica.defineColumn("idsasd", typeof(int));
	tinsegncaratteristica.defineColumn("lt", typeof(DateTime),false);
	tinsegncaratteristica.defineColumn("lu", typeof(string),false);
	tinsegncaratteristica.defineColumn("profess", typeof(string),false);
	Tables.Add(tinsegncaratteristica);
	tinsegncaratteristica.defineKey("idinsegn", "idinsegncaratteristica");

	//////////////////// CANALE /////////////////////////////////
	var tcanale= new MetaTable("canale");
	tcanale.defineColumn("idcanale", typeof(int),false);
	tcanale.defineColumn("idattivform", typeof(int),false);
	tcanale.defineColumn("iddidprogporzanno", typeof(int),false);
	tcanale.defineColumn("iddidproganno", typeof(int),false);
	tcanale.defineColumn("iddidprogori", typeof(int),false);
	tcanale.defineColumn("iddidprogcurr", typeof(int),false);
	tcanale.defineColumn("iddidprog", typeof(int),false);
	tcanale.defineColumn("idcorsostudio", typeof(int),false);
	tcanale.defineColumn("aa", typeof(string),false);
	tcanale.defineColumn("ct", typeof(DateTime),false);
	tcanale.defineColumn("cu", typeof(string),false);
	tcanale.defineColumn("CUIN", typeof(string));
	tcanale.defineColumn("idsede", typeof(int),false);
	tcanale.defineColumn("lt", typeof(DateTime),false);
	tcanale.defineColumn("lu", typeof(string),false);
	tcanale.defineColumn("numerostud", typeof(int));
	tcanale.defineColumn("sortcode", typeof(int));
	tcanale.defineColumn("title", typeof(string));
	Tables.Add(tcanale);
	tcanale.defineKey("idcanale", "idattivform", "iddidprogporzanno", "iddidproganno", "iddidprogori", "iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// ATTIVFORM /////////////////////////////////
	var tattivform= new MetaTable("attivform");
	tattivform.defineColumn("idattivform", typeof(int),false);
	tattivform.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivform.defineColumn("iddidproganno", typeof(int),false);
	tattivform.defineColumn("iddidprogori", typeof(int),false);
	tattivform.defineColumn("iddidprogcurr", typeof(int),false);
	tattivform.defineColumn("iddidprog", typeof(int),false);
	tattivform.defineColumn("idcorsostudio", typeof(int),false);
	tattivform.defineColumn("aa", typeof(string),false);
	tattivform.defineColumn("ct", typeof(DateTime),false);
	tattivform.defineColumn("cu", typeof(string),false);
	tattivform.defineColumn("iddidproggrupp", typeof(int));
	tattivform.defineColumn("idinsegn", typeof(int),false);
	tattivform.defineColumn("idinsegninteg", typeof(int));
	tattivform.defineColumn("lt", typeof(DateTime),false);
	tattivform.defineColumn("lu", typeof(string),false);
	tattivform.defineColumn("obbform", typeof(string));
	tattivform.defineColumn("obbform_en", typeof(string));
	tattivform.defineColumn("sortcode", typeof(int));
	tattivform.defineColumn("start", typeof(DateTime));
	tattivform.defineColumn("stop", typeof(DateTime));
	tattivform.defineColumn("tipovalutaz", typeof(string));
	tattivform.defineColumn("title", typeof(string));
	tattivform.defineColumn("idsede", typeof(int),false);
	Tables.Add(tattivform);
	tattivform.defineKey("idattivform", "iddidprogporzanno", "iddidproganno", "iddidprogori", "iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// INSEGNINTEGCARATTERISTICA /////////////////////////////////
	var tinsegnintegcaratteristica= new MetaTable("insegnintegcaratteristica");
	tinsegnintegcaratteristica.defineColumn("idinsegn", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idinsegninteg", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idinsegnintegcaratteristica", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("cf", typeof(decimal));
	tinsegnintegcaratteristica.defineColumn("ct", typeof(DateTime),false);
	tinsegnintegcaratteristica.defineColumn("cu", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("idsasd", typeof(int));
	tinsegnintegcaratteristica.defineColumn("lt", typeof(DateTime),false);
	tinsegnintegcaratteristica.defineColumn("lu", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("profess", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("json", typeof(string));
	Tables.Add(tinsegnintegcaratteristica);
	tinsegnintegcaratteristica.defineKey("idinsegn", "idinsegninteg", "idinsegnintegcaratteristica");

	//////////////////// AFFIDAMENTO /////////////////////////////////
	var taffidamento= new MetaTable("affidamento");
	taffidamento.defineColumn("idaffidamento", typeof(int),false);
	taffidamento.defineColumn("idcanale", typeof(int),false);
	taffidamento.defineColumn("idattivform", typeof(int),false);
	taffidamento.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamento.defineColumn("iddidproganno", typeof(int),false);
	taffidamento.defineColumn("iddidprogori", typeof(int),false);
	taffidamento.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamento.defineColumn("iddidprog", typeof(int),false);
	taffidamento.defineColumn("idaffidamentokind", typeof(int),false);
	taffidamento.defineColumn("gratuito", typeof(string),false);
	taffidamento.defineColumn("start", typeof(DateTime));
	taffidamento.defineColumn("stop", typeof(DateTime));
	taffidamento.defineColumn("riferimento", typeof(string),false);
	taffidamento.defineColumn("prog", typeof(string));
	taffidamento.defineColumn("prog_en", typeof(string));
	taffidamento.defineColumn("testi", typeof(string));
	taffidamento.defineColumn("testi_en", typeof(string));
	taffidamento.defineColumn("orariric", typeof(string));
	taffidamento.defineColumn("orariric_en", typeof(string));
	taffidamento.defineColumn("urlcorso", typeof(string));
	taffidamento.defineColumn("iderogazkind", typeof(int));
	taffidamento.defineColumn("freqobbl", typeof(string));
	taffidamento.defineColumn("idreg_docenti", typeof(int));
	taffidamento.defineColumn("paridaffidamento", typeof(int));
	taffidamento.defineColumn("ct", typeof(DateTime),false);
	taffidamento.defineColumn("cu", typeof(string),false);
	taffidamento.defineColumn("lt", typeof(DateTime),false);
	taffidamento.defineColumn("lu", typeof(string),false);
	taffidamento.defineColumn("idcorsostudio", typeof(int),false);
	taffidamento.defineColumn("aa", typeof(string),false);
	taffidamento.defineColumn("title", typeof(string));
	taffidamento.defineColumn("frequenzaminima", typeof(int));
	taffidamento.defineColumn("frequenzaminimadebito", typeof(int));
	taffidamento.defineColumn("json", typeof(string));
	taffidamento.defineColumn("jsonancestor", typeof(string));
	taffidamento.defineColumn("idsede", typeof(int),false);
	Tables.Add(taffidamento);
	taffidamento.defineKey("idaffidamento", "idcanale", "idattivform", "iddidprogporzanno", "iddidproganno", "iddidprogori", "iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// AFFIDAMENTOCARATTERISTICA /////////////////////////////////
	var taffidamentocaratteristica= new MetaTable("affidamentocaratteristica");
	taffidamentocaratteristica.defineColumn("idaffidamentocaratteristica", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idaffidamento", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idcanale", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idattivform", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidproganno", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogori", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprog", typeof(int),false);
	taffidamentocaratteristica.defineColumn("ct", typeof(DateTime),false);
	taffidamentocaratteristica.defineColumn("cu", typeof(string),false);
	taffidamentocaratteristica.defineColumn("lt", typeof(DateTime),false);
	taffidamentocaratteristica.defineColumn("lu", typeof(string),false);
	taffidamentocaratteristica.defineColumn("idtipoattform", typeof(int));
	taffidamentocaratteristica.defineColumn("idambitoareadisc", typeof(int));
	taffidamentocaratteristica.defineColumn("idsasdgruppo", typeof(int));
	taffidamentocaratteristica.defineColumn("idsasd", typeof(int));
	taffidamentocaratteristica.defineColumn("cf", typeof(decimal));
	taffidamentocaratteristica.defineColumn("profess", typeof(string),false);
	taffidamentocaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentocaratteristica.defineColumn("aa", typeof(string),false);
	taffidamentocaratteristica.defineColumn("title", typeof(string));
	taffidamentocaratteristica.defineColumn("json", typeof(string));
	Tables.Add(taffidamentocaratteristica);
	taffidamentocaratteristica.defineKey("idaffidamentocaratteristica", "idaffidamento", "idcanale", "idattivform", "iddidprogporzanno", "iddidproganno", "iddidprogori", "iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// LEZIONE /////////////////////////////////
	var tlezione= new MetaTable("lezione");
	tlezione.defineColumn("idlezione", typeof(int),false);
	tlezione.defineColumn("idaffidamento", typeof(int),false);
	tlezione.defineColumn("idcanale", typeof(int),false);
	tlezione.defineColumn("idattivform", typeof(int),false);
	tlezione.defineColumn("iddidprogporzanno", typeof(int),false);
	tlezione.defineColumn("iddidproganno", typeof(int),false);
	tlezione.defineColumn("iddidprogori", typeof(int),false);
	tlezione.defineColumn("iddidprogcurr", typeof(int),false);
	tlezione.defineColumn("iddidprog", typeof(int),false);
	tlezione.defineColumn("start", typeof(DateTime),false);
	tlezione.defineColumn("stop", typeof(DateTime),false);
	tlezione.defineColumn("idaula", typeof(int),false);
	tlezione.defineColumn("idsede", typeof(int),false);
	tlezione.defineColumn("idedificio", typeof(int),false);
	tlezione.defineColumn("ct", typeof(DateTime),false);
	tlezione.defineColumn("cu", typeof(string),false);
	tlezione.defineColumn("lt", typeof(DateTime),false);
	tlezione.defineColumn("lu", typeof(string),false);
	tlezione.defineColumn("idcorsostudio", typeof(int),false);
	tlezione.defineColumn("aa", typeof(string),false);
	tlezione.defineColumn("visita", typeof(string));
	tlezione.defineColumn("nonsvolta", typeof(string));
	tlezione.defineColumn("stage", typeof(string));
	tlezione.defineColumn("idreg_docenti", typeof(int),false);
	Tables.Add(tlezione);
	tlezione.defineKey("idlezione", "idaffidamento", "idcanale", "idattivform", "iddidprogporzanno", "iddidproganno", "iddidprogori", "iddidprogcurr", "iddidprog", "idaula", "idsede", "idedificio", "idcorsostudio", "aa", "idreg_docenti");

	//////////////////// AFFIDAMENTOCARATTERISTICAORA /////////////////////////////////
	var taffidamentocaratteristicaora= new MetaTable("affidamentocaratteristicaora");
	taffidamentocaratteristicaora.defineColumn("idaffidamentocaratteristicaora", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamentocaratteristica", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamento", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idcanale", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idattivform", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidproganno", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogori", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprog", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("ora", typeof(int));
	taffidamentocaratteristicaora.defineColumn("idorakind", typeof(int));
	taffidamentocaratteristicaora.defineColumn("ct", typeof(DateTime),false);
	taffidamentocaratteristicaora.defineColumn("cu", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("lt", typeof(DateTime),false);
	taffidamentocaratteristicaora.defineColumn("lu", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("aa", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("ripetizioni", typeof(int));
	Tables.Add(taffidamentocaratteristicaora);
	taffidamentocaratteristicaora.defineKey("idaffidamentocaratteristicaora", "idaffidamentocaratteristica", "idaffidamento", "idcanale", "idattivform", "iddidprogporzanno", "iddidproganno", "iddidprogori", "iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// ATTIVFORMCARATTERISTICA /////////////////////////////////
	var tattivformcaratteristica= new MetaTable("attivformcaratteristica");
	tattivformcaratteristica.defineColumn("idattivformcaratteristica", typeof(int),false);
	tattivformcaratteristica.defineColumn("idattivform", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidproganno", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogori", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprog", typeof(int),false);
	tattivformcaratteristica.defineColumn("ct", typeof(DateTime),false);
	tattivformcaratteristica.defineColumn("cu", typeof(string),false);
	tattivformcaratteristica.defineColumn("lt", typeof(DateTime),false);
	tattivformcaratteristica.defineColumn("lu", typeof(string),false);
	tattivformcaratteristica.defineColumn("idtipoattform", typeof(int));
	tattivformcaratteristica.defineColumn("idambitoareadisc", typeof(int));
	tattivformcaratteristica.defineColumn("idsasdgruppo", typeof(int));
	tattivformcaratteristica.defineColumn("idsasd", typeof(int));
	tattivformcaratteristica.defineColumn("cf", typeof(decimal));
	tattivformcaratteristica.defineColumn("profess", typeof(string),false);
	tattivformcaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	tattivformcaratteristica.defineColumn("aa", typeof(string),false);
	tattivformcaratteristica.defineColumn("title", typeof(string));
	tattivformcaratteristica.defineColumn("json", typeof(string));
	Tables.Add(tattivformcaratteristica);
	tattivformcaratteristica.defineKey("idattivformcaratteristica", "idattivform", "iddidprogporzanno", "iddidproganno", "iddidprogori", "iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// ATTIVFORMCARATTERISTICAORA /////////////////////////////////
	var tattivformcaratteristicaora= new MetaTable("attivformcaratteristicaora");
	tattivformcaratteristicaora.defineColumn("idattivformcaratteristicaora", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idattivformcaratteristica", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idattivform", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidproganno", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogori", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprog", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("ora", typeof(int));
	tattivformcaratteristicaora.defineColumn("idorakind", typeof(int));
	tattivformcaratteristicaora.defineColumn("ct", typeof(DateTime),false);
	tattivformcaratteristicaora.defineColumn("cu", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("lt", typeof(DateTime),false);
	tattivformcaratteristicaora.defineColumn("lu", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("idcorsostudio", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("aa", typeof(string),false);
	Tables.Add(tattivformcaratteristicaora);
	tattivformcaratteristicaora.defineKey("idattivformcaratteristicaora", "idattivformcaratteristica", "idattivform", "iddidprogporzanno", "iddidproganno", "iddidprogori", "iddidprogcurr", "iddidprog", "idcorsostudio");

	//////////////////// DIDEROG /////////////////////////////////
	var tdiderog= new MetaTable("diderog");
	tdiderog.defineColumn("idcorsostudio", typeof(int),false);
	tdiderog.defineColumn("aa", typeof(string),false);
	tdiderog.defineColumn("inesaurimento", typeof(string));
	tdiderog.defineColumn("idsede", typeof(int),false);
	Tables.Add(tdiderog);
	tdiderog.defineKey("idcorsostudio", "aa", "idsede");

	//////////////////// AULA /////////////////////////////////
	var taula= new MetaTable("aula");
	taula.defineColumn("idaula", typeof(int),false);
	taula.defineColumn("idedificio", typeof(int),false);
	taula.defineColumn("idsede", typeof(int),false);
	taula.defineColumn("address", typeof(string));
	taula.defineColumn("cap", typeof(string));
	taula.defineColumn("capienza", typeof(int));
	taula.defineColumn("capienzadis", typeof(int));
	taula.defineColumn("code", typeof(string));
	taula.defineColumn("ct", typeof(DateTime),false);
	taula.defineColumn("cu", typeof(string),false);
	taula.defineColumn("dotazioni", typeof(string));
	taula.defineColumn("idaulakind", typeof(int));
	taula.defineColumn("idcity", typeof(int));
	taula.defineColumn("idnation", typeof(int));
	taula.defineColumn("idstruttura", typeof(int));
	taula.defineColumn("latitude", typeof(double));
	taula.defineColumn("location", typeof(string));
	taula.defineColumn("longitude", typeof(double));
	taula.defineColumn("lt", typeof(DateTime),false);
	taula.defineColumn("lu", typeof(string),false);
	taula.defineColumn("title", typeof(string));
	Tables.Add(taula);
	taula.defineKey("idaula", "idedificio", "idsede");

	//////////////////// EDIFICIO /////////////////////////////////
	var tedificio= new MetaTable("edificio");
	tedificio.defineColumn("idedificio", typeof(int),false);
	tedificio.defineColumn("idsede", typeof(int),false);
	tedificio.defineColumn("address", typeof(string));
	tedificio.defineColumn("cap", typeof(string));
	tedificio.defineColumn("code", typeof(string));
	tedificio.defineColumn("ct", typeof(DateTime),false);
	tedificio.defineColumn("cu", typeof(string),false);
	tedificio.defineColumn("idcity", typeof(int));
	tedificio.defineColumn("idnation", typeof(int));
	tedificio.defineColumn("latitude", typeof(double));
	tedificio.defineColumn("location", typeof(string));
	tedificio.defineColumn("longitude", typeof(double));
	tedificio.defineColumn("lt", typeof(DateTime),false);
	tedificio.defineColumn("lu", typeof(string),false);
	tedificio.defineColumn("title", typeof(string));
	Tables.Add(tedificio);
	tedificio.defineKey("idedificio", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{corsostudio.Columns["idcorsostudio"]};
	var cChild = new []{corsostudioclassescuola.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("corsostudio_corsostudioclassescuola",cPar,cChild,false));

	cPar = new []{corsostudio.Columns["idcorsostudio"]};
	cChild = new []{didprog.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("corsostudio_didprog",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"], didprog.Columns["idcorsostudio"]};
	cChild = new []{didprogcurr.Columns["iddidprog"], didprogcurr.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("didprog_didprogcurr",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"], didprogcurr.Columns["iddidprog"], didprogcurr.Columns["idcorsostudio"]};
	cChild = new []{didprogori.Columns["iddidprogcurr"], didprogori.Columns["iddidprog"], didprogori.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("didprogcurr_didprogori",cPar,cChild,false));

	cPar = new []{didprogori.Columns["iddidprogori"], didprogori.Columns["iddidprogcurr"], didprogori.Columns["iddidprog"], didprogori.Columns["idcorsostudio"]};
	cChild = new []{didproganno.Columns["iddidprogori"], didproganno.Columns["iddidprogcurr"], didproganno.Columns["iddidprog"], didproganno.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("didprogori_didproganno",cPar,cChild,false));

	cPar = new []{insegn.Columns["idinsegn"]};
	cChild = new []{insegninteg.Columns["idinsegn"]};
	Relations.Add(new DataRelation("insegn_insegninteg",cPar,cChild,false));

	cPar = new []{insegn.Columns["idinsegn"]};
	cChild = new []{insegncaratteristica.Columns["idinsegn"]};
	Relations.Add(new DataRelation("insegn_insegncaratteristica",cPar,cChild,false));

	cPar = new []{didproganno.Columns["iddidproganno"], didproganno.Columns["iddidprogori"], didproganno.Columns["iddidprogcurr"], didproganno.Columns["iddidprog"], didproganno.Columns["idcorsostudio"], didproganno.Columns["aa"]};
	cChild = new []{didprogporzanno.Columns["iddidproganno"], didprogporzanno.Columns["iddidprogori"], didprogporzanno.Columns["iddidprogcurr"], didprogporzanno.Columns["iddidprog"], didprogporzanno.Columns["idcorsostudio"], didprogporzanno.Columns["aa"]};
	Relations.Add(new DataRelation("didproganno_didprogporzanno",cPar,cChild,false));

	cPar = new []{attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogporzanno"], attivform.Columns["aa"]};
	cChild = new []{attivformcaratteristica.Columns["idattivform"], attivformcaratteristica.Columns["idcorsostudio"], attivformcaratteristica.Columns["iddidprog"], attivformcaratteristica.Columns["iddidprogcurr"], attivformcaratteristica.Columns["iddidprogori"], attivformcaratteristica.Columns["iddidproganno"], attivformcaratteristica.Columns["iddidprogporzanno"], attivformcaratteristica.Columns["aa"]};
	Relations.Add(new DataRelation("attivform_attivformcaratteristica",cPar,cChild,false));

	cPar = new []{attivformcaratteristica.Columns["idattivformcaratteristica"], attivformcaratteristica.Columns["idattivform"], attivformcaratteristica.Columns["idcorsostudio"], attivformcaratteristica.Columns["iddidprog"], attivformcaratteristica.Columns["iddidprogcurr"], attivformcaratteristica.Columns["iddidprogori"], attivformcaratteristica.Columns["iddidproganno"], attivformcaratteristica.Columns["iddidprogporzanno"], attivformcaratteristica.Columns["aa"]};
	cChild = new []{attivformcaratteristicaora.Columns["idattivformcaratteristica"], attivformcaratteristicaora.Columns["idattivform"], attivformcaratteristicaora.Columns["idcorsostudio"], attivformcaratteristicaora.Columns["iddidprog"], attivformcaratteristicaora.Columns["iddidprogcurr"], attivformcaratteristicaora.Columns["iddidprogori"], attivformcaratteristicaora.Columns["iddidproganno"], attivformcaratteristicaora.Columns["iddidprogporzanno"], attivformcaratteristicaora.Columns["aa"]};
	Relations.Add(new DataRelation("attivformcaratteristica_attivformcaratteristicaora",cPar,cChild,false));

	cPar = new []{didprogporzanno.Columns["idcorsostudio"], didprogporzanno.Columns["iddidprog"], didprogporzanno.Columns["iddidprogcurr"], didprogporzanno.Columns["iddidprogori"], didprogporzanno.Columns["iddidproganno"], didprogporzanno.Columns["iddidprogporzanno"]};
	cChild = new []{attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("attivform_didprogporzanno",cPar,cChild,false));

	cPar = new []{attivform.Columns["idattivform"], attivform.Columns["iddidprogporzanno"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprog"], attivform.Columns["idcorsostudio"]};
	cChild = new []{canale.Columns["idattivform"], canale.Columns["iddidprogporzanno"], canale.Columns["iddidproganno"], canale.Columns["iddidprogori"], canale.Columns["iddidprogcurr"], canale.Columns["iddidprog"], canale.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("canale_attivform",cPar,cChild,false));

	cPar = new []{canale.Columns["idcanale"], canale.Columns["idattivform"], canale.Columns["iddidprogcurr"], canale.Columns["iddidprogori"], canale.Columns["iddidprog"], canale.Columns["iddidproganno"], canale.Columns["iddidprogporzanno"], canale.Columns["idcorsostudio"]};
	cChild = new []{affidamento.Columns["idcanale"], affidamento.Columns["idattivform"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogporzanno"], affidamento.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("canale_affidamento",cPar,cChild,false));

	cPar = new []{affidamento.Columns["idaffidamento"], affidamento.Columns["idcanale"], affidamento.Columns["idattivform"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogporzanno"], affidamento.Columns["idcorsostudio"]};
	cChild = new []{affidamentocaratteristica.Columns["idaffidamento"], affidamentocaratteristica.Columns["idcanale"], affidamentocaratteristica.Columns["idattivform"], affidamentocaratteristica.Columns["iddidprog"], affidamentocaratteristica.Columns["iddidprogcurr"], affidamentocaratteristica.Columns["iddidprogori"], affidamentocaratteristica.Columns["iddidproganno"], affidamentocaratteristica.Columns["iddidprogporzanno"], affidamentocaratteristica.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("affidamento_affidamentocaratteristica",cPar,cChild,false));

	cPar = new []{affidamentocaratteristica.Columns["idaffidamentocaratteristica"], affidamentocaratteristica.Columns["iddidproganno"], affidamentocaratteristica.Columns["iddidprogporzanno"], affidamentocaratteristica.Columns["idattivform"], affidamentocaratteristica.Columns["idcanale"], affidamentocaratteristica.Columns["idaffidamento"], affidamentocaratteristica.Columns["iddidprog"], affidamentocaratteristica.Columns["iddidprogcurr"], affidamentocaratteristica.Columns["idcorsostudio"], affidamentocaratteristica.Columns["iddidprogori"]};
	cChild = new []{affidamentocaratteristicaora.Columns["idaffidamentocaratteristica"], affidamentocaratteristicaora.Columns["iddidproganno"], affidamentocaratteristicaora.Columns["iddidprogporzanno"], affidamentocaratteristicaora.Columns["idattivform"], affidamentocaratteristicaora.Columns["idcanale"], affidamentocaratteristicaora.Columns["idaffidamento"], affidamentocaratteristicaora.Columns["iddidprog"], affidamentocaratteristicaora.Columns["iddidprogcurr"], affidamentocaratteristicaora.Columns["idcorsostudio"], affidamentocaratteristicaora.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("affidamentocaratteristica_affidamentocaratteristicaora",cPar,cChild,false));

	cPar = new []{insegninteg.Columns["idinsegninteg"], insegninteg.Columns["idinsegn"]};
	cChild = new []{insegnintegcaratteristica.Columns["idinsegninteg"], insegnintegcaratteristica.Columns["idinsegn"]};
	Relations.Add(new DataRelation("insegnintegcaratteristica_insegninteg",cPar,cChild,false));

	cPar = new []{corsostudio.Columns["idcorsostudio"]};
	cChild = new []{diderog.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("corsostudio_diderog",cPar,cChild,false));

	cPar = new []{affidamento.Columns["idaffidamento"], affidamento.Columns["idcanale"], affidamento.Columns["idattivform"], affidamento.Columns["iddidprog"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogporzanno"], affidamento.Columns["aa"]};
	cChild = new []{lezione.Columns["idaffidamento"], lezione.Columns["idcanale"], lezione.Columns["idattivform"], lezione.Columns["iddidprog"], lezione.Columns["idcorsostudio"], lezione.Columns["iddidprogcurr"], lezione.Columns["iddidprogori"], lezione.Columns["iddidproganno"], lezione.Columns["iddidprogporzanno"], lezione.Columns["aa"]};
	Relations.Add(new DataRelation("affidamentocaratteristica_lezione",cPar,cChild,false));

	cPar = new []{edificio.Columns["idsede"], edificio.Columns["idedificio"]};
	cChild = new []{aula.Columns["idsede"], aula.Columns["idedificio"]};
	Relations.Add(new DataRelation("edificio_aula",cPar,cChild,false));

	#endregion

}
}
}
