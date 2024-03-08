
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


namespace LiveUpdate {
using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
[System.CodeDom.Compiler.GeneratedCodeAttribute("HDSGene", "2.0")]
[DesignerCategoryAttribute("code")]
public partial class DSScriptSQL: System.Data.DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable updatedbversion		{get { return Tables["updatedbversion"];}}
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable updatedbscript		{get { return Tables["updatedbscript"];}}
	#endregion


[DebuggerNonUserCodeAttribute()]
public DSScriptSQL(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "DSScriptSQL";
	Prefix = "";
	Namespace = "http://tempuri.org/DSScriptSQL.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// updatedbversion /////////////////////////////////
	T= new DataTable("updatedbversion");
	C= new DataColumn("versionname", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("swversion", typeof(System.String)));
	T.Columns.Add( new DataColumn("scriptlist", typeof(System.String)));
	T.Columns.Add( new DataColumn("description", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagerror", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagadmin", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["versionname"]};


	//////////////////// updatedbscript /////////////////////////////////
	T= new DataTable("updatedbscript");
	C= new DataColumn("versionname", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("scriptname", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("sql", typeof(System.String)));
	T.Columns.Add( new DataColumn("result", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["versionname"], T.Columns["scriptname"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{updatedbversion.Columns["versionname"]};
	CChild = new DataColumn[1]{updatedbscript.Columns["versionname"]};
	Relations.Add(new DataRelation("updatedbversionupdatedbscript",CPar,CChild));

	#endregion

}
}
}
