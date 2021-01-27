
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
namespace meta_mandate {
public class mandateRow: MetaRow  {
	public mandateRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id tipo contratto (tabella mandatekind)
	///</summary>
	public String idmankind{ 
		get {if (this["idmankind"]==DBNull.Value)return null; return  (String)this["idmankind"];}
		set {if (value==null) this["idmankind"]= DBNull.Value; else this["idmankind"]= value;}
	}
	public object idmankindValue { 
		get{ return this["idmankind"];}
		set {if (value==null|| value==DBNull.Value) this["idmankind"]= DBNull.Value; else this["idmankind"]= value;}
	}
	public String idmankindOriginal { 
		get {if (this["idmankind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idmankind",DataRowVersion.Original];}
	}
	///<summary>
	///n.contratto
	///</summary>
	public Int32? nman{ 
		get {if (this["nman"]==DBNull.Value)return null; return  (Int32?)this["nman"];}
		set {if (value==null) this["nman"]= DBNull.Value; else this["nman"]= value;}
	}
	public object nmanValue { 
		get{ return this["nman"];}
		set {if (value==null|| value==DBNull.Value) this["nman"]= DBNull.Value; else this["nman"]= value;}
	}
	public Int32? nmanOriginal { 
		get {if (this["nman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nman",DataRowVersion.Original];}
	}
	///<summary>
	///anno contratto
	///</summary>
	public Int16? yman{ 
		get {if (this["yman"]==DBNull.Value)return null; return  (Int16?)this["yman"];}
		set {if (value==null) this["yman"]= DBNull.Value; else this["yman"]= value;}
	}
	public object ymanValue { 
		get{ return this["yman"];}
		set {if (value==null|| value==DBNull.Value) this["yman"]= DBNull.Value; else this["yman"]= value;}
	}
	public Int16? ymanOriginal { 
		get {if (this["yman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yman",DataRowVersion.Original];}
	}
	///<summary>
	///attivo
	///</summary>
	public String active{ 
		get {if (this["active"]==DBNull.Value)return null; return  (String)this["active"];}
		set {if (value==null) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {if (value==null|| value==DBNull.Value) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public String activeOriginal { 
		get {if (this["active",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["active",DataRowVersion.Original];}
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
	///data creazione
	///</summary>
	public DateTime? ct{ 
		get {if (this["ct"]==DBNull.Value)return null; return  (DateTime?)this["ct"];}
		set {if (value==null) this["ct"]= DBNull.Value; else this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {if (value==null|| value==DBNull.Value) this["ct"]= DBNull.Value; else this["ct"]= value;}
	}
	public DateTime? ctOriginal { 
		get {if (this["ct",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["ct",DataRowVersion.Original];}
	}
	///<summary>
	///nome utente creazione
	///</summary>
	public String cu{ 
		get {if (this["cu"]==DBNull.Value)return null; return  (String)this["cu"];}
		set {if (value==null) this["cu"]= DBNull.Value; else this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {if (value==null|| value==DBNull.Value) this["cu"]= DBNull.Value; else this["cu"]= value;}
	}
	public String cuOriginal { 
		get {if (this["cu",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cu",DataRowVersion.Original];}
	}
	///<summary>
	///Ind. cons.
	///</summary>
	public String deliveryaddress{ 
		get {if (this["deliveryaddress"]==DBNull.Value)return null; return  (String)this["deliveryaddress"];}
		set {if (value==null) this["deliveryaddress"]= DBNull.Value; else this["deliveryaddress"]= value;}
	}
	public object deliveryaddressValue { 
		get{ return this["deliveryaddress"];}
		set {if (value==null|| value==DBNull.Value) this["deliveryaddress"]= DBNull.Value; else this["deliveryaddress"]= value;}
	}
	public String deliveryaddressOriginal { 
		get {if (this["deliveryaddress",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["deliveryaddress",DataRowVersion.Original];}
	}
	///<summary>
	///Term. cons.
	///</summary>
	public String deliveryexpiration{ 
		get {if (this["deliveryexpiration"]==DBNull.Value)return null; return  (String)this["deliveryexpiration"];}
		set {if (value==null) this["deliveryexpiration"]= DBNull.Value; else this["deliveryexpiration"]= value;}
	}
	public object deliveryexpirationValue { 
		get{ return this["deliveryexpiration"];}
		set {if (value==null|| value==DBNull.Value) this["deliveryexpiration"]= DBNull.Value; else this["deliveryexpiration"]= value;}
	}
	public String deliveryexpirationOriginal { 
		get {if (this["deliveryexpiration",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["deliveryexpiration",DataRowVersion.Original];}
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
	///documento
	///</summary>
	public String doc{ 
		get {if (this["doc"]==DBNull.Value)return null; return  (String)this["doc"];}
		set {if (value==null) this["doc"]= DBNull.Value; else this["doc"]= value;}
	}
	public object docValue { 
		get{ return this["doc"];}
		set {if (value==null|| value==DBNull.Value) this["doc"]= DBNull.Value; else this["doc"]= value;}
	}
	public String docOriginal { 
		get {if (this["doc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["doc",DataRowVersion.Original];}
	}
	///<summary>
	///data documento
	///</summary>
	public DateTime? docdate{ 
		get {if (this["docdate"]==DBNull.Value)return null; return  (DateTime?)this["docdate"];}
		set {if (value==null) this["docdate"]= DBNull.Value; else this["docdate"]= value;}
	}
	public object docdateValue { 
		get{ return this["docdate"];}
		set {if (value==null|| value==DBNull.Value) this["docdate"]= DBNull.Value; else this["docdate"]= value;}
	}
	public DateTime? docdateOriginal { 
		get {if (this["docdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["docdate",DataRowVersion.Original];}
	}
	///<summary>
	///Tasso di cambio
	///</summary>
	public Double? exchangerate{ 
		get {if (this["exchangerate"]==DBNull.Value)return null; return  (Double?)this["exchangerate"];}
		set {if (value==null) this["exchangerate"]= DBNull.Value; else this["exchangerate"]= value;}
	}
	public object exchangerateValue { 
		get{ return this["exchangerate"];}
		set {if (value==null|| value==DBNull.Value) this["exchangerate"]= DBNull.Value; else this["exchangerate"]= value;}
	}
	public Double? exchangerateOriginal { 
		get {if (this["exchangerate",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["exchangerate",DataRowVersion.Original];}
	}
	///<summary>
	///id anagrafica (tabella registry)
	///</summary>
	public Int32? idreg{ 
		get {if (this["idreg"]==DBNull.Value)return null; return  (Int32?)this["idreg"];}
		set {if (value==null) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public object idregValue { 
		get{ return this["idreg"];}
		set {if (value==null|| value==DBNull.Value) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public Int32? idregOriginal { 
		get {if (this["idreg",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg",DataRowVersion.Original];}
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
	///Flag stampa
	///</summary>
	public String officiallyprinted{ 
		get {if (this["officiallyprinted"]==DBNull.Value)return null; return  (String)this["officiallyprinted"];}
		set {if (value==null) this["officiallyprinted"]= DBNull.Value; else this["officiallyprinted"]= value;}
	}
	public object officiallyprintedValue { 
		get{ return this["officiallyprinted"];}
		set {if (value==null|| value==DBNull.Value) this["officiallyprinted"]= DBNull.Value; else this["officiallyprinted"]= value;}
	}
	public String officiallyprintedOriginal { 
		get {if (this["officiallyprinted",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["officiallyprinted",DataRowVersion.Original];}
	}
	///<summary>
	///N. giorni scadenza
	///</summary>
	public Int16? paymentexpiring{ 
		get {if (this["paymentexpiring"]==DBNull.Value)return null; return  (Int16?)this["paymentexpiring"];}
		set {if (value==null) this["paymentexpiring"]= DBNull.Value; else this["paymentexpiring"]= value;}
	}
	public object paymentexpiringValue { 
		get{ return this["paymentexpiring"];}
		set {if (value==null|| value==DBNull.Value) this["paymentexpiring"]= DBNull.Value; else this["paymentexpiring"]= value;}
	}
	public Int16? paymentexpiringOriginal { 
		get {if (this["paymentexpiring",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["paymentexpiring",DataRowVersion.Original];}
	}
	///<summary>
	///Rif. fornit.
	///</summary>
	public String registryreference{ 
		get {if (this["registryreference"]==DBNull.Value)return null; return  (String)this["registryreference"];}
		set {if (value==null) this["registryreference"]= DBNull.Value; else this["registryreference"]= value;}
	}
	public object registryreferenceValue { 
		get{ return this["registryreference"];}
		set {if (value==null|| value==DBNull.Value) this["registryreference"]= DBNull.Value; else this["registryreference"]= value;}
	}
	public String registryreferenceOriginal { 
		get {if (this["registryreference",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["registryreference",DataRowVersion.Original];}
	}
	///<summary>
	///allegati
	///</summary>
	public Byte[] rtf{ 
		get {if (this["rtf"]==DBNull.Value)return null; return  (Byte[])this["rtf"];}
		set {if (value==null) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public object rtfValue { 
		get{ return this["rtf"];}
		set {if (value==null|| value==DBNull.Value) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public Byte[] rtfOriginal { 
		get {if (this["rtf",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte[])this["rtf",DataRowVersion.Original];}
	}
	///<summary>
	///note testuali
	///</summary>
	public String txt{ 
		get {if (this["txt"]==DBNull.Value)return null; return  (String)this["txt"];}
		set {if (value==null) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public object txtValue { 
		get{ return this["txt"];}
		set {if (value==null|| value==DBNull.Value) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public String txtOriginal { 
		get {if (this["txt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["txt",DataRowVersion.Original];}
	}
	///<summary>
	///id responsabile (tabella manager)
	///</summary>
	public Int32? idman{ 
		get {if (this["idman"]==DBNull.Value)return null; return  (Int32?)this["idman"];}
		set {if (value==null) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public object idmanValue { 
		get{ return this["idman"];}
		set {if (value==null|| value==DBNull.Value) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public Int32? idmanOriginal { 
		get {if (this["idman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idman",DataRowVersion.Original];}
	}
	///<summary>
	///Chiave valuta (tab. currency)
	///</summary>
	public Int32? idcurrency{ 
		get {if (this["idcurrency"]==DBNull.Value)return null; return  (Int32?)this["idcurrency"];}
		set {if (value==null) this["idcurrency"]= DBNull.Value; else this["idcurrency"]= value;}
	}
	public object idcurrencyValue { 
		get{ return this["idcurrency"];}
		set {if (value==null|| value==DBNull.Value) this["idcurrency"]= DBNull.Value; else this["idcurrency"]= value;}
	}
	public Int32? idcurrencyOriginal { 
		get {if (this["idcurrency",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcurrency",DataRowVersion.Original];}
	}
	///<summary>
	///id tipo scadenza (tabella expirationkind)
	///</summary>
	public Int16? idexpirationkind{ 
		get {if (this["idexpirationkind"]==DBNull.Value)return null; return  (Int16?)this["idexpirationkind"];}
		set {if (value==null) this["idexpirationkind"]= DBNull.Value; else this["idexpirationkind"]= value;}
	}
	public object idexpirationkindValue { 
		get{ return this["idexpirationkind"];}
		set {if (value==null|| value==DBNull.Value) this["idexpirationkind"]= DBNull.Value; else this["idexpirationkind"]= value;}
	}
	public Int16? idexpirationkindOriginal { 
		get {if (this["idexpirationkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["idexpirationkind",DataRowVersion.Original];}
	}
	///<summary>
	///Flag intracom (S/N/X)
	///	 N: Contratto in Italia
	///	 S: Contratto Intracom.
	///	 X: Contratto Extra-UE
	///</summary>
	public String flagintracom{ 
		get {if (this["flagintracom"]==DBNull.Value)return null; return  (String)this["flagintracom"];}
		set {if (value==null) this["flagintracom"]= DBNull.Value; else this["flagintracom"]= value;}
	}
	public object flagintracomValue { 
		get{ return this["flagintracom"];}
		set {if (value==null|| value==DBNull.Value) this["flagintracom"]= DBNull.Value; else this["flagintracom"]= value;}
	}
	public String flagintracomOriginal { 
		get {if (this["flagintracom",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagintracom",DataRowVersion.Original];}
	}
	///<summary>
	///Id della causale di debito (tabella accmotive) 
	///</summary>
	public String idaccmotivedebit{ 
		get {if (this["idaccmotivedebit"]==DBNull.Value)return null; return  (String)this["idaccmotivedebit"];}
		set {if (value==null) this["idaccmotivedebit"]= DBNull.Value; else this["idaccmotivedebit"]= value;}
	}
	public object idaccmotivedebitValue { 
		get{ return this["idaccmotivedebit"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivedebit"]= DBNull.Value; else this["idaccmotivedebit"]= value;}
	}
	public String idaccmotivedebitOriginal { 
		get {if (this["idaccmotivedebit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivedebit",DataRowVersion.Original];}
	}
	///<summary>
	///Id causale di debito - correzione (tabella accmotive)
	///</summary>
	public String idaccmotivedebit_crg{ 
		get {if (this["idaccmotivedebit_crg"]==DBNull.Value)return null; return  (String)this["idaccmotivedebit_crg"];}
		set {if (value==null) this["idaccmotivedebit_crg"]= DBNull.Value; else this["idaccmotivedebit_crg"]= value;}
	}
	public object idaccmotivedebit_crgValue { 
		get{ return this["idaccmotivedebit_crg"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivedebit_crg"]= DBNull.Value; else this["idaccmotivedebit_crg"]= value;}
	}
	public String idaccmotivedebit_crgOriginal { 
		get {if (this["idaccmotivedebit_crg",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivedebit_crg",DataRowVersion.Original];}
	}
	///<summary>
	///Data correzione causale di debito
	///</summary>
	public DateTime? idaccmotivedebit_datacrg{ 
		get {if (this["idaccmotivedebit_datacrg"]==DBNull.Value)return null; return  (DateTime?)this["idaccmotivedebit_datacrg"];}
		set {if (value==null) this["idaccmotivedebit_datacrg"]= DBNull.Value; else this["idaccmotivedebit_datacrg"]= value;}
	}
	public object idaccmotivedebit_datacrgValue { 
		get{ return this["idaccmotivedebit_datacrg"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivedebit_datacrg"]= DBNull.Value; else this["idaccmotivedebit_datacrg"]= value;}
	}
	public DateTime? idaccmotivedebit_datacrgOriginal { 
		get {if (this["idaccmotivedebit_datacrg",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["idaccmotivedebit_datacrg",DataRowVersion.Original];}
	}
	///<summary>
	///Note del Richiedente
	///</summary>
	public String applierannotations{ 
		get {if (this["applierannotations"]==DBNull.Value)return null; return  (String)this["applierannotations"];}
		set {if (value==null) this["applierannotations"]= DBNull.Value; else this["applierannotations"]= value;}
	}
	public object applierannotationsValue { 
		get{ return this["applierannotations"];}
		set {if (value==null|| value==DBNull.Value) this["applierannotations"]= DBNull.Value; else this["applierannotations"]= value;}
	}
	public String applierannotationsOriginal { 
		get {if (this["applierannotations",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["applierannotations",DataRowVersion.Original];}
	}
	///<summary>
	///Id stato contratto (tabella mandatestatus)
	///</summary>
	public Int16? idmandatestatus{ 
		get {if (this["idmandatestatus"]==DBNull.Value)return null; return  (Int16?)this["idmandatestatus"];}
		set {if (value==null) this["idmandatestatus"]= DBNull.Value; else this["idmandatestatus"]= value;}
	}
	public object idmandatestatusValue { 
		get{ return this["idmandatestatus"];}
		set {if (value==null|| value==DBNull.Value) this["idmandatestatus"]= DBNull.Value; else this["idmandatestatus"]= value;}
	}
	public Int16? idmandatestatusOriginal { 
		get {if (this["idmandatestatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["idmandatestatus",DataRowVersion.Original];}
	}
	///<summary>
	///Chiave magazzino (tabella store)
	///</summary>
	public Int32? idstore{ 
		get {if (this["idstore"]==DBNull.Value)return null; return  (Int32?)this["idstore"];}
		set {if (value==null) this["idstore"]= DBNull.Value; else this["idstore"]= value;}
	}
	public object idstoreValue { 
		get{ return this["idstore"];}
		set {if (value==null|| value==DBNull.Value) this["idstore"]= DBNull.Value; else this["idstore"]= value;}
	}
	public Int32? idstoreOriginal { 
		get {if (this["idstore",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstore",DataRowVersion.Original];}
	}
	///<summary>
	///Codice CIG
	///</summary>
	public String cigcode{ 
		get {if (this["cigcode"]==DBNull.Value)return null; return  (String)this["cigcode"];}
		set {if (value==null) this["cigcode"]= DBNull.Value; else this["cigcode"]= value;}
	}
	public object cigcodeValue { 
		get{ return this["cigcode"];}
		set {if (value==null|| value==DBNull.Value) this["cigcode"]= DBNull.Value; else this["cigcode"]= value;}
	}
	public String cigcodeOriginal { 
		get {if (this["cigcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cigcode",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 1(tabella sorting)
	///</summary>
	public Int32? idsor01{ 
		get {if (this["idsor01"]==DBNull.Value)return null; return  (Int32?)this["idsor01"];}
		set {if (value==null) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public object idsor01Value { 
		get{ return this["idsor01"];}
		set {if (value==null|| value==DBNull.Value) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public Int32? idsor01Original { 
		get {if (this["idsor01",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor01",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 2(tabella sorting)
	///</summary>
	public Int32? idsor02{ 
		get {if (this["idsor02"]==DBNull.Value)return null; return  (Int32?)this["idsor02"];}
		set {if (value==null) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public object idsor02Value { 
		get{ return this["idsor02"];}
		set {if (value==null|| value==DBNull.Value) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public Int32? idsor02Original { 
		get {if (this["idsor02",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor02",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 3(tabella sorting)
	///</summary>
	public Int32? idsor03{ 
		get {if (this["idsor03"]==DBNull.Value)return null; return  (Int32?)this["idsor03"];}
		set {if (value==null) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public object idsor03Value { 
		get{ return this["idsor03"];}
		set {if (value==null|| value==DBNull.Value) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public Int32? idsor03Original { 
		get {if (this["idsor03",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor03",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 4(tabella sorting)
	///</summary>
	public Int32? idsor04{ 
		get {if (this["idsor04"]==DBNull.Value)return null; return  (Int32?)this["idsor04"];}
		set {if (value==null) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public object idsor04Value { 
		get{ return this["idsor04"];}
		set {if (value==null|| value==DBNull.Value) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public Int32? idsor04Original { 
		get {if (this["idsor04",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor04",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 5(tabella sorting)
	///</summary>
	public Int32? idsor05{ 
		get {if (this["idsor05"]==DBNull.Value)return null; return  (Int32?)this["idsor05"];}
		set {if (value==null) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public object idsor05Value { 
		get{ return this["idsor05"];}
		set {if (value==null|| value==DBNull.Value) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public Int32? idsor05Original { 
		get {if (this["idsor05",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor05",DataRowVersion.Original];}
	}
	///<summary>
	///ID Dichiarazione ai fini CONSIP (tabella consipkind)
	///</summary>
	public Int32? idconsipkind{ 
		get {if (this["idconsipkind"]==DBNull.Value)return null; return  (Int32?)this["idconsipkind"];}
		set {if (value==null) this["idconsipkind"]= DBNull.Value; else this["idconsipkind"]= value;}
	}
	public object idconsipkindValue { 
		get{ return this["idconsipkind"];}
		set {if (value==null|| value==DBNull.Value) this["idconsipkind"]= DBNull.Value; else this["idconsipkind"]= value;}
	}
	public Int32? idconsipkindOriginal { 
		get {if (this["idconsipkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idconsipkind",DataRowVersion.Original];}
	}
	///<summary>
	///Materiale pericoloso
	///	 N: Non è materiale pericoloso
	///	 S: Materiale pericoloso
	///</summary>
	public String flagdanger{ 
		get {if (this["flagdanger"]==DBNull.Value)return null; return  (String)this["flagdanger"];}
		set {if (value==null) this["flagdanger"]= DBNull.Value; else this["flagdanger"]= value;}
	}
	public object flagdangerValue { 
		get{ return this["flagdanger"];}
		set {if (value==null|| value==DBNull.Value) this["flagdanger"]= DBNull.Value; else this["flagdanger"]= value;}
	}
	public String flagdangerOriginal { 
		get {if (this["flagdanger",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagdanger",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo richiesta contratto passivo che ha originato questo contratto (tabella idmankind di mandatekind)
	///</summary>
	public String idmankind_origin{ 
		get {if (this["idmankind_origin"]==DBNull.Value)return null; return  (String)this["idmankind_origin"];}
		set {if (value==null) this["idmankind_origin"]= DBNull.Value; else this["idmankind_origin"]= value;}
	}
	public object idmankind_originValue { 
		get{ return this["idmankind_origin"];}
		set {if (value==null|| value==DBNull.Value) this["idmankind_origin"]= DBNull.Value; else this["idmankind_origin"]= value;}
	}
	public String idmankind_originOriginal { 
		get {if (this["idmankind_origin",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idmankind_origin",DataRowVersion.Original];}
	}
	///<summary>
	///Numero richiesta che ha originato questo contratto
	///</summary>
	public Int32? nman_origin{ 
		get {if (this["nman_origin"]==DBNull.Value)return null; return  (Int32?)this["nman_origin"];}
		set {if (value==null) this["nman_origin"]= DBNull.Value; else this["nman_origin"]= value;}
	}
	public object nman_originValue { 
		get{ return this["nman_origin"];}
		set {if (value==null|| value==DBNull.Value) this["nman_origin"]= DBNull.Value; else this["nman_origin"]= value;}
	}
	public Int32? nman_originOriginal { 
		get {if (this["nman_origin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nman_origin",DataRowVersion.Original];}
	}
	///<summary>
	///Anno richiesta che ha originato questo contratto
	///</summary>
	public Int16? yman_origin{ 
		get {if (this["yman_origin"]==DBNull.Value)return null; return  (Int16?)this["yman_origin"];}
		set {if (value==null) this["yman_origin"]= DBNull.Value; else this["yman_origin"]= value;}
	}
	public object yman_originValue { 
		get{ return this["yman_origin"];}
		set {if (value==null|| value==DBNull.Value) this["yman_origin"]= DBNull.Value; else this["yman_origin"]= value;}
	}
	public Int16? yman_originOriginal { 
		get {if (this["yman_origin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yman_origin",DataRowVersion.Original];}
	}
	///<summary>
	///Prenotazione
	///</summary>
	public String subappropriation{ 
		get {if (this["subappropriation"]==DBNull.Value)return null; return  (String)this["subappropriation"];}
		set {if (value==null) this["subappropriation"]= DBNull.Value; else this["subappropriation"]= value;}
	}
	public object subappropriationValue { 
		get{ return this["subappropriation"];}
		set {if (value==null|| value==DBNull.Value) this["subappropriation"]= DBNull.Value; else this["subappropriation"]= value;}
	}
	public String subappropriationOriginal { 
		get {if (this["subappropriation",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["subappropriation",DataRowVersion.Original];}
	}
	///<summary>
	///Imputazione
	///</summary>
	public String finsubappropriation{ 
		get {if (this["finsubappropriation"]==DBNull.Value)return null; return  (String)this["finsubappropriation"];}
		set {if (value==null) this["finsubappropriation"]= DBNull.Value; else this["finsubappropriation"]= value;}
	}
	public object finsubappropriationValue { 
		get{ return this["finsubappropriation"];}
		set {if (value==null|| value==DBNull.Value) this["finsubappropriation"]= DBNull.Value; else this["finsubappropriation"]= value;}
	}
	public String finsubappropriationOriginal { 
		get {if (this["finsubappropriation",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["finsubappropriation",DataRowVersion.Original];}
	}
	///<summary>
	///Data Imputazione
	///</summary>
	public DateTime? adatesubappropriation{ 
		get {if (this["adatesubappropriation"]==DBNull.Value)return null; return  (DateTime?)this["adatesubappropriation"];}
		set {if (value==null) this["adatesubappropriation"]= DBNull.Value; else this["adatesubappropriation"]= value;}
	}
	public object adatesubappropriationValue { 
		get{ return this["adatesubappropriation"];}
		set {if (value==null|| value==DBNull.Value) this["adatesubappropriation"]= DBNull.Value; else this["adatesubappropriation"]= value;}
	}
	public DateTime? adatesubappropriationOriginal { 
		get {if (this["adatesubappropriation",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["adatesubappropriation",DataRowVersion.Original];}
	}
	///<summary>
	///Numero protocollo di entrata (registro unico)
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
	///Data ricezione documento (registro unico)
	///</summary>
	public DateTime? arrivaldate{ 
		get {if (this["arrivaldate"]==DBNull.Value)return null; return  (DateTime?)this["arrivaldate"];}
		set {if (value==null) this["arrivaldate"]= DBNull.Value; else this["arrivaldate"]= value;}
	}
	public object arrivaldateValue { 
		get{ return this["arrivaldate"];}
		set {if (value==null|| value==DBNull.Value) this["arrivaldate"]= DBNull.Value; else this["arrivaldate"]= value;}
	}
	public DateTime? arrivaldateOriginal { 
		get {if (this["arrivaldate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["arrivaldate",DataRowVersion.Original];}
	}
	///<summary>
	///Annotazioni (registro unico)
	///</summary>
	public String annotations{ 
		get {if (this["annotations"]==DBNull.Value)return null; return  (String)this["annotations"];}
		set {if (value==null) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public object annotationsValue { 
		get{ return this["annotations"];}
		set {if (value==null|| value==DBNull.Value) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public String annotationsOriginal { 
		get {if (this["annotations",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["annotations",DataRowVersion.Original];}
	}
	///<summary>
	///Ritrasmetti il contratto passivo alla PCC
	///	 N: Il contratto non è da ristrasmettere alla PCC
	///	 S: Ritrasmetti il contratto passivo alla PCC
	///</summary>
	public String resendingpcc{ 
		get {if (this["resendingpcc"]==DBNull.Value)return null; return  (String)this["resendingpcc"];}
		set {if (value==null) this["resendingpcc"]= DBNull.Value; else this["resendingpcc"]= value;}
	}
	public object resendingpccValue { 
		get{ return this["resendingpcc"];}
		set {if (value==null|| value==DBNull.Value) this["resendingpcc"]= DBNull.Value; else this["resendingpcc"]= value;}
	}
	public String resendingpccOriginal { 
		get {if (this["resendingpcc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["resendingpcc",DataRowVersion.Original];}
	}
	///<summary>
	///Chiave esterna per db collegati
	///</summary>
	public String external_reference{ 
		get {if (this["external_reference"]==DBNull.Value)return null; return  (String)this["external_reference"];}
		set {if (value==null) this["external_reference"]= DBNull.Value; else this["external_reference"]= value;}
	}
	public object external_referenceValue { 
		get{ return this["external_reference"];}
		set {if (value==null|| value==DBNull.Value) this["external_reference"]= DBNull.Value; else this["external_reference"]= value;}
	}
	public String external_referenceOriginal { 
		get {if (this["external_reference",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["external_reference",DataRowVersion.Original];}
	}
	///<summary>
	///Informazioni aggiuntive codificate sulla dich. consip
	///</summary>
	public Int32? idconsipkind_ext{ 
		get {if (this["idconsipkind_ext"]==DBNull.Value)return null; return  (Int32?)this["idconsipkind_ext"];}
		set {if (value==null) this["idconsipkind_ext"]= DBNull.Value; else this["idconsipkind_ext"]= value;}
	}
	public object idconsipkind_extValue { 
		get{ return this["idconsipkind_ext"];}
		set {if (value==null|| value==DBNull.Value) this["idconsipkind_ext"]= DBNull.Value; else this["idconsipkind_ext"]= value;}
	}
	public Int32? idconsipkind_extOriginal { 
		get {if (this["idconsipkind_ext",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idconsipkind_ext",DataRowVersion.Original];}
	}
	///<summary>
	///Causale consip
	///</summary>
	public String consipmotive{ 
		get {if (this["consipmotive"]==DBNull.Value)return null; return  (String)this["consipmotive"];}
		set {if (value==null) this["consipmotive"]= DBNull.Value; else this["consipmotive"]= value;}
	}
	public object consipmotiveValue { 
		get{ return this["consipmotive"];}
		set {if (value==null|| value==DBNull.Value) this["consipmotive"]= DBNull.Value; else this["consipmotive"]= value;}
	}
	public String consipmotiveOriginal { 
		get {if (this["consipmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["consipmotive",DataRowVersion.Original];}
	}
	///<summary>
	///per nota istruttoria, id dell'ufficio a cui inoltrare la pratica (tabella office)
	///</summary>
	public Int32? idoffice{ 
		get {if (this["idoffice"]==DBNull.Value)return null; return  (Int32?)this["idoffice"];}
		set {if (value==null) this["idoffice"]= DBNull.Value; else this["idoffice"]= value;}
	}
	public object idofficeValue { 
		get{ return this["idoffice"];}
		set {if (value==null|| value==DBNull.Value) this["idoffice"]= DBNull.Value; else this["idoffice"]= value;}
	}
	public Int32? idofficeOriginal { 
		get {if (this["idoffice",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idoffice",DataRowVersion.Original];}
	}
	///<summary>
	///Esito della gara
	///	 A: Aggiudicata
	///	 D: Andata deserta
	///	 N: Senza esito per offerte non congrue
	///</summary>
	public String flagtenderresult{ 
		get {if (this["flagtenderresult"]==DBNull.Value)return null; return  (String)this["flagtenderresult"];}
		set {if (value==null) this["flagtenderresult"]= DBNull.Value; else this["flagtenderresult"]= value;}
	}
	public object flagtenderresultValue { 
		get{ return this["flagtenderresult"];}
		set {if (value==null|| value==DBNull.Value) this["flagtenderresult"]= DBNull.Value; else this["flagtenderresult"]= value;}
	}
	public String flagtenderresultOriginal { 
		get {if (this["flagtenderresult",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagtenderresult",DataRowVersion.Original];}
	}
	///<summary>
	///Motivazione affidamento
	///</summary>
	public String motiveassignment{ 
		get {if (this["motiveassignment"]==DBNull.Value)return null; return  (String)this["motiveassignment"];}
		set {if (value==null) this["motiveassignment"]= DBNull.Value; else this["motiveassignment"]= value;}
	}
	public object motiveassignmentValue { 
		get{ return this["motiveassignment"];}
		set {if (value==null|| value==DBNull.Value) this["motiveassignment"]= DBNull.Value; else this["motiveassignment"]= value;}
	}
	public String motiveassignmentOriginal { 
		get {if (this["motiveassignment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motiveassignment",DataRowVersion.Original];}
	}
	///<summary>
	///ribasso percentuale dell'esito
	///</summary>
	public Double? anacreduced{ 
		get {if (this["anacreduced"]==DBNull.Value)return null; return  (Double?)this["anacreduced"];}
		set {if (value==null) this["anacreduced"]= DBNull.Value; else this["anacreduced"]= value;}
	}
	public object anacreducedValue { 
		get{ return this["anacreduced"];}
		set {if (value==null|| value==DBNull.Value) this["anacreduced"]= DBNull.Value; else this["anacreduced"]= value;}
	}
	public Double? anacreducedOriginal { 
		get {if (this["anacreduced",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["anacreduced",DataRowVersion.Original];}
	}
	///<summary>
	///R.U.P. Responsabile Unico del Procedimento per ANAC ( idreg di registry)
	///</summary>
	public Int32? idreg_rupanac{ 
		get {if (this["idreg_rupanac"]==DBNull.Value)return null; return  (Int32?)this["idreg_rupanac"];}
		set {if (value==null) this["idreg_rupanac"]= DBNull.Value; else this["idreg_rupanac"]= value;}
	}
	public object idreg_rupanacValue { 
		get{ return this["idreg_rupanac"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_rupanac"]= DBNull.Value; else this["idreg_rupanac"]= value;}
	}
	public Int32? idreg_rupanacOriginal { 
		get {if (this["idreg_rupanac",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_rupanac",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo Esito gara
	///	 A: Aggiudicata
	///	 D: Andata deserta
	///	 N: Senza esito per offerte non congrue
	///</summary>
	public String tenderkind{ 
		get {if (this["tenderkind"]==DBNull.Value)return null; return  (String)this["tenderkind"];}
		set {if (value==null) this["tenderkind"]= DBNull.Value; else this["tenderkind"]= value;}
	}
	public object tenderkindValue { 
		get{ return this["tenderkind"];}
		set {if (value==null|| value==DBNull.Value) this["tenderkind"]= DBNull.Value; else this["tenderkind"]= value;}
	}
	public String tenderkindOriginal { 
		get {if (this["tenderkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tenderkind",DataRowVersion.Original];}
	}
	///<summary>
	///Data pubblicazione
	///</summary>
	public DateTime? publishdate{ 
		get {if (this["publishdate"]==DBNull.Value)return null; return  (DateTime?)this["publishdate"];}
		set {if (value==null) this["publishdate"]= DBNull.Value; else this["publishdate"]= value;}
	}
	public object publishdateValue { 
		get{ return this["publishdate"];}
		set {if (value==null|| value==DBNull.Value) this["publishdate"]= DBNull.Value; else this["publishdate"]= value;}
	}
	public DateTime? publishdateOriginal { 
		get {if (this["publishdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["publishdate",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo data pubblicazione
	///	 C: Perfezionamento contratto
	///	 M: Acquisto sul MEPA
	///	 Q: Perfezionamento adesione ad accordo quadro
	///	 V: Convenzione
	///</summary>
	public String publishdatekind{ 
		get {if (this["publishdatekind"]==DBNull.Value)return null; return  (String)this["publishdatekind"];}
		set {if (value==null) this["publishdatekind"]= DBNull.Value; else this["publishdatekind"]= value;}
	}
	public object publishdatekindValue { 
		get{ return this["publishdatekind"];}
		set {if (value==null|| value==DBNull.Value) this["publishdatekind"]= DBNull.Value; else this["publishdatekind"]= value;}
	}
	public String publishdatekindOriginal { 
		get {if (this["publishdatekind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["publishdatekind",DataRowVersion.Original];}
	}
	///<summary>
	///Documenti richiesti
	///</summary>
	public Int32? requested_doc{ 
		get {if (this["requested_doc"]==DBNull.Value)return null; return  (Int32?)this["requested_doc"];}
		set {if (value==null) this["requested_doc"]= DBNull.Value; else this["requested_doc"]= value;}
	}
	public object requested_docValue { 
		get{ return this["requested_doc"];}
		set {if (value==null|| value==DBNull.Value) this["requested_doc"]= DBNull.Value; else this["requested_doc"]= value;}
	}
	public Int32? requested_docOriginal { 
		get {if (this["requested_doc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["requested_doc",DataRowVersion.Original];}
	}
	public Int32? flagbit{ 
		get {if (this["flagbit"]==DBNull.Value)return null; return  (Int32?)this["flagbit"];}
		set {if (value==null) this["flagbit"]= DBNull.Value; else this["flagbit"]= value;}
	}
	public object flagbitValue { 
		get{ return this["flagbit"];}
		set {if (value==null|| value==DBNull.Value) this["flagbit"]= DBNull.Value; else this["flagbit"]= value;}
	}
	public Int32? flagbitOriginal { 
		get {if (this["flagbit",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flagbit",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Contratto Passivo
///</summary>
public class mandateTable : MetaTableBase<mandateRow> {
	public mandateTable() : base("mandate"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idmankind",createColumn("idmankind",typeof(string),false,false)},
			{"nman",createColumn("nman",typeof(int),false,false)},
			{"yman",createColumn("yman",typeof(short),false,false)},
			{"active",createColumn("active",typeof(string),true,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"deliveryaddress",createColumn("deliveryaddress",typeof(string),true,false)},
			{"deliveryexpiration",createColumn("deliveryexpiration",typeof(string),true,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"doc",createColumn("doc",typeof(string),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"exchangerate",createColumn("exchangerate",typeof(double),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"officiallyprinted",createColumn("officiallyprinted",typeof(string),false,false)},
			{"paymentexpiring",createColumn("paymentexpiring",typeof(short),true,false)},
			{"registryreference",createColumn("registryreference",typeof(string),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"idman",createColumn("idman",typeof(int),true,false)},
			{"idcurrency",createColumn("idcurrency",typeof(int),true,false)},
			{"idexpirationkind",createColumn("idexpirationkind",typeof(short),true,false)},
			{"flagintracom",createColumn("flagintracom",typeof(string),true,false)},
			{"idaccmotivedebit",createColumn("idaccmotivedebit",typeof(string),true,false)},
			{"idaccmotivedebit_crg",createColumn("idaccmotivedebit_crg",typeof(string),true,false)},
			{"idaccmotivedebit_datacrg",createColumn("idaccmotivedebit_datacrg",typeof(DateTime),true,false)},
			{"applierannotations",createColumn("applierannotations",typeof(string),true,false)},
			{"idmandatestatus",createColumn("idmandatestatus",typeof(short),true,false)},
			{"idstore",createColumn("idstore",typeof(int),true,false)},
			{"cigcode",createColumn("cigcode",typeof(string),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"idconsipkind",createColumn("idconsipkind",typeof(int),true,false)},
			{"flagdanger",createColumn("flagdanger",typeof(string),true,false)},
			{"idmankind_origin",createColumn("idmankind_origin",typeof(string),true,false)},
			{"nman_origin",createColumn("nman_origin",typeof(int),true,false)},
			{"yman_origin",createColumn("yman_origin",typeof(short),true,false)},
			{"subappropriation",createColumn("subappropriation",typeof(string),true,false)},
			{"finsubappropriation",createColumn("finsubappropriation",typeof(string),true,false)},
			{"adatesubappropriation",createColumn("adatesubappropriation",typeof(DateTime),true,false)},
			{"arrivalprotocolnum",createColumn("arrivalprotocolnum",typeof(string),true,false)},
			{"arrivaldate",createColumn("arrivaldate",typeof(DateTime),true,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
			{"resendingpcc",createColumn("resendingpcc",typeof(string),true,false)},
			{"external_reference",createColumn("external_reference",typeof(string),true,false)},
			{"idconsipkind_ext",createColumn("idconsipkind_ext",typeof(int),true,false)},
			{"consipmotive",createColumn("consipmotive",typeof(string),true,false)},
			{"idoffice",createColumn("idoffice",typeof(int),true,false)},
			{"flagtenderresult",createColumn("flagtenderresult",typeof(string),true,false)},
			{"motiveassignment",createColumn("motiveassignment",typeof(string),true,false)},
			{"anacreduced",createColumn("anacreduced",typeof(double),true,false)},
			{"idreg_rupanac",createColumn("idreg_rupanac",typeof(int),true,false)},
			{"tenderkind",createColumn("tenderkind",typeof(string),true,false)},
			{"publishdate",createColumn("publishdate",typeof(DateTime),true,false)},
			{"publishdatekind",createColumn("publishdatekind",typeof(string),true,false)},
			{"requested_doc",createColumn("requested_doc",typeof(int),true,false)},
			{"flagbit",createColumn("flagbit",typeof(int),true,false)},
		};
	}
}
}
