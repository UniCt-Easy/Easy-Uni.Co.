
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


namespace income_wizardcontabilizza {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expense{get { return Tables["expense"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable income{get { return Tables["income"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomephase{get { return Tables["incomephase"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensephase{get { return Tables["expensephase"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable manager{get { return Tables["manager"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable registry{get { return Tables["registry"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensesorted{get { return Tables["expensesorted"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomesorted{get { return Tables["incomesorted"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenseyear{get { return Tables["expenseyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomeyear{get { return Tables["incomeyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensevar{get { return Tables["expensevar"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomevar{get { return Tables["incomevar"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sorting{get { return Tables["sorting"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind{get { return Tables["sortingkind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenseclawback{get { return Tables["expenseclawback"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensetax{get { return Tables["expensetax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable clawback{get { return Tables["clawback"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable tax{get { return Tables["tax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable creditpart{get { return Tables["creditpart"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable proceedspart{get { return Tables["proceedspart"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable fin{get { return Tables["fin"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoice{get { return Tables["invoice"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomeinvoice{get { return Tables["incomeinvoice"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable tipomovimento{get { return Tables["tipomovimento"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoicekind{get { return Tables["invoicekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable upb{get { return Tables["upb"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenselast{get { return Tables["expenselast"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomelast{get { return Tables["incomelast"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomeestimate{get { return Tables["incomeestimate"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable estimate{get { return Tables["estimate"];}}

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
	T= new DataTable("expense");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmov", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("parentidexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idclawback", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("income");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmov", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("parentidinc", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nphase"]};
	T.PrimaryKey = key;

	T= new DataTable("expensephase");
	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nphase"]};
	T.PrimaryKey = key;

	T= new DataTable("manager");
	C= new DataColumn("idman", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddivision", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("userweb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("passwordweb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idman"]};
	T.PrimaryKey = key;

	T= new DataTable("registry");
	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("cf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("p_iva", typeof(System.String), ""));
	C= new DataColumn("residence", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("annotation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("birthdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("gender", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("surname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forename", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("foreigncf", typeof(System.String), ""));
	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("badgecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcategory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcentralizedcategory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idmaritalstatus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idregistryclass", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("maritalsurname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idnation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("location", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("extmatricula", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idreg"]};
	T.PrimaryKey = key;

	T= new DataTable("expensesorted");
	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsubclass", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("tobecontinued", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("valuen1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("values1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paridsubclass", typeof(System.Int16), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idexp"], 	T.Columns["idsor"], 	T.Columns["idsubclass"]};
	T.PrimaryKey = key;

	T= new DataTable("incomesorted");
	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsubclass", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("tobecontinued", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("valuen1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("values1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paridsubclass", typeof(System.Int16), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idinc"], 	T.Columns["idsor"], 	T.Columns["idsubclass"]};
	T.PrimaryKey = key;

	T= new DataTable("expenseyear");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ayear"], 	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("incomeyear");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idinc"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("expensevar");
	C= new DataColumn("nvar", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yvar", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["nvar"], 	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("incomevar");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nvar", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yvar", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idinc"], 	T.Columns["nvar"]};
	T.PrimaryKey = key;

	T= new DataTable("sorting");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("sortcode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
	C= new DataColumn("nlevel", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("defaultn1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultn2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultn3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultn4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultn5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaults1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsor"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nphaseincome", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("nphaseexpense", typeof(System.Byte), ""));
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

	T.Columns.Add(new DataColumn("labeln1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedn1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedn1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedn2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedn2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedn3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedn3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedn4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedn4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedn5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedn5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockeds1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forceds1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockeds2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forceds2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockeds3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forceds3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockeds4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forceds4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockeds5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forceds5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelfordate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nodatelabel", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("totalexpression", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("expenseclawback");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idclawback", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idexp"], 	T.Columns["idclawback"]};
	T.PrimaryKey = key;

	T= new DataTable("expensetax");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("exemptionquota", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("abatements", typeof(System.Decimal), ""));
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
	T.Columns.Add(new DataColumn("competencydate", typeof(System.DateTime), ""));
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

	C= new DataColumn("nbracket", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idexp"], 	T.Columns["nbracket"], 	T.Columns["taxcode"]};
	T.PrimaryKey = key;

	T= new DataTable("clawback");
	C= new DataColumn("idclawback", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idclawback"]};
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["taxcode"]};
	T.PrimaryKey = key;

	T= new DataTable("creditpart");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ncreditpart", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ycreditpart", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idinc"], 	T.Columns["ncreditpart"]};
	T.PrimaryKey = key;

	T= new DataTable("proceedspart");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nproceedspart", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yproceedspart", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idinc"], 	T.Columns["nproceedspart"]};
	T.PrimaryKey = key;

	T= new DataTable("fin");
	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codefin", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("paridfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nlevel", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfin"]};
	T.PrimaryKey = key;

	T= new DataTable("invoice");
	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yinv", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ninv", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("registryreference", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paymentexpiring", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("idexpirationkind", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("idcurrency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("exchangerate", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("packinglistnum", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("packinglistdate", typeof(System.DateTime), ""));
	C= new DataColumn("officiallyprinted", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idinvkind"], 	T.Columns["yinv"], 	T.Columns["ninv"]};
	T.PrimaryKey = key;

	T= new DataTable("incomeinvoice");
	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yinv", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ninv", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("movkind", typeof(System.Int16), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idinvkind"], 	T.Columns["yinv"], 	T.Columns["ninv"], 	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("tipomovimento");
	C= new DataColumn("idtipo", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("descrizione", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idtipo"]};
	T.PrimaryKey = key;

	T= new DataTable("invoicekind");
	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinvkind"]};
	T.PrimaryKey = key;

	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idunderwriter", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("requested", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("granted", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previousappropriation", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("assured", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idupb"]};
	T.PrimaryKey = key;

	T= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iddeputy", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idregistrypaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idser", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ivaamount", typeof(System.Decimal), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymentdescr", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("servicestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("servicestop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("refexternaldoc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("biccode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymethod_flag", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymethod_allowdeputy", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("extracode", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("incomelast");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idpro", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("kpro", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("incomeestimate");
	C= new DataColumn("idestimkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nestim", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yestim", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	T.Columns.Add(new DataColumn("movkind", typeof(System.Int16), ""));
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idestimkind"], 	T.Columns["yestim"], 	T.Columns["nestim"], 	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("estimate");
	C= new DataColumn("idestimkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yestim", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nestim", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("deliveryaddress", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deliveryexpiration", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("exchangerate", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("idcurrency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idexpirationkind", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("officiallyprinted", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paymentexpiring", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("registryreference", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idestimkind"], 	T.Columns["yestim"], 	T.Columns["nestim"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["income"];
TChild= Tables["incomeestimate"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("income_incomeestimate",CPar,CChild));

TPar= Tables["estimate"];
TChild= Tables["incomeestimate"];
CPar = new DataColumn[3]{TPar.Columns["idestimkind"], TPar.Columns["yestim"], TPar.Columns["nestim"]};
CChild = new DataColumn[3]{TChild.Columns["idestimkind"], TChild.Columns["yestim"], TChild.Columns["nestim"]};
Relations.Add(new DataRelation("estimate_incomeestimate",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomelast"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("income_incomelast",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expenselast"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("expense_expenselast",CPar,CChild));

TPar= Tables["invoice"];
TChild= Tables["incomeinvoice"];
CPar = new DataColumn[3]{TPar.Columns["idinvkind"], TPar.Columns["yinv"], TPar.Columns["ninv"]};
CChild = new DataColumn[3]{TChild.Columns["idinvkind"], TChild.Columns["yinv"], TChild.Columns["ninv"]};
Relations.Add(new DataRelation("invoiceincomeinvoice",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomeinvoice"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("incomeincomeinvoice",CPar,CChild));

TPar= Tables["invoicekind"];
TChild= Tables["invoice"];
CPar = new DataColumn[1]{TPar.Columns["idinvkind"]};
CChild = new DataColumn[1]{TChild.Columns["idinvkind"]};
Relations.Add(new DataRelation("invoicekindinvoice",CPar,CChild));

TPar= Tables["fin"];
TChild= Tables["proceedspart"];
CPar = new DataColumn[1]{TPar.Columns["idfin"]};
CChild = new DataColumn[1]{TChild.Columns["idfin"]};
Relations.Add(new DataRelation("finproceedspart",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["proceedspart"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("incomeproceedspart",CPar,CChild));

TPar= Tables["fin"];
TChild= Tables["creditpart"];
CPar = new DataColumn[1]{TPar.Columns["idfin"]};
CChild = new DataColumn[1]{TChild.Columns["idfin"]};
Relations.Add(new DataRelation("fincreditpart",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["creditpart"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("incomecreditpart",CPar,CChild));

TPar= Tables["tax"];
TChild= Tables["expensetax"];
CPar = new DataColumn[1]{TPar.Columns["taxcode"]};
CChild = new DataColumn[1]{TChild.Columns["taxcode"]};
Relations.Add(new DataRelation("taxexpensetax",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expensetax"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("expenseexpensetax",CPar,CChild));

TPar= Tables["clawback"];
TChild= Tables["expenseclawback"];
CPar = new DataColumn[1]{TPar.Columns["idclawback"]};
CChild = new DataColumn[1]{TChild.Columns["idclawback"]};
Relations.Add(new DataRelation("clawbackexpenseclawback",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expenseclawback"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("expenseexpenseclawback",CPar,CChild));

TPar= Tables["sortingkind"];
TChild= Tables["sorting"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind"]};
Relations.Add(new DataRelation("sortingkindsorting",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomevar"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("incomeincomevar",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expensevar"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("expenseexpensevar",CPar,CChild));

TPar= Tables["fin"];
TChild= Tables["incomeyear"];
CPar = new DataColumn[1]{TPar.Columns["idfin"]};
CChild = new DataColumn[1]{TChild.Columns["idfin"]};
Relations.Add(new DataRelation("finincomeyear",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomeyear"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("incomeincomeyear",CPar,CChild));

TPar= Tables["fin"];
TChild= Tables["expenseyear"];
CPar = new DataColumn[1]{TPar.Columns["idfin"]};
CChild = new DataColumn[1]{TChild.Columns["idfin"]};
Relations.Add(new DataRelation("finexpenseyear",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expenseyear"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("expenseexpenseyear",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomesorted"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("incomeincomesorted",CPar,CChild));

TPar= Tables["sorting"];
TChild= Tables["incomesorted"];
CPar = new DataColumn[1]{TPar.Columns["idsor"]};
CChild = new DataColumn[1]{TChild.Columns["idsor"]};
Relations.Add(new DataRelation("sortingincomesorted",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expensesorted"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("expenseexpensesorted",CPar,CChild));

TPar= Tables["sorting"];
TChild= Tables["expensesorted"];
CPar = new DataColumn[1]{TPar.Columns["idsor"]};
CChild = new DataColumn[1]{TChild.Columns["idsor"]};
Relations.Add(new DataRelation("sortingexpensesorted",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idpayment"]};
Relations.Add(new DataRelation("expenseincome_1",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["parentidinc"]};
Relations.Add(new DataRelation("incomeincome",CPar,CChild));

TPar= Tables["registry"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["idreg"]};
CChild = new DataColumn[1]{TChild.Columns["idreg"]};
Relations.Add(new DataRelation("registryincome",CPar,CChild));

TPar= Tables["manager"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["idman"]};
CChild = new DataColumn[1]{TChild.Columns["idman"]};
Relations.Add(new DataRelation("managerincome",CPar,CChild));

TPar= Tables["incomephase"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["nphase"]};
CChild = new DataColumn[1]{TChild.Columns["nphase"]};
Relations.Add(new DataRelation("incomephaseincome",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idpayment"]};
Relations.Add(new DataRelation("expenseexpense_1",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["parentidexp"]};
Relations.Add(new DataRelation("expenseexpense",CPar,CChild));

TPar= Tables["registry"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["idreg"]};
CChild = new DataColumn[1]{TChild.Columns["idreg"]};
Relations.Add(new DataRelation("registryexpense",CPar,CChild));

TPar= Tables["manager"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["idman"]};
CChild = new DataColumn[1]{TChild.Columns["idman"]};
Relations.Add(new DataRelation("managerexpense",CPar,CChild));

TPar= Tables["expensephase"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["nphase"]};
CChild = new DataColumn[1]{TChild.Columns["nphase"]};
Relations.Add(new DataRelation("expensephaseexpense",CPar,CChild));

}
}
}
