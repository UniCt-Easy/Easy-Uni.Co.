/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
namespace metaeasylibrary {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("VistaEasyJournaling")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class VistaEasyJournaling: DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable tableop		{get { return Tables["tableop"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable journaltablesetup		{get { return Tables["journaltablesetup"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable journalfieldsetup		{get { return Tables["journalfieldsetup"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable journal		{get { return Tables["journal"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public VistaEasyJournaling(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected VistaEasyJournaling (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "VistaEasyJournaling";
	Prefix = "";
	Namespace = "http://tempuri.org/VistaEasyJournaling.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// TABLEOP /////////////////////////////////
	T= new DataTable("tableop");
	C= new DataColumn("tablename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("opkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["tablename"], T.Columns["opkind"]};


	//////////////////// JOURNALTABLESETUP /////////////////////////////////
	T= new DataTable("journaltablesetup");
	C= new DataColumn("tablename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("opkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["tablename"], T.Columns["opkind"]};


	//////////////////// JOURNALFIELDSETUP /////////////////////////////////
	T= new DataTable("journalfieldsetup");
	C= new DataColumn("tablename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("opkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("dbfield", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["tablename"], T.Columns["opkind"], T.Columns["dbfield"]};


	//////////////////// JOURNAL /////////////////////////////////
	T= new DataTable("journal");
	C= new DataColumn("operationdatetime", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("tablename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("opkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("fieldname", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("primarykey", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("value", typeof(String)));
	T.Columns.Add( new DataColumn("computername", typeof(String)));
	T.Columns.Add( new DataColumn("computeruser", typeof(String)));
	T.Columns.Add( new DataColumn("dbuser", typeof(String)));
	T.Columns.Add( new DataColumn("notes", typeof(String)));
	T.Columns.Add( new DataColumn("olenotes", typeof(Byte[])));
	T.Columns.Add( new DataColumn("oldvalue", typeof(String)));
	C= new DataColumn("iddbdepartment", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idflowchart", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[2]{journaltablesetup.Columns["tablename"], journaltablesetup.Columns["opkind"]};
	CChild = new DataColumn[2]{journalfieldsetup.Columns["tablename"], journalfieldsetup.Columns["opkind"]};
	Relations.Add(new DataRelation("journaltablesetupjournalfieldsetup",CPar,CChild,false));

	CPar = new DataColumn[2]{tableop.Columns["tablename"], tableop.Columns["opkind"]};
	CChild = new DataColumn[2]{journaltablesetup.Columns["tablename"], journaltablesetup.Columns["opkind"]};
	Relations.Add(new DataRelation("tableopjournaltablesetup",CPar,CChild,false));

	#endregion

}
}
}
