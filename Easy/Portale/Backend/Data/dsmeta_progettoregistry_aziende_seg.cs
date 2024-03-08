
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoregistry_aziende_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettoregistry_aziende_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable partnerkinddefaultview 		=> (MetaTable)Tables["partnerkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaziendeview 		=> (MetaTable)Tables["registryaziendeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoregistry_aziende 		=> (MetaTable)Tables["progettoregistry_aziende"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoregistry_aziende_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoregistry_aziende_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoregistry_aziende_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoregistry_aziende_seg.xsd";

	#region create DataTables
	//////////////////// PARTNERKINDDEFAULTVIEW /////////////////////////////////
	var tpartnerkinddefaultview= new MetaTable("partnerkinddefaultview");
	tpartnerkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpartnerkinddefaultview.defineColumn("idpartnerkind", typeof(int),false);
	tpartnerkinddefaultview.defineColumn("partnerkind_active", typeof(string));
	tpartnerkinddefaultview.defineColumn("partnerkind_description", typeof(string));
	tpartnerkinddefaultview.defineColumn("partnerkind_sortcode", typeof(int));
	tpartnerkinddefaultview.defineColumn("title", typeof(string));
	Tables.Add(tpartnerkinddefaultview);
	tpartnerkinddefaultview.defineKey("idpartnerkind");

	//////////////////// REGISTRYAZIENDEVIEW /////////////////////////////////
	var tregistryaziendeview= new MetaTable("registryaziendeview");
	tregistryaziendeview.defineColumn("accmotive_codemotive", typeof(string));
	tregistryaziendeview.defineColumn("accmotive_registry_codemotive", typeof(string));
	tregistryaziendeview.defineColumn("accmotive_registry_title", typeof(string));
	tregistryaziendeview.defineColumn("accmotive_title", typeof(string));
	tregistryaziendeview.defineColumn("ateco_codice", typeof(string));
	tregistryaziendeview.defineColumn("ateco_title", typeof(string));
	tregistryaziendeview.defineColumn("category_description", typeof(string));
	tregistryaziendeview.defineColumn("dropdown_title", typeof(string),false);
	tregistryaziendeview.defineColumn("geo_city_title", typeof(string));
	tregistryaziendeview.defineColumn("geo_nation_title", typeof(string));
	tregistryaziendeview.defineColumn("idaccmotivecredit", typeof(string));
	tregistryaziendeview.defineColumn("idaccmotivedebit", typeof(string));
	tregistryaziendeview.defineColumn("idateco", typeof(int));
	tregistryaziendeview.defineColumn("idcategory", typeof(string));
	tregistryaziendeview.defineColumn("idcity", typeof(int));
	tregistryaziendeview.defineColumn("idnace", typeof(string));
	tregistryaziendeview.defineColumn("idnation", typeof(int));
	tregistryaziendeview.defineColumn("idnaturagiur", typeof(int));
	tregistryaziendeview.defineColumn("idreg", typeof(int),false);
	tregistryaziendeview.defineColumn("nace_activity", typeof(string));
	tregistryaziendeview.defineColumn("nace_idnace", typeof(string));
	tregistryaziendeview.defineColumn("naturagiur_title", typeof(string));
	tregistryaziendeview.defineColumn("numerodip_title", typeof(string));
	tregistryaziendeview.defineColumn("registry_active", typeof(string));
	tregistryaziendeview.defineColumn("registry_annotation", typeof(string));
	tregistryaziendeview.defineColumn("registry_authorization_free", typeof(string));
	tregistryaziendeview.defineColumn("registry_badgecode", typeof(string));
	tregistryaziendeview.defineColumn("registry_birthdate", typeof(DateTime));
	tregistryaziendeview.defineColumn("registry_ccp", typeof(string));
	tregistryaziendeview.defineColumn("registry_cf", typeof(string));
	tregistryaziendeview.defineColumn("registry_ct", typeof(DateTime),false);
	tregistryaziendeview.defineColumn("registry_cu", typeof(string),false);
	tregistryaziendeview.defineColumn("registry_email_fe", typeof(string));
	tregistryaziendeview.defineColumn("registry_extension", typeof(string));
	tregistryaziendeview.defineColumn("registry_extmatricula", typeof(string));
	tregistryaziendeview.defineColumn("registry_flag_pa", typeof(string));
	tregistryaziendeview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistryaziendeview.defineColumn("registry_foreigncf", typeof(string));
	tregistryaziendeview.defineColumn("registry_forename", typeof(string));
	tregistryaziendeview.defineColumn("registry_gender", typeof(string));
	tregistryaziendeview.defineColumn("registry_idcentralizedcategory", typeof(string));
	tregistryaziendeview.defineColumn("registry_idclassconsorsuale", typeof(int));
	tregistryaziendeview.defineColumn("registry_idexternal", typeof(int));
	tregistryaziendeview.defineColumn("registry_idfonteindicebibliometrico", typeof(int));
	tregistryaziendeview.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistryaziendeview.defineColumn("registry_idnumerodip", typeof(int));
	tregistryaziendeview.defineColumn("registry_idreg_istituti", typeof(int));
	tregistryaziendeview.defineColumn("registry_idregistryclass", typeof(string));
	tregistryaziendeview.defineColumn("registry_idregistrykind", typeof(int));
	tregistryaziendeview.defineColumn("registry_idsasd", typeof(int));
	tregistryaziendeview.defineColumn("registry_idstruttura", typeof(int));
	tregistryaziendeview.defineColumn("registry_idtitle", typeof(string));
	tregistryaziendeview.defineColumn("registry_indicebibliometrico", typeof(int));
	tregistryaziendeview.defineColumn("registry_ipa_fe", typeof(string));
	tregistryaziendeview.defineColumn("registry_ipa_perlapa", typeof(string));
	tregistryaziendeview.defineColumn("registry_location", typeof(string));
	tregistryaziendeview.defineColumn("registry_lt", typeof(DateTime),false);
	tregistryaziendeview.defineColumn("registry_lu", typeof(string),false);
	tregistryaziendeview.defineColumn("registry_maritalsurname", typeof(string));
	tregistryaziendeview.defineColumn("registry_multi_cf", typeof(string));
	tregistryaziendeview.defineColumn("registry_p_iva", typeof(string));
	tregistryaziendeview.defineColumn("registry_pec_fe", typeof(string));
	tregistryaziendeview.defineColumn("registry_pic", typeof(string));
	tregistryaziendeview.defineColumn("registry_residence", typeof(int),false);
	tregistryaziendeview.defineColumn("registry_ricevimento", typeof(string));
	tregistryaziendeview.defineColumn("registry_rtf", typeof(Byte[]));
	tregistryaziendeview.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistryaziendeview.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistryaziendeview.defineColumn("registry_soggiorno", typeof(string));
	tregistryaziendeview.defineColumn("registry_surname", typeof(string));
	tregistryaziendeview.defineColumn("registry_title_en", typeof(string));
	tregistryaziendeview.defineColumn("registry_toredirect", typeof(int));
	tregistryaziendeview.defineColumn("registry_txt", typeof(string));
	tregistryaziendeview.defineColumn("registryclass_description", typeof(string));
	tregistryaziendeview.defineColumn("registrykind_description", typeof(string));
	tregistryaziendeview.defineColumn("residence_description", typeof(string));
	tregistryaziendeview.defineColumn("title", typeof(string),false);
	Tables.Add(tregistryaziendeview);
	tregistryaziendeview.defineKey("idreg");

	//////////////////// PROGETTOREGISTRY_AZIENDE /////////////////////////////////
	var tprogettoregistry_aziende= new MetaTable("progettoregistry_aziende");
	tprogettoregistry_aziende.defineColumn("ct", typeof(DateTime),false);
	tprogettoregistry_aziende.defineColumn("cu", typeof(string),false);
	tprogettoregistry_aziende.defineColumn("idpartnerkind", typeof(int));
	tprogettoregistry_aziende.defineColumn("idprogetto", typeof(int),false);
	tprogettoregistry_aziende.defineColumn("idreg_aziende", typeof(int),false);
	tprogettoregistry_aziende.defineColumn("lt", typeof(DateTime),false);
	tprogettoregistry_aziende.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoregistry_aziende);
	tprogettoregistry_aziende.defineKey("idprogetto", "idreg_aziende");

	#endregion


	#region DataRelation creation
	var cPar = new []{partnerkinddefaultview.Columns["idpartnerkind"]};
	var cChild = new []{progettoregistry_aziende.Columns["idpartnerkind"]};
	Relations.Add(new DataRelation("FK_progettoregistry_aziende_partnerkinddefaultview_idpartnerkind",cPar,cChild,false));

	cPar = new []{registryaziendeview.Columns["idreg"]};
	cChild = new []{progettoregistry_aziende.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_progettoregistry_aziende_registryaziendeview_idreg_aziende",cPar,cChild,false));

	#endregion

}
}
}
