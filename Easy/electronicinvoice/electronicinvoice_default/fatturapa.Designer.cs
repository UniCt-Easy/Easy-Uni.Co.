
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


namespace electronicinvoice_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class NewDataSet: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable FatturaElettronica{get { return Tables["FatturaElettronica"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable FatturaElettronicaHeader{get { return Tables["FatturaElettronicaHeader"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiTrasmissione{get { return Tables["DatiTrasmissione"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable IdTrasmittente{get { return Tables["IdTrasmittente"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable ContattiTrasmittente{get { return Tables["ContattiTrasmittente"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable CedentePrestatore{get { return Tables["CedentePrestatore"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiAnagrafici{get { return Tables["DatiAnagrafici"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable IdFiscaleIVA{get { return Tables["IdFiscaleIVA"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable Anagrafica{get { return Tables["Anagrafica"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable Sede{get { return Tables["Sede"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable StabileOrganizzazione{get { return Tables["StabileOrganizzazione"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable IscrizioneREA{get { return Tables["IscrizioneREA"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable Contatti{get { return Tables["Contatti"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable RappresentanteFiscale{get { return Tables["RappresentanteFiscale"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable CessionarioCommittente{get { return Tables["CessionarioCommittente"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable TerzoIntermediarioOSoggettoEmittente{get { return Tables["TerzoIntermediarioOSoggettoEmittente"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable FatturaElettronicaBody{get { return Tables["FatturaElettronicaBody"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiGenerali{get { return Tables["DatiGenerali"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiGeneraliDocumento{get { return Tables["DatiGeneraliDocumento"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiRitenuta{get { return Tables["DatiRitenuta"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiBollo{get { return Tables["DatiBollo"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiCassaPrevidenziale{get { return Tables["DatiCassaPrevidenziale"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable ScontoMaggiorazione{get { return Tables["ScontoMaggiorazione"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiOrdineAcquisto{get { return Tables["DatiOrdineAcquisto"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiContratto{get { return Tables["DatiContratto"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiConvenzione{get { return Tables["DatiConvenzione"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiRicezione{get { return Tables["DatiRicezione"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiFattureCollegate{get { return Tables["DatiFattureCollegate"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiSAL{get { return Tables["DatiSAL"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiDDT{get { return Tables["DatiDDT"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiTrasporto{get { return Tables["DatiTrasporto"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiAnagraficiVettore{get { return Tables["DatiAnagraficiVettore"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable IndirizzoResa{get { return Tables["IndirizzoResa"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable FatturaPrincipale{get { return Tables["FatturaPrincipale"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiBeniServizi{get { return Tables["DatiBeniServizi"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DettaglioLinee{get { return Tables["DettaglioLinee"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable CodiceArticolo{get { return Tables["CodiceArticolo"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable AltriDatiGestionali{get { return Tables["AltriDatiGestionali"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiRiepilogo{get { return Tables["DatiRiepilogo"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiVeicoli{get { return Tables["DatiVeicoli"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DatiPagamento{get { return Tables["DatiPagamento"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable DettaglioPagamento{get { return Tables["DettaglioPagamento"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable Allegati{get { return Tables["Allegati"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public NewDataSet(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "NewDataSet";
Prefix = "";
Namespace = "http://tempuri.org/NewDataSet.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("FatturaElettronica");
	C= new DataColumn("versione", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("FatturaElettronica_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["FatturaElettronica_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("FatturaElettronicaHeader");
	T.Columns.Add(new DataColumn("SoggettoEmittente", typeof(System.String), ""));
	C= new DataColumn("FatturaElettronicaHeader_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronica_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["FatturaElettronicaHeader_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("DatiTrasmissione");
	C= new DataColumn("ProgressivoInvio", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("FormatoTrasmissione", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("CodiceDestinatario", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("DatiTrasmissione_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronicaHeader_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["DatiTrasmissione_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("IdTrasmittente");
	C= new DataColumn("IdPaese", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("IdCodice", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiTrasmissione_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("ContattiTrasmittente");
	T.Columns.Add(new DataColumn("Telefono", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DatiTrasmissione_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("CedentePrestatore");
	T.Columns.Add(new DataColumn("RiferimentoAmministrazione", typeof(System.String), ""));
	C= new DataColumn("CedentePrestatore_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronicaHeader_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["CedentePrestatore_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("DatiAnagrafici");
	T.Columns.Add(new DataColumn("CodiceFiscale", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("AlboProfessionale", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ProvinciaAlbo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NumeroIscrizioneAlbo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DataIscrizioneAlbo", typeof(System.DateTime), ""));
	C= new DataColumn("RegimeFiscale", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("DatiAnagrafici_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CedentePrestatore_Id", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("RappresentanteFiscale_Id", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CessionarioCommittente_Id", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("TerzoIntermediarioOSoggettoEmittente_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["DatiAnagrafici_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("IdFiscaleIVA");
	C= new DataColumn("IdPaese", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("IdCodice", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiAnagrafici_Id", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DatiAnagraficiVettore_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("Anagrafica");
	C= new DataColumn("Denominazione", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Nome", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Cognome", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Titolo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodEORI", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DatiAnagrafici_Id", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DatiAnagraficiVettore_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("Sede");
	C= new DataColumn("Indirizzo", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("NumeroCivico", typeof(System.String), ""));
	C= new DataColumn("CAP", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Comune", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Provincia", typeof(System.String), ""));
	C= new DataColumn("Nazione", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CedentePrestatore_Id", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CessionarioCommittente_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("StabileOrganizzazione");
	C= new DataColumn("Indirizzo", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("NumeroCivico", typeof(System.String), ""));
	C= new DataColumn("CAP", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Comune", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Provincia", typeof(System.String), ""));
	C= new DataColumn("Nazione", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CedentePrestatore_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("IscrizioneREA");
	C= new DataColumn("Ufficio", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("NumeroREA", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CapitaleSociale", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("SocioUnico", typeof(System.String), ""));
	C= new DataColumn("StatoLiquidazione", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CedentePrestatore_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("Contatti");
	T.Columns.Add(new DataColumn("Telefono", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Fax", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CedentePrestatore_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("RappresentanteFiscale");
	C= new DataColumn("RappresentanteFiscale_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronicaHeader_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["RappresentanteFiscale_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("CessionarioCommittente");
	C= new DataColumn("CessionarioCommittente_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronicaHeader_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["CessionarioCommittente_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("TerzoIntermediarioOSoggettoEmittente");
	C= new DataColumn("TerzoIntermediarioOSoggettoEmittente_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronicaHeader_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["TerzoIntermediarioOSoggettoEmittente_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("FatturaElettronicaBody");
	C= new DataColumn("FatturaElettronicaBody_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronica_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["FatturaElettronicaBody_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("DatiGenerali");
	T.Columns.Add(new DataColumn("NormaDiRiferimento", typeof(System.String), ""));
	C= new DataColumn("DatiGenerali_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronicaBody_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["DatiGenerali_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("DatiGeneraliDocumento");
	C= new DataColumn("TipoDocumento", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Divisa", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Data", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Numero", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ImportoTotaleDocumento", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("Arrotondamento", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("Causale", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Art73", typeof(System.String), ""));
	C= new DataColumn("DatiGeneraliDocumento_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiGenerali_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["DatiGeneraliDocumento_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("DatiRitenuta");
	C= new DataColumn("TipoRitenuta", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ImportoRitenuta", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("AliquotaRitenuta", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("CausalePagamento", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiGeneraliDocumento_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiBollo");
	C= new DataColumn("NumeroBollo", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ImportoBollo", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiGeneraliDocumento_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiCassaPrevidenziale");
	C= new DataColumn("TipoCassa", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("AlCassa", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ImportoContributoCassa", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ImponibileCassa", typeof(System.Decimal), ""));
	C= new DataColumn("AliquotaIVA", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Ritenuta", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Natura", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("RiferimentoAmministrazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DatiGeneraliDocumento_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("ScontoMaggiorazione");
	C= new DataColumn("Tipo", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Percentuale", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("Importo", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("DatiGeneraliDocumento_Id", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DettaglioLinee_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiOrdineAcquisto");
	T.Columns.Add(new DataColumn("RiferimentoNumeroLinea", typeof(System.Int64), ""));
	C= new DataColumn("IdDocumento", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Data", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("NumItem", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCommessaConvenzione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCUP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCIG", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DatiGenerali_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiContratto");
	T.Columns.Add(new DataColumn("RiferimentoNumeroLinea", typeof(System.Int64), ""));
	C= new DataColumn("IdDocumento", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Data", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("NumItem", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCommessaConvenzione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCUP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCIG", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DatiGenerali_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiConvenzione");
	T.Columns.Add(new DataColumn("RiferimentoNumeroLinea", typeof(System.Int64), ""));
	C= new DataColumn("IdDocumento", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Data", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("NumItem", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCommessaConvenzione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCUP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCIG", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DatiGenerali_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiRicezione");
	T.Columns.Add(new DataColumn("RiferimentoNumeroLinea", typeof(System.Int64), ""));
	C= new DataColumn("IdDocumento", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Data", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("NumItem", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCommessaConvenzione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCUP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCIG", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DatiGenerali_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiFattureCollegate");
	T.Columns.Add(new DataColumn("RiferimentoNumeroLinea", typeof(System.Int64), ""));
	C= new DataColumn("IdDocumento", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Data", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("NumItem", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCommessaConvenzione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCUP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceCIG", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DatiGenerali_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiSAL");
	C= new DataColumn("RiferimentoFase", typeof(System.Int64), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiGenerali_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiDDT");
	C= new DataColumn("NumeroDDT", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("DataDDT", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("RiferimentoNumeroLinea", typeof(System.Int64), ""));
	T.Columns.Add(new DataColumn("DatiGenerali_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiTrasporto");
	T.Columns.Add(new DataColumn("MezzoTrasporto", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CausaleTrasporto", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NumeroColli", typeof(System.Int64), ""));
	T.Columns.Add(new DataColumn("Descrizione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("UnitaMisuraPeso", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PesoLordo", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("PesoNetto", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("DataOraRitiro", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("DataInizioTrasporto", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("TipoResa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DataOraConsegna", typeof(System.DateTime), ""));
	C= new DataColumn("DatiTrasporto_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiGenerali_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["DatiTrasporto_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("DatiAnagraficiVettore");
	T.Columns.Add(new DataColumn("CodiceFiscale", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NumeroLicenzaGuida", typeof(System.String), ""));
	C= new DataColumn("DatiAnagraficiVettore_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiTrasporto_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["DatiAnagraficiVettore_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("IndirizzoResa");
	C= new DataColumn("Indirizzo", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("NumeroCivico", typeof(System.String), ""));
	C= new DataColumn("CAP", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Comune", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Provincia", typeof(System.String), ""));
	C= new DataColumn("Nazione", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiTrasporto_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("FatturaPrincipale");
	C= new DataColumn("NumeroFatturaPrincipale", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("DataFatturaPrincipale", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiGenerali_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiBeniServizi");
	C= new DataColumn("DatiBeniServizi_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronicaBody_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["DatiBeniServizi_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("DettaglioLinee");
	C= new DataColumn("NumeroLinea", typeof(System.Int64), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("TipoCessionePrestazione", typeof(System.String), ""));
	C= new DataColumn("Descrizione", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Quantita", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("UnitaMisura", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DataInizioPeriodo", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("DataFinePeriodo", typeof(System.DateTime), ""));
	C= new DataColumn("PrezzoUnitario", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("PrezzoTotale", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("AliquotaIVA", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Ritenuta", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Natura", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("RiferimentoAmministrazione", typeof(System.String), ""));
	C= new DataColumn("DettaglioLinee_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DatiBeniServizi_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["DettaglioLinee_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("CodiceArticolo");
	C= new DataColumn("CodiceTipo", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("CodiceValore", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DettaglioLinee_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("AltriDatiGestionali");
	C= new DataColumn("TipoDato", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("RiferimentoTesto", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("RiferimentoNumero", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("RiferimentoData", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("DettaglioLinee_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiRiepilogo");
	C= new DataColumn("AliquotaIVA", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("Natura", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("SpeseAccessorie", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("Arrotondamento", typeof(System.Decimal), ""));
	C= new DataColumn("ImponibileImporto", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("Imposta", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("EsigibilitaIVA", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("RiferimentoNormativo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DatiBeniServizi_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiVeicoli");
	C= new DataColumn("Data", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("TotalePercorso", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronicaBody_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("DatiPagamento");
	C= new DataColumn("CondizioniPagamento", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("DatiPagamento_Id", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronicaBody_Id", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["DatiPagamento_Id"]};
	T.PrimaryKey = key;

	T= new DataTable("DettaglioPagamento");
	T.Columns.Add(new DataColumn("Beneficiario", typeof(System.String), ""));
	C= new DataColumn("ModalitaPagamento", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DataRiferimentoTerminiPagamento", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("GiorniTerminiPagamento", typeof(System.Int64), ""));
	T.Columns.Add(new DataColumn("DataScadenzaPagamento", typeof(System.DateTime), ""));
	C= new DataColumn("ImportoPagamento", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CodUfficioPostale", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CognomeQuietanzante", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NomeQuietanzante", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CFQuietanzante", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("TitoloQuietanzante", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IstitutoFinanziario", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IBAN", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ABI", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CAB", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("BIC", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ScontoPagamentoAnticipato", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("DataLimitePagamentoAnticipato", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("PenalitaPagamentiRitardati", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("DataDecorrenzaPenale", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("CodicePagamento", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DatiPagamento_Id", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("Allegati");
	C= new DataColumn("NomeAttachment", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("AlgoritmoCompressione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("FormatoAttachment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DescrizioneAttachment", typeof(System.String), ""));
	C= new DataColumn("Attachment", typeof(System.Byte[]), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("FatturaElettronicaBody_Id", typeof(System.Int32), ""));
	Tables.Add(T);

//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["FatturaElettronicaBody"];
TChild= Tables["Allegati"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronicaBody_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronicaBody_Id"]};
Relations.Add(new DataRelation("FatturaElettronicaBody_Allegati",CPar,CChild));

TPar= Tables["DatiPagamento"];
TChild= Tables["DettaglioPagamento"];
CPar = new DataColumn[1]{TPar.Columns["DatiPagamento_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiPagamento_Id"]};
Relations.Add(new DataRelation("DatiPagamento_DettaglioPagamento",CPar,CChild));

TPar= Tables["FatturaElettronicaBody"];
TChild= Tables["DatiPagamento"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronicaBody_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronicaBody_Id"]};
Relations.Add(new DataRelation("FatturaElettronicaBody_DatiPagamento",CPar,CChild));

TPar= Tables["FatturaElettronicaBody"];
TChild= Tables["DatiVeicoli"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronicaBody_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronicaBody_Id"]};
Relations.Add(new DataRelation("FatturaElettronicaBody_DatiVeicoli",CPar,CChild));

TPar= Tables["DatiBeniServizi"];
TChild= Tables["DatiRiepilogo"];
CPar = new DataColumn[1]{TPar.Columns["DatiBeniServizi_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiBeniServizi_Id"]};
Relations.Add(new DataRelation("DatiBeniServizi_DatiRiepilogo",CPar,CChild));

TPar= Tables["DettaglioLinee"];
TChild= Tables["AltriDatiGestionali"];
CPar = new DataColumn[1]{TPar.Columns["DettaglioLinee_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DettaglioLinee_Id"]};
Relations.Add(new DataRelation("DettaglioLinee_AltriDatiGestionali",CPar,CChild));

TPar= Tables["DettaglioLinee"];
TChild= Tables["CodiceArticolo"];
CPar = new DataColumn[1]{TPar.Columns["DettaglioLinee_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DettaglioLinee_Id"]};
Relations.Add(new DataRelation("DettaglioLinee_CodiceArticolo",CPar,CChild));

TPar= Tables["DatiBeniServizi"];
TChild= Tables["DettaglioLinee"];
CPar = new DataColumn[1]{TPar.Columns["DatiBeniServizi_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiBeniServizi_Id"]};
Relations.Add(new DataRelation("DatiBeniServizi_DettaglioLinee",CPar,CChild));

TPar= Tables["FatturaElettronicaBody"];
TChild= Tables["DatiBeniServizi"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronicaBody_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronicaBody_Id"]};
Relations.Add(new DataRelation("FatturaElettronicaBody_DatiBeniServizi",CPar,CChild));

TPar= Tables["DatiGenerali"];
TChild= Tables["FatturaPrincipale"];
CPar = new DataColumn[1]{TPar.Columns["DatiGenerali_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGenerali_Id"]};
Relations.Add(new DataRelation("DatiGenerali_FatturaPrincipale",CPar,CChild));

TPar= Tables["DatiTrasporto"];
TChild= Tables["IndirizzoResa"];
CPar = new DataColumn[1]{TPar.Columns["DatiTrasporto_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiTrasporto_Id"]};
Relations.Add(new DataRelation("DatiTrasporto_IndirizzoResa",CPar,CChild));

TPar= Tables["DatiTrasporto"];
TChild= Tables["DatiAnagraficiVettore"];
CPar = new DataColumn[1]{TPar.Columns["DatiTrasporto_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiTrasporto_Id"]};
Relations.Add(new DataRelation("DatiTrasporto_DatiAnagraficiVettore",CPar,CChild));

TPar= Tables["DatiGenerali"];
TChild= Tables["DatiTrasporto"];
CPar = new DataColumn[1]{TPar.Columns["DatiGenerali_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGenerali_Id"]};
Relations.Add(new DataRelation("DatiGenerali_DatiTrasporto",CPar,CChild));

TPar= Tables["DatiGenerali"];
TChild= Tables["DatiDDT"];
CPar = new DataColumn[1]{TPar.Columns["DatiGenerali_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGenerali_Id"]};
Relations.Add(new DataRelation("DatiGenerali_DatiDDT",CPar,CChild));

TPar= Tables["DatiGenerali"];
TChild= Tables["DatiSAL"];
CPar = new DataColumn[1]{TPar.Columns["DatiGenerali_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGenerali_Id"]};
Relations.Add(new DataRelation("DatiGenerali_DatiSAL",CPar,CChild));

TPar= Tables["DatiGenerali"];
TChild= Tables["DatiFattureCollegate"];
CPar = new DataColumn[1]{TPar.Columns["DatiGenerali_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGenerali_Id"]};
Relations.Add(new DataRelation("DatiGenerali_DatiFattureCollegate",CPar,CChild));

TPar= Tables["DatiGenerali"];
TChild= Tables["DatiRicezione"];
CPar = new DataColumn[1]{TPar.Columns["DatiGenerali_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGenerali_Id"]};
Relations.Add(new DataRelation("DatiGenerali_DatiRicezione",CPar,CChild));

TPar= Tables["DatiGenerali"];
TChild= Tables["DatiConvenzione"];
CPar = new DataColumn[1]{TPar.Columns["DatiGenerali_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGenerali_Id"]};
Relations.Add(new DataRelation("DatiGenerali_DatiConvenzione",CPar,CChild));

TPar= Tables["DatiGenerali"];
TChild= Tables["DatiContratto"];
CPar = new DataColumn[1]{TPar.Columns["DatiGenerali_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGenerali_Id"]};
Relations.Add(new DataRelation("DatiGenerali_DatiContratto",CPar,CChild));

TPar= Tables["DatiGenerali"];
TChild= Tables["DatiOrdineAcquisto"];
CPar = new DataColumn[1]{TPar.Columns["DatiGenerali_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGenerali_Id"]};
Relations.Add(new DataRelation("DatiGenerali_DatiOrdineAcquisto",CPar,CChild));

TPar= Tables["DettaglioLinee"];
TChild= Tables["ScontoMaggiorazione"];
CPar = new DataColumn[1]{TPar.Columns["DettaglioLinee_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DettaglioLinee_Id"]};
Relations.Add(new DataRelation("DettaglioLinee_ScontoMaggiorazione",CPar,CChild));

TPar= Tables["DatiGeneraliDocumento"];
TChild= Tables["ScontoMaggiorazione"];
CPar = new DataColumn[1]{TPar.Columns["DatiGeneraliDocumento_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGeneraliDocumento_Id"]};
Relations.Add(new DataRelation("DatiGeneraliDocumento_ScontoMaggiorazione",CPar,CChild));

TPar= Tables["DatiGeneraliDocumento"];
TChild= Tables["DatiCassaPrevidenziale"];
CPar = new DataColumn[1]{TPar.Columns["DatiGeneraliDocumento_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGeneraliDocumento_Id"]};
Relations.Add(new DataRelation("DatiGeneraliDocumento_DatiCassaPrevidenziale",CPar,CChild));

TPar= Tables["DatiGeneraliDocumento"];
TChild= Tables["DatiBollo"];
CPar = new DataColumn[1]{TPar.Columns["DatiGeneraliDocumento_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGeneraliDocumento_Id"]};
Relations.Add(new DataRelation("DatiGeneraliDocumento_DatiBollo",CPar,CChild));

TPar= Tables["DatiGeneraliDocumento"];
TChild= Tables["DatiRitenuta"];
CPar = new DataColumn[1]{TPar.Columns["DatiGeneraliDocumento_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGeneraliDocumento_Id"]};
Relations.Add(new DataRelation("DatiGeneraliDocumento_DatiRitenuta",CPar,CChild));

TPar= Tables["DatiGenerali"];
TChild= Tables["DatiGeneraliDocumento"];
CPar = new DataColumn[1]{TPar.Columns["DatiGenerali_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiGenerali_Id"]};
Relations.Add(new DataRelation("DatiGenerali_DatiGeneraliDocumento",CPar,CChild));

TPar= Tables["FatturaElettronicaBody"];
TChild= Tables["DatiGenerali"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronicaBody_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronicaBody_Id"]};
Relations.Add(new DataRelation("FatturaElettronicaBody_DatiGenerali",CPar,CChild));

TPar= Tables["FatturaElettronica"];
TChild= Tables["FatturaElettronicaBody"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronica_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronica_Id"]};
Relations.Add(new DataRelation("FatturaElettronica_FatturaElettronicaBody",CPar,CChild));

TPar= Tables["FatturaElettronicaHeader"];
TChild= Tables["TerzoIntermediarioOSoggettoEmittente"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronicaHeader_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronicaHeader_Id"]};
Relations.Add(new DataRelation("FatturaElettronicaHeader_TerzoIntermediarioOSoggettoEmittente",CPar,CChild));

TPar= Tables["FatturaElettronicaHeader"];
TChild= Tables["CessionarioCommittente"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronicaHeader_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronicaHeader_Id"]};
Relations.Add(new DataRelation("FatturaElettronicaHeader_CessionarioCommittente",CPar,CChild));

TPar= Tables["FatturaElettronicaHeader"];
TChild= Tables["RappresentanteFiscale"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronicaHeader_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronicaHeader_Id"]};
Relations.Add(new DataRelation("FatturaElettronicaHeader_RappresentanteFiscale",CPar,CChild));

TPar= Tables["CedentePrestatore"];
TChild= Tables["Contatti"];
CPar = new DataColumn[1]{TPar.Columns["CedentePrestatore_Id"]};
CChild = new DataColumn[1]{TChild.Columns["CedentePrestatore_Id"]};
Relations.Add(new DataRelation("CedentePrestatore_Contatti",CPar,CChild));

TPar= Tables["CedentePrestatore"];
TChild= Tables["IscrizioneREA"];
CPar = new DataColumn[1]{TPar.Columns["CedentePrestatore_Id"]};
CChild = new DataColumn[1]{TChild.Columns["CedentePrestatore_Id"]};
Relations.Add(new DataRelation("CedentePrestatore_IscrizioneREA",CPar,CChild));

TPar= Tables["CedentePrestatore"];
TChild= Tables["StabileOrganizzazione"];
CPar = new DataColumn[1]{TPar.Columns["CedentePrestatore_Id"]};
CChild = new DataColumn[1]{TChild.Columns["CedentePrestatore_Id"]};
Relations.Add(new DataRelation("CedentePrestatore_StabileOrganizzazione",CPar,CChild));

TPar= Tables["CessionarioCommittente"];
TChild= Tables["Sede"];
CPar = new DataColumn[1]{TPar.Columns["CessionarioCommittente_Id"]};
CChild = new DataColumn[1]{TChild.Columns["CessionarioCommittente_Id"]};
Relations.Add(new DataRelation("CessionarioCommittente_Sede",CPar,CChild));

TPar= Tables["CedentePrestatore"];
TChild= Tables["Sede"];
CPar = new DataColumn[1]{TPar.Columns["CedentePrestatore_Id"]};
CChild = new DataColumn[1]{TChild.Columns["CedentePrestatore_Id"]};
Relations.Add(new DataRelation("CedentePrestatore_Sede",CPar,CChild));

TPar= Tables["DatiAnagraficiVettore"];
TChild= Tables["Anagrafica"];
CPar = new DataColumn[1]{TPar.Columns["DatiAnagraficiVettore_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiAnagraficiVettore_Id"]};
Relations.Add(new DataRelation("DatiAnagraficiVettore_Anagrafica",CPar,CChild));

TPar= Tables["DatiAnagrafici"];
TChild= Tables["Anagrafica"];
CPar = new DataColumn[1]{TPar.Columns["DatiAnagrafici_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiAnagrafici_Id"]};
Relations.Add(new DataRelation("DatiAnagrafici_Anagrafica",CPar,CChild));

TPar= Tables["DatiAnagraficiVettore"];
TChild= Tables["IdFiscaleIVA"];
CPar = new DataColumn[1]{TPar.Columns["DatiAnagraficiVettore_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiAnagraficiVettore_Id"]};
Relations.Add(new DataRelation("DatiAnagraficiVettore_IdFiscaleIVA",CPar,CChild));

TPar= Tables["DatiAnagrafici"];
TChild= Tables["IdFiscaleIVA"];
CPar = new DataColumn[1]{TPar.Columns["DatiAnagrafici_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiAnagrafici_Id"]};
Relations.Add(new DataRelation("DatiAnagrafici_IdFiscaleIVA",CPar,CChild));

TPar= Tables["TerzoIntermediarioOSoggettoEmittente"];
TChild= Tables["DatiAnagrafici"];
CPar = new DataColumn[1]{TPar.Columns["TerzoIntermediarioOSoggettoEmittente_Id"]};
CChild = new DataColumn[1]{TChild.Columns["TerzoIntermediarioOSoggettoEmittente_Id"]};
Relations.Add(new DataRelation("TerzoIntermediarioOSoggettoEmittente_DatiAnagrafici",CPar,CChild));

TPar= Tables["CessionarioCommittente"];
TChild= Tables["DatiAnagrafici"];
CPar = new DataColumn[1]{TPar.Columns["CessionarioCommittente_Id"]};
CChild = new DataColumn[1]{TChild.Columns["CessionarioCommittente_Id"]};
Relations.Add(new DataRelation("CessionarioCommittente_DatiAnagrafici",CPar,CChild));

TPar= Tables["RappresentanteFiscale"];
TChild= Tables["DatiAnagrafici"];
CPar = new DataColumn[1]{TPar.Columns["RappresentanteFiscale_Id"]};
CChild = new DataColumn[1]{TChild.Columns["RappresentanteFiscale_Id"]};
Relations.Add(new DataRelation("RappresentanteFiscale_DatiAnagrafici",CPar,CChild));

TPar= Tables["CedentePrestatore"];
TChild= Tables["DatiAnagrafici"];
CPar = new DataColumn[1]{TPar.Columns["CedentePrestatore_Id"]};
CChild = new DataColumn[1]{TChild.Columns["CedentePrestatore_Id"]};
Relations.Add(new DataRelation("CedentePrestatore_DatiAnagrafici",CPar,CChild));

TPar= Tables["FatturaElettronicaHeader"];
TChild= Tables["CedentePrestatore"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronicaHeader_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronicaHeader_Id"]};
Relations.Add(new DataRelation("FatturaElettronicaHeader_CedentePrestatore",CPar,CChild));

TPar= Tables["DatiTrasmissione"];
TChild= Tables["ContattiTrasmittente"];
CPar = new DataColumn[1]{TPar.Columns["DatiTrasmissione_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiTrasmissione_Id"]};
Relations.Add(new DataRelation("DatiTrasmissione_ContattiTrasmittente",CPar,CChild));

TPar= Tables["DatiTrasmissione"];
TChild= Tables["IdTrasmittente"];
CPar = new DataColumn[1]{TPar.Columns["DatiTrasmissione_Id"]};
CChild = new DataColumn[1]{TChild.Columns["DatiTrasmissione_Id"]};
Relations.Add(new DataRelation("DatiTrasmissione_IdTrasmittente",CPar,CChild));

TPar= Tables["FatturaElettronicaHeader"];
TChild= Tables["DatiTrasmissione"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronicaHeader_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronicaHeader_Id"]};
Relations.Add(new DataRelation("FatturaElettronicaHeader_DatiTrasmissione",CPar,CChild));

TPar= Tables["FatturaElettronica"];
TChild= Tables["FatturaElettronicaHeader"];
CPar = new DataColumn[1]{TPar.Columns["FatturaElettronica_Id"]};
CChild = new DataColumn[1]{TChild.Columns["FatturaElettronica_Id"]};
Relations.Add(new DataRelation("FatturaElettronica_FatturaElettronicaHeader",CPar,CChild));

}
}
}
