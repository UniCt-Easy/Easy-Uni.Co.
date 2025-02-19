
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
namespace meta_ivapay {
public class ivapayRow: MetaRow  {
	public ivapayRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 nivapay{ 
		get {return  (Int32)this["nivapay"];}
		set {this["nivapay"]= value;}
	}
	public object nivapayValue { 
		get{ return this["nivapay"];}
		set {this["nivapay"]= value;}
	}
	public Int32 nivapayOriginal { 
		get {return  (Int32)this["nivapay",DataRowVersion.Original];}
	}
	public Int32 yivapay{ 
		get {return  (Int32)this["yivapay"];}
		set {this["yivapay"]= value;}
	}
	public object yivapayValue { 
		get{ return this["yivapay"];}
		set {this["yivapay"]= value;}
	}
	public Int32 yivapayOriginal { 
		get {return  (Int32)this["yivapay",DataRowVersion.Original];}
	}
	public DateTime? assesmentdate{ 
		get {if (this["assesmentdate"]==DBNull.Value)return null; return  (DateTime?)this["assesmentdate"];}
		set {if (value==null) this["assesmentdate"]= DBNull.Value; else this["assesmentdate"]= value;}
	}
	public object assesmentdateValue { 
		get{ return this["assesmentdate"];}
		set {if (value==null|| value==DBNull.Value) this["assesmentdate"]= DBNull.Value; else this["assesmentdate"]= value;}
	}
	public DateTime? assesmentdateOriginal { 
		get {if (this["assesmentdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["assesmentdate",DataRowVersion.Original];}
	}
	public Decimal? creditamount{ 
		get {if (this["creditamount"]==DBNull.Value)return null; return  (Decimal?)this["creditamount"];}
		set {if (value==null) this["creditamount"]= DBNull.Value; else this["creditamount"]= value;}
	}
	public object creditamountValue { 
		get{ return this["creditamount"];}
		set {if (value==null|| value==DBNull.Value) this["creditamount"]= DBNull.Value; else this["creditamount"]= value;}
	}
	public Decimal? creditamountOriginal { 
		get {if (this["creditamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["creditamount",DataRowVersion.Original];}
	}
	public Decimal? creditamountdeferred{ 
		get {if (this["creditamountdeferred"]==DBNull.Value)return null; return  (Decimal?)this["creditamountdeferred"];}
		set {if (value==null) this["creditamountdeferred"]= DBNull.Value; else this["creditamountdeferred"]= value;}
	}
	public object creditamountdeferredValue { 
		get{ return this["creditamountdeferred"];}
		set {if (value==null|| value==DBNull.Value) this["creditamountdeferred"]= DBNull.Value; else this["creditamountdeferred"]= value;}
	}
	public Decimal? creditamountdeferredOriginal { 
		get {if (this["creditamountdeferred",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["creditamountdeferred",DataRowVersion.Original];}
	}
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
	public DateTime dateivapay{ 
		get {return  (DateTime)this["dateivapay"];}
		set {this["dateivapay"]= value;}
	}
	public object dateivapayValue { 
		get{ return this["dateivapay"];}
		set {this["dateivapay"]= value;}
	}
	public DateTime dateivapayOriginal { 
		get {return  (DateTime)this["dateivapay",DataRowVersion.Original];}
	}
	public Decimal? debitamount{ 
		get {if (this["debitamount"]==DBNull.Value)return null; return  (Decimal?)this["debitamount"];}
		set {if (value==null) this["debitamount"]= DBNull.Value; else this["debitamount"]= value;}
	}
	public object debitamountValue { 
		get{ return this["debitamount"];}
		set {if (value==null|| value==DBNull.Value) this["debitamount"]= DBNull.Value; else this["debitamount"]= value;}
	}
	public Decimal? debitamountOriginal { 
		get {if (this["debitamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["debitamount",DataRowVersion.Original];}
	}
	public Decimal? debitamountdeferred{ 
		get {if (this["debitamountdeferred"]==DBNull.Value)return null; return  (Decimal?)this["debitamountdeferred"];}
		set {if (value==null) this["debitamountdeferred"]= DBNull.Value; else this["debitamountdeferred"]= value;}
	}
	public object debitamountdeferredValue { 
		get{ return this["debitamountdeferred"];}
		set {if (value==null|| value==DBNull.Value) this["debitamountdeferred"]= DBNull.Value; else this["debitamountdeferred"]= value;}
	}
	public Decimal? debitamountdeferredOriginal { 
		get {if (this["debitamountdeferred",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["debitamountdeferred",DataRowVersion.Original];}
	}
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
	public Decimal? mixed{ 
		get {if (this["mixed"]==DBNull.Value)return null; return  (Decimal?)this["mixed"];}
		set {if (value==null) this["mixed"]= DBNull.Value; else this["mixed"]= value;}
	}
	public object mixedValue { 
		get{ return this["mixed"];}
		set {if (value==null|| value==DBNull.Value) this["mixed"]= DBNull.Value; else this["mixed"]= value;}
	}
	public Decimal? mixedOriginal { 
		get {if (this["mixed",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["mixed",DataRowVersion.Original];}
	}
	public Decimal? paymentamount{ 
		get {if (this["paymentamount"]==DBNull.Value)return null; return  (Decimal?)this["paymentamount"];}
		set {if (value==null) this["paymentamount"]= DBNull.Value; else this["paymentamount"]= value;}
	}
	public object paymentamountValue { 
		get{ return this["paymentamount"];}
		set {if (value==null|| value==DBNull.Value) this["paymentamount"]= DBNull.Value; else this["paymentamount"]= value;}
	}
	public Decimal? paymentamountOriginal { 
		get {if (this["paymentamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["paymentamount",DataRowVersion.Original];}
	}
	public String paymentdetails{ 
		get {if (this["paymentdetails"]==DBNull.Value)return null; return  (String)this["paymentdetails"];}
		set {if (value==null) this["paymentdetails"]= DBNull.Value; else this["paymentdetails"]= value;}
	}
	public object paymentdetailsValue { 
		get{ return this["paymentdetails"];}
		set {if (value==null|| value==DBNull.Value) this["paymentdetails"]= DBNull.Value; else this["paymentdetails"]= value;}
	}
	public String paymentdetailsOriginal { 
		get {if (this["paymentdetails",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["paymentdetails",DataRowVersion.Original];}
	}
	public String paymentkind{ 
		get {return  (String)this["paymentkind"];}
		set {this["paymentkind"]= value;}
	}
	public object paymentkindValue { 
		get{ return this["paymentkind"];}
		set {this["paymentkind"]= value;}
	}
	public String paymentkindOriginal { 
		get {return  (String)this["paymentkind",DataRowVersion.Original];}
	}
	public Decimal? prorata{ 
		get {if (this["prorata"]==DBNull.Value)return null; return  (Decimal?)this["prorata"];}
		set {if (value==null) this["prorata"]= DBNull.Value; else this["prorata"]= value;}
	}
	public object prorataValue { 
		get{ return this["prorata"];}
		set {if (value==null|| value==DBNull.Value) this["prorata"]= DBNull.Value; else this["prorata"]= value;}
	}
	public Decimal? prorataOriginal { 
		get {if (this["prorata",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prorata",DataRowVersion.Original];}
	}
	public Decimal? refundamount{ 
		get {if (this["refundamount"]==DBNull.Value)return null; return  (Decimal?)this["refundamount"];}
		set {if (value==null) this["refundamount"]= DBNull.Value; else this["refundamount"]= value;}
	}
	public object refundamountValue { 
		get{ return this["refundamount"];}
		set {if (value==null|| value==DBNull.Value) this["refundamount"]= DBNull.Value; else this["refundamount"]= value;}
	}
	public Decimal? refundamountOriginal { 
		get {if (this["refundamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["refundamount",DataRowVersion.Original];}
	}
	public DateTime start{ 
		get {return  (DateTime)this["start"];}
		set {this["start"]= value;}
	}
	public object startValue { 
		get{ return this["start"];}
		set {this["start"]= value;}
	}
	public DateTime startOriginal { 
		get {return  (DateTime)this["start",DataRowVersion.Original];}
	}
	public DateTime stop{ 
		get {return  (DateTime)this["stop"];}
		set {this["stop"]= value;}
	}
	public object stopValue { 
		get{ return this["stop"];}
		set {this["stop"]= value;}
	}
	public DateTime stopOriginal { 
		get {return  (DateTime)this["stop",DataRowVersion.Original];}
	}
	public Decimal? totalcredit{ 
		get {if (this["totalcredit"]==DBNull.Value)return null; return  (Decimal?)this["totalcredit"];}
		set {if (value==null) this["totalcredit"]= DBNull.Value; else this["totalcredit"]= value;}
	}
	public object totalcreditValue { 
		get{ return this["totalcredit"];}
		set {if (value==null|| value==DBNull.Value) this["totalcredit"]= DBNull.Value; else this["totalcredit"]= value;}
	}
	public Decimal? totalcreditOriginal { 
		get {if (this["totalcredit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalcredit",DataRowVersion.Original];}
	}
	public Decimal? totaldebit{ 
		get {if (this["totaldebit"]==DBNull.Value)return null; return  (Decimal?)this["totaldebit"];}
		set {if (value==null) this["totaldebit"]= DBNull.Value; else this["totaldebit"]= value;}
	}
	public object totaldebitValue { 
		get{ return this["totaldebit"];}
		set {if (value==null|| value==DBNull.Value) this["totaldebit"]= DBNull.Value; else this["totaldebit"]= value;}
	}
	public Decimal? totaldebitOriginal { 
		get {if (this["totaldebit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totaldebit",DataRowVersion.Original];}
	}
	public Decimal? ivaintrastat12{ 
		get {if (this["ivaintrastat12"]==DBNull.Value)return null; return  (Decimal?)this["ivaintrastat12"];}
		set {if (value==null) this["ivaintrastat12"]= DBNull.Value; else this["ivaintrastat12"]= value;}
	}
	public object ivaintrastat12Value { 
		get{ return this["ivaintrastat12"];}
		set {if (value==null|| value==DBNull.Value) this["ivaintrastat12"]= DBNull.Value; else this["ivaintrastat12"]= value;}
	}
	public Decimal? ivaintrastat12Original { 
		get {if (this["ivaintrastat12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["ivaintrastat12",DataRowVersion.Original];}
	}
	public Decimal? taxableintrastat12{ 
		get {if (this["taxableintrastat12"]==DBNull.Value)return null; return  (Decimal?)this["taxableintrastat12"];}
		set {if (value==null) this["taxableintrastat12"]= DBNull.Value; else this["taxableintrastat12"]= value;}
	}
	public object taxableintrastat12Value { 
		get{ return this["taxableintrastat12"];}
		set {if (value==null|| value==DBNull.Value) this["taxableintrastat12"]= DBNull.Value; else this["taxableintrastat12"]= value;}
	}
	public Decimal? taxableintrastat12Original { 
		get {if (this["taxableintrastat12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["taxableintrastat12",DataRowVersion.Original];}
	}
	public Decimal? creditamount12{ 
		get {if (this["creditamount12"]==DBNull.Value)return null; return  (Decimal?)this["creditamount12"];}
		set {if (value==null) this["creditamount12"]= DBNull.Value; else this["creditamount12"]= value;}
	}
	public object creditamount12Value { 
		get{ return this["creditamount12"];}
		set {if (value==null|| value==DBNull.Value) this["creditamount12"]= DBNull.Value; else this["creditamount12"]= value;}
	}
	public Decimal? creditamount12Original { 
		get {if (this["creditamount12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["creditamount12",DataRowVersion.Original];}
	}
	public Decimal? creditamountdeferred12{ 
		get {if (this["creditamountdeferred12"]==DBNull.Value)return null; return  (Decimal?)this["creditamountdeferred12"];}
		set {if (value==null) this["creditamountdeferred12"]= DBNull.Value; else this["creditamountdeferred12"]= value;}
	}
	public object creditamountdeferred12Value { 
		get{ return this["creditamountdeferred12"];}
		set {if (value==null|| value==DBNull.Value) this["creditamountdeferred12"]= DBNull.Value; else this["creditamountdeferred12"]= value;}
	}
	public Decimal? creditamountdeferred12Original { 
		get {if (this["creditamountdeferred12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["creditamountdeferred12",DataRowVersion.Original];}
	}
	public Decimal? debitamount12{ 
		get {if (this["debitamount12"]==DBNull.Value)return null; return  (Decimal?)this["debitamount12"];}
		set {if (value==null) this["debitamount12"]= DBNull.Value; else this["debitamount12"]= value;}
	}
	public object debitamount12Value { 
		get{ return this["debitamount12"];}
		set {if (value==null|| value==DBNull.Value) this["debitamount12"]= DBNull.Value; else this["debitamount12"]= value;}
	}
	public Decimal? debitamount12Original { 
		get {if (this["debitamount12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["debitamount12",DataRowVersion.Original];}
	}
	public Decimal? debitamountdeferred12{ 
		get {if (this["debitamountdeferred12"]==DBNull.Value)return null; return  (Decimal?)this["debitamountdeferred12"];}
		set {if (value==null) this["debitamountdeferred12"]= DBNull.Value; else this["debitamountdeferred12"]= value;}
	}
	public object debitamountdeferred12Value { 
		get{ return this["debitamountdeferred12"];}
		set {if (value==null|| value==DBNull.Value) this["debitamountdeferred12"]= DBNull.Value; else this["debitamountdeferred12"]= value;}
	}
	public Decimal? debitamountdeferred12Original { 
		get {if (this["debitamountdeferred12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["debitamountdeferred12",DataRowVersion.Original];}
	}
	public Decimal? paymentamount12{ 
		get {if (this["paymentamount12"]==DBNull.Value)return null; return  (Decimal?)this["paymentamount12"];}
		set {if (value==null) this["paymentamount12"]= DBNull.Value; else this["paymentamount12"]= value;}
	}
	public object paymentamount12Value { 
		get{ return this["paymentamount12"];}
		set {if (value==null|| value==DBNull.Value) this["paymentamount12"]= DBNull.Value; else this["paymentamount12"]= value;}
	}
	public Decimal? paymentamount12Original { 
		get {if (this["paymentamount12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["paymentamount12",DataRowVersion.Original];}
	}
	public Decimal? refundamount12{ 
		get {if (this["refundamount12"]==DBNull.Value)return null; return  (Decimal?)this["refundamount12"];}
		set {if (value==null) this["refundamount12"]= DBNull.Value; else this["refundamount12"]= value;}
	}
	public object refundamount12Value { 
		get{ return this["refundamount12"];}
		set {if (value==null|| value==DBNull.Value) this["refundamount12"]= DBNull.Value; else this["refundamount12"]= value;}
	}
	public Decimal? refundamount12Original { 
		get {if (this["refundamount12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["refundamount12",DataRowVersion.Original];}
	}
	public Decimal? totalcredit12{ 
		get {if (this["totalcredit12"]==DBNull.Value)return null; return  (Decimal?)this["totalcredit12"];}
		set {if (value==null) this["totalcredit12"]= DBNull.Value; else this["totalcredit12"]= value;}
	}
	public object totalcredit12Value { 
		get{ return this["totalcredit12"];}
		set {if (value==null|| value==DBNull.Value) this["totalcredit12"]= DBNull.Value; else this["totalcredit12"]= value;}
	}
	public Decimal? totalcredit12Original { 
		get {if (this["totalcredit12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalcredit12",DataRowVersion.Original];}
	}
	public Decimal? totaldebit12{ 
		get {if (this["totaldebit12"]==DBNull.Value)return null; return  (Decimal?)this["totaldebit12"];}
		set {if (value==null) this["totaldebit12"]= DBNull.Value; else this["totaldebit12"]= value;}
	}
	public object totaldebit12Value { 
		get{ return this["totaldebit12"];}
		set {if (value==null|| value==DBNull.Value) this["totaldebit12"]= DBNull.Value; else this["totaldebit12"]= value;}
	}
	public Decimal? totaldebit12Original { 
		get {if (this["totaldebit12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totaldebit12",DataRowVersion.Original];}
	}
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
	public Decimal? prev_debit{ 
		get {if (this["prev_debit"]==DBNull.Value)return null; return  (Decimal?)this["prev_debit"];}
		set {if (value==null) this["prev_debit"]= DBNull.Value; else this["prev_debit"]= value;}
	}
	public object prev_debitValue { 
		get{ return this["prev_debit"];}
		set {if (value==null|| value==DBNull.Value) this["prev_debit"]= DBNull.Value; else this["prev_debit"]= value;}
	}
	public Decimal? prev_debitOriginal { 
		get {if (this["prev_debit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prev_debit",DataRowVersion.Original];}
	}
	public Decimal? prev_debit12{ 
		get {if (this["prev_debit12"]==DBNull.Value)return null; return  (Decimal?)this["prev_debit12"];}
		set {if (value==null) this["prev_debit12"]= DBNull.Value; else this["prev_debit12"]= value;}
	}
	public object prev_debit12Value { 
		get{ return this["prev_debit12"];}
		set {if (value==null|| value==DBNull.Value) this["prev_debit12"]= DBNull.Value; else this["prev_debit12"]= value;}
	}
	public Decimal? prev_debit12Original { 
		get {if (this["prev_debit12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prev_debit12",DataRowVersion.Original];}
	}
	public Decimal? totaldebitsplit{ 
		get {if (this["totaldebitsplit"]==DBNull.Value)return null; return  (Decimal?)this["totaldebitsplit"];}
		set {if (value==null) this["totaldebitsplit"]= DBNull.Value; else this["totaldebitsplit"]= value;}
	}
	public object totaldebitsplitValue { 
		get{ return this["totaldebitsplit"];}
		set {if (value==null|| value==DBNull.Value) this["totaldebitsplit"]= DBNull.Value; else this["totaldebitsplit"]= value;}
	}
	public Decimal? totaldebitsplitOriginal { 
		get {if (this["totaldebitsplit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totaldebitsplit",DataRowVersion.Original];}
	}
	public Decimal? paymentamountsplit{ 
		get {if (this["paymentamountsplit"]==DBNull.Value)return null; return  (Decimal?)this["paymentamountsplit"];}
		set {if (value==null) this["paymentamountsplit"]= DBNull.Value; else this["paymentamountsplit"]= value;}
	}
	public object paymentamountsplitValue { 
		get{ return this["paymentamountsplit"];}
		set {if (value==null|| value==DBNull.Value) this["paymentamountsplit"]= DBNull.Value; else this["paymentamountsplit"]= value;}
	}
	public Decimal? paymentamountsplitOriginal { 
		get {if (this["paymentamountsplit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["paymentamountsplit",DataRowVersion.Original];}
	}
	public Decimal? debitamountsplit{ 
		get {if (this["debitamountsplit"]==DBNull.Value)return null; return  (Decimal?)this["debitamountsplit"];}
		set {if (value==null) this["debitamountsplit"]= DBNull.Value; else this["debitamountsplit"]= value;}
	}
	public object debitamountsplitValue { 
		get{ return this["debitamountsplit"];}
		set {if (value==null|| value==DBNull.Value) this["debitamountsplit"]= DBNull.Value; else this["debitamountsplit"]= value;}
	}
	public Decimal? debitamountsplitOriginal { 
		get {if (this["debitamountsplit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["debitamountsplit",DataRowVersion.Original];}
	}
	public Decimal? debitamountdeferredsplit{ 
		get {if (this["debitamountdeferredsplit"]==DBNull.Value)return null; return  (Decimal?)this["debitamountdeferredsplit"];}
		set {if (value==null) this["debitamountdeferredsplit"]= DBNull.Value; else this["debitamountdeferredsplit"]= value;}
	}
	public object debitamountdeferredsplitValue { 
		get{ return this["debitamountdeferredsplit"];}
		set {if (value==null|| value==DBNull.Value) this["debitamountdeferredsplit"]= DBNull.Value; else this["debitamountdeferredsplit"]= value;}
	}
	public Decimal? debitamountdeferredsplitOriginal { 
		get {if (this["debitamountdeferredsplit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["debitamountdeferredsplit",DataRowVersion.Original];}
	}
	public Decimal? taxablesplit{ 
		get {if (this["taxablesplit"]==DBNull.Value)return null; return  (Decimal?)this["taxablesplit"];}
		set {if (value==null) this["taxablesplit"]= DBNull.Value; else this["taxablesplit"]= value;}
	}
	public object taxablesplitValue { 
		get{ return this["taxablesplit"];}
		set {if (value==null|| value==DBNull.Value) this["taxablesplit"]= DBNull.Value; else this["taxablesplit"]= value;}
	}
	public Decimal? taxablesplitOriginal { 
		get {if (this["taxablesplit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["taxablesplit",DataRowVersion.Original];}
	}
	public Decimal? ivasplit{ 
		get {if (this["ivasplit"]==DBNull.Value)return null; return  (Decimal?)this["ivasplit"];}
		set {if (value==null) this["ivasplit"]= DBNull.Value; else this["ivasplit"]= value;}
	}
	public object ivasplitValue { 
		get{ return this["ivasplit"];}
		set {if (value==null|| value==DBNull.Value) this["ivasplit"]= DBNull.Value; else this["ivasplit"]= value;}
	}
	public Decimal? ivasplitOriginal { 
		get {if (this["ivasplit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["ivasplit",DataRowVersion.Original];}
	}
	public Decimal? prev_debitsplit{ 
		get {if (this["prev_debitsplit"]==DBNull.Value)return null; return  (Decimal?)this["prev_debitsplit"];}
		set {if (value==null) this["prev_debitsplit"]= DBNull.Value; else this["prev_debitsplit"]= value;}
	}
	public object prev_debitsplitValue { 
		get{ return this["prev_debitsplit"];}
		set {if (value==null|| value==DBNull.Value) this["prev_debitsplit"]= DBNull.Value; else this["prev_debitsplit"]= value;}
	}
	public Decimal? prev_debitsplitOriginal { 
		get {if (this["prev_debitsplit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prev_debitsplit",DataRowVersion.Original];}
	}
	public Decimal? startcredit_applied{ 
		get {if (this["startcredit_applied"]==DBNull.Value)return null; return  (Decimal?)this["startcredit_applied"];}
		set {if (value==null) this["startcredit_applied"]= DBNull.Value; else this["startcredit_applied"]= value;}
	}
	public object startcredit_appliedValue { 
		get{ return this["startcredit_applied"];}
		set {if (value==null|| value==DBNull.Value) this["startcredit_applied"]= DBNull.Value; else this["startcredit_applied"]= value;}
	}
	public Decimal? startcredit_appliedOriginal { 
		get {if (this["startcredit_applied",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["startcredit_applied",DataRowVersion.Original];}
	}
	public String advancecomputemethod{ 
		get {if (this["advancecomputemethod"]==DBNull.Value)return null; return  (String)this["advancecomputemethod"];}
		set {if (value==null) this["advancecomputemethod"]= DBNull.Value; else this["advancecomputemethod"]= value;}
	}
	public object advancecomputemethodValue { 
		get{ return this["advancecomputemethod"];}
		set {if (value==null|| value==DBNull.Value) this["advancecomputemethod"]= DBNull.Value; else this["advancecomputemethod"]= value;}
	}
	public String advancecomputemethodOriginal { 
		get {if (this["advancecomputemethod",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["advancecomputemethod",DataRowVersion.Original];}
	}
	public Int32? idf24ep{ 
		get {if (this["idf24ep"]==DBNull.Value)return null; return  (Int32?)this["idf24ep"];}
		set {if (value==null) this["idf24ep"]= DBNull.Value; else this["idf24ep"]= value;}
	}
	public object idf24epValue { 
		get{ return this["idf24ep"];}
		set {if (value==null|| value==DBNull.Value) this["idf24ep"]= DBNull.Value; else this["idf24ep"]= value;}
	}
	public Int32? idf24epOriginal { 
		get {if (this["idf24ep",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idf24ep",DataRowVersion.Original];}
	}
	public Int32? idf24ordinario{ 
		get {if (this["idf24ordinario"]==DBNull.Value)return null; return  (Int32?)this["idf24ordinario"];}
		set {if (value==null) this["idf24ordinario"]= DBNull.Value; else this["idf24ordinario"]= value;}
	}
	public object idf24ordinarioValue { 
		get{ return this["idf24ordinario"];}
		set {if (value==null|| value==DBNull.Value) this["idf24ordinario"]= DBNull.Value; else this["idf24ordinario"]= value;}
	}
	public Int32? idf24ordinarioOriginal { 
		get {if (this["idf24ordinario",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idf24ordinario",DataRowVersion.Original];}
	}
	#endregion

}
public class ivapayTable : MetaTableBase<ivapayRow> {
	public ivapayTable() : base("ivapay"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nivapay",createColumn("nivapay",typeof(int),false,false)},
			{"yivapay",createColumn("yivapay",typeof(int),false,false)},
			{"assesmentdate",createColumn("assesmentdate",typeof(DateTime),true,false)},
			{"creditamount",createColumn("creditamount",typeof(decimal),true,false)},
			{"creditamountdeferred",createColumn("creditamountdeferred",typeof(decimal),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"dateivapay",createColumn("dateivapay",typeof(DateTime),false,false)},
			{"debitamount",createColumn("debitamount",typeof(decimal),true,false)},
			{"debitamountdeferred",createColumn("debitamountdeferred",typeof(decimal),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"mixed",createColumn("mixed",typeof(decimal),true,false)},
			{"paymentamount",createColumn("paymentamount",typeof(decimal),true,false)},
			{"paymentdetails",createColumn("paymentdetails",typeof(string),true,false)},
			{"paymentkind",createColumn("paymentkind",typeof(string),false,false)},
			{"prorata",createColumn("prorata",typeof(decimal),true,false)},
			{"refundamount",createColumn("refundamount",typeof(decimal),true,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"stop",createColumn("stop",typeof(DateTime),false,false)},
			{"totalcredit",createColumn("totalcredit",typeof(decimal),true,false)},
			{"totaldebit",createColumn("totaldebit",typeof(decimal),true,false)},
			{"ivaintrastat12",createColumn("ivaintrastat12",typeof(decimal),true,false)},
			{"taxableintrastat12",createColumn("taxableintrastat12",typeof(decimal),true,false)},
			{"creditamount12",createColumn("creditamount12",typeof(decimal),true,false)},
			{"creditamountdeferred12",createColumn("creditamountdeferred12",typeof(decimal),true,false)},
			{"debitamount12",createColumn("debitamount12",typeof(decimal),true,false)},
			{"debitamountdeferred12",createColumn("debitamountdeferred12",typeof(decimal),true,false)},
			{"paymentamount12",createColumn("paymentamount12",typeof(decimal),true,false)},
			{"refundamount12",createColumn("refundamount12",typeof(decimal),true,false)},
			{"totalcredit12",createColumn("totalcredit12",typeof(decimal),true,false)},
			{"totaldebit12",createColumn("totaldebit12",typeof(decimal),true,false)},
			{"flag",createColumn("flag",typeof(byte),true,false)},
			{"prev_debit",createColumn("prev_debit",typeof(decimal),true,false)},
			{"prev_debit12",createColumn("prev_debit12",typeof(decimal),true,false)},
			{"totaldebitsplit",createColumn("totaldebitsplit",typeof(decimal),true,false)},
			{"paymentamountsplit",createColumn("paymentamountsplit",typeof(decimal),true,false)},
			{"debitamountsplit",createColumn("debitamountsplit",typeof(decimal),true,false)},
			{"debitamountdeferredsplit",createColumn("debitamountdeferredsplit",typeof(decimal),true,false)},
			{"taxablesplit",createColumn("taxablesplit",typeof(decimal),true,false)},
			{"ivasplit",createColumn("ivasplit",typeof(decimal),true,false)},
			{"prev_debitsplit",createColumn("prev_debitsplit",typeof(decimal),true,false)},
			{"startcredit_applied",createColumn("startcredit_applied",typeof(decimal),true,false)},
			{"advancecomputemethod",createColumn("advancecomputemethod",typeof(string),true,false)},
			{"idf24ep",createColumn("idf24ep",typeof(int),true,false)},
			{"idf24ordinario",createColumn("idf24ordinario",typeof(int),true,false)},
		};
	}
}
}
