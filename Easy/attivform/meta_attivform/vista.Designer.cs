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
namespace meta_attivform {
public class attivformRow: MetaRow  {
	public attivformRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	public Int32? idattivform{ 
		get {if (this["idattivform"]==DBNull.Value)return null; return  (Int32?)this["idattivform"];}
		set {if (value==null) this["idattivform"]= DBNull.Value; else this["idattivform"]= value;}
	}
	public object idattivformValue { 
		get{ return this["idattivform"];}
		set {if (value==null|| value==DBNull.Value) this["idattivform"]= DBNull.Value; else this["idattivform"]= value;}
	}
	public Int32? idattivformOriginal { 
		get {if (this["idattivform",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idattivform",DataRowVersion.Original];}
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
	public Int32? iddidproggrupp{ 
		get {if (this["iddidproggrupp"]==DBNull.Value)return null; return  (Int32?)this["iddidproggrupp"];}
		set {if (value==null) this["iddidproggrupp"]= DBNull.Value; else this["iddidproggrupp"]= value;}
	}
	public object iddidproggruppValue { 
		get{ return this["iddidproggrupp"];}
		set {if (value==null|| value==DBNull.Value) this["iddidproggrupp"]= DBNull.Value; else this["iddidproggrupp"]= value;}
	}
	public Int32? iddidproggruppOriginal { 
		get {if (this["iddidproggrupp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidproggrupp",DataRowVersion.Original];}
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
	public Int32? iddidprogporzanno{ 
		get {if (this["iddidprogporzanno"]==DBNull.Value)return null; return  (Int32?)this["iddidprogporzanno"];}
		set {if (value==null) this["iddidprogporzanno"]= DBNull.Value; else this["iddidprogporzanno"]= value;}
	}
	public object iddidprogporzannoValue { 
		get{ return this["iddidprogporzanno"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprogporzanno"]= DBNull.Value; else this["iddidprogporzanno"]= value;}
	}
	public Int32? iddidprogporzannoOriginal { 
		get {if (this["iddidprogporzanno",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprogporzanno",DataRowVersion.Original];}
	}
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
	public String obbform{ 
		get {if (this["obbform"]==DBNull.Value)return null; return  (String)this["obbform"];}
		set {if (value==null) this["obbform"]= DBNull.Value; else this["obbform"]= value;}
	}
	public object obbformValue { 
		get{ return this["obbform"];}
		set {if (value==null|| value==DBNull.Value) this["obbform"]= DBNull.Value; else this["obbform"]= value;}
	}
	public String obbformOriginal { 
		get {if (this["obbform",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["obbform",DataRowVersion.Original];}
	}
	public String obbform_en{ 
		get {if (this["obbform_en"]==DBNull.Value)return null; return  (String)this["obbform_en"];}
		set {if (value==null) this["obbform_en"]= DBNull.Value; else this["obbform_en"]= value;}
	}
	public object obbform_enValue { 
		get{ return this["obbform_en"];}
		set {if (value==null|| value==DBNull.Value) this["obbform_en"]= DBNull.Value; else this["obbform_en"]= value;}
	}
	public String obbform_enOriginal { 
		get {if (this["obbform_en",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["obbform_en",DataRowVersion.Original];}
	}
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
	public String tipovalutaz{ 
		get {if (this["tipovalutaz"]==DBNull.Value)return null; return  (String)this["tipovalutaz"];}
		set {if (value==null) this["tipovalutaz"]= DBNull.Value; else this["tipovalutaz"]= value;}
	}
	public object tipovalutazValue { 
		get{ return this["tipovalutaz"];}
		set {if (value==null|| value==DBNull.Value) this["tipovalutaz"]= DBNull.Value; else this["tipovalutaz"]= value;}
	}
	public String tipovalutazOriginal { 
		get {if (this["tipovalutaz",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tipovalutaz",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.28 attività formativa: insegnamenti/moduli attivati in quella porzione d’anno
///</summary>
public class attivformTable : MetaTableBase<attivformRow> {
	public attivformTable() : base("attivform"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idattivform",createColumn("idattivform",typeof(int),false,false)},
			{"iddidprog",createColumn("iddidprog",typeof(int),false,false)},
			{"iddidproganno",createColumn("iddidproganno",typeof(int),false,false)},
			{"iddidprogcurr",createColumn("iddidprogcurr",typeof(int),false,false)},
			{"iddidproggrupp",createColumn("iddidproggrupp",typeof(int),true,false)},
			{"iddidprogori",createColumn("iddidprogori",typeof(int),false,false)},
			{"iddidprogporzanno",createColumn("iddidprogporzanno",typeof(int),false,false)},
			{"idinsegn",createColumn("idinsegn",typeof(int),false,false)},
			{"idinsegninteg",createColumn("idinsegninteg",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"obbform",createColumn("obbform",typeof(string),true,false)},
			{"obbform_en",createColumn("obbform_en",typeof(string),true,false)},
			{"sortcode",createColumn("sortcode",typeof(int),true,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"tipovalutaz",createColumn("tipovalutaz",typeof(string),true,false)},
		};
	}
}
}
