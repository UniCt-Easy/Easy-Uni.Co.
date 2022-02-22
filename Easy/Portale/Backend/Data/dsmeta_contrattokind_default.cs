
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
[System.Xml.Serialization.XmlRoot("dsmeta_contrattokind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_contrattokind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendio 		=> (MetaTable)Tables["stipendio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramento 		=> (MetaTable)Tables["inquadramento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokindposition 		=> (MetaTable)Tables["contrattokindposition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokindperiodo 		=> (MetaTable)Tables["contrattokindperiodo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_contrattokind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_contrattokind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_contrattokind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_contrattokind_default.xsd";

	#region create DataTables
	//////////////////// STIPENDIO /////////////////////////////////
	var tstipendio= new MetaTable("stipendio");
	tstipendio.defineColumn("!previdenza", typeof(decimal));
	tstipendio.defineColumn("!tesoro", typeof(decimal));
	tstipendio.defineColumn("!totalece", typeof(decimal));
	tstipendio.defineColumn("!tredicesima", typeof(decimal));
	tstipendio.defineColumn("assegno", typeof(decimal));
	tstipendio.defineColumn("classe", typeof(int));
	tstipendio.defineColumn("ct", typeof(DateTime));
	tstipendio.defineColumn("cu", typeof(string));
	tstipendio.defineColumn("idcontrattokind", typeof(int),false);
	tstipendio.defineColumn("idinquadramento", typeof(int),false);
	tstipendio.defineColumn("idstipendio", typeof(int),false);
	tstipendio.defineColumn("iis", typeof(decimal));
	tstipendio.defineColumn("irap", typeof(decimal));
	tstipendio.defineColumn("lordo", typeof(decimal));
	tstipendio.defineColumn("lt", typeof(DateTime));
	tstipendio.defineColumn("lu", typeof(string));
	tstipendio.defineColumn("scatto", typeof(int));
	tstipendio.defineColumn("siglaimportazione", typeof(string));
	tstipendio.defineColumn("stipendio", typeof(decimal));
	tstipendio.defineColumn("totale", typeof(decimal));
	Tables.Add(tstipendio);
	tstipendio.defineKey("idcontrattokind", "idinquadramento", "idstipendio");

	//////////////////// INQUADRAMENTO /////////////////////////////////
	var tinquadramento= new MetaTable("inquadramento");
	tinquadramento.defineColumn("costolordoannuo", typeof(decimal));
	tinquadramento.defineColumn("costolordoannuooneri", typeof(decimal));
	tinquadramento.defineColumn("ct", typeof(DateTime),false);
	tinquadramento.defineColumn("cu", typeof(string),false);
	tinquadramento.defineColumn("idcontrattokind", typeof(int),false);
	tinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tinquadramento.defineColumn("lt", typeof(DateTime),false);
	tinquadramento.defineColumn("lu", typeof(string),false);
	tinquadramento.defineColumn("siglaimportazione", typeof(string));
	tinquadramento.defineColumn("start", typeof(DateTime));
	tinquadramento.defineColumn("stop", typeof(DateTime));
	tinquadramento.defineColumn("tempdef", typeof(string));
	tinquadramento.defineColumn("title", typeof(string));
	Tables.Add(tinquadramento);
	tinquadramento.defineKey("idcontrattokind", "idinquadramento");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("codeposition", typeof(string),false);
	tposition.defineColumn("ct", typeof(DateTime),false);
	tposition.defineColumn("cu", typeof(string),false);
	tposition.defineColumn("description", typeof(string),false);
	tposition.defineColumn("foreignclass", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("lt", typeof(DateTime),false);
	tposition.defineColumn("lu", typeof(string),false);
	tposition.defineColumn("maxincomeclass", typeof(int));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// CONTRATTOKINDPOSITION /////////////////////////////////
	var tcontrattokindposition= new MetaTable("contrattokindposition");
	tcontrattokindposition.defineColumn("ct", typeof(DateTime),false);
	tcontrattokindposition.defineColumn("cu", typeof(string),false);
	tcontrattokindposition.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokindposition.defineColumn("idposition", typeof(int),false);
	tcontrattokindposition.defineColumn("lt", typeof(DateTime),false);
	tcontrattokindposition.defineColumn("lu", typeof(string),false);
	Tables.Add(tcontrattokindposition);
	tcontrattokindposition.defineKey("idcontrattokind", "idposition");

	//////////////////// CONTRATTOKINDPERIODO /////////////////////////////////
	var tcontrattokindperiodo= new MetaTable("contrattokindperiodo");
	tcontrattokindperiodo.defineColumn("ct", typeof(DateTime));
	tcontrattokindperiodo.defineColumn("cu", typeof(string));
	tcontrattokindperiodo.defineColumn("datafrom", typeof(DateTime));
	tcontrattokindperiodo.defineColumn("datato", typeof(DateTime));
	tcontrattokindperiodo.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokindperiodo.defineColumn("idcontrattokindperiodo", typeof(int),false);
	tcontrattokindperiodo.defineColumn("lt", typeof(DateTime));
	tcontrattokindperiodo.defineColumn("lu", typeof(string));
	Tables.Add(tcontrattokindperiodo);
	tcontrattokindperiodo.defineKey("idcontrattokind", "idcontrattokindperiodo");

	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("active", typeof(string),false);
	tcontrattokind.defineColumn("assegnoaggiuntivo", typeof(string));
	tcontrattokind.defineColumn("costolordoannuo", typeof(decimal));
	tcontrattokind.defineColumn("costolordoannuooneri", typeof(decimal));
	tcontrattokind.defineColumn("ct", typeof(DateTime),false);
	tcontrattokind.defineColumn("cu", typeof(string),false);
	tcontrattokind.defineColumn("description", typeof(string));
	tcontrattokind.defineColumn("elementoperequativo", typeof(string));
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("indennitadiateneo", typeof(string));
	tcontrattokind.defineColumn("indennitadiposizione", typeof(string));
	tcontrattokind.defineColumn("indvacancacontrattuale", typeof(string));
	tcontrattokind.defineColumn("lt", typeof(DateTime),false);
	tcontrattokind.defineColumn("lu", typeof(string),false);
	tcontrattokind.defineColumn("oremaxcompitididatempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremaxcompitididatempopieno", typeof(int));
	tcontrattokind.defineColumn("oremaxdidatempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremaxdidatempopieno", typeof(int));
	tcontrattokind.defineColumn("oremaxgg", typeof(int));
	tcontrattokind.defineColumn("oremaxtempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremaxtempopieno", typeof(int));
	tcontrattokind.defineColumn("oremincompitididatempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremincompitididatempopieno", typeof(int));
	tcontrattokind.defineColumn("oremindidatempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremindidatempopieno", typeof(int));
	tcontrattokind.defineColumn("oremintempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremintempopieno", typeof(int));
	tcontrattokind.defineColumn("orestraordinariemax", typeof(int));
	tcontrattokind.defineColumn("parttime", typeof(string));
	tcontrattokind.defineColumn("puntiorganico", typeof(decimal));
	tcontrattokind.defineColumn("scatto", typeof(string));
	tcontrattokind.defineColumn("siglaesportazione", typeof(string));
	tcontrattokind.defineColumn("siglaimportazione", typeof(string));
	tcontrattokind.defineColumn("sortcode", typeof(int),false);
	tcontrattokind.defineColumn("tempdef", typeof(string));
	tcontrattokind.defineColumn("title", typeof(string),false);
	tcontrattokind.defineColumn("totaletredicesima", typeof(string));
	tcontrattokind.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(string));
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{contrattokind.Columns["idcontrattokind"]};
	var cChild = new []{inquadramento.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_inquadramento_contrattokind_idcontrattokind",cPar,cChild,false));

	cPar = new []{inquadramento.Columns["idcontrattokind"], inquadramento.Columns["idinquadramento"]};
	cChild = new []{stipendio.Columns["idcontrattokind"], stipendio.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_stipendio_inquadramento_idcontrattokind-idinquadramento",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{contrattokindposition.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_contrattokindposition_contrattokind_idcontrattokind",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{contrattokindposition.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_contrattokindposition_position_idposition",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{contrattokindperiodo.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_contrattokindperiodo_contrattokind_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
