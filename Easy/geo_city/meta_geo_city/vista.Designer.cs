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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_geo_city {
public class geo_cityRow: MetaRow  {
	public geo_cityRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id città (tabella geo_city)
	///</summary>
	public Int32? idcity{ 
		get {if (this["idcity"]==DBNull.Value)return null; return  (Int32?)this["idcity"];}
		set {if (value==null) this["idcity"]= DBNull.Value; else this["idcity"]= value;}
	}
	public object idcityValue { 
		get{ return this["idcity"];}
		set {if (value==null|| value==DBNull.Value) this["idcity"]= DBNull.Value; else this["idcity"]= value;}
	}
	public Int32? idcityOriginal { 
		get {if (this["idcity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity",DataRowVersion.Original];}
	}
	///<summary>
	///id paese (tabella geo_country)
	///</summary>
	public Int32? idcountry{ 
		get {if (this["idcountry"]==DBNull.Value)return null; return  (Int32?)this["idcountry"];}
		set {if (value==null) this["idcountry"]= DBNull.Value; else this["idcountry"]= value;}
	}
	public object idcountryValue { 
		get{ return this["idcountry"];}
		set {if (value==null|| value==DBNull.Value) this["idcountry"]= DBNull.Value; else this["idcountry"]= value;}
	}
	public Int32? idcountryOriginal { 
		get {if (this["idcountry",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcountry",DataRowVersion.Original];}
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
	///id nuovo comune in cui questo ? eventualmente confluito, se valorizzato questo comune non ? pi? valido
	///</summary>
	public Int32? newcity{ 
		get {if (this["newcity"]==DBNull.Value)return null; return  (Int32?)this["newcity"];}
		set {if (value==null) this["newcity"]= DBNull.Value; else this["newcity"]= value;}
	}
	public object newcityValue { 
		get{ return this["newcity"];}
		set {if (value==null|| value==DBNull.Value) this["newcity"]= DBNull.Value; else this["newcity"]= value;}
	}
	public Int32? newcityOriginal { 
		get {if (this["newcity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["newcity",DataRowVersion.Original];}
	}
	///<summary>
	///id comune da cui questo ? confluito
	///</summary>
	public Int32? oldcity{ 
		get {if (this["oldcity"]==DBNull.Value)return null; return  (Int32?)this["oldcity"];}
		set {if (value==null) this["oldcity"]= DBNull.Value; else this["oldcity"]= value;}
	}
	public object oldcityValue { 
		get{ return this["oldcity"];}
		set {if (value==null|| value==DBNull.Value) this["oldcity"]= DBNull.Value; else this["oldcity"]= value;}
	}
	public Int32? oldcityOriginal { 
		get {if (this["oldcity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["oldcity",DataRowVersion.Original];}
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
///Comuni
///</summary>
public class geo_cityTable : MetaTableBase<geo_cityRow> {
	public geo_cityTable() : base("geo_city"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idcity",createColumn("idcity",typeof(int),false,false)},
			{"idcountry",createColumn("idcountry",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"newcity",createColumn("newcity",typeof(int),true,false)},
			{"oldcity",createColumn("oldcity",typeof(int),true,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
