
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
[System.Xml.Serialization.XmlRoot("dsmeta_dichiaraltrekind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_dichiaraltrekind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiaraltrekind 		=> (MetaTable)Tables["dichiaraltrekind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_dichiaraltrekind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_dichiaraltrekind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_dichiaraltrekind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_dichiaraltrekind_default.xsd";

	#region create DataTables
	//////////////////// DICHIARALTREKIND /////////////////////////////////
	var tdichiaraltrekind= new MetaTable("dichiaraltrekind");
	tdichiaraltrekind.defineColumn("active", typeof(string),false);
	tdichiaraltrekind.defineColumn("ct", typeof(DateTime),false);
	tdichiaraltrekind.defineColumn("cu", typeof(string),false);
	tdichiaraltrekind.defineColumn("description", typeof(string),false);
	tdichiaraltrekind.defineColumn("iddichiaraltrekind", typeof(int),false);
	tdichiaraltrekind.defineColumn("lt", typeof(DateTime),false);
	tdichiaraltrekind.defineColumn("lu", typeof(string),false);
	tdichiaraltrekind.defineColumn("sortcode", typeof(int),false);
	tdichiaraltrekind.defineColumn("title", typeof(string),false);
	Tables.Add(tdichiaraltrekind);
	tdichiaraltrekind.defineKey("iddichiaraltrekind");

	#endregion

}
}
}
