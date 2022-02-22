
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotipocostokindcontrattokind_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettotipocostokindcontrattokind_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokinddefaultview 		=> (MetaTable)Tables["contrattokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindcontrattokind 		=> (MetaTable)Tables["progettotipocostokindcontrattokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotipocostokindcontrattokind_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotipocostokindcontrattokind_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotipocostokindcontrattokind_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotipocostokindcontrattokind_seg.xsd";

	#region create DataTables
	//////////////////// CONTRATTOKINDDEFAULTVIEW /////////////////////////////////
	var tcontrattokinddefaultview= new MetaTable("contrattokinddefaultview");
	tcontrattokinddefaultview.defineColumn("contrattokind_active", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_assegnoaggiuntivo", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_costolordoannuo", typeof(decimal));
	tcontrattokinddefaultview.defineColumn("contrattokind_costolordoannuooneri", typeof(decimal));
	tcontrattokinddefaultview.defineColumn("contrattokind_ct", typeof(DateTime),false);
	tcontrattokinddefaultview.defineColumn("contrattokind_cu", typeof(string),false);
	tcontrattokinddefaultview.defineColumn("contrattokind_description", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_elementoperequativo", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_indennitadiateneo", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_indennitadiposizione", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_indvacancacontrattuale", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_lt", typeof(DateTime),false);
	tcontrattokinddefaultview.defineColumn("contrattokind_lu", typeof(string),false);
	tcontrattokinddefaultview.defineColumn("contrattokind_oremaxcompitididatempoparziale", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremaxcompitididatempopieno", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremaxdidatempoparziale", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremaxdidatempopieno", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremaxgg", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremaxtempoparziale", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremaxtempopieno", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremincompitididatempoparziale", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremincompitididatempopieno", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremindidatempoparziale", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremindidatempopieno", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremintempoparziale", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_oremintempopieno", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_orestraordinariemax", typeof(int));
	tcontrattokinddefaultview.defineColumn("contrattokind_parttime", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_puntiorganico", typeof(decimal));
	tcontrattokinddefaultview.defineColumn("contrattokind_scatto", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_siglaesportazione", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_siglaimportazione", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_sortcode", typeof(int),false);
	tcontrattokinddefaultview.defineColumn("contrattokind_tempdef", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_totaletredicesima", typeof(string));
	tcontrattokinddefaultview.defineColumn("contrattokind_tredicesimaindennitaintegrativaspeciale", typeof(string));
	tcontrattokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcontrattokinddefaultview.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokinddefaultview);
	tcontrattokinddefaultview.defineKey("idcontrattokind");

	//////////////////// PROGETTOTIPOCOSTOKINDCONTRATTOKIND /////////////////////////////////
	var tprogettotipocostokindcontrattokind= new MetaTable("progettotipocostokindcontrattokind");
	tprogettotipocostokindcontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokindcontrattokind.defineColumn("cu", typeof(string));
	tprogettotipocostokindcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tprogettotipocostokindcontrattokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindcontrattokind.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindcontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokindcontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostokindcontrattokind);
	tprogettotipocostokindcontrattokind.defineKey("idcontrattokind", "idprogettokind", "idprogettotipocostokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{contrattokinddefaultview.Columns["idcontrattokind"]};
	var cChild = new []{progettotipocostokindcontrattokind.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindcontrattokind_contrattokinddefaultview_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
