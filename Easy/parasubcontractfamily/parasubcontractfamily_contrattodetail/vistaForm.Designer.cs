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

namespace parasubcontractfamily_contrattodetail {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable parasubcontractfamily{get { return this.Tables["parasubcontractfamily"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable geo_cityview{get { return this.Tables["geo_cityview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable affinity{get { return this.Tables["affinity"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable geo_nation{get { return this.Tables["geo_nation"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable parasubcontractfamilyview{get { return this.Tables["parasubcontractfamilyview"];}}

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
	T= new DataTable("parasubcontractfamily");
	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idfamily", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idaffinity", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!descrparentela", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("surname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forename", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcitybirth", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("!comune", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!sigla", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!nazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idnation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("birthdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("flagforeign", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("gender", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("startapplication", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stopapplication", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("appliancepercentage", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("starthandicap", typeof(System.DateTime), ""));
	C= new DataColumn("foreignresident", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagdependent", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("childasparent", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idcon"], 	T.Columns["idfamily"], 	T.Columns["ayear"]};
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
	key = new DataColumn[1]{
	T.Columns["idcity"]};
	T.PrimaryKey = key;

	T= new DataTable("affinity");
	C= new DataColumn("idaffinity", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idaffinity"]};
	T.PrimaryKey = key;

	T= new DataTable("geo_nation");
	C= new DataColumn("idnation", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcontinent", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("newnation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("oldnation", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idnation"]};
	T.PrimaryKey = key;

	T= new DataTable("parasubcontractfamilyview");
	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idfamily", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("surname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forename", typeof(System.String), ""));
	C= new DataColumn("idaffinity", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("affinity", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idcitybirth", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("city", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("province", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idnation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("birthdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("flagforeign", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("gender", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("startapplication", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stopapplication", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("appliancepercentage", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("starthandicap", typeof(System.DateTime), ""));
	C= new DataColumn("foreignresident", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagdependent", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("childasparent", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	Tables.Add(T);

//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["geo_nation"];
TChild= Tables["parasubcontractfamily"];
CPar = new DataColumn[1]{TPar.Columns["idnation"]};
CChild = new DataColumn[1]{TChild.Columns["idnation"]};
Relations.Add(new DataRelation("geo_nationparasubcontractfamily",CPar,CChild));

TPar= Tables["affinity"];
TChild= Tables["parasubcontractfamily"];
CPar = new DataColumn[1]{TPar.Columns["idaffinity"]};
CChild = new DataColumn[1]{TChild.Columns["idaffinity"]};
Relations.Add(new DataRelation("affinityparasubcontractfamily",CPar,CChild));

TPar= Tables["geo_cityview"];
TChild= Tables["parasubcontractfamily"];
CPar = new DataColumn[1]{TPar.Columns["idcity"]};
CChild = new DataColumn[1]{TChild.Columns["idcitybirth"]};
Relations.Add(new DataRelation("geo_cityviewparasubcontractfamily",CPar,CChild));

}
}
}
