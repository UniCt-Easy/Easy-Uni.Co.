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

using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
using metadatalibrary;
namespace relation_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsmeta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Relazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable relation 		{get { return (MetaTable)Tables["relation"];}}
	///<summary>
	///Campo relazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable relationcol 		{get { return (MetaTable)Tables["relationcol"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable tabledescr_child 		{get { return (MetaTable)Tables["tabledescr_child"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable tabledescr_parent 		{get { return (MetaTable)Tables["tabledescr_parent"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public dsmeta(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";
	EnforceConstraints = false;

	#region create DataTables
	MetaTable T;
	//////////////////// RELATION /////////////////////////////////
	T= new MetaTable("relation");
	T.defineColumn("parenttable", typeof(String),false);
	T.defineColumn("childtable", typeof(String),false);
	T.defineColumn("description", typeof(String));
	T.defineColumn("lt", typeof(DateTime));
	T.defineColumn("lu", typeof(String));
	T.defineColumn("title", typeof(String));
	T.defineColumn("idrelation", typeof(Int32),false);
	Tables.Add(T);
	T.defineKey("idrelation");

	//////////////////// RELATIONCOL /////////////////////////////////
	T= new MetaTable("relationcol");
	T.defineColumn("idrelation", typeof(Int32),false);
	T.defineColumn("parentcol", typeof(String),false);
	T.defineColumn("childcol", typeof(String),false);
	T.defineColumn("lt", typeof(DateTime));
	T.defineColumn("lu", typeof(String));
	Tables.Add(T);
	T.defineKey("idrelation", "parentcol");

	//////////////////// TABLEDESCR_CHILD /////////////////////////////////
	T= new MetaTable("tabledescr_child");
	T.defineColumn("tablename", typeof(String),false);
	T.defineColumn("title", typeof(String),false);
	T.defineColumn("description", typeof(String));
	T.defineColumn("lt", typeof(DateTime));
	T.defineColumn("lu", typeof(String));
	Tables.Add(T);
	T.defineKey("tablename");

	//////////////////// TABLEDESCR_PARENT /////////////////////////////////
	T= new MetaTable("tabledescr_parent");
	T.defineColumn("tablename", typeof(String),false);
	T.defineColumn("title", typeof(String),false);
	T.defineColumn("description", typeof(String));
	T.defineColumn("lt", typeof(DateTime));
	T.defineColumn("lu", typeof(String));
	Tables.Add(T);
	T.defineKey("tablename");

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{tabledescr_child.Columns["tablename"]};
	CChild = new DataColumn[1]{relation.Columns["childtable"]};
	Relations.Add(new DataRelation("tabledescr_child_relation",CPar,CChild,false));

	CPar = new DataColumn[1]{relation.Columns["idrelation"]};
	CChild = new DataColumn[1]{relationcol.Columns["idrelation"]};
	Relations.Add(new DataRelation("relation_relationcol",CPar,CChild,false));

	CPar = new DataColumn[1]{tabledescr_parent.Columns["tablename"]};
	CChild = new DataColumn[1]{relation.Columns["parenttable"]};
	Relations.Add(new DataRelation("tabledescr_parent_relation",CPar,CChild,false));

	#endregion

}
}
}
