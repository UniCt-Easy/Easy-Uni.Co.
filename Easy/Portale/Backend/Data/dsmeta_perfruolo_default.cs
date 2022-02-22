
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfruolo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfruolo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettivokind 		=> (MetaTable)Tables["perfobiettivokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruoloperfobiettivokind 		=> (MetaTable)Tables["perfruoloperfobiettivokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolocontrattokind 		=> (MetaTable)Tables["perfruolocontrattokind"];

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

	//////////////////// PERFRUOLOCONTRATTOKIND /////////////////////////////////
	var tperfruolocontrattokind= new MetaTable("perfruolocontrattokind");
	tperfruolocontrattokind.defineColumn("ct", typeof(DateTime));
	tperfruolocontrattokind.defineColumn("cu", typeof(string));
	tperfruolocontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tperfruolocontrattokind.defineColumn("idperfruolo", typeof(string),false);
	tperfruolocontrattokind.defineColumn("lt", typeof(DateTime));
	tperfruolocontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tperfruolocontrattokind);
	tperfruolocontrattokind.defineKey("idcontrattokind", "idperfruolo");

	//////////////////// PERFRUOLO /////////////////////////////////
	var tperfruolo= new MetaTable("perfruolo");
	tperfruolo.defineColumn("aggiorna", typeof(string));
	tperfruolo.defineColumn("crea", typeof(string));
	tperfruolo.defineColumn("ct", typeof(DateTime),false);
	tperfruolo.defineColumn("cu", typeof(string),false);
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
	var cChild = new []{perfruoloperfobiettivokind.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_perfruoloperfobiettivokind_perfruolo_idperfruolo",cPar,cChild,false));

	cPar = new []{perfobiettivokind.Columns["idperfobiettivokind"]};
	cChild = new []{perfruoloperfobiettivokind.Columns["idperfobiettivokind"]};
	Relations.Add(new DataRelation("FK_perfruoloperfobiettivokind_perfobiettivokind_idperfobiettivokind",cPar,cChild,false));

	cPar = new []{perfruolo.Columns["idperfruolo"]};
	cChild = new []{perfruolocontrattokind.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_perfruolocontrattokind_perfruolo_idperfruolo",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{perfruolocontrattokind.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_perfruolocontrattokind_contrattokind_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
