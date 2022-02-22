
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
[System.Xml.Serialization.XmlRoot("dsmeta_contratto_amm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_contratto_amm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias1 		=> (MetaTable)Tables["year_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendioannuo 		=> (MetaTable)Tables["stipendioannuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese 		=> (MetaTable)Tables["mese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cedolino 		=> (MetaTable)Tables["cedolino"];

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
public dsmeta_contratto_amm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_contratto_amm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_contratto_amm";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_contratto_amm.xsd";

	#region create DataTables
	//////////////////// YEAR_ALIAS1 /////////////////////////////////
	var tyear_alias1= new MetaTable("year_alias1");
	tyear_alias1.defineColumn("year", typeof(int),false);
	tyear_alias1.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias1);
	tyear_alias1.defineKey("year");

	//////////////////// STIPENDIOANNUO /////////////////////////////////
	var tstipendioannuo= new MetaTable("stipendioannuo");
	tstipendioannuo.defineColumn("caricoente", typeof(decimal));
	tstipendioannuo.defineColumn("ct", typeof(DateTime));
	tstipendioannuo.defineColumn("cu", typeof(string));
	tstipendioannuo.defineColumn("idcontratto", typeof(int),false);
	tstipendioannuo.defineColumn("idreg", typeof(int),false);
	tstipendioannuo.defineColumn("idstipendioannuo", typeof(int),false);
	tstipendioannuo.defineColumn("irap", typeof(decimal));
	tstipendioannuo.defineColumn("lordo", typeof(decimal));
	tstipendioannuo.defineColumn("lt", typeof(DateTime));
	tstipendioannuo.defineColumn("lu", typeof(string));
	tstipendioannuo.defineColumn("totale", typeof(decimal));
	tstipendioannuo.defineColumn("year", typeof(int),false);
	Tables.Add(tstipendioannuo);
	tstipendioannuo.defineKey("idcontratto", "idreg", "idstipendioannuo", "year");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// MESE /////////////////////////////////
	var tmese= new MetaTable("mese");
	tmese.defineColumn("idmese", typeof(int),false);
	tmese.defineColumn("title", typeof(string));
	Tables.Add(tmese);
	tmese.defineKey("idmese");

	//////////////////// CEDOLINO /////////////////////////////////
	var tcedolino= new MetaTable("cedolino");
	tcedolino.defineColumn("!previdenza", typeof(decimal));
	tcedolino.defineColumn("!tesoro", typeof(decimal));
	tcedolino.defineColumn("!totalece", typeof(decimal));
	tcedolino.defineColumn("!tredicesima", typeof(decimal));
	tcedolino.defineColumn("assegno", typeof(decimal));
	tcedolino.defineColumn("classe", typeof(int));
	tcedolino.defineColumn("data", typeof(DateTime));
	tcedolino.defineColumn("idcedolino", typeof(int),false);
	tcedolino.defineColumn("idcontratto", typeof(int),false);
	tcedolino.defineColumn("idmese", typeof(int));
	tcedolino.defineColumn("idreg", typeof(int),false);
	tcedolino.defineColumn("iis", typeof(decimal));
	tcedolino.defineColumn("irap", typeof(decimal));
	tcedolino.defineColumn("lordo", typeof(decimal));
	tcedolino.defineColumn("scatto", typeof(int));
	tcedolino.defineColumn("stipendio", typeof(decimal));
	tcedolino.defineColumn("totale", typeof(decimal));
	tcedolino.defineColumn("year", typeof(int));
	tcedolino.defineColumn("!idmese_mese_title", typeof(string));
	Tables.Add(tcedolino);
	tcedolino.defineKey("idcedolino", "idcontratto", "idreg");

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
	var cPar = new []{contratto.Columns["idcontratto"], contratto.Columns["idreg"]};
	var cChild = new []{stipendioannuo.Columns["idcontratto"], stipendioannuo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_contratto_idcontratto-idreg",cPar,cChild,false));

	cPar = new []{year_alias1.Columns["year"]};
	cChild = new []{stipendioannuo.Columns["year"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_year_alias1_year",cPar,cChild,false));

	cPar = new []{contratto.Columns["idcontratto"], contratto.Columns["idreg"]};
	cChild = new []{cedolino.Columns["idcontratto"], cedolino.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_cedolino_contratto_idcontratto-idreg",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{cedolino.Columns["year"]};
	Relations.Add(new DataRelation("FK_cedolino_year_year",cPar,cChild,false));

	cPar = new []{mese.Columns["idmese"]};
	cChild = new []{cedolino.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_cedolino_mese_idmese",cPar,cChild,false));

	cPar = new []{inquadramentodefaultview.Columns["idinquadramento"]};
	cChild = new []{contratto.Columns["idinquadramento"]};
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
