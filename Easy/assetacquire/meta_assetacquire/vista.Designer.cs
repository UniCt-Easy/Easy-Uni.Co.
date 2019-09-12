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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
namespace meta_assetacquire {
public class assetacquireRow: MetaRow  {
	public assetacquireRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num. carico
	///</summary>
	public Int32? nassetacquire{ 
		get {if (this["nassetacquire"]==DBNull.Value)return null; return  (Int32?)this["nassetacquire"];}
		set {if (value==null) this["nassetacquire"]= DBNull.Value; else this["nassetacquire"]= value;}
	}
	public object nassetacquireValue { 
		get{ return this["nassetacquire"];}
		set {if (value==null|| value==DBNull.Value) this["nassetacquire"]= DBNull.Value; else this["nassetacquire"]= value;}
	}
	public Int32? nassetacquireOriginal { 
		get {if (this["nassetacquire",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nassetacquire",DataRowVersion.Original];}
	}
	///<summary>
	///IVA detraibile
	///</summary>
	public Decimal? abatable{ 
		get {if (this["abatable"]==DBNull.Value)return null; return  (Decimal?)this["abatable"];}
		set {if (value==null) this["abatable"]= DBNull.Value; else this["abatable"]= value;}
	}
	public object abatableValue { 
		get{ return this["abatable"];}
		set {if (value==null|| value==DBNull.Value) this["abatable"]= DBNull.Value; else this["abatable"]= value;}
	}
	public Decimal? abatableOriginal { 
		get {if (this["abatable",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["abatable",DataRowVersion.Original];}
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
	///sconto
	///</summary>
	public Double? discount{ 
		get {if (this["discount"]==DBNull.Value)return null; return  (Double?)this["discount"];}
		set {if (value==null) this["discount"]= DBNull.Value; else this["discount"]= value;}
	}
	public object discountValue { 
		get{ return this["discount"];}
		set {if (value==null|| value==DBNull.Value) this["discount"]= DBNull.Value; else this["discount"]= value;}
	}
	public Double? discountOriginal { 
		get {if (this["discount",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["discount",DataRowVersion.Original];}
	}
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
	///quantità
	///</summary>
	public Int32? number{ 
		get {if (this["number"]==DBNull.Value)return null; return  (Int32?)this["number"];}
		set {if (value==null) this["number"]= DBNull.Value; else this["number"]= value;}
	}
	public object numberValue { 
		get{ return this["number"];}
		set {if (value==null|| value==DBNull.Value) this["number"]= DBNull.Value; else this["number"]= value;}
	}
	public Int32? numberOriginal { 
		get {if (this["number",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["number",DataRowVersion.Original];}
	}
	///<summary>
	///N. riga contratto passivo ( Il collegamento al dettaglio Contratto Passivo viene fatto in termini di idgroup e non di rownum)
	///</summary>
	public Int32? rownum{ 
		get {if (this["rownum"]==DBNull.Value)return null; return  (Int32?)this["rownum"];}
		set {if (value==null) this["rownum"]= DBNull.Value; else this["rownum"]= value;}
	}
	public object rownumValue { 
		get{ return this["rownum"];}
		set {if (value==null|| value==DBNull.Value) this["rownum"]= DBNull.Value; else this["rownum"]= value;}
	}
	public Int32? rownumOriginal { 
		get {if (this["rownum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["rownum",DataRowVersion.Original];}
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
	///Num. iniziale
	///</summary>
	public Int32? startnumber{ 
		get {if (this["startnumber"]==DBNull.Value)return null; return  (Int32?)this["startnumber"];}
		set {if (value==null) this["startnumber"]= DBNull.Value; else this["startnumber"]= value;}
	}
	public object startnumberValue { 
		get{ return this["startnumber"];}
		set {if (value==null|| value==DBNull.Value) this["startnumber"]= DBNull.Value; else this["startnumber"]= value;}
	}
	public Int32? startnumberOriginal { 
		get {if (this["startnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["startnumber",DataRowVersion.Original];}
	}
	///<summary>
	///Nome imposta (tabella tax)
	///</summary>
	public Decimal? tax{ 
		get {if (this["tax"]==DBNull.Value)return null; return  (Decimal?)this["tax"];}
		set {if (value==null) this["tax"]= DBNull.Value; else this["tax"]= value;}
	}
	public object taxValue { 
		get{ return this["tax"];}
		set {if (value==null|| value==DBNull.Value) this["tax"]= DBNull.Value; else this["tax"]= value;}
	}
	public Decimal? taxOriginal { 
		get {if (this["tax",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["tax",DataRowVersion.Original];}
	}
	///<summary>
	///imponibile
	///</summary>
	public Decimal? taxable{ 
		get {if (this["taxable"]==DBNull.Value)return null; return  (Decimal?)this["taxable"];}
		set {if (value==null) this["taxable"]= DBNull.Value; else this["taxable"]= value;}
	}
	public object taxableValue { 
		get{ return this["taxable"];}
		set {if (value==null|| value==DBNull.Value) this["taxable"]= DBNull.Value; else this["taxable"]= value;}
	}
	public Decimal? taxableOriginal { 
		get {if (this["taxable",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["taxable",DataRowVersion.Original];}
	}
	///<summary>
	///Aliquota ritenuta
	///</summary>
	public Double? taxrate{ 
		get {if (this["taxrate"]==DBNull.Value)return null; return  (Double?)this["taxrate"];}
		set {if (value==null) this["taxrate"]= DBNull.Value; else this["taxrate"]= value;}
	}
	public object taxrateValue { 
		get{ return this["taxrate"];}
		set {if (value==null|| value==DBNull.Value) this["taxrate"]= DBNull.Value; else this["taxrate"]= value;}
	}
	public Double? taxrateOriginal { 
		get {if (this["taxrate",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["taxrate",DataRowVersion.Original];}
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
	///Trasmesso (non più usato)
	///</summary>
	public String transmitted{ 
		get {if (this["transmitted"]==DBNull.Value)return null; return  (String)this["transmitted"];}
		set {if (value==null) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public object transmittedValue { 
		get{ return this["transmitted"];}
		set {if (value==null|| value==DBNull.Value) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public String transmittedOriginal { 
		get {if (this["transmitted",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["transmitted",DataRowVersion.Original];}
	}
	///<summary>
	///id voce upb (tabella upb)
	///</summary>
	public String idupb{ 
		get {if (this["idupb"]==DBNull.Value)return null; return  (String)this["idupb"];}
		set {if (value==null) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public object idupbValue { 
		get{ return this["idupb"];}
		set {if (value==null|| value==DBNull.Value) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public String idupbOriginal { 
		get {if (this["idupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idupb",DataRowVersion.Original];}
	}
	///<summary>
	///Id inventario (tabella inventory)
	///</summary>
	public Int32? idinventory{ 
		get {if (this["idinventory"]==DBNull.Value)return null; return  (Int32?)this["idinventory"];}
		set {if (value==null) this["idinventory"]= DBNull.Value; else this["idinventory"]= value;}
	}
	public object idinventoryValue { 
		get{ return this["idinventory"];}
		set {if (value==null|| value==DBNull.Value) this["idinventory"]= DBNull.Value; else this["idinventory"]= value;}
	}
	public Int32? idinventoryOriginal { 
		get {if (this["idinventory",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinventory",DataRowVersion.Original];}
	}
	///<summary>
	///Id causale (tabella motive)
	///</summary>
	public Int32? idmot{ 
		get {if (this["idmot"]==DBNull.Value)return null; return  (Int32?)this["idmot"];}
		set {if (value==null) this["idmot"]= DBNull.Value; else this["idmot"]= value;}
	}
	public object idmotValue { 
		get{ return this["idmot"];}
		set {if (value==null|| value==DBNull.Value) this["idmot"]= DBNull.Value; else this["idmot"]= value;}
	}
	public Int32? idmotOriginal { 
		get {if (this["idmot",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idmot",DataRowVersion.Original];}
	}
	///<summary>
	///ID class. inventariale (tabella inventorytree)
	///</summary>
	public Int32? idinv{ 
		get {if (this["idinv"]==DBNull.Value)return null; return  (Int32?)this["idinv"];}
		set {if (value==null) this["idinv"]= DBNull.Value; else this["idinv"]= value;}
	}
	public object idinvValue { 
		get{ return this["idinv"];}
		set {if (value==null|| value==DBNull.Value) this["idinv"]= DBNull.Value; else this["idinv"]= value;}
	}
	public Int32? idinvOriginal { 
		get {if (this["idinv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinv",DataRowVersion.Original];}
	}
	///<summary>
	///id buono carico (tabella assetload)
	///</summary>
	public Int32? idassetload{ 
		get {if (this["idassetload"]==DBNull.Value)return null; return  (Int32?)this["idassetload"];}
		set {if (value==null) this["idassetload"]= DBNull.Value; else this["idassetload"]= value;}
	}
	public object idassetloadValue { 
		get{ return this["idassetload"];}
		set {if (value==null|| value==DBNull.Value) this["idassetload"]= DBNull.Value; else this["idassetload"]= value;}
	}
	public Int32? idassetloadOriginal { 
		get {if (this["idassetload",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idassetload",DataRowVersion.Original];}
	}
	///<summary>
	///flag su tipo carico
	///</summary>
	public Byte? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Byte?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Byte? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flag",DataRowVersion.Original];}
	}
	///<summary>
	///id voce analitica 1(tabella sorting)
	///</summary>
	public Int32? idsor1{ 
		get {if (this["idsor1"]==DBNull.Value)return null; return  (Int32?)this["idsor1"];}
		set {if (value==null) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public object idsor1Value { 
		get{ return this["idsor1"];}
		set {if (value==null|| value==DBNull.Value) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public Int32? idsor1Original { 
		get {if (this["idsor1",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor1",DataRowVersion.Original];}
	}
	///<summary>
	///id voce analitica 2(tabella sorting)
	///</summary>
	public Int32? idsor2{ 
		get {if (this["idsor2"]==DBNull.Value)return null; return  (Int32?)this["idsor2"];}
		set {if (value==null) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public object idsor2Value { 
		get{ return this["idsor2"];}
		set {if (value==null|| value==DBNull.Value) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public Int32? idsor2Original { 
		get {if (this["idsor2",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor2",DataRowVersion.Original];}
	}
	///<summary>
	///id voce analitica 3(tabella sorting)
	///</summary>
	public Int32? idsor3{ 
		get {if (this["idsor3"]==DBNull.Value)return null; return  (Int32?)this["idsor3"];}
		set {if (value==null) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public object idsor3Value { 
		get{ return this["idsor3"];}
		set {if (value==null|| value==DBNull.Value) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public Int32? idsor3Original { 
		get {if (this["idsor3",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor3",DataRowVersion.Original];}
	}
	///<summary>
	///Valore iniziale storico ai fini dell'ammortamento. Può differire dal valore iniziale se si tratta di un cespite proveniente da altri dipartimenti e caricato inizialmente con un valore diverso. Il valore iniziale storico è quello con cui è stato inserito la prima volta nel patrimonio.
	///</summary>
	public Decimal? historicalvalue{ 
		get {if (this["historicalvalue"]==DBNull.Value)return null; return  (Decimal?)this["historicalvalue"];}
		set {if (value==null) this["historicalvalue"]= DBNull.Value; else this["historicalvalue"]= value;}
	}
	public object historicalvalueValue { 
		get{ return this["historicalvalue"];}
		set {if (value==null|| value==DBNull.Value) this["historicalvalue"]= DBNull.Value; else this["historicalvalue"]= value;}
	}
	public Decimal? historicalvalueOriginal { 
		get {if (this["historicalvalue",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["historicalvalue",DataRowVersion.Original];}
	}
	///<summary>
	///voce di listino del magazzino (tabella list)
	///</summary>
	public Int32? idlist{ 
		get {if (this["idlist"]==DBNull.Value)return null; return  (Int32?)this["idlist"];}
		set {if (value==null) this["idlist"]= DBNull.Value; else this["idlist"]= value;}
	}
	public object idlistValue { 
		get{ return this["idlist"];}
		set {if (value==null|| value==DBNull.Value) this["idlist"]= DBNull.Value; else this["idlist"]= value;}
	}
	public Int32? idlistOriginal { 
		get {if (this["idlist",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlist",DataRowVersion.Original];}
	}
	///<summary>
	///esercizio fattura
	///</summary>
	public Int16? yinv{ 
		get {if (this["yinv"]==DBNull.Value)return null; return  (Int16?)this["yinv"];}
		set {if (value==null) this["yinv"]= DBNull.Value; else this["yinv"]= value;}
	}
	public object yinvValue { 
		get{ return this["yinv"];}
		set {if (value==null|| value==DBNull.Value) this["yinv"]= DBNull.Value; else this["yinv"]= value;}
	}
	public Int16? yinvOriginal { 
		get {if (this["yinv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yinv",DataRowVersion.Original];}
	}
	///<summary>
	///n. fattura
	///</summary>
	public Int32? ninv{ 
		get {if (this["ninv"]==DBNull.Value)return null; return  (Int32?)this["ninv"];}
		set {if (value==null) this["ninv"]= DBNull.Value; else this["ninv"]= value;}
	}
	public object ninvValue { 
		get{ return this["ninv"];}
		set {if (value==null|| value==DBNull.Value) this["ninv"]= DBNull.Value; else this["ninv"]= value;}
	}
	public Int32? ninvOriginal { 
		get {if (this["ninv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ninv",DataRowVersion.Original];}
	}
	///<summary>
	///id tipo fattura (tabella invoicekind)
	///</summary>
	public Int32? idinvkind{ 
		get {if (this["idinvkind"]==DBNull.Value)return null; return  (Int32?)this["idinvkind"];}
		set {if (value==null) this["idinvkind"]= DBNull.Value; else this["idinvkind"]= value;}
	}
	public object idinvkindValue { 
		get{ return this["idinvkind"];}
		set {if (value==null|| value==DBNull.Value) this["idinvkind"]= DBNull.Value; else this["idinvkind"]= value;}
	}
	public Int32? idinvkindOriginal { 
		get {if (this["idinvkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinvkind",DataRowVersion.Original];}
	}
	///<summary>
	///N. riga fattura ( Il collegamento al dettaglio fattura viene fatto in termini di idgroup e non di rownum, così come avviene per il CP.)
	///</summary>
	public Int32? invrownum{ 
		get {if (this["invrownum"]==DBNull.Value)return null; return  (Int32?)this["invrownum"];}
		set {if (value==null) this["invrownum"]= DBNull.Value; else this["invrownum"]= value;}
	}
	public object invrownumValue { 
		get{ return this["invrownum"];}
		set {if (value==null|| value==DBNull.Value) this["invrownum"]= DBNull.Value; else this["invrownum"]= value;}
	}
	public Int32? invrownumOriginal { 
		get {if (this["invrownum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["invrownum",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Carico dei cespiti da bolla/fattura
///</summary>
public class assetacquireTable : MetaTableBase<assetacquireRow> {
	public assetacquireTable() : base("assetacquire"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nassetacquire",createColumn("nassetacquire",typeof(Int32),false,false)},
			{"abatable",createColumn("abatable",typeof(Decimal),true,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"description",createColumn("description",typeof(String),false,false)},
			{"discount",createColumn("discount",typeof(Double),true,false)},
			{"idmankind",createColumn("idmankind",typeof(String),true,false)},
			{"idreg",createColumn("idreg",typeof(Int32),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"nman",createColumn("nman",typeof(Int32),true,false)},
			{"number",createColumn("number",typeof(Int32),false,false)},
			{"rownum",createColumn("rownum",typeof(Int32),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"startnumber",createColumn("startnumber",typeof(Int32),true,false)},
			{"tax",createColumn("tax",typeof(Decimal),true,false)},
			{"taxable",createColumn("taxable",typeof(Decimal),true,false)},
			{"taxrate",createColumn("taxrate",typeof(Double),true,false)},
			{"txt",createColumn("txt",typeof(String),true,false)},
			{"yman",createColumn("yman",typeof(Int16),true,false)},
			{"transmitted",createColumn("transmitted",typeof(String),true,false)},
			{"idupb",createColumn("idupb",typeof(String),true,false)},
			{"idinventory",createColumn("idinventory",typeof(Int32),false,false)},
			{"idmot",createColumn("idmot",typeof(Int32),false,false)},
			{"idinv",createColumn("idinv",typeof(Int32),false,false)},
			{"idassetload",createColumn("idassetload",typeof(Int32),true,false)},
			{"flag",createColumn("flag",typeof(Byte),false,false)},
			{"idsor1",createColumn("idsor1",typeof(Int32),true,false)},
			{"idsor2",createColumn("idsor2",typeof(Int32),true,false)},
			{"idsor3",createColumn("idsor3",typeof(Int32),true,false)},
			{"historicalvalue",createColumn("historicalvalue",typeof(Decimal),true,false)},
			{"idlist",createColumn("idlist",typeof(Int32),true,false)},
			{"yinv",createColumn("yinv",typeof(Int16),true,false)},
			{"ninv",createColumn("ninv",typeof(Int32),true,false)},
			{"idinvkind",createColumn("idinvkind",typeof(Int32),true,false)},
			{"invrownum",createColumn("invrownum",typeof(Int32),true,false)},
		};
	}
}
}
