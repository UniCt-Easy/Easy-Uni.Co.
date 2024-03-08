
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettosegreportview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettosegreportview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettosegreportview 		=> (MetaTable)Tables["progettosegreportview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettosegreportview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettosegreportview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettosegreportview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettosegreportview_default.xsd";

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

	#endregion

}
}
}
