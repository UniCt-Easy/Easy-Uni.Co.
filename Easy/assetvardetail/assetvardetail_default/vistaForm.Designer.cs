
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
namespace assetvardetail_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventoryagency 		=> Tables["inventoryagency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetvardetail 		=> Tables["assetvardetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetvar 		=> Tables["assetvar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytreeview 		=> Tables["inventorytreeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetvardetailview 		=> Tables["assetvardetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetvarview 		=> Tables["assetvarview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory 		=> Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadmotive 		=> Tables["assetloadmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetvardetailattachment 		=> Tables["assetvardetailattachment"];

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
	//////////////////// INVENTORYAGENCY /////////////////////////////////
	var tinventoryagency= new DataTable("inventoryagency");
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventoryagency.Columns.Add(C);
	tinventoryagency.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tinventoryagency);
	tinventoryagency.PrimaryKey =  new DataColumn[]{tinventoryagency.Columns["idinventoryagency"]};


	//////////////////// ASSETVARDETAIL /////////////////////////////////
	var tassetvardetail= new DataTable("assetvardetail");
	C= new DataColumn("idassetvar", typeof(int));
	C.AllowDBNull=false;
	tassetvardetail.Columns.Add(C);
	C= new DataColumn("idassetvardetail", typeof(int));
	C.AllowDBNull=false;
	tassetvardetail.Columns.Add(C);
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetvardetail.Columns.Add(C);
	tassetvardetail.Columns.Add( new DataColumn("description", typeof(string)));
	tassetvardetail.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetvardetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvardetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetvardetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvardetail.Columns.Add(C);
	tassetvardetail.Columns.Add( new DataColumn("idinventory", typeof(int)));
	tassetvardetail.Columns.Add( new DataColumn("idmot", typeof(int)));
	Tables.Add(tassetvardetail);
	tassetvardetail.PrimaryKey =  new DataColumn[]{tassetvardetail.Columns["idassetvar"], tassetvardetail.Columns["idassetvardetail"]};


	//////////////////// ASSETVAR /////////////////////////////////
	var tassetvar= new DataTable("assetvar");
	C= new DataColumn("idassetvar", typeof(int));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	tassetvar.Columns.Add( new DataColumn("enactment", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	tassetvar.Columns.Add( new DataColumn("nenactment", typeof(string)));
	tassetvar.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	tassetvar.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetvar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvar.Columns.Add(C);
	Tables.Add(tassetvar);
	tassetvar.PrimaryKey =  new DataColumn[]{tassetvar.Columns["idassetvar"]};


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

	//////////////////// ASSETVARDETAILVIEW /////////////////////////////////
	var tassetvardetailview= new DataTable("assetvardetailview");
	C= new DataColumn("idassetvar", typeof(int));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("idassetvardetail", typeof(int));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("inventoryagency", typeof(string));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("variationdescription", typeof(string));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	tassetvardetailview.Columns.Add( new DataColumn("enactment", typeof(string)));
	tassetvardetailview.Columns.Add( new DataColumn("nenactment", typeof(string)));
	tassetvardetailview.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	tassetvardetailview.Columns.Add( new DataColumn("variationkind", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	tassetvardetailview.Columns.Add( new DataColumn("description", typeof(string)));
	tassetvardetailview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvardetailview.Columns.Add(C);
	tassetvardetailview.Columns.Add( new DataColumn("idinventory", typeof(int)));
	tassetvardetailview.Columns.Add( new DataColumn("inventory", typeof(string)));
	tassetvardetailview.Columns.Add( new DataColumn("idmot", typeof(int)));
	Tables.Add(tassetvardetailview);
	tassetvardetailview.PrimaryKey =  new DataColumn[]{tassetvardetailview.Columns["idassetvar"], tassetvardetailview.Columns["idassetvardetail"]};


	//////////////////// ASSETVARVIEW /////////////////////////////////
	var tassetvarview= new DataTable("assetvarview");
	C= new DataColumn("idassetvar", typeof(int));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	C= new DataColumn("inventoryagency", typeof(string));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	tassetvarview.Columns.Add( new DataColumn("enactment", typeof(string)));
	tassetvarview.Columns.Add( new DataColumn("variationkind", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	tassetvarview.Columns.Add( new DataColumn("nenactment", typeof(string)));
	tassetvarview.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetvarview.Columns.Add(C);
	Tables.Add(tassetvarview);

	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new DataTable("inventory");
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("idinventorykind", typeof(int));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventory.Columns.Add(C);
	tinventory.Columns.Add( new DataColumn("startnumber", typeof(int)));
	tinventory.Columns.Add( new DataColumn("active", typeof(string)));
	tinventory.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinventory.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinventory);
	tinventory.PrimaryKey =  new DataColumn[]{tinventory.Columns["idinventory"]};


	//////////////////// ASSETLOADMOTIVE /////////////////////////////////
	var tassetloadmotive= new DataTable("assetloadmotive");
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	tassetloadmotive.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tassetloadmotive);
	tassetloadmotive.PrimaryKey =  new DataColumn[]{tassetloadmotive.Columns["idmot"]};


	//////////////////// ASSETVARDETAILATTACHMENT /////////////////////////////////
	var tassetvardetailattachment= new DataTable("assetvardetailattachment");
	C= new DataColumn("idassetvar", typeof(int));
	C.AllowDBNull=false;
	tassetvardetailattachment.Columns.Add(C);
	C= new DataColumn("idassetvardetail", typeof(int));
	C.AllowDBNull=false;
	tassetvardetailattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	tassetvardetailattachment.Columns.Add(C);
	tassetvardetailattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	tassetvardetailattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	tassetvardetailattachment.Columns.Add( new DataColumn("cu", typeof(string)));
	tassetvardetailattachment.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tassetvardetailattachment.Columns.Add( new DataColumn("lu", typeof(string)));
	tassetvardetailattachment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tassetvardetailattachment.Columns.Add( new DataColumn("idattachmentkind", typeof(int)));
	Tables.Add(tassetvardetailattachment);
	tassetvardetailattachment.PrimaryKey =  new DataColumn[]{tassetvardetailattachment.Columns["idassetvar"], tassetvardetailattachment.Columns["idassetvardetail"], tassetvardetailattachment.Columns["idattachment"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{inventoryagency.Columns["idinventoryagency"]};
	var cChild = new []{assetvar.Columns["idinventoryagency"]};
	Relations.Add(new DataRelation("inventoryagencyassetvar",cPar,cChild,false));

	cPar = new []{assetloadmotive.Columns["idmot"]};
	cChild = new []{assetvardetail.Columns["idmot"]};
	Relations.Add(new DataRelation("assetloadmotive_assetvardetail",cPar,cChild,false));

	cPar = new []{inventory.Columns["idinventory"]};
	cChild = new []{assetvardetail.Columns["idinventory"]};
	Relations.Add(new DataRelation("inventoryassetvardetail",cPar,cChild,false));

	cPar = new []{inventorytreeview.Columns["idinv"]};
	cChild = new []{assetvardetail.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytreeviewassetvardetail",cPar,cChild,false));

	cPar = new []{assetvar.Columns["idassetvar"]};
	cChild = new []{assetvardetail.Columns["idassetvar"]};
	Relations.Add(new DataRelation("assetvarassetvardetail",cPar,cChild,false));

	cPar = new []{assetvardetail.Columns["idassetvar"], assetvardetail.Columns["idassetvardetail"]};
	cChild = new []{assetvardetailattachment.Columns["idassetvar"], assetvardetailattachment.Columns["idassetvardetail"]};
	Relations.Add(new DataRelation("assetvardetail_assetvardetailattachment",cPar,cChild,false));

	#endregion

}
}
}
