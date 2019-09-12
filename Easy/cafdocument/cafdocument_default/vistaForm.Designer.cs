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

namespace cafdocument_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable cafdocument{get { return Tables["cafdocument"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable monthname{get { return Tables["monthname"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable fiscaltaxregion{get { return Tables["fiscaltaxregion"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable geo_city_agencyview{get { return Tables["geo_city_agencyview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable cafdocumentview{get { return Tables["cafdocumentview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable monthname1{get { return Tables["monthname1"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable monthname2{get { return Tables["monthname2"];}}

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
	T= new DataTable("cafdocument");
	C= new DataColumn("idcafdocument", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cafdocumentkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("docdate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("citytaxtorefundhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxtorefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxtoretainhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxtoretain", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtorefundhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtorefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtoretainhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtoretain", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("irpeftorefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("irpeftoretain", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("startmonth", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("monthfirstinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("monthsecondinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ratequantity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nquotafirstinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nquotasecondinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("firstrateadvance", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("separatedincomehusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("separatedincome", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("secondrateadvance", typeof(System.Decimal), ""));
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

	T.Columns.Add(new DataColumn("citytaxaccount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxaccounthusband", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idcafdocument"], 	T.Columns["idcon"]};
	T.PrimaryKey = key;

	T= new DataTable("monthname");
	C= new DataColumn("code", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cfvalue", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["code"]};
	T.PrimaryKey = key;

	T= new DataTable("fiscaltaxregion");
	C= new DataColumn("idfiscaltaxregion", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idcountry", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idregion", typeof(System.Int32), ""));
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfiscaltaxregion"]};
	T.PrimaryKey = key;

	T= new DataTable("geo_city_agencyview");
	C= new DataColumn("idcity", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	C= new DataColumn("idagency", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("agencyname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("agencywebsite", typeof(System.String), ""));
	C= new DataColumn("idcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("version", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("codename", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("value", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("provincecode", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["idcity"], 	T.Columns["idagency"], 	T.Columns["idcode"], 	T.Columns["version"]};
	T.PrimaryKey = key;

	T= new DataTable("cafdocumentview");
	C= new DataColumn("idcafdocument", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ycon", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ncon", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("registry", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cafdocumentkind", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("docdate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("citytaxtorefundhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxtorefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxtoretainhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxtoretain", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtorefundhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtorefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtoretainhusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("regionaltaxtoretain", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("citycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("fiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("irpeftorefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("irpeftoretain", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("startmonth", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("monthfirstinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("monthsecondinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ratequantity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nquotafirstinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("nquotasecondinstalment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("firstrateadvance", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("separatedincomehusband", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("separatedincome", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("secondrateadvance", typeof(System.Decimal), ""));
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

	T.Columns.Add(new DataColumn("citytaxaccount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("citytaxaccounthusband", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idcafdocument"], 	T.Columns["idcon"]};
	T.PrimaryKey = key;

	T= new DataTable("monthname1");
	C= new DataColumn("code", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cfvalue", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["code"]};
	T.PrimaryKey = key;

	T= new DataTable("monthname2");
	C= new DataColumn("code", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cfvalue", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["code"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["monthname2"];
TChild= Tables["cafdocument"];
CPar = new DataColumn[1]{TPar.Columns["code"]};
CChild = new DataColumn[1]{TChild.Columns["monthsecondinstalment"]};
Relations.Add(new DataRelation("monthname2_cafdocument",CPar,CChild));

TPar= Tables["monthname1"];
TChild= Tables["cafdocument"];
CPar = new DataColumn[1]{TPar.Columns["code"]};
CChild = new DataColumn[1]{TChild.Columns["monthfirstinstalment"]};
Relations.Add(new DataRelation("monthname1_cafdocument",CPar,CChild));

TPar= Tables["monthname"];
TChild= Tables["cafdocument"];
CPar = new DataColumn[1]{TPar.Columns["code"]};
CChild = new DataColumn[1]{TChild.Columns["startmonth"]};
Relations.Add(new DataRelation("monthname_cafdocument",CPar,CChild));

TPar= Tables["geo_city_agencyview"];
TChild= Tables["cafdocument"];
CPar = new DataColumn[1]{TPar.Columns["idcity"]};
CChild = new DataColumn[1]{TChild.Columns["idcity"]};
Relations.Add(new DataRelation("geo_city_agencyviewcafdocument",CPar,CChild));

TPar= Tables["fiscaltaxregion"];
TChild= Tables["cafdocument"];
CPar = new DataColumn[1]{TPar.Columns["idfiscaltaxregion"]};
CChild = new DataColumn[1]{TChild.Columns["idfiscaltaxregion"]};
Relations.Add(new DataRelation("fiscaltaxregioncafdocument",CPar,CChild));

}
}
}
