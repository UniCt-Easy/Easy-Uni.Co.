
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
namespace meta_geo_nation {
public class geo_nationRow: MetaRow  {
	public geo_nationRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String lang{ 
		get {if (this["lang"]==DBNull.Value)return null; return  (String)this["lang"];}
		set {if (value==null) this["lang"]= DBNull.Value; else this["lang"]= value;}
	}
	public object langValue { 
		get{ return this["lang"];}
		set {if (value==null|| value==DBNull.Value) this["lang"]= DBNull.Value; else this["lang"]= value;}
	}
	public String langOriginal { 
		get {if (this["lang",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lang",DataRowVersion.Original];}
	}
	///<summary>
	///id continente
	///</summary>
	public Int32? idcontinent{ 
		get {if (this["idcontinent"]==DBNull.Value)return null; return  (Int32?)this["idcontinent"];}
		set {if (value==null) this["idcontinent"]= DBNull.Value; else this["idcontinent"]= value;}
	}
	public object idcontinentValue { 
		get{ return this["idcontinent"];}
		set {if (value==null|| value==DBNull.Value) this["idcontinent"]= DBNull.Value; else this["idcontinent"]= value;}
	}
	public Int32? idcontinentOriginal { 
		get {if (this["idcontinent",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcontinent",DataRowVersion.Original];}
	}
	///<summary>
	///Id nazione (tabella geo_nation)
	///</summary>
	public Int32? idnation{ 
		get {if (this["idnation"]==DBNull.Value)return null; return  (Int32?)this["idnation"];}
		set {if (value==null) this["idnation"]= DBNull.Value; else this["idnation"]= value;}
	}
	public object idnationValue { 
		get{ return this["idnation"];}
		set {if (value==null|| value==DBNull.Value) this["idnation"]= DBNull.Value; else this["idnation"]= value;}
	}
	public Int32? idnationOriginal { 
		get {if (this["idnation",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnation",DataRowVersion.Original];}
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
	///nazione in cui questa è confluita
	///</summary>
	public Int32? newnation{ 
		get {if (this["newnation"]==DBNull.Value)return null; return  (Int32?)this["newnation"];}
		set {if (value==null) this["newnation"]= DBNull.Value; else this["newnation"]= value;}
	}
	public object newnationValue { 
		get{ return this["newnation"];}
		set {if (value==null|| value==DBNull.Value) this["newnation"]= DBNull.Value; else this["newnation"]= value;}
	}
	public Int32? newnationOriginal { 
		get {if (this["newnation",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["newnation",DataRowVersion.Original];}
	}
	///<summary>
	///nazione da cui questa  è confluita
	///</summary>
	public Int32? oldnation{ 
		get {if (this["oldnation"]==DBNull.Value)return null; return  (Int32?)this["oldnation"];}
		set {if (value==null) this["oldnation"]= DBNull.Value; else this["oldnation"]= value;}
	}
	public object oldnationValue { 
		get{ return this["oldnation"];}
		set {if (value==null|| value==DBNull.Value) this["oldnation"]= DBNull.Value; else this["oldnation"]= value;}
	}
	public Int32? oldnationOriginal { 
		get {if (this["oldnation",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["oldnation",DataRowVersion.Original];}
	}
	///<summary>
	///data inizio
	///</summary>
	public DateTime? start{ 
		get {if (this["start"]==DBNull.Value)return null; return  (DateTime?)this["start"];}
		set {if (value==null) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public object startValue { 
		get{ return this["start"];}
		set {if (value==null|| value==DBNull.Value) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public DateTime? startOriginal { 
		get {if (this["start",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["start",DataRowVersion.Original];}
	}
	///<summary>
	///data fine
	///</summary>
	public DateTime? stop{ 
		get {if (this["stop"]==DBNull.Value)return null; return  (DateTime?)this["stop"];}
		set {if (value==null) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public object stopValue { 
		get{ return this["stop"];}
		set {if (value==null|| value==DBNull.Value) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public DateTime? stopOriginal { 
		get {if (this["stop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["stop",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///Nazioni
///</summary>
public class geo_nationTable : MetaTableBase<geo_nationRow> {
	public geo_nationTable() : base("geo_nation"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"lang",createColumn("lang",typeof(string),true,false)},
			{"idcontinent",createColumn("idcontinent",typeof(int),true,false)},
			{"idnation",createColumn("idnation",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"newnation",createColumn("newnation",typeof(int),true,false)},
			{"oldnation",createColumn("oldnation",typeof(int),true,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
