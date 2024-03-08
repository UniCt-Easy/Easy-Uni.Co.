
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
namespace wageadditionattachment_detail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable wageadditionattachment 		=> Tables["wageadditionattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable serviceattachmentkind 		=> Tables["serviceattachmentkind"];

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
	//////////////////// WAGEADDITIONATTACHMENT /////////////////////////////////
	var twageadditionattachment= new DataTable("wageadditionattachment");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	twageadditionattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	twageadditionattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	twageadditionattachment.Columns.Add( new DataColumn("idattachmentkind", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	Tables.Add(twageadditionattachment);
	twageadditionattachment.PrimaryKey =  new DataColumn[]{twageadditionattachment.Columns["ycon"], twageadditionattachment.Columns["ncon"], twageadditionattachment.Columns["idattachment"]};


	//////////////////// SERVICEATTACHMENTKIND /////////////////////////////////
	var tserviceattachmentkind= new DataTable("serviceattachmentkind");
	C= new DataColumn("idattachmentkind", typeof(int));
	C.AllowDBNull=false;
	tserviceattachmentkind.Columns.Add(C);
	tserviceattachmentkind.Columns.Add( new DataColumn("title", typeof(string)));
	tserviceattachmentkind.Columns.Add( new DataColumn("active", typeof(string)));
	tserviceattachmentkind.Columns.Add( new DataColumn("idser", typeof(int)));
	tserviceattachmentkind.Columns.Add( new DataColumn("flag", typeof(int)));
	tserviceattachmentkind.Columns.Add( new DataColumn("flagforced", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tserviceattachmentkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tserviceattachmentkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tserviceattachmentkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tserviceattachmentkind.Columns.Add(C);
	Tables.Add(tserviceattachmentkind);
	tserviceattachmentkind.PrimaryKey =  new DataColumn[]{tserviceattachmentkind.Columns["idattachmentkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{serviceattachmentkind.Columns["idattachmentkind"]};
	var cChild = new []{wageadditionattachment.Columns["idattachmentkind"]};
	Relations.Add(new DataRelation("serviceattachmentkind_wageadditionattachment",cPar,cChild,false));

	#endregion

}
}
}
