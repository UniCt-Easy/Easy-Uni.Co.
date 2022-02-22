
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


namespace finbalance_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tempds: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable finbalancedetail{get { return this.Tables["finbalancedetail"];}}

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
	T= new DataTable("finbalancedetail");
	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("codefin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("supposedcash", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedcredits", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("revenue", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("expenditure", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("actualcashsurplus", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("actualcreditsurplus", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("previsionvariation", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("secondaryprevvariation", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("creditvariation", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("cashvariation", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedrevenue", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedexpenditure", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedavailableprev", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("actualavailableprev", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("actualprev", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("payment", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("proceeds", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("assignedcash", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!revenuevariation", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfin"]};
	T.PrimaryKey = key;

}
}
}
