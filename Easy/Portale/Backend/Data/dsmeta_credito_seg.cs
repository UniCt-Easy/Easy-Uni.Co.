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
[System.Xml.Serialization.XmlRoot("dsmeta_credito_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_credito_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokind 		=> (MetaTable)Tables["pagamentokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamento 		=> (MetaTable)Tables["pagamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable liquidazione 		=> (MetaTable)Tables["liquidazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debito 		=> (MetaTable)Tables["debito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable conguaglio 		=> (MetaTable)Tables["conguaglio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentodefaultview_alias1 		=> (MetaTable)Tables["pagamentodefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debitosegview 		=> (MetaTable)Tables["debitosegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable credito 		=> (MetaTable)Tables["credito"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_credito_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_credito_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_credito_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_credito_seg.xsd";

	#region create DataTables
	//////////////////// PAGAMENTOKIND /////////////////////////////////
	var tpagamentokind= new MetaTable("pagamentokind");
	tpagamentokind.defineColumn("active", typeof(string),false);
	tpagamentokind.defineColumn("idpagamentokind", typeof(int),false);
	tpagamentokind.defineColumn("title", typeof(string),false);
	Tables.Add(tpagamentokind);
	tpagamentokind.defineKey("idpagamentokind");

	//////////////////// PAGAMENTO /////////////////////////////////
	var tpagamento= new MetaTable("pagamento");
	tpagamento.defineColumn("ct", typeof(DateTime),false);
	tpagamento.defineColumn("cu", typeof(string),false);
	tpagamento.defineColumn("dataora", typeof(DateTime));
	tpagamento.defineColumn("iddebito", typeof(int),false);
	tpagamento.defineColumn("idpagamento", typeof(int),false);
	tpagamento.defineColumn("idpagamentokind", typeof(int));
	tpagamento.defineColumn("idreg", typeof(int),false);
	tpagamento.defineColumn("lt", typeof(DateTime),false);
	tpagamento.defineColumn("lu", typeof(string),false);
	tpagamento.defineColumn("!idpagamentokind_pagamentokind_title", typeof(string));
	tpagamento.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tpagamento);
	tpagamento.defineKey("iddebito", "idpagamento", "idreg");

	//////////////////// LIQUIDAZIONE /////////////////////////////////
	var tliquidazione= new MetaTable("liquidazione");
	tliquidazione.defineColumn("ct", typeof(DateTime));
	tliquidazione.defineColumn("cu", typeof(string));
	tliquidazione.defineColumn("data", typeof(DateTime));
	tliquidazione.defineColumn("idcredito", typeof(int),false);
	tliquidazione.defineColumn("iddebito_credito", typeof(int),false);
	tliquidazione.defineColumn("idliquidazione", typeof(int),false);
	tliquidazione.defineColumn("idpagamento", typeof(int),false);
	tliquidazione.defineColumn("idreg", typeof(int),false);
	tliquidazione.defineColumn("importo", typeof(decimal));
	tliquidazione.defineColumn("lt", typeof(DateTime));
	tliquidazione.defineColumn("lu", typeof(string));
	Tables.Add(tliquidazione);
	tliquidazione.defineKey("idcredito", "iddebito_credito", "idliquidazione", "idpagamento", "idreg");

	//////////////////// DEBITO /////////////////////////////////
	var tdebito= new MetaTable("debito");
	tdebito.defineColumn("iddebito", typeof(int),false);
	tdebito.defineColumn("title", typeof(string));
	Tables.Add(tdebito);
	tdebito.defineKey("iddebito");

	//////////////////// CONGUAGLIO /////////////////////////////////
	var tconguaglio= new MetaTable("conguaglio");
	tconguaglio.defineColumn("ct", typeof(DateTime));
	tconguaglio.defineColumn("cu", typeof(string));
	tconguaglio.defineColumn("dataora", typeof(DateTime));
	tconguaglio.defineColumn("idconguaglio", typeof(int),false);
	tconguaglio.defineColumn("idcredito", typeof(int),false);
	tconguaglio.defineColumn("iddebito", typeof(int),false);
	tconguaglio.defineColumn("iddebito_credito", typeof(int),false);
	tconguaglio.defineColumn("idpagamento", typeof(int),false);
	tconguaglio.defineColumn("idreg", typeof(int),false);
	tconguaglio.defineColumn("importo", typeof(decimal));
	tconguaglio.defineColumn("lt", typeof(DateTime));
	tconguaglio.defineColumn("lu", typeof(string));
	tconguaglio.defineColumn("!iddebito_credito_debito_title", typeof(string));
	Tables.Add(tconguaglio);
	tconguaglio.defineKey("idconguaglio", "idcredito", "iddebito", "iddebito_credito", "idpagamento", "idreg");

	//////////////////// PAGAMENTODEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tpagamentodefaultview_alias1= new MetaTable("pagamentodefaultview_alias1");
	tpagamentodefaultview_alias1.defineColumn("iddebito", typeof(int),false);
	tpagamentodefaultview_alias1.defineColumn("idpagamento", typeof(int),false);
	tpagamentodefaultview_alias1.defineColumn("idreg", typeof(int),false);
	tpagamentodefaultview_alias1.defineColumn("pagamento_cu", typeof(string),false);
	tpagamentodefaultview_alias1.defineColumn("pagamento_lu", typeof(string),false);
	tpagamentodefaultview_alias1.defineColumn("pagamentokind_title", typeof(string));
	tpagamentodefaultview_alias1.ExtendedProperties["TableForReading"]="pagamentodefaultview";
	Tables.Add(tpagamentodefaultview_alias1);
	tpagamentodefaultview_alias1.defineKey("iddebito", "idpagamento", "idreg");

	//////////////////// DEBITOSEGVIEW /////////////////////////////////
	var tdebitosegview= new MetaTable("debitosegview");
	tdebitosegview.defineColumn("dropdown_title", typeof(string),false);
	tdebitosegview.defineColumn("iddebito", typeof(int),false);
	Tables.Add(tdebitosegview);
	tdebitosegview.defineKey("iddebito");

	//////////////////// CREDITO /////////////////////////////////
	var tcredito= new MetaTable("credito");
	tcredito.defineColumn("autorizzato", typeof(string));
	tcredito.defineColumn("ct", typeof(DateTime),false);
	tcredito.defineColumn("cu", typeof(string),false);
	tcredito.defineColumn("idcredito", typeof(int),false);
	tcredito.defineColumn("iddebito", typeof(int),false);
	tcredito.defineColumn("idpagamento", typeof(int),false);
	tcredito.defineColumn("idreg", typeof(int),false);
	tcredito.defineColumn("lt", typeof(DateTime),false);
	tcredito.defineColumn("lu", typeof(string),false);
	Tables.Add(tcredito);
	tcredito.defineKey("idcredito", "iddebito", "idpagamento", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{credito.Columns["iddebito"], credito.Columns["idpagamento"], credito.Columns["idreg"]};
	var cChild = new []{pagamento.Columns["iddebito"], pagamento.Columns["idpagamento"], pagamento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pagamento_credito_iddebito-idpagamento-idreg",cPar,cChild,false));

	cPar = new []{pagamentokind.Columns["idpagamentokind"]};
	cChild = new []{pagamento.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_pagamento_pagamentokind_idpagamentokind",cPar,cChild,false));

	cPar = new []{credito.Columns["idcredito"], credito.Columns["iddebito"], credito.Columns["idpagamento"], credito.Columns["idreg"]};
	cChild = new []{liquidazione.Columns["idcredito"], liquidazione.Columns["iddebito_credito"], liquidazione.Columns["idpagamento"], liquidazione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_liquidazione_credito_idcredito-iddebito_credito-idpagamento-idreg",cPar,cChild,false));

	cPar = new []{credito.Columns["idcredito"], credito.Columns["iddebito"], credito.Columns["idpagamento"], credito.Columns["idreg"]};
	cChild = new []{conguaglio.Columns["idcredito"], conguaglio.Columns["iddebito"], conguaglio.Columns["idpagamento"], conguaglio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_conguaglio_credito_idcredito-iddebito-idpagamento-idreg",cPar,cChild,false));

	cPar = new []{debito.Columns["iddebito"]};
	cChild = new []{conguaglio.Columns["iddebito_credito"]};
	Relations.Add(new DataRelation("FK_conguaglio_debito_iddebito_credito",cPar,cChild,false));

	cPar = new []{pagamentodefaultview_alias1.Columns["idpagamento"]};
	cChild = new []{credito.Columns["idpagamento"]};
	Relations.Add(new DataRelation("FK_credito_pagamentodefaultview_alias1_idpagamento",cPar,cChild,false));

	cPar = new []{debitosegview.Columns["iddebito"]};
	cChild = new []{pagamentodefaultview_alias1.Columns["iddebito"]};
	Relations.Add(new DataRelation("FK_pagamentodefaultview_alias1_debitosegview_iddebito",cPar,cChild,false));

	cPar = new []{debitosegview.Columns["iddebito"]};
	cChild = new []{credito.Columns["iddebito"]};
	Relations.Add(new DataRelation("FK_credito_debitosegview_iddebito",cPar,cChild,false));

	#endregion

}
}
}
