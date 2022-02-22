
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
[System.Xml.Serialization.XmlRoot("dsmeta_creditoistanza_rimb_segistrimb"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_creditoistanza_rimb_segistrimb: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamento 		=> (MetaTable)Tables["pagamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debito 		=> (MetaTable)Tables["debito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable credito 		=> (MetaTable)Tables["credito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable creditoistanza_rimb 		=> (MetaTable)Tables["creditoistanza_rimb"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_creditoistanza_rimb_segistrimb(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_creditoistanza_rimb_segistrimb (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_creditoistanza_rimb_segistrimb";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_creditoistanza_rimb_segistrimb.xsd";

	#region create DataTables
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
	Tables.Add(tpagamento);
	tpagamento.defineKey("iddebito", "idpagamento", "idreg");

	//////////////////// DEBITO /////////////////////////////////
	var tdebito= new MetaTable("debito");
	tdebito.defineColumn("codicebollettino", typeof(string));
	tdebito.defineColumn("codicemav", typeof(string));
	tdebito.defineColumn("ct", typeof(DateTime),false);
	tdebito.defineColumn("cu", typeof(string),false);
	tdebito.defineColumn("iddebito", typeof(int),false);
	tdebito.defineColumn("idiscrizione", typeof(int));
	tdebito.defineColumn("idistanza", typeof(int));
	tdebito.defineColumn("idnullaosta", typeof(int));
	tdebito.defineColumn("idreg", typeof(int),false);
	tdebito.defineColumn("idtassaconf", typeof(int));
	tdebito.defineColumn("IUV", typeof(string));
	tdebito.defineColumn("lt", typeof(DateTime),false);
	tdebito.defineColumn("lu", typeof(string),false);
	tdebito.defineColumn("scadenza", typeof(DateTime));
	tdebito.defineColumn("title", typeof(string));
	Tables.Add(tdebito);
	tdebito.defineKey("iddebito", "idreg");

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

	//////////////////// CREDITOISTANZA_RIMB /////////////////////////////////
	var tcreditoistanza_rimb= new MetaTable("creditoistanza_rimb");
	tcreditoistanza_rimb.defineColumn("ct", typeof(DateTime),false);
	tcreditoistanza_rimb.defineColumn("cu", typeof(string),false);
	tcreditoistanza_rimb.defineColumn("idcredito", typeof(int),false);
	tcreditoistanza_rimb.defineColumn("iddebito", typeof(int),false);
	tcreditoistanza_rimb.defineColumn("idistanza", typeof(int),false);
	tcreditoistanza_rimb.defineColumn("idpagamento", typeof(int),false);
	tcreditoistanza_rimb.defineColumn("idreg", typeof(int),false);
	tcreditoistanza_rimb.defineColumn("lt", typeof(DateTime),false);
	tcreditoistanza_rimb.defineColumn("lu", typeof(string),false);
	Tables.Add(tcreditoistanza_rimb);
	tcreditoistanza_rimb.defineKey("idcredito", "iddebito", "idistanza", "idpagamento", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{pagamento.Columns["idpagamento"]};
	var cChild = new []{creditoistanza_rimb.Columns["idpagamento"]};
	Relations.Add(new DataRelation("FK_creditoistanza_rimb_pagamento_idpagamento",cPar,cChild,false));

	cPar = new []{debito.Columns["iddebito"]};
	cChild = new []{creditoistanza_rimb.Columns["iddebito"]};
	Relations.Add(new DataRelation("FK_creditoistanza_rimb_debito_iddebito",cPar,cChild,false));

	cPar = new []{credito.Columns["idcredito"]};
	cChild = new []{creditoistanza_rimb.Columns["idcredito"]};
	Relations.Add(new DataRelation("FK_creditoistanza_rimb_credito_idcredito",cPar,cChild,false));

	#endregion

}
}
}
