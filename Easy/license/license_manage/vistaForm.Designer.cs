/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace license_manage {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Informazioni ente contabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable license 		=> Tables["license"];

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
	//////////////////// LICENSE /////////////////////////////////
	var tlicense= new DataTable("license");
	tlicense.Columns.Add( new DataColumn("departmentname", typeof(string)));
	tlicense.Columns.Add( new DataColumn("agencyname", typeof(string)));
	tlicense.Columns.Add( new DataColumn("address1", typeof(string)));
	tlicense.Columns.Add( new DataColumn("address2", typeof(string)));
	tlicense.Columns.Add( new DataColumn("cap", typeof(string)));
	tlicense.Columns.Add( new DataColumn("location", typeof(string)));
	tlicense.Columns.Add( new DataColumn("country", typeof(string)));
	tlicense.Columns.Add( new DataColumn("cf", typeof(string)));
	tlicense.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tlicense.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tlicense.Columns.Add( new DataColumn("idreg", typeof(int)));
	tlicense.Columns.Add( new DataColumn("sent", typeof(string)));
	tlicense.Columns.Add( new DataColumn("swmorecode", typeof(string)));
	tlicense.Columns.Add( new DataColumn("swmoreflag", typeof(int)));
	tlicense.Columns.Add( new DataColumn("iddb", typeof(int)));
	tlicense.Columns.Add( new DataColumn("servername", typeof(string)));
	tlicense.Columns.Add( new DataColumn("dbname", typeof(string)));
	tlicense.Columns.Add( new DataColumn("lickind", typeof(string)));
	tlicense.Columns.Add( new DataColumn("expiringlic", typeof(DateTime)));
	tlicense.Columns.Add( new DataColumn("licstatus", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checklic", typeof(string)));
	tlicense.Columns.Add( new DataColumn("mankind", typeof(string)));
	tlicense.Columns.Add( new DataColumn("expiringman", typeof(DateTime)));
	tlicense.Columns.Add( new DataColumn("manstatus", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkman", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkflag", typeof(string)));
	tlicense.Columns.Add( new DataColumn("agency", typeof(string)));
	tlicense.Columns.Add( new DataColumn("department", typeof(string)));
	tlicense.Columns.Add( new DataColumn("referent", typeof(string)));
	tlicense.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tlicense.Columns.Add( new DataColumn("fax", typeof(string)));
	tlicense.Columns.Add( new DataColumn("email", typeof(string)));
	tlicense.Columns.Add( new DataColumn("annotations", typeof(string)));
	tlicense.Columns.Add( new DataColumn("nmsgs", typeof(int)));
	C= new DataColumn("dummykey", typeof(string));
	C.AllowDBNull=false;
	tlicense.Columns.Add(C);
	tlicense.Columns.Add( new DataColumn("serverbackup1", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkbackup1", typeof(string)));
	tlicense.Columns.Add( new DataColumn("serverbackup2", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkbackup2", typeof(string)));
	tlicense.Columns.Add( new DataColumn("lu", typeof(string)));
	tlicense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tlicense);
	tlicense.PrimaryKey =  new DataColumn[]{tlicense.Columns["dummykey"]};


	#endregion

}
}
}
