
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


namespace exhibitedcuddeduction_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable exhibitedcuddeduction{get { return this.Tables["exhibitedcuddeduction"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable deduction{get { return this.Tables["deduction"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable deductioncode{get { return this.Tables["deductioncode"];}}

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
	T= new DataTable("exhibitedcuddeduction");
	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexhibitedcud", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddeduction", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idcon"], 	T.Columns["idexhibitedcud"], 	T.Columns["iddeduction"]};
	T.PrimaryKey = key;

	T= new DataTable("deduction");
	C= new DataColumn("iddeduction", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("calculationkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxablecode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("evaluatesp", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("validitystart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("validitystop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("evaluationorder", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagdeductibleexpense", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["iddeduction"]};
	T.PrimaryKey = key;

	T= new DataTable("deductioncode");
	C= new DataColumn("iddeduction", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("code", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("longdescription", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("exemption", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("maximal", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("rate", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["iddeduction"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["deduction"];
TChild= Tables["exhibitedcuddeduction"];
CPar = new DataColumn[1]{TPar.Columns["iddeduction"]};
CChild = new DataColumn[1]{TChild.Columns["iddeduction"]};
Relations.Add(new DataRelation("deductionexhibitedcuddeduction",CPar,CChild));

TPar= Tables["deductioncode"];
TChild= Tables["exhibitedcuddeduction"];
CPar = new DataColumn[1]{TPar.Columns["iddeduction"]};
CChild = new DataColumn[1]{TChild.Columns["iddeduction"]};
Relations.Add(new DataRelation("deductioncodeexhibitedcuddeduction",CPar,CChild));

}
}
}
