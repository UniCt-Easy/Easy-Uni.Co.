
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
[System.Xml.Serialization.XmlRoot("dsmeta_classescuolacaratteristica_classe"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_classescuolacaratteristica_classe: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppodefaultview 		=> (MetaTable)Tables["sasdgruppodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadiscdefaultview 		=> (MetaTable)Tables["ambitoareadiscdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform_alias1 		=> (MetaTable)Tables["tipoattform_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classescuolacaratteristica 		=> (MetaTable)Tables["classescuolacaratteristica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_classescuolacaratteristica_classe(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_classescuolacaratteristica_classe (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_classescuolacaratteristica_classe";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_classescuolacaratteristica_classe.xsd";

	#region create DataTables
	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idareadidattica", typeof(int));
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
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
	Tables.Add(tclassescuolacaratteristica);
	tclassescuolacaratteristica.defineKey("idclassescuolacaratteristica");

	#endregion


	#region DataRelation creation
	var cPar = new []{sasddefaultview.Columns["idsasd"]};
	var cChild = new []{classescuolacaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_sasddefaultview_idsasd",cPar,cChild,false));

	cPar = new []{sasdgruppodefaultview.Columns["idsasdgruppo"]};
	cChild = new []{classescuolacaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_sasdgruppodefaultview_idsasdgruppo",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{sasdgruppodefaultview.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_sasdgruppodefaultview_tipoattform_idtipoattform",cPar,cChild,false));

	cPar = new []{ambitoareadiscdefaultview.Columns["idambitoareadisc"]};
	cChild = new []{classescuolacaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_ambitoareadiscdefaultview_idambitoareadisc",cPar,cChild,false));

	cPar = new []{tipoattform_alias1.Columns["idtipoattform"]};
	cChild = new []{classescuolacaratteristica.Columns["idtipoattform_2"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_tipoattform_alias1_idtipoattform_2",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{classescuolacaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_classescuolacaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	#endregion

}
}
}
