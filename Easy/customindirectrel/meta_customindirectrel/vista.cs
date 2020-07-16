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
using metadatalibrary;
#pragma warning disable 1591
namespace meta_customindirectrel {
public class customindirectrelRow: MetaRow  {
	public customindirectrelRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///#
	///</summary>
	public Int32? idcustomindirectrel{ 
		get {if (this["idcustomindirectrel"]==DBNull.Value)return null; return  (Int32?)this["idcustomindirectrel"];}
		set {if (value==null) this["idcustomindirectrel"]= DBNull.Value; else this["idcustomindirectrel"]= value;}
	}
	public object idcustomindirectrelValue { 
		get{ return this["idcustomindirectrel"];}
		set {if (value==null|| value==DBNull.Value) this["idcustomindirectrel"]= DBNull.Value; else this["idcustomindirectrel"]= value;}
	}
	public Int32? idcustomindirectrelOriginal { 
		get {if (this["idcustomindirectrel",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcustomindirectrel",DataRowVersion.Original];}
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
	///Nome maschera
	///</summary>
	public String edittype{ 
		get {if (this["edittype"]==DBNull.Value)return null; return  (String)this["edittype"];}
		set {if (value==null) this["edittype"]= DBNull.Value; else this["edittype"]= value;}
	}
	public object edittypeValue { 
		get{ return this["edittype"];}
		set {if (value==null|| value==DBNull.Value) this["edittype"]= DBNull.Value; else this["edittype"]= value;}
	}
	public String edittypeOriginal { 
		get {if (this["edittype",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["edittype",DataRowVersion.Original];}
	}
	///<summary>
	///Filtro da applicare alla tabella di mezzo
	///</summary>
	public String filtermiddle{ 
		get {if (this["filtermiddle"]==DBNull.Value)return null; return  (String)this["filtermiddle"];}
		set {if (value==null) this["filtermiddle"]= DBNull.Value; else this["filtermiddle"]= value;}
	}
	public object filtermiddleValue { 
		get{ return this["filtermiddle"];}
		set {if (value==null|| value==DBNull.Value) this["filtermiddle"]= DBNull.Value; else this["filtermiddle"]= value;}
	}
	public String filtermiddleOriginal { 
		get {if (this["filtermiddle",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["filtermiddle",DataRowVersion.Original];}
	}
	///<summary>
	///Filtro per ricerca in parent2
	///</summary>
	public String filterparenttable2{ 
		get {if (this["filterparenttable2"]==DBNull.Value)return null; return  (String)this["filterparenttable2"];}
		set {if (value==null) this["filterparenttable2"]= DBNull.Value; else this["filterparenttable2"]= value;}
	}
	public object filterparenttable2Value { 
		get{ return this["filterparenttable2"];}
		set {if (value==null|| value==DBNull.Value) this["filterparenttable2"]= DBNull.Value; else this["filterparenttable2"]= value;}
	}
	public String filterparenttable2Original { 
		get {if (this["filterparenttable2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["filterparenttable2",DataRowVersion.Original];}
	}
	///<summary>
	///flag per relazioni indirette
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
	///<summary>
	///Filtro attivazione inserimento, si applica alla tabella parent1
	///</summary>
	public String insertfilterparenttable1{ 
		get {if (this["insertfilterparenttable1"]==DBNull.Value)return null; return  (String)this["insertfilterparenttable1"];}
		set {if (value==null) this["insertfilterparenttable1"]= DBNull.Value; else this["insertfilterparenttable1"]= value;}
	}
	public object insertfilterparenttable1Value { 
		get{ return this["insertfilterparenttable1"];}
		set {if (value==null|| value==DBNull.Value) this["insertfilterparenttable1"]= DBNull.Value; else this["insertfilterparenttable1"]= value;}
	}
	public String insertfilterparenttable1Original { 
		get {if (this["insertfilterparenttable1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["insertfilterparenttable1",DataRowVersion.Original];}
	}
	///<summary>
	///data ultima modifica
	///</summary>
	public DateTime? lastmodtimestamp{ 
		get {if (this["lastmodtimestamp"]==DBNull.Value)return null; return  (DateTime?)this["lastmodtimestamp"];}
		set {if (value==null) this["lastmodtimestamp"]= DBNull.Value; else this["lastmodtimestamp"]= value;}
	}
	public object lastmodtimestampValue { 
		get{ return this["lastmodtimestamp"];}
		set {if (value==null|| value==DBNull.Value) this["lastmodtimestamp"]= DBNull.Value; else this["lastmodtimestamp"]= value;}
	}
	public DateTime? lastmodtimestampOriginal { 
		get {if (this["lastmodtimestamp",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lastmodtimestamp",DataRowVersion.Original];}
	}
	///<summary>
	///Utente ultima modifica
	///</summary>
	public String lastmoduser{ 
		get {if (this["lastmoduser"]==DBNull.Value)return null; return  (String)this["lastmoduser"];}
		set {if (value==null) this["lastmoduser"]= DBNull.Value; else this["lastmoduser"]= value;}
	}
	public object lastmoduserValue { 
		get{ return this["lastmoduser"];}
		set {if (value==null|| value==DBNull.Value) this["lastmoduser"]= DBNull.Value; else this["lastmoduser"]= value;}
	}
	public String lastmoduserOriginal { 
		get {if (this["lastmoduser",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lastmoduser",DataRowVersion.Original];}
	}
	///<summary>
	///nome elenco
	///</summary>
	public String listtype{ 
		get {if (this["listtype"]==DBNull.Value)return null; return  (String)this["listtype"];}
		set {if (value==null) this["listtype"]= DBNull.Value; else this["listtype"]= value;}
	}
	public object listtypeValue { 
		get{ return this["listtype"];}
		set {if (value==null|| value==DBNull.Value) this["listtype"]= DBNull.Value; else this["listtype"]= value;}
	}
	public String listtypeOriginal { 
		get {if (this["listtype",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["listtype",DataRowVersion.Original];}
	}
	///<summary>
	///Tabella di mezzo
	///</summary>
	public String middletable{ 
		get {if (this["middletable"]==DBNull.Value)return null; return  (String)this["middletable"];}
		set {if (value==null) this["middletable"]= DBNull.Value; else this["middletable"]= value;}
	}
	public object middletableValue { 
		get{ return this["middletable"];}
		set {if (value==null|| value==DBNull.Value) this["middletable"]= DBNull.Value; else this["middletable"]= value;}
	}
	public String middletableOriginal { 
		get {if (this["middletable",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["middletable",DataRowVersion.Original];}
	}
	///<summary>
	///Filtro attivazione navigazione da parent1
	///</summary>
	public String navigationfilterparenttable1{ 
		get {if (this["navigationfilterparenttable1"]==DBNull.Value)return null; return  (String)this["navigationfilterparenttable1"];}
		set {if (value==null) this["navigationfilterparenttable1"]= DBNull.Value; else this["navigationfilterparenttable1"]= value;}
	}
	public object navigationfilterparenttable1Value { 
		get{ return this["navigationfilterparenttable1"];}
		set {if (value==null|| value==DBNull.Value) this["navigationfilterparenttable1"]= DBNull.Value; else this["navigationfilterparenttable1"]= value;}
	}
	public String navigationfilterparenttable1Original { 
		get {if (this["navigationfilterparenttable1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["navigationfilterparenttable1",DataRowVersion.Original];}
	}
	///<summary>
	///Tabella parent1, da cui si origina la navigazione
	///</summary>
	public String parenttable1{ 
		get {if (this["parenttable1"]==DBNull.Value)return null; return  (String)this["parenttable1"];}
		set {if (value==null) this["parenttable1"]= DBNull.Value; else this["parenttable1"]= value;}
	}
	public object parenttable1Value { 
		get{ return this["parenttable1"];}
		set {if (value==null|| value==DBNull.Value) this["parenttable1"]= DBNull.Value; else this["parenttable1"]= value;}
	}
	public String parenttable1Original { 
		get {if (this["parenttable1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["parenttable1",DataRowVersion.Original];}
	}
	///<summary>
	///Tabella parent2, destinazione della relazione
	///</summary>
	public String parenttable2{ 
		get {if (this["parenttable2"]==DBNull.Value)return null; return  (String)this["parenttable2"];}
		set {if (value==null) this["parenttable2"]= DBNull.Value; else this["parenttable2"]= value;}
	}
	public object parenttable2Value { 
		get{ return this["parenttable2"];}
		set {if (value==null|| value==DBNull.Value) this["parenttable2"]= DBNull.Value; else this["parenttable2"]= value;}
	}
	public String parenttable2Original { 
		get {if (this["parenttable2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["parenttable2",DataRowVersion.Original];}
	}
	///<summary>
	///Vista in cui è cercata la riga per la destinazione
	///</summary>
	public String parenttable2view{ 
		get {if (this["parenttable2view"]==DBNull.Value)return null; return  (String)this["parenttable2view"];}
		set {if (value==null) this["parenttable2view"]= DBNull.Value; else this["parenttable2view"]= value;}
	}
	public object parenttable2viewValue { 
		get{ return this["parenttable2view"];}
		set {if (value==null|| value==DBNull.Value) this["parenttable2view"]= DBNull.Value; else this["parenttable2view"]= value;}
	}
	public String parenttable2viewOriginal { 
		get {if (this["parenttable2view",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["parenttable2view",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Relazione indiretta tra tabelle
///</summary>
public class customindirectrelTable : MetaTableBase<customindirectrelRow> {
	public customindirectrelTable() : base("customindirectrel"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idcustomindirectrel",createColumn("idcustomindirectrel",typeof(Int32),false,false)},
			{"description",createColumn("description",typeof(String),false,false)},
			{"edittype",createColumn("edittype",typeof(String),false,false)},
			{"filtermiddle",createColumn("filtermiddle",typeof(String),true,false)},
			{"filterparenttable2",createColumn("filterparenttable2",typeof(String),true,false)},
			{"flag",createColumn("flag",typeof(Int32),false,false)},
			{"insertfilterparenttable1",createColumn("insertfilterparenttable1",typeof(String),true,false)},
			{"lastmodtimestamp",createColumn("lastmodtimestamp",typeof(DateTime),true,false)},
			{"lastmoduser",createColumn("lastmoduser",typeof(String),true,false)},
			{"listtype",createColumn("listtype",typeof(String),true,false)},
			{"middletable",createColumn("middletable",typeof(String),true,false)},
			{"navigationfilterparenttable1",createColumn("navigationfilterparenttable1",typeof(String),true,false)},
			{"parenttable1",createColumn("parenttable1",typeof(String),false,false)},
			{"parenttable2",createColumn("parenttable2",typeof(String),false,false)},
			{"parenttable2view",createColumn("parenttable2view",typeof(String),true,false)},
		};
	}
}
}
