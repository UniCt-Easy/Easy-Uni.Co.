
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
using System.Collections.Generic;
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_nso_vendita {
public class nso_venditaRow: MetaRow  {
	public nso_venditaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32? idnso_vendita{ 
		get {if (this["idnso_vendita"]==DBNull.Value)return null; return  (Int32?)this["idnso_vendita"];}
		set {if (value==null) this["idnso_vendita"]= DBNull.Value; else this["idnso_vendita"]= value;}
	}
	public object idnso_venditaValue { 
		get{ return this["idnso_vendita"];}
		set {if (value==null|| value==DBNull.Value) this["idnso_vendita"]= DBNull.Value; else this["idnso_vendita"]= value;}
	}
	public Int32? idnso_venditaOriginal { 
		get {if (this["idnso_vendita",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnso_vendita",DataRowVersion.Original];}
	}
	public String filename{ 
		get {if (this["filename"]==DBNull.Value)return null; return  (String)this["filename"];}
		set {if (value==null) this["filename"]= DBNull.Value; else this["filename"]= value;}
	}
	public object filenameValue { 
		get{ return this["filename"];}
		set {if (value==null|| value==DBNull.Value) this["filename"]= DBNull.Value; else this["filename"]= value;}
	}
	public String filenameOriginal { 
		get {if (this["filename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["filename",DataRowVersion.Original];}
	}
	public String zipfilename{ 
		get {if (this["zipfilename"]==DBNull.Value)return null; return  (String)this["zipfilename"];}
		set {if (value==null) this["zipfilename"]= DBNull.Value; else this["zipfilename"]= value;}
	}
	public object zipfilenameValue { 
		get{ return this["zipfilename"];}
		set {if (value==null|| value==DBNull.Value) this["zipfilename"]= DBNull.Value; else this["zipfilename"]= value;}
	}
	public String zipfilenameOriginal { 
		get {if (this["zipfilename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["zipfilename",DataRowVersion.Original];}
	}
	public DateTime? adate{ 
		get {if (this["adate"]==DBNull.Value)return null; return  (DateTime?)this["adate"];}
		set {if (value==null) this["adate"]= DBNull.Value; else this["adate"]= value;}
	}
	public object adateValue { 
		get{ return this["adate"];}
		set {if (value==null|| value==DBNull.Value) this["adate"]= DBNull.Value; else this["adate"]= value;}
	}
	public DateTime? adateOriginal { 
		get {if (this["adate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["adate",DataRowVersion.Original];}
	}
	public String xml{ 
		get {if (this["xml"]==DBNull.Value)return null; return  (String)this["xml"];}
		set {if (value==null) this["xml"]= DBNull.Value; else this["xml"]= value;}
	}
	public object xmlValue { 
		get{ return this["xml"];}
		set {if (value==null|| value==DBNull.Value) this["xml"]= DBNull.Value; else this["xml"]= value;}
	}
	public String xmlOriginal { 
		get {if (this["xml",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["xml",DataRowVersion.Original];}
	}
	public Int64? identificativo_nso{ 
		get {if (this["identificativo_nso"]==DBNull.Value)return null; return  (Int64?)this["identificativo_nso"];}
		set {if (value==null) this["identificativo_nso"]= DBNull.Value; else this["identificativo_nso"]= value;}
	}
	public object identificativo_nsoValue { 
		get{ return this["identificativo_nso"];}
		set {if (value==null|| value==DBNull.Value) this["identificativo_nso"]= DBNull.Value; else this["identificativo_nso"]= value;}
	}
	public Int64? identificativo_nsoOriginal { 
		get {if (this["identificativo_nso",DataRowVersion.Original]==DBNull.Value)return null; return  (Int64?)this["identificativo_nso",DataRowVersion.Original];}
	}
	public DateTime? lt{ 
		get {if (this["lt"]==DBNull.Value)return null; return  (DateTime?)this["lt"];}
		set {if (value==null) this["lt"]= DBNull.Value; else this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {if (value==null|| value==DBNull.Value) this["lt"]= DBNull.Value; else this["lt"]= value;}
	}
	public DateTime? ltOriginal { 
		get {if (this["lt",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lt",DataRowVersion.Original];}
	}
	public String lu{ 
		get {if (this["lu"]==DBNull.Value)return null; return  (String)this["lu"];}
		set {if (value==null) this["lu"]= DBNull.Value; else this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {if (value==null|| value==DBNull.Value) this["lu"]= DBNull.Value; else this["lu"]= value;}
	}
	public String luOriginal { 
		get {if (this["lu",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lu",DataRowVersion.Original];}
	}
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
	public Int32? position{ 
		get {if (this["position"]==DBNull.Value)return null; return  (Int32?)this["position"];}
		set {if (value==null) this["position"]= DBNull.Value; else this["position"]= value;}
	}
	public object positionValue { 
		get{ return this["position"];}
		set {if (value==null|| value==DBNull.Value) this["position"]= DBNull.Value; else this["position"]= value;}
	}
	public Int32? positionOriginal { 
		get {if (this["position",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["position",DataRowVersion.Original];}
	}
	public Int16? idnso_status{ 
		get {if (this["idnso_status"]==DBNull.Value)return null; return  (Int16?)this["idnso_status"];}
		set {if (value==null) this["idnso_status"]= DBNull.Value; else this["idnso_status"]= value;}
	}
	public object idnso_statusValue { 
		get{ return this["idnso_status"];}
		set {if (value==null|| value==DBNull.Value) this["idnso_status"]= DBNull.Value; else this["idnso_status"]= value;}
	}
	public Int16? idnso_statusOriginal { 
		get {if (this["idnso_status",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["idnso_status",DataRowVersion.Original];}
	}
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
	public String tipo_risposta{ 
		get {if (this["tipo_risposta"]==DBNull.Value)return null; return  (String)this["tipo_risposta"];}
		set {if (value==null) this["tipo_risposta"]= DBNull.Value; else this["tipo_risposta"]= value;}
	}
	public object tipo_rispostaValue { 
		get{ return this["tipo_risposta"];}
		set {if (value==null|| value==DBNull.Value) this["tipo_risposta"]= DBNull.Value; else this["tipo_risposta"]= value;}
	}
	public String tipo_rispostaOriginal { 
		get {if (this["tipo_risposta",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tipo_risposta",DataRowVersion.Original];}
	}
	public DateTime? data_risposta{ 
		get {if (this["data_risposta"]==DBNull.Value)return null; return  (DateTime?)this["data_risposta"];}
		set {if (value==null) this["data_risposta"]= DBNull.Value; else this["data_risposta"]= value;}
	}
	public object data_rispostaValue { 
		get{ return this["data_risposta"];}
		set {if (value==null|| value==DBNull.Value) this["data_risposta"]= DBNull.Value; else this["data_risposta"]= value;}
	}
	public DateTime? data_rispostaOriginal { 
		get {if (this["data_risposta",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["data_risposta",DataRowVersion.Original];}
	}
	public String tipo_riscontro{ 
		get {if (this["tipo_riscontro"]==DBNull.Value)return null; return  (String)this["tipo_riscontro"];}
		set {if (value==null) this["tipo_riscontro"]= DBNull.Value; else this["tipo_riscontro"]= value;}
	}
	public object tipo_riscontroValue { 
		get{ return this["tipo_riscontro"];}
		set {if (value==null|| value==DBNull.Value) this["tipo_riscontro"]= DBNull.Value; else this["tipo_riscontro"]= value;}
	}
	public String tipo_riscontroOriginal { 
		get {if (this["tipo_riscontro",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tipo_riscontro",DataRowVersion.Original];}
	}
	public DateTime? data_riscontro{ 
		get {if (this["data_riscontro"]==DBNull.Value)return null; return  (DateTime?)this["data_riscontro"];}
		set {if (value==null) this["data_riscontro"]= DBNull.Value; else this["data_riscontro"]= value;}
	}
	public object data_riscontroValue { 
		get{ return this["data_riscontro"];}
		set {if (value==null|| value==DBNull.Value) this["data_riscontro"]= DBNull.Value; else this["data_riscontro"]= value;}
	}
	public DateTime? data_riscontroOriginal { 
		get {if (this["data_riscontro",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["data_riscontro",DataRowVersion.Original];}
	}
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
	public String signedxml{ 
		get {if (this["signedxml"]==DBNull.Value)return null; return  (String)this["signedxml"];}
		set {if (value==null) this["signedxml"]= DBNull.Value; else this["signedxml"]= value;}
	}
	public object signedxmlValue { 
		get{ return this["signedxml"];}
		set {if (value==null|| value==DBNull.Value) this["signedxml"]= DBNull.Value; else this["signedxml"]= value;}
	}
	public String signedxmlOriginal { 
		get {if (this["signedxml",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["signedxml",DataRowVersion.Original];}
	}
	public String signedxmlfilename{ 
		get {if (this["signedxmlfilename"]==DBNull.Value)return null; return  (String)this["signedxmlfilename"];}
		set {if (value==null) this["signedxmlfilename"]= DBNull.Value; else this["signedxmlfilename"]= value;}
	}
	public object signedxmlfilenameValue { 
		get{ return this["signedxmlfilename"];}
		set {if (value==null|| value==DBNull.Value) this["signedxmlfilename"]= DBNull.Value; else this["signedxmlfilename"]= value;}
	}
	public String signedxmlfilenameOriginal { 
		get {if (this["signedxmlfilename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["signedxmlfilename",DataRowVersion.Original];}
	}
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
	public String order_id{ 
		get {if (this["order_id"]==DBNull.Value)return null; return  (String)this["order_id"];}
		set {if (value==null) this["order_id"]= DBNull.Value; else this["order_id"]= value;}
	}
	public object order_idValue { 
		get{ return this["order_id"];}
		set {if (value==null|| value==DBNull.Value) this["order_id"]= DBNull.Value; else this["order_id"]= value;}
	}
	public String order_idOriginal { 
		get {if (this["order_id",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["order_id",DataRowVersion.Original];}
	}
	public String order_idemittente{ 
		get {if (this["order_idemittente"]==DBNull.Value)return null; return  (String)this["order_idemittente"];}
		set {if (value==null) this["order_idemittente"]= DBNull.Value; else this["order_idemittente"]= value;}
	}
	public object order_idemittenteValue { 
		get{ return this["order_idemittente"];}
		set {if (value==null|| value==DBNull.Value) this["order_idemittente"]= DBNull.Value; else this["order_idemittente"]= value;}
	}
	public String order_idemittenteOriginal { 
		get {if (this["order_idemittente",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["order_idemittente",DataRowVersion.Original];}
	}
	public DateTime? order_data_scadenza{ 
		get {if (this["order_data_scadenza"]==DBNull.Value)return null; return  (DateTime?)this["order_data_scadenza"];}
		set {if (value==null) this["order_data_scadenza"]= DBNull.Value; else this["order_data_scadenza"]= value;}
	}
	public object order_data_scadenzaValue { 
		get{ return this["order_data_scadenza"];}
		set {if (value==null|| value==DBNull.Value) this["order_data_scadenza"]= DBNull.Value; else this["order_data_scadenza"]= value;}
	}
	public DateTime? order_data_scadenzaOriginal { 
		get {if (this["order_data_scadenza",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["order_data_scadenza",DataRowVersion.Original];}
	}
	public Int32? order_tipo{ 
		get {if (this["order_tipo"]==DBNull.Value)return null; return  (Int32?)this["order_tipo"];}
		set {if (value==null) this["order_tipo"]= DBNull.Value; else this["order_tipo"]= value;}
	}
	public object order_tipoValue { 
		get{ return this["order_tipo"];}
		set {if (value==null|| value==DBNull.Value) this["order_tipo"]= DBNull.Value; else this["order_tipo"]= value;}
	}
	public Int32? order_tipoOriginal { 
		get {if (this["order_tipo",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["order_tipo",DataRowVersion.Original];}
	}
	public String contratto_id{ 
		get {if (this["contratto_id"]==DBNull.Value)return null; return  (String)this["contratto_id"];}
		set {if (value==null) this["contratto_id"]= DBNull.Value; else this["contratto_id"]= value;}
	}
	public object contratto_idValue { 
		get{ return this["contratto_id"];}
		set {if (value==null|| value==DBNull.Value) this["contratto_id"]= DBNull.Value; else this["contratto_id"]= value;}
	}
	public String contratto_idOriginal { 
		get {if (this["contratto_id",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["contratto_id",DataRowVersion.Original];}
	}
	public String codice_identificativo_gara{ 
		get {if (this["codice_identificativo_gara"]==DBNull.Value)return null; return  (String)this["codice_identificativo_gara"];}
		set {if (value==null) this["codice_identificativo_gara"]= DBNull.Value; else this["codice_identificativo_gara"]= value;}
	}
	public object codice_identificativo_garaValue { 
		get{ return this["codice_identificativo_gara"];}
		set {if (value==null|| value==DBNull.Value) this["codice_identificativo_gara"]= DBNull.Value; else this["codice_identificativo_gara"]= value;}
	}
	public String codice_identificativo_garaOriginal { 
		get {if (this["codice_identificativo_gara",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codice_identificativo_gara",DataRowVersion.Original];}
	}
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
	public Decimal? tax_total{ 
		get {if (this["tax_total"]==DBNull.Value)return null; return  (Decimal?)this["tax_total"];}
		set {if (value==null) this["tax_total"]= DBNull.Value; else this["tax_total"]= value;}
	}
	public object tax_totalValue { 
		get{ return this["tax_total"];}
		set {if (value==null|| value==DBNull.Value) this["tax_total"]= DBNull.Value; else this["tax_total"]= value;}
	}
	public Decimal? tax_totalOriginal { 
		get {if (this["tax_total",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["tax_total",DataRowVersion.Original];}
	}
	public String buyer_id{ 
		get {if (this["buyer_id"]==DBNull.Value)return null; return  (String)this["buyer_id"];}
		set {if (value==null) this["buyer_id"]= DBNull.Value; else this["buyer_id"]= value;}
	}
	public object buyer_idValue { 
		get{ return this["buyer_id"];}
		set {if (value==null|| value==DBNull.Value) this["buyer_id"]= DBNull.Value; else this["buyer_id"]= value;}
	}
	public String buyer_idOriginal { 
		get {if (this["buyer_id",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["buyer_id",DataRowVersion.Original];}
	}
	public String buyer_name{ 
		get {if (this["buyer_name"]==DBNull.Value)return null; return  (String)this["buyer_name"];}
		set {if (value==null) this["buyer_name"]= DBNull.Value; else this["buyer_name"]= value;}
	}
	public object buyer_nameValue { 
		get{ return this["buyer_name"];}
		set {if (value==null|| value==DBNull.Value) this["buyer_name"]= DBNull.Value; else this["buyer_name"]= value;}
	}
	public String buyer_nameOriginal { 
		get {if (this["buyer_name",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["buyer_name",DataRowVersion.Original];}
	}
	public String buyer_taxid{ 
		get {if (this["buyer_taxid"]==DBNull.Value)return null; return  (String)this["buyer_taxid"];}
		set {if (value==null) this["buyer_taxid"]= DBNull.Value; else this["buyer_taxid"]= value;}
	}
	public object buyer_taxidValue { 
		get{ return this["buyer_taxid"];}
		set {if (value==null|| value==DBNull.Value) this["buyer_taxid"]= DBNull.Value; else this["buyer_taxid"]= value;}
	}
	public String buyer_taxidOriginal { 
		get {if (this["buyer_taxid",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["buyer_taxid",DataRowVersion.Original];}
	}
	public String email_nso{ 
		get {if (this["email_nso"]==DBNull.Value)return null; return  (String)this["email_nso"];}
		set {if (value==null) this["email_nso"]= DBNull.Value; else this["email_nso"]= value;}
	}
	public object email_nsoValue { 
		get{ return this["email_nso"];}
		set {if (value==null|| value==DBNull.Value) this["email_nso"]= DBNull.Value; else this["email_nso"]= value;}
	}
	public String email_nsoOriginal { 
		get {if (this["email_nso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["email_nso",DataRowVersion.Original];}
	}
	public Int16? idnso_deliverystatus{ 
		get {if (this["idnso_deliverystatus"]==DBNull.Value)return null; return  (Int16?)this["idnso_deliverystatus"];}
		set {if (value==null) this["idnso_deliverystatus"]= DBNull.Value; else this["idnso_deliverystatus"]= value;}
	}
	public object idnso_deliverystatusValue { 
		get{ return this["idnso_deliverystatus"];}
		set {if (value==null|| value==DBNull.Value) this["idnso_deliverystatus"]= DBNull.Value; else this["idnso_deliverystatus"]= value;}
	}
	public Int16? idnso_deliverystatusOriginal { 
		get {if (this["idnso_deliverystatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["idnso_deliverystatus",DataRowVersion.Original];}
	}
	#endregion

}
public class nso_venditaTable : MetaTableBase<nso_venditaRow> {
	public nso_venditaTable() : base("nso_vendita"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idnso_vendita",createColumn("idnso_vendita",typeof(int),false,false)},
			{"filename",createColumn("filename",typeof(string),false,false)},
			{"zipfilename",createColumn("zipfilename",typeof(string),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"xml",createColumn("xml",typeof(string),false,false)},
			{"identificativo_nso",createColumn("identificativo_nso",typeof(long),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"dt",createColumn("dt",typeof(string),true,false)},
			{"dt_prot",createColumn("dt_prot",typeof(string),true,false)},
			{"ec",createColumn("ec",typeof(string),true,false)},
			{"ec_prot",createColumn("ec_prot",typeof(string),true,false)},
			{"mt",createColumn("mt",typeof(string),true,false)},
			{"mt_prot",createColumn("mt_prot",typeof(string),true,false)},
			{"se",createColumn("se",typeof(string),true,false)},
			{"se_prot",createColumn("se_prot",typeof(string),true,false)},
			{"ec_sent",createColumn("ec_sent",typeof(string),true,false)},
			{"ec_number",createColumn("ec_number",typeof(int),true,false)},
			{"position",createColumn("position",typeof(int),false,false)},
			{"idnso_status",createColumn("idnso_status",typeof(short),false,false)},
			{"flag_unseen",createColumn("flag_unseen",typeof(int),true,false)},
			{"codice_ipa",createColumn("codice_ipa",typeof(string),true,false)},
			{"protocoldate",createColumn("protocoldate",typeof(DateTime),true,false)},
			{"arrivalprotocolnum",createColumn("arrivalprotocolnum",typeof(string),true,false)},
			{"rejectreason",createColumn("rejectreason",typeof(string),true,false)},
			{"riferimento_amministrazione",createColumn("riferimento_amministrazione",typeof(string),true,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"data_ricezione",createColumn("data_ricezione",typeof(DateTime),true,false)},
			{"tipo_risposta",createColumn("tipo_risposta",typeof(string),true,false)},
			{"data_risposta",createColumn("data_risposta",typeof(DateTime),true,false)},
			{"tipo_riscontro",createColumn("tipo_riscontro",typeof(string),true,false)},
			{"data_riscontro",createColumn("data_riscontro",typeof(DateTime),true,false)},
			{"protocol_error",createColumn("protocol_error",typeof(string),true,false)},
			{"tipodocumento",createColumn("tipodocumento",typeof(string),true,false)},
			{"signedxml",createColumn("signedxml",typeof(string),true,false)},
			{"signedxmlfilename",createColumn("signedxmlfilename",typeof(string),true,false)},
			{"utente_accettata",createColumn("utente_accettata",typeof(string),true,false)},
			{"utente_rifiutata",createColumn("utente_rifiutata",typeof(string),true,false)},
			{"data_accettata",createColumn("data_accettata",typeof(DateTime),true,false)},
			{"data_rifiutata",createColumn("data_rifiutata",typeof(DateTime),true,false)},
			{"order_id",createColumn("order_id",typeof(string),false,false)},
			{"order_idemittente",createColumn("order_idemittente",typeof(string),true,false)},
			{"order_data_scadenza",createColumn("order_data_scadenza",typeof(DateTime),true,false)},
			{"order_tipo",createColumn("order_tipo",typeof(int),false,false)},
			{"contratto_id",createColumn("contratto_id",typeof(string),true,false)},
			{"codice_identificativo_gara",createColumn("codice_identificativo_gara",typeof(string),true,false)},
			{"total",createColumn("total",typeof(decimal),true,false)},
			{"tax_total",createColumn("tax_total",typeof(decimal),true,false)},
			{"buyer_id",createColumn("buyer_id",typeof(string),true,false)},
			{"buyer_name",createColumn("buyer_name",typeof(string),true,false)},
			{"buyer_taxid",createColumn("buyer_taxid",typeof(string),true,false)},
			{"email_nso",createColumn("email_nso",typeof(string),true,false)},
			{"idnso_deliverystatus",createColumn("idnso_deliverystatus",typeof(short),true,false)},
		};
	}
}
}
