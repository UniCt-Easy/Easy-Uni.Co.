
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
namespace meta_flussocreditidetail {
public class flussocreditidetailRow: MetaRow  {
	public flussocreditidetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///#
	///</summary>
	public Int32? idflusso{ 
		get {if (this["idflusso"]==DBNull.Value)return null; return  (Int32?)this["idflusso"];}
		set {if (value==null) this["idflusso"]= DBNull.Value; else this["idflusso"]= value;}
	}
	public object idflussoValue { 
		get{ return this["idflusso"];}
		set {if (value==null|| value==DBNull.Value) this["idflusso"]= DBNull.Value; else this["idflusso"]= value;}
	}
	public Int32? idflussoOriginal { 
		get {if (this["idflusso",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idflusso",DataRowVersion.Original];}
	}
	///<summary>
	///n. dettaglio
	///</summary>
	public Int32? iddetail{ 
		get {if (this["iddetail"]==DBNull.Value)return null; return  (Int32?)this["iddetail"];}
		set {if (value==null) this["iddetail"]= DBNull.Value; else this["iddetail"]= value;}
	}
	public object iddetailValue { 
		get{ return this["iddetail"];}
		set {if (value==null|| value==DBNull.Value) this["iddetail"]= DBNull.Value; else this["iddetail"]= value;}
	}
	public Int32? iddetailOriginal { 
		get {if (this["iddetail",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddetail",DataRowVersion.Original];}
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
	///Importo
	///</summary>
	public Decimal? importoversamento{ 
		get {if (this["importoversamento"]==DBNull.Value)return null; return  (Decimal?)this["importoversamento"];}
		set {if (value==null) this["importoversamento"]= DBNull.Value; else this["importoversamento"]= value;}
	}
	public object importoversamentoValue { 
		get{ return this["importoversamento"];}
		set {if (value==null|| value==DBNull.Value) this["importoversamento"]= DBNull.Value; else this["importoversamento"]= value;}
	}
	public Decimal? importoversamentoOriginal { 
		get {if (this["importoversamento",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["importoversamento",DataRowVersion.Original];}
	}
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
	///id tipo documento (tabella invoicekind)
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
	///anno fattura
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
	///n.fattura
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
	///n. riga fattura
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
	///<summary>
	///causale finanziaria per l'accertamento e l'incasso
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
	///Codice bollettino univoco (IUV)
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
	///causale di ricavo per scrittura ricavo a credito
	///</summary>
	public String idaccmotiverevenue{ 
		get {if (this["idaccmotiverevenue"]==DBNull.Value)return null; return  (String)this["idaccmotiverevenue"];}
		set {if (value==null) this["idaccmotiverevenue"]= DBNull.Value; else this["idaccmotiverevenue"]= value;}
	}
	public object idaccmotiverevenueValue { 
		get{ return this["idaccmotiverevenue"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotiverevenue"]= DBNull.Value; else this["idaccmotiverevenue"]= value;}
	}
	public String idaccmotiverevenueOriginal { 
		get {if (this["idaccmotiverevenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotiverevenue",DataRowVersion.Original];}
	}
	///<summary>
	///causale di credito per scrittura ricavo a credito
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
	///causale di annullo tasse entro l'anno di emissione
	///</summary>
	public String idaccmotiveundotax{ 
		get {if (this["idaccmotiveundotax"]==DBNull.Value)return null; return  (String)this["idaccmotiveundotax"];}
		set {if (value==null) this["idaccmotiveundotax"]= DBNull.Value; else this["idaccmotiveundotax"]= value;}
	}
	public object idaccmotiveundotaxValue { 
		get{ return this["idaccmotiveundotax"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotiveundotax"]= DBNull.Value; else this["idaccmotiveundotax"]= value;}
	}
	public String idaccmotiveundotaxOriginal { 
		get {if (this["idaccmotiveundotax",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotiveundotax",DataRowVersion.Original];}
	}
	///<summary>
	///causale di annullo tasse oltre l'anno di emissione
	///</summary>
	public String idaccmotiveundotaxpost{ 
		get {if (this["idaccmotiveundotaxpost"]==DBNull.Value)return null; return  (String)this["idaccmotiveundotaxpost"];}
		set {if (value==null) this["idaccmotiveundotaxpost"]= DBNull.Value; else this["idaccmotiveundotaxpost"]= value;}
	}
	public object idaccmotiveundotaxpostValue { 
		get{ return this["idaccmotiveundotaxpost"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotiveundotaxpost"]= DBNull.Value; else this["idaccmotiveundotaxpost"]= value;}
	}
	public String idaccmotiveundotaxpostOriginal { 
		get {if (this["idaccmotiveundotaxpost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotiveundotaxpost",DataRowVersion.Original];}
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
	///data annullamento del credito
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
	///Numero bollettino (rif. programma esterno)
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
	///Data di scadenza.
	///</summary>
	public DateTime? expirationdate{ 
		get {if (this["expirationdate"]==DBNull.Value)return null; return  (DateTime?)this["expirationdate"];}
		set {if (value==null) this["expirationdate"]= DBNull.Value; else this["expirationdate"]= value;}
	}
	public object expirationdateValue { 
		get{ return this["expirationdate"];}
		set {if (value==null|| value==DBNull.Value) this["expirationdate"]= DBNull.Value; else this["expirationdate"]= value;}
	}
	public DateTime? expirationdateOriginal { 
		get {if (this["expirationdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["expirationdate",DataRowVersion.Original];}
	}
	///<summary>
	///Contenuto in chiaro del codice a barre.
	///</summary>
	public String barcodevalue{ 
		get {if (this["barcodevalue"]==DBNull.Value)return null; return  (String)this["barcodevalue"];}
		set {if (value==null) this["barcodevalue"]= DBNull.Value; else this["barcodevalue"]= value;}
	}
	public object barcodevalueValue { 
		get{ return this["barcodevalue"];}
		set {if (value==null|| value==DBNull.Value) this["barcodevalue"]= DBNull.Value; else this["barcodevalue"]= value;}
	}
	public String barcodevalueOriginal { 
		get {if (this["barcodevalue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["barcodevalue",DataRowVersion.Original];}
	}
	///<summary>
	///Immagine del codice a barre.
	///</summary>
	public Byte[] barcodeimage{ 
		get {if (this["barcodeimage"]==DBNull.Value)return null; return  (Byte[])this["barcodeimage"];}
		set {if (value==null) this["barcodeimage"]= DBNull.Value; else this["barcodeimage"]= value;}
	}
	public object barcodeimageValue { 
		get{ return this["barcodeimage"];}
		set {if (value==null|| value==DBNull.Value) this["barcodeimage"]= DBNull.Value; else this["barcodeimage"]= value;}
	}
	public Byte[] barcodeimageOriginal { 
		get {if (this["barcodeimage",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte[])this["barcodeimage",DataRowVersion.Original];}
	}
	///<summary>
	///Contenuto in chiaro del codice QR.
	///</summary>
	public String qrcodevalue{ 
		get {if (this["qrcodevalue"]==DBNull.Value)return null; return  (String)this["qrcodevalue"];}
		set {if (value==null) this["qrcodevalue"]= DBNull.Value; else this["qrcodevalue"]= value;}
	}
	public object qrcodevalueValue { 
		get{ return this["qrcodevalue"];}
		set {if (value==null|| value==DBNull.Value) this["qrcodevalue"]= DBNull.Value; else this["qrcodevalue"]= value;}
	}
	public String qrcodevalueOriginal { 
		get {if (this["qrcodevalue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["qrcodevalue",DataRowVersion.Original];}
	}
	///<summary>
	///Immagine del codice QR.
	///</summary>
	public Byte[] qrcodeimage{ 
		get {if (this["qrcodeimage"]==DBNull.Value)return null; return  (Byte[])this["qrcodeimage"];}
		set {if (value==null) this["qrcodeimage"]= DBNull.Value; else this["qrcodeimage"]= value;}
	}
	public object qrcodeimageValue { 
		get{ return this["qrcodeimage"];}
		set {if (value==null|| value==DBNull.Value) this["qrcodeimage"]= DBNull.Value; else this["qrcodeimage"]= value;}
	}
	public Byte[] qrcodeimageOriginal { 
		get {if (this["qrcodeimage",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte[])this["qrcodeimage",DataRowVersion.Original];}
	}
	///<summary>
	///codice fiscale
	///</summary>
	public String cf{ 
		get {if (this["cf"]==DBNull.Value)return null; return  (String)this["cf"];}
		set {if (value==null) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public object cfValue { 
		get{ return this["cf"];}
		set {if (value==null|| value==DBNull.Value) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public String cfOriginal { 
		get {if (this["cf",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cf",DataRowVersion.Original];}
	}
	///<summary>
	///IUV
	///</summary>
	public String iuv{ 
		get {if (this["iuv"]==DBNull.Value)return null; return  (String)this["iuv"];}
		set {if (value==null) this["iuv"]= DBNull.Value; else this["iuv"]= value;}
	}
	public object iuvValue { 
		get{ return this["iuv"];}
		set {if (value==null|| value==DBNull.Value) this["iuv"]= DBNull.Value; else this["iuv"]= value;}
	}
	public String iuvOriginal { 
		get {if (this["iuv",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iuv",DataRowVersion.Original];}
	}
	///<summary>
	///Data annullamento
	///</summary>
	public DateTime? annulment{ 
		get {if (this["annulment"]==DBNull.Value)return null; return  (DateTime?)this["annulment"];}
		set {if (value==null) this["annulment"]= DBNull.Value; else this["annulment"]= value;}
	}
	public object annulmentValue { 
		get{ return this["annulment"];}
		set {if (value==null|| value==DBNull.Value) this["annulment"]= DBNull.Value; else this["annulment"]= value;}
	}
	public DateTime? annulmentOriginal { 
		get {if (this["annulment",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["annulment",DataRowVersion.Original];}
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
	///id univoco per l'intera tabella flussocreditidetail, in forma intera "pura", a volte è necessario per determinati servizi
	///</summary>
	public Int64? idunivoco{ 
		get {if (this["idunivoco"]==DBNull.Value)return null; return  (Int64?)this["idunivoco"];}
		set {if (value==null) this["idunivoco"]= DBNull.Value; else this["idunivoco"]= value;}
	}
	public object idunivocoValue { 
		get{ return this["idunivoco"];}
		set {if (value==null|| value==DBNull.Value) this["idunivoco"]= DBNull.Value; else this["idunivoco"]= value;}
	}
	public Int64? idunivocoOriginal { 
		get {if (this["idunivoco",DataRowVersion.Original]==DBNull.Value)return null; return  (Int64?)this["idunivoco",DataRowVersion.Original];}
	}
	///<summary>
	///Codice avviso ricevuto da pagoPA nell'invio del credito
	///</summary>
	public String codiceavviso{ 
		get {if (this["codiceavviso"]==DBNull.Value)return null; return  (String)this["codiceavviso"];}
		set {if (value==null) this["codiceavviso"]= DBNull.Value; else this["codiceavviso"]= value;}
	}
	public object codiceavvisoValue { 
		get{ return this["codiceavviso"];}
		set {if (value==null|| value==DBNull.Value) this["codiceavviso"]= DBNull.Value; else this["codiceavviso"]= value;}
	}
	public String codiceavvisoOriginal { 
		get {if (this["codiceavviso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceavviso",DataRowVersion.Original];}
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
	public String p_iva{ 
		get {if (this["p_iva"]==DBNull.Value)return null; return  (String)this["p_iva"];}
		set {if (value==null) this["p_iva"]= DBNull.Value; else this["p_iva"]= value;}
	}
	public object p_ivaValue { 
		get{ return this["p_iva"];}
		set {if (value==null|| value==DBNull.Value) this["p_iva"]= DBNull.Value; else this["p_iva"]= value;}
	}
	public String p_ivaOriginal { 
		get {if (this["p_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["p_iva",DataRowVersion.Original];}
	}
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
	#endregion

}
///<summary>
///Dettaglio flusso crediti
///</summary>
public class flussocreditidetailTable : MetaTableBase<flussocreditidetailRow> {
	public flussocreditidetailTable() : base("flussocreditidetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idflusso",createColumn("idflusso",typeof(int),false,false)},
			{"iddetail",createColumn("iddetail",typeof(int),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"importoversamento",createColumn("importoversamento",typeof(decimal),true,false)},
			{"idestimkind",createColumn("idestimkind",typeof(string),true,false)},
			{"yestim",createColumn("yestim",typeof(short),true,false)},
			{"nestim",createColumn("nestim",typeof(int),true,false)},
			{"rownum",createColumn("rownum",typeof(int),true,false)},
			{"idinvkind",createColumn("idinvkind",typeof(int),true,false)},
			{"yinv",createColumn("yinv",typeof(short),true,false)},
			{"ninv",createColumn("ninv",typeof(int),true,false)},
			{"invrownum",createColumn("invrownum",typeof(int),true,false)},
			{"idfinmotive",createColumn("idfinmotive",typeof(string),true,false)},
			{"iduniqueformcode",createColumn("iduniqueformcode",typeof(string),true,false)},
			{"idaccmotiverevenue",createColumn("idaccmotiverevenue",typeof(string),true,false)},
			{"idaccmotivecredit",createColumn("idaccmotivecredit",typeof(string),true,false)},
			{"idaccmotiveundotax",createColumn("idaccmotiveundotax",typeof(string),true,false)},
			{"idaccmotiveundotaxpost",createColumn("idaccmotiveundotaxpost",typeof(string),true,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"competencystart",createColumn("competencystart",typeof(DateTime),true,false)},
			{"competencystop",createColumn("competencystop",typeof(DateTime),true,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"nform",createColumn("nform",typeof(string),true,false)},
			{"expirationdate",createColumn("expirationdate",typeof(DateTime),true,false)},
			{"barcodevalue",createColumn("barcodevalue",typeof(string),true,false)},
			{"barcodeimage",createColumn("barcodeimage",typeof(Byte[]),true,false)},
			{"qrcodevalue",createColumn("qrcodevalue",typeof(string),true,false)},
			{"qrcodeimage",createColumn("qrcodeimage",typeof(Byte[]),true,false)},
			{"cf",createColumn("cf",typeof(string),true,false)},
			{"iuv",createColumn("iuv",typeof(string),true,false)},
			{"annulment",createColumn("annulment",typeof(DateTime),true,false)},
			{"flag",createColumn("flag",typeof(int),true,false)},
			{"idunivoco",createColumn("idunivoco",typeof(long),true,false)},
			{"codiceavviso",createColumn("codiceavviso",typeof(string),true,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
			{"idivakind",createColumn("idivakind",typeof(int),true,false)},
			{"tax",createColumn("tax",typeof(decimal),true,false)},
			{"number",createColumn("number",typeof(decimal),true,false)},
			{"idlist",createColumn("idlist",typeof(int),true,false)},
			{"p_iva",createColumn("p_iva",typeof(string),true,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
			{"idupb_iva",createColumn("idupb_iva",typeof(string),true,false)},
		};
	}
}
}
