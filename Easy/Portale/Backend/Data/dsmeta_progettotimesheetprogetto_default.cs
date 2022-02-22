
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
public class dsmeta_progettotimesheetprogetto_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettosegview 		=> (MetaTable)Tables["progettosegview"];

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
	//////////////////// PROGETTOSEGVIEW /////////////////////////////////
	var tprogettosegview= new MetaTable("progettosegview");
	tprogettosegview.defineColumn("corsostudio_annoistituz", typeof(int));
	tprogettosegview.defineColumn("corsostudio_title", typeof(string));
	tprogettosegview.defineColumn("currency_codecurrency", typeof(string));
	tprogettosegview.defineColumn("dropdown_title", typeof(string),false);
	tprogettosegview.defineColumn("duratakind_title", typeof(string));
	tprogettosegview.defineColumn("idcorsostudio", typeof(int));
	tprogettosegview.defineColumn("idcurrency", typeof(int));
	tprogettosegview.defineColumn("idprogetto", typeof(int),false);
	tprogettosegview.defineColumn("idreg", typeof(int));
	tprogettosegview.defineColumn("idreg_aziende", typeof(int));
	tprogettosegview.defineColumn("idreg_aziende_fin", typeof(int));
	tprogettosegview.defineColumn("progetto_budget", typeof(decimal));
	tprogettosegview.defineColumn("progetto_budgetcalcolato", typeof(decimal));
	tprogettosegview.defineColumn("progetto_budgetcalcolatodate", typeof(DateTime));
	tprogettosegview.defineColumn("progetto_capofilatxt", typeof(string));
	tprogettosegview.defineColumn("progetto_codiceidentificativo", typeof(string));
	tprogettosegview.defineColumn("progetto_contributo", typeof(decimal));
	tprogettosegview.defineColumn("progetto_contributoente", typeof(decimal));
	tprogettosegview.defineColumn("progetto_ct", typeof(DateTime),false);
	tprogettosegview.defineColumn("progetto_cu", typeof(string),false);
	tprogettosegview.defineColumn("progetto_cup", typeof(string));
	tprogettosegview.defineColumn("progetto_data", typeof(DateTime));
	tprogettosegview.defineColumn("progetto_datacontabile", typeof(DateTime));
	tprogettosegview.defineColumn("progetto_description", typeof(string));
	tprogettosegview.defineColumn("progetto_durata", typeof(int));
	tprogettosegview.defineColumn("progetto_finanziatoretxt", typeof(string));
	tprogettosegview.defineColumn("progetto_idduratakind", typeof(int));
	tprogettosegview.defineColumn("progetto_idprogettokind", typeof(int));
	tprogettosegview.defineColumn("progetto_idprogettostatuskind", typeof(int));
	tprogettosegview.defineColumn("progetto_idregistryprogfin", typeof(int));
	tprogettosegview.defineColumn("progetto_idregistryprogfinbando", typeof(int));
	tprogettosegview.defineColumn("progetto_lt", typeof(DateTime),false);
	tprogettosegview.defineColumn("progetto_lu", typeof(string),false);
	tprogettosegview.defineColumn("progetto_start", typeof(DateTime));
	tprogettosegview.defineColumn("progetto_stop", typeof(DateTime));
	tprogettosegview.defineColumn("progetto_title", typeof(string));
	tprogettosegview.defineColumn("progetto_totalbudget", typeof(decimal));
	tprogettosegview.defineColumn("progetto_totalcontributo", typeof(decimal));
	tprogettosegview.defineColumn("progetto_url", typeof(string));
	tprogettosegview.defineColumn("progettokind_title", typeof(string));
	tprogettosegview.defineColumn("progettostatuskind_title", typeof(string));
	tprogettosegview.defineColumn("registry_title", typeof(string));
	tprogettosegview.defineColumn("registryaziende_fin_title", typeof(string));
	tprogettosegview.defineColumn("registryaziende_title", typeof(string));
	tprogettosegview.defineColumn("registryprogfin_code", typeof(string));
	tprogettosegview.defineColumn("registryprogfin_title", typeof(string));
	tprogettosegview.defineColumn("registryprogfinbando_number", typeof(string));
	tprogettosegview.defineColumn("registryprogfinbando_scadenza", typeof(DateTime));
	tprogettosegview.defineColumn("registryprogfinbando_title", typeof(string));
	tprogettosegview.defineColumn("titolobreve", typeof(string));
	Tables.Add(tprogettosegview);
	tprogettosegview.defineKey("idprogetto");

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
	var cPar = new []{progettosegview.Columns["idprogetto"]};
	var cChild = new []{progettotimesheetprogetto.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettotimesheetprogetto_progettosegview_idprogetto",cPar,cChild,false));

	#endregion

}
}
}
