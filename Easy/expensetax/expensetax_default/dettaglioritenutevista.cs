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

namespace expensetax_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensetax{get { return this.Tables["expensetax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable tax{get { return this.Tables["tax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable fiscaltaxregion{get { return this.Tables["fiscaltaxregion"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable geo_cityview{get { return this.Tables["geo_cityview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensetaxview{get { return this.Tables["expensetaxview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomeview{get { return this.Tables["incomeview"];}}

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
	T= new DataTable("expensetax");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nbracket", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxablegross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("exemptionquota", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("abatements", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxabledenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employdenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("admindenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employtax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("admintax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("competencydate", typeof(System.DateTime), ""));
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

	T.Columns.Add(new DataColumn("taxablenet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayear", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("idinc", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ytaxpay", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("ntaxpay", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["taxcode"], 	T.Columns["idexp"], 	T.Columns["nbracket"]};
	T.PrimaryKey = key;

	T= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxref", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxkind", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("fiscaltaxcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagunabatable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("geoappliance", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["taxcode"]};
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
	T.Columns.Add(new DataColumn("idregion", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("region", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("regiondatestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("regiondatestop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("oldregion", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("newregion", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idnation", typeof(System.Int32), ""));
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

	T= new DataTable("expensetaxview");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nbracket", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxkind", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxablegross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxableoriginal", typeof(System.Decimal), ""));
	C= new DataColumn("taxref", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("exemptionquota", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("abatements", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxabledenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employdenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employtax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("admindenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("admintax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("competencydate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("datetaxpay", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ytaxpay", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("ntaxpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idaccmotive_debit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_pay", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("city", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("provincecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("fiscaltaxregion", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idinc", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("yincmov", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nincmov", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ayear", typeof(System.Int32), ""));
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
	T= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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
	T.Columns.Add(new DataColumn("kpro", typeof(System.Int32), ""));
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
	T.Columns.Add(new DataColumn("nproceedstransmission", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("transmissiondate", typeof(System.DateTime), ""));
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
	T.Columns["idinc"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["tax"];
TChild= Tables["expensetax"];
CPar = new DataColumn[1]{TPar.Columns["taxcode"]};
CChild = new DataColumn[1]{TChild.Columns["taxcode"]};
Relations.Add(new DataRelation("taxexpensetax",CPar,CChild));

TPar= Tables["fiscaltaxregion"];
TChild= Tables["expensetax"];
CPar = new DataColumn[1]{TPar.Columns["idfiscaltaxregion"]};
CChild = new DataColumn[1]{TChild.Columns["idfiscaltaxregion"]};
Relations.Add(new DataRelation("fiscaltaxregionexpensetax",CPar,CChild));

TPar= Tables["geo_cityview"];
TChild= Tables["expensetax"];
CPar = new DataColumn[1]{TPar.Columns["idcity"]};
CChild = new DataColumn[1]{TChild.Columns["idcity"]};
Relations.Add(new DataRelation("geo_cityviewexpensetax",CPar,CChild));

TPar= Tables["incomeview"];
TChild= Tables["expensetax"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("incomeviewexpensetax",CPar,CChild));

}
}
}
