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
namespace meta_diderog {
public class diderogRow: MetaRow  {
	public diderogRow(DataRowBuilder rb) : base(rb) {} 

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
	public Int32? idcorsostudio{ 
		get {if (this["idcorsostudio"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudio"];}
		set {if (value==null) this["idcorsostudio"]= DBNull.Value; else this["idcorsostudio"]= value;}
	}
	public object idcorsostudioValue { 
		get{ return this["idcorsostudio"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudio"]= DBNull.Value; else this["idcorsostudio"]= value;}
	}
	public Int32? idcorsostudioOriginal { 
		get {if (this["idcorsostudio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudio",DataRowVersion.Original];}
	}
	public String inesaurimento{ 
		get {if (this["inesaurimento"]==DBNull.Value)return null; return  (String)this["inesaurimento"];}
		set {if (value==null) this["inesaurimento"]= DBNull.Value; else this["inesaurimento"]= value;}
	}
	public object inesaurimentoValue { 
		get{ return this["inesaurimento"];}
		set {if (value==null|| value==DBNull.Value) this["inesaurimento"]= DBNull.Value; else this["inesaurimento"]= value;}
	}
	public String inesaurimentoOriginal { 
		get {if (this["inesaurimento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["inesaurimento",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.5.22 Didattica Erogata
///</summary>
public class diderogTable : MetaTableBase<diderogRow> {
	public diderogTable() : base("diderog"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"aa",createColumn("aa",typeof(string),false,false)},
			{"idcorsostudio",createColumn("idcorsostudio",typeof(int),false,false)},
			{"inesaurimento",createColumn("inesaurimento",typeof(string),true,false)},
		};
	}
}
}
