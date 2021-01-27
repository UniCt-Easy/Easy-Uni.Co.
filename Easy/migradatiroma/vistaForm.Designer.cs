
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
	C= new DataColumn("codice_ABI_BT", typeof(int));
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
	C= new DataColumn("codice_struttura", typeof(int));
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
	tMandatoClassificazioneDatiSiopeUscite.Columns.Add( new DataColumn("tipo_debito_siope_c", typeof(string)));
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
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("codice_cgu", typeof(string)));
	tMandatoDatiFatturaSiope.Columns.Add( new DataColumn("tipo_debito_siope_c", typeof(string)));
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
	tMandatoDatiFatturaSiope.PrimaryKey =  new DataColumn[]{tMandatoDatiFatturaSiope.Columns["identificativo_flusso"], tMandatoDatiFatturaSiope.Columns["tipo_operazione"], tMandatoDatiFatturaSiope.Columns["numero_mandato"], tMandatoDatiFatturaSiope.Columns["progressivo_beneficiario"]};


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
	tMandatoFatturaSiope.Columns.Add( new DataColumn("tipo_debito_siope_c", typeof(string)));
	tMandatoFatturaSiope.Columns.Add( new DataColumn("codice_cig_siope", typeof(string)));
	tMandatoFatturaSiope.Columns.Add( new DataColumn("codice_ipa_ente_siope", typeof(string)));
	tMandatoFatturaSiope.Columns.Add( new DataColumn("tipo_documento_siope_e", typeof(string)));
	tMandatoFatturaSiope.Columns.Add( new DataColumn("identificativo_lotto_sdi_siope", typeof(string)));
	Tables.Add(tMandatoFatturaSiope);
	tMandatoFatturaSiope.PrimaryKey =  new DataColumn[]{tMandatoFatturaSiope.Columns["identificativo_flusso"], tMandatoFatturaSiope.Columns["tipo_operazione"], tMandatoFatturaSiope.Columns["numero_mandato"], tMandatoFatturaSiope.Columns["progressivo_beneficiario"]};


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
	tMandatoRitenute.PrimaryKey =  new DataColumn[]{tMandatoRitenute.Columns["identificativo_flusso"], tMandatoRitenute.Columns["tipo_operazione"], tMandatoRitenute.Columns["numero_mandato"], tMandatoRitenute.Columns["progressivo_beneficiario"]};


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


	#endregion

}
}
}
