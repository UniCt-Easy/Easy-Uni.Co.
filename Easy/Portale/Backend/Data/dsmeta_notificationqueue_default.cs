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
[System.Xml.Serialization.XmlRoot("dsmeta_notificationqueue_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_notificationqueue_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable entrydetail 		=> (MetaTable)Tables["entrydetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable notificationqueue 		=> (MetaTable)Tables["notificationqueue"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_notificationqueue_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_notificationqueue_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_notificationqueue_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_notificationqueue_default.xsd";

	#region create DataTables
	//////////////////// ENTRYDETAIL /////////////////////////////////
	var tentrydetail= new MetaTable("entrydetail");
	tentrydetail.defineColumn("description", typeof(string));
	tentrydetail.defineColumn("idrelated", typeof(string));
	tentrydetail.defineColumn("ndetail", typeof(int),false);
	tentrydetail.defineColumn("nentry", typeof(int),false);
	tentrydetail.defineColumn("yentry", typeof(int),false);
	Tables.Add(tentrydetail);
	tentrydetail.defineKey("ndetail", "nentry", "yentry");

	//////////////////// NOTIFICATIONQUEUE /////////////////////////////////
	var tnotificationqueue= new MetaTable("notificationqueue");
	tnotificationqueue.defineColumn("ct", typeof(DateTime),false);
	tnotificationqueue.defineColumn("cu", typeof(string),false);
	tnotificationqueue.defineColumn("idnotificationqueue", typeof(int),false);
	tnotificationqueue.defineColumn("idrelated", typeof(string),false);
	tnotificationqueue.defineColumn("lt", typeof(DateTime),false);
	tnotificationqueue.defineColumn("lu", typeof(string),false);
	tnotificationqueue.defineColumn("senttimestamp", typeof(DateTime));
	tnotificationqueue.defineColumn("sourceedittype", typeof(string),false);
	tnotificationqueue.defineColumn("sourcetablename", typeof(string),false);
	Tables.Add(tnotificationqueue);
	tnotificationqueue.defineKey("idnotificationqueue");

	#endregion


	#region DataRelation creation
	var cPar = new []{entrydetail.Columns["idrelated"]};
	var cChild = new []{notificationqueue.Columns["idrelated"]};
	Relations.Add(new DataRelation("FK_notificationqueue_entrydetail_idrelated",cPar,cChild,false));

	#endregion

}
}
}
