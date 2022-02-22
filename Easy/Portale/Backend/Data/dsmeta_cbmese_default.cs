
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
[System.Xml.Serialization.XmlRoot("dsmeta_cbmese_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_cbmese_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbflussiviewdettaglio 		=> (MetaTable)Tables["cbflussiviewdettaglio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbflussiview 		=> (MetaTable)Tables["cbflussiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokind_alias2 		=> (MetaTable)Tables["pagamentokind_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbscadenziario 		=> (MetaTable)Tables["cbscadenziario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokind_alias1 		=> (MetaTable)Tables["pagamentokind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbscadenziariofornitori 		=> (MetaTable)Tables["cbscadenziariofornitori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese 		=> (MetaTable)Tables["mese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokind 		=> (MetaTable)Tables["pagamentokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable scadenziarioclienti 		=> (MetaTable)Tables["scadenziarioclienti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbmese 		=> (MetaTable)Tables["cbmese"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_cbmese_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_cbmese_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_cbmese_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_cbmese_default.xsd";

	#region create DataTables
	//////////////////// CBFLUSSIVIEWDETTAGLIO /////////////////////////////////
	var tcbflussiviewdettaglio= new MetaTable("cbflussiviewdettaglio");
	tcbflussiviewdettaglio.defineColumn("!credkind", typeof(string));
	tcbflussiviewdettaglio.defineColumn("!monthscadenza", typeof(int));
	tcbflussiviewdettaglio.defineColumn("!yearscadenza", typeof(int));
	tcbflussiviewdettaglio.defineColumn("cbflussiviewbasekind", typeof(string),false);
	tcbflussiviewdettaglio.defineColumn("cliente", typeof(string));
	tcbflussiviewdettaglio.defineColumn("dareavere", typeof(string));
	tcbflussiviewdettaglio.defineColumn("idcbflussiview", typeof(int),false);
	tcbflussiviewdettaglio.defineColumn("idcbflussiviewdettaglio", typeof(int),false);
	tcbflussiviewdettaglio.defineColumn("idcbmese", typeof(int),false);
	tcbflussiviewdettaglio.defineColumn("idpagamentokind", typeof(int));
	tcbflussiviewdettaglio.defineColumn("importo", typeof(decimal));
	tcbflussiviewdettaglio.defineColumn("inizio", typeof(string));
	tcbflussiviewdettaglio.defineColumn("note", typeof(string));
	tcbflussiviewdettaglio.defineColumn("scadenza", typeof(DateTime));
	Tables.Add(tcbflussiviewdettaglio);
	tcbflussiviewdettaglio.defineKey("idcbflussiview", "idcbflussiviewdettaglio", "idcbmese");

	//////////////////// CBFLUSSIVIEW /////////////////////////////////
	var tcbflussiview= new MetaTable("cbflussiview");
	tcbflussiview.defineColumn("disponibilita", typeof(decimal));
	tcbflussiview.defineColumn("disponibilitainiziale", typeof(decimal));
	tcbflussiview.defineColumn("entrate", typeof(decimal));
	tcbflussiview.defineColumn("flusso", typeof(decimal));
	tcbflussiview.defineColumn("idcbflussiview", typeof(int),false);
	tcbflussiview.defineColumn("idcbmese", typeof(int),false);
	tcbflussiview.defineColumn("scadenza", typeof(DateTime));
	tcbflussiview.defineColumn("uscite", typeof(decimal));
	Tables.Add(tcbflussiview);
	tcbflussiview.defineKey("idcbflussiview", "idcbmese");

	//////////////////// PAGAMENTOKIND_ALIAS2 /////////////////////////////////
	var tpagamentokind_alias2= new MetaTable("pagamentokind_alias2");
	tpagamentokind_alias2.defineColumn("active", typeof(string),false);
	tpagamentokind_alias2.defineColumn("idpagamentokind", typeof(int),false);
	tpagamentokind_alias2.defineColumn("title", typeof(string),false);
	tpagamentokind_alias2.ExtendedProperties["TableForReading"]="pagamentokind";
	Tables.Add(tpagamentokind_alias2);
	tpagamentokind_alias2.defineKey("idpagamentokind");

	//////////////////// CBSCADENZIARIO /////////////////////////////////
	var tcbscadenziario= new MetaTable("cbscadenziario");
	tcbscadenziario.defineColumn("!credkind", typeof(string));
	tcbscadenziario.defineColumn("!importoflussi", typeof(decimal));
	tcbscadenziario.defineColumn("!monthscadenza", typeof(int));
	tcbscadenziario.defineColumn("!scadenzaflussi", typeof(DateTime));
	tcbscadenziario.defineColumn("!yeardoc", typeof(int));
	tcbscadenziario.defineColumn("!yearscadenza", typeof(int));
	tcbscadenziario.defineColumn("cliente", typeof(string));
	tcbscadenziario.defineColumn("codiceconto", typeof(string));
	tcbscadenziario.defineColumn("dareavere", typeof(string));
	tcbscadenziario.defineColumn("datadocumeto", typeof(DateTime));
	tcbscadenziario.defineColumn("dataparte", typeof(DateTime));
	tcbscadenziario.defineColumn("dataprevistaincasso", typeof(DateTime));
	tcbscadenziario.defineColumn("idcbmese", typeof(int),false);
	tcbscadenziario.defineColumn("idcbscadenziario", typeof(int),false);
	tcbscadenziario.defineColumn("idpagamentokind", typeof(int));
	tcbscadenziario.defineColumn("importo", typeof(decimal));
	tcbscadenziario.defineColumn("importodaincassare", typeof(decimal));
	tcbscadenziario.defineColumn("importooriginale", typeof(decimal));
	tcbscadenziario.defineColumn("note", typeof(string));
	tcbscadenziario.defineColumn("nprotocollo", typeof(string));
	tcbscadenziario.defineColumn("numerodocumento", typeof(string));
	tcbscadenziario.defineColumn("numeroparte", typeof(string));
	tcbscadenziario.defineColumn("scadenza", typeof(DateTime));
	tcbscadenziario.defineColumn("scadenzaoriginale", typeof(DateTime));
	tcbscadenziario.defineColumn("!idpagamentokind_pagamentokind_title", typeof(string));
	Tables.Add(tcbscadenziario);
	tcbscadenziario.defineKey("idcbmese", "idcbscadenziario");

	//////////////////// PAGAMENTOKIND_ALIAS1 /////////////////////////////////
	var tpagamentokind_alias1= new MetaTable("pagamentokind_alias1");
	tpagamentokind_alias1.defineColumn("active", typeof(string),false);
	tpagamentokind_alias1.defineColumn("idpagamentokind", typeof(int),false);
	tpagamentokind_alias1.defineColumn("title", typeof(string),false);
	tpagamentokind_alias1.ExtendedProperties["TableForReading"]="pagamentokind";
	Tables.Add(tpagamentokind_alias1);
	tpagamentokind_alias1.defineKey("idpagamentokind");

	//////////////////// CBSCADENZIARIOFORNITORI /////////////////////////////////
	var tcbscadenziariofornitori= new MetaTable("cbscadenziariofornitori");
	tcbscadenziariofornitori.defineColumn("!credkind", typeof(string));
	tcbscadenziariofornitori.defineColumn("!importoflussi", typeof(decimal));
	tcbscadenziariofornitori.defineColumn("!monthscadenza", typeof(int));
	tcbscadenziariofornitori.defineColumn("!scadenzaflussi", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("!yeardoc", typeof(int));
	tcbscadenziariofornitori.defineColumn("!yearscadenza", typeof(int));
	tcbscadenziariofornitori.defineColumn("anomaliaimport", typeof(string));
	tcbscadenziariofornitori.defineColumn("cliente", typeof(string));
	tcbscadenziariofornitori.defineColumn("codiceconto", typeof(string));
	tcbscadenziariofornitori.defineColumn("dareavere", typeof(string));
	tcbscadenziariofornitori.defineColumn("datadocumeto", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("dataparte", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("dataprevistaincasso", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("idcbmese", typeof(int),false);
	tcbscadenziariofornitori.defineColumn("idcbscadenziariofornitori", typeof(int),false);
	tcbscadenziariofornitori.defineColumn("idpagamentokind", typeof(int));
	tcbscadenziariofornitori.defineColumn("importo", typeof(decimal));
	tcbscadenziariofornitori.defineColumn("importodaincassare", typeof(decimal));
	tcbscadenziariofornitori.defineColumn("importooriginale", typeof(decimal));
	tcbscadenziariofornitori.defineColumn("note", typeof(string));
	tcbscadenziariofornitori.defineColumn("nprotocollo", typeof(string));
	tcbscadenziariofornitori.defineColumn("numerodocumento", typeof(string));
	tcbscadenziariofornitori.defineColumn("numeroparte", typeof(string));
	tcbscadenziariofornitori.defineColumn("numeroregistrazione", typeof(decimal));
	tcbscadenziariofornitori.defineColumn("scadenza", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("scadenzaoriginale", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("!idpagamentokind_pagamentokind_title", typeof(string));
	Tables.Add(tcbscadenziariofornitori);
	tcbscadenziariofornitori.defineKey("idcbmese", "idcbscadenziariofornitori");

	//////////////////// MESE /////////////////////////////////
	var tmese= new MetaTable("mese");
	tmese.defineColumn("idmese", typeof(int),false);
	tmese.defineColumn("title", typeof(string));
	Tables.Add(tmese);
	tmese.defineKey("idmese");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PAGAMENTOKIND /////////////////////////////////
	var tpagamentokind= new MetaTable("pagamentokind");
	tpagamentokind.defineColumn("active", typeof(string),false);
	tpagamentokind.defineColumn("ct", typeof(DateTime),false);
	tpagamentokind.defineColumn("cu", typeof(string),false);
	tpagamentokind.defineColumn("idpagamentokind", typeof(int),false);
	tpagamentokind.defineColumn("lt", typeof(DateTime),false);
	tpagamentokind.defineColumn("lu", typeof(string),false);
	tpagamentokind.defineColumn("sortcode", typeof(int),false);
	tpagamentokind.defineColumn("title", typeof(string),false);
	Tables.Add(tpagamentokind);
	tpagamentokind.defineKey("idpagamentokind");

	//////////////////// SCADENZIARIOCLIENTI /////////////////////////////////
	var tscadenziarioclienti= new MetaTable("scadenziarioclienti");
	tscadenziarioclienti.defineColumn("!credkind", typeof(string));
	tscadenziarioclienti.defineColumn("!importoflussi", typeof(decimal));
	tscadenziarioclienti.defineColumn("!monthscadenza", typeof(int));
	tscadenziarioclienti.defineColumn("!scadenzaflussi", typeof(DateTime));
	tscadenziarioclienti.defineColumn("!yeardoc", typeof(int));
	tscadenziarioclienti.defineColumn("!yearscadenza", typeof(int));
	tscadenziarioclienti.defineColumn("anomaliaimport", typeof(string));
	tscadenziarioclienti.defineColumn("cliente", typeof(string));
	tscadenziarioclienti.defineColumn("codiceconto", typeof(string));
	tscadenziarioclienti.defineColumn("dareavere", typeof(string));
	tscadenziarioclienti.defineColumn("datadocumeto", typeof(DateTime));
	tscadenziarioclienti.defineColumn("dataparte", typeof(DateTime));
	tscadenziarioclienti.defineColumn("dataprevistaincasso", typeof(DateTime));
	tscadenziarioclienti.defineColumn("idcbmese", typeof(int),false);
	tscadenziarioclienti.defineColumn("idpagamentokind", typeof(int));
	tscadenziarioclienti.defineColumn("idscadenziarioclienti", typeof(int),false);
	tscadenziarioclienti.defineColumn("importo", typeof(decimal));
	tscadenziarioclienti.defineColumn("importodaincassare", typeof(decimal));
	tscadenziarioclienti.defineColumn("importooriginale", typeof(decimal));
	tscadenziarioclienti.defineColumn("note", typeof(string));
	tscadenziarioclienti.defineColumn("nprotocollo", typeof(string));
	tscadenziarioclienti.defineColumn("numerodocumento", typeof(string));
	tscadenziarioclienti.defineColumn("numeroparte", typeof(string));
	tscadenziarioclienti.defineColumn("scadenza", typeof(DateTime));
	tscadenziarioclienti.defineColumn("scadenzaoriginale", typeof(DateTime));
	tscadenziarioclienti.defineColumn("!idpagamentokind_pagamentokind_title", typeof(string));
	Tables.Add(tscadenziarioclienti);
	tscadenziarioclienti.defineKey("idcbmese", "idscadenziarioclienti");

	//////////////////// CBMESE /////////////////////////////////
	var tcbmese= new MetaTable("cbmese");
	tcbmese.defineColumn("ct", typeof(DateTime),false);
	tcbmese.defineColumn("cu", typeof(string),false);
	tcbmese.defineColumn("idcbmese", typeof(int),false);
	tcbmese.defineColumn("idmese", typeof(int));
	tcbmese.defineColumn("importo", typeof(decimal));
	tcbmese.defineColumn("lt", typeof(DateTime),false);
	tcbmese.defineColumn("lu", typeof(string),false);
	tcbmese.defineColumn("year", typeof(int));
	Tables.Add(tcbmese);
	tcbmese.defineKey("idcbmese");

	#endregion


	#region DataRelation creation
	var cPar = new []{cbmese.Columns["idcbmese"]};
	var cChild = new []{cbflussiview.Columns["idcbmese"]};
	Relations.Add(new DataRelation("FK_cbflussiview_cbmese_idcbmese",cPar,cChild,false));

	cPar = new []{cbflussiview.Columns["idcbflussiview"], cbflussiview.Columns["idcbmese"]};
	cChild = new []{cbflussiviewdettaglio.Columns["idcbflussiview"], cbflussiviewdettaglio.Columns["idcbmese"]};
	Relations.Add(new DataRelation("FK_cbflussiviewdettaglio_cbflussiview_idcbflussiview-idcbmese",cPar,cChild,false));

	cPar = new []{cbmese.Columns["idcbmese"]};
	cChild = new []{cbscadenziario.Columns["idcbmese"]};
	Relations.Add(new DataRelation("FK_cbscadenziario_cbmese_idcbmese",cPar,cChild,false));

	cPar = new []{pagamentokind_alias2.Columns["idpagamentokind"]};
	cChild = new []{cbscadenziario.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_cbscadenziario_pagamentokind_alias2_idpagamentokind",cPar,cChild,false));

	cPar = new []{cbmese.Columns["idcbmese"]};
	cChild = new []{cbscadenziariofornitori.Columns["idcbmese"]};
	Relations.Add(new DataRelation("FK_cbscadenziariofornitori_cbmese_idcbmese",cPar,cChild,false));

	cPar = new []{pagamentokind_alias1.Columns["idpagamentokind"]};
	cChild = new []{cbscadenziariofornitori.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_cbscadenziariofornitori_pagamentokind_alias1_idpagamentokind",cPar,cChild,false));

	cPar = new []{mese.Columns["idmese"]};
	cChild = new []{cbmese.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_cbmese_mese_idmese",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{cbmese.Columns["year"]};
	Relations.Add(new DataRelation("FK_cbmese_year_year",cPar,cChild,false));

	cPar = new []{cbmese.Columns["idcbmese"]};
	cChild = new []{scadenziarioclienti.Columns["idcbmese"]};
	Relations.Add(new DataRelation("FK_scadenziarioclienti_cbmese_idcbmese",cPar,cChild,false));

	cPar = new []{pagamentokind.Columns["idpagamentokind"]};
	cChild = new []{scadenziarioclienti.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_scadenziarioclienti_pagamentokind_idpagamentokind",cPar,cChild,false));

	#endregion

}
}
}
