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
[System.Xml.Serialization.XmlRoot("dsmeta_conguaglio_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_conguaglio_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentodefaultview 		=> (MetaTable)Tables["pagamentodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debito 		=> (MetaTable)Tables["debito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable creditosegview 		=> (MetaTable)Tables["creditosegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable conguaglio 		=> (MetaTable)Tables["conguaglio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_conguaglio_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_conguaglio_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_conguaglio_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_conguaglio_seg.xsd";

	#region create DataTables
	//////////////////// PAGAMENTODEFAULTVIEW /////////////////////////////////
	var tpagamentodefaultview= new MetaTable("pagamentodefaultview");
	tpagamentodefaultview.defineColumn("iddebito", typeof(int),false);
	tpagamentodefaultview.defineColumn("idpagamento", typeof(int),false);
	tpagamentodefaultview.defineColumn("idreg", typeof(int),false);
	tpagamentodefaultview.defineColumn("pagamento_cu", typeof(string),false);
	tpagamentodefaultview.defineColumn("pagamento_lu", typeof(string),false);
	tpagamentodefaultview.defineColumn("pagamentokind_title", typeof(string));
	Tables.Add(tpagamentodefaultview);
	tpagamentodefaultview.defineKey("iddebito", "idpagamento", "idreg");

	//////////////////// DEBITO /////////////////////////////////
	var tdebito= new MetaTable("debito");
	tdebito.defineColumn("iddebito", typeof(int),false);
	tdebito.defineColumn("idreg", typeof(int),false);
	tdebito.defineColumn("title", typeof(string));
	Tables.Add(tdebito);
	tdebito.defineKey("iddebito", "idreg");

	//////////////////// CREDITOSEGVIEW /////////////////////////////////
	var tcreditosegview= new MetaTable("creditosegview");
	tcreditosegview.defineColumn("dropdown_title", typeof(string),false);
	tcreditosegview.defineColumn("idcredito", typeof(int),false);
	tcreditosegview.defineColumn("iddebito", typeof(int),false);
	tcreditosegview.defineColumn("idpagamento", typeof(int),false);
	tcreditosegview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tcreditosegview);
	tcreditosegview.defineKey("idcredito", "iddebito", "idpagamento", "idreg");

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
	Tables.Add(tconguaglio);
	tconguaglio.defineKey("idconguaglio", "idcredito", "iddebito", "iddebito_credito", "idpagamento", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{pagamentodefaultview.Columns["idpagamento"]};
	var cChild = new []{conguaglio.Columns["idpagamento"]};
	Relations.Add(new DataRelation("FK_conguaglio_pagamentodefaultview_idpagamento",cPar,cChild,false));

	cPar = new []{creditosegview.Columns["iddebito"], creditosegview.Columns["idpagamento"], creditosegview.Columns["idreg"]};
	cChild = new []{pagamentodefaultview.Columns["iddebito"], pagamentodefaultview.Columns["idpagamento"], pagamentodefaultview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pagamentodefaultview_creditosegview_iddebito",cPar,cChild,false));

	cPar = new []{debito.Columns["iddebito"]};
	cChild = new []{conguaglio.Columns["iddebito_credito"]};
	Relations.Add(new DataRelation("FK_conguaglio_debito_iddebito_credito",cPar,cChild,false));

	cPar = new []{creditosegview.Columns["iddebito"], creditosegview.Columns["idreg"]};
	cChild = new []{debito.Columns["iddebito"], debito.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_debito_creditosegview_iddebito",cPar,cChild,false));

	cPar = new []{creditosegview.Columns["idcredito"]};
	cChild = new []{conguaglio.Columns["idcredito"]};
	Relations.Add(new DataRelation("FK_conguaglio_creditosegview_idcredito",cPar,cChild,false));

	#endregion

}
}
}
