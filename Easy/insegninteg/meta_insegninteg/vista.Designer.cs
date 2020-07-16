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
namespace meta_insegninteg {
public class insegnintegRow: MetaRow  {
	public insegnintegRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String codice{ 
		get {if (this["codice"]==DBNull.Value)return null; return  (String)this["codice"];}
		set {if (value==null) this["codice"]= DBNull.Value; else this["codice"]= value;}
	}
	public object codiceValue { 
		get{ return this["codice"];}
		set {if (value==null|| value==DBNull.Value) this["codice"]= DBNull.Value; else this["codice"]= value;}
	}
	public String codiceOriginal { 
		get {if (this["codice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codice",DataRowVersion.Original];}
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
	public String denominazione{ 
		get {if (this["denominazione"]==DBNull.Value)return null; return  (String)this["denominazione"];}
		set {if (value==null) this["denominazione"]= DBNull.Value; else this["denominazione"]= value;}
	}
	public object denominazioneValue { 
		get{ return this["denominazione"];}
		set {if (value==null|| value==DBNull.Value) this["denominazione"]= DBNull.Value; else this["denominazione"]= value;}
	}
	public String denominazioneOriginal { 
		get {if (this["denominazione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["denominazione",DataRowVersion.Original];}
	}
	///<summary>
	///Insegnamento padre
	///</summary>
	public Int32? idinsegn{ 
		get {if (this["idinsegn"]==DBNull.Value)return null; return  (Int32?)this["idinsegn"];}
		set {if (value==null) this["idinsegn"]= DBNull.Value; else this["idinsegn"]= value;}
	}
	public object idinsegnValue { 
		get{ return this["idinsegn"];}
		set {if (value==null|| value==DBNull.Value) this["idinsegn"]= DBNull.Value; else this["idinsegn"]= value;}
	}
	public Int32? idinsegnOriginal { 
		get {if (this["idinsegn",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinsegn",DataRowVersion.Original];}
	}
	public Int32? idinsegninteg{ 
		get {if (this["idinsegninteg"]==DBNull.Value)return null; return  (Int32?)this["idinsegninteg"];}
		set {if (value==null) this["idinsegninteg"]= DBNull.Value; else this["idinsegninteg"]= value;}
	}
	public object idinsegnintegValue { 
		get{ return this["idinsegninteg"];}
		set {if (value==null|| value==DBNull.Value) this["idinsegninteg"]= DBNull.Value; else this["idinsegninteg"]= value;}
	}
	public Int32? idinsegnintegOriginal { 
		get {if (this["idinsegninteg",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinsegninteg",DataRowVersion.Original];}
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
	#endregion

}
public class insegnintegTable : MetaTableBase<insegnintegRow> {
	public insegnintegTable() : base("insegninteg"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"codice",createColumn("codice",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"denominazione",createColumn("denominazione",typeof(string),true,false)},
			{"idinsegn",createColumn("idinsegn",typeof(int),false,false)},
			{"idinsegninteg",createColumn("idinsegninteg",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
		};
	}
}
}
