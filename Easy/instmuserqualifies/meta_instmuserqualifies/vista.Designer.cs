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
namespace meta_instmuserqualifies {
public class instmuserqualifiesRow: MetaRow  {
	public instmuserqualifiesRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///Qualifica
	///</summary>
	public Int32? idinstmqualifies{ 
		get {if (this["idinstmqualifies"]==DBNull.Value)return null; return  (Int32?)this["idinstmqualifies"];}
		set {if (value==null) this["idinstmqualifies"]= DBNull.Value; else this["idinstmqualifies"]= value;}
	}
	public object idinstmqualifiesValue { 
		get{ return this["idinstmqualifies"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmqualifies"]= DBNull.Value; else this["idinstmqualifies"]= value;}
	}
	public Int32? idinstmqualifiesOriginal { 
		get {if (this["idinstmqualifies",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmqualifies",DataRowVersion.Original];}
	}
	public Int32? idinstmuserqualifies{ 
		get {if (this["idinstmuserqualifies"]==DBNull.Value)return null; return  (Int32?)this["idinstmuserqualifies"];}
		set {if (value==null) this["idinstmuserqualifies"]= DBNull.Value; else this["idinstmuserqualifies"]= value;}
	}
	public object idinstmuserqualifiesValue { 
		get{ return this["idinstmuserqualifies"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmuserqualifies"]= DBNull.Value; else this["idinstmuserqualifies"]= value;}
	}
	public Int32? idinstmuserqualifiesOriginal { 
		get {if (this["idinstmuserqualifies",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmuserqualifies",DataRowVersion.Original];}
	}
	public Int32? idreg_instmuser{ 
		get {if (this["idreg_instmuser"]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser"];}
		set {if (value==null) this["idreg_instmuser"]= DBNull.Value; else this["idreg_instmuser"]= value;}
	}
	public object idreg_instmuserValue { 
		get{ return this["idreg_instmuser"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_instmuser"]= DBNull.Value; else this["idreg_instmuser"]= value;}
	}
	public Int32? idreg_instmuserOriginal { 
		get {if (this["idreg_instmuser",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser",DataRowVersion.Original];}
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
	///dal
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
	///al
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
	///Data di Scadenza Incarico 
	///</summary>
	public DateTime? termoffice{ 
		get {if (this["termoffice"]==DBNull.Value)return null; return  (DateTime?)this["termoffice"];}
		set {if (value==null) this["termoffice"]= DBNull.Value; else this["termoffice"]= value;}
	}
	public object termofficeValue { 
		get{ return this["termoffice"];}
		set {if (value==null|| value==DBNull.Value) this["termoffice"]= DBNull.Value; else this["termoffice"]= value;}
	}
	public DateTime? termofficeOriginal { 
		get {if (this["termoffice",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["termoffice",DataRowVersion.Original];}
	}
	#endregion

}
public class instmuserqualifiesTable : MetaTableBase<instmuserqualifiesRow> {
	public instmuserqualifiesTable() : base("instmuserqualifies"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idinstmqualifies",createColumn("idinstmqualifies",typeof(int),true,false)},
			{"idinstmuserqualifies",createColumn("idinstmuserqualifies",typeof(int),false,false)},
			{"idreg_instmuser",createColumn("idreg_instmuser",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"stop",createColumn("stop",typeof(DateTime),false,false)},
			{"termoffice",createColumn("termoffice",typeof(DateTime),true,false)},
		};
	}
}
}
