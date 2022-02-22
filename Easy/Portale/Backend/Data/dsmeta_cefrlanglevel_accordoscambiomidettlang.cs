
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
[System.Xml.Serialization.XmlRoot("dsmeta_cefrlanglevel_accordoscambiomidettlang"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_cefrlanglevel_accordoscambiomidettlang: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrdefaultview_alias4 		=> (MetaTable)Tables["cefrdefaultview_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrdefaultview_alias3 		=> (MetaTable)Tables["cefrdefaultview_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrdefaultview_alias2 		=> (MetaTable)Tables["cefrdefaultview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrdefaultview_alias1 		=> (MetaTable)Tables["cefrdefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrdefaultview 		=> (MetaTable)Tables["cefrdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomidettlangkind 		=> (MetaTable)Tables["accordoscambiomidettlangkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel 		=> (MetaTable)Tables["cefrlanglevel"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_cefrlanglevel_accordoscambiomidettlang(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_cefrlanglevel_accordoscambiomidettlang (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_cefrlanglevel_accordoscambiomidettlang";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_cefrlanglevel_accordoscambiomidettlang.xsd";

	#region create DataTables
	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("lang", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// CEFRDEFAULTVIEW_ALIAS4 /////////////////////////////////
	var tcefrdefaultview_alias4= new MetaTable("cefrdefaultview_alias4");
	tcefrdefaultview_alias4.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias4.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias4.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias4);
	tcefrdefaultview_alias4.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW_ALIAS3 /////////////////////////////////
	var tcefrdefaultview_alias3= new MetaTable("cefrdefaultview_alias3");
	tcefrdefaultview_alias3.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias3.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias3.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias3);
	tcefrdefaultview_alias3.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW_ALIAS2 /////////////////////////////////
	var tcefrdefaultview_alias2= new MetaTable("cefrdefaultview_alias2");
	tcefrdefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias2.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias2.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias2);
	tcefrdefaultview_alias2.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tcefrdefaultview_alias1= new MetaTable("cefrdefaultview_alias1");
	tcefrdefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview_alias1.defineColumn("idcefr", typeof(int),false);
	tcefrdefaultview_alias1.ExtendedProperties["TableForReading"]="cefrdefaultview";
	Tables.Add(tcefrdefaultview_alias1);
	tcefrdefaultview_alias1.defineKey("idcefr");

	//////////////////// CEFRDEFAULTVIEW /////////////////////////////////
	var tcefrdefaultview= new MetaTable("cefrdefaultview");
	tcefrdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcefrdefaultview.defineColumn("idcefr", typeof(int),false);
	Tables.Add(tcefrdefaultview);
	tcefrdefaultview.defineKey("idcefr");

	//////////////////// ACCORDOSCAMBIOMIDETTLANGKIND /////////////////////////////////
	var taccordoscambiomidettlangkind= new MetaTable("accordoscambiomidettlangkind");
	taccordoscambiomidettlangkind.defineColumn("idaccordoscambiomidettlangkind", typeof(int),false);
	taccordoscambiomidettlangkind.defineColumn("title", typeof(string));
	Tables.Add(taccordoscambiomidettlangkind);
	taccordoscambiomidettlangkind.defineKey("idaccordoscambiomidettlangkind");

	//////////////////// CEFRLANGLEVEL /////////////////////////////////
	var tcefrlanglevel= new MetaTable("cefrlanglevel");
	tcefrlanglevel.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel.defineColumn("cu", typeof(string),false);
	tcefrlanglevel.defineColumn("idaccordoscambiomi", typeof(int),false);
	tcefrlanglevel.defineColumn("idaccordoscambiomidett", typeof(int),false);
	tcefrlanglevel.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidettlangkind", typeof(int),false);
	tcefrlanglevel.defineColumn("idcefr_compasc", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_complett", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_scritto", typeof(int));
	tcefrlanglevel.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlanglevel.defineColumn("idiscrizionebmi", typeof(int));
	tcefrlanglevel.defineColumn("idlearningagrstud", typeof(int));
	tcefrlanglevel.defineColumn("idlearningagrtrainer", typeof(int));
	tcefrlanglevel.defineColumn("idnation", typeof(int));
	tcefrlanglevel.defineColumn("lt", typeof(DateTime),false);
	tcefrlanglevel.defineColumn("lu", typeof(string),false);
	Tables.Add(tcefrlanglevel);
	tcefrlanglevel.defineKey("idaccordoscambiomi", "idaccordoscambiomidett", "idcefrlanglevel");

	#endregion


	#region DataRelation creation
	var cPar = new []{geo_nation.Columns["idnation"]};
	var cChild = new []{cefrlanglevel.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{cefrdefaultview_alias4.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_scritto"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefrdefaultview_alias4_idcefr_scritto",cPar,cChild,false));

	cPar = new []{cefrdefaultview_alias3.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_parlprod"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefrdefaultview_alias3_idcefr_parlprod",cPar,cChild,false));

	cPar = new []{cefrdefaultview_alias2.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_parlinter"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefrdefaultview_alias2_idcefr_parlinter",cPar,cChild,false));

	cPar = new []{cefrdefaultview_alias1.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_complett"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefrdefaultview_alias1_idcefr_complett",cPar,cChild,false));

	cPar = new []{cefrdefaultview.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_compasc"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefrdefaultview_idcefr_compasc",cPar,cChild,false));

	cPar = new []{accordoscambiomidettlangkind.Columns["idaccordoscambiomidettlangkind"]};
	cChild = new []{cefrlanglevel.Columns["idaccordoscambiomidettlangkind"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_accordoscambiomidettlangkind_idaccordoscambiomidettlangkind",cPar,cChild,false));

	#endregion

}
}
}
