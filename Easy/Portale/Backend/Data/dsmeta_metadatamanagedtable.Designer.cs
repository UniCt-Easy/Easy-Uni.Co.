
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
[System.Xml.Serialization.XmlRoot("dsmeta_metadatamanagedtable"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_metadatamanagedtable: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable metadatamanagedtable 		=> (MetaTable)Tables["metadatamanagedtable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable metadataprimarykey 		=> (MetaTable)Tables["metadataprimarykey"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable metadatastaticfilter 		=> (MetaTable)Tables["metadatastaticfilter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable metadatasorting 		=> (MetaTable)Tables["metadatasorting"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_metadatamanagedtable(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_metadatamanagedtable (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_metadatamanagedtable";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_metadatamanagedtable.xsd";

	#region create DataTables
	//////////////////// METADATAMANAGEDTABLE /////////////////////////////////
	var tmetadatamanagedtable= new MetaTable("metadatamanagedtable");
	tmetadatamanagedtable.defineColumn("tablename", typeof(string),false);
	Tables.Add(tmetadatamanagedtable);
	tmetadatamanagedtable.defineKey("tablename");

	//////////////////// METADATAPRIMARYKEY /////////////////////////////////
	var tmetadataprimarykey= new MetaTable("metadataprimarykey");
	tmetadataprimarykey.defineColumn("tablename", typeof(string),false);
	tmetadataprimarykey.defineColumn("primarykey", typeof(string),false);
	Tables.Add(tmetadataprimarykey);
	tmetadataprimarykey.defineKey("tablename");

	//////////////////// METADATASTATICFILTER /////////////////////////////////
	var tmetadatastaticfilter= new MetaTable("metadatastaticfilter");
	tmetadatastaticfilter.defineColumn("tablename", typeof(string),false);
	tmetadatastaticfilter.defineColumn("listtype", typeof(string),false);
	tmetadatastaticfilter.defineColumn("staticfilter", typeof(string),false);
	Tables.Add(tmetadatastaticfilter);
	tmetadatastaticfilter.defineKey("tablename", "listtype");

	//////////////////// METADATASORTING /////////////////////////////////
	var tmetadatasorting= new MetaTable("metadatasorting");
	tmetadatasorting.defineColumn("tablename", typeof(string),false);
	tmetadatasorting.defineColumn("listtype", typeof(string),false);
	tmetadatasorting.defineColumn("sorting", typeof(string),false);
	Tables.Add(tmetadatasorting);
	tmetadatasorting.defineKey("tablename", "listtype");

	#endregion

}
}
}
