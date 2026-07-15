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
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_years_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_years_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_years 		=> (MetaTable)Tables["firenet_years"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_years_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_years_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_years_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_years_default.xsd";

	#region create DataTables
	//////////////////// FIRENET_YEARS /////////////////////////////////
	var tfirenet_years= new MetaTable("firenet_years");
	tfirenet_years.defineColumn("A1max", typeof(int));
	tfirenet_years.defineColumn("A1max2", typeof(int));
	tfirenet_years.defineColumn("A1min", typeof(int));
	tfirenet_years.defineColumn("A1min2", typeof(int));
	tfirenet_years.defineColumn("A2max", typeof(int));
	tfirenet_years.defineColumn("A2max2", typeof(int));
	tfirenet_years.defineColumn("A2min", typeof(int));
	tfirenet_years.defineColumn("A2min2", typeof(int));
	tfirenet_years.defineColumn("A3max", typeof(int));
	tfirenet_years.defineColumn("A3min", typeof(int));
	tfirenet_years.defineColumn("anno", typeof(int));
	tfirenet_years.defineColumn("B1max", typeof(int));
	tfirenet_years.defineColumn("B1max2", typeof(int));
	tfirenet_years.defineColumn("B1min", typeof(int));
	tfirenet_years.defineColumn("B1min2", typeof(int));
	tfirenet_years.defineColumn("B2max", typeof(int));
	tfirenet_years.defineColumn("B2max2", typeof(int));
	tfirenet_years.defineColumn("B2min", typeof(int));
	tfirenet_years.defineColumn("B2min2", typeof(int));
	tfirenet_years.defineColumn("B3max", typeof(int));
	tfirenet_years.defineColumn("B3min", typeof(int));
	tfirenet_years.defineColumn("C1max", typeof(int));
	tfirenet_years.defineColumn("C1max2", typeof(int));
	tfirenet_years.defineColumn("C1min", typeof(int));
	tfirenet_years.defineColumn("C1min2", typeof(int));
	tfirenet_years.defineColumn("C2max", typeof(int));
	tfirenet_years.defineColumn("C2max2", typeof(int));
	tfirenet_years.defineColumn("C2min", typeof(int));
	tfirenet_years.defineColumn("C2min2", typeof(int));
	tfirenet_years.defineColumn("C3max", typeof(int));
	tfirenet_years.defineColumn("C3min", typeof(int));
	tfirenet_years.defineColumn("created", typeof(DateTime));
	tfirenet_years.defineColumn("crediti", typeof(int));
	tfirenet_years.defineColumn("D1max", typeof(int));
	tfirenet_years.defineColumn("D1max2", typeof(int));
	tfirenet_years.defineColumn("D1min", typeof(int));
	tfirenet_years.defineColumn("D1min2", typeof(int));
	tfirenet_years.defineColumn("D2max", typeof(int));
	tfirenet_years.defineColumn("D2max2", typeof(int));
	tfirenet_years.defineColumn("D2min", typeof(int));
	tfirenet_years.defineColumn("D2min2", typeof(int));
	tfirenet_years.defineColumn("D3max", typeof(int));
	tfirenet_years.defineColumn("D3min", typeof(int));
	tfirenet_years.defineColumn("data_fine1_to", typeof(string));
	tfirenet_years.defineColumn("data_fine2_to", typeof(string));
	tfirenet_years.defineColumn("data_from", typeof(string));
	tfirenet_years.defineColumn("E1max", typeof(int));
	tfirenet_years.defineColumn("E1max2", typeof(int));
	tfirenet_years.defineColumn("E1min", typeof(int));
	tfirenet_years.defineColumn("E1min2", typeof(int));
	tfirenet_years.defineColumn("E2max", typeof(int));
	tfirenet_years.defineColumn("E2max2", typeof(int));
	tfirenet_years.defineColumn("E2min", typeof(int));
	tfirenet_years.defineColumn("E2min2", typeof(int));
	tfirenet_years.defineColumn("E3max", typeof(int));
	tfirenet_years.defineColumn("E3min", typeof(int));
	tfirenet_years.defineColumn("edit_operator_user_id", typeof(int));
	tfirenet_years.defineColumn("fitarea1max", typeof(int));
	tfirenet_years.defineColumn("fitarea1min", typeof(int));
	tfirenet_years.defineColumn("fitarea2max", typeof(int));
	tfirenet_years.defineColumn("fitarea2min", typeof(int));
	tfirenet_years.defineColumn("fitarea3max", typeof(int));
	tfirenet_years.defineColumn("fitarea3min", typeof(int));
	tfirenet_years.defineColumn("fitarea4max", typeof(int));
	tfirenet_years.defineColumn("fitarea4min", typeof(int));
	tfirenet_years.defineColumn("freqmin", typeof(int));
	tfirenet_years.defineColumn("id", typeof(int),false);
	tfirenet_years.defineColumn("laboratorio", typeof(int));
	tfirenet_years.defineColumn("maxlaboratorio", typeof(int));
	tfirenet_years.defineColumn("maxstrumentale", typeof(int));
	tfirenet_years.defineColumn("maxteorico", typeof(int));
	tfirenet_years.defineColumn("modified", typeof(DateTime));
	tfirenet_years.defineColumn("scarto", typeof(int));
	tfirenet_years.defineColumn("strumentale", typeof(decimal));
	tfirenet_years.defineColumn("teorico", typeof(int));
	Tables.Add(tfirenet_years);
	tfirenet_years.defineKey("id");

	#endregion

}
}
}
