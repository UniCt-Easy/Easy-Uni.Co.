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
[System.Xml.Serialization.XmlRootAttribute("vistaResponsabiliCespiti")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaResponsabiliCespiti: DataSet {

	#region Table members declaration
	///<summary>
	///Cespiti e accessori
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable asset		{get { return Tables["asset"];}}
	///<summary>
	///Ubicazione cespite
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetlocation		{get { return Tables["assetlocation"];}}
	///<summary>
	///Responsabile cespite
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetmanager		{get { return Tables["assetmanager"];}}
	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable manager		{get { return Tables["manager"];}}
	///<summary>
	///Piano delle Ubicazioni
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable location		{get { return Tables["location"];}}
	///<summary>
	///Sezione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable division		{get { return Tables["division"];}}
	///<summary>
	///Cespite da collegare, tabella che abbiamo usato in una migrazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assettolink		{get { return Tables["assettolink"];}}
	///<summary>
	///Consegnatario cespite
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetsubmanager		{get { return Tables["assetsubmanager"];}}
	///<summary>
	///Carico dei cespiti da bolla/fattura
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetacquire		{get { return Tables["assetacquire"];}}
	///<summary>
	///Inventario
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable inventory		{get { return Tables["inventory"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaResponsabiliCespiti(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaResponsabiliCespiti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaResponsabiliCespiti";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaResponsabiliCespiti.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// ASSET /////////////////////////////////
	T= new DataTable("asset");
	C= new DataColumn("idasset", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idasset_prev", typeof(Int32)));
	T.Columns.Add( new DataColumn("idpiece_prev", typeof(Int32)));
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
	T.Columns.Add( new DataColumn("idassetunload", typeof(Int32)));
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("multifield", typeof(String)));
	T.Columns.Add( new DataColumn("idcurrlocation", typeof(Int32)));
	T.Columns.Add( new DataColumn("idcurrman", typeof(Int32)));
	T.Columns.Add( new DataColumn("idcurrsubman", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idasset"], T.Columns["idpiece"]};


	//////////////////// ASSETLOCATION /////////////////////////////////
	T= new DataTable("assetlocation");
	C= new DataColumn("idasset", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idassetlocation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
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
	C= new DataColumn("idlocation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idasset"], T.Columns["idassetlocation"]};


	//////////////////// ASSETMANAGER /////////////////////////////////
	T= new DataTable("assetmanager");
	C= new DataColumn("idasset", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idassetmanager", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
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
	C= new DataColumn("idman", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idasset"], T.Columns["idassetmanager"]};


	//////////////////// MANAGER /////////////////////////////////
	T= new DataTable("manager");
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("email", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("passwordweb", typeof(String)));
	T.Columns.Add( new DataColumn("phonenumber", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("financeactive", typeof(String)));
	T.Columns.Add( new DataColumn("userweb", typeof(String)));
	C= new DataColumn("idman", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idman"]};


	//////////////////// LOCATION /////////////////////////////////
	T= new DataTable("location");
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
	C= new DataColumn("locationcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idlocation", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridlocation", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idlocation"]};


	//////////////////// DIVISION /////////////////////////////////
	T= new DataTable("division");
	T.Columns.Add( new DataColumn("address", typeof(String)));
	T.Columns.Add( new DataColumn("cap", typeof(String)));
	T.Columns.Add( new DataColumn("city", typeof(String)));
	T.Columns.Add( new DataColumn("country", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("faxnumber", typeof(String)));
	T.Columns.Add( new DataColumn("faxprefix", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("phonenumber", typeof(String)));
	T.Columns.Add( new DataColumn("phoneprefix", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("codedivision", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["iddivision"]};


	//////////////////// ASSETTOLINK /////////////////////////////////
	T= new DataTable("assettolink");
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
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idinventory_tolink", typeof(Int32)));
	T.Columns.Add( new DataColumn("ninventory_tolink", typeof(Int32)));
	T.Columns.Add( new DataColumn("idpiece_tolink", typeof(Int32)));
	C= new DataColumn("kind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idasset"], T.Columns["idpiece"], T.Columns["kind"]};


	//////////////////// ASSETSUBMANAGER /////////////////////////////////
	T= new DataTable("assetsubmanager");
	C= new DataColumn("idasset", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idassetsubmanager", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idmanager", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idasset"], T.Columns["idassetsubmanager"]};


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
	T.Columns.Add( new DataColumn("idmankind", typeof(String)));
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
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("idinventory", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idmot", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idassetload", typeof(Int32)));
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	T.Columns.Add( new DataColumn("historicalvalue", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idlist", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nassetacquire"]};


	//////////////////// INVENTORY /////////////////////////////////
	T= new DataTable("inventory");
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
	T.Columns.Add( new DataColumn("startnumber", typeof(Int32)));
	C= new DataColumn("idinventoryagency", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinventorykind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeinventory", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinventory"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{manager.Columns["idman"]};
	CChild = new DataColumn[1]{assetsubmanager.Columns["idmanager"]};
	Relations.Add(new DataRelation("manager_assetsubmanager",CPar,CChild,false));

	CPar = new DataColumn[1]{asset.Columns["idasset"]};
	CChild = new DataColumn[1]{assetsubmanager.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetsubmanager",CPar,CChild,false));

	CPar = new DataColumn[2]{asset.Columns["idasset"], asset.Columns["idpiece"]};
	CChild = new DataColumn[2]{assettolink.Columns["idasset"], assettolink.Columns["idpiece"]};
	Relations.Add(new DataRelation("asset_assettolink",CPar,CChild,false));

	CPar = new DataColumn[1]{division.Columns["iddivision"]};
	CChild = new DataColumn[1]{manager.Columns["iddivision"]};
	Relations.Add(new DataRelation("division_manager",CPar,CChild,false));

	CPar = new DataColumn[1]{manager.Columns["idman"]};
	CChild = new DataColumn[1]{assetmanager.Columns["idman"]};
	Relations.Add(new DataRelation("manager_assetmanager",CPar,CChild,false));

	CPar = new DataColumn[1]{asset.Columns["idasset"]};
	CChild = new DataColumn[1]{assetmanager.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetmanager",CPar,CChild,false));

	CPar = new DataColumn[1]{asset.Columns["idasset"]};
	CChild = new DataColumn[1]{assetlocation.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetlocation",CPar,CChild,false));

	CPar = new DataColumn[1]{location.Columns["idlocation"]};
	CChild = new DataColumn[1]{assetlocation.Columns["idlocation"]};
	Relations.Add(new DataRelation("location_assetlocation",CPar,CChild,false));

	CPar = new DataColumn[2]{asset.Columns["idasset"], asset.Columns["idpiece"]};
	CChild = new DataColumn[2]{asset.Columns["idasset_prev"], asset.Columns["idpiece_prev"]};
	Relations.Add(new DataRelation("asset_asset",CPar,CChild,false));

	CPar = new DataColumn[1]{manager.Columns["idman"]};
	CChild = new DataColumn[1]{asset.Columns["idcurrman"]};
	Relations.Add(new DataRelation("manager_asset",CPar,CChild,false));

	CPar = new DataColumn[1]{location.Columns["idlocation"]};
	CChild = new DataColumn[1]{asset.Columns["idcurrlocation"]};
	Relations.Add(new DataRelation("location_asset",CPar,CChild,false));

	CPar = new DataColumn[1]{manager.Columns["idman"]};
	CChild = new DataColumn[1]{asset.Columns["idcurrsubman"]};
	Relations.Add(new DataRelation("manager_asset1",CPar,CChild,false));

	CPar = new DataColumn[1]{inventory.Columns["idinventory"]};
	CChild = new DataColumn[1]{assetacquire.Columns["idinventory"]};
	Relations.Add(new DataRelation("inventory_assetacquire",CPar,CChild,false));

	CPar = new DataColumn[1]{assetacquire.Columns["nassetacquire"]};
	CChild = new DataColumn[1]{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("assetacquire_asset",CPar,CChild,false));

	#endregion

}
}
}
