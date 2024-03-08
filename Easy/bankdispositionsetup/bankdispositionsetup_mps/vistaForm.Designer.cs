
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


namespace bankdispositionsetup_mps {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable giornaledicassa{get { return this.Tables["giornaledicassa"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable gdc{get { return this.Tables["gdc"];}}
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
	T= new DataTable("giornaledicassa");
	T.Columns.Add(new DataColumn("DATAPRODUZIONEFLUSSO", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("CODICEFILIALE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CODICEENTE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ESERCIZIOFINANZIARIO", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DATADIRIFERIMENTO", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("TIPORECORD", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("PROGRESSIVODIFLUSSO", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("NUMEROORDINATIVO_O_CARTACONTABILE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("PROGRESSIVODISPOSIZIONE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FLAGORDINATIVO_CARTACONTABILE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("BENEFICIARIO_O_OBBLIGATO", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("FLAGCOMPETENZA_RESIDUI", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FLAGENTRATE_USCITE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("IMPORTO", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("FLAGFRUTTIFERO_INFRUTTIFERO", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("IMPORTOFRUTTIFERO", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("STORNO", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("BOLLETTA", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CONTOCORRENTE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DATAVALUTA", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("VALUTASPECIALE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("GIROFONDI", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DIVISAOPERAZIONE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CONTROVALOREDIVISAOPERAZIONE", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("MODALITADIESECUZIONE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CARTACONTABILE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DATIRISERVATIALLENTE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DESCRIZIONEOPERAZIONE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CRO_NUMEROASSEGNO", typeof(System.Int64), ""));
	T.Columns.Add(new DataColumn("FILLER", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("gdc");
	T.Columns.Add(new DataColumn("TIPORECORD1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("PROGRESSIVODIFLUSSO1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("TIPOFLUSSO", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DATAPRODUZIONEFLUSSO", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("PROGRESSIVOPERDATA", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CODICEFILIALE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CODICEENTE", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ANAGRAFICAENTE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ESERCIZIOFINANZIARIO", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DATADIRIFERIMENTO", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("DIVISA", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("FILLER1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("TIPORECORD3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PROGRESSIVODIFLUSSO3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("RISCOSSIONIGIORNATA", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PAGAMENTIGIORNATA", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("RISCOSSIONIGIORNATEPRECEDENTI", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PAGAMENTIGIORNATEPRECEDENTI", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("RISCOSSIONITOTALI", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PAGAMENTITOTALI", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("SALDOINIZIALE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("SALDOALLADATARIFERIMENTO", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("SALDOFRUTTIFERO", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("SALDOINFRUTTIFERO", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ECCEDENZAGIACENZAMASSIMA", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("FILLER3", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("bankdispositionsetup");
	T.Columns.Add(new DataColumn("ayear", typeof(System.Int32), ""));
	Tables.Add(T);
}
}
}
