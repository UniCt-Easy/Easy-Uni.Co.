
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
[System.Xml.Serialization.XmlRoot("dsmeta_rendicontattivitaprogettoora_personale"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_rendicontattivitaprogettoora_personale: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salelenchiview 		=> (MetaTable)Tables["salelenchiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto 		=> (MetaTable)Tables["rendicontattivitaprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackagesegview 		=> (MetaTable)Tables["workpackagesegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoelenchiview 		=> (MetaTable)Tables["progettoelenchiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_rendicontattivitaprogettoora_personale(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_rendicontattivitaprogettoora_personale (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_rendicontattivitaprogettoora_personale";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_rendicontattivitaprogettoora_personale.xsd";

	#region create DataTables
	//////////////////// SALELENCHIVIEW /////////////////////////////////
	var tsalelenchiview= new MetaTable("salelenchiview");
	tsalelenchiview.defineColumn("dropdown_title", typeof(string),false);
	tsalelenchiview.defineColumn("idprogetto", typeof(int),false);
	tsalelenchiview.defineColumn("idsal", typeof(int),false);
	Tables.Add(tsalelenchiview);
	tsalelenchiview.defineKey("idprogetto", "idsal");

	//////////////////// RENDICONTATTIVITAPROGETTO /////////////////////////////////
	var trendicontattivitaprogetto= new MetaTable("rendicontattivitaprogetto");
	trendicontattivitaprogetto.defineColumn("!orerendicont", typeof(string));
	trendicontattivitaprogetto.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("datainizioprevista", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("description", typeof(string));
	trendicontattivitaprogetto.defineColumn("iditineration", typeof(int));
	trendicontattivitaprogetto.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idrendicontattivitaprogettokind", typeof(int));
	trendicontattivitaprogetto.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("orepreventivate", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("stop", typeof(DateTime));
	Tables.Add(trendicontattivitaprogetto);
	trendicontattivitaprogetto.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idworkpackage");

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

	//////////////////// RENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var trendicontattivitaprogettoora= new MetaTable("rendicontattivitaprogettoora");
	trendicontattivitaprogettoora.defineColumn("!titleancestor", typeof(string));
	trendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("data", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("idconsolidamento", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idsal", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("ore", typeof(int));
	Tables.Add(trendicontattivitaprogettoora);
	trendicontattivitaprogettoora.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	#endregion


	#region DataRelation creation
	var cPar = new []{salelenchiview.Columns["idsal"]};
	var cChild = new []{rendicontattivitaprogettoora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_salelenchiview_idsal",cPar,cChild,false));

	cPar = new []{progettoelenchiview.Columns["idprogetto"]};
	cChild = new []{salelenchiview.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_salelenchiview_progettoelenchiview_idprogetto",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_rendicontattivitaprogetto_idrendicontattivitaprogetto",cPar,cChild,false));

	cPar = new []{workpackagesegview.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_workpackagesegview_idworkpackage",cPar,cChild,false));

	cPar = new []{workpackagesegview.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_workpackagesegview_idworkpackage",cPar,cChild,false));

	cPar = new []{progettoelenchiview.Columns["idprogetto"]};
	cChild = new []{workpackagesegview.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_workpackagesegview_progettoelenchiview_idprogetto",cPar,cChild,false));

	cPar = new []{progettoelenchiview.Columns["idprogetto"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_progettoelenchiview_idprogetto",cPar,cChild,false));

	#endregion

}
}
}
