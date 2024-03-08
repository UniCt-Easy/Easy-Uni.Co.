
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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
namespace meta_banktransaction {
public class banktransactionRow: MetaRow  {
	public banktransactionRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///N. transazione bancaria
	///</summary>
	public Int32? nban{ 
		get {if (this["nban"]==DBNull.Value)return null; return  (Int32?)this["nban"];}
		set {if (value==null) this["nban"]= DBNull.Value; else this["nban"]= value;}
	}
	public object nbanValue { 
		get{ return this["nban"];}
		set {if (value==null|| value==DBNull.Value) this["nban"]= DBNull.Value; else this["nban"]= value;}
	}
	public Int32? nbanOriginal { 
		get {if (this["nban",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nban",DataRowVersion.Original];}
	}
	///<summary>
	///Anno transazione bancaria
	///</summary>
	public Int16? yban{ 
		get {if (this["yban"]==DBNull.Value)return null; return  (Int16?)this["yban"];}
		set {if (value==null) this["yban"]= DBNull.Value; else this["yban"]= value;}
	}
	public object ybanValue { 
		get{ return this["yban"];}
		set {if (value==null|| value==DBNull.Value) this["yban"]= DBNull.Value; else this["yban"]= value;}
	}
	public Int16? ybanOriginal { 
		get {if (this["yban",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yban",DataRowVersion.Original];}
	}
	///<summary>
	///importo
	///</summary>
	public Decimal? amount{ 
		get {if (this["amount"]==DBNull.Value)return null; return  (Decimal?)this["amount"];}
		set {if (value==null) this["amount"]= DBNull.Value; else this["amount"]= value;}
	}
	public object amountValue { 
		get{ return this["amount"];}
		set {if (value==null|| value==DBNull.Value) this["amount"]= DBNull.Value; else this["amount"]= value;}
	}
	public Decimal? amountOriginal { 
		get {if (this["amount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["amount",DataRowVersion.Original];}
	}
	///<summary>
	///Riferimento banca
	///</summary>
	public String bankreference{ 
		get {if (this["bankreference"]==DBNull.Value)return null; return  (String)this["bankreference"];}
		set {if (value==null) this["bankreference"]= DBNull.Value; else this["bankreference"]= value;}
	}
	public object bankreferenceValue { 
		get{ return this["bankreference"];}
		set {if (value==null|| value==DBNull.Value) this["bankreference"]= DBNull.Value; else this["bankreference"]= value;}
	}
	public String bankreferenceOriginal { 
		get {if (this["bankreference",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["bankreference",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo
	///</summary>
	public String kind{ 
		get {if (this["kind"]==DBNull.Value)return null; return  (String)this["kind"];}
		set {if (value==null) this["kind"]= DBNull.Value; else this["kind"]= value;}
	}
	public object kindValue { 
		get{ return this["kind"];}
		set {if (value==null|| value==DBNull.Value) this["kind"]= DBNull.Value; else this["kind"]= value;}
	}
	public String kindOriginal { 
		get {if (this["kind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["kind",DataRowVersion.Original];}
	}
	///<summary>
	///Data operazione
	///</summary>
	public DateTime? transactiondate{ 
		get {if (this["transactiondate"]==DBNull.Value)return null; return  (DateTime?)this["transactiondate"];}
		set {if (value==null) this["transactiondate"]= DBNull.Value; else this["transactiondate"]= value;}
	}
	public object transactiondateValue { 
		get{ return this["transactiondate"];}
		set {if (value==null|| value==DBNull.Value) this["transactiondate"]= DBNull.Value; else this["transactiondate"]= value;}
	}
	public DateTime? transactiondateOriginal { 
		get {if (this["transactiondate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["transactiondate",DataRowVersion.Original];}
	}
	///<summary>
	///Data valuta
	///</summary>
	public DateTime? valuedate{ 
		get {if (this["valuedate"]==DBNull.Value)return null; return  (DateTime?)this["valuedate"];}
		set {if (value==null) this["valuedate"]= DBNull.Value; else this["valuedate"]= value;}
	}
	public object valuedateValue { 
		get{ return this["valuedate"];}
		set {if (value==null|| value==DBNull.Value) this["valuedate"]= DBNull.Value; else this["valuedate"]= value;}
	}
	public DateTime? valuedateOriginal { 
		get {if (this["valuedate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["valuedate",DataRowVersion.Original];}
	}
	///<summary>
	///N. submovimento di pagamento (campo di expenselast)
	///</summary>
	public Int32? idpay{ 
		get {if (this["idpay"]==DBNull.Value)return null; return  (Int32?)this["idpay"];}
		set {if (value==null) this["idpay"]= DBNull.Value; else this["idpay"]= value;}
	}
	public object idpayValue { 
		get{ return this["idpay"];}
		set {if (value==null|| value==DBNull.Value) this["idpay"]= DBNull.Value; else this["idpay"]= value;}
	}
	public Int32? idpayOriginal { 
		get {if (this["idpay",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpay",DataRowVersion.Original];}
	}
	///<summary>
	///N. submovimento di incasso (campo di incomelast)
	///</summary>
	public Int32? idpro{ 
		get {if (this["idpro"]==DBNull.Value)return null; return  (Int32?)this["idpro"];}
		set {if (value==null) this["idpro"]= DBNull.Value; else this["idpro"]= value;}
	}
	public object idproValue { 
		get{ return this["idpro"];}
		set {if (value==null|| value==DBNull.Value) this["idpro"]= DBNull.Value; else this["idpro"]= value;}
	}
	public Int32? idproOriginal { 
		get {if (this["idpro",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpro",DataRowVersion.Original];}
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
	///id mov. spesa (tabella expense)
	///</summary>
	public Int32? idexp{ 
		get {if (this["idexp"]==DBNull.Value)return null; return  (Int32?)this["idexp"];}
		set {if (value==null) this["idexp"]= DBNull.Value; else this["idexp"]= value;}
	}
	public object idexpValue { 
		get{ return this["idexp"];}
		set {if (value==null|| value==DBNull.Value) this["idexp"]= DBNull.Value; else this["idexp"]= value;}
	}
	public Int32? idexpOriginal { 
		get {if (this["idexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idexp",DataRowVersion.Original];}
	}
	///<summary>
	///id mov. entrata (tabella income)
	///</summary>
	public Int32? idinc{ 
		get {if (this["idinc"]==DBNull.Value)return null; return  (Int32?)this["idinc"];}
		set {if (value==null) this["idinc"]= DBNull.Value; else this["idinc"]= value;}
	}
	public object idincValue { 
		get{ return this["idinc"];}
		set {if (value==null|| value==DBNull.Value) this["idinc"]= DBNull.Value; else this["idinc"]= value;}
	}
	public Int32? idincOriginal { 
		get {if (this["idinc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinc",DataRowVersion.Original];}
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
	///chiave reversale (tabella proceeds)
	///</summary>
	public Int32? kpro{ 
		get {if (this["kpro"]==DBNull.Value)return null; return  (Int32?)this["kpro"];}
		set {if (value==null) this["kpro"]= DBNull.Value; else this["kpro"]= value;}
	}
	public object kproValue { 
		get{ return this["kpro"];}
		set {if (value==null|| value==DBNull.Value) this["kpro"]= DBNull.Value; else this["kpro"]= value;}
	}
	public Int32? kproOriginal { 
		get {if (this["kpro",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kpro",DataRowVersion.Original];}
	}
	///<summary>
	///ID Importazione esiti e sospesi (tabella bankimport)
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
	///Causale (descrizione)
	///</summary>
	public String motive{ 
		get {if (this["motive"]==DBNull.Value)return null; return  (String)this["motive"];}
		set {if (value==null) this["motive"]= DBNull.Value; else this["motive"]= value;}
	}
	public object motiveValue { 
		get{ return this["motive"];}
		set {if (value==null|| value==DBNull.Value) this["motive"]= DBNull.Value; else this["motive"]= value;}
	}
	public String motiveOriginal { 
		get {if (this["motive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motive",DataRowVersion.Original];}
	}
	///<summary>
	///N.bolletta
	///</summary>
	public Int32? nbill{ 
		get {if (this["nbill"]==DBNull.Value)return null; return  (Int32?)this["nbill"];}
		set {if (value==null) this["nbill"]= DBNull.Value; else this["nbill"]= value;}
	}
	public object nbillValue { 
		get{ return this["nbill"];}
		set {if (value==null|| value==DBNull.Value) this["nbill"]= DBNull.Value; else this["nbill"]= value;}
	}
	public Int32? nbillOriginal { 
		get {if (this["nbill",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nbill",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Movimento bancario
///</summary>
public class banktransactionTable : MetaTableBase<banktransactionRow> {
	public banktransactionTable() : base("banktransaction"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nban",createColumn("nban",typeof(Int32),false,false)},
			{"yban",createColumn("yban",typeof(Int16),false,false)},
			{"amount",createColumn("amount",typeof(Decimal),true,false)},
			{"bankreference",createColumn("bankreference",typeof(String),true,false)},
			{"kind",createColumn("kind",typeof(String),false,false)},
			{"transactiondate",createColumn("transactiondate",typeof(DateTime),true,false)},
			{"valuedate",createColumn("valuedate",typeof(DateTime),true,false)},
			{"idpay",createColumn("idpay",typeof(Int32),true,false)},
			{"idpro",createColumn("idpro",typeof(Int32),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"idexp",createColumn("idexp",typeof(Int32),true,false)},
			{"idinc",createColumn("idinc",typeof(Int32),true,false)},
			{"kpay",createColumn("kpay",typeof(Int32),true,false)},
			{"kpro",createColumn("kpro",typeof(Int32),true,false)},
			{"idbankimport",createColumn("idbankimport",typeof(Int32),true,false)},
			{"motive",createColumn("motive",typeof(String),true,false)},
			{"nbill",createColumn("nbill",typeof(Int32),true,false)},
		};
	}
}
}
