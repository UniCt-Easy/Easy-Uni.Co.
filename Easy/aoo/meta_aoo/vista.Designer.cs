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
namespace meta_aoo {
public class aooRow: MetaRow  {
	public aooRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Codice IPA
	///</summary>
	public String codiceaooipa{ 
		get {if (this["codiceaooipa"]==DBNull.Value)return null; return  (String)this["codiceaooipa"];}
		set {if (value==null) this["codiceaooipa"]= DBNull.Value; else this["codiceaooipa"]= value;}
	}
	public object codiceaooipaValue { 
		get{ return this["codiceaooipa"];}
		set {if (value==null|| value==DBNull.Value) this["codiceaooipa"]= DBNull.Value; else this["codiceaooipa"]= value;}
	}
	public String codiceaooipaOriginal { 
		get {if (this["codiceaooipa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceaooipa",DataRowVersion.Original];}
	}
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
	public Int32? idaoo{ 
		get {if (this["idaoo"]==DBNull.Value)return null; return  (Int32?)this["idaoo"];}
		set {if (value==null) this["idaoo"]= DBNull.Value; else this["idaoo"]= value;}
	}
	public object idaooValue { 
		get{ return this["idaoo"];}
		set {if (value==null|| value==DBNull.Value) this["idaoo"]= DBNull.Value; else this["idaoo"]= value;}
	}
	public Int32? idaooOriginal { 
		get {if (this["idaoo",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idaoo",DataRowVersion.Original];}
	}
	///<summary>
	///Sede
	///</summary>
	public Int32? idlocation_sede{ 
		get {if (this["idlocation_sede"]==DBNull.Value)return null; return  (Int32?)this["idlocation_sede"];}
		set {if (value==null) this["idlocation_sede"]= DBNull.Value; else this["idlocation_sede"]= value;}
	}
	public object idlocation_sedeValue { 
		get{ return this["idlocation_sede"];}
		set {if (value==null|| value==DBNull.Value) this["idlocation_sede"]= DBNull.Value; else this["idlocation_sede"]= value;}
	}
	public Int32? idlocation_sedeOriginal { 
		get {if (this["idlocation_sede",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlocation_sede",DataRowVersion.Original];}
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
///<summary>
///2.4.38 Area organizzativa omogenea (AOO)
///</summary>
public class aooTable : MetaTableBase<aooRow> {
	public aooTable() : base("aoo"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"codiceaooipa",createColumn("codiceaooipa",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idaoo",createColumn("idaoo",typeof(int),false,false)},
			{"idlocation_sede",createColumn("idlocation_sede",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),false,false)},
		};
	}
}
}
