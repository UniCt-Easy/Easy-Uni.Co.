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
namespace meta_instmkwmetodicheregistry_instmuser {
public class instmkwmetodicheregistry_instmuserRow: MetaRow  {
	public instmkwmetodicheregistry_instmuserRow(DataRowBuilder rb) : base(rb) {} 

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
	///Keyword
	///</summary>
	public Int32? idinstmkwmetodiche{ 
		get {if (this["idinstmkwmetodiche"]==DBNull.Value)return null; return  (Int32?)this["idinstmkwmetodiche"];}
		set {if (value==null) this["idinstmkwmetodiche"]= DBNull.Value; else this["idinstmkwmetodiche"]= value;}
	}
	public object idinstmkwmetodicheValue { 
		get{ return this["idinstmkwmetodiche"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmkwmetodiche"]= DBNull.Value; else this["idinstmkwmetodiche"]= value;}
	}
	public Int32? idinstmkwmetodicheOriginal { 
		get {if (this["idinstmkwmetodiche",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmkwmetodiche",DataRowVersion.Original];}
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
	#endregion

}
public class instmkwmetodicheregistry_instmuserTable : MetaTableBase<instmkwmetodicheregistry_instmuserRow> {
	public instmkwmetodicheregistry_instmuserTable() : base("instmkwmetodicheregistry_instmuser"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idinstmkwmetodiche",createColumn("idinstmkwmetodiche",typeof(int),false,false)},
			{"idreg_instmuser",createColumn("idreg_instmuser",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
		};
	}
}
}
