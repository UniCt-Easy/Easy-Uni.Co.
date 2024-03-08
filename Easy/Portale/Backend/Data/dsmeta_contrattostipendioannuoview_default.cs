
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
[System.Xml.Serialization.XmlRoot("dsmeta_contrattostipendioannuoview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_contrattostipendioannuoview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendioannuodefaultview 		=> (MetaTable)Tables["stipendioannuodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatusdefaultview 		=> (MetaTable)Tables["registrylegalstatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattostipendioannuoview 		=> (MetaTable)Tables["contrattostipendioannuoview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_contrattostipendioannuoview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_contrattostipendioannuoview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_contrattostipendioannuoview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_contrattostipendioannuoview_default.xsd";

	#region create DataTables
	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// STIPENDIOANNUODEFAULTVIEW /////////////////////////////////
	var tstipendioannuodefaultview= new MetaTable("stipendioannuodefaultview");
	tstipendioannuodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstipendioannuodefaultview.defineColumn("idreg", typeof(int),false);
	tstipendioannuodefaultview.defineColumn("idregistrylegalstatus", typeof(int),false);
	tstipendioannuodefaultview.defineColumn("idstipendioannuo", typeof(int),false);
	tstipendioannuodefaultview.defineColumn("stipendioannuo_caricoente", typeof(decimal));
	tstipendioannuodefaultview.defineColumn("stipendioannuo_ct", typeof(DateTime),false);
	tstipendioannuodefaultview.defineColumn("stipendioannuo_cu", typeof(string),false);
	tstipendioannuodefaultview.defineColumn("stipendioannuo_irap", typeof(decimal));
	tstipendioannuodefaultview.defineColumn("stipendioannuo_lordo", typeof(decimal));
	tstipendioannuodefaultview.defineColumn("stipendioannuo_lt", typeof(DateTime),false);
	tstipendioannuodefaultview.defineColumn("stipendioannuo_lu", typeof(string),false);
	tstipendioannuodefaultview.defineColumn("stipendioannuo_totale", typeof(decimal));
	tstipendioannuodefaultview.defineColumn("year", typeof(int),false);
	Tables.Add(tstipendioannuodefaultview);
	tstipendioannuodefaultview.defineKey("idreg", "idregistrylegalstatus", "idstipendioannuo", "year");

	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("accmotive_codemotive", typeof(string));
	tregistrydefaultview.defineColumn("accmotive_registry_codemotive", typeof(string));
	tregistrydefaultview.defineColumn("accmotive_registry_title", typeof(string));
	tregistrydefaultview.defineColumn("accmotive_title", typeof(string));
	tregistrydefaultview.defineColumn("category_description", typeof(string));
	tregistrydefaultview.defineColumn("centralizedcategory_description", typeof(string));
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("geo_city_title", typeof(string));
	tregistrydefaultview.defineColumn("geo_nation_title", typeof(string));
	tregistrydefaultview.defineColumn("idaccmotivecredit", typeof(string));
	tregistrydefaultview.defineColumn("idaccmotivedebit", typeof(string));
	tregistrydefaultview.defineColumn("idcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcity", typeof(int));
	tregistrydefaultview.defineColumn("idnation", typeof(int));
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("idregistryclass", typeof(string));
	tregistrydefaultview.defineColumn("idtitle", typeof(string));
	tregistrydefaultview.defineColumn("maritalstatus_description", typeof(string));
	tregistrydefaultview.defineColumn("registry_active", typeof(string));
	tregistrydefaultview.defineColumn("registry_annotation", typeof(string));
	tregistrydefaultview.defineColumn("registry_authorization_free", typeof(string));
	tregistrydefaultview.defineColumn("registry_badgecode", typeof(string));
	tregistrydefaultview.defineColumn("registry_birthdate", typeof(DateTime));
	tregistrydefaultview.defineColumn("registry_ccp", typeof(string));
	tregistrydefaultview.defineColumn("registry_cf", typeof(string));
	tregistrydefaultview.defineColumn("registry_ct", typeof(DateTime),false);
	tregistrydefaultview.defineColumn("registry_cu", typeof(string),false);
	tregistrydefaultview.defineColumn("registry_email_fe", typeof(string));
	tregistrydefaultview.defineColumn("registry_extension", typeof(string));
	tregistrydefaultview.defineColumn("registry_extmatricula", typeof(string));
	tregistrydefaultview.defineColumn("registry_flag_pa", typeof(string));
	tregistrydefaultview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistrydefaultview.defineColumn("registry_foreigncf", typeof(string));
	tregistrydefaultview.defineColumn("registry_forename", typeof(string));
	tregistrydefaultview.defineColumn("registry_gender", typeof(string));
	tregistrydefaultview.defineColumn("registry_idexternal", typeof(int));
	tregistrydefaultview.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistrydefaultview.defineColumn("registry_idregistrykind", typeof(int));
	tregistrydefaultview.defineColumn("registry_ipa_fe", typeof(string));
	tregistrydefaultview.defineColumn("registry_ipa_perlapa", typeof(string));
	tregistrydefaultview.defineColumn("registry_location", typeof(string));
	tregistrydefaultview.defineColumn("registry_lt", typeof(DateTime),false);
	tregistrydefaultview.defineColumn("registry_lu", typeof(string),false);
	tregistrydefaultview.defineColumn("registry_maritalsurname", typeof(string));
	tregistrydefaultview.defineColumn("registry_multi_cf", typeof(string));
	tregistrydefaultview.defineColumn("registry_p_iva", typeof(string));
	tregistrydefaultview.defineColumn("registry_pec_fe", typeof(string));
	tregistrydefaultview.defineColumn("registry_rtf", typeof(Byte[]));
	tregistrydefaultview.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistrydefaultview.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistrydefaultview.defineColumn("registry_surname", typeof(string));
	tregistrydefaultview.defineColumn("registry_toredirect", typeof(int));
	tregistrydefaultview.defineColumn("registry_txt", typeof(string));
	tregistrydefaultview.defineColumn("registryclass_description", typeof(string));
	tregistrydefaultview.defineColumn("registrykind_description", typeof(string));
	tregistrydefaultview.defineColumn("residence", typeof(int),false);
	tregistrydefaultview.defineColumn("residence_description", typeof(string));
	tregistrydefaultview.defineColumn("title", typeof(string),false);
	tregistrydefaultview.defineColumn("title_description", typeof(string));
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// REGISTRYLEGALSTATUSDEFAULTVIEW /////////////////////////////////
	var tregistrylegalstatusdefaultview= new MetaTable("registrylegalstatusdefaultview");
	tregistrylegalstatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrylegalstatusdefaultview.defineColumn("idposition", typeof(int));
	tregistrylegalstatusdefaultview.defineColumn("idreg", typeof(int),false);
	tregistrylegalstatusdefaultview.defineColumn("idregistrylegalstatus", typeof(int),false);
	tregistrylegalstatusdefaultview.defineColumn("inquadramento_tempdef", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("inquadramento_title", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("position_title", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_active", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_csa_class", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_csa_compartment", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_csa_role", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_ct", typeof(DateTime));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_cu", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_datarivalutazione", typeof(DateTime));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_iddaliaposition", typeof(int));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_idinquadramento", typeof(int));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_incomeclass", typeof(int));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_incomeclassvalidity", typeof(DateTime));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_livello", typeof(int));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_lt", typeof(DateTime));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_lu", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_parttime", typeof(decimal));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_percentualesufondiateneo", typeof(decimal));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_rtf", typeof(Byte[]));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_start", typeof(DateTime),false);
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_stop", typeof(DateTime));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_tempdef", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_tempindet", typeof(string));
	tregistrylegalstatusdefaultview.defineColumn("registrylegalstatus_txt", typeof(string));
	Tables.Add(tregistrylegalstatusdefaultview);
	tregistrylegalstatusdefaultview.defineKey("idreg", "idregistrylegalstatus");

	//////////////////// CONTRATTOSTIPENDIOANNUOVIEW /////////////////////////////////
	var tcontrattostipendioannuoview= new MetaTable("contrattostipendioannuoview");
	tcontrattostipendioannuoview.defineColumn("caricoente", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("ct", typeof(DateTime));
	tcontrattostipendioannuoview.defineColumn("cu", typeof(string));
	tcontrattostipendioannuoview.defineColumn("idreg", typeof(int),false);
	tcontrattostipendioannuoview.defineColumn("idregistrylegalstatus", typeof(int));
	tcontrattostipendioannuoview.defineColumn("idstipendioannuo", typeof(int));
	tcontrattostipendioannuoview.defineColumn("irap", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("lordo", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("lt", typeof(DateTime));
	tcontrattostipendioannuoview.defineColumn("lu", typeof(string));
	tcontrattostipendioannuoview.defineColumn("totale", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("tredicesima", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("year", typeof(int),false);
	Tables.Add(tcontrattostipendioannuoview);
	tcontrattostipendioannuoview.defineKey("idreg", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{year.Columns["year"]};
	var cChild = new []{contrattostipendioannuoview.Columns["year"]};
	Relations.Add(new DataRelation("FK_contrattostipendioannuoview_year_year",cPar,cChild,false));

	cPar = new []{stipendioannuodefaultview.Columns["idstipendioannuo"]};
	cChild = new []{contrattostipendioannuoview.Columns["idstipendioannuo"]};
	Relations.Add(new DataRelation("FK_contrattostipendioannuoview_stipendioannuodefaultview_idstipendioannuo",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{contrattostipendioannuoview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_contrattostipendioannuoview_registrydefaultview_idreg",cPar,cChild,false));

	cPar = new []{registrylegalstatusdefaultview.Columns["idregistrylegalstatus"]};
	cChild = new []{contrattostipendioannuoview.Columns["idregistrylegalstatus"]};
	Relations.Add(new DataRelation("FK_contrattostipendioannuoview_registrylegalstatusdefaultview_idregistrylegalstatus",cPar,cChild,false));

	#endregion

}
}
}
