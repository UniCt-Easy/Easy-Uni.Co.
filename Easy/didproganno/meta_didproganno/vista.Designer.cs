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
namespace meta_didproganno {
public class didprogannoRow: MetaRow  {
	public didprogannoRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String aa{ 
		get {if (this["aa"]==DBNull.Value)return null; return  (String)this["aa"];}
		set {if (value==null) this["aa"]= DBNull.Value; else this["aa"]= value;}
	}
	public object aaValue { 
		get{ return this["aa"];}
		set {if (value==null|| value==DBNull.Value) this["aa"]= DBNull.Value; else this["aa"]= value;}
	}
	public String aaOriginal { 
		get {if (this["aa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["aa",DataRowVersion.Original];}
	}
	public Int32? anno{ 
		get {if (this["anno"]==DBNull.Value)return null; return  (Int32?)this["anno"];}
		set {if (value==null) this["anno"]= DBNull.Value; else this["anno"]= value;}
	}
	public object annoValue { 
		get{ return this["anno"];}
		set {if (value==null|| value==DBNull.Value) this["anno"]= DBNull.Value; else this["anno"]= value;}
	}
	public Int32? annoOriginal { 
		get {if (this["anno",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["anno",DataRowVersion.Original];}
	}
	public Decimal? cf{ 
		get {if (this["cf"]==DBNull.Value)return null; return  (Decimal?)this["cf"];}
		set {if (value==null) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public object cfValue { 
		get{ return this["cf"];}
		set {if (value==null|| value==DBNull.Value) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public Decimal? cfOriginal { 
		get {if (this["cf",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["cf",DataRowVersion.Original];}
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
	public Int32? iddidprog{ 
		get {if (this["iddidprog"]==DBNull.Value)return null; return  (Int32?)this["iddidprog"];}
		set {if (value==null) this["iddidprog"]= DBNull.Value; else this["iddidprog"]= value;}
	}
	public object iddidprogValue { 
		get{ return this["iddidprog"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprog"]= DBNull.Value; else this["iddidprog"]= value;}
	}
	public Int32? iddidprogOriginal { 
		get {if (this["iddidprog",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprog",DataRowVersion.Original];}
	}
	public Int32? iddidproganno{ 
		get {if (this["iddidproganno"]==DBNull.Value)return null; return  (Int32?)this["iddidproganno"];}
		set {if (value==null) this["iddidproganno"]= DBNull.Value; else this["iddidproganno"]= value;}
	}
	public object iddidprogannoValue { 
		get{ return this["iddidproganno"];}
		set {if (value==null|| value==DBNull.Value) this["iddidproganno"]= DBNull.Value; else this["iddidproganno"]= value;}
	}
	public Int32? iddidprogannoOriginal { 
		get {if (this["iddidproganno",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidproganno",DataRowVersion.Original];}
	}
	public Int32? iddidprogcurr{ 
		get {if (this["iddidprogcurr"]==DBNull.Value)return null; return  (Int32?)this["iddidprogcurr"];}
		set {if (value==null) this["iddidprogcurr"]= DBNull.Value; else this["iddidprogcurr"]= value;}
	}
	public object iddidprogcurrValue { 
		get{ return this["iddidprogcurr"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprogcurr"]= DBNull.Value; else this["iddidprogcurr"]= value;}
	}
	public Int32? iddidprogcurrOriginal { 
		get {if (this["iddidprogcurr",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprogcurr",DataRowVersion.Original];}
	}
	public Int32? iddidprogori{ 
		get {if (this["iddidprogori"]==DBNull.Value)return null; return  (Int32?)this["iddidprogori"];}
		set {if (value==null) this["iddidprogori"]= DBNull.Value; else this["iddidprogori"]= value;}
	}
	public object iddidprogoriValue { 
		get{ return this["iddidprogori"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprogori"]= DBNull.Value; else this["iddidprogori"]= value;}
	}
	public Int32? iddidprogoriOriginal { 
		get {if (this["iddidprogori",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprogori",DataRowVersion.Original];}
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
///<summary>
///2.4.14 anno di corso
///</summary>
public class didprogannoTable : MetaTableBase<didprogannoRow> {
	public didprogannoTable() : base("didproganno"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"aa",createColumn("aa",typeof(string),true,false)},
			{"anno",createColumn("anno",typeof(int),true,false)},
			{"cf",createColumn("cf",typeof(decimal),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"iddidprog",createColumn("iddidprog",typeof(int),false,false)},
			{"iddidproganno",createColumn("iddidproganno",typeof(int),false,false)},
			{"iddidprogcurr",createColumn("iddidprogcurr",typeof(int),false,false)},
			{"iddidprogori",createColumn("iddidprogori",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
		};
	}
}
}
