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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_areadidattica {
public class areadidatticaRow: MetaRow  {
	public areadidatticaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Attivo
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
	///Codice
	///</summary>
	public Int32? idareadidattica{ 
		get {if (this["idareadidattica"]==DBNull.Value)return null; return  (Int32?)this["idareadidattica"];}
		set {if (value==null) this["idareadidattica"]= DBNull.Value; else this["idareadidattica"]= value;}
	}
	public object idareadidatticaValue { 
		get{ return this["idareadidattica"];}
		set {if (value==null|| value==DBNull.Value) this["idareadidattica"]= DBNull.Value; else this["idareadidattica"]= value;}
	}
	public Int32? idareadidatticaOriginal { 
		get {if (this["idareadidattica",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idareadidattica",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo di corso
	///</summary>
	public Int32? idcorsostudiokind{ 
		get {if (this["idcorsostudiokind"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiokind"];}
		set {if (value==null) this["idcorsostudiokind"]= DBNull.Value; else this["idcorsostudiokind"]= value;}
	}
	public object idcorsostudiokindValue { 
		get{ return this["idcorsostudiokind"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudiokind"]= DBNull.Value; else this["idcorsostudiokind"]= value;}
	}
	public Int32? idcorsostudiokindOriginal { 
		get {if (this["idcorsostudiokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiokind",DataRowVersion.Original];}
	}
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
	///Ordine
	///</summary>
	public Int32? sortcode{ 
		get {if (this["sortcode"]==DBNull.Value)return null; return  (Int32?)this["sortcode"];}
		set {if (value==null) this["sortcode"]= DBNull.Value; else this["sortcode"]= value;}
	}
	public object sortcodeValue { 
		get{ return this["sortcode"];}
		set {if (value==null|| value==DBNull.Value) this["sortcode"]= DBNull.Value; else this["sortcode"]= value;}
	}
	public Int32? sortcodeOriginal { 
		get {if (this["sortcode",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["sortcode",DataRowVersion.Original];}
	}
	///<summary>
	///Sotto-titolo
	///</summary>
	public String subtitle{ 
		get {if (this["subtitle"]==DBNull.Value)return null; return  (String)this["subtitle"];}
		set {if (value==null) this["subtitle"]= DBNull.Value; else this["subtitle"]= value;}
	}
	public object subtitleValue { 
		get{ return this["subtitle"];}
		set {if (value==null|| value==DBNull.Value) this["subtitle"]= DBNull.Value; else this["subtitle"]= value;}
	}
	public String subtitleOriginal { 
		get {if (this["subtitle",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["subtitle",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo
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
	#endregion

}
///<summary>
///VOCABOLARIO MIUR delle aree didattiche
///</summary>
public class areadidatticaTable : MetaTableBase<areadidatticaRow> {
	public areadidatticaTable() : base("areadidattica"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idareadidattica",createColumn("idareadidattica",typeof(int),false,false)},
			{"idcorsostudiokind",createColumn("idcorsostudiokind",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"sortcode",createColumn("sortcode",typeof(int),false,false)},
			{"subtitle",createColumn("subtitle",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),false,false)},
		};
	}
}
}
