
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
using meta_customdirectrelcol;
using metadatalibrary;
namespace customdirectrelcol_single {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsmeta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Colonne di relazione diretta
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public customdirectrelcolTable customdirectrelcol 		{get { return (customdirectrelcolTable )Tables["customdirectrelcol"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable columntypes 		{get { return (MetaTable)Tables["columntypes"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable columntypes1 		{get { return (MetaTable)Tables["columntypes1"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable customobject 		{get { return (MetaTable)Tables["customobject"];}}
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
	//////////////////// CUSTOMDIRECTRELCOL /////////////////////////////////
	var tcustomdirectrelcol= new customdirectrelcolTable();
	tcustomdirectrelcol.addBaseColumns("fromfield","idcustomdirectrel","tofield","lastmodtimestamp","lastmoduser");
	Tables.Add(tcustomdirectrelcol);
	tcustomdirectrelcol.defineKey("fromfield", "idcustomdirectrel", "tofield");

	//////////////////// COLUMNTYPES /////////////////////////////////
	T= new MetaTable("columntypes");
	T.defineColumn("tablename", typeof(String),false);
	T.defineColumn("field", typeof(String),false);
	Tables.Add(T);
	T.defineKey("tablename", "field");

	//////////////////// COLUMNTYPES1 /////////////////////////////////
	T= new MetaTable("columntypes1");
	T.defineColumn("tablename", typeof(String),false);
	T.defineColumn("field", typeof(String),false);
	Tables.Add(T);
	T.defineKey("tablename", "field");

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

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{columntypes.Columns["field"]};
	CChild = new DataColumn[1]{customdirectrelcol.Columns["fromfield"]};
	Relations.Add(new DataRelation("columntypes_customdirectrelcol",CPar,CChild,false));

	CPar = new DataColumn[1]{columntypes1.Columns["field"]};
	CChild = new DataColumn[1]{customdirectrelcol.Columns["tofield"]};
	Relations.Add(new DataRelation("columntypes1_customdirectrelcol",CPar,CChild,false));

	CPar = new DataColumn[1]{customobject.Columns["objectname"]};
	CChild = new DataColumn[1]{columntypes1.Columns["tablename"]};
	Relations.Add(new DataRelation("customobject_columntypes1",CPar,CChild,false));

	#endregion

}
}
}
