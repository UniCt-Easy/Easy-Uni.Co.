
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace checkup_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Diagnostica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable checkup 		=> Tables["checkup"];

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
	//////////////////// CHECKUP /////////////////////////////////
	var tcheckup= new DataTable("checkup");
	C= new DataColumn("idcheckup", typeof(int));
	C.AllowDBNull=false;
	tcheckup.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tcheckup.Columns.Add(C);
	tcheckup.Columns.Add( new DataColumn("description", typeof(string)));
	tcheckup.Columns.Add( new DataColumn("listerrors", typeof(string)));
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tcheckup.Columns.Add(C);
	tcheckup.Columns.Add( new DataColumn("listtype", typeof(string)));
	tcheckup.Columns.Add( new DataColumn("checkerrors", typeof(string)));
	tcheckup.Columns.Add( new DataColumn("corrige", typeof(string)));
	tcheckup.Columns.Add( new DataColumn("txt", typeof(string)));
	tcheckup.Columns.Add( new DataColumn("groupnumber", typeof(string)));
	tcheckup.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcheckup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcheckup.Columns.Add(C);
	tcheckup.Columns.Add( new DataColumn("edittype", typeof(string)));
	tcheckup.Columns.Add( new DataColumn("motive", typeof(string)));
	tcheckup.Columns.Add( new DataColumn("consequence", typeof(string)));
	Tables.Add(tcheckup);
	tcheckup.PrimaryKey =  new DataColumn[]{tcheckup.Columns["idcheckup"]};


	#endregion

}
}
}
