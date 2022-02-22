
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


namespace underwritingappropriation_detail {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable underwritingappropriation{get { return this.Tables["underwritingappropriation"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable underwriting{get { return this.Tables["underwriting"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable upbunderwritingyearview{get { return this.Tables["upbunderwritingyearview"];}}

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
	T= new DataTable("underwritingappropriation");
	C= new DataColumn("idunderwriting", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexp", typeof(System.Int32), "");
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
	key = new DataColumn[2]{
	T.Columns["idunderwriting"], 	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("underwriting");
	C= new DataColumn("idunderwriting", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idunderwriter", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
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

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("codeunderwriting", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idunderwriting"]};
	T.PrimaryKey = key;

	T= new DataTable("upbunderwritingyearview");
	C= new DataColumn("idunderwriting", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("codeunderwriting", typeof(System.String), ""));
	C= new DataColumn("underwriting", typeof(System.String), "");
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

	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codefin", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("fin", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("finpart", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("initialprevision", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("varprevision", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("actualprevision", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("initialsecondaryprev", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("varsecondaryprev", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("actualsecondaryprev", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("totcreditpart", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("totpreceedspart", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("assessment", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("appropriation", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("proceeds", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("payment", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("incomeprevavailable", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("expenseprevavailable", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("proceedsprevavailable", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("paymentprevavailable", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("creditavailable", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("proceedsavailable", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idunderwriting"], 	T.Columns["idupb"], 	T.Columns["idfin"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["underwriting"];
TChild= Tables["underwritingappropriation"];
CPar = new DataColumn[1]{TPar.Columns["idunderwriting"]};
CChild = new DataColumn[1]{TChild.Columns["idunderwriting"]};
Relations.Add(new DataRelation("underwriting_underwritingappropriation",CPar,CChild));

}
}
}
