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
namespace meta_attach {
public class attachRow: MetaRow  {
	public attachRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Allegato su SQL
	///</summary>
	public String attachment{ 
		get {if (this["attachment"]==DBNull.Value)return null; return  (String)this["attachment"];}
		set {if (value==null) this["attachment"]= DBNull.Value; else this["attachment"]= value;}
	}
	public object attachmentValue { 
		get{ return this["attachment"];}
		set {if (value==null|| value==DBNull.Value) this["attachment"]= DBNull.Value; else this["attachment"]= value;}
	}
	public String attachmentOriginal { 
		get {if (this["attachment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["attachment",DataRowVersion.Original];}
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
	///<summary>
	///Nome del file
	///</summary>
	public String filename{ 
		get {if (this["filename"]==DBNull.Value)return null; return  (String)this["filename"];}
		set {if (value==null) this["filename"]= DBNull.Value; else this["filename"]= value;}
	}
	public object filenameValue { 
		get{ return this["filename"];}
		set {if (value==null|| value==DBNull.Value) this["filename"]= DBNull.Value; else this["filename"]= value;}
	}
	public String filenameOriginal { 
		get {if (this["filename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["filename",DataRowVersion.Original];}
	}
	public String hash{ 
		get {if (this["hash"]==DBNull.Value)return null; return  (String)this["hash"];}
		set {if (value==null) this["hash"]= DBNull.Value; else this["hash"]= value;}
	}
	public object hashValue { 
		get{ return this["hash"];}
		set {if (value==null|| value==DBNull.Value) this["hash"]= DBNull.Value; else this["hash"]= value;}
	}
	public String hashOriginal { 
		get {if (this["hash",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["hash",DataRowVersion.Original];}
	}
	public Int32? idattach{ 
		get {if (this["idattach"]==DBNull.Value)return null; return  (Int32?)this["idattach"];}
		set {if (value==null) this["idattach"]= DBNull.Value; else this["idattach"]= value;}
	}
	public object idattachValue { 
		get{ return this["idattach"];}
		set {if (value==null|| value==DBNull.Value) this["idattach"]= DBNull.Value; else this["idattach"]= value;}
	}
	public Int32? idattachOriginal { 
		get {if (this["idattach",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idattach",DataRowVersion.Original];}
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
	///Dimensione
	///</summary>
	public Int32? size{ 
		get {if (this["size"]==DBNull.Value)return null; return  (Int32?)this["size"];}
		set {if (value==null) this["size"]= DBNull.Value; else this["size"]= value;}
	}
	public object sizeValue { 
		get{ return this["size"];}
		set {if (value==null|| value==DBNull.Value) this["size"]= DBNull.Value; else this["size"]= value;}
	}
	public Int32? sizeOriginal { 
		get {if (this["size",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["size",DataRowVersion.Original];}
	}
	#endregion

}
public class attachTable : MetaTableBase<attachRow> {
	public attachTable() : base("attach"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"attachment",createColumn("attachment",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"filename",createColumn("filename",typeof(string),false,false)},
			{"hash",createColumn("hash",typeof(string),false,false)},
			{"idattach",createColumn("idattach",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"size",createColumn("size",typeof(int),false,false)},
		};
	}
}
}
