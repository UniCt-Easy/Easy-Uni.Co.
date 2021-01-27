
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


namespace taxrateregionstart_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable taxrateregionstart{get { return this.Tables["taxrateregionstart"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable taxrateregionbracket{get { return this.Tables["taxrateregionbracket"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable geo_region_view{get { return this.Tables["geo_region_view"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable taxrateregionstartview{get { return this.Tables["taxrateregionstartview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable tax{get { return this.Tables["tax"];}}

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
	T= new DataTable("taxrateregionstart");
	C= new DataColumn("idregion", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idtaxrateregionstart", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("start", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("enforcement", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idregion"], 	T.Columns["taxcode"], 	T.Columns["idtaxrateregionstart"]};
	T.PrimaryKey = key;

	T= new DataTable("taxrateregionbracket");
	C= new DataColumn("idregion", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idtaxrateregionstart", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nbracket", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("rate", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("minamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("maxamount", typeof(System.Decimal), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idregion"], 	T.Columns["taxcode"], 	T.Columns["idtaxrateregionstart"], 	T.Columns["nbracket"]};
	T.PrimaryKey = key;

	T= new DataTable("geo_region_view");
	C= new DataColumn("idregion", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("oldregion", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("newregion", typeof(System.Int32), ""));
	C= new DataColumn("idnation", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idcontinent", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nationdatestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("nationdatestop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("oldnation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("newnation", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idregion"], 	T.Columns["idnation"]};
	T.PrimaryKey = key;

	T= new DataTable("taxrateregionstartview");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxref", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idregion", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idtaxrateregionstart", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("region", typeof(System.String), ""));
	C= new DataColumn("start", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("enforcement", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["taxcode"], 	T.Columns["idregion"], 	T.Columns["idtaxrateregionstart"]};
	T.PrimaryKey = key;

	T= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appliancebasis", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("fiscaltaxcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagunabatable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("geoappliance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_cost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_debit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_pay", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxablecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("taxkind", typeof(System.Int16), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["taxcode"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["taxrateregionstart"];
TChild= Tables["taxrateregionbracket"];
CPar = new DataColumn[3]{TPar.Columns["idregion"], TPar.Columns["taxcode"], TPar.Columns["idtaxrateregionstart"]};
CChild = new DataColumn[3]{TChild.Columns["idregion"], TChild.Columns["taxcode"], TChild.Columns["idtaxrateregionstart"]};
Relations.Add(new DataRelation("taxrateregionstart_taxrateregionbracket",CPar,CChild));

TPar= Tables["geo_region_view"];
TChild= Tables["taxrateregionstart"];
CPar = new DataColumn[1]{TPar.Columns["idregion"]};
CChild = new DataColumn[1]{TChild.Columns["idregion"]};
Relations.Add(new DataRelation("geo_region_view_taxrateregionstart",CPar,CChild));

TPar= Tables["tax"];
TChild= Tables["taxrateregionstart"];
CPar = new DataColumn[1]{TPar.Columns["taxcode"]};
CChild = new DataColumn[1]{TChild.Columns["taxcode"]};
Relations.Add(new DataRelation("tax_taxrateregionstart",CPar,CChild));

}
}
}
