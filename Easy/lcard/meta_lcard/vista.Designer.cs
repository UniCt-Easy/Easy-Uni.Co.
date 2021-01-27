
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
namespace meta_lcard {
public class lcardRow: MetaRow  {
	public lcardRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id card magazzino (tabella lcard)
	///</summary>
	public Int32? idlcard{ 
		get {if (this["idlcard"]==DBNull.Value)return null; return  (Int32?)this["idlcard"];}
		set {if (value==null) this["idlcard"]= DBNull.Value; else this["idlcard"]= value;}
	}
	public object idlcardValue { 
		get{ return this["idlcard"];}
		set {if (value==null|| value==DBNull.Value) this["idlcard"]= DBNull.Value; else this["idlcard"]= value;}
	}
	public Int32? idlcardOriginal { 
		get {if (this["idlcard",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlcard",DataRowVersion.Original];}
	}
	///<summary>
	///Intestazione
	///</summary>
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
	///anno inizio validit?
	///</summary>
	public Int16? ystart{ 
		get {if (this["ystart"]==DBNull.Value)return null; return  (Int16?)this["ystart"];}
		set {if (value==null) this["ystart"]= DBNull.Value; else this["ystart"]= value;}
	}
	public object ystartValue { 
		get{ return this["ystart"];}
		set {if (value==null|| value==DBNull.Value) this["ystart"]= DBNull.Value; else this["ystart"]= value;}
	}
	public Int16? ystartOriginal { 
		get {if (this["ystart",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ystart",DataRowVersion.Original];}
	}
	///<summary>
	///anno fine validit?
	///</summary>
	public Int16? ystop{ 
		get {if (this["ystop"]==DBNull.Value)return null; return  (Int16?)this["ystop"];}
		set {if (value==null) this["ystop"]= DBNull.Value; else this["ystop"]= value;}
	}
	public object ystopValue { 
		get{ return this["ystop"];}
		set {if (value==null|| value==DBNull.Value) this["ystop"]= DBNull.Value; else this["ystop"]= value;}
	}
	public Int16? ystopOriginal { 
		get {if (this["ystop",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ystop",DataRowVersion.Original];}
	}
	///<summary>
	///attivo
	///</summary>
	public String active{ 
		get {if (this["active"]==DBNull.Value)return null; return  (String)this["active"];}
		set {if (value==null) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {if (value==null|| value==DBNull.Value) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public String activeOriginal { 
		get {if (this["active",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["active",DataRowVersion.Original];}
	}
	///<summary>
	///id responsabile (tabella manager)
	///</summary>
	public Int32? idman{ 
		get {if (this["idman"]==DBNull.Value)return null; return  (Int32?)this["idman"];}
		set {if (value==null) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public object idmanValue { 
		get{ return this["idman"];}
		set {if (value==null|| value==DBNull.Value) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public Int32? idmanOriginal { 
		get {if (this["idman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idman",DataRowVersion.Original];}
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
	///Chiave magazzino (tabella store)
	///</summary>
	public Int32? idstore{ 
		get {if (this["idstore"]==DBNull.Value)return null; return  (Int32?)this["idstore"];}
		set {if (value==null) this["idstore"]= DBNull.Value; else this["idstore"]= value;}
	}
	public object idstoreValue { 
		get{ return this["idstore"];}
		set {if (value==null|| value==DBNull.Value) this["idstore"]= DBNull.Value; else this["idstore"]= value;}
	}
	public Int32? idstoreOriginal { 
		get {if (this["idstore",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstore",DataRowVersion.Original];}
	}
	///<summary>
	///Codice esterno
	///</summary>
	public String extcode{ 
		get {if (this["extcode"]==DBNull.Value)return null; return  (String)this["extcode"];}
		set {if (value==null) this["extcode"]= DBNull.Value; else this["extcode"]= value;}
	}
	public object extcodeValue { 
		get{ return this["extcode"];}
		set {if (value==null|| value==DBNull.Value) this["extcode"]= DBNull.Value; else this["extcode"]= value;}
	}
	public String extcodeOriginal { 
		get {if (this["extcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["extcode",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Card
///</summary>
public class lcardTable : MetaTableBase<lcardRow> {
	public lcardTable() : base("lcard"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idlcard")){ 
			defineColumn("idlcard", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("title")){ 
			defineColumn("title", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String));
		}
		if (definedColums.ContainsKey("ystart")){ 
			defineColumn("ystart", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("ystop")){ 
			defineColumn("ystop", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("active")){ 
			defineColumn("active", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idman")){ 
			defineColumn("idman", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String));
		}
		if (definedColums.ContainsKey("idstore")){ 
			defineColumn("idstore", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("extcode")){ 
			defineColumn("extcode", typeof(System.String));
		}
		#endregion

	}
}
}
