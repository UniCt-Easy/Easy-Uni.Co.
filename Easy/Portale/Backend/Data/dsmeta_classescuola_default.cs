
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
[System.Xml.Serialization.XmlRoot("dsmeta_classescuola_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_classescuola_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform_alias1 		=> (MetaTable)Tables["tipoattform_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppo 		=> (MetaTable)Tables["sasdgruppo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadisc 		=> (MetaTable)Tables["ambitoareadisc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classescuolacaratteristica 		=> (MetaTable)Tables["classescuolacaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classescuolaarea 		=> (MetaTable)Tables["classescuolaarea"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classescuolakinddefaultview 		=> (MetaTable)Tables["classescuolakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudionormadefaultview 		=> (MetaTable)Tables["corsostudionormadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classescuola 		=> (MetaTable)Tables["classescuola"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_classescuola_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_classescuola_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_classescuola_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_classescuola_default.xsd";

	#region create DataTables
	//////////////////// TIPOATTFORM_ALIAS1 /////////////////////////////////
	var ttipoattform_alias1= new MetaTable("tipoattform_alias1");
	ttipoattform_alias1.defineColumn("idtipoattform", typeof(int),false);
	ttipoattform_alias1.defineColumn("title", typeof(string),false);
	ttipoattform_alias1.ExtendedProperties["TableForReading"]="tipoattform";
	Tables.Add(ttipoattform_alias1);
	ttipoattform_alias1.defineKey("idtipoattform");

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

	//////////////////// CLASSESCUOLACARATTERISTICA /////////////////////////////////
	var tclassescuolacaratteristica= new MetaTable("classescuolacaratteristica");
	tclassescuolacaratteristica.defineColumn("cf", typeof(decimal));
	tclassescuolacaratteristica.defineColumn("cfmax", typeof(decimal));
	tclassescuolacaratteristica.defineColumn("cfmin", typeof(decimal));
	tclassescuolacaratteristica.defineColumn("ct", typeof(DateTime),false);
	tclassescuolacaratteristica.defineColumn("cu", typeof(string),false);
	tclassescuolacaratteristica.defineColumn("idambitoareadisc", typeof(int));
	tclassescuolacaratteristica.defineColumn("idclassescuola", typeof(int),false);
	tclassescuolacaratteristica.defineColumn("idclassescuolacaratteristica", typeof(int),false);
	tclassescuolacaratteristica.defineColumn("idsasd", typeof(int));
	tclassescuolacaratteristica.defineColumn("idsasdgruppo", typeof(int));
	tclassescuolacaratteristica.defineColumn("idtipoattform", typeof(int));
	tclassescuolacaratteristica.defineColumn("idtipoattform_2", typeof(int));
	tclassescuolacaratteristica.defineColumn("lt", typeof(DateTime),false);
	tclassescuolacaratteristica.defineColumn("lu", typeof(string),false);
	tclassescuolacaratteristica.defineColumn("obblig", typeof(string),false);
	tclassescuolacaratteristica.defineColumn("profess", typeof(string),false);
	tclassescuolacaratteristica.defineColumn("!idambitoareadisc_ambitoareadisc_title", typeof(string));
	tclassescuolacaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	tclassescuolacaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	tclassescuolacaratteristica.defineColumn("!idsasdgruppo_sasdgruppo_title", typeof(string));
	tclassescuolacaratteristica.defineColumn("!idtipoattform_tipoattform_title", typeof(string));
	tclassescuolacaratteristica.defineColumn("!idtipoattform_2_tipoattform_title", typeof(string));
	tclassescuolacaratteristica.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tclassescuolacaratteristica);
	tclassescuolacaratteristica.defineKey("idclassescuolacaratteristica");

	//////////////////// CLASSESCUOLAAREA /////////////////////////////////
	var tclassescuolaarea= new MetaTable("classescuolaarea");
	tclassescuolaarea.defineColumn("idclassescuolaarea", typeof(int),false);
	tclassescuolaarea.defineColumn("title", typeof(string));
	Tables.Add(tclassescuolaarea);
	tclassescuolaarea.defineKey("idclassescuolaarea");

	//////////////////// CLASSESCUOLAKINDDEFAULTVIEW /////////////////////////////////
	var tclassescuolakinddefaultview= new MetaTable("classescuolakinddefaultview");
	tclassescuolakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tclassescuolakinddefaultview.defineColumn("idclassescuolakind", typeof(string),false);
	tclassescuolakinddefaultview.defineColumn("idcorsostudiolivello", typeof(int));
	Tables.Add(tclassescuolakinddefaultview);
	tclassescuolakinddefaultview.defineKey("idclassescuolakind");

	//////////////////// CORSOSTUDIONORMADEFAULTVIEW /////////////////////////////////
	var tcorsostudionormadefaultview= new MetaTable("corsostudionormadefaultview");
	tcorsostudionormadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudionormadefaultview.defineColumn("idcorsostudionorma", typeof(int),false);
	Tables.Add(tcorsostudionormadefaultview);
	tcorsostudionormadefaultview.defineKey("idcorsostudionorma");

	//////////////////// CLASSESCUOLA /////////////////////////////////
	var tclassescuola= new MetaTable("classescuola");
	tclassescuola.defineColumn("idclassescuola", typeof(int),false);
	tclassescuola.defineColumn("idclassescuolaarea", typeof(int));
	tclassescuola.defineColumn("idclassescuolakind", typeof(string));
	tclassescuola.defineColumn("idcorsostudionorma", typeof(int));
	tclassescuola.defineColumn("indicecineca", typeof(int));
	tclassescuola.defineColumn("lt", typeof(DateTime),false);
	tclassescuola.defineColumn("lu", typeof(string),false);
	tclassescuola.defineColumn("obbform", typeof(string));
	tclassescuola.defineColumn("prospocc", typeof(string));
	tclassescuola.defineColumn("sigla", typeof(string));
	tclassescuola.defineColumn("title", typeof(string),false);
	Tables.Add(tclassescuola);
	tclassescuola.defineKey("idclassescuola");

	#endregion


	#region DataRelation creation
	var cPar = new []{classescuola.Columns["idclassescuola"]};
	var cChild = new []{classescuolacaratteristica.Columns["idclassescuola"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_classescuola_idclassescuola",cPar,cChild,false));

	cPar = new []{tipoattform_alias1.Columns["idtipoattform"]};
	cChild = new []{classescuolacaratteristica.Columns["idtipoattform_2"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_tipoattform_alias1_idtipoattform_2",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{classescuolacaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	cPar = new []{sasdgruppo.Columns["idsasdgruppo"]};
	cChild = new []{classescuolacaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_sasdgruppo_idsasdgruppo",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{classescuolacaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_sasd_idsasd",cPar,cChild,false));

	cPar = new []{ambitoareadisc.Columns["idambitoareadisc"]};
	cChild = new []{classescuolacaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_ambitoareadisc_idambitoareadisc",cPar,cChild,false));

	cPar = new []{classescuolaarea.Columns["idclassescuolaarea"]};
	cChild = new []{classescuola.Columns["idclassescuolaarea"]};
	Relations.Add(new DataRelation("FK_classescuola_classescuolaarea_idclassescuolaarea",cPar,cChild,false));

	cPar = new []{classescuolakinddefaultview.Columns["idclassescuolakind"]};
	cChild = new []{classescuola.Columns["idclassescuolakind"]};
	Relations.Add(new DataRelation("FK_classescuola_classescuolakinddefaultview_idclassescuolakind",cPar,cChild,false));

	cPar = new []{corsostudionormadefaultview.Columns["idcorsostudionorma"]};
	cChild = new []{classescuola.Columns["idcorsostudionorma"]};
	Relations.Add(new DataRelation("FK_classescuola_corsostudionormadefaultview_idcorsostudionorma",cPar,cChild,false));

	#endregion

}
}
}
