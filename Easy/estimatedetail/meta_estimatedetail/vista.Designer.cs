/*
    Easy
    Copyright (C) 2019 Universit‡ degli Studi di Catania (www.unict.it)

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
namespace meta_estimatedetail {
public class estimatedetailRow: MetaRow  {
	public estimatedetailRow(DataRowBuilder rb) : base(rb) {} 

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
	///n. dettagli in fattura (non usato, usare quello della vista)
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
	///quantit√†
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
	///id mov. di entrata per contabilizzare imponibile
	///</summary>
	public Int32? idinc_taxable{ 
		get {if (this["idinc_taxable"]==DBNull.Value)return null; return  (Int32?)this["idinc_taxable"];}
		set {if (value==null) this["idinc_taxable"]= DBNull.Value; else this["idinc_taxable"]= value;}
	}
	public object idinc_taxableValue { 
		get{ return this["idinc_taxable"];}
		set {if (value==null|| value==DBNull.Value) this["idinc_taxable"]= DBNull.Value; else this["idinc_taxable"]= value;}
	}
	public Int32? idinc_taxableOriginal { 
		get {if (this["idinc_taxable",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinc_taxable",DataRowVersion.Original];}
	}
	///<summary>
	///id mov. di entrata per contabilizzazione iva
	///</summary>
	public Int32? idinc_iva{ 
		get {if (this["idinc_iva"]==DBNull.Value)return null; return  (Int32?)this["idinc_iva"];}
		set {if (value==null) this["idinc_iva"]= DBNull.Value; else this["idinc_iva"]= value;}
	}
	public object idinc_ivaValue { 
		get{ return this["idinc_iva"];}
		set {if (value==null|| value==DBNull.Value) this["idinc_iva"]= DBNull.Value; else this["idinc_iva"]= value;}
	}
	public Int32? idinc_ivaOriginal { 
		get {if (this["idinc_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinc_iva",DataRowVersion.Original];}
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
	///causale di annullamento (idaccmotive di accmotive)
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
	///Tipo EP
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
	///ID Ripartizione dei ricavi (tabella revenuepartition)
	///</summary>
	public Int32? idrevenuepartition{ 
		get {if (this["idrevenuepartition"]==DBNull.Value)return null; return  (Int32?)this["idrevenuepartition"];}
		set {if (value==null) this["idrevenuepartition"]= DBNull.Value; else this["idrevenuepartition"]= value;}
	}
	public object idrevenuepartitionValue { 
		get{ return this["idrevenuepartition"];}
		set {if (value==null|| value==DBNull.Value) this["idrevenuepartition"]= DBNull.Value; else this["idrevenuepartition"]= value;}
	}
	public Int32? idrevenuepartitionOriginal { 
		get {if (this["idrevenuepartition",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idrevenuepartition",DataRowVersion.Original];}
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
	///id dell'upb per contabilizzare l'iva e per scritture in pd su iva
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
	///causale finanziaria 
	///</summary>
	public String idfinmotive{ 
		get {if (this["idfinmotive"]==DBNull.Value)return null; return  (String)this["idfinmotive"];}
		set {if (value==null) this["idfinmotive"]= DBNull.Value; else this["idfinmotive"]= value;}
	}
	public object idfinmotiveValue { 
		get{ return this["idfinmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idfinmotive"]= DBNull.Value; else this["idfinmotive"]= value;}
	}
	public String idfinmotiveOriginal { 
		get {if (this["idfinmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idfinmotive",DataRowVersion.Original];}
	}
	///<summary>
	///codice bollettino univoco (IUV)
	///</summary>
	public String iduniqueformcode{ 
		get {if (this["iduniqueformcode"]==DBNull.Value)return null; return  (String)this["iduniqueformcode"];}
		set {if (value==null) this["iduniqueformcode"]= DBNull.Value; else this["iduniqueformcode"]= value;}
	}
	public object iduniqueformcodeValue { 
		get{ return this["iduniqueformcode"];}
		set {if (value==null|| value==DBNull.Value) this["iduniqueformcode"]= DBNull.Value; else this["iduniqueformcode"]= value;}
	}
	public String iduniqueformcodeOriginal { 
		get {if (this["iduniqueformcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iduniqueformcode",DataRowVersion.Original];}
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
	///scadenza credito
	///</summary>
	public DateTime? proceedsexpiring{ 
		get {if (this["proceedsexpiring"]==DBNull.Value)return null; return  (DateTime?)this["proceedsexpiring"];}
		set {if (value==null) this["proceedsexpiring"]= DBNull.Value; else this["proceedsexpiring"]= value;}
	}
	public object proceedsexpiringValue { 
		get{ return this["proceedsexpiring"];}
		set {if (value==null|| value==DBNull.Value) this["proceedsexpiring"]= DBNull.Value; else this["proceedsexpiring"]= value;}
	}
	public DateTime? proceedsexpiringOriginal { 
		get {if (this["proceedsexpiring",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["proceedsexpiring",DataRowVersion.Original];}
	}
	///<summary>
	///N. bollettino
	///</summary>
	public String nform{ 
		get {if (this["nform"]==DBNull.Value)return null; return  (String)this["nform"];}
		set {if (value==null) this["nform"]= DBNull.Value; else this["nform"]= value;}
	}
	public object nformValue { 
		get{ return this["nform"];}
		set {if (value==null|| value==DBNull.Value) this["nform"]= DBNull.Value; else this["nform"]= value;}
	}
	public String nformOriginal { 
		get {if (this["nform",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["nform",DataRowVersion.Original];}
	}
	///<summary>
	///id della class. siope (idsor di sorting) per il ricavo
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
	public Int32? idepacc_pre{ 
		get {if (this["idepacc_pre"]==DBNull.Value)return null; return  (Int32?)this["idepacc_pre"];}
		set {if (value==null) this["idepacc_pre"]= DBNull.Value; else this["idepacc_pre"]= value;}
	}
	public object idepacc_preValue { 
		get{ return this["idepacc_pre"];}
		set {if (value==null|| value==DBNull.Value) this["idepacc_pre"]= DBNull.Value; else this["idepacc_pre"]= value;}
	}
	public Int32? idepacc_preOriginal { 
		get {if (this["idepacc_pre",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepacc_pre",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Dettaglio contratto attivo
///</summary>
public class estimatedetailTable : MetaTableBase<estimatedetailRow> {
	public estimatedetailTable() : base("estimatedetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idestimkind",createColumn("idestimkind",typeof(string),false,false)},
			{"yestim",createColumn("yestim",typeof(short),false,false)},
			{"nestim",createColumn("nestim",typeof(int),false,false)},
			{"rownum",createColumn("rownum",typeof(int),false,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
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
			{"idaccmotive",createColumn("idaccmotive",typeof(string),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"idgroup",createColumn("idgroup",typeof(int),true,false)},
			{"competencystart",createColumn("competencystart",typeof(DateTime),true,false)},
			{"competencystop",createColumn("competencystop",typeof(DateTime),true,false)},
			{"idinc_taxable",createColumn("idinc_taxable",typeof(int),true,false)},
			{"idinc_iva",createColumn("idinc_iva",typeof(int),true,false)},
			{"idivakind",createColumn("idivakind",typeof(int),true,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
			{"idaccmotiveannulment",createColumn("idaccmotiveannulment",typeof(string),true,false)},
			{"epkind",createColumn("epkind",typeof(string),true,false)},
			{"idrevenuepartition",createColumn("idrevenuepartition",typeof(int),true,false)},
			{"idepacc",createColumn("idepacc",typeof(int),true,false)},
			{"idupb_iva",createColumn("idupb_iva",typeof(string),true,false)},
			{"idlist",createColumn("idlist",typeof(int),true,false)},
			{"cigcode",createColumn("cigcode",typeof(string),true,false)},
			{"idfinmotive",createColumn("idfinmotive",typeof(string),true,false)},
			{"iduniqueformcode",createColumn("iduniqueformcode",typeof(string),true,false)},
			{"flag",createColumn("flag",typeof(int),true,false)},
			{"proceedsexpiring",createColumn("proceedsexpiring",typeof(DateTime),true,false)},
			{"nform",createColumn("nform",typeof(string),true,false)},
			{"idsor_siope",createColumn("idsor_siope",typeof(int),true,false)},
			{"idepacc_pre",createColumn("idepacc_pre",typeof(int),true,false)},
		};
	}
}
}
