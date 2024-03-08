
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
namespace meta_surplus {
public class surplusRow: MetaRow  {
	public surplusRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///esercizio
	///</summary>
	public Int16? ayear{ 
		get {if (this["ayear"]==DBNull.Value)return null; return  (Int16?)this["ayear"];}
		set {if (value==null) this["ayear"]= DBNull.Value; else this["ayear"]= value;}
	}
	public object ayearValue { 
		get{ return this["ayear"];}
		set {if (value==null|| value==DBNull.Value) this["ayear"]= DBNull.Value; else this["ayear"]= value;}
	}
	public Int16? ayearOriginal { 
		get {if (this["ayear",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ayear",DataRowVersion.Original];}
	}
	///<summary>
	///Pag. competenza
	///</summary>
	public Decimal? competencypayments{ 
		get {if (this["competencypayments"]==DBNull.Value)return null; return  (Decimal?)this["competencypayments"];}
		set {if (value==null) this["competencypayments"]= DBNull.Value; else this["competencypayments"]= value;}
	}
	public object competencypaymentsValue { 
		get{ return this["competencypayments"];}
		set {if (value==null|| value==DBNull.Value) this["competencypayments"]= DBNull.Value; else this["competencypayments"]= value;}
	}
	public Decimal? competencypaymentsOriginal { 
		get {if (this["competencypayments",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["competencypayments",DataRowVersion.Original];}
	}
	///<summary>
	///Inc. competenza
	///</summary>
	public Decimal? competencyproceeds{ 
		get {if (this["competencyproceeds"]==DBNull.Value)return null; return  (Decimal?)this["competencyproceeds"];}
		set {if (value==null) this["competencyproceeds"]= DBNull.Value; else this["competencyproceeds"]= value;}
	}
	public object competencyproceedsValue { 
		get{ return this["competencyproceeds"];}
		set {if (value==null|| value==DBNull.Value) this["competencyproceeds"]= DBNull.Value; else this["competencyproceeds"]= value;}
	}
	public Decimal? competencyproceedsOriginal { 
		get {if (this["competencyproceeds",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["competencyproceeds",DataRowVersion.Original];}
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
	///Res. pass. corr.
	///</summary>
	public Decimal? currentexpenditure{ 
		get {if (this["currentexpenditure"]==DBNull.Value)return null; return  (Decimal?)this["currentexpenditure"];}
		set {if (value==null) this["currentexpenditure"]= DBNull.Value; else this["currentexpenditure"]= value;}
	}
	public object currentexpenditureValue { 
		get{ return this["currentexpenditure"];}
		set {if (value==null|| value==DBNull.Value) this["currentexpenditure"]= DBNull.Value; else this["currentexpenditure"]= value;}
	}
	public Decimal? currentexpenditureOriginal { 
		get {if (this["currentexpenditure",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["currentexpenditure",DataRowVersion.Original];}
	}
	///<summary>
	///Res. att. corr.
	///</summary>
	public Decimal? currentrevenue{ 
		get {if (this["currentrevenue"]==DBNull.Value)return null; return  (Decimal?)this["currentrevenue"];}
		set {if (value==null) this["currentrevenue"]= DBNull.Value; else this["currentrevenue"]= value;}
	}
	public object currentrevenueValue { 
		get{ return this["currentrevenue"];}
		set {if (value==null|| value==DBNull.Value) this["currentrevenue"]= DBNull.Value; else this["currentrevenue"]= value;}
	}
	public Decimal? currentrevenueOriginal { 
		get {if (this["currentrevenue",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["currentrevenue",DataRowVersion.Original];}
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
	///Pag. 1/1 - Data
	///</summary>
	public Decimal? paymentstilldate{ 
		get {if (this["paymentstilldate"]==DBNull.Value)return null; return  (Decimal?)this["paymentstilldate"];}
		set {if (value==null) this["paymentstilldate"]= DBNull.Value; else this["paymentstilldate"]= value;}
	}
	public object paymentstilldateValue { 
		get{ return this["paymentstilldate"];}
		set {if (value==null|| value==DBNull.Value) this["paymentstilldate"]= DBNull.Value; else this["paymentstilldate"]= value;}
	}
	public Decimal? paymentstilldateOriginal { 
		get {if (this["paymentstilldate",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["paymentstilldate",DataRowVersion.Original];}
	}
	///<summary>
	///Pag. pres. Data - 31/12
	///</summary>
	public Decimal? paymentstoendofyear{ 
		get {if (this["paymentstoendofyear"]==DBNull.Value)return null; return  (Decimal?)this["paymentstoendofyear"];}
		set {if (value==null) this["paymentstoendofyear"]= DBNull.Value; else this["paymentstoendofyear"]= value;}
	}
	public object paymentstoendofyearValue { 
		get{ return this["paymentstoendofyear"];}
		set {if (value==null|| value==DBNull.Value) this["paymentstoendofyear"]= DBNull.Value; else this["paymentstoendofyear"]= value;}
	}
	public Decimal? paymentstoendofyearOriginal { 
		get {if (this["paymentstoendofyear",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["paymentstoendofyear",DataRowVersion.Original];}
	}
	///<summary>
	///Res. pass. prec.
	///</summary>
	public Decimal? previousexpenditure{ 
		get {if (this["previousexpenditure"]==DBNull.Value)return null; return  (Decimal?)this["previousexpenditure"];}
		set {if (value==null) this["previousexpenditure"]= DBNull.Value; else this["previousexpenditure"]= value;}
	}
	public object previousexpenditureValue { 
		get{ return this["previousexpenditure"];}
		set {if (value==null|| value==DBNull.Value) this["previousexpenditure"]= DBNull.Value; else this["previousexpenditure"]= value;}
	}
	public Decimal? previousexpenditureOriginal { 
		get {if (this["previousexpenditure",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["previousexpenditure",DataRowVersion.Original];}
	}
	///<summary>
	///Res. att. prec.
	///</summary>
	public Decimal? previousrevenue{ 
		get {if (this["previousrevenue"]==DBNull.Value)return null; return  (Decimal?)this["previousrevenue"];}
		set {if (value==null) this["previousrevenue"]= DBNull.Value; else this["previousrevenue"]= value;}
	}
	public object previousrevenueValue { 
		get{ return this["previousrevenue"];}
		set {if (value==null|| value==DBNull.Value) this["previousrevenue"]= DBNull.Value; else this["previousrevenue"]= value;}
	}
	public Decimal? previousrevenueOriginal { 
		get {if (this["previousrevenue",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["previousrevenue",DataRowVersion.Original];}
	}
	///<summary>
	///Data presunto
	///</summary>
	public DateTime? previsiondate{ 
		get {if (this["previsiondate"]==DBNull.Value)return null; return  (DateTime?)this["previsiondate"];}
		set {if (value==null) this["previsiondate"]= DBNull.Value; else this["previsiondate"]= value;}
	}
	public object previsiondateValue { 
		get{ return this["previsiondate"];}
		set {if (value==null|| value==DBNull.Value) this["previsiondate"]= DBNull.Value; else this["previsiondate"]= value;}
	}
	public DateTime? previsiondateOriginal { 
		get {if (this["previsiondate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["previsiondate",DataRowVersion.Original];}
	}
	///<summary>
	///Inc. 1/1 - Data
	///</summary>
	public Decimal? proceedstilldate{ 
		get {if (this["proceedstilldate"]==DBNull.Value)return null; return  (Decimal?)this["proceedstilldate"];}
		set {if (value==null) this["proceedstilldate"]= DBNull.Value; else this["proceedstilldate"]= value;}
	}
	public object proceedstilldateValue { 
		get{ return this["proceedstilldate"];}
		set {if (value==null|| value==DBNull.Value) this["proceedstilldate"]= DBNull.Value; else this["proceedstilldate"]= value;}
	}
	public Decimal? proceedstilldateOriginal { 
		get {if (this["proceedstilldate",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["proceedstilldate",DataRowVersion.Original];}
	}
	///<summary>
	///Inc. pres. Data - 31/12
	///</summary>
	public Decimal? proceedstoendofyear{ 
		get {if (this["proceedstoendofyear"]==DBNull.Value)return null; return  (Decimal?)this["proceedstoendofyear"];}
		set {if (value==null) this["proceedstoendofyear"]= DBNull.Value; else this["proceedstoendofyear"]= value;}
	}
	public object proceedstoendofyearValue { 
		get{ return this["proceedstoendofyear"];}
		set {if (value==null|| value==DBNull.Value) this["proceedstoendofyear"]= DBNull.Value; else this["proceedstoendofyear"]= value;}
	}
	public Decimal? proceedstoendofyearOriginal { 
		get {if (this["proceedstoendofyear",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["proceedstoendofyear",DataRowVersion.Original];}
	}
	///<summary>
	///Pag. residui
	///</summary>
	public Decimal? residualpayments{ 
		get {if (this["residualpayments"]==DBNull.Value)return null; return  (Decimal?)this["residualpayments"];}
		set {if (value==null) this["residualpayments"]= DBNull.Value; else this["residualpayments"]= value;}
	}
	public object residualpaymentsValue { 
		get{ return this["residualpayments"];}
		set {if (value==null|| value==DBNull.Value) this["residualpayments"]= DBNull.Value; else this["residualpayments"]= value;}
	}
	public Decimal? residualpaymentsOriginal { 
		get {if (this["residualpayments",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["residualpayments",DataRowVersion.Original];}
	}
	///<summary>
	///Inc. residui
	///</summary>
	public Decimal? residualproceeds{ 
		get {if (this["residualproceeds"]==DBNull.Value)return null; return  (Decimal?)this["residualproceeds"];}
		set {if (value==null) this["residualproceeds"]= DBNull.Value; else this["residualproceeds"]= value;}
	}
	public object residualproceedsValue { 
		get{ return this["residualproceeds"];}
		set {if (value==null|| value==DBNull.Value) this["residualproceeds"]= DBNull.Value; else this["residualproceeds"]= value;}
	}
	public Decimal? residualproceedsOriginal { 
		get {if (this["residualproceeds",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["residualproceeds",DataRowVersion.Original];}
	}
	///<summary>
	///Avanzo cassa al 1/1
	///</summary>
	public Decimal? startfloatfund{ 
		get {if (this["startfloatfund"]==DBNull.Value)return null; return  (Decimal?)this["startfloatfund"];}
		set {if (value==null) this["startfloatfund"]= DBNull.Value; else this["startfloatfund"]= value;}
	}
	public object startfloatfundValue { 
		get{ return this["startfloatfund"];}
		set {if (value==null|| value==DBNull.Value) this["startfloatfund"]= DBNull.Value; else this["startfloatfund"]= value;}
	}
	public Decimal? startfloatfundOriginal { 
		get {if (this["startfloatfund",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["startfloatfund",DataRowVersion.Original];}
	}
	///<summary>
	///Res. pass. pres. corr.
	///</summary>
	public Decimal? supposedcurrentexpenditure{ 
		get {if (this["supposedcurrentexpenditure"]==DBNull.Value)return null; return  (Decimal?)this["supposedcurrentexpenditure"];}
		set {if (value==null) this["supposedcurrentexpenditure"]= DBNull.Value; else this["supposedcurrentexpenditure"]= value;}
	}
	public object supposedcurrentexpenditureValue { 
		get{ return this["supposedcurrentexpenditure"];}
		set {if (value==null|| value==DBNull.Value) this["supposedcurrentexpenditure"]= DBNull.Value; else this["supposedcurrentexpenditure"]= value;}
	}
	public Decimal? supposedcurrentexpenditureOriginal { 
		get {if (this["supposedcurrentexpenditure",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["supposedcurrentexpenditure",DataRowVersion.Original];}
	}
	///<summary>
	///Res. att. pres. corr.
	///</summary>
	public Decimal? supposedcurrentrevenue{ 
		get {if (this["supposedcurrentrevenue"]==DBNull.Value)return null; return  (Decimal?)this["supposedcurrentrevenue"];}
		set {if (value==null) this["supposedcurrentrevenue"]= DBNull.Value; else this["supposedcurrentrevenue"]= value;}
	}
	public object supposedcurrentrevenueValue { 
		get{ return this["supposedcurrentrevenue"];}
		set {if (value==null|| value==DBNull.Value) this["supposedcurrentrevenue"]= DBNull.Value; else this["supposedcurrentrevenue"]= value;}
	}
	public Decimal? supposedcurrentrevenueOriginal { 
		get {if (this["supposedcurrentrevenue",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["supposedcurrentrevenue",DataRowVersion.Original];}
	}
	///<summary>
	///Res. pass. pres. prec.
	///</summary>
	public Decimal? supposedpreviousexpenditure{ 
		get {if (this["supposedpreviousexpenditure"]==DBNull.Value)return null; return  (Decimal?)this["supposedpreviousexpenditure"];}
		set {if (value==null) this["supposedpreviousexpenditure"]= DBNull.Value; else this["supposedpreviousexpenditure"]= value;}
	}
	public object supposedpreviousexpenditureValue { 
		get{ return this["supposedpreviousexpenditure"];}
		set {if (value==null|| value==DBNull.Value) this["supposedpreviousexpenditure"]= DBNull.Value; else this["supposedpreviousexpenditure"]= value;}
	}
	public Decimal? supposedpreviousexpenditureOriginal { 
		get {if (this["supposedpreviousexpenditure",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["supposedpreviousexpenditure",DataRowVersion.Original];}
	}
	///<summary>
	///Res. att. pres. prec.
	///</summary>
	public Decimal? supposedpreviousrevenue{ 
		get {if (this["supposedpreviousrevenue"]==DBNull.Value)return null; return  (Decimal?)this["supposedpreviousrevenue"];}
		set {if (value==null) this["supposedpreviousrevenue"]= DBNull.Value; else this["supposedpreviousrevenue"]= value;}
	}
	public object supposedpreviousrevenueValue { 
		get{ return this["supposedpreviousrevenue"];}
		set {if (value==null|| value==DBNull.Value) this["supposedpreviousrevenue"]= DBNull.Value; else this["supposedpreviousrevenue"]= value;}
	}
	public Decimal? supposedpreviousrevenueOriginal { 
		get {if (this["supposedpreviousrevenue",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["supposedpreviousrevenue",DataRowVersion.Original];}
	}
	///<summary>
	///bloccato
	///	 N: Non ? vero che: "bloccato"
	///	 S: bloccato
	///</summary>
	public String locked{ 
		get {if (this["locked"]==DBNull.Value)return null; return  (String)this["locked"];}
		set {if (value==null) this["locked"]= DBNull.Value; else this["locked"]= value;}
	}
	public object lockedValue { 
		get{ return this["locked"];}
		set {if (value==null|| value==DBNull.Value) this["locked"]= DBNull.Value; else this["locked"]= value;}
	}
	public String lockedOriginal { 
		get {if (this["locked",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["locked",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Situazione Finanziaria / Amministrativa
///</summary>
public class surplusTable : MetaTableBase<surplusRow> {
	public surplusTable() : base("surplus"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("ayear")){ 
			defineColumn("ayear", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("competencypayments")){ 
			defineColumn("competencypayments", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("competencyproceeds")){ 
			defineColumn("competencyproceeds", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("currentexpenditure")){ 
			defineColumn("currentexpenditure", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("currentrevenue")){ 
			defineColumn("currentrevenue", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("paymentstilldate")){ 
			defineColumn("paymentstilldate", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("paymentstoendofyear")){ 
			defineColumn("paymentstoendofyear", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("previousexpenditure")){ 
			defineColumn("previousexpenditure", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("previousrevenue")){ 
			defineColumn("previousrevenue", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("previsiondate")){ 
			defineColumn("previsiondate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("proceedstilldate")){ 
			defineColumn("proceedstilldate", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("proceedstoendofyear")){ 
			defineColumn("proceedstoendofyear", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("residualpayments")){ 
			defineColumn("residualpayments", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("residualproceeds")){ 
			defineColumn("residualproceeds", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("startfloatfund")){ 
			defineColumn("startfloatfund", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("supposedcurrentexpenditure")){ 
			defineColumn("supposedcurrentexpenditure", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("supposedcurrentrevenue")){ 
			defineColumn("supposedcurrentrevenue", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("supposedpreviousexpenditure")){ 
			defineColumn("supposedpreviousexpenditure", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("supposedpreviousrevenue")){ 
			defineColumn("supposedpreviousrevenue", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("locked")){ 
			defineColumn("locked", typeof(System.String));
		}
		#endregion

	}
}
}
