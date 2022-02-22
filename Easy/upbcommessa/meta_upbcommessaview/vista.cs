
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
namespace meta_upbcommessaview {
public class upbcommessaviewRow: MetaRow  {
	public upbcommessaviewRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	public String codeupb{ 
		get {if (this["codeupb"]==DBNull.Value)return null; return  (String)this["codeupb"];}
		set {if (value==null) this["codeupb"]= DBNull.Value; else this["codeupb"]= value;}
	}
	public object codeupbValue { 
		get{ return this["codeupb"];}
		set {if (value==null|| value==DBNull.Value) this["codeupb"]= DBNull.Value; else this["codeupb"]= value;}
	}
	public String codeupbOriginal { 
		get {if (this["codeupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeupb",DataRowVersion.Original];}
	}
	public String title{ 
		get {if (this["title"]==DBNull.Value)return null; return  (String)this["title"];}
		set {if (value==null) this["title"]= DBNull.Value; else this["title"]= value;}
	}
	public object titleValue { 
		get{ return this["title"];}
		set {if (value==null|| value==DBNull.Value) this["title"]= DBNull.Value; else this["title"]= value;}
	}
	public String titleOriginal { 
		get {if (this["title",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title",DataRowVersion.Original];}
	}
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
	public String codemotive_cost{ 
		get {if (this["codemotive_cost"]==DBNull.Value)return null; return  (String)this["codemotive_cost"];}
		set {if (value==null) this["codemotive_cost"]= DBNull.Value; else this["codemotive_cost"]= value;}
	}
	public object codemotive_costValue { 
		get{ return this["codemotive_cost"];}
		set {if (value==null|| value==DBNull.Value) this["codemotive_cost"]= DBNull.Value; else this["codemotive_cost"]= value;}
	}
	public String codemotive_costOriginal { 
		get {if (this["codemotive_cost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codemotive_cost",DataRowVersion.Original];}
	}
	public String motive_cost{ 
		get {if (this["motive_cost"]==DBNull.Value)return null; return  (String)this["motive_cost"];}
		set {if (value==null) this["motive_cost"]= DBNull.Value; else this["motive_cost"]= value;}
	}
	public object motive_costValue { 
		get{ return this["motive_cost"];}
		set {if (value==null|| value==DBNull.Value) this["motive_cost"]= DBNull.Value; else this["motive_cost"]= value;}
	}
	public String motive_costOriginal { 
		get {if (this["motive_cost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motive_cost",DataRowVersion.Original];}
	}
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
	public String codemotive_revenue{ 
		get {if (this["codemotive_revenue"]==DBNull.Value)return null; return  (String)this["codemotive_revenue"];}
		set {if (value==null) this["codemotive_revenue"]= DBNull.Value; else this["codemotive_revenue"]= value;}
	}
	public object codemotive_revenueValue { 
		get{ return this["codemotive_revenue"];}
		set {if (value==null|| value==DBNull.Value) this["codemotive_revenue"]= DBNull.Value; else this["codemotive_revenue"]= value;}
	}
	public String codemotive_revenueOriginal { 
		get {if (this["codemotive_revenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codemotive_revenue",DataRowVersion.Original];}
	}
	public String motive_revenue{ 
		get {if (this["motive_revenue"]==DBNull.Value)return null; return  (String)this["motive_revenue"];}
		set {if (value==null) this["motive_revenue"]= DBNull.Value; else this["motive_revenue"]= value;}
	}
	public object motive_revenueValue { 
		get{ return this["motive_revenue"];}
		set {if (value==null|| value==DBNull.Value) this["motive_revenue"]= DBNull.Value; else this["motive_revenue"]= value;}
	}
	public String motive_revenueOriginal { 
		get {if (this["motive_revenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motive_revenue",DataRowVersion.Original];}
	}
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
	public String codemotive_deferredcost{ 
		get {if (this["codemotive_deferredcost"]==DBNull.Value)return null; return  (String)this["codemotive_deferredcost"];}
		set {if (value==null) this["codemotive_deferredcost"]= DBNull.Value; else this["codemotive_deferredcost"]= value;}
	}
	public object codemotive_deferredcostValue { 
		get{ return this["codemotive_deferredcost"];}
		set {if (value==null|| value==DBNull.Value) this["codemotive_deferredcost"]= DBNull.Value; else this["codemotive_deferredcost"]= value;}
	}
	public String codemotive_deferredcostOriginal { 
		get {if (this["codemotive_deferredcost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codemotive_deferredcost",DataRowVersion.Original];}
	}
	public String motive_deferredcost{ 
		get {if (this["motive_deferredcost"]==DBNull.Value)return null; return  (String)this["motive_deferredcost"];}
		set {if (value==null) this["motive_deferredcost"]= DBNull.Value; else this["motive_deferredcost"]= value;}
	}
	public object motive_deferredcostValue { 
		get{ return this["motive_deferredcost"];}
		set {if (value==null|| value==DBNull.Value) this["motive_deferredcost"]= DBNull.Value; else this["motive_deferredcost"]= value;}
	}
	public String motive_deferredcostOriginal { 
		get {if (this["motive_deferredcost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motive_deferredcost",DataRowVersion.Original];}
	}
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
	public String codemotive_accruals{ 
		get {if (this["codemotive_accruals"]==DBNull.Value)return null; return  (String)this["codemotive_accruals"];}
		set {if (value==null) this["codemotive_accruals"]= DBNull.Value; else this["codemotive_accruals"]= value;}
	}
	public object codemotive_accrualsValue { 
		get{ return this["codemotive_accruals"];}
		set {if (value==null|| value==DBNull.Value) this["codemotive_accruals"]= DBNull.Value; else this["codemotive_accruals"]= value;}
	}
	public String codemotive_accrualsOriginal { 
		get {if (this["codemotive_accruals",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codemotive_accruals",DataRowVersion.Original];}
	}
	public String motive_accruals{ 
		get {if (this["motive_accruals"]==DBNull.Value)return null; return  (String)this["motive_accruals"];}
		set {if (value==null) this["motive_accruals"]= DBNull.Value; else this["motive_accruals"]= value;}
	}
	public object motive_accrualsValue { 
		get{ return this["motive_accruals"];}
		set {if (value==null|| value==DBNull.Value) this["motive_accruals"]= DBNull.Value; else this["motive_accruals"]= value;}
	}
	public String motive_accrualsOriginal { 
		get {if (this["motive_accruals",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motive_accruals",DataRowVersion.Original];}
	}
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
	public String codeacc_cost{ 
		get {if (this["codeacc_cost"]==DBNull.Value)return null; return  (String)this["codeacc_cost"];}
		set {if (value==null) this["codeacc_cost"]= DBNull.Value; else this["codeacc_cost"]= value;}
	}
	public object codeacc_costValue { 
		get{ return this["codeacc_cost"];}
		set {if (value==null|| value==DBNull.Value) this["codeacc_cost"]= DBNull.Value; else this["codeacc_cost"]= value;}
	}
	public String codeacc_costOriginal { 
		get {if (this["codeacc_cost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeacc_cost",DataRowVersion.Original];}
	}
	public String acc_cost{ 
		get {if (this["acc_cost"]==DBNull.Value)return null; return  (String)this["acc_cost"];}
		set {if (value==null) this["acc_cost"]= DBNull.Value; else this["acc_cost"]= value;}
	}
	public object acc_costValue { 
		get{ return this["acc_cost"];}
		set {if (value==null|| value==DBNull.Value) this["acc_cost"]= DBNull.Value; else this["acc_cost"]= value;}
	}
	public String acc_costOriginal { 
		get {if (this["acc_cost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["acc_cost",DataRowVersion.Original];}
	}
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
	public String codeacc_revenue{ 
		get {if (this["codeacc_revenue"]==DBNull.Value)return null; return  (String)this["codeacc_revenue"];}
		set {if (value==null) this["codeacc_revenue"]= DBNull.Value; else this["codeacc_revenue"]= value;}
	}
	public object codeacc_revenueValue { 
		get{ return this["codeacc_revenue"];}
		set {if (value==null|| value==DBNull.Value) this["codeacc_revenue"]= DBNull.Value; else this["codeacc_revenue"]= value;}
	}
	public String codeacc_revenueOriginal { 
		get {if (this["codeacc_revenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeacc_revenue",DataRowVersion.Original];}
	}
	public String acc_revenue{ 
		get {if (this["acc_revenue"]==DBNull.Value)return null; return  (String)this["acc_revenue"];}
		set {if (value==null) this["acc_revenue"]= DBNull.Value; else this["acc_revenue"]= value;}
	}
	public object acc_revenueValue { 
		get{ return this["acc_revenue"];}
		set {if (value==null|| value==DBNull.Value) this["acc_revenue"]= DBNull.Value; else this["acc_revenue"]= value;}
	}
	public String acc_revenueOriginal { 
		get {if (this["acc_revenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["acc_revenue",DataRowVersion.Original];}
	}
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
	public String codeacc_deferredcost{ 
		get {if (this["codeacc_deferredcost"]==DBNull.Value)return null; return  (String)this["codeacc_deferredcost"];}
		set {if (value==null) this["codeacc_deferredcost"]= DBNull.Value; else this["codeacc_deferredcost"]= value;}
	}
	public object codeacc_deferredcostValue { 
		get{ return this["codeacc_deferredcost"];}
		set {if (value==null|| value==DBNull.Value) this["codeacc_deferredcost"]= DBNull.Value; else this["codeacc_deferredcost"]= value;}
	}
	public String codeacc_deferredcostOriginal { 
		get {if (this["codeacc_deferredcost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeacc_deferredcost",DataRowVersion.Original];}
	}
	public String acc_deferredcost{ 
		get {if (this["acc_deferredcost"]==DBNull.Value)return null; return  (String)this["acc_deferredcost"];}
		set {if (value==null) this["acc_deferredcost"]= DBNull.Value; else this["acc_deferredcost"]= value;}
	}
	public object acc_deferredcostValue { 
		get{ return this["acc_deferredcost"];}
		set {if (value==null|| value==DBNull.Value) this["acc_deferredcost"]= DBNull.Value; else this["acc_deferredcost"]= value;}
	}
	public String acc_deferredcostOriginal { 
		get {if (this["acc_deferredcost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["acc_deferredcost",DataRowVersion.Original];}
	}
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
	public String codeacc_accruals{ 
		get {if (this["codeacc_accruals"]==DBNull.Value)return null; return  (String)this["codeacc_accruals"];}
		set {if (value==null) this["codeacc_accruals"]= DBNull.Value; else this["codeacc_accruals"]= value;}
	}
	public object codeacc_accrualsValue { 
		get{ return this["codeacc_accruals"];}
		set {if (value==null|| value==DBNull.Value) this["codeacc_accruals"]= DBNull.Value; else this["codeacc_accruals"]= value;}
	}
	public String codeacc_accrualsOriginal { 
		get {if (this["codeacc_accruals",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeacc_accruals",DataRowVersion.Original];}
	}
	public String acc_accruals{ 
		get {if (this["acc_accruals"]==DBNull.Value)return null; return  (String)this["acc_accruals"];}
		set {if (value==null) this["acc_accruals"]= DBNull.Value; else this["acc_accruals"]= value;}
	}
	public object acc_accrualsValue { 
		get{ return this["acc_accruals"];}
		set {if (value==null|| value==DBNull.Value) this["acc_accruals"]= DBNull.Value; else this["acc_accruals"]= value;}
	}
	public String acc_accrualsOriginal { 
		get {if (this["acc_accruals",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["acc_accruals",DataRowVersion.Original];}
	}
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
	public Decimal? costi{ 
		get {if (this["costi"]==DBNull.Value)return null; return  (Decimal?)this["costi"];}
		set {if (value==null) this["costi"]= DBNull.Value; else this["costi"]= value;}
	}
	public object costiValue { 
		get{ return this["costi"];}
		set {if (value==null|| value==DBNull.Value) this["costi"]= DBNull.Value; else this["costi"]= value;}
	}
	public Decimal? costiOriginal { 
		get {if (this["costi",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["costi",DataRowVersion.Original];}
	}
	public Decimal? risconti{ 
		get {if (this["risconti"]==DBNull.Value)return null; return  (Decimal?)this["risconti"];}
		set {if (value==null) this["risconti"]= DBNull.Value; else this["risconti"]= value;}
	}
	public object riscontiValue { 
		get{ return this["risconti"];}
		set {if (value==null|| value==DBNull.Value) this["risconti"]= DBNull.Value; else this["risconti"]= value;}
	}
	public Decimal? riscontiOriginal { 
		get {if (this["risconti",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["risconti",DataRowVersion.Original];}
	}
	public Decimal? rateiattivi{ 
		get {if (this["rateiattivi"]==DBNull.Value)return null; return  (Decimal?)this["rateiattivi"];}
		set {if (value==null) this["rateiattivi"]= DBNull.Value; else this["rateiattivi"]= value;}
	}
	public object rateiattiviValue { 
		get{ return this["rateiattivi"];}
		set {if (value==null|| value==DBNull.Value) this["rateiattivi"]= DBNull.Value; else this["rateiattivi"]= value;}
	}
	public Decimal? rateiattiviOriginal { 
		get {if (this["rateiattivi",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["rateiattivi",DataRowVersion.Original];}
	}
	#endregion

}
public class upbcommessaviewTable : MetaTableBase<upbcommessaviewRow> {
	public upbcommessaviewTable() : base("upbcommessaview"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idupb",createColumn("idupb",typeof(string),false,false)},
			{"ayear",createColumn("ayear",typeof(short),false,false)},
			{"codeupb",createColumn("codeupb",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),false,false)},
			{"yearstart",createColumn("yearstart",typeof(short),true,false)},
			{"yearstop",createColumn("yearstop",typeof(short),true,false)},
			{"idepupbkind",createColumn("idepupbkind",typeof(int),true,false)},
			{"idaccmotive_cost",createColumn("idaccmotive_cost",typeof(string),true,false)},
			{"codemotive_cost",createColumn("codemotive_cost",typeof(string),true,false)},
			{"motive_cost",createColumn("motive_cost",typeof(string),true,false)},
			{"idaccmotive_revenue",createColumn("idaccmotive_revenue",typeof(string),true,false)},
			{"codemotive_revenue",createColumn("codemotive_revenue",typeof(string),true,false)},
			{"motive_revenue",createColumn("motive_revenue",typeof(string),true,false)},
			{"idaccmotive_deferredcost",createColumn("idaccmotive_deferredcost",typeof(string),true,false)},
			{"codemotive_deferredcost",createColumn("codemotive_deferredcost",typeof(string),true,false)},
			{"motive_deferredcost",createColumn("motive_deferredcost",typeof(string),true,false)},
			{"idaccmotive_accruals",createColumn("idaccmotive_accruals",typeof(string),true,false)},
			{"codemotive_accruals",createColumn("codemotive_accruals",typeof(string),true,false)},
			{"motive_accruals",createColumn("motive_accruals",typeof(string),true,false)},
			{"idacc_cost",createColumn("idacc_cost",typeof(string),true,false)},
			{"codeacc_cost",createColumn("codeacc_cost",typeof(string),true,false)},
			{"acc_cost",createColumn("acc_cost",typeof(string),true,false)},
			{"idacc_revenue",createColumn("idacc_revenue",typeof(string),true,false)},
			{"codeacc_revenue",createColumn("codeacc_revenue",typeof(string),true,false)},
			{"acc_revenue",createColumn("acc_revenue",typeof(string),true,false)},
			{"idacc_deferredcost",createColumn("idacc_deferredcost",typeof(string),true,false)},
			{"codeacc_deferredcost",createColumn("codeacc_deferredcost",typeof(string),true,false)},
			{"acc_deferredcost",createColumn("acc_deferredcost",typeof(string),true,false)},
			{"idacc_accruals",createColumn("idacc_accruals",typeof(string),true,false)},
			{"codeacc_accruals",createColumn("codeacc_accruals",typeof(string),true,false)},
			{"acc_accruals",createColumn("acc_accruals",typeof(string),true,false)},
			{"cost",createColumn("cost",typeof(decimal),true,false)},
			{"reserve",createColumn("reserve",typeof(decimal),true,false)},
			{"revenue",createColumn("revenue",typeof(decimal),true,false)},
			{"accruals",createColumn("accruals",typeof(decimal),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"costi",createColumn("costi",typeof(decimal),true,false)},
			{"risconti",createColumn("risconti",typeof(decimal),true,false)},
			{"rateiattivi",createColumn("rateiattivi",typeof(decimal),true,false)},
		};
	}
}
}
