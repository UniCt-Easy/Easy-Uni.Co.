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
using meta_customindirectrel;
using meta_customindirectrelcol;
using metadatalibrary;
namespace customindirectrel_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsmeta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Relazione indiretta tra tabelle
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public customindirectrelTable customindirectrel 		{get { return (customindirectrelTable )Tables["customindirectrel"];}}
	///<summary>
	///colonne di Relazione di navigazione indiretta
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public customindirectrelcolTable customindirectrelcol 		{get { return (customindirectrelcolTable )Tables["customindirectrelcol"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable customobject_middle 		{get { return (MetaTable)Tables["customobject_middle"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable customobject_parent1 		{get { return (MetaTable)Tables["customobject_parent1"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable customobject_parent2 		{get { return (MetaTable)Tables["customobject_parent2"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable customobject_parent2view 		{get { return (MetaTable)Tables["customobject_parent2view"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable edittype 		{get { return (MetaTable)Tables["edittype"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable listtype 		{get { return (MetaTable)Tables["listtype"];}}
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
	//////////////////// CUSTOMINDIRECTREL /////////////////////////////////
	var tcustomindirectrel= new customindirectrelTable();
	tcustomindirectrel.addBaseColumns("idcustomindirectrel","description","edittype","filtermiddle","filterparenttable2","flag","insertfilterparenttable1","lastmodtimestamp","lastmoduser","listtype","middletable","navigationfilterparenttable1","parenttable1","parenttable2","parenttable2view");
	Tables.Add(tcustomindirectrel);
	tcustomindirectrel.defineKey("idcustomindirectrel");

	//////////////////// CUSTOMINDIRECTRELCOL /////////////////////////////////
	var tcustomindirectrelcol= new customindirectrelcolTable();
	tcustomindirectrelcol.addBaseColumns("idcustomindirectrel","parentfield","parentnumber","lastmodtimestamp","lastmoduser","middlefield");
	Tables.Add(tcustomindirectrelcol);
	tcustomindirectrelcol.defineKey("idcustomindirectrel", "parentfield", "parentnumber");

	//////////////////// CUSTOMOBJECT_MIDDLE /////////////////////////////////
	T= new MetaTable("customobject_middle");
	T.defineColumn("objectname", typeof(String),false);
	T.defineColumn("description", typeof(String));
	T.defineColumn("isreal", typeof(String),false);
	T.defineColumn("realtable", typeof(String));
	T.defineColumn("lastmodtimestamp", typeof(DateTime));
	T.defineColumn("lastmoduser", typeof(String));
	Tables.Add(T);
	T.defineKey("objectname");

	//////////////////// CUSTOMOBJECT_PARENT1 /////////////////////////////////
	T= new MetaTable("customobject_parent1");
	T.defineColumn("objectname", typeof(String),false);
	T.defineColumn("description", typeof(String));
	T.defineColumn("isreal", typeof(String),false);
	T.defineColumn("realtable", typeof(String));
	T.defineColumn("lastmodtimestamp", typeof(DateTime));
	T.defineColumn("lastmoduser", typeof(String));
	Tables.Add(T);
	T.defineKey("objectname");

	//////////////////// CUSTOMOBJECT_PARENT2 /////////////////////////////////
	T= new MetaTable("customobject_parent2");
	T.defineColumn("objectname", typeof(String),false);
	T.defineColumn("description", typeof(String));
	T.defineColumn("isreal", typeof(String),false);
	T.defineColumn("realtable", typeof(String));
	T.defineColumn("lastmodtimestamp", typeof(DateTime));
	T.defineColumn("lastmoduser", typeof(String));
	Tables.Add(T);
	T.defineKey("objectname");

	//////////////////// CUSTOMOBJECT_PARENT2VIEW /////////////////////////////////
	T= new MetaTable("customobject_parent2view");
	T.defineColumn("objectname", typeof(String),false);
	T.defineColumn("description", typeof(String));
	T.defineColumn("isreal", typeof(String),false);
	T.defineColumn("realtable", typeof(String));
	T.defineColumn("lastmodtimestamp", typeof(DateTime));
	T.defineColumn("lastmoduser", typeof(String));
	Tables.Add(T);
	T.defineKey("objectname");

	//////////////////// EDITTYPE /////////////////////////////////
	T= new MetaTable("edittype");
	T.defineColumn("edit", typeof(String),false);
	Tables.Add(T);
	T.defineKey("edit");

	//////////////////// LISTTYPE /////////////////////////////////
	T= new MetaTable("listtype");
	T.defineColumn("list", typeof(String),false);
	Tables.Add(T);
	T.defineKey("list");

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	this.defineRelation("customindirectrel_customindirectrelcol","customindirectrel","customindirectrelcol","idcustomindirectrel");
	CPar = new DataColumn[1]{customobject_middle.Columns["objectname"]};
	CChild = new DataColumn[1]{customindirectrel.Columns["middletable"]};
	Relations.Add(new DataRelation("customobject_middle_customindirectrel",CPar,CChild,false));

	CPar = new DataColumn[1]{customobject_parent1.Columns["objectname"]};
	CChild = new DataColumn[1]{customindirectrel.Columns["parenttable1"]};
	Relations.Add(new DataRelation("customobject_parent1_customindirectrel",CPar,CChild,false));

	CPar = new DataColumn[1]{customobject_parent2.Columns["objectname"]};
	CChild = new DataColumn[1]{customindirectrel.Columns["parenttable2"]};
	Relations.Add(new DataRelation("customobject_parent2_customindirectrel",CPar,CChild,false));

	CPar = new DataColumn[1]{customobject_parent2view.Columns["objectname"]};
	CChild = new DataColumn[1]{customindirectrel.Columns["parenttable2view"]};
	Relations.Add(new DataRelation("customobject_parent2view_customindirectrel",CPar,CChild,false));

	CPar = new DataColumn[1]{listtype.Columns["list"]};
	CChild = new DataColumn[1]{customindirectrel.Columns["listtype"]};
	Relations.Add(new DataRelation("listtype_customindirectrel",CPar,CChild,false));

	CPar = new DataColumn[1]{edittype.Columns["edit"]};
	CChild = new DataColumn[1]{customindirectrel.Columns["edittype"]};
	Relations.Add(new DataRelation("edittype_customindirectrel",CPar,CChild,false));

	#endregion

}
}
}
