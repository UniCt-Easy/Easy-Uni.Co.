
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
using metadatalibrary;
namespace meta_finbalance {
public class finbalanceRow: MetaRow  {
	public finbalanceRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///esercizio
	///</summary>
	public Int32? ayear{ 
		get {if (this["ayear"]==DBNull.Value)return null; return  (Int32?)this["ayear"];}
		set {if (value==null) this["ayear"]= DBNull.Value; else this["ayear"]= value;}
	}
	public object ayearValue { 
		get{ return this["ayear"];}
		set {if (value==null|| value==DBNull.Value) this["ayear"]= DBNull.Value; else this["ayear"]= value;}
	}
	public Int32? ayearOriginal { 
		get {if (this["ayear",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ayear",DataRowVersion.Original];}
	}
	///<summary>
	///Num. Assestamento
	///</summary>
	public Int32? nfinbalance{ 
		get {if (this["nfinbalance"]==DBNull.Value)return null; return  (Int32?)this["nfinbalance"];}
		set {if (value==null) this["nfinbalance"]= DBNull.Value; else this["nfinbalance"]= value;}
	}
	public object nfinbalanceValue { 
		get{ return this["nfinbalance"];}
		set {if (value==null|| value==DBNull.Value) this["nfinbalance"]= DBNull.Value; else this["nfinbalance"]= value;}
	}
	public Int32? nfinbalanceOriginal { 
		get {if (this["nfinbalance",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nfinbalance",DataRowVersion.Original];}
	}
	///<summary>
	///data assestamento
	///</summary>
	public DateTime? balancedate{ 
		get {if (this["balancedate"]==DBNull.Value)return null; return  (DateTime?)this["balancedate"];}
		set {if (value==null) this["balancedate"]= DBNull.Value; else this["balancedate"]= value;}
	}
	public object balancedateValue { 
		get{ return this["balancedate"];}
		set {if (value==null|| value==DBNull.Value) this["balancedate"]= DBNull.Value; else this["balancedate"]= value;}
	}
	public DateTime? balancedateOriginal { 
		get {if (this["balancedate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["balancedate",DataRowVersion.Original];}
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
	///Ufficiale
	///	 N: Non ? vero che: "Ufficiale"
	///	 S: Ufficiale
	///</summary>
	public String official{ 
		get {if (this["official"]==DBNull.Value)return null; return  (String)this["official"];}
		set {if (value==null) this["official"]= DBNull.Value; else this["official"]= value;}
	}
	public object officialValue { 
		get{ return this["official"];}
		set {if (value==null|| value==DBNull.Value) this["official"]= DBNull.Value; else this["official"]= value;}
	}
	public String officialOriginal { 
		get {if (this["official",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["official",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Assestamento Bilancio Annuale
///</summary>
public class finbalanceTable : MetaTableBase<finbalanceRow> {
	public finbalanceTable() : base("finbalance"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("ayear")){ 
			defineColumn("ayear", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("nfinbalance")){ 
			defineColumn("nfinbalance", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("balancedate")){ 
			defineColumn("balancedate", typeof(System.DateTime));
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
		if (definedColums.ContainsKey("official")){ 
			defineColumn("official", typeof(System.String));
		}
		#endregion

	}
}
}
