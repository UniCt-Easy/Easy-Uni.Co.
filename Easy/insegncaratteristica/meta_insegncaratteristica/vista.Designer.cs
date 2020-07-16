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
namespace meta_insegncaratteristica {
public class insegncaratteristicaRow: MetaRow  {
	public insegncaratteristicaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Crediti
	///</summary>
	public Decimal? cf{ 
		get {if (this["cf"]==DBNull.Value)return null; return  (Decimal?)this["cf"];}
		set {if (value==null) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public object cfValue { 
		get{ return this["cf"];}
		set {if (value==null|| value==DBNull.Value) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public Decimal? cfOriginal { 
		get {if (this["cf",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["cf",DataRowVersion.Original];}
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
	public Int32? idinsegn{ 
		get {if (this["idinsegn"]==DBNull.Value)return null; return  (Int32?)this["idinsegn"];}
		set {if (value==null) this["idinsegn"]= DBNull.Value; else this["idinsegn"]= value;}
	}
	public object idinsegnValue { 
		get{ return this["idinsegn"];}
		set {if (value==null|| value==DBNull.Value) this["idinsegn"]= DBNull.Value; else this["idinsegn"]= value;}
	}
	public Int32? idinsegnOriginal { 
		get {if (this["idinsegn",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinsegn",DataRowVersion.Original];}
	}
	public Int32? idinsegncaratteristica{ 
		get {if (this["idinsegncaratteristica"]==DBNull.Value)return null; return  (Int32?)this["idinsegncaratteristica"];}
		set {if (value==null) this["idinsegncaratteristica"]= DBNull.Value; else this["idinsegncaratteristica"]= value;}
	}
	public object idinsegncaratteristicaValue { 
		get{ return this["idinsegncaratteristica"];}
		set {if (value==null|| value==DBNull.Value) this["idinsegncaratteristica"]= DBNull.Value; else this["idinsegncaratteristica"]= value;}
	}
	public Int32? idinsegncaratteristicaOriginal { 
		get {if (this["idinsegncaratteristica",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinsegncaratteristica",DataRowVersion.Original];}
	}
	///<summary>
	///SASD
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
	///Professionalizzante
	///</summary>
	public String profess{ 
		get {if (this["profess"]==DBNull.Value)return null; return  (String)this["profess"];}
		set {if (value==null) this["profess"]= DBNull.Value; else this["profess"]= value;}
	}
	public object professValue { 
		get{ return this["profess"];}
		set {if (value==null|| value==DBNull.Value) this["profess"]= DBNull.Value; else this["profess"]= value;}
	}
	public String professOriginal { 
		get {if (this["profess",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["profess",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///caratteristiche dell’insegnamento nel vocabolario ovvero sasd e cf
///</summary>
public class insegncaratteristicaTable : MetaTableBase<insegncaratteristicaRow> {
	public insegncaratteristicaTable() : base("insegncaratteristica"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"cf",createColumn("cf",typeof(decimal),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idinsegn",createColumn("idinsegn",typeof(int),false,false)},
			{"idinsegncaratteristica",createColumn("idinsegncaratteristica",typeof(int),false,false)},
			{"idsasd",createColumn("idsasd",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"profess",createColumn("profess",typeof(string),false,false)},
		};
	}
}
}
