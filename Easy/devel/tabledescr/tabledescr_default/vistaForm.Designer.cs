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

using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace tabledescr_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tabella
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable tabledescr		{get { return Tables["tabledescr"];}}
	///<summary>
	///Descrizione campo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable coldescr		{get { return Tables["coldescr"];}}
	///<summary>
	///Descrizione valore codificato
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable colvalue		{get { return Tables["colvalue"];}}
	///<summary>
	///Descrizione significato bit
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable colbit		{get { return Tables["colbit"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable relation_parent		{get { return Tables["relation_parent"];}}
	///<summary>
	///Campo relazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable relationcol		{get { return Tables["relationcol"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable relation_child		{get { return Tables["relation_child"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable relationcol_child		{get { return Tables["relationcol_child"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable applicationlist		{get { return Tables["applicationlist"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// TABLEDESCR /////////////////////////////////
	T= new DataTable("tabledescr");
	C= new DataColumn("tablename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("isdbo", typeof(Char)));
	T.Columns.Add( new DataColumn("idapplication", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["tablename"]};


	//////////////////// COLDESCR /////////////////////////////////
	T= new DataTable("coldescr");
	C= new DataColumn("tablename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("colname", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("sql_type", typeof(String)));
	T.Columns.Add( new DataColumn("col_len", typeof(Int32)));
	T.Columns.Add( new DataColumn("col_scale", typeof(Int32)));
	T.Columns.Add( new DataColumn("col_precision", typeof(Int32)));
	T.Columns.Add( new DataColumn("sql_declaration", typeof(String)));
	T.Columns.Add( new DataColumn("system_type", typeof(String)));
	T.Columns.Add( new DataColumn("primarykey", typeof(String)));
	T.Columns.Add( new DataColumn("kind", typeof(Char)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["tablename"], T.Columns["colname"]};


	//////////////////// COLVALUE /////////////////////////////////
	T= new DataTable("colvalue");
	C= new DataColumn("tablename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("colname", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("value", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("title", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["tablename"], T.Columns["colname"], T.Columns["value"]};


	//////////////////// COLBIT /////////////////////////////////
	T= new DataTable("colbit");
	C= new DataColumn("tablename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("colname", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nbit", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["tablename"], T.Columns["colname"], T.Columns["nbit"]};


	//////////////////// RELATION_PARENT /////////////////////////////////
	T= new DataTable("relation_parent");
	C= new DataColumn("parenttable", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("childtable", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("title", typeof(String)));
	C= new DataColumn("idrelation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idrelation"]};


	//////////////////// RELATIONCOL /////////////////////////////////
	T= new DataTable("relationcol");
	C= new DataColumn("idrelation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("parentcol", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("childcol", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idrelation"], T.Columns["parentcol"]};


	//////////////////// RELATION_CHILD /////////////////////////////////
	T= new DataTable("relation_child");
	C= new DataColumn("parenttable", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("childtable", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("title", typeof(String)));
	C= new DataColumn("idrelation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idrelation"]};


	//////////////////// RELATIONCOL_CHILD /////////////////////////////////
	T= new DataTable("relationcol_child");
	C= new DataColumn("idrelation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("parentcol", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("childcol", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idrelation"], T.Columns["parentcol"]};


	//////////////////// APPLICATIONLIST /////////////////////////////////
	T= new DataTable("applicationlist");
	C= new DataColumn("idapplication", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idapplication"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{relation_parent.Columns["idrelation"]};
	CChild = new DataColumn[1]{relationcol.Columns["idrelation"]};
	Relations.Add(new DataRelation("relation_relationcol",CPar,CChild,false));

	CPar = new DataColumn[2]{coldescr.Columns["tablename"], coldescr.Columns["colname"]};
	CChild = new DataColumn[2]{colbit.Columns["tablename"], colbit.Columns["colname"]};
	Relations.Add(new DataRelation("coldescr_colbit",CPar,CChild,false));

	CPar = new DataColumn[2]{coldescr.Columns["tablename"], coldescr.Columns["colname"]};
	CChild = new DataColumn[2]{colvalue.Columns["tablename"], colvalue.Columns["colname"]};
	Relations.Add(new DataRelation("coldescr_colvalue",CPar,CChild,false));

	CPar = new DataColumn[1]{tabledescr.Columns["tablename"]};
	CChild = new DataColumn[1]{coldescr.Columns["tablename"]};
	Relations.Add(new DataRelation("tabledescr_coldescr",CPar,CChild,false));

	CPar = new DataColumn[1]{tabledescr.Columns["tablename"]};
	CChild = new DataColumn[1]{relation_child.Columns["parenttable"]};
	Relations.Add(new DataRelation("tabledescr_relation1",CPar,CChild,false));

	CPar = new DataColumn[1]{tabledescr.Columns["tablename"]};
	CChild = new DataColumn[1]{relation_parent.Columns["childtable"]};
	Relations.Add(new DataRelation("tabledescr_relation",CPar,CChild,false));

	CPar = new DataColumn[1]{relation_child.Columns["idrelation"]};
	CChild = new DataColumn[1]{relationcol_child.Columns["idrelation"]};
	Relations.Add(new DataRelation("relation_child_relationcol_child",CPar,CChild,false));

	CPar = new DataColumn[1]{applicationlist.Columns["idapplication"]};
	CChild = new DataColumn[1]{tabledescr.Columns["idapplication"]};
	Relations.Add(new DataRelation("applicationlist_tabledescr",CPar,CChild,false));

	#endregion

}
}
}
