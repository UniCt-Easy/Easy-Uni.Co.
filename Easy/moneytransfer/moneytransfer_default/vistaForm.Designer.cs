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

namespace moneytransfer_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable moneytransfer{get { return Tables["moneytransfer"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable treasurersource{get { return Tables["treasurersource"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable treasurerdest{get { return Tables["treasurerdest"];}}

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
	T= new DataTable("moneytransfer");
	C= new DataColumn("ytransfer", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ntransfer", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idtreasurersource", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idtreasurerdest", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("yproceedspart", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nproceedspart", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("yvar", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nvar", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rownum", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("transferkind", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ytransfer"], 	T.Columns["ntransfer"]};
	T.PrimaryKey = key;

	T= new DataTable("treasurersource");
	T.Columns.Add(new DataColumn("address", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("agencycodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cabcodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cap", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("city", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("country", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("depcodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxnumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxprefix", typeof(System.String), ""));
	C= new DataColumn("flagdefault", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccmotive_payment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_proceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phoneprefix", typeof(System.String), ""));
	C= new DataColumn("codetreasurer", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idtreasurer", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("spexportexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagmultiexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("fileextension", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("spexportinc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("bic", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagfruitful", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cccbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cincbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbankcbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcabcbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ibancbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("siacodecbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("reccbikind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("trasmcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagbank_grouping", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("motivelen", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("motiveprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motiveseparator", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annotations", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagedisp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("billcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idtreasurer"]};
	T.PrimaryKey = key;

	T= new DataTable("treasurerdest");
	T.Columns.Add(new DataColumn("address", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("agencycodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cabcodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cap", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("city", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("country", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("depcodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxnumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxprefix", typeof(System.String), ""));
	C= new DataColumn("flagdefault", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccmotive_payment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_proceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phoneprefix", typeof(System.String), ""));
	C= new DataColumn("codetreasurer", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idtreasurer", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("spexportexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagmultiexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("fileextension", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("spexportinc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("bic", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagfruitful", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cccbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cincbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbankcbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcabcbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ibancbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("siacodecbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("reccbikind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("trasmcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagbank_grouping", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("motivelen", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("motiveprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motiveseparator", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annotations", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagedisp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("billcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idtreasurer"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["treasurersource"];
TChild= Tables["moneytransfer"];
CPar = new DataColumn[1]{TPar.Columns["idtreasurer"]};
CChild = new DataColumn[1]{TChild.Columns["idtreasurersource"]};
Relations.Add(new DataRelation("FK_treasurersource_moneytransfer",CPar,CChild));

TPar= Tables["treasurerdest"];
TChild= Tables["moneytransfer"];
CPar = new DataColumn[1]{TPar.Columns["idtreasurer"]};
CChild = new DataColumn[1]{TChild.Columns["idtreasurerdest"]};
Relations.Add(new DataRelation("FK_treasurerdest_moneytransfer",CPar,CChild));

}
}
}
