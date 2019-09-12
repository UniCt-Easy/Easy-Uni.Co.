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

namespace parasubcontract_senzacedolini {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable parasubcontract{get { return this.Tables["parasubcontract"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payroll{get { return this.Tables["payroll"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable parasubcontractview{get { return this.Tables["parasubcontractview"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

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
	T= new DataTable("parasubcontract");
	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ycon", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ncon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("duty", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idpayrollkind", typeof(System.String), ""));
	C= new DataColumn("idser", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("employed", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("payrollccinfo", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("start", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("stop", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("monthlen", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("grossamount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idpat", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("matricula", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idmatriculabook", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idcon"]};
	T.PrimaryKey = key;

	T= new DataTable("payroll");
	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("fiscalyear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("npayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagbalance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("disbursementdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idresidence", typeof(System.Int32), ""));
	C= new DataColumn("workingdays", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("feegross", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagcomputed", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("currentrounding", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	C= new DataColumn("enabletaxrelief", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("start", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("stop", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idpayroll"]};
	T.PrimaryKey = key;

	T= new DataTable("parasubcontractview");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ycon", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ncon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("registry", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("matricula", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("duty", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idpayrollkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("payroll", typeof(System.String), ""));
	C= new DataColumn("idser", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("service", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idresidence", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("city", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcountry", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("country", typeof(System.String), ""));
	C= new DataColumn("employed", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("payrollccinfo", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("start", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("stop", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("monthlen", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("grossamount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("activitycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("activity", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idotherinsurance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("otherinsurance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idpat", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("patcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("pat", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idmatriculabook", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("matriculabook", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("regionaltax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("countrytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ratequantity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("startmonth", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("suspendedregionaltax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("suspendedcountrytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("suspendedcitytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("notaxappliance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("applybrackets", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("highertax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablecud", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("cuddays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("taxablecontract", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ndays", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("taxablepension", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("fiscaldeduction", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("notaxdeduction", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablegross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("startcompetency", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stopcompetency", typeof(System.DateTime), ""));
	Tables.Add(T);

//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["parasubcontract"];
TChild= Tables["payroll"];
CPar = new DataColumn[1]{TPar.Columns["idcon"]};
CChild = new DataColumn[1]{TChild.Columns["idcon"]};
Relations.Add(new DataRelation("parasubcontractpayroll",CPar,CChild));

}
}
}
