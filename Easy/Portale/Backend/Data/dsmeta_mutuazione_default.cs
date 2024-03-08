
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
[System.Xml.Serialization.XmlRoot("dsmeta_mutuazione_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_mutuazione_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazionecaratteristicaora 		=> (MetaTable)Tables["mutuazionecaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppo 		=> (MetaTable)Tables["sasdgruppo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadisc 		=> (MetaTable)Tables["ambitoareadisc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazionecaratteristica 		=> (MetaTable)Tables["mutuazionecaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale 		=> (MetaTable)Tables["canale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale_alias1 		=> (MetaTable)Tables["canale_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazione 		=> (MetaTable)Tables["mutuazione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_mutuazione_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_mutuazione_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_mutuazione_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_mutuazione_default.xsd";

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
	tmutuazionecaratteristica.defineColumn("!idambitoareadisc_ambitoareadisc_title", typeof(string));
	tmutuazionecaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	tmutuazionecaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	tmutuazionecaratteristica.defineColumn("!idsasdgruppo_sasdgruppo_title", typeof(string));
	tmutuazionecaratteristica.defineColumn("!idtipoattform_tipoattform_title", typeof(string));
	tmutuazionecaratteristica.defineColumn("!idtipoattform_tipoattform_description", typeof(string));
	Tables.Add(tmutuazionecaratteristica);
	tmutuazionecaratteristica.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idmutuazione", "idmutuazionecaratteristica");

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
	Tables.Add(tmutuazione);
	tmutuazione.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idmutuazione");

	#endregion


	#region DataRelation creation
	var cPar = new []{mutuazione.Columns["aa"], mutuazione.Columns["idattivform"], mutuazione.Columns["idcanale"], mutuazione.Columns["idcorsostudio"], mutuazione.Columns["iddidprog"], mutuazione.Columns["iddidproganno"], mutuazione.Columns["iddidprogcurr"], mutuazione.Columns["iddidprogori"], mutuazione.Columns["iddidprogporzanno"], mutuazione.Columns["idmutuazione"]};
	var cChild = new []{mutuazionecaratteristica.Columns["aa"], mutuazionecaratteristica.Columns["idattivform"], mutuazionecaratteristica.Columns["idcanale"], mutuazionecaratteristica.Columns["idcorsostudio"], mutuazionecaratteristica.Columns["iddidprog"], mutuazionecaratteristica.Columns["iddidproganno"], mutuazionecaratteristica.Columns["iddidprogcurr"], mutuazionecaratteristica.Columns["iddidprogori"], mutuazionecaratteristica.Columns["iddidprogporzanno"], mutuazionecaratteristica.Columns["idmutuazione"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_mutuazione_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idmutuazione",cPar,cChild,false));

	cPar = new []{mutuazionecaratteristica.Columns["aa"], mutuazionecaratteristica.Columns["idattivform"], mutuazionecaratteristica.Columns["idcanale"], mutuazionecaratteristica.Columns["idcorsostudio"], mutuazionecaratteristica.Columns["iddidprog"], mutuazionecaratteristica.Columns["iddidproganno"], mutuazionecaratteristica.Columns["iddidprogcurr"], mutuazionecaratteristica.Columns["iddidprogori"], mutuazionecaratteristica.Columns["iddidprogporzanno"], mutuazionecaratteristica.Columns["idmutuazione"], mutuazionecaratteristica.Columns["idmutuazionecaratteristica"]};
	cChild = new []{mutuazionecaratteristicaora.Columns["aa"], mutuazionecaratteristicaora.Columns["idattivform"], mutuazionecaratteristicaora.Columns["idcanale"], mutuazionecaratteristicaora.Columns["idcorsostudio"], mutuazionecaratteristicaora.Columns["iddidprog"], mutuazionecaratteristicaora.Columns["iddidproganno"], mutuazionecaratteristicaora.Columns["iddidprogcurr"], mutuazionecaratteristicaora.Columns["iddidprogori"], mutuazionecaratteristicaora.Columns["iddidprogporzanno"], mutuazionecaratteristicaora.Columns["idmutuazione"], mutuazionecaratteristicaora.Columns["idmutuazionecaratteristica"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristicaora_mutuazionecaratteristica_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idmutuazione-idmutuazionecaratteristica",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{mutuazionecaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	cPar = new []{sasdgruppo.Columns["idsasdgruppo"]};
	cChild = new []{mutuazionecaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_sasdgruppo_idsasdgruppo",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{mutuazionecaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_sasd_idsasd",cPar,cChild,false));

	cPar = new []{ambitoareadisc.Columns["idambitoareadisc"]};
	cChild = new []{mutuazionecaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_ambitoareadisc_idambitoareadisc",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{mutuazione.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_mutuazione_sede_idsede",cPar,cChild,false));

	cPar = new []{canale.Columns["idcanale"]};
	cChild = new []{mutuazione.Columns["idcanale_from"]};
	Relations.Add(new DataRelation("FK_mutuazione_canale_idcanale_from",cPar,cChild,false));

	cPar = new []{canale_alias1.Columns["idcanale"]};
	cChild = new []{mutuazione.Columns["idcanale"]};
	Relations.Add(new DataRelation("FK_mutuazione_canale_alias1_idcanale",cPar,cChild,false));

	#endregion

}
}
}
