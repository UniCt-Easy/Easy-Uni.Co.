
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
[System.Xml.Serialization.XmlRoot("dsmeta_apptablerule_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_apptablerule_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptablerule 		=> (MetaTable)Tables["apptablerule"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_apptablerule_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_apptablerule_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_apptablerule_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_apptablerule_default.xsd";

	#region create DataTables
	//////////////////// APPTABLERULE /////////////////////////////////
	var tapptablerule= new MetaTable("apptablerule");
	tapptablerule.defineColumn("code", typeof(string),false);
	tapptablerule.defineColumn("del", typeof(string),false);
	tapptablerule.defineColumn("idapptable", typeof(int),false);
	tapptablerule.defineColumn("idapptablerule", typeof(int),false);
	tapptablerule.defineColumn("ins", typeof(string),false);
	tapptablerule.defineColumn("message", typeof(string),false);
	tapptablerule.defineColumn("post", typeof(string),false);
	tapptablerule.defineColumn("sql", typeof(string),false);
	tapptablerule.defineColumn("upd", typeof(string),false);
	tapptablerule.defineColumn("warning", typeof(string),false);
	Tables.Add(tapptablerule);
	tapptablerule.defineKey("idapptable", "idapptablerule");

	#endregion

}
}
}
