
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_serviziopreruoloinps_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_serviziopreruoloinps_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tiponominadefaultview 		=> (MetaTable)Tables["tiponominadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsualedefaultview 		=> (MetaTable)Tables["classconsorsualedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable positiondefaultview 		=> (MetaTable)Tables["positiondefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziopreruoloinps 		=> (MetaTable)Tables["serviziopreruoloinps"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_serviziopreruoloinps_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_serviziopreruoloinps_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_serviziopreruoloinps_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_serviziopreruoloinps_default.xsd";

	#region create DataTables
	//////////////////// TIPONOMINADEFAULTVIEW /////////////////////////////////
	var ttiponominadefaultview= new MetaTable("tiponominadefaultview");
	ttiponominadefaultview.defineColumn("dropdown_title", typeof(string),false);
	ttiponominadefaultview.defineColumn("idtiponomina", typeof(int),false);
	ttiponominadefaultview.defineColumn("tiponomina_active", typeof(string));
	ttiponominadefaultview.defineColumn("tiponomina_ct", typeof(DateTime),false);
	ttiponominadefaultview.defineColumn("tiponomina_cu", typeof(string),false);
	ttiponominadefaultview.defineColumn("tiponomina_description", typeof(string));
	ttiponominadefaultview.defineColumn("tiponomina_lt", typeof(DateTime),false);
	ttiponominadefaultview.defineColumn("tiponomina_lu", typeof(string),false);
	ttiponominadefaultview.defineColumn("tiponomina_sortcode", typeof(int));
	ttiponominadefaultview.defineColumn("title", typeof(string));
	Tables.Add(ttiponominadefaultview);
	ttiponominadefaultview.defineKey("idtiponomina");

	//////////////////// CLASSCONSORSUALEDEFAULTVIEW /////////////////////////////////
	var tclassconsorsualedefaultview= new MetaTable("classconsorsualedefaultview");
	tclassconsorsualedefaultview.defineColumn("classconsorsuale_active", typeof(string));
	tclassconsorsualedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tclassconsorsualedefaultview.defineColumn("idclassconsorsuale", typeof(int),false);
	Tables.Add(tclassconsorsualedefaultview);
	tclassconsorsualedefaultview.defineKey("idclassconsorsuale");

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

	//////////////////// SERVIZIOPRERUOLOINPS /////////////////////////////////
	var tserviziopreruoloinps= new MetaTable("serviziopreruoloinps");
	tserviziopreruoloinps.defineColumn("anni", typeof(int));
	tserviziopreruoloinps.defineColumn("annokind", typeof(string));
	tserviziopreruoloinps.defineColumn("cedolini", typeof(string));
	tserviziopreruoloinps.defineColumn("ct", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("cu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("giorni", typeof(int));
	tserviziopreruoloinps.defineColumn("idclassconsorsuale", typeof(int));
	tserviziopreruoloinps.defineColumn("idposition", typeof(int));
	tserviziopreruoloinps.defineColumn("idreg", typeof(int),false);
	tserviziopreruoloinps.defineColumn("idserviziopreruoloinps", typeof(int),false);
	tserviziopreruoloinps.defineColumn("idtiponomina", typeof(int));
	tserviziopreruoloinps.defineColumn("istituzione", typeof(string));
	tserviziopreruoloinps.defineColumn("lt", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("lu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("mesi", typeof(int));
	tserviziopreruoloinps.defineColumn("start", typeof(DateTime));
	tserviziopreruoloinps.defineColumn("stop", typeof(DateTime));
	Tables.Add(tserviziopreruoloinps);
	tserviziopreruoloinps.defineKey("idreg", "idserviziopreruoloinps");

	#endregion


	#region DataRelation creation
	var cPar = new []{tiponominadefaultview.Columns["idtiponomina"]};
	var cChild = new []{serviziopreruoloinps.Columns["idtiponomina"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_tiponominadefaultview_idtiponomina",cPar,cChild,false));

	cPar = new []{classconsorsualedefaultview.Columns["idclassconsorsuale"]};
	cChild = new []{serviziopreruoloinps.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_classconsorsualedefaultview_idclassconsorsuale",cPar,cChild,false));

	cPar = new []{positiondefaultview.Columns["idposition"]};
	cChild = new []{serviziopreruoloinps.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_positiondefaultview_idposition",cPar,cChild,false));

	#endregion

}
}
}
