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

namespace bankdispositionsetup_carime {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable bankdispositionsetup{get { return this.Tables["bankdispositionsetup"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable carime{get { return this.Tables["carime"];}}

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
	T= new DataTable("bankdispositionsetup");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("carime");
	T.Columns.Add(new DataColumn("codiceistituto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codicedipendenza", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codiceente", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codiceesercizio", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codicedivisaente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("abi", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cab", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numeroconto", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("datamovimento", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("tipomovimento", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("numdocumento", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numsub", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numricevuta", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numcapitolo", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numarticolo", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("annoresiduo", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codicedivisacliente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("importodivisacliente", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoricevuta", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("segno", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codiceesecuzione", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codicebolli", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("importibolli", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("codicespese", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("importospese", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("datavaluta", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("numdocrif", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numsubrif", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("abicliente", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cabcliente", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("descrizionecliente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codicecausale", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("causale1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("causale2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("causale3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codicetipoimputazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("imputazionefruttifera", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("imputazioneinfruttifera", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("imputazionevincolata", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("imputazionedelegazioni", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("imputazionegiornaliera", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("destfruttiferainfruttifera", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("indicatoreadisposizione", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("entratauscita", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codicedivisaesercizio", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("importodivisaente", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("space01", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("space02", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("space03", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codiceresiduo", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numerosubcaricati", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numerosottoconto", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codicefornitore", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numerocro", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("numeroassegnoda", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("numeroassegnoa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("descrizionecausaleaggiuntiva", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codicebeneficiario", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("filler", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("tipdoc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("indreg", typeof(System.String), ""));
	Tables.Add(T);
}
}
}
