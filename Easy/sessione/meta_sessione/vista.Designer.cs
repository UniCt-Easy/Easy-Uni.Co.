
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace meta_sessione {
public class sessioneRow: MetaRow  {
	public sessioneRow(DataRowBuilder rb) : base(rb) {} 

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
	///Tipologia di appello
	///</summary>
	public Int32? idappellokind{ 
		get {if (this["idappellokind"]==DBNull.Value)return null; return  (Int32?)this["idappellokind"];}
		set {if (value==null) this["idappellokind"]= DBNull.Value; else this["idappellokind"]= value;}
	}
	public object idappellokindValue { 
		get{ return this["idappellokind"];}
		set {if (value==null|| value==DBNull.Value) this["idappellokind"]= DBNull.Value; else this["idappellokind"]= value;}
	}
	public Int32? idappellokindOriginal { 
		get {if (this["idappellokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idappellokind",DataRowVersion.Original];}
	}
	public Int32? idsessione{ 
		get {if (this["idsessione"]==DBNull.Value)return null; return  (Int32?)this["idsessione"];}
		set {if (value==null) this["idsessione"]= DBNull.Value; else this["idsessione"]= value;}
	}
	public object idsessioneValue { 
		get{ return this["idsessione"];}
		set {if (value==null|| value==DBNull.Value) this["idsessione"]= DBNull.Value; else this["idsessione"]= value;}
	}
	public Int32? idsessioneOriginal { 
		get {if (this["idsessione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsessione",DataRowVersion.Original];}
	}
	///<summary>
	///Tipologia di sessione
	///</summary>
	public Int32? idsessionekind{ 
		get {if (this["idsessionekind"]==DBNull.Value)return null; return  (Int32?)this["idsessionekind"];}
		set {if (value==null) this["idsessionekind"]= DBNull.Value; else this["idsessionekind"]= value;}
	}
	public object idsessionekindValue { 
		get{ return this["idsessionekind"];}
		set {if (value==null|| value==DBNull.Value) this["idsessionekind"]= DBNull.Value; else this["idsessionekind"]= value;}
	}
	public Int32? idsessionekindOriginal { 
		get {if (this["idsessionekind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsessionekind",DataRowVersion.Original];}
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
	///Data di inizio
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
	///Data di fine
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
	#endregion

}
///<summary>
///2.2.6 Sessione di esami
///</summary>
public class sessioneTable : MetaTableBase<sessioneRow> {
	public sessioneTable() : base("sessione"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idappellokind",createColumn("idappellokind",typeof(int),true,false)},
			{"idsessione",createColumn("idsessione",typeof(int),false,false)},
			{"idsessionekind",createColumn("idsessionekind",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
		};
	}
}
}
