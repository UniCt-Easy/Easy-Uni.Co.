
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
[System.Xml.Serialization.XmlRoot("dsmeta_stipendiocomplementokind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_stipendiocomplementokind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendiocomplementokind 		=> (MetaTable)Tables["stipendiocomplementokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_stipendiocomplementokind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_stipendiocomplementokind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_stipendiocomplementokind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_stipendiocomplementokind_default.xsd";

	#region create DataTables
	//////////////////// STIPENDIOCOMPLEMENTOKIND /////////////////////////////////
	var tstipendiocomplementokind= new MetaTable("stipendiocomplementokind");
	tstipendiocomplementokind.defineColumn("active", typeof(string));
	tstipendiocomplementokind.defineColumn("description", typeof(string));
	tstipendiocomplementokind.defineColumn("idstipendiocomplementokind", typeof(int),false);
	tstipendiocomplementokind.defineColumn("sortcode", typeof(int));
	tstipendiocomplementokind.defineColumn("title", typeof(string));
	Tables.Add(tstipendiocomplementokind);
	tstipendiocomplementokind.defineKey("idstipendiocomplementokind");

	#endregion

}
}
}
