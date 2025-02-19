
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
namespace userenvironment_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Variabili d'ambiente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable userenvironment 		=> Tables["userenvironment"];

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
	//////////////////// USERENVIRONMENT /////////////////////////////////
	var tuserenvironment= new DataTable("userenvironment");
	C= new DataColumn("variablename", typeof(string));
	C.AllowDBNull=false;
	tuserenvironment.Columns.Add(C);
	C= new DataColumn("idcustomuser", typeof(string));
	C.AllowDBNull=false;
	tuserenvironment.Columns.Add(C);
	tuserenvironment.Columns.Add( new DataColumn("value", typeof(string)));
	C= new DataColumn("flagadmin", typeof(string));
	C.AllowDBNull=false;
	tuserenvironment.Columns.Add(C);
	C= new DataColumn("kind", typeof(string));
	C.AllowDBNull=false;
	tuserenvironment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tuserenvironment.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tuserenvironment.Columns.Add(C);
	Tables.Add(tuserenvironment);
	tuserenvironment.PrimaryKey =  new DataColumn[]{tuserenvironment.Columns["variablename"], tuserenvironment.Columns["idcustomuser"]};


	#endregion

}
}
}
