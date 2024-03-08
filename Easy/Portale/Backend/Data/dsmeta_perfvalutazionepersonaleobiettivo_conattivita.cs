
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazionepersonaleobiettivo_conattivita"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazionepersonaleobiettivo_conattivita: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalesoglia 		=> (MetaTable)Tables["perfvalutazionepersonalesoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitaelenchiview 		=> (MetaTable)Tables["perfprogettoobiettivoattivitaelenchiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleobiettivo 		=> (MetaTable)Tables["perfvalutazionepersonaleobiettivo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazionepersonaleobiettivo_conattivita(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazionepersonaleobiettivo_conattivita (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazionepersonaleobiettivo_conattivita";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazionepersonaleobiettivo_conattivita.xsd";

	#region create DataTables
	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

	//////////////////// PERFVALUTAZIONEPERSONALESOGLIA /////////////////////////////////
	var tperfvalutazionepersonalesoglia= new MetaTable("perfvalutazionepersonalesoglia");
	tperfvalutazionepersonalesoglia.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonalesoglia.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonalesoglia.defineColumn("description", typeof(string));
	tperfvalutazionepersonalesoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfvalutazionepersonalesoglia.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonalesoglia.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int),false);
	tperfvalutazionepersonalesoglia.defineColumn("idperfvalutazionepersonalesoglia", typeof(int),false);
	tperfvalutazionepersonalesoglia.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonalesoglia.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonalesoglia.defineColumn("percentuale", typeof(decimal));
	tperfvalutazionepersonalesoglia.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfvalutazionepersonalesoglia);
	tperfvalutazionepersonalesoglia.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleobiettivo", "idperfvalutazionepersonalesoglia");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITAELENCHIVIEW /////////////////////////////////
	var tperfprogettoobiettivoattivitaelenchiview= new MetaTable("perfprogettoobiettivoattivitaelenchiview");
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("account_ayear", typeof(int));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("account_codeacc", typeof(string));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("account_title", typeof(string));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("idacc", typeof(string));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("idupb", typeof(string));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogetto_title", typeof(string));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivo_title", typeof(string));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_completamento", typeof(decimal));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_cu", typeof(string),false);
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_datafineeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_datafineprevista", typeof(DateTime));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_datainizioeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_datainizioprevista", typeof(DateTime));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_description", typeof(string));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_idreg", typeof(int));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_lu", typeof(string),false);
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_paridperfprogettoobiettivoattivita", typeof(int));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("perfprogettoobiettivoattivita_title", typeof(string));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("registry_title", typeof(string));
	tperfprogettoobiettivoattivitaelenchiview.defineColumn("upb_title", typeof(string));
	Tables.Add(tperfprogettoobiettivoattivitaelenchiview);
	tperfprogettoobiettivoattivitaelenchiview.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// PERFVALUTAZIONEPERSONALEOBIETTIVO /////////////////////////////////
	var tperfvalutazionepersonaleobiettivo= new MetaTable("perfvalutazionepersonaleobiettivo");
	tperfvalutazionepersonaleobiettivo.defineColumn("completamento", typeof(decimal));
	tperfvalutazionepersonaleobiettivo.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("description", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfprogettoobiettivoattivita", typeof(int));
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("inverso", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("note", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("peso", typeof(decimal));
	tperfvalutazionepersonaleobiettivo.defineColumn("title", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfvalutazionepersonaleobiettivo);
	tperfvalutazionepersonaleobiettivo.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleobiettivo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"], perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonaleobiettivo"]};
	var cChild = new []{perfvalutazionepersonalesoglia.Columns["idperfvalutazionepersonale"], perfvalutazionepersonalesoglia.Columns["idperfvalutazionepersonaleobiettivo"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalesoglia_perfvalutazionepersonaleobiettivo_idperfvalutazionepersonale-idperfvalutazionepersonaleobiettivo",cPar,cChild,false));

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfvalutazionepersonalesoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalesoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivitaelenchiview.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfvalutazionepersonaleobiettivo.Columns["idperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleobiettivo_perfprogettoobiettivoattivitaelenchiview_idperfprogettoobiettivoattivita",cPar,cChild,false));

	#endregion

}
}
}
