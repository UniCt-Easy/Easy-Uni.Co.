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
[System.Xml.Serialization.XmlRoot("dsmeta_customselection_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_customselection_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable customselection 		=> (MetaTable)Tables["customselection"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_customselection_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_customselection_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_customselection_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_customselection_default.xsd";

	#region create DataTables
	//////////////////// CUSTOMSELECTION /////////////////////////////////
	var tcustomselection= new MetaTable("customselection");
	tcustomselection.defineColumn("editlisttype", typeof(string));
	tcustomselection.defineColumn("extraparameter", typeof(string));
	tcustomselection.defineColumn("fieldname", typeof(string));
	tcustomselection.defineColumn("filter", typeof(string));
	tcustomselection.defineColumn("lastmodtimestamp", typeof(DateTime));
	tcustomselection.defineColumn("lastmoduser", typeof(string));
	tcustomselection.defineColumn("relationfield", typeof(string));
	tcustomselection.defineColumn("selectioncode", typeof(string),false);
	tcustomselection.defineColumn("selectionname", typeof(string));
	tcustomselection.defineColumn("selectiontype", typeof(string));
	tcustomselection.defineColumn("tablename", typeof(string));
	Tables.Add(tcustomselection);
	tcustomselection.defineKey("selectioncode");

	#endregion

}
}
}
