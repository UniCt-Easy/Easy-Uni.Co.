
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
using metadatalibrary;
namespace meta_proceedspart {
public class proceedspartRow: MetaRow  {
	public proceedspartRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num. assegn.
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
	///allegati
	///</summary>
	public Byte[] rtf{ 
		get {if (this["rtf"]==DBNull.Value)return null; return  (Byte[])this["rtf"];}
		set {if (value==null) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public object rtfValue { 
		get{ return this["rtf"];}
		set {if (value==null|| value==DBNull.Value) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public Byte[] rtfOriginal { 
		get {if (this["rtf",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte[])this["rtf",DataRowVersion.Original];}
	}
	///<summary>
	///note testuali
	///</summary>
	public String txt{ 
		get {if (this["txt"]==DBNull.Value)return null; return  (String)this["txt"];}
		set {if (value==null) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public object txtValue { 
		get{ return this["txt"];}
		set {if (value==null|| value==DBNull.Value) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public String txtOriginal { 
		get {if (this["txt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["txt",DataRowVersion.Original];}
	}
	///<summary>
	///Eserc. assegn.
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
	///id voce bilancio (tabella fin)
	///</summary>
	public Int32? idfin{ 
		get {if (this["idfin"]==DBNull.Value)return null; return  (Int32?)this["idfin"];}
		set {if (value==null) this["idfin"]= DBNull.Value; else this["idfin"]= value;}
	}
	public object idfinValue { 
		get{ return this["idfin"];}
		set {if (value==null|| value==DBNull.Value) this["idfin"]= DBNull.Value; else this["idfin"]= value;}
	}
	public Int32? idfinOriginal { 
		get {if (this["idfin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfin",DataRowVersion.Original];}
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
	///id voce upb (tabella upb)
	///</summary>
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
///Assegnazione incasso al bilancio
///</summary>
public class proceedspartTable : MetaTableBase<proceedspartRow> {
	public proceedspartTable() : base("proceedspart"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("nproceedspart")){ 
			defineColumn("nproceedspart", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("amount")){ 
			defineColumn("amount", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("yproceedspart")){ 
			defineColumn("yproceedspart", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("idfin")){ 
			defineColumn("idfin", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idinc")){ 
			defineColumn("idinc", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idupb")){ 
			defineColumn("idupb", typeof(System.String));
		}
		#endregion

	}
}
}
