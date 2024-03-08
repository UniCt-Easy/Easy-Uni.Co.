
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
[System.Xml.Serialization.XmlRoot("dsmeta_affidamentocaratteristica_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_affidamentocaratteristica_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable orakind 		=> (MetaTable)Tables["orakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristicaora 		=> (MetaTable)Tables["affidamentocaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppodefaultview 		=> (MetaTable)Tables["sasdgruppodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadiscdefaultview 		=> (MetaTable)Tables["ambitoareadiscdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattformdefaultview 		=> (MetaTable)Tables["tipoattformdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristica 		=> (MetaTable)Tables["affidamentocaratteristica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_affidamentocaratteristica_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_affidamentocaratteristica_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_affidamentocaratteristica_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_affidamentocaratteristica_seg.xsd";

	#region create DataTables
	//////////////////// ORAKIND /////////////////////////////////
	var torakind= new MetaTable("orakind");
	torakind.defineColumn("active", typeof(string));
	torakind.defineColumn("idorakind", typeof(int),false);
	torakind.defineColumn("title", typeof(string));
	Tables.Add(torakind);
	torakind.defineKey("idorakind");

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
	taffidamentocaratteristicaora.defineColumn("!idorakind_orakind_title", typeof(string));
	Tables.Add(taffidamentocaratteristicaora);
	taffidamentocaratteristicaora.defineKey("aa", "idaffidamento", "idaffidamentocaratteristica", "idaffidamentocaratteristicaora", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

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
	tambitoareadiscdefaultview.defineColumn("ambitoareadisc_idtipoattform", typeof(int));
	tambitoareadiscdefaultview.defineColumn("ambitoareadisc_indicecineca", typeof(int));
	tambitoareadiscdefaultview.defineColumn("ambitoareadisc_lt", typeof(DateTime),false);
	tambitoareadiscdefaultview.defineColumn("ambitoareadisc_lu", typeof(string));
	tambitoareadiscdefaultview.defineColumn("ambitoareadisc_sortcode", typeof(int));
	tambitoareadiscdefaultview.defineColumn("classescuola_sigla", typeof(string));
	tambitoareadiscdefaultview.defineColumn("classescuola_title", typeof(string));
	tambitoareadiscdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tambitoareadiscdefaultview.defineColumn("idambitoareadisc", typeof(int),false);
	tambitoareadiscdefaultview.defineColumn("idclassescuola", typeof(int));
	tambitoareadiscdefaultview.defineColumn("tipoattform_description", typeof(string));
	tambitoareadiscdefaultview.defineColumn("tipoattform_title", typeof(string));
	tambitoareadiscdefaultview.defineColumn("title", typeof(string),false);
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

	#endregion


	#region DataRelation creation
	var cPar = new []{affidamentocaratteristica.Columns["aa"], affidamentocaratteristica.Columns["idaffidamento"], affidamentocaratteristica.Columns["idaffidamentocaratteristica"], affidamentocaratteristica.Columns["idattivform"], affidamentocaratteristica.Columns["idcanale"], affidamentocaratteristica.Columns["idcorsostudio"], affidamentocaratteristica.Columns["iddidprog"], affidamentocaratteristica.Columns["iddidproganno"], affidamentocaratteristica.Columns["iddidprogcurr"], affidamentocaratteristica.Columns["iddidprogori"], affidamentocaratteristica.Columns["iddidprogporzanno"]};
	var cChild = new []{affidamentocaratteristicaora.Columns["aa"], affidamentocaratteristicaora.Columns["idaffidamento"], affidamentocaratteristicaora.Columns["idaffidamentocaratteristica"], affidamentocaratteristicaora.Columns["idattivform"], affidamentocaratteristicaora.Columns["idcanale"], affidamentocaratteristicaora.Columns["idcorsostudio"], affidamentocaratteristicaora.Columns["iddidprog"], affidamentocaratteristicaora.Columns["iddidproganno"], affidamentocaratteristicaora.Columns["iddidprogcurr"], affidamentocaratteristicaora.Columns["iddidprogori"], affidamentocaratteristicaora.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristicaora_affidamentocaratteristica_aa-idaffidamento-idaffidamentocaratteristica-idattivform-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{orakind.Columns["idorakind"]};
	cChild = new []{affidamentocaratteristicaora.Columns["idorakind"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristicaora_orakind_idorakind",cPar,cChild,false));

	cPar = new []{sasddefaultview.Columns["idsasd"]};
	cChild = new []{affidamentocaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_sasddefaultview_idsasd",cPar,cChild,false));

	cPar = new []{sasdgruppodefaultview.Columns["idsasdgruppo"]};
	cChild = new []{affidamentocaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_sasdgruppodefaultview_idsasdgruppo",cPar,cChild,false));

	cPar = new []{tipoattformdefaultview.Columns["idtipoattform"]};
	cChild = new []{sasdgruppodefaultview.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_sasdgruppodefaultview_tipoattformdefaultview_idtipoattform",cPar,cChild,false));

	cPar = new []{ambitoareadiscdefaultview.Columns["idambitoareadisc"]};
	cChild = new []{affidamentocaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_ambitoareadiscdefaultview_idambitoareadisc",cPar,cChild,false));

	cPar = new []{tipoattformdefaultview.Columns["idtipoattform"]};
	cChild = new []{affidamentocaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_affidamentocaratteristica_tipoattformdefaultview_idtipoattform",cPar,cChild,false));

	#endregion

}
}
}
