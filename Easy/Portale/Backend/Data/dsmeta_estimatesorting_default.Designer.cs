
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
[System.Xml.Serialization.XmlRoot("dsmeta_estimatesorting_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_estimatesorting_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingapplicabilityview 		=> (MetaTable)Tables["sortingapplicabilityview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting 		=> (MetaTable)Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimatesorting 		=> (MetaTable)Tables["estimatesorting"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_estimatesorting_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_estimatesorting_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_estimatesorting_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_estimatesorting_default.xsd";

	#region create DataTables
	//////////////////// SORTINGAPPLICABILITYVIEW /////////////////////////////////
	var tsortingapplicabilityview= new MetaTable("sortingapplicabilityview");
	tsortingapplicabilityview.defineColumn("idsorkind", typeof(int),false);
	tsortingapplicabilityview.defineColumn("description", typeof(string),false);
	tsortingapplicabilityview.defineColumn("nphaseincome", typeof(byte));
	tsortingapplicabilityview.defineColumn("incomephase", typeof(string));
	tsortingapplicabilityview.defineColumn("nphaseexpense", typeof(byte));
	tsortingapplicabilityview.defineColumn("expensephase", typeof(string));
	tsortingapplicabilityview.defineColumn("flagcheckavailability", typeof(string),false);
	tsortingapplicabilityview.defineColumn("flagforced", typeof(string),false);
	tsortingapplicabilityview.defineColumn("cu", typeof(string),false);
	tsortingapplicabilityview.defineColumn("ct", typeof(DateTime),false);
	tsortingapplicabilityview.defineColumn("lu", typeof(string),false);
	tsortingapplicabilityview.defineColumn("lt", typeof(DateTime),false);
	tsortingapplicabilityview.defineColumn("tablename", typeof(string),false);
	tsortingapplicabilityview.defineColumn("active", typeof(string));
	tsortingapplicabilityview.defineColumn("start", typeof(short));
	tsortingapplicabilityview.defineColumn("stop", typeof(short));
	Tables.Add(tsortingapplicabilityview);
	tsortingapplicabilityview.defineKey("idsorkind");

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
	tsorting.defineColumn("movkind", typeof(string));
	tsorting.defineColumn("printingorder", typeof(string));
	tsorting.defineColumn("defaultv1", typeof(decimal));
	tsorting.defineColumn("defaultv2", typeof(decimal));
	tsorting.defineColumn("defaultv3", typeof(decimal));
	tsorting.defineColumn("defaultv4", typeof(decimal));
	tsorting.defineColumn("defaultv5", typeof(decimal));
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	//////////////////// ESTIMATESORTING /////////////////////////////////
	var testimatesorting= new MetaTable("estimatesorting");
	testimatesorting.defineColumn("idsor", typeof(int),false);
	testimatesorting.defineColumn("idestimkind", typeof(string),false);
	testimatesorting.defineColumn("yestim", typeof(short),false);
	testimatesorting.defineColumn("nestim", typeof(int),false);
	testimatesorting.defineColumn("ct", typeof(DateTime),false);
	testimatesorting.defineColumn("cu", typeof(string),false);
	testimatesorting.defineColumn("lt", typeof(DateTime),false);
	testimatesorting.defineColumn("lu", typeof(string),false);
	testimatesorting.defineColumn("quota", typeof(double));
	Tables.Add(testimatesorting);
	testimatesorting.defineKey("idestimkind", "idsor", "nestim", "yestim");

	#endregion


	#region DataRelation creation
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{estimatesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingestimatesorting",cPar,cChild,false));

	#endregion

}
}
}
