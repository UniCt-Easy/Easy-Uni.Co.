
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoreport_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettoreport_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettosegreportview 		=> (MetaTable)Tables["progettosegreportview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettostatuskind 		=> (MetaTable)Tables["progettostatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreportprogettostatuskind 		=> (MetaTable)Tables["progettoreportprogettostatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativi_alias2 		=> (MetaTable)Tables["getregistrydocentiamministrativi_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativi_alias1 		=> (MetaTable)Tables["getregistrydocentiamministrativi_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativi 		=> (MetaTable)Tables["getregistrydocentiamministrativi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreportstruttura 		=> (MetaTable)Tables["progettoreportstruttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryprogfin 		=> (MetaTable)Tables["registryprogfin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreportregistryprogfin 		=> (MetaTable)Tables["progettoreportregistryprogfin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoactivitykind_alias1 		=> (MetaTable)Tables["progettoactivitykind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettokind 		=> (MetaTable)Tables["progettokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreportprogettokind 		=> (MetaTable)Tables["progettoreportprogettokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoactivitykind 		=> (MetaTable)Tables["progettoactivitykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreportprogettoactivitykind 		=> (MetaTable)Tables["progettoreportprogettoactivitykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreport 		=> (MetaTable)Tables["progettoreport"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoreport_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoreport_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoreport_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoreport_default.xsd";

	#region create DataTables
	//////////////////// PROGETTOSEGREPORTVIEW /////////////////////////////////
	var tprogettosegreportview= new MetaTable("progettosegreportview");
	tprogettosegreportview.defineColumn("borse_assegni", typeof(int));
	tprogettosegreportview.defineColumn("classconsorsuale", typeof(string));
	tprogettosegreportview.defineColumn("codice_interno", typeof(int),false);
	tprogettosegreportview.defineColumn("contrattokind", typeof(string));
	tprogettosegreportview.defineColumn("currency_codecurrency", typeof(string));
	tprogettosegreportview.defineColumn("duratakind_title", typeof(string));
	tprogettosegreportview.defineColumn("gender", typeof(string));
	tprogettosegreportview.defineColumn("idprogettoreport", typeof(int),false);
	tprogettosegreportview.defineColumn("keywords", typeof(string));
	tprogettosegreportview.defineColumn("macroarea", typeof(string));
	tprogettosegreportview.defineColumn("macroareastruttura", typeof(string));
	tprogettosegreportview.defineColumn("partner", typeof(string));
	tprogettosegreportview.defineColumn("partnerkind_title", typeof(string));
	tprogettosegreportview.defineColumn("partners", typeof(int));
	tprogettosegreportview.defineColumn("personale_fondi_progetto_donne", typeof(int));
	tprogettosegreportview.defineColumn("personale_fondi_progetto_ssd", typeof(string));
	tprogettosegreportview.defineColumn("personale_fondi_progetto_uomini_donne", typeof(int));
	tprogettosegreportview.defineColumn("progetto_bandoriferimentotxt", typeof(string));
	tprogettosegreportview.defineColumn("progetto_budget", typeof(decimal));
	tprogettosegreportview.defineColumn("progetto_budgetcalcolato", typeof(decimal));
	tprogettosegreportview.defineColumn("progetto_budgetcalcolatodate", typeof(DateTime));
	tprogettosegreportview.defineColumn("progetto_capofilatxt", typeof(string));
	tprogettosegreportview.defineColumn("progetto_codiceidentificativo", typeof(string));
	tprogettosegreportview.defineColumn("progetto_contributo", typeof(decimal));
	tprogettosegreportview.defineColumn("progetto_contributoente", typeof(decimal));
	tprogettosegreportview.defineColumn("progetto_contributoenterichiesto", typeof(decimal));
	tprogettosegreportview.defineColumn("progetto_contributorichiesto", typeof(decimal));
	tprogettosegreportview.defineColumn("progetto_costoapprovatoateneo", typeof(decimal));
	tprogettosegreportview.defineColumn("progetto_costoapprovatoateneocalcolato", typeof(decimal));
	tprogettosegreportview.defineColumn("progetto_cup", typeof(string));
	tprogettosegreportview.defineColumn("progetto_description", typeof(string));
	tprogettosegreportview.defineColumn("progetto_durata", typeof(int));
	tprogettosegreportview.defineColumn("progetto_finanziamento", typeof(string));
	tprogettosegreportview.defineColumn("progetto_finanziatoretxt", typeof(string));
	tprogettosegreportview.defineColumn("progetto_progfinanziamentotxt", typeof(string));
	tprogettosegreportview.defineColumn("progetto_start", typeof(DateTime));
	tprogettosegreportview.defineColumn("progetto_stop", typeof(DateTime));
	tprogettosegreportview.defineColumn("progetto_title", typeof(string));
	tprogettosegreportview.defineColumn("progetto_title_en", typeof(string));
	tprogettosegreportview.defineColumn("progetto_totalbudget", typeof(decimal));
	tprogettosegreportview.defineColumn("progetto_totalcontributo", typeof(decimal));
	tprogettosegreportview.defineColumn("progettoactivitykind_title", typeof(string));
	tprogettosegreportview.defineColumn("progettokind_title", typeof(string));
	tprogettosegreportview.defineColumn("progettostatuskind_title", typeof(string));
	tprogettosegreportview.defineColumn("registry_cf", typeof(string));
	tprogettosegreportview.defineColumn("registry_forename", typeof(string));
	tprogettosegreportview.defineColumn("registry_idreg", typeof(int),false);
	tprogettosegreportview.defineColumn("registry_surname", typeof(string));
	tprogettosegreportview.defineColumn("registryamm_cf", typeof(string));
	tprogettosegreportview.defineColumn("registryamm_forename", typeof(string));
	tprogettosegreportview.defineColumn("registryamm_idreg", typeof(int),false);
	tprogettosegreportview.defineColumn("registryamm_surname", typeof(string));
	tprogettosegreportview.defineColumn("registryaziende_fin_title", typeof(string));
	tprogettosegreportview.defineColumn("registryaziende_title", typeof(string));
	tprogettosegreportview.defineColumn("registryprogfin_title", typeof(string));
	tprogettosegreportview.defineColumn("registryprogfinbando_scadenza", typeof(DateTime));
	tprogettosegreportview.defineColumn("registryprogfinbando_title", typeof(string));
	tprogettosegreportview.defineColumn("ssd", typeof(string));
	tprogettosegreportview.defineColumn("strumentofin_title", typeof(string));
	tprogettosegreportview.defineColumn("struttura", typeof(string));
	tprogettosegreportview.defineColumn("team_unict_progetto_dipartimenti", typeof(string));
	tprogettosegreportview.defineColumn("team_unict_progetto_donne", typeof(int));
	tprogettosegreportview.defineColumn("team_unict_progetto_macroaree", typeof(string));
	tprogettosegreportview.defineColumn("team_unict_progetto_ssd", typeof(string));
	tprogettosegreportview.defineColumn("team_unict_progetto_uomini_donne", typeof(int));
	tprogettosegreportview.defineColumn("titolobreve", typeof(string));
	tprogettosegreportview.defineColumn("ulteriorecup", typeof(string));
	Tables.Add(tprogettosegreportview);
	tprogettosegreportview.defineKey("codice_interno", "idprogettoreport", "registry_idreg", "registryamm_idreg");

	//////////////////// PROGETTOSTATUSKIND /////////////////////////////////
	var tprogettostatuskind= new MetaTable("progettostatuskind");
	tprogettostatuskind.defineColumn("contributo", typeof(string));
	tprogettostatuskind.defineColumn("contributoente", typeof(string));
	tprogettostatuskind.defineColumn("contributoenterichiesto", typeof(string));
	tprogettostatuskind.defineColumn("contributorichiesto", typeof(string));
	tprogettostatuskind.defineColumn("ct", typeof(DateTime),false);
	tprogettostatuskind.defineColumn("cu", typeof(string),false);
	tprogettostatuskind.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettostatuskind.defineColumn("lt", typeof(DateTime),false);
	tprogettostatuskind.defineColumn("lu", typeof(string),false);
	tprogettostatuskind.defineColumn("sortcode", typeof(int),false);
	tprogettostatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tprogettostatuskind);
	tprogettostatuskind.defineKey("idprogettostatuskind");

	//////////////////// PROGETTOREPORTPROGETTOSTATUSKIND /////////////////////////////////
	var tprogettoreportprogettostatuskind= new MetaTable("progettoreportprogettostatuskind");
	tprogettoreportprogettostatuskind.defineColumn("ct", typeof(DateTime),false);
	tprogettoreportprogettostatuskind.defineColumn("cu", typeof(string),false);
	tprogettoreportprogettostatuskind.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreportprogettostatuskind.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettoreportprogettostatuskind.defineColumn("lt", typeof(DateTime),false);
	tprogettoreportprogettostatuskind.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoreportprogettostatuskind);
	tprogettoreportprogettostatuskind.defineKey("idprogettoreport", "idprogettostatuskind");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVI_ALIAS2 /////////////////////////////////
	var tgetregistrydocentiamministrativi_alias2= new MetaTable("getregistrydocentiamministrativi_alias2");
	tgetregistrydocentiamministrativi_alias2.defineColumn("contratto", typeof(string));
	tgetregistrydocentiamministrativi_alias2.defineColumn("extmatricula", typeof(string));
	tgetregistrydocentiamministrativi_alias2.defineColumn("forename", typeof(string));
	tgetregistrydocentiamministrativi_alias2.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativi_alias2.defineColumn("surname", typeof(string));
	tgetregistrydocentiamministrativi_alias2.ExtendedProperties["TableForReading"]="getregistrydocentiamministrativi";
	Tables.Add(tgetregistrydocentiamministrativi_alias2);
	tgetregistrydocentiamministrativi_alias2.defineKey("idreg");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVI_ALIAS1 /////////////////////////////////
	var tgetregistrydocentiamministrativi_alias1= new MetaTable("getregistrydocentiamministrativi_alias1");
	tgetregistrydocentiamministrativi_alias1.defineColumn("contratto", typeof(string));
	tgetregistrydocentiamministrativi_alias1.defineColumn("extmatricula", typeof(string));
	tgetregistrydocentiamministrativi_alias1.defineColumn("forename", typeof(string));
	tgetregistrydocentiamministrativi_alias1.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativi_alias1.defineColumn("surname", typeof(string));
	tgetregistrydocentiamministrativi_alias1.ExtendedProperties["TableForReading"]="getregistrydocentiamministrativi";
	Tables.Add(tgetregistrydocentiamministrativi_alias1);
	tgetregistrydocentiamministrativi_alias1.defineKey("idreg");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVI /////////////////////////////////
	var tgetregistrydocentiamministrativi= new MetaTable("getregistrydocentiamministrativi");
	tgetregistrydocentiamministrativi.defineColumn("contratto", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("extmatricula", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("forename", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativi.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministrativi);
	tgetregistrydocentiamministrativi.defineKey("idreg");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("active", typeof(string));
	tstruttura.defineColumn("codice", typeof(string));
	tstruttura.defineColumn("codiceipa", typeof(string));
	tstruttura.defineColumn("ct", typeof(DateTime),false);
	tstruttura.defineColumn("cu", typeof(string),false);
	tstruttura.defineColumn("email", typeof(string));
	tstruttura.defineColumn("fax", typeof(string));
	tstruttura.defineColumn("idaoo", typeof(int));
	tstruttura.defineColumn("idreg", typeof(int));
	tstruttura.defineColumn("idreg_appr", typeof(int));
	tstruttura.defineColumn("idreg_resp", typeof(int));
	tstruttura.defineColumn("idreg_valut", typeof(int));
	tstruttura.defineColumn("idsede", typeof(int),false);
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("idupb", typeof(string));
	tstruttura.defineColumn("lt", typeof(DateTime),false);
	tstruttura.defineColumn("lu", typeof(string),false);
	tstruttura.defineColumn("paridstruttura", typeof(int));
	tstruttura.defineColumn("pesoindicatori", typeof(decimal));
	tstruttura.defineColumn("pesoobiettivi", typeof(decimal));
	tstruttura.defineColumn("pesoprogaltreuo", typeof(decimal));
	tstruttura.defineColumn("pesoproguo", typeof(decimal));
	tstruttura.defineColumn("telefono", typeof(string));
	tstruttura.defineColumn("title", typeof(string));
	tstruttura.defineColumn("title_en", typeof(string));
	tstruttura.defineColumn("!idreg_appr_getregistrydocentiamministrativi_surname", typeof(string));
	tstruttura.defineColumn("!idreg_appr_getregistrydocentiamministrativi_forename", typeof(string));
	tstruttura.defineColumn("!idreg_appr_getregistrydocentiamministrativi_extmatricula", typeof(string));
	tstruttura.defineColumn("!idreg_appr_getregistrydocentiamministrativi_contratto", typeof(string));
	tstruttura.defineColumn("!idreg_resp_getregistrydocentiamministrativi_surname", typeof(string));
	tstruttura.defineColumn("!idreg_resp_getregistrydocentiamministrativi_forename", typeof(string));
	tstruttura.defineColumn("!idreg_resp_getregistrydocentiamministrativi_extmatricula", typeof(string));
	tstruttura.defineColumn("!idreg_resp_getregistrydocentiamministrativi_contratto", typeof(string));
	tstruttura.defineColumn("!idreg_valut_getregistrydocentiamministrativi_surname", typeof(string));
	tstruttura.defineColumn("!idreg_valut_getregistrydocentiamministrativi_forename", typeof(string));
	tstruttura.defineColumn("!idreg_valut_getregistrydocentiamministrativi_extmatricula", typeof(string));
	tstruttura.defineColumn("!idreg_valut_getregistrydocentiamministrativi_contratto", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// PROGETTOREPORTSTRUTTURA /////////////////////////////////
	var tprogettoreportstruttura= new MetaTable("progettoreportstruttura");
	tprogettoreportstruttura.defineColumn("ct", typeof(DateTime),false);
	tprogettoreportstruttura.defineColumn("cu", typeof(string),false);
	tprogettoreportstruttura.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreportstruttura.defineColumn("idstruttura", typeof(int),false);
	tprogettoreportstruttura.defineColumn("lt", typeof(DateTime),false);
	tprogettoreportstruttura.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoreportstruttura);
	tprogettoreportstruttura.defineKey("idprogettoreport", "idstruttura");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// REGISTRYPROGFIN /////////////////////////////////
	var tregistryprogfin= new MetaTable("registryprogfin");
	tregistryprogfin.defineColumn("code", typeof(string));
	tregistryprogfin.defineColumn("ct", typeof(DateTime),false);
	tregistryprogfin.defineColumn("cu", typeof(string),false);
	tregistryprogfin.defineColumn("description", typeof(string));
	tregistryprogfin.defineColumn("idreg", typeof(int),false);
	tregistryprogfin.defineColumn("idregistryprogfin", typeof(int),false);
	tregistryprogfin.defineColumn("lt", typeof(DateTime),false);
	tregistryprogfin.defineColumn("lu", typeof(string),false);
	tregistryprogfin.defineColumn("title", typeof(string));
	Tables.Add(tregistryprogfin);
	tregistryprogfin.defineKey("idreg", "idregistryprogfin");

	//////////////////// PROGETTOREPORTREGISTRYPROGFIN /////////////////////////////////
	var tprogettoreportregistryprogfin= new MetaTable("progettoreportregistryprogfin");
	tprogettoreportregistryprogfin.defineColumn("ct", typeof(DateTime),false);
	tprogettoreportregistryprogfin.defineColumn("cu", typeof(string),false);
	tprogettoreportregistryprogfin.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreportregistryprogfin.defineColumn("idregistryprogfin", typeof(int),false);
	tprogettoreportregistryprogfin.defineColumn("lt", typeof(DateTime),false);
	tprogettoreportregistryprogfin.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoreportregistryprogfin);
	tprogettoreportregistryprogfin.defineKey("idprogettoreport", "idregistryprogfin");

	//////////////////// PROGETTOACTIVITYKIND_ALIAS1 /////////////////////////////////
	var tprogettoactivitykind_alias1= new MetaTable("progettoactivitykind_alias1");
	tprogettoactivitykind_alias1.defineColumn("active", typeof(string));
	tprogettoactivitykind_alias1.defineColumn("idprogettoactivitykind", typeof(int),false);
	tprogettoactivitykind_alias1.defineColumn("title", typeof(string));
	tprogettoactivitykind_alias1.ExtendedProperties["TableForReading"]="progettoactivitykind";
	Tables.Add(tprogettoactivitykind_alias1);
	tprogettoactivitykind_alias1.defineKey("idprogettoactivitykind");

	//////////////////// PROGETTOKIND /////////////////////////////////
	var tprogettokind= new MetaTable("progettokind");
	tprogettokind.defineColumn("active", typeof(string));
	tprogettokind.defineColumn("ct", typeof(DateTime));
	tprogettokind.defineColumn("cu", typeof(string));
	tprogettokind.defineColumn("description", typeof(string));
	tprogettokind.defineColumn("idcorsostudio", typeof(string));
	tprogettokind.defineColumn("idprogettoactivitykind", typeof(int));
	tprogettokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettokind.defineColumn("irap", typeof(string));
	tprogettokind.defineColumn("lt", typeof(DateTime));
	tprogettokind.defineColumn("lu", typeof(string));
	tprogettokind.defineColumn("oredivisionecostostipendio", typeof(int),false);
	tprogettokind.defineColumn("stipendioannoprec", typeof(string));
	tprogettokind.defineColumn("stipendiocomericavo", typeof(string));
	tprogettokind.defineColumn("title", typeof(string));
	tprogettokind.defineColumn("!idprogettoactivitykind_progettoactivitykind_title", typeof(string));
	Tables.Add(tprogettokind);
	tprogettokind.defineKey("idprogettokind");

	//////////////////// PROGETTOREPORTPROGETTOKIND /////////////////////////////////
	var tprogettoreportprogettokind= new MetaTable("progettoreportprogettokind");
	tprogettoreportprogettokind.defineColumn("ct", typeof(DateTime),false);
	tprogettoreportprogettokind.defineColumn("cu", typeof(string),false);
	tprogettoreportprogettokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettoreportprogettokind.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreportprogettokind.defineColumn("lt", typeof(DateTime),false);
	tprogettoreportprogettokind.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoreportprogettokind);
	tprogettoreportprogettokind.defineKey("idprogettokind", "idprogettoreport");

	//////////////////// PROGETTOACTIVITYKIND /////////////////////////////////
	var tprogettoactivitykind= new MetaTable("progettoactivitykind");
	tprogettoactivitykind.defineColumn("active", typeof(string));
	tprogettoactivitykind.defineColumn("ct", typeof(DateTime),false);
	tprogettoactivitykind.defineColumn("cu", typeof(string),false);
	tprogettoactivitykind.defineColumn("description", typeof(string));
	tprogettoactivitykind.defineColumn("idprogettoactivitykind", typeof(int),false);
	tprogettoactivitykind.defineColumn("lt", typeof(DateTime),false);
	tprogettoactivitykind.defineColumn("lu", typeof(string),false);
	tprogettoactivitykind.defineColumn("sortcode", typeof(int));
	tprogettoactivitykind.defineColumn("title", typeof(string));
	Tables.Add(tprogettoactivitykind);
	tprogettoactivitykind.defineKey("idprogettoactivitykind");

	//////////////////// PROGETTOREPORTPROGETTOACTIVITYKIND /////////////////////////////////
	var tprogettoreportprogettoactivitykind= new MetaTable("progettoreportprogettoactivitykind");
	tprogettoreportprogettoactivitykind.defineColumn("ct", typeof(DateTime),false);
	tprogettoreportprogettoactivitykind.defineColumn("cu", typeof(string),false);
	tprogettoreportprogettoactivitykind.defineColumn("idprogettoactivitykind", typeof(int),false);
	tprogettoreportprogettoactivitykind.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreportprogettoactivitykind.defineColumn("lt", typeof(DateTime),false);
	tprogettoreportprogettoactivitykind.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoreportprogettoactivitykind);
	tprogettoreportprogettoactivitykind.defineKey("idprogettoactivitykind", "idprogettoreport");

	//////////////////// PROGETTOREPORT /////////////////////////////////
	var tprogettoreport= new MetaTable("progettoreport");
	tprogettoreport.defineColumn("ct", typeof(DateTime),false);
	tprogettoreport.defineColumn("cu", typeof(string),false);
	tprogettoreport.defineColumn("detail", typeof(string));
	tprogettoreport.defineColumn("gender", typeof(string));
	tprogettoreport.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreport.defineColumn("lt", typeof(DateTime),false);
	tprogettoreport.defineColumn("lu", typeof(string),false);
	tprogettoreport.defineColumn("title", typeof(string));
	tprogettoreport.defineColumn("year", typeof(int));
	Tables.Add(tprogettoreport);
	tprogettoreport.defineKey("idprogettoreport");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettosegreportview.Columns["idprogettoreport"]};
	var cChild = new []{progettoreport.Columns["idprogettoreport"]};
	Relations.Add(new DataRelation("FK_progettoreport_progettosegreportview_idprogettoreport",cPar,cChild,false));

	cPar = new []{progettoreport.Columns["idprogettoreport"]};
	cChild = new []{progettoreportprogettostatuskind.Columns["idprogettoreport"]};
	Relations.Add(new DataRelation("FK_progettoreportprogettostatuskind_progettoreport_idprogettoreport",cPar,cChild,false));

	cPar = new []{progettostatuskind.Columns["idprogettostatuskind"]};
	cChild = new []{progettoreportprogettostatuskind.Columns["idprogettostatuskind"]};
	Relations.Add(new DataRelation("FK_progettoreportprogettostatuskind_progettostatuskind_idprogettostatuskind",cPar,cChild,false));

	cPar = new []{progettoreport.Columns["idprogettoreport"]};
	cChild = new []{progettoreportstruttura.Columns["idprogettoreport"]};
	Relations.Add(new DataRelation("FK_progettoreportstruttura_progettoreport_idprogettoreport",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{progettoreportstruttura.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_progettoreportstruttura_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi_alias2.Columns["idreg"]};
	cChild = new []{struttura.Columns["idreg_valut"]};
	Relations.Add(new DataRelation("FK_struttura_getregistrydocentiamministrativi_alias2_idreg_valut",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi_alias1.Columns["idreg"]};
	cChild = new []{struttura.Columns["idreg_resp"]};
	Relations.Add(new DataRelation("FK_struttura_getregistrydocentiamministrativi_alias1_idreg_resp",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi.Columns["idreg"]};
	cChild = new []{struttura.Columns["idreg_appr"]};
	Relations.Add(new DataRelation("FK_struttura_getregistrydocentiamministrativi_idreg_appr",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{progettoreport.Columns["year"]};
	Relations.Add(new DataRelation("FK_progettoreport_year_year",cPar,cChild,false));

	cPar = new []{progettoreport.Columns["idprogettoreport"]};
	cChild = new []{progettoreportregistryprogfin.Columns["idprogettoreport"]};
	Relations.Add(new DataRelation("FK_progettoreportregistryprogfin_progettoreport_idprogettoreport",cPar,cChild,false));

	cPar = new []{registryprogfin.Columns["idregistryprogfin"]};
	cChild = new []{progettoreportregistryprogfin.Columns["idregistryprogfin"]};
	Relations.Add(new DataRelation("FK_progettoreportregistryprogfin_registryprogfin_idregistryprogfin",cPar,cChild,false));

	cPar = new []{progettoreport.Columns["idprogettoreport"]};
	cChild = new []{progettoreportprogettokind.Columns["idprogettoreport"]};
	Relations.Add(new DataRelation("FK_progettoreportprogettokind_progettoreport_idprogettoreport",cPar,cChild,false));

	cPar = new []{progettokind.Columns["idprogettokind"]};
	cChild = new []{progettoreportprogettokind.Columns["idprogettokind"]};
	Relations.Add(new DataRelation("FK_progettoreportprogettokind_progettokind_idprogettokind",cPar,cChild,false));

	cPar = new []{progettoactivitykind_alias1.Columns["idprogettoactivitykind"]};
	cChild = new []{progettokind.Columns["idprogettoactivitykind"]};
	Relations.Add(new DataRelation("FK_progettokind_progettoactivitykind_alias1_idprogettoactivitykind",cPar,cChild,false));

	cPar = new []{progettoreport.Columns["idprogettoreport"]};
	cChild = new []{progettoreportprogettoactivitykind.Columns["idprogettoreport"]};
	Relations.Add(new DataRelation("FK_progettoreportprogettoactivitykind_progettoreport_idprogettoreport",cPar,cChild,false));

	cPar = new []{progettoactivitykind.Columns["idprogettoactivitykind"]};
	cChild = new []{progettoreportprogettoactivitykind.Columns["idprogettoactivitykind"]};
	Relations.Add(new DataRelation("FK_progettoreportprogettoactivitykind_progettoactivitykind_idprogettoactivitykind",cPar,cChild,false));

	#endregion

}
}
}
