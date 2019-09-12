/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace meta_sasdistitutokind {
public class sasdistitutokindRow: MetaRow  {
	public sasdistitutokindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32? idistitutokind{ 
		get {if (this["idistitutokind"]==DBNull.Value)return null; return  (Int32?)this["idistitutokind"];}
		set {if (value==null) this["idistitutokind"]= DBNull.Value; else this["idistitutokind"]= value;}
	}
	public object idistitutokindValue { 
		get{ return this["idistitutokind"];}
		set {if (value==null|| value==DBNull.Value) this["idistitutokind"]= DBNull.Value; else this["idistitutokind"]= value;}
	}
	public Int32? idistitutokindOriginal { 
		get {if (this["idistitutokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idistitutokind",DataRowVersion.Original];}
	}
	public Int32? idsasd{ 
		get {if (this["idsasd"]==DBNull.Value)return null; return  (Int32?)this["idsasd"];}
		set {if (value==null) this["idsasd"]= DBNull.Value; else this["idsasd"]= value;}
	}
	public object idsasdValue { 
		get{ return this["idsasd"];}
		set {if (value==null|| value==DBNull.Value) this["idsasd"]= DBNull.Value; else this["idsasd"]= value;}
	}
	public Int32? idsasdOriginal { 
		get {if (this["idsasd",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsasd",DataRowVersion.Original];}
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
public class sasdistitutokindTable : MetaTableBase<sasdistitutokindRow> {
	public sasdistitutokindTable() : base("sasdistitutokind"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idistitutokind",createColumn("idistitutokind",typeof(int),false,false)},
			{"idsasd",createColumn("idsasd",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
		};
	}
}
}
