
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


namespace no_table_wiz_cfpiva_duplicata {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable no_table{get { return Tables["no_table"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable registryclass{get { return Tables["registryclass"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable registrymainview{get { return Tables["registrymainview"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

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
	T= new DataTable("no_table");
	C= new DataColumn("idnotable", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idnotable"]};
	T.PrimaryKey = key;

	T= new DataTable("registryclass");
	C= new DataColumn("idregistryclass", typeof(System.String), "");
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

	C= new DataColumn("flagbadgecode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagbadgecode_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagCF", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagcf_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagcfbutton", typeof(System.String), ""));
	C= new DataColumn("flagextmatricula", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagextmatricula_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagfiscalresidence", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagfiscalresidence_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagforeigncf", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagforeigncf_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flaghuman", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flaginfofromcfbutton", typeof(System.String), ""));
	C= new DataColumn("flagmaritalstatus", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagmaritalstatus_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagmaritalsurname", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagmaritalsurname_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagothers", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagothers_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagp_iva", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagp_iva_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagqualification", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagqualification_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagresidence", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagresidence_forced", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagtitle", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagtitle_forced", typeof(System.String), "");
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
	key = new DataColumn[1]{
	T.Columns["idregistryclass"]};
	T.PrimaryKey = key;

	T= new DataTable("registrymainview");
	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idregistryclass", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("registryclass", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("surname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forename", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("p_iva", typeof(System.String), ""));
	C= new DataColumn("residence", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("coderesidence", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("residencekind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annotation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("birthdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("city", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("gender", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("foreigncf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("qualification", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idmaritalstatus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("maritalstatus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idregistrykind", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("sortcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("registrykind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("human", typeof(System.String), ""));
	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("badgecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("maritalsurname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcategory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("category", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("extmatricula", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcentralizedcategory", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("location", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idnation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("authorization_free", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("multi_cf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("toredirect", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idaccmotivedebit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codemotivedebit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotivecredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codemotivecredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ccp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagbankitaliaproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ipa_fe", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flag_pa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sdi_norifamm", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sdi_defrifamm", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idreg"]};
	T.PrimaryKey = key;

}
}
}
