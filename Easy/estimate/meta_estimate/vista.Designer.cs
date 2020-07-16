/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace meta_estimate {
public class estimateRow: MetaRow  {
	public estimateRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///chiave tipo contratto attivo (tabella estimatekind)
	///</summary>
	public String idestimkind{ 
		get {if (this["idestimkind"]==DBNull.Value)return null; return  (String)this["idestimkind"];}
		set {if (value==null) this["idestimkind"]= DBNull.Value; else this["idestimkind"]= value;}
	}
	public object idestimkindValue { 
		get{ return this["idestimkind"];}
		set {if (value==null|| value==DBNull.Value) this["idestimkind"]= DBNull.Value; else this["idestimkind"]= value;}
	}
	public String idestimkindOriginal { 
		get {if (this["idestimkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idestimkind",DataRowVersion.Original];}
	}
	///<summary>
	///Anno contratto attivo
	///</summary>
	public Int16? yestim{ 
		get {if (this["yestim"]==DBNull.Value)return null; return  (Int16?)this["yestim"];}
		set {if (value==null) this["yestim"]= DBNull.Value; else this["yestim"]= value;}
	}
	public object yestimValue { 
		get{ return this["yestim"];}
		set {if (value==null|| value==DBNull.Value) this["yestim"]= DBNull.Value; else this["yestim"]= value;}
	}
	public Int16? yestimOriginal { 
		get {if (this["yestim",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yestim",DataRowVersion.Original];}
	}
	///<summary>
	///N.contratto attivo
	///</summary>
	public Int32? nestim{ 
		get {if (this["nestim"]==DBNull.Value)return null; return  (Int32?)this["nestim"];}
		set {if (value==null) this["nestim"]= DBNull.Value; else this["nestim"]= value;}
	}
	public object nestimValue { 
		get{ return this["nestim"];}
		set {if (value==null|| value==DBNull.Value) this["nestim"]= DBNull.Value; else this["nestim"]= value;}
	}
	public Int32? nestimOriginal { 
		get {if (this["nestim",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nestim",DataRowVersion.Original];}
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
	///Rif. Cliente.
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
	///	 S: Contratto Intracom
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
	///causale di credito
	///</summary>
	public String idaccmotivecredit{ 
		get {if (this["idaccmotivecredit"]==DBNull.Value)return null; return  (String)this["idaccmotivecredit"];}
		set {if (value==null) this["idaccmotivecredit"]= DBNull.Value; else this["idaccmotivecredit"]= value;}
	}
	public object idaccmotivecreditValue { 
		get{ return this["idaccmotivecredit"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivecredit"]= DBNull.Value; else this["idaccmotivecredit"]= value;}
	}
	public String idaccmotivecreditOriginal { 
		get {if (this["idaccmotivecredit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivecredit",DataRowVersion.Original];}
	}
	///<summary>
	///causale di credito corretta
	///</summary>
	public String idaccmotivecredit_crg{ 
		get {if (this["idaccmotivecredit_crg"]==DBNull.Value)return null; return  (String)this["idaccmotivecredit_crg"];}
		set {if (value==null) this["idaccmotivecredit_crg"]= DBNull.Value; else this["idaccmotivecredit_crg"]= value;}
	}
	public object idaccmotivecredit_crgValue { 
		get{ return this["idaccmotivecredit_crg"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivecredit_crg"]= DBNull.Value; else this["idaccmotivecredit_crg"]= value;}
	}
	public String idaccmotivecredit_crgOriginal { 
		get {if (this["idaccmotivecredit_crg",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivecredit_crg",DataRowVersion.Original];}
	}
	///<summary>
	///Data Correz. Causale Credito
	///</summary>
	public DateTime? idaccmotivecredit_datacrg{ 
		get {if (this["idaccmotivecredit_datacrg"]==DBNull.Value)return null; return  (DateTime?)this["idaccmotivecredit_datacrg"];}
		set {if (value==null) this["idaccmotivecredit_datacrg"]= DBNull.Value; else this["idaccmotivecredit_datacrg"]= value;}
	}
	public object idaccmotivecredit_datacrgValue { 
		get{ return this["idaccmotivecredit_datacrg"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivecredit_datacrg"]= DBNull.Value; else this["idaccmotivecredit_datacrg"]= value;}
	}
	public DateTime? idaccmotivecredit_datacrgOriginal { 
		get {if (this["idaccmotivecredit_datacrg",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["idaccmotivecredit_datacrg",DataRowVersion.Original];}
	}
	///<summary>
	///non  ? utilizzato
	///</summary>
	public Int32? idsor_underwriter{ 
		get {if (this["idsor_underwriter"]==DBNull.Value)return null; return  (Int32?)this["idsor_underwriter"];}
		set {if (value==null) this["idsor_underwriter"]= DBNull.Value; else this["idsor_underwriter"]= value;}
	}
	public object idsor_underwriterValue { 
		get{ return this["idsor_underwriter"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_underwriter"]= DBNull.Value; else this["idsor_underwriter"]= value;}
	}
	public Int32? idsor_underwriterOriginal { 
		get {if (this["idsor_underwriter",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_underwriter",DataRowVersion.Original];}
	}
	///<summary>
	///id finanziamento (tabella underwriting)
	///</summary>
	public Int32? idunderwriting{ 
		get {if (this["idunderwriting"]==DBNull.Value)return null; return  (Int32?)this["idunderwriting"];}
		set {if (value==null) this["idunderwriting"]= DBNull.Value; else this["idunderwriting"]= value;}
	}
	public object idunderwritingValue { 
		get{ return this["idunderwriting"];}
		set {if (value==null|| value==DBNull.Value) this["idunderwriting"]= DBNull.Value; else this["idunderwriting"]= value;}
	}
	public Int32? idunderwritingOriginal { 
		get {if (this["idunderwriting",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idunderwriting",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///Contratto attivo
///</summary>
public class estimateTable : MetaTableBase<estimateRow> {
	public estimateTable() : base("estimate"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idestimkind")){ 
			defineColumn("idestimkind", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("yestim")){ 
			defineColumn("yestim", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("nestim")){ 
			defineColumn("nestim", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("active")){ 
			defineColumn("active", typeof(System.String));
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("deliveryaddress")){ 
			defineColumn("deliveryaddress", typeof(System.String));
		}
		if (definedColums.ContainsKey("deliveryexpiration")){ 
			defineColumn("deliveryexpiration", typeof(System.String));
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("doc")){ 
			defineColumn("doc", typeof(System.String));
		}
		if (definedColums.ContainsKey("docdate")){ 
			defineColumn("docdate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("exchangerate")){ 
			defineColumn("exchangerate", typeof(System.Double));
		}
		if (definedColums.ContainsKey("idreg")){ 
			defineColumn("idreg", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("officiallyprinted")){ 
			defineColumn("officiallyprinted", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("paymentexpiring")){ 
			defineColumn("paymentexpiring", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("registryreference")){ 
			defineColumn("registryreference", typeof(System.String));
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("idman")){ 
			defineColumn("idman", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idcurrency")){ 
			defineColumn("idcurrency", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idexpirationkind")){ 
			defineColumn("idexpirationkind", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("flagintracom")){ 
			defineColumn("flagintracom", typeof(System.String));
		}
		if (definedColums.ContainsKey("idaccmotivecredit")){ 
			defineColumn("idaccmotivecredit", typeof(System.String));
		}
		if (definedColums.ContainsKey("idaccmotivecredit_crg")){ 
			defineColumn("idaccmotivecredit_crg", typeof(System.String));
		}
		if (definedColums.ContainsKey("idaccmotivecredit_datacrg")){ 
			defineColumn("idaccmotivecredit_datacrg", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("idsor_underwriter")){ 
			defineColumn("idsor_underwriter", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idunderwriting")){ 
			defineColumn("idunderwriting", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor01")){ 
			defineColumn("idsor01", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor02")){ 
			defineColumn("idsor02", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor03")){ 
			defineColumn("idsor03", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor04")){ 
			defineColumn("idsor04", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor05")){ 
			defineColumn("idsor05", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("external_reference")){ 
			defineColumn("external_reference", typeof(System.String));
		}
		if (definedColums.ContainsKey("cigcode")){ 
			defineColumn("cigcode", typeof(System.String));
		}
		#endregion

	}
}
}
