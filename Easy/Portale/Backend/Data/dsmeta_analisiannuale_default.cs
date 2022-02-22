
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
[System.Xml.Serialization.XmlRoot("dsmeta_analisiannuale_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_analisiannuale_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getcontrattikindview 		=> (MetaTable)Tables["getcontrattikindview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pcsbilancio 		=> (MetaTable)Tables["pcsbilancio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pcspuntiorganicoview 		=> (MetaTable)Tables["pcspuntiorganicoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind_alias3 		=> (MetaTable)Tables["contrattokind_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind_alias2 		=> (MetaTable)Tables["contrattokind_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pcsassunzioni 		=> (MetaTable)Tables["pcsassunzioni"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramento 		=> (MetaTable)Tables["inquadramento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind_alias1 		=> (MetaTable)Tables["contrattokind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contratto 		=> (MetaTable)Tables["contratto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendioannuo 		=> (MetaTable)Tables["stipendioannuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pcscessazioniview 		=> (MetaTable)Tables["pcscessazioniview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pcsassunzionisimulate 		=> (MetaTable)Tables["pcsassunzionisimulate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable analisiannuale 		=> (MetaTable)Tables["analisiannuale"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_analisiannuale_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_analisiannuale_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_analisiannuale_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_analisiannuale_default.xsd";

	#region create DataTables
	//////////////////// GETCONTRATTIKINDVIEW /////////////////////////////////
	var tgetcontrattikindview= new MetaTable("getcontrattikindview");
	tgetcontrattikindview.defineColumn("costolordoannuo", typeof(decimal));
	tgetcontrattikindview.defineColumn("costolordoannuo_ck", typeof(decimal));
	tgetcontrattikindview.defineColumn("costolordoannuo_inq", typeof(decimal));
	tgetcontrattikindview.defineColumn("costolordoannuo_stip", typeof(decimal));
	tgetcontrattikindview.defineColumn("costomese", typeof(decimal));
	tgetcontrattikindview.defineColumn("costoora", typeof(decimal));
	tgetcontrattikindview.defineColumn("idcontrattokind", typeof(int),false);
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
	tgetcontrattikindview.defineKey("idcontrattokind");

	//////////////////// PCSBILANCIO /////////////////////////////////
	var tpcsbilancio= new MetaTable("pcsbilancio");
	tpcsbilancio.defineColumn("ct", typeof(DateTime),false);
	tpcsbilancio.defineColumn("cu", typeof(string),false);
	tpcsbilancio.defineColumn("descrizione", typeof(string));
	tpcsbilancio.defineColumn("idanalisiannuale", typeof(int),false);
	tpcsbilancio.defineColumn("idpcsbilancio", typeof(int),false);
	tpcsbilancio.defineColumn("importo", typeof(decimal));
	tpcsbilancio.defineColumn("importo1", typeof(decimal));
	tpcsbilancio.defineColumn("importo2", typeof(decimal));
	tpcsbilancio.defineColumn("importo3", typeof(decimal));
	tpcsbilancio.defineColumn("lt", typeof(DateTime),false);
	tpcsbilancio.defineColumn("lu", typeof(string),false);
	tpcsbilancio.defineColumn("year", typeof(int),false);
	Tables.Add(tpcsbilancio);
	tpcsbilancio.defineKey("idanalisiannuale", "idpcsbilancio", "year");

	//////////////////// PCSPUNTIORGANICOVIEW /////////////////////////////////
	var tpcspuntiorganicoview= new MetaTable("pcspuntiorganicoview");
	tpcspuntiorganicoview.defineColumn("contrattokind_title", typeof(string),false);
	tpcspuntiorganicoview.defineColumn("importo0", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importo1", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importo2", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importo3", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoateneo0", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoateneo1", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoateneo2", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoateneo3", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoesterno0", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoesterno1", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoesterno2", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoesterno3", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("isdoc", typeof(string),false);
	tpcspuntiorganicoview.defineColumn("puntimeno0", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntimeno1", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntimeno2", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntimeno3", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntipiu0", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntipiu1", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntipiu2", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntipiu3", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("year", typeof(int),false);
	tpcspuntiorganicoview.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tpcspuntiorganicoview);
	tpcspuntiorganicoview.defineKey("contrattokind_title", "year");

	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("title", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("codice", typeof(string),false);
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	//////////////////// CONTRATTOKIND_ALIAS3 /////////////////////////////////
	var tcontrattokind_alias3= new MetaTable("contrattokind_alias3");
	tcontrattokind_alias3.defineColumn("active", typeof(string),false);
	tcontrattokind_alias3.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind_alias3.defineColumn("title", typeof(string),false);
	tcontrattokind_alias3.ExtendedProperties["TableForReading"]="contrattokind";
	Tables.Add(tcontrattokind_alias3);
	tcontrattokind_alias3.defineKey("idcontrattokind");

	//////////////////// CONTRATTOKIND_ALIAS2 /////////////////////////////////
	var tcontrattokind_alias2= new MetaTable("contrattokind_alias2");
	tcontrattokind_alias2.defineColumn("active", typeof(string),false);
	tcontrattokind_alias2.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind_alias2.defineColumn("title", typeof(string),false);
	tcontrattokind_alias2.ExtendedProperties["TableForReading"]="contrattokind";
	Tables.Add(tcontrattokind_alias2);
	tcontrattokind_alias2.defineKey("idcontrattokind");

	//////////////////// PCSASSUNZIONI /////////////////////////////////
	var tpcsassunzioni= new MetaTable("pcsassunzioni");
	tpcsassunzioni.defineColumn("ct", typeof(DateTime),false);
	tpcsassunzioni.defineColumn("cu", typeof(string),false);
	tpcsassunzioni.defineColumn("data", typeof(DateTime));
	tpcsassunzioni.defineColumn("finanziamento", typeof(string));
	tpcsassunzioni.defineColumn("idcontrattokind", typeof(int));
	tpcsassunzioni.defineColumn("idcontrattokind_start", typeof(int));
	tpcsassunzioni.defineColumn("idpcsassunzioni", typeof(int),false);
	tpcsassunzioni.defineColumn("idsasd", typeof(int));
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
	tpcsassunzioni.defineColumn("!idcontrattokind_contrattokind_title", typeof(string));
	tpcsassunzioni.defineColumn("!idcontrattokind_start_contrattokind_title", typeof(string));
	tpcsassunzioni.defineColumn("!idsasd_sasd_codice", typeof(string));
	tpcsassunzioni.defineColumn("!idsasd_sasd_title", typeof(string));
	tpcsassunzioni.defineColumn("!idstruttura_struttura_title", typeof(string));
	tpcsassunzioni.defineColumn("!idstruttura_struttura_idstrutturakind_title", typeof(string));
	tpcsassunzioni.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tpcsassunzioni);
	tpcsassunzioni.defineKey("idpcsassunzioni", "year");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// INQUADRAMENTO /////////////////////////////////
	var tinquadramento= new MetaTable("inquadramento");
	tinquadramento.defineColumn("idcontrattokind", typeof(int),false);
	tinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tinquadramento.defineColumn("tempdef", typeof(string));
	tinquadramento.defineColumn("title", typeof(string));
	Tables.Add(tinquadramento);
	tinquadramento.defineKey("idcontrattokind", "idinquadramento");

	//////////////////// CONTRATTOKIND_ALIAS1 /////////////////////////////////
	var tcontrattokind_alias1= new MetaTable("contrattokind_alias1");
	tcontrattokind_alias1.defineColumn("active", typeof(string),false);
	tcontrattokind_alias1.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind_alias1.defineColumn("title", typeof(string),false);
	tcontrattokind_alias1.ExtendedProperties["TableForReading"]="contrattokind";
	Tables.Add(tcontrattokind_alias1);
	tcontrattokind_alias1.defineKey("idcontrattokind");

	//////////////////// CONTRATTO /////////////////////////////////
	var tcontratto= new MetaTable("contratto");
	tcontratto.defineColumn("idcontratto", typeof(int),false);
	tcontratto.defineColumn("idcontrattokind", typeof(int),false);
	tcontratto.defineColumn("idinquadramento", typeof(int));
	tcontratto.defineColumn("idreg", typeof(int),false);
	tcontratto.defineColumn("parttime", typeof(decimal));
	tcontratto.defineColumn("percentualesufondiateneo", typeof(decimal));
	tcontratto.defineColumn("start", typeof(DateTime),false);
	tcontratto.defineColumn("stop", typeof(DateTime));
	Tables.Add(tcontratto);
	tcontratto.defineKey("idcontratto", "idreg");

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
	tstipendioannuo.defineColumn("!idcontratto_contratto_percentualesufondiateneo", typeof(decimal));
	tstipendioannuo.defineColumn("!idcontratto_contratto_start", typeof(DateTime));
	tstipendioannuo.defineColumn("!idcontratto_contratto_stop", typeof(DateTime));
	tstipendioannuo.defineColumn("!idcontratto_contratto_parttime", typeof(decimal));
	tstipendioannuo.defineColumn("!idcontratto_contratto_idcontrattokind_title", typeof(string));
	tstipendioannuo.defineColumn("!idcontratto_contratto_idinquadramento_title", typeof(string));
	tstipendioannuo.defineColumn("!idcontratto_contratto_idinquadramento_tempdef", typeof(string));
	tstipendioannuo.defineColumn("!idreg_registry_extmatricula", typeof(string));
	tstipendioannuo.defineColumn("!idreg_registry_title", typeof(string));
	tstipendioannuo.defineColumn("!idreg_registry_cf", typeof(string));
	tstipendioannuo.defineColumn("!idreg_registry_p_iva", typeof(string));
	tstipendioannuo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tstipendioannuo);
	tstipendioannuo.defineKey("idcontratto", "idreg", "idstipendioannuo", "year");

	//////////////////// PCSCESSAZIONIVIEW /////////////////////////////////
	var tpcscessazioniview= new MetaTable("pcscessazioniview");
	tpcscessazioniview.defineColumn("data", typeof(DateTime));
	tpcscessazioniview.defineColumn("idanalisiannuale", typeof(int),false);
	tpcscessazioniview.defineColumn("idpcscessazioniview", typeof(int),false);
	tpcscessazioniview.defineColumn("title", typeof(string),false);
	tpcscessazioniview.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tpcscessazioniview);
	tpcscessazioniview.defineKey("idpcscessazioniview");

	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("active", typeof(string),false);
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// PCSASSUNZIONISIMULATE /////////////////////////////////
	var tpcsassunzionisimulate= new MetaTable("pcsassunzionisimulate");
	tpcsassunzionisimulate.defineColumn("ct", typeof(DateTime),false);
	tpcsassunzionisimulate.defineColumn("cu", typeof(string),false);
	tpcsassunzionisimulate.defineColumn("data", typeof(DateTime));
	tpcsassunzionisimulate.defineColumn("finanziamento", typeof(string));
	tpcsassunzionisimulate.defineColumn("idcontrattokind", typeof(int));
	tpcsassunzionisimulate.defineColumn("idcontrattokind_start", typeof(int));
	tpcsassunzionisimulate.defineColumn("idpcsassunzionisimulate", typeof(int),false);
	tpcsassunzionisimulate.defineColumn("idsasd", typeof(int));
	tpcsassunzionisimulate.defineColumn("idstruttura", typeof(int));
	tpcsassunzionisimulate.defineColumn("legge", typeof(string));
	tpcsassunzionisimulate.defineColumn("lt", typeof(DateTime),false);
	tpcsassunzionisimulate.defineColumn("lu", typeof(string),false);
	tpcsassunzionisimulate.defineColumn("nominativo", typeof(string));
	tpcsassunzionisimulate.defineColumn("numeropersoneassunzione", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("percentuale", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("stipendio", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("totale", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("totale1", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("totale2", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("totale3", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("year", typeof(int),false);
	tpcsassunzionisimulate.defineColumn("!idcontrattokind_contrattokind_title", typeof(string));
	tpcsassunzionisimulate.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tpcsassunzionisimulate);
	tpcsassunzionisimulate.defineKey("idpcsassunzionisimulate", "year");

	//////////////////// ANALISIANNUALE /////////////////////////////////
	var tanalisiannuale= new MetaTable("analisiannuale");
	tanalisiannuale.defineColumn("!denominatore0", typeof(decimal));
	tanalisiannuale.defineColumn("!denominatore1", typeof(decimal));
	tanalisiannuale.defineColumn("!denominatore2", typeof(decimal));
	tanalisiannuale.defineColumn("!denominatore3", typeof(decimal));
	tanalisiannuale.defineColumn("!indicatore0", typeof(decimal));
	tanalisiannuale.defineColumn("!indicatore1", typeof(decimal));
	tanalisiannuale.defineColumn("!indicatore2", typeof(decimal));
	tanalisiannuale.defineColumn("!indicatore3", typeof(decimal));
	tanalisiannuale.defineColumn("!numeratore0", typeof(decimal));
	tanalisiannuale.defineColumn("!numeratore1", typeof(decimal));
	tanalisiannuale.defineColumn("!numeratore2", typeof(decimal));
	tanalisiannuale.defineColumn("!numeratore3", typeof(decimal));
	tanalisiannuale.defineColumn("!year1", typeof(int));
	tanalisiannuale.defineColumn("!year2", typeof(int));
	tanalisiannuale.defineColumn("!year3", typeof(int));
	tanalisiannuale.defineColumn("contrattiincarichiinsegnamento0", typeof(decimal));
	tanalisiannuale.defineColumn("contrattiincarichiinsegnamento1", typeof(decimal));
	tanalisiannuale.defineColumn("contrattiincarichiinsegnamento2", typeof(decimal));
	tanalisiannuale.defineColumn("contrattiincarichiinsegnamento3", typeof(decimal));
	tanalisiannuale.defineColumn("costopt", typeof(decimal));
	tanalisiannuale.defineColumn("ct", typeof(DateTime));
	tanalisiannuale.defineColumn("cu", typeof(string));
	tanalisiannuale.defineColumn("ffo0", typeof(decimal));
	tanalisiannuale.defineColumn("ffo1", typeof(decimal));
	tanalisiannuale.defineColumn("ffo2", typeof(decimal));
	tanalisiannuale.defineColumn("ffo3", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternicontrattiincarichiinsegnamento0", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternicontrattiincarichiinsegnamento1", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternicontrattiincarichiinsegnamento2", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternicontrattiincarichiinsegnamento3", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternidirPTA0", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternidirPTA1", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternidirPTA2", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternidirPTA3", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternidocenti0", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternidocenti1", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternidocenti2", typeof(decimal));
	tanalisiannuale.defineColumn("finanzesternidocenti3", typeof(decimal));
	tanalisiannuale.defineColumn("fondocontrattazioneintegrativa0", typeof(decimal));
	tanalisiannuale.defineColumn("fondocontrattazioneintegrativa1", typeof(decimal));
	tanalisiannuale.defineColumn("fondocontrattazioneintegrativa2", typeof(decimal));
	tanalisiannuale.defineColumn("fondocontrattazioneintegrativa3", typeof(decimal));
	tanalisiannuale.defineColumn("idanalisiannuale", typeof(int),false);
	tanalisiannuale.defineColumn("incrementodocenti1", typeof(decimal));
	tanalisiannuale.defineColumn("incrementodocenti2", typeof(decimal));
	tanalisiannuale.defineColumn("incrementodocenti3", typeof(decimal));
	tanalisiannuale.defineColumn("lt", typeof(DateTime));
	tanalisiannuale.defineColumn("lu", typeof(string));
	tanalisiannuale.defineColumn("programmazionetriennale0", typeof(decimal));
	tanalisiannuale.defineColumn("programmazionetriennale1", typeof(decimal));
	tanalisiannuale.defineColumn("programmazionetriennale2", typeof(decimal));
	tanalisiannuale.defineColumn("programmazionetriennale3", typeof(decimal));
	tanalisiannuale.defineColumn("speseDG0", typeof(decimal));
	tanalisiannuale.defineColumn("speseDG1", typeof(decimal));
	tanalisiannuale.defineColumn("speseDG2", typeof(decimal));
	tanalisiannuale.defineColumn("speseDG3", typeof(decimal));
	tanalisiannuale.defineColumn("spesedirPTA0", typeof(decimal));
	tanalisiannuale.defineColumn("spesedirPTA1", typeof(decimal));
	tanalisiannuale.defineColumn("spesedirPTA2", typeof(decimal));
	tanalisiannuale.defineColumn("spesedirPTA3", typeof(decimal));
	tanalisiannuale.defineColumn("spesedocenti0", typeof(decimal));
	tanalisiannuale.defineColumn("spesedocenti1", typeof(decimal));
	tanalisiannuale.defineColumn("spesedocenti2", typeof(decimal));
	tanalisiannuale.defineColumn("spesedocenti3", typeof(decimal));
	tanalisiannuale.defineColumn("speseriduzione0", typeof(decimal));
	tanalisiannuale.defineColumn("speseriduzione1", typeof(decimal));
	tanalisiannuale.defineColumn("speseriduzione2", typeof(decimal));
	tanalisiannuale.defineColumn("speseriduzione3", typeof(decimal));
	tanalisiannuale.defineColumn("tasse0", typeof(decimal));
	tanalisiannuale.defineColumn("tasse1", typeof(decimal));
	tanalisiannuale.defineColumn("tasse2", typeof(decimal));
	tanalisiannuale.defineColumn("tasse3", typeof(decimal));
	tanalisiannuale.defineColumn("totspesepersonalecaricoateneo0", typeof(decimal));
	tanalisiannuale.defineColumn("totspesepersonalecaricoateneo1", typeof(decimal));
	tanalisiannuale.defineColumn("totspesepersonalecaricoateneo2", typeof(decimal));
	tanalisiannuale.defineColumn("totspesepersonalecaricoateneo3", typeof(decimal));
	tanalisiannuale.defineColumn("trattamentostipintegrativoCEL0", typeof(decimal));
	tanalisiannuale.defineColumn("trattamentostipintegrativoCEL1", typeof(decimal));
	tanalisiannuale.defineColumn("trattamentostipintegrativoCEL2", typeof(decimal));
	tanalisiannuale.defineColumn("trattamentostipintegrativoCEL3", typeof(decimal));
	tanalisiannuale.defineColumn("year", typeof(int),false);
	Tables.Add(tanalisiannuale);
	tanalisiannuale.defineKey("idanalisiannuale", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{analisiannuale.Columns["idanalisiannuale"], analisiannuale.Columns["year"]};
	var cChild = new []{pcsbilancio.Columns["idanalisiannuale"], pcsbilancio.Columns["year"]};
	Relations.Add(new DataRelation("FK_pcsbilancio_analisiannuale_idanalisiannuale-year",cPar,cChild,false));

	cPar = new []{analisiannuale.Columns["year"]};
	cChild = new []{pcspuntiorganicoview.Columns["year"]};
	Relations.Add(new DataRelation("FK_pcspuntiorganicoview_analisiannuale_year",cPar,cChild,false));

	cPar = new []{analisiannuale.Columns["year"]};
	cChild = new []{pcsassunzioni.Columns["year"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_analisiannuale_year",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{pcsassunzioni.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{pcsassunzioni.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_sasd_idsasd",cPar,cChild,false));

	cPar = new []{contrattokind_alias3.Columns["idcontrattokind"]};
	cChild = new []{pcsassunzioni.Columns["idcontrattokind_start"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_contrattokind_alias3_idcontrattokind_start",cPar,cChild,false));

	cPar = new []{contrattokind_alias2.Columns["idcontrattokind"]};
	cChild = new []{pcsassunzioni.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_contrattokind_alias2_idcontrattokind",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{analisiannuale.Columns["year"]};
	Relations.Add(new DataRelation("FK_analisiannuale_year_year",cPar,cChild,false));

	cPar = new []{analisiannuale.Columns["year"]};
	cChild = new []{stipendioannuo.Columns["year"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_analisiannuale_year",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{stipendioannuo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_registry_idreg",cPar,cChild,false));

	cPar = new []{contratto.Columns["idcontratto"]};
	cChild = new []{stipendioannuo.Columns["idcontratto"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_contratto_idcontratto",cPar,cChild,false));

	cPar = new []{inquadramento.Columns["idinquadramento"]};
	cChild = new []{contratto.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_contratto_inquadramento_idinquadramento",cPar,cChild,false));

	cPar = new []{contrattokind_alias1.Columns["idcontrattokind"]};
	cChild = new []{contratto.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_contratto_contrattokind_alias1_idcontrattokind",cPar,cChild,false));

	cPar = new []{analisiannuale.Columns["idanalisiannuale"]};
	cChild = new []{pcscessazioniview.Columns["idanalisiannuale"]};
	Relations.Add(new DataRelation("FK_pcscessazioniview_analisiannuale_idanalisiannuale",cPar,cChild,false));

	cPar = new []{analisiannuale.Columns["year"]};
	cChild = new []{pcsassunzionisimulate.Columns["year"]};
	Relations.Add(new DataRelation("FK_pcsassunzionisimulate_analisiannuale_year",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{pcsassunzionisimulate.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_pcsassunzionisimulate_contrattokind_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
