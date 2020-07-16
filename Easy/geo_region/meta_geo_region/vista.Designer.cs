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
namespace meta_geo_region {
public class geo_regionRow: MetaRow  {
	public geo_regionRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///regione successiva
	///</summary>
	public Int32? newregion{ 
		get {if (this["newregion"]==DBNull.Value)return null; return  (Int32?)this["newregion"];}
		set {if (value==null) this["newregion"]= DBNull.Value; else this["newregion"]= value;}
	}
	public object newregionValue { 
		get{ return this["newregion"];}
		set {if (value==null|| value==DBNull.Value) this["newregion"]= DBNull.Value; else this["newregion"]= value;}
	}
	public Int32? newregionOriginal { 
		get {if (this["newregion",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["newregion",DataRowVersion.Original];}
	}
	///<summary>
	///regione precedente
	///</summary>
	public Int32? oldregion{ 
		get {if (this["oldregion"]==DBNull.Value)return null; return  (Int32?)this["oldregion"];}
		set {if (value==null) this["oldregion"]= DBNull.Value; else this["oldregion"]= value;}
	}
	public object oldregionValue { 
		get{ return this["oldregion"];}
		set {if (value==null|| value==DBNull.Value) this["oldregion"]= DBNull.Value; else this["oldregion"]= value;}
	}
	public Int32? oldregionOriginal { 
		get {if (this["oldregion",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["oldregion",DataRowVersion.Original];}
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
///Regioni
///</summary>
public class geo_regionTable : MetaTableBase<geo_regionRow> {
	public geo_regionTable() : base("geo_region"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idnation",createColumn("idnation",typeof(int),true,false)},
			{"idregion",createColumn("idregion",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"newregion",createColumn("newregion",typeof(int),true,false)},
			{"oldregion",createColumn("oldregion",typeof(int),true,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
