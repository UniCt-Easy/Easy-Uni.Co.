
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettokindcontrattokind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettokindcontrattokind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable positiondefaultview 		=> (MetaTable)Tables["positiondefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettokindcontrattokind 		=> (MetaTable)Tables["progettokindcontrattokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettokindcontrattokind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettokindcontrattokind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettokindcontrattokind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettokindcontrattokind_default.xsd";

	#region create DataTables
	//////////////////// POSITIONDEFAULTVIEW /////////////////////////////////
	var tpositiondefaultview= new MetaTable("positiondefaultview");
	tpositiondefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpositiondefaultview.defineColumn("idposition", typeof(int),false);
	tpositiondefaultview.defineColumn("position_active", typeof(string));
	Tables.Add(tpositiondefaultview);
	tpositiondefaultview.defineKey("idposition");

	//////////////////// PROGETTOKINDCONTRATTOKIND /////////////////////////////////
	var tprogettokindcontrattokind= new MetaTable("progettokindcontrattokind");
	tprogettokindcontrattokind.defineColumn("costostandard", typeof(decimal));
	tprogettokindcontrattokind.defineColumn("ct", typeof(DateTime),false);
	tprogettokindcontrattokind.defineColumn("cu", typeof(string),false);
	tprogettokindcontrattokind.defineColumn("idposition", typeof(int),false);
	tprogettokindcontrattokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettokindcontrattokind.defineColumn("lt", typeof(DateTime),false);
	tprogettokindcontrattokind.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettokindcontrattokind);
	tprogettokindcontrattokind.defineKey("idposition", "idprogettokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{positiondefaultview.Columns["idposition"]};
	var cChild = new []{progettokindcontrattokind.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_progettokindcontrattokind_positiondefaultview_idposition",cPar,cChild,false));

	#endregion

}
}
}
