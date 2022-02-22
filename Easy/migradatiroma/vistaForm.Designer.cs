
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace migradatiroma {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatiXML 		=> Tables["MandatiXML"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoTestataFlusso 		=> Tables["MandatoTestataFlusso"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable Mandato 		=> Tables["Mandato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoAvvisoPagoPA 		=> Tables["MandatoAvvisoPagoPA"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoBollo 		=> Tables["MandatoBollo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoClassificazione 		=> Tables["MandatoClassificazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoClassificazioneDatiSiopeUscite 		=> Tables["MandatoClassificazioneDatiSiopeUscite"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoDatiADisposizioneEnteBeneficiario 		=> Tables["MandatoDatiADisposizioneEnteBeneficiario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoDatiFatturaSiope 		=> Tables["MandatoDatiFatturaSiope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoFatturaSiope 		=> Tables["MandatoFatturaSiope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoInformazioniAggiuntive 		=> Tables["MandatoInformazioniAggiuntive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoInformazioniBeneficiario 		=> Tables["MandatoInformazioniBeneficiario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoRitenute 		=> Tables["MandatoRitenute"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoSepaCreditTransfer 		=> Tables["MandatoSepaCreditTransfer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoSpese 		=> Tables["MandatoSpese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoDelegato 		=> Tables["MandatoDelegato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoCofogSiope 		=> Tables["MandatoCofogSiope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoDatiArconetSiope 		=> Tables["MandatoDatiArconetSiope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable no_table 		=> Tables["no_table"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoBeneficiario 		=> Tables["MandatoBeneficiario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleVersante 		=> Tables["ReversaleVersante"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable Reversale 		=> Tables["Reversale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleBollo 		=> Tables["ReversaleBollo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleClassificazione 		=> Tables["ReversaleClassificazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleClassificazioneDatiSiopeEntrate 		=> Tables["ReversaleClassificazioneDatiSiopeEntrate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleDatiADisposizioneEnteVersante 		=> Tables["ReversaleDatiADisposizioneEnteVersante"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleDatiFatturaSiope 		=> Tables["ReversaleDatiFatturaSiope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleFatturaSiope 		=> Tables["ReversaleFatturaSiope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleInformazioniVersante 		=> Tables["ReversaleInformazioniVersante"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleMandatoAssociato 		=> Tables["ReversaleMandatoAssociato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleSospeso 		=> Tables["ReversaleSospeso"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleTestataFlusso 		=> Tables["ReversaleTestataFlusso"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ReversaleInformazioniAggiuntive 		=> Tables["ReversaleInformazioniAggiuntive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable MandatoSospeso 		=> Tables["MandatoSospeso"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// MANDATIXML /////////////////////////////////
	var tMandatiXML= new DataTable("MandatiXML");
	C= new DataColumn("ID", typeof(int));
	C.AllowDBNull=false;
	tMandatiXML.Columns.Add(C);
	C= new DataColumn("XMLColumn", typeof(string));
	C.AllowDBNull=false;
	tMandatiXML.Columns.Add(C);
	Tables.Add(tMandatiXML);

	//////////////////// MANDATOTESTATAFLUSSO /////////////////////////////////
	var tMandatoTestataFlusso= new DataTable("MandatoTestataFlusso");
	C= new DataColumn("codice_ABI_BT", typeof(string));
	C.AllowDBNull=false;
	tMandatoTestataFlusso.Columns.Add(C);
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoTestataFlusso.Columns.Add(C);
	C= new DataColumn("data_ora_creazione_flusso", typeof(DateTime));
	C.AllowDBNull=false;
	tMandatoTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_ente", typeof(string));
	C.AllowDBNull=false;
	tMandatoTestataFlusso.Columns.Add(C);
	C= new DataColumn("descrizione_ente", typeof(string));
	C.AllowDBNull=false;
	tMandatoTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_istat_ente", typeof(string));
	C.AllowDBNull=false;
	tMandatoTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_fiscale_ente", typeof(string));
	C.AllowDBNull=false;
	tMandatoTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_tramite_ente", typeof(string));
	C.AllowDBNull=false;
	tMandatoTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_tramite_BT", typeof(string));
	C.AllowDBNull=false;
	tMandatoTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_ente_BT", typeof(string));
	C.AllowDBNull=false;
	tMandatoTestataFlusso.Columns.Add(C);
	tMandatoTestataFlusso.Columns.Add( new DataColumn("riferimento_ente", typeof(string)));
	Tables.Add(tMandatoTestataFlusso);
	tMandatoTestataFlusso.PrimaryKey =  new DataColumn[]{tMandatoTestataFlusso.Columns["codice_ABI_BT"], tMandatoTestataFlusso.Columns["identificativo_flusso"], tMandatoTestataFlusso.Columns["data_ora_creazione_flusso"]};


	//////////////////// MANDATO /////////////////////////////////
	var tMandato= new DataTable("Mandato");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandato.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandato.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandato.Columns.Add(C);
	C= new DataColumn("data_mandato", typeof(DateTime));
	C.AllowDBNull=false;
	tMandato.Columns.Add(C);
	C= new DataColumn("importo_mandato", typeof(decimal));
	C.AllowDBNull=false;
	tMandato.Columns.Add(C);
	tMandato.Columns.Add( new DataColumn("conto_evidenza", typeof(string)));
	tMandato.Columns.Add( new DataColumn("estremi_provvedimento_autorizzativo", typeof(string)));
	tMandato.Columns.Add( new DataColumn("responsabile_provvedimento", typeof(string)));
	tMandato.Columns.Add( new DataColumn("ufficio_responsabile", typeof(string)));
	C= new DataColumn("codice_struttura", typeof(string));
	C.AllowDBNull=false;
	tMandato.Columns.Add(C);
	Tables.Add(tMandato);
	tMandato.PrimaryKey =  new DataColumn[]{tMandato.Columns["identificativo_flusso"], tMandato.Columns["tipo_operazione"], tMandato.Columns["numero_mandato"]};


	//////////////////// MANDATOAVVISOPAGOPA /////////////////////////////////
	var tMandatoAvvisoPagoPA= new DataTable("MandatoAvvisoPagoPA");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoAvvisoPagoPA.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoAvvisoPagoPA.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoAvvisoPagoPA.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoAvvisoPagoPA.Columns.Add(C);
	tMandatoAvvisoPagoPA.Columns.Add( new DataColumn("riferimento_documento_esterno", typeof(string)));
	tMandatoAvvisoPagoPA.Columns.Add( new DataColumn("codice_identificativo_ente", typeof(string)));
	tMandatoAvvisoPagoPA.Columns.Add( new DataColumn("numero_avviso", typeof(string)));
	Tables.Add(tMandatoAvvisoPagoPA);
	tMandatoAvvisoPagoPA.PrimaryKey =  new DataColumn[]{tMandatoAvvisoPagoPA.Columns["identificativo_flusso"], tMandatoAvvisoPagoPA.Columns["tipo_operazione"], tMandatoAvvisoPagoPA.Columns["numero_mandato"], tMandatoAvvisoPagoPA.Columns["progressivo_beneficiario"]};


	//////////////////// MANDATOBOLLO /////////////////////////////////
	var tMandatoBollo= new DataTable("MandatoBollo");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoBollo.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoBollo.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoBollo.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoBollo.Columns.Add(C);
	C= new DataColumn("assoggettamento_bollo", typeof(string));
	C.AllowDBNull=false;
	tMandatoBollo.Columns.Add(C);
	tMandatoBollo.Columns.Add( new DataColumn("causale_esenzione_bollo", typeof(string)));
	Tables.Add(tMandatoBollo);
	tMandatoBollo.PrimaryKey =  new DataColumn[]{tMandatoBollo.Columns["identificativo_flusso"], tMandatoBollo.Columns["tipo_operazione"], tMandatoBollo.Columns["numero_mandato"], tMandatoBollo.Columns["progressivo_beneficiario"]};


	//////////////////// MANDATOCLASSIFICAZIONE /////////////////////////////////
	var tMandatoClassificazione= new DataTable("MandatoClassificazione");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoClassificazione.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoClassificazione.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoClassificazione.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoClassificazione.Columns.Add(C);
	tMandatoClassificazione.Columns.Add( new DataColumn("codice_cgu", typeof(string)));
	tMandatoClassificazione.Columns.Add( new DataColumn("codice_cup", typeof(string)));
	tMandatoClassificazione.Columns.Add( new DataColumn("importo", typeof(decimal)));
	Tables.Add(tMandatoClassificazione);
	tMandatoClassificazione.PrimaryKey =  new DataColumn[]{tMandatoClassificazione.Columns["identificativo_flusso"], tMandatoClassificazione.Columns["tipo_operazione"], tMandatoClassificazione.Columns["numero_mandato"], tMandatoClassificazione.Columns["progressivo_beneficiario"]};


	//////////////////// MANDATOCLASSIFICAZIONEDATISIOPEUSCITE /////////////////////////////////
	var tMandatoClassificazioneDatiSiopeUscite= new DataTable("MandatoClassificazioneDatiSiopeUscite");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoClassificazioneDatiSiopeUscite.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoClassificazioneDatiSiopeUscite.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoClassificazioneDatiSiopeUscite.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoClassificazioneDatiSiopeUscite.Columns.Add(C);
	tMandatoClassificazioneDatiSiopeUscite.Columns.Add( new DataColumn("codice_cgu", typeof(string)));
	tMandatoClassificazioneDatiSiopeUscite.Columns.Add( new DataColumn("tipo_debito_siope", typeof(string)));
	tMandatoClassificazioneDatiSiopeUscite.Columns.Add( new DataColumn("codice_cig_siope", typeof(string)));
	tMandatoClassificazioneDatiSiopeUscite.Columns.Add( new DataColumn("motivo_esclusione_cig_siope", typeof(string)));
	Tables.Add(tMandatoClassificazioneDatiSiopeUscite);
	tMandatoClassificazioneDatiSiopeUscite.PrimaryKey =  new DataColumn[]{tMandatoClassificazioneDatiSiopeUscite.Columns["identificativo_flusso"], tMandatoClassificazioneDatiSiopeUscite.Columns["tipo_operazione"], tMandatoClassificazioneDatiSiopeUscite.Columns["numero_mandato"], tMandatoClassificazioneDatiSiopeUscite.Columns["progressivo_beneficiario"]};


	//////////////////// MANDATODATIADISPOSIZIONEENTEBENEFICIARIO /////////////////////////////////
	var tMandatoDatiADisposizioneEnteBeneficiario= new DataTable("MandatoDatiADisposizioneEnteBeneficiario");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoDatiADisposizioneEnteBeneficiario.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoDatiADisposizioneEnteBeneficiario.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoDatiADisposizioneEnteBeneficiario.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoDatiADisposizioneEnteBeneficiario.Columns.Add(C);
	Tables.Add(tMandatoDatiADisposizioneEnteBeneficiario);
	tMandatoDatiADisposizioneEnteBeneficiario.PrimaryKey =  new DataColumn[]{tMandatoDatiADisposizioneEnteBeneficiario.Columns["identificativo_flusso"], tMandatoDatiADisposizioneEnteBeneficiario.Columns["tipo_operazione"], tMandatoDatiADisposizioneEnteBeneficiario.Columns["numero_mandato"], tMandatoDatiADisposizioneEnteBeneficiario.Columns["progressivo_beneficiario"]};


	//////////////////// MANDATODATIFATTURASIOPE /////////////////////////////////
	var tMandatoDatiFatturaSiope= new DataTable("MandatoDatiFatturaSiope");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoDatiFatturaSiope.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoDatiFatturaSiope.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoDatiFatturaSiope.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoDatiFatturaSiope.Columns.Add(C);
	C= new DataColumn("codice_cgu", typeof(string));
	C.AllowDBNull=false;
	tMandatoDatiFatturaSiope.Columns.Add(C);
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("tipo_debito_siope", typeof(string)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("codice_cig_siope", typeof(string)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("codice_ipa_ente_siope", typeof(string)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("tipo_documento_siope_e", typeof(string)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("identificativo_lotto_sdi_siope", typeof(string)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("numero_fattura_siope", typeof(string)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("importo_siope", typeof(decimal)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("data_scadenza_pagam_siope", typeof(DateTime)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("motivo_scadenza_siope", typeof(string)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("natura_spesa_siope", typeof(string)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("utilizzo_nota_di_credito", typeof(string)));
	Tables.Add(tMandatoDatiFatturaSiope);

	//////////////////// MANDATOFATTURASIOPE /////////////////////////////////
	var tMandatoFatturaSiope= new DataTable("MandatoFatturaSiope");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoFatturaSiope.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoFatturaSiope.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoFatturaSiope.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoFatturaSiope.Columns.Add(C);
	tMandatoFatturaSiope.Columns.Add( new DataColumn("codice_cgu", typeof(string)));
	tMandatoFatturaSiope.Columns.Add( new DataColumn("tipo_debito_siope", typeof(string)));
	tMandatoFatturaSiope.Columns.Add( new DataColumn("codice_cig_siope", typeof(string)));
	tMandatoFatturaSiope.Columns.Add( new DataColumn("codice_ipa_ente_siope", typeof(string)));
	tMandatoFatturaSiope.Columns.Add( new DataColumn("tipo_documento_siope_e", typeof(string)));
	tMandatoFatturaSiope.Columns.Add( new DataColumn("identificativo_lotto_sdi_siope", typeof(string)));
	Tables.Add(tMandatoFatturaSiope);

	//////////////////// MANDATOINFORMAZIONIAGGIUNTIVE /////////////////////////////////
	var tMandatoInformazioniAggiuntive= new DataTable("MandatoInformazioniAggiuntive");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoInformazioniAggiuntive.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoInformazioniAggiuntive.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoInformazioniAggiuntive.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoInformazioniAggiuntive.Columns.Add(C);
	tMandatoInformazioniAggiuntive.Columns.Add( new DataColumn("lingua", typeof(string)));
	tMandatoInformazioniAggiuntive.Columns.Add( new DataColumn("riferimento_documento_esterno", typeof(string)));
	Tables.Add(tMandatoInformazioniAggiuntive);
	tMandatoInformazioniAggiuntive.PrimaryKey =  new DataColumn[]{tMandatoInformazioniAggiuntive.Columns["identificativo_flusso"], tMandatoInformazioniAggiuntive.Columns["tipo_operazione"], tMandatoInformazioniAggiuntive.Columns["numero_mandato"], tMandatoInformazioniAggiuntive.Columns["progressivo_beneficiario"]};


	//////////////////// MANDATOINFORMAZIONIBENEFICIARIO /////////////////////////////////
	var tMandatoInformazioniBeneficiario= new DataTable("MandatoInformazioniBeneficiario");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoInformazioniBeneficiario.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoInformazioniBeneficiario.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoInformazioniBeneficiario.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoInformazioniBeneficiario.Columns.Add(C);
	C= new DataColumn("importo_beneficiario", typeof(decimal));
	C.AllowDBNull=false;
	tMandatoInformazioniBeneficiario.Columns.Add(C);
	C= new DataColumn("tipo_pagamento", typeof(string));
	C.AllowDBNull=false;
	tMandatoInformazioniBeneficiario.Columns.Add(C);
	tMandatoInformazioniBeneficiario.Columns.Add( new DataColumn("data_esecuzione_pagamento", typeof(DateTime)));
	tMandatoInformazioniBeneficiario.Columns.Add( new DataColumn("data_scadenza_pagamento", typeof(DateTime)));
	tMandatoInformazioniBeneficiario.Columns.Add( new DataColumn("destinazione", typeof(string)));
	tMandatoInformazioniBeneficiario.Columns.Add( new DataColumn("numero_conto_banca_italia_ente_ricevente", typeof(string)));
	tMandatoInformazioniBeneficiario.Columns.Add( new DataColumn("tipo_contabilita_ente_ricevente", typeof(string)));
	tMandatoInformazioniBeneficiario.Columns.Add( new DataColumn("causale", typeof(string)));
	Tables.Add(tMandatoInformazioniBeneficiario);
	tMandatoInformazioniBeneficiario.PrimaryKey =  new DataColumn[]{tMandatoInformazioniBeneficiario.Columns["identificativo_flusso"], tMandatoInformazioniBeneficiario.Columns["tipo_operazione"], tMandatoInformazioniBeneficiario.Columns["numero_mandato"], tMandatoInformazioniBeneficiario.Columns["progressivo_beneficiario"]};


	//////////////////// MANDATORITENUTE /////////////////////////////////
	var tMandatoRitenute= new DataTable("MandatoRitenute");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoRitenute.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoRitenute.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoRitenute.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoRitenute.Columns.Add(C);
	tMandatoRitenute.Columns.Add( new DataColumn("importo_ritenute", typeof(decimal)));
	tMandatoRitenute.Columns.Add( new DataColumn("numero_reversale", typeof(int)));
	tMandatoRitenute.Columns.Add( new DataColumn("progressivo_versante", typeof(int)));
	Tables.Add(tMandatoRitenute);

	//////////////////// MANDATOSEPACREDITTRANSFER /////////////////////////////////
	var tMandatoSepaCreditTransfer= new DataTable("MandatoSepaCreditTransfer");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoSepaCreditTransfer.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoSepaCreditTransfer.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoSepaCreditTransfer.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoSepaCreditTransfer.Columns.Add(C);
	tMandatoSepaCreditTransfer.Columns.Add( new DataColumn("iban", typeof(string)));
	tMandatoSepaCreditTransfer.Columns.Add( new DataColumn("bic", typeof(string)));
	tMandatoSepaCreditTransfer.Columns.Add( new DataColumn("identificativo_end_to_end", typeof(string)));
	Tables.Add(tMandatoSepaCreditTransfer);
	tMandatoSepaCreditTransfer.PrimaryKey =  new DataColumn[]{tMandatoSepaCreditTransfer.Columns["identificativo_flusso"], tMandatoSepaCreditTransfer.Columns["tipo_operazione"], tMandatoSepaCreditTransfer.Columns["numero_mandato"], tMandatoSepaCreditTransfer.Columns["progressivo_beneficiario"]};


	//////////////////// MANDATOSPESE /////////////////////////////////
	var tMandatoSpese= new DataTable("MandatoSpese");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoSpese.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoSpese.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoSpese.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoSpese.Columns.Add(C);
	C= new DataColumn("soggetto_destinatario_delle_spese", typeof(string));
	C.AllowDBNull=false;
	tMandatoSpese.Columns.Add(C);
	tMandatoSpese.Columns.Add( new DataColumn("natura_pagamento", typeof(string)));
	tMandatoSpese.Columns.Add( new DataColumn("causale_esenzione_spese", typeof(string)));
	Tables.Add(tMandatoSpese);
	tMandatoSpese.PrimaryKey =  new DataColumn[]{tMandatoSpese.Columns["identificativo_flusso"], tMandatoSpese.Columns["tipo_operazione"], tMandatoSpese.Columns["numero_mandato"], tMandatoSpese.Columns["progressivo_beneficiario"]};


	//////////////////// MANDATODELEGATO /////////////////////////////////
	var tMandatoDelegato= new DataTable("MandatoDelegato");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoDelegato.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoDelegato.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoDelegato.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoDelegato.Columns.Add(C);
	C= new DataColumn("anagrafica_delegato", typeof(string));
	C.AllowDBNull=false;
	tMandatoDelegato.Columns.Add(C);
	C= new DataColumn("indirizzo_delegato", typeof(string));
	C.AllowDBNull=false;
	tMandatoDelegato.Columns.Add(C);
	tMandatoDelegato.Columns.Add( new DataColumn("cap_delegato", typeof(string)));
	tMandatoDelegato.Columns.Add( new DataColumn("localita_delegato", typeof(string)));
	tMandatoDelegato.Columns.Add( new DataColumn("provincia_delegato", typeof(string)));
	tMandatoDelegato.Columns.Add( new DataColumn("stato_delegato", typeof(string)));
	tMandatoDelegato.Columns.Add( new DataColumn("codice_fiscale_delegato", typeof(string)));
	Tables.Add(tMandatoDelegato);

	//////////////////// MANDATOCOFOGSIOPE /////////////////////////////////
	var tMandatoCofogSiope= new DataTable("MandatoCofogSiope");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoCofogSiope.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoCofogSiope.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoCofogSiope.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoCofogSiope.Columns.Add(C);
	tMandatoCofogSiope.Columns.Add( new DataColumn("codice_cgu", typeof(string)));
	tMandatoCofogSiope.Columns.Add( new DataColumn("tipo_debito_siope", typeof(string)));
	tMandatoCofogSiope.Columns.Add( new DataColumn("codice_missione_siope", typeof(string)));
	tMandatoCofogSiope.Columns.Add( new DataColumn("codice_programma_siope", typeof(string)));
	tMandatoCofogSiope.Columns.Add( new DataColumn("codice_economico_siope", typeof(string)));
	tMandatoCofogSiope.Columns.Add( new DataColumn("codice_cofog_siope", typeof(string)));
	tMandatoCofogSiope.Columns.Add( new DataColumn("importo_cofog_siope", typeof(decimal)));
	Tables.Add(tMandatoCofogSiope);

	//////////////////// MANDATODATIARCONETSIOPE /////////////////////////////////
	var tMandatoDatiArconetSiope= new DataTable("MandatoDatiArconetSiope");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoDatiArconetSiope.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoDatiArconetSiope.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoDatiArconetSiope.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoDatiArconetSiope.Columns.Add(C);
	tMandatoDatiArconetSiope.Columns.Add( new DataColumn("codice_cgu", typeof(string)));
	tMandatoDatiArconetSiope.Columns.Add( new DataColumn("tipo_debito_siope", typeof(string)));
	tMandatoDatiArconetSiope.Columns.Add( new DataColumn("codice_missione_siope", typeof(string)));
	tMandatoDatiArconetSiope.Columns.Add( new DataColumn("codice_programma_siope", typeof(string)));
	tMandatoDatiArconetSiope.Columns.Add( new DataColumn("codice_economico_siope", typeof(string)));
	tMandatoDatiArconetSiope.Columns.Add( new DataColumn("importo_codice_economico_siope", typeof(decimal)));
	tMandatoDatiArconetSiope.Columns.Add( new DataColumn("codice_UE_siope", typeof(string)));
	tMandatoDatiArconetSiope.Columns.Add( new DataColumn("codice_entrata_siope", typeof(string)));
	Tables.Add(tMandatoDatiArconetSiope);

	//////////////////// NO_TABLE /////////////////////////////////
	var tno_table= new DataTable("no_table");
	C= new DataColumn("id_no_table", typeof(int));
	C.AllowDBNull=false;
	tno_table.Columns.Add(C);
	Tables.Add(tno_table);

	//////////////////// MANDATOBENEFICIARIO /////////////////////////////////
	var tMandatoBeneficiario= new DataTable("MandatoBeneficiario");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoBeneficiario.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoBeneficiario.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoBeneficiario.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoBeneficiario.Columns.Add(C);
	C= new DataColumn("anagrafica_beneficiario", typeof(string));
	C.AllowDBNull=false;
	tMandatoBeneficiario.Columns.Add(C);
	tMandatoBeneficiario.Columns.Add( new DataColumn("indirizzo_beneficiario", typeof(string)));
	tMandatoBeneficiario.Columns.Add( new DataColumn("cap_beneficiario", typeof(string)));
	tMandatoBeneficiario.Columns.Add( new DataColumn("localita_beneficiario", typeof(string)));
	tMandatoBeneficiario.Columns.Add( new DataColumn("provincia_beneficiario", typeof(string)));
	tMandatoBeneficiario.Columns.Add( new DataColumn("stato_beneficiario", typeof(string)));
	tMandatoBeneficiario.Columns.Add( new DataColumn("partita_iva_beneficiario", typeof(string)));
	tMandatoBeneficiario.Columns.Add( new DataColumn("codice_fiscale_beneficiario", typeof(string)));
	Tables.Add(tMandatoBeneficiario);
	tMandatoBeneficiario.PrimaryKey =  new DataColumn[]{tMandatoBeneficiario.Columns["identificativo_flusso"], tMandatoBeneficiario.Columns["tipo_operazione"], tMandatoBeneficiario.Columns["numero_mandato"], tMandatoBeneficiario.Columns["progressivo_beneficiario"], tMandatoBeneficiario.Columns["anagrafica_beneficiario"]};


	//////////////////// REVERSALEVERSANTE /////////////////////////////////
	var tReversaleVersante= new DataTable("ReversaleVersante");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleVersante.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleVersante.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleVersante.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleVersante.Columns.Add(C);
	C= new DataColumn("anagrafica_versante", typeof(string));
	C.AllowDBNull=false;
	tReversaleVersante.Columns.Add(C);
	tReversaleVersante.Columns.Add( new DataColumn("indirizzo_versante", typeof(string)));
	tReversaleVersante.Columns.Add( new DataColumn("cap_versante", typeof(string)));
	tReversaleVersante.Columns.Add( new DataColumn("localita_versante", typeof(string)));
	tReversaleVersante.Columns.Add( new DataColumn("provincia_versante", typeof(string)));
	tReversaleVersante.Columns.Add( new DataColumn("stato_versante", typeof(string)));
	tReversaleVersante.Columns.Add( new DataColumn("partita_iva_versante", typeof(string)));
	tReversaleVersante.Columns.Add( new DataColumn("codice_fiscale_versante", typeof(string)));
	Tables.Add(tReversaleVersante);
	tReversaleVersante.PrimaryKey =  new DataColumn[]{tReversaleVersante.Columns["identificativo_flusso"], tReversaleVersante.Columns["tipo_operazione"], tReversaleVersante.Columns["numero_reversale"], tReversaleVersante.Columns["progressivo_versante"], tReversaleVersante.Columns["anagrafica_versante"]};


	//////////////////// REVERSALE /////////////////////////////////
	var tReversale= new DataTable("Reversale");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversale.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversale.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversale.Columns.Add(C);
	C= new DataColumn("data_reversale", typeof(DateTime));
	C.AllowDBNull=false;
	tReversale.Columns.Add(C);
	C= new DataColumn("importo_reversale", typeof(decimal));
	C.AllowDBNull=false;
	tReversale.Columns.Add(C);
	tReversale.Columns.Add( new DataColumn("conto_evidenza", typeof(string)));
	C= new DataColumn("codice_struttura", typeof(string));
	C.AllowDBNull=false;
	tReversale.Columns.Add(C);
	Tables.Add(tReversale);
	tReversale.PrimaryKey =  new DataColumn[]{tReversale.Columns["identificativo_flusso"], tReversale.Columns["tipo_operazione"], tReversale.Columns["numero_reversale"]};


	//////////////////// REVERSALEBOLLO /////////////////////////////////
	var tReversaleBollo= new DataTable("ReversaleBollo");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleBollo.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleBollo.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleBollo.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleBollo.Columns.Add(C);
	C= new DataColumn("assoggettamento_bollo", typeof(string));
	C.AllowDBNull=false;
	tReversaleBollo.Columns.Add(C);
	tReversaleBollo.Columns.Add( new DataColumn("causale_esenzione_bollo", typeof(string)));
	Tables.Add(tReversaleBollo);
	tReversaleBollo.PrimaryKey =  new DataColumn[]{tReversaleBollo.Columns["identificativo_flusso"], tReversaleBollo.Columns["tipo_operazione"], tReversaleBollo.Columns["numero_reversale"], tReversaleBollo.Columns["progressivo_versante"]};


	//////////////////// REVERSALECLASSIFICAZIONE /////////////////////////////////
	var tReversaleClassificazione= new DataTable("ReversaleClassificazione");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleClassificazione.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleClassificazione.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleClassificazione.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleClassificazione.Columns.Add(C);
	C= new DataColumn("codice_cge", typeof(string));
	C.AllowDBNull=false;
	tReversaleClassificazione.Columns.Add(C);
	tReversaleClassificazione.Columns.Add( new DataColumn("importo", typeof(decimal)));
	Tables.Add(tReversaleClassificazione);
	tReversaleClassificazione.PrimaryKey =  new DataColumn[]{tReversaleClassificazione.Columns["identificativo_flusso"], tReversaleClassificazione.Columns["tipo_operazione"], tReversaleClassificazione.Columns["numero_reversale"], tReversaleClassificazione.Columns["progressivo_versante"], tReversaleClassificazione.Columns["codice_cge"]};


	//////////////////// REVERSALECLASSIFICAZIONEDATISIOPEENTRATE /////////////////////////////////
	var tReversaleClassificazioneDatiSiopeEntrate= new DataTable("ReversaleClassificazioneDatiSiopeEntrate");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleClassificazioneDatiSiopeEntrate.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleClassificazioneDatiSiopeEntrate.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleClassificazioneDatiSiopeEntrate.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleClassificazioneDatiSiopeEntrate.Columns.Add(C);
	C= new DataColumn("codice_cge", typeof(string));
	C.AllowDBNull=false;
	tReversaleClassificazioneDatiSiopeEntrate.Columns.Add(C);
	tReversaleClassificazioneDatiSiopeEntrate.Columns.Add( new DataColumn("tipo_debito_siope", typeof(string)));
	Tables.Add(tReversaleClassificazioneDatiSiopeEntrate);
	tReversaleClassificazioneDatiSiopeEntrate.PrimaryKey =  new DataColumn[]{tReversaleClassificazioneDatiSiopeEntrate.Columns["identificativo_flusso"], tReversaleClassificazioneDatiSiopeEntrate.Columns["tipo_operazione"], tReversaleClassificazioneDatiSiopeEntrate.Columns["numero_reversale"], tReversaleClassificazioneDatiSiopeEntrate.Columns["progressivo_versante"], tReversaleClassificazioneDatiSiopeEntrate.Columns["codice_cge"]};


	//////////////////// REVERSALEDATIADISPOSIZIONEENTEVERSANTE /////////////////////////////////
	var tReversaleDatiADisposizioneEnteVersante= new DataTable("ReversaleDatiADisposizioneEnteVersante");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleDatiADisposizioneEnteVersante.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleDatiADisposizioneEnteVersante.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleDatiADisposizioneEnteVersante.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleDatiADisposizioneEnteVersante.Columns.Add(C);
	tReversaleDatiADisposizioneEnteVersante.Columns.Add( new DataColumn("lingua", typeof(string)));
	tReversaleDatiADisposizioneEnteVersante.Columns.Add( new DataColumn("riferimento_documento_esterno", typeof(string)));
	Tables.Add(tReversaleDatiADisposizioneEnteVersante);
	tReversaleDatiADisposizioneEnteVersante.PrimaryKey =  new DataColumn[]{tReversaleDatiADisposizioneEnteVersante.Columns["identificativo_flusso"], tReversaleDatiADisposizioneEnteVersante.Columns["tipo_operazione"], tReversaleDatiADisposizioneEnteVersante.Columns["numero_reversale"], tReversaleDatiADisposizioneEnteVersante.Columns["progressivo_versante"]};


	//////////////////// REVERSALEDATIFATTURASIOPE /////////////////////////////////
	var tReversaleDatiFatturaSiope= new DataTable("ReversaleDatiFatturaSiope");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleDatiFatturaSiope.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleDatiFatturaSiope.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleDatiFatturaSiope.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleDatiFatturaSiope.Columns.Add(C);
	C= new DataColumn("codice_cge", typeof(string));
	C.AllowDBNull=false;
	tReversaleDatiFatturaSiope.Columns.Add(C);
	tReversaleDatiFatturaSiope.Columns.Add( new DataColumn("tipo_debito_siope", typeof(string)));
	C= new DataColumn("codice_ipa_ente_siope", typeof(string));
	C.AllowDBNull=false;
	tReversaleDatiFatturaSiope.Columns.Add(C);
	tReversaleDatiFatturaSiope.Columns.Add( new DataColumn("tipo_documento_siope_e", typeof(string)));
	tReversaleDatiFatturaSiope.Columns.Add( new DataColumn("identificativo_lotto_sdi_siope", typeof(string)));
	C= new DataColumn("numero_fattura_siope", typeof(string));
	C.AllowDBNull=false;
	tReversaleDatiFatturaSiope.Columns.Add(C);
	tReversaleDatiFatturaSiope.Columns.Add( new DataColumn("importo_siope", typeof(decimal)));
	tReversaleDatiFatturaSiope.Columns.Add( new DataColumn("data_scadenza_pagam_siope", typeof(DateTime)));
	tReversaleDatiFatturaSiope.Columns.Add( new DataColumn("motivo_scadenza_siope", typeof(string)));
	tReversaleDatiFatturaSiope.Columns.Add( new DataColumn("natura_spesa_siope", typeof(string)));
	Tables.Add(tReversaleDatiFatturaSiope);
	tReversaleDatiFatturaSiope.PrimaryKey =  new DataColumn[]{tReversaleDatiFatturaSiope.Columns["identificativo_flusso"], tReversaleDatiFatturaSiope.Columns["tipo_operazione"], tReversaleDatiFatturaSiope.Columns["numero_reversale"], tReversaleDatiFatturaSiope.Columns["progressivo_versante"], tReversaleDatiFatturaSiope.Columns["codice_cge"], tReversaleDatiFatturaSiope.Columns["codice_ipa_ente_siope"], tReversaleDatiFatturaSiope.Columns["numero_fattura_siope"]};


	//////////////////// REVERSALEFATTURASIOPE /////////////////////////////////
	var tReversaleFatturaSiope= new DataTable("ReversaleFatturaSiope");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleFatturaSiope.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleFatturaSiope.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleFatturaSiope.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleFatturaSiope.Columns.Add(C);
	C= new DataColumn("codice_cge", typeof(string));
	C.AllowDBNull=false;
	tReversaleFatturaSiope.Columns.Add(C);
	tReversaleFatturaSiope.Columns.Add( new DataColumn("tipo_debito_siope", typeof(string)));
	C= new DataColumn("codice_ipa_ente_siope", typeof(string));
	C.AllowDBNull=false;
	tReversaleFatturaSiope.Columns.Add(C);
	tReversaleFatturaSiope.Columns.Add( new DataColumn("tipo_documento_siope_e", typeof(string)));
	C= new DataColumn("identificativo_lotto_sdi_siope", typeof(string));
	C.AllowDBNull=false;
	tReversaleFatturaSiope.Columns.Add(C);
	Tables.Add(tReversaleFatturaSiope);
	tReversaleFatturaSiope.PrimaryKey =  new DataColumn[]{tReversaleFatturaSiope.Columns["identificativo_flusso"], tReversaleFatturaSiope.Columns["tipo_operazione"], tReversaleFatturaSiope.Columns["numero_reversale"], tReversaleFatturaSiope.Columns["progressivo_versante"], tReversaleFatturaSiope.Columns["codice_cge"], tReversaleFatturaSiope.Columns["codice_ipa_ente_siope"], tReversaleFatturaSiope.Columns["identificativo_lotto_sdi_siope"]};


	//////////////////// REVERSALEINFORMAZIONIVERSANTE /////////////////////////////////
	var tReversaleInformazioniVersante= new DataTable("ReversaleInformazioniVersante");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleInformazioniVersante.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleInformazioniVersante.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleInformazioniVersante.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleInformazioniVersante.Columns.Add(C);
	C= new DataColumn("importo_versante", typeof(decimal));
	C.AllowDBNull=false;
	tReversaleInformazioniVersante.Columns.Add(C);
	C= new DataColumn("tipo_riscossione", typeof(string));
	C.AllowDBNull=false;
	tReversaleInformazioniVersante.Columns.Add(C);
	tReversaleInformazioniVersante.Columns.Add( new DataColumn("tipo_entrata", typeof(string)));
	tReversaleInformazioniVersante.Columns.Add( new DataColumn("destinazione", typeof(string)));
	C= new DataColumn("causale", typeof(string));
	C.AllowDBNull=false;
	tReversaleInformazioniVersante.Columns.Add(C);
	Tables.Add(tReversaleInformazioniVersante);
	tReversaleInformazioniVersante.PrimaryKey =  new DataColumn[]{tReversaleInformazioniVersante.Columns["identificativo_flusso"], tReversaleInformazioniVersante.Columns["tipo_operazione"], tReversaleInformazioniVersante.Columns["numero_reversale"], tReversaleInformazioniVersante.Columns["progressivo_versante"]};


	//////////////////// REVERSALEMANDATOASSOCIATO /////////////////////////////////
	var tReversaleMandatoAssociato= new DataTable("ReversaleMandatoAssociato");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleMandatoAssociato.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleMandatoAssociato.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleMandatoAssociato.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleMandatoAssociato.Columns.Add(C);
	tReversaleMandatoAssociato.Columns.Add( new DataColumn("numero_mandato", typeof(int)));
	tReversaleMandatoAssociato.Columns.Add( new DataColumn("progressivo_beneficiario", typeof(int)));
	Tables.Add(tReversaleMandatoAssociato);
	tReversaleMandatoAssociato.PrimaryKey =  new DataColumn[]{tReversaleMandatoAssociato.Columns["identificativo_flusso"], tReversaleMandatoAssociato.Columns["tipo_operazione"], tReversaleMandatoAssociato.Columns["numero_reversale"], tReversaleMandatoAssociato.Columns["progressivo_versante"]};


	//////////////////// REVERSALESOSPESO /////////////////////////////////
	var tReversaleSospeso= new DataTable("ReversaleSospeso");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleSospeso.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleSospeso.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleSospeso.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleSospeso.Columns.Add(C);
	tReversaleSospeso.Columns.Add( new DataColumn("numero_provvisorio", typeof(int)));
	tReversaleSospeso.Columns.Add( new DataColumn("importo_provvisorio", typeof(decimal)));
	Tables.Add(tReversaleSospeso);
	tReversaleSospeso.PrimaryKey =  new DataColumn[]{tReversaleSospeso.Columns["identificativo_flusso"], tReversaleSospeso.Columns["tipo_operazione"], tReversaleSospeso.Columns["numero_reversale"], tReversaleSospeso.Columns["progressivo_versante"]};


	//////////////////// REVERSALETESTATAFLUSSO /////////////////////////////////
	var tReversaleTestataFlusso= new DataTable("ReversaleTestataFlusso");
	C= new DataColumn("codice_ABI_BT", typeof(string));
	C.AllowDBNull=false;
	tReversaleTestataFlusso.Columns.Add(C);
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleTestataFlusso.Columns.Add(C);
	C= new DataColumn("data_ora_creazione_flusso", typeof(DateTime));
	C.AllowDBNull=false;
	tReversaleTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_ente", typeof(string));
	C.AllowDBNull=false;
	tReversaleTestataFlusso.Columns.Add(C);
	C= new DataColumn("descrizione_ente", typeof(string));
	C.AllowDBNull=false;
	tReversaleTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_istat_ente", typeof(string));
	C.AllowDBNull=false;
	tReversaleTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_fiscale_ente", typeof(string));
	C.AllowDBNull=false;
	tReversaleTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_tramite_ente", typeof(string));
	C.AllowDBNull=false;
	tReversaleTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_tramite_BT", typeof(string));
	C.AllowDBNull=false;
	tReversaleTestataFlusso.Columns.Add(C);
	C= new DataColumn("codice_ente_BT", typeof(string));
	C.AllowDBNull=false;
	tReversaleTestataFlusso.Columns.Add(C);
	tReversaleTestataFlusso.Columns.Add( new DataColumn("riferimento_ente", typeof(string)));
	Tables.Add(tReversaleTestataFlusso);
	tReversaleTestataFlusso.PrimaryKey =  new DataColumn[]{tReversaleTestataFlusso.Columns["codice_ABI_BT"], tReversaleTestataFlusso.Columns["identificativo_flusso"], tReversaleTestataFlusso.Columns["data_ora_creazione_flusso"]};


	//////////////////// REVERSALEINFORMAZIONIAGGIUNTIVE /////////////////////////////////
	var tReversaleInformazioniAggiuntive= new DataTable("ReversaleInformazioniAggiuntive");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tReversaleInformazioniAggiuntive.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tReversaleInformazioniAggiuntive.Columns.Add(C);
	C= new DataColumn("numero_reversale", typeof(int));
	C.AllowDBNull=false;
	tReversaleInformazioniAggiuntive.Columns.Add(C);
	C= new DataColumn("progressivo_versante", typeof(int));
	C.AllowDBNull=false;
	tReversaleInformazioniAggiuntive.Columns.Add(C);
	tReversaleInformazioniAggiuntive.Columns.Add( new DataColumn("lingua", typeof(string)));
	tReversaleInformazioniAggiuntive.Columns.Add( new DataColumn("riferimento_documento_esterno", typeof(string)));
	Tables.Add(tReversaleInformazioniAggiuntive);
	tReversaleInformazioniAggiuntive.PrimaryKey =  new DataColumn[]{tReversaleInformazioniAggiuntive.Columns["identificativo_flusso"], tReversaleInformazioniAggiuntive.Columns["tipo_operazione"], tReversaleInformazioniAggiuntive.Columns["numero_reversale"], tReversaleInformazioniAggiuntive.Columns["progressivo_versante"]};


	//////////////////// MANDATOSOSPESO /////////////////////////////////
	var tMandatoSospeso= new DataTable("MandatoSospeso");
	C= new DataColumn("identificativo_flusso", typeof(string));
	C.AllowDBNull=false;
	tMandatoSospeso.Columns.Add(C);
	C= new DataColumn("tipo_operazione", typeof(string));
	C.AllowDBNull=false;
	tMandatoSospeso.Columns.Add(C);
	C= new DataColumn("numero_mandato", typeof(int));
	C.AllowDBNull=false;
	tMandatoSospeso.Columns.Add(C);
	C= new DataColumn("progressivo_beneficiario", typeof(int));
	C.AllowDBNull=false;
	tMandatoSospeso.Columns.Add(C);
	C= new DataColumn("numero_provvisorio", typeof(int));
	C.AllowDBNull=false;
	tMandatoSospeso.Columns.Add(C);
	tMandatoSospeso.Columns.Add( new DataColumn("importo_provvisorio", typeof(decimal)));
	Tables.Add(tMandatoSospeso);
	tMandatoSospeso.PrimaryKey =  new DataColumn[]{tMandatoSospeso.Columns["identificativo_flusso"], tMandatoSospeso.Columns["tipo_operazione"], tMandatoSospeso.Columns["numero_mandato"], tMandatoSospeso.Columns["progressivo_beneficiario"], tMandatoSospeso.Columns["numero_provvisorio"]};


	#endregion

}
}
}
