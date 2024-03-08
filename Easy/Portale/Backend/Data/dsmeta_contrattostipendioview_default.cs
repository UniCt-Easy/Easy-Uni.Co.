
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
[System.Xml.Serialization.XmlRoot("dsmeta_contrattostipendioview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_contrattostipendioview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese 		=> (MetaTable)Tables["mese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendio 		=> (MetaTable)Tables["stipendio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramentodefaultview 		=> (MetaTable)Tables["inquadramentodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable positiondefaultview 		=> (MetaTable)Tables["positiondefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatusdefaultview 		=> (MetaTable)Tables["registrylegalstatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattostipendioview 		=> (MetaTable)Tables["contrattostipendioview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_contrattostipendioview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_contrattostipendioview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_contrattostipendioview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_contrattostipendioview_default.xsd";

	#region create DataTables
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

	//////////////////// MESE /////////////////////////////////
	var tmese= new MetaTable("mese");
	tmese.defineColumn("idmese", typeof(int),false);
	tmese.defineColumn("title", typeof(string));
	Tables.Add(tmese);
	tmese.defineKey("idmese");

	//////////////////// STIPENDIO /////////////////////////////////
	var tstipendio= new MetaTable("stipendio");
	tstipendio.defineColumn("!previdenza", typeof(decimal));
	tstipendio.defineColumn("!tesoro", typeof(decimal));
	tstipendio.defineColumn("!totalece", typeof(decimal));
	tstipendio.defineColumn("!tredicesima", typeof(decimal));
	tstipendio.defineColumn("anzianitamax", typeof(int));
	tstipendio.defineColumn("anzianitamin", typeof(int));
	tstipendio.defineColumn("assegno", typeof(decimal));
	tstipendio.defineColumn("classe", typeof(int));
	tstipendio.defineColumn("ct", typeof(DateTime));
	tstipendio.defineColumn("cu", typeof(string));
	tstipendio.defineColumn("idinquadramento", typeof(int),false);
	tstipendio.defineColumn("idposition", typeof(int),false);
	tstipendio.defineColumn("idstipendio", typeof(int),false);
	tstipendio.defineColumn("iis", typeof(decimal));
	tstipendio.defineColumn("irap", typeof(decimal));
	tstipendio.defineColumn("lordo", typeof(decimal));
	tstipendio.defineColumn("lordonotredicesima", typeof(decimal));
	tstipendio.defineColumn("lt", typeof(DateTime));
	tstipendio.defineColumn("lu", typeof(string));
	tstipendio.defineColumn("rifnormativo", typeof(string));
	tstipendio.defineColumn("scatto", typeof(int));
	tstipendio.defineColumn("siglaimportazione", typeof(string));
	tstipendio.defineColumn("start", typeof(DateTime));
	tstipendio.defineColumn("stipendio", typeof(decimal));
	tstipendio.defineColumn("stop", typeof(DateTime));
	tstipendio.defineColumn("totale", typeof(decimal));
	Tables.Add(tstipendio);
	tstipendio.defineKey("idinquadramento", "idposition", "idstipendio");

	//////////////////// INQUADRAMENTODEFAULTVIEW /////////////////////////////////
	var tinquadramentodefaultview= new MetaTable("inquadramentodefaultview");
	tinquadramentodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinquadramentodefaultview.defineColumn("idinquadramento", typeof(int),false);
	tinquadramentodefaultview.defineColumn("idposition", typeof(int),false);
	tinquadramentodefaultview.defineColumn("inquadramento_costolordoannuo", typeof(decimal));
	tinquadramentodefaultview.defineColumn("inquadramento_costolordoannuooneri", typeof(decimal));
	tinquadramentodefaultview.defineColumn("inquadramento_ct", typeof(DateTime),false);
	tinquadramentodefaultview.defineColumn("inquadramento_cu", typeof(string),false);
	tinquadramentodefaultview.defineColumn("inquadramento_lt", typeof(DateTime),false);
	tinquadramentodefaultview.defineColumn("inquadramento_lu", typeof(string),false);
	tinquadramentodefaultview.defineColumn("inquadramento_siglaimportazione", typeof(string));
	tinquadramentodefaultview.defineColumn("inquadramento_start", typeof(DateTime));
	tinquadramentodefaultview.defineColumn("inquadramento_stop", typeof(DateTime));
	tinquadramentodefaultview.defineColumn("inquadramento_tempdef", typeof(string));
	tinquadramentodefaultview.defineColumn("title", typeof(string));
	Tables.Add(tinquadramentodefaultview);
	tinquadramentodefaultview.defineKey("idinquadramento", "idposition");

	//////////////////// POSITIONDEFAULTVIEW /////////////////////////////////
	var tpositiondefaultview= new MetaTable("positiondefaultview");
	tpositiondefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpositiondefaultview.defineColumn("idposition", typeof(int),false);
	tpositiondefaultview.defineColumn("position_active", typeof(string));
	tpositiondefaultview.defineColumn("position_assegnoaggiuntivo", typeof(string));
	tpositiondefaultview.defineColumn("position_codeposition", typeof(string),false);
	tpositiondefaultview.defineColumn("position_costolordoannuo", typeof(decimal));
	tpositiondefaultview.defineColumn("position_costolordoannuooneri", typeof(decimal));
	tpositiondefaultview.defineColumn("position_ct", typeof(DateTime),false);
	tpositiondefaultview.defineColumn("position_cu", typeof(string),false);
	tpositiondefaultview.defineColumn("position_description", typeof(string),false);
	tpositiondefaultview.defineColumn("position_elementoperequativo", typeof(string));
	tpositiondefaultview.defineColumn("position_foreignclass", typeof(string));
	tpositiondefaultview.defineColumn("position_indennitadiateneo", typeof(string));
	tpositiondefaultview.defineColumn("position_indennitadiposizione", typeof(string));
	tpositiondefaultview.defineColumn("position_indvacancacontrattuale", typeof(string));
	tpositiondefaultview.defineColumn("position_livello", typeof(string));
	tpositiondefaultview.defineColumn("position_lt", typeof(DateTime),false);
	tpositiondefaultview.defineColumn("position_lu", typeof(string),false);
	tpositiondefaultview.defineColumn("position_maxincomeclass", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxcompitididatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxcompitididatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxdidatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxdidatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxgg", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxtempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxtempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremincompitididatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremincompitididatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremindidatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremindidatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremintempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremintempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_orestraordinariemax", typeof(int));
	tpositiondefaultview.defineColumn("position_parttime", typeof(string));
	tpositiondefaultview.defineColumn("position_printingorder", typeof(int));
	tpositiondefaultview.defineColumn("position_puntiorganico", typeof(decimal));
	tpositiondefaultview.defineColumn("position_siglaesportazione", typeof(string));
	tpositiondefaultview.defineColumn("position_siglaimportazione", typeof(string));
	tpositiondefaultview.defineColumn("position_tempdef", typeof(string));
	tpositiondefaultview.defineColumn("position_tipoente", typeof(string));
	tpositiondefaultview.defineColumn("position_tipopersonale", typeof(string));
	tpositiondefaultview.defineColumn("position_totaletredicesima", typeof(string));
	tpositiondefaultview.defineColumn("position_tredicesimaindennitaintegrativaspeciale", typeof(string));
	tpositiondefaultview.defineColumn("title", typeof(string));
	Tables.Add(tpositiondefaultview);
	tpositiondefaultview.defineKey("idposition");

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

	//////////////////// CONTRATTOSTIPENDIOVIEW /////////////////////////////////
	var tcontrattostipendioview= new MetaTable("contrattostipendioview");
	tcontrattostipendioview.defineColumn("anno", typeof(int),false);
	tcontrattostipendioview.defineColumn("assegno", typeof(decimal));
	tcontrattostipendioview.defineColumn("caricoente", typeof(decimal));
	tcontrattostipendioview.defineColumn("classe", typeof(int));
	tcontrattostipendioview.defineColumn("ct", typeof(DateTime));
	tcontrattostipendioview.defineColumn("cu", typeof(string));
	tcontrattostipendioview.defineColumn("idinquadramento", typeof(int),false);
	tcontrattostipendioview.defineColumn("idmese", typeof(int),false);
	tcontrattostipendioview.defineColumn("idposition", typeof(int),false);
	tcontrattostipendioview.defineColumn("idreg", typeof(int),false);
	tcontrattostipendioview.defineColumn("idregistrylegalstatus", typeof(int),false);
	tcontrattostipendioview.defineColumn("idstipendio", typeof(int),false);
	tcontrattostipendioview.defineColumn("iis", typeof(decimal));
	tcontrattostipendioview.defineColumn("irap", typeof(decimal));
	tcontrattostipendioview.defineColumn("lordo", typeof(decimal));
	tcontrattostipendioview.defineColumn("lt", typeof(DateTime));
	tcontrattostipendioview.defineColumn("lu", typeof(string));
	tcontrattostipendioview.defineColumn("mese", typeof(string),false);
	tcontrattostipendioview.defineColumn("mesilavorati", typeof(int));
	tcontrattostipendioview.defineColumn("rifnormativo", typeof(string));
	tcontrattostipendioview.defineColumn("scatto", typeof(int));
	tcontrattostipendioview.defineColumn("siglaimportazione", typeof(string));
	tcontrattostipendioview.defineColumn("start", typeof(DateTime),false);
	tcontrattostipendioview.defineColumn("stipendio", typeof(decimal));
	tcontrattostipendioview.defineColumn("stop", typeof(DateTime));
	tcontrattostipendioview.defineColumn("totale", typeof(decimal));
	tcontrattostipendioview.defineColumn("totaleanno", typeof(decimal));
	tcontrattostipendioview.defineColumn("totaletfr", typeof(decimal));
	tcontrattostipendioview.defineColumn("tredicesima", typeof(decimal),false);
	tcontrattostipendioview.defineColumn("validfortredicesima", typeof(string),false);
	Tables.Add(tcontrattostipendioview);
	tcontrattostipendioview.defineKey("anno", "idreg", "idregistrylegalstatus", "idstipendio", "mese");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrydefaultview.Columns["idreg"]};
	var cChild = new []{contrattostipendioview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_contrattostipendioview_registrydefaultview_idreg",cPar,cChild,false));

	cPar = new []{mese.Columns["idmese"]};
	cChild = new []{contrattostipendioview.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_contrattostipendioview_mese_idmese",cPar,cChild,false));

	cPar = new []{stipendio.Columns["idstipendio"]};
	cChild = new []{contrattostipendioview.Columns["idstipendio"]};
	Relations.Add(new DataRelation("FK_contrattostipendioview_stipendio_idstipendio",cPar,cChild,false));

	cPar = new []{inquadramentodefaultview.Columns["idinquadramento"]};
	cChild = new []{contrattostipendioview.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_contrattostipendioview_inquadramentodefaultview_idinquadramento",cPar,cChild,false));

	cPar = new []{positiondefaultview.Columns["idposition"]};
	cChild = new []{contrattostipendioview.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_contrattostipendioview_positiondefaultview_idposition",cPar,cChild,false));

	cPar = new []{registrylegalstatusdefaultview.Columns["idregistrylegalstatus"]};
	cChild = new []{contrattostipendioview.Columns["idregistrylegalstatus"]};
	Relations.Add(new DataRelation("FK_contrattostipendioview_registrylegalstatusdefaultview_idregistrylegalstatus",cPar,cChild,false));

	#endregion

}
}
}
