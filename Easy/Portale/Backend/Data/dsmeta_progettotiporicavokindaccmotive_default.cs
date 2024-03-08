
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotiporicavokindaccmotive_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettotiporicavokindaccmotive_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivesegview 		=> (MetaTable)Tables["accmotivesegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotiporicavokindaccmotive 		=> (MetaTable)Tables["progettotiporicavokindaccmotive"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotiporicavokindaccmotive_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotiporicavokindaccmotive_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotiporicavokindaccmotive_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotiporicavokindaccmotive_default.xsd";

	#region create DataTables
	//////////////////// ACCMOTIVESEGVIEW /////////////////////////////////
	var taccmotivesegview= new MetaTable("accmotivesegview");
	taccmotivesegview.defineColumn("accmotive_active", typeof(string));
	taccmotivesegview.defineColumn("accmotive_codemotive", typeof(string),false);
	taccmotivesegview.defineColumn("accmotive_ct", typeof(DateTime),false);
	taccmotivesegview.defineColumn("accmotive_cu", typeof(string),false);
	taccmotivesegview.defineColumn("accmotive_expensekind", typeof(string));
	taccmotivesegview.defineColumn("accmotive_flag", typeof(int));
	taccmotivesegview.defineColumn("accmotive_flagamm", typeof(string));
	taccmotivesegview.defineColumn("accmotive_flagdep", typeof(string));
	taccmotivesegview.defineColumn("accmotive_lt", typeof(DateTime),false);
	taccmotivesegview.defineColumn("accmotive_lu", typeof(string),false);
	taccmotivesegview.defineColumn("accmotiveparent_codemotive", typeof(string));
	taccmotivesegview.defineColumn("accmotiveparent_title", typeof(string));
	taccmotivesegview.defineColumn("dropdown_title", typeof(string),false);
	taccmotivesegview.defineColumn("idaccmotive", typeof(string),false);
	taccmotivesegview.defineColumn("paridaccmotive", typeof(string));
	taccmotivesegview.defineColumn("title", typeof(string),false);
	Tables.Add(taccmotivesegview);
	taccmotivesegview.defineKey("idaccmotive");

	//////////////////// PROGETTOTIPORICAVOKINDACCMOTIVE /////////////////////////////////
	var tprogettotiporicavokindaccmotive= new MetaTable("progettotiporicavokindaccmotive");
	tprogettotiporicavokindaccmotive.defineColumn("ct", typeof(DateTime));
	tprogettotiporicavokindaccmotive.defineColumn("cu", typeof(string));
	tprogettotiporicavokindaccmotive.defineColumn("idaccmotive", typeof(string),false);
	tprogettotiporicavokindaccmotive.defineColumn("idprogettokind", typeof(int),false);
	tprogettotiporicavokindaccmotive.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotiporicavokindaccmotive.defineColumn("lt", typeof(DateTime));
	tprogettotiporicavokindaccmotive.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotiporicavokindaccmotive);
	tprogettotiporicavokindaccmotive.defineKey("idaccmotive", "idprogettokind", "idprogettotipocostokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{accmotivesegview.Columns["idaccmotive"]};
	var cChild = new []{progettotiporicavokindaccmotive.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_progettotiporicavokindaccmotive_accmotivesegview_idaccmotive",cPar,cChild,false));

	#endregion

}
}
}
