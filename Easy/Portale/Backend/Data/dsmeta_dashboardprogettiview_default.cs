
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_dashboardprogettiview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_dashboardprogettiview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettostatuskinddefaultview 		=> (MetaTable)Tables["progettostatuskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettokindsegview 		=> (MetaTable)Tables["progettokindsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoelenchiview 		=> (MetaTable)Tables["progettoelenchiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dashboardprogettiview 		=> (MetaTable)Tables["dashboardprogettiview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_dashboardprogettiview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_dashboardprogettiview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_dashboardprogettiview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_dashboardprogettiview_default.xsd";

	#region create DataTables
	//////////////////// PROGETTOSTATUSKINDDEFAULTVIEW /////////////////////////////////
	var tprogettostatuskinddefaultview= new MetaTable("progettostatuskinddefaultview");
	tprogettostatuskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tprogettostatuskinddefaultview.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributo", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributoente", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributoenterichiesto", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributorichiesto", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_ct", typeof(DateTime),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_cu", typeof(string),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_lt", typeof(DateTime),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_lu", typeof(string),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_sortcode", typeof(int),false);
	tprogettostatuskinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tprogettostatuskinddefaultview);
	tprogettostatuskinddefaultview.defineKey("idprogettostatuskind");

	//////////////////// PROGETTOKINDSEGVIEW /////////////////////////////////
	var tprogettokindsegview= new MetaTable("progettokindsegview");
	tprogettokindsegview.defineColumn("dropdown_title", typeof(string),false);
	tprogettokindsegview.defineColumn("idprogettokind", typeof(int),false);
	tprogettokindsegview.defineColumn("progettoactivitykind_title", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_active", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_ct", typeof(DateTime));
	tprogettokindsegview.defineColumn("progettokind_cu", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_description", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_idcorsostudio", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_idprogettoactivitykind", typeof(int));
	tprogettokindsegview.defineColumn("progettokind_irap", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_lt", typeof(DateTime));
	tprogettokindsegview.defineColumn("progettokind_lu", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_oredivisionecostostipendio", typeof(int));
	tprogettokindsegview.defineColumn("progettokind_stipendioannoprec", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_stipendiocomericavo", typeof(string));
	tprogettokindsegview.defineColumn("title", typeof(string));
	Tables.Add(tprogettokindsegview);
	tprogettokindsegview.defineKey("idprogettokind");

	//////////////////// PROGETTOELENCHIVIEW /////////////////////////////////
	var tprogettoelenchiview= new MetaTable("progettoelenchiview");
	tprogettoelenchiview.defineColumn("corsostudio_annoistituz", typeof(int));
	tprogettoelenchiview.defineColumn("corsostudio_title", typeof(string));
	tprogettoelenchiview.defineColumn("currency_codecurrency", typeof(string));
	tprogettoelenchiview.defineColumn("dropdown_title", typeof(string),false);
	tprogettoelenchiview.defineColumn("duratakind_title", typeof(string));
	tprogettoelenchiview.defineColumn("idcorsostudio", typeof(int));
	tprogettoelenchiview.defineColumn("idcurrency", typeof(int));
	tprogettoelenchiview.defineColumn("idprogetto", typeof(int),false);
	tprogettoelenchiview.defineColumn("idreg", typeof(int));
	tprogettoelenchiview.defineColumn("idreg_amm", typeof(int));
	tprogettoelenchiview.defineColumn("idreg_aziende", typeof(int));
	tprogettoelenchiview.defineColumn("idreg_aziende_fin", typeof(int));
	tprogettoelenchiview.defineColumn("idstrumentofin", typeof(int));
	tprogettoelenchiview.defineColumn("partnerkind_title", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_bandoriferimentotxt", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_budget", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_budgetcalcolato", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_budgetcalcolatodate", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_capofilatxt", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_codiceidentificativo", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_contributo", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_contributoente", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_contributoenterichiesto", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_contributorichiesto", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_costoapprovatoateneo", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_costoapprovatoateneocalcolato", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_ct", typeof(DateTime),false);
	tprogettoelenchiview.defineColumn("progetto_cu", typeof(string),false);
	tprogettoelenchiview.defineColumn("progetto_cup", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_data", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_datacontabile", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_dataesito", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_description", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_durata", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_finanziamento", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_finanziatoretxt", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_idduratakind", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_idpartnerkind", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_idprogettokind", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_idprogettostatuskind", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_idregistryprogfin", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_idregistryprogfinbando", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_lt", typeof(DateTime),false);
	tprogettoelenchiview.defineColumn("progetto_lu", typeof(string),false);
	tprogettoelenchiview.defineColumn("progetto_progfinanziamentotxt", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_respamministrativi", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_responsabiliamministrativi", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_responsabiliscientifici", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_respscientifici", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_start", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_stop", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_title", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_title_en", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_totalbudget", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_totalcontributo", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_ulteriorecup", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_unitaorganizzativa", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_url", typeof(string));
	tprogettoelenchiview.defineColumn("progettokind_title", typeof(string));
	tprogettoelenchiview.defineColumn("progettostatuskind_title", typeof(string));
	tprogettoelenchiview.defineColumn("registry_title", typeof(string));
	tprogettoelenchiview.defineColumn("registryamm_cf", typeof(string));
	tprogettoelenchiview.defineColumn("registryamm_forename", typeof(string));
	tprogettoelenchiview.defineColumn("registryamm_idtitle", typeof(string));
	tprogettoelenchiview.defineColumn("registryamm_surname", typeof(string));
	tprogettoelenchiview.defineColumn("registryaziende_fin_title", typeof(string));
	tprogettoelenchiview.defineColumn("registryaziende_title", typeof(string));
	tprogettoelenchiview.defineColumn("registryprogfin_code", typeof(string));
	tprogettoelenchiview.defineColumn("registryprogfin_title", typeof(string));
	tprogettoelenchiview.defineColumn("registryprogfinbando_number", typeof(string));
	tprogettoelenchiview.defineColumn("registryprogfinbando_scadenza", typeof(DateTime));
	tprogettoelenchiview.defineColumn("registryprogfinbando_title", typeof(string));
	tprogettoelenchiview.defineColumn("strumentofin_title", typeof(string));
	tprogettoelenchiview.defineColumn("title_description", typeof(string));
	tprogettoelenchiview.defineColumn("titolobreve", typeof(string));
	Tables.Add(tprogettoelenchiview);
	tprogettoelenchiview.defineKey("idprogetto");

	//////////////////// DASHBOARDPROGETTIVIEW /////////////////////////////////
	var tdashboardprogettiview= new MetaTable("dashboardprogettiview");
	tdashboardprogettiview.defineColumn("avanzamento_costi_su_temporale", typeof(decimal));
	tdashboardprogettiview.defineColumn("avanzamento_economico", typeof(decimal));
	tdashboardprogettiview.defineColumn("avanzamento_gg", typeof(int));
	tdashboardprogettiview.defineColumn("avanzamento_temporale", typeof(decimal));
	tdashboardprogettiview.defineColumn("costi", typeof(decimal),false);
	tdashboardprogettiview.defineColumn("cup", typeof(string));
	tdashboardprogettiview.defineColumn("dipartimento", typeof(string));
	tdashboardprogettiview.defineColumn("durata_gg", typeof(int),false);
	tdashboardprogettiview.defineColumn("idprogetto", typeof(int),false);
	tdashboardprogettiview.defineColumn("idprogettokind", typeof(int));
	tdashboardprogettiview.defineColumn("idprogettostatuskind", typeof(int));
	tdashboardprogettiview.defineColumn("progettostop", typeof(DateTime));
	tdashboardprogettiview.defineColumn("start", typeof(DateTime));
	tdashboardprogettiview.defineColumn("title", typeof(string));
	tdashboardprogettiview.defineColumn("titolobreve", typeof(string));
	tdashboardprogettiview.defineColumn("total_budget", typeof(decimal),false);
	Tables.Add(tdashboardprogettiview);
	tdashboardprogettiview.defineKey("idprogetto");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettostatuskinddefaultview.Columns["idprogettostatuskind"]};
	var cChild = new []{dashboardprogettiview.Columns["idprogettostatuskind"]};
	Relations.Add(new DataRelation("FK_dashboardprogettiview_progettostatuskinddefaultview_idprogettostatuskind",cPar,cChild,false));

	cPar = new []{progettokindsegview.Columns["idprogettokind"]};
	cChild = new []{dashboardprogettiview.Columns["idprogettokind"]};
	Relations.Add(new DataRelation("FK_dashboardprogettiview_progettokindsegview_idprogettokind",cPar,cChild,false));

	cPar = new []{progettoelenchiview.Columns["idprogetto"]};
	cChild = new []{dashboardprogettiview.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_dashboardprogettiview_progettoelenchiview_idprogetto",cPar,cChild,false));

	#endregion

}
}
}
