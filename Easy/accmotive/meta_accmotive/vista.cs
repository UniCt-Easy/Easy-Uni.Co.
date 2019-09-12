/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace meta_accmotive {
public class accmotiveRow: MetaRow  {
	public accmotiveRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id causale (tabella acccmotive)
	///</summary>
	public String idaccmotive{ 
		get {if (this["idaccmotive"]==DBNull.Value)return null; return  (String)this["idaccmotive"];}
		set {if (value==null) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public object idaccmotiveValue { 
		get{ return this["idaccmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public String idaccmotiveOriginal { 
		get {if (this["idaccmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive",DataRowVersion.Original];}
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
	///Codice causale
	///</summary>
	public String codemotive{ 
		get {if (this["codemotive"]==DBNull.Value)return null; return  (String)this["codemotive"];}
		set {if (value==null) this["codemotive"]= DBNull.Value; else this["codemotive"]= value;}
	}
	public object codemotiveValue { 
		get{ return this["codemotive"];}
		set {if (value==null|| value==DBNull.Value) this["codemotive"]= DBNull.Value; else this["codemotive"]= value;}
	}
	public String codemotiveOriginal { 
		get {if (this["codemotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codemotive",DataRowVersion.Original];}
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
	///chiave della riga parent (idaccmotive)
	///</summary>
	public String paridaccmotive{ 
		get {if (this["paridaccmotive"]==DBNull.Value)return null; return  (String)this["paridaccmotive"];}
		set {if (value==null) this["paridaccmotive"]= DBNull.Value; else this["paridaccmotive"]= value;}
	}
	public object paridaccmotiveValue { 
		get{ return this["paridaccmotive"];}
		set {if (value==null|| value==DBNull.Value) this["paridaccmotive"]= DBNull.Value; else this["paridaccmotive"]= value;}
	}
	public String paridaccmotiveOriginal { 
		get {if (this["paridaccmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["paridaccmotive",DataRowVersion.Original];}
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
	///Utilizzabile dai dipartimenti
	///	 N: Non Ã¨ vero che: "Utilizzabile dai dipartimenti"
	///	 S: Utilizzabile dai dipartimenti
	///</summary>
	public String flagdep{ 
		get {if (this["flagdep"]==DBNull.Value)return null; return  (String)this["flagdep"];}
		set {if (value==null) this["flagdep"]= DBNull.Value; else this["flagdep"]= value;}
	}
	public object flagdepValue { 
		get{ return this["flagdep"];}
		set {if (value==null|| value==DBNull.Value) this["flagdep"]= DBNull.Value; else this["flagdep"]= value;}
	}
	public String flagdepOriginal { 
		get {if (this["flagdep",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagdep",DataRowVersion.Original];}
	}
	///<summary>
	///Utilizzabile dall'Amministrazione
	///	 N: Non utilizzabile dall'Amministrazione
	///	 S: Utilizzabile dall'Amministrazione
	///</summary>
	public String flagamm{ 
		get {if (this["flagamm"]==DBNull.Value)return null; return  (String)this["flagamm"];}
		set {if (value==null) this["flagamm"]= DBNull.Value; else this["flagamm"]= value;}
	}
	public object flagammValue { 
		get{ return this["flagamm"];}
		set {if (value==null|| value==DBNull.Value) this["flagamm"]= DBNull.Value; else this["flagamm"]= value;}
	}
	public String flagammOriginal { 
		get {if (this["flagamm",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagamm",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo spesa PCC (COrrente o CApitale)
	///</summary>
	public String expensekind{ 
		get {if (this["expensekind"]==DBNull.Value)return null; return  (String)this["expensekind"];}
		set {if (value==null) this["expensekind"]= DBNull.Value; else this["expensekind"]= value;}
	}
	public object expensekindValue { 
		get{ return this["expensekind"];}
		set {if (value==null|| value==DBNull.Value) this["expensekind"]= DBNull.Value; else this["expensekind"]= value;}
	}
	public String expensekindOriginal { 
		get {if (this["expensekind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["expensekind",DataRowVersion.Original];}
	}
	///<summary>
	///flag
	///</summary>
	public Int32? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Int32?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Int32? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flag",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Piano dei conti
///</summary>
public class accmotiveTable : MetaTableBase<accmotiveRow> {
	public accmotiveTable() : base("accmotive"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idaccmotive",createColumn("idaccmotive",typeof(string),false,false)},
			{"active",createColumn("active",typeof(string),true,false)},
			{"codemotive",createColumn("codemotive",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"paridaccmotive",createColumn("paridaccmotive",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),false,false)},
			{"flagdep",createColumn("flagdep",typeof(string),true,false)},
			{"flagamm",createColumn("flagamm",typeof(string),true,false)},
			{"expensekind",createColumn("expensekind",typeof(string),true,false)},
			{"flag",createColumn("flag",typeof(int),true,false)},
		};
	}
}
}
