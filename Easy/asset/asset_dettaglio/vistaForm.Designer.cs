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

namespace asset_dettaglio {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable manager{get { return this.Tables["manager"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable asset{get { return this.Tables["asset"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable locationview{get { return this.Tables["locationview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable inventorytree{get { return this.Tables["inventorytree"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable assetacquire{get { return this.Tables["assetacquire"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable assetview{get { return this.Tables["assetview"];}}

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
	T= new DataTable("manager");
	C= new DataColumn("idman", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddivision", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("userweb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("passwordweb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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
	T.Columns["idman"]};
	T.PrimaryKey = key;

	T= new DataTable("asset");
	C= new DataColumn("idasset", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nassetacquire", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ninventory", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("lifestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idlocation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idassetunloadkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("yassetunload", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nassetunload", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("!location", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!ninventory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!manager", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!numeroriga", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!assetdescription", typeof(System.String), ""));
	C= new DataColumn("idpiece", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("transmitted", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idasset"], 	T.Columns["idpiece"]};
	T.PrimaryKey = key;

	T= new DataTable("locationview");
	C= new DataColumn("idlocation", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("locationcode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("leveldescr", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridlocation", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
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
	T= new DataTable("inventorytree");
	C= new DataColumn("idinv", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeinv", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridinv", typeof(System.String), ""));
	C= new DataColumn("nlevel", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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
	T.Columns["idinv"]};
	T.PrimaryKey = key;

	T= new DataTable("assetacquire");
	C= new DataColumn("nassetacquire", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("yman", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rownum", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	C= new DataColumn("idmot", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinv", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinventory", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idassetloadkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("yassetload", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nassetload", typeof(System.Int32), ""));
	C= new DataColumn("number", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxrate", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("discount", typeof(System.Double), ""));
	C= new DataColumn("startnumber", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagload", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("loadkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("abatable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("tax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("transmitted", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["nassetacquire"]};
	T.PrimaryKey = key;

	T= new DataTable("assetview");
	C= new DataColumn("idasset", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idpiece", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lifestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("nassetacquire", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ninventory", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idlocation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("locationcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("location", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	C= new DataColumn("idinv", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeinv", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("inventorytree", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinventory", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("inventory", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idassetloadkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("yassetload", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nassetload", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("taxable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxrate", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("discount", typeof(System.Double), ""));
	T.Columns.Add(new DataColumn("total", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("currentvalue", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idassetunloadkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("yassetunload", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("nassetunload", typeof(System.Int32), ""));
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

	T.Columns.Add(new DataColumn("cost", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("abatable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("transmitted", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idasset"], 	T.Columns["idpiece"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["inventorytree"];
TChild= Tables["assetacquire"];
CPar = new DataColumn[1]{TPar.Columns["idinv"]};
CChild = new DataColumn[1]{TChild.Columns["idinv"]};
Relations.Add(new DataRelation("inventorytreeassetacquire",CPar,CChild));

TPar= Tables["assetview"];
TChild= Tables["asset"];
CPar = new DataColumn[1]{TPar.Columns["idasset"]};
CChild = new DataColumn[1]{TChild.Columns["idasset"]};
Relations.Add(new DataRelation("assetviewasset",CPar,CChild));

TPar= Tables["assetacquire"];
TChild= Tables["asset"];
CPar = new DataColumn[1]{TPar.Columns["nassetacquire"]};
CChild = new DataColumn[1]{TChild.Columns["nassetacquire"]};
Relations.Add(new DataRelation("assetacquireasset",CPar,CChild));

TPar= Tables["manager"];
TChild= Tables["asset"];
CPar = new DataColumn[1]{TPar.Columns["idman"]};
CChild = new DataColumn[1]{TChild.Columns["idman"]};
Relations.Add(new DataRelation("managerasset",CPar,CChild));

TPar= Tables["locationview"];
TChild= Tables["asset"];
CPar = new DataColumn[1]{TPar.Columns["idlocation"]};
CChild = new DataColumn[1]{TChild.Columns["idlocation"]};
Relations.Add(new DataRelation("locationviewasset",CPar,CChild));

}
}
}
