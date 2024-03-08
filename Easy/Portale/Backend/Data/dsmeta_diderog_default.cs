
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
[System.Xml.Serialization.XmlRoot("dsmeta_diderog_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_diderog_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getcostididattica 		=> (MetaTable)Tables["getcostididattica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentoattach 		=> (MetaTable)Tables["affidamentoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable lezione 		=> (MetaTable)Tables["lezione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristicaora 		=> (MetaTable)Tables["affidamentocaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristica 		=> (MetaTable)Tables["affidamentocaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable erogazkind 		=> (MetaTable)Tables["erogazkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentokind 		=> (MetaTable)Tables["affidamentokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamento 		=> (MetaTable)Tables["affidamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazionecaratteristicaora 		=> (MetaTable)Tables["mutuazionecaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazionecaratteristica 		=> (MetaTable)Tables["mutuazionecaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale_alias2 		=> (MetaTable)Tables["canale_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazione 		=> (MetaTable)Tables["mutuazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzanno_alias1 		=> (MetaTable)Tables["didprogporzanno_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori_alias1 		=> (MetaTable)Tables["didprogori_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr_alias1 		=> (MetaTable)Tables["didprogcurr_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproganno_alias1 		=> (MetaTable)Tables["didproganno_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform_alias2 		=> (MetaTable)Tables["attivform_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale 		=> (MetaTable)Tables["canale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformcaratteristicaora 		=> (MetaTable)Tables["attivformcaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppo 		=> (MetaTable)Tables["sasdgruppo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadisc 		=> (MetaTable)Tables["ambitoareadisc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformcaratteristica 		=> (MetaTable)Tables["attivformcaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appelloattivform 		=> (MetaTable)Tables["appelloattivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformvalutazionekind 		=> (MetaTable)Tables["attivformvalutazionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegninteg 		=> (MetaTable)Tables["insegninteg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegn 		=> (MetaTable)Tables["insegn"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzanno 		=> (MetaTable)Tables["didprogporzanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori 		=> (MetaTable)Tables["didprogori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproggrupp 		=> (MetaTable)Tables["didproggrupp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproganno 		=> (MetaTable)Tables["didproganno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sededefaultview 		=> (MetaTable)Tables["sededefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diderog 		=> (MetaTable)Tables["diderog"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_diderog_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_diderog_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_diderog_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_diderog_default.xsd";

	#region create DataTables
	//////////////////// GETCOSTIDIDATTICA /////////////////////////////////
	var tgetcostididattica= new MetaTable("getcostididattica");
	tgetcostididattica.defineColumn("aa", typeof(string),false);
	tgetcostididattica.defineColumn("aaprogrammata", typeof(string));
	tgetcostididattica.defineColumn("affidamento", typeof(string),false);
	tgetcostididattica.defineColumn("corsostudio", typeof(string));
	tgetcostididattica.defineColumn("costo", typeof(decimal));
	tgetcostididattica.defineColumn("costoorariodacontratto", typeof(string),false);
	tgetcostididattica.defineColumn("curriculum", typeof(string));
	tgetcostididattica.defineColumn("docente", typeof(string));
	tgetcostididattica.defineColumn("idaffidamento", typeof(int),false);
	tgetcostididattica.defineColumn("idaffidamentokind", typeof(int),false);
	tgetcostididattica.defineColumn("idcorsostudio", typeof(int),false);
	tgetcostididattica.defineColumn("iddidprog", typeof(int),false);
	tgetcostididattica.defineColumn("iddidprogcurr", typeof(int),false);
	tgetcostididattica.defineColumn("idinsegn", typeof(int),false);
	tgetcostididattica.defineColumn("idinsegninteg", typeof(int));
	tgetcostididattica.defineColumn("idposition", typeof(int),false);
	tgetcostididattica.defineColumn("idreg_docenti", typeof(int));
	tgetcostididattica.defineColumn("idsede", typeof(int),false);
	tgetcostididattica.defineColumn("insegnamento", typeof(string));
	tgetcostididattica.defineColumn("modulo", typeof(string));
	tgetcostididattica.defineColumn("ruolo", typeof(string),false);
	tgetcostididattica.defineColumn("sede", typeof(string));
	Tables.Add(tgetcostididattica);
	tgetcostididattica.defineKey("aa", "idaffidamento", "idcorsostudio", "iddidprog", "iddidprogcurr", "idposition", "idsede");

	//////////////////// AFFIDAMENTOATTACH /////////////////////////////////
	var taffidamentoattach= new MetaTable("affidamentoattach");
	taffidamentoattach.defineColumn("aa", typeof(string),false);
	taffidamentoattach.defineColumn("ct", typeof(DateTime),false);
	taffidamentoattach.defineColumn("cu", typeof(string),false);
	taffidamentoattach.defineColumn("idaffidamento", typeof(int),false);
	taffidamentoattach.defineColumn("idattach", typeof(int),false);
	taffidamentoattach.defineColumn("idattivform", typeof(int),false);
	taffidamentoattach.defineColumn("idcanale", typeof(int),false);
	taffidamentoattach.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprog", typeof(int),false);
	taffidamentoattach.defineColumn("iddidproganno", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprogori", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentoattach.defineColumn("idreg_docenti", typeof(int));
	taffidamentoattach.defineColumn("lt", typeof(DateTime),false);
	taffidamentoattach.defineColumn("lu", typeof(string),false);
	Tables.Add(taffidamentoattach);
	taffidamentoattach.defineKey("aa", "idaffidamento", "idattach", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// LEZIONE /////////////////////////////////
	var tlezione= new MetaTable("lezione");
	tlezione.defineColumn("!title", typeof(string));
	tlezione.defineColumn("aa", typeof(string),false);
	tlezione.defineColumn("ct", typeof(DateTime),false);
	tlezione.defineColumn("cu", typeof(string),false);
	tlezione.defineColumn("idaffidamento", typeof(int),false);
	tlezione.defineColumn("idattivform", typeof(int),false);
	tlezione.defineColumn("idaula", typeof(int),false);
	tlezione.defineColumn("idcanale", typeof(int),false);
	tlezione.defineColumn("idcorsostudio", typeof(int),false);
	tlezione.defineColumn("iddidprog", typeof(int),false);
	tlezione.defineColumn("iddidproganno", typeof(int),false);
	tlezione.defineColumn("iddidprogcurr", typeof(int),false);
	tlezione.defineColumn("iddidprogori", typeof(int),false);
	tlezione.defineColumn("iddidprogporzanno", typeof(int),false);
	tlezione.defineColumn("idedificio", typeof(int),false);
	tlezione.defineColumn("idlezione", typeof(int),false);
	tlezione.defineColumn("idreg_docenti", typeof(int),false);
	tlezione.defineColumn("idsede", typeof(int),false);
	tlezione.defineColumn("lt", typeof(DateTime),false);
	tlezione.defineColumn("lu", typeof(string),false);
	tlezione.defineColumn("nonsvolta", typeof(string));
	tlezione.defineColumn("stage", typeof(string));
	tlezione.defineColumn("start", typeof(DateTime),false);
	tlezione.defineColumn("stop", typeof(DateTime),false);
	tlezione.defineColumn("visita", typeof(string));
	Tables.Add(tlezione);
	tlezione.defineKey("aa", "idaffidamento", "idattivform", "idaula", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idedificio", "idlezione", "idreg_docenti", "idsede");

	//////////////////// AFFIDAMENTOCARATTERISTICAORA /////////////////////////////////
	var taffidamentocaratteristicaora= new MetaTable("affidamentocaratteristicaora");
	taffidamentocaratteristicaora.defineColumn("aa", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("ct", typeof(DateTime),false);
	taffidamentocaratteristicaora.defineColumn("cu", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamento", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamentocaratteristica", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamentocaratteristicaora", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idattivform", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idcanale", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprog", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidproganno", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogori", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idorakind", typeof(int));
	taffidamentocaratteristicaora.defineColumn("lt", typeof(DateTime),false);
	taffidamentocaratteristicaora.defineColumn("lu", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("ora", typeof(int));
	taffidamentocaratteristicaora.defineColumn("ripetizioni", typeof(int));
	Tables.Add(taffidamentocaratteristicaora);
	taffidamentocaratteristicaora.defineKey("aa", "idaffidamento", "idaffidamentocaratteristica", "idaffidamentocaratteristicaora", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// AFFIDAMENTOCARATTERISTICA /////////////////////////////////
	var taffidamentocaratteristica= new MetaTable("affidamentocaratteristica");
	taffidamentocaratteristica.defineColumn("aa", typeof(string),false);
	taffidamentocaratteristica.defineColumn("cf", typeof(decimal));
	taffidamentocaratteristica.defineColumn("ct", typeof(DateTime),false);
	taffidamentocaratteristica.defineColumn("cu", typeof(string),false);
	taffidamentocaratteristica.defineColumn("idaffidamento", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idaffidamentocaratteristica", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idambitoareadisc", typeof(int));
	taffidamentocaratteristica.defineColumn("idattivform", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idcanale", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprog", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidproganno", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogori", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idsasd", typeof(int));
	taffidamentocaratteristica.defineColumn("idsasdgruppo", typeof(int));
	taffidamentocaratteristica.defineColumn("idtipoattform", typeof(int));
	taffidamentocaratteristica.defineColumn("json", typeof(string));
	taffidamentocaratteristica.defineColumn("lt", typeof(DateTime),false);
	taffidamentocaratteristica.defineColumn("lu", typeof(string),false);
	taffidamentocaratteristica.defineColumn("profess", typeof(string),false);
	taffidamentocaratteristica.defineColumn("title", typeof(string));
	Tables.Add(taffidamentocaratteristica);
	taffidamentocaratteristica.defineKey("aa", "idaffidamento", "idaffidamentocaratteristica", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// EROGAZKIND /////////////////////////////////
	var terogazkind= new MetaTable("erogazkind");
	terogazkind.defineColumn("active", typeof(string),false);
	terogazkind.defineColumn("iderogazkind", typeof(int),false);
	terogazkind.defineColumn("title", typeof(string),false);
	Tables.Add(terogazkind);
	terogazkind.defineKey("iderogazkind");

	//////////////////// AFFIDAMENTOKIND /////////////////////////////////
	var taffidamentokind= new MetaTable("affidamentokind");
	taffidamentokind.defineColumn("active", typeof(string),false);
	taffidamentokind.defineColumn("idaffidamentokind", typeof(int),false);
	taffidamentokind.defineColumn("title", typeof(string),false);
	Tables.Add(taffidamentokind);
	taffidamentokind.defineKey("idaffidamentokind");

	//////////////////// AFFIDAMENTO /////////////////////////////////
	var taffidamento= new MetaTable("affidamento");
	taffidamento.defineColumn("aa", typeof(string),false);
	taffidamento.defineColumn("ct", typeof(DateTime),false);
	taffidamento.defineColumn("cu", typeof(string),false);
	taffidamento.defineColumn("freqobbl", typeof(string));
	taffidamento.defineColumn("frequenzaminima", typeof(int));
	taffidamento.defineColumn("frequenzaminimadebito", typeof(int));
	taffidamento.defineColumn("gratuito", typeof(string),false);
	taffidamento.defineColumn("idaffidamento", typeof(int),false);
	taffidamento.defineColumn("idaffidamentokind", typeof(int),false);
	taffidamento.defineColumn("idattivform", typeof(int),false);
	taffidamento.defineColumn("idcanale", typeof(int),false);
	taffidamento.defineColumn("idcorsostudio", typeof(int),false);
	taffidamento.defineColumn("iddidprog", typeof(int),false);
	taffidamento.defineColumn("iddidproganno", typeof(int),false);
	taffidamento.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamento.defineColumn("iddidprogori", typeof(int),false);
	taffidamento.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamento.defineColumn("iderogazkind", typeof(int));
	taffidamento.defineColumn("idreg_docenti", typeof(int));
	taffidamento.defineColumn("idsede", typeof(int),false);
	taffidamento.defineColumn("json", typeof(string));
	taffidamento.defineColumn("jsonancestor", typeof(string));
	taffidamento.defineColumn("lt", typeof(DateTime),false);
	taffidamento.defineColumn("lu", typeof(string),false);
	taffidamento.defineColumn("orariric", typeof(string));
	taffidamento.defineColumn("orariric_en", typeof(string));
	taffidamento.defineColumn("paridaffidamento", typeof(int));
	taffidamento.defineColumn("prog", typeof(string));
	taffidamento.defineColumn("prog_en", typeof(string));
	taffidamento.defineColumn("riferimento", typeof(string),false);
	taffidamento.defineColumn("start", typeof(DateTime));
	taffidamento.defineColumn("stop", typeof(DateTime));
	taffidamento.defineColumn("testi", typeof(string));
	taffidamento.defineColumn("testi_en", typeof(string));
	taffidamento.defineColumn("title", typeof(string));
	taffidamento.defineColumn("urlcorso", typeof(string));
	taffidamento.defineColumn("!idaffidamentokind_affidamentokind_title", typeof(string));
	taffidamento.defineColumn("!iderogazkind_erogazkind_title", typeof(string));
	taffidamento.defineColumn("!idreg_docenti_registry_title", typeof(string));
	Tables.Add(taffidamento);
	taffidamento.defineKey("aa", "idaffidamento", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// MUTUAZIONECARATTERISTICAORA /////////////////////////////////
	var tmutuazionecaratteristicaora= new MetaTable("mutuazionecaratteristicaora");
	tmutuazionecaratteristicaora.defineColumn("aa", typeof(string),false);
	tmutuazionecaratteristicaora.defineColumn("ct", typeof(DateTime),false);
	tmutuazionecaratteristicaora.defineColumn("cu", typeof(string),false);
	tmutuazionecaratteristicaora.defineColumn("idattivform", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idcanale", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idcorsostudio", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("iddidprog", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("iddidproganno", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("iddidprogcurr", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("iddidprogori", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("iddidprogporzanno", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idmutuazione", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idmutuazionecaratteristica", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idmutuazionecaratteristicaora", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idorakind", typeof(int));
	tmutuazionecaratteristicaora.defineColumn("lt", typeof(DateTime),false);
	tmutuazionecaratteristicaora.defineColumn("lu", typeof(string),false);
	tmutuazionecaratteristicaora.defineColumn("ora", typeof(int));
	Tables.Add(tmutuazionecaratteristicaora);
	tmutuazionecaratteristicaora.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idmutuazione", "idmutuazionecaratteristica", "idmutuazionecaratteristicaora");

	//////////////////// MUTUAZIONECARATTERISTICA /////////////////////////////////
	var tmutuazionecaratteristica= new MetaTable("mutuazionecaratteristica");
	tmutuazionecaratteristica.defineColumn("aa", typeof(string),false);
	tmutuazionecaratteristica.defineColumn("cf", typeof(decimal));
	tmutuazionecaratteristica.defineColumn("ct", typeof(DateTime),false);
	tmutuazionecaratteristica.defineColumn("cu", typeof(string),false);
	tmutuazionecaratteristica.defineColumn("idambitoareadisc", typeof(int));
	tmutuazionecaratteristica.defineColumn("idattivform", typeof(int),false);
	tmutuazionecaratteristica.defineColumn("idcanale", typeof(int),false);
	tmutuazionecaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	tmutuazionecaratteristica.defineColumn("iddidprog", typeof(int),false);
	tmutuazionecaratteristica.defineColumn("iddidproganno", typeof(int),false);
	tmutuazionecaratteristica.defineColumn("iddidprogcurr", typeof(int),false);
	tmutuazionecaratteristica.defineColumn("iddidprogori", typeof(int),false);
	tmutuazionecaratteristica.defineColumn("iddidprogporzanno", typeof(int),false);
	tmutuazionecaratteristica.defineColumn("idmutuazione", typeof(int),false);
	tmutuazionecaratteristica.defineColumn("idmutuazionecaratteristica", typeof(int),false);
	tmutuazionecaratteristica.defineColumn("idsasd", typeof(int));
	tmutuazionecaratteristica.defineColumn("idsasdgruppo", typeof(int));
	tmutuazionecaratteristica.defineColumn("idtipoattform", typeof(int));
	tmutuazionecaratteristica.defineColumn("json", typeof(string));
	tmutuazionecaratteristica.defineColumn("lt", typeof(DateTime),false);
	tmutuazionecaratteristica.defineColumn("lu", typeof(string),false);
	tmutuazionecaratteristica.defineColumn("profess", typeof(string),false);
	tmutuazionecaratteristica.defineColumn("title", typeof(string));
	Tables.Add(tmutuazionecaratteristica);
	tmutuazionecaratteristica.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idmutuazione", "idmutuazionecaratteristica");

	//////////////////// CANALE_ALIAS2 /////////////////////////////////
	var tcanale_alias2= new MetaTable("canale_alias2");
	tcanale_alias2.defineColumn("aa", typeof(string),false);
	tcanale_alias2.defineColumn("idattivform", typeof(int),false);
	tcanale_alias2.defineColumn("idcanale", typeof(int),false);
	tcanale_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tcanale_alias2.defineColumn("iddidprog", typeof(int),false);
	tcanale_alias2.defineColumn("iddidproganno", typeof(int),false);
	tcanale_alias2.defineColumn("iddidprogcurr", typeof(int),false);
	tcanale_alias2.defineColumn("iddidprogori", typeof(int),false);
	tcanale_alias2.defineColumn("iddidprogporzanno", typeof(int),false);
	tcanale_alias2.defineColumn("title", typeof(string));
	tcanale_alias2.ExtendedProperties["TableForReading"]="canale";
	Tables.Add(tcanale_alias2);
	tcanale_alias2.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// MUTUAZIONE /////////////////////////////////
	var tmutuazione= new MetaTable("mutuazione");
	tmutuazione.defineColumn("aa", typeof(string),false);
	tmutuazione.defineColumn("ct", typeof(DateTime),false);
	tmutuazione.defineColumn("cu", typeof(string),false);
	tmutuazione.defineColumn("idattivform", typeof(int),false);
	tmutuazione.defineColumn("idcanale", typeof(int),false);
	tmutuazione.defineColumn("idcanale_from", typeof(int),false);
	tmutuazione.defineColumn("idcorsostudio", typeof(int),false);
	tmutuazione.defineColumn("iddidprog", typeof(int),false);
	tmutuazione.defineColumn("iddidproganno", typeof(int),false);
	tmutuazione.defineColumn("iddidprogcurr", typeof(int),false);
	tmutuazione.defineColumn("iddidprogori", typeof(int),false);
	tmutuazione.defineColumn("iddidprogporzanno", typeof(int),false);
	tmutuazione.defineColumn("idmutuazione", typeof(int),false);
	tmutuazione.defineColumn("idsede", typeof(int),false);
	tmutuazione.defineColumn("json", typeof(string));
	tmutuazione.defineColumn("lt", typeof(DateTime),false);
	tmutuazione.defineColumn("lu", typeof(string),false);
	tmutuazione.defineColumn("riferimento", typeof(string),false);
	tmutuazione.defineColumn("title", typeof(string));
	tmutuazione.defineColumn("!idcanale_from_canale_title", typeof(string));
	Tables.Add(tmutuazione);
	tmutuazione.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idmutuazione");

	//////////////////// DIDPROGPORZANNO_ALIAS1 /////////////////////////////////
	var tdidprogporzanno_alias1= new MetaTable("didprogporzanno_alias1");
	tdidprogporzanno_alias1.defineColumn("aa", typeof(string),false);
	tdidprogporzanno_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzanno_alias1.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzanno_alias1.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzanno_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzanno_alias1.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzanno_alias1.defineColumn("iddidprogporzanno", typeof(int),false);
	tdidprogporzanno_alias1.defineColumn("title", typeof(string));
	tdidprogporzanno_alias1.ExtendedProperties["TableForReading"]="didprogporzanno";
	Tables.Add(tdidprogporzanno_alias1);
	tdidprogporzanno_alias1.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// DIDPROGORI_ALIAS1 /////////////////////////////////
	var tdidprogori_alias1= new MetaTable("didprogori_alias1");
	tdidprogori_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori_alias1.defineColumn("iddidprog", typeof(int),false);
	tdidprogori_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori_alias1.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori_alias1.defineColumn("title", typeof(string));
	tdidprogori_alias1.ExtendedProperties["TableForReading"]="didprogori";
	Tables.Add(tdidprogori_alias1);
	tdidprogori_alias1.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGCURR_ALIAS1 /////////////////////////////////
	var tdidprogcurr_alias1= new MetaTable("didprogcurr_alias1");
	tdidprogcurr_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("title", typeof(string));
	tdidprogcurr_alias1.ExtendedProperties["TableForReading"]="didprogcurr";
	Tables.Add(tdidprogcurr_alias1);
	tdidprogcurr_alias1.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// DIDPROGANNO_ALIAS1 /////////////////////////////////
	var tdidproganno_alias1= new MetaTable("didproganno_alias1");
	tdidproganno_alias1.defineColumn("aa", typeof(string),false);
	tdidproganno_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdidproganno_alias1.defineColumn("iddidprog", typeof(int),false);
	tdidproganno_alias1.defineColumn("iddidproganno", typeof(int),false);
	tdidproganno_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tdidproganno_alias1.defineColumn("iddidprogori", typeof(int),false);
	tdidproganno_alias1.defineColumn("title", typeof(string));
	tdidproganno_alias1.ExtendedProperties["TableForReading"]="didproganno";
	Tables.Add(tdidproganno_alias1);
	tdidproganno_alias1.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori");

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

	//////////////////// CANALE /////////////////////////////////
	var tcanale= new MetaTable("canale");
	tcanale.defineColumn("aa", typeof(string),false);
	tcanale.defineColumn("ct", typeof(DateTime),false);
	tcanale.defineColumn("cu", typeof(string),false);
	tcanale.defineColumn("CUIN", typeof(string));
	tcanale.defineColumn("idattivform", typeof(int),false);
	tcanale.defineColumn("idcanale", typeof(int),false);
	tcanale.defineColumn("idcorsostudio", typeof(int),false);
	tcanale.defineColumn("iddidprog", typeof(int),false);
	tcanale.defineColumn("iddidproganno", typeof(int),false);
	tcanale.defineColumn("iddidprogcurr", typeof(int),false);
	tcanale.defineColumn("iddidprogori", typeof(int),false);
	tcanale.defineColumn("iddidprogporzanno", typeof(int),false);
	tcanale.defineColumn("idsede", typeof(int),false);
	tcanale.defineColumn("lt", typeof(DateTime),false);
	tcanale.defineColumn("lu", typeof(string),false);
	tcanale.defineColumn("numerostud", typeof(int));
	tcanale.defineColumn("sortcode", typeof(int));
	tcanale.defineColumn("title", typeof(string));
	tcanale.defineColumn("!idattivform_attivform_title", typeof(string));
	tcanale.defineColumn("!iddidproganno_didproganno_title", typeof(string));
	tcanale.defineColumn("!iddidprogcurr_didprogcurr_title", typeof(string));
	tcanale.defineColumn("!iddidprogori_didprogori_title", typeof(string));
	tcanale.defineColumn("!iddidprogporzanno_didprogporzanno_title", typeof(string));
	tcanale.defineColumn("!mutuazione", typeof(string));
	tcanale.defineColumn("!affidamento", typeof(string));
	tcanale.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tcanale);
	tcanale.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// ATTIVFORMCARATTERISTICAORA /////////////////////////////////
	var tattivformcaratteristicaora= new MetaTable("attivformcaratteristicaora");
	tattivformcaratteristicaora.defineColumn("aa", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("ct", typeof(DateTime),false);
	tattivformcaratteristicaora.defineColumn("cu", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("idattivform", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idattivformcaratteristica", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idattivformcaratteristicaora", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idcorsostudio", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprog", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidproganno", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogori", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idorakind", typeof(int));
	tattivformcaratteristicaora.defineColumn("lt", typeof(DateTime),false);
	tattivformcaratteristicaora.defineColumn("lu", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("ora", typeof(int));
	Tables.Add(tattivformcaratteristicaora);
	tattivformcaratteristicaora.defineKey("aa", "idattivform", "idattivformcaratteristica", "idattivformcaratteristicaora", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// TIPOATTFORM /////////////////////////////////
	var ttipoattform= new MetaTable("tipoattform");
	ttipoattform.defineColumn("idtipoattform", typeof(int),false);
	ttipoattform.defineColumn("title", typeof(string),false);
	Tables.Add(ttipoattform);
	ttipoattform.defineKey("idtipoattform");

	//////////////////// SASDGRUPPO /////////////////////////////////
	var tsasdgruppo= new MetaTable("sasdgruppo");
	tsasdgruppo.defineColumn("idsasdgruppo", typeof(int),false);
	tsasdgruppo.defineColumn("idtipoattform", typeof(int),false);
	tsasdgruppo.defineColumn("title", typeof(string));
	Tables.Add(tsasdgruppo);
	tsasdgruppo.defineKey("idsasdgruppo", "idtipoattform");

	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("codice", typeof(string),false);
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	//////////////////// AMBITOAREADISC /////////////////////////////////
	var tambitoareadisc= new MetaTable("ambitoareadisc");
	tambitoareadisc.defineColumn("idambitoareadisc", typeof(int),false);
	tambitoareadisc.defineColumn("title", typeof(string),false);
	Tables.Add(tambitoareadisc);
	tambitoareadisc.defineKey("idambitoareadisc");

	//////////////////// ATTIVFORMCARATTERISTICA /////////////////////////////////
	var tattivformcaratteristica= new MetaTable("attivformcaratteristica");
	tattivformcaratteristica.defineColumn("aa", typeof(string),false);
	tattivformcaratteristica.defineColumn("cf", typeof(decimal));
	tattivformcaratteristica.defineColumn("ct", typeof(DateTime),false);
	tattivformcaratteristica.defineColumn("cu", typeof(string),false);
	tattivformcaratteristica.defineColumn("idambitoareadisc", typeof(int));
	tattivformcaratteristica.defineColumn("idattivform", typeof(int),false);
	tattivformcaratteristica.defineColumn("idattivformcaratteristica", typeof(int),false);
	tattivformcaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprog", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidproganno", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogori", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformcaratteristica.defineColumn("idsasd", typeof(int));
	tattivformcaratteristica.defineColumn("idsasdgruppo", typeof(int));
	tattivformcaratteristica.defineColumn("idtipoattform", typeof(int));
	tattivformcaratteristica.defineColumn("json", typeof(string));
	tattivformcaratteristica.defineColumn("lt", typeof(DateTime),false);
	tattivformcaratteristica.defineColumn("lu", typeof(string),false);
	tattivformcaratteristica.defineColumn("profess", typeof(string),false);
	tattivformcaratteristica.defineColumn("title", typeof(string));
	tattivformcaratteristica.defineColumn("!idambitoareadisc_ambitoareadisc_title", typeof(string));
	tattivformcaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	tattivformcaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	tattivformcaratteristica.defineColumn("!idsasdgruppo_sasdgruppo_title", typeof(string));
	tattivformcaratteristica.defineColumn("!idtipoattform_tipoattform_title", typeof(string));
	tattivformcaratteristica.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tattivformcaratteristica);
	tattivformcaratteristica.defineKey("aa", "idattivform", "idattivformcaratteristica", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

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
	tappelloattivform.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tappelloattivform);
	tappelloattivform.defineKey("aa", "idappello", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// ATTIVFORMVALUTAZIONEKIND /////////////////////////////////
	var tattivformvalutazionekind= new MetaTable("attivformvalutazionekind");
	tattivformvalutazionekind.defineColumn("aa", typeof(string),false);
	tattivformvalutazionekind.defineColumn("ct", typeof(DateTime),false);
	tattivformvalutazionekind.defineColumn("cu", typeof(string),false);
	tattivformvalutazionekind.defineColumn("idattivform", typeof(int),false);
	tattivformvalutazionekind.defineColumn("idcorsostudio", typeof(int),false);
	tattivformvalutazionekind.defineColumn("iddidprog", typeof(int),false);
	tattivformvalutazionekind.defineColumn("iddidproganno", typeof(int),false);
	tattivformvalutazionekind.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformvalutazionekind.defineColumn("iddidprogori", typeof(int),false);
	tattivformvalutazionekind.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformvalutazionekind.defineColumn("idvalutazionekind", typeof(int),false);
	tattivformvalutazionekind.defineColumn("lt", typeof(DateTime),false);
	tattivformvalutazionekind.defineColumn("lu", typeof(string),false);
	tattivformvalutazionekind.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tattivformvalutazionekind);
	tattivformvalutazionekind.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idvalutazionekind");

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

	//////////////////// DIDPROGPORZANNO /////////////////////////////////
	var tdidprogporzanno= new MetaTable("didprogporzanno");
	tdidprogporzanno.defineColumn("aa", typeof(string),false);
	tdidprogporzanno.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogporzanno", typeof(int),false);
	tdidprogporzanno.defineColumn("title", typeof(string));
	Tables.Add(tdidprogporzanno);
	tdidprogporzanno.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// DIDPROGORI /////////////////////////////////
	var tdidprogori= new MetaTable("didprogori");
	tdidprogori.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori.defineColumn("iddidprog", typeof(int),false);
	tdidprogori.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori.defineColumn("title", typeof(string));
	Tables.Add(tdidprogori);
	tdidprogori.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGGRUPP /////////////////////////////////
	var tdidproggrupp= new MetaTable("didproggrupp");
	tdidproggrupp.defineColumn("idcorsostudio", typeof(int),false);
	tdidproggrupp.defineColumn("iddidprog", typeof(int),false);
	tdidproggrupp.defineColumn("iddidproggrupp", typeof(int),false);
	tdidproggrupp.defineColumn("title", typeof(string));
	Tables.Add(tdidproggrupp);
	tdidproggrupp.defineKey("idcorsostudio", "iddidprog", "iddidproggrupp");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// DIDPROGANNO /////////////////////////////////
	var tdidproganno= new MetaTable("didproganno");
	tdidproganno.defineColumn("aa", typeof(string),false);
	tdidproganno.defineColumn("anno", typeof(int));
	tdidproganno.defineColumn("cf", typeof(decimal));
	tdidproganno.defineColumn("ct", typeof(DateTime),false);
	tdidproganno.defineColumn("cu", typeof(string),false);
	tdidproganno.defineColumn("idcorsostudio", typeof(int),false);
	tdidproganno.defineColumn("iddidprog", typeof(int),false);
	tdidproganno.defineColumn("iddidproganno", typeof(int),false);
	tdidproganno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidproganno.defineColumn("iddidprogori", typeof(int),false);
	tdidproganno.defineColumn("lt", typeof(DateTime),false);
	tdidproganno.defineColumn("lu", typeof(string),false);
	tdidproganno.defineColumn("title", typeof(string));
	Tables.Add(tdidproganno);
	tdidproganno.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori");

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
	tattivform.defineColumn("!iddidproganno_didproganno_title", typeof(string));
	tattivform.defineColumn("!iddidprogcurr_didprogcurr_title", typeof(string));
	tattivform.defineColumn("!iddidproggrupp_didproggrupp_title", typeof(string));
	tattivform.defineColumn("!iddidprogori_didprogori_title", typeof(string));
	tattivform.defineColumn("!iddidprogporzanno_didprogporzanno_title", typeof(string));
	tattivform.defineColumn("!idinsegn_insegn_denominazione", typeof(string));
	tattivform.defineColumn("!idinsegn_insegn_codice", typeof(string));
	tattivform.defineColumn("!idinsegninteg_insegninteg_denominazione", typeof(string));
	tattivform.defineColumn("!idinsegninteg_insegninteg_codice", typeof(string));
	tattivform.defineColumn("!attivformcaratteristica", typeof(string));
	Tables.Add(tattivform);
	tattivform.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// SEDEDEFAULTVIEW /////////////////////////////////
	var tsededefaultview= new MetaTable("sededefaultview");
	tsededefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsededefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tsededefaultview);
	tsededefaultview.defineKey("idsede");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	Tables.Add(tcorsostudiodefaultview);
	tcorsostudiodefaultview.defineKey("idcorsostudio");

	//////////////////// DIDEROG /////////////////////////////////
	var tdiderog= new MetaTable("diderog");
	tdiderog.defineColumn("aa", typeof(string),false);
	tdiderog.defineColumn("idcorsostudio", typeof(int),false);
	tdiderog.defineColumn("idsede", typeof(int),false);
	tdiderog.defineColumn("inesaurimento", typeof(string));
	Tables.Add(tdiderog);
	tdiderog.defineKey("aa", "idcorsostudio", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{getcostididattica.Columns["aa"], getcostididattica.Columns["idcorsostudio"], getcostididattica.Columns["idsede"]};
	var cChild = new []{diderog.Columns["aa"], diderog.Columns["idcorsostudio"], diderog.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_diderog_getcostididattica_aa-idcorsostudio-idsede",cPar,cChild,false));

	cPar = new []{diderog.Columns["aa"], diderog.Columns["idcorsostudio"], diderog.Columns["idsede"]};
	cChild = new []{canale.Columns["aa"], canale.Columns["idcorsostudio"], canale.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_canale_diderog_aa-idcorsostudio-idsede",cPar,cChild,false));

	cPar = new []{canale.Columns["aa"], canale.Columns["idattivform"], canale.Columns["idcanale"], canale.Columns["idcorsostudio"], canale.Columns["iddidprog"], canale.Columns["iddidproganno"], canale.Columns["iddidprogcurr"], canale.Columns["iddidprogori"], canale.Columns["iddidprogporzanno"]};
	cChild = new []{affidamento.Columns["aa"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamento_canale_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{affidamento.Columns["aa"], affidamento.Columns["idaffidamento"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"]};
	cChild = new []{affidamentoattach.Columns["aa"], affidamentoattach.Columns["idaffidamento"], affidamentoattach.Columns["idattivform"], affidamentoattach.Columns["idcanale"], affidamentoattach.Columns["idcorsostudio"], affidamentoattach.Columns["iddidprog"], affidamentoattach.Columns["iddidproganno"], affidamentoattach.Columns["iddidprogcurr"], affidamentoattach.Columns["iddidprogori"], affidamentoattach.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamentoattach_affidamento_aa-idaffidamento-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{affidamento.Columns["aa"], affidamento.Columns["idaffidamento"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"]};
	cChild = new []{lezione.Columns["aa"], lezione.Columns["idaffidamento"], lezione.Columns["idattivform"], lezione.Columns["idcanale"], lezione.Columns["idcorsostudio"], lezione.Columns["iddidprog"], lezione.Columns["iddidproganno"], lezione.Columns["iddidprogcurr"], lezione.Columns["iddidprogori"], lezione.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_lezione_affidamento_aa-idaffidamento-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{affidamento.Columns["aa"], affidamento.Columns["idaffidamento"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"]};
	cChild = new []{affidamentocaratteristica.Columns["aa"], affidamentocaratteristica.Columns["idaffidamento"], affidamentocaratteristica.Columns["idattivform"], affidamentocaratteristica.Columns["idcanale"], affidamentocaratteristica.Columns["idcorsostudio"], affidamentocaratteristica.Columns["iddidprog"], affidamentocaratteristica.Columns["iddidproganno"], affidamentocaratteristica.Columns["iddidprogcurr"], affidamentocaratteristica.Columns["iddidprogori"], affidamentocaratteristica.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_affidamento_aa-idaffidamento-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{affidamentocaratteristica.Columns["aa"], affidamentocaratteristica.Columns["idaffidamento"], affidamentocaratteristica.Columns["idaffidamentocaratteristica"], affidamentocaratteristica.Columns["idattivform"], affidamentocaratteristica.Columns["idcanale"], affidamentocaratteristica.Columns["idcorsostudio"], affidamentocaratteristica.Columns["iddidprog"], affidamentocaratteristica.Columns["iddidproganno"], affidamentocaratteristica.Columns["iddidprogcurr"], affidamentocaratteristica.Columns["iddidprogori"], affidamentocaratteristica.Columns["iddidprogporzanno"]};
	cChild = new []{affidamentocaratteristicaora.Columns["aa"], affidamentocaratteristicaora.Columns["idaffidamento"], affidamentocaratteristicaora.Columns["idaffidamentocaratteristica"], affidamentocaratteristicaora.Columns["idattivform"], affidamentocaratteristicaora.Columns["idcanale"], affidamentocaratteristicaora.Columns["idcorsostudio"], affidamentocaratteristicaora.Columns["iddidprog"], affidamentocaratteristicaora.Columns["iddidproganno"], affidamentocaratteristicaora.Columns["iddidprogcurr"], affidamentocaratteristicaora.Columns["iddidprogori"], affidamentocaratteristicaora.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristicaora_affidamentocaratteristica_aa-idaffidamento-idaffidamentocaratteristica-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{affidamento.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_affidamento_registry_idreg_docenti",cPar,cChild,false));

	cPar = new []{erogazkind.Columns["iderogazkind"]};
	cChild = new []{affidamento.Columns["iderogazkind"]};
	Relations.Add(new DataRelation("FK_affidamento_erogazkind_iderogazkind",cPar,cChild,false));

	cPar = new []{affidamentokind.Columns["idaffidamentokind"]};
	cChild = new []{affidamento.Columns["idaffidamentokind"]};
	Relations.Add(new DataRelation("FK_affidamento_affidamentokind_idaffidamentokind",cPar,cChild,false));

	cPar = new []{canale.Columns["aa"], canale.Columns["idattivform"], canale.Columns["idcanale"], canale.Columns["idcorsostudio"], canale.Columns["iddidprog"], canale.Columns["iddidproganno"], canale.Columns["iddidprogcurr"], canale.Columns["iddidprogori"], canale.Columns["iddidprogporzanno"]};
	cChild = new []{mutuazione.Columns["aa"], mutuazione.Columns["idattivform"], mutuazione.Columns["idcanale"], mutuazione.Columns["idcorsostudio"], mutuazione.Columns["iddidprog"], mutuazione.Columns["iddidproganno"], mutuazione.Columns["iddidprogcurr"], mutuazione.Columns["iddidprogori"], mutuazione.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_mutuazione_canale_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{mutuazione.Columns["aa"], mutuazione.Columns["idattivform"], mutuazione.Columns["idcanale"], mutuazione.Columns["idcorsostudio"], mutuazione.Columns["iddidprog"], mutuazione.Columns["iddidproganno"], mutuazione.Columns["iddidprogcurr"], mutuazione.Columns["iddidprogori"], mutuazione.Columns["iddidprogporzanno"], mutuazione.Columns["idmutuazione"]};
	cChild = new []{mutuazionecaratteristica.Columns["aa"], mutuazionecaratteristica.Columns["idattivform"], mutuazionecaratteristica.Columns["idcanale"], mutuazionecaratteristica.Columns["idcorsostudio"], mutuazionecaratteristica.Columns["iddidprog"], mutuazionecaratteristica.Columns["iddidproganno"], mutuazionecaratteristica.Columns["iddidprogcurr"], mutuazionecaratteristica.Columns["iddidprogori"], mutuazionecaratteristica.Columns["iddidprogporzanno"], mutuazionecaratteristica.Columns["idmutuazione"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_mutuazione_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idmutuazione",cPar,cChild,false));

	cPar = new []{mutuazionecaratteristica.Columns["aa"], mutuazionecaratteristica.Columns["idattivform"], mutuazionecaratteristica.Columns["idcanale"], mutuazionecaratteristica.Columns["idcorsostudio"], mutuazionecaratteristica.Columns["iddidprog"], mutuazionecaratteristica.Columns["iddidproganno"], mutuazionecaratteristica.Columns["iddidprogcurr"], mutuazionecaratteristica.Columns["iddidprogori"], mutuazionecaratteristica.Columns["iddidprogporzanno"], mutuazionecaratteristica.Columns["idmutuazione"], mutuazionecaratteristica.Columns["idmutuazionecaratteristica"]};
	cChild = new []{mutuazionecaratteristicaora.Columns["aa"], mutuazionecaratteristicaora.Columns["idattivform"], mutuazionecaratteristicaora.Columns["idcanale"], mutuazionecaratteristicaora.Columns["idcorsostudio"], mutuazionecaratteristicaora.Columns["iddidprog"], mutuazionecaratteristicaora.Columns["iddidproganno"], mutuazionecaratteristicaora.Columns["iddidprogcurr"], mutuazionecaratteristicaora.Columns["iddidprogori"], mutuazionecaratteristicaora.Columns["iddidprogporzanno"], mutuazionecaratteristicaora.Columns["idmutuazione"], mutuazionecaratteristicaora.Columns["idmutuazionecaratteristica"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristicaora_mutuazionecaratteristica_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idmutuazione-idmutuazionecaratteristica",cPar,cChild,false));

	cPar = new []{canale_alias2.Columns["idcanale"]};
	cChild = new []{mutuazione.Columns["idcanale_from"]};
	Relations.Add(new DataRelation("FK_mutuazione_canale_alias2_idcanale_from",cPar,cChild,false));

	cPar = new []{didprogporzanno_alias1.Columns["iddidprogporzanno"]};
	cChild = new []{canale.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_canale_didprogporzanno_alias1_iddidprogporzanno",cPar,cChild,false));

	cPar = new []{didprogori_alias1.Columns["iddidprogori"]};
	cChild = new []{canale.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_canale_didprogori_alias1_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr_alias1.Columns["iddidprogcurr"]};
	cChild = new []{canale.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_canale_didprogcurr_alias1_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didproganno_alias1.Columns["iddidproganno"]};
	cChild = new []{canale.Columns["iddidproganno"]};
	Relations.Add(new DataRelation("FK_canale_didproganno_alias1_iddidproganno",cPar,cChild,false));

	cPar = new []{attivform_alias2.Columns["idattivform"]};
	cChild = new []{canale.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_canale_attivform_alias2_idattivform",cPar,cChild,false));

	cPar = new []{diderog.Columns["aa"], diderog.Columns["idcorsostudio"], diderog.Columns["idsede"]};
	cChild = new []{attivform.Columns["aa"], attivform.Columns["idcorsostudio"], attivform.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_attivform_diderog_aa-idcorsostudio-idsede",cPar,cChild,false));

	cPar = new []{attivform.Columns["aa"], attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogporzanno"]};
	cChild = new []{attivformcaratteristica.Columns["aa"], attivformcaratteristica.Columns["idattivform"], attivformcaratteristica.Columns["idcorsostudio"], attivformcaratteristica.Columns["iddidprog"], attivformcaratteristica.Columns["iddidproganno"], attivformcaratteristica.Columns["iddidprogcurr"], attivformcaratteristica.Columns["iddidprogori"], attivformcaratteristica.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_attivform_aa-idattivform-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{attivformcaratteristica.Columns["aa"], attivformcaratteristica.Columns["idattivform"], attivformcaratteristica.Columns["idattivformcaratteristica"], attivformcaratteristica.Columns["idcorsostudio"], attivformcaratteristica.Columns["iddidprog"], attivformcaratteristica.Columns["iddidproganno"], attivformcaratteristica.Columns["iddidprogcurr"], attivformcaratteristica.Columns["iddidprogori"], attivformcaratteristica.Columns["iddidprogporzanno"]};
	cChild = new []{attivformcaratteristicaora.Columns["aa"], attivformcaratteristicaora.Columns["idattivform"], attivformcaratteristicaora.Columns["idattivformcaratteristica"], attivformcaratteristicaora.Columns["idcorsostudio"], attivformcaratteristicaora.Columns["iddidprog"], attivformcaratteristicaora.Columns["iddidproganno"], attivformcaratteristicaora.Columns["iddidprogcurr"], attivformcaratteristicaora.Columns["iddidprogori"], attivformcaratteristicaora.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristicaora_attivformcaratteristica_aa-idattivform-idattivformcaratteristica-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{attivformcaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	cPar = new []{sasdgruppo.Columns["idsasdgruppo"]};
	cChild = new []{attivformcaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_sasdgruppo_idsasdgruppo",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{attivformcaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_sasd_idsasd",cPar,cChild,false));

	cPar = new []{ambitoareadisc.Columns["idambitoareadisc"]};
	cChild = new []{attivformcaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_ambitoareadisc_idambitoareadisc",cPar,cChild,false));

	cPar = new []{attivform.Columns["aa"], attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogporzanno"]};
	cChild = new []{appelloattivform.Columns["aa"], appelloattivform.Columns["idattivform"], appelloattivform.Columns["idcorsostudio"], appelloattivform.Columns["iddidprog"], appelloattivform.Columns["iddidproganno"], appelloattivform.Columns["iddidprogcurr"], appelloattivform.Columns["iddidprogori"], appelloattivform.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_appelloattivform_attivform_aa-idattivform-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{attivform.Columns["aa"], attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogporzanno"]};
	cChild = new []{attivformvalutazionekind.Columns["aa"], attivformvalutazionekind.Columns["idattivform"], attivformvalutazionekind.Columns["idcorsostudio"], attivformvalutazionekind.Columns["iddidprog"], attivformvalutazionekind.Columns["iddidproganno"], attivformvalutazionekind.Columns["iddidprogcurr"], attivformvalutazionekind.Columns["iddidprogori"], attivformvalutazionekind.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformvalutazionekind_attivform_aa-idattivform-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{insegninteg.Columns["idinsegninteg"]};
	cChild = new []{attivform.Columns["idinsegninteg"]};
	Relations.Add(new DataRelation("FK_attivform_insegninteg_idinsegninteg",cPar,cChild,false));

	cPar = new []{insegn.Columns["idinsegn"]};
	cChild = new []{attivform.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_attivform_insegn_idinsegn",cPar,cChild,false));

	cPar = new []{didprogporzanno.Columns["iddidprogporzanno"]};
	cChild = new []{attivform.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivform_didprogporzanno_iddidprogporzanno",cPar,cChild,false));

	cPar = new []{didprogori.Columns["iddidprogori"]};
	cChild = new []{attivform.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_attivform_didprogori_iddidprogori",cPar,cChild,false));

	cPar = new []{didproggrupp.Columns["iddidproggrupp"]};
	cChild = new []{attivform.Columns["iddidproggrupp"]};
	Relations.Add(new DataRelation("FK_attivform_didproggrupp_iddidproggrupp",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{attivform.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_attivform_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didproganno.Columns["iddidproganno"]};
	cChild = new []{attivform.Columns["iddidproganno"]};
	Relations.Add(new DataRelation("FK_attivform_didproganno_iddidproganno",cPar,cChild,false));

	cPar = new []{sededefaultview.Columns["idsede"]};
	cChild = new []{diderog.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_diderog_sededefaultview_idsede",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{diderog.Columns["aa"]};
	Relations.Add(new DataRelation("FK_diderog_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{diderog.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_diderog_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	#endregion

}
}
}
