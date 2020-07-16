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
namespace meta_instmcontrattoallegato {
public class instmcontrattoallegatoRow: MetaRow  {
	public instmcontrattoallegatoRow(DataRowBuilder rb) : base(rb) {} 

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
	///<summary>
	///File
	///</summary>
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
	public Int32? idinstmcontratto{ 
		get {if (this["idinstmcontratto"]==DBNull.Value)return null; return  (Int32?)this["idinstmcontratto"];}
		set {if (value==null) this["idinstmcontratto"]= DBNull.Value; else this["idinstmcontratto"]= value;}
	}
	public object idinstmcontrattoValue { 
		get{ return this["idinstmcontratto"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmcontratto"]= DBNull.Value; else this["idinstmcontratto"]= value;}
	}
	public Int32? idinstmcontrattoOriginal { 
		get {if (this["idinstmcontratto",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmcontratto",DataRowVersion.Original];}
	}
	public Int32? idinstmcontrattoallegato{ 
		get {if (this["idinstmcontrattoallegato"]==DBNull.Value)return null; return  (Int32?)this["idinstmcontrattoallegato"];}
		set {if (value==null) this["idinstmcontrattoallegato"]= DBNull.Value; else this["idinstmcontrattoallegato"]= value;}
	}
	public object idinstmcontrattoallegatoValue { 
		get{ return this["idinstmcontrattoallegato"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmcontrattoallegato"]= DBNull.Value; else this["idinstmcontrattoallegato"]= value;}
	}
	public Int32? idinstmcontrattoallegatoOriginal { 
		get {if (this["idinstmcontrattoallegato",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmcontrattoallegato",DataRowVersion.Original];}
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
	///Descrizione
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
public class instmcontrattoallegatoTable : MetaTableBase<instmcontrattoallegatoRow> {
	public instmcontrattoallegatoTable() : base("instmcontrattoallegato"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idattach",createColumn("idattach",typeof(int),true,false)},
			{"idinstmcontratto",createColumn("idinstmcontratto",typeof(int),false,false)},
			{"idinstmcontrattoallegato",createColumn("idinstmcontrattoallegato",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
