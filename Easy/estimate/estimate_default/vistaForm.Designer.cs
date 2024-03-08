
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


namespace estimate_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable estimate{get { return this.Tables["estimate"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable estimatedetail{get { return this.Tables["estimatedetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable manager{get { return this.Tables["manager"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable estimatekind{get { return this.Tables["estimatekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable upb{get { return this.Tables["upb"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable currency{get { return this.Tables["currency"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expirationkind{get { return this.Tables["expirationkind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable estimateview{get { return this.Tables["estimateview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sorting{get { return this.Tables["sorting"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable estimatesorting{get { return this.Tables["estimatesorting"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoicedetail{get { return this.Tables["invoicedetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable registrymainview{get { return this.Tables["registrymainview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable config{get { return this.Tables["config"];}}

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
	T= new DataTable("estimate");
	C= new DataColumn("idestimkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nestim", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yestim", typeof(System.Int16), "");
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
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
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
	T.Columns["idestimkind"], 	T.Columns["nestim"], 	T.Columns["yestim"]};
	T.PrimaryKey = key;

	T= new DataTable("estimatedetail");
	C= new DataColumn("idestimkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nestim", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("rownum", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yestim", typeof(System.Int16), "");
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
	T.Columns.Add(new DataColumn("idinc_iva", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinc_taxable", typeof(System.Int32), ""));
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
	T.Columns.Add(new DataColumn("!totaleriga", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idgroup", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("competencystart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("competencystop", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idestimkind"], 	T.Columns["nestim"], 	T.Columns["rownum"], 	T.Columns["yestim"]};
	T.PrimaryKey = key;

	T= new DataTable("manager");
	C= new DataColumn("idman", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	C= new DataColumn("iddivision", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idman"]};
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
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idestimkind"]};
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
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
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

	T= new DataTable("currency");
	C= new DataColumn("idcurrency", typeof(System.String), "");
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idcurrency"]};
	T.PrimaryKey = key;

	T= new DataTable("expirationkind");
	C= new DataColumn("idexpirationkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idexpirationkind"]};
	T.PrimaryKey = key;

	T= new DataTable("estimateview");
	C= new DataColumn("idestimkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yestim", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nestim", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("estimkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("registry", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("registryreference", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deliveryexpiration", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deliveryaddress", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentexpiring", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("idexpirationkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcurrency", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("currency", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("exchangerate", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("officiallyprinted", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
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
	T= new DataTable("sorting");
	C= new DataColumn("idsorkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.String), "");
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
	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridsor", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("printingorder", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("sortcode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idsorkind"], 	T.Columns["idsor"]};
	T.PrimaryKey = key;

	T= new DataTable("estimatesorting");
	C= new DataColumn("idsorkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idestimkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yestim", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nestim", typeof(System.Int32), "");
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

	T.Columns.Add(new DataColumn("quota", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("!codiceclass", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!descrizione", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[5]{
	T.Columns["idsorkind"], 	T.Columns["idsor"], 	T.Columns["idestimkind"], 	T.Columns["yestim"], 	T.Columns["nestim"]};
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
	T.Columns.Add(new DataColumn("idexp_iva", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idexp_taxable", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinc_iva", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinc_taxable", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idgroup", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idinvkind"], 	T.Columns["ninv"], 	T.Columns["rownum"], 	T.Columns["yinv"]};
	T.PrimaryKey = key;

	T= new DataTable("registrymainview");
	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idregistryclass", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("registryclass", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("surname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forename", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("p_iva", typeof(System.String), ""));
	C= new DataColumn("residence", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("residencekind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annotation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("birthdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("city", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("gender", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("foreigncf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("qualification", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idmaritalstatus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("maritalstatus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sortcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("registrykind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("human", typeof(System.String), ""));
	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("badgecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("maritalsurname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcategory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idemployment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("extmatricula", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcentralizedcategory", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("location", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idnation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nation", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idreg"]};
	T.PrimaryKey = key;

	T= new DataTable("config");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("admintaxkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("agencycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appropriationphasecode", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("assessmentphasecode", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("asset_flagnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("asset_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("asset_numerationkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("assetload_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("boxpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cashvaliditykind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("casualcontract_flagnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("casualcontract_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("clawbackkind", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("currpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deferredexpensephase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deferredincomephase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("electronicimport", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("electronictrasmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("employtaxkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("estimate_numerationkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("expense_expiringdays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("expensephase", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("flagadmintax", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagarrearsadmintax", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagautopayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagautoproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagclawback", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagepexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagfruitful", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagpayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagrefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagtax", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagtaxcompetency", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("foreignhours", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idacc_accruedcost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_accruedrevenue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_customer", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredcost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredcredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferreddebit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredrevenue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivapayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivarefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_patrimony", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_pl", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_supplier", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_admincar", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_foot", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_owncar", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idclawback", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinexpense", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinexpensesurplus", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinincomesurplus", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivapayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivarefund", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idivapayperiodicity", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idregauto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsortingkind1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsortingkind2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsortingkind3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("importappname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("income_expiringdays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("incomephase", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("invoice_numerationkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("linktoinvoice", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("mandate_numerationkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("minpayment", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("minrefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("motivelen", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("motiveprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motiveseparator", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("parasubcontract_numerationkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("payment_finlevel", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("payment_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("payment_flagautoprintdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("payments_groupingkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("previsionkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("prevpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("proceeds_finlevel", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("proceeds_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("proceeds_flagautoprintdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("proceeds_groupingkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("profservice_flagnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("profservice_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refundagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("secprevisionkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("wageaddition_flagnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("wageaddition_flagrestart", typeof(System.String), ""));
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
TPar= Tables["estimate"];
TChild= Tables["invoicedetail"];
CPar = new DataColumn[3]{TPar.Columns["idestimkind"], TPar.Columns["nestim"], TPar.Columns["yestim"]};
CChild = new DataColumn[3]{TChild.Columns["idestimkind"], TChild.Columns["nestim"], TChild.Columns["yestim"]};
Relations.Add(new DataRelation("estimateinvoicedetail",CPar,CChild));

TPar= Tables["sorting"];
TChild= Tables["estimatesorting"];
CPar = new DataColumn[2]{TPar.Columns["idsorkind"], TPar.Columns["idsor"]};
CChild = new DataColumn[2]{TChild.Columns["idsorkind"], TChild.Columns["idsor"]};
Relations.Add(new DataRelation("sortingestimatesorting",CPar,CChild));

TPar= Tables["estimate"];
TChild= Tables["estimatesorting"];
CPar = new DataColumn[3]{TPar.Columns["idestimkind"], TPar.Columns["nestim"], TPar.Columns["yestim"]};
CChild = new DataColumn[3]{TChild.Columns["idestimkind"], TChild.Columns["nestim"], TChild.Columns["yestim"]};
Relations.Add(new DataRelation("estimateestimatesorting",CPar,CChild));

TPar= Tables["estimate"];
TChild= Tables["estimatedetail"];
CPar = new DataColumn[3]{TPar.Columns["idestimkind"], TPar.Columns["nestim"], TPar.Columns["yestim"]};
CChild = new DataColumn[3]{TChild.Columns["idestimkind"], TChild.Columns["nestim"], TChild.Columns["yestim"]};
Relations.Add(new DataRelation("estimateestimatedetail",CPar,CChild));

TPar= Tables["estimatekind"];
TChild= Tables["estimate"];
CPar = new DataColumn[1]{TPar.Columns["idestimkind"]};
CChild = new DataColumn[1]{TChild.Columns["idestimkind"]};
Relations.Add(new DataRelation("estimatekindestimate",CPar,CChild));

TPar= Tables["manager"];
TChild= Tables["estimate"];
CPar = new DataColumn[1]{TPar.Columns["idman"]};
CChild = new DataColumn[1]{TChild.Columns["idman"]};
Relations.Add(new DataRelation("managerestimate",CPar,CChild));

TPar= Tables["expirationkind"];
TChild= Tables["estimate"];
CPar = new DataColumn[1]{TPar.Columns["idexpirationkind"]};
CChild = new DataColumn[1]{TChild.Columns["idexpirationkind"]};
Relations.Add(new DataRelation("expirationkindestimate",CPar,CChild));

TPar= Tables["currency"];
TChild= Tables["estimate"];
CPar = new DataColumn[1]{TPar.Columns["idcurrency"]};
CChild = new DataColumn[1]{TChild.Columns["idcurrency"]};
Relations.Add(new DataRelation("currencyestimate",CPar,CChild));

TPar= Tables["registrymainview"];
TChild= Tables["estimate"];
CPar = new DataColumn[1]{TPar.Columns["idreg"]};
CChild = new DataColumn[1]{TChild.Columns["idreg"]};
Relations.Add(new DataRelation("registrymainviewestimate",CPar,CChild));

}
}
}
