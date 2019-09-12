/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using metadatalibrary;
namespace meta_sdi_vendita {
public class sdi_venditaRow: MetaRow  {
	public sdi_venditaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num.File
	///</summary>
	public Int32? idsdi_vendita{ 
		get {if (this["idsdi_vendita"]==DBNull.Value)return null; return  (Int32?)this["idsdi_vendita"];}
		set {if (value==null) this["idsdi_vendita"]= DBNull.Value; else this["idsdi_vendita"]= value;}
	}
	public object idsdi_venditaValue { 
		get{ return this["idsdi_vendita"];}
		set {if (value==null|| value==DBNull.Value) this["idsdi_vendita"]= DBNull.Value; else this["idsdi_vendita"]= value;}
	}
	public Int32? idsdi_venditaOriginal { 
		get {if (this["idsdi_vendita",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsdi_vendita",DataRowVersion.Original];}
	}
	///<summary>
	///Nome file
	///</summary>
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
	///<summary>
	///data contabile
	///</summary>
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
	///<summary>
	///xml
	///</summary>
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
	///<summary>
	///data ultima modifica
	///</summary>
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
	///<summary>
	///nome ultimo utente modifica
	///</summary>
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
	///<summary>
	///Identificativo SdI
	///</summary>
	public Int32? identificativo_sdi{ 
		get {if (this["identificativo_sdi"]==DBNull.Value)return null; return  (Int32?)this["identificativo_sdi"];}
		set {if (value==null) this["identificativo_sdi"]= DBNull.Value; else this["identificativo_sdi"]= value;}
	}
	public object identificativo_sdiValue { 
		get{ return this["identificativo_sdi"];}
		set {if (value==null|| value==DBNull.Value) this["identificativo_sdi"]= DBNull.Value; else this["identificativo_sdi"]= value;}
	}
	public Int32? identificativo_sdiOriginal { 
		get {if (this["identificativo_sdi",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["identificativo_sdi",DataRowVersion.Original];}
	}
	///<summary>
	///Notifica di scarto (file xml)
	///</summary>
	public String ns{ 
		get {if (this["ns"]==DBNull.Value)return null; return  (String)this["ns"];}
		set {if (value==null) this["ns"]= DBNull.Value; else this["ns"]= value;}
	}
	public object nsValue { 
		get{ return this["ns"];}
		set {if (value==null|| value==DBNull.Value) this["ns"]= DBNull.Value; else this["ns"]= value;}
	}
	public String nsOriginal { 
		get {if (this["ns",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ns",DataRowVersion.Original];}
	}
	///<summary>
	///Notifica di mancata consegna (file xml)
	///</summary>
	public String mc{ 
		get {if (this["mc"]==DBNull.Value)return null; return  (String)this["mc"];}
		set {if (value==null) this["mc"]= DBNull.Value; else this["mc"]= value;}
	}
	public object mcValue { 
		get{ return this["mc"];}
		set {if (value==null|| value==DBNull.Value) this["mc"]= DBNull.Value; else this["mc"]= value;}
	}
	public String mcOriginal { 
		get {if (this["mc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mc",DataRowVersion.Original];}
	}
	///<summary>
	///Ricevuta consegna (file xml)
	///</summary>
	public String rc{ 
		get {if (this["rc"]==DBNull.Value)return null; return  (String)this["rc"];}
		set {if (value==null) this["rc"]= DBNull.Value; else this["rc"]= value;}
	}
	public object rcValue { 
		get{ return this["rc"];}
		set {if (value==null|| value==DBNull.Value) this["rc"]= DBNull.Value; else this["rc"]= value;}
	}
	public String rcOriginal { 
		get {if (this["rc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rc",DataRowVersion.Original];}
	}
	///<summary>
	///Notifica esito cedente (file xml)
	///</summary>
	public String ne{ 
		get {if (this["ne"]==DBNull.Value)return null; return  (String)this["ne"];}
		set {if (value==null) this["ne"]= DBNull.Value; else this["ne"]= value;}
	}
	public object neValue { 
		get{ return this["ne"];}
		set {if (value==null|| value==DBNull.Value) this["ne"]= DBNull.Value; else this["ne"]= value;}
	}
	public String neOriginal { 
		get {if (this["ne",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ne",DataRowVersion.Original];}
	}
	///<summary>
	///Notifica decorrenza termini (file xml)
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
	///Attestazione di avvenuta trasmissione della fattura al SdI con impossibilità di recapito (file xml)
	///</summary>
	public String at{ 
		get {if (this["at"]==DBNull.Value)return null; return  (String)this["at"];}
		set {if (value==null) this["at"]= DBNull.Value; else this["at"]= value;}
	}
	public object atValue { 
		get{ return this["at"];}
		set {if (value==null|| value==DBNull.Value) this["at"]= DBNull.Value; else this["at"]= value;}
	}
	public String atOriginal { 
		get {if (this["at",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["at",DataRowVersion.Original];}
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
	///</summary>
	public Int16? idsdi_status{ 
		get {if (this["idsdi_status"]==DBNull.Value)return null; return  (Int16?)this["idsdi_status"];}
		set {if (value==null) this["idsdi_status"]= DBNull.Value; else this["idsdi_status"]= value;}
	}
	public object idsdi_statusValue { 
		get{ return this["idsdi_status"];}
		set {if (value==null|| value==DBNull.Value) this["idsdi_status"]= DBNull.Value; else this["idsdi_status"]= value;}
	}
	public Int16? idsdi_statusOriginal { 
		get {if (this["idsdi_status",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["idsdi_status",DataRowVersion.Original];}
	}
	///<summary>
	///ID Stato trasmissione SDI (tabella sdi_deliverystatus)
	///</summary>
	public Int16? idsdi_deliverystatus{ 
		get {if (this["idsdi_deliverystatus"]==DBNull.Value)return null; return  (Int16?)this["idsdi_deliverystatus"];}
		set {if (value==null) this["idsdi_deliverystatus"]= DBNull.Value; else this["idsdi_deliverystatus"]= value;}
	}
	public object idsdi_deliverystatusValue { 
		get{ return this["idsdi_deliverystatus"];}
		set {if (value==null|| value==DBNull.Value) this["idsdi_deliverystatus"]= DBNull.Value; else this["idsdi_deliverystatus"]= value;}
	}
	public Int16? idsdi_deliverystatusOriginal { 
		get {if (this["idsdi_deliverystatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["idsdi_deliverystatus",DataRowVersion.Original];}
	}
	///<summary>
	///Posizione
	///</summary>
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
	///<summary>
	///Inviata all'SDI
	///	 N: Non è vero che: "Inviata all'SDI"
	///	 S: Inviata all'SDI
	///</summary>
	public String exported{ 
		get {if (this["exported"]==DBNull.Value)return null; return  (String)this["exported"];}
		set {if (value==null) this["exported"]= DBNull.Value; else this["exported"]= value;}
	}
	public object exportedValue { 
		get{ return this["exported"];}
		set {if (value==null|| value==DBNull.Value) this["exported"]= DBNull.Value; else this["exported"]= value;}
	}
	public String exportedOriginal { 
		get {if (this["exported",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["exported",DataRowVersion.Original];}
	}
	///<summary>
	///Nome File Compresso
	///</summary>
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
	///<summary>
	///Data protocollo
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
	///protocollo Notifica di scarto
	///</summary>
	public String ns_prot{ 
		get {if (this["ns_prot"]==DBNull.Value)return null; return  (String)this["ns_prot"];}
		set {if (value==null) this["ns_prot"]= DBNull.Value; else this["ns_prot"]= value;}
	}
	public object ns_protValue { 
		get{ return this["ns_prot"];}
		set {if (value==null|| value==DBNull.Value) this["ns_prot"]= DBNull.Value; else this["ns_prot"]= value;}
	}
	public String ns_protOriginal { 
		get {if (this["ns_prot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ns_prot",DataRowVersion.Original];}
	}
	///<summary>
	///protocollo Notifica di mancata consegna
	///</summary>
	public String mc_prot{ 
		get {if (this["mc_prot"]==DBNull.Value)return null; return  (String)this["mc_prot"];}
		set {if (value==null) this["mc_prot"]= DBNull.Value; else this["mc_prot"]= value;}
	}
	public object mc_protValue { 
		get{ return this["mc_prot"];}
		set {if (value==null|| value==DBNull.Value) this["mc_prot"]= DBNull.Value; else this["mc_prot"]= value;}
	}
	public String mc_protOriginal { 
		get {if (this["mc_prot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mc_prot",DataRowVersion.Original];}
	}
	///<summary>
	///protocollo Ricevuta consegna
	///</summary>
	public String rc_prot{ 
		get {if (this["rc_prot"]==DBNull.Value)return null; return  (String)this["rc_prot"];}
		set {if (value==null) this["rc_prot"]= DBNull.Value; else this["rc_prot"]= value;}
	}
	public object rc_protValue { 
		get{ return this["rc_prot"];}
		set {if (value==null|| value==DBNull.Value) this["rc_prot"]= DBNull.Value; else this["rc_prot"]= value;}
	}
	public String rc_protOriginal { 
		get {if (this["rc_prot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rc_prot",DataRowVersion.Original];}
	}
	///<summary>
	///protocollo Notifica esito cedente
	///</summary>
	public String ne_prot{ 
		get {if (this["ne_prot"]==DBNull.Value)return null; return  (String)this["ne_prot"];}
		set {if (value==null) this["ne_prot"]= DBNull.Value; else this["ne_prot"]= value;}
	}
	public object ne_protValue { 
		get{ return this["ne_prot"];}
		set {if (value==null|| value==DBNull.Value) this["ne_prot"]= DBNull.Value; else this["ne_prot"]= value;}
	}
	public String ne_protOriginal { 
		get {if (this["ne_prot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ne_prot",DataRowVersion.Original];}
	}
	///<summary>
	///protocollo Notifica decorrenza termini
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
	///N. protocollo Attestazione di avvenuta trasmissione della fattura al SdI con impossibilità di recapito
	///</summary>
	public String at_prot{ 
		get {if (this["at_prot"]==DBNull.Value)return null; return  (String)this["at_prot"];}
		set {if (value==null) this["at_prot"]= DBNull.Value; else this["at_prot"]= value;}
	}
	public object at_protValue { 
		get{ return this["at_prot"];}
		set {if (value==null|| value==DBNull.Value) this["at_prot"]= DBNull.Value; else this["at_prot"]= value;}
	}
	public String at_protOriginal { 
		get {if (this["at_prot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["at_prot",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA
	///</summary>
	public String ipa_fe{ 
		get {if (this["ipa_fe"]==DBNull.Value)return null; return  (String)this["ipa_fe"];}
		set {if (value==null) this["ipa_fe"]= DBNull.Value; else this["ipa_fe"]= value;}
	}
	public object ipa_feValue { 
		get{ return this["ipa_fe"];}
		set {if (value==null|| value==DBNull.Value) this["ipa_fe"]= DBNull.Value; else this["ipa_fe"]= value;}
	}
	public String ipa_feOriginal { 
		get {if (this["ipa_fe",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ipa_fe",DataRowVersion.Original];}
	}
	///<summary>
	///ID Riferimento amministrazione (tabella sdi_rifamm)
	///</summary>
	public String idsdi_rifamm{ 
		get {if (this["idsdi_rifamm"]==DBNull.Value)return null; return  (String)this["idsdi_rifamm"];}
		set {if (value==null) this["idsdi_rifamm"]= DBNull.Value; else this["idsdi_rifamm"]= value;}
	}
	public object idsdi_rifammValue { 
		get{ return this["idsdi_rifamm"];}
		set {if (value==null|| value==DBNull.Value) this["idsdi_rifamm"]= DBNull.Value; else this["idsdi_rifamm"]= value;}
	}
	public String idsdi_rifammOriginal { 
		get {if (this["idsdi_rifamm",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idsdi_rifamm",DataRowVersion.Original];}
	}
	///<summary>
	///Errore ricevuto in fase di protocollazione
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
	///file firmato
	///</summary>
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
	///<summary>
	///nome del file firmato
	///</summary>
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
	///<summary>
	///Firmata
	///	 N: Non è vero che: "Firmata"
	///	 S: Firmata
	///</summary>
	public String issigned{ 
		get {if (this["issigned"]==DBNull.Value)return null; return  (String)this["issigned"];}
		set {if (value==null) this["issigned"]= DBNull.Value; else this["issigned"]= value;}
	}
	public object issignedValue { 
		get{ return this["issigned"];}
		set {if (value==null|| value==DBNull.Value) this["issigned"]= DBNull.Value; else this["issigned"]= value;}
	}
	public String issignedOriginal { 
		get {if (this["issigned",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["issigned",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Fatture di vendita selezionate per la trasmissione
///</summary>
public class sdi_venditaTable : MetaTableBase<sdi_venditaRow> {
	public sdi_venditaTable() : base("sdi_vendita"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idsdi_vendita")){ 
			defineColumn("idsdi_vendita", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("filename")){ 
			defineColumn("filename", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("xml")){ 
			defineColumn("xml", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("identificativo_sdi")){ 
			defineColumn("identificativo_sdi", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("ns")){ 
			defineColumn("ns", typeof(System.String));
		}
		if (definedColums.ContainsKey("mc")){ 
			defineColumn("mc", typeof(System.String));
		}
		if (definedColums.ContainsKey("rc")){ 
			defineColumn("rc", typeof(System.String));
		}
		if (definedColums.ContainsKey("ne")){ 
			defineColumn("ne", typeof(System.String));
		}
		if (definedColums.ContainsKey("dt")){ 
			defineColumn("dt", typeof(System.String));
		}
		if (definedColums.ContainsKey("at")){ 
			defineColumn("at", typeof(System.String));
		}
		if (definedColums.ContainsKey("flag_unseen")){ 
			defineColumn("flag_unseen", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsdi_status")){ 
			defineColumn("idsdi_status", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("idsdi_deliverystatus")){ 
			defineColumn("idsdi_deliverystatus", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("position")){ 
			defineColumn("position", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("exported")){ 
			defineColumn("exported", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("zipfilename")){ 
			defineColumn("zipfilename", typeof(System.String));
		}
		if (definedColums.ContainsKey("arrivalprotocolnum")){ 
			defineColumn("arrivalprotocolnum", typeof(System.String));
		}
		if (definedColums.ContainsKey("ns_prot")){ 
			defineColumn("ns_prot", typeof(System.String));
		}
		if (definedColums.ContainsKey("mc_prot")){ 
			defineColumn("mc_prot", typeof(System.String));
		}
		if (definedColums.ContainsKey("rc_prot")){ 
			defineColumn("rc_prot", typeof(System.String));
		}
		if (definedColums.ContainsKey("ne_prot")){ 
			defineColumn("ne_prot", typeof(System.String));
		}
		if (definedColums.ContainsKey("dt_prot")){ 
			defineColumn("dt_prot", typeof(System.String));
		}
		if (definedColums.ContainsKey("at_prot")){ 
			defineColumn("at_prot", typeof(System.String));
		}
		if (definedColums.ContainsKey("ipa_fe")){ 
			defineColumn("ipa_fe", typeof(System.String));
		}
		if (definedColums.ContainsKey("idsdi_rifamm")){ 
			defineColumn("idsdi_rifamm", typeof(System.String));
		}
		if (definedColums.ContainsKey("protocol_error")){ 
			defineColumn("protocol_error", typeof(System.String));
		}
		if (definedColums.ContainsKey("signedxml")){ 
			defineColumn("signedxml", typeof(System.String));
		}
		if (definedColums.ContainsKey("signedxmlfilename")){ 
			defineColumn("signedxmlfilename", typeof(System.String));
		}
		if (definedColums.ContainsKey("issigned")){ 
			defineColumn("issigned", typeof(System.String));
		}
		#endregion

	}
}
}
