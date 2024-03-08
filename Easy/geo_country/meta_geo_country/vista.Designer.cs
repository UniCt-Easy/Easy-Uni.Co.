
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
namespace meta_geo_country {
public class geo_countryRow: MetaRow  {
	public geo_countryRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///id regione (tabella geo_region)
	///</summary>
	public Int32? idregion{ 
		get {if (this["idregion"]==DBNull.Value)return null; return  (Int32?)this["idregion"];}
		set {if (value==null) this["idregion"]= DBNull.Value; else this["idregion"]= value;}
	}
	public object idregionValue { 
		get{ return this["idregion"];}
		set {if (value==null|| value==DBNull.Value) this["idregion"]= DBNull.Value; else this["idregion"]= value;}
	}
	public Int32? idregionOriginal { 
		get {if (this["idregion",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idregion",DataRowVersion.Original];}
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
	///id nuova provincia in cui questa ? confluita
	///</summary>
	public Int32? newcountry{ 
		get {if (this["newcountry"]==DBNull.Value)return null; return  (Int32?)this["newcountry"];}
		set {if (value==null) this["newcountry"]= DBNull.Value; else this["newcountry"]= value;}
	}
	public object newcountryValue { 
		get{ return this["newcountry"];}
		set {if (value==null|| value==DBNull.Value) this["newcountry"]= DBNull.Value; else this["newcountry"]= value;}
	}
	public Int32? newcountryOriginal { 
		get {if (this["newcountry",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["newcountry",DataRowVersion.Original];}
	}
	///<summary>
	///id provincia da cui questa ? confluita
	///</summary>
	public Int32? oldcountry{ 
		get {if (this["oldcountry"]==DBNull.Value)return null; return  (Int32?)this["oldcountry"];}
		set {if (value==null) this["oldcountry"]= DBNull.Value; else this["oldcountry"]= value;}
	}
	public object oldcountryValue { 
		get{ return this["oldcountry"];}
		set {if (value==null|| value==DBNull.Value) this["oldcountry"]= DBNull.Value; else this["oldcountry"]= value;}
	}
	public Int32? oldcountryOriginal { 
		get {if (this["oldcountry",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["oldcountry",DataRowVersion.Original];}
	}
	///<summary>
	///sigla provincia
	///</summary>
	public String province{ 
		get {if (this["province"]==DBNull.Value)return null; return  (String)this["province"];}
		set {if (value==null) this["province"]= DBNull.Value; else this["province"]= value;}
	}
	public object provinceValue { 
		get{ return this["province"];}
		set {if (value==null|| value==DBNull.Value) this["province"]= DBNull.Value; else this["province"]= value;}
	}
	public String provinceOriginal { 
		get {if (this["province",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["province",DataRowVersion.Original];}
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
///Province
///</summary>
public class geo_countryTable : MetaTableBase<geo_countryRow> {
	public geo_countryTable() : base("geo_country"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idcountry",createColumn("idcountry",typeof(int),false,false)},
			{"idregion",createColumn("idregion",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"newcountry",createColumn("newcountry",typeof(int),true,false)},
			{"oldcountry",createColumn("oldcountry",typeof(int),true,false)},
			{"province",createColumn("province",typeof(string),true,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
