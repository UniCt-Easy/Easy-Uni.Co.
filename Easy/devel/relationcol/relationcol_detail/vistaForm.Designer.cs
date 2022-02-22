
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace relationcol_detail {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Campo relazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable relationcol		{get { return Tables["relationcol"];}}
	///<summary>
	///Relazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable relation		{get { return Tables["relation"];}}
	///<summary>
	///Descrizione campo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable coldescr		{get { return Tables["coldescr"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable coldescr1		{get { return Tables["coldescr1"];}}
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
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
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


	//////////////////// RELATION /////////////////////////////////
	T= new DataTable("relation");
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


	//////////////////// COLDESCR1 /////////////////////////////////
	T= new DataTable("coldescr1");
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


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{coldescr.Columns["colname"]};
	CChild = new DataColumn[1]{relationcol.Columns["parentcol"]};
	Relations.Add(new DataRelation("coldescr_relationcol",CPar,CChild,false));

	CPar = new DataColumn[1]{relation.Columns["idrelation"]};
	CChild = new DataColumn[1]{relationcol.Columns["idrelation"]};
	Relations.Add(new DataRelation("relation_relationcol",CPar,CChild,false));

	#endregion

}
}
}
