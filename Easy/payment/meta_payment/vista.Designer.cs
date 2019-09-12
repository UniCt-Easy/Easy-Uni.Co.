/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace meta_payment {
public class paymentRow: MetaRow  {
	public paymentRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///N. mandato
	///</summary>
	public Int32? npay{ 
		get {if (this["npay"]==DBNull.Value)return null; return  (Int32?)this["npay"];}
		set {if (value==null) this["npay"]= DBNull.Value; else this["npay"]= value;}
	}
	public object npayValue { 
		get{ return this["npay"];}
		set {if (value==null|| value==DBNull.Value) this["npay"]= DBNull.Value; else this["npay"]= value;}
	}
	public Int32? npayOriginal { 
		get {if (this["npay",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["npay",DataRowVersion.Original];}
	}
	///<summary>
	///Anno mandato
	///</summary>
	public Int16? ypay{ 
		get {if (this["ypay"]==DBNull.Value)return null; return  (Int16?)this["ypay"];}
		set {if (value==null) this["ypay"]= DBNull.Value; else this["ypay"]= value;}
	}
	public object ypayValue { 
		get{ return this["ypay"];}
		set {if (value==null|| value==DBNull.Value) this["ypay"]= DBNull.Value; else this["ypay"]= value;}
	}
	public Int16? ypayOriginal { 
		get {if (this["ypay",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ypay",DataRowVersion.Original];}
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
	///Data annullamento
	///</summary>
	public DateTime? annulmentdate{ 
		get {if (this["annulmentdate"]==DBNull.Value)return null; return  (DateTime?)this["annulmentdate"];}
		set {if (value==null) this["annulmentdate"]= DBNull.Value; else this["annulmentdate"]= value;}
	}
	public object annulmentdateValue { 
		get{ return this["annulmentdate"];}
		set {if (value==null|| value==DBNull.Value) this["annulmentdate"]= DBNull.Value; else this["annulmentdate"]= value;}
	}
	public DateTime? annulmentdateOriginal { 
		get {if (this["annulmentdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["annulmentdate",DataRowVersion.Original];}
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
	///Data stampa
	///</summary>
	public DateTime? printdate{ 
		get {if (this["printdate"]==DBNull.Value)return null; return  (DateTime?)this["printdate"];}
		set {if (value==null) this["printdate"]= DBNull.Value; else this["printdate"]= value;}
	}
	public object printdateValue { 
		get{ return this["printdate"];}
		set {if (value==null|| value==DBNull.Value) this["printdate"]= DBNull.Value; else this["printdate"]= value;}
	}
	public DateTime? printdateOriginal { 
		get {if (this["printdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["printdate",DataRowVersion.Original];}
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
	///id voce bilancio (tabella fin)
	///</summary>
	public Int32? idfin{ 
		get {if (this["idfin"]==DBNull.Value)return null; return  (Int32?)this["idfin"];}
		set {if (value==null) this["idfin"]= DBNull.Value; else this["idfin"]= value;}
	}
	public object idfinValue { 
		get{ return this["idfin"];}
		set {if (value==null|| value==DBNull.Value) this["idfin"]= DBNull.Value; else this["idfin"]= value;}
	}
	public Int32? idfinOriginal { 
		get {if (this["idfin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfin",DataRowVersion.Original];}
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
	///ID Trattamento del bollo (tabella stamphandling)
	///</summary>
	public Int32? idstamphandling{ 
		get {if (this["idstamphandling"]==DBNull.Value)return null; return  (Int32?)this["idstamphandling"];}
		set {if (value==null) this["idstamphandling"]= DBNull.Value; else this["idstamphandling"]= value;}
	}
	public object idstamphandlingValue { 
		get{ return this["idstamphandling"];}
		set {if (value==null|| value==DBNull.Value) this["idstamphandling"]= DBNull.Value; else this["idstamphandling"]= value;}
	}
	public Int32? idstamphandlingOriginal { 
		get {if (this["idstamphandling",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstamphandling",DataRowVersion.Original];}
	}
	///<summary>
	///Id cassiere (tabella treasurer)
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
	///Tipo competenza
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
	///chiave mandato (tabella payment)
	///</summary>
	public Int32? kpay{ 
		get {if (this["kpay"]==DBNull.Value)return null; return  (Int32?)this["kpay"];}
		set {if (value==null) this["kpay"]= DBNull.Value; else this["kpay"]= value;}
	}
	public object kpayValue { 
		get{ return this["kpay"];}
		set {if (value==null|| value==DBNull.Value) this["kpay"]= DBNull.Value; else this["kpay"]= value;}
	}
	public Int32? kpayOriginal { 
		get {if (this["kpay",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kpay",DataRowVersion.Original];}
	}
	///<summary>
	///chiave elenco di trasmissione in cui Ã¨ inserito il mandato (tabella paymenttransmission)
	///</summary>
	public Int32? kpaymenttransmission{ 
		get {if (this["kpaymenttransmission"]==DBNull.Value)return null; return  (Int32?)this["kpaymenttransmission"];}
		set {if (value==null) this["kpaymenttransmission"]= DBNull.Value; else this["kpaymenttransmission"]= value;}
	}
	public object kpaymenttransmissionValue { 
		get{ return this["kpaymenttransmission"];}
		set {if (value==null|| value==DBNull.Value) this["kpaymenttransmission"]= DBNull.Value; else this["kpaymenttransmission"]= value;}
	}
	public Int32? kpaymenttransmissionOriginal { 
		get {if (this["kpaymenttransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kpaymenttransmission",DataRowVersion.Original];}
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
	///Num. progressivo Cassiere
	///</summary>
	public Int32? npay_treasurer{ 
		get {if (this["npay_treasurer"]==DBNull.Value)return null; return  (Int32?)this["npay_treasurer"];}
		set {if (value==null) this["npay_treasurer"]= DBNull.Value; else this["npay_treasurer"]= value;}
	}
	public object npay_treasurerValue { 
		get{ return this["npay_treasurer"];}
		set {if (value==null|| value==DBNull.Value) this["npay_treasurer"]= DBNull.Value; else this["npay_treasurer"]= value;}
	}
	public Int32? npay_treasurerOriginal { 
		get {if (this["npay_treasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["npay_treasurer",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Documento di pagamento
///</summary>
public class paymentTable : MetaTableBase<paymentRow> {
	public paymentTable() : base("payment"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"npay",createColumn("npay",typeof(Int32),false,false)},
			{"ypay",createColumn("ypay",typeof(Int16),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),true,false)},
			{"annulmentdate",createColumn("annulmentdate",typeof(DateTime),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"idreg",createColumn("idreg",typeof(Int32),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"printdate",createColumn("printdate",typeof(DateTime),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(String),true,false)},
			{"idfin",createColumn("idfin",typeof(Int32),true,false)},
			{"idman",createColumn("idman",typeof(Int32),true,false)},
			{"idstamphandling",createColumn("idstamphandling",typeof(Int32),true,false)},
			{"idtreasurer",createColumn("idtreasurer",typeof(Int32),true,false)},
			{"flag",createColumn("flag",typeof(Byte),false,false)},
			{"kpay",createColumn("kpay",typeof(Int32),false,false)},
			{"kpaymenttransmission",createColumn("kpaymenttransmission",typeof(Int32),true,false)},
			{"idsor01",createColumn("idsor01",typeof(Int32),true,false)},
			{"idsor02",createColumn("idsor02",typeof(Int32),true,false)},
			{"idsor03",createColumn("idsor03",typeof(Int32),true,false)},
			{"idsor04",createColumn("idsor04",typeof(Int32),true,false)},
			{"idsor05",createColumn("idsor05",typeof(Int32),true,false)},
			{"external_reference",createColumn("external_reference",typeof(String),true,false)},
			{"npay_treasurer",createColumn("npay_treasurer",typeof(Int32),true,false)},
		};
	}
}
}
