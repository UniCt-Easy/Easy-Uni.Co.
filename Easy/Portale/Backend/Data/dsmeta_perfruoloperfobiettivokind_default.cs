
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfruoloperfobiettivokind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfruoloperfobiettivokind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettivokinddefaultview 		=> (MetaTable)Tables["perfobiettivokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruoloperfobiettivokind 		=> (MetaTable)Tables["perfruoloperfobiettivokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfruoloperfobiettivokind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfruoloperfobiettivokind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfruoloperfobiettivokind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfruoloperfobiettivokind_default.xsd";

	#region create DataTables
	//////////////////// PERFOBIETTIVOKINDDEFAULTVIEW /////////////////////////////////
	var tperfobiettivokinddefaultview= new MetaTable("perfobiettivokinddefaultview");
	tperfobiettivokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfobiettivokinddefaultview.defineColumn("idperfobiettivokind", typeof(int),false);
	tperfobiettivokinddefaultview.defineColumn("perfobiettivokind_active", typeof(string));
	tperfobiettivokinddefaultview.defineColumn("perfobiettivokind_ct", typeof(DateTime));
	tperfobiettivokinddefaultview.defineColumn("perfobiettivokind_cu", typeof(string));
	tperfobiettivokinddefaultview.defineColumn("perfobiettivokind_description", typeof(string));
	tperfobiettivokinddefaultview.defineColumn("perfobiettivokind_lt", typeof(DateTime));
	tperfobiettivokinddefaultview.defineColumn("perfobiettivokind_lu", typeof(string));
	tperfobiettivokinddefaultview.defineColumn("title", typeof(string));
	Tables.Add(tperfobiettivokinddefaultview);
	tperfobiettivokinddefaultview.defineKey("idperfobiettivokind");

	//////////////////// PERFRUOLOPERFOBIETTIVOKIND /////////////////////////////////
	var tperfruoloperfobiettivokind= new MetaTable("perfruoloperfobiettivokind");
	tperfruoloperfobiettivokind.defineColumn("ct", typeof(DateTime));
	tperfruoloperfobiettivokind.defineColumn("cu", typeof(string));
	tperfruoloperfobiettivokind.defineColumn("idperfobiettivokind", typeof(int),false);
	tperfruoloperfobiettivokind.defineColumn("idperfruolo", typeof(string),false);
	tperfruoloperfobiettivokind.defineColumn("lt", typeof(DateTime));
	tperfruoloperfobiettivokind.defineColumn("lu", typeof(string));
	Tables.Add(tperfruoloperfobiettivokind);
	tperfruoloperfobiettivokind.defineKey("idperfobiettivokind", "idperfruolo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfobiettivokinddefaultview.Columns["idperfobiettivokind"]};
	var cChild = new []{perfruoloperfobiettivokind.Columns["idperfobiettivokind"]};
	Relations.Add(new DataRelation("FK_perfruoloperfobiettivokind_perfobiettivokinddefaultview_idperfobiettivokind",cPar,cChild,false));

	#endregion

}
}
}
