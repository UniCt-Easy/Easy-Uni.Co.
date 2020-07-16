/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using System.Globalization;
namespace estimateattachment_default {
[System.CodeDom.Compiler.GeneratedCodeAttribute("HDSGene", "2.0")]
[DesignerCategoryAttribute("code")]
public partial class vista: System.Data.DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable estimateattachment		{get { return Tables["estimateattachment"];}}
	#endregion


[DebuggerNonUserCodeAttribute()]
public vista(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vista";
	Prefix = "";
	Namespace = "http://tempuri.org/vista.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// estimateattachment /////////////////////////////////
	T= new DataTable("estimateattachment");
	C= new DataColumn("idestimkind", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yestim", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nestim", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("filename", typeof(System.String)));
	T.Columns.Add( new DataColumn("attachment", typeof(System.Byte[])));
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idestimkind"], T.Columns["yestim"], T.Columns["nestim"], T.Columns["idattachment"]};


	#endregion

}
}
}
