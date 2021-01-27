
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


using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_customdirectrel;
using meta_customdirectrelcol;
using metadatalibrary;
namespace customdirectrel_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsmeta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Relazione diretta tra tabelle
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public customdirectrelTable customdirectrel 		{get { return (customdirectrelTable )Tables["customdirectrel"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable customobject 		{get { return (MetaTable)Tables["customobject"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable customobject1 		{get { return (MetaTable)Tables["customobject1"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable customobjecttableview 		{get { return (MetaTable)Tables["customobjecttableview"];}}
	///<summary>
	///Colonne di relazione diretta
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public customdirectrelcolTable customdirectrelcol 		{get { return (customdirectrelcolTable )Tables["customdirectrelcol"];}}
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
	//////////////////// CUSTOMDIRECTREL /////////////////////////////////
	var tcustomdirectrel= new customdirectrelTable();
	tcustomdirectrel.addBaseColumns("idcustomdirectrel","description","edittype","filter","flag","fromtable","insertfilterparent","lastmodtimestamp","lastmoduser","listtype","navigationfilterparent","totable","totableview");
	Tables.Add(tcustomdirectrel);
	tcustomdirectrel.defineKey("idcustomdirectrel");

	//////////////////// CUSTOMOBJECT /////////////////////////////////
	T= new MetaTable("customobject");
	T.defineColumn("objectname", typeof(String),false);
	T.defineColumn("description", typeof(String));
	T.defineColumn("isreal", typeof(String),false);
	T.defineColumn("realtable", typeof(String));
	T.defineColumn("lastmodtimestamp", typeof(DateTime));
	T.defineColumn("lastmoduser", typeof(String));
	Tables.Add(T);
	T.defineKey("objectname");

	//////////////////// CUSTOMOBJECT1 /////////////////////////////////
	T= new MetaTable("customobject1");
	T.defineColumn("objectname", typeof(String),false);
	T.defineColumn("description", typeof(String));
	T.defineColumn("isreal", typeof(String),false);
	T.defineColumn("realtable", typeof(String));
	T.defineColumn("lastmodtimestamp", typeof(DateTime));
	T.defineColumn("lastmoduser", typeof(String));
	Tables.Add(T);
	T.defineKey("objectname");

	//////////////////// CUSTOMOBJECTTABLEVIEW /////////////////////////////////
	T= new MetaTable("customobjecttableview");
	T.defineColumn("objectname", typeof(String),false);
	T.defineColumn("description", typeof(String));
	T.defineColumn("isreal", typeof(String),false);
	T.defineColumn("realtable", typeof(String));
	T.defineColumn("lastmodtimestamp", typeof(DateTime));
	T.defineColumn("lastmoduser", typeof(String));
	Tables.Add(T);
	T.defineKey("objectname");

	//////////////////// CUSTOMDIRECTRELCOL /////////////////////////////////
	var tcustomdirectrelcol= new customdirectrelcolTable();
	tcustomdirectrelcol.addBaseColumns("fromfield","idcustomdirectrel","tofield","lastmodtimestamp","lastmoduser");
	Tables.Add(tcustomdirectrelcol);
	tcustomdirectrelcol.defineKey("fromfield", "idcustomdirectrel", "tofield");

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
	CPar = new DataColumn[1]{customobject.Columns["objectname"]};
	CChild = new DataColumn[1]{customdirectrel.Columns["fromtable"]};
	Relations.Add(new DataRelation("customobject_customdirectrel",CPar,CChild,false));

	CPar = new DataColumn[1]{customobject1.Columns["objectname"]};
	CChild = new DataColumn[1]{customdirectrel.Columns["totable"]};
	Relations.Add(new DataRelation("customobject1_customdirectrel",CPar,CChild,false));

	CPar = new DataColumn[1]{customobjecttableview.Columns["objectname"]};
	CChild = new DataColumn[1]{customdirectrel.Columns["totableview"]};
	Relations.Add(new DataRelation("customobjectview_customdirectrel",CPar,CChild,false));

	this.defineRelation("customdirectrel_customdirectrelcol","customdirectrel","customdirectrelcol","idcustomdirectrel");
	CPar = new DataColumn[1]{edittype.Columns["edit"]};
	CChild = new DataColumn[1]{customdirectrel.Columns["edittype"]};
	Relations.Add(new DataRelation("edittype_customdirectrel",CPar,CChild,false));

	CPar = new DataColumn[1]{listtype.Columns["list"]};
	CChild = new DataColumn[1]{customdirectrel.Columns["listtype"]};
	Relations.Add(new DataRelation("listtype_customdirectrel",CPar,CChild,false));

	#endregion

}
}
}
