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
namespace export_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exportfunction 		=> Tables["exportfunction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exportfunctionparam 		=> Tables["exportfunctionparam"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable columntypes 		=> Tables["columntypes"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable customselection 		=> Tables["customselection"];

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
	//////////////////// EXPORTFUNCTION /////////////////////////////////
	var texportfunction= new DataTable("exportfunction");
	C= new DataColumn("procedurename", typeof(string));
	C.AllowDBNull=false;
	texportfunction.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texportfunction.Columns.Add(C);
	C= new DataColumn("modulename", typeof(string));
	C.AllowDBNull=false;
	texportfunction.Columns.Add(C);
	texportfunction.Columns.Add( new DataColumn("fileformat", typeof(string)));
	texportfunction.Columns.Add( new DataColumn("timeout", typeof(int)));
	texportfunction.Columns.Add( new DataColumn("fileextension", typeof(string)));
	Tables.Add(texportfunction);
	texportfunction.PrimaryKey =  new DataColumn[]{texportfunction.Columns["procedurename"]};


	//////////////////// EXPORTFUNCTIONPARAM /////////////////////////////////
	var texportfunctionparam= new DataTable("exportfunctionparam");
	C= new DataColumn("procedurename", typeof(string));
	C.AllowDBNull=false;
	texportfunctionparam.Columns.Add(C);
	C= new DataColumn("paramname", typeof(string));
	C.AllowDBNull=false;
	texportfunctionparam.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texportfunctionparam.Columns.Add(C);
	texportfunctionparam.Columns.Add( new DataColumn("systype", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("tag", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("hintkind", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("hint", typeof(string)));
	C= new DataColumn("number", typeof(short));
	C.AllowDBNull=false;
	texportfunctionparam.Columns.Add(C);
	C= new DataColumn("iscombobox", typeof(string));
	C.AllowDBNull=false;
	texportfunctionparam.Columns.Add(C);
	texportfunctionparam.Columns.Add( new DataColumn("datasource", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("valuemember", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("displaymember", typeof(string)));
	C= new DataColumn("noselectionforall", typeof(string));
	C.AllowDBNull=false;
	texportfunctionparam.Columns.Add(C);
	texportfunctionparam.Columns.Add( new DataColumn("help", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("filter", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("cu", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texportfunctionparam.Columns.Add( new DataColumn("lu", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	texportfunctionparam.Columns.Add( new DataColumn("selectioncode", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("master", typeof(string)));
	Tables.Add(texportfunctionparam);
	texportfunctionparam.PrimaryKey =  new DataColumn[]{texportfunctionparam.Columns["procedurename"], texportfunctionparam.Columns["paramname"]};


	//////////////////// COLUMNTYPES /////////////////////////////////
	var tcolumntypes= new DataTable("columntypes");
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	C= new DataColumn("field", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	C= new DataColumn("iskey", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	C= new DataColumn("sqltype", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	tcolumntypes.Columns.Add( new DataColumn("col_len", typeof(int)));
	tcolumntypes.Columns.Add( new DataColumn("col_precision", typeof(int)));
	tcolumntypes.Columns.Add( new DataColumn("col_scale", typeof(int)));
	tcolumntypes.Columns.Add( new DataColumn("systemtype", typeof(string)));
	C= new DataColumn("sqldeclaration", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	C= new DataColumn("allownull", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	tcolumntypes.Columns.Add( new DataColumn("defaultvalue", typeof(string)));
	tcolumntypes.Columns.Add( new DataColumn("format", typeof(string)));
	C= new DataColumn("denynull", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	tcolumntypes.Columns.Add( new DataColumn("lastmoduser", typeof(string)));
	tcolumntypes.Columns.Add( new DataColumn("lastmodtimestamp", typeof(DateTime)));
	tcolumntypes.Columns.Add( new DataColumn("createuser", typeof(string)));
	tcolumntypes.Columns.Add( new DataColumn("createtimestamp", typeof(DateTime)));
	Tables.Add(tcolumntypes);
	tcolumntypes.PrimaryKey =  new DataColumn[]{tcolumntypes.Columns["tablename"], tcolumntypes.Columns["field"]};


	//////////////////// CUSTOMSELECTION /////////////////////////////////
	var tcustomselection= new DataTable("customselection");
	C= new DataColumn("selectioncode", typeof(string));
	C.AllowDBNull=false;
	tcustomselection.Columns.Add(C);
	tcustomselection.Columns.Add( new DataColumn("editlisttype", typeof(string)));
	tcustomselection.Columns.Add( new DataColumn("extraparameter", typeof(string)));
	tcustomselection.Columns.Add( new DataColumn("fieldname", typeof(string)));
	tcustomselection.Columns.Add( new DataColumn("filter", typeof(string)));
	tcustomselection.Columns.Add( new DataColumn("lastmodtimestamp", typeof(DateTime)));
	tcustomselection.Columns.Add( new DataColumn("lastmoduser", typeof(string)));
	tcustomselection.Columns.Add( new DataColumn("relationfield", typeof(string)));
	tcustomselection.Columns.Add( new DataColumn("selectionname", typeof(string)));
	tcustomselection.Columns.Add( new DataColumn("selectiontype", typeof(string)));
	tcustomselection.Columns.Add( new DataColumn("tablename", typeof(string)));
	Tables.Add(tcustomselection);
	tcustomselection.PrimaryKey =  new DataColumn[]{tcustomselection.Columns["selectioncode"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{columntypes.Columns["tablename"]};
	var cChild = new []{exportfunctionparam.Columns["datasource"]};
	Relations.Add(new DataRelation("columntypesexportfunctionparam",cPar,cChild,false));

	cPar = new []{exportfunction.Columns["procedurename"]};
	cChild = new []{exportfunctionparam.Columns["procedurename"]};
	Relations.Add(new DataRelation("exportfunctionexportfunctionparam",cPar,cChild,false));

	#endregion

}
}
}
