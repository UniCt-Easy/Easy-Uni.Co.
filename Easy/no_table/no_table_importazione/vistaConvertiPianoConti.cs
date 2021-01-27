
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


namespace notable_importazione {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaConvertiPianoConti: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable account{get { return Tables["account"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable accountlookup{get { return Tables["accountlookup"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaConvertiPianoConti(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "vistaConvertiPianoConti";
Prefix = "";
Namespace = "http://tempuri.org/vistaConvertiPianoConti.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("account");
	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagregistry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagtransitory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccountkind", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridacc", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idpatrimony", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idplaccount", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagprofit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagloss", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("placcount_sign", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("patrimony_sign", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcompetency", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idacc_special", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagenablebudgetprev", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagaccountusage", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idacc"]};
	T.PrimaryKey = key;

	T= new DataTable("accountlookup");
	C= new DataColumn("newidacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("oldidacc", typeof(System.String), "");
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

	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["newidacc"], 	T.Columns["oldidacc"]};
	T.PrimaryKey = key;

}
}
}
