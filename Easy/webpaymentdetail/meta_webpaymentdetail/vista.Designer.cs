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
namespace meta_webpaymentdetail {
public class webpaymentdetailRow: MetaRow  {
	public webpaymentdetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///#
	///</summary>
	public Int32? idwebpayment{ 
		get {if (this["idwebpayment"]==DBNull.Value)return null; return  (Int32?)this["idwebpayment"];}
		set {if (value==null) this["idwebpayment"]= DBNull.Value; else this["idwebpayment"]= value;}
	}
	public object idwebpaymentValue { 
		get{ return this["idwebpayment"];}
		set {if (value==null|| value==DBNull.Value) this["idwebpayment"]= DBNull.Value; else this["idwebpayment"]= value;}
	}
	public Int32? idwebpaymentOriginal { 
		get {if (this["idwebpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idwebpayment",DataRowVersion.Original];}
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
	///prezzo pagato
	///</summary>
	public Decimal? price{ 
		get {if (this["price"]==DBNull.Value)return null; return  (Decimal?)this["price"];}
		set {if (value==null) this["price"]= DBNull.Value; else this["price"]= value;}
	}
	public object priceValue { 
		get{ return this["price"];}
		set {if (value==null|| value==DBNull.Value) this["price"]= DBNull.Value; else this["price"]= value;}
	}
	public Decimal? priceOriginal { 
		get {if (this["price",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["price",DataRowVersion.Original];}
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
///Dett. pagamento web
///</summary>
public class webpaymentdetailTable : MetaTableBase<webpaymentdetailRow> {
	public webpaymentdetailTable() : base("webpaymentdetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idwebpayment",createColumn("idwebpayment",typeof(int),false,false)},
			{"iddetail",createColumn("iddetail",typeof(int),false,false)},
			{"idlist",createColumn("idlist",typeof(int),false,false)},
			{"idstore",createColumn("idstore",typeof(int),false,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
			{"number",createColumn("number",typeof(decimal),false,false)},
			{"price",createColumn("price",typeof(decimal),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"idestimkind",createColumn("idestimkind",typeof(string),true,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"paymentexpiring",createColumn("paymentexpiring",typeof(short),true,false)},
			{"idivakind",createColumn("idivakind",typeof(int),true,false)},
			{"tax",createColumn("tax",typeof(decimal),true,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
			{"idinvkind",createColumn("idinvkind",typeof(int),true,false)},
			{"competencystart",createColumn("competencystart",typeof(DateTime),true,false)},
			{"competencystop",createColumn("competencystop",typeof(DateTime),true,false)},
			{"idupb_iva",createColumn("idupb_iva",typeof(string),true,false)},
		};
	}
}
}
