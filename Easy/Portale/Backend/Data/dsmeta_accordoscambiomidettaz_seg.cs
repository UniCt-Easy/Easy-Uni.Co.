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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_accordoscambiomidettaz_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_accordoscambiomidettaz_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefr_alias4 		=> (MetaTable)Tables["cefr_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefr_alias3 		=> (MetaTable)Tables["cefr_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefr_alias2 		=> (MetaTable)Tables["cefr_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefr_alias1 		=> (MetaTable)Tables["cefr_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefr 		=> (MetaTable)Tables["cefr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel 		=> (MetaTable)Tables["cefrlanglevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaziendeview 		=> (MetaTable)Tables["registryaziendeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomidettaz 		=> (MetaTable)Tables["accordoscambiomidettaz"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_accordoscambiomidettaz_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_accordoscambiomidettaz_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_accordoscambiomidettaz_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_accordoscambiomidettaz_seg.xsd";

	#region create DataTables
	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("lang", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// CEFR_ALIAS4 /////////////////////////////////
	var tcefr_alias4= new MetaTable("cefr_alias4");
	tcefr_alias4.defineColumn("active", typeof(string),false);
	tcefr_alias4.defineColumn("idcefr", typeof(int),false);
	tcefr_alias4.defineColumn("title", typeof(string),false);
	tcefr_alias4.ExtendedProperties["TableForReading"]="cefr";
	Tables.Add(tcefr_alias4);
	tcefr_alias4.defineKey("idcefr");

	//////////////////// CEFR_ALIAS3 /////////////////////////////////
	var tcefr_alias3= new MetaTable("cefr_alias3");
	tcefr_alias3.defineColumn("active", typeof(string),false);
	tcefr_alias3.defineColumn("idcefr", typeof(int),false);
	tcefr_alias3.defineColumn("title", typeof(string),false);
	tcefr_alias3.ExtendedProperties["TableForReading"]="cefr";
	Tables.Add(tcefr_alias3);
	tcefr_alias3.defineKey("idcefr");

	//////////////////// CEFR_ALIAS2 /////////////////////////////////
	var tcefr_alias2= new MetaTable("cefr_alias2");
	tcefr_alias2.defineColumn("active", typeof(string),false);
	tcefr_alias2.defineColumn("idcefr", typeof(int),false);
	tcefr_alias2.defineColumn("title", typeof(string),false);
	tcefr_alias2.ExtendedProperties["TableForReading"]="cefr";
	Tables.Add(tcefr_alias2);
	tcefr_alias2.defineKey("idcefr");

	//////////////////// CEFR_ALIAS1 /////////////////////////////////
	var tcefr_alias1= new MetaTable("cefr_alias1");
	tcefr_alias1.defineColumn("active", typeof(string),false);
	tcefr_alias1.defineColumn("idcefr", typeof(int),false);
	tcefr_alias1.defineColumn("title", typeof(string),false);
	tcefr_alias1.ExtendedProperties["TableForReading"]="cefr";
	Tables.Add(tcefr_alias1);
	tcefr_alias1.defineKey("idcefr");

	//////////////////// CEFR /////////////////////////////////
	var tcefr= new MetaTable("cefr");
	tcefr.defineColumn("active", typeof(string),false);
	tcefr.defineColumn("idcefr", typeof(int),false);
	tcefr.defineColumn("title", typeof(string),false);
	Tables.Add(tcefr);
	tcefr.defineKey("idcefr");

	//////////////////// CEFRLANGLEVEL /////////////////////////////////
	var tcefrlanglevel= new MetaTable("cefrlanglevel");
	tcefrlanglevel.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel.defineColumn("cu", typeof(string),false);
	tcefrlanglevel.defineColumn("idaccordoscambiomi", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidett", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidettlangkind", typeof(int));
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
	tcefrlanglevel.defineColumn("!idcefr_compasc_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_complett_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_parlinter_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_parlprod_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_scritto_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idnation_geo_nation_lang", typeof(string));
	tcefrlanglevel.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tcefrlanglevel);
	tcefrlanglevel.defineKey("idcefrlanglevel");

	//////////////////// REGISTRYAZIENDEVIEW /////////////////////////////////
	var tregistryaziendeview= new MetaTable("registryaziendeview");
	tregistryaziendeview.defineColumn("dropdown_title", typeof(string),false);
	tregistryaziendeview.defineColumn("idreg", typeof(int),false);
	tregistryaziendeview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistryaziendeview);
	tregistryaziendeview.defineKey("idreg");

	//////////////////// ACCORDOSCAMBIOMIDETTAZ /////////////////////////////////
	var taccordoscambiomidettaz= new MetaTable("accordoscambiomidettaz");
	taccordoscambiomidettaz.defineColumn("ct", typeof(DateTime),false);
	taccordoscambiomidettaz.defineColumn("cu", typeof(string),false);
	taccordoscambiomidettaz.defineColumn("idaccordoscambiomi", typeof(int),false);
	taccordoscambiomidettaz.defineColumn("idaccordoscambiomidettaz", typeof(int),false);
	taccordoscambiomidettaz.defineColumn("idreg_aziende", typeof(int),false);
	taccordoscambiomidettaz.defineColumn("lt", typeof(DateTime),false);
	taccordoscambiomidettaz.defineColumn("lu", typeof(string),false);
	taccordoscambiomidettaz.defineColumn("numstud", typeof(int));
	taccordoscambiomidettaz.defineColumn("stipula", typeof(DateTime));
	taccordoscambiomidettaz.defineColumn("stop", typeof(DateTime));
	Tables.Add(taccordoscambiomidettaz);
	taccordoscambiomidettaz.defineKey("idaccordoscambiomi", "idaccordoscambiomidettaz", "idreg_aziende");

	#endregion


	#region DataRelation creation
	var cPar = new []{accordoscambiomidettaz.Columns["idaccordoscambiomi"], accordoscambiomidettaz.Columns["idaccordoscambiomidettaz"]};
	var cChild = new []{cefrlanglevel.Columns["idaccordoscambiomi"], cefrlanglevel.Columns["idaccordoscambiomidettaz"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_accordoscambiomidettaz_idaccordoscambiomi-idaccordoscambiomidettaz",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{cefrlanglevel.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{cefr_alias4.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_scritto"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefr_alias4_idcefr_scritto",cPar,cChild,false));

	cPar = new []{cefr_alias3.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_parlprod"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefr_alias3_idcefr_parlprod",cPar,cChild,false));

	cPar = new []{cefr_alias2.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_parlinter"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefr_alias2_idcefr_parlinter",cPar,cChild,false));

	cPar = new []{cefr_alias1.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_complett"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefr_alias1_idcefr_complett",cPar,cChild,false));

	cPar = new []{cefr.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_compasc"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefr_idcefr_compasc",cPar,cChild,false));

	cPar = new []{registryaziendeview.Columns["idreg"]};
	cChild = new []{accordoscambiomidettaz.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_accordoscambiomidettaz_registryaziendeview_idreg_aziende",cPar,cChild,false));

	#endregion

}
}
}
