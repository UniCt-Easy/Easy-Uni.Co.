
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
namespace registryattachment_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vista"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vista: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryattachment 		=> Tables["registryattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryattachmentkind 		=> Tables["registryattachmentkind"];

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
	//////////////////// REGISTRYATTACHMENT /////////////////////////////////
	var tregistryattachment= new DataTable("registryattachment");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	tregistryattachment.Columns.Add(C);
	tregistryattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	tregistryattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	tregistryattachment.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistryattachment.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistryattachment.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistryattachment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistryattachment.Columns.Add( new DataColumn("idattachmentkind", typeof(int)));
	Tables.Add(tregistryattachment);
	tregistryattachment.PrimaryKey =  new DataColumn[]{tregistryattachment.Columns["idreg"], tregistryattachment.Columns["idattachment"]};


	//////////////////// REGISTRYATTACHMENTKIND /////////////////////////////////
	var tregistryattachmentkind= new DataTable("registryattachmentkind");
	C= new DataColumn("idattachmentkind", typeof(int));
	C.AllowDBNull=false;
	tregistryattachmentkind.Columns.Add(C);
	tregistryattachmentkind.Columns.Add( new DataColumn("active", typeof(string)));
	tregistryattachmentkind.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistryattachmentkind.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistryattachmentkind.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistryattachmentkind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistryattachmentkind.Columns.Add( new DataColumn("title", typeof(string)));
	tregistryattachmentkind.Columns.Add( new DataColumn("mandatory", typeof(string)));
	Tables.Add(tregistryattachmentkind);
	tregistryattachmentkind.PrimaryKey =  new DataColumn[]{tregistryattachmentkind.Columns["idattachmentkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registryattachmentkind.Columns["idattachmentkind"]};
	var cChild = new []{registryattachment.Columns["idattachmentkind"]};
	Relations.Add(new DataRelation("registryattachmentkind_registryattachment",cPar,cChild,false));

	#endregion

}
}
}
