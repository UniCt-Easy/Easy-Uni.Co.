
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
[System.Xml.Serialization.XmlRoot("dsmeta_istanzakind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_istanzakind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzakind 		=> (MetaTable)Tables["istanzakind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanzakind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanzakind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanzakind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanzakind_default.xsd";

	#region create DataTables
	//////////////////// ISTANZAKIND /////////////////////////////////
	var tistanzakind= new MetaTable("istanzakind");
	tistanzakind.defineColumn("active", typeof(string),false);
	tistanzakind.defineColumn("ct", typeof(DateTime),false);
	tistanzakind.defineColumn("cu", typeof(string),false);
	tistanzakind.defineColumn("description", typeof(string));
	tistanzakind.defineColumn("idistanzakind", typeof(int),false);
	tistanzakind.defineColumn("lt", typeof(DateTime),false);
	tistanzakind.defineColumn("lu", typeof(string),false);
	tistanzakind.defineColumn("sortcode", typeof(int),false);
	tistanzakind.defineColumn("title", typeof(string),false);
	Tables.Add(tistanzakind);
	tistanzakind.defineKey("idistanzakind");

	#endregion

}
}
}
