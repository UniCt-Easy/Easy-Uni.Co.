
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
[System.Xml.Serialization.XmlRoot("dsmeta_contrattokindperiodo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_contrattokindperiodo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokindperiodo 		=> (MetaTable)Tables["contrattokindperiodo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_contrattokindperiodo_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_contrattokindperiodo_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_contrattokindperiodo_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_contrattokindperiodo_default.xsd";

	#region create DataTables
	//////////////////// CONTRATTOKINDPERIODO /////////////////////////////////
	var tcontrattokindperiodo= new MetaTable("contrattokindperiodo");
	tcontrattokindperiodo.defineColumn("ct", typeof(DateTime));
	tcontrattokindperiodo.defineColumn("cu", typeof(string));
	tcontrattokindperiodo.defineColumn("datafrom", typeof(DateTime));
	tcontrattokindperiodo.defineColumn("datato", typeof(DateTime));
	tcontrattokindperiodo.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokindperiodo.defineColumn("idcontrattokindperiodo", typeof(int),false);
	tcontrattokindperiodo.defineColumn("lt", typeof(DateTime));
	tcontrattokindperiodo.defineColumn("lu", typeof(string));
	Tables.Add(tcontrattokindperiodo);
	tcontrattokindperiodo.defineKey("idcontrattokind", "idcontrattokindperiodo");

	#endregion

}
}
}
