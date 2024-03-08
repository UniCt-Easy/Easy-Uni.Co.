
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_itinerationrefund {
public class itinerationrefundRow: MetaRow  {
	public itinerationrefundRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int16 nrefund{ 
		get {return  (Int16)this["nrefund"];}
		set {this["nrefund"]= value;}
	}
	public object nrefundValue { 
		get{ return this["nrefund"];}
		set {this["nrefund"]= value;}
	}
	public Int16 nrefundOriginal { 
		get {return  (Int16)this["nrefund",DataRowVersion.Original];}
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
	public Double? exchangerate{ 
		get {if (this["exchangerate"]==DBNull.Value)return null; return  (Double?)this["exchangerate"];}
		set {if (value==null) this["exchangerate"]= DBNull.Value; else this["exchangerate"]= value;}
	}
	public object exchangerateValue { 
		get{ return this["exchangerate"];}
		set {if (value==null|| value==DBNull.Value) this["exchangerate"]= DBNull.Value; else this["exchangerate"]= value;}
	}
	public Double? exchangerateOriginal { 
		get {if (this["exchangerate",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["exchangerate",DataRowVersion.Original];}
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
	public Decimal? extraallowance{ 
		get {if (this["extraallowance"]==DBNull.Value)return null; return  (Decimal?)this["extraallowance"];}
		set {if (value==null) this["extraallowance"]= DBNull.Value; else this["extraallowance"]= value;}
	}
	public object extraallowanceValue { 
		get{ return this["extraallowance"];}
		set {if (value==null|| value==DBNull.Value) this["extraallowance"]= DBNull.Value; else this["extraallowance"]= value;}
	}
	public Decimal? extraallowanceOriginal { 
		get {if (this["extraallowance",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["extraallowance",DataRowVersion.Original];}
	}
	public Decimal? advancepercentage{ 
		get {if (this["advancepercentage"]==DBNull.Value)return null; return  (Decimal?)this["advancepercentage"];}
		set {if (value==null) this["advancepercentage"]= DBNull.Value; else this["advancepercentage"]= value;}
	}
	public object advancepercentageValue { 
		get{ return this["advancepercentage"];}
		set {if (value==null|| value==DBNull.Value) this["advancepercentage"]= DBNull.Value; else this["advancepercentage"]= value;}
	}
	public Decimal? advancepercentageOriginal { 
		get {if (this["advancepercentage",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["advancepercentage",DataRowVersion.Original];}
	}
	public DateTime? starttime{ 
		get {if (this["starttime"]==DBNull.Value)return null; return  (DateTime?)this["starttime"];}
		set {if (value==null) this["starttime"]= DBNull.Value; else this["starttime"]= value;}
	}
	public object starttimeValue { 
		get{ return this["starttime"];}
		set {if (value==null|| value==DBNull.Value) this["starttime"]= DBNull.Value; else this["starttime"]= value;}
	}
	public DateTime? starttimeOriginal { 
		get {if (this["starttime",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["starttime",DataRowVersion.Original];}
	}
	public DateTime? stoptime{ 
		get {if (this["stoptime"]==DBNull.Value)return null; return  (DateTime?)this["stoptime"];}
		set {if (value==null) this["stoptime"]= DBNull.Value; else this["stoptime"]= value;}
	}
	public object stoptimeValue { 
		get{ return this["stoptime"];}
		set {if (value==null|| value==DBNull.Value) this["stoptime"]= DBNull.Value; else this["stoptime"]= value;}
	}
	public DateTime? stoptimeOriginal { 
		get {if (this["stoptime",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["stoptime",DataRowVersion.Original];}
	}
	public String flag_geo{ 
		get {if (this["flag_geo"]==DBNull.Value)return null; return  (String)this["flag_geo"];}
		set {if (value==null) this["flag_geo"]= DBNull.Value; else this["flag_geo"]= value;}
	}
	public object flag_geoValue { 
		get{ return this["flag_geo"];}
		set {if (value==null|| value==DBNull.Value) this["flag_geo"]= DBNull.Value; else this["flag_geo"]= value;}
	}
	public String flag_geoOriginal { 
		get {if (this["flag_geo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flag_geo",DataRowVersion.Original];}
	}
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
	public Int32? iditinerationrefundkind{ 
		get {if (this["iditinerationrefundkind"]==DBNull.Value)return null; return  (Int32?)this["iditinerationrefundkind"];}
		set {if (value==null) this["iditinerationrefundkind"]= DBNull.Value; else this["iditinerationrefundkind"]= value;}
	}
	public object iditinerationrefundkindValue { 
		get{ return this["iditinerationrefundkind"];}
		set {if (value==null|| value==DBNull.Value) this["iditinerationrefundkind"]= DBNull.Value; else this["iditinerationrefundkind"]= value;}
	}
	public Int32? iditinerationrefundkindOriginal { 
		get {if (this["iditinerationrefundkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iditinerationrefundkind",DataRowVersion.Original];}
	}
	public Int32? idcurrency{ 
		get {if (this["idcurrency"]==DBNull.Value)return null; return  (Int32?)this["idcurrency"];}
		set {if (value==null) this["idcurrency"]= DBNull.Value; else this["idcurrency"]= value;}
	}
	public object idcurrencyValue { 
		get{ return this["idcurrency"];}
		set {if (value==null|| value==DBNull.Value) this["idcurrency"]= DBNull.Value; else this["idcurrency"]= value;}
	}
	public Int32? idcurrencyOriginal { 
		get {if (this["idcurrency",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcurrency",DataRowVersion.Original];}
	}
	public Int32 iditineration{ 
		get {return  (Int32)this["iditineration"];}
		set {this["iditineration"]= value;}
	}
	public object iditinerationValue { 
		get{ return this["iditineration"];}
		set {this["iditineration"]= value;}
	}
	public Int32 iditinerationOriginal { 
		get {return  (Int32)this["iditineration",DataRowVersion.Original];}
	}
	public String flagitalian{ 
		get {if (this["flagitalian"]==DBNull.Value)return null; return  (String)this["flagitalian"];}
		set {if (value==null) this["flagitalian"]= DBNull.Value; else this["flagitalian"]= value;}
	}
	public object flagitalianValue { 
		get{ return this["flagitalian"];}
		set {if (value==null|| value==DBNull.Value) this["flagitalian"]= DBNull.Value; else this["flagitalian"]= value;}
	}
	public String flagitalianOriginal { 
		get {if (this["flagitalian",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagitalian",DataRowVersion.Original];}
	}
	public String flagadvancebalance{ 
		get {if (this["flagadvancebalance"]==DBNull.Value)return null; return  (String)this["flagadvancebalance"];}
		set {if (value==null) this["flagadvancebalance"]= DBNull.Value; else this["flagadvancebalance"]= value;}
	}
	public object flagadvancebalanceValue { 
		get{ return this["flagadvancebalance"];}
		set {if (value==null|| value==DBNull.Value) this["flagadvancebalance"]= DBNull.Value; else this["flagadvancebalance"]= value;}
	}
	public String flagadvancebalanceOriginal { 
		get {if (this["flagadvancebalance",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagadvancebalance",DataRowVersion.Original];}
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
	public Decimal? requiredamount{ 
		get {if (this["requiredamount"]==DBNull.Value)return null; return  (Decimal?)this["requiredamount"];}
		set {if (value==null) this["requiredamount"]= DBNull.Value; else this["requiredamount"]= value;}
	}
	public object requiredamountValue { 
		get{ return this["requiredamount"];}
		set {if (value==null|| value==DBNull.Value) this["requiredamount"]= DBNull.Value; else this["requiredamount"]= value;}
	}
	public Decimal? requiredamountOriginal { 
		get {if (this["requiredamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["requiredamount",DataRowVersion.Original];}
	}
	public Decimal? docamount{ 
		get {if (this["docamount"]==DBNull.Value)return null; return  (Decimal?)this["docamount"];}
		set {if (value==null) this["docamount"]= DBNull.Value; else this["docamount"]= value;}
	}
	public object docamountValue { 
		get{ return this["docamount"];}
		set {if (value==null|| value==DBNull.Value) this["docamount"]= DBNull.Value; else this["docamount"]= value;}
	}
	public Decimal? docamountOriginal { 
		get {if (this["docamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["docamount",DataRowVersion.Original];}
	}
	public String webwarn{ 
		get {if (this["webwarn"]==DBNull.Value)return null; return  (String)this["webwarn"];}
		set {if (value==null) this["webwarn"]= DBNull.Value; else this["webwarn"]= value;}
	}
	public object webwarnValue { 
		get{ return this["webwarn"];}
		set {if (value==null|| value==DBNull.Value) this["webwarn"]= DBNull.Value; else this["webwarn"]= value;}
	}
	public String webwarnOriginal { 
		get {if (this["webwarn",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["webwarn",DataRowVersion.Original];}
	}
	public Int32? idforeigncountry{ 
		get {if (this["idforeigncountry"]==DBNull.Value)return null; return  (Int32?)this["idforeigncountry"];}
		set {if (value==null) this["idforeigncountry"]= DBNull.Value; else this["idforeigncountry"]= value;}
	}
	public object idforeigncountryValue { 
		get{ return this["idforeigncountry"];}
		set {if (value==null|| value==DBNull.Value) this["idforeigncountry"]= DBNull.Value; else this["idforeigncountry"]= value;}
	}
	public Int32? idforeigncountryOriginal { 
		get {if (this["idforeigncountry",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idforeigncountry",DataRowVersion.Original];}
	}
	public Decimal? noaccount{ 
		get {if (this["noaccount"]==DBNull.Value)return null; return  (Decimal?)this["noaccount"];}
		set {if (value==null) this["noaccount"]= DBNull.Value; else this["noaccount"]= value;}
	}
	public object noaccountValue { 
		get{ return this["noaccount"];}
		set {if (value==null|| value==DBNull.Value) this["noaccount"]= DBNull.Value; else this["noaccount"]= value;}
	}
	public Decimal? noaccountOriginal { 
		get {if (this["noaccount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["noaccount",DataRowVersion.Original];}
	}
	public Decimal? amount_c{ 
		get {if (this["amount_c"]==DBNull.Value)return null; return  (Decimal?)this["amount_c"];}
		set {if (value==null) this["amount_c"]= DBNull.Value; else this["amount_c"]= value;}
	}
	public object amount_cValue { 
		get{ return this["amount_c"];}
		set {if (value==null|| value==DBNull.Value) this["amount_c"]= DBNull.Value; else this["amount_c"]= value;}
	}
	public Decimal? amount_cOriginal { 
		get {if (this["amount_c",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["amount_c",DataRowVersion.Original];}
	}
	public Decimal? docamount_c{ 
		get {if (this["docamount_c"]==DBNull.Value)return null; return  (Decimal?)this["docamount_c"];}
		set {if (value==null) this["docamount_c"]= DBNull.Value; else this["docamount_c"]= value;}
	}
	public object docamount_cValue { 
		get{ return this["docamount_c"];}
		set {if (value==null|| value==DBNull.Value) this["docamount_c"]= DBNull.Value; else this["docamount_c"]= value;}
	}
	public Decimal? docamount_cOriginal { 
		get {if (this["docamount_c",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["docamount_c",DataRowVersion.Original];}
	}
	public Decimal? requiredamount_c{ 
		get {if (this["requiredamount_c"]==DBNull.Value)return null; return  (Decimal?)this["requiredamount_c"];}
		set {if (value==null) this["requiredamount_c"]= DBNull.Value; else this["requiredamount_c"]= value;}
	}
	public object requiredamount_cValue { 
		get{ return this["requiredamount_c"];}
		set {if (value==null|| value==DBNull.Value) this["requiredamount_c"]= DBNull.Value; else this["requiredamount_c"]= value;}
	}
	public Decimal? requiredamount_cOriginal { 
		get {if (this["requiredamount_c",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["requiredamount_c",DataRowVersion.Original];}
	}
	#endregion

}
public class itinerationrefundTable : MetaTableBase<itinerationrefundRow> {
	public itinerationrefundTable() : base("itinerationrefund"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nrefund",createColumn("nrefund",typeof(short),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"exchangerate",createColumn("exchangerate",typeof(double),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"extraallowance",createColumn("extraallowance",typeof(decimal),true,false)},
			{"advancepercentage",createColumn("advancepercentage",typeof(decimal),true,false)},
			{"starttime",createColumn("starttime",typeof(DateTime),true,false)},
			{"stoptime",createColumn("stoptime",typeof(DateTime),true,false)},
			{"flag_geo",createColumn("flag_geo",typeof(string),true,false)},
			{"amount",createColumn("amount",typeof(decimal),true,false)},
			{"iditinerationrefundkind",createColumn("iditinerationrefundkind",typeof(int),true,false)},
			{"idcurrency",createColumn("idcurrency",typeof(int),true,false)},
			{"iditineration",createColumn("iditineration",typeof(int),false,false)},
			{"flagitalian",createColumn("flagitalian",typeof(string),true,false)},
			{"flagadvancebalance",createColumn("flagadvancebalance",typeof(string),true,false)},
			{"doc",createColumn("doc",typeof(string),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"requiredamount",createColumn("requiredamount",typeof(decimal),true,false)},
			{"docamount",createColumn("docamount",typeof(decimal),true,false)},
			{"webwarn",createColumn("webwarn",typeof(string),true,false)},
			{"idforeigncountry",createColumn("idforeigncountry",typeof(int),true,false)},
			{"noaccount",createColumn("noaccount",typeof(decimal),true,false)},
			{"amount_c",createColumn("amount_c",typeof(decimal),true,false)},
			{"docamount_c",createColumn("docamount_c",typeof(decimal),true,false)},
			{"requiredamount_c",createColumn("requiredamount_c",typeof(decimal),true,false)},
		};
	}
}
}
