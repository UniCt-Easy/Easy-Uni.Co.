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

namespace payroll_trasf_cedolino {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class dsCedolino: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payroll{get { return Tables["payroll"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payrolltax{get { return Tables["payrolltax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payrolltaxbracket{get { return Tables["payrolltaxbracket"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payrolldeduction{get { return Tables["payrolldeduction"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payrollabatement{get { return Tables["payrollabatement"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable cedolinonontrasferibile{get { return Tables["cedolinonontrasferibile"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable cedolinoannosuccessivo{get { return Tables["cedolinoannosuccessivo"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable cedolinoerogato{get { return Tables["cedolinoerogato"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable parasubcontract{get { return Tables["parasubcontract"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable parasubcontractyear{get { return Tables["parasubcontractyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable service{get { return Tables["service"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payrolltaxcorrige{get { return Tables["payrolltaxcorrige"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public dsCedolino(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "dsCedolino";
Prefix = "";
Namespace = "http://tempuri.org/dsCedolino.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("payroll");
	T.Columns.Add(new DataColumn("!eserccontratto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("!numcontratto", typeof(System.Int32), ""));
	C= new DataColumn("fiscalyear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("npayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagbalance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!service", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!flagneedbalance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!primocedolinononerogato", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!denominazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("disbursementdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idresidence", typeof(System.Int32), ""));
	C= new DataColumn("workingdays", typeof(System.Int16), "");
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

	C= new DataColumn("feegross", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("netfee", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!causa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagsummarybalance", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idpayroll"]};
	T.PrimaryKey = key;

	T= new DataTable("payrolltax");
	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idpayrolltax", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxcode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("taxablegross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("deduction", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("abatements", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("taxablenumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxabledenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employdenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("admindenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employtax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("admintax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employtaxgross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("annualtaxabletotal", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("annualpayedemploytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("annualcreditapplied", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idpayroll"], 	T.Columns["idpayrolltax"]};
	T.PrimaryKey = key;

	T= new DataTable("payrolltaxbracket");
	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idpayrolltax", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nbracket", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employtax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("admintax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idpayroll"], 	T.Columns["idpayrolltax"], 	T.Columns["nbracket"]};
	T.PrimaryKey = key;

	T= new DataTable("payrolldeduction");
	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddeduction", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxablecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annualamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idpayroll"], 	T.Columns["iddeduction"]};
	T.PrimaryKey = key;

	T= new DataTable("payrollabatement");
	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idabatement", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxcode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("annualamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idpayroll"], 	T.Columns["idabatement"]};
	T.PrimaryKey = key;

	T= new DataTable("cedolinonontrasferibile");
	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!causa", typeof(System.String), ""));
	C= new DataColumn("fiscalyear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("npayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!eserccontratto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("!numcontratto", typeof(System.Int32), ""));
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

	T.Columns.Add(new DataColumn("netfee", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!denominazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagsummarybalance", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idpayroll"]};
	T.PrimaryKey = key;

	T= new DataTable("cedolinoannosuccessivo");
	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("fiscalyear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("enabletaxrelief", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("currentrounding", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("feegross", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("netfee", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("disbursementdate", typeof(System.DateTime), ""));
	C= new DataColumn("stop", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("start", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagcomputed", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagbalance", typeof(System.String), ""));
	C= new DataColumn("workingdays", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idresidence", typeof(System.Int32), ""));
	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	C= new DataColumn("npayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagsummarybalance", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idpayroll"]};
	T.PrimaryKey = key;

	T= new DataTable("cedolinoerogato");
	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("fiscalyear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("npayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!eserccontratto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("!numcontratto", typeof(System.Int32), ""));
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

	T.Columns.Add(new DataColumn("netfee", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!denominazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!causa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagsummarybalance", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idpayroll"]};
	T.PrimaryKey = key;

	T= new DataTable("parasubcontract");
	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idpayrollkind", typeof(System.String), ""));
	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idser", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idmatriculabook", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	C= new DataColumn("stop", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("start", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("duty", typeof(System.String), ""));
	C= new DataColumn("monthlen", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ycon", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idpat", typeof(System.Int32), ""));
	C= new DataColumn("grossamount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("payrollccinfo", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("employed", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("matricula", typeof(System.Int32), ""));
	C= new DataColumn("ncon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("idaccmotive", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idcon"]};
	T.PrimaryKey = key;

	T= new DataTable("parasubcontractyear");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("citytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("countrytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("suspendedcitytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("suspendedcountrytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("suspendedregionaltax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("applybrackets", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("activitycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idotherinsurance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("notaxdeduction", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("fiscaldeduction", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("stopcompetency", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ndays", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cuddays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("idresidence", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("taxablecontract", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablecud", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablegross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablepension", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("startcompetency", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("highertax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("startmonth", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ratequantity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("notaxappliance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("competencymonths", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idemenscontractkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annualincome", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytax_account", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ratequantity_account", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("startmonth_account", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ayear"], 	T.Columns["idcon"]};
	T.PrimaryKey = key;

	T= new DataTable("service");
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("allowedit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("certificatekind", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagalwaysinfiscalmodels", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagapplyabatements", typeof(System.String), ""));
	C= new DataColumn("flagonlyfiscalabatement", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idmotive", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("itinerationvisible", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ivaamount", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("module", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rec770kind", typeof(System.String), ""));
	C= new DataColumn("codeser", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idser", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagneedbalance", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idser"]};
	T.PrimaryKey = key;

	T= new DataTable("payrolltaxcorrige");
	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idpayrolltaxcorrige", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxablegross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idpayroll"], 	T.Columns["idpayrolltaxcorrige"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["cedolinonontrasferibile"];
TChild= Tables["payrolltaxcorrige"];
CPar = new DataColumn[1]{TPar.Columns["idpayroll"]};
CChild = new DataColumn[1]{TChild.Columns["idpayroll"]};
Relations.Add(new DataRelation("cedolinonontrasferibile_payrolltaxcorrige",CPar,CChild));

TPar= Tables["payroll"];
TChild= Tables["payrolltaxcorrige"];
CPar = new DataColumn[1]{TPar.Columns["idpayroll"]};
CChild = new DataColumn[1]{TChild.Columns["idpayroll"]};
Relations.Add(new DataRelation("payrollpayrolltaxcorrige",CPar,CChild));

TPar= Tables["parasubcontract"];
TChild= Tables["parasubcontractyear"];
CPar = new DataColumn[1]{TPar.Columns["idcon"]};
CChild = new DataColumn[1]{TChild.Columns["idcon"]};
Relations.Add(new DataRelation("parasubcontractparasubcontractyear",CPar,CChild));

TPar= Tables["service"];
TChild= Tables["parasubcontract"];
CPar = new DataColumn[1]{TPar.Columns["idser"]};
CChild = new DataColumn[1]{TChild.Columns["idser"]};
Relations.Add(new DataRelation("service_parasubcontract",CPar,CChild));

TPar= Tables["parasubcontract"];
TChild= Tables["cedolinonontrasferibile"];
CPar = new DataColumn[1]{TPar.Columns["idcon"]};
CChild = new DataColumn[1]{TChild.Columns["idcon"]};
Relations.Add(new DataRelation("parasubcontract_cedolinonontrasferibile",CPar,CChild));

TPar= Tables["payroll"];
TChild= Tables["payrollabatement"];
CPar = new DataColumn[1]{TPar.Columns["idpayroll"]};
CChild = new DataColumn[1]{TChild.Columns["idpayroll"]};
Relations.Add(new DataRelation("payrollpayrollabatement",CPar,CChild));

TPar= Tables["payroll"];
TChild= Tables["payrolldeduction"];
CPar = new DataColumn[1]{TPar.Columns["idpayroll"]};
CChild = new DataColumn[1]{TChild.Columns["idpayroll"]};
Relations.Add(new DataRelation("payrollpayrolldeduction",CPar,CChild));

TPar= Tables["payrolltax"];
TChild= Tables["payrolltaxbracket"];
CPar = new DataColumn[2]{TPar.Columns["idpayroll"], TPar.Columns["idpayrolltax"]};
CChild = new DataColumn[2]{TChild.Columns["idpayroll"], TChild.Columns["idpayrolltax"]};
Relations.Add(new DataRelation("payrolltaxpayrolltaxbracket",CPar,CChild));

TPar= Tables["payroll"];
TChild= Tables["payrolltax"];
CPar = new DataColumn[1]{TPar.Columns["idpayroll"]};
CChild = new DataColumn[1]{TChild.Columns["idpayroll"]};
Relations.Add(new DataRelation("payrollpayrolltax",CPar,CChild));

TPar= Tables["cedolinonontrasferibile"];
TChild= Tables["payrolltax"];
CPar = new DataColumn[1]{TPar.Columns["idpayroll"]};
CChild = new DataColumn[1]{TChild.Columns["idpayroll"]};
Relations.Add(new DataRelation("cedolinonontrasferibile_payrolltax",CPar,CChild));

TPar= Tables["parasubcontract"];
TChild= Tables["payroll"];
CPar = new DataColumn[1]{TPar.Columns["idcon"]};
CChild = new DataColumn[1]{TChild.Columns["idcon"]};
Relations.Add(new DataRelation("parasubcontractpayroll",CPar,CChild));

}
}
}
