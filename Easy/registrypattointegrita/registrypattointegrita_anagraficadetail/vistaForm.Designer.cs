
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
namespace registrypattointegrita_anagraficadetail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrypattointegrita 		=> Tables["registrypattointegrita"];

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
	//////////////////// REGISTRYPATTOINTEGRITA /////////////////////////////////
	var tregistrypattointegrita= new DataTable("registrypattointegrita");
	C= new DataColumn("idregistrypattointegrita", typeof(int));
	C.AllowDBNull=false;
	tregistrypattointegrita.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrypattointegrita.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypattointegrita.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrypattointegrita.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypattointegrita.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrypattointegrita.Columns.Add(C);
	tregistrypattointegrita.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tregistrypattointegrita.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tregistrypattointegrita.Columns.Add( new DataColumn("pattointegritacertification", typeof(Byte[])));
	Tables.Add(tregistrypattointegrita);
	tregistrypattointegrita.PrimaryKey =  new DataColumn[]{tregistrypattointegrita.Columns["idregistrypattointegrita"], tregistrypattointegrita.Columns["idreg"]};


	#endregion

}
}
}