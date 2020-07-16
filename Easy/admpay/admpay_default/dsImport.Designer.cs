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

namespace admpay_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class dsImport: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay{get { return this.Tables["admpay"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay_expense{get { return this.Tables["admpay_expense"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay_employtax{get { return this.Tables["admpay_employtax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay_admintax{get { return this.Tables["admpay_admintax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay_expensesorted{get { return this.Tables["admpay_expensesorted"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay_clawback{get { return this.Tables["admpay_clawback"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sorting{get { return this.Tables["sorting"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind{get { return this.Tables["sortingkind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable tax{get { return this.Tables["tax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable taxsorting{get { return this.Tables["taxsorting"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingtranslation{get { return this.Tables["sortingtranslation"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay_appropriation{get { return this.Tables["admpay_appropriation"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable wageimportsetup{get { return this.Tables["wageimportsetup"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable clawbacksorting{get { return this.Tables["clawbacksorting"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay_income{get { return this.Tables["admpay_income"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay_incomesorted{get { return this.Tables["admpay_incomesorted"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay_assessment{get { return this.Tables["admpay_assessment"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public dsImport(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "dsImport";
this.Prefix = "";
this.Namespace = "http://tempuri.org/dsImport.xsd";
this.EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("admpay");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("processed", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["yadmpay"], 	T.Columns["nadmpay"]};
	T.PrimaryKey = key;

	T= new DataTable("admpay_expense");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nexpense", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idser", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nappropriation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["yadmpay"], 	T.Columns["nadmpay"], 	T.Columns["nexpense"]};
	T.PrimaryKey = key;

	T= new DataTable("admpay_employtax");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nexpense", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nbracket", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[5]{
	T.Columns["yadmpay"], 	T.Columns["nadmpay"], 	T.Columns["nexpense"], 	T.Columns["taxcode"], 	T.Columns["nbracket"]};
	T.PrimaryKey = key;

	T= new DataTable("admpay_admintax");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nexpense", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nbracket", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
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

	T.Columns.Add(new DataColumn("nappropriation", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[5]{
	T.Columns["yadmpay"], 	T.Columns["nadmpay"], 	T.Columns["nexpense"], 	T.Columns["taxcode"], 	T.Columns["nbracket"]};
	T.PrimaryKey = key;

	T= new DataTable("admpay_expensesorted");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nexpense", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsubclass", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[5]{
	T.Columns["idsor"], 	T.Columns["idsubclass"], 	T.Columns["nadmpay"], 	T.Columns["nexpense"], 	T.Columns["yadmpay"]};
	T.PrimaryKey = key;

	T= new DataTable("admpay_clawback");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nexpense", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idclawback", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["yadmpay"], 	T.Columns["nadmpay"], 	T.Columns["nexpense"], 	T.Columns["idclawback"]};
	T.PrimaryKey = key;

	T= new DataTable("sorting");
	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("defaultN1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultN2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultN3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultN4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultN5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv5", typeof(System.Decimal), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("movkind", typeof(System.String), ""));
	C= new DataColumn("nlevel", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("printingorder", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("sortcode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsor"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelfordate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv5", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nodatelabel", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nphaseexpense", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("nphaseincome", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("totalexpression", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxref", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appliancebasis", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("fiscaltaxcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagunabatable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("geoappliance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_cost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_debit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_pay", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxablecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("taxkind", typeof(System.Int16), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["taxcode"]};
	T.PrimaryKey = key;

	T= new DataTable("taxsorting");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("quota", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idsor"], 	T.Columns["taxcode"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingtranslation");
	C= new DataColumn("idsortingchild", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsortingmaster", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("defaultN1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultN2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultN3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultN4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultN5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("denominator", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("numerator", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("percentage", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idsortingchild"], 	T.Columns["idsortingmaster"]};
	T.PrimaryKey = key;

	T= new DataTable("admpay_appropriation");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nappropriation", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["yadmpay"], 	T.Columns["nadmpay"], 	T.Columns["nappropriation"]};
	T.PrimaryKey = key;

	T= new DataTable("wageimportsetup");
	C= new DataColumn("idwageimportsetup", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idsorkind_fin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_upb", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_registry", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_tax", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_clawback", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_service", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingmaster1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingmaster2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingmaster3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingmaster4", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingmaster5", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingchild1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingchild2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingchild3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingchild4", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingchild5", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_accmotivegroup1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_accmotivegroup2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("listfield", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("kind", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idwageimportsetup"]};
	T.PrimaryKey = key;

	T= new DataTable("clawbacksorting");
	C= new DataColumn("idclawback", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("quota", typeof(System.Decimal), ""));
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
	T.Columns["idclawback"], 	T.Columns["idsor"]};
	T.PrimaryKey = key;

	T= new DataTable("admpay_income");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nincome", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nassessment", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["yadmpay"], 	T.Columns["nadmpay"], 	T.Columns["nincome"]};
	T.PrimaryKey = key;

	T= new DataTable("admpay_incomesorted");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nincome", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsubclass", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[5]{
	T.Columns["idsor"], 	T.Columns["idsubclass"], 	T.Columns["nadmpay"], 	T.Columns["nincome"], 	T.Columns["yadmpay"]};
	T.PrimaryKey = key;

	T= new DataTable("admpay_assessment");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nassessment", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idinc", typeof(System.Int32), ""));
	C= new DataColumn("amount", typeof(System.Decimal), "");
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["yadmpay"], 	T.Columns["nadmpay"], 	T.Columns["nassessment"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["admpay"];
TChild= Tables["admpay_assessment"];
CPar = new DataColumn[2]{TPar.Columns["yadmpay"], TPar.Columns["nadmpay"]};
CChild = new DataColumn[2]{TChild.Columns["yadmpay"], TChild.Columns["nadmpay"]};
Relations.Add(new DataRelation("admpay_admpay_assessment",CPar,CChild));

TPar= Tables["sorting"];
TChild= Tables["admpay_incomesorted"];
CPar = new DataColumn[1]{TPar.Columns["idsor"]};
CChild = new DataColumn[1]{TChild.Columns["idsor"]};
Relations.Add(new DataRelation("sorting_admpay_incomesorted",CPar,CChild));

TPar= Tables["admpay"];
TChild= Tables["admpay_income"];
CPar = new DataColumn[2]{TPar.Columns["yadmpay"], TPar.Columns["nadmpay"]};
CChild = new DataColumn[2]{TChild.Columns["yadmpay"], TChild.Columns["nadmpay"]};
Relations.Add(new DataRelation("admpay_admpay_income",CPar,CChild));

TPar= Tables["admpay_assessment"];
TChild= Tables["admpay_income"];
CPar = new DataColumn[3]{TPar.Columns["yadmpay"], TPar.Columns["nadmpay"], TPar.Columns["nassessment"]};
CChild = new DataColumn[3]{TChild.Columns["nassessment"], TChild.Columns["nadmpay"], TChild.Columns["yadmpay"]};
Relations.Add(new DataRelation("admpay_assessment_admpay_income",CPar,CChild));

TPar= Tables["admpay"];
TChild= Tables["admpay_appropriation"];
CPar = new DataColumn[2]{TPar.Columns["yadmpay"], TPar.Columns["nadmpay"]};
CChild = new DataColumn[2]{TChild.Columns["yadmpay"], TChild.Columns["nadmpay"]};
Relations.Add(new DataRelation("admpayadmpay_appropriation",CPar,CChild));

TPar= Tables["admpay"];
TChild= Tables["admpay_clawback"];
CPar = new DataColumn[2]{TPar.Columns["yadmpay"], TPar.Columns["nadmpay"]};
CChild = new DataColumn[2]{TChild.Columns["yadmpay"], TChild.Columns["nadmpay"]};
Relations.Add(new DataRelation("admpayadmpay_clawback",CPar,CChild));

TPar= Tables["admpay"];
TChild= Tables["admpay_expensesorted"];
CPar = new DataColumn[2]{TPar.Columns["yadmpay"], TPar.Columns["nadmpay"]};
CChild = new DataColumn[2]{TChild.Columns["yadmpay"], TChild.Columns["nadmpay"]};
Relations.Add(new DataRelation("admpayadmpay_expensesorted",CPar,CChild));

TPar= Tables["sorting"];
TChild= Tables["admpay_expensesorted"];
CPar = new DataColumn[1]{TPar.Columns["idsor"]};
CChild = new DataColumn[1]{TChild.Columns["idsor"]};
Relations.Add(new DataRelation("sortingadmpay_expensesorted",CPar,CChild));

TPar= Tables["admpay"];
TChild= Tables["admpay_admintax"];
CPar = new DataColumn[2]{TPar.Columns["yadmpay"], TPar.Columns["nadmpay"]};
CChild = new DataColumn[2]{TChild.Columns["yadmpay"], TChild.Columns["nadmpay"]};
Relations.Add(new DataRelation("admpayadmpay_admintax",CPar,CChild));

TPar= Tables["admpay"];
TChild= Tables["admpay_employtax"];
CPar = new DataColumn[2]{TPar.Columns["yadmpay"], TPar.Columns["nadmpay"]};
CChild = new DataColumn[2]{TChild.Columns["yadmpay"], TChild.Columns["nadmpay"]};
Relations.Add(new DataRelation("admpayadmpay_employtax",CPar,CChild));

TPar= Tables["admpay"];
TChild= Tables["admpay_expense"];
CPar = new DataColumn[2]{TPar.Columns["yadmpay"], TPar.Columns["nadmpay"]};
CChild = new DataColumn[2]{TChild.Columns["yadmpay"], TChild.Columns["nadmpay"]};
Relations.Add(new DataRelation("admpayadmpay_expense",CPar,CChild));

TPar= Tables["admpay_appropriation"];
TChild= Tables["admpay_expense"];
CPar = new DataColumn[3]{TPar.Columns["yadmpay"], TPar.Columns["nadmpay"], TPar.Columns["nappropriation"]};
CChild = new DataColumn[3]{TChild.Columns["yadmpay"], TChild.Columns["nadmpay"], TChild.Columns["nappropriation"]};
Relations.Add(new DataRelation("admpay_appropriationadmpay_expense",CPar,CChild));

}
}
}
