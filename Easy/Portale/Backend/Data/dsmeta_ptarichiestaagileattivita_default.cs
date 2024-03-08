
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
[System.Xml.Serialization.XmlRoot("dsmeta_ptarichiestaagileattivita_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ptarichiestaagileattivita_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleobiettivodefaultview 		=> (MetaTable)Tables["perfvalutazionepersonaleobiettivodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaagileattivita 		=> (MetaTable)Tables["ptarichiestaagileattivita"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ptarichiestaagileattivita_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ptarichiestaagileattivita_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ptarichiestaagileattivita_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ptarichiestaagileattivita_default.xsd";

	#region create DataTables
	//////////////////// PERFVALUTAZIONEPERSONALEOBIETTIVODEFAULTVIEW /////////////////////////////////
	var tperfvalutazionepersonaleobiettivodefaultview= new MetaTable("perfvalutazionepersonaleobiettivodefaultview");
	tperfvalutazionepersonaleobiettivodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfvalutazionepersonaleobiettivodefaultview.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaleobiettivodefaultview.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int),false);
	Tables.Add(tperfvalutazionepersonaleobiettivodefaultview);
	tperfvalutazionepersonaleobiettivodefaultview.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleobiettivo");

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
	Tables.Add(tptarichiestaagileattivita);
	tptarichiestaagileattivita.defineKey("idperfvalutazionepersonaleobiettivo", "idptarichiestaagile", "idptarichiestaagileattivita");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfvalutazionepersonaleobiettivodefaultview.Columns["idperfvalutazionepersonaleobiettivo"]};
	var cChild = new []{ptarichiestaagileattivita.Columns["idperfvalutazionepersonaleobiettivo"]};
	Relations.Add(new DataRelation("FK_ptarichiestaagileattivita_perfvalutazionepersonaleobiettivodefaultview_idperfvalutazionepersonaleobiettivo",cPar,cChild,false));

	#endregion

}
}
}
