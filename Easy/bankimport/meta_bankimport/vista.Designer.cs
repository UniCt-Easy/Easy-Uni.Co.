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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_bankimport {
public class bankimportRow: MetaRow  {
	public bankimportRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///#
	///</summary>
	public Int32? idbankimport{ 
		get {if (this["idbankimport"]==DBNull.Value)return null; return  (Int32?)this["idbankimport"];}
		set {if (value==null) this["idbankimport"]= DBNull.Value; else this["idbankimport"]= value;}
	}
	public object idbankimportValue { 
		get{ return this["idbankimport"];}
		set {if (value==null|| value==DBNull.Value) this["idbankimport"]= DBNull.Value; else this["idbankimport"]= value;}
	}
	public Int32? idbankimportOriginal { 
		get {if (this["idbankimport",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idbankimport",DataRowVersion.Original];}
	}
	///<summary>
	///Data ultimo mandato presente nel flusso
	///</summary>
	public DateTime? lastpayment{ 
		get {if (this["lastpayment"]==DBNull.Value)return null; return  (DateTime?)this["lastpayment"];}
		set {if (value==null) this["lastpayment"]= DBNull.Value; else this["lastpayment"]= value;}
	}
	public object lastpaymentValue { 
		get{ return this["lastpayment"];}
		set {if (value==null|| value==DBNull.Value) this["lastpayment"]= DBNull.Value; else this["lastpayment"]= value;}
	}
	public DateTime? lastpaymentOriginal { 
		get {if (this["lastpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lastpayment",DataRowVersion.Original];}
	}
	///<summary>
	///Data ultima reversale presente nel flusso
	///</summary>
	public DateTime? lastproceeds{ 
		get {if (this["lastproceeds"]==DBNull.Value)return null; return  (DateTime?)this["lastproceeds"];}
		set {if (value==null) this["lastproceeds"]= DBNull.Value; else this["lastproceeds"]= value;}
	}
	public object lastproceedsValue { 
		get{ return this["lastproceeds"];}
		set {if (value==null|| value==DBNull.Value) this["lastproceeds"]= DBNull.Value; else this["lastproceeds"]= value;}
	}
	public DateTime? lastproceedsOriginal { 
		get {if (this["lastproceeds",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lastproceeds",DataRowVersion.Original];}
	}
	///<summary>
	///Data ultimo provvisorio di entrata presente nel flusso
	///</summary>
	public DateTime? lastbillincome{ 
		get {if (this["lastbillincome"]==DBNull.Value)return null; return  (DateTime?)this["lastbillincome"];}
		set {if (value==null) this["lastbillincome"]= DBNull.Value; else this["lastbillincome"]= value;}
	}
	public object lastbillincomeValue { 
		get{ return this["lastbillincome"];}
		set {if (value==null|| value==DBNull.Value) this["lastbillincome"]= DBNull.Value; else this["lastbillincome"]= value;}
	}
	public DateTime? lastbillincomeOriginal { 
		get {if (this["lastbillincome",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lastbillincome",DataRowVersion.Original];}
	}
	///<summary>
	///Data ultimo provvisorio di uscita presente nel flusso
	///</summary>
	public DateTime? lastbillexpense{ 
		get {if (this["lastbillexpense"]==DBNull.Value)return null; return  (DateTime?)this["lastbillexpense"];}
		set {if (value==null) this["lastbillexpense"]= DBNull.Value; else this["lastbillexpense"]= value;}
	}
	public object lastbillexpenseValue { 
		get{ return this["lastbillexpense"];}
		set {if (value==null|| value==DBNull.Value) this["lastbillexpense"]= DBNull.Value; else this["lastbillexpense"]= value;}
	}
	public DateTime? lastbillexpenseOriginal { 
		get {if (this["lastbillexpense",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lastbillexpense",DataRowVersion.Original];}
	}
	///<summary>
	///Tot.pagamenti
	///</summary>
	public Decimal? totalpayment{ 
		get {if (this["totalpayment"]==DBNull.Value)return null; return  (Decimal?)this["totalpayment"];}
		set {if (value==null) this["totalpayment"]= DBNull.Value; else this["totalpayment"]= value;}
	}
	public object totalpaymentValue { 
		get{ return this["totalpayment"];}
		set {if (value==null|| value==DBNull.Value) this["totalpayment"]= DBNull.Value; else this["totalpayment"]= value;}
	}
	public Decimal? totalpaymentOriginal { 
		get {if (this["totalpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalpayment",DataRowVersion.Original];}
	}
	///<summary>
	///Tot.incassi
	///</summary>
	public Decimal? totalproceeds{ 
		get {if (this["totalproceeds"]==DBNull.Value)return null; return  (Decimal?)this["totalproceeds"];}
		set {if (value==null) this["totalproceeds"]= DBNull.Value; else this["totalproceeds"]= value;}
	}
	public object totalproceedsValue { 
		get{ return this["totalproceeds"];}
		set {if (value==null|| value==DBNull.Value) this["totalproceeds"]= DBNull.Value; else this["totalproceeds"]= value;}
	}
	public Decimal? totalproceedsOriginal { 
		get {if (this["totalproceeds",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalproceeds",DataRowVersion.Original];}
	}
	///<summary>
	///Sospesi entrata (+)
	///</summary>
	public Decimal? totalbillincome_plus{ 
		get {if (this["totalbillincome_plus"]==DBNull.Value)return null; return  (Decimal?)this["totalbillincome_plus"];}
		set {if (value==null) this["totalbillincome_plus"]= DBNull.Value; else this["totalbillincome_plus"]= value;}
	}
	public object totalbillincome_plusValue { 
		get{ return this["totalbillincome_plus"];}
		set {if (value==null|| value==DBNull.Value) this["totalbillincome_plus"]= DBNull.Value; else this["totalbillincome_plus"]= value;}
	}
	public Decimal? totalbillincome_plusOriginal { 
		get {if (this["totalbillincome_plus",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalbillincome_plus",DataRowVersion.Original];}
	}
	///<summary>
	///Sospesi entrata (-)
	///</summary>
	public Decimal? totalbillincome_minus{ 
		get {if (this["totalbillincome_minus"]==DBNull.Value)return null; return  (Decimal?)this["totalbillincome_minus"];}
		set {if (value==null) this["totalbillincome_minus"]= DBNull.Value; else this["totalbillincome_minus"]= value;}
	}
	public object totalbillincome_minusValue { 
		get{ return this["totalbillincome_minus"];}
		set {if (value==null|| value==DBNull.Value) this["totalbillincome_minus"]= DBNull.Value; else this["totalbillincome_minus"]= value;}
	}
	public Decimal? totalbillincome_minusOriginal { 
		get {if (this["totalbillincome_minus",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalbillincome_minus",DataRowVersion.Original];}
	}
	///<summary>
	///Sospesi uscita (+)
	///</summary>
	public Decimal? totalbillexpense_plus{ 
		get {if (this["totalbillexpense_plus"]==DBNull.Value)return null; return  (Decimal?)this["totalbillexpense_plus"];}
		set {if (value==null) this["totalbillexpense_plus"]= DBNull.Value; else this["totalbillexpense_plus"]= value;}
	}
	public object totalbillexpense_plusValue { 
		get{ return this["totalbillexpense_plus"];}
		set {if (value==null|| value==DBNull.Value) this["totalbillexpense_plus"]= DBNull.Value; else this["totalbillexpense_plus"]= value;}
	}
	public Decimal? totalbillexpense_plusOriginal { 
		get {if (this["totalbillexpense_plus",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalbillexpense_plus",DataRowVersion.Original];}
	}
	///<summary>
	///Sospesi uscita (-)
	///</summary>
	public Decimal? totalbillexpense_minus{ 
		get {if (this["totalbillexpense_minus"]==DBNull.Value)return null; return  (Decimal?)this["totalbillexpense_minus"];}
		set {if (value==null) this["totalbillexpense_minus"]= DBNull.Value; else this["totalbillexpense_minus"]= value;}
	}
	public object totalbillexpense_minusValue { 
		get{ return this["totalbillexpense_minus"];}
		set {if (value==null|| value==DBNull.Value) this["totalbillexpense_minus"]= DBNull.Value; else this["totalbillexpense_minus"]= value;}
	}
	public Decimal? totalbillexpense_minusOriginal { 
		get {if (this["totalbillexpense_minus",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalbillexpense_minus",DataRowVersion.Original];}
	}
	///<summary>
	///ABI
	///</summary>
	public String idbank{ 
		get {if (this["idbank"]==DBNull.Value)return null; return  (String)this["idbank"];}
		set {if (value==null) this["idbank"]= DBNull.Value; else this["idbank"]= value;}
	}
	public object idbankValue { 
		get{ return this["idbank"];}
		set {if (value==null|| value==DBNull.Value) this["idbank"]= DBNull.Value; else this["idbank"]= value;}
	}
	public String idbankOriginal { 
		get {if (this["idbank",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idbank",DataRowVersion.Original];}
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
	public String identificativo_flusso_bt{ 
		get {if (this["identificativo_flusso_bt"]==DBNull.Value)return null; return  (String)this["identificativo_flusso_bt"];}
		set {if (value==null) this["identificativo_flusso_bt"]= DBNull.Value; else this["identificativo_flusso_bt"]= value;}
	}
	public object identificativo_flusso_btValue { 
		get{ return this["identificativo_flusso_bt"];}
		set {if (value==null|| value==DBNull.Value) this["identificativo_flusso_bt"]= DBNull.Value; else this["identificativo_flusso_bt"]= value;}
	}
	public String identificativo_flusso_btOriginal { 
		get {if (this["identificativo_flusso_bt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["identificativo_flusso_bt",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Importazione esiti e sospesi
///</summary>
public class bankimportTable : MetaTableBase<bankimportRow> {
	public bankimportTable() : base("bankimport"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idbankimport",createColumn("idbankimport",typeof(int),false,false)},
			{"lastpayment",createColumn("lastpayment",typeof(DateTime),true,false)},
			{"lastproceeds",createColumn("lastproceeds",typeof(DateTime),true,false)},
			{"lastbillincome",createColumn("lastbillincome",typeof(DateTime),true,false)},
			{"lastbillexpense",createColumn("lastbillexpense",typeof(DateTime),true,false)},
			{"totalpayment",createColumn("totalpayment",typeof(decimal),true,false)},
			{"totalproceeds",createColumn("totalproceeds",typeof(decimal),true,false)},
			{"totalbillincome_plus",createColumn("totalbillincome_plus",typeof(decimal),true,false)},
			{"totalbillincome_minus",createColumn("totalbillincome_minus",typeof(decimal),true,false)},
			{"totalbillexpense_plus",createColumn("totalbillexpense_plus",typeof(decimal),true,false)},
			{"totalbillexpense_minus",createColumn("totalbillexpense_minus",typeof(decimal),true,false)},
			{"idbank",createColumn("idbank",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"adate",createColumn("adate",typeof(DateTime),true,false)},
			{"ayear",createColumn("ayear",typeof(short),true,false)},
			{"identificativo_flusso_bt",createColumn("identificativo_flusso_bt",typeof(string),true,false)},
		};
	}
}
}
