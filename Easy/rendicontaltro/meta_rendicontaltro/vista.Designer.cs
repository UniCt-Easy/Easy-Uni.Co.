/*
    Easy
    Copyright (C) 2019 Universit‡ degli Studi di Catania (www.unict.it)

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
namespace meta_rendicontaltro {
public class rendicontaltroRow: MetaRow  {
	public rendicontaltroRow(DataRowBuilder rb) : base(rb) {} 

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
	public DateTime? data{ 
		get {if (this["data"]==DBNull.Value)return null; return  (DateTime?)this["data"];}
		set {if (value==null) this["data"]= DBNull.Value; else this["data"]= value;}
	}
	public object dataValue { 
		get{ return this["data"];}
		set {if (value==null|| value==DBNull.Value) this["data"]= DBNull.Value; else this["data"]= value;}
	}
	public DateTime? dataOriginal { 
		get {if (this["data",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["data",DataRowVersion.Original];}
	}
	///<summary>
	///Rendicontazione
	///</summary>
	public Int32? idrendicont{ 
		get {if (this["idrendicont"]==DBNull.Value)return null; return  (Int32?)this["idrendicont"];}
		set {if (value==null) this["idrendicont"]= DBNull.Value; else this["idrendicont"]= value;}
	}
	public object idrendicontValue { 
		get{ return this["idrendicont"];}
		set {if (value==null|| value==DBNull.Value) this["idrendicont"]= DBNull.Value; else this["idrendicont"]= value;}
	}
	public Int32? idrendicontOriginal { 
		get {if (this["idrendicont",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idrendicont",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
	///</summary>
	public Int32? idrendicontaltro{ 
		get {if (this["idrendicontaltro"]==DBNull.Value)return null; return  (Int32?)this["idrendicontaltro"];}
		set {if (value==null) this["idrendicontaltro"]= DBNull.Value; else this["idrendicontaltro"]= value;}
	}
	public object idrendicontaltroValue { 
		get{ return this["idrendicontaltro"];}
		set {if (value==null|| value==DBNull.Value) this["idrendicontaltro"]= DBNull.Value; else this["idrendicontaltro"]= value;}
	}
	public Int32? idrendicontaltroOriginal { 
		get {if (this["idrendicontaltro",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idrendicontaltro",DataRowVersion.Original];}
	}
	///<summary>
	///Tipologia
	///</summary>
	public Int32? idrendicontaltrokind{ 
		get {if (this["idrendicontaltrokind"]==DBNull.Value)return null; return  (Int32?)this["idrendicontaltrokind"];}
		set {if (value==null) this["idrendicontaltrokind"]= DBNull.Value; else this["idrendicontaltrokind"]= value;}
	}
	public object idrendicontaltrokindValue { 
		get{ return this["idrendicontaltrokind"];}
		set {if (value==null|| value==DBNull.Value) this["idrendicontaltrokind"]= DBNull.Value; else this["idrendicontaltrokind"]= value;}
	}
	public Int32? idrendicontaltrokindOriginal { 
		get {if (this["idrendicontaltrokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idrendicontaltrokind",DataRowVersion.Original];}
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
	public Decimal? ore{ 
		get {if (this["ore"]==DBNull.Value)return null; return  (Decimal?)this["ore"];}
		set {if (value==null) this["ore"]= DBNull.Value; else this["ore"]= value;}
	}
	public object oreValue { 
		get{ return this["ore"];}
		set {if (value==null|| value==DBNull.Value) this["ore"]= DBNull.Value; else this["ore"]= value;}
	}
	public Decimal? oreOriginal { 
		get {if (this["ore",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["ore",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Registro delle attivit√† oltre le lezioni della 2.4.31 Scheda di rendicontazione / registro elettronico
///</summary>
public class rendicontaltroTable : MetaTableBase<rendicontaltroRow> {
	public rendicontaltroTable() : base("rendicontaltro"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"data",createColumn("data",typeof(DateTime),false,false)},
			{"idrendicont",createColumn("idrendicont",typeof(int),false,false)},
			{"idrendicontaltro",createColumn("idrendicontaltro",typeof(int),false,false)},
			{"idrendicontaltrokind",createColumn("idrendicontaltrokind",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"ore",createColumn("ore",typeof(decimal),false,false)},
		};
	}
}
}
