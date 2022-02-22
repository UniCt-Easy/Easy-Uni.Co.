
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
[System.Xml.Serialization.XmlRoot("dsmeta_ambitoareadisc_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ambitoareadisc_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattformdefaultview 		=> (MetaTable)Tables["tipoattformdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classescuoladefaultview 		=> (MetaTable)Tables["classescuoladefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadisc 		=> (MetaTable)Tables["ambitoareadisc"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ambitoareadisc_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ambitoareadisc_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ambitoareadisc_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ambitoareadisc_default.xsd";

	#region create DataTables
	//////////////////// TIPOATTFORMDEFAULTVIEW /////////////////////////////////
	var ttipoattformdefaultview= new MetaTable("tipoattformdefaultview");
	ttipoattformdefaultview.defineColumn("dropdown_title", typeof(string),false);
	ttipoattformdefaultview.defineColumn("idtipoattform", typeof(int),false);
	Tables.Add(ttipoattformdefaultview);
	ttipoattformdefaultview.defineKey("idtipoattform");

	//////////////////// CLASSESCUOLADEFAULTVIEW /////////////////////////////////
	var tclassescuoladefaultview= new MetaTable("classescuoladefaultview");
	tclassescuoladefaultview.defineColumn("dropdown_title", typeof(string),false);
	tclassescuoladefaultview.defineColumn("idclassescuola", typeof(int),false);
	tclassescuoladefaultview.defineColumn("idclassescuolaarea", typeof(int));
	tclassescuoladefaultview.defineColumn("idcorsostudionorma", typeof(int));
	Tables.Add(tclassescuoladefaultview);
	tclassescuoladefaultview.defineKey("idclassescuola");

	//////////////////// AMBITOAREADISC /////////////////////////////////
	var tambitoareadisc= new MetaTable("ambitoareadisc");
	tambitoareadisc.defineColumn("idambitoareadisc", typeof(int),false);
	tambitoareadisc.defineColumn("idclassescuola", typeof(int));
	tambitoareadisc.defineColumn("idtipoattform", typeof(int));
	tambitoareadisc.defineColumn("indicecineca", typeof(int));
	tambitoareadisc.defineColumn("lt", typeof(DateTime),false);
	tambitoareadisc.defineColumn("lu", typeof(string));
	tambitoareadisc.defineColumn("sortcode", typeof(int));
	tambitoareadisc.defineColumn("title", typeof(string),false);
	Tables.Add(tambitoareadisc);
	tambitoareadisc.defineKey("idambitoareadisc");

	#endregion


	#region DataRelation creation
	var cPar = new []{tipoattformdefaultview.Columns["idtipoattform"]};
	var cChild = new []{ambitoareadisc.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_ambitoareadisc_tipoattformdefaultview_idtipoattform",cPar,cChild,false));

	cPar = new []{classescuoladefaultview.Columns["idclassescuola"]};
	cChild = new []{ambitoareadisc.Columns["idclassescuola"]};
	Relations.Add(new DataRelation("FK_ambitoareadisc_classescuoladefaultview_idclassescuola",cPar,cChild,false));

	#endregion

}
}
}
