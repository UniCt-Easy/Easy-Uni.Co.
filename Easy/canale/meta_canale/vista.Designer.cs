/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
namespace meta_canale {
public class canaleRow: MetaRow  {
	public canaleRow(DataRowBuilder rb) : base(rb) {} 

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
	public String CUIN{ 
		get {if (this["CUIN"]==DBNull.Value)return null; return  (String)this["CUIN"];}
		set {if (value==null) this["CUIN"]= DBNull.Value; else this["CUIN"]= value;}
	}
	public object CUINValue { 
		get{ return this["CUIN"];}
		set {if (value==null|| value==DBNull.Value) this["CUIN"]= DBNull.Value; else this["CUIN"]= value;}
	}
	public String CUINOriginal { 
		get {if (this["CUIN",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["CUIN",DataRowVersion.Original];}
	}
	public Int32? idattivform{ 
		get {if (this["idattivform"]==DBNull.Value)return null; return  (Int32?)this["idattivform"];}
		set {if (value==null) this["idattivform"]= DBNull.Value; else this["idattivform"]= value;}
	}
	public object idattivformValue { 
		get{ return this["idattivform"];}
		set {if (value==null|| value==DBNull.Value) this["idattivform"]= DBNull.Value; else this["idattivform"]= value;}
	}
	public Int32? idattivformOriginal { 
		get {if (this["idattivform",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idattivform",DataRowVersion.Original];}
	}
	public Int32? idcanale{ 
		get {if (this["idcanale"]==DBNull.Value)return null; return  (Int32?)this["idcanale"];}
		set {if (value==null) this["idcanale"]= DBNull.Value; else this["idcanale"]= value;}
	}
	public object idcanaleValue { 
		get{ return this["idcanale"];}
		set {if (value==null|| value==DBNull.Value) this["idcanale"]= DBNull.Value; else this["idcanale"]= value;}
	}
	public Int32? idcanaleOriginal { 
		get {if (this["idcanale",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcanale",DataRowVersion.Original];}
	}
	public Int32? iddidprog{ 
		get {if (this["iddidprog"]==DBNull.Value)return null; return  (Int32?)this["iddidprog"];}
		set {if (value==null) this["iddidprog"]= DBNull.Value; else this["iddidprog"]= value;}
	}
	public object iddidprogValue { 
		get{ return this["iddidprog"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprog"]= DBNull.Value; else this["iddidprog"]= value;}
	}
	public Int32? iddidprogOriginal { 
		get {if (this["iddidprog",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprog",DataRowVersion.Original];}
	}
	public Int32? iddidproganno{ 
		get {if (this["iddidproganno"]==DBNull.Value)return null; return  (Int32?)this["iddidproganno"];}
		set {if (value==null) this["iddidproganno"]= DBNull.Value; else this["iddidproganno"]= value;}
	}
	public object iddidprogannoValue { 
		get{ return this["iddidproganno"];}
		set {if (value==null|| value==DBNull.Value) this["iddidproganno"]= DBNull.Value; else this["iddidproganno"]= value;}
	}
	public Int32? iddidprogannoOriginal { 
		get {if (this["iddidproganno",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidproganno",DataRowVersion.Original];}
	}
	public Int32? iddidprogcurr{ 
		get {if (this["iddidprogcurr"]==DBNull.Value)return null; return  (Int32?)this["iddidprogcurr"];}
		set {if (value==null) this["iddidprogcurr"]= DBNull.Value; else this["iddidprogcurr"]= value;}
	}
	public object iddidprogcurrValue { 
		get{ return this["iddidprogcurr"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprogcurr"]= DBNull.Value; else this["iddidprogcurr"]= value;}
	}
	public Int32? iddidprogcurrOriginal { 
		get {if (this["iddidprogcurr",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprogcurr",DataRowVersion.Original];}
	}
	public Int32? iddidprogori{ 
		get {if (this["iddidprogori"]==DBNull.Value)return null; return  (Int32?)this["iddidprogori"];}
		set {if (value==null) this["iddidprogori"]= DBNull.Value; else this["iddidprogori"]= value;}
	}
	public object iddidprogoriValue { 
		get{ return this["iddidprogori"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprogori"]= DBNull.Value; else this["iddidprogori"]= value;}
	}
	public Int32? iddidprogoriOriginal { 
		get {if (this["iddidprogori",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprogori",DataRowVersion.Original];}
	}
	public Int32? iddidprogporzanno{ 
		get {if (this["iddidprogporzanno"]==DBNull.Value)return null; return  (Int32?)this["iddidprogporzanno"];}
		set {if (value==null) this["iddidprogporzanno"]= DBNull.Value; else this["iddidprogporzanno"]= value;}
	}
	public object iddidprogporzannoValue { 
		get{ return this["iddidprogporzanno"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprogporzanno"]= DBNull.Value; else this["iddidprogporzanno"]= value;}
	}
	public Int32? iddidprogporzannoOriginal { 
		get {if (this["iddidprogporzanno",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprogporzanno",DataRowVersion.Original];}
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
	public Int32? numerostud{ 
		get {if (this["numerostud"]==DBNull.Value)return null; return  (Int32?)this["numerostud"];}
		set {if (value==null) this["numerostud"]= DBNull.Value; else this["numerostud"]= value;}
	}
	public object numerostudValue { 
		get{ return this["numerostud"];}
		set {if (value==null|| value==DBNull.Value) this["numerostud"]= DBNull.Value; else this["numerostud"]= value;}
	}
	public Int32? numerostudOriginal { 
		get {if (this["numerostud",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["numerostud",DataRowVersion.Original];}
	}
	public Int32? sortcode{ 
		get {if (this["sortcode"]==DBNull.Value)return null; return  (Int32?)this["sortcode"];}
		set {if (value==null) this["sortcode"]= DBNull.Value; else this["sortcode"]= value;}
	}
	public object sortcodeValue { 
		get{ return this["sortcode"];}
		set {if (value==null|| value==DBNull.Value) this["sortcode"]= DBNull.Value; else this["sortcode"]= value;}
	}
	public Int32? sortcodeOriginal { 
		get {if (this["sortcode",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["sortcode",DataRowVersion.Original];}
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
///2.4.17 Canale
///</summary>
public class canaleTable : MetaTableBase<canaleRow> {
	public canaleTable() : base("canale"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"CUIN",createColumn("CUIN",typeof(string),true,false)},
			{"idattivform",createColumn("idattivform",typeof(int),false,false)},
			{"idcanale",createColumn("idcanale",typeof(int),false,false)},
			{"iddidprog",createColumn("iddidprog",typeof(int),false,false)},
			{"iddidproganno",createColumn("iddidproganno",typeof(int),false,false)},
			{"iddidprogcurr",createColumn("iddidprogcurr",typeof(int),false,false)},
			{"iddidprogori",createColumn("iddidprogori",typeof(int),false,false)},
			{"iddidprogporzanno",createColumn("iddidprogporzanno",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"numerostud",createColumn("numerostud",typeof(int),true,false)},
			{"sortcode",createColumn("sortcode",typeof(int),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
