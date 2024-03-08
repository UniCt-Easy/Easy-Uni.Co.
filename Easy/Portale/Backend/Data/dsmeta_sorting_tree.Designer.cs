
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
[System.Xml.Serialization.XmlRoot("dsmeta_sorting_tree"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_sorting_tree: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortinglevel 		=> (MetaTable)Tables["sortinglevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting 		=> (MetaTable)Tables["sorting"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_sorting_tree(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_sorting_tree (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_sorting_tree";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_sorting_tree.xsd";

	#region create DataTables
	//////////////////// SORTINGLEVEL /////////////////////////////////
	var tsortinglevel= new MetaTable("sortinglevel");
	tsortinglevel.defineColumn("nlevel", typeof(byte),false);
	tsortinglevel.defineColumn("idsorkind", typeof(int),false);
	tsortinglevel.defineColumn("description", typeof(string),false);
	tsortinglevel.defineColumn("flag", typeof(short),false);
	tsortinglevel.defineColumn("cu", typeof(string),false);
	tsortinglevel.defineColumn("ct", typeof(DateTime),false);
	tsortinglevel.defineColumn("lu", typeof(string),false);
	tsortinglevel.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tsortinglevel);
	tsortinglevel.defineKey("nlevel", "idsorkind");

	//////////////////// SORTING /////////////////////////////////
	var tsorting= new MetaTable("sorting");
	tsorting.defineColumn("idsorkind", typeof(int),false);
	tsorting.defineColumn("idsor", typeof(int),false);
	tsorting.defineColumn("sortcode", typeof(string),false);
	tsorting.defineColumn("paridsor", typeof(int));
	tsorting.defineColumn("nlevel", typeof(byte),false);
	tsorting.defineColumn("description", typeof(string),false);
	tsorting.defineColumn("txt", typeof(string));
	tsorting.defineColumn("rtf", typeof(Byte[]));
	tsorting.defineColumn("cu", typeof(string),false);
	tsorting.defineColumn("ct", typeof(DateTime),false);
	tsorting.defineColumn("lu", typeof(string),false);
	tsorting.defineColumn("lt", typeof(DateTime),false);
	tsorting.defineColumn("defaultn1", typeof(decimal));
	tsorting.defineColumn("defaultn2", typeof(decimal));
	tsorting.defineColumn("defaultn3", typeof(decimal));
	tsorting.defineColumn("defaultn4", typeof(decimal));
	tsorting.defineColumn("defaultn5", typeof(decimal));
	tsorting.defineColumn("defaults1", typeof(string));
	tsorting.defineColumn("defaults2", typeof(string));
	tsorting.defineColumn("defaults3", typeof(string));
	tsorting.defineColumn("defaults4", typeof(string));
	tsorting.defineColumn("defaults5", typeof(string));
	tsorting.defineColumn("flagnodate", typeof(string));
	tsorting.defineColumn("start", typeof(short));
	tsorting.defineColumn("stop", typeof(short));
	tsorting.defineColumn("idsor01", typeof(int));
	tsorting.defineColumn("idsor02", typeof(int));
	tsorting.defineColumn("idsor03", typeof(int));
	tsorting.defineColumn("idsor04", typeof(int));
	tsorting.defineColumn("idsor05", typeof(int));
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	#endregion


	#region DataRelation creation
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{sorting.Columns["paridsor"]};
	Relations.Add(new DataRelation("sortingsorting",cPar,cChild,false));

	cPar = new []{sortinglevel.Columns["nlevel"], sortinglevel.Columns["idsorkind"]};
	cChild = new []{sorting.Columns["nlevel"], sorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortinglevelsorting",cPar,cChild,false));

	#endregion

}
}
}
