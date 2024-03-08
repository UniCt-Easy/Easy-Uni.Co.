
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using meta_customindirectrelcol;
using metadatalibrary;
namespace customindirectrelcol_single {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsmeta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable columntypes_parent 		{get { return (MetaTable)Tables["columntypes_parent"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable columntypes_middle 		{get { return (MetaTable)Tables["columntypes_middle"];}}
	///<summary>
	///colonne di Relazione di navigazione indiretta
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public customindirectrelcolTable customindirectrelcol 		{get { return (customindirectrelcolTable )Tables["customindirectrelcol"];}}
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
	//////////////////// COLUMNTYPES_PARENT /////////////////////////////////
	T= new MetaTable("columntypes_parent");
	T.defineColumn("tablename", typeof(String),false);
	T.defineColumn("field", typeof(String),false);
	Tables.Add(T);
	T.defineKey("tablename", "field");

	//////////////////// COLUMNTYPES_MIDDLE /////////////////////////////////
	T= new MetaTable("columntypes_middle");
	T.defineColumn("tablename", typeof(String),false);
	T.defineColumn("field", typeof(String),false);
	Tables.Add(T);
	T.defineKey("tablename", "field");

	//////////////////// CUSTOMINDIRECTRELCOL /////////////////////////////////
	var tcustomindirectrelcol= new customindirectrelcolTable();
	tcustomindirectrelcol.addBaseColumns("idcustomindirectrel","parentfield","parentnumber","lastmodtimestamp","lastmoduser","middlefield");
	Tables.Add(tcustomindirectrelcol);
	tcustomindirectrelcol.defineKey("idcustomindirectrel", "parentfield", "parentnumber");

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{columntypes_middle.Columns["field"]};
	CChild = new DataColumn[1]{customindirectrelcol.Columns["middlefield"]};
	Relations.Add(new DataRelation("columntypes_middle_customindirectrelcol",CPar,CChild,false));

	CPar = new DataColumn[1]{columntypes_parent.Columns["field"]};
	CChild = new DataColumn[1]{customindirectrelcol.Columns["parentfield"]};
	Relations.Add(new DataRelation("columntypes_parent_customindirectrelcol",CPar,CChild,false));

	#endregion

}
}
}
