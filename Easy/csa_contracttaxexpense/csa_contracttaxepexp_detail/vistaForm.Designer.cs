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

namespace csa_contracttaxepexp_detail {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable csa_contracttaxepexp{get { return Tables["csa_contracttaxepexp"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable epexp{get { return Tables["epexp"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable fase_epexp{get { return Tables["fase_epexp"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable epexpview{get { return Tables["epexpview"];}}

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
	T= new DataTable("csa_contracttaxepexp");
	C= new DataColumn("idcsa_contract", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcsa_contracttax", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ndetail", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("quota", typeof(System.Decimal), "");
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

	T.Columns.Add(new DataColumn("idepexp", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idcsa_contract"], 	T.Columns["idcsa_contracttax"], 	T.Columns["ndetail"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("epexp");
	C= new DataColumn("idepexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idrelated", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nepexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridepexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	C= new DataColumn("yepexp", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idepexp"]};
	T.PrimaryKey = key;

	T= new DataTable("fase_epexp");
	C= new DataColumn("nphase", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("descrizione", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nphase"]};
	T.PrimaryKey = key;

	T= new DataTable("epexpview");
	C= new DataColumn("idepexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yepexp", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nepexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("phase", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("amount3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("amount4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("amount5", typeof(System.Decimal), ""));
	C= new DataColumn("totamount", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount5", typeof(System.Decimal), ""));
	C= new DataColumn("totcurramount", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("available", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available5", typeof(System.Decimal), ""));
	C= new DataColumn("totavailable", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("totalcost", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("totaldebit", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("account", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("upb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridepexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentyepexp", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("parentnepexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idrelated", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagaccountusage", typeof(System.Int32), ""));
	C= new DataColumn("rateiattivi", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("rateipassivi", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("riscontiattivi", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("riscontipassivi", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("debit", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("credit", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("cost", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("revenue", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("fixedassets", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("freeusesurplus", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("captiveusesurplus", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("reserve", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idepexp"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["epexpview"];
TChild= Tables["csa_contracttaxepexp"];
CPar = new DataColumn[1]{TPar.Columns["idepexp"]};
CChild = new DataColumn[1]{TChild.Columns["idepexp"]};
Relations.Add(new DataRelation("epexpview_csa_contracttaxepexp",CPar,CChild));

TPar= Tables["epexp"];
TChild= Tables["csa_contracttaxepexp"];
CPar = new DataColumn[1]{TPar.Columns["idepexp"]};
CChild = new DataColumn[1]{TChild.Columns["idepexp"]};
Relations.Add(new DataRelation("epexp_csa_contracttaxepexp",CPar,CChild));

}
}
}
