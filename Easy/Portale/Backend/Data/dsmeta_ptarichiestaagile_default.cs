
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
[System.Xml.Serialization.XmlRoot("dsmeta_ptarichiestaagile_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ptarichiestaagile_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagilereportptarichiestaagileattivita 		=> (MetaTable)Tables["ptarichiestaagilereportptarichiestaagileattivita"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagilereportstatus 		=> (MetaTable)Tables["ptarichiestaagilereportstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagilereport 		=> (MetaTable)Tables["ptarichiestaagilereport"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleobiettivo 		=> (MetaTable)Tables["perfvalutazionepersonaleobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagileattivita 		=> (MetaTable)Tables["ptarichiestaagileattivita"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenzaammview 		=> (MetaTable)Tables["afferenzaammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview 		=> (MetaTable)Tables["registryamministrativiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagile 		=> (MetaTable)Tables["ptarichiestaagile"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ptarichiestaagile_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ptarichiestaagile_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ptarichiestaagile_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ptarichiestaagile_default.xsd";

	#region create DataTables
	//////////////////// PTARICHIESTAAGILEREPORTPTARICHIESTAAGILEATTIVITA /////////////////////////////////
	var tptarichiestaagilereportptarichiestaagileattivita= new MetaTable("ptarichiestaagilereportptarichiestaagileattivita");
	tptarichiestaagilereportptarichiestaagileattivita.defineColumn("ct", typeof(DateTime),false);
	tptarichiestaagilereportptarichiestaagileattivita.defineColumn("cu", typeof(string),false);
	tptarichiestaagilereportptarichiestaagileattivita.defineColumn("idptarichiestaagile", typeof(int),false);
	tptarichiestaagilereportptarichiestaagileattivita.defineColumn("idptarichiestaagileattivita", typeof(int),false);
	tptarichiestaagilereportptarichiestaagileattivita.defineColumn("idptarichiestaagilereport", typeof(int),false);
	tptarichiestaagilereportptarichiestaagileattivita.defineColumn("lt", typeof(DateTime),false);
	tptarichiestaagilereportptarichiestaagileattivita.defineColumn("lu", typeof(string),false);
	Tables.Add(tptarichiestaagilereportptarichiestaagileattivita);
	tptarichiestaagilereportptarichiestaagileattivita.defineKey("idptarichiestaagile", "idptarichiestaagileattivita", "idptarichiestaagilereport");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PTARICHIESTAAGILEREPORTSTATUS /////////////////////////////////
	var tptarichiestaagilereportstatus= new MetaTable("ptarichiestaagilereportstatus");
	tptarichiestaagilereportstatus.defineColumn("idptarichiestaagilereportstatus", typeof(int),false);
	tptarichiestaagilereportstatus.defineColumn("title", typeof(string));
	Tables.Add(tptarichiestaagilereportstatus);
	tptarichiestaagilereportstatus.defineKey("idptarichiestaagilereportstatus");

	//////////////////// PTARICHIESTAAGILEREPORT /////////////////////////////////
	var tptarichiestaagilereport= new MetaTable("ptarichiestaagilereport");
	tptarichiestaagilereport.defineColumn("ct", typeof(DateTime),false);
	tptarichiestaagilereport.defineColumn("cu", typeof(string),false);
	tptarichiestaagilereport.defineColumn("data", typeof(DateTime));
	tptarichiestaagilereport.defineColumn("idptarichiestaagile", typeof(int),false);
	tptarichiestaagilereport.defineColumn("idptarichiestaagilereport", typeof(int),false);
	tptarichiestaagilereport.defineColumn("idptarichiestaagilereportstatus", typeof(int));
	tptarichiestaagilereport.defineColumn("lt", typeof(DateTime),false);
	tptarichiestaagilereport.defineColumn("lu", typeof(string),false);
	tptarichiestaagilereport.defineColumn("mese", typeof(int));
	tptarichiestaagilereport.defineColumn("protanno", typeof(int));
	tptarichiestaagilereport.defineColumn("protnumero", typeof(int));
	tptarichiestaagilereport.defineColumn("vistodir", typeof(string));
	tptarichiestaagilereport.defineColumn("vistoresp", typeof(string));
	tptarichiestaagilereport.defineColumn("vistoresptem", typeof(string));
	tptarichiestaagilereport.defineColumn("year", typeof(int));
	tptarichiestaagilereport.defineColumn("!idptarichiestaagilereportstatus_ptarichiestaagilereportstatus_title", typeof(string));
	tptarichiestaagilereport.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tptarichiestaagilereport);
	tptarichiestaagilereport.defineKey("idptarichiestaagile", "idptarichiestaagilereport");

	//////////////////// PERFVALUTAZIONEPERSONALEOBIETTIVO /////////////////////////////////
	var tperfvalutazionepersonaleobiettivo= new MetaTable("perfvalutazionepersonaleobiettivo");
	tperfvalutazionepersonaleobiettivo.defineColumn("completamento", typeof(decimal));
	tperfvalutazionepersonaleobiettivo.defineColumn("description", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("note", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("peso", typeof(decimal));
	tperfvalutazionepersonaleobiettivo.defineColumn("title", typeof(string));
	Tables.Add(tperfvalutazionepersonaleobiettivo);
	tperfvalutazionepersonaleobiettivo.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleobiettivo");

	//////////////////// PTARICHIESTAAGILEATTIVITA /////////////////////////////////
	var tptarichiestaagileattivita= new MetaTable("ptarichiestaagileattivita");
	tptarichiestaagileattivita.defineColumn("ct", typeof(DateTime),false);
	tptarichiestaagileattivita.defineColumn("cu", typeof(string),false);
	tptarichiestaagileattivita.defineColumn("description", typeof(string));
	tptarichiestaagileattivita.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int),false);
	tptarichiestaagileattivita.defineColumn("idptarichiestaagile", typeof(int),false);
	tptarichiestaagileattivita.defineColumn("idptarichiestaagileattivita", typeof(int),false);
	tptarichiestaagileattivita.defineColumn("lt", typeof(DateTime),false);
	tptarichiestaagileattivita.defineColumn("lu", typeof(string),false);
	tptarichiestaagileattivita.defineColumn("!idperfvalutazionepersonaleobiettivo_perfvalutazionepersonaleobiettivo_title", typeof(string));
	tptarichiestaagileattivita.defineColumn("!idperfvalutazionepersonaleobiettivo_perfvalutazionepersonaleobiettivo_description", typeof(string));
	tptarichiestaagileattivita.defineColumn("!idperfvalutazionepersonaleobiettivo_perfvalutazionepersonaleobiettivo_peso", typeof(decimal));
	tptarichiestaagileattivita.defineColumn("!idperfvalutazionepersonaleobiettivo_perfvalutazionepersonaleobiettivo_completamento", typeof(decimal));
	tptarichiestaagileattivita.defineColumn("!idperfvalutazionepersonaleobiettivo_perfvalutazionepersonaleobiettivo_note", typeof(string));
	tptarichiestaagileattivita.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tptarichiestaagileattivita);
	tptarichiestaagileattivita.defineKey("idperfvalutazionepersonaleobiettivo", "idptarichiestaagile", "idptarichiestaagileattivita");

	//////////////////// AFFERENZAAMMVIEW /////////////////////////////////
	var tafferenzaammview= new MetaTable("afferenzaammview");
	tafferenzaammview.defineColumn("afferenza_ct", typeof(DateTime),false);
	tafferenzaammview.defineColumn("afferenza_cu", typeof(string),false);
	tafferenzaammview.defineColumn("afferenza_idmansionekind", typeof(int));
	tafferenzaammview.defineColumn("afferenza_lt", typeof(DateTime),false);
	tafferenzaammview.defineColumn("afferenza_lu", typeof(string),false);
	tafferenzaammview.defineColumn("afferenza_start", typeof(DateTime));
	tafferenzaammview.defineColumn("afferenza_stop", typeof(DateTime));
	tafferenzaammview.defineColumn("dropdown_title", typeof(string),false);
	tafferenzaammview.defineColumn("idafferenza", typeof(int),false);
	tafferenzaammview.defineColumn("idreg", typeof(int),false);
	tafferenzaammview.defineColumn("idstruttura", typeof(int));
	tafferenzaammview.defineColumn("mansionekind_title", typeof(string));
	tafferenzaammview.defineColumn("struttura_paridstruttura", typeof(int));
	tafferenzaammview.defineColumn("struttura_title", typeof(string));
	tafferenzaammview.defineColumn("strutturaparent_title", typeof(string));
	Tables.Add(tafferenzaammview);
	tafferenzaammview.defineKey("idafferenza", "idreg");

	//////////////////// REGISTRYAMMINISTRATIVIVIEW /////////////////////////////////
	var tregistryamministrativiview= new MetaTable("registryamministrativiview");
	tregistryamministrativiview.defineColumn("dropdown_title", typeof(string),false);
	tregistryamministrativiview.defineColumn("idreg", typeof(int),false);
	tregistryamministrativiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistryamministrativiview);
	tregistryamministrativiview.defineKey("idreg");

	//////////////////// PTARICHIESTAAGILE /////////////////////////////////
	var tptarichiestaagile= new MetaTable("ptarichiestaagile");
	tptarichiestaagile.defineColumn("ct", typeof(DateTime),false);
	tptarichiestaagile.defineColumn("cu", typeof(string),false);
	tptarichiestaagile.defineColumn("idafferenza", typeof(int));
	tptarichiestaagile.defineColumn("idptarichiestaagile", typeof(int),false);
	tptarichiestaagile.defineColumn("idreg", typeof(int),false);
	tptarichiestaagile.defineColumn("lt", typeof(DateTime),false);
	tptarichiestaagile.defineColumn("lu", typeof(string),false);
	tptarichiestaagile.defineColumn("preavviso", typeof(int));
	tptarichiestaagile.defineColumn("protanno", typeof(int));
	tptarichiestaagile.defineColumn("protnumero", typeof(int));
	Tables.Add(tptarichiestaagile);
	tptarichiestaagile.defineKey("idptarichiestaagile", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{ptarichiestaagile.Columns["idptarichiestaagile"]};
	var cChild = new []{ptarichiestaagilereport.Columns["idptarichiestaagile"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagilereport_ptarichiestaagile_idptarichiestaagile",cPar,cChild,false));

	cPar = new []{ptarichiestaagilereport.Columns["idptarichiestaagile"], ptarichiestaagilereport.Columns["idptarichiestaagilereport"]};
	cChild = new []{ptarichiestaagilereportptarichiestaagileattivita.Columns["idptarichiestaagile"], ptarichiestaagilereportptarichiestaagileattivita.Columns["idptarichiestaagilereport"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagilereportptarichiestaagileattivita_ptarichiestaagilereport_idptarichiestaagile-idptarichiestaagilereport",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{ptarichiestaagilereport.Columns["year"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagilereport_year_year",cPar,cChild,false));

	cPar = new []{ptarichiestaagilereportstatus.Columns["idptarichiestaagilereportstatus"]};
	cChild = new []{ptarichiestaagilereport.Columns["idptarichiestaagilereportstatus"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagilereport_ptarichiestaagilereportstatus_idptarichiestaagilereportstatus",cPar,cChild,false));

	cPar = new []{ptarichiestaagile.Columns["idptarichiestaagile"]};
	cChild = new []{ptarichiestaagileattivita.Columns["idptarichiestaagile"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagileattivita_ptarichiestaagile_idptarichiestaagile",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonaleobiettivo"]};
	cChild = new []{ptarichiestaagileattivita.Columns["idperfvalutazionepersonaleobiettivo"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagileattivita_perfvalutazionepersonaleobiettivo_idperfvalutazionepersonaleobiettivo",cPar,cChild,false));

	cPar = new []{afferenzaammview.Columns["idafferenza"]};
	cChild = new []{ptarichiestaagile.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagile_afferenzaammview_idafferenza",cPar,cChild,false));

	cPar = new []{registryamministrativiview.Columns["idreg"]};
	cChild = new []{ptarichiestaagile.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagile_registryamministrativiview_idreg",cPar,cChild,false));

	#endregion

}
}
}
