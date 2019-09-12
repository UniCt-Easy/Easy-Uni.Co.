/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace exportfunction_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Parametro della procedura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exportfunctionparam 		=> Tables["exportfunctionparam"];

	///<summary>
	///Procedure di esportazione su file ASCII o su Microsoft Excel
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exportfunction 		=> Tables["exportfunction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tmp_modulename 		=> Tables["tmp_modulename"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tmp_fileformat 		=> Tables["tmp_fileformat"];

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
	texportfunctionparam.Columns.Add( new DataColumn("iscombobox", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("datasource", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("valuemember", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("displaymember", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("noselectionforall", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("help", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("filter", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("cu", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texportfunctionparam.Columns.Add( new DataColumn("lu", typeof(string)));
	texportfunctionparam.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	texportfunctionparam.Columns.Add( new DataColumn("selectioncode", typeof(string)));
	Tables.Add(texportfunctionparam);
	texportfunctionparam.PrimaryKey =  new DataColumn[]{texportfunctionparam.Columns["procedurename"], texportfunctionparam.Columns["paramname"]};


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
	texportfunction.Columns.Add( new DataColumn("cu", typeof(string)));
	texportfunction.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texportfunction.Columns.Add( new DataColumn("lu", typeof(string)));
	texportfunction.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	texportfunction.Columns.Add( new DataColumn("timeout", typeof(int)));
	texportfunction.Columns.Add( new DataColumn("webvisible", typeof(string)));
	texportfunction.Columns.Add( new DataColumn("fileextension", typeof(string)));
	texportfunction.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(texportfunction);
	texportfunction.PrimaryKey =  new DataColumn[]{texportfunction.Columns["procedurename"]};


	//////////////////// TMP_MODULENAME /////////////////////////////////
	var ttmp_modulename= new DataTable("tmp_modulename");
	C= new DataColumn("modulename", typeof(string));
	C.AllowDBNull=false;
	ttmp_modulename.Columns.Add(C);
	Tables.Add(ttmp_modulename);
	ttmp_modulename.PrimaryKey =  new DataColumn[]{ttmp_modulename.Columns["modulename"]};


	//////////////////// TMP_FILEFORMAT /////////////////////////////////
	var ttmp_fileformat= new DataTable("tmp_fileformat");
	C= new DataColumn("fileformat", typeof(string));
	C.AllowDBNull=false;
	ttmp_fileformat.Columns.Add(C);
	ttmp_fileformat.Columns.Add( new DataColumn("description", typeof(string)));
	Tables.Add(ttmp_fileformat);
	ttmp_fileformat.PrimaryKey =  new DataColumn[]{ttmp_fileformat.Columns["fileformat"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{tmp_fileformat.Columns["fileformat"]};
	var cChild = new []{exportfunction.Columns["fileformat"]};
	Relations.Add(new DataRelation("tmp_fileformatexportfunction",cPar,cChild,false));

	cPar = new []{tmp_modulename.Columns["modulename"]};
	cChild = new []{exportfunction.Columns["modulename"]};
	Relations.Add(new DataRelation("tmp_modulenameexportfunction",cPar,cChild,false));

	cPar = new []{exportfunction.Columns["procedurename"]};
	cChild = new []{exportfunctionparam.Columns["procedurename"]};
	Relations.Add(new DataRelation("exportfunctionexportfunctionparam",cPar,cChild,false));

	#endregion

}
}
}
