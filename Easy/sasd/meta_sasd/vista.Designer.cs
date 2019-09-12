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
namespace meta_sasd {
public class sasdRow: MetaRow  {
	public sasdRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String codice{ 
		get {if (this["codice"]==DBNull.Value)return null; return  (String)this["codice"];}
		set {if (value==null) this["codice"]= DBNull.Value; else this["codice"]= value;}
	}
	public object codiceValue { 
		get{ return this["codice"];}
		set {if (value==null|| value==DBNull.Value) this["codice"]= DBNull.Value; else this["codice"]= value;}
	}
	public String codiceOriginal { 
		get {if (this["codice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codice",DataRowVersion.Original];}
	}
	///<summary>
	///Codice legge precedente
	///</summary>
	public String codice_old{ 
		get {if (this["codice_old"]==DBNull.Value)return null; return  (String)this["codice_old"];}
		set {if (value==null) this["codice_old"]= DBNull.Value; else this["codice_old"]= value;}
	}
	public object codice_oldValue { 
		get{ return this["codice_old"];}
		set {if (value==null|| value==DBNull.Value) this["codice_old"]= DBNull.Value; else this["codice_old"]= value;}
	}
	public String codice_oldOriginal { 
		get {if (this["codice_old",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codice_old",DataRowVersion.Original];}
	}
	///<summary>
	///Area o ambito disciplinare
	///</summary>
	public Int32? idareadidattica{ 
		get {if (this["idareadidattica"]==DBNull.Value)return null; return  (Int32?)this["idareadidattica"];}
		set {if (value==null) this["idareadidattica"]= DBNull.Value; else this["idareadidattica"]= value;}
	}
	public object idareadidatticaValue { 
		get{ return this["idareadidattica"];}
		set {if (value==null|| value==DBNull.Value) this["idareadidattica"]= DBNull.Value; else this["idareadidattica"]= value;}
	}
	public Int32? idareadidatticaOriginal { 
		get {if (this["idareadidattica",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idareadidattica",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Istituto
	///</summary>
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
	///<summary>
	///Settore Artistico Scientifico Disciplinare
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
///VOCABOLARIO MIUR dei settori artistico-scientifico disciplinari
///</summary>
public class sasdTable : MetaTableBase<sasdRow> {
	public sasdTable() : base("sasd"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"codice",createColumn("codice",typeof(string),false,false)},
			{"codice_old",createColumn("codice_old",typeof(string),true,false)},
			{"idareadidattica",createColumn("idareadidattica",typeof(int),true,false)},
			{"idsasd",createColumn("idsasd",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),false,false)},
		};
	}
}
}
