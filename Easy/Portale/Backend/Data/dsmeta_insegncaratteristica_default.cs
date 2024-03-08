
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
[System.Xml.Serialization.XmlRoot("dsmeta_insegncaratteristica_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_insegncaratteristica_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegncaratteristica 		=> (MetaTable)Tables["insegncaratteristica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_insegncaratteristica_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_insegncaratteristica_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_insegncaratteristica_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_insegncaratteristica_default.xsd";

	#region create DataTables
	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idareadidattica", typeof(int));
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
	Tables.Add(tsasddefaultview);
	tsasddefaultview.defineKey("idsasd");

	//////////////////// INSEGNCARATTERISTICA /////////////////////////////////
	var tinsegncaratteristica= new MetaTable("insegncaratteristica");
	tinsegncaratteristica.defineColumn("cf", typeof(decimal));
	tinsegncaratteristica.defineColumn("ct", typeof(DateTime),false);
	tinsegncaratteristica.defineColumn("cu", typeof(string),false);
	tinsegncaratteristica.defineColumn("idinsegn", typeof(int),false);
	tinsegncaratteristica.defineColumn("idinsegncaratteristica", typeof(int),false);
	tinsegncaratteristica.defineColumn("idsasd", typeof(int));
	tinsegncaratteristica.defineColumn("lt", typeof(DateTime),false);
	tinsegncaratteristica.defineColumn("lu", typeof(string),false);
	tinsegncaratteristica.defineColumn("profess", typeof(string),false);
	Tables.Add(tinsegncaratteristica);
	tinsegncaratteristica.defineKey("idinsegn", "idinsegncaratteristica");

	#endregion


	#region DataRelation creation
	var cPar = new []{sasddefaultview.Columns["idsasd"]};
	var cChild = new []{insegncaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_insegncaratteristica_sasddefaultview_idsasd",cPar,cChild,false));

	#endregion

}
}
}
