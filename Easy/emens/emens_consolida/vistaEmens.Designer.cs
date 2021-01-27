
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


namespace emens_consolida {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class VistaEmens: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable Azienda{get { return this.Tables["Azienda"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable Collaboratore{get { return this.Tables["Collaboratore"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable log{get { return this.Tables["log"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable inpscenter{get { return this.Tables["inpscenter"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable Emens{get { return this.Tables["Emens"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable emenscontractkind{get { return this.Tables["emenscontractkind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable inpsactivity{get { return this.Tables["inpsactivity"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable otherinsurance{get { return this.Tables["otherinsurance"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public VistaEmens(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "VistaEmens";
this.Prefix = "";
this.Namespace = "http://tempuri.org/VistaEmens.xsd";
this.EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("Azienda");
	C= new DataColumn("AnnoMeseDenuncia", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("CFAzienda", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("RagSocAzienda", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CAP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ISTAT", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["AnnoMeseDenuncia"], 	T.Columns["CFAzienda"]};
	T.PrimaryKey = key;

	T= new DataTable("Collaboratore");
	C= new DataColumn("CFCollaboratore", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Cognome", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Nome", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CodiceComune", typeof(System.String), ""));
	C= new DataColumn("TipoRapporto", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CodiceAttivita", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Imponibile", typeof(System.String), ""));
	C= new DataColumn("Aliquota", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("AltraAss", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Dal", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Al", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodCalamita", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodCertificazione", typeof(System.String), ""));
	C= new DataColumn("AnnoMeseDenuncia", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("CFAzienda", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[5]{
	T.Columns["CFCollaboratore"], 	T.Columns["AnnoMeseDenuncia"], 	T.Columns["CFAzienda"], 	T.Columns["TipoRapporto"], 	T.Columns["Aliquota"]};
	T.PrimaryKey = key;

	T= new DataTable("log");
	T.Columns.Add(new DataColumn("nomefile", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("AnnoMeseDenuncia", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CFAzienda", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("esitolettura", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("inpscenter");
	C= new DataColumn("idinpscenter", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ccp", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinpscenter"]};
	T.PrimaryKey = key;

	T= new DataTable("Emens");
	C= new DataColumn("CFAzienda", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("AnnoMeseDenuncia", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("CFCollaboratore", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Cognome", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Nome", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CodiceComune", typeof(System.String), ""));
	C= new DataColumn("TipoRapporto", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CodiceAttivita", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Imponibile", typeof(System.String), ""));
	C= new DataColumn("Aliquota", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("AltraAss", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Dal", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Al", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodCalamita", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodCertificazione", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[5]{
	T.Columns["CFCollaboratore"], 	T.Columns["TipoRapporto"], 	T.Columns["Aliquota"], 	T.Columns["AnnoMeseDenuncia"], 	T.Columns["CFAzienda"]};
	T.PrimaryKey = key;

	T= new DataTable("emenscontractkind");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idemenscontractkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annotations", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagactivityrequested", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["ayear"], 	T.Columns["idemenscontractkind"]};
	T.PrimaryKey = key;

	T= new DataTable("inpsactivity");
	C= new DataColumn("activitycode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["activitycode"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;

	T= new DataTable("otherinsurance");
	C= new DataColumn("idotherinsurance", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idotherinsurance"], 	T.Columns["ayear"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["Azienda"];
TChild= Tables["Collaboratore"];
CPar = new DataColumn[2]{TPar.Columns["AnnoMeseDenuncia"], TPar.Columns["CFAzienda"]};
CChild = new DataColumn[2]{TChild.Columns["AnnoMeseDenuncia"], TChild.Columns["CFAzienda"]};
Relations.Add(new DataRelation("AziendaCollaboratore",CPar,CChild));

}
}
}
