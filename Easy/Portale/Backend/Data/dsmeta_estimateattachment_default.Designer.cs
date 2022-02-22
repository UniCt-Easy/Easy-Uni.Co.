
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
[System.Xml.Serialization.XmlRoot("dsmeta_estimateattachment_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_estimateattachment_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimateattachment 		=> (MetaTable)Tables["estimateattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_estimateattachment_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_estimateattachment_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_estimateattachment_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_estimateattachment_default.xsd";

	#region create DataTables
	//////////////////// ESTIMATEATTACHMENT /////////////////////////////////
	var testimateattachment= new MetaTable("estimateattachment");
	testimateattachment.defineColumn("idestimkind", typeof(string),false);
	testimateattachment.defineColumn("yestim", typeof(short),false);
	testimateattachment.defineColumn("nestim", typeof(int),false);
	testimateattachment.defineColumn("idattachment", typeof(int),false);
	testimateattachment.defineColumn("filename", typeof(string));
	testimateattachment.defineColumn("attachment", typeof(Byte[]));
	testimateattachment.defineColumn("lt", typeof(DateTime));
	testimateattachment.defineColumn("lu", typeof(string));
	testimateattachment.defineColumn("ct", typeof(DateTime));
	testimateattachment.defineColumn("cu", typeof(string));
	testimateattachment.defineColumn("!attachment", typeof(int));
	Tables.Add(testimateattachment);
	testimateattachment.defineKey("idestimkind", "yestim", "nestim", "idattachment");

	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(string),false);
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	#endregion


	#region DataRelation creation
	var cPar = new []{attach.Columns["idattach"]};
	var cChild = new []{estimateattachment.Columns["!attachment"]};
	Relations.Add(new DataRelation("attach_estimateattachment",cPar,cChild,false));

	#endregion

}
}
}
