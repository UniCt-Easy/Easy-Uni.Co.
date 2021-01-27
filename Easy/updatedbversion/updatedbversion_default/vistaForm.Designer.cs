
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
namespace updatedbversion_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Gestione versioni Database
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable updatedbversion 		=> Tables["updatedbversion"];

	///<summary>
	///Script SQL
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable updatedbscript 		=> Tables["updatedbscript"];

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
	//////////////////// UPDATEDBVERSION /////////////////////////////////
	var tupdatedbversion= new DataTable("updatedbversion");
	C= new DataColumn("versionname", typeof(string));
	C.AllowDBNull=false;
	tupdatedbversion.Columns.Add(C);
	tupdatedbversion.Columns.Add( new DataColumn("swversion", typeof(string)));
	tupdatedbversion.Columns.Add( new DataColumn("scriptlist", typeof(string)));
	tupdatedbversion.Columns.Add( new DataColumn("description", typeof(string)));
	tupdatedbversion.Columns.Add( new DataColumn("flagerror", typeof(string)));
	tupdatedbversion.Columns.Add( new DataColumn("flagadmin", typeof(string)));
	Tables.Add(tupdatedbversion);
	tupdatedbversion.PrimaryKey =  new DataColumn[]{tupdatedbversion.Columns["versionname"]};


	//////////////////// UPDATEDBSCRIPT /////////////////////////////////
	var tupdatedbscript= new DataTable("updatedbscript");
	C= new DataColumn("versionname", typeof(string));
	C.AllowDBNull=false;
	tupdatedbscript.Columns.Add(C);
	C= new DataColumn("scriptname", typeof(string));
	C.AllowDBNull=false;
	tupdatedbscript.Columns.Add(C);
	tupdatedbscript.Columns.Add( new DataColumn("sql", typeof(string)));
	tupdatedbscript.Columns.Add( new DataColumn("result", typeof(string)));
	Tables.Add(tupdatedbscript);
	tupdatedbscript.PrimaryKey =  new DataColumn[]{tupdatedbscript.Columns["versionname"], tupdatedbscript.Columns["scriptname"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{updatedbversion.Columns["versionname"]};
	var cChild = new []{updatedbscript.Columns["versionname"]};
	Relations.Add(new DataRelation("updatedbversionupdatedbscript",cPar,cChild,false));

	#endregion

}
}
}
