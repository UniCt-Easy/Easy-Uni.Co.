
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
[System.Xml.Serialization.XmlRoot("dsmeta_ptarichiestaagilereport_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ptarichiestaagilereport_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleobiettivo 		=> (MetaTable)Tables["perfvalutazionepersonaleobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagileattivita 		=> (MetaTable)Tables["ptarichiestaagileattivita"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagilereportptarichiestaagileattivita 		=> (MetaTable)Tables["ptarichiestaagilereportptarichiestaagileattivita"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagilereportstatus 		=> (MetaTable)Tables["ptarichiestaagilereportstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagilereport 		=> (MetaTable)Tables["ptarichiestaagilereport"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ptarichiestaagilereport_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ptarichiestaagilereport_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ptarichiestaagilereport_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ptarichiestaagilereport_default.xsd";

	#region create DataTables
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
	Tables.Add(tptarichiestaagileattivita);
	tptarichiestaagileattivita.defineKey("idperfvalutazionepersonaleobiettivo", "idptarichiestaagile", "idptarichiestaagileattivita");

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

	//////////////////// PTARICHIESTAAGILEREPORTSTATUS /////////////////////////////////
	var tptarichiestaagilereportstatus= new MetaTable("ptarichiestaagilereportstatus");
	tptarichiestaagilereportstatus.defineColumn("idptarichiestaagilereportstatus", typeof(int),false);
	tptarichiestaagilereportstatus.defineColumn("title", typeof(string));
	Tables.Add(tptarichiestaagilereportstatus);
	tptarichiestaagilereportstatus.defineKey("idptarichiestaagilereportstatus");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

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
	Tables.Add(tptarichiestaagilereport);
	tptarichiestaagilereport.defineKey("idptarichiestaagile", "idptarichiestaagilereport");

	#endregion


	#region DataRelation creation
	var cPar = new []{ptarichiestaagilereport.Columns["idptarichiestaagile"], ptarichiestaagilereport.Columns["idptarichiestaagilereport"]};
	var cChild = new []{ptarichiestaagilereportptarichiestaagileattivita.Columns["idptarichiestaagile"], ptarichiestaagilereportptarichiestaagileattivita.Columns["idptarichiestaagilereport"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagilereportptarichiestaagileattivita_ptarichiestaagilereport_idptarichiestaagile-idptarichiestaagilereport",cPar,cChild,false));

	cPar = new []{ptarichiestaagileattivita.Columns["idptarichiestaagileattivita"]};
	cChild = new []{ptarichiestaagilereportptarichiestaagileattivita.Columns["idptarichiestaagileattivita"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagilereportptarichiestaagileattivita_ptarichiestaagileattivita_idptarichiestaagileattivita",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonaleobiettivo"]};
	cChild = new []{ptarichiestaagileattivita.Columns["idperfvalutazionepersonaleobiettivo"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagileattivita_perfvalutazionepersonaleobiettivo_idperfvalutazionepersonaleobiettivo",cPar,cChild,false));

	cPar = new []{ptarichiestaagilereportstatus.Columns["idptarichiestaagilereportstatus"]};
	cChild = new []{ptarichiestaagilereport.Columns["idptarichiestaagilereportstatus"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagilereport_ptarichiestaagilereportstatus_idptarichiestaagilereportstatus",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{ptarichiestaagilereport.Columns["year"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagilereport_year_year",cPar,cChild,false));

	#endregion

}
}
}
