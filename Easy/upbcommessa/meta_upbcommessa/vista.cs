
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace meta_upbcommessa {
public class upbcommessaRow: MetaRow  {
	public upbcommessaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id voce upb (tabella upb)
	///</summary>
	public String idupb{ 
		get {return  (String)this["idupb"];}
		set {this["idupb"]= value;}
	}
	public object idupbValue { 
		get{ return this["idupb"];}
		set {this["idupb"]= value;}
	}
	public String idupbOriginal { 
		get {return  (String)this["idupb",DataRowVersion.Original];}
	}
	///<summary>
	///esercizio
	///</summary>
	public Int16 ayear{ 
		get {return  (Int16)this["ayear"];}
		set {this["ayear"]= value;}
	}
	public object ayearValue { 
		get{ return this["ayear"];}
		set {this["ayear"]= value;}
	}
	public Int16 ayearOriginal { 
		get {return  (Int16)this["ayear",DataRowVersion.Original];}
	}
	///<summary>
	///codice upb
	///</summary>
	public String codeupb{ 
		get {return  (String)this["codeupb"];}
		set {this["codeupb"]= value;}
	}
	public object codeupbValue { 
		get{ return this["codeupb"];}
		set {this["codeupb"]= value;}
	}
	public String codeupbOriginal { 
		get {return  (String)this["codeupb",DataRowVersion.Original];}
	}
	///<summary>
	///Denominazione
	///</summary>
	public String title{ 
		get {return  (String)this["title"];}
		set {this["title"]= value;}
	}
	public object titleValue { 
		get{ return this["title"];}
		set {this["title"]= value;}
	}
	public String titleOriginal { 
		get {return  (String)this["title",DataRowVersion.Original];}
	}
	///<summary>
	///anno data inizio 
	///</summary>
	public Int16? yearstart{ 
		get {if (this["yearstart"]==DBNull.Value)return null; return  (Int16?)this["yearstart"];}
		set {if (value==null) this["yearstart"]= DBNull.Value; else this["yearstart"]= value;}
	}
	public object yearstartValue { 
		get{ return this["yearstart"];}
		set {if (value==null|| value==DBNull.Value) this["yearstart"]= DBNull.Value; else this["yearstart"]= value;}
	}
	public Int16? yearstartOriginal { 
		get {if (this["yearstart",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yearstart",DataRowVersion.Original];}
	}
	///<summary>
	///anno data fine
	///</summary>
	public Int16? yearstop{ 
		get {if (this["yearstop"]==DBNull.Value)return null; return  (Int16?)this["yearstop"];}
		set {if (value==null) this["yearstop"]= DBNull.Value; else this["yearstop"]= value;}
	}
	public object yearstopValue { 
		get{ return this["yearstop"];}
		set {if (value==null|| value==DBNull.Value) this["yearstop"]= DBNull.Value; else this["yearstop"]= value;}
	}
	public Int16? yearstopOriginal { 
		get {if (this["yearstop",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yearstop",DataRowVersion.Original];}
	}
	///<summary>
	///tipo upb
	///</summary>
	public Int32? idepupbkind{ 
		get {if (this["idepupbkind"]==DBNull.Value)return null; return  (Int32?)this["idepupbkind"];}
		set {if (value==null) this["idepupbkind"]= DBNull.Value; else this["idepupbkind"]= value;}
	}
	public object idepupbkindValue { 
		get{ return this["idepupbkind"];}
		set {if (value==null|| value==DBNull.Value) this["idepupbkind"]= DBNull.Value; else this["idepupbkind"]= value;}
	}
	public Int32? idepupbkindOriginal { 
		get {if (this["idepupbkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepupbkind",DataRowVersion.Original];}
	}
	///<summary>
	///causale costo
	///</summary>
	public String idaccmotive_cost{ 
		get {if (this["idaccmotive_cost"]==DBNull.Value)return null; return  (String)this["idaccmotive_cost"];}
		set {if (value==null) this["idaccmotive_cost"]= DBNull.Value; else this["idaccmotive_cost"]= value;}
	}
	public object idaccmotive_costValue { 
		get{ return this["idaccmotive_cost"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_cost"]= DBNull.Value; else this["idaccmotive_cost"]= value;}
	}
	public String idaccmotive_costOriginal { 
		get {if (this["idaccmotive_cost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_cost",DataRowVersion.Original];}
	}
	///<summary>
	///causale ricavi
	///</summary>
	public String idaccmotive_revenue{ 
		get {if (this["idaccmotive_revenue"]==DBNull.Value)return null; return  (String)this["idaccmotive_revenue"];}
		set {if (value==null) this["idaccmotive_revenue"]= DBNull.Value; else this["idaccmotive_revenue"]= value;}
	}
	public object idaccmotive_revenueValue { 
		get{ return this["idaccmotive_revenue"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_revenue"]= DBNull.Value; else this["idaccmotive_revenue"]= value;}
	}
	public String idaccmotive_revenueOriginal { 
		get {if (this["idaccmotive_revenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_revenue",DataRowVersion.Original];}
	}
	///<summary>
	///causale risconto passivo
	///</summary>
	public String idaccmotive_deferredcost{ 
		get {if (this["idaccmotive_deferredcost"]==DBNull.Value)return null; return  (String)this["idaccmotive_deferredcost"];}
		set {if (value==null) this["idaccmotive_deferredcost"]= DBNull.Value; else this["idaccmotive_deferredcost"]= value;}
	}
	public object idaccmotive_deferredcostValue { 
		get{ return this["idaccmotive_deferredcost"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_deferredcost"]= DBNull.Value; else this["idaccmotive_deferredcost"]= value;}
	}
	public String idaccmotive_deferredcostOriginal { 
		get {if (this["idaccmotive_deferredcost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_deferredcost",DataRowVersion.Original];}
	}
	///<summary>
	///causale ratei attivi
	///</summary>
	public String idaccmotive_accruals{ 
		get {if (this["idaccmotive_accruals"]==DBNull.Value)return null; return  (String)this["idaccmotive_accruals"];}
		set {if (value==null) this["idaccmotive_accruals"]= DBNull.Value; else this["idaccmotive_accruals"]= value;}
	}
	public object idaccmotive_accrualsValue { 
		get{ return this["idaccmotive_accruals"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_accruals"]= DBNull.Value; else this["idaccmotive_accruals"]= value;}
	}
	public String idaccmotive_accrualsOriginal { 
		get {if (this["idaccmotive_accruals",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_accruals",DataRowVersion.Original];}
	}
	///<summary>
	///conto costi
	///</summary>
	public String idacc_cost{ 
		get {if (this["idacc_cost"]==DBNull.Value)return null; return  (String)this["idacc_cost"];}
		set {if (value==null) this["idacc_cost"]= DBNull.Value; else this["idacc_cost"]= value;}
	}
	public object idacc_costValue { 
		get{ return this["idacc_cost"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_cost"]= DBNull.Value; else this["idacc_cost"]= value;}
	}
	public String idacc_costOriginal { 
		get {if (this["idacc_cost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_cost",DataRowVersion.Original];}
	}
	///<summary>
	///conto ricavi
	///</summary>
	public String idacc_revenue{ 
		get {if (this["idacc_revenue"]==DBNull.Value)return null; return  (String)this["idacc_revenue"];}
		set {if (value==null) this["idacc_revenue"]= DBNull.Value; else this["idacc_revenue"]= value;}
	}
	public object idacc_revenueValue { 
		get{ return this["idacc_revenue"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_revenue"]= DBNull.Value; else this["idacc_revenue"]= value;}
	}
	public String idacc_revenueOriginal { 
		get {if (this["idacc_revenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_revenue",DataRowVersion.Original];}
	}
	///<summary>
	///conto risconti passivi
	///</summary>
	public String idacc_deferredcost{ 
		get {if (this["idacc_deferredcost"]==DBNull.Value)return null; return  (String)this["idacc_deferredcost"];}
		set {if (value==null) this["idacc_deferredcost"]= DBNull.Value; else this["idacc_deferredcost"]= value;}
	}
	public object idacc_deferredcostValue { 
		get{ return this["idacc_deferredcost"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_deferredcost"]= DBNull.Value; else this["idacc_deferredcost"]= value;}
	}
	public String idacc_deferredcostOriginal { 
		get {if (this["idacc_deferredcost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_deferredcost",DataRowVersion.Original];}
	}
	///<summary>
	///conto ratei attivi
	///</summary>
	public String idacc_accruals{ 
		get {if (this["idacc_accruals"]==DBNull.Value)return null; return  (String)this["idacc_accruals"];}
		set {if (value==null) this["idacc_accruals"]= DBNull.Value; else this["idacc_accruals"]= value;}
	}
	public object idacc_accrualsValue { 
		get{ return this["idacc_accruals"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_accruals"]= DBNull.Value; else this["idacc_accruals"]= value;}
	}
	public String idacc_accrualsOriginal { 
		get {if (this["idacc_accruals",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_accruals",DataRowVersion.Original];}
	}
	///<summary>
	///totale costi
	///</summary>
	public Decimal? cost{ 
		get {if (this["cost"]==DBNull.Value)return null; return  (Decimal?)this["cost"];}
		set {if (value==null) this["cost"]= DBNull.Value; else this["cost"]= value;}
	}
	public object costValue { 
		get{ return this["cost"];}
		set {if (value==null|| value==DBNull.Value) this["cost"]= DBNull.Value; else this["cost"]= value;}
	}
	public Decimal? costOriginal { 
		get {if (this["cost",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["cost",DataRowVersion.Original];}
	}
	///<summary>
	///Tot. riserve
	///</summary>
	public Decimal? reserve{ 
		get {if (this["reserve"]==DBNull.Value)return null; return  (Decimal?)this["reserve"];}
		set {if (value==null) this["reserve"]= DBNull.Value; else this["reserve"]= value;}
	}
	public object reserveValue { 
		get{ return this["reserve"];}
		set {if (value==null|| value==DBNull.Value) this["reserve"]= DBNull.Value; else this["reserve"]= value;}
	}
	public Decimal? reserveOriginal { 
		get {if (this["reserve",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["reserve",DataRowVersion.Original];}
	}
	///<summary>
	///Tot. ricavi
	///</summary>
	public Decimal? revenue{ 
		get {if (this["revenue"]==DBNull.Value)return null; return  (Decimal?)this["revenue"];}
		set {if (value==null) this["revenue"]= DBNull.Value; else this["revenue"]= value;}
	}
	public object revenueValue { 
		get{ return this["revenue"];}
		set {if (value==null|| value==DBNull.Value) this["revenue"]= DBNull.Value; else this["revenue"]= value;}
	}
	public Decimal? revenueOriginal { 
		get {if (this["revenue",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["revenue",DataRowVersion.Original];}
	}
	///<summary>
	///totale ratei attivi
	///</summary>
	public Decimal? accruals{ 
		get {if (this["accruals"]==DBNull.Value)return null; return  (Decimal?)this["accruals"];}
		set {if (value==null) this["accruals"]= DBNull.Value; else this["accruals"]= value;}
	}
	public object accrualsValue { 
		get{ return this["accruals"];}
		set {if (value==null|| value==DBNull.Value) this["accruals"]= DBNull.Value; else this["accruals"]= value;}
	}
	public Decimal? accrualsOriginal { 
		get {if (this["accruals",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["accruals",DataRowVersion.Original];}
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
	public Decimal? assetamortization{ 
		get {if (this["assetamortization"]==DBNull.Value)return null; return  (Decimal?)this["assetamortization"];}
		set {if (value==null) this["assetamortization"]= DBNull.Value; else this["assetamortization"]= value;}
	}
	public object assetamortizationValue { 
		get{ return this["assetamortization"];}
		set {if (value==null|| value==DBNull.Value) this["assetamortization"]= DBNull.Value; else this["assetamortization"]= value;}
	}
	public Decimal? assetamortizationOriginal { 
		get {if (this["assetamortization",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["assetamortization",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Dati su commessa completata
///</summary>
public class upbcommessaTable : MetaTableBase<upbcommessaRow> {
	public upbcommessaTable() : base("upbcommessa"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idupb",createColumn("idupb",typeof(string),false,false)},
			{"ayear",createColumn("ayear",typeof(short),false,false)},
			{"codeupb",createColumn("codeupb",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),false,false)},
			{"yearstart",createColumn("yearstart",typeof(short),true,false)},
			{"yearstop",createColumn("yearstop",typeof(short),true,false)},
			{"idepupbkind",createColumn("idepupbkind",typeof(int),true,false)},
			{"idaccmotive_cost",createColumn("idaccmotive_cost",typeof(string),true,false)},
			{"idaccmotive_revenue",createColumn("idaccmotive_revenue",typeof(string),true,false)},
			{"idaccmotive_deferredcost",createColumn("idaccmotive_deferredcost",typeof(string),true,false)},
			{"idaccmotive_accruals",createColumn("idaccmotive_accruals",typeof(string),true,false)},
			{"idacc_cost",createColumn("idacc_cost",typeof(string),true,false)},
			{"idacc_revenue",createColumn("idacc_revenue",typeof(string),true,false)},
			{"idacc_deferredcost",createColumn("idacc_deferredcost",typeof(string),true,false)},
			{"idacc_accruals",createColumn("idacc_accruals",typeof(string),true,false)},
			{"cost",createColumn("cost",typeof(decimal),true,false)},
			{"reserve",createColumn("reserve",typeof(decimal),true,false)},
			{"revenue",createColumn("revenue",typeof(decimal),true,false)},
			{"accruals",createColumn("accruals",typeof(decimal),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"assetamortization",createColumn("assetamortization",typeof(decimal),true,false)},
		};
	}
}
}
