
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
[System.Xml.Serialization.XmlRoot("dsmeta_pcspeoview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_pcspeoview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramentodefaultview 		=> (MetaTable)Tables["inquadramentodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable positiondefaultview 		=> (MetaTable)Tables["positiondefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pcspeoview 		=> (MetaTable)Tables["pcspeoview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pcspeoview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pcspeoview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pcspeoview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pcspeoview_default.xsd";

	#region create DataTables
	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("aoo_title", typeof(string));
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	tstrutturadefaultview.defineColumn("sede_title", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codice", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codiceipa", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_ct", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_cu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_email", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_fax", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_idaoo", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idreg", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idsede", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_idstrutturakind", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_lt", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_lu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_pesoindicatori", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoobiettivi", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoprogaltreuo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoproguo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_telefono", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_title_en", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_struttura_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturaparent_idstrutturakind", typeof(int));
	tstrutturadefaultview.defineColumn("strutturaparent_title", typeof(string));
	tstrutturadefaultview.defineColumn("title", typeof(string));
	tstrutturadefaultview.defineColumn("upb_title", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// INQUADRAMENTODEFAULTVIEW /////////////////////////////////
	var tinquadramentodefaultview= new MetaTable("inquadramentodefaultview");
	tinquadramentodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinquadramentodefaultview.defineColumn("idinquadramento", typeof(int),false);
	tinquadramentodefaultview.defineColumn("idposition", typeof(int),false);
	tinquadramentodefaultview.defineColumn("inquadramento_costolordoannuo", typeof(decimal));
	tinquadramentodefaultview.defineColumn("inquadramento_costolordoannuooneri", typeof(decimal));
	tinquadramentodefaultview.defineColumn("inquadramento_ct", typeof(DateTime),false);
	tinquadramentodefaultview.defineColumn("inquadramento_cu", typeof(string),false);
	tinquadramentodefaultview.defineColumn("inquadramento_lt", typeof(DateTime),false);
	tinquadramentodefaultview.defineColumn("inquadramento_lu", typeof(string),false);
	tinquadramentodefaultview.defineColumn("inquadramento_siglaimportazione", typeof(string));
	tinquadramentodefaultview.defineColumn("inquadramento_start", typeof(DateTime));
	tinquadramentodefaultview.defineColumn("inquadramento_stop", typeof(DateTime));
	tinquadramentodefaultview.defineColumn("inquadramento_tempdef", typeof(string));
	tinquadramentodefaultview.defineColumn("title", typeof(string));
	Tables.Add(tinquadramentodefaultview);
	tinquadramentodefaultview.defineKey("idinquadramento", "idposition");

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

	//////////////////// PCSPEOVIEW /////////////////////////////////
	var tpcspeoview= new MetaTable("pcspeoview");
	tpcspeoview.defineColumn("data", typeof(DateTime));
	tpcspeoview.defineColumn("idinquadramento", typeof(int));
	tpcspeoview.defineColumn("idinquadramento_start", typeof(int));
	tpcspeoview.defineColumn("idpcspeoview", typeof(int),false);
	tpcspeoview.defineColumn("idposition", typeof(int),false);
	tpcspeoview.defineColumn("idposition_start", typeof(int),false);
	tpcspeoview.defineColumn("idstipendio", typeof(int),false);
	tpcspeoview.defineColumn("idstipendio_start", typeof(int),false);
	tpcspeoview.defineColumn("idstruttura", typeof(int));
	tpcspeoview.defineColumn("nominativo", typeof(string),false);
	tpcspeoview.defineColumn("numeropersoneassunzione", typeof(int),false);
	tpcspeoview.defineColumn("percentuale", typeof(int),false);
	tpcspeoview.defineColumn("stipendio", typeof(decimal));
	tpcspeoview.defineColumn("totale", typeof(decimal));
	tpcspeoview.defineColumn("totale1", typeof(decimal));
	tpcspeoview.defineColumn("totale2", typeof(decimal));
	tpcspeoview.defineColumn("totale3", typeof(decimal));
	tpcspeoview.defineColumn("year", typeof(int),false);
	Tables.Add(tpcspeoview);
	tpcspeoview.defineKey("idpcspeoview", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	var cChild = new []{pcspeoview.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_pcspeoview_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{inquadramentodefaultview.Columns["idinquadramento"]};
	cChild = new []{pcspeoview.Columns["idinquadramento_start"]};
	Relations.Add(new DataRelation("FK_pcspeoview_inquadramentodefaultview_idinquadramento_start",cPar,cChild,false));

	cPar = new []{positiondefaultview.Columns["idposition"]};
	cChild = new []{pcspeoview.Columns["idposition_start"]};
	Relations.Add(new DataRelation("FK_pcspeoview_positiondefaultview_idposition_start",cPar,cChild,false));

	#endregion

}
}
}
