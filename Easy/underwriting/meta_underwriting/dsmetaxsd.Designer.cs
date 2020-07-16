/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace meta_underwriting {
public class underwritingRow: MetaRow  {
	public underwritingRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id finanziamento (tabella underwriting)
	///</summary>
	public Int32? idunderwriting{ 
		get {if (this["idunderwriting"]==DBNull.Value)return null; return  (Int32?)this["idunderwriting"];}
		set {if (value==null) this["idunderwriting"]= DBNull.Value; else this["idunderwriting"]= value;}
	}
	public object idunderwritingValue { 
		get{ return this["idunderwriting"];}
		set {if (value==null|| value==DBNull.Value) this["idunderwriting"]= DBNull.Value; else this["idunderwriting"]= value;}
	}
	public Int32? idunderwritingOriginal { 
		get {if (this["idunderwriting",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idunderwriting",DataRowVersion.Original];}
	}
	///<summary>
	///ID Ente finanziatore (tabella underwriter)
	///</summary>
	public Int32? idunderwriter{ 
		get {if (this["idunderwriter"]==DBNull.Value)return null; return  (Int32?)this["idunderwriter"];}
		set {if (value==null) this["idunderwriter"]= DBNull.Value; else this["idunderwriter"]= value;}
	}
	public object idunderwriterValue { 
		get{ return this["idunderwriter"];}
		set {if (value==null|| value==DBNull.Value) this["idunderwriter"]= DBNull.Value; else this["idunderwriter"]= value;}
	}
	public Int32? idunderwriterOriginal { 
		get {if (this["idunderwriter",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idunderwriter",DataRowVersion.Original];}
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
	///Denominazione
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
	///Codice
	///</summary>
	public String codeunderwriting{ 
		get {if (this["codeunderwriting"]==DBNull.Value)return null; return  (String)this["codeunderwriting"];}
		set {if (value==null) this["codeunderwriting"]= DBNull.Value; else this["codeunderwriting"]= value;}
	}
	public object codeunderwritingValue { 
		get{ return this["codeunderwriting"];}
		set {if (value==null|| value==DBNull.Value) this["codeunderwriting"]= DBNull.Value; else this["codeunderwriting"]= value;}
	}
	public String codeunderwritingOriginal { 
		get {if (this["codeunderwriting",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeunderwriting",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Finanziamento
///</summary>
public class underwritingTable : MetaTableBase<underwritingRow> {
	public underwritingTable() : base("underwriting"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idunderwriting",createColumn("idunderwriting",typeof(Int32),false,false)},
			{"idunderwriter",createColumn("idunderwriter",typeof(Int32),true,false)},
			{"idsor01",createColumn("idsor01",typeof(Int32),true,false)},
			{"idsor02",createColumn("idsor02",typeof(Int32),true,false)},
			{"idsor03",createColumn("idsor03",typeof(Int32),true,false)},
			{"idsor04",createColumn("idsor04",typeof(Int32),true,false)},
			{"idsor05",createColumn("idsor05",typeof(Int32),true,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"title",createColumn("title",typeof(String),false,false)},
			{"active",createColumn("active",typeof(String),true,false)},
			{"doc",createColumn("doc",typeof(String),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"codeunderwriting",createColumn("codeunderwriting",typeof(String),true,false)},
		};
	}
}
}
