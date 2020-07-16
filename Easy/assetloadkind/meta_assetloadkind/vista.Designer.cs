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
namespace meta_assetloadkind {
public class assetloadkindRow: MetaRow  {
	public assetloadkindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///Numero iniziale da cui partire nella creazione dei buoni di carico
	///</summary>
	public Int32? startnumber{ 
		get {if (this["startnumber"]==DBNull.Value)return null; return  (Int32?)this["startnumber"];}
		set {if (value==null) this["startnumber"]= DBNull.Value; else this["startnumber"]= value;}
	}
	public object startnumberValue { 
		get{ return this["startnumber"];}
		set {if (value==null|| value==DBNull.Value) this["startnumber"]= DBNull.Value; else this["startnumber"]= value;}
	}
	public Int32? startnumberOriginal { 
		get {if (this["startnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["startnumber",DataRowVersion.Original];}
	}
	///<summary>
	///Id inventario (tabella inventory)
	///</summary>
	public Int32? idinventory{ 
		get {if (this["idinventory"]==DBNull.Value)return null; return  (Int32?)this["idinventory"];}
		set {if (value==null) this["idinventory"]= DBNull.Value; else this["idinventory"]= value;}
	}
	public object idinventoryValue { 
		get{ return this["idinventory"];}
		set {if (value==null|| value==DBNull.Value) this["idinventory"]= DBNull.Value; else this["idinventory"]= value;}
	}
	public Int32? idinventoryOriginal { 
		get {if (this["idinventory",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinventory",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
	///</summary>
	public String codeassetloadkind{ 
		get {if (this["codeassetloadkind"]==DBNull.Value)return null; return  (String)this["codeassetloadkind"];}
		set {if (value==null) this["codeassetloadkind"]= DBNull.Value; else this["codeassetloadkind"]= value;}
	}
	public object codeassetloadkindValue { 
		get{ return this["codeassetloadkind"];}
		set {if (value==null|| value==DBNull.Value) this["codeassetloadkind"]= DBNull.Value; else this["codeassetloadkind"]= value;}
	}
	public String codeassetloadkindOriginal { 
		get {if (this["codeassetloadkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeassetloadkind",DataRowVersion.Original];}
	}
	///<summary>
	///#
	///</summary>
	public Int32? idassetloadkind{ 
		get {if (this["idassetloadkind"]==DBNull.Value)return null; return  (Int32?)this["idassetloadkind"];}
		set {if (value==null) this["idassetloadkind"]= DBNull.Value; else this["idassetloadkind"]= value;}
	}
	public object idassetloadkindValue { 
		get{ return this["idassetloadkind"];}
		set {if (value==null|| value==DBNull.Value) this["idassetloadkind"]= DBNull.Value; else this["idassetloadkind"]= value;}
	}
	public Int32? idassetloadkindOriginal { 
		get {if (this["idassetloadkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idassetloadkind",DataRowVersion.Original];}
	}
	///<summary>
	///flag
	///</summary>
	public Byte? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Byte?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Byte? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flag",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///Tipi di buoni di carico
///</summary>
public class assetloadkindTable : MetaTableBase<assetloadkindRow> {
	public assetloadkindTable() : base("assetloadkind"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"description",createColumn("description",typeof(String),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"startnumber",createColumn("startnumber",typeof(Int32),true,false)},
			{"idinventory",createColumn("idinventory",typeof(Int32),false,false)},
			{"codeassetloadkind",createColumn("codeassetloadkind",typeof(String),false,false)},
			{"idassetloadkind",createColumn("idassetloadkind",typeof(Int32),false,false)},
			{"flag",createColumn("flag",typeof(Byte),false,false)},
			{"active",createColumn("active",typeof(String),true,false)},
			{"idsor01",createColumn("idsor01",typeof(Int32),true,false)},
			{"idsor02",createColumn("idsor02",typeof(Int32),true,false)},
			{"idsor03",createColumn("idsor03",typeof(Int32),true,false)},
			{"idsor04",createColumn("idsor04",typeof(Int32),true,false)},
			{"idsor05",createColumn("idsor05",typeof(Int32),true,false)},
		};
	}
}
}
