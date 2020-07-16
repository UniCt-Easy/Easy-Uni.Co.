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

namespace cab_default_anag {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable cab{get { return this.Tables["cab"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable geo_city{get { return this.Tables["geo_city"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable geo_country{get { return this.Tables["geo_country"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable bank{get { return this.Tables["bank"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable geo_cityview{get { return this.Tables["geo_cityview"];}}

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
	T= new DataTable("cab");
	C= new DataColumn("idbank", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcab", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("address", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cap", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("!banca", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!comune", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("location", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagusable", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idbank"], 	T.Columns["idcab"]};
	T.PrimaryKey = key;

	T= new DataTable("geo_city");
	C= new DataColumn("idcity", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("oldcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("newcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idcountry", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idcity"]};
	T.PrimaryKey = key;

	T= new DataTable("geo_country");
	C= new DataColumn("idcountry", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("province", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("oldcountry", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("newcountry", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idregion", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idcountry"]};
	T.PrimaryKey = key;

	T= new DataTable("bank");
	C= new DataColumn("idbank", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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
	key = new DataColumn[1]{
	T.Columns["idbank"]};
	T.PrimaryKey = key;

	T= new DataTable("geo_cityview");
	C= new DataColumn("idcity", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("oldcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("newcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	C= new DataColumn("idcountry", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("provincecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("country", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("oldcountry", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("newcountry", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("countrydatestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("countrydatestop", typeof(System.DateTime), ""));
	C= new DataColumn("idregion", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("region", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("regiondatestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("regiondatestop", typeof(System.DateTime), ""));
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
	key = new DataColumn[4]{
	T.Columns["idcity"], 	T.Columns["idcountry"], 	T.Columns["idregion"], 	T.Columns["idnation"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["geo_country"];
TChild= Tables["geo_city"];
CPar = new DataColumn[1]{TPar.Columns["idcountry"]};
CChild = new DataColumn[1]{TChild.Columns["idcountry"]};
Relations.Add(new DataRelation("geo_countrygeo_city",CPar,CChild));

TPar= Tables["bank"];
TChild= Tables["cab"];
CPar = new DataColumn[1]{TPar.Columns["idbank"]};
CChild = new DataColumn[1]{TChild.Columns["idbank"]};
Relations.Add(new DataRelation("bankcab",CPar,CChild));

TPar= Tables["geo_city"];
TChild= Tables["cab"];
CPar = new DataColumn[1]{TPar.Columns["idcity"]};
CChild = new DataColumn[1]{TChild.Columns["idcity"]};
Relations.Add(new DataRelation("geo_citycab",CPar,CChild));

}
}
}
