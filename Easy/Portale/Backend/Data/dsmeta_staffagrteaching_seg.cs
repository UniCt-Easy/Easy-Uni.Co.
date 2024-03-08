
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
[System.Xml.Serialization.XmlRoot("dsmeta_staffagrteaching_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_staffagrteaching_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview_alias1 		=> (MetaTable)Tables["registrydefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable isced2013 		=> (MetaTable)Tables["isced2013"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable staffagrteaching 		=> (MetaTable)Tables["staffagrteaching"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_staffagrteaching_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_staffagrteaching_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_staffagrteaching_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_staffagrteaching_seg.xsd";

	#region create DataTables
	//////////////////// REGISTRYDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tregistrydefaultview_alias1= new MetaTable("registrydefaultview_alias1");
	tregistrydefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview_alias1.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview_alias1.defineColumn("registry_active", typeof(string));
	tregistrydefaultview_alias1.ExtendedProperties["TableForReading"]="registrydefaultview";
	Tables.Add(tregistrydefaultview_alias1);
	tregistrydefaultview_alias1.defineKey("idreg");

	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// REGISTRYDOCENTIVIEW /////////////////////////////////
	var tregistrydocentiview= new MetaTable("registrydocentiview");
	tregistrydocentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydocentiview.defineColumn("idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydocentiview);
	tregistrydocentiview.defineKey("idreg");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// ISCED2013 /////////////////////////////////
	var tisced2013= new MetaTable("isced2013");
	tisced2013.defineColumn("active", typeof(string));
	tisced2013.defineColumn("detailedfield", typeof(string));
	tisced2013.defineColumn("idisced2013", typeof(int),false);
	Tables.Add(tisced2013);
	tisced2013.defineKey("idisced2013");

	//////////////////// STAFFAGRTEACHING /////////////////////////////////
	var tstaffagrteaching= new MetaTable("staffagrteaching");
	tstaffagrteaching.defineColumn("ct", typeof(DateTime),false);
	tstaffagrteaching.defineColumn("cu", typeof(string),false);
	tstaffagrteaching.defineColumn("idbandomi", typeof(int),false);
	tstaffagrteaching.defineColumn("idisced2013", typeof(int),false);
	tstaffagrteaching.defineColumn("idiscrizionebmi", typeof(int),false);
	tstaffagrteaching.defineColumn("idlivelloeqf", typeof(int),false);
	tstaffagrteaching.defineColumn("idnation", typeof(int));
	tstaffagrteaching.defineColumn("idreg", typeof(int),false);
	tstaffagrteaching.defineColumn("idreg_docenti", typeof(int),false);
	tstaffagrteaching.defineColumn("idreg_resp", typeof(int),false);
	tstaffagrteaching.defineColumn("idreg_respestero", typeof(int));
	tstaffagrteaching.defineColumn("idstaffagrteaching", typeof(int),false);
	tstaffagrteaching.defineColumn("lt", typeof(DateTime),false);
	tstaffagrteaching.defineColumn("lu", typeof(string),false);
	tstaffagrteaching.defineColumn("numore", typeof(int));
	tstaffagrteaching.defineColumn("numstud", typeof(int));
	tstaffagrteaching.defineColumn("obiettivi", typeof(string));
	tstaffagrteaching.defineColumn("programma", typeof(string));
	tstaffagrteaching.defineColumn("risultati", typeof(string));
	tstaffagrteaching.defineColumn("valore", typeof(string));
	Tables.Add(tstaffagrteaching);
	tstaffagrteaching.defineKey("idbandomi", "idiscrizionebmi", "idreg", "idstaffagrteaching");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrydefaultview_alias1.Columns["idreg"]};
	var cChild = new []{staffagrteaching.Columns["idreg_respestero"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_registrydefaultview_alias1_idreg_respestero",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{staffagrteaching.Columns["idreg_resp"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_registrydefaultview_idreg_resp",cPar,cChild,false));

	cPar = new []{registrydocentiview.Columns["idreg"]};
	cChild = new []{staffagrteaching.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_registrydocentiview_idreg_docenti",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{staffagrteaching.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{isced2013.Columns["idisced2013"]};
	cChild = new []{staffagrteaching.Columns["idisced2013"]};
	Relations.Add(new DataRelation("FK_staffagrteaching_isced2013_idisced2013",cPar,cChild,false));

	#endregion

}
}
}
