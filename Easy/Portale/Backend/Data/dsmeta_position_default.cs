
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
[System.Xml.Serialization.XmlRoot("dsmeta_position_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_position_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendiocomplemento 		=> (MetaTable)Tables["stipendiocomplemento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendio 		=> (MetaTable)Tables["stipendio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramento 		=> (MetaTable)Tables["inquadramento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_position_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_position_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_position_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_position_default.xsd";

	#region create DataTables
	//////////////////// STIPENDIOCOMPLEMENTO /////////////////////////////////
	var tstipendiocomplemento= new MetaTable("stipendiocomplemento");
	tstipendiocomplemento.defineColumn("anzianitamax", typeof(int));
	tstipendiocomplemento.defineColumn("anzianitamin", typeof(int));
	tstipendiocomplemento.defineColumn("complementomensile", typeof(decimal));
	tstipendiocomplemento.defineColumn("idcontrattokind", typeof(int));
	tstipendiocomplemento.defineColumn("idinquadramento", typeof(int),false);
	tstipendiocomplemento.defineColumn("idposition", typeof(int),false);
	tstipendiocomplemento.defineColumn("idstipendiocomplemento", typeof(int),false);
	tstipendiocomplemento.defineColumn("idstipendiocomplementokind", typeof(int));
	tstipendiocomplemento.defineColumn("rifnormativo", typeof(string));
	tstipendiocomplemento.defineColumn("start", typeof(DateTime));
	tstipendiocomplemento.defineColumn("stop", typeof(DateTime));
	Tables.Add(tstipendiocomplemento);
	tstipendiocomplemento.defineKey("idinquadramento", "idposition", "idstipendiocomplemento");

	//////////////////// STIPENDIO /////////////////////////////////
	var tstipendio= new MetaTable("stipendio");
	tstipendio.defineColumn("!previdenza", typeof(decimal));
	tstipendio.defineColumn("!tesoro", typeof(decimal));
	tstipendio.defineColumn("!totalece", typeof(decimal));
	tstipendio.defineColumn("!tredicesima", typeof(decimal));
	tstipendio.defineColumn("anzianitamax", typeof(int));
	tstipendio.defineColumn("anzianitamin", typeof(int));
	tstipendio.defineColumn("assegno", typeof(decimal));
	tstipendio.defineColumn("classe", typeof(int));
	tstipendio.defineColumn("ct", typeof(DateTime));
	tstipendio.defineColumn("cu", typeof(string));
	tstipendio.defineColumn("elementoperequativo", typeof(decimal));
	tstipendio.defineColumn("idcontrattokind", typeof(int));
	tstipendio.defineColumn("idinquadramento", typeof(int),false);
	tstipendio.defineColumn("idposition", typeof(int),false);
	tstipendio.defineColumn("idstipendio", typeof(int),false);
	tstipendio.defineColumn("iis", typeof(decimal));
	tstipendio.defineColumn("indennitaateneo", typeof(decimal));
	tstipendio.defineColumn("indennitaposizioneminima", typeof(decimal));
	tstipendio.defineColumn("irap", typeof(decimal));
	tstipendio.defineColumn("lordo", typeof(decimal));
	tstipendio.defineColumn("lordonotredicesima", typeof(decimal));
	tstipendio.defineColumn("lt", typeof(DateTime));
	tstipendio.defineColumn("lu", typeof(string));
	tstipendio.defineColumn("rifnormativo", typeof(string));
	tstipendio.defineColumn("scatto", typeof(int));
	tstipendio.defineColumn("siglaimportazione", typeof(string));
	tstipendio.defineColumn("start", typeof(DateTime));
	tstipendio.defineColumn("stipendio", typeof(decimal));
	tstipendio.defineColumn("stop", typeof(DateTime));
	tstipendio.defineColumn("totale", typeof(decimal));
	Tables.Add(tstipendio);
	tstipendio.defineKey("idinquadramento", "idposition", "idstipendio");

	//////////////////// INQUADRAMENTO /////////////////////////////////
	var tinquadramento= new MetaTable("inquadramento");
	tinquadramento.defineColumn("costolordoannuo", typeof(decimal));
	tinquadramento.defineColumn("costolordoannuooneri", typeof(decimal));
	tinquadramento.defineColumn("ct", typeof(DateTime),false);
	tinquadramento.defineColumn("cu", typeof(string),false);
	tinquadramento.defineColumn("idcontrattokind", typeof(int));
	tinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tinquadramento.defineColumn("idposition", typeof(int),false);
	tinquadramento.defineColumn("lt", typeof(DateTime),false);
	tinquadramento.defineColumn("lu", typeof(string),false);
	tinquadramento.defineColumn("siglaimportazione", typeof(string));
	tinquadramento.defineColumn("start", typeof(DateTime));
	tinquadramento.defineColumn("stop", typeof(DateTime));
	tinquadramento.defineColumn("tempdef", typeof(string));
	tinquadramento.defineColumn("title", typeof(string));
	Tables.Add(tinquadramento);
	tinquadramento.defineKey("idinquadramento", "idposition");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{position.Columns["idposition"]};
	var cChild = new []{inquadramento.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_inquadramento_position_idposition",cPar,cChild,false));

	cPar = new []{inquadramento.Columns["idinquadramento"], inquadramento.Columns["idposition"]};
	cChild = new []{stipendiocomplemento.Columns["idinquadramento"], stipendiocomplemento.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_stipendiocomplemento_inquadramento_idinquadramento-idposition",cPar,cChild,false));

	cPar = new []{inquadramento.Columns["idinquadramento"], inquadramento.Columns["idposition"]};
	cChild = new []{stipendio.Columns["idinquadramento"], stipendio.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_stipendio_inquadramento_idinquadramento-idposition",cPar,cChild,false));

	#endregion

}
}
}
