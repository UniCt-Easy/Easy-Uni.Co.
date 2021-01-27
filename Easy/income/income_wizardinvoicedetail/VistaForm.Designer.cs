
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


namespace income_wizardinvoicedetail {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[Serializable()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class VistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable registry{get { return this.Tables["registry"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable income{get { return this.Tables["income"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable incomeyear{get { return this.Tables["incomeyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable fin{get { return this.Tables["fin"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable incomephase{get { return this.Tables["incomephase"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable upb{get { return this.Tables["upb"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable invoicedetail{get { return this.Tables["invoicedetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable ivakind{get { return this.Tables["ivakind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable estimate{get { return this.Tables["estimate"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable estimatekind{get { return this.Tables["estimatekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable incomeestimate{get { return this.Tables["incomeestimate"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable estimatedetail{get { return this.Tables["estimatedetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable incomeinvoice{get { return this.Tables["incomeinvoice"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable invoice{get { return this.Tables["invoice"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable invoicekind{get { return this.Tables["invoicekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable incomesorted{get { return this.Tables["incomesorted"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable tipomovimento{get { return this.Tables["tipomovimento"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable incomesetup{get { return this.Tables["incomesetup"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public VistaForm(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "VistaForm";
this.Prefix = "";
this.Namespace = "http://tempuri.org/VistaForm.xsd";
this.EnforceConstraints = false;
this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("registry");
	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("annotation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("badgecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("birthdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cf", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("extmatricula", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("foreigncf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forename", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("gender", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcategory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcentralizedcategory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idmaritalstatus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idnation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idregistryclass", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("location", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("maritalsurname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("p_iva", typeof(System.String), ""));
	C= new DataColumn("residence", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("sortcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("surname", typeof(System.String), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idreg"]};
	T.PrimaryKey = key;

	T= new DataTable("income");
	C= new DataColumn("idinc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("autocode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("fulfilled", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmov", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("npro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentidinc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	C= new DataColumn("ycreation", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ypro", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpro", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("incomeyear");
	C= new DataColumn("idinc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagarrear", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nphase", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idinc"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("fin");
	C= new DataColumn("idfin", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codefin", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("finpart", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagcontra", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagexpensesurplus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagincomesurplus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flaginternaltransfer", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagthirdparties", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("paridfin", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfin"]};
	T.PrimaryKey = key;

	T= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(System.String), "");
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

	T.Columns.Add(new DataColumn("flagfinance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nphase"]};
	T.PrimaryKey = key;

	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("assured", typeof(System.String), ""));
	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("granted", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idunderwriter", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("previousappropriation", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previousassessment", typeof(System.Decimal), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("requested", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idupb"]};
	T.PrimaryKey = key;

	T= new DataTable("invoicedetail");
	C= new DataColumn("idinvkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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
	C= new DataColumn("idivakind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idmankind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor3", typeof(System.String), ""));
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
	T.Columns.Add(new DataColumn("idexp_iva", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idexp_taxable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idinc_iva", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idinc_taxable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idgroup", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("!disponibile", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!idinctolink", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!monoestimate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!tipoiva", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!totaleriga", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!aliquota", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!codeupb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idinvkind"], 	T.Columns["ninv"], 	T.Columns["rownum"], 	T.Columns["yinv"]};
	T.PrimaryKey = key;

	T= new DataTable("ivakind");
	C= new DataColumn("idivakind", typeof(System.String), "");
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

	C= new DataColumn("rate", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("unabatabilitypercentage", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idivakind"]};
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
	T.Columns.Add(new DataColumn("idcurrency", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idexpirationkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.String), ""));
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
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idestimkind"], 	T.Columns["yestim"], 	T.Columns["nestim"]};
	T.PrimaryKey = key;

	T= new DataTable("estimatekind");
	C= new DataColumn("idestimkind", typeof(System.String), "");
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

	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxnumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("office", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("linktoinvoice", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("multireg", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deltaamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("deltapercentage", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idestimkind"]};
	T.PrimaryKey = key;

	T= new DataTable("incomeestimate");
	C= new DataColumn("idinc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	T.Columns.Add(new DataColumn("movkind", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idinc"], 	T.Columns["idestimkind"], 	T.Columns["nestim"], 	T.Columns["yestim"]};
	T.PrimaryKey = key;

	T= new DataTable("estimatedetail");
	C= new DataColumn("idestimkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yestim", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nestim", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("rownum", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("annotations", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("detaildescription", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("discount", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("idinc_iva", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idinc_taxable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ninvoiced", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("number", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("tax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxrate", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("toinvoice", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idivakind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idgroup", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("!totale", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!assegnato", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idestimkind"], 	T.Columns["yestim"], 	T.Columns["nestim"], 	T.Columns["rownum"]};
	T.PrimaryKey = key;

	T= new DataTable("incomeinvoice");
	C= new DataColumn("idinc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinvkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ninv", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yinv", typeof(System.Int16), "");
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

	T.Columns.Add(new DataColumn("movkind", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idinc"], 	T.Columns["idinvkind"], 	T.Columns["ninv"], 	T.Columns["yinv"]};
	T.PrimaryKey = key;

	T= new DataTable("invoice");
	C= new DataColumn("idinvkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ninv", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yinv", typeof(System.Int16), "");
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

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("exchangerate", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("flagdeferred", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcurrency", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idexpirationkind", typeof(System.String), ""));
	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("officiallyprinted", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("packinglistdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("packinglistnum", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentexpiring", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("registryreference", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idinvkind"], 	T.Columns["yinv"], 	T.Columns["ninv"]};
	T.PrimaryKey = key;

	T= new DataTable("invoicekind");
	C= new DataColumn("idinvkind", typeof(System.String), "");
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

	C= new DataColumn("flagbuysell", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagmixed", typeof(System.String), ""));
	C= new DataColumn("flagvariation", typeof(System.String), "");
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
	key = new DataColumn[1]{
	T.Columns["idinvkind"]};
	T.PrimaryKey = key;

	T= new DataTable("incomesorted");
	C= new DataColumn("idinc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsorkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsubclass", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayear", typeof(System.Int16), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridsor", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paridsorkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paridsubclass", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("tobecontinued", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
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
	T.Columns.Add(new DataColumn("valuev1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev5", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idsorkind"], 	T.Columns["idsor"], 	T.Columns["idinc"], 	T.Columns["idsubclass"]};
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

	T= new DataTable("incomesetup");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("incomephase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("expiringadvancedays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagautoprintdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagautoproceeds", typeof(System.String), ""));
	C= new DataColumn("flagcommseparatemanager", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagfinance", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagfruitful", typeof(System.String), ""));
	C= new DataColumn("flagregistry", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagseparatearrears", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagseparatemanager", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("managerkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("proceedsfinlevel", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("numerationkind", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["income"];
TChild= Tables["incomesorted"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("income_incomesorted",CPar,CChild));

TPar= Tables["invoicekind"];
TChild= Tables["invoice"];
CPar = new DataColumn[1]{TPar.Columns["idinvkind"]};
CChild = new DataColumn[1]{TChild.Columns["idinvkind"]};
Relations.Add(new DataRelation("invoicekind_invoice",CPar,CChild));

TPar= Tables["invoice"];
TChild= Tables["incomeinvoice"];
CPar = new DataColumn[3]{TPar.Columns["idinvkind"], TPar.Columns["yinv"], TPar.Columns["ninv"]};
CChild = new DataColumn[3]{TChild.Columns["idinvkind"], TChild.Columns["yinv"], TChild.Columns["ninv"]};
Relations.Add(new DataRelation("invoice_incomeinvoice",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomeinvoice"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("income_incomeinvoice",CPar,CChild));

TPar= Tables["estimate"];
TChild= Tables["estimatedetail"];
CPar = new DataColumn[3]{TPar.Columns["idestimkind"], TPar.Columns["yestim"], TPar.Columns["nestim"]};
CChild = new DataColumn[3]{TChild.Columns["idestimkind"], TChild.Columns["yestim"], TChild.Columns["nestim"]};
Relations.Add(new DataRelation("estimate_estimatedetail",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["estimatedetail"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc_taxable"]};
Relations.Add(new DataRelation("income_estimatedetail",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["estimatedetail"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc_iva"]};
Relations.Add(new DataRelation("income_estimatedetail1",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomeestimate"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("income_incomeestimate",CPar,CChild));

TPar= Tables["estimatekind"];
TChild= Tables["estimate"];
CPar = new DataColumn[1]{TPar.Columns["idestimkind"]};
CChild = new DataColumn[1]{TChild.Columns["idestimkind"]};
Relations.Add(new DataRelation("estimatekind_estimate",CPar,CChild));

TPar= Tables["upb"];
TChild= Tables["invoicedetail"];
CPar = new DataColumn[1]{TPar.Columns["idupb"]};
CChild = new DataColumn[1]{TChild.Columns["idupb"]};
Relations.Add(new DataRelation("upb_invoicedetail",CPar,CChild));

TPar= Tables["ivakind"];
TChild= Tables["invoicedetail"];
CPar = new DataColumn[1]{TPar.Columns["idivakind"]};
CChild = new DataColumn[1]{TChild.Columns["idivakind"]};
Relations.Add(new DataRelation("ivakind_invoicedetail",CPar,CChild));

TPar= Tables["invoice"];
TChild= Tables["invoicedetail"];
CPar = new DataColumn[3]{TPar.Columns["idinvkind"], TPar.Columns["yinv"], TPar.Columns["ninv"]};
CChild = new DataColumn[3]{TChild.Columns["idinvkind"], TChild.Columns["yinv"], TChild.Columns["ninv"]};
Relations.Add(new DataRelation("invoice_invoicedetail",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["invoicedetail"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc_taxable"]};
Relations.Add(new DataRelation("income_invoicedetail",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["invoicedetail"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc_iva"]};
Relations.Add(new DataRelation("income_invoicedetail1",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomeyear"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("income_incomeyear",CPar,CChild));

TPar= Tables["fin"];
TChild= Tables["incomeyear"];
CPar = new DataColumn[1]{TPar.Columns["idfin"]};
CChild = new DataColumn[1]{TChild.Columns["idfin"]};
Relations.Add(new DataRelation("fin_incomeyear",CPar,CChild));

TPar= Tables["upb"];
TChild= Tables["incomeyear"];
CPar = new DataColumn[1]{TPar.Columns["idupb"]};
CChild = new DataColumn[1]{TChild.Columns["idupb"]};
Relations.Add(new DataRelation("upb_incomeyear",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["parentidinc"]};
Relations.Add(new DataRelation("income_income",CPar,CChild));

TPar= Tables["registry"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["idreg"]};
CChild = new DataColumn[1]{TChild.Columns["idreg"]};
Relations.Add(new DataRelation("registry_income",CPar,CChild));

}
}
}
