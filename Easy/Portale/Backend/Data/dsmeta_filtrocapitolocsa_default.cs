/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_filtrocapitolocsa_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_filtrocapitolocsa_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable capitolocsa 		=> (MetaTable)Tables["capitolocsa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable filtrocapitolocsacapitolocsa 		=> (MetaTable)Tables["filtrocapitolocsacapitolocsa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable filtrocapitolocsaposition 		=> (MetaTable)Tables["filtrocapitolocsaposition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable filtrocapitolocsa 		=> (MetaTable)Tables["filtrocapitolocsa"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_filtrocapitolocsa_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_filtrocapitolocsa_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_filtrocapitolocsa_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_filtrocapitolocsa_default.xsd";

	#region create DataTables
	//////////////////// CAPITOLOCSA /////////////////////////////////
	var tcapitolocsa= new MetaTable("capitolocsa");
	tcapitolocsa.defineColumn("idcapitolocsa", typeof(string),false);
	Tables.Add(tcapitolocsa);
	tcapitolocsa.defineKey("idcapitolocsa");

	//////////////////// FILTROCAPITOLOCSACAPITOLOCSA /////////////////////////////////
	var tfiltrocapitolocsacapitolocsa= new MetaTable("filtrocapitolocsacapitolocsa");
	tfiltrocapitolocsacapitolocsa.defineColumn("ct", typeof(DateTime));
	tfiltrocapitolocsacapitolocsa.defineColumn("cu", typeof(string));
	tfiltrocapitolocsacapitolocsa.defineColumn("idcapitolocsa", typeof(string),false);
	tfiltrocapitolocsacapitolocsa.defineColumn("idfiltrocapitolocsa", typeof(int),false);
	tfiltrocapitolocsacapitolocsa.defineColumn("lt", typeof(DateTime));
	tfiltrocapitolocsacapitolocsa.defineColumn("lu", typeof(string));
	Tables.Add(tfiltrocapitolocsacapitolocsa);
	tfiltrocapitolocsacapitolocsa.defineKey("idcapitolocsa", "idfiltrocapitolocsa");

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

	//////////////////// FILTROCAPITOLOCSAPOSITION /////////////////////////////////
	var tfiltrocapitolocsaposition= new MetaTable("filtrocapitolocsaposition");
	tfiltrocapitolocsaposition.defineColumn("ct", typeof(DateTime));
	tfiltrocapitolocsaposition.defineColumn("cu", typeof(string));
	tfiltrocapitolocsaposition.defineColumn("idfiltrocapitolocsa", typeof(int),false);
	tfiltrocapitolocsaposition.defineColumn("idposition", typeof(int),false);
	tfiltrocapitolocsaposition.defineColumn("lt", typeof(DateTime));
	tfiltrocapitolocsaposition.defineColumn("lu", typeof(string));
	Tables.Add(tfiltrocapitolocsaposition);
	tfiltrocapitolocsaposition.defineKey("idfiltrocapitolocsa", "idposition");

	//////////////////// FILTROCAPITOLOCSA /////////////////////////////////
	var tfiltrocapitolocsa= new MetaTable("filtrocapitolocsa");
	tfiltrocapitolocsa.defineColumn("ct", typeof(DateTime));
	tfiltrocapitolocsa.defineColumn("cu", typeof(string));
	tfiltrocapitolocsa.defineColumn("description", typeof(string));
	tfiltrocapitolocsa.defineColumn("idfiltrocapitolocsa", typeof(int),false);
	tfiltrocapitolocsa.defineColumn("lt", typeof(DateTime));
	tfiltrocapitolocsa.defineColumn("lu", typeof(string));
	tfiltrocapitolocsa.defineColumn("title", typeof(string));
	Tables.Add(tfiltrocapitolocsa);
	tfiltrocapitolocsa.defineKey("idfiltrocapitolocsa");

	#endregion


	#region DataRelation creation
	var cPar = new []{filtrocapitolocsa.Columns["idfiltrocapitolocsa"]};
	var cChild = new []{filtrocapitolocsacapitolocsa.Columns["idfiltrocapitolocsa"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsacapitolocsa_filtrocapitolocsa_idfiltrocapitolocsa",cPar,cChild,false));

	cPar = new []{capitolocsa.Columns["idcapitolocsa"]};
	cChild = new []{filtrocapitolocsacapitolocsa.Columns["idcapitolocsa"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsacapitolocsa_capitolocsa_idcapitolocsa",cPar,cChild,false));

	cPar = new []{filtrocapitolocsa.Columns["idfiltrocapitolocsa"]};
	cChild = new []{filtrocapitolocsaposition.Columns["idfiltrocapitolocsa"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsaposition_filtrocapitolocsa_idfiltrocapitolocsa",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{filtrocapitolocsaposition.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsaposition_position_idposition",cPar,cChild,false));

	#endregion

}
}
}
