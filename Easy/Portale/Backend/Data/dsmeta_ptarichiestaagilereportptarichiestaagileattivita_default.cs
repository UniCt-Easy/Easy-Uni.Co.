
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
[System.Xml.Serialization.XmlRoot("dsmeta_ptarichiestaagilereportptarichiestaagileattivita_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ptarichiestaagilereportptarichiestaagileattivita_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagileattivitadefaultview 		=> (MetaTable)Tables["ptarichiestaagileattivitadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagilereportptarichiestaagileattivita 		=> (MetaTable)Tables["ptarichiestaagilereportptarichiestaagileattivita"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ptarichiestaagilereportptarichiestaagileattivita_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ptarichiestaagilereportptarichiestaagileattivita_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ptarichiestaagilereportptarichiestaagileattivita_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ptarichiestaagilereportptarichiestaagileattivita_default.xsd";

	#region create DataTables
	//////////////////// PTARICHIESTAAGILEATTIVITADEFAULTVIEW /////////////////////////////////
	var tptarichiestaagileattivitadefaultview= new MetaTable("ptarichiestaagileattivitadefaultview");
	tptarichiestaagileattivitadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tptarichiestaagileattivitadefaultview.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int),false);
	tptarichiestaagileattivitadefaultview.defineColumn("idptarichiestaagile", typeof(int),false);
	tptarichiestaagileattivitadefaultview.defineColumn("idptarichiestaagileattivita", typeof(int),false);
	tptarichiestaagileattivitadefaultview.defineColumn("perfvalutazionepersonaleobiettivo_completamento", typeof(decimal));
	tptarichiestaagileattivitadefaultview.defineColumn("perfvalutazionepersonaleobiettivo_description", typeof(string));
	tptarichiestaagileattivitadefaultview.defineColumn("perfvalutazionepersonaleobiettivo_note", typeof(string));
	tptarichiestaagileattivitadefaultview.defineColumn("perfvalutazionepersonaleobiettivo_peso", typeof(decimal));
	tptarichiestaagileattivitadefaultview.defineColumn("perfvalutazionepersonaleobiettivo_title", typeof(string));
	tptarichiestaagileattivitadefaultview.defineColumn("ptarichiestaagileattivita_ct", typeof(DateTime),false);
	tptarichiestaagileattivitadefaultview.defineColumn("ptarichiestaagileattivita_cu", typeof(string),false);
	tptarichiestaagileattivitadefaultview.defineColumn("ptarichiestaagileattivita_description", typeof(string));
	tptarichiestaagileattivitadefaultview.defineColumn("ptarichiestaagileattivita_lt", typeof(DateTime),false);
	tptarichiestaagileattivitadefaultview.defineColumn("ptarichiestaagileattivita_lu", typeof(string),false);
	Tables.Add(tptarichiestaagileattivitadefaultview);
	tptarichiestaagileattivitadefaultview.defineKey("idperfvalutazionepersonaleobiettivo", "idptarichiestaagile", "idptarichiestaagileattivita");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{ptarichiestaagileattivitadefaultview.Columns["idptarichiestaagileattivita"]};
	var cChild = new []{ptarichiestaagilereportptarichiestaagileattivita.Columns["idptarichiestaagileattivita"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagilereportptarichiestaagileattivita_ptarichiestaagileattivitadefaultview_idptarichiestaagileattivita",cPar,cChild,false));

	#endregion

}
}
}
