
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
namespace meta_paydisposition {
public class paydispositionRow: MetaRow  {
	public paydispositionRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num. Disposizione
	///</summary>
	public Int32? idpaydisposition{ 
		get {if (this["idpaydisposition"]==DBNull.Value)return null; return  (Int32?)this["idpaydisposition"];}
		set {if (value==null) this["idpaydisposition"]= DBNull.Value; else this["idpaydisposition"]= value;}
	}
	public object idpaydispositionValue { 
		get{ return this["idpaydisposition"];}
		set {if (value==null|| value==DBNull.Value) this["idpaydisposition"]= DBNull.Value; else this["idpaydisposition"]= value;}
	}
	public Int32? idpaydispositionOriginal { 
		get {if (this["idpaydisposition",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpaydisposition",DataRowVersion.Original];}
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
	///Descrizione
	///</summary>
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
	///ID Causale CBI (tabella cbimotive)
	///</summary>
	public Int32? idcbimotive{ 
		get {if (this["idcbimotive"]==DBNull.Value)return null; return  (Int32?)this["idcbimotive"];}
		set {if (value==null) this["idcbimotive"]= DBNull.Value; else this["idcbimotive"]= value;}
	}
	public object idcbimotiveValue { 
		get{ return this["idcbimotive"];}
		set {if (value==null|| value==DBNull.Value) this["idcbimotive"]= DBNull.Value; else this["idcbimotive"]= value;}
	}
	public Int32? idcbimotiveOriginal { 
		get {if (this["idcbimotive",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcbimotive",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Disposizione di Pagamento
///</summary>
public class paydispositionTable : MetaTableBase<paydispositionRow> {
	public paydispositionTable() : base("paydisposition"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idpaydisposition")){ 
			defineColumn("idpaydisposition", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("ayear")){ 
			defineColumn("ayear", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String));
		}
		if (definedColums.ContainsKey("motive")){ 
			defineColumn("motive", typeof(System.String));
		}
		if (definedColums.ContainsKey("kpay")){ 
			defineColumn("kpay", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idcbimotive")){ 
			defineColumn("idcbimotive", typeof(System.Int32));
		}
		#endregion

	}
}
}
