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
[System.Xml.Serialization.XmlRoot("dsmeta_timesheettemplate_configurazione"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_timesheettemplate_configurazione: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable timesheettemplate 		=> (MetaTable)Tables["timesheettemplate"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_timesheettemplate_configurazione(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_timesheettemplate_configurazione (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_timesheettemplate_configurazione";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_timesheettemplate_configurazione.xsd";

	#region create DataTables
	//////////////////// TIMESHEETTEMPLATE /////////////////////////////////
	var ttimesheettemplate= new MetaTable("timesheettemplate");
	ttimesheettemplate.defineColumn("active", typeof(string));
	ttimesheettemplate.defineColumn("ct", typeof(DateTime));
	ttimesheettemplate.defineColumn("cu", typeof(string));
	ttimesheettemplate.defineColumn("description", typeof(string));
	ttimesheettemplate.defineColumn("idtimesheettemplate", typeof(string),false);
	ttimesheettemplate.defineColumn("leftsignaturelabel", typeof(string));
	ttimesheettemplate.defineColumn("lt", typeof(DateTime));
	ttimesheettemplate.defineColumn("lu", typeof(string));
	ttimesheettemplate.defineColumn("middlesignaturelabel", typeof(string));
	ttimesheettemplate.defineColumn("rightsignaturelabel", typeof(string));
	ttimesheettemplate.defineColumn("title", typeof(string));
	Tables.Add(ttimesheettemplate);
	ttimesheettemplate.defineKey("idtimesheettemplate");

	#endregion

}
}
}
