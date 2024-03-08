
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
[System.Xml.Serialization.XmlRoot("dsmeta_stipendiocomplemento_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_stipendiocomplemento_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendiocomplementokinddefaultview 		=> (MetaTable)Tables["stipendiocomplementokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendiocomplemento 		=> (MetaTable)Tables["stipendiocomplemento"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_stipendiocomplemento_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_stipendiocomplemento_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_stipendiocomplemento_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_stipendiocomplemento_default.xsd";

	#region create DataTables
	//////////////////// STIPENDIOCOMPLEMENTOKINDDEFAULTVIEW /////////////////////////////////
	var tstipendiocomplementokinddefaultview= new MetaTable("stipendiocomplementokinddefaultview");
	tstipendiocomplementokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstipendiocomplementokinddefaultview.defineColumn("idstipendiocomplementokind", typeof(int),false);
	tstipendiocomplementokinddefaultview.defineColumn("stipendiocomplementokind_active", typeof(string));
	tstipendiocomplementokinddefaultview.defineColumn("stipendiocomplementokind_description", typeof(string));
	tstipendiocomplementokinddefaultview.defineColumn("stipendiocomplementokind_sortcode", typeof(int));
	tstipendiocomplementokinddefaultview.defineColumn("title", typeof(string));
	Tables.Add(tstipendiocomplementokinddefaultview);
	tstipendiocomplementokinddefaultview.defineKey("idstipendiocomplementokind");

	//////////////////// STIPENDIOCOMPLEMENTO /////////////////////////////////
	var tstipendiocomplemento= new MetaTable("stipendiocomplemento");
	tstipendiocomplemento.defineColumn("anzianitamax", typeof(int));
	tstipendiocomplemento.defineColumn("anzianitamin", typeof(int));
	tstipendiocomplemento.defineColumn("complementomensile", typeof(decimal));
	tstipendiocomplemento.defineColumn("idcontrattokind", typeof(int));
	tstipendiocomplemento.defineColumn("idinquadramento", typeof(int),false);
	tstipendiocomplemento.defineColumn("idposition", typeof(int),false);
	tstipendiocomplemento.defineColumn("idstipendiocomplemento", typeof(int),false);
	tstipendiocomplemento.defineColumn("idstipendiocomplementokind", typeof(int));
	tstipendiocomplemento.defineColumn("rifnormativo", typeof(string));
	tstipendiocomplemento.defineColumn("start", typeof(DateTime));
	tstipendiocomplemento.defineColumn("stop", typeof(DateTime));
	Tables.Add(tstipendiocomplemento);
	tstipendiocomplemento.defineKey("idinquadramento", "idposition", "idstipendiocomplemento");

	#endregion


	#region DataRelation creation
	var cPar = new []{stipendiocomplementokinddefaultview.Columns["idstipendiocomplementokind"]};
	var cChild = new []{stipendiocomplemento.Columns["idstipendiocomplementokind"]};
	Relations.Add(new DataRelation("FK_stipendiocomplemento_stipendiocomplementokinddefaultview_idstipendiocomplementokind",cPar,cChild,false));

	#endregion

}
}
}
