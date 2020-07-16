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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace journaltablesetup_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Nome campo da monitorare nel log
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable journalfieldsetup 		=> Tables["journalfieldsetup"];

	///<summary>
	///Evento transazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable journaltablesetup 		=> Tables["journaltablesetup"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable customobject 		=> Tables["customobject"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable columntypes 		=> Tables["columntypes"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// JOURNALFIELDSETUP /////////////////////////////////
	var tjournalfieldsetup= new DataTable("journalfieldsetup");
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tjournalfieldsetup.Columns.Add(C);
	C= new DataColumn("opkind", typeof(string));
	C.AllowDBNull=false;
	tjournalfieldsetup.Columns.Add(C);
	C= new DataColumn("dbfield", typeof(string));
	C.AllowDBNull=false;
	tjournalfieldsetup.Columns.Add(C);
	Tables.Add(tjournalfieldsetup);
	tjournalfieldsetup.PrimaryKey =  new DataColumn[]{tjournalfieldsetup.Columns["tablename"], tjournalfieldsetup.Columns["opkind"], tjournalfieldsetup.Columns["dbfield"]};


	//////////////////// JOURNALTABLESETUP /////////////////////////////////
	var tjournaltablesetup= new DataTable("journaltablesetup");
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tjournaltablesetup.Columns.Add(C);
	C= new DataColumn("opkind", typeof(string));
	C.AllowDBNull=false;
	tjournaltablesetup.Columns.Add(C);
	Tables.Add(tjournaltablesetup);
	tjournaltablesetup.PrimaryKey =  new DataColumn[]{tjournaltablesetup.Columns["tablename"], tjournaltablesetup.Columns["opkind"]};


	//////////////////// CUSTOMOBJECT /////////////////////////////////
	var tcustomobject= new DataTable("customobject");
	C= new DataColumn("objectname", typeof(string));
	C.AllowDBNull=false;
	tcustomobject.Columns.Add(C);
	tcustomobject.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("isreal", typeof(string));
	C.AllowDBNull=false;
	tcustomobject.Columns.Add(C);
	tcustomobject.Columns.Add( new DataColumn("realtable", typeof(string)));
	tcustomobject.Columns.Add( new DataColumn("lastmoduser", typeof(string)));
	tcustomobject.Columns.Add( new DataColumn("lastmodtimestamp", typeof(DateTime)));
	Tables.Add(tcustomobject);
	tcustomobject.PrimaryKey =  new DataColumn[]{tcustomobject.Columns["objectname"]};


	//////////////////// COLUMNTYPES /////////////////////////////////
	var tcolumntypes= new DataTable("columntypes");
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	C= new DataColumn("field", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	C= new DataColumn("iskey", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	C= new DataColumn("sqltype", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	tcolumntypes.Columns.Add( new DataColumn("col_len", typeof(int)));
	tcolumntypes.Columns.Add( new DataColumn("col_precision", typeof(int)));
	tcolumntypes.Columns.Add( new DataColumn("col_scale", typeof(int)));
	tcolumntypes.Columns.Add( new DataColumn("systemtype", typeof(string)));
	C= new DataColumn("sqldeclaration", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	C= new DataColumn("allownull", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	tcolumntypes.Columns.Add( new DataColumn("defaultvalue", typeof(string)));
	tcolumntypes.Columns.Add( new DataColumn("format", typeof(string)));
	C= new DataColumn("denynull", typeof(string));
	C.AllowDBNull=false;
	tcolumntypes.Columns.Add(C);
	tcolumntypes.Columns.Add( new DataColumn("lastmodtimestamp", typeof(DateTime)));
	tcolumntypes.Columns.Add( new DataColumn("lastmoduser", typeof(string)));
	tcolumntypes.Columns.Add( new DataColumn("createuser", typeof(string)));
	tcolumntypes.Columns.Add( new DataColumn("createtimestamp", typeof(DateTime)));
	Tables.Add(tcolumntypes);
	tcolumntypes.PrimaryKey =  new DataColumn[]{tcolumntypes.Columns["tablename"], tcolumntypes.Columns["field"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{customobject.Columns["objectname"]};
	var cChild = new []{journaltablesetup.Columns["tablename"]};
	Relations.Add(new DataRelation("customobjectjournaltablesetup",cPar,cChild,false));

	cPar = new []{journaltablesetup.Columns["tablename"], journaltablesetup.Columns["opkind"]};
	cChild = new []{journalfieldsetup.Columns["tablename"], journalfieldsetup.Columns["opkind"]};
	Relations.Add(new DataRelation("journaltablesetupjournalfieldsetup",cPar,cChild,false));

	#endregion

}
}
}
