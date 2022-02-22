
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
namespace itinerationrefundattachment_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("DataSet1"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class DataSet1: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundattachment 		=> Tables["itinerationrefundattachment"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public DataSet1(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected DataSet1 (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "DataSet1";
	Prefix = "";
	Namespace = "http://tempuri.org/DataSet1.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// ITINERATIONREFUNDATTACHMENT /////////////////////////////////
	var titinerationrefundattachment= new DataTable("itinerationrefundattachment");
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("nrefund", typeof(short));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	titinerationrefundattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	titinerationrefundattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	titinerationrefundattachment.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("lt", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	titinerationrefundattachment.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(titinerationrefundattachment);
	titinerationrefundattachment.PrimaryKey =  new DataColumn[]{titinerationrefundattachment.Columns["idattachment"], titinerationrefundattachment.Columns["iditineration"], titinerationrefundattachment.Columns["nrefund"]};


	#endregion

}
}
}
