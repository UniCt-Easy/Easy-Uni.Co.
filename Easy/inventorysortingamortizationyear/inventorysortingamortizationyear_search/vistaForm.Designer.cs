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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace inventorysortingamortizationyear_search {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorysortingamortizationyear 		=> Tables["inventorysortingamortizationyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_load 		=> Tables["accmotiveapplied_load"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_unload 		=> Tables["accmotiveapplied_unload"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytreeview 		=> Tables["inventorytreeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventoryamortization 		=> Tables["inventoryamortization"];

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
	//////////////////// INVENTORYSORTINGAMORTIZATIONYEAR /////////////////////////////////
	var tinventorysortingamortizationyear= new DataTable("inventorysortingamortizationyear");
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tinventorysortingamortizationyear.Columns.Add(C);
	C= new DataColumn("idinventoryamortization", typeof(int));
	C.AllowDBNull=false;
	tinventorysortingamortizationyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tinventorysortingamortizationyear.Columns.Add(C);
	tinventorysortingamortizationyear.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventorysortingamortizationyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorysortingamortizationyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventorysortingamortizationyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorysortingamortizationyear.Columns.Add(C);
	tinventorysortingamortizationyear.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tinventorysortingamortizationyear.Columns.Add( new DataColumn("idaccmotiveunload", typeof(string)));
	Tables.Add(tinventorysortingamortizationyear);
	tinventorysortingamortizationyear.PrimaryKey =  new DataColumn[]{tinventorysortingamortizationyear.Columns["idinv"], tinventorysortingamortizationyear.Columns["idinventoryamortization"], tinventorysortingamortizationyear.Columns["ayear"]};


	//////////////////// ACCMOTIVEAPPLIED_LOAD /////////////////////////////////
	var taccmotiveapplied_load= new DataTable("accmotiveapplied_load");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_load.Columns.Add(C);
	taccmotiveapplied_load.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_load.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_load.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_load.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_load.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_load.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_load.Columns.Add(C);
	taccmotiveapplied_load.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_load.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_load.Columns.Add( new DataColumn("epoperation", typeof(string)));
	taccmotiveapplied_load.Columns.Add( new DataColumn("in_use", typeof(string)));
	Tables.Add(taccmotiveapplied_load);
	taccmotiveapplied_load.PrimaryKey =  new DataColumn[]{taccmotiveapplied_load.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVEAPPLIED_UNLOAD /////////////////////////////////
	var taccmotiveapplied_unload= new DataTable("accmotiveapplied_unload");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_unload.Columns.Add(C);
	taccmotiveapplied_unload.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_unload.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_unload.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_unload.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_unload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_unload.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_unload.Columns.Add(C);
	taccmotiveapplied_unload.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_unload.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_unload.Columns.Add( new DataColumn("epoperation", typeof(string)));
	taccmotiveapplied_unload.Columns.Add( new DataColumn("in_use", typeof(string)));
	Tables.Add(taccmotiveapplied_unload);
	taccmotiveapplied_unload.PrimaryKey =  new DataColumn[]{taccmotiveapplied_unload.Columns["idaccmotive"]};


	//////////////////// INVENTORYTREEVIEW /////////////////////////////////
	var tinventorytreeview= new DataTable("inventorytreeview");
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	tinventorytreeview.Columns.Add( new DataColumn("paridinv", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	Tables.Add(tinventorytreeview);
	tinventorytreeview.PrimaryKey =  new DataColumn[]{tinventorytreeview.Columns["idinv"]};


	//////////////////// INVENTORYAMORTIZATION /////////////////////////////////
	var tinventoryamortization= new DataTable("inventoryamortization");
	C= new DataColumn("idinventoryamortization", typeof(int));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("codeinventoryamortization", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	tinventoryamortization.Columns.Add( new DataColumn("age", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinventoryamortization.Columns.Add(C);
	tinventoryamortization.Columns.Add( new DataColumn("active", typeof(string)));
	tinventoryamortization.Columns.Add( new DataColumn("agemax", typeof(int)));
	tinventoryamortization.Columns.Add( new DataColumn("valuemin", typeof(decimal)));
	tinventoryamortization.Columns.Add( new DataColumn("valuemax", typeof(decimal)));
	Tables.Add(tinventoryamortization);
	tinventoryamortization.PrimaryKey =  new DataColumn[]{tinventoryamortization.Columns["idinventoryamortization"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{accmotiveapplied_load.Columns["idaccmotive"]};
	var cChild = new []{inventorysortingamortizationyear.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("inventorysortingamortizationyear_accmotiveapplied_load",cPar,cChild,false));

	cPar = new []{accmotiveapplied_unload.Columns["idaccmotive"]};
	cChild = new []{inventorysortingamortizationyear.Columns["idaccmotiveunload"]};
	Relations.Add(new DataRelation("inventorysortingamortizationyear_accmotiveapplied_unload",cPar,cChild,false));

	cPar = new []{inventorytreeview.Columns["idinv"]};
	cChild = new []{inventorysortingamortizationyear.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytreeview_inventorysortingamortizationyear",cPar,cChild,false));

	cPar = new []{inventoryamortization.Columns["idinventoryamortization"]};
	cChild = new []{inventorysortingamortizationyear.Columns["idinventoryamortization"]};
	Relations.Add(new DataRelation("inventoryamortization_inventorysortingamortizationyear",cPar,cChild,false));

	#endregion

}
}
}
