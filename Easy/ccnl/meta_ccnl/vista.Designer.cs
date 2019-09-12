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
namespace meta_ccnl {
public class ccnlRow: MetaRow  {
	public ccnlRow(DataRowBuilder rb) : base(rb) {} 

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
	public String area{ 
		get {if (this["area"]==DBNull.Value)return null; return  (String)this["area"];}
		set {if (value==null) this["area"]= DBNull.Value; else this["area"]= value;}
	}
	public object areaValue { 
		get{ return this["area"];}
		set {if (value==null|| value==DBNull.Value) this["area"]= DBNull.Value; else this["area"]= value;}
	}
	public String areaOriginal { 
		get {if (this["area",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["area",DataRowVersion.Original];}
	}
	public String contraenti{ 
		get {if (this["contraenti"]==DBNull.Value)return null; return  (String)this["contraenti"];}
		set {if (value==null) this["contraenti"]= DBNull.Value; else this["contraenti"]= value;}
	}
	public object contraentiValue { 
		get{ return this["contraenti"];}
		set {if (value==null|| value==DBNull.Value) this["contraenti"]= DBNull.Value; else this["contraenti"]= value;}
	}
	public String contraentiOriginal { 
		get {if (this["contraenti",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["contraenti",DataRowVersion.Original];}
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
	public DateTime? decorrenza{ 
		get {if (this["decorrenza"]==DBNull.Value)return null; return  (DateTime?)this["decorrenza"];}
		set {if (value==null) this["decorrenza"]= DBNull.Value; else this["decorrenza"]= value;}
	}
	public object decorrenzaValue { 
		get{ return this["decorrenza"];}
		set {if (value==null|| value==DBNull.Value) this["decorrenza"]= DBNull.Value; else this["decorrenza"]= value;}
	}
	public DateTime? decorrenzaOriginal { 
		get {if (this["decorrenza",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["decorrenza",DataRowVersion.Original];}
	}
	public Int32? idccnl{ 
		get {if (this["idccnl"]==DBNull.Value)return null; return  (Int32?)this["idccnl"];}
		set {if (value==null) this["idccnl"]= DBNull.Value; else this["idccnl"]= value;}
	}
	public object idccnlValue { 
		get{ return this["idccnl"];}
		set {if (value==null|| value==DBNull.Value) this["idccnl"]= DBNull.Value; else this["idccnl"]= value;}
	}
	public Int32? idccnlOriginal { 
		get {if (this["idccnl",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idccnl",DataRowVersion.Original];}
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
	///Scadenza ec.
	///</summary>
	public DateTime? scadec{ 
		get {if (this["scadec"]==DBNull.Value)return null; return  (DateTime?)this["scadec"];}
		set {if (value==null) this["scadec"]= DBNull.Value; else this["scadec"]= value;}
	}
	public object scadecValue { 
		get{ return this["scadec"];}
		set {if (value==null|| value==DBNull.Value) this["scadec"]= DBNull.Value; else this["scadec"]= value;}
	}
	public DateTime? scadecOriginal { 
		get {if (this["scadec",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["scadec",DataRowVersion.Original];}
	}
	public DateTime? scadenza{ 
		get {if (this["scadenza"]==DBNull.Value)return null; return  (DateTime?)this["scadenza"];}
		set {if (value==null) this["scadenza"]= DBNull.Value; else this["scadenza"]= value;}
	}
	public object scadenzaValue { 
		get{ return this["scadenza"];}
		set {if (value==null|| value==DBNull.Value) this["scadenza"]= DBNull.Value; else this["scadenza"]= value;}
	}
	public DateTime? scadenzaOriginal { 
		get {if (this["scadenza",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["scadenza",DataRowVersion.Original];}
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
	public DateTime? stipula{ 
		get {if (this["stipula"]==DBNull.Value)return null; return  (DateTime?)this["stipula"];}
		set {if (value==null) this["stipula"]= DBNull.Value; else this["stipula"]= value;}
	}
	public object stipulaValue { 
		get{ return this["stipula"];}
		set {if (value==null|| value==DBNull.Value) this["stipula"]= DBNull.Value; else this["stipula"]= value;}
	}
	public DateTime? stipulaOriginal { 
		get {if (this["stipula",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["stipula",DataRowVersion.Original];}
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
///VOCABOLARIO dei contratti nazionali del lavoro censiti dal CNEL
///</summary>
public class ccnlTable : MetaTableBase<ccnlRow> {
	public ccnlTable() : base("ccnl"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),false,false)},
			{"area",createColumn("area",typeof(string),false,false)},
			{"contraenti",createColumn("contraenti",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"decorrenza",createColumn("decorrenza",typeof(DateTime),true,false)},
			{"idccnl",createColumn("idccnl",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"scadec",createColumn("scadec",typeof(DateTime),true,false)},
			{"scadenza",createColumn("scadenza",typeof(DateTime),true,false)},
			{"sortcode",createColumn("sortcode",typeof(int),false,false)},
			{"stipula",createColumn("stipula",typeof(DateTime),false,false)},
			{"title",createColumn("title",typeof(string),false,false)},
		};
	}
}
}
