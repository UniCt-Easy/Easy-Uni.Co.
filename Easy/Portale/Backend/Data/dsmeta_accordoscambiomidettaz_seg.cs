
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
[System.Xml.Serialization.XmlRoot("dsmeta_accordoscambiomidettaz_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_accordoscambiomidettaz_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

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

	//////////////////// CEFR /////////////////////////////////
	var tcefr= new MetaTable("cefr");
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
	tcefrlanglevel.defineColumn("!idcefr_compasc_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_complett_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_parlinter_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_parlprod_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_scritto_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idnation_geo_nation_lang", typeof(string));
	Tables.Add(tcefrlanglevel);
	tcefrlanglevel.defineKey("idcefrlanglevel");

	//////////////////// REGISTRYAZIENDEVIEW /////////////////////////////////
	var tregistryaziendeview= new MetaTable("registryaziendeview");
	tregistryaziendeview.defineColumn("dropdown_title", typeof(string),false);
	tregistryaziendeview.defineColumn("idateco", typeof(int));
	tregistryaziendeview.defineColumn("idcategory", typeof(string));
	tregistryaziendeview.defineColumn("idcity", typeof(int));
	tregistryaziendeview.defineColumn("idnace", typeof(string));
	tregistryaziendeview.defineColumn("idnation", typeof(int));
	tregistryaziendeview.defineColumn("idnaturagiur", typeof(int));
	tregistryaziendeview.defineColumn("idnumerodip", typeof(int));
	tregistryaziendeview.defineColumn("idreg", typeof(int),false);
	tregistryaziendeview.defineColumn("idregistryclass", typeof(string));
	tregistryaziendeview.defineColumn("residence", typeof(int),false);
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

	cPar = new []{cefr.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_scritto"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefr_idcefr_scritto",cPar,cChild,false));

	cPar = new []{cefr.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_parlprod"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefr_idcefr_parlprod",cPar,cChild,false));

	cPar = new []{cefr.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_parlinter"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefr_idcefr_parlinter",cPar,cChild,false));

	cPar = new []{cefr.Columns["idcefr"]};
	cChild = new []{cefrlanglevel.Columns["idcefr_complett"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_cefr_idcefr_complett",cPar,cChild,false));

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
