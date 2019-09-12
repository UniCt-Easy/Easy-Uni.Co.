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
namespace meta_apppagesbutton {
public class apppagesbuttonRow: MetaRow  {
	public apppagesbuttonRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Codice
	///</summary>
	public String code{ 
		get {if (this["code"]==DBNull.Value)return null; return  (String)this["code"];}
		set {if (value==null) this["code"]= DBNull.Value; else this["code"]= value;}
	}
	public object codeValue { 
		get{ return this["code"];}
		set {if (value==null|| value==DBNull.Value) this["code"]= DBNull.Value; else this["code"]= value;}
	}
	public String codeOriginal { 
		get {if (this["code",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["code",DataRowVersion.Original];}
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
	public Int32? idapppagesbutton{ 
		get {if (this["idapppagesbutton"]==DBNull.Value)return null; return  (Int32?)this["idapppagesbutton"];}
		set {if (value==null) this["idapppagesbutton"]= DBNull.Value; else this["idapppagesbutton"]= value;}
	}
	public object idapppagesbuttonValue { 
		get{ return this["idapppagesbutton"];}
		set {if (value==null|| value==DBNull.Value) this["idapppagesbutton"]= DBNull.Value; else this["idapppagesbutton"]= value;}
	}
	public Int32? idapppagesbuttonOriginal { 
		get {if (this["idapppagesbutton",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapppagesbutton",DataRowVersion.Original];}
	}
	///<summary>
	///Tab
	///</summary>
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
	public String javascript{ 
		get {if (this["javascript"]==DBNull.Value)return null; return  (String)this["javascript"];}
		set {if (value==null) this["javascript"]= DBNull.Value; else this["javascript"]= value;}
	}
	public object javascriptValue { 
		get{ return this["javascript"];}
		set {if (value==null|| value==DBNull.Value) this["javascript"]= DBNull.Value; else this["javascript"]= value;}
	}
	public String javascriptOriginal { 
		get {if (this["javascript",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["javascript",DataRowVersion.Original];}
	}
	///<summary>
	///Nome
	///</summary>
	public String name{ 
		get {if (this["name"]==DBNull.Value)return null; return  (String)this["name"];}
		set {if (value==null) this["name"]= DBNull.Value; else this["name"]= value;}
	}
	public object nameValue { 
		get{ return this["name"];}
		set {if (value==null|| value==DBNull.Value) this["name"]= DBNull.Value; else this["name"]= value;}
	}
	public String nameOriginal { 
		get {if (this["name",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["name",DataRowVersion.Original];}
	}
	///<summary>
	///Parametri
	///</summary>
	public String parameter{ 
		get {if (this["parameter"]==DBNull.Value)return null; return  (String)this["parameter"];}
		set {if (value==null) this["parameter"]= DBNull.Value; else this["parameter"]= value;}
	}
	public object parameterValue { 
		get{ return this["parameter"];}
		set {if (value==null|| value==DBNull.Value) this["parameter"]= DBNull.Value; else this["parameter"]= value;}
	}
	public String parameterOriginal { 
		get {if (this["parameter",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["parameter",DataRowVersion.Original];}
	}
	///<summary>
	///Griglie da aggironare
	///</summary>
	public String refresh{ 
		get {if (this["refresh"]==DBNull.Value)return null; return  (String)this["refresh"];}
		set {if (value==null) this["refresh"]= DBNull.Value; else this["refresh"]= value;}
	}
	public object refreshValue { 
		get{ return this["refresh"];}
		set {if (value==null|| value==DBNull.Value) this["refresh"]= DBNull.Value; else this["refresh"]= value;}
	}
	public String refreshOriginal { 
		get {if (this["refresh",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["refresh",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo
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
public class apppagesbuttonTable : MetaTableBase<apppagesbuttonRow> {
	public apppagesbuttonTable() : base("apppagesbutton"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"code",createColumn("code",typeof(string),true,false)},
			{"icon",createColumn("icon",typeof(string),true,false)},
			{"idapppages",createColumn("idapppages",typeof(int),true,false)},
			{"idapppagesbutton",createColumn("idapppagesbutton",typeof(int),false,false)},
			{"idapptab",createColumn("idapptab",typeof(int),true,false)},
			{"javascript",createColumn("javascript",typeof(string),true,false)},
			{"name",createColumn("name",typeof(string),true,false)},
			{"parameter",createColumn("parameter",typeof(string),true,false)},
			{"refresh",createColumn("refresh",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
