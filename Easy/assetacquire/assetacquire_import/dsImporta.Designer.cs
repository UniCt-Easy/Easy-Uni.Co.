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
namespace assetacquire_import {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsImporta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsImporta: DataSet {

	#region Table members declaration
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registry		{get { return Tables["registry"];}}
	///<summary>
	///Carico dei cespiti da bolla/fattura
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetacquire		{get { return Tables["assetacquire"];}}
	///<summary>
	///Cespiti e accessori
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable asset		{get { return Tables["asset"];}}
	///<summary>
	///Tipi di buoni di carico
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetloadkind		{get { return Tables["assetloadkind"];}}
	///<summary>
	///Tipi di buoni di scarico
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetunloadkind		{get { return Tables["assetunloadkind"];}}
	///<summary>
	///Buono di scarico
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetunload		{get { return Tables["assetunload"];}}
	///<summary>
	///Buono di carico
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetload		{get { return Tables["assetload"];}}
	///<summary>
	///Rivalutazione/Svalutazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetamortization		{get { return Tables["assetamortization"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public dsImporta(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected dsImporta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "dsImporta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsImporta.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// REGISTRY /////////////////////////////////
	T= new DataTable("registry");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("badgecode", typeof(String)));
	T.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("extmatricula", typeof(String)));
	T.Columns.Add( new DataColumn("foreigncf", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("gender", typeof(String)));
	T.Columns.Add( new DataColumn("idcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idcentralizedcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idmaritalstatus", typeof(String)));
	T.Columns.Add( new DataColumn("idnation", typeof(Int32)));
	T.Columns.Add( new DataColumn("idregistryclass", typeof(String)));
	T.Columns.Add( new DataColumn("idtitle", typeof(String)));
	T.Columns.Add( new DataColumn("location", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("maritalsurname", typeof(String)));
	T.Columns.Add( new DataColumn("p_iva", typeof(String)));
	C= new DataColumn("residence", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"]};


	//////////////////// ASSETACQUIRE /////////////////////////////////
	T= new DataTable("assetacquire");
	C= new DataColumn("nassetacquire", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("abatable", typeof(Decimal)));
	C= new DataColumn("adate", typeof(DateTime));
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
	T.Columns.Add( new DataColumn("discount", typeof(Double)));
	C= new DataColumn("idinv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idmankind", typeof(String)));
	C= new DataColumn("idmot", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nman", typeof(Int32)));
	C= new DataColumn("number", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rownum", typeof(Int32)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("startnumber", typeof(Int32)));
	T.Columns.Add( new DataColumn("tax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxable", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxrate", typeof(Double)));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("yman", typeof(Int16)));
	T.Columns.Add( new DataColumn("transmitted", typeof(String)));
	C= new DataColumn("idassetload", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flag", typeof(Byte)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nassetacquire"]};


	//////////////////// ASSET /////////////////////////////////
	T= new DataTable("asset");
	C= new DataColumn("idasset", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nassetacquire", typeof(Int32)));
	T.Columns.Add( new DataColumn("ninventory", typeof(Int32)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("transmitted", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("idassetunload", typeof(Int32)));
	T.Columns.Add( new DataColumn("idcurrman", typeof(Int32)));
	T.Columns.Add( new DataColumn("idcurrsubman", typeof(Int32)));
	T.Columns.Add( new DataColumn("idcurrlocation", typeof(Int32)));
	T.Columns.Add( new DataColumn("idinventory", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idasset"], T.Columns["idpiece"]};


	//////////////////// ASSETLOADKIND /////////////////////////////////
	T= new DataTable("assetloadkind");
	C= new DataColumn("idassetloadkind", typeof(Int32));
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
	C= new DataColumn("idinventory", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("startnumber", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idassetloadkind"]};


	//////////////////// ASSETUNLOADKIND /////////////////////////////////
	T= new DataTable("assetunloadkind");
	C= new DataColumn("idassetunloadkind", typeof(Int32));
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
	T.Columns.Add( new DataColumn("idinventory", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("startnumber", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idassetunloadkind"]};


	//////////////////// ASSETUNLOAD /////////////////////////////////
	T= new DataTable("assetunload");
	C= new DataColumn("idassetunloadkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nassetunload", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yassetunload", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("enactment", typeof(String)));
	T.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idmot", typeof(Int32)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("transmitted", typeof(String)));
	C= new DataColumn("idassetunload", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idassetunload"]};


	//////////////////// ASSETLOAD /////////////////////////////////
	T= new DataTable("assetload");
	C= new DataColumn("idassetloadkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nassetload", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yassetload", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("enactment", typeof(String)));
	T.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idmot", typeof(Int32)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("transmitted", typeof(String)));
	C= new DataColumn("idassetload", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idassetload"]};


	//////////////////// ASSETAMORTIZATION /////////////////////////////////
	T= new DataTable("assetamortization");
	C= new DataColumn("namortization", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amortizationquota", typeof(Double)));
	T.Columns.Add( new DataColumn("assetvalue", typeof(Decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idasset", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinventoryamortization", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpiece", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("transmitted", typeof(String)));
	C= new DataColumn("idassetunload", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flag", typeof(Byte)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["namortization"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[2]{asset.Columns["idasset"], asset.Columns["idpiece"]};
	CChild = new DataColumn[2]{assetamortization.Columns["idasset"], assetamortization.Columns["idpiece"]};
	Relations.Add(new DataRelation("asset_assetamortization",CPar,CChild,false));

	CPar = new DataColumn[1]{assetunload.Columns["idassetunload"]};
	CChild = new DataColumn[1]{assetamortization.Columns["idassetunload"]};
	Relations.Add(new DataRelation("assetunload_assetamortization",CPar,CChild,false));

	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{assetload.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_assetload",CPar,CChild,false));

	CPar = new DataColumn[1]{assetloadkind.Columns["idassetloadkind"]};
	CChild = new DataColumn[1]{assetload.Columns["idassetloadkind"]};
	Relations.Add(new DataRelation("assetloadkind_assetload",CPar,CChild,false));

	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{assetunload.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_assetunload",CPar,CChild,false));

	CPar = new DataColumn[1]{assetunloadkind.Columns["idassetunloadkind"]};
	CChild = new DataColumn[1]{assetunload.Columns["idassetunloadkind"]};
	Relations.Add(new DataRelation("assetunloadkindassetunload",CPar,CChild,false));

	CPar = new DataColumn[1]{assetload.Columns["idassetload"]};
	CChild = new DataColumn[1]{assetacquire.Columns["idassetload"]};
	Relations.Add(new DataRelation("assetload_assetacquire",CPar,CChild,false));

	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{assetacquire.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_assetacquire",CPar,CChild,false));

	#endregion

}
}
}
