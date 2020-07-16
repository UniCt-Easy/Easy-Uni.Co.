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
namespace LiveUpdateSyncService {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaform"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaform: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sync 		=> Tables["sync"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable master 		=> Tables["master"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaform(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaform (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaform";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaform.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// SYNC /////////////////////////////////
	var tsync= new DataTable("sync");
	C= new DataColumn("id", typeof(int));
	C.AllowDBNull=false;
	tsync.Columns.Add(C);
	tsync.Columns.Add( new DataColumn("indirizzo", typeof(string)));
	tsync.Columns.Add( new DataColumn("port", typeof(string)));
	tsync.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tsync.Columns.Add( new DataColumn("user", typeof(string)));
	tsync.Columns.Add( new DataColumn("pwd", typeof(string)));
	tsync.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tsync);
	tsync.PrimaryKey =  new DataColumn[]{tsync.Columns["id"]};


	//////////////////// MASTER /////////////////////////////////
	var tmaster= new DataTable("master");
	tmaster.Columns.Add( new DataColumn("indirizzo", typeof(string)));
	tmaster.Columns.Add( new DataColumn("user", typeof(string)));
	tmaster.Columns.Add( new DataColumn("pwd", typeof(string)));
	tmaster.Columns.Add( new DataColumn("flaglocale", typeof(string)));
	Tables.Add(tmaster);

	#endregion

}
}
}
