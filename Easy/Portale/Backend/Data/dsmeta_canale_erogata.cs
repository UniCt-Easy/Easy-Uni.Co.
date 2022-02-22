
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
[System.Xml.Serialization.XmlRoot("dsmeta_canale_erogata"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_canale_erogata: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazionecaratteristicaora 		=> (MetaTable)Tables["mutuazionecaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazionecaratteristica 		=> (MetaTable)Tables["mutuazionecaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale_alias1 		=> (MetaTable)Tables["canale_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazione 		=> (MetaTable)Tables["mutuazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiperssd 		=> (MetaTable)Tables["getdocentiperssd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentoattach 		=> (MetaTable)Tables["affidamentoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable lezione 		=> (MetaTable)Tables["lezione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristicaora 		=> (MetaTable)Tables["affidamentocaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppo 		=> (MetaTable)Tables["sasdgruppo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadisc 		=> (MetaTable)Tables["ambitoareadisc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristica 		=> (MetaTable)Tables["affidamentocaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_docenti 		=> (MetaTable)Tables["registry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable erogazkind 		=> (MetaTable)Tables["erogazkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentokind 		=> (MetaTable)Tables["affidamentokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamento 		=> (MetaTable)Tables["affidamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale 		=> (MetaTable)Tables["canale"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_canale_erogata(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_canale_erogata (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_canale_erogata";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_canale_erogata.xsd";

	#region create DataTables
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

	//////////////////// CANALE_ALIAS1 /////////////////////////////////
	var tcanale_alias1= new MetaTable("canale_alias1");
	tcanale_alias1.defineColumn("aa", typeof(string),false);
	tcanale_alias1.defineColumn("idattivform", typeof(int),false);
	tcanale_alias1.defineColumn("idcanale", typeof(int),false);
	tcanale_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tcanale_alias1.defineColumn("iddidprog", typeof(int),false);
	tcanale_alias1.defineColumn("iddidproganno", typeof(int),false);
	tcanale_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tcanale_alias1.defineColumn("iddidprogori", typeof(int),false);
	tcanale_alias1.defineColumn("iddidprogporzanno", typeof(int),false);
	tcanale_alias1.defineColumn("title", typeof(string));
	tcanale_alias1.ExtendedProperties["TableForReading"]="canale";
	Tables.Add(tcanale_alias1);
	tcanale_alias1.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

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

	//////////////////// GETDOCENTIPERSSD /////////////////////////////////
	var tgetdocentiperssd= new MetaTable("getdocentiperssd");
	tgetdocentiperssd.defineColumn("aa", typeof(string),false);
	tgetdocentiperssd.defineColumn("cognome", typeof(string));
	tgetdocentiperssd.defineColumn("contratto", typeof(string),false);
	tgetdocentiperssd.defineColumn("costoorario", typeof(decimal));
	tgetdocentiperssd.defineColumn("idreg", typeof(int),false);
	tgetdocentiperssd.defineColumn("idsasd", typeof(int),false);
	tgetdocentiperssd.defineColumn("iniziocontratto", typeof(DateTime),false);
	tgetdocentiperssd.defineColumn("matricola", typeof(string));
	tgetdocentiperssd.defineColumn("nome", typeof(string));
	tgetdocentiperssd.defineColumn("oremaxdida", typeof(int));
	tgetdocentiperssd.defineColumn("oremindida", typeof(int));
	tgetdocentiperssd.defineColumn("oreperaaaffidamento", typeof(int));
	tgetdocentiperssd.defineColumn("oreperaacontratto", typeof(int));
	tgetdocentiperssd.defineColumn("parttime", typeof(decimal));
	tgetdocentiperssd.defineColumn("ssd", typeof(string),false);
	tgetdocentiperssd.defineColumn("struttura", typeof(string));
	tgetdocentiperssd.defineColumn("tempodefinito", typeof(string),false);
	tgetdocentiperssd.defineColumn("terminecontratto", typeof(DateTime),false);
	tgetdocentiperssd.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tgetdocentiperssd);
	tgetdocentiperssd.defineKey("aa", "idreg");

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

	//////////////////// TIPOATTFORM /////////////////////////////////
	var ttipoattform= new MetaTable("tipoattform");
	ttipoattform.defineColumn("description", typeof(string));
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
	taffidamentocaratteristica.defineColumn("!idambitoareadisc_ambitoareadisc_title", typeof(string));
	taffidamentocaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	taffidamentocaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	taffidamentocaratteristica.defineColumn("!idsasdgruppo_sasdgruppo_title", typeof(string));
	taffidamentocaratteristica.defineColumn("!idtipoattform_tipoattform_title", typeof(string));
	taffidamentocaratteristica.defineColumn("!idtipoattform_tipoattform_description", typeof(string));
	Tables.Add(taffidamentocaratteristica);
	taffidamentocaratteristica.defineKey("aa", "idaffidamento", "idaffidamentocaratteristica", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime),false);
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("ct", typeof(DateTime),false);
	tregistry.defineColumn("cu", typeof(string),false);
	tregistry.defineColumn("email_fe", typeof(string));
	tregistry.defineColumn("extension", typeof(string));
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("flag_pa", typeof(string));
	tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry.defineColumn("foreigncf", typeof(string));
	tregistry.defineColumn("forename", typeof(string),false);
	tregistry.defineColumn("gender", typeof(string),false);
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int),false);
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("ipa_perlapa", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("surname", typeof(string),false);
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// REGISTRY_DOCENTI /////////////////////////////////
	var tregistry_docenti= new MetaTable("registry_docenti");
	tregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tregistry_docenti.defineColumn("cu", typeof(string),false);
	tregistry_docenti.defineColumn("cv", typeof(string));
	tregistry_docenti.defineColumn("idclassconsorsuale", typeof(int));
	tregistry_docenti.defineColumn("idcontrattokind", typeof(int));
	tregistry_docenti.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistry_docenti.defineColumn("idreg", typeof(int),false);
	tregistry_docenti.defineColumn("idreg_istituti", typeof(int));
	tregistry_docenti.defineColumn("idsasd", typeof(int));
	tregistry_docenti.defineColumn("idstruttura", typeof(int));
	tregistry_docenti.defineColumn("indicebibliometrico", typeof(int));
	tregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tregistry_docenti.defineColumn("lu", typeof(string),false);
	tregistry_docenti.defineColumn("matricola", typeof(string));
	tregistry_docenti.defineColumn("ricevimento", typeof(string));
	tregistry_docenti.defineColumn("soggiorno", typeof(string));
	Tables.Add(tregistry_docenti);
	tregistry_docenti.defineKey("idreg");

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
	taffidamento.defineColumn("!idreg_docenti_registry_docenti_title", typeof(string));
	taffidamento.defineColumn("!affidamentocaratteristica", typeof(string));
	Tables.Add(taffidamento);
	taffidamento.defineKey("aa", "idaffidamento", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

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
	Tables.Add(tcanale);
	tcanale.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	#endregion


	#region DataRelation creation
	var cPar = new []{canale.Columns["aa"], canale.Columns["idattivform"], canale.Columns["idcanale"], canale.Columns["idcorsostudio"], canale.Columns["iddidprog"], canale.Columns["iddidproganno"], canale.Columns["iddidprogcurr"], canale.Columns["iddidprogori"], canale.Columns["iddidprogporzanno"]};
	var cChild = new []{mutuazione.Columns["aa"], mutuazione.Columns["idattivform"], mutuazione.Columns["idcanale"], mutuazione.Columns["idcorsostudio"], mutuazione.Columns["iddidprog"], mutuazione.Columns["iddidproganno"], mutuazione.Columns["iddidprogcurr"], mutuazione.Columns["iddidprogori"], mutuazione.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_mutuazione_canale_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{mutuazione.Columns["aa"], mutuazione.Columns["idattivform"], mutuazione.Columns["idcanale"], mutuazione.Columns["idcorsostudio"], mutuazione.Columns["iddidprog"], mutuazione.Columns["iddidproganno"], mutuazione.Columns["iddidprogcurr"], mutuazione.Columns["iddidprogori"], mutuazione.Columns["iddidprogporzanno"], mutuazione.Columns["idmutuazione"]};
	cChild = new []{mutuazionecaratteristica.Columns["aa"], mutuazionecaratteristica.Columns["idattivform"], mutuazionecaratteristica.Columns["idcanale"], mutuazionecaratteristica.Columns["idcorsostudio"], mutuazionecaratteristica.Columns["iddidprog"], mutuazionecaratteristica.Columns["iddidproganno"], mutuazionecaratteristica.Columns["iddidprogcurr"], mutuazionecaratteristica.Columns["iddidprogori"], mutuazionecaratteristica.Columns["iddidprogporzanno"], mutuazionecaratteristica.Columns["idmutuazione"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_mutuazione_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idmutuazione",cPar,cChild,false));

	cPar = new []{mutuazionecaratteristica.Columns["aa"], mutuazionecaratteristica.Columns["idattivform"], mutuazionecaratteristica.Columns["idcanale"], mutuazionecaratteristica.Columns["idcorsostudio"], mutuazionecaratteristica.Columns["iddidprog"], mutuazionecaratteristica.Columns["iddidproganno"], mutuazionecaratteristica.Columns["iddidprogcurr"], mutuazionecaratteristica.Columns["iddidprogori"], mutuazionecaratteristica.Columns["iddidprogporzanno"], mutuazionecaratteristica.Columns["idmutuazione"], mutuazionecaratteristica.Columns["idmutuazionecaratteristica"]};
	cChild = new []{mutuazionecaratteristicaora.Columns["aa"], mutuazionecaratteristicaora.Columns["idattivform"], mutuazionecaratteristicaora.Columns["idcanale"], mutuazionecaratteristicaora.Columns["idcorsostudio"], mutuazionecaratteristicaora.Columns["iddidprog"], mutuazionecaratteristicaora.Columns["iddidproganno"], mutuazionecaratteristicaora.Columns["iddidprogcurr"], mutuazionecaratteristicaora.Columns["iddidprogori"], mutuazionecaratteristicaora.Columns["iddidprogporzanno"], mutuazionecaratteristicaora.Columns["idmutuazione"], mutuazionecaratteristicaora.Columns["idmutuazionecaratteristica"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristicaora_mutuazionecaratteristica_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idmutuazione-idmutuazionecaratteristica",cPar,cChild,false));

	cPar = new []{canale_alias1.Columns["idcanale"]};
	cChild = new []{mutuazione.Columns["idcanale_from"]};
	Relations.Add(new DataRelation("FK_mutuazione_canale_alias1_idcanale_from",cPar,cChild,false));

	cPar = new []{canale.Columns["aa"], canale.Columns["idattivform"], canale.Columns["idcanale"], canale.Columns["idcorsostudio"], canale.Columns["iddidprog"], canale.Columns["iddidproganno"], canale.Columns["iddidprogcurr"], canale.Columns["iddidprogori"], canale.Columns["iddidprogporzanno"]};
	cChild = new []{affidamento.Columns["aa"], affidamento.Columns["idattivform"], affidamento.Columns["idcanale"], affidamento.Columns["idcorsostudio"], affidamento.Columns["iddidprog"], affidamento.Columns["iddidproganno"], affidamento.Columns["iddidprogcurr"], affidamento.Columns["iddidprogori"], affidamento.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamento_canale_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{affidamento.Columns["aa"], affidamento.Columns["idreg_docenti"]};
	cChild = new []{getdocentiperssd.Columns["aa"], getdocentiperssd.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_getdocentiperssd_affidamento_aa-idreg",cPar,cChild,false));

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

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{affidamentocaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	cPar = new []{sasdgruppo.Columns["idsasdgruppo"]};
	cChild = new []{affidamentocaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_sasdgruppo_idsasdgruppo",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{affidamentocaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_sasd_idsasd",cPar,cChild,false));

	cPar = new []{ambitoareadisc.Columns["idambitoareadisc"]};
	cChild = new []{affidamentocaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_ambitoareadisc_idambitoareadisc",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{affidamento.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_affidamento_registry_idreg_docenti",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_docenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_docenti_registry_idreg",cPar,cChild,false));

	cPar = new []{erogazkind.Columns["iderogazkind"]};
	cChild = new []{affidamento.Columns["iderogazkind"]};
	Relations.Add(new DataRelation("FK_affidamento_erogazkind_iderogazkind",cPar,cChild,false));

	cPar = new []{affidamentokind.Columns["idaffidamentokind"]};
	cChild = new []{affidamento.Columns["idaffidamentokind"]};
	Relations.Add(new DataRelation("FK_affidamento_affidamentokind_idaffidamentokind",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{canale.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_canale_sede_idsede",cPar,cChild,false));

	#endregion

}
}
}
