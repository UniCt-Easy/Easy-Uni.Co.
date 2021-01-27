
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
namespace meta_mandatedetail {
public class mandatedetailRow: MetaRow  {
	public mandatedetailRow(DataRowBuilder rb) : base(rb) {} 

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
	///N. riga
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
	///Tipo cespite
	///</summary>
	public String assetkind{ 
		get {if (this["assetkind"]==DBNull.Value)return null; return  (String)this["assetkind"];}
		set {if (value==null) this["assetkind"]= DBNull.Value; else this["assetkind"]= value;}
	}
	public object assetkindValue { 
		get{ return this["assetkind"];}
		set {if (value==null|| value==DBNull.Value) this["assetkind"]= DBNull.Value; else this["assetkind"]= value;}
	}
	public String assetkindOriginal { 
		get {if (this["assetkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["assetkind",DataRowVersion.Original];}
	}
	///<summary>
	///Data inizio competenza
	///</summary>
	public DateTime? competencystart{ 
		get {if (this["competencystart"]==DBNull.Value)return null; return  (DateTime?)this["competencystart"];}
		set {if (value==null) this["competencystart"]= DBNull.Value; else this["competencystart"]= value;}
	}
	public object competencystartValue { 
		get{ return this["competencystart"];}
		set {if (value==null|| value==DBNull.Value) this["competencystart"]= DBNull.Value; else this["competencystart"]= value;}
	}
	public DateTime? competencystartOriginal { 
		get {if (this["competencystart",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["competencystart",DataRowVersion.Original];}
	}
	///<summary>
	///Data fine competenza
	///</summary>
	public DateTime? competencystop{ 
		get {if (this["competencystop"]==DBNull.Value)return null; return  (DateTime?)this["competencystop"];}
		set {if (value==null) this["competencystop"]= DBNull.Value; else this["competencystop"]= value;}
	}
	public object competencystopValue { 
		get{ return this["competencystop"];}
		set {if (value==null|| value==DBNull.Value) this["competencystop"]= DBNull.Value; else this["competencystop"]= value;}
	}
	public DateTime? competencystopOriginal { 
		get {if (this["competencystop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["competencystop",DataRowVersion.Original];}
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
	///Descrizione dettaglio
	///</summary>
	public String detaildescription{ 
		get {if (this["detaildescription"]==DBNull.Value)return null; return  (String)this["detaildescription"];}
		set {if (value==null) this["detaildescription"]= DBNull.Value; else this["detaildescription"]= value;}
	}
	public object detaildescriptionValue { 
		get{ return this["detaildescription"];}
		set {if (value==null|| value==DBNull.Value) this["detaildescription"]= DBNull.Value; else this["detaildescription"]= value;}
	}
	public String detaildescriptionOriginal { 
		get {if (this["detaildescription",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["detaildescription",DataRowVersion.Original];}
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
	///non usato
	///</summary>
	public Decimal? ninvoiced{ 
		get {if (this["ninvoiced"]==DBNull.Value)return null; return  (Decimal?)this["ninvoiced"];}
		set {if (value==null) this["ninvoiced"]= DBNull.Value; else this["ninvoiced"]= value;}
	}
	public object ninvoicedValue { 
		get{ return this["ninvoiced"];}
		set {if (value==null|| value==DBNull.Value) this["ninvoiced"]= DBNull.Value; else this["ninvoiced"]= value;}
	}
	public Decimal? ninvoicedOriginal { 
		get {if (this["ninvoiced",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["ninvoiced",DataRowVersion.Original];}
	}
	///<summary>
	///quantità
	///</summary>
	public Decimal? number{ 
		get {if (this["number"]==DBNull.Value)return null; return  (Decimal?)this["number"];}
		set {if (value==null) this["number"]= DBNull.Value; else this["number"]= value;}
	}
	public object numberValue { 
		get{ return this["number"];}
		set {if (value==null|| value==DBNull.Value) this["number"]= DBNull.Value; else this["number"]= value;}
	}
	public Decimal? numberOriginal { 
		get {if (this["number",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["number",DataRowVersion.Original];}
	}
	///<summary>
	///data inizio
	///</summary>
	public DateTime? start{ 
		get {if (this["start"]==DBNull.Value)return null; return  (DateTime?)this["start"];}
		set {if (value==null) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public object startValue { 
		get{ return this["start"];}
		set {if (value==null|| value==DBNull.Value) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public DateTime? startOriginal { 
		get {if (this["start",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["start",DataRowVersion.Original];}
	}
	///<summary>
	///data fine
	///</summary>
	public DateTime? stop{ 
		get {if (this["stop"]==DBNull.Value)return null; return  (DateTime?)this["stop"];}
		set {if (value==null) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public object stopValue { 
		get{ return this["stop"];}
		set {if (value==null|| value==DBNull.Value) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public DateTime? stopOriginal { 
		get {if (this["stop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["stop",DataRowVersion.Original];}
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
	///Da proporre in fattura
	///</summary>
	public String toinvoice{ 
		get {if (this["toinvoice"]==DBNull.Value)return null; return  (String)this["toinvoice"];}
		set {if (value==null) this["toinvoice"]= DBNull.Value; else this["toinvoice"]= value;}
	}
	public object toinvoiceValue { 
		get{ return this["toinvoice"];}
		set {if (value==null|| value==DBNull.Value) this["toinvoice"]= DBNull.Value; else this["toinvoice"]= value;}
	}
	public String toinvoiceOriginal { 
		get {if (this["toinvoice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["toinvoice",DataRowVersion.Original];}
	}
	///<summary>
	///Promiscuo (campo non più utilizzato)
	///</summary>
	public String flagmixed{ 
		get {if (this["flagmixed"]==DBNull.Value)return null; return  (String)this["flagmixed"];}
		set {if (value==null) this["flagmixed"]= DBNull.Value; else this["flagmixed"]= value;}
	}
	public object flagmixedValue { 
		get{ return this["flagmixed"];}
		set {if (value==null|| value==DBNull.Value) this["flagmixed"]= DBNull.Value; else this["flagmixed"]= value;}
	}
	public String flagmixedOriginal { 
		get {if (this["flagmixed",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagmixed",DataRowVersion.Original];}
	}
	///<summary>
	///id causale (tabella acccmotive)
	///</summary>
	public String idaccmotive{ 
		get {if (this["idaccmotive"]==DBNull.Value)return null; return  (String)this["idaccmotive"];}
		set {if (value==null) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public object idaccmotiveValue { 
		get{ return this["idaccmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public String idaccmotiveOriginal { 
		get {if (this["idaccmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive",DataRowVersion.Original];}
	}
	///<summary>
	///Iva indetraibile
	///</summary>
	public Decimal? unabatable{ 
		get {if (this["unabatable"]==DBNull.Value)return null; return  (Decimal?)this["unabatable"];}
		set {if (value==null) this["unabatable"]= DBNull.Value; else this["unabatable"]= value;}
	}
	public object unabatableValue { 
		get{ return this["unabatable"];}
		set {if (value==null|| value==DBNull.Value) this["unabatable"]= DBNull.Value; else this["unabatable"]= value;}
	}
	public Decimal? unabatableOriginal { 
		get {if (this["unabatable",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["unabatable",DataRowVersion.Original];}
	}
	///<summary>
	///n. raggruppamento dettagli
	///</summary>
	public Int32? idgroup{ 
		get {if (this["idgroup"]==DBNull.Value)return null; return  (Int32?)this["idgroup"];}
		set {if (value==null) this["idgroup"]= DBNull.Value; else this["idgroup"]= value;}
	}
	public object idgroupValue { 
		get{ return this["idgroup"];}
		set {if (value==null|| value==DBNull.Value) this["idgroup"]= DBNull.Value; else this["idgroup"]= value;}
	}
	public Int32? idgroupOriginal { 
		get {if (this["idgroup",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idgroup",DataRowVersion.Original];}
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
	///id mov. spesa che contabilizza l'impegno dell'imponibile
	///</summary>
	public Int32? idexp_taxable{ 
		get {if (this["idexp_taxable"]==DBNull.Value)return null; return  (Int32?)this["idexp_taxable"];}
		set {if (value==null) this["idexp_taxable"]= DBNull.Value; else this["idexp_taxable"]= value;}
	}
	public object idexp_taxableValue { 
		get{ return this["idexp_taxable"];}
		set {if (value==null|| value==DBNull.Value) this["idexp_taxable"]= DBNull.Value; else this["idexp_taxable"]= value;}
	}
	public Int32? idexp_taxableOriginal { 
		get {if (this["idexp_taxable",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idexp_taxable",DataRowVersion.Original];}
	}
	///<summary>
	///id mov. spesa che contabilizza l'impegno dell'iva
	///</summary>
	public Int32? idexp_iva{ 
		get {if (this["idexp_iva"]==DBNull.Value)return null; return  (Int32?)this["idexp_iva"];}
		set {if (value==null) this["idexp_iva"]= DBNull.Value; else this["idexp_iva"]= value;}
	}
	public object idexp_ivaValue { 
		get{ return this["idexp_iva"];}
		set {if (value==null|| value==DBNull.Value) this["idexp_iva"]= DBNull.Value; else this["idexp_iva"]= value;}
	}
	public Int32? idexp_ivaOriginal { 
		get {if (this["idexp_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idexp_iva",DataRowVersion.Original];}
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
	///id tipo iva (tabella ivakind)
	///</summary>
	public Int32? idivakind{ 
		get {if (this["idivakind"]==DBNull.Value)return null; return  (Int32?)this["idivakind"];}
		set {if (value==null) this["idivakind"]= DBNull.Value; else this["idivakind"]= value;}
	}
	public object idivakindValue { 
		get{ return this["idivakind"];}
		set {if (value==null|| value==DBNull.Value) this["idivakind"]= DBNull.Value; else this["idivakind"]= value;}
	}
	public Int32? idivakindOriginal { 
		get {if (this["idivakind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idivakind",DataRowVersion.Original];}
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
	///causale di annullamento
	///</summary>
	public String idaccmotiveannulment{ 
		get {if (this["idaccmotiveannulment"]==DBNull.Value)return null; return  (String)this["idaccmotiveannulment"];}
		set {if (value==null) this["idaccmotiveannulment"]= DBNull.Value; else this["idaccmotiveannulment"]= value;}
	}
	public object idaccmotiveannulmentValue { 
		get{ return this["idaccmotiveannulment"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotiveannulment"]= DBNull.Value; else this["idaccmotiveannulment"]= value;}
	}
	public String idaccmotiveannulmentOriginal { 
		get {if (this["idaccmotiveannulment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotiveannulment",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo attività
	///	 1: Qualsiasi/Non specificata
	///	 2: Commerciale
	///	 3: Promiscua
	///	 4: Qualsiasi/Non specificata
	///</summary>
	public Int16? flagactivity{ 
		get {if (this["flagactivity"]==DBNull.Value)return null; return  (Int16?)this["flagactivity"];}
		set {if (value==null) this["flagactivity"]= DBNull.Value; else this["flagactivity"]= value;}
	}
	public object flagactivityValue { 
		get{ return this["flagactivity"];}
		set {if (value==null|| value==DBNull.Value) this["flagactivity"]= DBNull.Value; else this["flagactivity"]= value;}
	}
	public Int16? flagactivityOriginal { 
		get {if (this["flagactivity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["flagactivity",DataRowVersion.Original];}
	}
	///<summary>
	///quadro VF (beni ammortizzabili / strumentali / destinati alla rivendita / altri acquisti)
	///	 A: Altiri acquisti
	///	 N: Beni strumentali non ammortizzabili
	///	 R: Beni destinati alla rivendita
	///	 S: Beni ammortizzabili
	///</summary>
	public String va3type{ 
		get {if (this["va3type"]==DBNull.Value)return null; return  (String)this["va3type"];}
		set {if (value==null) this["va3type"]= DBNull.Value; else this["va3type"]= value;}
	}
	public object va3typeValue { 
		get{ return this["va3type"];}
		set {if (value==null|| value==DBNull.Value) this["va3type"]= DBNull.Value; else this["va3type"]= value;}
	}
	public String va3typeOriginal { 
		get {if (this["va3type",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["va3type",DataRowVersion.Original];}
	}
	///<summary>
	///Note del richiedente - questo campo non è usato, è usato quello di mandate
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
	///note sull'iva
	///</summary>
	public String ivanotes{ 
		get {if (this["ivanotes"]==DBNull.Value)return null; return  (String)this["ivanotes"];}
		set {if (value==null) this["ivanotes"]= DBNull.Value; else this["ivanotes"]= value;}
	}
	public object ivanotesValue { 
		get{ return this["ivanotes"];}
		set {if (value==null|| value==DBNull.Value) this["ivanotes"]= DBNull.Value; else this["ivanotes"]= value;}
	}
	public String ivanotesOriginal { 
		get {if (this["ivanotes",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ivanotes",DataRowVersion.Original];}
	}
	///<summary>
	///chiave listino (tabella list)
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
	///id unità di misura (tabella unit)
	///</summary>
	public Int32? idunit{ 
		get {if (this["idunit"]==DBNull.Value)return null; return  (Int32?)this["idunit"];}
		set {if (value==null) this["idunit"]= DBNull.Value; else this["idunit"]= value;}
	}
	public object idunitValue { 
		get{ return this["idunit"];}
		set {if (value==null|| value==DBNull.Value) this["idunit"]= DBNull.Value; else this["idunit"]= value;}
	}
	public Int32? idunitOriginal { 
		get {if (this["idunit",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idunit",DataRowVersion.Original];}
	}
	///<summary>
	///Id confezione (tabella package)
	///</summary>
	public Int32? idpackage{ 
		get {if (this["idpackage"]==DBNull.Value)return null; return  (Int32?)this["idpackage"];}
		set {if (value==null) this["idpackage"]= DBNull.Value; else this["idpackage"]= value;}
	}
	public object idpackageValue { 
		get{ return this["idpackage"];}
		set {if (value==null|| value==DBNull.Value) this["idpackage"]= DBNull.Value; else this["idpackage"]= value;}
	}
	public Int32? idpackageOriginal { 
		get {if (this["idpackage",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpackage",DataRowVersion.Original];}
	}
	///<summary>
	///N. unità per confezione
	///</summary>
	public Int32? unitsforpackage{ 
		get {if (this["unitsforpackage"]==DBNull.Value)return null; return  (Int32?)this["unitsforpackage"];}
		set {if (value==null) this["unitsforpackage"]= DBNull.Value; else this["unitsforpackage"]= value;}
	}
	public object unitsforpackageValue { 
		get{ return this["unitsforpackage"];}
		set {if (value==null|| value==DBNull.Value) this["unitsforpackage"]= DBNull.Value; else this["unitsforpackage"]= value;}
	}
	public Int32? unitsforpackageOriginal { 
		get {if (this["unitsforpackage",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["unitsforpackage",DataRowVersion.Original];}
	}
	///<summary>
	///Q.tà
	///</summary>
	public Decimal? npackage{ 
		get {if (this["npackage"]==DBNull.Value)return null; return  (Decimal?)this["npackage"];}
		set {if (value==null) this["npackage"]= DBNull.Value; else this["npackage"]= value;}
	}
	public object npackageValue { 
		get{ return this["npackage"];}
		set {if (value==null|| value==DBNull.Value) this["npackage"]= DBNull.Value; else this["npackage"]= value;}
	}
	public Decimal? npackageOriginal { 
		get {if (this["npackage",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["npackage",DataRowVersion.Original];}
	}
	///<summary>
	///Codice CUP
	///</summary>
	public String cupcode{ 
		get {if (this["cupcode"]==DBNull.Value)return null; return  (String)this["cupcode"];}
		set {if (value==null) this["cupcode"]= DBNull.Value; else this["cupcode"]= value;}
	}
	public object cupcodeValue { 
		get{ return this["cupcode"];}
		set {if (value==null|| value==DBNull.Value) this["cupcode"]= DBNull.Value; else this["cupcode"]= value;}
	}
	public String cupcodeOriginal { 
		get {if (this["cupcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cupcode",DataRowVersion.Original];}
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
	///flag Da inserire in buono scarico
	///	 N: Non è da inserire in buono scarico
	///	 S: Da inserire in buono scarico
	///</summary>
	public String flagto_unload{ 
		get {if (this["flagto_unload"]==DBNull.Value)return null; return  (String)this["flagto_unload"];}
		set {if (value==null) this["flagto_unload"]= DBNull.Value; else this["flagto_unload"]= value;}
	}
	public object flagto_unloadValue { 
		get{ return this["flagto_unload"];}
		set {if (value==null|| value==DBNull.Value) this["flagto_unload"]= DBNull.Value; else this["flagto_unload"]= value;}
	}
	public String flagto_unloadOriginal { 
		get {if (this["flagto_unload",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagto_unload",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo EP
	///	 F: Fattura da ricevere
	///	 N: Non generare ratei o scritture automatiche a fine anno
	///	 S: Genera rateo
	///</summary>
	public String epkind{ 
		get {if (this["epkind"]==DBNull.Value)return null; return  (String)this["epkind"];}
		set {if (value==null) this["epkind"]= DBNull.Value; else this["epkind"]= value;}
	}
	public object epkindValue { 
		get{ return this["epkind"];}
		set {if (value==null|| value==DBNull.Value) this["epkind"]= DBNull.Value; else this["epkind"]= value;}
	}
	public String epkindOriginal { 
		get {if (this["epkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["epkind",DataRowVersion.Original];}
	}
	///<summary>
	///n. riga di provenienza da richiesta ordine
	///</summary>
	public Int32? rownum_origin{ 
		get {if (this["rownum_origin"]==DBNull.Value)return null; return  (Int32?)this["rownum_origin"];}
		set {if (value==null) this["rownum_origin"]= DBNull.Value; else this["rownum_origin"]= value;}
	}
	public object rownum_originValue { 
		get{ return this["rownum_origin"];}
		set {if (value==null|| value==DBNull.Value) this["rownum_origin"]= DBNull.Value; else this["rownum_origin"]= value;}
	}
	public Int32? rownum_originOriginal { 
		get {if (this["rownum_origin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["rownum_origin",DataRowVersion.Original];}
	}
	///<summary>
	///non più usato
	///</summary>
	public Decimal? contractamount{ 
		get {if (this["contractamount"]==DBNull.Value)return null; return  (Decimal?)this["contractamount"];}
		set {if (value==null) this["contractamount"]= DBNull.Value; else this["contractamount"]= value;}
	}
	public object contractamountValue { 
		get{ return this["contractamount"];}
		set {if (value==null|| value==DBNull.Value) this["contractamount"]= DBNull.Value; else this["contractamount"]= value;}
	}
	public Decimal? contractamountOriginal { 
		get {if (this["contractamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["contractamount",DataRowVersion.Original];}
	}
	///<summary>
	///idavcp del partecipante che si è aggiudicato il lotto
	///</summary>
	public Int32? idavcp{ 
		get {if (this["idavcp"]==DBNull.Value)return null; return  (Int32?)this["idavcp"];}
		set {if (value==null) this["idavcp"]= DBNull.Value; else this["idavcp"]= value;}
	}
	public object idavcpValue { 
		get{ return this["idavcp"];}
		set {if (value==null|| value==DBNull.Value) this["idavcp"]= DBNull.Value; else this["idavcp"]= value;}
	}
	public Int32? idavcpOriginal { 
		get {if (this["idavcp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idavcp",DataRowVersion.Original];}
	}
	///<summary>
	///non più usato
	///</summary>
	public Int32? idavcp_choice{ 
		get {if (this["idavcp_choice"]==DBNull.Value)return null; return  (Int32?)this["idavcp_choice"];}
		set {if (value==null) this["idavcp_choice"]= DBNull.Value; else this["idavcp_choice"]= value;}
	}
	public object idavcp_choiceValue { 
		get{ return this["idavcp_choice"];}
		set {if (value==null|| value==DBNull.Value) this["idavcp_choice"]= DBNull.Value; else this["idavcp_choice"]= value;}
	}
	public Int32? idavcp_choiceOriginal { 
		get {if (this["idavcp_choice",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idavcp_choice",DataRowVersion.Original];}
	}
	///<summary>
	///non più usato
	///</summary>
	public DateTime? avcp_startcontract{ 
		get {if (this["avcp_startcontract"]==DBNull.Value)return null; return  (DateTime?)this["avcp_startcontract"];}
		set {if (value==null) this["avcp_startcontract"]= DBNull.Value; else this["avcp_startcontract"]= value;}
	}
	public object avcp_startcontractValue { 
		get{ return this["avcp_startcontract"];}
		set {if (value==null|| value==DBNull.Value) this["avcp_startcontract"]= DBNull.Value; else this["avcp_startcontract"]= value;}
	}
	public DateTime? avcp_startcontractOriginal { 
		get {if (this["avcp_startcontract",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["avcp_startcontract",DataRowVersion.Original];}
	}
	///<summary>
	///non più usato
	///</summary>
	public DateTime? avcp_stopcontract{ 
		get {if (this["avcp_stopcontract"]==DBNull.Value)return null; return  (DateTime?)this["avcp_stopcontract"];}
		set {if (value==null) this["avcp_stopcontract"]= DBNull.Value; else this["avcp_stopcontract"]= value;}
	}
	public object avcp_stopcontractValue { 
		get{ return this["avcp_stopcontract"];}
		set {if (value==null|| value==DBNull.Value) this["avcp_stopcontract"]= DBNull.Value; else this["avcp_stopcontract"]= value;}
	}
	public DateTime? avcp_stopcontractOriginal { 
		get {if (this["avcp_stopcontract",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["avcp_stopcontract",DataRowVersion.Original];}
	}
	///<summary>
	///non più usato
	///</summary>
	public String avcp_description{ 
		get {if (this["avcp_description"]==DBNull.Value)return null; return  (String)this["avcp_description"];}
		set {if (value==null) this["avcp_description"]= DBNull.Value; else this["avcp_description"]= value;}
	}
	public object avcp_descriptionValue { 
		get{ return this["avcp_description"];}
		set {if (value==null|| value==DBNull.Value) this["avcp_description"]= DBNull.Value; else this["avcp_description"]= value;}
	}
	public String avcp_descriptionOriginal { 
		get {if (this["avcp_description",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["avcp_description",DataRowVersion.Original];}
	}
	///<summary>
	///id causale debito pcc (tabella pccdebitmotive)
	///</summary>
	public String idpccdebitmotive{ 
		get {if (this["idpccdebitmotive"]==DBNull.Value)return null; return  (String)this["idpccdebitmotive"];}
		set {if (value==null) this["idpccdebitmotive"]= DBNull.Value; else this["idpccdebitmotive"]= value;}
	}
	public object idpccdebitmotiveValue { 
		get{ return this["idpccdebitmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idpccdebitmotive"]= DBNull.Value; else this["idpccdebitmotive"]= value;}
	}
	public String idpccdebitmotiveOriginal { 
		get {if (this["idpccdebitmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idpccdebitmotive",DataRowVersion.Original];}
	}
	///<summary>
	///id stato debito (tabella pccdebitstatus)
	///</summary>
	public String idpccdebitstatus{ 
		get {if (this["idpccdebitstatus"]==DBNull.Value)return null; return  (String)this["idpccdebitstatus"];}
		set {if (value==null) this["idpccdebitstatus"]= DBNull.Value; else this["idpccdebitstatus"]= value;}
	}
	public object idpccdebitstatusValue { 
		get{ return this["idpccdebitstatus"];}
		set {if (value==null|| value==DBNull.Value) this["idpccdebitstatus"]= DBNull.Value; else this["idpccdebitstatus"]= value;}
	}
	public String idpccdebitstatusOriginal { 
		get {if (this["idpccdebitstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idpccdebitstatus",DataRowVersion.Original];}
	}
	///<summary>
	///id ripartizione dei costi (tabella costpartition)
	///</summary>
	public Int32? idcostpartition{ 
		get {if (this["idcostpartition"]==DBNull.Value)return null; return  (Int32?)this["idcostpartition"];}
		set {if (value==null) this["idcostpartition"]= DBNull.Value; else this["idcostpartition"]= value;}
	}
	public object idcostpartitionValue { 
		get{ return this["idcostpartition"];}
		set {if (value==null|| value==DBNull.Value) this["idcostpartition"]= DBNull.Value; else this["idcostpartition"]= value;}
	}
	public Int32? idcostpartitionOriginal { 
		get {if (this["idcostpartition",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcostpartition",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo spesa PCC (COrrente o CApitale)
	///</summary>
	public String expensekind{ 
		get {if (this["expensekind"]==DBNull.Value)return null; return  (String)this["expensekind"];}
		set {if (value==null) this["expensekind"]= DBNull.Value; else this["expensekind"]= value;}
	}
	public object expensekindValue { 
		get{ return this["expensekind"];}
		set {if (value==null|| value==DBNull.Value) this["expensekind"]= DBNull.Value; else this["expensekind"]= value;}
	}
	public String expensekindOriginal { 
		get {if (this["expensekind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["expensekind",DataRowVersion.Original];}
	}
	///<summary>
	///id impegno di budget (tabella epexp)
	///</summary>
	public Int32? idepexp{ 
		get {if (this["idepexp"]==DBNull.Value)return null; return  (Int32?)this["idepexp"];}
		set {if (value==null) this["idepexp"]= DBNull.Value; else this["idepexp"]= value;}
	}
	public object idepexpValue { 
		get{ return this["idepexp"];}
		set {if (value==null|| value==DBNull.Value) this["idepexp"]= DBNull.Value; else this["idepexp"]= value;}
	}
	public Int32? idepexpOriginal { 
		get {if (this["idepexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepexp",DataRowVersion.Original];}
	}
	///<summary>
	///id accertamento di budget (tabella epacc)
	///</summary>
	public Int32? idepacc{ 
		get {if (this["idepacc"]==DBNull.Value)return null; return  (Int32?)this["idepacc"];}
		set {if (value==null) this["idepacc"]= DBNull.Value; else this["idepacc"]= value;}
	}
	public object idepaccValue { 
		get{ return this["idepacc"];}
		set {if (value==null|| value==DBNull.Value) this["idepacc"]= DBNull.Value; else this["idepacc"]= value;}
	}
	public Int32? idepaccOriginal { 
		get {if (this["idepacc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepacc",DataRowVersion.Original];}
	}
	///<summary>
	///ubicazione prefissata del bene 
	///</summary>
	public Int32? idlocation{ 
		get {if (this["idlocation"]==DBNull.Value)return null; return  (Int32?)this["idlocation"];}
		set {if (value==null) this["idlocation"]= DBNull.Value; else this["idlocation"]= value;}
	}
	public object idlocationValue { 
		get{ return this["idlocation"];}
		set {if (value==null|| value==DBNull.Value) this["idlocation"]= DBNull.Value; else this["idlocation"]= value;}
	}
	public Int32? idlocationOriginal { 
		get {if (this["idlocation",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlocation",DataRowVersion.Original];}
	}
	///<summary>
	///id della class. siope (idsor di sorting) per il costo
	///</summary>
	public Int32? idsor_siope{ 
		get {if (this["idsor_siope"]==DBNull.Value)return null; return  (Int32?)this["idsor_siope"];}
		set {if (value==null) this["idsor_siope"]= DBNull.Value; else this["idsor_siope"]= value;}
	}
	public object idsor_siopeValue { 
		get{ return this["idsor_siope"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_siope"]= DBNull.Value; else this["idsor_siope"]= value;}
	}
	public Int32? idsor_siopeOriginal { 
		get {if (this["idsor_siope",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_siope",DataRowVersion.Original];}
	}
	///<summary>
	///id upb per contabilizzazione iva
	///</summary>
	public String idupb_iva{ 
		get {if (this["idupb_iva"]==DBNull.Value)return null; return  (String)this["idupb_iva"];}
		set {if (value==null) this["idupb_iva"]= DBNull.Value; else this["idupb_iva"]= value;}
	}
	public object idupb_ivaValue { 
		get{ return this["idupb_iva"];}
		set {if (value==null|| value==DBNull.Value) this["idupb_iva"]= DBNull.Value; else this["idupb_iva"]= value;}
	}
	public String idupb_ivaOriginal { 
		get {if (this["idupb_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idupb_iva",DataRowVersion.Original];}
	}
	public Int32? idepexp_pre{ 
		get {if (this["idepexp_pre"]==DBNull.Value)return null; return  (Int32?)this["idepexp_pre"];}
		set {if (value==null) this["idepexp_pre"]= DBNull.Value; else this["idepexp_pre"]= value;}
	}
	public object idepexp_preValue { 
		get{ return this["idepexp_pre"];}
		set {if (value==null|| value==DBNull.Value) this["idepexp_pre"]= DBNull.Value; else this["idepexp_pre"]= value;}
	}
	public Int32? idepexp_preOriginal { 
		get {if (this["idepexp_pre",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepexp_pre",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Dettaglio contratto passivo
///</summary>
public class mandatedetailTable : MetaTableBase<mandatedetailRow> {
	public mandatedetailTable() : base("mandatedetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idmankind",createColumn("idmankind",typeof(string),false,false)},
			{"nman",createColumn("nman",typeof(int),false,false)},
			{"rownum",createColumn("rownum",typeof(int),false,false)},
			{"yman",createColumn("yman",typeof(short),false,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
			{"assetkind",createColumn("assetkind",typeof(string),false,false)},
			{"competencystart",createColumn("competencystart",typeof(DateTime),true,false)},
			{"competencystop",createColumn("competencystop",typeof(DateTime),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"detaildescription",createColumn("detaildescription",typeof(string),true,false)},
			{"discount",createColumn("discount",typeof(double),true,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"ninvoiced",createColumn("ninvoiced",typeof(decimal),true,false)},
			{"number",createColumn("number",typeof(decimal),true,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"tax",createColumn("tax",typeof(decimal),true,false)},
			{"taxable",createColumn("taxable",typeof(decimal),true,false)},
			{"taxrate",createColumn("taxrate",typeof(double),true,false)},
			{"toinvoice",createColumn("toinvoice",typeof(string),true,false)},
			{"flagmixed",createColumn("flagmixed",typeof(string),true,false)},
			{"idaccmotive",createColumn("idaccmotive",typeof(string),true,false)},
			{"unabatable",createColumn("unabatable",typeof(decimal),true,false)},
			{"idgroup",createColumn("idgroup",typeof(int),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"idexp_taxable",createColumn("idexp_taxable",typeof(int),true,false)},
			{"idexp_iva",createColumn("idexp_iva",typeof(int),true,false)},
			{"idinv",createColumn("idinv",typeof(int),true,false)},
			{"idivakind",createColumn("idivakind",typeof(int),true,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
			{"idaccmotiveannulment",createColumn("idaccmotiveannulment",typeof(string),true,false)},
			{"flagactivity",createColumn("flagactivity",typeof(short),true,false)},
			{"va3type",createColumn("va3type",typeof(string),true,false)},
			{"applierannotations",createColumn("applierannotations",typeof(string),true,false)},
			{"ivanotes",createColumn("ivanotes",typeof(string),true,false)},
			{"idlist",createColumn("idlist",typeof(int),true,false)},
			{"idunit",createColumn("idunit",typeof(int),true,false)},
			{"idpackage",createColumn("idpackage",typeof(int),true,false)},
			{"unitsforpackage",createColumn("unitsforpackage",typeof(int),true,false)},
			{"npackage",createColumn("npackage",typeof(decimal),true,false)},
			{"cupcode",createColumn("cupcode",typeof(string),true,false)},
			{"cigcode",createColumn("cigcode",typeof(string),true,false)},
			{"flagto_unload",createColumn("flagto_unload",typeof(string),true,false)},
			{"epkind",createColumn("epkind",typeof(string),true,false)},
			{"rownum_origin",createColumn("rownum_origin",typeof(int),true,false)},
			{"contractamount",createColumn("contractamount",typeof(decimal),true,false)},
			{"idavcp",createColumn("idavcp",typeof(int),true,false)},
			{"idavcp_choice",createColumn("idavcp_choice",typeof(int),true,false)},
			{"avcp_startcontract",createColumn("avcp_startcontract",typeof(DateTime),true,false)},
			{"avcp_stopcontract",createColumn("avcp_stopcontract",typeof(DateTime),true,false)},
			{"avcp_description",createColumn("avcp_description",typeof(string),true,false)},
			{"idpccdebitmotive",createColumn("idpccdebitmotive",typeof(string),true,false)},
			{"idpccdebitstatus",createColumn("idpccdebitstatus",typeof(string),true,false)},
			{"idcostpartition",createColumn("idcostpartition",typeof(int),true,false)},
			{"expensekind",createColumn("expensekind",typeof(string),true,false)},
			{"idepexp",createColumn("idepexp",typeof(int),true,false)},
			{"idepacc",createColumn("idepacc",typeof(int),true,false)},
			{"idlocation",createColumn("idlocation",typeof(int),true,false)},
			{"idsor_siope",createColumn("idsor_siope",typeof(int),true,false)},
			{"idupb_iva",createColumn("idupb_iva",typeof(string),true,false)},
			{"idepexp_pre",createColumn("idepexp_pre",typeof(int),true,false)},
		};
	}
}
}
