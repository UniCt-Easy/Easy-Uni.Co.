
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
namespace mod770_details_certificazioneunica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Modello 770
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mod770_details 		=> Tables["mod770_details"];

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
	//////////////////// MOD770_DETAILS /////////////////////////////////
	var tmod770_details= new DataTable("mod770_details");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tmod770_details.Columns.Add(C);
	C= new DataColumn("frame", typeof(string));
	C.AllowDBNull=false;
	tmod770_details.Columns.Add(C);
	C= new DataColumn("colnumber", typeof(string));
	C.AllowDBNull=false;
	tmod770_details.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmod770_details.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmod770_details.Columns.Add(C);
	tmod770_details.Columns.Add( new DataColumn("description", typeof(string)));
	tmod770_details.Columns.Add( new DataColumn("fieldlen", typeof(int)));
	tmod770_details.Columns.Add( new DataColumn("format", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmod770_details.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmod770_details.Columns.Add(C);
	tmod770_details.Columns.Add( new DataColumn("colorder", typeof(int)));
	tmod770_details.Columns.Add( new DataColumn("row", typeof(string)));
	tmod770_details.Columns.Add( new DataColumn("position", typeof(int)));
	tmod770_details.Columns.Add( new DataColumn("section", typeof(string)));
	tmod770_details.Columns.Add( new DataColumn("admittedvalues", typeof(string)));
	tmod770_details.Columns.Add( new DataColumn("blockingcontrols", typeof(string)));
	tmod770_details.Columns.Add( new DataColumn("correspondence", typeof(string)));
	Tables.Add(tmod770_details);
	tmod770_details.PrimaryKey =  new DataColumn[]{tmod770_details.Columns["ayear"], tmod770_details.Columns["frame"], tmod770_details.Columns["colnumber"]};


	#endregion

}
}
}
