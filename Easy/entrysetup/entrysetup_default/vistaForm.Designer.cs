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

namespace entrysetup_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable entrysetup{get { return this.Tables["entrysetup"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account_ivapayment{get { return this.Tables["account_ivapayment"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account_supplier{get { return this.Tables["account_supplier"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account_ivarefund{get { return this.Tables["account_ivarefund"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account_customer{get { return this.Tables["account_customer"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account_accruedcost{get { return this.Tables["account_accruedcost"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account_accruedrevenue{get { return this.Tables["account_accruedrevenue"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account_deferredcost{get { return this.Tables["account_deferredcost"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account_deferredrevenue{get { return this.Tables["account_deferredrevenue"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account_pat{get { return this.Tables["account_pat"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account_pl{get { return this.Tables["account_pl"];}}

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
	T= new DataTable("entrysetup");
	T.Namespace = this.Namespace;
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idacc_customer", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_supplier", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivapayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivarefund", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("flagepexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_accruedcost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_accruedrevenue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredcost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredrevenue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_pl", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_patrimony", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("account_ivapayment");
	T.Namespace = this.Namespace;
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
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

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;

	T= new DataTable("account_supplier");
	T.Namespace = this.Namespace;
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
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

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;

	T= new DataTable("account_ivarefund");
	T.Namespace = this.Namespace;
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
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

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;

	T= new DataTable("account_customer");
	T.Namespace = this.Namespace;
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
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

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;

	T= new DataTable("account_accruedcost");
	T.Namespace = this.Namespace;
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
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

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;

	T= new DataTable("account_accruedrevenue");
	T.Namespace = this.Namespace;
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
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

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;

	T= new DataTable("account_deferredcost");
	T.Namespace = this.Namespace;
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
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

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;

	T= new DataTable("account_deferredrevenue");
	T.Namespace = this.Namespace;
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
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

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;

	T= new DataTable("account_pat");
	T.Namespace = this.Namespace;
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idpatrimony", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idplaccount", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagprofit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagloss", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("placcount_sign", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("patrimony_sign", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcompetency", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;

	T= new DataTable("account_pl");
	T.Namespace = this.Namespace;
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idpatrimony", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idplaccount", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagprofit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagloss", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("placcount_sign", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("patrimony_sign", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcompetency", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["account_deferredrevenue"];
TChild= Tables["entrysetup"];
CPar = new DataColumn[1]{TPar.Columns["idacc"]};
CChild = new DataColumn[1]{TChild.Columns["idacc_deferredrevenue"]};
Relations.Add(new DataRelation("account_deferredrevenueentrysetup",CPar,CChild));

TPar= Tables["account_ivarefund"];
TChild= Tables["entrysetup"];
CPar = new DataColumn[1]{TPar.Columns["idacc"]};
CChild = new DataColumn[1]{TChild.Columns["idacc_ivarefund"]};
Relations.Add(new DataRelation("account_ivarefundentrysetup",CPar,CChild));

TPar= Tables["account_ivapayment"];
TChild= Tables["entrysetup"];
CPar = new DataColumn[1]{TPar.Columns["idacc"]};
CChild = new DataColumn[1]{TChild.Columns["idacc_ivapayment"]};
Relations.Add(new DataRelation("account_ivapaymententrysetup",CPar,CChild));

TPar= Tables["account_supplier"];
TChild= Tables["entrysetup"];
CPar = new DataColumn[1]{TPar.Columns["idacc"]};
CChild = new DataColumn[1]{TChild.Columns["idacc_supplier"]};
Relations.Add(new DataRelation("account_supplierentrysetup",CPar,CChild));

TPar= Tables["account_customer"];
TChild= Tables["entrysetup"];
CPar = new DataColumn[1]{TPar.Columns["idacc"]};
CChild = new DataColumn[1]{TChild.Columns["idacc_customer"]};
Relations.Add(new DataRelation("account_customerentrysetup",CPar,CChild));

TPar= Tables["account_accruedcost"];
TChild= Tables["entrysetup"];
CPar = new DataColumn[1]{TPar.Columns["idacc"]};
CChild = new DataColumn[1]{TChild.Columns["idacc_accruedcost"]};
Relations.Add(new DataRelation("account_accruedcostentrysetup",CPar,CChild));

TPar= Tables["account_accruedrevenue"];
TChild= Tables["entrysetup"];
CPar = new DataColumn[1]{TPar.Columns["idacc"]};
CChild = new DataColumn[1]{TChild.Columns["idacc_accruedrevenue"]};
Relations.Add(new DataRelation("account_accruedrevenueentrysetup",CPar,CChild));

TPar= Tables["account_deferredcost"];
TChild= Tables["entrysetup"];
CPar = new DataColumn[1]{TPar.Columns["idacc"]};
CChild = new DataColumn[1]{TChild.Columns["idacc_deferredcost"]};
Relations.Add(new DataRelation("account_deferredcostentrysetup",CPar,CChild));

TPar= Tables["account_pat"];
TChild= Tables["entrysetup"];
CPar = new DataColumn[1]{TPar.Columns["idacc"]};
CChild = new DataColumn[1]{TChild.Columns["idacc_patrimony"]};
Relations.Add(new DataRelation("account_pat_entrysetup",CPar,CChild));

TPar= Tables["account_pl"];
TChild= Tables["entrysetup"];
CPar = new DataColumn[1]{TPar.Columns["idacc"]};
CChild = new DataColumn[1]{TChild.Columns["idacc_pl"]};
Relations.Add(new DataRelation("account_pl_entrysetup",CPar,CChild));

}
}
}
