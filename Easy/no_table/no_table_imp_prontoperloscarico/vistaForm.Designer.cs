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
namespace no_table_imp_prontoperloscarico {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable asset 		=> Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable no_table 		=> Tables["no_table"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetview 		=> Tables["assetview"];

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
	//////////////////// ASSET /////////////////////////////////
	var tasset= new DataTable("asset");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tasset.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tasset.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	tasset.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("multifield", typeof(string)));
	tasset.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tasset.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tasset.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tasset.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tasset.Columns.Add( new DataColumn("txt", typeof(string)));
	tasset.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	tasset.Columns.Add( new DataColumn("idinventoryamortization", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idinventory", typeof(int)));
	tasset.Columns.Add( new DataColumn("rfid", typeof(string)));
	Tables.Add(tasset);
	tasset.PrimaryKey =  new DataColumn[]{tasset.Columns["idasset"], tasset.Columns["idpiece"]};


	//////////////////// NO_TABLE /////////////////////////////////
	var tno_table= new DataTable("no_table");
	C= new DataColumn("idnotable", typeof(string));
	C.AllowDBNull=false;
	tno_table.Columns.Add(C);
	Tables.Add(tno_table);
	tno_table.PrimaryKey =  new DataColumn[]{tno_table.Columns["idnotable"]};


	//////////////////// ASSETVIEW /////////////////////////////////
	var tassetview= new DataTable("assetview");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idinventory_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("codeinventory_prev", typeof(string)));
	tassetview.Columns.Add( new DataColumn("inventory_prev", typeof(string)));
	tassetview.Columns.Add( new DataColumn("ninventory_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idasset_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idpiece_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idinventory_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("codeinventory_next", typeof(string)));
	tassetview.Columns.Add( new DataColumn("inventory_next", typeof(string)));
	tassetview.Columns.Add( new DataColumn("ninventory_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("yearstart", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tassetview.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetview.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetview.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetview.Columns.Add( new DataColumn("currmanager", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tassetview.Columns.Add( new DataColumn("currsubmanager", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventorytree_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("codeinventory", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("idloadmot", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("loadmotive", typeof(string)));
	tassetview.Columns.Add( new DataColumn("loaddescription", typeof(string)));
	tassetview.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("loaddate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("loaddoc", typeof(string)));
	tassetview.Columns.Add( new DataColumn("loaddocdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("loadenactment", typeof(string)));
	tassetview.Columns.Add( new DataColumn("loadenactmentdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("loadprintdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("abatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("cost", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("revals", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("revals_pending", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("subtractions", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("currentvalue", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetview.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetview.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetview.Columns.Add( new DataColumn("unloaddate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("idunloadmot", typeof(int)));
	tassetview.Columns.Add( new DataColumn("unloadmotive", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloaddescription", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloaddoc", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloaddocdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("unloadenactment", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloadenactmentdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("unloadratificationdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("unloadregistry", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("flagtransf", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flagload", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("loadkind", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("multifield", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("is_unloaded", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("is_loaded", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tassetview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tassetview.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventoryagency", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idlist", typeof(int)));
	tassetview.Columns.Add( new DataColumn("intcode", typeof(string)));
	tassetview.Columns.Add( new DataColumn("list", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idinventoryamortization", typeof(int)));
	tassetview.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	tassetview.Columns.Add( new DataColumn("historical", typeof(decimal)));
	C= new DataColumn("ispiece", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventorykindvisible", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("rfid", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tassetview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tassetview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tassetview.Columns.Add( new DataColumn("invrownum", typeof(int)));
	Tables.Add(tassetview);
	tassetview.PrimaryKey =  new DataColumn[]{tassetview.Columns["idasset"], tassetview.Columns["idpiece"]};


	#endregion

}
}
}
