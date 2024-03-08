
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace estimateattachment_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vista"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vista: DataSet {

	#region Table members declaration
	///<summary>
	///allegato contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimateattachment 		=> Tables["estimateattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimateattachmentkind 		=> Tables["estimateattachmentkind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vista(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vista (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vista";
	Prefix = "";
	Namespace = "http://tempuri.org/vista.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// ESTIMATEATTACHMENT /////////////////////////////////
	var testimateattachment= new DataTable("estimateattachment");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimateattachment.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimateattachment.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimateattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	testimateattachment.Columns.Add(C);
	testimateattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	testimateattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	testimateattachment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	testimateattachment.Columns.Add( new DataColumn("lu", typeof(string)));
	testimateattachment.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	testimateattachment.Columns.Add( new DataColumn("cu", typeof(string)));
	testimateattachment.Columns.Add( new DataColumn("idattachmentkind", typeof(int)));
	Tables.Add(testimateattachment);
	testimateattachment.PrimaryKey =  new DataColumn[]{testimateattachment.Columns["idestimkind"], testimateattachment.Columns["yestim"], testimateattachment.Columns["nestim"], testimateattachment.Columns["idattachment"]};


	//////////////////// ESTIMATEATTACHMENTKIND /////////////////////////////////
	var testimateattachmentkind= new DataTable("estimateattachmentkind");
	C= new DataColumn("idattachmentkind", typeof(int));
	C.AllowDBNull=false;
	testimateattachmentkind.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	testimateattachmentkind.Columns.Add(C);
	testimateattachmentkind.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	testimateattachmentkind.Columns.Add( new DataColumn("cu", typeof(string)));
	testimateattachmentkind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	testimateattachmentkind.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	testimateattachmentkind.Columns.Add(C);
	Tables.Add(testimateattachmentkind);
	testimateattachmentkind.PrimaryKey =  new DataColumn[]{testimateattachmentkind.Columns["idattachmentkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{estimateattachmentkind.Columns["idattachmentkind"]};
	var cChild = new []{estimateattachment.Columns["idattachmentkind"]};
	Relations.Add(new DataRelation("estimateattachmentkind_estimateattachment",cPar,cChild,false));

	#endregion

}
}
}
