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
namespace itinerationrefundattachmentkind_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundattachmentkind 		=> Tables["itinerationrefundattachmentkind"];

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
	//////////////////// ITINERATIONREFUNDATTACHMENTKIND /////////////////////////////////
	var titinerationrefundattachmentkind= new DataTable("itinerationrefundattachmentkind");
	C= new DataColumn("iditinerationrefundattachmentkind", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundattachmentkind.Columns.Add(C);
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("active", typeof(string)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("cu", typeof(string)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("lu", typeof(string)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("title", typeof(string)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("flag", typeof(int)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("code", typeof(string)));
	Tables.Add(titinerationrefundattachmentkind);
	titinerationrefundattachmentkind.PrimaryKey =  new DataColumn[]{titinerationrefundattachmentkind.Columns["iditinerationrefundattachmentkind"]};


	#endregion

}
}
}
