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

namespace purchasedetail_single {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable purchasedetail{get { return this.Tables["purchasedetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable listview{get { return this.Tables["listview"];}}

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
	T= new DataTable("purchasedetail");
	C= new DataColumn("idpurchase", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddetail", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idlist", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("quantity", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("unitiva", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unitprice", typeof(System.Decimal), ""));
	Tables.Add(T);
	//Primary Key
	T.PrimaryKey =  new DataColumn[]{T.Columns["idpurchase"], T.Columns["iddetail"]};;

	T= new DataTable("listview");
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
	T.Columns.Add(new DataColumn("package", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idunit", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("unit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("unitsforpackage", typeof(System.Int32), ""));
	C= new DataColumn("has_expiry", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idlistclass", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codelistclass", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("listclass", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("pic", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("timesupply", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nmaxorder", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("authrequired", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("assetkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagvisiblekind", typeof(System.Byte), ""));
	Tables.Add(T);
	//Primary Key
	T.PrimaryKey =  new DataColumn[]{T.Columns["idlist"]};;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["listview"];
TChild= Tables["purchasedetail"];
CPar = new DataColumn[1]{TPar.Columns["idlist"]};
CChild = new DataColumn[1]{TChild.Columns["idlist"]};
Relations.Add(new DataRelation("listview_purchasedetail",CPar,CChild));

}
}
}
