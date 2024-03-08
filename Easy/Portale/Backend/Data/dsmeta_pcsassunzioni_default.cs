
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
[System.Xml.Serialization.XmlRoot("dsmeta_pcsassunzioni_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_pcsassunzioni_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getcontrattikindview 		=> (MetaTable)Tables["getcontrattikindview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable positiondefaultview_alias1 		=> (MetaTable)Tables["positiondefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable positiondefaultview 		=> (MetaTable)Tables["positiondefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pcsassunzioni 		=> (MetaTable)Tables["pcsassunzioni"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pcsassunzioni_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pcsassunzioni_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pcsassunzioni_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pcsassunzioni_default.xsd";

	#region create DataTables
	//////////////////// GETCONTRATTIKINDVIEW /////////////////////////////////
	var tgetcontrattikindview= new MetaTable("getcontrattikindview");
	tgetcontrattikindview.defineColumn("costolordoannuo", typeof(decimal));
	tgetcontrattikindview.defineColumn("costolordoannuo_ck", typeof(decimal));
	tgetcontrattikindview.defineColumn("costolordoannuo_inq", typeof(decimal));
	tgetcontrattikindview.defineColumn("costolordoannuo_stip", typeof(decimal));
	tgetcontrattikindview.defineColumn("costomese", typeof(decimal));
	tgetcontrattikindview.defineColumn("costoora", typeof(decimal));
	tgetcontrattikindview.defineColumn("idposition", typeof(int),false);
	tgetcontrattikindview.defineColumn("oremaxdidatempoparziale", typeof(int));
	tgetcontrattikindview.defineColumn("oremaxdidatempopieno", typeof(int));
	tgetcontrattikindview.defineColumn("oremaxgg", typeof(int));
	tgetcontrattikindview.defineColumn("oremaxtempoparziale", typeof(int));
	tgetcontrattikindview.defineColumn("oremaxtempopieno", typeof(int));
	tgetcontrattikindview.defineColumn("oremindidatempoparziale", typeof(int));
	tgetcontrattikindview.defineColumn("oremindidatempopieno", typeof(int));
	tgetcontrattikindview.defineColumn("parttime", typeof(string));
	tgetcontrattikindview.defineColumn("tempdef", typeof(string));
	tgetcontrattikindview.defineColumn("title", typeof(string),false);
	Tables.Add(tgetcontrattikindview);
	tgetcontrattikindview.defineKey("idposition");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
	Tables.Add(tsasddefaultview);
	tsasddefaultview.defineKey("idsasd");

	//////////////////// POSITIONDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tpositiondefaultview_alias1= new MetaTable("positiondefaultview_alias1");
	tpositiondefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tpositiondefaultview_alias1.defineColumn("idposition", typeof(int),false);
	tpositiondefaultview_alias1.defineColumn("position_active", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_assegnoaggiuntivo", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_codeposition", typeof(string),false);
	tpositiondefaultview_alias1.defineColumn("position_costolordoannuo", typeof(decimal));
	tpositiondefaultview_alias1.defineColumn("position_costolordoannuooneri", typeof(decimal));
	tpositiondefaultview_alias1.defineColumn("position_ct", typeof(DateTime),false);
	tpositiondefaultview_alias1.defineColumn("position_cu", typeof(string),false);
	tpositiondefaultview_alias1.defineColumn("position_description", typeof(string),false);
	tpositiondefaultview_alias1.defineColumn("position_elementoperequativo", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_foreignclass", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_indennitadiateneo", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_indennitadiposizione", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_indvacancacontrattuale", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_livello", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_lt", typeof(DateTime),false);
	tpositiondefaultview_alias1.defineColumn("position_lu", typeof(string),false);
	tpositiondefaultview_alias1.defineColumn("position_maxincomeclass", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremaxcompitididatempoparziale", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremaxcompitididatempopieno", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremaxdidatempoparziale", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremaxdidatempopieno", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremaxgg", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremaxtempoparziale", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremaxtempopieno", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremincompitididatempoparziale", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremincompitididatempopieno", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremindidatempoparziale", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremindidatempopieno", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremintempoparziale", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_oremintempopieno", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_orestraordinariemax", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_parttime", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_printingorder", typeof(int));
	tpositiondefaultview_alias1.defineColumn("position_puntiorganico", typeof(decimal));
	tpositiondefaultview_alias1.defineColumn("position_siglaesportazione", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_siglaimportazione", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_tempdef", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_tipoente", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_tipopersonale", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_totaletredicesima", typeof(string));
	tpositiondefaultview_alias1.defineColumn("position_tredicesimaindennitaintegrativaspeciale", typeof(string));
	tpositiondefaultview_alias1.defineColumn("title", typeof(string));
	tpositiondefaultview_alias1.ExtendedProperties["TableForReading"]="positiondefaultview";
	Tables.Add(tpositiondefaultview_alias1);
	tpositiondefaultview_alias1.defineKey("idposition");

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

	//////////////////// PCSASSUNZIONI /////////////////////////////////
	var tpcsassunzioni= new MetaTable("pcsassunzioni");
	tpcsassunzioni.defineColumn("codicessd", typeof(string));
	tpcsassunzioni.defineColumn("ct", typeof(DateTime),false);
	tpcsassunzioni.defineColumn("cu", typeof(string),false);
	tpcsassunzioni.defineColumn("data", typeof(DateTime));
	tpcsassunzioni.defineColumn("finanziamento", typeof(string));
	tpcsassunzioni.defineColumn("idinquadramento", typeof(int));
	tpcsassunzioni.defineColumn("idinquadramento_start", typeof(int));
	tpcsassunzioni.defineColumn("idpcsassunzioni", typeof(int),false);
	tpcsassunzioni.defineColumn("idposition", typeof(int));
	tpcsassunzioni.defineColumn("idposition_start", typeof(int));
	tpcsassunzioni.defineColumn("idsasd", typeof(int));
	tpcsassunzioni.defineColumn("idstipendio", typeof(int));
	tpcsassunzioni.defineColumn("idstipendio_start", typeof(int));
	tpcsassunzioni.defineColumn("idstruttura", typeof(int));
	tpcsassunzioni.defineColumn("legge", typeof(string));
	tpcsassunzioni.defineColumn("lt", typeof(DateTime),false);
	tpcsassunzioni.defineColumn("lu", typeof(string),false);
	tpcsassunzioni.defineColumn("nominativo", typeof(string));
	tpcsassunzioni.defineColumn("numeropersoneassunzione", typeof(decimal));
	tpcsassunzioni.defineColumn("percentuale", typeof(decimal));
	tpcsassunzioni.defineColumn("stipendio", typeof(decimal));
	tpcsassunzioni.defineColumn("totale", typeof(decimal));
	tpcsassunzioni.defineColumn("totale1", typeof(decimal));
	tpcsassunzioni.defineColumn("totale2", typeof(decimal));
	tpcsassunzioni.defineColumn("totale3", typeof(decimal));
	tpcsassunzioni.defineColumn("year", typeof(int),false);
	Tables.Add(tpcsassunzioni);
	tpcsassunzioni.defineKey("idpcsassunzioni", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	var cChild = new []{pcsassunzioni.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{sasddefaultview.Columns["idsasd"]};
	cChild = new []{pcsassunzioni.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_sasddefaultview_idsasd",cPar,cChild,false));

	cPar = new []{positiondefaultview_alias1.Columns["idposition"]};
	cChild = new []{pcsassunzioni.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_positiondefaultview_alias1_idposition",cPar,cChild,false));

	cPar = new []{positiondefaultview.Columns["idposition"]};
	cChild = new []{pcsassunzioni.Columns["idposition_start"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_positiondefaultview_idposition_start",cPar,cChild,false));

	#endregion

}
}
}
