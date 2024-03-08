
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfruolo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfruolo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekind 		=> (MetaTable)Tables["mansionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolomansionekind 		=> (MetaTable)Tables["perfruolomansionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolocontrattokind 		=> (MetaTable)Tables["perfruolocontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettivokind 		=> (MetaTable)Tables["perfobiettivokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruoloperfobiettivokind 		=> (MetaTable)Tables["perfruoloperfobiettivokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolo 		=> (MetaTable)Tables["perfruolo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfruolo_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfruolo_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfruolo_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfruolo_default.xsd";

	#region create DataTables
	//////////////////// MANSIONEKIND /////////////////////////////////
	var tmansionekind= new MetaTable("mansionekind");
	tmansionekind.defineColumn("ct", typeof(DateTime),false);
	tmansionekind.defineColumn("cu", typeof(string),false);
	tmansionekind.defineColumn("generascheda", typeof(string));
	tmansionekind.defineColumn("idmansionekind", typeof(int),false);
	tmansionekind.defineColumn("lt", typeof(DateTime),false);
	tmansionekind.defineColumn("lu", typeof(string),false);
	tmansionekind.defineColumn("pesoateneo", typeof(decimal));
	tmansionekind.defineColumn("pesocomp", typeof(decimal));
	tmansionekind.defineColumn("pesoindividuale", typeof(decimal));
	tmansionekind.defineColumn("pesouo", typeof(decimal));
	tmansionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tmansionekind);
	tmansionekind.defineKey("idmansionekind");

	//////////////////// PERFRUOLOMANSIONEKIND /////////////////////////////////
	var tperfruolomansionekind= new MetaTable("perfruolomansionekind");
	tperfruolomansionekind.defineColumn("ct", typeof(DateTime),false);
	tperfruolomansionekind.defineColumn("cu", typeof(string),false);
	tperfruolomansionekind.defineColumn("idmansionekind", typeof(int),false);
	tperfruolomansionekind.defineColumn("idperfruolo", typeof(string),false);
	tperfruolomansionekind.defineColumn("lt", typeof(DateTime),false);
	tperfruolomansionekind.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfruolomansionekind);
	tperfruolomansionekind.defineKey("idmansionekind", "idperfruolo");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("assegnoaggiuntivo", typeof(string));
	tposition.defineColumn("codeposition", typeof(string),false);
	tposition.defineColumn("costolordoannuo", typeof(decimal));
	tposition.defineColumn("costolordoannuooneri", typeof(decimal));
	tposition.defineColumn("ct", typeof(DateTime),false);
	tposition.defineColumn("cu", typeof(string),false);
	tposition.defineColumn("description", typeof(string),false);
	tposition.defineColumn("elementoperequativo", typeof(string));
	tposition.defineColumn("foreignclass", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("indennitadiateneo", typeof(string));
	tposition.defineColumn("indennitadiposizione", typeof(string));
	tposition.defineColumn("indvacancacontrattuale", typeof(string));
	tposition.defineColumn("livello", typeof(string));
	tposition.defineColumn("lt", typeof(DateTime),false);
	tposition.defineColumn("lu", typeof(string),false);
	tposition.defineColumn("maxincomeclass", typeof(int));
	tposition.defineColumn("oremaxcompitididatempoparziale", typeof(int));
	tposition.defineColumn("oremaxcompitididatempopieno", typeof(int));
	tposition.defineColumn("oremaxdidatempoparziale", typeof(int));
	tposition.defineColumn("oremaxdidatempopieno", typeof(int));
	tposition.defineColumn("oremaxgg", typeof(int));
	tposition.defineColumn("oremaxtempoparziale", typeof(int));
	tposition.defineColumn("oremaxtempopieno", typeof(int));
	tposition.defineColumn("oremincompitididatempoparziale", typeof(int));
	tposition.defineColumn("oremincompitididatempopieno", typeof(int));
	tposition.defineColumn("oremindidatempoparziale", typeof(int));
	tposition.defineColumn("oremindidatempopieno", typeof(int));
	tposition.defineColumn("oremintempoparziale", typeof(int));
	tposition.defineColumn("oremintempopieno", typeof(int));
	tposition.defineColumn("orestraordinariemax", typeof(int));
	tposition.defineColumn("parttime", typeof(string));
	tposition.defineColumn("printingorder", typeof(int));
	tposition.defineColumn("puntiorganico", typeof(decimal));
	tposition.defineColumn("siglaesportazione", typeof(string));
	tposition.defineColumn("siglaimportazione", typeof(string));
	tposition.defineColumn("tempdef", typeof(string));
	tposition.defineColumn("tipoente", typeof(string));
	tposition.defineColumn("tipopersonale", typeof(string));
	tposition.defineColumn("title", typeof(string));
	tposition.defineColumn("totaletredicesima", typeof(string));
	tposition.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// PERFRUOLOCONTRATTOKIND /////////////////////////////////
	var tperfruolocontrattokind= new MetaTable("perfruolocontrattokind");
	tperfruolocontrattokind.defineColumn("ct", typeof(DateTime));
	tperfruolocontrattokind.defineColumn("cu", typeof(string));
	tperfruolocontrattokind.defineColumn("idperfruolo", typeof(string),false);
	tperfruolocontrattokind.defineColumn("idposition", typeof(int),false);
	tperfruolocontrattokind.defineColumn("lt", typeof(DateTime));
	tperfruolocontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tperfruolocontrattokind);
	tperfruolocontrattokind.defineKey("idperfruolo", "idposition");

	//////////////////// PERFOBIETTIVOKIND /////////////////////////////////
	var tperfobiettivokind= new MetaTable("perfobiettivokind");
	tperfobiettivokind.defineColumn("active", typeof(string));
	tperfobiettivokind.defineColumn("ct", typeof(DateTime));
	tperfobiettivokind.defineColumn("cu", typeof(string));
	tperfobiettivokind.defineColumn("description", typeof(string));
	tperfobiettivokind.defineColumn("idperfobiettivokind", typeof(int),false);
	tperfobiettivokind.defineColumn("lt", typeof(DateTime));
	tperfobiettivokind.defineColumn("lu", typeof(string));
	tperfobiettivokind.defineColumn("title", typeof(string));
	Tables.Add(tperfobiettivokind);
	tperfobiettivokind.defineKey("idperfobiettivokind");

	//////////////////// PERFRUOLOPERFOBIETTIVOKIND /////////////////////////////////
	var tperfruoloperfobiettivokind= new MetaTable("perfruoloperfobiettivokind");
	tperfruoloperfobiettivokind.defineColumn("ct", typeof(DateTime));
	tperfruoloperfobiettivokind.defineColumn("cu", typeof(string));
	tperfruoloperfobiettivokind.defineColumn("idperfobiettivokind", typeof(int),false);
	tperfruoloperfobiettivokind.defineColumn("idperfruolo", typeof(string),false);
	tperfruoloperfobiettivokind.defineColumn("lt", typeof(DateTime));
	tperfruoloperfobiettivokind.defineColumn("lu", typeof(string));
	Tables.Add(tperfruoloperfobiettivokind);
	tperfruoloperfobiettivokind.defineKey("idperfobiettivokind", "idperfruolo");

	//////////////////// PERFRUOLO /////////////////////////////////
	var tperfruolo= new MetaTable("perfruolo");
	tperfruolo.defineColumn("aggiorna", typeof(string));
	tperfruolo.defineColumn("approva", typeof(string));
	tperfruolo.defineColumn("crea", typeof(string));
	tperfruolo.defineColumn("ct", typeof(DateTime),false);
	tperfruolo.defineColumn("cu", typeof(string),false);
	tperfruolo.defineColumn("escluso", typeof(string));
	tperfruolo.defineColumn("generascheda", typeof(string));
	tperfruolo.defineColumn("idperfruolo", typeof(string),false);
	tperfruolo.defineColumn("leggi", typeof(string));
	tperfruolo.defineColumn("lt", typeof(DateTime),false);
	tperfruolo.defineColumn("lu", typeof(string),false);
	tperfruolo.defineColumn("oper", typeof(string));
	tperfruolo.defineColumn("valuta", typeof(string));
	Tables.Add(tperfruolo);
	tperfruolo.defineKey("idperfruolo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfruolo.Columns["idperfruolo"]};
	var cChild = new []{perfruolomansionekind.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_perfruolomansionekind_perfruolo_idperfruolo",cPar,cChild,false));

	cPar = new []{mansionekind.Columns["idmansionekind"]};
	cChild = new []{perfruolomansionekind.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_perfruolomansionekind_mansionekind_idmansionekind",cPar,cChild,false));

	cPar = new []{perfruolo.Columns["idperfruolo"]};
	cChild = new []{perfruolocontrattokind.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_perfruolocontrattokind_perfruolo_idperfruolo",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{perfruolocontrattokind.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_perfruolocontrattokind_position_idposition",cPar,cChild,false));

	cPar = new []{perfruolo.Columns["idperfruolo"]};
	cChild = new []{perfruoloperfobiettivokind.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_perfruoloperfobiettivokind_perfruolo_idperfruolo",cPar,cChild,false));

	cPar = new []{perfobiettivokind.Columns["idperfobiettivokind"]};
	cChild = new []{perfruoloperfobiettivokind.Columns["idperfobiettivokind"]};
	Relations.Add(new DataRelation("FK_perfruoloperfobiettivokind_perfobiettivokind_idperfobiettivokind",cPar,cChild,false));

	#endregion

}
}
}
