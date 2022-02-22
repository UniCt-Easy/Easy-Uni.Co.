
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_driverupb_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_driverupb_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting 		=> (MetaTable)Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable driverupbdetail 		=> (MetaTable)Tables["driverupbdetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbcoanview 		=> (MetaTable)Tables["upbcoanview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accountusablecoanview 		=> (MetaTable)Tables["accountusablecoanview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable driverupb 		=> (MetaTable)Tables["driverupb"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_driverupb_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_driverupb_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_driverupb_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_driverupb_default.xsd";

	#region create DataTables
	//////////////////// SORTING /////////////////////////////////
	var tsorting= new MetaTable("sorting");
	tsorting.defineColumn("description", typeof(string),false);
	tsorting.defineColumn("idsor", typeof(int),false);
	tsorting.defineColumn("sortcode", typeof(string),false);
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// DRIVERUPBDETAIL /////////////////////////////////
	var tdriverupbdetail= new MetaTable("driverupbdetail");
	tdriverupbdetail.defineColumn("iddriverupb", typeof(int),false);
	tdriverupbdetail.defineColumn("iddriverupbdetail", typeof(int),false);
	tdriverupbdetail.defineColumn("idreg", typeof(int));
	tdriverupbdetail.defineColumn("idsor", typeof(int),false);
	tdriverupbdetail.defineColumn("quota", typeof(decimal));
	tdriverupbdetail.defineColumn("!idreg_registry_title", typeof(string));
	tdriverupbdetail.defineColumn("!idsor_sorting_sortcode", typeof(string));
	tdriverupbdetail.defineColumn("!idsor_sorting_description", typeof(string));
	Tables.Add(tdriverupbdetail);
	tdriverupbdetail.defineKey("iddriverupb", "iddriverupbdetail");

	//////////////////// UPBCOANVIEW /////////////////////////////////
	var tupbcoanview= new MetaTable("upbcoanview");
	tupbcoanview.defineColumn("dropdown_title", typeof(string),false);
	tupbcoanview.defineColumn("idupb", typeof(string),false);
	tupbcoanview.defineColumn("upb_active", typeof(string));
	Tables.Add(tupbcoanview);
	tupbcoanview.defineKey("idupb");

	//////////////////// ACCOUNTUSABLECOANVIEW /////////////////////////////////
	var taccountusablecoanview= new MetaTable("accountusablecoanview");
	taccountusablecoanview.defineColumn("accountkind_description", typeof(string));
	taccountusablecoanview.defineColumn("accountusable_accountkind", typeof(string),false);
	taccountusablecoanview.defineColumn("accountusable_ayear", typeof(int),false);
	taccountusablecoanview.defineColumn("accountusable_codeacc", typeof(string),false);
	taccountusablecoanview.defineColumn("accountusable_ct", typeof(DateTime),false);
	taccountusablecoanview.defineColumn("accountusable_cu", typeof(string),false);
	taccountusablecoanview.defineColumn("accountusable_flagaccountusage", typeof(int));
	taccountusablecoanview.defineColumn("accountusable_flagda", typeof(string));
	taccountusablecoanview.defineColumn("accountusable_flagregistry", typeof(string));
	taccountusablecoanview.defineColumn("accountusable_flagtransitory", typeof(string));
	taccountusablecoanview.defineColumn("accountusable_flagupb", typeof(string));
	taccountusablecoanview.defineColumn("accountusable_idaccountkind", typeof(string));
	taccountusablecoanview.defineColumn("accountusable_lt", typeof(DateTime),false);
	taccountusablecoanview.defineColumn("accountusable_lu", typeof(string),false);
	taccountusablecoanview.defineColumn("accountusable_nlevel", typeof(string));
	taccountusablecoanview.defineColumn("accountusable_printingorder", typeof(string),false);
	taccountusablecoanview.defineColumn("accountusableparent_ayear", typeof(int));
	taccountusablecoanview.defineColumn("accountusableparent_codeacc", typeof(string));
	taccountusablecoanview.defineColumn("accountusableparent_title", typeof(string));
	taccountusablecoanview.defineColumn("dropdown_title", typeof(string),false);
	taccountusablecoanview.defineColumn("idacc", typeof(string),false);
	taccountusablecoanview.defineColumn("idpatrimony", typeof(string));
	taccountusablecoanview.defineColumn("idplaccount", typeof(string));
	taccountusablecoanview.defineColumn("paridacc", typeof(string));
	taccountusablecoanview.defineColumn("patrimony_title", typeof(string));
	taccountusablecoanview.defineColumn("placcount_title", typeof(string));
	taccountusablecoanview.defineColumn("title", typeof(string),false);
	Tables.Add(taccountusablecoanview);
	taccountusablecoanview.defineKey("idacc");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// DRIVERUPB /////////////////////////////////
	var tdriverupb= new MetaTable("driverupb");
	tdriverupb.defineColumn("!percentuale", typeof(decimal));
	tdriverupb.defineColumn("idacc", typeof(string),false);
	tdriverupb.defineColumn("iddriverupb", typeof(int),false);
	tdriverupb.defineColumn("idupb", typeof(string),false);
	tdriverupb.defineColumn("year", typeof(int));
	Tables.Add(tdriverupb);
	tdriverupb.defineKey("iddriverupb");

	#endregion


	#region DataRelation creation
	var cPar = new []{driverupb.Columns["iddriverupb"]};
	var cChild = new []{driverupbdetail.Columns["iddriverupb"]};
	Relations.Add(new DataRelation("FK_driverupbdetail_driverupb_iddriverupb",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{driverupbdetail.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_driverupbdetail_sorting_idsor",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{driverupbdetail.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_driverupbdetail_registry_idreg",cPar,cChild,false));

	cPar = new []{upbcoanview.Columns["idupb"]};
	cChild = new []{driverupb.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_driverupb_upbcoanview_idupb",cPar,cChild,false));

	cPar = new []{accountusablecoanview.Columns["idacc"]};
	cChild = new []{driverupb.Columns["idacc"]};
	Relations.Add(new DataRelation("FK_driverupb_accountusablecoanview_idacc",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{driverupb.Columns["year"]};
	Relations.Add(new DataRelation("FK_driverupb_year_year",cPar,cChild,false));

	#endregion

}
}
}
