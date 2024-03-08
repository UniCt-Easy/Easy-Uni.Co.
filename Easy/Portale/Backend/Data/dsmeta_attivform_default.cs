
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
[System.Xml.Serialization.XmlRoot("dsmeta_attivform_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_attivform_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale 		=> (MetaTable)Tables["canale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegninteg 		=> (MetaTable)Tables["insegninteg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegn 		=> (MetaTable)Tables["insegn"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzanno 		=> (MetaTable)Tables["didprogporzanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori 		=> (MetaTable)Tables["didprogori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproggrupp_alias1 		=> (MetaTable)Tables["didproggrupp_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr_alias1 		=> (MetaTable)Tables["didprogcurr_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproganno 		=> (MetaTable)Tables["didproganno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform_alias1 		=> (MetaTable)Tables["attivform_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformproped 		=> (MetaTable)Tables["attivformproped"];

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
public dsmeta_attivform_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_attivform_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_attivform_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_attivform_default.xsd";

	#region create DataTables
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
	tcanale.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tcanale);
	tcanale.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// INSEGNINTEG /////////////////////////////////
	var tinsegninteg= new MetaTable("insegninteg");
	tinsegninteg.defineColumn("codice", typeof(string));
	tinsegninteg.defineColumn("ct", typeof(DateTime),false);
	tinsegninteg.defineColumn("cu", typeof(string),false);
	tinsegninteg.defineColumn("denominazione", typeof(string));
	tinsegninteg.defineColumn("denominazione_en", typeof(string));
	tinsegninteg.defineColumn("idinsegn", typeof(int),false);
	tinsegninteg.defineColumn("idinsegninteg", typeof(int),false);
	tinsegninteg.defineColumn("lt", typeof(DateTime),false);
	tinsegninteg.defineColumn("lu", typeof(string),false);
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

	//////////////////// DIDPROGGRUPP_ALIAS1 /////////////////////////////////
	var tdidproggrupp_alias1= new MetaTable("didproggrupp_alias1");
	tdidproggrupp_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdidproggrupp_alias1.defineColumn("iddidprog", typeof(int),false);
	tdidproggrupp_alias1.defineColumn("iddidproggrupp", typeof(int),false);
	tdidproggrupp_alias1.defineColumn("title", typeof(string));
	tdidproggrupp_alias1.ExtendedProperties["TableForReading"]="didproggrupp";
	Tables.Add(tdidproggrupp_alias1);
	tdidproggrupp_alias1.defineKey("idcorsostudio", "iddidprog", "iddidproggrupp");

	//////////////////// DIDPROGCURR_ALIAS1 /////////////////////////////////
	var tdidprogcurr_alias1= new MetaTable("didprogcurr_alias1");
	tdidprogcurr_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("title", typeof(string));
	tdidprogcurr_alias1.ExtendedProperties["TableForReading"]="didprogcurr";
	Tables.Add(tdidprogcurr_alias1);
	tdidprogcurr_alias1.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// DIDPROGANNO /////////////////////////////////
	var tdidproganno= new MetaTable("didproganno");
	tdidproganno.defineColumn("aa", typeof(string),false);
	tdidproganno.defineColumn("idcorsostudio", typeof(int),false);
	tdidproganno.defineColumn("iddidprog", typeof(int),false);
	tdidproganno.defineColumn("iddidproganno", typeof(int),false);
	tdidproganno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidproganno.defineColumn("iddidprogori", typeof(int),false);
	tdidproganno.defineColumn("title", typeof(string));
	Tables.Add(tdidproganno);
	tdidproganno.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori");

	//////////////////// ATTIVFORM_ALIAS1 /////////////////////////////////
	var tattivform_alias1= new MetaTable("attivform_alias1");
	tattivform_alias1.defineColumn("aa", typeof(string),false);
	tattivform_alias1.defineColumn("ct", typeof(DateTime),false);
	tattivform_alias1.defineColumn("cu", typeof(string),false);
	tattivform_alias1.defineColumn("idattivform", typeof(int),false);
	tattivform_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprog", typeof(int),false);
	tattivform_alias1.defineColumn("iddidproganno", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tattivform_alias1.defineColumn("iddidproggrupp", typeof(int));
	tattivform_alias1.defineColumn("iddidprogori", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivform_alias1.defineColumn("idinsegn", typeof(int),false);
	tattivform_alias1.defineColumn("idinsegninteg", typeof(int));
	tattivform_alias1.defineColumn("idsede", typeof(int),false);
	tattivform_alias1.defineColumn("lt", typeof(DateTime),false);
	tattivform_alias1.defineColumn("lu", typeof(string),false);
	tattivform_alias1.defineColumn("obbform", typeof(string));
	tattivform_alias1.defineColumn("obbform_en", typeof(string));
	tattivform_alias1.defineColumn("sortcode", typeof(int));
	tattivform_alias1.defineColumn("start", typeof(DateTime));
	tattivform_alias1.defineColumn("stop", typeof(DateTime));
	tattivform_alias1.defineColumn("tipovalutaz", typeof(string));
	tattivform_alias1.defineColumn("title", typeof(string));
	tattivform_alias1.ExtendedProperties["TableForReading"]="attivform";
	Tables.Add(tattivform_alias1);
	tattivform_alias1.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// ATTIVFORMPROPED /////////////////////////////////
	var tattivformproped= new MetaTable("attivformproped");
	tattivformproped.defineColumn("aa", typeof(string),false);
	tattivformproped.defineColumn("alternativa", typeof(int),false);
	tattivformproped.defineColumn("ct", typeof(DateTime),false);
	tattivformproped.defineColumn("cu", typeof(string),false);
	tattivformproped.defineColumn("idattivform", typeof(int),false);
	tattivformproped.defineColumn("idattivform_proped", typeof(int),false);
	tattivformproped.defineColumn("idcorsostudio", typeof(int),false);
	tattivformproped.defineColumn("iddidprog", typeof(int),false);
	tattivformproped.defineColumn("iddidproganno", typeof(int),false);
	tattivformproped.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformproped.defineColumn("iddidprogori", typeof(int),false);
	tattivformproped.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformproped.defineColumn("lt", typeof(DateTime),false);
	tattivformproped.defineColumn("lu", typeof(string),false);
	tattivformproped.defineColumn("!idattivform_proped_didprogcurr_alias1_title", typeof(string));
	tattivformproped.defineColumn("!idattivform_proped_didprogori_title", typeof(string));
	tattivformproped.defineColumn("!idattivform_proped_didproganno_title", typeof(string));
	tattivformproped.defineColumn("!idattivform_proped_didprogporzanno_title", typeof(string));
	tattivformproped.defineColumn("!idattivform_proped_didproggrupp_alias1_title", typeof(string));
	tattivformproped.defineColumn("!idattivform_proped_insegn_denominazione", typeof(string));
	tattivformproped.defineColumn("!idattivform_proped_insegn_codice", typeof(string));
	tattivformproped.defineColumn("!idattivform_proped_insegninteg_denominazione", typeof(string));
	tattivformproped.defineColumn("!idattivform_proped_insegninteg_codice", typeof(string));
	tattivformproped.defineColumn("!idattivform_proped_attivform_alias1_start", typeof(DateTime));
	tattivformproped.defineColumn("!idattivform_proped_attivform_alias1_stop", typeof(DateTime));
	tattivformproped.defineColumn("!idattivform_proped_attivform_alias1_tipovalutaz", typeof(string));
	tattivformproped.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tattivformproped);
	tattivformproped.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

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
	tdidprogannodefaultview.defineColumn("didproganno_anno", typeof(int));
	tdidprogannodefaultview.defineColumn("didproganno_cf", typeof(decimal));
	tdidprogannodefaultview.defineColumn("didproganno_ct", typeof(DateTime),false);
	tdidprogannodefaultview.defineColumn("didproganno_cu", typeof(string),false);
	tdidprogannodefaultview.defineColumn("didproganno_lt", typeof(DateTime),false);
	tdidprogannodefaultview.defineColumn("didproganno_lu", typeof(string),false);
	tdidprogannodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogannodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidproganno", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprogori", typeof(int),false);
	tdidprogannodefaultview.defineColumn("title", typeof(string));
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
	tinsegndefaultview.defineColumn("corsostudio_annoistituz", typeof(int));
	tinsegndefaultview.defineColumn("corsostudio_title", typeof(string));
	tinsegndefaultview.defineColumn("corsostudiokind_title", typeof(string));
	tinsegndefaultview.defineColumn("denominazione", typeof(string));
	tinsegndefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinsegndefaultview.defineColumn("idcorsostudio", typeof(int));
	tinsegndefaultview.defineColumn("idinsegn", typeof(int),false);
	tinsegndefaultview.defineColumn("idstruttura", typeof(int));
	tinsegndefaultview.defineColumn("insegn_codice", typeof(string));
	tinsegndefaultview.defineColumn("insegn_ct", typeof(DateTime),false);
	tinsegndefaultview.defineColumn("insegn_cu", typeof(string),false);
	tinsegndefaultview.defineColumn("insegn_denominazione_en", typeof(string));
	tinsegndefaultview.defineColumn("insegn_idcorsostudiokind", typeof(int));
	tinsegndefaultview.defineColumn("insegn_lt", typeof(DateTime),false);
	tinsegndefaultview.defineColumn("insegn_lu", typeof(string),false);
	tinsegndefaultview.defineColumn("struttura_idstrutturakind", typeof(int));
	tinsegndefaultview.defineColumn("struttura_title", typeof(string));
	tinsegndefaultview.defineColumn("strutturakind_title", typeof(string));
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
	var cPar = new []{attivform.Columns["aa"], attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogporzanno"], attivform.Columns["idsede"]};
	var cChild = new []{canale.Columns["aa"], canale.Columns["idattivform"], canale.Columns["idcorsostudio"], canale.Columns["iddidprog"], canale.Columns["iddidproganno"], canale.Columns["iddidprogcurr"], canale.Columns["iddidprogori"], canale.Columns["iddidprogporzanno"], canale.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_canale_attivform_aa-idattivform-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idsede",cPar,cChild,false));

	cPar = new []{attivform.Columns["aa"], attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogporzanno"]};
	cChild = new []{attivformproped.Columns["aa"], attivformproped.Columns["idattivform"], attivformproped.Columns["idcorsostudio"], attivformproped.Columns["iddidprog"], attivformproped.Columns["iddidproganno"], attivformproped.Columns["iddidprogcurr"], attivformproped.Columns["iddidprogori"], attivformproped.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformproped_attivform_aa-idattivform-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{attivform_alias1.Columns["idattivform"]};
	cChild = new []{attivformproped.Columns["idattivform_proped"]};
	Relations.Add(new DataRelation("FK_attivformproped_attivform_alias1_idattivform_proped",cPar,cChild,false));

	cPar = new []{insegninteg.Columns["idinsegninteg"]};
	cChild = new []{attivform_alias1.Columns["idinsegninteg"]};
	Relations.Add(new DataRelation("FK_attivform_alias1_insegninteg_idinsegninteg",cPar,cChild,false));

	cPar = new []{insegn.Columns["idinsegn"]};
	cChild = new []{attivform_alias1.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_attivform_alias1_insegn_idinsegn",cPar,cChild,false));

	cPar = new []{didprogporzanno.Columns["iddidprogporzanno"]};
	cChild = new []{attivform_alias1.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivform_alias1_didprogporzanno_iddidprogporzanno",cPar,cChild,false));

	cPar = new []{didprogori.Columns["iddidprogori"]};
	cChild = new []{attivform_alias1.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_attivform_alias1_didprogori_iddidprogori",cPar,cChild,false));

	cPar = new []{didproggrupp_alias1.Columns["iddidproggrupp"]};
	cChild = new []{attivform_alias1.Columns["iddidproggrupp"]};
	Relations.Add(new DataRelation("FK_attivform_alias1_didproggrupp_alias1_iddidproggrupp",cPar,cChild,false));

	cPar = new []{didprogcurr_alias1.Columns["iddidprogcurr"]};
	cChild = new []{attivform_alias1.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_attivform_alias1_didprogcurr_alias1_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didproganno.Columns["iddidproganno"]};
	cChild = new []{attivform_alias1.Columns["iddidproganno"]};
	Relations.Add(new DataRelation("FK_attivform_alias1_didproganno_iddidproganno",cPar,cChild,false));

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
