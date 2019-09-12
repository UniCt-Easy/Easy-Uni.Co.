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

namespace storeunloaddetail_single {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable storeunload{get { return this.Tables["storeunload"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable bookingdetail{get { return this.Tables["bookingdetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable booking{get { return this.Tables["booking"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable storeunloaddetail{get { return this.Tables["storeunloaddetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable stock{get { return this.Tables["stock"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable list{get { return this.Tables["list"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable manager{get { return this.Tables["manager"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoicedetail{get { return this.Tables["invoicedetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoicekind{get { return this.Tables["invoicekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable listclass{get { return this.Tables["listclass"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sorting3{get { return this.Tables["sorting3"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sorting2{get { return this.Tables["sorting2"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sorting1{get { return this.Tables["sorting1"];}}

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
	T= new DataTable("storeunload");
	C= new DataColumn("idstoreunload", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idstoreunload_motive", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ystoreunload", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nstoreunload", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
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

	T.Columns.Add(new DataColumn("idddt_out", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idstore", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idstoreunload"]};
	T.PrimaryKey = key;

	T= new DataTable("bookingdetail");
	C= new DataColumn("idbooking", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idlist", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("number", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idstore", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idbooking"], 	T.Columns["idlist"]};
	T.PrimaryKey = key;

	T= new DataTable("booking");
	C= new DataColumn("idbooking", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	C= new DataColumn("ybooking", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbooking", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idbooking"]};
	T.PrimaryKey = key;

	T= new DataTable("storeunloaddetail");
	C= new DataColumn("idstoreunload", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idstoreunloaddetail", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idstock", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("number", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idbooking", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinvkind", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("yinv", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("ninv", typeof(System.Int32), ""));
	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rownum", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor3", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idstoreunload"], 	T.Columns["idstoreunloaddetail"]};
	T.PrimaryKey = key;

	T= new DataTable("stock");
	C= new DataColumn("idstock", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idstore", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idlist", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("number", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("expiry", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idmankind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("yman", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("man_idgroup", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinvkind", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("yinv", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("ninv", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("inv_idgroup", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idddt_in", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idstoreload_motive", typeof(System.Int32), ""));
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
	T.Columns["idstock"]};
	T.PrimaryKey = key;

	T= new DataTable("list");
	C= new DataColumn("idlist", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("intcode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("intbarcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("extcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("extbarcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("validitystop", typeof(System.DateTime), ""));
	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idpackage", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idunit", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("unitsforpackage", typeof(System.Int32), ""));
	C= new DataColumn("has_expiry", typeof(System.String), "");
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

	C= new DataColumn("idlistclass", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("pic", typeof(System.Byte[]), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idlist"]};
	T.PrimaryKey = key;

	T= new DataTable("manager");
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("passwordweb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("userweb", typeof(System.String), ""));
	C= new DataColumn("idman", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddivision", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idman"]};
	T.PrimaryKey = key;

	T= new DataTable("invoicedetail");
	C= new DataColumn("ninv", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("rownum", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yinv", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("annotations", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("competencystart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("paymentcompetency", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("competencystop", typeof(System.DateTime), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("detaildescription", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("discount", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("idaccmotive", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idmankind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("manrownum", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("number", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("tax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unabatable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("yman", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("idestimkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("estimrownum", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nestim", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("yestim", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("idgroup", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idexp_taxable", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idexp_iva", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinc_taxable", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinc_iva", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ninv_main", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("yinv_main", typeof(System.Int16), ""));
	C= new DataColumn("idivakind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idsor1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idintrastatcode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idintrastatmeasure", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("weight", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("va3type", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("intrastatoperationkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idintrastatservice", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idintrastatsupplymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idlist", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idunit", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpackage", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("unitsforpackage", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("npackage", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["ninv"], 	T.Columns["rownum"], 	T.Columns["yinv"], 	T.Columns["idinvkind"]};
	T.PrimaryKey = key;

	T= new DataTable("invoicekind");
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

	C= new DataColumn("codeinvkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flag_autodocnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("formatstring", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinvkind"]};
	T.PrimaryKey = key;

	T= new DataTable("listclass");
	C= new DataColumn("idlistclass", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codelistclass", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridlistclass", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("authrequired", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idlistclass"]};
	T.PrimaryKey = key;

	T= new DataTable("sorting3");
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
	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("movkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("printingorder", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv5", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsor"]};
	T.PrimaryKey = key;

	T= new DataTable("sorting2");
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
	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("movkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("printingorder", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv5", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsor"]};
	T.PrimaryKey = key;

	T= new DataTable("sorting1");
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
	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("movkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("printingorder", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv5", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsor"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["invoicekind"];
TChild= Tables["invoicedetail"];
CPar = new DataColumn[1]{TPar.Columns["idinvkind"]};
CChild = new DataColumn[1]{TChild.Columns["idinvkind"]};
Relations.Add(new DataRelation("invoicekind_invoicedetail",CPar,CChild));

TPar= Tables["listclass"];
TChild= Tables["list"];
CPar = new DataColumn[1]{TPar.Columns["idlistclass"]};
CChild = new DataColumn[1]{TChild.Columns["idlistclass"]};
Relations.Add(new DataRelation("listclass_list",CPar,CChild));

TPar= Tables["list"];
TChild= Tables["stock"];
CPar = new DataColumn[1]{TPar.Columns["idlist"]};
CChild = new DataColumn[1]{TChild.Columns["idlist"]};
Relations.Add(new DataRelation("list_stock",CPar,CChild));

TPar= Tables["sorting3"];
TChild= Tables["storeunloaddetail"];
CPar = new DataColumn[1]{TPar.Columns["idsor"]};
CChild = new DataColumn[1]{TChild.Columns["idsor3"]};
Relations.Add(new DataRelation("sorting3_storeunloaddetail",CPar,CChild));

TPar= Tables["sorting2"];
TChild= Tables["storeunloaddetail"];
CPar = new DataColumn[1]{TPar.Columns["idsor"]};
CChild = new DataColumn[1]{TChild.Columns["idsor2"]};
Relations.Add(new DataRelation("sorting2_storeunloaddetail",CPar,CChild));

TPar= Tables["sorting1"];
TChild= Tables["storeunloaddetail"];
CPar = new DataColumn[1]{TPar.Columns["idsor"]};
CChild = new DataColumn[1]{TChild.Columns["idsor1"]};
Relations.Add(new DataRelation("sorting1_storeunloaddetail",CPar,CChild));

TPar= Tables["invoicedetail"];
TChild= Tables["storeunloaddetail"];
CPar = new DataColumn[4]{TPar.Columns["ninv"], TPar.Columns["rownum"], TPar.Columns["yinv"], TPar.Columns["idinvkind"]};
CChild = new DataColumn[4]{TChild.Columns["ninv"], TChild.Columns["rownum"], TChild.Columns["yinv"], TChild.Columns["idinvkind"]};
Relations.Add(new DataRelation("invoicedetail_storeunloaddetail",CPar,CChild));

TPar= Tables["booking"];
TChild= Tables["storeunloaddetail"];
CPar = new DataColumn[1]{TPar.Columns["idbooking"]};
CChild = new DataColumn[1]{TChild.Columns["idbooking"]};
Relations.Add(new DataRelation("booking_storeunloaddetail",CPar,CChild));

TPar= Tables["manager"];
TChild= Tables["storeunloaddetail"];
CPar = new DataColumn[1]{TPar.Columns["idman"]};
CChild = new DataColumn[1]{TChild.Columns["idman"]};
Relations.Add(new DataRelation("manager_storeunloaddetail",CPar,CChild));

TPar= Tables["stock"];
TChild= Tables["storeunloaddetail"];
CPar = new DataColumn[1]{TPar.Columns["idstock"]};
CChild = new DataColumn[1]{TChild.Columns["idstock"]};
Relations.Add(new DataRelation("stock_storeunloaddetail",CPar,CChild));

TPar= Tables["storeunload"];
TChild= Tables["storeunloaddetail"];
CPar = new DataColumn[1]{TPar.Columns["idstoreunload"]};
CChild = new DataColumn[1]{TChild.Columns["idstoreunload"]};
Relations.Add(new DataRelation("storeunload_storeunloaddetail",CPar,CChild));

TPar= Tables["booking"];
TChild= Tables["bookingdetail"];
CPar = new DataColumn[1]{TPar.Columns["idbooking"]};
CChild = new DataColumn[1]{TChild.Columns["idbooking"]};
Relations.Add(new DataRelation("booking_bookingdetail",CPar,CChild));

}
}
}
