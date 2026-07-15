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
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_tax_ranges_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_tax_ranges_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_tax_ranges 		=> (MetaTable)Tables["firenet_tax_ranges"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_tax_ranges_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_tax_ranges_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_tax_ranges_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_tax_ranges_default.xsd";

	#region create DataTables
	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// FIRENET_TAX_RANGES /////////////////////////////////
	var tfirenet_tax_ranges= new MetaTable("firenet_tax_ranges");
	tfirenet_tax_ranges.defineColumn("aa", typeof(int));
	tfirenet_tax_ranges.defineColumn("created", typeof(DateTime));
	tfirenet_tax_ranges.defineColumn("edit_operator_user_id", typeof(int));
	tfirenet_tax_ranges.defineColumn("exclude_mode", typeof(int));
	tfirenet_tax_ranges.defineColumn("id", typeof(int),false);
	tfirenet_tax_ranges.defineColumn("importo", typeof(decimal));
	tfirenet_tax_ranges.defineColumn("livello", typeof(int));
	tfirenet_tax_ranges.defineColumn("lower_bound", typeof(decimal));
	tfirenet_tax_ranges.defineColumn("modified", typeof(DateTime));
	tfirenet_tax_ranges.defineColumn("tax_type_id", typeof(int));
	tfirenet_tax_ranges.defineColumn("upper_bound", typeof(decimal));
	Tables.Add(tfirenet_tax_ranges);
	tfirenet_tax_ranges.defineKey("id");

	#endregion

}
}
}
