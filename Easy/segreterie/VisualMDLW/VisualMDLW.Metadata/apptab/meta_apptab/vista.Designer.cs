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
namespace meta_apptab {
public class apptabRow: MetaRow  {
	public apptabRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Intestazione
	///</summary>
	public String header{ 
		get {if (this["header"]==DBNull.Value)return null; return  (String)this["header"];}
		set {if (value==null) this["header"]= DBNull.Value; else this["header"]= value;}
	}
	public object headerValue { 
		get{ return this["header"];}
		set {if (value==null|| value==DBNull.Value) this["header"]= DBNull.Value; else this["header"]= value;}
	}
	public String headerOriginal { 
		get {if (this["header",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["header",DataRowVersion.Original];}
	}
	///<summary>
	///Icona
	///</summary>
	public String icon{ 
		get {if (this["icon"]==DBNull.Value)return null; return  (String)this["icon"];}
		set {if (value==null) this["icon"]= DBNull.Value; else this["icon"]= value;}
	}
	public object iconValue { 
		get{ return this["icon"];}
		set {if (value==null|| value==DBNull.Value) this["icon"]= DBNull.Value; else this["icon"]= value;}
	}
	public String iconOriginal { 
		get {if (this["icon",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["icon",DataRowVersion.Original];}
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
	public Int32? idapptab{ 
		get {if (this["idapptab"]==DBNull.Value)return null; return  (Int32?)this["idapptab"];}
		set {if (value==null) this["idapptab"]= DBNull.Value; else this["idapptab"]= value;}
	}
	public object idapptabValue { 
		get{ return this["idapptab"];}
		set {if (value==null|| value==DBNull.Value) this["idapptab"]= DBNull.Value; else this["idapptab"]= value;}
	}
	public Int32? idapptabOriginal { 
		get {if (this["idapptab",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapptab",DataRowVersion.Original];}
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
	#endregion

}
public class apptabTable : MetaTableBase<apptabRow> {
	public apptabTable() : base("apptab"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"header",createColumn("header",typeof(string),true,false)},
			{"icon",createColumn("icon",typeof(string),true,false)},
			{"idapppages",createColumn("idapppages",typeof(int),false,false)},
			{"idapptab",createColumn("idapptab",typeof(int),false,false)},
			{"position",createColumn("position",typeof(int),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
