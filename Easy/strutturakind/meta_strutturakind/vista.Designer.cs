
/*
Easy
Copyright (C) 2021 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace meta_strutturakind {
public class strutturakindRow: MetaRow  {
	public strutturakindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String active{ 
		get {if (this["active"]==DBNull.Value)return null; return  (String)this["active"];}
		set {if (value==null) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {if (value==null|| value==DBNull.Value) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public String activeOriginal { 
		get {if (this["active",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["active",DataRowVersion.Original];}
	}
	public String description{ 
		get {if (this["description"]==DBNull.Value)return null; return  (String)this["description"];}
		set {if (value==null) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {if (value==null|| value==DBNull.Value) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {if (this["description",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["description",DataRowVersion.Original];}
	}
	public Int32? idstrutturakind{ 
		get {if (this["idstrutturakind"]==DBNull.Value)return null; return  (Int32?)this["idstrutturakind"];}
		set {if (value==null) this["idstrutturakind"]= DBNull.Value; else this["idstrutturakind"]= value;}
	}
	public object idstrutturakindValue { 
		get{ return this["idstrutturakind"];}
		set {if (value==null|| value==DBNull.Value) this["idstrutturakind"]= DBNull.Value; else this["idstrutturakind"]= value;}
	}
	public Int32? idstrutturakindOriginal { 
		get {if (this["idstrutturakind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstrutturakind",DataRowVersion.Original];}
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
	public Int32? sortCode{ 
		get {if (this["sortCode"]==DBNull.Value)return null; return  (Int32?)this["sortCode"];}
		set {if (value==null) this["sortCode"]= DBNull.Value; else this["sortCode"]= value;}
	}
	public object sortCodeValue { 
		get{ return this["sortCode"];}
		set {if (value==null|| value==DBNull.Value) this["sortCode"]= DBNull.Value; else this["sortCode"]= value;}
	}
	public Int32? sortCodeOriginal { 
		get {if (this["sortCode",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["sortCode",DataRowVersion.Original];}
	}
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
///VOCABOLARIO delle tipologie di una 2.4.11 Struttura / Unit√† organizzativa
///</summary>
public class strutturakindTable : MetaTableBase<strutturakindRow> {
	public strutturakindTable() : base("strutturakind"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"idstrutturakind",createColumn("idstrutturakind",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"sortCode",createColumn("sortCode",typeof(int),false,false)},
			{"title",createColumn("title",typeof(string),false,false)},
		};
	}
}
}
