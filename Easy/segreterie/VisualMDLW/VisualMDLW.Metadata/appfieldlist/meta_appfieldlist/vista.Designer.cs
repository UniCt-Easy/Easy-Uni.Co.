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
namespace meta_appfieldlist {
public class appfieldlistRow: MetaRow  {
	public appfieldlistRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Nome colonna
	///</summary>
	public String columnname{ 
		get {if (this["columnname"]==DBNull.Value)return null; return  (String)this["columnname"];}
		set {if (value==null) this["columnname"]= DBNull.Value; else this["columnname"]= value;}
	}
	public object columnnameValue { 
		get{ return this["columnname"];}
		set {if (value==null|| value==DBNull.Value) this["columnname"]= DBNull.Value; else this["columnname"]= value;}
	}
	public String columnnameOriginal { 
		get {if (this["columnname",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["columnname",DataRowVersion.Original];}
	}
	///<summary>
	///filtro
	///</summary>
	public String filter{ 
		get {if (this["filter"]==DBNull.Value)return null; return  (String)this["filter"];}
		set {if (value==null) this["filter"]= DBNull.Value; else this["filter"]= value;}
	}
	public object filterValue { 
		get{ return this["filter"];}
		set {if (value==null|| value==DBNull.Value) this["filter"]= DBNull.Value; else this["filter"]= value;}
	}
	public String filterOriginal { 
		get {if (this["filter",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["filter",DataRowVersion.Original];}
	}
	///<summary>
	///Ordinamento (asc,desc)
	///</summary>
	public String getsorting{ 
		get {if (this["getsorting"]==DBNull.Value)return null; return  (String)this["getsorting"];}
		set {if (value==null) this["getsorting"]= DBNull.Value; else this["getsorting"]= value;}
	}
	public object getsortingValue { 
		get{ return this["getsorting"];}
		set {if (value==null|| value==DBNull.Value) this["getsorting"]= DBNull.Value; else this["getsorting"]= value;}
	}
	public String getsortingOriginal { 
		get {if (this["getsorting",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["getsorting",DataRowVersion.Original];}
	}
	public Int32? idappfieldlist{ 
		get {if (this["idappfieldlist"]==DBNull.Value)return null; return  (Int32?)this["idappfieldlist"];}
		set {if (value==null) this["idappfieldlist"]= DBNull.Value; else this["idappfieldlist"]= value;}
	}
	public object idappfieldlistValue { 
		get{ return this["idappfieldlist"];}
		set {if (value==null|| value==DBNull.Value) this["idappfieldlist"]= DBNull.Value; else this["idappfieldlist"]= value;}
	}
	public Int32? idappfieldlistOriginal { 
		get {if (this["idappfieldlist",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idappfieldlist",DataRowVersion.Original];}
	}
	///<summary>
	///Interfaccia
	///</summary>
	public Int32? idapppages{ 
		get {if (this["idapppages"]==DBNull.Value)return null; return  (Int32?)this["idapppages"];}
		set {if (value==null) this["idapppages"]= DBNull.Value; else this["idapppages"]= value;}
	}
	public object idapppagesValue { 
		get{ return this["idapppages"];}
		set {if (value==null|| value==DBNull.Value) this["idapppages"]= DBNull.Value; else this["idapppages"]= value;}
	}
	public Int32? idapppagesOriginal { 
		get {if (this["idapppages",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapppages",DataRowVersion.Original];}
	}
	///<summary>
	///Posizione
	///</summary>
	public Int32? position{ 
		get {if (this["position"]==DBNull.Value)return null; return  (Int32?)this["position"];}
		set {if (value==null) this["position"]= DBNull.Value; else this["position"]= value;}
	}
	public object positionValue { 
		get{ return this["position"];}
		set {if (value==null|| value==DBNull.Value) this["position"]= DBNull.Value; else this["position"]= value;}
	}
	public Int32? positionOriginal { 
		get {if (this["position",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["position",DataRowVersion.Original];}
	}
	///<summary>
	///Campo testuale per l'oggetto
	///</summary>
	public Int32? textfield{ 
		get {if (this["textfield"]==DBNull.Value)return null; return  (Int32?)this["textfield"];}
		set {if (value==null) this["textfield"]= DBNull.Value; else this["textfield"]= value;}
	}
	public object textfieldValue { 
		get{ return this["textfield"];}
		set {if (value==null|| value==DBNull.Value) this["textfield"]= DBNull.Value; else this["textfield"]= value;}
	}
	public Int32? textfieldOriginal { 
		get {if (this["textfield",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["textfield",DataRowVersion.Original];}
	}
	public String visible{ 
		get {if (this["visible"]==DBNull.Value)return null; return  (String)this["visible"];}
		set {if (value==null) this["visible"]= DBNull.Value; else this["visible"]= value;}
	}
	public object visibleValue { 
		get{ return this["visible"];}
		set {if (value==null|| value==DBNull.Value) this["visible"]= DBNull.Value; else this["visible"]= value;}
	}
	public String visibleOriginal { 
		get {if (this["visible",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["visible",DataRowVersion.Original];}
	}
	#endregion

}
public class appfieldlistTable : MetaTableBase<appfieldlistRow> {
	public appfieldlistTable() : base("appfieldlist"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"columnname",createColumn("columnname",typeof(string),true,false)},
			{"filter",createColumn("filter",typeof(string),true,false)},
			{"getsorting",createColumn("getsorting",typeof(string),true,false)},
			{"idappfieldlist",createColumn("idappfieldlist",typeof(int),false,false)},
			{"idapppages",createColumn("idapppages",typeof(int),true,false)},
			{"position",createColumn("position",typeof(int),true,false)},
			{"textfield",createColumn("textfield",typeof(int),true,false)},
			{"visible",createColumn("visible",typeof(string),true,false)},
		};
	}
}
}
