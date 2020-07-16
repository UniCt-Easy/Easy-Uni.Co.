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

namespace ivaregister_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable ivaregister{get { return this.Tables["ivaregister"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable ivaregisterkind{get { return this.Tables["ivaregisterkind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoicekind{get { return this.Tables["invoicekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoice{get { return this.Tables["invoice"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable registry{get { return this.Tables["registry"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoicedetail{get { return this.Tables["invoicedetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable ivakind{get { return this.Tables["ivakind"];}}

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
	T= new DataTable("ivaregister");
	C= new DataColumn("idivaregisterkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yivaregister", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nivaregister", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yinv", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ninv", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("protocolnum", typeof(System.Int32), ""));
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
	key = new DataColumn[3]{
	T.Columns["idivaregisterkind"], 	T.Columns["yivaregister"], 	T.Columns["nivaregister"]};
	T.PrimaryKey = key;

	T= new DataTable("ivaregisterkind");
	C= new DataColumn("idivaregisterkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("registerclass", typeof(System.String), "");
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
	T.Columns["idivaregisterkind"]};
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

	T.Columns.Add(new DataColumn("flagdeferred", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idinvkind"], 	T.Columns["yinv"], 	T.Columns["ninv"]};
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

	T= new DataTable("invoicedetail");
	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yinv", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ninv", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("rownum", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idivakind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!tipoiva", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("detaildescription", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!aliquota", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("!percindetraibilita", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("annotations", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("taxable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("tax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unabatable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!totaleriga", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!imponibile", typeof(System.Decimal), ""));
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

	T.Columns.Add(new DataColumn("discount", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("idmankind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("yman", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manrownum", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("number", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("competencystart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("competencystop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idaccmotive", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("npackage", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idpackage", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idunit", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("unitsforpackage", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idinvkind"], 	T.Columns["yinv"], 	T.Columns["ninv"], 	T.Columns["rownum"]};
	T.PrimaryKey = key;

	T= new DataTable("ivakind");
	C= new DataColumn("idivakind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("rate", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("unabatabilitypercentage", typeof(System.Decimal), "");
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
	T.Columns["idivakind"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["invoice"];
TChild= Tables["invoicedetail"];
CPar = new DataColumn[3]{TPar.Columns["idinvkind"], TPar.Columns["yinv"], TPar.Columns["ninv"]};
CChild = new DataColumn[3]{TChild.Columns["idinvkind"], TChild.Columns["yinv"], TChild.Columns["ninv"]};
Relations.Add(new DataRelation("invoiceinvoicedetail",CPar,CChild));

TPar= Tables["ivakind"];
TChild= Tables["invoicedetail"];
CPar = new DataColumn[1]{TPar.Columns["idivakind"]};
CChild = new DataColumn[1]{TChild.Columns["idivakind"]};
Relations.Add(new DataRelation("ivakindinvoicedetail",CPar,CChild));

TPar= Tables["registry"];
TChild= Tables["invoice"];
CPar = new DataColumn[1]{TPar.Columns["idreg"]};
CChild = new DataColumn[1]{TChild.Columns["idreg"]};
Relations.Add(new DataRelation("registryinvoice",CPar,CChild));

TPar= Tables["ivaregisterkind"];
TChild= Tables["ivaregister"];
CPar = new DataColumn[1]{TPar.Columns["idivaregisterkind"]};
CChild = new DataColumn[1]{TChild.Columns["idivaregisterkind"]};
Relations.Add(new DataRelation("ivaregisterkindivaregister",CPar,CChild));

TPar= Tables["invoicekind"];
TChild= Tables["ivaregister"];
CPar = new DataColumn[1]{TPar.Columns["idinvkind"]};
CChild = new DataColumn[1]{TChild.Columns["idinvkind"]};
Relations.Add(new DataRelation("invoicekindivaregister",CPar,CChild));

TPar= Tables["invoice"];
TChild= Tables["ivaregister"];
CPar = new DataColumn[3]{TPar.Columns["idinvkind"], TPar.Columns["yinv"], TPar.Columns["ninv"]};
CChild = new DataColumn[3]{TChild.Columns["idinvkind"], TChild.Columns["yinv"], TChild.Columns["ninv"]};
Relations.Add(new DataRelation("invoiceivaregister",CPar,CChild));

}
}
}
