
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotipocostokindaccmotive_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettotipocostokindaccmotive_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive 		=> (MetaTable)Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindaccmotive 		=> (MetaTable)Tables["progettotipocostokindaccmotive"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotipocostokindaccmotive_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotipocostokindaccmotive_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotipocostokindaccmotive_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotipocostokindaccmotive_seg.xsd";

	#region create DataTables
	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new MetaTable("accmotive");
	taccmotive.defineColumn("active", typeof(string));
	taccmotive.defineColumn("codemotive", typeof(string),false);
	taccmotive.defineColumn("ct", typeof(DateTime),false);
	taccmotive.defineColumn("cu", typeof(string),false);
	taccmotive.defineColumn("expensekind", typeof(string));
	taccmotive.defineColumn("flag", typeof(int));
	taccmotive.defineColumn("flagamm", typeof(string));
	taccmotive.defineColumn("flagdep", typeof(string));
	taccmotive.defineColumn("idaccmotive", typeof(string),false);
	taccmotive.defineColumn("lt", typeof(DateTime),false);
	taccmotive.defineColumn("lu", typeof(string),false);
	taccmotive.defineColumn("paridaccmotive", typeof(string));
	taccmotive.defineColumn("title", typeof(string),false);
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

	//////////////////// PROGETTOTIPOCOSTOKINDACCMOTIVE /////////////////////////////////
	var tprogettotipocostokindaccmotive= new MetaTable("progettotipocostokindaccmotive");
	tprogettotipocostokindaccmotive.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokindaccmotive.defineColumn("cu", typeof(string));
	tprogettotipocostokindaccmotive.defineColumn("idaccmotive", typeof(string),false);
	tprogettotipocostokindaccmotive.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindaccmotive.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindaccmotive.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokindaccmotive.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostokindaccmotive);
	tprogettotipocostokindaccmotive.defineKey("idaccmotive", "idprogettokind", "idprogettotipocostokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{accmotive.Columns["idaccmotive"]};
	var cChild = new []{progettotipocostokindaccmotive.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindaccmotive_accmotive_idaccmotive",cPar,cChild,false));

	#endregion

}
}
}
