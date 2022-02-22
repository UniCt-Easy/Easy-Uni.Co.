
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
[System.Xml.Serialization.XmlRoot("dsmeta_accordoscambiomidett_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_accordoscambiomidett_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefr 		=> (MetaTable)Tables["cefr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomidettlangkind 		=> (MetaTable)Tables["accordoscambiomidettlangkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel 		=> (MetaTable)Tables["cefrlanglevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzannokind 		=> (MetaTable)Tables["didprogporzannokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomiporzanno 		=> (MetaTable)Tables["accordoscambiomiporzanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable torkind 		=> (MetaTable)Tables["torkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryistitutiesteriview 		=> (MetaTable)Tables["registryistitutiesteriview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable isced2013 		=> (MetaTable)Tables["isced2013"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomidett 		=> (MetaTable)Tables["accordoscambiomidett"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_accordoscambiomidett_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_accordoscambiomidett_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_accordoscambiomidett_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_accordoscambiomidett_seg.xsd";

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
	tcefrlanglevel.defineColumn("!idaccordoscambiomidettlangkind_accordoscambiomidettlangkind_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_compasc_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_complett_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_parlinter_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_parlprod_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idcefr_scritto_cefr_title", typeof(string));
	tcefrlanglevel.defineColumn("!idnation_geo_nation_lang", typeof(string));
	Tables.Add(tcefrlanglevel);
	tcefrlanglevel.defineKey("idaccordoscambiomi", "idaccordoscambiomidett", "idcefrlanglevel");

	//////////////////// DIDPROGPORZANNOKIND /////////////////////////////////
	var tdidprogporzannokind= new MetaTable("didprogporzannokind");
	tdidprogporzannokind.defineColumn("iddidprogporzannokind", typeof(int),false);
	tdidprogporzannokind.defineColumn("title", typeof(string),false);
	Tables.Add(tdidprogporzannokind);
	tdidprogporzannokind.defineKey("iddidprogporzannokind");

	//////////////////// ACCORDOSCAMBIOMIPORZANNO /////////////////////////////////
	var taccordoscambiomiporzanno= new MetaTable("accordoscambiomiporzanno");
	taccordoscambiomiporzanno.defineColumn("ct", typeof(DateTime),false);
	taccordoscambiomiporzanno.defineColumn("cu", typeof(string),false);
	taccordoscambiomiporzanno.defineColumn("idaccordoscambiomi", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("idaccordoscambiomidett", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("idaccordoscambiomiporzanno", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("iddidprogporzannokind", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("indice", typeof(int));
	taccordoscambiomiporzanno.defineColumn("lt", typeof(DateTime),false);
	taccordoscambiomiporzanno.defineColumn("lu", typeof(string),false);
	taccordoscambiomiporzanno.defineColumn("!iddidprogporzannokind_didprogporzannokind_title", typeof(string));
	Tables.Add(taccordoscambiomiporzanno);
	taccordoscambiomiporzanno.defineKey("idaccordoscambiomi", "idaccordoscambiomidett", "idaccordoscambiomiporzanno", "iddidprogporzannokind");

	//////////////////// TORKIND /////////////////////////////////
	var ttorkind= new MetaTable("torkind");
	ttorkind.defineColumn("description", typeof(string));
	ttorkind.defineColumn("idtorkind", typeof(int),false);
	ttorkind.defineColumn("title", typeof(string),false);
	Tables.Add(ttorkind);
	ttorkind.defineKey("idtorkind");

	//////////////////// REGISTRYISTITUTIESTERIVIEW /////////////////////////////////
	var tregistryistitutiesteriview= new MetaTable("registryistitutiesteriview");
	tregistryistitutiesteriview.defineColumn("dropdown_title", typeof(string),false);
	tregistryistitutiesteriview.defineColumn("idcity", typeof(int));
	tregistryistitutiesteriview.defineColumn("idnace", typeof(string));
	tregistryistitutiesteriview.defineColumn("idnation", typeof(int));
	tregistryistitutiesteriview.defineColumn("idreg", typeof(int),false);
	tregistryistitutiesteriview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistryistitutiesteriview);
	tregistryistitutiesteriview.defineKey("idreg");

	//////////////////// ISCED2013 /////////////////////////////////
	var tisced2013= new MetaTable("isced2013");
	tisced2013.defineColumn("detailedfield", typeof(string));
	tisced2013.defineColumn("idisced2013", typeof(int),false);
	Tables.Add(tisced2013);
	tisced2013.defineKey("idisced2013");

	//////////////////// ACCORDOSCAMBIOMIDETT /////////////////////////////////
	var taccordoscambiomidett= new MetaTable("accordoscambiomidett");
	taccordoscambiomidett.defineColumn("ct", typeof(DateTime),false);
	taccordoscambiomidett.defineColumn("cu", typeof(string),false);
	taccordoscambiomidett.defineColumn("idaccordoscambiomi", typeof(int),false);
	taccordoscambiomidett.defineColumn("idaccordoscambiomidett", typeof(int),false);
	taccordoscambiomidett.defineColumn("idisced2013", typeof(int),false);
	taccordoscambiomidett.defineColumn("idreg_istitutiesteri", typeof(int),false);
	taccordoscambiomidett.defineColumn("idtorkind", typeof(int));
	taccordoscambiomidett.defineColumn("lt", typeof(DateTime),false);
	taccordoscambiomidett.defineColumn("lu", typeof(string),false);
	taccordoscambiomidett.defineColumn("numdocincoming", typeof(int));
	taccordoscambiomidett.defineColumn("numdocoutgoing", typeof(int));
	taccordoscambiomidett.defineColumn("numpersincoming", typeof(int));
	taccordoscambiomidett.defineColumn("numpersoutgoing", typeof(int));
	taccordoscambiomidett.defineColumn("numstulearincoming", typeof(int));
	taccordoscambiomidett.defineColumn("numstulearoutgoing", typeof(int));
	taccordoscambiomidett.defineColumn("numstutraincoming", typeof(int));
	taccordoscambiomidett.defineColumn("numstutraoutgoing", typeof(int));
	taccordoscambiomidett.defineColumn("stipula", typeof(DateTime));
	taccordoscambiomidett.defineColumn("stop", typeof(DateTime));
	Tables.Add(taccordoscambiomidett);
	taccordoscambiomidett.defineKey("idaccordoscambiomi", "idaccordoscambiomidett", "idreg_istitutiesteri");

	#endregion


	#region DataRelation creation
	var cPar = new []{accordoscambiomidett.Columns["idaccordoscambiomi"], accordoscambiomidett.Columns["idaccordoscambiomidett"]};
	var cChild = new []{cefrlanglevel.Columns["idaccordoscambiomi"], cefrlanglevel.Columns["idaccordoscambiomidett"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_accordoscambiomidett_idaccordoscambiomi-idaccordoscambiomidett",cPar,cChild,false));

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

	cPar = new []{accordoscambiomidettlangkind.Columns["idaccordoscambiomidettlangkind"]};
	cChild = new []{cefrlanglevel.Columns["idaccordoscambiomidettlangkind"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_accordoscambiomidettlangkind_idaccordoscambiomidettlangkind",cPar,cChild,false));

	cPar = new []{accordoscambiomidett.Columns["idaccordoscambiomi"], accordoscambiomidett.Columns["idaccordoscambiomidett"]};
	cChild = new []{accordoscambiomiporzanno.Columns["idaccordoscambiomi"], accordoscambiomiporzanno.Columns["idaccordoscambiomidett"]};
	Relations.Add(new DataRelation("FK_accordoscambiomiporzanno_accordoscambiomidett_idaccordoscambiomi-idaccordoscambiomidett",cPar,cChild,false));

	cPar = new []{didprogporzannokind.Columns["iddidprogporzannokind"]};
	cChild = new []{accordoscambiomiporzanno.Columns["iddidprogporzannokind"]};
	Relations.Add(new DataRelation("FK_accordoscambiomiporzanno_didprogporzannokind_iddidprogporzannokind",cPar,cChild,false));

	cPar = new []{torkind.Columns["idtorkind"]};
	cChild = new []{accordoscambiomidett.Columns["idtorkind"]};
	Relations.Add(new DataRelation("FK_accordoscambiomidett_torkind_idtorkind",cPar,cChild,false));

	cPar = new []{registryistitutiesteriview.Columns["idreg"]};
	cChild = new []{accordoscambiomidett.Columns["idreg_istitutiesteri"]};
	Relations.Add(new DataRelation("FK_accordoscambiomidett_registryistitutiesteriview_idreg_istitutiesteri",cPar,cChild,false));

	cPar = new []{isced2013.Columns["idisced2013"]};
	cChild = new []{accordoscambiomidett.Columns["idisced2013"]};
	Relations.Add(new DataRelation("FK_accordoscambiomidett_isced2013_idisced2013",cPar,cChild,false));

	#endregion

}
}
}
