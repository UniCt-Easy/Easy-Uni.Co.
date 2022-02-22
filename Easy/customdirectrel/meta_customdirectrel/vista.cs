
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
namespace meta_customdirectrel {
public class customdirectrelRow: MetaRow  {
	public customdirectrelRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///#
	///</summary>
	public Int32? idcustomdirectrel{ 
		get {if (this["idcustomdirectrel"]==DBNull.Value)return null; return  (Int32?)this["idcustomdirectrel"];}
		set {if (value==null) this["idcustomdirectrel"]= DBNull.Value; else this["idcustomdirectrel"]= value;}
	}
	public object idcustomdirectrelValue { 
		get{ return this["idcustomdirectrel"];}
		set {if (value==null|| value==DBNull.Value) this["idcustomdirectrel"]= DBNull.Value; else this["idcustomdirectrel"]= value;}
	}
	public Int32? idcustomdirectrelOriginal { 
		get {if (this["idcustomdirectrel",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcustomdirectrel",DataRowVersion.Original];}
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
	///filtro da applicare in fase di navigazione
	///</summary>
	public String filter{ 
		get {if (this["filter"]==DBNull.Value)return null; return  (String)this["filter"];}
		set {if (value==null) this["filter"]= DBNull.Value; else this["filter"]= value;}
	}
	public object filterValue { 
		get{ return this["filter"];}
		set {if (value==null|| value==DBNull.Value) this["filter"]= DBNull.Value; else this["filter"]= value;}
	}
	public String filterOriginal { 
		get {if (this["filter",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["filter",DataRowVersion.Original];}
	}
	///<summary>
	///flag per relazioni dirette
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
	///Tabella origine, in cui appare il menu contestuale
	///</summary>
	public String fromtable{ 
		get {if (this["fromtable"]==DBNull.Value)return null; return  (String)this["fromtable"];}
		set {if (value==null) this["fromtable"]= DBNull.Value; else this["fromtable"]= value;}
	}
	public object fromtableValue { 
		get{ return this["fromtable"];}
		set {if (value==null|| value==DBNull.Value) this["fromtable"]= DBNull.Value; else this["fromtable"]= value;}
	}
	public String fromtableOriginal { 
		get {if (this["fromtable",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["fromtable",DataRowVersion.Original];}
	}
	///<summary>
	///Condizione che attiva la possibilità di inserire nella tabella figlia, si applica sulla riga corrente della tabella From
	///</summary>
	public String insertfilterparent{ 
		get {if (this["insertfilterparent"]==DBNull.Value)return null; return  (String)this["insertfilterparent"];}
		set {if (value==null) this["insertfilterparent"]= DBNull.Value; else this["insertfilterparent"]= value;}
	}
	public object insertfilterparentValue { 
		get{ return this["insertfilterparent"];}
		set {if (value==null|| value==DBNull.Value) this["insertfilterparent"]= DBNull.Value; else this["insertfilterparent"]= value;}
	}
	public String insertfilterparentOriginal { 
		get {if (this["insertfilterparent",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["insertfilterparent",DataRowVersion.Original];}
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
	///Condizione che attiva la possibilità di navigare, si applica sulla riga corrente della tabella From
	///</summary>
	public String navigationfilterparent{ 
		get {if (this["navigationfilterparent"]==DBNull.Value)return null; return  (String)this["navigationfilterparent"];}
		set {if (value==null) this["navigationfilterparent"]= DBNull.Value; else this["navigationfilterparent"]= value;}
	}
	public object navigationfilterparentValue { 
		get{ return this["navigationfilterparent"];}
		set {if (value==null|| value==DBNull.Value) this["navigationfilterparent"]= DBNull.Value; else this["navigationfilterparent"]= value;}
	}
	public String navigationfilterparentOriginal { 
		get {if (this["navigationfilterparent",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["navigationfilterparent",DataRowVersion.Original];}
	}
	///<summary>
	///Tabella verso cui navigare
	///</summary>
	public String totable{ 
		get {if (this["totable"]==DBNull.Value)return null; return  (String)this["totable"];}
		set {if (value==null) this["totable"]= DBNull.Value; else this["totable"]= value;}
	}
	public object totableValue { 
		get{ return this["totable"];}
		set {if (value==null|| value==DBNull.Value) this["totable"]= DBNull.Value; else this["totable"]= value;}
	}
	public String totableOriginal { 
		get {if (this["totable",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["totable",DataRowVersion.Original];}
	}
	///<summary>
	///Tabella o vista, facoltativa, in cui  è cercata la riga destinazione, però ai fini del form è usata la tabella From
	///</summary>
	public String totableview{ 
		get {if (this["totableview"]==DBNull.Value)return null; return  (String)this["totableview"];}
		set {if (value==null) this["totableview"]= DBNull.Value; else this["totableview"]= value;}
	}
	public object totableviewValue { 
		get{ return this["totableview"];}
		set {if (value==null|| value==DBNull.Value) this["totableview"]= DBNull.Value; else this["totableview"]= value;}
	}
	public String totableviewOriginal { 
		get {if (this["totableview",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["totableview",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Relazione diretta tra tabelle
///</summary>
public class customdirectrelTable : MetaTableBase<customdirectrelRow> {
	public customdirectrelTable() : base("customdirectrel"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idcustomdirectrel",createColumn("idcustomdirectrel",typeof(Int32),false,false)},
			{"description",createColumn("description",typeof(String),false,false)},
			{"edittype",createColumn("edittype",typeof(String),false,false)},
			{"filter",createColumn("filter",typeof(String),true,false)},
			{"flag",createColumn("flag",typeof(Int32),false,false)},
			{"fromtable",createColumn("fromtable",typeof(String),false,false)},
			{"insertfilterparent",createColumn("insertfilterparent",typeof(String),true,false)},
			{"lastmodtimestamp",createColumn("lastmodtimestamp",typeof(DateTime),true,false)},
			{"lastmoduser",createColumn("lastmoduser",typeof(String),true,false)},
			{"listtype",createColumn("listtype",typeof(String),true,false)},
			{"navigationfilterparent",createColumn("navigationfilterparent",typeof(String),true,false)},
			{"totable",createColumn("totable",typeof(String),false,false)},
			{"totableview",createColumn("totableview",typeof(String),true,false)},
		};
	}
}
}
