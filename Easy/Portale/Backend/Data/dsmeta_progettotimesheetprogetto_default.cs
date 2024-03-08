
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotimesheetprogetto_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettotimesheetprogetto_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettogriglieview 		=> (MetaTable)Tables["progettogriglieview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotimesheetprogetto 		=> (MetaTable)Tables["progettotimesheetprogetto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotimesheetprogetto_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotimesheetprogetto_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotimesheetprogetto_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotimesheetprogetto_default.xsd";

	#region create DataTables
	//////////////////// PROGETTOGRIGLIEVIEW /////////////////////////////////
	var tprogettogriglieview= new MetaTable("progettogriglieview");
	tprogettogriglieview.defineColumn("corsostudio_annoistituz", typeof(int));
	tprogettogriglieview.defineColumn("corsostudio_title", typeof(string));
	tprogettogriglieview.defineColumn("currency_codecurrency", typeof(string));
	tprogettogriglieview.defineColumn("dropdown_title", typeof(string),false);
	tprogettogriglieview.defineColumn("duratakind_title", typeof(string));
	tprogettogriglieview.defineColumn("idcorsostudio", typeof(int));
	tprogettogriglieview.defineColumn("idcurrency", typeof(int));
	tprogettogriglieview.defineColumn("idprogetto", typeof(int),false);
	tprogettogriglieview.defineColumn("idreg", typeof(int));
	tprogettogriglieview.defineColumn("idreg_amm", typeof(int));
	tprogettogriglieview.defineColumn("idreg_aziende", typeof(int));
	tprogettogriglieview.defineColumn("idreg_aziende_fin", typeof(int));
	tprogettogriglieview.defineColumn("idstrumentofin", typeof(int));
	tprogettogriglieview.defineColumn("partnerkind_title", typeof(string));
	tprogettogriglieview.defineColumn("progetto_bandoriferimentotxt", typeof(string));
	tprogettogriglieview.defineColumn("progetto_budget", typeof(decimal));
	tprogettogriglieview.defineColumn("progetto_budgetcalcolato", typeof(decimal));
	tprogettogriglieview.defineColumn("progetto_budgetcalcolatodate", typeof(DateTime));
	tprogettogriglieview.defineColumn("progetto_capofilatxt", typeof(string));
	tprogettogriglieview.defineColumn("progetto_codiceidentificativo", typeof(string));
	tprogettogriglieview.defineColumn("progetto_contributo", typeof(decimal));
	tprogettogriglieview.defineColumn("progetto_contributoente", typeof(decimal));
	tprogettogriglieview.defineColumn("progetto_contributoenterichiesto", typeof(decimal));
	tprogettogriglieview.defineColumn("progetto_contributorichiesto", typeof(decimal));
	tprogettogriglieview.defineColumn("progetto_costoapprovatoateneo", typeof(decimal));
	tprogettogriglieview.defineColumn("progetto_costoapprovatoateneocalcolato", typeof(decimal));
	tprogettogriglieview.defineColumn("progetto_ct", typeof(DateTime),false);
	tprogettogriglieview.defineColumn("progetto_cu", typeof(string),false);
	tprogettogriglieview.defineColumn("progetto_cup", typeof(string));
	tprogettogriglieview.defineColumn("progetto_data", typeof(DateTime));
	tprogettogriglieview.defineColumn("progetto_datacontabile", typeof(DateTime));
	tprogettogriglieview.defineColumn("progetto_dataesito", typeof(DateTime));
	tprogettogriglieview.defineColumn("progetto_description", typeof(string));
	tprogettogriglieview.defineColumn("progetto_durata", typeof(int));
	tprogettogriglieview.defineColumn("progetto_finanziamento", typeof(string));
	tprogettogriglieview.defineColumn("progetto_finanziatoretxt", typeof(string));
	tprogettogriglieview.defineColumn("progetto_idduratakind", typeof(int));
	tprogettogriglieview.defineColumn("progetto_idpartnerkind", typeof(int));
	tprogettogriglieview.defineColumn("progetto_idprogettokind", typeof(int));
	tprogettogriglieview.defineColumn("progetto_idprogettostatuskind", typeof(int));
	tprogettogriglieview.defineColumn("progetto_idregistryprogfin", typeof(int));
	tprogettogriglieview.defineColumn("progetto_idregistryprogfinbando", typeof(int));
	tprogettogriglieview.defineColumn("progetto_lt", typeof(DateTime),false);
	tprogettogriglieview.defineColumn("progetto_lu", typeof(string),false);
	tprogettogriglieview.defineColumn("progetto_progfinanziamentotxt", typeof(string));
	tprogettogriglieview.defineColumn("progetto_responsabiliamministrativi", typeof(string));
	tprogettogriglieview.defineColumn("progetto_responsabiliscientifici", typeof(string));
	tprogettogriglieview.defineColumn("progetto_start", typeof(DateTime));
	tprogettogriglieview.defineColumn("progetto_stop", typeof(DateTime));
	tprogettogriglieview.defineColumn("progetto_title", typeof(string));
	tprogettogriglieview.defineColumn("progetto_title_en", typeof(string));
	tprogettogriglieview.defineColumn("progetto_totalbudget", typeof(decimal));
	tprogettogriglieview.defineColumn("progetto_totalcontributo", typeof(decimal));
	tprogettogriglieview.defineColumn("progetto_ulteriorecup", typeof(string));
	tprogettogriglieview.defineColumn("progetto_unitaorganizzativa", typeof(string));
	tprogettogriglieview.defineColumn("progetto_url", typeof(string));
	tprogettogriglieview.defineColumn("progettokind_title", typeof(string));
	tprogettogriglieview.defineColumn("progettostatuskind_title", typeof(string));
	tprogettogriglieview.defineColumn("registry_title", typeof(string));
	tprogettogriglieview.defineColumn("registryamm_cf", typeof(string));
	tprogettogriglieview.defineColumn("registryamm_forename", typeof(string));
	tprogettogriglieview.defineColumn("registryamm_idtitle", typeof(string));
	tprogettogriglieview.defineColumn("registryamm_surname", typeof(string));
	tprogettogriglieview.defineColumn("registryaziende_fin_title", typeof(string));
	tprogettogriglieview.defineColumn("registryaziende_title", typeof(string));
	tprogettogriglieview.defineColumn("registryprogfin_code", typeof(string));
	tprogettogriglieview.defineColumn("registryprogfin_title", typeof(string));
	tprogettogriglieview.defineColumn("registryprogfinbando_number", typeof(string));
	tprogettogriglieview.defineColumn("registryprogfinbando_scadenza", typeof(DateTime));
	tprogettogriglieview.defineColumn("registryprogfinbando_title", typeof(string));
	tprogettogriglieview.defineColumn("strumentofin_title", typeof(string));
	tprogettogriglieview.defineColumn("title_description", typeof(string));
	tprogettogriglieview.defineColumn("titolobreve", typeof(string));
	Tables.Add(tprogettogriglieview);
	tprogettogriglieview.defineKey("idprogetto");

	//////////////////// PROGETTOTIMESHEETPROGETTO /////////////////////////////////
	var tprogettotimesheetprogetto= new MetaTable("progettotimesheetprogetto");
	tprogettotimesheetprogetto.defineColumn("ct", typeof(DateTime));
	tprogettotimesheetprogetto.defineColumn("cu", typeof(string));
	tprogettotimesheetprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogettotimesheetprogetto.defineColumn("idprogettotimesheet", typeof(int),false);
	tprogettotimesheetprogetto.defineColumn("lt", typeof(DateTime));
	tprogettotimesheetprogetto.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotimesheetprogetto);
	tprogettotimesheetprogetto.defineKey("idprogetto", "idprogettotimesheet");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettogriglieview.Columns["idprogetto"]};
	var cChild = new []{progettotimesheetprogetto.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettotimesheetprogetto_progettogriglieview_idprogetto",cPar,cChild,false));

	#endregion

}
}
}
