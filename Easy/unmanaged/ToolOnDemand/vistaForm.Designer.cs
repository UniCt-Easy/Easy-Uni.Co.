
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
namespace ToolOnDemand {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable update 		=> Tables["update"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fileupdate 		=> Tables["fileupdate"];

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
	//////////////////// UPDATE /////////////////////////////////
	var tupdate= new DataTable("update");
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tupdate.Columns.Add(C);
	tupdate.Columns.Add( new DataColumn("shortdescription", typeof(string)));
	tupdate.Columns.Add( new DataColumn("description", typeof(string)));
	tupdate.Columns.Add( new DataColumn("publishingdate", typeof(DateTime)));
	tupdate.Columns.Add( new DataColumn("flagkind", typeof(string)));
	tupdate.Columns.Add( new DataColumn("flagannullato", typeof(string)));
	tupdate.Columns.Add( new DataColumn("dbversion", typeof(string)));
	Tables.Add(tupdate);
	tupdate.PrimaryKey =  new DataColumn[]{tupdate.Columns["code"]};


	//////////////////// FILEUPDATE /////////////////////////////////
	var tfileupdate= new DataTable("fileupdate");
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tfileupdate.Columns.Add(C);
	C= new DataColumn("progressivo", typeof(int));
	C.AllowDBNull=false;
	tfileupdate.Columns.Add(C);
	tfileupdate.Columns.Add( new DataColumn("filename", typeof(string)));
	tfileupdate.Columns.Add( new DataColumn("filekind", typeof(string)));
	Tables.Add(tfileupdate);
	tfileupdate.PrimaryKey =  new DataColumn[]{tfileupdate.Columns["code"], tfileupdate.Columns["progressivo"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{update.Columns["code"]};
	var cChild = new []{fileupdate.Columns["code"]};
	Relations.Add(new DataRelation("updatefileupdate",cPar,cChild,false));

	#endregion

}
}
}
