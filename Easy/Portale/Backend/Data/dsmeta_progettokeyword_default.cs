
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettokeyword_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettokeyword_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettokeyword 		=> (MetaTable)Tables["progettokeyword"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettokeyword_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettokeyword_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettokeyword_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettokeyword_default.xsd";

	#region create DataTables
	//////////////////// PROGETTOKEYWORD /////////////////////////////////
	var tprogettokeyword= new MetaTable("progettokeyword");
	tprogettokeyword.defineColumn("ct", typeof(DateTime),false);
	tprogettokeyword.defineColumn("cu", typeof(string),false);
	tprogettokeyword.defineColumn("idprogetto", typeof(int),false);
	tprogettokeyword.defineColumn("idprogettokeyword", typeof(int),false);
	tprogettokeyword.defineColumn("keyword", typeof(string),false);
	tprogettokeyword.defineColumn("lt", typeof(DateTime),false);
	tprogettokeyword.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettokeyword);
	tprogettokeyword.defineKey("idprogetto", "idprogettokeyword");

	#endregion

}
}
}
