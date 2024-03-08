
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotipocostocontrattokind_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettotipocostocontrattokind_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable positiondefaultview 		=> (MetaTable)Tables["positiondefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostocontrattokind 		=> (MetaTable)Tables["progettotipocostocontrattokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotipocostocontrattokind_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotipocostocontrattokind_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotipocostocontrattokind_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotipocostocontrattokind_seg.xsd";

	#region create DataTables
	//////////////////// POSITIONDEFAULTVIEW /////////////////////////////////
	var tpositiondefaultview= new MetaTable("positiondefaultview");
	tpositiondefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpositiondefaultview.defineColumn("idposition", typeof(int),false);
	tpositiondefaultview.defineColumn("position_active", typeof(string));
	tpositiondefaultview.defineColumn("position_assegnoaggiuntivo", typeof(string));
	tpositiondefaultview.defineColumn("position_codeposition", typeof(string),false);
	tpositiondefaultview.defineColumn("position_costolordoannuo", typeof(decimal));
	tpositiondefaultview.defineColumn("position_costolordoannuooneri", typeof(decimal));
	tpositiondefaultview.defineColumn("position_ct", typeof(DateTime),false);
	tpositiondefaultview.defineColumn("position_cu", typeof(string),false);
	tpositiondefaultview.defineColumn("position_description", typeof(string),false);
	tpositiondefaultview.defineColumn("position_elementoperequativo", typeof(string));
	tpositiondefaultview.defineColumn("position_foreignclass", typeof(string));
	tpositiondefaultview.defineColumn("position_indennitadiateneo", typeof(string));
	tpositiondefaultview.defineColumn("position_indennitadiposizione", typeof(string));
	tpositiondefaultview.defineColumn("position_indvacancacontrattuale", typeof(string));
	tpositiondefaultview.defineColumn("position_livello", typeof(string));
	tpositiondefaultview.defineColumn("position_lt", typeof(DateTime),false);
	tpositiondefaultview.defineColumn("position_lu", typeof(string),false);
	tpositiondefaultview.defineColumn("position_maxincomeclass", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxcompitididatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxcompitididatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxdidatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxdidatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxgg", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxtempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremaxtempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremincompitididatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremincompitididatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremindidatempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremindidatempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_oremintempoparziale", typeof(int));
	tpositiondefaultview.defineColumn("position_oremintempopieno", typeof(int));
	tpositiondefaultview.defineColumn("position_orestraordinariemax", typeof(int));
	tpositiondefaultview.defineColumn("position_parttime", typeof(string));
	tpositiondefaultview.defineColumn("position_printingorder", typeof(int));
	tpositiondefaultview.defineColumn("position_puntiorganico", typeof(decimal));
	tpositiondefaultview.defineColumn("position_siglaesportazione", typeof(string));
	tpositiondefaultview.defineColumn("position_siglaimportazione", typeof(string));
	tpositiondefaultview.defineColumn("position_tempdef", typeof(string));
	tpositiondefaultview.defineColumn("position_tipoente", typeof(string));
	tpositiondefaultview.defineColumn("position_tipopersonale", typeof(string));
	tpositiondefaultview.defineColumn("position_totaletredicesima", typeof(string));
	tpositiondefaultview.defineColumn("position_tredicesimaindennitaintegrativaspeciale", typeof(string));
	tpositiondefaultview.defineColumn("title", typeof(string));
	Tables.Add(tpositiondefaultview);
	tpositiondefaultview.defineKey("idposition");

	//////////////////// PROGETTOTIPOCOSTOCONTRATTOKIND /////////////////////////////////
	var tprogettotipocostocontrattokind= new MetaTable("progettotipocostocontrattokind");
	tprogettotipocostocontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotipocostocontrattokind.defineColumn("cu", typeof(string));
	tprogettotipocostocontrattokind.defineColumn("idposition", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotipocostocontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostocontrattokind);
	tprogettotipocostocontrattokind.defineKey("idposition", "idprogetto", "idprogettotipocosto");

	#endregion


	#region DataRelation creation
	var cPar = new []{positiondefaultview.Columns["idposition"]};
	var cChild = new []{progettotipocostocontrattokind.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_progettotipocostocontrattokind_positiondefaultview_idposition",cPar,cChild,false));

	#endregion

}
}
}
