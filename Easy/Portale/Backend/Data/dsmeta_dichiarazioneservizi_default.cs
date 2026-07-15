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
[System.Xml.Serialization.XmlRoot("dsmeta_dichiarazioneservizi_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_dichiarazioneservizi_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarazioneserviziattach 		=> (MetaTable)Tables["dichiarazioneserviziattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziriepilogoview 		=> (MetaTable)Tables["serviziriepilogoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable servizioaltro 		=> (MetaTable)Tables["servizioaltro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable servizioricongiunzioni 		=> (MetaTable)Tables["servizioricongiunzioni"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziomilitare 		=> (MetaTable)Tables["serviziomilitare"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziocontributi 		=> (MetaTable)Tables["serviziocontributi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tiponomina_alias1 		=> (MetaTable)Tables["tiponomina_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position_alias2 		=> (MetaTable)Tables["position_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsuale_alias1 		=> (MetaTable)Tables["classconsorsuale_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziopreruoloinps 		=> (MetaTable)Tables["serviziopreruoloinps"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tiponomina 		=> (MetaTable)Tables["tiponomina"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position_alias1 		=> (MetaTable)Tables["position_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsuale 		=> (MetaTable)Tables["classconsorsuale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziopreruolotesoro 		=> (MetaTable)Tables["serviziopreruolotesoro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatus 		=> (MetaTable)Tables["registrylegalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarazioneservizi 		=> (MetaTable)Tables["dichiarazioneservizi"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_dichiarazioneservizi_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_dichiarazioneservizi_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_dichiarazioneservizi_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_dichiarazioneservizi_default.xsd";

	#region create DataTables
	//////////////////// DICHIARAZIONESERVIZIATTACH /////////////////////////////////
	var tdichiarazioneserviziattach= new MetaTable("dichiarazioneserviziattach");
	tdichiarazioneserviziattach.defineColumn("ct", typeof(DateTime),false);
	tdichiarazioneserviziattach.defineColumn("cu", typeof(string),false);
	tdichiarazioneserviziattach.defineColumn("idattach", typeof(int),false);
	tdichiarazioneserviziattach.defineColumn("iddichiarazioneservizi", typeof(int),false);
	tdichiarazioneserviziattach.defineColumn("idreg", typeof(int),false);
	tdichiarazioneserviziattach.defineColumn("lt", typeof(DateTime),false);
	tdichiarazioneserviziattach.defineColumn("lu", typeof(string),false);
	tdichiarazioneserviziattach.defineColumn("title", typeof(string));
	Tables.Add(tdichiarazioneserviziattach);
	tdichiarazioneserviziattach.defineKey("idattach", "iddichiarazioneservizi", "idreg");

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

	//////////////////// TIPONOMINA_ALIAS1 /////////////////////////////////
	var ttiponomina_alias1= new MetaTable("tiponomina_alias1");
	ttiponomina_alias1.defineColumn("active", typeof(string));
	ttiponomina_alias1.defineColumn("idtiponomina", typeof(int),false);
	ttiponomina_alias1.defineColumn("title", typeof(string));
	ttiponomina_alias1.ExtendedProperties["TableForReading"]="tiponomina";
	Tables.Add(ttiponomina_alias1);
	ttiponomina_alias1.defineKey("idtiponomina");

	//////////////////// POSITION_ALIAS2 /////////////////////////////////
	var tposition_alias2= new MetaTable("position_alias2");
	tposition_alias2.defineColumn("active", typeof(string));
	tposition_alias2.defineColumn("idposition", typeof(int),false);
	tposition_alias2.defineColumn("title", typeof(string));
	tposition_alias2.ExtendedProperties["TableForReading"]="position";
	Tables.Add(tposition_alias2);
	tposition_alias2.defineKey("idposition");

	//////////////////// CLASSCONSORSUALE_ALIAS1 /////////////////////////////////
	var tclassconsorsuale_alias1= new MetaTable("classconsorsuale_alias1");
	tclassconsorsuale_alias1.defineColumn("active", typeof(string),false);
	tclassconsorsuale_alias1.defineColumn("description", typeof(string),false);
	tclassconsorsuale_alias1.defineColumn("idclassconsorsuale", typeof(int),false);
	tclassconsorsuale_alias1.defineColumn("title", typeof(string),false);
	tclassconsorsuale_alias1.ExtendedProperties["TableForReading"]="classconsorsuale";
	Tables.Add(tclassconsorsuale_alias1);
	tclassconsorsuale_alias1.defineKey("idclassconsorsuale");

	//////////////////// SERVIZIOPRERUOLOINPS /////////////////////////////////
	var tserviziopreruoloinps= new MetaTable("serviziopreruoloinps");
	tserviziopreruoloinps.defineColumn("anni", typeof(int));
	tserviziopreruoloinps.defineColumn("annokind", typeof(string));
	tserviziopreruoloinps.defineColumn("cedolini", typeof(string));
	tserviziopreruoloinps.defineColumn("ct", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("cu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("giorni", typeof(int));
	tserviziopreruoloinps.defineColumn("idclassconsorsuale", typeof(int));
	tserviziopreruoloinps.defineColumn("idposition", typeof(int));
	tserviziopreruoloinps.defineColumn("idreg", typeof(int),false);
	tserviziopreruoloinps.defineColumn("idserviziopreruoloinps", typeof(int),false);
	tserviziopreruoloinps.defineColumn("idtiponomina", typeof(int));
	tserviziopreruoloinps.defineColumn("istituzione", typeof(string));
	tserviziopreruoloinps.defineColumn("lt", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("lu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("mesi", typeof(int));
	tserviziopreruoloinps.defineColumn("start", typeof(DateTime));
	tserviziopreruoloinps.defineColumn("stop", typeof(DateTime));
	tserviziopreruoloinps.defineColumn("!idclassconsorsuale_classconsorsuale_title", typeof(string));
	tserviziopreruoloinps.defineColumn("!idclassconsorsuale_classconsorsuale_description", typeof(string));
	tserviziopreruoloinps.defineColumn("!idposition_position_title", typeof(string));
	tserviziopreruoloinps.defineColumn("!idtiponomina_tiponomina_title", typeof(string));
	tserviziopreruoloinps.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tserviziopreruoloinps);
	tserviziopreruoloinps.defineKey("idreg", "idserviziopreruoloinps");

	//////////////////// TIPONOMINA /////////////////////////////////
	var ttiponomina= new MetaTable("tiponomina");
	ttiponomina.defineColumn("active", typeof(string));
	ttiponomina.defineColumn("idtiponomina", typeof(int),false);
	ttiponomina.defineColumn("title", typeof(string));
	Tables.Add(ttiponomina);
	ttiponomina.defineKey("idtiponomina");

	//////////////////// POSITION_ALIAS1 /////////////////////////////////
	var tposition_alias1= new MetaTable("position_alias1");
	tposition_alias1.defineColumn("active", typeof(string));
	tposition_alias1.defineColumn("idposition", typeof(int),false);
	tposition_alias1.defineColumn("title", typeof(string));
	tposition_alias1.ExtendedProperties["TableForReading"]="position";
	Tables.Add(tposition_alias1);
	tposition_alias1.defineKey("idposition");

	//////////////////// CLASSCONSORSUALE /////////////////////////////////
	var tclassconsorsuale= new MetaTable("classconsorsuale");
	tclassconsorsuale.defineColumn("active", typeof(string),false);
	tclassconsorsuale.defineColumn("description", typeof(string),false);
	tclassconsorsuale.defineColumn("idclassconsorsuale", typeof(int),false);
	tclassconsorsuale.defineColumn("title", typeof(string),false);
	Tables.Add(tclassconsorsuale);
	tclassconsorsuale.defineKey("idclassconsorsuale");

	//////////////////// SERVIZIOPRERUOLOTESORO /////////////////////////////////
	var tserviziopreruolotesoro= new MetaTable("serviziopreruolotesoro");
	tserviziopreruolotesoro.defineColumn("anni", typeof(int));
	tserviziopreruolotesoro.defineColumn("annokind", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("cedolini", typeof(string));
	tserviziopreruolotesoro.defineColumn("ct", typeof(DateTime),false);
	tserviziopreruolotesoro.defineColumn("cu", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("giorni", typeof(int));
	tserviziopreruolotesoro.defineColumn("idclassconsorsuale", typeof(int));
	tserviziopreruolotesoro.defineColumn("idposition", typeof(int));
	tserviziopreruolotesoro.defineColumn("idreg", typeof(int),false);
	tserviziopreruolotesoro.defineColumn("idserviziopreruolotesoro", typeof(int),false);
	tserviziopreruolotesoro.defineColumn("idtiponomina", typeof(int));
	tserviziopreruolotesoro.defineColumn("istituzione", typeof(string));
	tserviziopreruolotesoro.defineColumn("lt", typeof(DateTime),false);
	tserviziopreruolotesoro.defineColumn("lu", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("mesi", typeof(int));
	tserviziopreruolotesoro.defineColumn("start", typeof(DateTime));
	tserviziopreruolotesoro.defineColumn("stop", typeof(DateTime));
	tserviziopreruolotesoro.defineColumn("!idclassconsorsuale_classconsorsuale_title", typeof(string));
	tserviziopreruolotesoro.defineColumn("!idclassconsorsuale_classconsorsuale_description", typeof(string));
	tserviziopreruolotesoro.defineColumn("!idposition_position_title", typeof(string));
	tserviziopreruolotesoro.defineColumn("!idtiponomina_tiponomina_title", typeof(string));
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
	tregistrylegalstatus.defineColumn("active", typeof(string));
	tregistrylegalstatus.defineColumn("anni", typeof(int));
	tregistrylegalstatus.defineColumn("annokind", typeof(string));
	tregistrylegalstatus.defineColumn("cedolini", typeof(string));
	tregistrylegalstatus.defineColumn("csa_class", typeof(string));
	tregistrylegalstatus.defineColumn("csa_compartment", typeof(string));
	tregistrylegalstatus.defineColumn("csa_role", typeof(string));
	tregistrylegalstatus.defineColumn("ct", typeof(DateTime));
	tregistrylegalstatus.defineColumn("cu", typeof(string));
	tregistrylegalstatus.defineColumn("datarivalutazione", typeof(DateTime));
	tregistrylegalstatus.defineColumn("flagdefault", typeof(string));
	tregistrylegalstatus.defineColumn("giorni", typeof(int));
	tregistrylegalstatus.defineColumn("idclassconsorsuale", typeof(int));
	tregistrylegalstatus.defineColumn("iddaliaposition", typeof(int));
	tregistrylegalstatus.defineColumn("idinquadramento", typeof(int));
	tregistrylegalstatus.defineColumn("idposition", typeof(int));
	tregistrylegalstatus.defineColumn("idreg", typeof(int),false);
	tregistrylegalstatus.defineColumn("idregistrylegalstatus", typeof(int),false);
	tregistrylegalstatus.defineColumn("idtipologiaruolo", typeof(int));
	tregistrylegalstatus.defineColumn("idtiponomina", typeof(int));
	tregistrylegalstatus.defineColumn("incomeclass", typeof(int));
	tregistrylegalstatus.defineColumn("incomeclassvalidity", typeof(DateTime));
	tregistrylegalstatus.defineColumn("istituzione", typeof(string));
	tregistrylegalstatus.defineColumn("livello", typeof(int));
	tregistrylegalstatus.defineColumn("lt", typeof(DateTime));
	tregistrylegalstatus.defineColumn("lu", typeof(string));
	tregistrylegalstatus.defineColumn("mesi", typeof(int));
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

	//////////////////// DICHIARAZIONESERVIZI /////////////////////////////////
	var tdichiarazioneservizi= new MetaTable("dichiarazioneservizi");
	tdichiarazioneservizi.defineColumn("ct", typeof(DateTime),false);
	tdichiarazioneservizi.defineColumn("cu", typeof(string),false);
	tdichiarazioneservizi.defineColumn("data", typeof(DateTime));
	tdichiarazioneservizi.defineColumn("iddichiarazioneservizi", typeof(int),false);
	tdichiarazioneservizi.defineColumn("idreg", typeof(int),false);
	tdichiarazioneservizi.defineColumn("lt", typeof(DateTime),false);
	tdichiarazioneservizi.defineColumn("lu", typeof(string),false);
	tdichiarazioneservizi.defineColumn("note", typeof(string));
	tdichiarazioneservizi.defineColumn("noteistituto", typeof(string));
	tdichiarazioneservizi.defineColumn("protanno", typeof(int));
	tdichiarazioneservizi.defineColumn("protnumero", typeof(int));
	Tables.Add(tdichiarazioneservizi);
	tdichiarazioneservizi.defineKey("iddichiarazioneservizi", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{dichiarazioneservizi.Columns["iddichiarazioneservizi"], dichiarazioneservizi.Columns["idreg"]};
	var cChild = new []{dichiarazioneserviziattach.Columns["iddichiarazioneservizi"], dichiarazioneserviziattach.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_dichiarazioneserviziattach_dichiarazioneservizi_iddichiarazioneservizi-idreg",cPar,cChild,false));

	cPar = new []{serviziriepilogoview.Columns["idreg"]};
	cChild = new []{dichiarazioneservizi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_dichiarazioneservizi_serviziriepilogoview_idreg",cPar,cChild,false));

	cPar = new []{dichiarazioneservizi.Columns["idreg"]};
	cChild = new []{servizioaltro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_servizioaltro_dichiarazioneservizi_idreg",cPar,cChild,false));

	cPar = new []{dichiarazioneservizi.Columns["idreg"]};
	cChild = new []{servizioricongiunzioni.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_servizioricongiunzioni_dichiarazioneservizi_idreg",cPar,cChild,false));

	cPar = new []{dichiarazioneservizi.Columns["idreg"]};
	cChild = new []{serviziomilitare.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziomilitare_dichiarazioneservizi_idreg",cPar,cChild,false));

	cPar = new []{dichiarazioneservizi.Columns["idreg"]};
	cChild = new []{serviziocontributi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziocontributi_dichiarazioneservizi_idreg",cPar,cChild,false));

	cPar = new []{dichiarazioneservizi.Columns["idreg"]};
	cChild = new []{serviziopreruoloinps.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_dichiarazioneservizi_idreg",cPar,cChild,false));

	cPar = new []{tiponomina_alias1.Columns["idtiponomina"]};
	cChild = new []{serviziopreruoloinps.Columns["idtiponomina"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_tiponomina_alias1_idtiponomina",cPar,cChild,false));

	cPar = new []{position_alias2.Columns["idposition"]};
	cChild = new []{serviziopreruoloinps.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_position_alias2_idposition",cPar,cChild,false));

	cPar = new []{classconsorsuale_alias1.Columns["idclassconsorsuale"]};
	cChild = new []{serviziopreruoloinps.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_classconsorsuale_alias1_idclassconsorsuale",cPar,cChild,false));

	cPar = new []{dichiarazioneservizi.Columns["idreg"]};
	cChild = new []{serviziopreruolotesoro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_dichiarazioneservizi_idreg",cPar,cChild,false));

	cPar = new []{tiponomina.Columns["idtiponomina"]};
	cChild = new []{serviziopreruolotesoro.Columns["idtiponomina"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_tiponomina_idtiponomina",cPar,cChild,false));

	cPar = new []{position_alias1.Columns["idposition"]};
	cChild = new []{serviziopreruolotesoro.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_position_alias1_idposition",cPar,cChild,false));

	cPar = new []{classconsorsuale.Columns["idclassconsorsuale"]};
	cChild = new []{serviziopreruolotesoro.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_classconsorsuale_idclassconsorsuale",cPar,cChild,false));

	cPar = new []{dichiarazioneservizi.Columns["idreg"]};
	cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_dichiarazioneservizi_idreg",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_position_idposition",cPar,cChild,false));

	#endregion

}
}
}
