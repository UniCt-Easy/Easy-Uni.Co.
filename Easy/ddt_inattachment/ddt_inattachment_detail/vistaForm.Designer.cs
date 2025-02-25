
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
namespace ddt_inattachment_detail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ddt_inattachment 		=> Tables["ddt_inattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable attachmentkind 		=> Tables["attachmentkind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// ddt_inATTACHMENT /////////////////////////////////
	var tddt_inattachment= new DataTable("ddt_inattachment");
	C= new DataColumn("idddt_in", typeof(Int32));
	C.AllowDBNull=true;
	tddt_inattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	tddt_inattachment.Columns.Add(C);
	tddt_inattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tddt_inattachment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tddt_inattachment.Columns.Add(C);
	tddt_inattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	tddt_inattachment.Columns.Add( new DataColumn("idattachmentkind", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tddt_inattachment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tddt_inattachment.Columns.Add(C);
	Tables.Add(tddt_inattachment);
	tddt_inattachment.PrimaryKey =  new DataColumn[]{tddt_inattachment.Columns["idddt_in"], tddt_inattachment.Columns["idattachment"]};


	//////////////////// attachmentkind /////////////////////////////////
	var tattachmentkind= new DataTable("attachmentkind");
	C= new DataColumn("idattachmentkind", typeof(int));
	C.AllowDBNull=false;
	tattachmentkind.Columns.Add(C);
	tattachmentkind.Columns.Add( new DataColumn("title", typeof(string)));
	tattachmentkind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tattachmentkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tattachmentkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tattachmentkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tattachmentkind.Columns.Add(C);
	Tables.Add(tattachmentkind);
	tattachmentkind.PrimaryKey =  new DataColumn[]{tattachmentkind.Columns["idattachmentkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{attachmentkind.Columns["idattachmentkind"]};
	var cChild = new []{ddt_inattachment.Columns["idattachmentkind"]};
	Relations.Add(new DataRelation("attachmentkind_ddt_inattachment",cPar,cChild,false));

	#endregion

}
}
}
