
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
namespace meta_profservice {
public class profserviceRow: MetaRow  {
	public profserviceRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 ncon{ 
		get {return  (Int32)this["ncon"];}
		set {this["ncon"]= value;}
	}
	public object nconValue { 
		get{ return this["ncon"];}
		set {this["ncon"]= value;}
	}
	public Int32 nconOriginal { 
		get {return  (Int32)this["ncon",DataRowVersion.Original];}
	}
	public Int32 ycon{ 
		get {return  (Int32)this["ycon"];}
		set {this["ycon"]= value;}
	}
	public object yconValue { 
		get{ return this["ycon"];}
		set {this["ycon"]= value;}
	}
	public Int32 yconOriginal { 
		get {return  (Int32)this["ycon",DataRowVersion.Original];}
	}
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
	public Decimal feegross{ 
		get {return  (Decimal)this["feegross"];}
		set {this["feegross"]= value;}
	}
	public object feegrossValue { 
		get{ return this["feegross"];}
		set {this["feegross"]= value;}
	}
	public Decimal feegrossOriginal { 
		get {return  (Decimal)this["feegross",DataRowVersion.Original];}
	}
	public String flaginvoiced{ 
		get {if (this["flaginvoiced"]==DBNull.Value)return null; return  (String)this["flaginvoiced"];}
		set {if (value==null) this["flaginvoiced"]= DBNull.Value; else this["flaginvoiced"]= value;}
	}
	public object flaginvoicedValue { 
		get{ return this["flaginvoiced"];}
		set {if (value==null|| value==DBNull.Value) this["flaginvoiced"]= DBNull.Value; else this["flaginvoiced"]= value;}
	}
	public String flaginvoicedOriginal { 
		get {if (this["flaginvoiced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flaginvoiced",DataRowVersion.Original];}
	}
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
	public Decimal? ivaamount{ 
		get {if (this["ivaamount"]==DBNull.Value)return null; return  (Decimal?)this["ivaamount"];}
		set {if (value==null) this["ivaamount"]= DBNull.Value; else this["ivaamount"]= value;}
	}
	public object ivaamountValue { 
		get{ return this["ivaamount"];}
		set {if (value==null|| value==DBNull.Value) this["ivaamount"]= DBNull.Value; else this["ivaamount"]= value;}
	}
	public Decimal? ivaamountOriginal { 
		get {if (this["ivaamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["ivaamount",DataRowVersion.Original];}
	}
	public Int32? ivafieldnumber{ 
		get {if (this["ivafieldnumber"]==DBNull.Value)return null; return  (Int32?)this["ivafieldnumber"];}
		set {if (value==null) this["ivafieldnumber"]= DBNull.Value; else this["ivafieldnumber"]= value;}
	}
	public object ivafieldnumberValue { 
		get{ return this["ivafieldnumber"];}
		set {if (value==null|| value==DBNull.Value) this["ivafieldnumber"]= DBNull.Value; else this["ivafieldnumber"]= value;}
	}
	public Int32? ivafieldnumberOriginal { 
		get {if (this["ivafieldnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ivafieldnumber",DataRowVersion.Original];}
	}
	public Decimal? ivarate{ 
		get {if (this["ivarate"]==DBNull.Value)return null; return  (Decimal?)this["ivarate"];}
		set {if (value==null) this["ivarate"]= DBNull.Value; else this["ivarate"]= value;}
	}
	public object ivarateValue { 
		get{ return this["ivarate"];}
		set {if (value==null|| value==DBNull.Value) this["ivarate"]= DBNull.Value; else this["ivarate"]= value;}
	}
	public Decimal? ivarateOriginal { 
		get {if (this["ivarate",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["ivarate",DataRowVersion.Original];}
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
	public Int32 ndays{ 
		get {return  (Int32)this["ndays"];}
		set {this["ndays"]= value;}
	}
	public object ndaysValue { 
		get{ return this["ndays"];}
		set {this["ndays"]= value;}
	}
	public Int32 ndaysOriginal { 
		get {return  (Int32)this["ndays",DataRowVersion.Original];}
	}
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
	public Decimal? pensioncontributionrate{ 
		get {if (this["pensioncontributionrate"]==DBNull.Value)return null; return  (Decimal?)this["pensioncontributionrate"];}
		set {if (value==null) this["pensioncontributionrate"]= DBNull.Value; else this["pensioncontributionrate"]= value;}
	}
	public object pensioncontributionrateValue { 
		get{ return this["pensioncontributionrate"];}
		set {if (value==null|| value==DBNull.Value) this["pensioncontributionrate"]= DBNull.Value; else this["pensioncontributionrate"]= value;}
	}
	public Decimal? pensioncontributionrateOriginal { 
		get {if (this["pensioncontributionrate",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["pensioncontributionrate",DataRowVersion.Original];}
	}
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
	public Decimal? socialsecurityrate{ 
		get {if (this["socialsecurityrate"]==DBNull.Value)return null; return  (Decimal?)this["socialsecurityrate"];}
		set {if (value==null) this["socialsecurityrate"]= DBNull.Value; else this["socialsecurityrate"]= value;}
	}
	public object socialsecurityrateValue { 
		get{ return this["socialsecurityrate"];}
		set {if (value==null|| value==DBNull.Value) this["socialsecurityrate"]= DBNull.Value; else this["socialsecurityrate"]= value;}
	}
	public Decimal? socialsecurityrateOriginal { 
		get {if (this["socialsecurityrate",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["socialsecurityrate",DataRowVersion.Original];}
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
	public Decimal? totalcost{ 
		get {if (this["totalcost"]==DBNull.Value)return null; return  (Decimal?)this["totalcost"];}
		set {if (value==null) this["totalcost"]= DBNull.Value; else this["totalcost"]= value;}
	}
	public object totalcostValue { 
		get{ return this["totalcost"];}
		set {if (value==null|| value==DBNull.Value) this["totalcost"]= DBNull.Value; else this["totalcost"]= value;}
	}
	public Decimal? totalcostOriginal { 
		get {if (this["totalcost",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalcost",DataRowVersion.Original];}
	}
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
	public Int32 idser{ 
		get {return  (Int32)this["idser"];}
		set {this["idser"]= value;}
	}
	public object idserValue { 
		get{ return this["idser"];}
		set {this["idser"]= value;}
	}
	public Int32 idserOriginal { 
		get {return  (Int32)this["idser",DataRowVersion.Original];}
	}
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
	public String authdoc{ 
		get {if (this["authdoc"]==DBNull.Value)return null; return  (String)this["authdoc"];}
		set {if (value==null) this["authdoc"]= DBNull.Value; else this["authdoc"]= value;}
	}
	public object authdocValue { 
		get{ return this["authdoc"];}
		set {if (value==null|| value==DBNull.Value) this["authdoc"]= DBNull.Value; else this["authdoc"]= value;}
	}
	public String authdocOriginal { 
		get {if (this["authdoc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["authdoc",DataRowVersion.Original];}
	}
	public DateTime? authdocdate{ 
		get {if (this["authdocdate"]==DBNull.Value)return null; return  (DateTime?)this["authdocdate"];}
		set {if (value==null) this["authdocdate"]= DBNull.Value; else this["authdocdate"]= value;}
	}
	public object authdocdateValue { 
		get{ return this["authdocdate"];}
		set {if (value==null|| value==DBNull.Value) this["authdocdate"]= DBNull.Value; else this["authdocdate"]= value;}
	}
	public DateTime? authdocdateOriginal { 
		get {if (this["authdocdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["authdocdate",DataRowVersion.Original];}
	}
	public String authneeded{ 
		get {if (this["authneeded"]==DBNull.Value)return null; return  (String)this["authneeded"];}
		set {if (value==null) this["authneeded"]= DBNull.Value; else this["authneeded"]= value;}
	}
	public object authneededValue { 
		get{ return this["authneeded"];}
		set {if (value==null|| value==DBNull.Value) this["authneeded"]= DBNull.Value; else this["authneeded"]= value;}
	}
	public String authneededOriginal { 
		get {if (this["authneeded",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["authneeded",DataRowVersion.Original];}
	}
	public String noauthreason{ 
		get {if (this["noauthreason"]==DBNull.Value)return null; return  (String)this["noauthreason"];}
		set {if (value==null) this["noauthreason"]= DBNull.Value; else this["noauthreason"]= value;}
	}
	public object noauthreasonValue { 
		get{ return this["noauthreason"];}
		set {if (value==null|| value==DBNull.Value) this["noauthreason"]= DBNull.Value; else this["noauthreason"]= value;}
	}
	public String noauthreasonOriginal { 
		get {if (this["noauthreason",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["noauthreason",DataRowVersion.Original];}
	}
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
	public Decimal? totalgross{ 
		get {if (this["totalgross"]==DBNull.Value)return null; return  (Decimal?)this["totalgross"];}
		set {if (value==null) this["totalgross"]= DBNull.Value; else this["totalgross"]= value;}
	}
	public object totalgrossValue { 
		get{ return this["totalgross"];}
		set {if (value==null|| value==DBNull.Value) this["totalgross"]= DBNull.Value; else this["totalgross"]= value;}
	}
	public Decimal? totalgrossOriginal { 
		get {if (this["totalgross",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalgross",DataRowVersion.Original];}
	}
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
	public Int32? iddaliaposition{ 
		get {if (this["iddaliaposition"]==DBNull.Value)return null; return  (Int32?)this["iddaliaposition"];}
		set {if (value==null) this["iddaliaposition"]= DBNull.Value; else this["iddaliaposition"]= value;}
	}
	public object iddaliapositionValue { 
		get{ return this["iddaliaposition"];}
		set {if (value==null|| value==DBNull.Value) this["iddaliaposition"]= DBNull.Value; else this["iddaliaposition"]= value;}
	}
	public Int32? iddaliapositionOriginal { 
		get {if (this["iddaliaposition",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddaliaposition",DataRowVersion.Original];}
	}
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
	public Int32? iddaliarecruitmentmotive{ 
		get {if (this["iddaliarecruitmentmotive"]==DBNull.Value)return null; return  (Int32?)this["iddaliarecruitmentmotive"];}
		set {if (value==null) this["iddaliarecruitmentmotive"]= DBNull.Value; else this["iddaliarecruitmentmotive"]= value;}
	}
	public object iddaliarecruitmentmotiveValue { 
		get{ return this["iddaliarecruitmentmotive"];}
		set {if (value==null|| value==DBNull.Value) this["iddaliarecruitmentmotive"]= DBNull.Value; else this["iddaliarecruitmentmotive"]= value;}
	}
	public Int32? iddaliarecruitmentmotiveOriginal { 
		get {if (this["iddaliarecruitmentmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddaliarecruitmentmotive",DataRowVersion.Original];}
	}
	public Int32? iddalia_dipartimento{ 
		get {if (this["iddalia_dipartimento"]==DBNull.Value)return null; return  (Int32?)this["iddalia_dipartimento"];}
		set {if (value==null) this["iddalia_dipartimento"]= DBNull.Value; else this["iddalia_dipartimento"]= value;}
	}
	public object iddalia_dipartimentoValue { 
		get{ return this["iddalia_dipartimento"];}
		set {if (value==null|| value==DBNull.Value) this["iddalia_dipartimento"]= DBNull.Value; else this["iddalia_dipartimento"]= value;}
	}
	public Int32? iddalia_dipartimentoOriginal { 
		get {if (this["iddalia_dipartimento",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddalia_dipartimento",DataRowVersion.Original];}
	}
	public Int32? iddalia_funzionale{ 
		get {if (this["iddalia_funzionale"]==DBNull.Value)return null; return  (Int32?)this["iddalia_funzionale"];}
		set {if (value==null) this["iddalia_funzionale"]= DBNull.Value; else this["iddalia_funzionale"]= value;}
	}
	public object iddalia_funzionaleValue { 
		get{ return this["iddalia_funzionale"];}
		set {if (value==null|| value==DBNull.Value) this["iddalia_funzionale"]= DBNull.Value; else this["iddalia_funzionale"]= value;}
	}
	public Int32? iddalia_funzionaleOriginal { 
		get {if (this["iddalia_funzionale",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddalia_funzionale",DataRowVersion.Original];}
	}
	public String flagexcludefromcertificate{ 
		get {if (this["flagexcludefromcertificate"]==DBNull.Value)return null; return  (String)this["flagexcludefromcertificate"];}
		set {if (value==null) this["flagexcludefromcertificate"]= DBNull.Value; else this["flagexcludefromcertificate"]= value;}
	}
	public object flagexcludefromcertificateValue { 
		get{ return this["flagexcludefromcertificate"];}
		set {if (value==null|| value==DBNull.Value) this["flagexcludefromcertificate"]= DBNull.Value; else this["flagexcludefromcertificate"]= value;}
	}
	public String flagexcludefromcertificateOriginal { 
		get {if (this["flagexcludefromcertificate",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagexcludefromcertificate",DataRowVersion.Original];}
	}
	#endregion

}
public class profserviceTable : MetaTableBase<profserviceRow> {
	public profserviceTable() : base("profservice"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ncon",createColumn("ncon",typeof(int),false,false)},
			{"ycon",createColumn("ycon",typeof(int),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"doc",createColumn("doc",typeof(string),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"feegross",createColumn("feegross",typeof(decimal),false,false)},
			{"flaginvoiced",createColumn("flaginvoiced",typeof(string),true,false)},
			{"idaccmotive",createColumn("idaccmotive",typeof(string),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"ivaamount",createColumn("ivaamount",typeof(decimal),true,false)},
			{"ivafieldnumber",createColumn("ivafieldnumber",typeof(int),true,false)},
			{"ivarate",createColumn("ivarate",typeof(decimal),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"ndays",createColumn("ndays",typeof(int),false,false)},
			{"ninv",createColumn("ninv",typeof(int),true,false)},
			{"pensioncontributionrate",createColumn("pensioncontributionrate",typeof(decimal),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"socialsecurityrate",createColumn("socialsecurityrate",typeof(decimal),true,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"stop",createColumn("stop",typeof(DateTime),false,false)},
			{"totalcost",createColumn("totalcost",typeof(decimal),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"yinv",createColumn("yinv",typeof(short),true,false)},
			{"flagmixed",createColumn("flagmixed",typeof(string),true,false)},
			{"idser",createColumn("idser",typeof(int),false,false)},
			{"idivakind",createColumn("idivakind",typeof(int),true,false)},
			{"idinvkind",createColumn("idinvkind",typeof(int),true,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
			{"idaccmotivedebit",createColumn("idaccmotivedebit",typeof(string),true,false)},
			{"idaccmotivedebit_crg",createColumn("idaccmotivedebit_crg",typeof(string),true,false)},
			{"idaccmotivedebit_datacrg",createColumn("idaccmotivedebit_datacrg",typeof(DateTime),true,false)},
			{"authdoc",createColumn("authdoc",typeof(string),true,false)},
			{"authdocdate",createColumn("authdocdate",typeof(DateTime),true,false)},
			{"authneeded",createColumn("authneeded",typeof(string),true,false)},
			{"noauthreason",createColumn("noauthreason",typeof(string),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"totalgross",createColumn("totalgross",typeof(decimal),true,false)},
			{"epkind",createColumn("epkind",typeof(string),true,false)},
			{"iddaliaposition",createColumn("iddaliaposition",typeof(int),true,false)},
			{"idsor_siope",createColumn("idsor_siope",typeof(int),true,false)},
			{"requested_doc",createColumn("requested_doc",typeof(int),true,false)},
			{"iddaliarecruitmentmotive",createColumn("iddaliarecruitmentmotive",typeof(int),true,false)},
			{"iddalia_dipartimento",createColumn("iddalia_dipartimento",typeof(int),true,false)},
			{"iddalia_funzionale",createColumn("iddalia_funzionale",typeof(int),true,false)},
			{"flagexcludefromcertificate",createColumn("flagexcludefromcertificate",typeof(string),true,false)},
		};
	}
}
}
