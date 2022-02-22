
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_sdi_acquisto {
public class sdi_acquistoRow: MetaRow  {
	public sdi_acquistoRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num.File
	///</summary>
	public Int32 idsdi_acquisto{ 
		get {return  (Int32)this["idsdi_acquisto"];}
		set {this["idsdi_acquisto"]= value;}
	}
	public object idsdi_acquistoValue { 
		get{ return this["idsdi_acquisto"];}
		set {this["idsdi_acquisto"]= value;}
	}
	public Int32 idsdi_acquistoOriginal { 
		get {return  (Int32)this["idsdi_acquisto",DataRowVersion.Original];}
	}
	///<summary>
	///Nome file
	///</summary>
	public String filename{ 
		get {return  (String)this["filename"];}
		set {this["filename"]= value;}
	}
	public object filenameValue { 
		get{ return this["filename"];}
		set {this["filename"]= value;}
	}
	public String filenameOriginal { 
		get {return  (String)this["filename",DataRowVersion.Original];}
	}
	///<summary>
	///Nome File supporto
	///</summary>
	public String zipfilename{ 
		get {return  (String)this["zipfilename"];}
		set {this["zipfilename"]= value;}
	}
	public object zipfilenameValue { 
		get{ return this["zipfilename"];}
		set {this["zipfilename"]= value;}
	}
	public String zipfilenameOriginal { 
		get {return  (String)this["zipfilename",DataRowVersion.Original];}
	}
	///<summary>
	///data contabile
	///</summary>
	public DateTime adate{ 
		get {return  (DateTime)this["adate"];}
		set {this["adate"]= value;}
	}
	public object adateValue { 
		get{ return this["adate"];}
		set {this["adate"]= value;}
	}
	public DateTime adateOriginal { 
		get {return  (DateTime)this["adate",DataRowVersion.Original];}
	}
	///<summary>
	///xml fattura
	///</summary>
	public String xml{ 
		get {return  (String)this["xml"];}
		set {this["xml"]= value;}
	}
	public object xmlValue { 
		get{ return this["xml"];}
		set {this["xml"]= value;}
	}
	public String xmlOriginal { 
		get {return  (String)this["xml",DataRowVersion.Original];}
	}
	///<summary>
	///data ultima modifica
	///</summary>
	public DateTime lt{ 
		get {return  (DateTime)this["lt"];}
		set {this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {this["lt"]= value;}
	}
	public DateTime ltOriginal { 
		get {return  (DateTime)this["lt",DataRowVersion.Original];}
	}
	///<summary>
	///nome ultimo utente modifica
	///</summary>
	public String lu{ 
		get {return  (String)this["lu"];}
		set {this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {this["lu"]= value;}
	}
	public String luOriginal { 
		get {return  (String)this["lu",DataRowVersion.Original];}
	}
	///<summary>
	///identificativo assegnato dall'SDI
	///</summary>
	public Int64? identificativo_sdi{ 
		get {if (this["identificativo_sdi"]==DBNull.Value)return null; return  (Int64?)this["identificativo_sdi"];}
		set {if (value==null) this["identificativo_sdi"]= DBNull.Value; else this["identificativo_sdi"]= value;}
	}
	public object identificativo_sdiValue { 
		get{ return this["identificativo_sdi"];}
		set {if (value==null|| value==DBNull.Value) this["identificativo_sdi"]= DBNull.Value; else this["identificativo_sdi"]= value;}
	}
	public Int64? identificativo_sdiOriginal { 
		get {if (this["identificativo_sdi",DataRowVersion.Original]==DBNull.Value)return null; return  (Int64?)this["identificativo_sdi",DataRowVersion.Original];}
	}
	///<summary>
	///file xml metadati
	///</summary>
	public String mt{ 
		get {if (this["mt"]==DBNull.Value)return null; return  (String)this["mt"];}
		set {if (value==null) this["mt"]= DBNull.Value; else this["mt"]= value;}
	}
	public object mtValue { 
		get{ return this["mt"];}
		set {if (value==null|| value==DBNull.Value) this["mt"]= DBNull.Value; else this["mt"]= value;}
	}
	public String mtOriginal { 
		get {if (this["mt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mt",DataRowVersion.Original];}
	}
	///<summary>
	///file xml esito committente 
	///</summary>
	public String ec{ 
		get {if (this["ec"]==DBNull.Value)return null; return  (String)this["ec"];}
		set {if (value==null) this["ec"]= DBNull.Value; else this["ec"]= value;}
	}
	public object ecValue { 
		get{ return this["ec"];}
		set {if (value==null|| value==DBNull.Value) this["ec"]= DBNull.Value; else this["ec"]= value;}
	}
	public String ecOriginal { 
		get {if (this["ec",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ec",DataRowVersion.Original];}
	}
	///<summary>
	///esito committente inviato
	///	 N: Esito committente non inviato
	///	 S: esito committente inviato
	///</summary>
	public String ec_sent{ 
		get {if (this["ec_sent"]==DBNull.Value)return null; return  (String)this["ec_sent"];}
		set {if (value==null) this["ec_sent"]= DBNull.Value; else this["ec_sent"]= value;}
	}
	public object ec_sentValue { 
		get{ return this["ec_sent"];}
		set {if (value==null|| value==DBNull.Value) this["ec_sent"]= DBNull.Value; else this["ec_sent"]= value;}
	}
	public String ec_sentOriginal { 
		get {if (this["ec_sent",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ec_sent",DataRowVersion.Original];}
	}
	///<summary>
	///File xml "scarto esito"
	///</summary>
	public String se{ 
		get {if (this["se"]==DBNull.Value)return null; return  (String)this["se"];}
		set {if (value==null) this["se"]= DBNull.Value; else this["se"]= value;}
	}
	public object seValue { 
		get{ return this["se"];}
		set {if (value==null|| value==DBNull.Value) this["se"]= DBNull.Value; else this["se"]= value;}
	}
	public String seOriginal { 
		get {if (this["se",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["se",DataRowVersion.Original];}
	}
	///<summary>
	///file xml comunicazione decorrenza  termini
	///</summary>
	public String dt{ 
		get {if (this["dt"]==DBNull.Value)return null; return  (String)this["dt"];}
		set {if (value==null) this["dt"]= DBNull.Value; else this["dt"]= value;}
	}
	public object dtValue { 
		get{ return this["dt"];}
		set {if (value==null|| value==DBNull.Value) this["dt"]= DBNull.Value; else this["dt"]= value;}
	}
	public String dtOriginal { 
		get {if (this["dt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["dt",DataRowVersion.Original];}
	}
	///<summary>
	///Informazioni ricevute non visualizzate
	///</summary>
	public Int32? flag_unseen{ 
		get {if (this["flag_unseen"]==DBNull.Value)return null; return  (Int32?)this["flag_unseen"];}
		set {if (value==null) this["flag_unseen"]= DBNull.Value; else this["flag_unseen"]= value;}
	}
	public object flag_unseenValue { 
		get{ return this["flag_unseen"];}
		set {if (value==null|| value==DBNull.Value) this["flag_unseen"]= DBNull.Value; else this["flag_unseen"]= value;}
	}
	public Int32? flag_unseenOriginal { 
		get {if (this["flag_unseen",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flag_unseen",DataRowVersion.Original];}
	}
	///<summary>
	///ID Stato fattura in SDI (tabella sdi_status)
	///	 1: In attesa
	///	 2: Accettata
	///	 3: Rifiutata
	///	 4: Decorsi i termini
	///	 5: Da protocollare (casua problemi tecnici col servizio)
	///	 6: Da protocollare (inserita via web)
	///</summary>
	public Int16 idsdi_status{ 
		get {return  (Int16)this["idsdi_status"];}
		set {this["idsdi_status"]= value;}
	}
	public object idsdi_statusValue { 
		get{ return this["idsdi_status"];}
		set {this["idsdi_status"]= value;}
	}
	public Int16 idsdi_statusOriginal { 
		get {return  (Int16)this["idsdi_status",DataRowVersion.Original];}
	}
	///<summary>
	///Posizione della fattura di acquisto all'interno del file xml
	///</summary>
	public Int32 position{ 
		get {return  (Int32)this["position"];}
		set {this["position"]= value;}
	}
	public object positionValue { 
		get{ return this["position"];}
		set {this["position"]= value;}
	}
	public Int32 positionOriginal { 
		get {return  (Int32)this["position",DataRowVersion.Original];}
	}
	///<summary>
	///Numero progressivo per comunicazione esito committente, fa parte del nome file esito committente inviato
	///</summary>
	public Int32? ec_number{ 
		get {if (this["ec_number"]==DBNull.Value)return null; return  (Int32?)this["ec_number"];}
		set {if (value==null) this["ec_number"]= DBNull.Value; else this["ec_number"]= value;}
	}
	public object ec_numberValue { 
		get{ return this["ec_number"];}
		set {if (value==null|| value==DBNull.Value) this["ec_number"]= DBNull.Value; else this["ec_number"]= value;}
	}
	public Int32? ec_numberOriginal { 
		get {if (this["ec_number",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ec_number",DataRowVersion.Original];}
	}
	///<summary>
	///Denominazione
	///</summary>
	public String title{ 
		get {if (this["title"]==DBNull.Value)return null; return  (String)this["title"];}
		set {if (value==null) this["title"]= DBNull.Value; else this["title"]= value;}
	}
	public object titleValue { 
		get{ return this["title"];}
		set {if (value==null|| value==DBNull.Value) this["title"]= DBNull.Value; else this["title"]= value;}
	}
	public String titleOriginal { 
		get {if (this["title",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione
	///</summary>
	public String description{ 
		get {if (this["description"]==DBNull.Value)return null; return  (String)this["description"];}
		set {if (value==null) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {if (value==null|| value==DBNull.Value) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {if (this["description",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["description",DataRowVersion.Original];}
	}
	///<summary>
	///Numero Fattura
	///</summary>
	public String ninvoice{ 
		get {if (this["ninvoice"]==DBNull.Value)return null; return  (String)this["ninvoice"];}
		set {if (value==null) this["ninvoice"]= DBNull.Value; else this["ninvoice"]= value;}
	}
	public object ninvoiceValue { 
		get{ return this["ninvoice"];}
		set {if (value==null|| value==DBNull.Value) this["ninvoice"]= DBNull.Value; else this["ninvoice"]= value;}
	}
	public String ninvoiceOriginal { 
		get {if (this["ninvoice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ninvoice",DataRowVersion.Original];}
	}
	///<summary>
	///Riferimento amministrazione
	///</summary>
	public String riferimento_amministrazione{ 
		get {if (this["riferimento_amministrazione"]==DBNull.Value)return null; return  (String)this["riferimento_amministrazione"];}
		set {if (value==null) this["riferimento_amministrazione"]= DBNull.Value; else this["riferimento_amministrazione"]= value;}
	}
	public object riferimento_amministrazioneValue { 
		get{ return this["riferimento_amministrazione"];}
		set {if (value==null|| value==DBNull.Value) this["riferimento_amministrazione"]= DBNull.Value; else this["riferimento_amministrazione"]= value;}
	}
	public String riferimento_amministrazioneOriginal { 
		get {if (this["riferimento_amministrazione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["riferimento_amministrazione",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA  (campo ipa_fe di tabella IPA)
	///</summary>
	public String codice_ipa{ 
		get {if (this["codice_ipa"]==DBNull.Value)return null; return  (String)this["codice_ipa"];}
		set {if (value==null) this["codice_ipa"]= DBNull.Value; else this["codice_ipa"]= value;}
	}
	public object codice_ipaValue { 
		get{ return this["codice_ipa"];}
		set {if (value==null|| value==DBNull.Value) this["codice_ipa"]= DBNull.Value; else this["codice_ipa"]= value;}
	}
	public String codice_ipaOriginal { 
		get {if (this["codice_ipa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codice_ipa",DataRowVersion.Original];}
	}
	///<summary>
	///Importo totale documento
	///</summary>
	public Decimal? total{ 
		get {if (this["total"]==DBNull.Value)return null; return  (Decimal?)this["total"];}
		set {if (value==null) this["total"]= DBNull.Value; else this["total"]= value;}
	}
	public object totalValue { 
		get{ return this["total"];}
		set {if (value==null|| value==DBNull.Value) this["total"]= DBNull.Value; else this["total"]= value;}
	}
	public Decimal? totalOriginal { 
		get {if (this["total",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["total",DataRowVersion.Original];}
	}
	///<summary>
	///Totale sconto
	///</summary>
	public Decimal? discount_amount{ 
		get {if (this["discount_amount"]==DBNull.Value)return null; return  (Decimal?)this["discount_amount"];}
		set {if (value==null) this["discount_amount"]= DBNull.Value; else this["discount_amount"]= value;}
	}
	public object discount_amountValue { 
		get{ return this["discount_amount"];}
		set {if (value==null|| value==DBNull.Value) this["discount_amount"]= DBNull.Value; else this["discount_amount"]= value;}
	}
	public Decimal? discount_amountOriginal { 
		get {if (this["discount_amount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["discount_amount",DataRowVersion.Original];}
	}
	///<summary>
	///Data Ricezione
	///</summary>
	public DateTime? protocoldate{ 
		get {if (this["protocoldate"]==DBNull.Value)return null; return  (DateTime?)this["protocoldate"];}
		set {if (value==null) this["protocoldate"]= DBNull.Value; else this["protocoldate"]= value;}
	}
	public object protocoldateValue { 
		get{ return this["protocoldate"];}
		set {if (value==null|| value==DBNull.Value) this["protocoldate"]= DBNull.Value; else this["protocoldate"]= value;}
	}
	public DateTime? protocoldateOriginal { 
		get {if (this["protocoldate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["protocoldate",DataRowVersion.Original];}
	}
	///<summary>
	///Numero protocollo di entrata
	///</summary>
	public String arrivalprotocolnum{ 
		get {if (this["arrivalprotocolnum"]==DBNull.Value)return null; return  (String)this["arrivalprotocolnum"];}
		set {if (value==null) this["arrivalprotocolnum"]= DBNull.Value; else this["arrivalprotocolnum"]= value;}
	}
	public object arrivalprotocolnumValue { 
		get{ return this["arrivalprotocolnum"];}
		set {if (value==null|| value==DBNull.Value) this["arrivalprotocolnum"]= DBNull.Value; else this["arrivalprotocolnum"]= value;}
	}
	public String arrivalprotocolnumOriginal { 
		get {if (this["arrivalprotocolnum",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["arrivalprotocolnum",DataRowVersion.Original];}
	}
	///<summary>
	///Annotazioni su rifiuto o accettazione
	///</summary>
	public String rejectreason{ 
		get {if (this["rejectreason"]==DBNull.Value)return null; return  (String)this["rejectreason"];}
		set {if (value==null) this["rejectreason"]= DBNull.Value; else this["rejectreason"]= value;}
	}
	public object rejectreasonValue { 
		get{ return this["rejectreason"];}
		set {if (value==null|| value==DBNull.Value) this["rejectreason"]= DBNull.Value; else this["rejectreason"]= value;}
	}
	public String rejectreasonOriginal { 
		get {if (this["rejectreason",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rejectreason",DataRowVersion.Original];}
	}
	///<summary>
	///Protocollo esito committente
	///</summary>
	public String ec_prot{ 
		get {if (this["ec_prot"]==DBNull.Value)return null; return  (String)this["ec_prot"];}
		set {if (value==null) this["ec_prot"]= DBNull.Value; else this["ec_prot"]= value;}
	}
	public object ec_protValue { 
		get{ return this["ec_prot"];}
		set {if (value==null|| value==DBNull.Value) this["ec_prot"]= DBNull.Value; else this["ec_prot"]= value;}
	}
	public String ec_protOriginal { 
		get {if (this["ec_prot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ec_prot",DataRowVersion.Original];}
	}
	///<summary>
	///protocollo per file metadati
	///</summary>
	public String mt_prot{ 
		get {if (this["mt_prot"]==DBNull.Value)return null; return  (String)this["mt_prot"];}
		set {if (value==null) this["mt_prot"]= DBNull.Value; else this["mt_prot"]= value;}
	}
	public object mt_protValue { 
		get{ return this["mt_prot"];}
		set {if (value==null|| value==DBNull.Value) this["mt_prot"]= DBNull.Value; else this["mt_prot"]= value;}
	}
	public String mt_protOriginal { 
		get {if (this["mt_prot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mt_prot",DataRowVersion.Original];}
	}
	///<summary>
	///Protocollo per comunicazione scarto esito
	///</summary>
	public String se_prot{ 
		get {if (this["se_prot"]==DBNull.Value)return null; return  (String)this["se_prot"];}
		set {if (value==null) this["se_prot"]= DBNull.Value; else this["se_prot"]= value;}
	}
	public object se_protValue { 
		get{ return this["se_prot"];}
		set {if (value==null|| value==DBNull.Value) this["se_prot"]= DBNull.Value; else this["se_prot"]= value;}
	}
	public String se_protOriginal { 
		get {if (this["se_prot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["se_prot",DataRowVersion.Original];}
	}
	///<summary>
	///Protocollo decorrenza termini
	///</summary>
	public String dt_prot{ 
		get {if (this["dt_prot"]==DBNull.Value)return null; return  (String)this["dt_prot"];}
		set {if (value==null) this["dt_prot"]= DBNull.Value; else this["dt_prot"]= value;}
	}
	public object dt_protValue { 
		get{ return this["dt_prot"];}
		set {if (value==null|| value==DBNull.Value) this["dt_prot"]= DBNull.Value; else this["dt_prot"]= value;}
	}
	public String dt_protOriginal { 
		get {if (this["dt_prot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["dt_prot",DataRowVersion.Original];}
	}
	///<summary>
	///Utente accettazione
	///</summary>
	public String utente_accettata{ 
		get {if (this["utente_accettata"]==DBNull.Value)return null; return  (String)this["utente_accettata"];}
		set {if (value==null) this["utente_accettata"]= DBNull.Value; else this["utente_accettata"]= value;}
	}
	public object utente_accettataValue { 
		get{ return this["utente_accettata"];}
		set {if (value==null|| value==DBNull.Value) this["utente_accettata"]= DBNull.Value; else this["utente_accettata"]= value;}
	}
	public String utente_accettataOriginal { 
		get {if (this["utente_accettata",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["utente_accettata",DataRowVersion.Original];}
	}
	///<summary>
	///Utente rifiuto
	///</summary>
	public String utente_rifiutata{ 
		get {if (this["utente_rifiutata"]==DBNull.Value)return null; return  (String)this["utente_rifiutata"];}
		set {if (value==null) this["utente_rifiutata"]= DBNull.Value; else this["utente_rifiutata"]= value;}
	}
	public object utente_rifiutataValue { 
		get{ return this["utente_rifiutata"];}
		set {if (value==null|| value==DBNull.Value) this["utente_rifiutata"]= DBNull.Value; else this["utente_rifiutata"]= value;}
	}
	public String utente_rifiutataOriginal { 
		get {if (this["utente_rifiutata",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["utente_rifiutata",DataRowVersion.Original];}
	}
	///<summary>
	///Data accettazione
	///</summary>
	public DateTime? data_accettata{ 
		get {if (this["data_accettata"]==DBNull.Value)return null; return  (DateTime?)this["data_accettata"];}
		set {if (value==null) this["data_accettata"]= DBNull.Value; else this["data_accettata"]= value;}
	}
	public object data_accettataValue { 
		get{ return this["data_accettata"];}
		set {if (value==null|| value==DBNull.Value) this["data_accettata"]= DBNull.Value; else this["data_accettata"]= value;}
	}
	public DateTime? data_accettataOriginal { 
		get {if (this["data_accettata",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["data_accettata",DataRowVersion.Original];}
	}
	///<summary>
	///Data rifiuto
	///</summary>
	public DateTime? data_rifiutata{ 
		get {if (this["data_rifiutata"]==DBNull.Value)return null; return  (DateTime?)this["data_rifiutata"];}
		set {if (value==null) this["data_rifiutata"]= DBNull.Value; else this["data_rifiutata"]= value;}
	}
	public object data_rifiutataValue { 
		get{ return this["data_rifiutata"];}
		set {if (value==null|| value==DBNull.Value) this["data_rifiutata"]= DBNull.Value; else this["data_rifiutata"]= value;}
	}
	public DateTime? data_rifiutataOriginal { 
		get {if (this["data_rifiutata",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["data_rifiutata",DataRowVersion.Original];}
	}
	///<summary>
	///Messaggio di errore nell'ottenimento del protocollo
	///</summary>
	public String protocol_error{ 
		get {if (this["protocol_error"]==DBNull.Value)return null; return  (String)this["protocol_error"];}
		set {if (value==null) this["protocol_error"]= DBNull.Value; else this["protocol_error"]= value;}
	}
	public object protocol_errorValue { 
		get{ return this["protocol_error"];}
		set {if (value==null|| value==DBNull.Value) this["protocol_error"]= DBNull.Value; else this["protocol_error"]= value;}
	}
	public String protocol_errorOriginal { 
		get {if (this["protocol_error",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["protocol_error",DataRowVersion.Original];}
	}
	///<summary>
	///Totale come calcolato da easy sulla base della somma dei dettagli
	///</summary>
	public Decimal? total_easy{ 
		get {if (this["total_easy"]==DBNull.Value)return null; return  (Decimal?)this["total_easy"];}
		set {if (value==null) this["total_easy"]= DBNull.Value; else this["total_easy"]= value;}
	}
	public object total_easyValue { 
		get{ return this["total_easy"];}
		set {if (value==null|| value==DBNull.Value) this["total_easy"]= DBNull.Value; else this["total_easy"]= value;}
	}
	public Decimal? total_easyOriginal { 
		get {if (this["total_easy",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["total_easy",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo Documento SDI
	///	 TD01: Fattura
	///	 TD02: Acconto / anticipo su fattura
	///	 TD03: Acconto / anticipo su parcella
	///	 TD04: Nota di credito
	///	 TD05: Nota di debito
	///	 TD06: Parcella
	///</summary>
	public String tipodocumento{ 
		get {if (this["tipodocumento"]==DBNull.Value)return null; return  (String)this["tipodocumento"];}
		set {if (value==null) this["tipodocumento"]= DBNull.Value; else this["tipodocumento"]= value;}
	}
	public object tipodocumentoValue { 
		get{ return this["tipodocumento"];}
		set {if (value==null|| value==DBNull.Value) this["tipodocumento"]= DBNull.Value; else this["tipodocumento"]= value;}
	}
	public String tipodocumentoOriginal { 
		get {if (this["tipodocumento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tipodocumento",DataRowVersion.Original];}
	}
	///<summary>
	///Non creare fattura
	///	 N: Creare fattura (caso normale)
	///	 S: Non creare fattura
	///</summary>
	public String notcreacontabilita{ 
		get {if (this["notcreacontabilita"]==DBNull.Value)return null; return  (String)this["notcreacontabilita"];}
		set {if (value==null) this["notcreacontabilita"]= DBNull.Value; else this["notcreacontabilita"]= value;}
	}
	public object notcreacontabilitaValue { 
		get{ return this["notcreacontabilita"];}
		set {if (value==null|| value==DBNull.Value) this["notcreacontabilita"]= DBNull.Value; else this["notcreacontabilita"]= value;}
	}
	public String notcreacontabilitaOriginal { 
		get {if (this["notcreacontabilita",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["notcreacontabilita",DataRowVersion.Original];}
	}
	///<summary>
	///Motivo per cui non va creata una fattura in contabilit√†
	///</summary>
	public String notcreacontabilitareason{ 
		get {if (this["notcreacontabilitareason"]==DBNull.Value)return null; return  (String)this["notcreacontabilitareason"];}
		set {if (value==null) this["notcreacontabilitareason"]= DBNull.Value; else this["notcreacontabilitareason"]= value;}
	}
	public object notcreacontabilitareasonValue { 
		get{ return this["notcreacontabilitareason"];}
		set {if (value==null|| value==DBNull.Value) this["notcreacontabilitareason"]= DBNull.Value; else this["notcreacontabilitareason"]= value;}
	}
	public String notcreacontabilitareasonOriginal { 
		get {if (this["notcreacontabilitareason",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["notcreacontabilitareason",DataRowVersion.Original];}
	}
	public DateTime? data_ricezione{ 
		get {if (this["data_ricezione"]==DBNull.Value)return null; return  (DateTime?)this["data_ricezione"];}
		set {if (value==null) this["data_ricezione"]= DBNull.Value; else this["data_ricezione"]= value;}
	}
	public object data_ricezioneValue { 
		get{ return this["data_ricezione"];}
		set {if (value==null|| value==DBNull.Value) this["data_ricezione"]= DBNull.Value; else this["data_ricezione"]= value;}
	}
	public DateTime? data_ricezioneOriginal { 
		get {if (this["data_ricezione",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["data_ricezione",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Fattura Elettronica-Acquisto
///</summary>
public class sdi_acquistoTable : MetaTableBase<sdi_acquistoRow> {
	public sdi_acquistoTable() : base("sdi_acquisto"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idsdi_acquisto",createColumn("idsdi_acquisto",typeof(int),false,false)},
			{"filename",createColumn("filename",typeof(string),false,false)},
			{"zipfilename",createColumn("zipfilename",typeof(string),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"xml",createColumn("xml",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"identificativo_sdi",createColumn("identificativo_sdi",typeof(long),true,false)},
			{"mt",createColumn("mt",typeof(string),true,false)},
			{"ec",createColumn("ec",typeof(string),true,false)},
			{"ec_sent",createColumn("ec_sent",typeof(string),true,false)},
			{"se",createColumn("se",typeof(string),true,false)},
			{"dt",createColumn("dt",typeof(string),true,false)},
			{"flag_unseen",createColumn("flag_unseen",typeof(int),true,false)},
			{"idsdi_status",createColumn("idsdi_status",typeof(short),false,false)},
			{"position",createColumn("position",typeof(int),false,false)},
			{"ec_number",createColumn("ec_number",typeof(int),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"ninvoice",createColumn("ninvoice",typeof(string),true,false)},
			{"riferimento_amministrazione",createColumn("riferimento_amministrazione",typeof(string),true,false)},
			{"codice_ipa",createColumn("codice_ipa",typeof(string),true,false)},
			{"total",createColumn("total",typeof(decimal),true,false)},
			{"discount_amount",createColumn("discount_amount",typeof(decimal),true,false)},
			{"protocoldate",createColumn("protocoldate",typeof(DateTime),true,false)},
			{"arrivalprotocolnum",createColumn("arrivalprotocolnum",typeof(string),true,false)},
			{"rejectreason",createColumn("rejectreason",typeof(string),true,false)},
			{"ec_prot",createColumn("ec_prot",typeof(string),true,false)},
			{"mt_prot",createColumn("mt_prot",typeof(string),true,false)},
			{"se_prot",createColumn("se_prot",typeof(string),true,false)},
			{"dt_prot",createColumn("dt_prot",typeof(string),true,false)},
			{"utente_accettata",createColumn("utente_accettata",typeof(string),true,false)},
			{"utente_rifiutata",createColumn("utente_rifiutata",typeof(string),true,false)},
			{"data_accettata",createColumn("data_accettata",typeof(DateTime),true,false)},
			{"data_rifiutata",createColumn("data_rifiutata",typeof(DateTime),true,false)},
			{"protocol_error",createColumn("protocol_error",typeof(string),true,false)},
			{"total_easy",createColumn("total_easy",typeof(decimal),true,false)},
			{"tipodocumento",createColumn("tipodocumento",typeof(string),true,false)},
			{"notcreacontabilita",createColumn("notcreacontabilita",typeof(string),true,false)},
			{"notcreacontabilitareason",createColumn("notcreacontabilitareason",typeof(string),true,false)},
			{"data_ricezione",createColumn("data_ricezione",typeof(DateTime),true,false)},
		};
	}
}
}
