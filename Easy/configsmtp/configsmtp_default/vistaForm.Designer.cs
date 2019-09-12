/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace configsmtp_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Gestione Notifiche
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable configsmtp 		=> Tables["configsmtp"];

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
	//////////////////// CONFIGSMTP /////////////////////////////////
	var tconfigsmtp= new DataTable("configsmtp");
	C= new DataColumn("dummykey", typeof(int));
	C.AllowDBNull=false;
	tconfigsmtp.Columns.Add(C);
	C= new DataColumn("server", typeof(string));
	C.AllowDBNull=false;
	tconfigsmtp.Columns.Add(C);
	C= new DataColumn("login", typeof(string));
	C.AllowDBNull=false;
	tconfigsmtp.Columns.Add(C);
	C= new DataColumn("password", typeof(string));
	C.AllowDBNull=false;
	tconfigsmtp.Columns.Add(C);
	C= new DataColumn("port", typeof(int));
	C.AllowDBNull=false;
	tconfigsmtp.Columns.Add(C);
	tconfigsmtp.Columns.Add( new DataColumn("flagsend", typeof(string)));
	tconfigsmtp.Columns.Add( new DataColumn("sqlattachmentspath", typeof(string)));
	tconfigsmtp.Columns.Add( new DataColumn("server_cu", typeof(string)));
	tconfigsmtp.Columns.Add( new DataColumn("login_cu", typeof(string)));
	tconfigsmtp.Columns.Add( new DataColumn("password_cu", typeof(string)));
	tconfigsmtp.Columns.Add( new DataColumn("port_cu", typeof(int)));
	tconfigsmtp.Columns.Add( new DataColumn("flagsend_cu", typeof(string)));
	tconfigsmtp.Columns.Add( new DataColumn("sqlattachmentspath_cu", typeof(string)));
	Tables.Add(tconfigsmtp);
	tconfigsmtp.PrimaryKey =  new DataColumn[]{tconfigsmtp.Columns["dummykey"]};


	#endregion

}
}
}
