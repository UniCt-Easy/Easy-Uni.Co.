
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
[System.Xml.Serialization.XmlRoot("dsmeta_learningagrstud_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_learningagrstud_seg: DataSet {

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
	public MetaTable cefrlanglevel 		=> (MetaTable)Tables["cefrlanglevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidakind 		=> (MetaTable)Tables["convalidakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryistitutiesteriview 		=> (MetaTable)Tables["registryistitutiesteriview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrkind 		=> (MetaTable)Tables["learningagrkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrstud 		=> (MetaTable)Tables["learningagrstud"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_learningagrstud_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_learningagrstud_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_learningagrstud_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_learningagrstud_seg.xsd";

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
	Tables.Add(tcefrlanglevel);
	tcefrlanglevel.defineKey("idcefrlanglevel");

	//////////////////// CONVALIDATO /////////////////////////////////
	var tconvalidato= new MetaTable("convalidato");
	tconvalidato.defineColumn("changesother", typeof(string));
	tconvalidato.defineColumn("ct", typeof(DateTime),false);
	tconvalidato.defineColumn("cu", typeof(string),false);
	tconvalidato.defineColumn("idattivform", typeof(int),false);
	tconvalidato.defineColumn("idchanges", typeof(int));
	tconvalidato.defineColumn("idchangeskind", typeof(int));
	tconvalidato.defineColumn("idconvalida", typeof(int),false);
	tconvalidato.defineColumn("idconvalidato", typeof(int),false);
	tconvalidato.defineColumn("iddichiar", typeof(int));
	tconvalidato.defineColumn("iddidprog", typeof(int));
	tconvalidato.defineColumn("idiscrizione", typeof(int));
	tconvalidato.defineColumn("idiscrizione_from", typeof(int));
	tconvalidato.defineColumn("idiscrizionebmi", typeof(int));
	tconvalidato.defineColumn("idistanza", typeof(int));
	tconvalidato.defineColumn("idlearningagrstud", typeof(int));
	tconvalidato.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidato.defineColumn("idpratica", typeof(int));
	tconvalidato.defineColumn("idreg", typeof(int),false);
	tconvalidato.defineColumn("lt", typeof(DateTime),false);
	tconvalidato.defineColumn("lu", typeof(string),false);
	Tables.Add(tconvalidato);
	tconvalidato.defineKey("idconvalida", "idconvalidato", "idreg");

	//////////////////// CONVALIDAKIND /////////////////////////////////
	var tconvalidakind= new MetaTable("convalidakind");
	tconvalidakind.defineColumn("idconvalidakind", typeof(int),false);
	tconvalidakind.defineColumn("title", typeof(string),false);
	Tables.Add(tconvalidakind);
	tconvalidakind.defineKey("idconvalidakind");

	//////////////////// CONVALIDA /////////////////////////////////
	var tconvalida= new MetaTable("convalida");
	tconvalida.defineColumn("cf", typeof(decimal));
	tconvalida.defineColumn("cfintegrazione", typeof(decimal));
	tconvalida.defineColumn("ct", typeof(DateTime),false);
	tconvalida.defineColumn("cu", typeof(string),false);
	tconvalida.defineColumn("data", typeof(DateTime));
	tconvalida.defineColumn("idconvalida", typeof(int),false);
	tconvalida.defineColumn("idconvalidakind", typeof(int));
	tconvalida.defineColumn("iddichiar", typeof(int));
	tconvalida.defineColumn("iddidprog", typeof(int));
	tconvalida.defineColumn("idiscrizione", typeof(int));
	tconvalida.defineColumn("idiscrizione_from", typeof(int));
	tconvalida.defineColumn("idiscrizionebmi", typeof(int));
	tconvalida.defineColumn("idistanza", typeof(int));
	tconvalida.defineColumn("idlearningagrstud", typeof(int));
	tconvalida.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalida.defineColumn("idpratica", typeof(int));
	tconvalida.defineColumn("idreg", typeof(int),false);
	tconvalida.defineColumn("lt", typeof(DateTime),false);
	tconvalida.defineColumn("lu", typeof(string),false);
	tconvalida.defineColumn("voto", typeof(decimal));
	tconvalida.defineColumn("votolode", typeof(string));
	tconvalida.defineColumn("votosu", typeof(int));
	tconvalida.defineColumn("!idconvalidakind_convalidakind_title", typeof(string));
	Tables.Add(tconvalida);
	tconvalida.defineKey("idconvalida", "idreg");

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

	//////////////////// LEARNINGAGRKIND /////////////////////////////////
	var tlearningagrkind= new MetaTable("learningagrkind");
	tlearningagrkind.defineColumn("description", typeof(string));
	tlearningagrkind.defineColumn("idlearningagrkind", typeof(int),false);
	tlearningagrkind.defineColumn("title", typeof(string));
	Tables.Add(tlearningagrkind);
	tlearningagrkind.defineKey("idlearningagrkind");

	//////////////////// LEARNINGAGRSTUD /////////////////////////////////
	var tlearningagrstud= new MetaTable("learningagrstud");
	tlearningagrstud.defineColumn("ct", typeof(DateTime),false);
	tlearningagrstud.defineColumn("cu", typeof(string),false);
	tlearningagrstud.defineColumn("idbandomi", typeof(int),false);
	tlearningagrstud.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrkind", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrstud", typeof(int),false);
	tlearningagrstud.defineColumn("idreg", typeof(int),false);
	tlearningagrstud.defineColumn("idreg_istitutiesteri", typeof(int));
	tlearningagrstud.defineColumn("lt", typeof(DateTime),false);
	tlearningagrstud.defineColumn("lu", typeof(string),false);
	tlearningagrstud.defineColumn("note", typeof(string));
	tlearningagrstud.defineColumn("start", typeof(DateTime),false);
	tlearningagrstud.defineColumn("stop", typeof(DateTime),false);
	Tables.Add(tlearningagrstud);
	tlearningagrstud.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrstud", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idlearningagrstud"]};
	var cChild = new []{cefrlanglevel.Columns["idiscrizionebmi"], cefrlanglevel.Columns["idlearningagrstud"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_learningagrstud_idiscrizionebmi-idlearningagrstud",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{cefrlanglevel.Columns["idnation"]};
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

	cPar = new []{learningagrstud.Columns["idiscrizionebmi"], learningagrstud.Columns["idlearningagrstud"], learningagrstud.Columns["idreg"]};
	cChild = new []{convalida.Columns["idiscrizionebmi"], convalida.Columns["idlearningagrstud"], convalida.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalida_learningagrstud_idiscrizionebmi-idlearningagrstud-idreg",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{convalidakind.Columns["idconvalidakind"]};
	cChild = new []{convalida.Columns["idconvalidakind"]};
	Relations.Add(new DataRelation("FK_convalida_convalidakind_idconvalidakind",cPar,cChild,false));

	cPar = new []{registryistitutiesteriview.Columns["idreg"]};
	cChild = new []{learningagrstud.Columns["idreg_istitutiesteri"]};
	Relations.Add(new DataRelation("FK_learningagrstud_registryistitutiesteriview_idreg_istitutiesteri",cPar,cChild,false));

	cPar = new []{learningagrkind.Columns["idlearningagrkind"]};
	cChild = new []{learningagrstud.Columns["idlearningagrkind"]};
	Relations.Add(new DataRelation("FK_learningagrstud_learningagrkind_idlearningagrkind",cPar,cChild,false));

	#endregion

}
}
}
