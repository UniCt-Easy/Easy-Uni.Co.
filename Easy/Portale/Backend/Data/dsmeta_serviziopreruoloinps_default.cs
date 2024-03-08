
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
[System.Xml.Serialization.XmlRoot("dsmeta_serviziopreruoloinps_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_serviziopreruoloinps_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable positiondefaultview 		=> (MetaTable)Tables["positiondefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziopreruoloinps 		=> (MetaTable)Tables["serviziopreruoloinps"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_serviziopreruoloinps_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_serviziopreruoloinps_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_serviziopreruoloinps_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_serviziopreruoloinps_default.xsd";

	#region create DataTables
	//////////////////// POSITIONDEFAULTVIEW /////////////////////////////////
	var tpositiondefaultview= new MetaTable("positiondefaultview");
	tpositiondefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpositiondefaultview.defineColumn("idposition", typeof(int),false);
	tpositiondefaultview.defineColumn("position_active", typeof(string));
	Tables.Add(tpositiondefaultview);
	tpositiondefaultview.defineKey("idposition");

	//////////////////// SERVIZIOPRERUOLOINPS /////////////////////////////////
	var tserviziopreruoloinps= new MetaTable("serviziopreruoloinps");
	tserviziopreruoloinps.defineColumn("anni", typeof(int));
	tserviziopreruoloinps.defineColumn("annokind", typeof(string));
	tserviziopreruoloinps.defineColumn("cedolini", typeof(string));
	tserviziopreruoloinps.defineColumn("ct", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("cu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("giorni", typeof(int));
	tserviziopreruoloinps.defineColumn("idposition", typeof(int));
	tserviziopreruoloinps.defineColumn("idreg", typeof(int),false);
	tserviziopreruoloinps.defineColumn("idserviziopreruoloinps", typeof(int),false);
	tserviziopreruoloinps.defineColumn("istituzione", typeof(string));
	tserviziopreruoloinps.defineColumn("lt", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("lu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("mesi", typeof(int));
	tserviziopreruoloinps.defineColumn("start", typeof(DateTime));
	tserviziopreruoloinps.defineColumn("stop", typeof(DateTime));
	Tables.Add(tserviziopreruoloinps);
	tserviziopreruoloinps.defineKey("idreg", "idserviziopreruoloinps");

	#endregion


	#region DataRelation creation
	var cPar = new []{positiondefaultview.Columns["idposition"]};
	var cChild = new []{serviziopreruoloinps.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_positiondefaultview_idposition",cPar,cChild,false));

	#endregion

}
}
}
