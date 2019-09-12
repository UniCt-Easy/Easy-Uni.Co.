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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace maintenance_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory 		=> Tables["inventory"];

	///<summary>
	///Tipo Manutenzione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable maintenancekind 		=> Tables["maintenancekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable maintenanceview 		=> Tables["maintenanceview"];

	///<summary>
	///Manutenzione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable maintenance 		=> Tables["maintenance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetpieceview 		=> Tables["assetpieceview"];

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
	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new DataTable("inventory");
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("idinventorykind", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	tinventory.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	tinventory.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tinventory);
	tinventory.PrimaryKey =  new DataColumn[]{tinventory.Columns["idinventory"]};


	//////////////////// MAINTENANCEKIND /////////////////////////////////
	var tmaintenancekind= new DataTable("maintenancekind");
	C= new DataColumn("idmaintenancekind", typeof(int));
	C.AllowDBNull=false;
	tmaintenancekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmaintenancekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmaintenancekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmaintenancekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmaintenancekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmaintenancekind.Columns.Add(C);
	tmaintenancekind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tmaintenancekind);
	tmaintenancekind.PrimaryKey =  new DataColumn[]{tmaintenancekind.Columns["idmaintenancekind"]};


	//////////////////// MAINTENANCEVIEW /////////////////////////////////
	var tmaintenanceview= new DataTable("maintenanceview");
	C= new DataColumn("nmaintenance", typeof(int));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("idmaintenancekind", typeof(int));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("maintenancekind", typeof(string));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	tmaintenanceview.Columns.Add( new DataColumn("ninventory", typeof(int)));
	C= new DataColumn("loaddescription", typeof(string));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	tmaintenanceview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmaintenanceview.Columns.Add(C);
	Tables.Add(tmaintenanceview);
	tmaintenanceview.PrimaryKey =  new DataColumn[]{tmaintenanceview.Columns["nmaintenance"]};


	//////////////////// MAINTENANCE /////////////////////////////////
	var tmaintenance= new DataTable("maintenance");
	C= new DataColumn("nmaintenance", typeof(int));
	C.AllowDBNull=false;
	tmaintenance.Columns.Add(C);
	C= new DataColumn("idmaintenancekind", typeof(int));
	C.AllowDBNull=false;
	tmaintenance.Columns.Add(C);
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tmaintenance.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmaintenance.Columns.Add(C);
	tmaintenance.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tmaintenance.Columns.Add(C);
	tmaintenance.Columns.Add( new DataColumn("txt", typeof(string)));
	tmaintenance.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmaintenance.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmaintenance.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmaintenance.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmaintenance.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tmaintenance.Columns.Add(C);
	Tables.Add(tmaintenance);
	tmaintenance.PrimaryKey =  new DataColumn[]{tmaintenance.Columns["nmaintenance"]};


	//////////////////// ASSETPIECEVIEW /////////////////////////////////
	var tassetpieceview= new DataTable("assetpieceview");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	tassetpieceview.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idlocation", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("locationcode", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("location", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("idman", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("manager", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("currmanager", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("descriptionmain", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetpieceview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetpieceview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tassetpieceview.Columns.Add( new DataColumn("discount", typeof(double)));
	tassetpieceview.Columns.Add( new DataColumn("total", typeof(decimal)));
	tassetpieceview.Columns.Add( new DataColumn("currentvalue", typeof(decimal)));
	tassetpieceview.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetpieceview.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("cost", typeof(decimal)));
	tassetpieceview.Columns.Add( new DataColumn("abatable", typeof(decimal)));
	Tables.Add(tassetpieceview);
	tassetpieceview.PrimaryKey =  new DataColumn[]{tassetpieceview.Columns["idasset"], tassetpieceview.Columns["idpiece"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{inventory.Columns["idinventory"]};
	var cChild = new []{assetpieceview.Columns["idinventory"]};
	Relations.Add(new DataRelation("inventoryassetpieceview",cPar,cChild,false));

	cPar = new []{assetpieceview.Columns["idasset"], assetpieceview.Columns["idpiece"]};
	cChild = new []{maintenance.Columns["idasset"], maintenance.Columns["idpiece"]};
	Relations.Add(new DataRelation("assetpieceviewmaintenance",cPar,cChild,false));

	cPar = new []{maintenancekind.Columns["idmaintenancekind"]};
	cChild = new []{maintenance.Columns["idmaintenancekind"]};
	Relations.Add(new DataRelation("maintenancekindmaintenance",cPar,cChild,false));

	#endregion

}
}
}
