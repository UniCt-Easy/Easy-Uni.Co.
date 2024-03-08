
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
namespace dbaccess_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///elenco utenti che hanno accesso al db
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dbaccess 		=> Tables["dbaccess"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable combo_dbaccess 		=> Tables["combo_dbaccess"];

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
	//////////////////// DBACCESS /////////////////////////////////
	var tdbaccess= new DataTable("dbaccess");
	tdbaccess.Columns.Add( new DataColumn("alpha1", typeof(string)));
	C= new DataColumn("iddbdepartment", typeof(string));
	C.AllowDBNull=false;
	tdbaccess.Columns.Add(C);
	C= new DataColumn("login", typeof(string));
	C.AllowDBNull=false;
	tdbaccess.Columns.Add(C);
	tdbaccess.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdbaccess.Columns.Add( new DataColumn("lu", typeof(string)));
	tdbaccess.Columns.Add( new DataColumn("pwdlastmod", typeof(DateTime)));
	tdbaccess.Columns.Add( new DataColumn("pwdmaxage", typeof(int)));
	tdbaccess.Columns.Add( new DataColumn("pwdwarning", typeof(int)));
	Tables.Add(tdbaccess);
	tdbaccess.PrimaryKey =  new DataColumn[]{tdbaccess.Columns["iddbdepartment"], tdbaccess.Columns["login"]};


	//////////////////// COMBO_DBACCESS /////////////////////////////////
	var tcombo_dbaccess= new DataTable("combo_dbaccess");
	tcombo_dbaccess.Columns.Add( new DataColumn("alpha1", typeof(string)));
	C= new DataColumn("iddbdepartment", typeof(string));
	C.AllowDBNull=false;
	tcombo_dbaccess.Columns.Add(C);
	C= new DataColumn("login", typeof(string));
	C.AllowDBNull=false;
	tcombo_dbaccess.Columns.Add(C);
	tcombo_dbaccess.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcombo_dbaccess.Columns.Add( new DataColumn("lu", typeof(string)));
	tcombo_dbaccess.Columns.Add( new DataColumn("pwdlastmod", typeof(DateTime)));
	tcombo_dbaccess.Columns.Add( new DataColumn("pwdmaxage", typeof(int)));
	tcombo_dbaccess.Columns.Add( new DataColumn("pwdwarning", typeof(int)));
	Tables.Add(tcombo_dbaccess);
	tcombo_dbaccess.PrimaryKey =  new DataColumn[]{tcombo_dbaccess.Columns["iddbdepartment"], tcombo_dbaccess.Columns["login"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{combo_dbaccess.Columns["iddbdepartment"], combo_dbaccess.Columns["login"]};
	var cChild = new []{dbaccess.Columns["iddbdepartment"], dbaccess.Columns["login"]};
	Relations.Add(new DataRelation("combo_dbaccess_dbaccess",cPar,cChild,false));

	#endregion

}
}
}
