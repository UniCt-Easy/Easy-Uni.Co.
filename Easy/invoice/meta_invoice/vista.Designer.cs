
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
namespace meta_invoice {
public class invoiceRow: MetaRow  {
	public invoiceRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///n.fattura
	///</summary>
	public Int32 ninv{ 
		get {return  (Int32)this["ninv"];}
		set {this["ninv"]= value;}
	}
	public object ninvValue { 
		get{ return this["ninv"];}
		set {this["ninv"]= value;}
	}
	public Int32 ninvOriginal { 
		get {return  (Int32)this["ninv",DataRowVersion.Original];}
	}
	///<summary>
	///anno fattura
	///</summary>
	public Int16 yinv{ 
		get {return  (Int16)this["yinv"];}
		set {this["yinv"]= value;}
	}
	public object yinvValue { 
		get{ return this["yinv"];}
		set {this["yinv"]= value;}
	}
	public Int16 yinvOriginal { 
		get {return  (Int16)this["yinv",DataRowVersion.Original];}
	}
	///<summary>
	///Utilizzabile per la contabilizzazione
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
	///Data registrazione
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
	///data creazione
	///</summary>
	public DateTime ct{ 
		get {return  (DateTime)this["ct"];}
		set {this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {this["ct"]= value;}
	}
	public DateTime ctOriginal { 
		get {return  (DateTime)this["ct",DataRowVersion.Original];}
	}
	///<summary>
	///nome utente creazione
	///</summary>
	public String cu{ 
		get {return  (String)this["cu"];}
		set {this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {this["cu"]= value;}
	}
	public String cuOriginal { 
		get {return  (String)this["cu",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione
	///</summary>
	public String description{ 
		get {return  (String)this["description"];}
		set {this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {return  (String)this["description",DataRowVersion.Original];}
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
	///Fattura differita
	///	 N: Fattura immediata
	///	 S: Differita
	///</summary>
	public String flagdeferred{ 
		get {if (this["flagdeferred"]==DBNull.Value)return null; return  (String)this["flagdeferred"];}
		set {if (value==null) this["flagdeferred"]= DBNull.Value; else this["flagdeferred"]= value;}
	}
	public object flagdeferredValue { 
		get{ return this["flagdeferred"];}
		set {if (value==null|| value==DBNull.Value) this["flagdeferred"]= DBNull.Value; else this["flagdeferred"]= value;}
	}
	public String flagdeferredOriginal { 
		get {if (this["flagdeferred",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagdeferred",DataRowVersion.Original];}
	}
	///<summary>
	///id anagrafica (tabella registry)
	///</summary>
	public Int32 idreg{ 
		get {return  (Int32)this["idreg"];}
		set {this["idreg"]= value;}
	}
	public object idregValue { 
		get{ return this["idreg"];}
		set {this["idreg"]= value;}
	}
	public Int32 idregOriginal { 
		get {return  (Int32)this["idreg",DataRowVersion.Original];}
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
	///Flag stampa
	///</summary>
	public String officiallyprinted{ 
		get {return  (String)this["officiallyprinted"];}
		set {this["officiallyprinted"]= value;}
	}
	public object officiallyprintedValue { 
		get{ return this["officiallyprinted"];}
		set {this["officiallyprinted"]= value;}
	}
	public String officiallyprintedOriginal { 
		get {return  (String)this["officiallyprinted",DataRowVersion.Original];}
	}
	///<summary>
	///Data doc. trasp.
	///</summary>
	public DateTime? packinglistdate{ 
		get {if (this["packinglistdate"]==DBNull.Value)return null; return  (DateTime?)this["packinglistdate"];}
		set {if (value==null) this["packinglistdate"]= DBNull.Value; else this["packinglistdate"]= value;}
	}
	public object packinglistdateValue { 
		get{ return this["packinglistdate"];}
		set {if (value==null|| value==DBNull.Value) this["packinglistdate"]= DBNull.Value; else this["packinglistdate"]= value;}
	}
	public DateTime? packinglistdateOriginal { 
		get {if (this["packinglistdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["packinglistdate",DataRowVersion.Original];}
	}
	///<summary>
	///Num. doc. trasp.
	///</summary>
	public String packinglistnum{ 
		get {if (this["packinglistnum"]==DBNull.Value)return null; return  (String)this["packinglistnum"];}
		set {if (value==null) this["packinglistnum"]= DBNull.Value; else this["packinglistnum"]= value;}
	}
	public object packinglistnumValue { 
		get{ return this["packinglistnum"];}
		set {if (value==null|| value==DBNull.Value) this["packinglistnum"]= DBNull.Value; else this["packinglistnum"]= value;}
	}
	public String packinglistnumOriginal { 
		get {if (this["packinglistnum",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["packinglistnum",DataRowVersion.Original];}
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
	///Riferimento Cliente/Fornitore
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
	///id tipo documento (tabella invoicekind)
	///</summary>
	public Int32 idinvkind{ 
		get {return  (Int32)this["idinvkind"];}
		set {this["idinvkind"]= value;}
	}
	public object idinvkindValue { 
		get{ return this["idinvkind"];}
		set {this["idinvkind"]= value;}
	}
	public Int32 idinvkindOriginal { 
		get {return  (Int32)this["idinvkind",DataRowVersion.Original];}
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
	///Id cassiere per l'incasso (tabella treasurer)
	///</summary>
	public Int32? idtreasurer{ 
		get {if (this["idtreasurer"]==DBNull.Value)return null; return  (Int32?)this["idtreasurer"];}
		set {if (value==null) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public object idtreasurerValue { 
		get{ return this["idtreasurer"];}
		set {if (value==null|| value==DBNull.Value) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public Int32? idtreasurerOriginal { 
		get {if (this["idtreasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtreasurer",DataRowVersion.Original];}
	}
	///<summary>
	///Flag intracom (N/X/S)
	///	 N: Fattura in Italia
	///	 S: Fattura Intracomunitaria
	///	 X: Fattura Extra-UE
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
	///Id paese origine per acquisti intrastat
	///</summary>
	public String iso_origin{ 
		get {if (this["iso_origin"]==DBNull.Value)return null; return  (String)this["iso_origin"];}
		set {if (value==null) this["iso_origin"]= DBNull.Value; else this["iso_origin"]= value;}
	}
	public object iso_originValue { 
		get{ return this["iso_origin"];}
		set {if (value==null|| value==DBNull.Value) this["iso_origin"]= DBNull.Value; else this["iso_origin"]= value;}
	}
	public String iso_originOriginal { 
		get {if (this["iso_origin",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iso_origin",DataRowVersion.Original];}
	}
	///<summary>
	///Id paese provenienza per acquisti intrastat
	///</summary>
	public String iso_provenance{ 
		get {if (this["iso_provenance"]==DBNull.Value)return null; return  (String)this["iso_provenance"];}
		set {if (value==null) this["iso_provenance"]= DBNull.Value; else this["iso_provenance"]= value;}
	}
	public object iso_provenanceValue { 
		get{ return this["iso_provenance"];}
		set {if (value==null|| value==DBNull.Value) this["iso_provenance"]= DBNull.Value; else this["iso_provenance"]= value;}
	}
	public String iso_provenanceOriginal { 
		get {if (this["iso_provenance",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iso_provenance",DataRowVersion.Original];}
	}
	///<summary>
	///Provincia di destinazione per vendite intrastat
	///</summary>
	public String iso_destination{ 
		get {if (this["iso_destination"]==DBNull.Value)return null; return  (String)this["iso_destination"];}
		set {if (value==null) this["iso_destination"]= DBNull.Value; else this["iso_destination"]= value;}
	}
	public object iso_destinationValue { 
		get{ return this["iso_destination"];}
		set {if (value==null|| value==DBNull.Value) this["iso_destination"]= DBNull.Value; else this["iso_destination"]= value;}
	}
	public String iso_destinationOriginal { 
		get {if (this["iso_destination",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iso_destination",DataRowVersion.Original];}
	}
	///<summary>
	///Provincia di origine per vendita intrastat
	///</summary>
	public Int32? idcountry_origin{ 
		get {if (this["idcountry_origin"]==DBNull.Value)return null; return  (Int32?)this["idcountry_origin"];}
		set {if (value==null) this["idcountry_origin"]= DBNull.Value; else this["idcountry_origin"]= value;}
	}
	public object idcountry_originValue { 
		get{ return this["idcountry_origin"];}
		set {if (value==null|| value==DBNull.Value) this["idcountry_origin"]= DBNull.Value; else this["idcountry_origin"]= value;}
	}
	public Int32? idcountry_originOriginal { 
		get {if (this["idcountry_origin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcountry_origin",DataRowVersion.Original];}
	}
	///<summary>
	///Paese di destinazione per acquisti intrastat
	///</summary>
	public Int32? idcountry_destination{ 
		get {if (this["idcountry_destination"]==DBNull.Value)return null; return  (Int32?)this["idcountry_destination"];}
		set {if (value==null) this["idcountry_destination"]= DBNull.Value; else this["idcountry_destination"]= value;}
	}
	public object idcountry_destinationValue { 
		get{ return this["idcountry_destination"];}
		set {if (value==null|| value==DBNull.Value) this["idcountry_destination"]= DBNull.Value; else this["idcountry_destination"]= value;}
	}
	public Int32? idcountry_destinationOriginal { 
		get {if (this["idcountry_destination",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcountry_destination",DataRowVersion.Original];}
	}
	///<summary>
	///ID  Natura della transazione (tabella intrastatkind)
	///</summary>
	public String idintrastatkind{ 
		get {if (this["idintrastatkind"]==DBNull.Value)return null; return  (String)this["idintrastatkind"];}
		set {if (value==null) this["idintrastatkind"]= DBNull.Value; else this["idintrastatkind"]= value;}
	}
	public object idintrastatkindValue { 
		get{ return this["idintrastatkind"];}
		set {if (value==null|| value==DBNull.Value) this["idintrastatkind"]= DBNull.Value; else this["idintrastatkind"]= value;}
	}
	public String idintrastatkindOriginal { 
		get {if (this["idintrastatkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idintrastatkind",DataRowVersion.Original];}
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
	///ID Modalità pagamento  (tabella intrastatpaymethod) (Dettagli ai fini dei modelli Intrastat per Servizi resi / ricevuti)
	///</summary>
	public Int32? idintrastatpaymethod{ 
		get {if (this["idintrastatpaymethod"]==DBNull.Value)return null; return  (Int32?)this["idintrastatpaymethod"];}
		set {if (value==null) this["idintrastatpaymethod"]= DBNull.Value; else this["idintrastatpaymethod"]= value;}
	}
	public object idintrastatpaymethodValue { 
		get{ return this["idintrastatpaymethod"];}
		set {if (value==null|| value==DBNull.Value) this["idintrastatpaymethod"]= DBNull.Value; else this["idintrastatpaymethod"]= value;}
	}
	public Int32? idintrastatpaymethodOriginal { 
		get {if (this["idintrastatpaymethod",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idintrastatpaymethod",DataRowVersion.Original];}
	}
	///<summary>
	///id Paese di pagamento (Dettagli ai fini dei modelli Intrastat per Servizi resi / ricevuti)
	///</summary>
	public String iso_payment{ 
		get {if (this["iso_payment"]==DBNull.Value)return null; return  (String)this["iso_payment"];}
		set {if (value==null) this["iso_payment"]= DBNull.Value; else this["iso_payment"]= value;}
	}
	public object iso_paymentValue { 
		get{ return this["iso_payment"];}
		set {if (value==null|| value==DBNull.Value) this["iso_payment"]= DBNull.Value; else this["iso_payment"]= value;}
	}
	public String iso_paymentOriginal { 
		get {if (this["iso_payment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iso_payment",DataRowVersion.Original];}
	}
	///<summary>
	///Fattura accompagnatoria
	///	 N: Non si tratta di fattura accompagnatoria
	///	 S: Fattura accompagnatoria
	///</summary>
	public String flag_ddt{ 
		get {if (this["flag_ddt"]==DBNull.Value)return null; return  (String)this["flag_ddt"];}
		set {if (value==null) this["flag_ddt"]= DBNull.Value; else this["flag_ddt"]= value;}
	}
	public object flag_ddtValue { 
		get{ return this["flag_ddt"];}
		set {if (value==null|| value==DBNull.Value) this["flag_ddt"]= DBNull.Value; else this["flag_ddt"]= value;}
	}
	public String flag_ddtOriginal { 
		get {if (this["flag_ddt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flag_ddt",DataRowVersion.Original];}
	}
	///<summary>
	///flag
	///</summary>
	public Int32? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Int32?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Int32? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flag",DataRowVersion.Original];}
	}
	///<summary>
	///ID  Paesi a fiscalità privilegiata (tabella blacklist)
	///</summary>
	public Int32? idblacklist{ 
		get {if (this["idblacklist"]==DBNull.Value)return null; return  (Int32?)this["idblacklist"];}
		set {if (value==null) this["idblacklist"]= DBNull.Value; else this["idblacklist"]= value;}
	}
	public object idblacklistValue { 
		get{ return this["idblacklist"];}
		set {if (value==null|| value==DBNull.Value) this["idblacklist"]= DBNull.Value; else this["idblacklist"]= value;}
	}
	public Int32? idblacklistOriginal { 
		get {if (this["idblacklist",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idblacklist",DataRowVersion.Original];}
	}
	///<summary>
	///id tipo documento fattura di riferimento per autofattura (idinvoicekind di invoice)
	///</summary>
	public Int32? idinvkind_real{ 
		get {if (this["idinvkind_real"]==DBNull.Value)return null; return  (Int32?)this["idinvkind_real"];}
		set {if (value==null) this["idinvkind_real"]= DBNull.Value; else this["idinvkind_real"]= value;}
	}
	public object idinvkind_realValue { 
		get{ return this["idinvkind_real"];}
		set {if (value==null|| value==DBNull.Value) this["idinvkind_real"]= DBNull.Value; else this["idinvkind_real"]= value;}
	}
	public Int32? idinvkind_realOriginal { 
		get {if (this["idinvkind_real",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinvkind_real",DataRowVersion.Original];}
	}
	///<summary>
	///anno  documento fattura di riferimento per autofattura yinv di invoice)
	///</summary>
	public Int16? yinv_real{ 
		get {if (this["yinv_real"]==DBNull.Value)return null; return  (Int16?)this["yinv_real"];}
		set {if (value==null) this["yinv_real"]= DBNull.Value; else this["yinv_real"]= value;}
	}
	public object yinv_realValue { 
		get{ return this["yinv_real"];}
		set {if (value==null|| value==DBNull.Value) this["yinv_real"]= DBNull.Value; else this["yinv_real"]= value;}
	}
	public Int16? yinv_realOriginal { 
		get {if (this["yinv_real",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yinv_real",DataRowVersion.Original];}
	}
	///<summary>
	///numero documento fattura di riferimento per autofattura (ninv di invoice)
	///</summary>
	public Int32? ninv_real{ 
		get {if (this["ninv_real"]==DBNull.Value)return null; return  (Int32?)this["ninv_real"];}
		set {if (value==null) this["ninv_real"]= DBNull.Value; else this["ninv_real"]= value;}
	}
	public object ninv_realValue { 
		get{ return this["ninv_real"];}
		set {if (value==null|| value==DBNull.Value) this["ninv_real"]= DBNull.Value; else this["ninv_real"]= value;}
	}
	public Int32? ninv_realOriginal { 
		get {if (this["ninv_real",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ninv_real",DataRowVersion.Original];}
	}
	///<summary>
	///Autofattura
	///	 N: Non è autofattura
	///	 S: Autofattura
	///</summary>
	public String autoinvoice{ 
		get {if (this["autoinvoice"]==DBNull.Value)return null; return  (String)this["autoinvoice"];}
		set {if (value==null) this["autoinvoice"]= DBNull.Value; else this["autoinvoice"]= value;}
	}
	public object autoinvoiceValue { 
		get{ return this["autoinvoice"];}
		set {if (value==null|| value==DBNull.Value) this["autoinvoice"]= DBNull.Value; else this["autoinvoice"]= value;}
	}
	public String autoinvoiceOriginal { 
		get {if (this["autoinvoice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["autoinvoice",DataRowVersion.Original];}
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
	///Data ricezione
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
	///ID Condizioni  pagamento fattura elettronica (tabella fepaymethodcondition)
	///</summary>
	public String idfepaymethodcondition{ 
		get {if (this["idfepaymethodcondition"]==DBNull.Value)return null; return  (String)this["idfepaymethodcondition"];}
		set {if (value==null) this["idfepaymethodcondition"]= DBNull.Value; else this["idfepaymethodcondition"]= value;}
	}
	public object idfepaymethodconditionValue { 
		get{ return this["idfepaymethodcondition"];}
		set {if (value==null|| value==DBNull.Value) this["idfepaymethodcondition"]= DBNull.Value; else this["idfepaymethodcondition"]= value;}
	}
	public String idfepaymethodconditionOriginal { 
		get {if (this["idfepaymethodcondition",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idfepaymethodcondition",DataRowVersion.Original];}
	}
	///<summary>
	///ID Condizioni pagamento fattura elettronica (tabella fepaymethod)
	///</summary>
	public String idfepaymethod{ 
		get {if (this["idfepaymethod"]==DBNull.Value)return null; return  (String)this["idfepaymethod"];}
		set {if (value==null) this["idfepaymethod"]= DBNull.Value; else this["idfepaymethod"]= value;}
	}
	public object idfepaymethodValue { 
		get{ return this["idfepaymethod"];}
		set {if (value==null|| value==DBNull.Value) this["idfepaymethod"]= DBNull.Value; else this["idfepaymethod"]= value;}
	}
	public String idfepaymethodOriginal { 
		get {if (this["idfepaymethod",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idfepaymethod",DataRowVersion.Original];}
	}
	///<summary>
	///N. fattura elettronica (chiave per electroinicinvoice)
	///</summary>
	public Int32? nelectronicinvoice{ 
		get {if (this["nelectronicinvoice"]==DBNull.Value)return null; return  (Int32?)this["nelectronicinvoice"];}
		set {if (value==null) this["nelectronicinvoice"]= DBNull.Value; else this["nelectronicinvoice"]= value;}
	}
	public object nelectronicinvoiceValue { 
		get{ return this["nelectronicinvoice"];}
		set {if (value==null|| value==DBNull.Value) this["nelectronicinvoice"]= DBNull.Value; else this["nelectronicinvoice"]= value;}
	}
	public Int32? nelectronicinvoiceOriginal { 
		get {if (this["nelectronicinvoice",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nelectronicinvoice",DataRowVersion.Original];}
	}
	///<summary>
	///Anno fattura elettronica (chiave per electroinicinvoice)
	///</summary>
	public Int16? yelectronicinvoice{ 
		get {if (this["yelectronicinvoice"]==DBNull.Value)return null; return  (Int16?)this["yelectronicinvoice"];}
		set {if (value==null) this["yelectronicinvoice"]= DBNull.Value; else this["yelectronicinvoice"]= value;}
	}
	public object yelectronicinvoiceValue { 
		get{ return this["yelectronicinvoice"];}
		set {if (value==null|| value==DBNull.Value) this["yelectronicinvoice"]= DBNull.Value; else this["yelectronicinvoice"]= value;}
	}
	public Int16? yelectronicinvoiceOriginal { 
		get {if (this["yelectronicinvoice",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yelectronicinvoice",DataRowVersion.Original];}
	}
	///<summary>
	///Annotazioni
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
	///Includi in Indicatore Tempest. dei Pagamenti
	///	 N: Non includere in Indicatore Tempest. dei Pagamenti
	///	 S: Includi in Indicatore Tempest. dei Pagamenti
	///</summary>
	public String toincludeinpaymentindicator{ 
		get {if (this["toincludeinpaymentindicator"]==DBNull.Value)return null; return  (String)this["toincludeinpaymentindicator"];}
		set {if (value==null) this["toincludeinpaymentindicator"]= DBNull.Value; else this["toincludeinpaymentindicator"]= value;}
	}
	public object toincludeinpaymentindicatorValue { 
		get{ return this["toincludeinpaymentindicator"];}
		set {if (value==null|| value==DBNull.Value) this["toincludeinpaymentindicator"]= DBNull.Value; else this["toincludeinpaymentindicator"]= value;}
	}
	public String toincludeinpaymentindicatorOriginal { 
		get {if (this["toincludeinpaymentindicator",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["toincludeinpaymentindicator",DataRowVersion.Original];}
	}
	///<summary>
	///Ritrasmetti fattura alla PCC
	///	 N: Non ritrasmettere fattura alla PCC
	///	 S: Ritrasmetti fattura alla PCC
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
	///Protocolla nel Registro Unico
	///</summary>
	public String touniqueregister{ 
		get {if (this["touniqueregister"]==DBNull.Value)return null; return  (String)this["touniqueregister"];}
		set {if (value==null) this["touniqueregister"]= DBNull.Value; else this["touniqueregister"]= value;}
	}
	public object touniqueregisterValue { 
		get{ return this["touniqueregister"];}
		set {if (value==null|| value==DBNull.Value) this["touniqueregister"]= DBNull.Value; else this["touniqueregister"]= value;}
	}
	public String touniqueregisterOriginal { 
		get {if (this["touniqueregister",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["touniqueregister",DataRowVersion.Original];}
	}
	///<summary>
	///tipo Bollo (no= non soggetta)
	///	 dm19_2014: Fattura soggetta ad imposta di bollo € 2,00 con assolvimento secondo modalità telemetiche del DM 19 
	///	 no: Fattura non soggetta a bollo
	///</summary>
	public String idstampkind{ 
		get {if (this["idstampkind"]==DBNull.Value)return null; return  (String)this["idstampkind"];}
		set {if (value==null) this["idstampkind"]= DBNull.Value; else this["idstampkind"]= value;}
	}
	public object idstampkindValue { 
		get{ return this["idstampkind"];}
		set {if (value==null|| value==DBNull.Value) this["idstampkind"]= DBNull.Value; else this["idstampkind"]= value;}
	}
	public String idstampkindOriginal { 
		get {if (this["idstampkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idstampkind",DataRowVersion.Original];}
	}
	///<summary>
	///Abilita modifica manuale
	///	 N: Dati split payment inseriti automaticamente
	///	 S: Abilita modifica manuale
	///</summary>
	public String flag_auto_split_payment{ 
		get {if (this["flag_auto_split_payment"]==DBNull.Value)return null; return  (String)this["flag_auto_split_payment"];}
		set {if (value==null) this["flag_auto_split_payment"]= DBNull.Value; else this["flag_auto_split_payment"]= value;}
	}
	public object flag_auto_split_paymentValue { 
		get{ return this["flag_auto_split_payment"];}
		set {if (value==null|| value==DBNull.Value) this["flag_auto_split_payment"]= DBNull.Value; else this["flag_auto_split_payment"]= value;}
	}
	public String flag_auto_split_paymentOriginal { 
		get {if (this["flag_auto_split_payment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flag_auto_split_payment",DataRowVersion.Original];}
	}
	///<summary>
	///Applica Split Payment
	///	 N: Non applicare Split Payment
	///	 S: Applica Split Payment
	///</summary>
	public String flag_enable_split_payment{ 
		get {if (this["flag_enable_split_payment"]==DBNull.Value)return null; return  (String)this["flag_enable_split_payment"];}
		set {if (value==null) this["flag_enable_split_payment"]= DBNull.Value; else this["flag_enable_split_payment"]= value;}
	}
	public object flag_enable_split_paymentValue { 
		get{ return this["flag_enable_split_payment"];}
		set {if (value==null|| value==DBNull.Value) this["flag_enable_split_payment"]= DBNull.Value; else this["flag_enable_split_payment"]= value;}
	}
	public String flag_enable_split_paymentOriginal { 
		get {if (this["flag_enable_split_payment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flag_enable_split_payment",DataRowVersion.Original];}
	}
	///<summary>
	///ID Fattura Elettronica-Acquisto (tabella sdi_acquisto)
	///</summary>
	public Int32? idsdi_acquisto{ 
		get {if (this["idsdi_acquisto"]==DBNull.Value)return null; return  (Int32?)this["idsdi_acquisto"];}
		set {if (value==null) this["idsdi_acquisto"]= DBNull.Value; else this["idsdi_acquisto"]= value;}
	}
	public object idsdi_acquistoValue { 
		get{ return this["idsdi_acquisto"];}
		set {if (value==null|| value==DBNull.Value) this["idsdi_acquisto"]= DBNull.Value; else this["idsdi_acquisto"]= value;}
	}
	public Int32? idsdi_acquistoOriginal { 
		get {if (this["idsdi_acquisto",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsdi_acquisto",DataRowVersion.Original];}
	}
	///<summary>
	///ID Fatture di vendita selezionate per la trasmissione (tabella sdi_vendita)
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
	///Applica Reverse Charge
	///	 N: Non applicare Reverse Charge
	///	 S: Applica Reverse Charge
	///</summary>
	public String flag_reverse_charge{ 
		get {if (this["flag_reverse_charge"]==DBNull.Value)return null; return  (String)this["flag_reverse_charge"];}
		set {if (value==null) this["flag_reverse_charge"]= DBNull.Value; else this["flag_reverse_charge"]= value;}
	}
	public object flag_reverse_chargeValue { 
		get{ return this["flag_reverse_charge"];}
		set {if (value==null|| value==DBNull.Value) this["flag_reverse_charge"]= DBNull.Value; else this["flag_reverse_charge"]= value;}
	}
	public String flag_reverse_chargeOriginal { 
		get {if (this["flag_reverse_charge",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flag_reverse_charge",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA
	///</summary>
	public String ipa_acq{ 
		get {if (this["ipa_acq"]==DBNull.Value)return null; return  (String)this["ipa_acq"];}
		set {if (value==null) this["ipa_acq"]= DBNull.Value; else this["ipa_acq"]= value;}
	}
	public object ipa_acqValue { 
		get{ return this["ipa_acq"];}
		set {if (value==null|| value==DBNull.Value) this["ipa_acq"]= DBNull.Value; else this["ipa_acq"]= value;}
	}
	public String ipa_acqOriginal { 
		get {if (this["ipa_acq",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ipa_acq",DataRowVersion.Original];}
	}
	///<summary>
	///Riferimento amministrazione per destinatario della fattura di acquisto, è il campo idsdi_rifamm per la tabella sdi_rifamm
	///</summary>
	public String rifamm_acq{ 
		get {if (this["rifamm_acq"]==DBNull.Value)return null; return  (String)this["rifamm_acq"];}
		set {if (value==null) this["rifamm_acq"]= DBNull.Value; else this["rifamm_acq"]= value;}
	}
	public object rifamm_acqValue { 
		get{ return this["rifamm_acq"];}
		set {if (value==null|| value==DBNull.Value) this["rifamm_acq"]= DBNull.Value; else this["rifamm_acq"]= value;}
	}
	public String rifamm_acqOriginal { 
		get {if (this["rifamm_acq",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rifamm_acq",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, campo ipa_de della tabella ipa
	///</summary>
	public String ipa_ven_emittente{ 
		get {if (this["ipa_ven_emittente"]==DBNull.Value)return null; return  (String)this["ipa_ven_emittente"];}
		set {if (value==null) this["ipa_ven_emittente"]= DBNull.Value; else this["ipa_ven_emittente"]= value;}
	}
	public object ipa_ven_emittenteValue { 
		get{ return this["ipa_ven_emittente"];}
		set {if (value==null|| value==DBNull.Value) this["ipa_ven_emittente"]= DBNull.Value; else this["ipa_ven_emittente"]= value;}
	}
	public String ipa_ven_emittenteOriginal { 
		get {if (this["ipa_ven_emittente",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ipa_ven_emittente",DataRowVersion.Original];}
	}
	///<summary>
	///Riferimento Amministrazione per mittente fattura di vendita, è il campo idsdi_rifamm per la tabella sdi_rifamm
	///</summary>
	public String rifamm_ven_emittente{ 
		get {if (this["rifamm_ven_emittente"]==DBNull.Value)return null; return  (String)this["rifamm_ven_emittente"];}
		set {if (value==null) this["rifamm_ven_emittente"]= DBNull.Value; else this["rifamm_ven_emittente"]= value;}
	}
	public object rifamm_ven_emittenteValue { 
		get{ return this["rifamm_ven_emittente"];}
		set {if (value==null|| value==DBNull.Value) this["rifamm_ven_emittente"]= DBNull.Value; else this["rifamm_ven_emittente"]= value;}
	}
	public String rifamm_ven_emittenteOriginal { 
		get {if (this["rifamm_ven_emittente",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rifamm_ven_emittente",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA
	///</summary>
	public String ipa_ven_cliente{ 
		get {if (this["ipa_ven_cliente"]==DBNull.Value)return null; return  (String)this["ipa_ven_cliente"];}
		set {if (value==null) this["ipa_ven_cliente"]= DBNull.Value; else this["ipa_ven_cliente"]= value;}
	}
	public object ipa_ven_clienteValue { 
		get{ return this["ipa_ven_cliente"];}
		set {if (value==null|| value==DBNull.Value) this["ipa_ven_cliente"]= DBNull.Value; else this["ipa_ven_cliente"]= value;}
	}
	public String ipa_ven_clienteOriginal { 
		get {if (this["ipa_ven_cliente",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ipa_ven_cliente",DataRowVersion.Original];}
	}
	///<summary>
	///Riferimento amministrazione per destinatario fattura di vendita, è il campo idsdi_rifamm per la tabella sdi_rifamm
	///</summary>
	public String rifamm_ven_cliente{ 
		get {if (this["rifamm_ven_cliente"]==DBNull.Value)return null; return  (String)this["rifamm_ven_cliente"];}
		set {if (value==null) this["rifamm_ven_cliente"]= DBNull.Value; else this["rifamm_ven_cliente"]= value;}
	}
	public object rifamm_ven_clienteValue { 
		get{ return this["rifamm_ven_cliente"];}
		set {if (value==null|| value==DBNull.Value) this["rifamm_ven_cliente"]= DBNull.Value; else this["rifamm_ven_cliente"]= value;}
	}
	public String rifamm_ven_clienteOriginal { 
		get {if (this["rifamm_ven_cliente",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rifamm_ven_cliente",DataRowVersion.Original];}
	}
	///<summary>
	///tipo spesa per progetto tessera sanitaria
	///	 AA: Altre spese
	///	 AD: Acquisto dispositivo
	///	 AS: Spese sanitarie
	///	 CT: Cure Termali
	///	 FC: Farmaco
	///	 FV: Faramco veterinario
	///	 IC: Intervento di chirurgia 
	///	 PI: protesica e integrativa
	///	 SR: Spese prestazioni 
	///	 TK: ticket
	///</summary>
	public String ssntipospesa{ 
		get {if (this["ssntipospesa"]==DBNull.Value)return null; return  (String)this["ssntipospesa"];}
		set {if (value==null) this["ssntipospesa"]= DBNull.Value; else this["ssntipospesa"]= value;}
	}
	public object ssntipospesaValue { 
		get{ return this["ssntipospesa"];}
		set {if (value==null|| value==DBNull.Value) this["ssntipospesa"]= DBNull.Value; else this["ssntipospesa"]= value;}
	}
	public String ssntipospesaOriginal { 
		get {if (this["ssntipospesa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ssntipospesa",DataRowVersion.Original];}
	}
	///<summary>
	///non sembra usato
	///</summary>
	public String ssnflagtipospesa{ 
		get {if (this["ssnflagtipospesa"]==DBNull.Value)return null; return  (String)this["ssnflagtipospesa"];}
		set {if (value==null) this["ssnflagtipospesa"]= DBNull.Value; else this["ssnflagtipospesa"]= value;}
	}
	public object ssnflagtipospesaValue { 
		get{ return this["ssnflagtipospesa"];}
		set {if (value==null|| value==DBNull.Value) this["ssnflagtipospesa"]= DBNull.Value; else this["ssnflagtipospesa"]= value;}
	}
	public String ssnflagtipospesaOriginal { 
		get {if (this["ssnflagtipospesa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ssnflagtipospesa",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo fattura spedizioniere. Campo valorizzato nella Bolla doganale.
	///</summary>
	public Int32? idinvkind_forwarder{ 
		get {if (this["idinvkind_forwarder"]==DBNull.Value)return null; return  (Int32?)this["idinvkind_forwarder"];}
		set {if (value==null) this["idinvkind_forwarder"]= DBNull.Value; else this["idinvkind_forwarder"]= value;}
	}
	public object idinvkind_forwarderValue { 
		get{ return this["idinvkind_forwarder"];}
		set {if (value==null|| value==DBNull.Value) this["idinvkind_forwarder"]= DBNull.Value; else this["idinvkind_forwarder"]= value;}
	}
	public Int32? idinvkind_forwarderOriginal { 
		get {if (this["idinvkind_forwarder",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinvkind_forwarder",DataRowVersion.Original];}
	}
	///<summary>
	///Esercizio fattura spedizioniere. Campo valorizzato nella Bolla doganale.
	///</summary>
	public Int16? yinv_forwarder{ 
		get {if (this["yinv_forwarder"]==DBNull.Value)return null; return  (Int16?)this["yinv_forwarder"];}
		set {if (value==null) this["yinv_forwarder"]= DBNull.Value; else this["yinv_forwarder"]= value;}
	}
	public object yinv_forwarderValue { 
		get{ return this["yinv_forwarder"];}
		set {if (value==null|| value==DBNull.Value) this["yinv_forwarder"]= DBNull.Value; else this["yinv_forwarder"]= value;}
	}
	public Int16? yinv_forwarderOriginal { 
		get {if (this["yinv_forwarder",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yinv_forwarder",DataRowVersion.Original];}
	}
	///<summary>
	///Numero fattura spedizioniere. Campo valorizzato nella Bolla doganale.
	///</summary>
	public Int32? ninv_forwarder{ 
		get {if (this["ninv_forwarder"]==DBNull.Value)return null; return  (Int32?)this["ninv_forwarder"];}
		set {if (value==null) this["ninv_forwarder"]= DBNull.Value; else this["ninv_forwarder"]= value;}
	}
	public object ninv_forwarderValue { 
		get{ return this["ninv_forwarder"];}
		set {if (value==null|| value==DBNull.Value) this["ninv_forwarder"]= DBNull.Value; else this["ninv_forwarder"]= value;}
	}
	public Int32? ninv_forwarderOriginal { 
		get {if (this["ninv_forwarder",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ninv_forwarder",DataRowVersion.Original];}
	}
	///<summary>
	///Flag a bit.
	///</summary>
	public Byte? flagbit{ 
		get {if (this["flagbit"]==DBNull.Value)return null; return  (Byte?)this["flagbit"];}
		set {if (value==null) this["flagbit"]= DBNull.Value; else this["flagbit"]= value;}
	}
	public object flagbitValue { 
		get{ return this["flagbit"];}
		set {if (value==null|| value==DBNull.Value) this["flagbit"]= DBNull.Value; else this["flagbit"]= value;}
	}
	public Byte? flagbitOriginal { 
		get {if (this["flagbit",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flagbit",DataRowVersion.Original];}
	}
	///<summary>
	///Numero protocollo (sistema TS)
	///</summary>
	public String ssn_nprot{ 
		get {if (this["ssn_nprot"]==DBNull.Value)return null; return  (String)this["ssn_nprot"];}
		set {if (value==null) this["ssn_nprot"]= DBNull.Value; else this["ssn_nprot"]= value;}
	}
	public object ssn_nprotValue { 
		get{ return this["ssn_nprot"];}
		set {if (value==null|| value==DBNull.Value) this["ssn_nprot"]= DBNull.Value; else this["ssn_nprot"]= value;}
	}
	public String ssn_nprotOriginal { 
		get {if (this["ssn_nprot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ssn_nprot",DataRowVersion.Original];}
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
	public Int32? idnocigmotive{ 
		get {if (this["idnocigmotive"]==DBNull.Value)return null; return  (Int32?)this["idnocigmotive"];}
		set {if (value==null) this["idnocigmotive"]= DBNull.Value; else this["idnocigmotive"]= value;}
	}
	public object idnocigmotiveValue { 
		get{ return this["idnocigmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idnocigmotive"]= DBNull.Value; else this["idnocigmotive"]= value;}
	}
	public Int32? idnocigmotiveOriginal { 
		get {if (this["idnocigmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnocigmotive",DataRowVersion.Original];}
	}
	public Int32? idreg_sostituto{ 
		get {if (this["idreg_sostituto"]==DBNull.Value)return null; return  (Int32?)this["idreg_sostituto"];}
		set {if (value==null) this["idreg_sostituto"]= DBNull.Value; else this["idreg_sostituto"]= value;}
	}
	public object idreg_sostitutoValue { 
		get{ return this["idreg_sostituto"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_sostituto"]= DBNull.Value; else this["idreg_sostituto"]= value;}
	}
	public Int32? idreg_sostitutoOriginal { 
		get {if (this["idreg_sostituto",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_sostituto",DataRowVersion.Original];}
	}
	public String pec_ven_cliente{ 
		get {if (this["pec_ven_cliente"]==DBNull.Value)return null; return  (String)this["pec_ven_cliente"];}
		set {if (value==null) this["pec_ven_cliente"]= DBNull.Value; else this["pec_ven_cliente"]= value;}
	}
	public object pec_ven_clienteValue { 
		get{ return this["pec_ven_cliente"];}
		set {if (value==null|| value==DBNull.Value) this["pec_ven_cliente"]= DBNull.Value; else this["pec_ven_cliente"]= value;}
	}
	public String pec_ven_clienteOriginal { 
		get {if (this["pec_ven_cliente",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["pec_ven_cliente",DataRowVersion.Original];}
	}
	public String email_ven_cliente{ 
		get {if (this["email_ven_cliente"]==DBNull.Value)return null; return  (String)this["email_ven_cliente"];}
		set {if (value==null) this["email_ven_cliente"]= DBNull.Value; else this["email_ven_cliente"]= value;}
	}
	public object email_ven_clienteValue { 
		get{ return this["email_ven_cliente"];}
		set {if (value==null|| value==DBNull.Value) this["email_ven_cliente"]= DBNull.Value; else this["email_ven_cliente"]= value;}
	}
	public String email_ven_clienteOriginal { 
		get {if (this["email_ven_cliente",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["email_ven_cliente",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Fattura
///</summary>
public class invoiceTable : MetaTableBase<invoiceRow> {
	public invoiceTable() : base("invoice"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ninv",createColumn("ninv",typeof(int),false,false)},
			{"yinv",createColumn("yinv",typeof(short),false,false)},
			{"active",createColumn("active",typeof(string),true,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"doc",createColumn("doc",typeof(string),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"exchangerate",createColumn("exchangerate",typeof(double),true,false)},
			{"flagdeferred",createColumn("flagdeferred",typeof(string),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"officiallyprinted",createColumn("officiallyprinted",typeof(string),false,false)},
			{"packinglistdate",createColumn("packinglistdate",typeof(DateTime),true,false)},
			{"packinglistnum",createColumn("packinglistnum",typeof(string),true,false)},
			{"paymentexpiring",createColumn("paymentexpiring",typeof(short),true,false)},
			{"registryreference",createColumn("registryreference",typeof(string),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"idinvkind",createColumn("idinvkind",typeof(int),false,false)},
			{"idcurrency",createColumn("idcurrency",typeof(int),true,false)},
			{"idexpirationkind",createColumn("idexpirationkind",typeof(short),true,false)},
			{"idtreasurer",createColumn("idtreasurer",typeof(int),true,false)},
			{"flagintracom",createColumn("flagintracom",typeof(string),true,false)},
			{"iso_origin",createColumn("iso_origin",typeof(string),true,false)},
			{"iso_provenance",createColumn("iso_provenance",typeof(string),true,false)},
			{"iso_destination",createColumn("iso_destination",typeof(string),true,false)},
			{"idcountry_origin",createColumn("idcountry_origin",typeof(int),true,false)},
			{"idcountry_destination",createColumn("idcountry_destination",typeof(int),true,false)},
			{"idintrastatkind",createColumn("idintrastatkind",typeof(string),true,false)},
			{"idaccmotivedebit",createColumn("idaccmotivedebit",typeof(string),true,false)},
			{"idaccmotivedebit_crg",createColumn("idaccmotivedebit_crg",typeof(string),true,false)},
			{"idaccmotivedebit_datacrg",createColumn("idaccmotivedebit_datacrg",typeof(DateTime),true,false)},
			{"idintrastatpaymethod",createColumn("idintrastatpaymethod",typeof(int),true,false)},
			{"iso_payment",createColumn("iso_payment",typeof(string),true,false)},
			{"flag_ddt",createColumn("flag_ddt",typeof(string),true,false)},
			{"flag",createColumn("flag",typeof(int),true,false)},
			{"idblacklist",createColumn("idblacklist",typeof(int),true,false)},
			{"idinvkind_real",createColumn("idinvkind_real",typeof(int),true,false)},
			{"yinv_real",createColumn("yinv_real",typeof(short),true,false)},
			{"ninv_real",createColumn("ninv_real",typeof(int),true,false)},
			{"autoinvoice",createColumn("autoinvoice",typeof(string),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"protocoldate",createColumn("protocoldate",typeof(DateTime),true,false)},
			{"idfepaymethodcondition",createColumn("idfepaymethodcondition",typeof(string),true,false)},
			{"idfepaymethod",createColumn("idfepaymethod",typeof(string),true,false)},
			{"nelectronicinvoice",createColumn("nelectronicinvoice",typeof(int),true,false)},
			{"yelectronicinvoice",createColumn("yelectronicinvoice",typeof(short),true,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
			{"arrivalprotocolnum",createColumn("arrivalprotocolnum",typeof(string),true,false)},
			{"toincludeinpaymentindicator",createColumn("toincludeinpaymentindicator",typeof(string),true,false)},
			{"resendingpcc",createColumn("resendingpcc",typeof(string),true,false)},
			{"touniqueregister",createColumn("touniqueregister",typeof(string),true,false)},
			{"idstampkind",createColumn("idstampkind",typeof(string),true,false)},
			{"flag_auto_split_payment",createColumn("flag_auto_split_payment",typeof(string),true,false)},
			{"flag_enable_split_payment",createColumn("flag_enable_split_payment",typeof(string),true,false)},
			{"idsdi_acquisto",createColumn("idsdi_acquisto",typeof(int),true,false)},
			{"idsdi_vendita",createColumn("idsdi_vendita",typeof(int),true,false)},
			{"flag_reverse_charge",createColumn("flag_reverse_charge",typeof(string),true,false)},
			{"ipa_acq",createColumn("ipa_acq",typeof(string),true,false)},
			{"rifamm_acq",createColumn("rifamm_acq",typeof(string),true,false)},
			{"ipa_ven_emittente",createColumn("ipa_ven_emittente",typeof(string),true,false)},
			{"rifamm_ven_emittente",createColumn("rifamm_ven_emittente",typeof(string),true,false)},
			{"ipa_ven_cliente",createColumn("ipa_ven_cliente",typeof(string),true,false)},
			{"rifamm_ven_cliente",createColumn("rifamm_ven_cliente",typeof(string),true,false)},
			{"ssntipospesa",createColumn("ssntipospesa",typeof(string),true,false)},
			{"ssnflagtipospesa",createColumn("ssnflagtipospesa",typeof(string),true,false)},
			{"idinvkind_forwarder",createColumn("idinvkind_forwarder",typeof(int),true,false)},
			{"yinv_forwarder",createColumn("yinv_forwarder",typeof(short),true,false)},
			{"ninv_forwarder",createColumn("ninv_forwarder",typeof(int),true,false)},
			{"flagbit",createColumn("flagbit",typeof(byte),true,false)},
			{"ssn_nprot",createColumn("ssn_nprot",typeof(string),true,false)},
			{"requested_doc",createColumn("requested_doc",typeof(int),true,false)},
			{"idnocigmotive",createColumn("idnocigmotive",typeof(int),true,false)},
			{"idreg_sostituto",createColumn("idreg_sostituto",typeof(int),true,false)},
			{"pec_ven_cliente",createColumn("pec_ven_cliente",typeof(string),true,false)},
			{"email_ven_cliente",createColumn("email_ven_cliente",typeof(string),true,false)},
		};
	}
}
}
