
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
using System.Runtime.Serialization;
#pragma warning disable 1591
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_progettokind_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettokind_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackagekind 		=> (MetaTable)Tables["workpackagekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotestokindprogettostatuskind 		=> (MetaTable)Tables["progettotestokindprogettostatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotestokind 		=> (MetaTable)Tables["progettotestokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettokindcontrattokind 		=> (MetaTable)Tables["progettokindcontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoattachkindprogettostatuskind 		=> (MetaTable)Tables["progettoattachkindprogettostatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoattachkind 		=> (MetaTable)Tables["progettoattachkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotiporicavokindcontrattokind 		=> (MetaTable)Tables["progettotiporicavokindcontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotiporicavokindaccmotive 		=> (MetaTable)Tables["progettotiporicavokindaccmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindtax 		=> (MetaTable)Tables["progettotipocostokindtax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindinventorytree 		=> (MetaTable)Tables["progettotipocostokindinventorytree"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindcontrattokind 		=> (MetaTable)Tables["progettotipocostokindcontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindaccmotive 		=> (MetaTable)Tables["progettotipocostokindaccmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokind 		=> (MetaTable)Tables["progettotipocostokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoactivitykinddefaultview 		=> (MetaTable)Tables["progettoactivitykinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettokind 		=> (MetaTable)Tables["progettokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettokind_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettokind_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettokind_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettokind_seg.xsd";

	#region create DataTables
	//////////////////// WORKPACKAGEKIND /////////////////////////////////
	var tworkpackagekind= new MetaTable("workpackagekind");
	tworkpackagekind.defineColumn("idprogettokind", typeof(int),false);
	tworkpackagekind.defineColumn("idworkpackagekind", typeof(int),false);
	tworkpackagekind.defineColumn("title", typeof(string));
	Tables.Add(tworkpackagekind);
	tworkpackagekind.defineKey("idprogettokind", "idworkpackagekind");

	//////////////////// PROGETTOTESTOKINDPROGETTOSTATUSKIND /////////////////////////////////
	var tprogettotestokindprogettostatuskind= new MetaTable("progettotestokindprogettostatuskind");
	tprogettotestokindprogettostatuskind.defineColumn("ct", typeof(DateTime));
	tprogettotestokindprogettostatuskind.defineColumn("cu", typeof(string));
	tprogettotestokindprogettostatuskind.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettotestokindprogettostatuskind.defineColumn("idprogettotestokind", typeof(int),false);
	tprogettotestokindprogettostatuskind.defineColumn("lt", typeof(DateTime));
	tprogettotestokindprogettostatuskind.defineColumn("lu", typeof(string));
	tprogettotestokindprogettostatuskind.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprogettotestokindprogettostatuskind);
	tprogettotestokindprogettostatuskind.defineKey("idprogettostatuskind", "idprogettotestokind");

	//////////////////// PROGETTOTESTOKIND /////////////////////////////////
	var tprogettotestokind= new MetaTable("progettotestokind");
	tprogettotestokind.defineColumn("ct", typeof(DateTime));
	tprogettotestokind.defineColumn("cu", typeof(string));
	tprogettotestokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettotestokind.defineColumn("idprogettotestokind", typeof(int),false);
	tprogettotestokind.defineColumn("lt", typeof(DateTime));
	tprogettotestokind.defineColumn("lu", typeof(string));
	tprogettotestokind.defineColumn("sortcode", typeof(int));
	tprogettotestokind.defineColumn("titolo", typeof(string));
	Tables.Add(tprogettotestokind);
	tprogettotestokind.defineKey("idprogettokind", "idprogettotestokind");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("title", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// PROGETTOKINDCONTRATTOKIND /////////////////////////////////
	var tprogettokindcontrattokind= new MetaTable("progettokindcontrattokind");
	tprogettokindcontrattokind.defineColumn("costostandard", typeof(decimal));
	tprogettokindcontrattokind.defineColumn("ct", typeof(DateTime),false);
	tprogettokindcontrattokind.defineColumn("cu", typeof(string),false);
	tprogettokindcontrattokind.defineColumn("idposition", typeof(int),false);
	tprogettokindcontrattokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettokindcontrattokind.defineColumn("lt", typeof(DateTime),false);
	tprogettokindcontrattokind.defineColumn("lu", typeof(string),false);
	tprogettokindcontrattokind.defineColumn("!idposition_position_title", typeof(string));
	Tables.Add(tprogettokindcontrattokind);
	tprogettokindcontrattokind.defineKey("idposition", "idprogettokind");

	//////////////////// PROGETTOATTACHKINDPROGETTOSTATUSKIND /////////////////////////////////
	var tprogettoattachkindprogettostatuskind= new MetaTable("progettoattachkindprogettostatuskind");
	tprogettoattachkindprogettostatuskind.defineColumn("ct", typeof(DateTime));
	tprogettoattachkindprogettostatuskind.defineColumn("cu", typeof(string));
	tprogettoattachkindprogettostatuskind.defineColumn("idprogettoattachkind", typeof(int),false);
	tprogettoattachkindprogettostatuskind.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettoattachkindprogettostatuskind.defineColumn("lt", typeof(DateTime));
	tprogettoattachkindprogettostatuskind.defineColumn("lu", typeof(string));
	tprogettoattachkindprogettostatuskind.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprogettoattachkindprogettostatuskind);
	tprogettoattachkindprogettostatuskind.defineKey("idprogettoattachkind", "idprogettostatuskind");

	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// PROGETTOATTACHKIND /////////////////////////////////
	var tprogettoattachkind= new MetaTable("progettoattachkind");
	tprogettoattachkind.defineColumn("ct", typeof(DateTime),false);
	tprogettoattachkind.defineColumn("cu", typeof(string),false);
	tprogettoattachkind.defineColumn("idattach_template", typeof(int));
	tprogettoattachkind.defineColumn("idprogettoattachkind", typeof(int),false);
	tprogettoattachkind.defineColumn("idprogettokind", typeof(int),false);
	tprogettoattachkind.defineColumn("linktemplate", typeof(string));
	tprogettoattachkind.defineColumn("lt", typeof(DateTime),false);
	tprogettoattachkind.defineColumn("lu", typeof(string),false);
	tprogettoattachkind.defineColumn("title", typeof(string));
	tprogettoattachkind.defineColumn("!idattach_template_attach_filename", typeof(string));
	Tables.Add(tprogettoattachkind);
	tprogettoattachkind.defineKey("idprogettoattachkind", "idprogettokind");

	//////////////////// PROGETTOTIPORICAVOKINDCONTRATTOKIND /////////////////////////////////
	var tprogettotiporicavokindcontrattokind= new MetaTable("progettotiporicavokindcontrattokind");
	tprogettotiporicavokindcontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotiporicavokindcontrattokind.defineColumn("cu", typeof(string));
	tprogettotiporicavokindcontrattokind.defineColumn("idposition", typeof(int),false);
	tprogettotiporicavokindcontrattokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettotiporicavokindcontrattokind.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotiporicavokindcontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotiporicavokindcontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotiporicavokindcontrattokind);
	tprogettotiporicavokindcontrattokind.defineKey("idposition", "idprogettokind", "idprogettotipocostokind");

	//////////////////// PROGETTOTIPORICAVOKINDACCMOTIVE /////////////////////////////////
	var tprogettotiporicavokindaccmotive= new MetaTable("progettotiporicavokindaccmotive");
	tprogettotiporicavokindaccmotive.defineColumn("ct", typeof(DateTime));
	tprogettotiporicavokindaccmotive.defineColumn("cu", typeof(string));
	tprogettotiporicavokindaccmotive.defineColumn("idaccmotive", typeof(string),false);
	tprogettotiporicavokindaccmotive.defineColumn("idprogettokind", typeof(int),false);
	tprogettotiporicavokindaccmotive.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotiporicavokindaccmotive.defineColumn("lt", typeof(DateTime));
	tprogettotiporicavokindaccmotive.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotiporicavokindaccmotive);
	tprogettotiporicavokindaccmotive.defineKey("idaccmotive", "idprogettokind", "idprogettotipocostokind");

	//////////////////// PROGETTOTIPOCOSTOKINDTAX /////////////////////////////////
	var tprogettotipocostokindtax= new MetaTable("progettotipocostokindtax");
	tprogettotipocostokindtax.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokindtax.defineColumn("cu", typeof(string));
	tprogettotipocostokindtax.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindtax.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindtax.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokindtax.defineColumn("lu", typeof(string));
	tprogettotipocostokindtax.defineColumn("taxcode", typeof(int),false);
	Tables.Add(tprogettotipocostokindtax);
	tprogettotipocostokindtax.defineKey("idprogettokind", "idprogettotipocostokind", "taxcode");

	//////////////////// PROGETTOTIPOCOSTOKINDINVENTORYTREE /////////////////////////////////
	var tprogettotipocostokindinventorytree= new MetaTable("progettotipocostokindinventorytree");
	tprogettotipocostokindinventorytree.defineColumn("ct", typeof(DateTime),false);
	tprogettotipocostokindinventorytree.defineColumn("cu", typeof(string),false);
	tprogettotipocostokindinventorytree.defineColumn("idinv", typeof(int),false);
	tprogettotipocostokindinventorytree.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindinventorytree.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindinventorytree.defineColumn("lt", typeof(DateTime),false);
	tprogettotipocostokindinventorytree.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettotipocostokindinventorytree);
	tprogettotipocostokindinventorytree.defineKey("idinv", "idprogettokind", "idprogettotipocostokind");

	//////////////////// PROGETTOTIPOCOSTOKINDCONTRATTOKIND /////////////////////////////////
	var tprogettotipocostokindcontrattokind= new MetaTable("progettotipocostokindcontrattokind");
	tprogettotipocostokindcontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokindcontrattokind.defineColumn("cu", typeof(string));
	tprogettotipocostokindcontrattokind.defineColumn("idposition", typeof(int),false);
	tprogettotipocostokindcontrattokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindcontrattokind.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindcontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokindcontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostokindcontrattokind);
	tprogettotipocostokindcontrattokind.defineKey("idposition", "idprogettokind", "idprogettotipocostokind");

	//////////////////// PROGETTOTIPOCOSTOKINDACCMOTIVE /////////////////////////////////
	var tprogettotipocostokindaccmotive= new MetaTable("progettotipocostokindaccmotive");
	tprogettotipocostokindaccmotive.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokindaccmotive.defineColumn("cu", typeof(string));
	tprogettotipocostokindaccmotive.defineColumn("idaccmotive", typeof(string),false);
	tprogettotipocostokindaccmotive.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindaccmotive.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindaccmotive.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokindaccmotive.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostokindaccmotive);
	tprogettotipocostokindaccmotive.defineKey("idaccmotive", "idprogettokind", "idprogettotipocostokind");

	//////////////////// PROGETTOTIPOCOSTOKIND /////////////////////////////////
	var tprogettotipocostokind= new MetaTable("progettotipocostokind");
	tprogettotipocostokind.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokind.defineColumn("cu", typeof(string));
	tprogettotipocostokind.defineColumn("description", typeof(string));
	tprogettotipocostokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokind.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokind.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokind.defineColumn("lu", typeof(string));
	tprogettotipocostokind.defineColumn("title", typeof(string));
	Tables.Add(tprogettotipocostokind);
	tprogettotipocostokind.defineKey("idprogettokind", "idprogettotipocostokind");

	//////////////////// PROGETTOACTIVITYKINDDEFAULTVIEW /////////////////////////////////
	var tprogettoactivitykinddefaultview= new MetaTable("progettoactivitykinddefaultview");
	tprogettoactivitykinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tprogettoactivitykinddefaultview.defineColumn("idprogettoactivitykind", typeof(int),false);
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_active", typeof(string));
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_ct", typeof(DateTime),false);
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_cu", typeof(string),false);
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_description", typeof(string));
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_lt", typeof(DateTime),false);
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_lu", typeof(string),false);
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_sortcode", typeof(int));
	tprogettoactivitykinddefaultview.defineColumn("title", typeof(string));
	Tables.Add(tprogettoactivitykinddefaultview);
	tprogettoactivitykinddefaultview.defineKey("idprogettoactivitykind");

	//////////////////// PROGETTOKIND /////////////////////////////////
	var tprogettokind= new MetaTable("progettokind");
	tprogettokind.defineColumn("active", typeof(string));
	tprogettokind.defineColumn("ct", typeof(DateTime));
	tprogettokind.defineColumn("cu", typeof(string));
	tprogettokind.defineColumn("description", typeof(string));
	tprogettokind.defineColumn("idcorsostudio", typeof(string));
	tprogettokind.defineColumn("idprogettoactivitykind", typeof(int));
	tprogettokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettokind.defineColumn("irap", typeof(string));
	tprogettokind.defineColumn("lt", typeof(DateTime));
	tprogettokind.defineColumn("lu", typeof(string));
	tprogettokind.defineColumn("oredivisionecostostipendio", typeof(int),false);
	tprogettokind.defineColumn("stipendioannoprec", typeof(string));
	tprogettokind.defineColumn("stipendiocomericavo", typeof(string));
	tprogettokind.defineColumn("title", typeof(string));
	Tables.Add(tprogettokind);
	tprogettokind.defineKey("idprogettokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettokind.Columns["idprogettokind"]};
	var cChild = new []{workpackagekind.Columns["idprogettokind"]};
	Relations.Add(new DataRelation("FK_workpackagekind_progettokind_idprogettokind",cPar,cChild,false));

	cPar = new []{progettokind.Columns["idprogettokind"]};
	cChild = new []{progettotestokind.Columns["idprogettokind"]};
	Relations.Add(new DataRelation("FK_progettotestokind_progettokind_idprogettokind",cPar,cChild,false));

	cPar = new []{progettotestokind.Columns["idprogettotestokind"]};
	cChild = new []{progettotestokindprogettostatuskind.Columns["idprogettotestokind"]};
	Relations.Add(new DataRelation("FK_progettotestokindprogettostatuskind_progettotestokind_idprogettotestokind",cPar,cChild,false));

	cPar = new []{progettokind.Columns["idprogettokind"]};
	cChild = new []{progettokindcontrattokind.Columns["idprogettokind"]};
	Relations.Add(new DataRelation("FK_progettokindcontrattokind_progettokind_idprogettokind",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{progettokindcontrattokind.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_progettokindcontrattokind_position_idposition",cPar,cChild,false));

	cPar = new []{progettokind.Columns["idprogettokind"]};
	cChild = new []{progettoattachkind.Columns["idprogettokind"]};
	Relations.Add(new DataRelation("FK_progettoattachkind_progettokind_idprogettokind",cPar,cChild,false));

	cPar = new []{progettoattachkind.Columns["idprogettoattachkind"]};
	cChild = new []{progettoattachkindprogettostatuskind.Columns["idprogettoattachkind"]};
	Relations.Add(new DataRelation("FK_progettoattachkindprogettostatuskind_progettoattachkind_idprogettoattachkind",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{progettoattachkind.Columns["idattach_template"]};
	Relations.Add(new DataRelation("FK_progettoattachkind_attach_idattach_template",cPar,cChild,false));

	cPar = new []{progettokind.Columns["idprogettokind"]};
	cChild = new []{progettotipocostokind.Columns["idprogettokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokind_progettokind_idprogettokind",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotiporicavokindcontrattokind.Columns["idprogettokind"], progettotiporicavokindcontrattokind.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotiporicavokindcontrattokind_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotiporicavokindaccmotive.Columns["idprogettokind"], progettotiporicavokindaccmotive.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotiporicavokindaccmotive_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotipocostokindtax.Columns["idprogettokind"], progettotipocostokindtax.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindtax_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotipocostokindinventorytree.Columns["idprogettokind"], progettotipocostokindinventorytree.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindinventorytree_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotipocostokindcontrattokind.Columns["idprogettokind"], progettotipocostokindcontrattokind.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindcontrattokind_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotipocostokindaccmotive.Columns["idprogettokind"], progettotipocostokindaccmotive.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindaccmotive_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{progettoactivitykinddefaultview.Columns["idprogettoactivitykind"]};
	cChild = new []{progettokind.Columns["idprogettoactivitykind"]};
	Relations.Add(new DataRelation("FK_progettokind_progettoactivitykinddefaultview_idprogettoactivitykind",cPar,cChild,false));

	#endregion

}
}
}
