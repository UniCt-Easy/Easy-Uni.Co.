
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
[System.Xml.Serialization.XmlRoot("dsmeta_stipendiokind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_stipendiokind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramentodefaultview 		=> (MetaTable)Tables["inquadramentodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokinddefaultview 		=> (MetaTable)Tables["contrattokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendiokind 		=> (MetaTable)Tables["stipendiokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_stipendiokind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_stipendiokind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_stipendiokind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_stipendiokind_default.xsd";

	#region create DataTables
	//////////////////// INQUADRAMENTODEFAULTVIEW /////////////////////////////////
	var tinquadramentodefaultview= new MetaTable("inquadramentodefaultview");
	tinquadramentodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinquadramentodefaultview.defineColumn("idcontrattokind", typeof(int),false);
	tinquadramentodefaultview.defineColumn("idinquadramento", typeof(int),false);
	Tables.Add(tinquadramentodefaultview);
	tinquadramentodefaultview.defineKey("idinquadramento");

	//////////////////// CONTRATTOKINDDEFAULTVIEW /////////////////////////////////
	var tcontrattokinddefaultview= new MetaTable("contrattokinddefaultview");
	tcontrattokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcontrattokinddefaultview.defineColumn("idcontrattokind", typeof(int),false);
	Tables.Add(tcontrattokinddefaultview);
	tcontrattokinddefaultview.defineKey("idcontrattokind");

	//////////////////// STIPENDIOKIND /////////////////////////////////
	var tstipendiokind= new MetaTable("stipendiokind");
	tstipendiokind.defineColumn("assegnoaggiuntivo", typeof(decimal));
	tstipendiokind.defineColumn("ct", typeof(DateTime),false);
	tstipendiokind.defineColumn("cu", typeof(string),false);
	tstipendiokind.defineColumn("elementoperequativo", typeof(decimal));
	tstipendiokind.defineColumn("idcontrattokind", typeof(int));
	tstipendiokind.defineColumn("idinquadramento", typeof(int));
	tstipendiokind.defineColumn("idstipendiokind", typeof(int),false);
	tstipendiokind.defineColumn("indennitadiateneo", typeof(decimal));
	tstipendiokind.defineColumn("indennitadiposizione", typeof(decimal));
	tstipendiokind.defineColumn("indintegrativaspeciale", typeof(decimal));
	tstipendiokind.defineColumn("indvacancacontrattuale", typeof(decimal));
	tstipendiokind.defineColumn("irap", typeof(decimal));
	tstipendiokind.defineColumn("lt", typeof(DateTime),false);
	tstipendiokind.defineColumn("lu", typeof(string),false);
	tstipendiokind.defineColumn("oneriprevidenzialicaricoente", typeof(decimal));
	tstipendiokind.defineColumn("retribuzione", typeof(decimal));
	tstipendiokind.defineColumn("scatto", typeof(string));
	tstipendiokind.defineColumn("tempdef", typeof(string));
	tstipendiokind.defineColumn("totaletredicesima", typeof(decimal));
	tstipendiokind.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(decimal));
	Tables.Add(tstipendiokind);
	tstipendiokind.defineKey("idstipendiokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{inquadramentodefaultview.Columns["idinquadramento"]};
	var cChild = new []{stipendiokind.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_stipendiokind_inquadramentodefaultview_idinquadramento",cPar,cChild,false));

	cPar = new []{contrattokinddefaultview.Columns["idcontrattokind"]};
	cChild = new []{stipendiokind.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_stipendiokind_contrattokinddefaultview_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
