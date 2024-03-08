
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettosalreport_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettosalreport_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoelenchiview 		=> (MetaTable)Tables["progettoelenchiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettosalreport 		=> (MetaTable)Tables["progettosalreport"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettosalreport_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettosalreport_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettosalreport_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettosalreport_default.xsd";

	#region create DataTables
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("aoo_title", typeof(string));
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	tstrutturadefaultview.defineColumn("sede_title", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codice", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codiceipa", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_ct", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_cu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_email", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_fax", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_idaoo", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idreg", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idsede", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_idstrutturakind", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_lt", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_lu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_pesoindicatori", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoobiettivi", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoprogaltreuo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoproguo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_telefono", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_title_en", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_struttura_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturaparent_idstrutturakind", typeof(int));
	tstrutturadefaultview.defineColumn("strutturaparent_title", typeof(string));
	tstrutturadefaultview.defineColumn("title", typeof(string));
	tstrutturadefaultview.defineColumn("upb_title", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIDEFAULTVIEW /////////////////////////////////
	var tgetregistrydocentiamministratividefaultview= new MetaTable("getregistrydocentiamministratividefaultview");
	tgetregistrydocentiamministratividefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tgetregistrydocentiamministratividefaultview);
	tgetregistrydocentiamministratividefaultview.defineKey("idreg");

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
	tprogettoelenchiview.defineColumn("progetto_responsabiliamministrativi", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_responsabiliscientifici", typeof(string));
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

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PROGETTOSALREPORT /////////////////////////////////
	var tprogettosalreport= new MetaTable("progettosalreport");
	tprogettosalreport.defineColumn("ct", typeof(DateTime),false);
	tprogettosalreport.defineColumn("cu", typeof(string),false);
	tprogettosalreport.defineColumn("idprogetto", typeof(int));
	tprogettosalreport.defineColumn("idprogettosalreport", typeof(int),false);
	tprogettosalreport.defineColumn("idreg", typeof(int));
	tprogettosalreport.defineColumn("idreg_user", typeof(int));
	tprogettosalreport.defineColumn("idstruttura", typeof(int));
	tprogettosalreport.defineColumn("lt", typeof(DateTime),false);
	tprogettosalreport.defineColumn("lu", typeof(string),false);
	tprogettosalreport.defineColumn("year", typeof(int));
	Tables.Add(tprogettosalreport);
	tprogettosalreport.defineKey("idprogettosalreport");

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{progettosalreport.Columns["idreg_user"]};
	Relations.Add(new DataRelation("FK_progettosalreport_registry_idreg_user",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{progettosalreport.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_progettosalreport_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview.Columns["idreg"]};
	cChild = new []{progettosalreport.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_progettosalreport_getregistrydocentiamministratividefaultview_idreg",cPar,cChild,false));

	cPar = new []{progettoelenchiview.Columns["idprogetto"]};
	cChild = new []{progettosalreport.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettosalreport_progettoelenchiview_idprogetto",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{progettosalreport.Columns["year"]};
	Relations.Add(new DataRelation("FK_progettosalreport_year_year",cPar,cChild,false));

	#endregion

}
}
}
