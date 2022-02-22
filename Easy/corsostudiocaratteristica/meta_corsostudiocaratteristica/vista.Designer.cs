
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace meta_corsostudiocaratteristica {
public class corsostudiocaratteristicaRow: MetaRow  {
	public corsostudiocaratteristicaRow(DataRowBuilder rb) : base(rb) {} 

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
	///<summary>
	///Crediti max
	///</summary>
	public Decimal? cfmax{ 
		get {if (this["cfmax"]==DBNull.Value)return null; return  (Decimal?)this["cfmax"];}
		set {if (value==null) this["cfmax"]= DBNull.Value; else this["cfmax"]= value;}
	}
	public object cfmaxValue { 
		get{ return this["cfmax"];}
		set {if (value==null|| value==DBNull.Value) this["cfmax"]= DBNull.Value; else this["cfmax"]= value;}
	}
	public Decimal? cfmaxOriginal { 
		get {if (this["cfmax",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["cfmax",DataRowVersion.Original];}
	}
	///<summary>
	///Crediti min
	///</summary>
	public Decimal? cfmin{ 
		get {if (this["cfmin"]==DBNull.Value)return null; return  (Decimal?)this["cfmin"];}
		set {if (value==null) this["cfmin"]= DBNull.Value; else this["cfmin"]= value;}
	}
	public object cfminValue { 
		get{ return this["cfmin"];}
		set {if (value==null|| value==DBNull.Value) this["cfmin"]= DBNull.Value; else this["cfmin"]= value;}
	}
	public Decimal? cfminOriginal { 
		get {if (this["cfmin",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["cfmin",DataRowVersion.Original];}
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
	public Int32? idcorsostudiocaratteristica{ 
		get {if (this["idcorsostudiocaratteristica"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiocaratteristica"];}
		set {if (value==null) this["idcorsostudiocaratteristica"]= DBNull.Value; else this["idcorsostudiocaratteristica"]= value;}
	}
	public object idcorsostudiocaratteristicaValue { 
		get{ return this["idcorsostudiocaratteristica"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudiocaratteristica"]= DBNull.Value; else this["idcorsostudiocaratteristica"]= value;}
	}
	public Int32? idcorsostudiocaratteristicaOriginal { 
		get {if (this["idcorsostudiocaratteristica",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiocaratteristica",DataRowVersion.Original];}
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
	///Tipo di attivit√† formativa
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
	///Obbligatorio
	///</summary>
	public String obblig{ 
		get {if (this["obblig"]==DBNull.Value)return null; return  (String)this["obblig"];}
		set {if (value==null) this["obblig"]= DBNull.Value; else this["obblig"]= value;}
	}
	public object obbligValue { 
		get{ return this["obblig"];}
		set {if (value==null|| value==DBNull.Value) this["obblig"]= DBNull.Value; else this["obblig"]= value;}
	}
	public String obbligOriginal { 
		get {if (this["obblig",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["obblig",DataRowVersion.Original];}
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
///Caratterisitche del 2.4.2 corso di studi (solitamente min e max o dei totali)
///</summary>
public class corsostudiocaratteristicaTable : MetaTableBase<corsostudiocaratteristicaRow> {
	public corsostudiocaratteristicaTable() : base("corsostudiocaratteristica"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"cf",createColumn("cf",typeof(decimal),true,false)},
			{"cfmax",createColumn("cfmax",typeof(decimal),true,false)},
			{"cfmin",createColumn("cfmin",typeof(decimal),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idambitoareadisc",createColumn("idambitoareadisc",typeof(int),true,false)},
			{"idcorsostudio",createColumn("idcorsostudio",typeof(int),false,false)},
			{"idcorsostudiocaratteristica",createColumn("idcorsostudiocaratteristica",typeof(int),false,false)},
			{"idsasd",createColumn("idsasd",typeof(int),true,false)},
			{"idtipoattform",createColumn("idtipoattform",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"obblig",createColumn("obblig",typeof(string),false,false)},
			{"profess",createColumn("profess",typeof(string),false,false)},
			{"subambito",createColumn("subambito",typeof(string),true,false)},
		};
	}
}
}
