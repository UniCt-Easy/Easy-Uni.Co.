
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
namespace invoicemultifieldkind_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicemultifieldkind 		=> Tables["invoicemultifieldkind"];

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
	//////////////////// INVOICEMULTIFIELDKIND /////////////////////////////////
	var tinvoicemultifieldkind= new DataTable("invoicemultifieldkind");
	C= new DataColumn("idmultifieldkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicemultifieldkind.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tinvoicemultifieldkind.Columns.Add(C);
	C= new DataColumn("allownull", typeof(string));
	C.AllowDBNull=false;
	tinvoicemultifieldkind.Columns.Add(C);
	C= new DataColumn("fieldcode", typeof(string));
	C.AllowDBNull=false;
	tinvoicemultifieldkind.Columns.Add(C);
	C= new DataColumn("fieldname", typeof(string));
	C.AllowDBNull=false;
	tinvoicemultifieldkind.Columns.Add(C);
	tinvoicemultifieldkind.Columns.Add( new DataColumn("len", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicemultifieldkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicemultifieldkind.Columns.Add(C);
	tinvoicemultifieldkind.Columns.Add( new DataColumn("ordernumber", typeof(short)));
	C= new DataColumn("systype", typeof(string));
	C.AllowDBNull=false;
	tinvoicemultifieldkind.Columns.Add(C);
	tinvoicemultifieldkind.Columns.Add( new DataColumn("tabname", typeof(string)));
	tinvoicemultifieldkind.Columns.Add( new DataColumn("tag", typeof(string)));
	tinvoicemultifieldkind.Columns.Add( new DataColumn("documentkind", typeof(string)));
	Tables.Add(tinvoicemultifieldkind);
	tinvoicemultifieldkind.PrimaryKey =  new DataColumn[]{tinvoicemultifieldkind.Columns["idmultifieldkind"]};


	#endregion

}
}
}
