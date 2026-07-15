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
namespace metaeasylibrary {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dblist"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dblist: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable db 		=> Tables["db"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dblist(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dblist (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dblist";
	Prefix = "";
	Namespace = "http://tempuri.org/dblist.xsd";

	#region create DataTables
	//////////////////// DB /////////////////////////////////
	var tdb= new DataTable("db");
	tdb.Columns.Add( new DataColumn("description", typeof(string)));
	tdb.Columns.Add( new DataColumn("server", typeof(string)));
	tdb.Columns.Add( new DataColumn("database", typeof(string)));
	tdb.Columns.Add( new DataColumn("user", typeof(string)));
	tdb.Columns.Add( new DataColumn("department", typeof(string)));
	tdb.Columns.Add( new DataColumn("ldapserver", typeof(string)));
	tdb.Columns.Add( new DataColumn("ntuser", typeof(string)));
	Tables.Add(tdb);

	#endregion

}
}
}
