
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
[System.Xml.Serialization.XmlRoot("dsmeta_mutuazionecaratteristica_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_mutuazionecaratteristica_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable orakind 		=> (MetaTable)Tables["orakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazionecaratteristicaora 		=> (MetaTable)Tables["mutuazionecaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppodefaultview 		=> (MetaTable)Tables["sasdgruppodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadiscdefaultview 		=> (MetaTable)Tables["ambitoareadiscdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattformdefaultview 		=> (MetaTable)Tables["tipoattformdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazionecaratteristica 		=> (MetaTable)Tables["mutuazionecaratteristica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_mutuazionecaratteristica_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_mutuazionecaratteristica_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_mutuazionecaratteristica_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_mutuazionecaratteristica_default.xsd";

	#region create DataTables
	//////////////////// ORAKIND /////////////////////////////////
	var torakind= new MetaTable("orakind");
	torakind.defineColumn("active", typeof(string));
	torakind.defineColumn("idorakind", typeof(int),false);
	torakind.defineColumn("title", typeof(string));
	Tables.Add(torakind);
	torakind.defineKey("idorakind");

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
	tmutuazionecaratteristicaora.defineColumn("!idorakind_orakind_title", typeof(string));
	Tables.Add(tmutuazionecaratteristicaora);
	tmutuazionecaratteristicaora.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idmutuazione", "idmutuazionecaratteristica", "idmutuazionecaratteristicaora");

	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("areadidattica_title", typeof(string));
	tsasddefaultview.defineColumn("codice", typeof(string),false);
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idareadidattica", typeof(int));
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
	tsasddefaultview.defineColumn("sasd_codice_old", typeof(string));
	tsasddefaultview.defineColumn("sasd_lt", typeof(DateTime));
	tsasddefaultview.defineColumn("sasd_lu", typeof(string));
	tsasddefaultview.defineColumn("sasd_title", typeof(string),false);
	Tables.Add(tsasddefaultview);
	tsasddefaultview.defineKey("idsasd");

	//////////////////// SASDGRUPPODEFAULTVIEW /////////////////////////////////
	var tsasdgruppodefaultview= new MetaTable("sasdgruppodefaultview");
	tsasdgruppodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasdgruppodefaultview.defineColumn("idsasdgruppo", typeof(int),false);
	tsasdgruppodefaultview.defineColumn("idtipoattform", typeof(int),false);
	Tables.Add(tsasdgruppodefaultview);
	tsasdgruppodefaultview.defineKey("idsasdgruppo");

	//////////////////// AMBITOAREADISCDEFAULTVIEW /////////////////////////////////
	var tambitoareadiscdefaultview= new MetaTable("ambitoareadiscdefaultview");
	tambitoareadiscdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tambitoareadiscdefaultview.defineColumn("idambitoareadisc", typeof(int),false);
	tambitoareadiscdefaultview.defineColumn("idclassescuola", typeof(int));
	Tables.Add(tambitoareadiscdefaultview);
	tambitoareadiscdefaultview.defineKey("idambitoareadisc");

	//////////////////// TIPOATTFORMDEFAULTVIEW /////////////////////////////////
	var ttipoattformdefaultview= new MetaTable("tipoattformdefaultview");
	ttipoattformdefaultview.defineColumn("dropdown_title", typeof(string),false);
	ttipoattformdefaultview.defineColumn("idtipoattform", typeof(int),false);
	ttipoattformdefaultview.defineColumn("tipoattform_description", typeof(string));
	ttipoattformdefaultview.defineColumn("tipoattform_lt", typeof(DateTime),false);
	ttipoattformdefaultview.defineColumn("tipoattform_lu", typeof(string),false);
	ttipoattformdefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(ttipoattformdefaultview);
	ttipoattformdefaultview.defineKey("idtipoattform");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{mutuazionecaratteristica.Columns["aa"], mutuazionecaratteristica.Columns["idattivform"], mutuazionecaratteristica.Columns["idcanale"], mutuazionecaratteristica.Columns["idcorsostudio"], mutuazionecaratteristica.Columns["iddidprog"], mutuazionecaratteristica.Columns["iddidproganno"], mutuazionecaratteristica.Columns["iddidprogcurr"], mutuazionecaratteristica.Columns["iddidprogori"], mutuazionecaratteristica.Columns["iddidprogporzanno"], mutuazionecaratteristica.Columns["idmutuazione"], mutuazionecaratteristica.Columns["idmutuazionecaratteristica"]};
	var cChild = new []{mutuazionecaratteristicaora.Columns["aa"], mutuazionecaratteristicaora.Columns["idattivform"], mutuazionecaratteristicaora.Columns["idcanale"], mutuazionecaratteristicaora.Columns["idcorsostudio"], mutuazionecaratteristicaora.Columns["iddidprog"], mutuazionecaratteristicaora.Columns["iddidproganno"], mutuazionecaratteristicaora.Columns["iddidprogcurr"], mutuazionecaratteristicaora.Columns["iddidprogori"], mutuazionecaratteristicaora.Columns["iddidprogporzanno"], mutuazionecaratteristicaora.Columns["idmutuazione"], mutuazionecaratteristicaora.Columns["idmutuazionecaratteristica"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristicaora_mutuazionecaratteristica_aa-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idmutuazione-idmutuazionecaratteristica",cPar,cChild,false));

	cPar = new []{orakind.Columns["idorakind"]};
	cChild = new []{mutuazionecaratteristicaora.Columns["idorakind"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristicaora_orakind_idorakind",cPar,cChild,false));

	cPar = new []{sasddefaultview.Columns["idsasd"]};
	cChild = new []{mutuazionecaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_sasddefaultview_idsasd",cPar,cChild,false));

	cPar = new []{sasdgruppodefaultview.Columns["idsasdgruppo"]};
	cChild = new []{mutuazionecaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_sasdgruppodefaultview_idsasdgruppo",cPar,cChild,false));

	cPar = new []{tipoattformdefaultview.Columns["idtipoattform"]};
	cChild = new []{sasdgruppodefaultview.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_sasdgruppodefaultview_tipoattformdefaultview_idtipoattform",cPar,cChild,false));

	cPar = new []{ambitoareadiscdefaultview.Columns["idambitoareadisc"]};
	cChild = new []{mutuazionecaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_ambitoareadiscdefaultview_idambitoareadisc",cPar,cChild,false));

	cPar = new []{tipoattformdefaultview.Columns["idtipoattform"]};
	cChild = new []{mutuazionecaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristica_tipoattformdefaultview_idtipoattform",cPar,cChild,false));

	#endregion

}
}
}
