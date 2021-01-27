
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


namespace notable_importazione {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaAvanzo: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable surplus{get { return this.Tables["surplus"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaAvanzo(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "vistaAvanzo";
this.Prefix = "";
this.Namespace = "http://tempuri.org/vistaAvanzo.xsd";
this.EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("surplus");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("competencypayments", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("competencyproceeds", typeof(System.Decimal), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("currentexpenditure", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("currentrevenue", typeof(System.Decimal), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paymentstilldate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("paymentstoendofyear", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previousexpenditure", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previousrevenue", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previsiondate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("proceedstilldate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("proceedstoendofyear", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("residualpayments", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("residualproceeds", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("startfloatfund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedcurrentexpenditure", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedcurrentrevenue", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedpreviousexpenditure", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("supposedpreviousrevenue", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
	T.PrimaryKey = key;

}
}
}
