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
[System.Xml.Serialization.XmlRoot("dsmeta_debito_seganagstu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_debito_seganagstu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamento 		=> (MetaTable)Tables["pagamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonero 		=> (MetaTable)Tables["esonero"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonerostudente 		=> (MetaTable)Tables["esonerostudente"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debitoesonero 		=> (MetaTable)Tables["debitoesonero"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ratadef 		=> (MetaTable)Tables["ratadef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fasciaiseedef 		=> (MetaTable)Tables["fasciaiseedef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefdettagliokind 		=> (MetaTable)Tables["costoscontodefdettagliokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefdettaglio 		=> (MetaTable)Tables["costoscontodefdettaglio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef 		=> (MetaTable)Tables["costoscontodef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debitodettaglio 		=> (MetaTable)Tables["debitodettaglio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokind 		=> (MetaTable)Tables["pagamentokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamento_alias2 		=> (MetaTable)Tables["pagamento_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debito_alias2 		=> (MetaTable)Tables["debito_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamento_alias1 		=> (MetaTable)Tables["pagamento_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debito_alias1 		=> (MetaTable)Tables["debito_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable credito 		=> (MetaTable)Tables["credito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable conguaglio 		=> (MetaTable)Tables["conguaglio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tassaconfdefaultview 		=> (MetaTable)Tables["tassaconfdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta 		=> (MetaTable)Tables["nullaosta"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzasegstuelencoview_alias14 		=> (MetaTable)Tables["istanzasegstuelencoview_alias14"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debito 		=> (MetaTable)Tables["debito"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_debito_seganagstu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_debito_seganagstu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_debito_seganagstu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_debito_seganagstu.xsd";

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
	tpagamento.defineColumn("!idpagamentokind_pagamentokind_title", typeof(string));
	Tables.Add(tpagamento);
	tpagamento.defineKey("iddebito", "idpagamento", "idreg");

	//////////////////// ESONERO /////////////////////////////////
	var tesonero= new MetaTable("esonero");
	tesonero.defineColumn("idesonero", typeof(int),false);
	tesonero.defineColumn("title", typeof(string),false);
	Tables.Add(tesonero);
	tesonero.defineKey("idesonero");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idsede", typeof(int),false);
	tdidprog.defineColumn("title", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ISCRIZIONE /////////////////////////////////
	var tiscrizione= new MetaTable("iscrizione");
	tiscrizione.defineColumn("aa", typeof(string),false);
	tiscrizione.defineColumn("anno", typeof(int));
	tiscrizione.defineColumn("ct", typeof(DateTime),false);
	tiscrizione.defineColumn("cu", typeof(string),false);
	tiscrizione.defineColumn("data", typeof(DateTime));
	tiscrizione.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione.defineColumn("iddidprog", typeof(int),false);
	tiscrizione.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione.defineColumn("idreg", typeof(int),false);
	tiscrizione.defineColumn("lt", typeof(DateTime),false);
	tiscrizione.defineColumn("lu", typeof(string),false);
	tiscrizione.defineColumn("matricola", typeof(string));
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// ESONEROSTUDENTE /////////////////////////////////
	var tesonerostudente= new MetaTable("esonerostudente");
	tesonerostudente.defineColumn("aa", typeof(string));
	tesonerostudente.defineColumn("ct", typeof(DateTime),false);
	tesonerostudente.defineColumn("cu", typeof(string),false);
	tesonerostudente.defineColumn("esito", typeof(string));
	tesonerostudente.defineColumn("idesonero", typeof(int),false);
	tesonerostudente.defineColumn("idesonerostudente", typeof(int),false);
	tesonerostudente.defineColumn("idiscrizione", typeof(int));
	tesonerostudente.defineColumn("idreg", typeof(int),false);
	tesonerostudente.defineColumn("lt", typeof(DateTime),false);
	tesonerostudente.defineColumn("lu", typeof(string),false);
	Tables.Add(tesonerostudente);
	tesonerostudente.defineKey("idesonero", "idesonerostudente", "idreg");

	//////////////////// DEBITOESONERO /////////////////////////////////
	var tdebitoesonero= new MetaTable("debitoesonero");
	tdebitoesonero.defineColumn("ct", typeof(DateTime));
	tdebitoesonero.defineColumn("cu", typeof(string));
	tdebitoesonero.defineColumn("iddebito", typeof(int),false);
	tdebitoesonero.defineColumn("idesonerostudente", typeof(int),false);
	tdebitoesonero.defineColumn("lt", typeof(DateTime));
	tdebitoesonero.defineColumn("lu", typeof(string));
	tdebitoesonero.defineColumn("!idesonerostudente_esonero_title", typeof(string));
	tdebitoesonero.defineColumn("!idesonerostudente_annoaccademico_aa", typeof(string));
	tdebitoesonero.defineColumn("!idesonerostudente_esonerostudente_esito", typeof(string));
	tdebitoesonero.defineColumn("!idesonerostudente_iscrizione_anno", typeof(int));
	tdebitoesonero.defineColumn("!idesonerostudente_iscrizione_annoaccademico_aa", typeof(string));
	tdebitoesonero.defineColumn("!idesonerostudente_iscrizione_didprog_title", typeof(string));
	tdebitoesonero.defineColumn("!idesonerostudente_iscrizione_didprog_aa", typeof(string));
	tdebitoesonero.defineColumn("!idesonerostudente_iscrizione_didprog_idsede", typeof(int));
	tdebitoesonero.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tdebitoesonero);
	tdebitoesonero.defineKey("iddebito", "idesonerostudente");

	//////////////////// RATADEF /////////////////////////////////
	var tratadef= new MetaTable("ratadef");
	tratadef.defineColumn("idcostoscontodef", typeof(int),false);
	tratadef.defineColumn("idfasciaiseedef", typeof(int),false);
	tratadef.defineColumn("idratadef", typeof(int),false);
	tratadef.defineColumn("idratakind", typeof(string));
	Tables.Add(tratadef);
	tratadef.defineKey("idcostoscontodef", "idfasciaiseedef", "idratadef");

	//////////////////// FASCIAISEEDEF /////////////////////////////////
	var tfasciaiseedef= new MetaTable("fasciaiseedef");
	tfasciaiseedef.defineColumn("idcostoscontodef", typeof(int),false);
	tfasciaiseedef.defineColumn("idfasciaisee", typeof(string),false);
	tfasciaiseedef.defineColumn("idfasciaiseedef", typeof(int),false);
	Tables.Add(tfasciaiseedef);
	tfasciaiseedef.defineKey("idcostoscontodef", "idfasciaiseedef");

	//////////////////// COSTOSCONTODEFDETTAGLIOKIND /////////////////////////////////
	var tcostoscontodefdettagliokind= new MetaTable("costoscontodefdettagliokind");
	tcostoscontodefdettagliokind.defineColumn("active", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("idcostoscontodefdettagliokind", typeof(int),false);
	tcostoscontodefdettagliokind.defineColumn("title", typeof(string));
	Tables.Add(tcostoscontodefdettagliokind);
	tcostoscontodefdettagliokind.defineKey("idcostoscontodefdettagliokind");

	//////////////////// COSTOSCONTODEFDETTAGLIO /////////////////////////////////
	var tcostoscontodefdettaglio= new MetaTable("costoscontodefdettaglio");
	tcostoscontodefdettaglio.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("idcostoscontodefdettaglio", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("idcostoscontodefdettagliokind", typeof(int));
	tcostoscontodefdettaglio.defineColumn("idfasciaiseedef", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("idratadef", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("importo", typeof(decimal));
	Tables.Add(tcostoscontodefdettaglio);
	tcostoscontodefdettaglio.defineKey("idcostoscontodef", "idcostoscontodefdettaglio", "idfasciaiseedef", "idratadef");

	//////////////////// COSTOSCONTODEF /////////////////////////////////
	var tcostoscontodef= new MetaTable("costoscontodef");
	tcostoscontodef.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodef.defineColumn("title", typeof(string));
	Tables.Add(tcostoscontodef);
	tcostoscontodef.defineKey("idcostoscontodef");

	//////////////////// DEBITODETTAGLIO /////////////////////////////////
	var tdebitodettaglio= new MetaTable("debitodettaglio");
	tdebitodettaglio.defineColumn("ct", typeof(DateTime));
	tdebitodettaglio.defineColumn("cu", typeof(string));
	tdebitodettaglio.defineColumn("idcostoscontodef", typeof(int),false);
	tdebitodettaglio.defineColumn("idcostoscontodefdettaglio", typeof(int));
	tdebitodettaglio.defineColumn("iddebito", typeof(int),false);
	tdebitodettaglio.defineColumn("iddebitodettaglio", typeof(int),false);
	tdebitodettaglio.defineColumn("idfasciaiseedef", typeof(int),false);
	tdebitodettaglio.defineColumn("idratadef", typeof(int),false);
	tdebitodettaglio.defineColumn("idreg", typeof(int),false);
	tdebitodettaglio.defineColumn("importo", typeof(decimal));
	tdebitodettaglio.defineColumn("lt", typeof(DateTime));
	tdebitodettaglio.defineColumn("lu", typeof(string));
	tdebitodettaglio.defineColumn("!idcostoscontodef_costoscontodef_title", typeof(string));
	tdebitodettaglio.defineColumn("!idcostoscontodefdettaglio_costoscontodefdettaglio_idfasciaiseedef", typeof(int));
	tdebitodettaglio.defineColumn("!idcostoscontodefdettaglio_costoscontodefdettaglio_idratadef", typeof(int));
	tdebitodettaglio.defineColumn("!idcostoscontodefdettaglio_costoscontodefdettaglio_importo", typeof(decimal));
	tdebitodettaglio.defineColumn("!idcostoscontodefdettaglio_costoscontodefdettaglio_idcostoscontodefdettagliokind_title", typeof(string));
	tdebitodettaglio.defineColumn("!idfasciaiseedef_fasciaiseedef_idfasciaisee", typeof(string));
	tdebitodettaglio.defineColumn("!idratadef_ratadef_idratakind", typeof(string));
	Tables.Add(tdebitodettaglio);
	tdebitodettaglio.defineKey("idcostoscontodef", "iddebito", "iddebitodettaglio", "idfasciaiseedef", "idratadef", "idreg");

	//////////////////// PAGAMENTOKIND /////////////////////////////////
	var tpagamentokind= new MetaTable("pagamentokind");
	tpagamentokind.defineColumn("active", typeof(string),false);
	tpagamentokind.defineColumn("idpagamentokind", typeof(int),false);
	tpagamentokind.defineColumn("title", typeof(string),false);
	Tables.Add(tpagamentokind);
	tpagamentokind.defineKey("idpagamentokind");

	//////////////////// PAGAMENTO_ALIAS2 /////////////////////////////////
	var tpagamento_alias2= new MetaTable("pagamento_alias2");
	tpagamento_alias2.defineColumn("dataora", typeof(DateTime));
	tpagamento_alias2.defineColumn("iddebito", typeof(int),false);
	tpagamento_alias2.defineColumn("idpagamento", typeof(int),false);
	tpagamento_alias2.defineColumn("idpagamentokind", typeof(int));
	tpagamento_alias2.defineColumn("idreg", typeof(int),false);
	tpagamento_alias2.ExtendedProperties["TableForReading"]="pagamento";
	Tables.Add(tpagamento_alias2);
	tpagamento_alias2.defineKey("iddebito", "idpagamento", "idreg");

	//////////////////// DEBITO_ALIAS2 /////////////////////////////////
	var tdebito_alias2= new MetaTable("debito_alias2");
	tdebito_alias2.defineColumn("iddebito", typeof(int),false);
	tdebito_alias2.defineColumn("idreg", typeof(int),false);
	tdebito_alias2.defineColumn("title", typeof(string));
	tdebito_alias2.ExtendedProperties["TableForReading"]="debito";
	Tables.Add(tdebito_alias2);
	tdebito_alias2.defineKey("iddebito", "idreg");

	//////////////////// PAGAMENTO_ALIAS1 /////////////////////////////////
	var tpagamento_alias1= new MetaTable("pagamento_alias1");
	tpagamento_alias1.defineColumn("dataora", typeof(DateTime));
	tpagamento_alias1.defineColumn("iddebito", typeof(int),false);
	tpagamento_alias1.defineColumn("idpagamento", typeof(int),false);
	tpagamento_alias1.defineColumn("idpagamentokind", typeof(int));
	tpagamento_alias1.defineColumn("idreg", typeof(int),false);
	tpagamento_alias1.ExtendedProperties["TableForReading"]="pagamento";
	Tables.Add(tpagamento_alias1);
	tpagamento_alias1.defineKey("iddebito", "idpagamento", "idreg");

	//////////////////// DEBITO_ALIAS1 /////////////////////////////////
	var tdebito_alias1= new MetaTable("debito_alias1");
	tdebito_alias1.defineColumn("iddebito", typeof(int),false);
	tdebito_alias1.defineColumn("idreg", typeof(int),false);
	tdebito_alias1.defineColumn("title", typeof(string));
	tdebito_alias1.ExtendedProperties["TableForReading"]="debito";
	Tables.Add(tdebito_alias1);
	tdebito_alias1.defineKey("iddebito", "idreg");

	//////////////////// CREDITO /////////////////////////////////
	var tcredito= new MetaTable("credito");
	tcredito.defineColumn("autorizzato", typeof(string));
	tcredito.defineColumn("idcredito", typeof(int),false);
	tcredito.defineColumn("iddebito", typeof(int),false);
	tcredito.defineColumn("idpagamento", typeof(int),false);
	tcredito.defineColumn("idreg", typeof(int),false);
	Tables.Add(tcredito);
	tcredito.defineKey("idcredito", "iddebito", "idpagamento", "idreg");

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
	tconguaglio.defineColumn("!idcredito_credito_autorizzato", typeof(string));
	tconguaglio.defineColumn("!idcredito_credito_iddebito_title", typeof(string));
	tconguaglio.defineColumn("!idcredito_credito_idpagamento_dataora", typeof(DateTime));
	tconguaglio.defineColumn("!idcredito_credito_idpagamento_idpagamentokind", typeof(int));
	tconguaglio.defineColumn("!iddebito_credito_debito_title", typeof(string));
	tconguaglio.defineColumn("!idpagamento_pagamento_dataora", typeof(DateTime));
	tconguaglio.defineColumn("!idpagamento_pagamento_idpagamentokind_title", typeof(string));
	Tables.Add(tconguaglio);
	tconguaglio.defineKey("idconguaglio", "idcredito", "iddebito", "iddebito_credito", "idpagamento", "idreg");

	//////////////////// TASSACONFDEFAULTVIEW /////////////////////////////////
	var ttassaconfdefaultview= new MetaTable("tassaconfdefaultview");
	ttassaconfdefaultview.defineColumn("dropdown_title", typeof(string),false);
	ttassaconfdefaultview.defineColumn("idtassaconf", typeof(int),false);
	Tables.Add(ttassaconfdefaultview);
	ttassaconfdefaultview.defineKey("idtassaconf");

	//////////////////// NULLAOSTA /////////////////////////////////
	var tnullaosta= new MetaTable("nullaosta");
	tnullaosta.defineColumn("extension", typeof(string));
	tnullaosta.defineColumn("idistanza", typeof(int),false);
	tnullaosta.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta.defineColumn("idreg", typeof(int),false);
	Tables.Add(tnullaosta);
	tnullaosta.defineKey("idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// ISTANZASEGSTUELENCOVIEW_ALIAS14 /////////////////////////////////
	var tistanzasegstuelencoview_alias14= new MetaTable("istanzasegstuelencoview_alias14");
	tistanzasegstuelencoview_alias14.defineColumn("aa", typeof(string),false);
	tistanzasegstuelencoview_alias14.defineColumn("dropdown_title", typeof(string),false);
	tistanzasegstuelencoview_alias14.defineColumn("idcorsostudio", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("iddidprog", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("idistanza", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("idistanzakind", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("idreg_studenti", typeof(int),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_ct", typeof(DateTime),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_cu", typeof(string),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_data", typeof(DateTime),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_extension", typeof(string));
	tistanzasegstuelencoview_alias14.defineColumn("istanza_idiscrizione", typeof(int));
	tistanzasegstuelencoview_alias14.defineColumn("istanza_idstatuskind", typeof(int));
	tistanzasegstuelencoview_alias14.defineColumn("istanza_lt", typeof(DateTime),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_lu", typeof(string),false);
	tistanzasegstuelencoview_alias14.defineColumn("istanza_paridistanza", typeof(int));
	tistanzasegstuelencoview_alias14.defineColumn("istanza_protanno", typeof(int));
	tistanzasegstuelencoview_alias14.defineColumn("istanza_protnumero", typeof(int));
	tistanzasegstuelencoview_alias14.defineColumn("istanzakind_title", typeof(string));
	tistanzasegstuelencoview_alias14.defineColumn("registrystudenti_title", typeof(string));
	tistanzasegstuelencoview_alias14.defineColumn("statuskind_title", typeof(string));
	tistanzasegstuelencoview_alias14.ExtendedProperties["TableForReading"]="istanzasegstuelencoview";
	Tables.Add(tistanzasegstuelencoview_alias14);
	tistanzasegstuelencoview_alias14.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("anno", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_aa", typeof(string));
	tiscrizionedefaultview.defineColumn("didprog_idsede", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_title", typeof(string));
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizionedefaultview.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizionedefaultview.defineColumn("registry_title", typeof(string));
	tiscrizionedefaultview.defineColumn("sede_title", typeof(string));
	Tables.Add(tiscrizionedefaultview);
	tiscrizionedefaultview.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{debito.Columns["iddebito"], debito.Columns["idreg"]};
	var cChild = new []{pagamento.Columns["iddebito"], pagamento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pagamento_debito_iddebito-idreg",cPar,cChild,false));

	cPar = new []{pagamentokind.Columns["idpagamentokind"]};
	cChild = new []{pagamento.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_pagamento_pagamentokind_idpagamentokind",cPar,cChild,false));

	cPar = new []{debito.Columns["iddebito"]};
	cChild = new []{debitoesonero.Columns["iddebito"]};
	Relations.Add(new DataRelation("FK_debitoesonero_debito_iddebito",cPar,cChild,false));

	cPar = new []{esonerostudente.Columns["idesonerostudente"]};
	cChild = new []{debitoesonero.Columns["idesonerostudente"]};
	Relations.Add(new DataRelation("FK_debitoesonero_esonerostudente_idesonerostudente",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"]};
	cChild = new []{esonerostudente.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_esonerostudente_iscrizione_idiscrizione",cPar,cChild,false));

	cPar = new []{esonero.Columns["idesonero"]};
	cChild = new []{esonerostudente.Columns["idesonero"]};
	Relations.Add(new DataRelation("FK_esonerostudente_esonero_idesonero",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{esonerostudente.Columns["aa"]};
	Relations.Add(new DataRelation("FK_esonerostudente_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{iscrizione.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{debito.Columns["iddebito"], debito.Columns["idreg"]};
	cChild = new []{debitodettaglio.Columns["iddebito"], debitodettaglio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_debitodettaglio_debito_iddebito-idreg",cPar,cChild,false));

	cPar = new []{ratadef.Columns["idratadef"]};
	cChild = new []{debitodettaglio.Columns["idratadef"]};
	Relations.Add(new DataRelation("FK_debitodettaglio_ratadef_idratadef",cPar,cChild,false));

	cPar = new []{fasciaiseedef.Columns["idfasciaiseedef"]};
	cChild = new []{debitodettaglio.Columns["idfasciaiseedef"]};
	Relations.Add(new DataRelation("FK_debitodettaglio_fasciaiseedef_idfasciaiseedef",cPar,cChild,false));

	cPar = new []{costoscontodefdettaglio.Columns["idcostoscontodefdettaglio"]};
	cChild = new []{debitodettaglio.Columns["idcostoscontodefdettaglio"]};
	Relations.Add(new DataRelation("FK_debitodettaglio_costoscontodefdettaglio_idcostoscontodefdettaglio",cPar,cChild,false));

	cPar = new []{costoscontodefdettagliokind.Columns["idcostoscontodefdettagliokind"]};
	cChild = new []{costoscontodefdettaglio.Columns["idcostoscontodefdettagliokind"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettaglio_costoscontodefdettagliokind_idcostoscontodefdettagliokind",cPar,cChild,false));

	cPar = new []{costoscontodef.Columns["idcostoscontodef"]};
	cChild = new []{debitodettaglio.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_debitodettaglio_costoscontodef_idcostoscontodef",cPar,cChild,false));

	cPar = new []{debito.Columns["iddebito"], debito.Columns["idreg"]};
	cChild = new []{conguaglio.Columns["iddebito"], conguaglio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_conguaglio_debito_iddebito-idreg",cPar,cChild,false));

	cPar = new []{pagamento_alias2.Columns["idpagamento"]};
	cChild = new []{conguaglio.Columns["idpagamento"]};
	Relations.Add(new DataRelation("FK_conguaglio_pagamento_alias2_idpagamento",cPar,cChild,false));

	cPar = new []{pagamentokind.Columns["idpagamentokind"]};
	cChild = new []{pagamento_alias2.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_pagamento_alias2_pagamentokind_idpagamentokind",cPar,cChild,false));

	cPar = new []{debito_alias2.Columns["iddebito"]};
	cChild = new []{conguaglio.Columns["iddebito_credito"]};
	Relations.Add(new DataRelation("FK_conguaglio_debito_alias2_iddebito_credito",cPar,cChild,false));

	cPar = new []{credito.Columns["idcredito"]};
	cChild = new []{conguaglio.Columns["idcredito"]};
	Relations.Add(new DataRelation("FK_conguaglio_credito_idcredito",cPar,cChild,false));

	cPar = new []{pagamento_alias1.Columns["idpagamento"]};
	cChild = new []{credito.Columns["idpagamento"]};
	Relations.Add(new DataRelation("FK_credito_pagamento_alias1_idpagamento",cPar,cChild,false));

	cPar = new []{debito_alias1.Columns["iddebito"]};
	cChild = new []{credito.Columns["iddebito"]};
	Relations.Add(new DataRelation("FK_credito_debito_alias1_iddebito",cPar,cChild,false));

	cPar = new []{tassaconfdefaultview.Columns["idtassaconf"]};
	cChild = new []{debito.Columns["idtassaconf"]};
	Relations.Add(new DataRelation("FK_debito_tassaconfdefaultview_idtassaconf",cPar,cChild,false));

	cPar = new []{nullaosta.Columns["idnullaosta"]};
	cChild = new []{debito.Columns["idnullaosta"]};
	Relations.Add(new DataRelation("FK_debito_nullaosta_idnullaosta",cPar,cChild,false));

	cPar = new []{istanzasegstuelencoview_alias14.Columns["idistanza"]};
	cChild = new []{nullaosta.Columns["idistanza"]};
	Relations.Add(new DataRelation("FK_nullaosta_istanzasegstuelencoview_alias14_idistanza",cPar,cChild,false));

	cPar = new []{istanzasegstuelencoview_alias14.Columns["idistanza"]};
	cChild = new []{debito.Columns["idistanza"]};
	Relations.Add(new DataRelation("FK_debito_istanzasegstuelencoview_alias14_idistanza",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{debito.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_debito_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	#endregion

}
}
}
