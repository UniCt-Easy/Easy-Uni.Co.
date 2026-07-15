/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_sospensionekind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_sospensionekind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable eventokinddefaultview 		=> (MetaTable)Tables["eventokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensionekind 		=> (MetaTable)Tables["sospensionekind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_sospensionekind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_sospensionekind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_sospensionekind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_sospensionekind_default.xsd";

	#region create DataTables
	//////////////////// EVENTOKINDDEFAULTVIEW /////////////////////////////////
	var teventokinddefaultview= new MetaTable("eventokinddefaultview");
	teventokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	teventokinddefaultview.defineColumn("eventokind_active", typeof(string));
	teventokinddefaultview.defineColumn("eventokind_ct", typeof(DateTime));
	teventokinddefaultview.defineColumn("eventokind_cu", typeof(string));
	teventokinddefaultview.defineColumn("eventokind_lt", typeof(DateTime));
	teventokinddefaultview.defineColumn("eventokind_lu", typeof(string));
	teventokinddefaultview.defineColumn("ideventokind", typeof(int),false);
	teventokinddefaultview.defineColumn("title", typeof(string));
	Tables.Add(teventokinddefaultview);
	teventokinddefaultview.defineKey("ideventokind");

	//////////////////// SOSPENSIONEKIND /////////////////////////////////
	var tsospensionekind= new MetaTable("sospensionekind");
	tsospensionekind.defineColumn("active", typeof(string),false);
	tsospensionekind.defineColumn("ct", typeof(DateTime),false);
	tsospensionekind.defineColumn("cu", typeof(string),false);
	tsospensionekind.defineColumn("description", typeof(string));
	tsospensionekind.defineColumn("ideventokind", typeof(int),false);
	tsospensionekind.defineColumn("idsospensionekind", typeof(int),false);
	tsospensionekind.defineColumn("lt", typeof(DateTime),false);
	tsospensionekind.defineColumn("lu", typeof(string),false);
	tsospensionekind.defineColumn("sortcode", typeof(int),false);
	tsospensionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tsospensionekind);
	tsospensionekind.defineKey("idsospensionekind");

	#endregion


	#region DataRelation creation
	var cPar = new []{eventokinddefaultview.Columns["ideventokind"]};
	var cChild = new []{sospensionekind.Columns["ideventokind"]};
	Relations.Add(new DataRelation("FK_sospensionekind_eventokinddefaultview_ideventokind",cPar,cChild,false));

	#endregion

}
}
}
