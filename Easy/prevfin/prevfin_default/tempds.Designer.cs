
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


namespace prevfin_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tempds: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable prevfindetail{get { return this.Tables["prevfindetail"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public tempds(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "tempds";
this.Prefix = "";
this.Namespace = "http://tempuri.org/tempds.xsd";
this.EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("prevfindetail");
	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("codefin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("floatfund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedpayments", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedproceeds", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedexpenditure", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedrevenue", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("incometopartitioncompetency", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("incometopartitioncash", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("cash", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("competency", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedcreditsurplus", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedfloatfund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("availableprevision", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfin"]};
	T.PrimaryKey = key;

}
}
}
