
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
[System.Xml.Serialization.XmlRoot("dsmeta_rendicontattivitaprogettourdmemboview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_rendicontattivitaprogettourdmemboview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoudrmembrosegview 		=> (MetaTable)Tables["progettoudrmembrosegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoudr 		=> (MetaTable)Tables["progettoudr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto 		=> (MetaTable)Tables["progetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettourdmemboview 		=> (MetaTable)Tables["rendicontattivitaprogettourdmemboview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_rendicontattivitaprogettourdmemboview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_rendicontattivitaprogettourdmemboview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_rendicontattivitaprogettourdmemboview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_rendicontattivitaprogettourdmemboview_default.xsd";

	#region create DataTables
	//////////////////// PROGETTOUDRMEMBROSEGVIEW /////////////////////////////////
	var tprogettoudrmembrosegview= new MetaTable("progettoudrmembrosegview");
	tprogettoudrmembrosegview.defineColumn("dropdown_title", typeof(string),false);
	tprogettoudrmembrosegview.defineColumn("idprogetto", typeof(int),false);
	tprogettoudrmembrosegview.defineColumn("idprogettoudr", typeof(int),false);
	tprogettoudrmembrosegview.defineColumn("idprogettoudrmembro", typeof(int),false);
	tprogettoudrmembrosegview.defineColumn("idreg", typeof(int));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_costoorario", typeof(decimal));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_ct", typeof(DateTime));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_cu", typeof(string));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_fondiprogetto", typeof(string));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_giornipreventivati", typeof(int));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_idprogettoudrmembrokind", typeof(int));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_impegno", typeof(decimal));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_lt", typeof(DateTime));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_lu", typeof(string));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_orepreventivate", typeof(int));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_ricavoorario", typeof(decimal));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_start", typeof(DateTime));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembro_stop", typeof(DateTime));
	tprogettoudrmembrosegview.defineColumn("progettoudrmembrokind_title", typeof(string));
	tprogettoudrmembrosegview.defineColumn("registry_title", typeof(string));
	Tables.Add(tprogettoudrmembrosegview);
	tprogettoudrmembrosegview.defineKey("idprogetto", "idprogettoudr", "idprogettoudrmembro");

	//////////////////// PROGETTOUDR /////////////////////////////////
	var tprogettoudr= new MetaTable("progettoudr");
	tprogettoudr.defineColumn("!budgetore", typeof(decimal));
	tprogettoudr.defineColumn("assegniricerca", typeof(int));
	tprogettoudr.defineColumn("borsedottorati", typeof(int));
	tprogettoudr.defineColumn("budget", typeof(decimal));
	tprogettoudr.defineColumn("contrattirtd", typeof(int));
	tprogettoudr.defineColumn("contributo", typeof(decimal));
	tprogettoudr.defineColumn("ct", typeof(DateTime));
	tprogettoudr.defineColumn("cu", typeof(string));
	tprogettoudr.defineColumn("description", typeof(string));
	tprogettoudr.defineColumn("idprogetto", typeof(int),false);
	tprogettoudr.defineColumn("idprogettoudr", typeof(int),false);
	tprogettoudr.defineColumn("impegnototale", typeof(decimal));
	tprogettoudr.defineColumn("impegnototaleore", typeof(int));
	tprogettoudr.defineColumn("lt", typeof(DateTime));
	tprogettoudr.defineColumn("lu", typeof(string));
	tprogettoudr.defineColumn("title", typeof(string));
	Tables.Add(tprogettoudr);
	tprogettoudr.defineKey("idprogetto", "idprogettoudr");

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

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PROGETTO /////////////////////////////////
	var tprogetto= new MetaTable("progetto");
	tprogetto.defineColumn("!altreupb", typeof(string));
	tprogetto.defineColumn("!datafine", typeof(DateTime));
	tprogetto.defineColumn("!datainizio", typeof(DateTime));
	tprogetto.defineColumn("!filtraAsset", typeof(string));
	tprogetto.defineColumn("!idreg", typeof(int));
	tprogetto.defineColumn("!idrendicontattivitaprogetto", typeof(int));
	tprogetto.defineColumn("bandoriferimentotxt", typeof(string));
	tprogetto.defineColumn("budget", typeof(decimal));
	tprogetto.defineColumn("budgetcalcolato", typeof(decimal));
	tprogetto.defineColumn("budgetcalcolatodate", typeof(DateTime));
	tprogetto.defineColumn("capofilatxt", typeof(string));
	tprogetto.defineColumn("codiceidentificativo", typeof(string));
	tprogetto.defineColumn("contributo", typeof(decimal));
	tprogetto.defineColumn("contributoente", typeof(decimal));
	tprogetto.defineColumn("contributoenterichiesto", typeof(decimal));
	tprogetto.defineColumn("contributorichiesto", typeof(decimal));
	tprogetto.defineColumn("costoapprovatoateneo", typeof(decimal));
	tprogetto.defineColumn("costoapprovatoateneocalcolato", typeof(decimal));
	tprogetto.defineColumn("ct", typeof(DateTime),false);
	tprogetto.defineColumn("cu", typeof(string),false);
	tprogetto.defineColumn("cup", typeof(string));
	tprogetto.defineColumn("data", typeof(DateTime));
	tprogetto.defineColumn("datacontabile", typeof(DateTime));
	tprogetto.defineColumn("dataesito", typeof(DateTime));
	tprogetto.defineColumn("description", typeof(string));
	tprogetto.defineColumn("durata", typeof(int));
	tprogetto.defineColumn("finanziamento", typeof(string));
	tprogetto.defineColumn("finanziatoretxt", typeof(string));
	tprogetto.defineColumn("idcorsostudio", typeof(int));
	tprogetto.defineColumn("idcurrency", typeof(int));
	tprogetto.defineColumn("idduratakind", typeof(int));
	tprogetto.defineColumn("idpartnerkind", typeof(int));
	tprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogetto.defineColumn("idprogettokind", typeof(int));
	tprogetto.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogetto.defineColumn("idreg", typeof(int));
	tprogetto.defineColumn("idreg_amm", typeof(int));
	tprogetto.defineColumn("idreg_aziende", typeof(int));
	tprogetto.defineColumn("idreg_aziende_fin", typeof(int));
	tprogetto.defineColumn("idregistryprogfin", typeof(int));
	tprogetto.defineColumn("idregistryprogfinbando", typeof(int));
	tprogetto.defineColumn("idstrumentofin", typeof(int));
	tprogetto.defineColumn("lt", typeof(DateTime),false);
	tprogetto.defineColumn("lu", typeof(string),false);
	tprogetto.defineColumn("progfinanziamentotxt", typeof(string));
	tprogetto.defineColumn("respamministrativi", typeof(string));
	tprogetto.defineColumn("responsabiliamministrativi", typeof(string));
	tprogetto.defineColumn("responsabiliscientifici", typeof(string));
	tprogetto.defineColumn("respscientifici", typeof(string));
	tprogetto.defineColumn("start", typeof(DateTime));
	tprogetto.defineColumn("stop", typeof(DateTime));
	tprogetto.defineColumn("title", typeof(string));
	tprogetto.defineColumn("title_en", typeof(string));
	tprogetto.defineColumn("titolobreve", typeof(string),false);
	tprogetto.defineColumn("totalbudget", typeof(decimal));
	tprogetto.defineColumn("totalcontributo", typeof(decimal));
	tprogetto.defineColumn("ulteriorecup", typeof(string));
	tprogetto.defineColumn("unitaorganizzativa", typeof(string));
	tprogetto.defineColumn("url", typeof(string));
	Tables.Add(tprogetto);
	tprogetto.defineKey("idprogetto");

	//////////////////// RENDICONTATTIVITAPROGETTOURDMEMBOVIEW /////////////////////////////////
	var trendicontattivitaprogettourdmemboview= new MetaTable("rendicontattivitaprogettourdmemboview");
	trendicontattivitaprogettourdmemboview.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettourdmemboview.defineColumn("idprogettoudr", typeof(int),false);
	trendicontattivitaprogettourdmemboview.defineColumn("idprogettoudrmembro", typeof(int),false);
	trendicontattivitaprogettourdmemboview.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettourdmemboview.defineColumn("oreanno", typeof(int));
	trendicontattivitaprogettourdmemboview.defineColumn("oreannoimpegnate", typeof(int));
	trendicontattivitaprogettourdmemboview.defineColumn("oreannorendicontate", typeof(int));
	trendicontattivitaprogettourdmemboview.defineColumn("oreattivita", typeof(int));
	trendicontattivitaprogettourdmemboview.defineColumn("oremaxanno", typeof(int),false);
	trendicontattivitaprogettourdmemboview.defineColumn("stipendioannuo", typeof(decimal));
	trendicontattivitaprogettourdmemboview.defineColumn("stipendiorendicontato", typeof(decimal));
	trendicontattivitaprogettourdmemboview.defineColumn("year", typeof(int),false);
	Tables.Add(trendicontattivitaprogettourdmemboview);
	trendicontattivitaprogettourdmemboview.defineKey("idprogetto", "idprogettoudr", "idprogettoudrmembro", "idreg", "oremaxanno", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettoudrmembrosegview.Columns["idprogettoudrmembro"]};
	var cChild = new []{rendicontattivitaprogettourdmemboview.Columns["idprogettoudrmembro"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettourdmemboview_progettoudrmembrosegview_idprogettoudrmembro",cPar,cChild,false));

	cPar = new []{progettoudr.Columns["idprogettoudr"]};
	cChild = new []{rendicontattivitaprogettourdmemboview.Columns["idprogettoudr"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettourdmemboview_progettoudr_idprogettoudr",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogettourdmemboview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettourdmemboview_registrydefaultview_idreg",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{rendicontattivitaprogettourdmemboview.Columns["year"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettourdmemboview_year_year",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{rendicontattivitaprogettourdmemboview.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettourdmemboview_progetto_idprogetto",cPar,cChild,false));

	#endregion

}
}
}
