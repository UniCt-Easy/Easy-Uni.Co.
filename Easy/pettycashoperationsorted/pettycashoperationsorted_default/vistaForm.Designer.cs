
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
namespace pettycashoperationsorted_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Classificazione Operazione Fondo Economale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable pettycashoperationsorted		{get { return Tables["pettycashoperationsorted"];}}
	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingkind		{get { return Tables["sortingkind"];}}
	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting		{get { return Tables["sorting"];}}
	///<summary>
	///Livello Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortinglevel		{get { return Tables["sortinglevel"];}}
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
	//////////////////// PETTYCASHOPERATIONSORTED /////////////////////////////////
	T= new DataTable("pettycashoperationsorted");
	C= new DataColumn("idpettycash", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yoperation", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("noperation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	T.Columns.Add( new DataColumn("tobecontinued", typeof(String)));
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuen1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuen2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuen3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuen4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuen5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("values1", typeof(String)));
	T.Columns.Add( new DataColumn("values2", typeof(String)));
	T.Columns.Add( new DataColumn("values3", typeof(String)));
	T.Columns.Add( new DataColumn("values4", typeof(String)));
	T.Columns.Add( new DataColumn("values5", typeof(String)));
	T.Columns.Add( new DataColumn("valuev1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuev2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuev3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuev4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("valuev5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
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
	T.PrimaryKey =  new DataColumn[]{T.Columns["idpettycash"], T.Columns["yoperation"], T.Columns["noperation"], T.Columns["idsor"], T.Columns["idsubclass"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	T= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Byte)));
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
	T.Columns.Add( new DataColumn("nphaseexpense", typeof(Byte)));
	T.Columns.Add( new DataColumn("nphaseincome", typeof(Byte)));
	T.Columns.Add( new DataColumn("totalexpression", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsorkind"]};


	//////////////////// SORTING /////////////////////////////////
	T= new DataTable("sorting");
	C= new DataColumn("idsorkind", typeof(Int32));
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
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SORTINGLEVEL /////////////////////////////////
	T= new DataTable("sortinglevel");
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsorkind"], T.Columns["nlevel"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[2]{sortinglevel.Columns["idsorkind"], sortinglevel.Columns["nlevel"]};
	CChild = new DataColumn[2]{sorting.Columns["idsorkind"], sorting.Columns["nlevel"]};
	Relations.Add(new DataRelation("sortinglevelsorting",CPar,CChild,false));

	CPar = new DataColumn[1]{sortingkind.Columns["idsorkind"]};
	CChild = new DataColumn[1]{sorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkindsorting",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting.Columns["idsor"]};
	CChild = new DataColumn[1]{pettycashoperationsorted.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingpettycashoperationsorted",CPar,CChild,false));

	#endregion

}
}
}
