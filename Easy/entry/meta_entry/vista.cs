/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
namespace meta_entry {
public class entryRow: MetaRow  {
	public entryRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num.
	///</summary>
	public Int32? nentry{ 
		get {if (this["nentry"]==DBNull.Value)return null; return  (Int32?)this["nentry"];}
		set {if (value==null) this["nentry"]= DBNull.Value; else this["nentry"]= value;}
	}
	public object nentryValue { 
		get{ return this["nentry"];}
		set {if (value==null|| value==DBNull.Value) this["nentry"]= DBNull.Value; else this["nentry"]= value;}
	}
	public Int32? nentryOriginal { 
		get {if (this["nentry",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nentry",DataRowVersion.Original];}
	}
	///<summary>
	///anno scrittura
	///</summary>
	public Int16? yentry{ 
		get {if (this["yentry"]==DBNull.Value)return null; return  (Int16?)this["yentry"];}
		set {if (value==null) this["yentry"]= DBNull.Value; else this["yentry"]= value;}
	}
	public object yentryValue { 
		get{ return this["yentry"];}
		set {if (value==null|| value==DBNull.Value) this["yentry"]= DBNull.Value; else this["yentry"]= value;}
	}
	public Int16? yentryOriginal { 
		get {if (this["yentry",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yentry",DataRowVersion.Original];}
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
	///ID Tipo scrittura (tabella entrykind)
	///</summary>
	public Int32? identrykind{ 
		get {if (this["identrykind"]==DBNull.Value)return null; return  (Int32?)this["identrykind"];}
		set {if (value==null) this["identrykind"]= DBNull.Value; else this["identrykind"]= value;}
	}
	public object identrykindValue { 
		get{ return this["identrykind"];}
		set {if (value==null|| value==DBNull.Value) this["identrykind"]= DBNull.Value; else this["identrykind"]= value;}
	}
	public Int32? identrykindOriginal { 
		get {if (this["identrykind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["identrykind",DataRowVersion.Original];}
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
	///documento
	///</summary>
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
	///<summary>
	///data documento
	///</summary>
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
	///<summary>
	///Id del documento collegato (codificato)
	///</summary>
	public String idrelated{ 
		get {if (this["idrelated"]==DBNull.Value)return null; return  (String)this["idrelated"];}
		set {if (value==null) this["idrelated"]= DBNull.Value; else this["idrelated"]= value;}
	}
	public object idrelatedValue { 
		get{ return this["idrelated"];}
		set {if (value==null|| value==DBNull.Value) this["idrelated"]= DBNull.Value; else this["idrelated"]= value;}
	}
	public String idrelatedOriginal { 
		get {if (this["idrelated",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idrelated",DataRowVersion.Original];}
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
	///bloccata
	///</summary>
	public String locked{ 
		get {if (this["locked"]==DBNull.Value)return null; return  (String)this["locked"];}
		set {if (value==null) this["locked"]= DBNull.Value; else this["locked"]= value;}
	}
	public object lockedValue { 
		get{ return this["locked"];}
		set {if (value==null|| value==DBNull.Value) this["locked"]= DBNull.Value; else this["locked"]= value;}
	}
	public String lockedOriginal { 
		get {if (this["locked",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["locked",DataRowVersion.Original];}
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
	///id voce class.sicurezza 1(tabella sorting)
	///</summary>
	public Int32? idsor01{ 
		get {if (this["idsor01"]==DBNull.Value)return null; return  (Int32?)this["idsor01"];}
		set {if (value==null) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public object idsor01Value { 
		get{ return this["idsor01"];}
		set {if (value==null|| value==DBNull.Value) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public Int32? idsor01Original { 
		get {if (this["idsor01",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor01",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 2(tabella sorting)
	///</summary>
	public Int32? idsor02{ 
		get {if (this["idsor02"]==DBNull.Value)return null; return  (Int32?)this["idsor02"];}
		set {if (value==null) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public object idsor02Value { 
		get{ return this["idsor02"];}
		set {if (value==null|| value==DBNull.Value) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public Int32? idsor02Original { 
		get {if (this["idsor02",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor02",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 3(tabella sorting)
	///</summary>
	public Int32? idsor03{ 
		get {if (this["idsor03"]==DBNull.Value)return null; return  (Int32?)this["idsor03"];}
		set {if (value==null) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public object idsor03Value { 
		get{ return this["idsor03"];}
		set {if (value==null|| value==DBNull.Value) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public Int32? idsor03Original { 
		get {if (this["idsor03",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor03",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 4(tabella sorting)
	///</summary>
	public Int32? idsor04{ 
		get {if (this["idsor04"]==DBNull.Value)return null; return  (Int32?)this["idsor04"];}
		set {if (value==null) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public object idsor04Value { 
		get{ return this["idsor04"];}
		set {if (value==null|| value==DBNull.Value) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public Int32? idsor04Original { 
		get {if (this["idsor04",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor04",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 5(tabella sorting)
	///</summary>
	public Int32? idsor05{ 
		get {if (this["idsor05"]==DBNull.Value)return null; return  (Int32?)this["idsor05"];}
		set {if (value==null) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public object idsor05Value { 
		get{ return this["idsor05"];}
		set {if (value==null|| value==DBNull.Value) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public Int32? idsor05Original { 
		get {if (this["idsor05",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor05",DataRowVersion.Original];}
	}
	///<summary>
	///ufficiale
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
///Scrittura in partita doppia
///</summary>
public class entryTable : MetaTableBase<entryRow> {
	public entryTable() : base("entry"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("nentry")){ 
			defineColumn("nentry", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("yentry")){ 
			defineColumn("yentry", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("identrykind")){ 
			defineColumn("identrykind", typeof(System.Int32));
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
		if (definedColums.ContainsKey("doc")){ 
			defineColumn("doc", typeof(System.String));
		}
		if (definedColums.ContainsKey("docdate")){ 
			defineColumn("docdate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("idrelated")){ 
			defineColumn("idrelated", typeof(System.String));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("locked")){ 
			defineColumn("locked", typeof(System.String));
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("idsor01")){ 
			defineColumn("idsor01", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor02")){ 
			defineColumn("idsor02", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor03")){ 
			defineColumn("idsor03", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor04")){ 
			defineColumn("idsor04", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor05")){ 
			defineColumn("idsor05", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("official")){ 
			defineColumn("official", typeof(System.String));
		}
		#endregion

	}
}
}
