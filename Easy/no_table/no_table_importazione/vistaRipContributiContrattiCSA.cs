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

namespace notable_importazione {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaRipContributiContrattiCSA: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable csa_contract{get { return Tables["csa_contract"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable csa_contractkindyear{get { return Tables["csa_contractkindyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable csa_contractkind{get { return Tables["csa_contractkind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable csa_contracttax{get { return Tables["csa_contracttax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable csa_contracttaxexpense{get { return Tables["csa_contracttaxexpense"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaRipContributiContrattiCSA(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "vistaRipContributiContrattiCSA";
Prefix = "";
Namespace = "http://tempuri.org/vistaRipContributiContrattiCSA.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("csa_contract");
	C= new DataColumn("idcsa_contract", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ycontract", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ncontract", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcsa_contractkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagkeepalive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_main", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idexp_main", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfin_main", typeof(System.Int32), ""));
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

	T.Columns.Add(new DataColumn("flagrecreate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor_siope_main", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idunderwriting", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idepexp_main", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idcsa_contract"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("csa_contractkindyear");
	C= new DataColumn("idcsa_contractkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_main", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfin_main", typeof(System.Int32), ""));
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

	T.Columns.Add(new DataColumn("idsor_siope_main", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idcsa_contractkind"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("csa_contractkind");
	C= new DataColumn("idcsa_contractkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("contractkindcode", typeof(System.String), "");
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

	C= new DataColumn("flagcr", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagkeepalive", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idunderwriting", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idcsa_contractkind"]};
	T.PrimaryKey = key;

	T= new DataTable("csa_contracttax");
	C= new DataColumn("idcsa_contract", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcsa_contracttax", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("vocecsa", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idacc", typeof(System.String), ""));
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

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor_siope", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idepexp", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idcsa_contract"], 	T.Columns["idcsa_contracttax"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("csa_contracttaxexpense");
	C= new DataColumn("idcsa_contract", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcsa_contracttax", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ndetail", typeof(System.Int32), "");
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

	T.Columns.Add(new DataColumn("idexp", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idcsa_contract"], 	T.Columns["idcsa_contracttax"], 	T.Columns["ayear"], 	T.Columns["ndetail"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["csa_contracttax"];
TChild= Tables["csa_contracttaxexpense"];
CPar = new DataColumn[3]{TPar.Columns["idcsa_contract"], TPar.Columns["idcsa_contracttax"], TPar.Columns["ayear"]};
CChild = new DataColumn[3]{TChild.Columns["idcsa_contract"], TChild.Columns["idcsa_contracttax"], TChild.Columns["ayear"]};
Relations.Add(new DataRelation("csa_contracttax_csa_contracttaxexpense",CPar,CChild));

TPar= Tables["csa_contract"];
TChild= Tables["csa_contracttax"];
CPar = new DataColumn[2]{TPar.Columns["idcsa_contract"], TPar.Columns["ayear"]};
CChild = new DataColumn[2]{TChild.Columns["idcsa_contract"], TChild.Columns["ayear"]};
Relations.Add(new DataRelation("csa_contract_csa_contracttax",CPar,CChild));

TPar= Tables["csa_contractkind"];
TChild= Tables["csa_contractkindyear"];
CPar = new DataColumn[1]{TPar.Columns["idcsa_contractkind"]};
CChild = new DataColumn[1]{TChild.Columns["idcsa_contractkind"]};
Relations.Add(new DataRelation("csa_contractkind_csa_contractkindyear",CPar,CChild));

TPar= Tables["csa_contractkind"];
TChild= Tables["csa_contract"];
CPar = new DataColumn[1]{TPar.Columns["idcsa_contractkind"]};
CChild = new DataColumn[1]{TChild.Columns["idcsa_contractkind"]};
Relations.Add(new DataRelation("csa_contractkind_csa_contract",CPar,CChild));

}
}
}
