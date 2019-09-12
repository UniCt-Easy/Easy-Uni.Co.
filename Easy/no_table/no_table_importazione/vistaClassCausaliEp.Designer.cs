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
namespace notable_importazione {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaClassCausaliEp")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaClassCausaliEp: DataSet {

	#region Table members declaration
	///<summary>
	///Classificazione causale E/P
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotivesorting		{get { return Tables["accmotivesorting"];}}
	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingkind		{get { return Tables["sortingkind"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaClassCausaliEp(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaClassCausaliEp (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaClassCausaliEp";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaClassCausaliEp.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// ACCMOTIVESORTING /////////////////////////////////
	T= new DataTable("accmotivesorting");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idaccmotive"], T.Columns["idsor"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	T= new DataTable("sortingkind");
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagdate", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN5", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS5", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv5", typeof(String)));
	T.Columns.Add( new DataColumn("labelfordate", typeof(String)));
	T.Columns.Add( new DataColumn("labeln1", typeof(String)));
	T.Columns.Add( new DataColumn("labeln2", typeof(String)));
	T.Columns.Add( new DataColumn("labeln3", typeof(String)));
	T.Columns.Add( new DataColumn("labeln4", typeof(String)));
	T.Columns.Add( new DataColumn("labeln5", typeof(String)));
	T.Columns.Add( new DataColumn("labels1", typeof(String)));
	T.Columns.Add( new DataColumn("labels2", typeof(String)));
	T.Columns.Add( new DataColumn("labels3", typeof(String)));
	T.Columns.Add( new DataColumn("labels4", typeof(String)));
	T.Columns.Add( new DataColumn("labels5", typeof(String)));
	T.Columns.Add( new DataColumn("labelv1", typeof(String)));
	T.Columns.Add( new DataColumn("labelv2", typeof(String)));
	T.Columns.Add( new DataColumn("labelv3", typeof(String)));
	T.Columns.Add( new DataColumn("labelv4", typeof(String)));
	T.Columns.Add( new DataColumn("labelv5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv5", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nodatelabel", typeof(String)));
	T.Columns.Add( new DataColumn("totalexpression", typeof(String)));
	T.Columns.Add( new DataColumn("nphaseexpense", typeof(Byte)));
	T.Columns.Add( new DataColumn("nphaseincome", typeof(Byte)));
	C= new DataColumn("codesorkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	T.Columns.Add( new DataColumn("idparentkind", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsorkind"]};


	#endregion

}
}
}
