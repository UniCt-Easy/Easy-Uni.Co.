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

namespace import_flow_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable import_flow{get { return Tables["import_flow"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenseyear{get { return Tables["expenseyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable fin{get { return Tables["fin"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable upb{get { return Tables["upb"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable registry{get { return Tables["registry"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensephase{get { return Tables["expensephase"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensesorted{get { return Tables["expensesorted"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind{get { return Tables["sortingkind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomeyear{get { return Tables["incomeyear"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomesorted{get { return Tables["incomesorted"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expense{get { return Tables["expense"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable income{get { return Tables["income"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenselast{get { return Tables["expenselast"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomelast{get { return Tables["incomelast"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenseview{get { return Tables["expenseview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomeview{get { return Tables["incomeview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable finvar{get { return Tables["finvar"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable finvardetail{get { return Tables["finvardetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable config{get { return Tables["config"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomephase{get { return Tables["incomephase"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payment{get { return Tables["payment"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable proceeds{get { return Tables["proceeds"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable paymethod{get { return Tables["paymethod"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable entry{get { return Tables["entry"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable entrydetail{get { return Tables["entrydetail"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable import_flow_coge{get { return Tables["import_flow_coge"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable paymenttransmission{get { return Tables["paymenttransmission"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable proceedstransmission{get { return Tables["proceedstransmission"];}}

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
	T= new DataTable("import_flow");
	C= new DataColumn("idimportflow", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("id_ruolo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("categoria_ruolo", typeof(System.String), ""));
	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idregistrypaymethod", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("data_liquidazione", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("importo", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("descrizione_liq", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("esercizio", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("E_S", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("codefin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("anno_accimp", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("numero_accimp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cod_prodotto", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("id_liq", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("id_inc", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("data_elaborazione", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("manrev", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("variazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("partite_giro", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idimportflow_parent", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("regtime", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("assegnazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codtipoclass1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sortcode1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codtipoclass2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sortcode2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codtipoclass3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sortcode3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codtipoclass4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sortcode4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codtipoclass5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sortcode5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("natura_mandato_CMR", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cod_cassiere", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("fruttifero", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("datacont_manreve", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("datadoc", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("handlingbankcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nfase_accimp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("external_reference", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nmanreve", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("neletrasm", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idimportflow"]};
	T.PrimaryKey = key;

	T= new DataTable("expenseyear");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ayear"], 	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("fin");
	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codefin", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfin"]};
	T.PrimaryKey = key;

	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idupb"]};
	T.PrimaryKey = key;

	T= new DataTable("registry");
	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idreg"]};
	T.PrimaryKey = key;

	T= new DataTable("expensephase");
	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nphase"]};
	T.PrimaryKey = key;

	T= new DataTable("expensesorted");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.Int32), "");
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

	T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
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
	key = new DataColumn[3]{
	T.Columns["idexp"], 	T.Columns["idsor"], 	T.Columns["idsubclass"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
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

	T.Columns.Add(new DataColumn("flagdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelfordate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv5", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nodatelabel", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nphaseexpense", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("nphaseincome", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("totalexpression", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("incomeyear");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idinc"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("incomesorted");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.Int32), "");
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

	T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
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
	key = new DataColumn[3]{
	T.Columns["idinc"], 	T.Columns["idsor"], 	T.Columns["idsubclass"]};
	T.PrimaryKey = key;

	T= new DataTable("expense");
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
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
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

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idclawback", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("parentidexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idformerexpense", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("external_reference", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("income");
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
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
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

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("parentidinc", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("external_reference", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iddeputy", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idregistrypaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idser", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ivaamount", typeof(System.Decimal), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymentdescr", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("servicestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("servicestop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("refexternaldoc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccdebit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("biccode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymethod_flag", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymethod_allowdeputy", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("extracode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("kpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idchargehandling", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idexp"]};
	T.PrimaryKey = key;

	T= new DataTable("incomelast");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idpro", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idacccredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("kpro", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!livprecedente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nphase", typeof(System.Byte), ""));
	C= new DataColumn("phase", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmov", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("parentidexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentymov", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("parentnmov", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idformerexpense", typeof(System.Int32), ""));
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codefin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("finance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("upb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	C= new DataColumn("ypay", typeof(System.Int16), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("npay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymentadate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayearstartamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idregistrypaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iddeputy", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("deputy", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refexternaldoc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentdescr", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idser", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("service", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("servicestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("servicestop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ivaamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("totflag", typeof(System.Byte), ""));
	C= new DataColumn("flagarrear", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idclawback", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("clawback", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpay", typeof(System.Int32), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idexp"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!livprecedente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nphase", typeof(System.Byte), ""));
	C= new DataColumn("phase", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmov", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("parentymov", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("parentnmov", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentidinc", typeof(System.Int32), ""));
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codefin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("finance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("upb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ypro", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("npro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayearstartamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unpartitioned", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Byte), ""));
	C= new DataColumn("totflag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagarrear", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpro", typeof(System.Int32), ""));
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
	key = new DataColumn[2]{
	T.Columns["idinc"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("finvar");
	C= new DataColumn("nvar", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yvar", typeof(System.Int16), "");
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

	T.Columns.Add(new DataColumn("enactment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("enactmentdate", typeof(System.DateTime), ""));
	C= new DataColumn("flagcredit", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagprevision", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagproceeds", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagsecondaryprev", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nenactment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("official", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nofficial", typeof(System.Int32), ""));
	C= new DataColumn("variationkind", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfinvarstatus", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("idenactment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("reason", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("limit", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("annotation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinvarkind", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("moneytransfer", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("varflag", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["yvar"], 	T.Columns["nvar"]};
	T.PrimaryKey = key;

	T= new DataTable("finvardetail");
	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nvar", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yvar", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("limit", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("annotation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idlcard", typeof(System.Int32), ""));
	C= new DataColumn("rownum", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idunderwriting", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("prevision2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("createexpense", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("residual", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["nvar"], 	T.Columns["yvar"], 	T.Columns["rownum"]};
	T.PrimaryKey = key;

	T= new DataTable("config");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("agencycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appropriationphasecode", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("assessmentphasecode", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("asset_flagnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("asset_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("assetload_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("boxpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("finvarofficial_default", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("casualcontract_flagrestart", typeof(System.String), ""));
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
	T.Columns.Add(new DataColumn("expense_expiringdays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("expensephase", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("flagautopayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagautoproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagepexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagfruitful", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagpayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagrefund", typeof(System.String), ""));
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
	T.Columns.Add(new DataColumn("idregauto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("importappname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("income_expiringdays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("incomephase", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("linktoinvoice", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("minpayment", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("minrefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("motivelen", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("motiveprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motiveseparator", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("payment_finlevel", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("payment_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("payment_flagautoprintdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("prevpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("proceeds_finlevel", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("proceeds_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("proceeds_flagautoprintdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("profservice_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refundagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("wageaddition_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idivapayperiodicity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsortingkind1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsortingkind2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsortingkind3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("fin_kind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("taxvaliditykind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("flag_paymentamount", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("automanagekind", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flag_autodocnumbering", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagbank_grouping", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cashvaliditykind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("wageimportappname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("balancekind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("idpaymethodabi", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpaymethodnoabi", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("iban_f24", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cudactivitycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("startivabalance", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flagivapaybyrow", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_unabatable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_unabatable_refund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("invoice_flagregister", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("default_idfinvarstatus", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagivaregphase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainflagpayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainflagrefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainidfinivapayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainidfinivarefund", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainminpayment", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainminrefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainpaymentagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainrefundagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainflagivaregphase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainstartivabalance", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainidacc_unabatable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainidacc_unabatable_refund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment_internal", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund_internal", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagva3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagrefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagpayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refundagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymentagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivarefund12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivapayment12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("minrefund12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("minpayment12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idacc_ivapayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivarefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment_internal12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund_internal12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("startivabalance12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainrefundagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainpaymentagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainflagrefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainflagpayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainidfinivarefund12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainidfinivapayment12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainminrefund12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainminpayment12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainstartivabalance12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idreg_csa", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("finvar_warnmail", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagdirectcsaclawback", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_revenue_gross_csa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfinincome_gross_csa", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor1_stock", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor2_stock", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor3_stock", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinpscenter", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idivapayperiodicity_instit", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfin_store", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagpcashautopayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagpcashautoproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lcard", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("booking_on_invoice", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("itineration_directauth", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("email_f24", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("csa_flaggroupby_income", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("csa_flaggroupby_expense", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("csa_flaglinktoexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsiopeincome_csa", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idacc_invoicetoemit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_invoicetoreceive", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("epannualthreeshold", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("incomephase");
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

	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nphase"]};
	T.PrimaryKey = key;

	T= new DataTable("payment");
	C= new DataColumn("npay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypay", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("adate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("annulmentdate", typeof(System.DateTime), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("printdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idstamphandling", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("kpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("kpaymenttransmission", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("npay_treasurer", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kpay"]};
	T.PrimaryKey = key;

	T= new DataTable("proceeds");
	C= new DataColumn("npro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypro", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("annulmentdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("printdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("kpro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("kproceedstransmission", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idstamphandling", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("npro_treasurer", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kpro"]};
	T.PrimaryKey = key;

	T= new DataTable("paymethod");
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("allowdeputy", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("methodbankcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("footerpaymentadvice", typeof(System.String), ""));
	C= new DataColumn("idpaymethod", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("committeecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("committeeamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("minamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("maxamount", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idpaymethod"]};
	T.PrimaryKey = key;

	T= new DataTable("entry");
	C= new DataColumn("nentry", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yentry", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("identrykind", typeof(System.Int32), ""));
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
	T.Columns.Add(new DataColumn("idrelated", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("locked", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("official", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["yentry"], 	T.Columns["nentry"]};
	T.PrimaryKey = key;

	T= new DataTable("entrydetail");
	C= new DataColumn("ndetail", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nentry", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yentry", typeof(System.Int16), "");
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

	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccmotive", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("competencystart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("competencystop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idsor1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("!codice", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!conto", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!dare", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!avere", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ndetail"], 	T.Columns["nentry"], 	T.Columns["yentry"]};
	T.PrimaryKey = key;

	T= new DataTable("import_flow_coge");
	C= new DataColumn("idimportflow", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idimportflow_prog", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cod_tipopers_ca", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cod_tipofisc_ca", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cod_tipoliq_ca", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcolonna_ca", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("importo", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("fasi_array", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idimportflow"], 	T.Columns["idimportflow_prog"]};
	T.PrimaryKey = key;

	T= new DataTable("paymenttransmission");
	C= new DataColumn("npaymenttransmission", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypaymenttransmission", typeof(System.Int16), "");
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

	T.Columns.Add(new DataColumn("transmissiondate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("kpaymenttransmission", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagmailsent", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("transmissionkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("streamdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("bankdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("flagtransmissionenabled", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("noep", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kpaymenttransmission"]};
	T.PrimaryKey = key;

	T= new DataTable("proceedstransmission");
	C= new DataColumn("nproceedstransmission", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yproceedstransmission", typeof(System.Int16), "");
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

	T.Columns.Add(new DataColumn("transmissiondate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("kproceedstransmission", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("transmissionkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("streamdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("flagtransmissionenabled", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("noep", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kproceedstransmission"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["entry"];
TChild= Tables["entrydetail"];
CPar = new DataColumn[2]{TPar.Columns["yentry"], TPar.Columns["nentry"]};
CChild = new DataColumn[2]{TChild.Columns["yentry"], TChild.Columns["nentry"]};
Relations.Add(new DataRelation("entry_entrydetail",CPar,CChild));

TPar= Tables["proceedstransmission"];
TChild= Tables["proceeds"];
CPar = new DataColumn[1]{TPar.Columns["kproceedstransmission"]};
CChild = new DataColumn[1]{TChild.Columns["kproceedstransmission"]};
Relations.Add(new DataRelation("proceedstransmission_proceeds",CPar,CChild));

TPar= Tables["paymenttransmission"];
TChild= Tables["payment"];
CPar = new DataColumn[1]{TPar.Columns["kpaymenttransmission"]};
CChild = new DataColumn[1]{TChild.Columns["kpaymenttransmission"]};
Relations.Add(new DataRelation("paymenttransmission_payment",CPar,CChild));

TPar= Tables["finvar"];
TChild= Tables["finvardetail"];
CPar = new DataColumn[2]{TPar.Columns["yvar"], TPar.Columns["nvar"]};
CChild = new DataColumn[2]{TChild.Columns["yvar"], TChild.Columns["nvar"]};
Relations.Add(new DataRelation("finvar_finvardetail",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomelast"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("income_incomelast",CPar,CChild));

TPar= Tables["proceeds"];
TChild= Tables["incomelast"];
CPar = new DataColumn[1]{TPar.Columns["kpro"]};
CChild = new DataColumn[1]{TChild.Columns["kpro"]};
Relations.Add(new DataRelation("proceeds_incomelast",CPar,CChild));

TPar= Tables["payment"];
TChild= Tables["expenselast"];
CPar = new DataColumn[1]{TPar.Columns["kpay"]};
CChild = new DataColumn[1]{TChild.Columns["kpay"]};
Relations.Add(new DataRelation("payment_expenselast",CPar,CChild));

TPar= Tables["paymethod"];
TChild= Tables["expenselast"];
CPar = new DataColumn[1]{TPar.Columns["idpaymethod"]};
CChild = new DataColumn[1]{TChild.Columns["idpaymethod"]};
Relations.Add(new DataRelation("paymethod_expenselast",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expenselast"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("expense_expenselast",CPar,CChild));

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

TPar= Tables["expense"];
TChild= Tables["income"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idpayment"]};
Relations.Add(new DataRelation("expense_income",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["parentidexp"]};
Relations.Add(new DataRelation("expenseexpense",CPar,CChild));

TPar= Tables["registry"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["idreg"]};
CChild = new DataColumn[1]{TChild.Columns["idreg"]};
Relations.Add(new DataRelation("registryexpense",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expense"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idpayment"]};
Relations.Add(new DataRelation("expense_expense",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomesorted"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("income_incomesorted",CPar,CChild));

TPar= Tables["income"];
TChild= Tables["incomeyear"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("income_incomeyear",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expensesorted"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("expenseexpensesorted",CPar,CChild));

TPar= Tables["expense"];
TChild= Tables["expenseyear"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("expenseexpenseyear",CPar,CChild));

TPar= Tables["upb"];
TChild= Tables["expenseyear"];
CPar = new DataColumn[1]{TPar.Columns["idupb"]};
CChild = new DataColumn[1]{TChild.Columns["idupb"]};
Relations.Add(new DataRelation("upbexpenseyear",CPar,CChild));

TPar= Tables["fin"];
TChild= Tables["expenseyear"];
CPar = new DataColumn[1]{TPar.Columns["idfin"]};
CChild = new DataColumn[1]{TChild.Columns["idfin"]};
Relations.Add(new DataRelation("finexpenseyear",CPar,CChild));

TPar= Tables["expenselast"];
TChild= Tables["import_flow"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["id_liq"]};
Relations.Add(new DataRelation("expenselast_import_flow",CPar,CChild));

TPar= Tables["incomelast"];
TChild= Tables["import_flow"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["id_inc"]};
Relations.Add(new DataRelation("incomelast_import_flow",CPar,CChild));

}
}
}
