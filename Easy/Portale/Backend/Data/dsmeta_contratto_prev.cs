
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
[System.Xml.Serialization.XmlRoot("dsmeta_contratto_prev"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_contratto_prev: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramentodefaultview 		=> (MetaTable)Tables["inquadramentodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokinddefaultview 		=> (MetaTable)Tables["contrattokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contratto 		=> (MetaTable)Tables["contratto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_contratto_prev(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_contratto_prev (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_contratto_prev";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_contratto_prev.xsd";

	#region create DataTables
	//////////////////// INQUADRAMENTODEFAULTVIEW /////////////////////////////////
	var tinquadramentodefaultview= new MetaTable("inquadramentodefaultview");
	tinquadramentodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinquadramentodefaultview.defineColumn("idcontrattokind", typeof(int),false);
	tinquadramentodefaultview.defineColumn("idinquadramento", typeof(int),false);
	Tables.Add(tinquadramentodefaultview);
	tinquadramentodefaultview.defineKey("idcontrattokind", "idinquadramento");

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

	//////////////////// CONTRATTO /////////////////////////////////
	var tcontratto= new MetaTable("contratto");
	tcontratto.defineColumn("classe", typeof(int));
	tcontratto.defineColumn("ct", typeof(DateTime),false);
	tcontratto.defineColumn("cu", typeof(string),false);
	tcontratto.defineColumn("datarivalutazione", typeof(DateTime));
	tcontratto.defineColumn("estremibando", typeof(string));
	tcontratto.defineColumn("idcontratto", typeof(int),false);
	tcontratto.defineColumn("idcontrattokind", typeof(int),false);
	tcontratto.defineColumn("idinquadramento", typeof(int));
	tcontratto.defineColumn("idreg", typeof(int),false);
	tcontratto.defineColumn("lt", typeof(DateTime),false);
	tcontratto.defineColumn("lu", typeof(string),false);
	tcontratto.defineColumn("parttime", typeof(decimal));
	tcontratto.defineColumn("percentualesufondiateneo", typeof(decimal));
	tcontratto.defineColumn("scatto", typeof(int));
	tcontratto.defineColumn("start", typeof(DateTime),false);
	tcontratto.defineColumn("stop", typeof(DateTime));
	tcontratto.defineColumn("tempdef", typeof(string),false);
	tcontratto.defineColumn("tempindet", typeof(string),false);
	Tables.Add(tcontratto);
	tcontratto.defineKey("idcontratto", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{inquadramentodefaultview.Columns["idinquadramento"]};
	var cChild = new []{contratto.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_contratto_inquadramentodefaultview_idinquadramento",cPar,cChild,false));

	cPar = new []{contrattokinddefaultview.Columns["idcontrattokind"]};
	cChild = new []{inquadramentodefaultview.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_inquadramentodefaultview_contrattokinddefaultview_idcontrattokind",cPar,cChild,false));

	cPar = new []{contrattokinddefaultview.Columns["idcontrattokind"]};
	cChild = new []{contratto.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_contratto_contrattokinddefaultview_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
