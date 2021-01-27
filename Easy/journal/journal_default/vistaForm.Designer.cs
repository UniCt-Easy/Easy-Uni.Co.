
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace journal_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Log delle transazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable journal 		=> Tables["journal"];

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
	//////////////////// JOURNAL /////////////////////////////////
	var tjournal= new DataTable("journal");
	C= new DataColumn("fieldname", typeof(string));
	C.AllowDBNull=false;
	tjournal.Columns.Add(C);
	C= new DataColumn("operationdatetime", typeof(DateTime));
	C.AllowDBNull=false;
	tjournal.Columns.Add(C);
	C= new DataColumn("opkind", typeof(string));
	C.AllowDBNull=false;
	tjournal.Columns.Add(C);
	C= new DataColumn("primarykey", typeof(string));
	C.AllowDBNull=false;
	tjournal.Columns.Add(C);
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tjournal.Columns.Add(C);
	tjournal.Columns.Add( new DataColumn("computername", typeof(string)));
	tjournal.Columns.Add( new DataColumn("computeruser", typeof(string)));
	tjournal.Columns.Add( new DataColumn("dbuser", typeof(string)));
	tjournal.Columns.Add( new DataColumn("notes", typeof(string)));
	tjournal.Columns.Add( new DataColumn("oldvalue", typeof(string)));
	tjournal.Columns.Add( new DataColumn("olenotes", typeof(Byte[])));
	tjournal.Columns.Add( new DataColumn("value", typeof(string)));
	C= new DataColumn("iddbdepartment", typeof(string));
	C.AllowDBNull=false;
	tjournal.Columns.Add(C);
	tjournal.Columns.Add( new DataColumn("idflowchart", typeof(string)));
	Tables.Add(tjournal);
	tjournal.PrimaryKey =  new DataColumn[]{tjournal.Columns["fieldname"], tjournal.Columns["operationdatetime"], tjournal.Columns["opkind"], tjournal.Columns["primarykey"], tjournal.Columns["tablename"], tjournal.Columns["iddbdepartment"]};


	#endregion

}
}
}
