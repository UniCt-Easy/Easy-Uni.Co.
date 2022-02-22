
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
[System.Xml.Serialization.XmlRoot("dsmeta_insegnintegcaratteristica_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_insegnintegcaratteristica_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdintegrandiview 		=> (MetaTable)Tables["sasdintegrandiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegnintegcaratteristica 		=> (MetaTable)Tables["insegnintegcaratteristica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_insegnintegcaratteristica_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_insegnintegcaratteristica_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_insegnintegcaratteristica_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_insegnintegcaratteristica_default.xsd";

	#region create DataTables
	//////////////////// SASDINTEGRANDIVIEW /////////////////////////////////
	var tsasdintegrandiview= new MetaTable("sasdintegrandiview");
	tsasdintegrandiview.defineColumn("dropdown_title", typeof(string),false);
	tsasdintegrandiview.defineColumn("idareadidattica", typeof(int));
	tsasdintegrandiview.defineColumn("idsasd", typeof(int),false);
	Tables.Add(tsasdintegrandiview);
	tsasdintegrandiview.defineKey("idsasd");

	//////////////////// INSEGNINTEGCARATTERISTICA /////////////////////////////////
	var tinsegnintegcaratteristica= new MetaTable("insegnintegcaratteristica");
	tinsegnintegcaratteristica.defineColumn("cf", typeof(decimal));
	tinsegnintegcaratteristica.defineColumn("ct", typeof(DateTime),false);
	tinsegnintegcaratteristica.defineColumn("cu", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("idinsegn", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idinsegninteg", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idinsegnintegcaratteristica", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idsasd", typeof(int));
	tinsegnintegcaratteristica.defineColumn("lt", typeof(DateTime),false);
	tinsegnintegcaratteristica.defineColumn("lu", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("profess", typeof(string),false);
	Tables.Add(tinsegnintegcaratteristica);
	tinsegnintegcaratteristica.defineKey("idinsegn", "idinsegninteg", "idinsegnintegcaratteristica");

	#endregion


	#region DataRelation creation
	var cPar = new []{sasdintegrandiview.Columns["idsasd"]};
	var cChild = new []{insegnintegcaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_insegnintegcaratteristica_sasdintegrandiview_idsasd",cPar,cChild,false));

	#endregion

}
}
}
