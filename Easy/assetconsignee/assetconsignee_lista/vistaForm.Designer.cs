
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
namespace assetconsignee_lista {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventoryagency 		=> Tables["inventoryagency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetconsignee 		=> Tables["assetconsignee"];

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
	//////////////////// INVENTORYAGENCY /////////////////////////////////
	var tinventoryagency= new DataTable("inventoryagency");
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	tinventoryagency.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tinventoryagency.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tinventoryagency);
	tinventoryagency.PrimaryKey =  new DataColumn[]{tinventoryagency.Columns["idinventoryagency"]};


	//////////////////// ASSETCONSIGNEE /////////////////////////////////
	var tassetconsignee= new DataTable("assetconsignee");
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tassetconsignee.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tassetconsignee.Columns.Add(C);
	tassetconsignee.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tassetconsignee.Columns.Add( new DataColumn("lu", typeof(string)));
	tassetconsignee.Columns.Add( new DataColumn("qualification", typeof(string)));
	tassetconsignee.Columns.Add( new DataColumn("title", typeof(string)));
	tassetconsignee.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tassetconsignee);
	tassetconsignee.PrimaryKey =  new DataColumn[]{tassetconsignee.Columns["idinventoryagency"], tassetconsignee.Columns["start"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{inventoryagency.Columns["idinventoryagency"]};
	var cChild = new []{assetconsignee.Columns["idinventoryagency"]};
	Relations.Add(new DataRelation("inventoryagencyassetconsignee",cPar,cChild,false));

	#endregion

}
}
}
