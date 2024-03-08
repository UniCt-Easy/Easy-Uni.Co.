
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
[System.Xml.Serialization.XmlRoot("dsmeta_ricostruzione_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_ricostruzione_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ricostruzioneattach 		=> (MetaTable)Tables["ricostruzioneattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable servizioaltro 		=> (MetaTable)Tables["servizioaltro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable servizioricongiunzioni 		=> (MetaTable)Tables["servizioricongiunzioni"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziomilitare 		=> (MetaTable)Tables["serviziomilitare"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziocontributi 		=> (MetaTable)Tables["serviziocontributi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position_alias2 		=> (MetaTable)Tables["position_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziopreruoloinps 		=> (MetaTable)Tables["serviziopreruoloinps"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position_alias1 		=> (MetaTable)Tables["position_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziopreruolotesoro 		=> (MetaTable)Tables["serviziopreruolotesoro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatus 		=> (MetaTable)Tables["registrylegalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ricostruzioneanniaccademici 		=> (MetaTable)Tables["ricostruzioneanniaccademici"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziriepilogoview 		=> (MetaTable)Tables["serviziriepilogoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ricostruzionenonvaliditaview 		=> (MetaTable)Tables["ricostruzionenonvaliditaview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nonvalutabilitakind 		=> (MetaTable)Tables["nonvalutabilitakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ricostruzioneperiodonv 		=> (MetaTable)Tables["ricostruzioneperiodonv"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ricostruzionekinddefaultview 		=> (MetaTable)Tables["ricostruzionekinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ricostruzione 		=> (MetaTable)Tables["ricostruzione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ricostruzione_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ricostruzione_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ricostruzione_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ricostruzione_default.xsd";

	#region create DataTables
	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// RICOSTRUZIONEATTACH /////////////////////////////////
	var tricostruzioneattach= new MetaTable("ricostruzioneattach");
	tricostruzioneattach.defineColumn("ct", typeof(DateTime),false);
	tricostruzioneattach.defineColumn("cu", typeof(string),false);
	tricostruzioneattach.defineColumn("idattach", typeof(int),false);
	tricostruzioneattach.defineColumn("idricostruzione", typeof(int),false);
	tricostruzioneattach.defineColumn("lt", typeof(DateTime),false);
	tricostruzioneattach.defineColumn("lu", typeof(string),false);
	tricostruzioneattach.defineColumn("title", typeof(string));
	tricostruzioneattach.defineColumn("!idattach_attach_filename", typeof(string));
	tricostruzioneattach.defineColumn("!idattach_attach_size", typeof(int));
	tricostruzioneattach.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tricostruzioneattach);
	tricostruzioneattach.defineKey("idattach", "idricostruzione");

	//////////////////// SERVIZIOALTRO /////////////////////////////////
	var tservizioaltro= new MetaTable("servizioaltro");
	tservizioaltro.defineColumn("anni", typeof(int));
	tservizioaltro.defineColumn("ct", typeof(DateTime),false);
	tservizioaltro.defineColumn("cu", typeof(string),false);
	tservizioaltro.defineColumn("giorni", typeof(int));
	tservizioaltro.defineColumn("idreg", typeof(int),false);
	tservizioaltro.defineColumn("idservizioaltro", typeof(int),false);
	tservizioaltro.defineColumn("istituzione", typeof(string));
	tservizioaltro.defineColumn("lt", typeof(DateTime),false);
	tservizioaltro.defineColumn("lu", typeof(string),false);
	tservizioaltro.defineColumn("mesi", typeof(int));
	tservizioaltro.defineColumn("start", typeof(DateTime));
	tservizioaltro.defineColumn("stop", typeof(DateTime));
	tservizioaltro.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tservizioaltro);
	tservizioaltro.defineKey("idreg", "idservizioaltro");

	//////////////////// SERVIZIORICONGIUNZIONI /////////////////////////////////
	var tservizioricongiunzioni= new MetaTable("servizioricongiunzioni");
	tservizioricongiunzioni.defineColumn("anni", typeof(int));
	tservizioricongiunzioni.defineColumn("cronologico", typeof(string));
	tservizioricongiunzioni.defineColumn("ct", typeof(DateTime),false);
	tservizioricongiunzioni.defineColumn("cu", typeof(string),false);
	tservizioricongiunzioni.defineColumn("datadecreto", typeof(DateTime));
	tservizioricongiunzioni.defineColumn("dataregdecreto", typeof(DateTime));
	tservizioricongiunzioni.defineColumn("euro", typeof(decimal));
	tservizioricongiunzioni.defineColumn("foglio", typeof(string));
	tservizioricongiunzioni.defineColumn("giorni", typeof(int));
	tservizioricongiunzioni.defineColumn("idreg", typeof(int),false);
	tservizioricongiunzioni.defineColumn("idservizioricongiunzioni", typeof(int),false);
	tservizioricongiunzioni.defineColumn("lire", typeof(int));
	tservizioricongiunzioni.defineColumn("lt", typeof(DateTime),false);
	tservizioricongiunzioni.defineColumn("lu", typeof(string),false);
	tservizioricongiunzioni.defineColumn("mesi", typeof(int));
	tservizioricongiunzioni.defineColumn("ndecreto", typeof(string));
	tservizioricongiunzioni.defineColumn("registro", typeof(string));
	tservizioricongiunzioni.defineColumn("start", typeof(DateTime));
	tservizioricongiunzioni.defineColumn("stop", typeof(DateTime));
	tservizioricongiunzioni.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tservizioricongiunzioni);
	tservizioricongiunzioni.defineKey("idreg", "idservizioricongiunzioni");

	//////////////////// SERVIZIOMILITARE /////////////////////////////////
	var tserviziomilitare= new MetaTable("serviziomilitare");
	tserviziomilitare.defineColumn("anni", typeof(int));
	tserviziomilitare.defineColumn("ct", typeof(DateTime),false);
	tserviziomilitare.defineColumn("cu", typeof(string),false);
	tserviziomilitare.defineColumn("giorni", typeof(int));
	tserviziomilitare.defineColumn("idreg", typeof(int),false);
	tserviziomilitare.defineColumn("idserviziomilitare", typeof(int),false);
	tserviziomilitare.defineColumn("istituzione", typeof(string));
	tserviziomilitare.defineColumn("lt", typeof(DateTime),false);
	tserviziomilitare.defineColumn("lu", typeof(string),false);
	tserviziomilitare.defineColumn("mesi", typeof(int));
	tserviziomilitare.defineColumn("start", typeof(DateTime));
	tserviziomilitare.defineColumn("stop", typeof(DateTime));
	tserviziomilitare.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tserviziomilitare);
	tserviziomilitare.defineKey("idreg", "idserviziomilitare");

	//////////////////// SERVIZIOCONTRIBUTI /////////////////////////////////
	var tserviziocontributi= new MetaTable("serviziocontributi");
	tserviziocontributi.defineColumn("anni", typeof(int));
	tserviziocontributi.defineColumn("ct", typeof(DateTime),false);
	tserviziocontributi.defineColumn("cu", typeof(string),false);
	tserviziocontributi.defineColumn("giorni", typeof(int));
	tserviziocontributi.defineColumn("idreg", typeof(int),false);
	tserviziocontributi.defineColumn("idserviziocontributi", typeof(int),false);
	tserviziocontributi.defineColumn("istituzione", typeof(string));
	tserviziocontributi.defineColumn("lt", typeof(DateTime),false);
	tserviziocontributi.defineColumn("lu", typeof(string),false);
	tserviziocontributi.defineColumn("mesi", typeof(int));
	tserviziocontributi.defineColumn("start", typeof(DateTime));
	tserviziocontributi.defineColumn("stop", typeof(DateTime));
	tserviziocontributi.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tserviziocontributi);
	tserviziocontributi.defineKey("idreg", "idserviziocontributi");

	//////////////////// POSITION_ALIAS2 /////////////////////////////////
	var tposition_alias2= new MetaTable("position_alias2");
	tposition_alias2.defineColumn("active", typeof(string));
	tposition_alias2.defineColumn("idposition", typeof(int),false);
	tposition_alias2.defineColumn("title", typeof(string));
	tposition_alias2.ExtendedProperties["TableForReading"]="position";
	Tables.Add(tposition_alias2);
	tposition_alias2.defineKey("idposition");

	//////////////////// SERVIZIOPRERUOLOINPS /////////////////////////////////
	var tserviziopreruoloinps= new MetaTable("serviziopreruoloinps");
	tserviziopreruoloinps.defineColumn("anni", typeof(int));
	tserviziopreruoloinps.defineColumn("annokind", typeof(string));
	tserviziopreruoloinps.defineColumn("cedolini", typeof(string));
	tserviziopreruoloinps.defineColumn("ct", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("cu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("giorni", typeof(int));
	tserviziopreruoloinps.defineColumn("idposition", typeof(int));
	tserviziopreruoloinps.defineColumn("idreg", typeof(int),false);
	tserviziopreruoloinps.defineColumn("idserviziopreruoloinps", typeof(int),false);
	tserviziopreruoloinps.defineColumn("istituzione", typeof(string));
	tserviziopreruoloinps.defineColumn("lt", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("lu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("mesi", typeof(int));
	tserviziopreruoloinps.defineColumn("start", typeof(DateTime));
	tserviziopreruoloinps.defineColumn("stop", typeof(DateTime));
	tserviziopreruoloinps.defineColumn("!idposition_position_title", typeof(string));
	tserviziopreruoloinps.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tserviziopreruoloinps);
	tserviziopreruoloinps.defineKey("idreg", "idserviziopreruoloinps");

	//////////////////// POSITION_ALIAS1 /////////////////////////////////
	var tposition_alias1= new MetaTable("position_alias1");
	tposition_alias1.defineColumn("active", typeof(string));
	tposition_alias1.defineColumn("idposition", typeof(int),false);
	tposition_alias1.defineColumn("title", typeof(string));
	tposition_alias1.ExtendedProperties["TableForReading"]="position";
	Tables.Add(tposition_alias1);
	tposition_alias1.defineKey("idposition");

	//////////////////// SERVIZIOPRERUOLOTESORO /////////////////////////////////
	var tserviziopreruolotesoro= new MetaTable("serviziopreruolotesoro");
	tserviziopreruolotesoro.defineColumn("anni", typeof(int));
	tserviziopreruolotesoro.defineColumn("annokind", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("cedolini", typeof(string));
	tserviziopreruolotesoro.defineColumn("ct", typeof(DateTime),false);
	tserviziopreruolotesoro.defineColumn("cu", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("giorni", typeof(int));
	tserviziopreruolotesoro.defineColumn("idposition", typeof(int));
	tserviziopreruolotesoro.defineColumn("idreg", typeof(int),false);
	tserviziopreruolotesoro.defineColumn("idserviziopreruolotesoro", typeof(int),false);
	tserviziopreruolotesoro.defineColumn("istituzione", typeof(string));
	tserviziopreruolotesoro.defineColumn("lt", typeof(DateTime),false);
	tserviziopreruolotesoro.defineColumn("lu", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("mesi", typeof(int));
	tserviziopreruolotesoro.defineColumn("start", typeof(DateTime));
	tserviziopreruolotesoro.defineColumn("stop", typeof(DateTime));
	tserviziopreruolotesoro.defineColumn("!idposition_position_title", typeof(string));
	tserviziopreruolotesoro.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tserviziopreruolotesoro);
	tserviziopreruolotesoro.defineKey("idreg", "idserviziopreruolotesoro");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("title", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	var tregistrylegalstatus= new MetaTable("registrylegalstatus");
	tregistrylegalstatus.defineColumn("!anni", typeof(string));
	tregistrylegalstatus.defineColumn("!giorni", typeof(string));
	tregistrylegalstatus.defineColumn("!mesi", typeof(string));
	tregistrylegalstatus.defineColumn("active", typeof(string));
	tregistrylegalstatus.defineColumn("csa_class", typeof(string));
	tregistrylegalstatus.defineColumn("csa_compartment", typeof(string));
	tregistrylegalstatus.defineColumn("csa_role", typeof(string));
	tregistrylegalstatus.defineColumn("ct", typeof(DateTime));
	tregistrylegalstatus.defineColumn("cu", typeof(string));
	tregistrylegalstatus.defineColumn("datarivalutazione", typeof(DateTime));
	tregistrylegalstatus.defineColumn("iddaliaposition", typeof(int));
	tregistrylegalstatus.defineColumn("idinquadramento", typeof(int));
	tregistrylegalstatus.defineColumn("idposition", typeof(int));
	tregistrylegalstatus.defineColumn("idreg", typeof(int),false);
	tregistrylegalstatus.defineColumn("idregistrylegalstatus", typeof(int),false);
	tregistrylegalstatus.defineColumn("incomeclass", typeof(int));
	tregistrylegalstatus.defineColumn("incomeclassvalidity", typeof(DateTime));
	tregistrylegalstatus.defineColumn("livello", typeof(int));
	tregistrylegalstatus.defineColumn("lt", typeof(DateTime));
	tregistrylegalstatus.defineColumn("lu", typeof(string));
	tregistrylegalstatus.defineColumn("parttime", typeof(decimal));
	tregistrylegalstatus.defineColumn("percentualesufondiateneo", typeof(decimal));
	tregistrylegalstatus.defineColumn("rtf", typeof(Byte[]));
	tregistrylegalstatus.defineColumn("start", typeof(DateTime));
	tregistrylegalstatus.defineColumn("stop", typeof(DateTime));
	tregistrylegalstatus.defineColumn("tempdef", typeof(string));
	tregistrylegalstatus.defineColumn("tempindet", typeof(string));
	tregistrylegalstatus.defineColumn("txt", typeof(string));
	tregistrylegalstatus.defineColumn("!idposition_position_title", typeof(string));
	tregistrylegalstatus.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.defineKey("idreg", "idregistrylegalstatus");

	//////////////////// RICOSTRUZIONEANNIACCADEMICI /////////////////////////////////
	var tricostruzioneanniaccademici= new MetaTable("ricostruzioneanniaccademici");
	tricostruzioneanniaccademici.defineColumn("anninonvalidi", typeof(string));
	tricostruzioneanniaccademici.defineColumn("annoaccademico", typeof(string),false);
	tricostruzioneanniaccademici.defineColumn("giorni", typeof(int));
	tricostruzioneanniaccademici.defineColumn("idricostruzione", typeof(int),false);
	tricostruzioneanniaccademici.defineColumn("servizi", typeof(string));
	tricostruzioneanniaccademici.defineColumn("serviziorows", typeof(string));
	tricostruzioneanniaccademici.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tricostruzioneanniaccademici);
	tricostruzioneanniaccademici.defineKey("annoaccademico", "idricostruzione");

	//////////////////// SERVIZIRIEPILOGOVIEW /////////////////////////////////
	var tserviziriepilogoview= new MetaTable("serviziriepilogoview");
	tserviziriepilogoview.defineColumn("anni", typeof(int));
	tserviziriepilogoview.defineColumn("cedolini", typeof(string));
	tserviziriepilogoview.defineColumn("ct", typeof(DateTime),false);
	tserviziriepilogoview.defineColumn("cu", typeof(string),false);
	tserviziriepilogoview.defineColumn("giorni", typeof(int));
	tserviziriepilogoview.defineColumn("idreg", typeof(int),false);
	tserviziriepilogoview.defineColumn("idserviziriepilogoview", typeof(string),false);
	tserviziriepilogoview.defineColumn("istituzione", typeof(string));
	tserviziriepilogoview.defineColumn("lt", typeof(DateTime),false);
	tserviziriepilogoview.defineColumn("lu", typeof(string),false);
	tserviziriepilogoview.defineColumn("mesi", typeof(int));
	tserviziriepilogoview.defineColumn("start", typeof(DateTime));
	tserviziriepilogoview.defineColumn("stop", typeof(DateTime));
	tserviziriepilogoview.defineColumn("tipologia", typeof(string),false);
	tserviziriepilogoview.defineColumn("totaldays", typeof(int));
	Tables.Add(tserviziriepilogoview);
	tserviziriepilogoview.defineKey("idreg", "idserviziriepilogoview");

	//////////////////// RICOSTRUZIONENONVALIDITAVIEW /////////////////////////////////
	var tricostruzionenonvaliditaview= new MetaTable("ricostruzionenonvaliditaview");
	tricostruzionenonvaliditaview.defineColumn("aa_start", typeof(string),false);
	tricostruzionenonvaliditaview.defineColumn("aa_stop", typeof(string));
	tricostruzionenonvaliditaview.defineColumn("cedolini", typeof(string));
	tricostruzionenonvaliditaview.defineColumn("cf", typeof(string));
	tricostruzionenonvaliditaview.defineColumn("extmatricula", typeof(string));
	tricostruzionenonvaliditaview.defineColumn("forename", typeof(string));
	tricostruzionenonvaliditaview.defineColumn("giorni", typeof(int));
	tricostruzionenonvaliditaview.defineColumn("idreg", typeof(int),false);
	tricostruzionenonvaliditaview.defineColumn("start", typeof(DateTime));
	tricostruzionenonvaliditaview.defineColumn("startoriginal", typeof(DateTime));
	tricostruzionenonvaliditaview.defineColumn("stop", typeof(DateTime));
	tricostruzionenonvaliditaview.defineColumn("stoporiginal", typeof(DateTime));
	tricostruzionenonvaliditaview.defineColumn("surname", typeof(string));
	Tables.Add(tricostruzionenonvaliditaview);
	tricostruzionenonvaliditaview.defineKey("aa_start", "idreg");

	//////////////////// NONVALUTABILITAKIND /////////////////////////////////
	var tnonvalutabilitakind= new MetaTable("nonvalutabilitakind");
	tnonvalutabilitakind.defineColumn("active", typeof(string));
	tnonvalutabilitakind.defineColumn("idnonvalutabilitakind", typeof(int),false);
	tnonvalutabilitakind.defineColumn("title", typeof(string));
	Tables.Add(tnonvalutabilitakind);
	tnonvalutabilitakind.defineKey("idnonvalutabilitakind");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// RICOSTRUZIONEPERIODONV /////////////////////////////////
	var tricostruzioneperiodonv= new MetaTable("ricostruzioneperiodonv");
	tricostruzioneperiodonv.defineColumn("aa_start", typeof(string));
	tricostruzioneperiodonv.defineColumn("aa_stop", typeof(string));
	tricostruzioneperiodonv.defineColumn("idnonvalutabilitakind", typeof(int));
	tricostruzioneperiodonv.defineColumn("idreg", typeof(int),false);
	tricostruzioneperiodonv.defineColumn("idricostruzione", typeof(int),false);
	tricostruzioneperiodonv.defineColumn("idricostruzioneperiodonv", typeof(int),false);
	tricostruzioneperiodonv.defineColumn("!idnonvalutabilitakind_nonvalutabilitakind_title", typeof(string));
	Tables.Add(tricostruzioneperiodonv);
	tricostruzioneperiodonv.defineKey("idreg", "idricostruzione", "idricostruzioneperiodonv");

	//////////////////// RICOSTRUZIONEKINDDEFAULTVIEW /////////////////////////////////
	var tricostruzionekinddefaultview= new MetaTable("ricostruzionekinddefaultview");
	tricostruzionekinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tricostruzionekinddefaultview.defineColumn("idricostruzionekind", typeof(int),false);
	tricostruzionekinddefaultview.defineColumn("ricostruzionekind_active", typeof(string));
	tricostruzionekinddefaultview.defineColumn("ricostruzionekind_description", typeof(string));
	tricostruzionekinddefaultview.defineColumn("ricostruzionekind_sortcode", typeof(int));
	tricostruzionekinddefaultview.defineColumn("title", typeof(string));
	Tables.Add(tricostruzionekinddefaultview);
	tricostruzionekinddefaultview.defineKey("idricostruzionekind");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIDEFAULTVIEW /////////////////////////////////
	var tgetregistrydocentiamministratividefaultview= new MetaTable("getregistrydocentiamministratividefaultview");
	tgetregistrydocentiamministratividefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tgetregistrydocentiamministratividefaultview);
	tgetregistrydocentiamministratividefaultview.defineKey("idreg");

	//////////////////// RICOSTRUZIONE /////////////////////////////////
	var tricostruzione= new MetaTable("ricostruzione");
	tricostruzione.defineColumn("!decreto", typeof(string));
	tricostruzione.defineColumn("annimilitare", typeof(int));
	tricostruzione.defineColumn("annipre1516", typeof(int));
	tricostruzione.defineColumn("annipre2014", typeof(int));
	tricostruzione.defineColumn("anniruolo", typeof(int));
	tricostruzione.defineColumn("datacontratto", typeof(DateTime));
	tricostruzione.defineColumn("datadecreto", typeof(DateTime),false);
	tricostruzione.defineColumn("dataecon", typeof(DateTime));
	tricostruzione.defineColumn("datagiur", typeof(DateTime));
	tricostruzione.defineColumn("dataregcontratto", typeof(DateTime));
	tricostruzione.defineColumn("dpanzianitaa", typeof(int));
	tricostruzione.defineColumn("dpanzianitadata", typeof(DateTime));
	tricostruzione.defineColumn("dpanzianitag", typeof(int));
	tricostruzione.defineColumn("dpanzianitam", typeof(int));
	tricostruzione.defineColumn("dpdata", typeof(DateTime));
	tricostruzione.defineColumn("dpnumero", typeof(string));
	tricostruzione.defineColumn("giornimilitare", typeof(int));
	tricostruzione.defineColumn("idreg", typeof(int),false);
	tricostruzione.defineColumn("idricostruzione", typeof(int),false);
	tricostruzione.defineColumn("idricostruzionekind", typeof(int));
	tricostruzione.defineColumn("legge", typeof(string));
	tricostruzione.defineColumn("mesialtro", typeof(int));
	tricostruzione.defineColumn("mesimilitare", typeof(int));
	tricostruzione.defineColumn("mesipre1415", typeof(int));
	tricostruzione.defineColumn("mesipre2011", typeof(int));
	tricostruzione.defineColumn("numerodecreto", typeof(string));
	tricostruzione.defineColumn("pensiona", typeof(int));
	tricostruzione.defineColumn("pensiong", typeof(int));
	tricostruzione.defineColumn("pensionm", typeof(int));
	tricostruzione.defineColumn("preruoloa", typeof(int));
	tricostruzione.defineColumn("preruoloecona", typeof(int));
	tricostruzione.defineColumn("preruoloecong", typeof(int));
	tricostruzione.defineColumn("preruoloeconm", typeof(int));
	tricostruzione.defineColumn("preruolog", typeof(int));
	tricostruzione.defineColumn("preruoloisruolo", typeof(string));
	tricostruzione.defineColumn("preruolom", typeof(int));
	tricostruzione.defineColumn("preruolotota", typeof(int));
	tricostruzione.defineColumn("preruolototg", typeof(int));
	tricostruzione.defineColumn("preruolototm", typeof(int));
	tricostruzione.defineColumn("protocollo", typeof(string));
	tricostruzione.defineColumn("ruolonominaa", typeof(int));
	tricostruzione.defineColumn("ruolonominag", typeof(int));
	tricostruzione.defineColumn("ruolonominam", typeof(int));
	Tables.Add(tricostruzione);
	tricostruzione.defineKey("idreg", "idricostruzione");

	#endregion


	#region DataRelation creation
	var cPar = new []{ricostruzione.Columns["idricostruzione"]};
	var cChild = new []{ricostruzioneattach.Columns["idricostruzione"]};
	Relations.Add(new DataRelation("FK_ricostruzioneattach_ricostruzione_idricostruzione",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{ricostruzioneattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_ricostruzioneattach_attach_idattach",cPar,cChild,false));

	cPar = new []{ricostruzione.Columns["idreg"]};
	cChild = new []{servizioaltro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_servizioaltro_ricostruzione_idreg",cPar,cChild,false));

	cPar = new []{ricostruzione.Columns["idreg"]};
	cChild = new []{servizioricongiunzioni.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_servizioricongiunzioni_ricostruzione_idreg",cPar,cChild,false));

	cPar = new []{ricostruzione.Columns["idreg"]};
	cChild = new []{serviziomilitare.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziomilitare_ricostruzione_idreg",cPar,cChild,false));

	cPar = new []{ricostruzione.Columns["idreg"]};
	cChild = new []{serviziocontributi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziocontributi_ricostruzione_idreg",cPar,cChild,false));

	cPar = new []{ricostruzione.Columns["idreg"]};
	cChild = new []{serviziopreruoloinps.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_ricostruzione_idreg",cPar,cChild,false));

	cPar = new []{position_alias2.Columns["idposition"]};
	cChild = new []{serviziopreruoloinps.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_position_alias2_idposition",cPar,cChild,false));

	cPar = new []{ricostruzione.Columns["idreg"]};
	cChild = new []{serviziopreruolotesoro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_ricostruzione_idreg",cPar,cChild,false));

	cPar = new []{position_alias1.Columns["idposition"]};
	cChild = new []{serviziopreruolotesoro.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_position_alias1_idposition",cPar,cChild,false));

	cPar = new []{ricostruzione.Columns["idreg"]};
	cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_ricostruzione_idreg",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_position_idposition",cPar,cChild,false));

	cPar = new []{ricostruzione.Columns["idricostruzione"]};
	cChild = new []{ricostruzioneanniaccademici.Columns["idricostruzione"]};
	Relations.Add(new DataRelation("FK_ricostruzioneanniaccademici_ricostruzione_idricostruzione",cPar,cChild,false));

	cPar = new []{serviziriepilogoview.Columns["idreg"]};
	cChild = new []{ricostruzione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_ricostruzione_serviziriepilogoview_idreg",cPar,cChild,false));

	cPar = new []{ricostruzionenonvaliditaview.Columns["idreg"]};
	cChild = new []{ricostruzione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_ricostruzione_ricostruzionenonvaliditaview_idreg",cPar,cChild,false));

	cPar = new []{ricostruzione.Columns["idreg"], ricostruzione.Columns["idricostruzione"]};
	cChild = new []{ricostruzioneperiodonv.Columns["idreg"], ricostruzioneperiodonv.Columns["idricostruzione"]};
	Relations.Add(new DataRelation("FK_ricostruzioneperiodonv_ricostruzione_idreg-idricostruzione",cPar,cChild,false));

	cPar = new []{nonvalutabilitakind.Columns["idnonvalutabilitakind"]};
	cChild = new []{ricostruzioneperiodonv.Columns["idnonvalutabilitakind"]};
	Relations.Add(new DataRelation("FK_ricostruzioneperiodonv_nonvalutabilitakind_idnonvalutabilitakind",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{ricostruzioneperiodonv.Columns["aa_stop"]};
	Relations.Add(new DataRelation("FK_ricostruzioneperiodonv_annoaccademico_alias1_aa_stop",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{ricostruzioneperiodonv.Columns["aa_start"]};
	Relations.Add(new DataRelation("FK_ricostruzioneperiodonv_annoaccademico_aa_start",cPar,cChild,false));

	cPar = new []{ricostruzionekinddefaultview.Columns["idricostruzionekind"]};
	cChild = new []{ricostruzione.Columns["idricostruzionekind"]};
	Relations.Add(new DataRelation("FK_ricostruzione_ricostruzionekinddefaultview_idricostruzionekind",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview.Columns["idreg"]};
	cChild = new []{ricostruzione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_ricostruzione_getregistrydocentiamministratividefaultview_idreg",cPar,cChild,false));

	#endregion

}
}
}
