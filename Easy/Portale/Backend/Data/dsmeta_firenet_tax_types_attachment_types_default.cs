
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_tax_types_attachment_types_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_tax_types_attachment_types_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_tax_types_attachment_types 		=> (MetaTable)Tables["firenet_tax_types_attachment_types"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_tax_types_attachment_types_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_tax_types_attachment_types_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_tax_types_attachment_types_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_tax_types_attachment_types_default.xsd";

	#region create DataTables
	//////////////////// FIRENET_TAX_TYPES_ATTACHMENT_TYPES /////////////////////////////////
	var tfirenet_tax_types_attachment_types= new MetaTable("firenet_tax_types_attachment_types");
	tfirenet_tax_types_attachment_types.defineColumn("attachment_type_id", typeof(int));
	tfirenet_tax_types_attachment_types.defineColumn("created", typeof(DateTime));
	tfirenet_tax_types_attachment_types.defineColumn("id", typeof(int),false);
	tfirenet_tax_types_attachment_types.defineColumn("modified", typeof(DateTime));
	tfirenet_tax_types_attachment_types.defineColumn("tax_type_id", typeof(int));
	Tables.Add(tfirenet_tax_types_attachment_types);
	tfirenet_tax_types_attachment_types.defineKey("id");

	#endregion

}
}
}
