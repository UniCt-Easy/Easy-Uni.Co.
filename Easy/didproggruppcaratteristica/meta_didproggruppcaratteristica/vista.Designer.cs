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
namespace meta_didproggruppcaratteristica {
public class didproggruppcaratteristicaRow: MetaRow  {
	public didproggruppcaratteristicaRow(DataRowBuilder rb) : base(rb) {} 

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
	///<summary>
	///Ambito o area disciplinare
	///</summary>
	public Int32? idambitoareadisc{ 
		get {if (this["idambitoareadisc"]==DBNull.Value)return null; return  (Int32?)this["idambitoareadisc"];}
		set {if (value==null) this["idambitoareadisc"]= DBNull.Value; else this["idambitoareadisc"]= value;}
	}
	public object idambitoareadiscValue { 
		get{ return this["idambitoareadisc"];}
		set {if (value==null|| value==DBNull.Value) this["idambitoareadisc"]= DBNull.Value; else this["idambitoareadisc"]= value;}
	}
	public Int32? idambitoareadiscOriginal { 
		get {if (this["idambitoareadisc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idambitoareadisc",DataRowVersion.Original];}
	}
	public Int32? idcorsostudio{ 
		get {if (this["idcorsostudio"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudio"];}
		set {if (value==null) this["idcorsostudio"]= DBNull.Value; else this["idcorsostudio"]= value;}
	}
	public object idcorsostudioValue { 
		get{ return this["idcorsostudio"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudio"]= DBNull.Value; else this["idcorsostudio"]= value;}
	}
	public Int32? idcorsostudioOriginal { 
		get {if (this["idcorsostudio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudio",DataRowVersion.Original];}
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
	public Int32? iddidproggrupp{ 
		get {if (this["iddidproggrupp"]==DBNull.Value)return null; return  (Int32?)this["iddidproggrupp"];}
		set {if (value==null) this["iddidproggrupp"]= DBNull.Value; else this["iddidproggrupp"]= value;}
	}
	public object iddidproggruppValue { 
		get{ return this["iddidproggrupp"];}
		set {if (value==null|| value==DBNull.Value) this["iddidproggrupp"]= DBNull.Value; else this["iddidproggrupp"]= value;}
	}
	public Int32? iddidproggruppOriginal { 
		get {if (this["iddidproggrupp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidproggrupp",DataRowVersion.Original];}
	}
	public Int32? iddidproggruppcaratteristica{ 
		get {if (this["iddidproggruppcaratteristica"]==DBNull.Value)return null; return  (Int32?)this["iddidproggruppcaratteristica"];}
		set {if (value==null) this["iddidproggruppcaratteristica"]= DBNull.Value; else this["iddidproggruppcaratteristica"]= value;}
	}
	public object iddidproggruppcaratteristicaValue { 
		get{ return this["iddidproggruppcaratteristica"];}
		set {if (value==null|| value==DBNull.Value) this["iddidproggruppcaratteristica"]= DBNull.Value; else this["iddidproggruppcaratteristica"]= value;}
	}
	public Int32? iddidproggruppcaratteristicaOriginal { 
		get {if (this["iddidproggruppcaratteristica",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidproggruppcaratteristica",DataRowVersion.Original];}
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
	///<summary>
	///Tipo di attività formativa
	///</summary>
	public Int32? idtipoattform{ 
		get {if (this["idtipoattform"]==DBNull.Value)return null; return  (Int32?)this["idtipoattform"];}
		set {if (value==null) this["idtipoattform"]= DBNull.Value; else this["idtipoattform"]= value;}
	}
	public object idtipoattformValue { 
		get{ return this["idtipoattform"];}
		set {if (value==null|| value==DBNull.Value) this["idtipoattform"]= DBNull.Value; else this["idtipoattform"]= value;}
	}
	public Int32? idtipoattformOriginal { 
		get {if (this["idtipoattform",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtipoattform",DataRowVersion.Original];}
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
	///<summary>
	///Sotto-ambito
	///</summary>
	public String subambito{ 
		get {if (this["subambito"]==DBNull.Value)return null; return  (String)this["subambito"];}
		set {if (value==null) this["subambito"]= DBNull.Value; else this["subambito"]= value;}
	}
	public object subambitoValue { 
		get{ return this["subambito"];}
		set {if (value==null|| value==DBNull.Value) this["subambito"]= DBNull.Value; else this["subambito"]= value;}
	}
	public String subambitoOriginal { 
		get {if (this["subambito",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["subambito",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Caratteristiche del 2.4.16 gruppo opzionale nella sua definizione
///</summary>
public class didproggruppcaratteristicaTable : MetaTableBase<didproggruppcaratteristicaRow> {
	public didproggruppcaratteristicaTable() : base("didproggruppcaratteristica"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"cf",createColumn("cf",typeof(decimal),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idambitoareadisc",createColumn("idambitoareadisc",typeof(int),true,false)},
			{"idcorsostudio",createColumn("idcorsostudio",typeof(int),false,false)},
			{"iddidprog",createColumn("iddidprog",typeof(int),false,false)},
			{"iddidproggrupp",createColumn("iddidproggrupp",typeof(int),false,false)},
			{"iddidproggruppcaratteristica",createColumn("iddidproggruppcaratteristica",typeof(int),false,false)},
			{"idsasd",createColumn("idsasd",typeof(int),true,false)},
			{"idtipoattform",createColumn("idtipoattform",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"profess",createColumn("profess",typeof(string),false,false)},
			{"subambito",createColumn("subambito",typeof(string),true,false)},
		};
	}
}
}
