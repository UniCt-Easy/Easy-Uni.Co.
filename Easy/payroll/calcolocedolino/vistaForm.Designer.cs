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

namespace calcolocedolino {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable parasubcontract{get { return Tables["parasubcontract"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payroll{get { return Tables["payroll"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payrolldeduction{get { return Tables["payrolldeduction"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payrollabatement{get { return Tables["payrollabatement"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payrolltax{get { return Tables["payrolltax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payrolltaxbracket{get { return Tables["payrolltaxbracket"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable parasubcontractyear{get { return Tables["parasubcontractyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable exhibitedcud{get { return Tables["exhibitedcud"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable otherinail{get { return Tables["otherinail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable pat{get { return Tables["pat"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable exhibitedcuddeduction{get { return Tables["exhibitedcuddeduction"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable deductioncode{get { return Tables["deductioncode"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable deductibleexpense{get { return Tables["deductibleexpense"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable taxablekind{get { return Tables["taxablekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable deduction{get { return Tables["deduction"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable tax{get { return Tables["tax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable parasubcontractfamily{get { return Tables["parasubcontractfamily"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable abatement{get { return Tables["abatement"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable abatableexpense{get { return Tables["abatableexpense"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable abatementcode{get { return Tables["abatementcode"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable exhibitedcudabatement{get { return Tables["exhibitedcudabatement"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable cafdocument{get { return Tables["cafdocument"];}}
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
public vistaForm(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "vistaForm";
Prefix = "";
Namespace = "http://tempuri.org/vistaForm.xsd";
EnforceConstraints = false;
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
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idaccmotive", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotivedebit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotivedebit_crg", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotivedebit_datacrg", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idcon"]};
	T.PrimaryKey = key;

	T= new DataTable("payroll");
	C= new DataColumn("idpayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("npayroll", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("disbursementdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idresidence", typeof(System.Int32), ""));
	C= new DataColumn("workingdays", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("feegross", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("netfee", typeof(System.Decimal), ""));
	C= new DataColumn("flagcomputed", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagbalance", typeof(System.String), "");
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

	C= new DataColumn("fiscalyear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("start", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("stop", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagsummarybalance", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idpayroll"]};
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
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annualcreditapplied", typeof(System.Decimal), ""));
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

	T= new DataTable("parasubcontractyear");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("regionaltax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("countrytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ratequantity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("startmonth", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("suspendedregionaltax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("suspendedcitytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("suspendedcountrytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idotherinsurance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("activitycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
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
	T.Columns.Add(new DataColumn("idresidence", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("startcompetency", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stopcompetency", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("annualincome", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytax_account", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ratequantity_account", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("startmonth_account", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagbonusappliance", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ayear"], 	T.Columns["idcon"]};
	T.PrimaryKey = key;

	T= new DataTable("exhibitedcud");
	C= new DataColumn("idexhibitedcud", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("citytaxapplied", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("suspendedcitytax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxapplied", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("suspendedregionaltax", typeof(System.Decimal), ""));
	C= new DataColumn("fiscalyear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("transfermotive", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cfotherdeputy", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	C= new DataColumn("stop", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("start", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagignoreprevcud", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxablegross", typeof(System.Decimal), ""));
	C= new DataColumn("taxablepension", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("inpsowed", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("inpsretained", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("irpefapplied", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("irpefsuspended", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ndays", typeof(System.Int32), ""));
	C= new DataColumn("nmonths", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idlinkeddbdepartment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("irpefgross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("earnings_based_abatements", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("totabatements", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("fiscalbonusnotapplied", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("fiscalbonusapplied", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flagbonusaccredited", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idlinkedcon", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idexhibitedcud"], 	T.Columns["idcon"]};
	T.PrimaryKey = key;

	T= new DataTable("otherinail");
	C= new DataColumn("idotherinail", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("taxable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("nmonths", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idotherinail"], 	T.Columns["idcon"]};
	T.PrimaryKey = key;

	T= new DataTable("pat");
	C= new DataColumn("idpat", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("adminrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employrate", typeof(System.Decimal), ""));
	C= new DataColumn("patcode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("validitystop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("validitystart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("admindenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employdenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxabledenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenumerator", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idpat"]};
	T.PrimaryKey = key;

	T= new DataTable("exhibitedcuddeduction");
	C= new DataColumn("idexhibitedcud", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddeduction", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idexhibitedcud"], 	T.Columns["idcon"], 	T.Columns["iddeduction"]};
	T.PrimaryKey = key;

	T= new DataTable("deductioncode");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddeduction", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("code", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("longdescription", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("exemption", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("maximal", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ayear"], 	T.Columns["iddeduction"]};
	T.PrimaryKey = key;

	T= new DataTable("deductibleexpense");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddeduction", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	C= new DataColumn("totalamount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ayear"], 	T.Columns["idcon"], 	T.Columns["iddeduction"]};
	T.PrimaryKey = key;

	T= new DataTable("taxablekind");
	C= new DataColumn("taxablecode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("roundingkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtaxablekind", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	C= new DataColumn("evaluationorder", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("spcalcannualtaxable", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("spcalcrefertaxable", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["taxablecode"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("deduction");
	C= new DataColumn("iddeduction", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxablecode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("validitystop", typeof(System.DateTime), ""));
	C= new DataColumn("flagdeductibleexpense", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("validitystart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("evaluationorder", typeof(System.Int32), ""));
	C= new DataColumn("evaluatesp", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("calculationkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["iddeduction"]};
	T.PrimaryKey = key;

	T= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxkind", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("fiscaltaxcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagunabatable", typeof(System.String), ""));
	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("taxablecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appliancebasis", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("geoappliance", typeof(System.String), ""));
	C= new DataColumn("taxref", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("maintaxcode", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["taxcode"]};
	T.PrimaryKey = key;

	T= new DataTable("parasubcontractfamily");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idfamily", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("cf", typeof(System.String), ""));
	C= new DataColumn("idaffinity", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("surname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("birthdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stopapplication", typeof(System.DateTime), ""));
	C= new DataColumn("flagdependent", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagforeign", typeof(System.String), ""));
	C= new DataColumn("foreignresident", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idcitybirth", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idnation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("startapplication", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("starthandicap", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("forename", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appliancepercentage", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("gender", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("childasparent", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ayear"], 	T.Columns["idcon"], 	T.Columns["idfamily"]};
	T.PrimaryKey = key;

	T= new DataTable("abatement");
	C= new DataColumn("idabatement", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("appliance", typeof(System.String), ""));
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("validitystop", typeof(System.DateTime), ""));
	C= new DataColumn("flagabatableexpense", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("validitystart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("evaluationorder", typeof(System.Int32), ""));
	C= new DataColumn("evaluatesp", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("calculationkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idabatement"]};
	T.PrimaryKey = key;

	T= new DataTable("abatableexpense");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idabatement", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("totalamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ayear"], 	T.Columns["idcon"], 	T.Columns["idabatement"]};
	T.PrimaryKey = key;

	T= new DataTable("abatementcode");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idabatement", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("code", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("longdescription", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("exemption", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("maximal", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ayear"], 	T.Columns["idabatement"]};
	T.PrimaryKey = key;

	T= new DataTable("exhibitedcudabatement");
	C= new DataColumn("idexhibitedcud", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idabatement", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idexhibitedcud"], 	T.Columns["idcon"], 	T.Columns["idabatement"]};
	T.PrimaryKey = key;

	T= new DataTable("cafdocument");
	C= new DataColumn("idcafdocument", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cafdocumentkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("docdate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("citytaxtorefundhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxtorefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxtoretainhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxtoretain", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtorefundhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtorefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtoretainhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtoretain", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("irpeftorefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("irpeftoretain", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("startmonth", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("monthfirstinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("monthsecondinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ratequantity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nquotafirstinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nquotasecondinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("firstrateadvance", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("separatedincomehusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("separatedincome", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("secondrateadvance", typeof(System.Decimal), ""));
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

	T.Columns.Add(new DataColumn("citytaxaccount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxaccounthusband", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idcafdocument"], 	T.Columns["idcon"]};
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

	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
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
TPar= Tables["payroll"];
TChild= Tables["payrolltaxcorrige"];
CPar = new DataColumn[1]{TPar.Columns["idpayroll"]};
CChild = new DataColumn[1]{TChild.Columns["idpayroll"]};
Relations.Add(new DataRelation("payrollpayrolltaxcorrige",CPar,CChild));

TPar= Tables["parasubcontract"];
TChild= Tables["cafdocument"];
CPar = new DataColumn[1]{TPar.Columns["idcon"]};
CChild = new DataColumn[1]{TChild.Columns["idcon"]};
Relations.Add(new DataRelation("parasubcontractcafdocument",CPar,CChild));

TPar= Tables["exhibitedcud"];
TChild= Tables["exhibitedcudabatement"];
CPar = new DataColumn[2]{TPar.Columns["idexhibitedcud"], TPar.Columns["idcon"]};
CChild = new DataColumn[2]{TChild.Columns["idexhibitedcud"], TChild.Columns["idcon"]};
Relations.Add(new DataRelation("exhibitedcudexhibitedcudabatement",CPar,CChild));

TPar= Tables["exhibitedcud"];
TChild= Tables["exhibitedcuddeduction"];
CPar = new DataColumn[2]{TPar.Columns["idexhibitedcud"], TPar.Columns["idcon"]};
CChild = new DataColumn[2]{TChild.Columns["idexhibitedcud"], TChild.Columns["idcon"]};
Relations.Add(new DataRelation("exhibitedcudexhibitedcuddeduction",CPar,CChild));

TPar= Tables["parasubcontract"];
TChild= Tables["otherinail"];
CPar = new DataColumn[1]{TPar.Columns["idcon"]};
CChild = new DataColumn[1]{TChild.Columns["idcon"]};
Relations.Add(new DataRelation("parasubcontractotherinail",CPar,CChild));

TPar= Tables["parasubcontract"];
TChild= Tables["exhibitedcud"];
CPar = new DataColumn[1]{TPar.Columns["idcon"]};
CChild = new DataColumn[1]{TChild.Columns["idcon"]};
Relations.Add(new DataRelation("parasubcontractexhibitedcud",CPar,CChild));

TPar= Tables["parasubcontract"];
TChild= Tables["parasubcontractyear"];
CPar = new DataColumn[1]{TPar.Columns["idcon"]};
CChild = new DataColumn[1]{TChild.Columns["idcon"]};
Relations.Add(new DataRelation("parasubcontractparasubcontractyear",CPar,CChild));

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

TPar= Tables["parasubcontractyear"];
TChild= Tables["payroll"];
CPar = new DataColumn[2]{TPar.Columns["ayear"], TPar.Columns["idcon"]};
CChild = new DataColumn[2]{TChild.Columns["fiscalyear"], TChild.Columns["idcon"]};
Relations.Add(new DataRelation("parasubcontractyearpayroll",CPar,CChild));

TPar= Tables["parasubcontract"];
TChild= Tables["payroll"];
CPar = new DataColumn[1]{TPar.Columns["idcon"]};
CChild = new DataColumn[1]{TChild.Columns["idcon"]};
Relations.Add(new DataRelation("parasubcontractpayroll",CPar,CChild));

TPar= Tables["pat"];
TChild= Tables["parasubcontract"];
CPar = new DataColumn[1]{TPar.Columns["idpat"]};
CChild = new DataColumn[1]{TChild.Columns["idpat"]};
Relations.Add(new DataRelation("patparasubcontract",CPar,CChild));

}
}
}
