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

namespace no_table_wiz_fillunified {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable unifiedtax{get { return this.Tables["unifiedtax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable unifiedtaxcorrige{get { return this.Tables["unifiedtaxcorrige"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable no_table{get { return this.Tables["no_table"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaForm(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "vistaForm";
this.Prefix = "";
this.Namespace = "http://tempuri.org/vistaForm.xsd";
this.EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("unifiedtax");
	C= new DataColumn("idunifiedtax", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbracket", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("abatements", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("admindenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("admintax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employdenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employtax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxabledenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablegross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("exemptionquota", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("competencydate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ayear", typeof(System.Int16), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nmonth", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("iddbdepartment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("servicestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("servicestop", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idunifiedtax"]};
	T.PrimaryKey = key;

	T= new DataTable("unifiedtaxcorrige");
	C= new DataColumn("idunifiedtaxcorrige", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexpensetaxcorrige", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ayear", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("employamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("adate", typeof(System.DateTime), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nmonth", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("servicestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("servicestop", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idunifiedtaxcorrige"]};
	T.PrimaryKey = key;

	T= new DataTable("no_table");
	C= new DataColumn("id_no_table", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["id_no_table"]};
	T.PrimaryKey = key;

}
}
}
