
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace meta_payroll {
public class payrollRow: MetaRow  {
	public payrollRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Id cedolino (tabella payroll)
	///</summary>
	public Int32? idpayroll{ 
		get {if (this["idpayroll"]==DBNull.Value)return null; return  (Int32?)this["idpayroll"];}
		set {if (value==null) this["idpayroll"]= DBNull.Value; else this["idpayroll"]= value;}
	}
	public object idpayrollValue { 
		get{ return this["idpayroll"];}
		set {if (value==null|| value==DBNull.Value) this["idpayroll"]= DBNull.Value; else this["idpayroll"]= value;}
	}
	public Int32? idpayrollOriginal { 
		get {if (this["idpayroll",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpayroll",DataRowVersion.Original];}
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
	///Arrotond.
	///</summary>
	public Decimal? currentrounding{ 
		get {if (this["currentrounding"]==DBNull.Value)return null; return  (Decimal?)this["currentrounding"];}
		set {if (value==null) this["currentrounding"]= DBNull.Value; else this["currentrounding"]= value;}
	}
	public object currentroundingValue { 
		get{ return this["currentrounding"];}
		set {if (value==null|| value==DBNull.Value) this["currentrounding"]= DBNull.Value; else this["currentrounding"]= value;}
	}
	public Decimal? currentroundingOriginal { 
		get {if (this["currentrounding",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["currentrounding",DataRowVersion.Original];}
	}
	///<summary>
	///Erogazione
	///</summary>
	public DateTime? disbursementdate{ 
		get {if (this["disbursementdate"]==DBNull.Value)return null; return  (DateTime?)this["disbursementdate"];}
		set {if (value==null) this["disbursementdate"]= DBNull.Value; else this["disbursementdate"]= value;}
	}
	public object disbursementdateValue { 
		get{ return this["disbursementdate"];}
		set {if (value==null|| value==DBNull.Value) this["disbursementdate"]= DBNull.Value; else this["disbursementdate"]= value;}
	}
	public DateTime? disbursementdateOriginal { 
		get {if (this["disbursementdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["disbursementdate",DataRowVersion.Original];}
	}
	///<summary>
	///Applica Ag.Fiscali
	///</summary>
	public String enabletaxrelief{ 
		get {if (this["enabletaxrelief"]==DBNull.Value)return null; return  (String)this["enabletaxrelief"];}
		set {if (value==null) this["enabletaxrelief"]= DBNull.Value; else this["enabletaxrelief"]= value;}
	}
	public object enabletaxreliefValue { 
		get{ return this["enabletaxrelief"];}
		set {if (value==null|| value==DBNull.Value) this["enabletaxrelief"]= DBNull.Value; else this["enabletaxrelief"]= value;}
	}
	public String enabletaxreliefOriginal { 
		get {if (this["enabletaxrelief",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["enabletaxrelief",DataRowVersion.Original];}
	}
	///<summary>
	///Importo lordo
	///</summary>
	public Decimal? feegross{ 
		get {if (this["feegross"]==DBNull.Value)return null; return  (Decimal?)this["feegross"];}
		set {if (value==null) this["feegross"]= DBNull.Value; else this["feegross"]= value;}
	}
	public object feegrossValue { 
		get{ return this["feegross"];}
		set {if (value==null|| value==DBNull.Value) this["feegross"]= DBNull.Value; else this["feegross"]= value;}
	}
	public Decimal? feegrossOriginal { 
		get {if (this["feegross",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["feegross",DataRowVersion.Original];}
	}
	///<summary>
	///Anno fiscale
	///</summary>
	public Int32? fiscalyear{ 
		get {if (this["fiscalyear"]==DBNull.Value)return null; return  (Int32?)this["fiscalyear"];}
		set {if (value==null) this["fiscalyear"]= DBNull.Value; else this["fiscalyear"]= value;}
	}
	public object fiscalyearValue { 
		get{ return this["fiscalyear"];}
		set {if (value==null|| value==DBNull.Value) this["fiscalyear"]= DBNull.Value; else this["fiscalyear"]= value;}
	}
	public Int32? fiscalyearOriginal { 
		get {if (this["fiscalyear",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["fiscalyear",DataRowVersion.Original];}
	}
	///<summary>
	///Conguaglio
	///	 N: Cedolino ordinario
	///	 S: Conguaglio
	///</summary>
	public String flagbalance{ 
		get {if (this["flagbalance"]==DBNull.Value)return null; return  (String)this["flagbalance"];}
		set {if (value==null) this["flagbalance"]= DBNull.Value; else this["flagbalance"]= value;}
	}
	public object flagbalanceValue { 
		get{ return this["flagbalance"];}
		set {if (value==null|| value==DBNull.Value) this["flagbalance"]= DBNull.Value; else this["flagbalance"]= value;}
	}
	public String flagbalanceOriginal { 
		get {if (this["flagbalance",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagbalance",DataRowVersion.Original];}
	}
	///<summary>
	///Calcolato
	///	 N: Non ancora calcolato
	///	 S: Calcolato
	///</summary>
	public String flagcomputed{ 
		get {if (this["flagcomputed"]==DBNull.Value)return null; return  (String)this["flagcomputed"];}
		set {if (value==null) this["flagcomputed"]= DBNull.Value; else this["flagcomputed"]= value;}
	}
	public object flagcomputedValue { 
		get{ return this["flagcomputed"];}
		set {if (value==null|| value==DBNull.Value) this["flagcomputed"]= DBNull.Value; else this["flagcomputed"]= value;}
	}
	public String flagcomputedOriginal { 
		get {if (this["flagcomputed",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagcomputed",DataRowVersion.Original];}
	}
	///<summary>
	///ID contratto
	///</summary>
	public String idcon{ 
		get {if (this["idcon"]==DBNull.Value)return null; return  (String)this["idcon"];}
		set {if (value==null) this["idcon"]= DBNull.Value; else this["idcon"]= value;}
	}
	public object idconValue { 
		get{ return this["idcon"];}
		set {if (value==null|| value==DBNull.Value) this["idcon"]= DBNull.Value; else this["idcon"]= value;}
	}
	public String idconOriginal { 
		get {if (this["idcon",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idcon",DataRowVersion.Original];}
	}
	///<summary>
	///ID  Tipo Residenza (tabella residence)
	///</summary>
	public Int32? idresidence{ 
		get {if (this["idresidence"]==DBNull.Value)return null; return  (Int32?)this["idresidence"];}
		set {if (value==null) this["idresidence"]= DBNull.Value; else this["idresidence"]= value;}
	}
	public object idresidenceValue { 
		get{ return this["idresidence"];}
		set {if (value==null|| value==DBNull.Value) this["idresidence"]= DBNull.Value; else this["idresidence"]= value;}
	}
	public Int32? idresidenceOriginal { 
		get {if (this["idresidence",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idresidence",DataRowVersion.Original];}
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
	///Comp.netto
	///</summary>
	public Decimal? netfee{ 
		get {if (this["netfee"]==DBNull.Value)return null; return  (Decimal?)this["netfee"];}
		set {if (value==null) this["netfee"]= DBNull.Value; else this["netfee"]= value;}
	}
	public object netfeeValue { 
		get{ return this["netfee"];}
		set {if (value==null|| value==DBNull.Value) this["netfee"]= DBNull.Value; else this["netfee"]= value;}
	}
	public Decimal? netfeeOriginal { 
		get {if (this["netfee",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["netfee",DataRowVersion.Original];}
	}
	///<summary>
	///Progressivo Anno
	///</summary>
	public Int32? npayroll{ 
		get {if (this["npayroll"]==DBNull.Value)return null; return  (Int32?)this["npayroll"];}
		set {if (value==null) this["npayroll"]= DBNull.Value; else this["npayroll"]= value;}
	}
	public object npayrollValue { 
		get{ return this["npayroll"];}
		set {if (value==null|| value==DBNull.Value) this["npayroll"]= DBNull.Value; else this["npayroll"]= value;}
	}
	public Int32? npayrollOriginal { 
		get {if (this["npayroll",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["npayroll",DataRowVersion.Original];}
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
	///gg. lavorati
	///</summary>
	public Int16? workingdays{ 
		get {if (this["workingdays"]==DBNull.Value)return null; return  (Int16?)this["workingdays"];}
		set {if (value==null) this["workingdays"]= DBNull.Value; else this["workingdays"]= value;}
	}
	public object workingdaysValue { 
		get{ return this["workingdays"];}
		set {if (value==null|| value==DBNull.Value) this["workingdays"]= DBNull.Value; else this["workingdays"]= value;}
	}
	public Int16? workingdaysOriginal { 
		get {if (this["workingdays",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["workingdays",DataRowVersion.Original];}
	}
	///<summary>
	///Cedolino di riepilogo 
	///</summary>
	public String flagsummarybalance{ 
		get {if (this["flagsummarybalance"]==DBNull.Value)return null; return  (String)this["flagsummarybalance"];}
		set {if (value==null) this["flagsummarybalance"]= DBNull.Value; else this["flagsummarybalance"]= value;}
	}
	public object flagsummarybalanceValue { 
		get{ return this["flagsummarybalance"];}
		set {if (value==null|| value==DBNull.Value) this["flagsummarybalance"]= DBNull.Value; else this["flagsummarybalance"]= value;}
	}
	public String flagsummarybalanceOriginal { 
		get {if (this["flagsummarybalance",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagsummarybalance",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///Cedolino
///</summary>
public class payrollTable : MetaTableBase<payrollRow> {
	public payrollTable() : base("payroll"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idpayroll",createColumn("idpayroll",typeof(int),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"currentrounding",createColumn("currentrounding",typeof(decimal),false,false)},
			{"disbursementdate",createColumn("disbursementdate",typeof(DateTime),true,false)},
			{"enabletaxrelief",createColumn("enabletaxrelief",typeof(string),false,false)},
			{"feegross",createColumn("feegross",typeof(decimal),false,false)},
			{"fiscalyear",createColumn("fiscalyear",typeof(int),false,false)},
			{"flagbalance",createColumn("flagbalance",typeof(string),true,false)},
			{"flagcomputed",createColumn("flagcomputed",typeof(string),false,false)},
			{"idcon",createColumn("idcon",typeof(string),false,false)},
			{"idresidence",createColumn("idresidence",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"netfee",createColumn("netfee",typeof(decimal),true,false)},
			{"npayroll",createColumn("npayroll",typeof(int),false,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"stop",createColumn("stop",typeof(DateTime),false,false)},
			{"workingdays",createColumn("workingdays",typeof(short),false,false)},
			{"flagsummarybalance",createColumn("flagsummarybalance",typeof(string),true,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
		};
	}
}
}
