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
[System.Xml.Serialization.XmlRoot("dsmeta_rendicontattivitaprogettowpview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_rendicontattivitaprogettowpview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackagesegview 		=> (MetaTable)Tables["workpackagesegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoanagview 		=> (MetaTable)Tables["rendicontattivitaprogettoanagview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettowpview 		=> (MetaTable)Tables["rendicontattivitaprogettowpview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_rendicontattivitaprogettowpview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_rendicontattivitaprogettowpview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_rendicontattivitaprogettowpview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_rendicontattivitaprogettowpview_default.xsd";

	#region create DataTables
	//////////////////// WORKPACKAGESEGVIEW /////////////////////////////////
	var tworkpackagesegview= new MetaTable("workpackagesegview");
	tworkpackagesegview.defineColumn("dropdown_title", typeof(string),false);
	tworkpackagesegview.defineColumn("idprogetto", typeof(int),false);
	tworkpackagesegview.defineColumn("idworkpackage", typeof(int),false);
	tworkpackagesegview.defineColumn("raggruppamento", typeof(string));
	tworkpackagesegview.defineColumn("struttura_idstrutturakind", typeof(int));
	tworkpackagesegview.defineColumn("struttura_title", typeof(string));
	tworkpackagesegview.defineColumn("strutturakind_title", typeof(string));
	tworkpackagesegview.defineColumn("workpackage_acronimo", typeof(string));
	tworkpackagesegview.defineColumn("workpackage_ct", typeof(DateTime),false);
	tworkpackagesegview.defineColumn("workpackage_cu", typeof(string),false);
	tworkpackagesegview.defineColumn("workpackage_description", typeof(string));
	tworkpackagesegview.defineColumn("workpackage_idstruttura", typeof(int));
	tworkpackagesegview.defineColumn("workpackage_lt", typeof(DateTime),false);
	tworkpackagesegview.defineColumn("workpackage_lu", typeof(string),false);
	tworkpackagesegview.defineColumn("workpackage_start", typeof(DateTime));
	tworkpackagesegview.defineColumn("workpackage_stop", typeof(DateTime));
	tworkpackagesegview.defineColumn("workpackage_title", typeof(string));
	Tables.Add(tworkpackagesegview);
	tworkpackagesegview.defineKey("idprogetto", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOANAGVIEW /////////////////////////////////
	var trendicontattivitaprogettoanagview= new MetaTable("rendicontattivitaprogettoanagview");
	trendicontattivitaprogettoanagview.defineColumn("dropdown_title", typeof(string),false);
	trendicontattivitaprogettoanagview.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoanagview.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettoanagview.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoanagview.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoanagview.defineColumn("progetto_start", typeof(DateTime));
	trendicontattivitaprogettoanagview.defineColumn("progetto_stop", typeof(DateTime));
	trendicontattivitaprogettoanagview.defineColumn("progetto_titolobreve", typeof(string));
	trendicontattivitaprogettoanagview.defineColumn("rendicontattivitaprogetto_ct", typeof(DateTime),false);
	trendicontattivitaprogettoanagview.defineColumn("rendicontattivitaprogetto_cu", typeof(string),false);
	trendicontattivitaprogettoanagview.defineColumn("rendicontattivitaprogetto_datainizioprevista", typeof(DateTime));
	trendicontattivitaprogettoanagview.defineColumn("rendicontattivitaprogetto_description", typeof(string));
	trendicontattivitaprogettoanagview.defineColumn("rendicontattivitaprogetto_idrendicontattivitaprogettokind", typeof(int));
	trendicontattivitaprogettoanagview.defineColumn("rendicontattivitaprogetto_lt", typeof(DateTime),false);
	trendicontattivitaprogettoanagview.defineColumn("rendicontattivitaprogetto_lu", typeof(string),false);
	trendicontattivitaprogettoanagview.defineColumn("rendicontattivitaprogetto_orepreventivate", typeof(int));
	trendicontattivitaprogettoanagview.defineColumn("rendicontattivitaprogetto_stop", typeof(DateTime));
	trendicontattivitaprogettoanagview.defineColumn("rendicontattivitaprogettokind_title", typeof(string));
	trendicontattivitaprogettoanagview.defineColumn("workpackage_raggruppamento", typeof(string));
	trendicontattivitaprogettoanagview.defineColumn("workpackage_start", typeof(DateTime));
	trendicontattivitaprogettoanagview.defineColumn("workpackage_stop", typeof(DateTime));
	trendicontattivitaprogettoanagview.defineColumn("workpackage_title", typeof(string));
	Tables.Add(trendicontattivitaprogettoanagview);
	trendicontattivitaprogettoanagview.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

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

	//////////////////// RENDICONTATTIVITAPROGETTOWPVIEW /////////////////////////////////
	var trendicontattivitaprogettowpview= new MetaTable("rendicontattivitaprogettowpview");
	trendicontattivitaprogettowpview.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettowpview.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettowpview.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettowpview.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettowpview.defineColumn("oreanno", typeof(int));
	trendicontattivitaprogettowpview.defineColumn("oreattivita", typeof(int));
	trendicontattivitaprogettowpview.defineColumn("oremaxanno", typeof(int),false);
	trendicontattivitaprogettowpview.defineColumn("residuoanno", typeof(int));
	trendicontattivitaprogettowpview.defineColumn("stipendioannuo", typeof(decimal));
	trendicontattivitaprogettowpview.defineColumn("stipendiorendicontato", typeof(decimal));
	trendicontattivitaprogettowpview.defineColumn("stipendioresiduo", typeof(decimal));
	trendicontattivitaprogettowpview.defineColumn("year", typeof(int),false);
	Tables.Add(trendicontattivitaprogettowpview);
	trendicontattivitaprogettowpview.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idworkpackage", "oremaxanno", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{workpackagesegview.Columns["idworkpackage"]};
	var cChild = new []{rendicontattivitaprogettowpview.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettowpview_workpackagesegview_idworkpackage",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogettoanagview.Columns["idrendicontattivitaprogetto"]};
	cChild = new []{rendicontattivitaprogettowpview.Columns["idrendicontattivitaprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettowpview_rendicontattivitaprogettoanagview_idrendicontattivitaprogetto",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{rendicontattivitaprogettowpview.Columns["year"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettowpview_year_year",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogettowpview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettowpview_registrydefaultview_idreg",cPar,cChild,false));

	#endregion

}
}
}
