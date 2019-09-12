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
namespace meta_geo_continent {
public class geo_continentRow: MetaRow  {
	public geo_continentRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32? idcontinent{ 
		get {if (this["idcontinent"]==DBNull.Value)return null; return  (Int32?)this["idcontinent"];}
		set {if (value==null) this["idcontinent"]= DBNull.Value; else this["idcontinent"]= value;}
	}
	public object idcontinentValue { 
		get{ return this["idcontinent"];}
		set {if (value==null|| value==DBNull.Value) this["idcontinent"]= DBNull.Value; else this["idcontinent"]= value;}
	}
	public Int32? idcontinentOriginal { 
		get {if (this["idcontinent",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcontinent",DataRowVersion.Original];}
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
	///<summary>
	///Denominazione (EN)
	///</summary>
	public String title_EN{ 
		get {if (this["title_EN"]==DBNull.Value)return null; return  (String)this["title_EN"];}
		set {if (value==null) this["title_EN"]= DBNull.Value; else this["title_EN"]= value;}
	}
	public object title_ENValue { 
		get{ return this["title_EN"];}
		set {if (value==null|| value==DBNull.Value) this["title_EN"]= DBNull.Value; else this["title_EN"]= value;}
	}
	public String title_ENOriginal { 
		get {if (this["title_EN",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title_EN",DataRowVersion.Original];}
	}
	#endregion

}
public class geo_continentTable : MetaTableBase<geo_continentRow> {
	public geo_continentTable() : base("geo_continent"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idcontinent",createColumn("idcontinent",typeof(int),false,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"title_EN",createColumn("title_EN",typeof(string),true,false)},
		};
	}
}
}
