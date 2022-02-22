
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
[System.Xml.Serialization.XmlRoot("dsmeta_tassaconfkind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tassaconfkind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tassaconfkind 		=> (MetaTable)Tables["tassaconfkind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tassaconfkind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tassaconfkind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tassaconfkind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tassaconfkind_default.xsd";

	#region create DataTables
	//////////////////// TASSACONFKIND /////////////////////////////////
	var ttassaconfkind= new MetaTable("tassaconfkind");
	ttassaconfkind.defineColumn("active", typeof(string),false);
	ttassaconfkind.defineColumn("ct", typeof(DateTime),false);
	ttassaconfkind.defineColumn("cu", typeof(string),false);
	ttassaconfkind.defineColumn("idtassaconfkind", typeof(int),false);
	ttassaconfkind.defineColumn("lt", typeof(DateTime),false);
	ttassaconfkind.defineColumn("lu", typeof(string),false);
	ttassaconfkind.defineColumn("sortcode", typeof(int),false);
	ttassaconfkind.defineColumn("title", typeof(string),false);
	Tables.Add(ttassaconfkind);
	ttassaconfkind.defineKey("idtassaconfkind");

	#endregion

}
}
}
