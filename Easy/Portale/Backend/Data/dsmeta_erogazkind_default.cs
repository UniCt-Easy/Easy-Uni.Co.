
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_erogazkind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_erogazkind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable erogazkind 		=> (MetaTable)Tables["erogazkind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_erogazkind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_erogazkind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_erogazkind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_erogazkind_default.xsd";

	#region create DataTables
	//////////////////// EROGAZKIND /////////////////////////////////
	var terogazkind= new MetaTable("erogazkind");
	terogazkind.defineColumn("active", typeof(string),false);
	terogazkind.defineColumn("ans", typeof(string));
	terogazkind.defineColumn("description", typeof(string));
	terogazkind.defineColumn("iderogazkind", typeof(int),false);
	terogazkind.defineColumn("lt", typeof(DateTime),false);
	terogazkind.defineColumn("lu", typeof(string),false);
	terogazkind.defineColumn("sortcode", typeof(int),false);
	terogazkind.defineColumn("title", typeof(string),false);
	Tables.Add(terogazkind);
	terogazkind.defineKey("iderogazkind");

	#endregion

}
}
}
