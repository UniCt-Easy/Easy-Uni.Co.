/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
namespace list_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Listino
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable list		{get { return Tables["list"];}}
	///<summary>
	///Unità di Misura per il carico/scarico
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable unit		{get { return Tables["unit"];}}
	///<summary>
	/// Unità di Misura per l'acquisto
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable package		{get { return Tables["package"];}}
	///<summary>
	///Classificazione Merceologica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable listclass		{get { return Tables["listclass"];}}
	///<summary>
	///Classificazione listino
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable listsorting		{get { return Tables["listsorting"];}}
	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting		{get { return Tables["sorting"];}}
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
	//////////////////// LIST /////////////////////////////////
	T= new DataTable("list");
	C= new DataColumn("idlist", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("intcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("intbarcode", typeof(String)));
	T.Columns.Add( new DataColumn("extcode", typeof(String)));
	T.Columns.Add( new DataColumn("extbarcode", typeof(String)));
	T.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpackage", typeof(Int32)));
	T.Columns.Add( new DataColumn("idunit", typeof(Int32)));
	T.Columns.Add( new DataColumn("unitsforpackage", typeof(Int32)));
	C= new DataColumn("has_expiry", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idlistclass", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("pic", typeof(Byte[])));
	T.Columns.Add( new DataColumn("picext", typeof(String)));
	T.Columns.Add( new DataColumn("nmin", typeof(Decimal)));
	T.Columns.Add( new DataColumn("ntoreorder", typeof(Decimal)));
	T.Columns.Add( new DataColumn("timesupply", typeof(Int32)));
	T.Columns.Add( new DataColumn("nmaxorder", typeof(Decimal)));
	T.Columns.Add( new DataColumn("price", typeof(Decimal)));
	T.Columns.Add( new DataColumn("insinfo", typeof(String)));
	T.Columns.Add( new DataColumn("descrforuser", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idlist"]};


	//////////////////// UNIT /////////////////////////////////
	T= new DataTable("unit");
	C= new DataColumn("idunit", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idunit"]};


	//////////////////// PACKAGE /////////////////////////////////
	T= new DataTable("package");
	C= new DataColumn("idpackage", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idpackage"]};


	//////////////////// LISTCLASS /////////////////////////////////
	T= new DataTable("listclass");
	C= new DataColumn("idlistclass", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codelistclass", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridlistclass", typeof(String)));
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
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
	T.Columns.Add( new DataColumn("flagvisiblekind", typeof(Byte)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idlistclass"]};


	//////////////////// LISTSORTING /////////////////////////////////
	T= new DataTable("listsorting");
	C= new DataColumn("idlist", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("quota", typeof(Double));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("!codiceclass", typeof(String)));
	T.Columns.Add( new DataColumn("!descrizione", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idlist"], T.Columns["idsor"]};


	//////////////////// SORTING /////////////////////////////////
	T= new DataTable("sorting");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	T.Columns.Add( new DataColumn("email", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{sorting.Columns["idsor"]};
	CChild = new DataColumn[1]{listsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sorting_listsorting",CPar,CChild,false));

	CPar = new DataColumn[1]{list.Columns["idlist"]};
	CChild = new DataColumn[1]{listsorting.Columns["idlist"]};
	Relations.Add(new DataRelation("FK_list_listsorting",CPar,CChild,false));

	CPar = new DataColumn[1]{listclass.Columns["idlistclass"]};
	CChild = new DataColumn[1]{list.Columns["idlistclass"]};
	Relations.Add(new DataRelation("FK_listclass_list",CPar,CChild,false));

	CPar = new DataColumn[1]{package.Columns["idpackage"]};
	CChild = new DataColumn[1]{list.Columns["idpackage"]};
	Relations.Add(new DataRelation("FK_package_list",CPar,CChild,false));

	CPar = new DataColumn[1]{unit.Columns["idunit"]};
	CChild = new DataColumn[1]{list.Columns["idunit"]};
	Relations.Add(new DataRelation("FK_unit_list",CPar,CChild,false));

	#endregion

}
}
}
