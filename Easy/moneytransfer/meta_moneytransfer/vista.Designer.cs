
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
namespace meta_moneytransfer {
public class moneytransferRow: MetaRow  {
	public moneytransferRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Eserc. Girofondo
	///</summary>
	public Int16? ytransfer{ 
		get {if (this["ytransfer"]==DBNull.Value)return null; return  (Int16?)this["ytransfer"];}
		set {if (value==null) this["ytransfer"]= DBNull.Value; else this["ytransfer"]= value;}
	}
	public object ytransferValue { 
		get{ return this["ytransfer"];}
		set {if (value==null|| value==DBNull.Value) this["ytransfer"]= DBNull.Value; else this["ytransfer"]= value;}
	}
	public Int16? ytransferOriginal { 
		get {if (this["ytransfer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ytransfer",DataRowVersion.Original];}
	}
	///<summary>
	///Num. Girofondo
	///</summary>
	public Int32? ntransfer{ 
		get {if (this["ntransfer"]==DBNull.Value)return null; return  (Int32?)this["ntransfer"];}
		set {if (value==null) this["ntransfer"]= DBNull.Value; else this["ntransfer"]= value;}
	}
	public object ntransferValue { 
		get{ return this["ntransfer"];}
		set {if (value==null|| value==DBNull.Value) this["ntransfer"]= DBNull.Value; else this["ntransfer"]= value;}
	}
	public Int32? ntransferOriginal { 
		get {if (this["ntransfer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ntransfer",DataRowVersion.Original];}
	}
	///<summary>
	///id cassiere origine
	///</summary>
	public Int32? idtreasurersource{ 
		get {if (this["idtreasurersource"]==DBNull.Value)return null; return  (Int32?)this["idtreasurersource"];}
		set {if (value==null) this["idtreasurersource"]= DBNull.Value; else this["idtreasurersource"]= value;}
	}
	public object idtreasurersourceValue { 
		get{ return this["idtreasurersource"];}
		set {if (value==null|| value==DBNull.Value) this["idtreasurersource"]= DBNull.Value; else this["idtreasurersource"]= value;}
	}
	public Int32? idtreasurersourceOriginal { 
		get {if (this["idtreasurersource",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtreasurersource",DataRowVersion.Original];}
	}
	///<summary>
	///id cassiere destinazione
	///</summary>
	public Int32? idtreasurerdest{ 
		get {if (this["idtreasurerdest"]==DBNull.Value)return null; return  (Int32?)this["idtreasurerdest"];}
		set {if (value==null) this["idtreasurerdest"]= DBNull.Value; else this["idtreasurerdest"]= value;}
	}
	public object idtreasurerdestValue { 
		get{ return this["idtreasurerdest"];}
		set {if (value==null|| value==DBNull.Value) this["idtreasurerdest"]= DBNull.Value; else this["idtreasurerdest"]= value;}
	}
	public Int32? idtreasurerdestOriginal { 
		get {if (this["idtreasurerdest",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtreasurerdest",DataRowVersion.Original];}
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
	///n. assegnazione cassa
	///</summary>
	public Int32? nproceedspart{ 
		get {if (this["nproceedspart"]==DBNull.Value)return null; return  (Int32?)this["nproceedspart"];}
		set {if (value==null) this["nproceedspart"]= DBNull.Value; else this["nproceedspart"]= value;}
	}
	public object nproceedspartValue { 
		get{ return this["nproceedspart"];}
		set {if (value==null|| value==DBNull.Value) this["nproceedspart"]= DBNull.Value; else this["nproceedspart"]= value;}
	}
	public Int32? nproceedspartOriginal { 
		get {if (this["nproceedspart",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nproceedspart",DataRowVersion.Original];}
	}
	///<summary>
	///eserc.  assegnazione cassa
	///</summary>
	public Int16? yproceedspart{ 
		get {if (this["yproceedspart"]==DBNull.Value)return null; return  (Int16?)this["yproceedspart"];}
		set {if (value==null) this["yproceedspart"]= DBNull.Value; else this["yproceedspart"]= value;}
	}
	public object yproceedspartValue { 
		get{ return this["yproceedspart"];}
		set {if (value==null|| value==DBNull.Value) this["yproceedspart"]= DBNull.Value; else this["yproceedspart"]= value;}
	}
	public Int16? yproceedspartOriginal { 
		get {if (this["yproceedspart",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yproceedspart",DataRowVersion.Original];}
	}
	///<summary>
	///Anno variazione
	///</summary>
	public Int16? yvar{ 
		get {if (this["yvar"]==DBNull.Value)return null; return  (Int16?)this["yvar"];}
		set {if (value==null) this["yvar"]= DBNull.Value; else this["yvar"]= value;}
	}
	public object yvarValue { 
		get{ return this["yvar"];}
		set {if (value==null|| value==DBNull.Value) this["yvar"]= DBNull.Value; else this["yvar"]= value;}
	}
	public Int16? yvarOriginal { 
		get {if (this["yvar",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yvar",DataRowVersion.Original];}
	}
	///<summary>
	///N. variazione
	///</summary>
	public Int32? nvar{ 
		get {if (this["nvar"]==DBNull.Value)return null; return  (Int32?)this["nvar"];}
		set {if (value==null) this["nvar"]= DBNull.Value; else this["nvar"]= value;}
	}
	public object nvarValue { 
		get{ return this["nvar"];}
		set {if (value==null|| value==DBNull.Value) this["nvar"]= DBNull.Value; else this["nvar"]= value;}
	}
	public Int32? nvarOriginal { 
		get {if (this["nvar",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nvar",DataRowVersion.Original];}
	}
	///<summary>
	///N. riga
	///</summary>
	public Int32? rownum{ 
		get {if (this["rownum"]==DBNull.Value)return null; return  (Int32?)this["rownum"];}
		set {if (value==null) this["rownum"]= DBNull.Value; else this["rownum"]= value;}
	}
	public object rownumValue { 
		get{ return this["rownum"];}
		set {if (value==null|| value==DBNull.Value) this["rownum"]= DBNull.Value; else this["rownum"]= value;}
	}
	public Int32? rownumOriginal { 
		get {if (this["rownum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["rownum",DataRowVersion.Original];}
	}
	///<summary>
	///tipo trasferimento
	///	 G: Pagamento o incassi da girofondare
	///	 I: Iva
	///	 N: Altro
	///	 P: Prestiti
	///	 R: Ritenute
	///	 V: Variazioni di cassa
	///</summary>
	public String transferkind{ 
		get {if (this["transferkind"]==DBNull.Value)return null; return  (String)this["transferkind"];}
		set {if (value==null) this["transferkind"]= DBNull.Value; else this["transferkind"]= value;}
	}
	public object transferkindValue { 
		get{ return this["transferkind"];}
		set {if (value==null|| value==DBNull.Value) this["transferkind"]= DBNull.Value; else this["transferkind"]= value;}
	}
	public String transferkindOriginal { 
		get {if (this["transferkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["transferkind",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Girofondo
///</summary>
public class moneytransferTable : MetaTableBase<moneytransferRow> {
	public moneytransferTable() : base("moneytransfer"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("ytransfer")){ 
			defineColumn("ytransfer", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("ntransfer")){ 
			defineColumn("ntransfer", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idtreasurersource")){ 
			defineColumn("idtreasurersource", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idtreasurerdest")){ 
			defineColumn("idtreasurerdest", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("amount")){ 
			defineColumn("amount", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String));
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("nproceedspart")){ 
			defineColumn("nproceedspart", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("yproceedspart")){ 
			defineColumn("yproceedspart", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("yvar")){ 
			defineColumn("yvar", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("nvar")){ 
			defineColumn("nvar", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("rownum")){ 
			defineColumn("rownum", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("transferkind")){ 
			defineColumn("transferkind", typeof(System.String));
		}
		#endregion

	}
}
}
