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
namespace meta_publicazkeyword {
public class publicazkeywordRow: MetaRow  {
	public publicazkeywordRow(DataRowBuilder rb) : base(rb) {} 

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
	public Int32? idpublicaz{ 
		get {if (this["idpublicaz"]==DBNull.Value)return null; return  (Int32?)this["idpublicaz"];}
		set {if (value==null) this["idpublicaz"]= DBNull.Value; else this["idpublicaz"]= value;}
	}
	public object idpublicazValue { 
		get{ return this["idpublicaz"];}
		set {if (value==null|| value==DBNull.Value) this["idpublicaz"]= DBNull.Value; else this["idpublicaz"]= value;}
	}
	public Int32? idpublicazOriginal { 
		get {if (this["idpublicaz",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpublicaz",DataRowVersion.Original];}
	}
	public Int32? idpublicazkeyword{ 
		get {if (this["idpublicazkeyword"]==DBNull.Value)return null; return  (Int32?)this["idpublicazkeyword"];}
		set {if (value==null) this["idpublicazkeyword"]= DBNull.Value; else this["idpublicazkeyword"]= value;}
	}
	public object idpublicazkeywordValue { 
		get{ return this["idpublicazkeyword"];}
		set {if (value==null|| value==DBNull.Value) this["idpublicazkeyword"]= DBNull.Value; else this["idpublicazkeyword"]= value;}
	}
	public Int32? idpublicazkeywordOriginal { 
		get {if (this["idpublicazkeyword",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpublicazkeyword",DataRowVersion.Original];}
	}
	public String keyword{ 
		get {if (this["keyword"]==DBNull.Value)return null; return  (String)this["keyword"];}
		set {if (value==null) this["keyword"]= DBNull.Value; else this["keyword"]= value;}
	}
	public object keywordValue { 
		get{ return this["keyword"];}
		set {if (value==null|| value==DBNull.Value) this["keyword"]= DBNull.Value; else this["keyword"]= value;}
	}
	public String keywordOriginal { 
		get {if (this["keyword",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["keyword",DataRowVersion.Original];}
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
///Keyword della 2.4.27 pubblicazione
///</summary>
public class publicazkeywordTable : MetaTableBase<publicazkeywordRow> {
	public publicazkeywordTable() : base("publicazkeyword"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idpublicaz",createColumn("idpublicaz",typeof(int),false,false)},
			{"idpublicazkeyword",createColumn("idpublicazkeyword",typeof(int),false,false)},
			{"keyword",createColumn("keyword",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
		};
	}
}
}
