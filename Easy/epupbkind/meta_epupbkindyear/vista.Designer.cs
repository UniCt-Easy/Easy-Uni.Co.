
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
using metadatalibrary;
namespace meta_epupbkindyear {
public class epupbkindyearRow: MetaRow  {
	public epupbkindyearRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///ID Tipo UPB nell'economico patrimoniale (tabella epupbkind)
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
	///conto per costo(idacc di account)
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
	///id conto ricavo (tabella account)
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
	///conto per risconto passivo (idacc di account)
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
	///conto per rateo attivo (idacc di account)
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
	///conto per riserve (idacc di account)
	///</summary>
	public String idacc_reserve{ 
		get {if (this["idacc_reserve"]==DBNull.Value)return null; return  (String)this["idacc_reserve"];}
		set {if (value==null) this["idacc_reserve"]= DBNull.Value; else this["idacc_reserve"]= value;}
	}
	public object idacc_reserveValue { 
		get{ return this["idacc_reserve"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_reserve"]= DBNull.Value; else this["idacc_reserve"]= value;}
	}
	public String idacc_reserveOriginal { 
		get {if (this["idacc_reserve",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_reserve",DataRowVersion.Original];}
	}
	///<summary>
	///tipo di assestamento
	///	 C: Commessa completata
	///	 P: Percenuale di completamento metodo del costo
	///</summary>
	public String adjustmentkind{ 
		get {if (this["adjustmentkind"]==DBNull.Value)return null; return  (String)this["adjustmentkind"];}
		set {if (value==null) this["adjustmentkind"]= DBNull.Value; else this["adjustmentkind"]= value;}
	}
	public object adjustmentkindValue { 
		get{ return this["adjustmentkind"];}
		set {if (value==null|| value==DBNull.Value) this["adjustmentkind"]= DBNull.Value; else this["adjustmentkind"]= value;}
	}
	public String adjustmentkindOriginal { 
		get {if (this["adjustmentkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["adjustmentkind",DataRowVersion.Original];}
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
	public String idaccmotive_reserve{ 
		get {if (this["idaccmotive_reserve"]==DBNull.Value)return null; return  (String)this["idaccmotive_reserve"];}
		set {if (value==null) this["idaccmotive_reserve"]= DBNull.Value; else this["idaccmotive_reserve"]= value;}
	}
	public object idaccmotive_reserveValue { 
		get{ return this["idaccmotive_reserve"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_reserve"]= DBNull.Value; else this["idaccmotive_reserve"]= value;}
	}
	public String idaccmotive_reserveOriginal { 
		get {if (this["idaccmotive_reserve",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_reserve",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Tipo EP dell' upb, informazioni annuali su UPB nell'economico patrimoniale
///</summary>
public class epupbkindyearTable : MetaTableBase<epupbkindyearRow> {
	public epupbkindyearTable() : base("epupbkindyear"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idepupbkind")){ 
			defineColumn("idepupbkind", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("ayear")){ 
			defineColumn("ayear", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("idacc_cost")){ 
			defineColumn("idacc_cost", typeof(System.String));
		}
		if (definedColums.ContainsKey("idacc_revenue")){ 
			defineColumn("idacc_revenue", typeof(System.String));
		}
		if (definedColums.ContainsKey("idacc_deferredcost")){ 
			defineColumn("idacc_deferredcost", typeof(System.String));
		}
		if (definedColums.ContainsKey("idacc_accruals")){ 
			defineColumn("idacc_accruals", typeof(System.String));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String));
		}
		if (definedColums.ContainsKey("idacc_reserve")){ 
			defineColumn("idacc_reserve", typeof(System.String));
		}
		if (definedColums.ContainsKey("adjustmentkind")){ 
			defineColumn("adjustmentkind", typeof(System.String));
		}
		if (definedColums.ContainsKey("idaccmotive_cost")){ 
			defineColumn("idaccmotive_cost", typeof(System.String));
		}
		if (definedColums.ContainsKey("idaccmotive_revenue")){ 
			defineColumn("idaccmotive_revenue", typeof(System.String));
		}
		if (definedColums.ContainsKey("idaccmotive_deferredcost")){ 
			defineColumn("idaccmotive_deferredcost", typeof(System.String));
		}
		if (definedColums.ContainsKey("idaccmotive_accruals")){ 
			defineColumn("idaccmotive_accruals", typeof(System.String));
		}
		if (definedColums.ContainsKey("idaccmotive_reserve")){ 
			defineColumn("idaccmotive_reserve", typeof(System.String));
		}
		#endregion

	}
}
}
