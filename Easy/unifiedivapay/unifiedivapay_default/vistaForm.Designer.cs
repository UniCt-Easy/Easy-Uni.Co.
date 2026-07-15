/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
namespace unifiedivapay_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unifiedivapay 		=> Tables["unifiedivapay"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable department 		=> Tables["department"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivaregisterkind 		=> Tables["ivaregisterkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unifiedivapaydetail 		=> Tables["unifiedivapaydetail"];

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
	//////////////////// UNIFIEDIVAPAY /////////////////////////////////
	var tunifiedivapay= new DataTable("unifiedivapay");
	C= new DataColumn("yunifiedivapay", typeof(int));
	C.AllowDBNull=false;
	tunifiedivapay.Columns.Add(C);
	C= new DataColumn("nunifiedivapay", typeof(int));
	C.AllowDBNull=false;
	tunifiedivapay.Columns.Add(C);
	C= new DataColumn("iddepartment", typeof(int));
	C.AllowDBNull=false;
	tunifiedivapay.Columns.Add(C);
	tunifiedivapay.Columns.Add( new DataColumn("assesmentdate", typeof(DateTime)));
	tunifiedivapay.Columns.Add( new DataColumn("creditamount", typeof(decimal)));
	tunifiedivapay.Columns.Add( new DataColumn("creditamountdeferred", typeof(decimal)));
	tunifiedivapay.Columns.Add( new DataColumn("debitamount", typeof(decimal)));
	tunifiedivapay.Columns.Add( new DataColumn("debitamountdeferred", typeof(decimal)));
	tunifiedivapay.Columns.Add( new DataColumn("paymentamount", typeof(decimal)));
	tunifiedivapay.Columns.Add( new DataColumn("refundamount", typeof(decimal)));
	C= new DataColumn("paymentkind", typeof(string));
	C.AllowDBNull=false;
	tunifiedivapay.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedivapay.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedivapay.Columns.Add(C);
	tunifiedivapay.Columns.Add( new DataColumn("paymentdetails", typeof(string)));
	tunifiedivapay.Columns.Add( new DataColumn("mixed", typeof(decimal)));
	tunifiedivapay.Columns.Add( new DataColumn("prorata", typeof(decimal)));
	tunifiedivapay.Columns.Add( new DataColumn("dateivapay", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedivapay.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunifiedivapay.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedivapay.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunifiedivapay.Columns.Add(C);
	Tables.Add(tunifiedivapay);
	tunifiedivapay.PrimaryKey =  new DataColumn[]{tunifiedivapay.Columns["yunifiedivapay"], tunifiedivapay.Columns["nunifiedivapay"], tunifiedivapay.Columns["iddepartment"]};


	//////////////////// DEPARTMENT /////////////////////////////////
	var tdepartment= new DataTable("department");
	C= new DataColumn("iddepartment", typeof(int));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	tdepartment.Columns.Add( new DataColumn("server", typeof(string)));
	tdepartment.Columns.Add( new DataColumn("db", typeof(string)));
	tdepartment.Columns.Add( new DataColumn("userdep", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tdepartment.Columns.Add(C);
	Tables.Add(tdepartment);
	tdepartment.PrimaryKey =  new DataColumn[]{tdepartment.Columns["iddepartment"]};


	//////////////////// IVAREGISTERKIND /////////////////////////////////
	var tivaregisterkind= new DataTable("ivaregisterkind");
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	tivaregisterkind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("registerclass", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("idivaregisterkindunified", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	tivaregisterkind.Columns.Add( new DataColumn("emails", typeof(string)));
	Tables.Add(tivaregisterkind);
	tivaregisterkind.PrimaryKey =  new DataColumn[]{tivaregisterkind.Columns["idivaregisterkind"]};


	//////////////////// UNIFIEDIVAPAYDETAIL /////////////////////////////////
	var tunifiedivapaydetail= new DataTable("unifiedivapaydetail");
	C= new DataColumn("yunifiedivapay", typeof(int));
	C.AllowDBNull=false;
	tunifiedivapaydetail.Columns.Add(C);
	C= new DataColumn("nunifiedivapay", typeof(int));
	C.AllowDBNull=false;
	tunifiedivapaydetail.Columns.Add(C);
	C= new DataColumn("idivaregisterkindunified", typeof(string));
	C.AllowDBNull=false;
	tunifiedivapaydetail.Columns.Add(C);
	C= new DataColumn("iddepartment", typeof(int));
	C.AllowDBNull=false;
	tunifiedivapaydetail.Columns.Add(C);
	tunifiedivapaydetail.Columns.Add( new DataColumn("iva", typeof(decimal)));
	tunifiedivapaydetail.Columns.Add( new DataColumn("ivadeferred", typeof(decimal)));
	tunifiedivapaydetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tunifiedivapaydetail.Columns.Add( new DataColumn("unabatabledeferred", typeof(decimal)));
	tunifiedivapaydetail.Columns.Add( new DataColumn("ivanet", typeof(decimal)));
	tunifiedivapaydetail.Columns.Add( new DataColumn("ivanetdeferred", typeof(decimal)));
	tunifiedivapaydetail.Columns.Add( new DataColumn("prorata", typeof(decimal)));
	tunifiedivapaydetail.Columns.Add( new DataColumn("mixed", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedivapaydetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunifiedivapaydetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedivapaydetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunifiedivapaydetail.Columns.Add(C);
	tunifiedivapaydetail.Columns.Add( new DataColumn("!ivacredit", typeof(decimal)));
	tunifiedivapaydetail.Columns.Add( new DataColumn("!department", typeof(string)));
	tunifiedivapaydetail.Columns.Add( new DataColumn("!registerkindunified", typeof(string)));
	tunifiedivapaydetail.Columns.Add( new DataColumn("!registerclass", typeof(string)));
	Tables.Add(tunifiedivapaydetail);
	tunifiedivapaydetail.PrimaryKey =  new DataColumn[]{tunifiedivapaydetail.Columns["yunifiedivapay"], tunifiedivapaydetail.Columns["nunifiedivapay"], tunifiedivapaydetail.Columns["idivaregisterkindunified"], tunifiedivapaydetail.Columns["iddepartment"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{ivaregisterkind.Columns["idivaregisterkindunified"]};
	var cChild = new []{unifiedivapaydetail.Columns["idivaregisterkindunified"]};
	Relations.Add(new DataRelation("ivaregisterkindunifiedivapaydetail",cPar,cChild,false));

	cPar = new []{unifiedivapay.Columns["yunifiedivapay"], unifiedivapay.Columns["nunifiedivapay"], unifiedivapay.Columns["iddepartment"]};
	cChild = new []{unifiedivapaydetail.Columns["yunifiedivapay"], unifiedivapaydetail.Columns["nunifiedivapay"], unifiedivapaydetail.Columns["iddepartment"]};
	Relations.Add(new DataRelation("unifiedivapayunifiedivapaydetail",cPar,cChild,false));

	cPar = new []{department.Columns["iddepartment"]};
	cChild = new []{unifiedivapaydetail.Columns["iddepartment"]};
	Relations.Add(new DataRelation("departmentunifiedivapaydetail",cPar,cChild,false));

	cPar = new []{department.Columns["iddepartment"]};
	cChild = new []{unifiedivapay.Columns["iddepartment"]};
	Relations.Add(new DataRelation("departmentunifiedivapay",cPar,cChild,false));

	#endregion

}
}
}
