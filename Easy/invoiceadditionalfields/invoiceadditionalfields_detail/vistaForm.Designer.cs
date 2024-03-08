
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
namespace invoiceadditionalfields_detail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoiceadditionalfields 		=> Tables["invoiceadditionalfields"];

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
	//////////////////// INVOICEADDITIONALFIELDS /////////////////////////////////
	var tinvoiceadditionalfields= new DataTable("invoiceadditionalfields");
	C= new DataColumn("idadditionalfields", typeof(int));
	C.AllowDBNull=false;
	tinvoiceadditionalfields.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoiceadditionalfields.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoiceadditionalfields.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoiceadditionalfields.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoiceadditionalfields.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoiceadditionalfields.Columns.Add(C);
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield1date", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield1int", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield1str", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield2date", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield2int", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield2str", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield3date", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield3int", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield3str", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield4date", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield4int", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield4str", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield5date", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield5int", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("labelfield5str", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoiceadditionalfields.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoiceadditionalfields.Columns.Add(C);
	tinvoiceadditionalfields.Columns.Add( new DataColumn("rownum", typeof(int)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield1date", typeof(DateTime)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield1int", typeof(int)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield1str", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield2date", typeof(DateTime)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield2int", typeof(int)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield2str", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield3date", typeof(DateTime)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield3int", typeof(int)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield3str", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield4date", typeof(DateTime)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield4int", typeof(int)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield4str", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield5date", typeof(DateTime)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield5int", typeof(int)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("valuefield5str", typeof(string)));
	tinvoiceadditionalfields.Columns.Add( new DataColumn("documentkind", typeof(string)));
	Tables.Add(tinvoiceadditionalfields);
	tinvoiceadditionalfields.PrimaryKey =  new DataColumn[]{tinvoiceadditionalfields.Columns["idadditionalfields"], tinvoiceadditionalfields.Columns["idinvkind"], tinvoiceadditionalfields.Columns["yinv"], tinvoiceadditionalfields.Columns["ninv"]};


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
	C= new DataColumn("documentkind", typeof(string));
	C.AllowDBNull=false;
	tinvoicemultifieldkind.Columns.Add(C);
	Tables.Add(tinvoicemultifieldkind);
	tinvoicemultifieldkind.PrimaryKey =  new DataColumn[]{tinvoicemultifieldkind.Columns["idmultifieldkind"]};


	#endregion

}
}
}
