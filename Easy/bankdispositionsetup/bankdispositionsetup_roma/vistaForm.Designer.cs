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

ï»¿namespace bankdispositionsetup_roma {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable roma{get { return this.Tables["roma"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable bankdispositionsetup{get { return this.Tables["bankdispositionsetup"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

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
	T= new DataTable("roma");
	T.Columns.Add(new DataColumn("ente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("esercdocumento", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("numtipomovimento", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rifbanca", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numdocumento", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("progrdoc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("datapagamento", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("importo", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("divisa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codicebollo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("creditoredebitore", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codicessd", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("causale", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("tipo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("descrizione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("datavaluta", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("capitolo", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("articolo", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("annoresiduo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("importooriginalesub", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("divisaios", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("datacaricamento", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("tipopagamento", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("datavalutabeneficiario", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("abi", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cab", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("conto", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("indirizzo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cap", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("localita", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("voceeconomica", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("competenzaresidui", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("attribuito", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("dataimportazione", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("tipdoc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("segno", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("indreg", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("bankdispositionsetup");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
	T.PrimaryKey = key;

}
}
}
