
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
[System.Xml.Serialization.XmlRoot("dsmeta_attivform_erogata"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_attivform_erogata: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable valutazionekind 		=> (MetaTable)Tables["valutazionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformvalutazionekind 		=> (MetaTable)Tables["attivformvalutazionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable orakind 		=> (MetaTable)Tables["orakind"];

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
	public MetaTable appellokind 		=> (MetaTable)Tables["appellokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appelloazionekind 		=> (MetaTable)Tables["appelloazionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sessionekind 		=> (MetaTable)Tables["sessionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sessione 		=> (MetaTable)Tables["sessione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appello 		=> (MetaTable)Tables["appello"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appelloattivform 		=> (MetaTable)Tables["appelloattivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproggrupp 		=> (MetaTable)Tables["didproggrupp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzannodefaultview 		=> (MetaTable)Tables["didprogporzannodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogannodefaultview 		=> (MetaTable)Tables["didprogannodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogoridefaultview 		=> (MetaTable)Tables["didprogoridefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegnintegdefaultview 		=> (MetaTable)Tables["insegnintegdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegndefaultview 		=> (MetaTable)Tables["insegndefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_attivform_erogata(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_attivform_erogata (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_attivform_erogata";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_attivform_erogata.xsd";

	#region create DataTables
	//////////////////// VALUTAZIONEKIND /////////////////////////////////
	var tvalutazionekind= new MetaTable("valutazionekind");
	tvalutazionekind.defineColumn("active", typeof(string),false);
	tvalutazionekind.defineColumn("ct", typeof(DateTime),false);
	tvalutazionekind.defineColumn("cu", typeof(string),false);
	tvalutazionekind.defineColumn("description", typeof(string));
	tvalutazionekind.defineColumn("idvalutazionekind", typeof(int),false);
	tvalutazionekind.defineColumn("lt", typeof(DateTime),false);
	tvalutazionekind.defineColumn("lu", typeof(string),false);
	tvalutazionekind.defineColumn("sortcode", typeof(int),false);
	tvalutazionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tvalutazionekind);
	tvalutazionekind.defineKey("idvalutazionekind");

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

	//////////////////// ORAKIND /////////////////////////////////
	var torakind= new MetaTable("orakind");
	torakind.defineColumn("active", typeof(string));
	torakind.defineColumn("idorakind", typeof(int),false);
	torakind.defineColumn("title", typeof(string));
	Tables.Add(torakind);
	torakind.defineKey("idorakind");

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
	tattivformcaratteristicaora.defineColumn("!idorakind_orakind_title", typeof(string));
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
	tattivformcaratteristica.defineColumn("!attivformcaratteristicaora", typeof(string));
	tattivformcaratteristica.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tattivformcaratteristica);
	tattivformcaratteristica.defineKey("aa", "idattivform", "idattivformcaratteristica", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// APPELLOKIND /////////////////////////////////
	var tappellokind= new MetaTable("appellokind");
	tappellokind.defineColumn("active", typeof(string),false);
	tappellokind.defineColumn("idappellokind", typeof(int),false);
	tappellokind.defineColumn("title", typeof(string),false);
	Tables.Add(tappellokind);
	tappellokind.defineKey("idappellokind");

	//////////////////// APPELLOAZIONEKIND /////////////////////////////////
	var tappelloazionekind= new MetaTable("appelloazionekind");
	tappelloazionekind.defineColumn("active", typeof(string));
	tappelloazionekind.defineColumn("idappelloazionekind", typeof(int),false);
	tappelloazionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tappelloazionekind);
	tappelloazionekind.defineKey("idappelloazionekind");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// SESSIONEKIND /////////////////////////////////
	var tsessionekind= new MetaTable("sessionekind");
	tsessionekind.defineColumn("active", typeof(string),false);
	tsessionekind.defineColumn("idsessionekind", typeof(int),false);
	tsessionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tsessionekind);
	tsessionekind.defineKey("idsessionekind");

	//////////////////// SESSIONE /////////////////////////////////
	var tsessione= new MetaTable("sessione");
	tsessione.defineColumn("ct", typeof(DateTime),false);
	tsessione.defineColumn("cu", typeof(string),false);
	tsessione.defineColumn("idappellokind", typeof(int));
	tsessione.defineColumn("idsessione", typeof(int),false);
	tsessione.defineColumn("idsessionekind", typeof(int));
	tsessione.defineColumn("lt", typeof(DateTime),false);
	tsessione.defineColumn("lu", typeof(string),false);
	tsessione.defineColumn("start", typeof(DateTime));
	tsessione.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsessione);
	tsessione.defineKey("idsessione");

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
	tappelloattivform.defineColumn("!idappello_appello_description", typeof(string));
	tappelloattivform.defineColumn("!idappello_annoaccademico_aa", typeof(string));
	tappelloattivform.defineColumn("!idappello_appelloazionekind_title", typeof(string));
	tappelloattivform.defineColumn("!idappello_appellokind_title", typeof(string));
	tappelloattivform.defineColumn("!idappello_sessione_sessionekind_title", typeof(string));
	tappelloattivform.defineColumn("!idappello_sessione_start", typeof(DateTime));
	tappelloattivform.defineColumn("!idappello_sessione_stop", typeof(DateTime));
	tappelloattivform.defineColumn("!idappello_appello_minvoto", typeof(int));
	tappelloattivform.defineColumn("!idappello_appello_basevoto", typeof(int));
	tappelloattivform.defineColumn("!idappello_appello_prointermedia", typeof(string));
	tappelloattivform.defineColumn("!idappello_appello_posti", typeof(int));
	tappelloattivform.defineColumn("!idappello_appello_prenotstart", typeof(DateTime));
	tappelloattivform.defineColumn("!idappello_appello_penotend", typeof(DateTime));
	tappelloattivform.defineColumn("!idappello_appello_publicato", typeof(string));
	tappelloattivform.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tappelloattivform);
	tappelloattivform.defineKey("aa", "idappello", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

	//////////////////// DIDPROGGRUPP /////////////////////////////////
	var tdidproggrupp= new MetaTable("didproggrupp");
	tdidproggrupp.defineColumn("idcorsostudio", typeof(int),false);
	tdidproggrupp.defineColumn("iddidprog", typeof(int),false);
	tdidproggrupp.defineColumn("iddidproggrupp", typeof(int),false);
	tdidproggrupp.defineColumn("title", typeof(string));
	Tables.Add(tdidproggrupp);
	tdidproggrupp.defineKey("idcorsostudio", "iddidprog", "iddidproggrupp");

	//////////////////// DIDPROGPORZANNODEFAULTVIEW /////////////////////////////////
	var tdidprogporzannodefaultview= new MetaTable("didprogporzannodefaultview");
	tdidprogporzannodefaultview.defineColumn("aa", typeof(string),false);
	tdidprogporzannodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogporzannodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	Tables.Add(tdidprogporzannodefaultview);
	tdidprogporzannodefaultview.defineKey("iddidprogporzanno");

	//////////////////// DIDPROGANNODEFAULTVIEW /////////////////////////////////
	var tdidprogannodefaultview= new MetaTable("didprogannodefaultview");
	tdidprogannodefaultview.defineColumn("aa", typeof(string),false);
	tdidprogannodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogannodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidproganno", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprogori", typeof(int),false);
	Tables.Add(tdidprogannodefaultview);
	tdidprogannodefaultview.defineKey("iddidproganno");

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
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// INSEGNINTEGDEFAULTVIEW /////////////////////////////////
	var tinsegnintegdefaultview= new MetaTable("insegnintegdefaultview");
	tinsegnintegdefaultview.defineColumn("denominazione", typeof(string));
	tinsegnintegdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinsegnintegdefaultview.defineColumn("idinsegn", typeof(int),false);
	tinsegnintegdefaultview.defineColumn("idinsegninteg", typeof(int),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_codice", typeof(string));
	tinsegnintegdefaultview.defineColumn("insegninteg_ct", typeof(DateTime),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_cu", typeof(string),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_denominazione_en", typeof(string));
	tinsegnintegdefaultview.defineColumn("insegninteg_lt", typeof(DateTime),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_lu", typeof(string),false);
	Tables.Add(tinsegnintegdefaultview);
	tinsegnintegdefaultview.defineKey("idinsegninteg");

	//////////////////// INSEGNDEFAULTVIEW /////////////////////////////////
	var tinsegndefaultview= new MetaTable("insegndefaultview");
	tinsegndefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinsegndefaultview.defineColumn("idcorsostudio", typeof(int));
	tinsegndefaultview.defineColumn("idinsegn", typeof(int),false);
	tinsegndefaultview.defineColumn("idstruttura", typeof(int));
	Tables.Add(tinsegndefaultview);
	tinsegndefaultview.defineKey("idinsegn");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{attivform.Columns["aa"], attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogporzanno"]};
	var cChild = new []{attivformvalutazionekind.Columns["aa"], attivformvalutazionekind.Columns["idattivform"], attivformvalutazionekind.Columns["idcorsostudio"], attivformvalutazionekind.Columns["iddidprog"], attivformvalutazionekind.Columns["iddidproganno"], attivformvalutazionekind.Columns["iddidprogcurr"], attivformvalutazionekind.Columns["iddidprogori"], attivformvalutazionekind.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformvalutazionekind_attivform_aa-idattivform-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{valutazionekind.Columns["idvalutazionekind"]};
	cChild = new []{attivformvalutazionekind.Columns["idvalutazionekind"]};
	Relations.Add(new DataRelation("FK_attivformvalutazionekind_valutazionekind_idvalutazionekind",cPar,cChild,false));

	cPar = new []{attivform.Columns["aa"], attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogporzanno"]};
	cChild = new []{attivformcaratteristica.Columns["aa"], attivformcaratteristica.Columns["idattivform"], attivformcaratteristica.Columns["idcorsostudio"], attivformcaratteristica.Columns["iddidprog"], attivformcaratteristica.Columns["iddidproganno"], attivformcaratteristica.Columns["iddidprogcurr"], attivformcaratteristica.Columns["iddidprogori"], attivformcaratteristica.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_attivform_aa-idattivform-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{attivformcaratteristica.Columns["aa"], attivformcaratteristica.Columns["idattivform"], attivformcaratteristica.Columns["idattivformcaratteristica"], attivformcaratteristica.Columns["idcorsostudio"], attivformcaratteristica.Columns["iddidprog"], attivformcaratteristica.Columns["iddidproganno"], attivformcaratteristica.Columns["iddidprogcurr"], attivformcaratteristica.Columns["iddidprogori"], attivformcaratteristica.Columns["iddidprogporzanno"]};
	cChild = new []{attivformcaratteristicaora.Columns["aa"], attivformcaratteristicaora.Columns["idattivform"], attivformcaratteristicaora.Columns["idattivformcaratteristica"], attivformcaratteristicaora.Columns["idcorsostudio"], attivformcaratteristicaora.Columns["iddidprog"], attivformcaratteristicaora.Columns["iddidproganno"], attivformcaratteristicaora.Columns["iddidprogcurr"], attivformcaratteristicaora.Columns["iddidprogori"], attivformcaratteristicaora.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristicaora_attivformcaratteristica_aa-idattivform-idattivformcaratteristica-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{orakind.Columns["idorakind"]};
	cChild = new []{attivformcaratteristicaora.Columns["idorakind"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristicaora_orakind_idorakind",cPar,cChild,false));

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

	cPar = new []{appello.Columns["idappello"]};
	cChild = new []{appelloattivform.Columns["idappello"]};
	Relations.Add(new DataRelation("FK_appelloattivform_appello_idappello",cPar,cChild,false));

	cPar = new []{sessione.Columns["idsessione"]};
	cChild = new []{appello.Columns["idsessione"]};
	Relations.Add(new DataRelation("FK_appello_sessione_idsessione",cPar,cChild,false));

	cPar = new []{appellokind.Columns["idappellokind"]};
	cChild = new []{appello.Columns["idappellokind"]};
	Relations.Add(new DataRelation("FK_appello_appellokind_idappellokind",cPar,cChild,false));

	cPar = new []{appelloazionekind.Columns["idappelloazionekind"]};
	cChild = new []{appello.Columns["idappelloazionekind"]};
	Relations.Add(new DataRelation("FK_appello_appelloazionekind_idappelloazionekind",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{appello.Columns["aa"]};
	Relations.Add(new DataRelation("FK_appello_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{sessionekind.Columns["idsessionekind"]};
	cChild = new []{sessione.Columns["idsessionekind"]};
	Relations.Add(new DataRelation("FK_sessione_sessionekind_idsessionekind",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{attivform.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_attivform_sede_idsede",cPar,cChild,false));

	cPar = new []{didproggrupp.Columns["iddidproggrupp"]};
	cChild = new []{attivform.Columns["iddidproggrupp"]};
	Relations.Add(new DataRelation("FK_attivform_didproggrupp_iddidproggrupp",cPar,cChild,false));

	cPar = new []{didprogporzannodefaultview.Columns["iddidprogporzanno"]};
	cChild = new []{attivform.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivform_didprogporzannodefaultview_iddidprogporzanno",cPar,cChild,false));

	cPar = new []{didprogannodefaultview.Columns["iddidproganno"]};
	cChild = new []{didprogporzannodefaultview.Columns["iddidproganno"]};
	Relations.Add(new DataRelation("FK_didprogporzannodefaultview_didprogannodefaultview_iddidproganno",cPar,cChild,false));

	cPar = new []{didprogannodefaultview.Columns["iddidproganno"]};
	cChild = new []{attivform.Columns["iddidproganno"]};
	Relations.Add(new DataRelation("FK_attivform_didprogannodefaultview_iddidproganno",cPar,cChild,false));

	cPar = new []{didprogoridefaultview.Columns["iddidprogori"]};
	cChild = new []{didprogannodefaultview.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_didprogannodefaultview_didprogoridefaultview_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogoridefaultview.Columns["iddidprogori"]};
	cChild = new []{attivform.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_attivform_didprogoridefaultview_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{didprogoridefaultview.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_didprogoridefaultview_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{attivform.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_attivform_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{insegnintegdefaultview.Columns["idinsegninteg"]};
	cChild = new []{attivform.Columns["idinsegninteg"]};
	Relations.Add(new DataRelation("FK_attivform_insegnintegdefaultview_idinsegninteg",cPar,cChild,false));

	cPar = new []{insegndefaultview.Columns["idinsegn"]};
	cChild = new []{attivform.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_attivform_insegndefaultview_idinsegn",cPar,cChild,false));

	#endregion

}
}
}
