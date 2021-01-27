
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
namespace meta_corsostudiolivello {
public class corsostudiolivelloRow: MetaRow  {
	public corsostudiolivelloRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Tipologia del corso di studi
	///</summary>
	public Int32? idcorsostudiokind{ 
		get {if (this["idcorsostudiokind"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiokind"];}
		set {if (value==null) this["idcorsostudiokind"]= DBNull.Value; else this["idcorsostudiokind"]= value;}
	}
	public object idcorsostudiokindValue { 
		get{ return this["idcorsostudiokind"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudiokind"]= DBNull.Value; else this["idcorsostudiokind"]= value;}
	}
	public Int32? idcorsostudiokindOriginal { 
		get {if (this["idcorsostudiokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiokind",DataRowVersion.Original];}
	}
	///<summary>
	///Identificativo
	///</summary>
	public Int32? idcorsostudiolivello{ 
		get {if (this["idcorsostudiolivello"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiolivello"];}
		set {if (value==null) this["idcorsostudiolivello"]= DBNull.Value; else this["idcorsostudiolivello"]= value;}
	}
	public object idcorsostudiolivelloValue { 
		get{ return this["idcorsostudiolivello"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudiolivello"]= DBNull.Value; else this["idcorsostudiolivello"]= value;}
	}
	public Int32? idcorsostudiolivelloOriginal { 
		get {if (this["idcorsostudiolivello",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiolivello",DataRowVersion.Original];}
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
	///Livello
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
	#endregion

}
///<summary>
///VOCABOLARIO dei livelli dei  2.4.2 Corso di studio 
///</summary>
public class corsostudiolivelloTable : MetaTableBase<corsostudiolivelloRow> {
	public corsostudiolivelloTable() : base("corsostudiolivello"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idcorsostudiokind",createColumn("idcorsostudiokind",typeof(int),true,false)},
			{"idcorsostudiolivello",createColumn("idcorsostudiolivello",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
