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
namespace meta_location_aula {
public class location_aulaRow: MetaRow  {
	public location_aulaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32? capienza{ 
		get {if (this["capienza"]==DBNull.Value)return null; return  (Int32?)this["capienza"];}
		set {if (value==null) this["capienza"]= DBNull.Value; else this["capienza"]= value;}
	}
	public object capienzaValue { 
		get{ return this["capienza"];}
		set {if (value==null|| value==DBNull.Value) this["capienza"]= DBNull.Value; else this["capienza"]= value;}
	}
	public Int32? capienzaOriginal { 
		get {if (this["capienza",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["capienza",DataRowVersion.Original];}
	}
	///<summary>
	///Capienza disabili
	///</summary>
	public Int32? capienzadis{ 
		get {if (this["capienzadis"]==DBNull.Value)return null; return  (Int32?)this["capienzadis"];}
		set {if (value==null) this["capienzadis"]= DBNull.Value; else this["capienzadis"]= value;}
	}
	public object capienzadisValue { 
		get{ return this["capienzadis"];}
		set {if (value==null|| value==DBNull.Value) this["capienzadis"]= DBNull.Value; else this["capienzadis"]= value;}
	}
	public Int32? capienzadisOriginal { 
		get {if (this["capienzadis",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["capienzadis",DataRowVersion.Original];}
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
	public String dotazioni{ 
		get {if (this["dotazioni"]==DBNull.Value)return null; return  (String)this["dotazioni"];}
		set {if (value==null) this["dotazioni"]= DBNull.Value; else this["dotazioni"]= value;}
	}
	public object dotazioniValue { 
		get{ return this["dotazioni"];}
		set {if (value==null|| value==DBNull.Value) this["dotazioni"]= DBNull.Value; else this["dotazioni"]= value;}
	}
	public String dotazioniOriginal { 
		get {if (this["dotazioni",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["dotazioni",DataRowVersion.Original];}
	}
	///<summary>
	///Tipologia
	///</summary>
	public Int32? idaulakind{ 
		get {if (this["idaulakind"]==DBNull.Value)return null; return  (Int32?)this["idaulakind"];}
		set {if (value==null) this["idaulakind"]= DBNull.Value; else this["idaulakind"]= value;}
	}
	public object idaulakindValue { 
		get{ return this["idaulakind"];}
		set {if (value==null|| value==DBNull.Value) this["idaulakind"]= DBNull.Value; else this["idaulakind"]= value;}
	}
	public Int32? idaulakindOriginal { 
		get {if (this["idaulakind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idaulakind",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
	///</summary>
	public Int32? idlocation{ 
		get {if (this["idlocation"]==DBNull.Value)return null; return  (Int32?)this["idlocation"];}
		set {if (value==null) this["idlocation"]= DBNull.Value; else this["idlocation"]= value;}
	}
	public object idlocationValue { 
		get{ return this["idlocation"];}
		set {if (value==null|| value==DBNull.Value) this["idlocation"]= DBNull.Value; else this["idlocation"]= value;}
	}
	public Int32? idlocationOriginal { 
		get {if (this["idlocation",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlocation",DataRowVersion.Original];}
	}
	///<summary>
	///Struttura di afferenza
	///</summary>
	public Int32? idlocation_struttura{ 
		get {if (this["idlocation_struttura"]==DBNull.Value)return null; return  (Int32?)this["idlocation_struttura"];}
		set {if (value==null) this["idlocation_struttura"]= DBNull.Value; else this["idlocation_struttura"]= value;}
	}
	public object idlocation_strutturaValue { 
		get{ return this["idlocation_struttura"];}
		set {if (value==null|| value==DBNull.Value) this["idlocation_struttura"]= DBNull.Value; else this["idlocation_struttura"]= value;}
	}
	public Int32? idlocation_strutturaOriginal { 
		get {if (this["idlocation_struttura",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlocation_struttura",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///2.4.24 aula
///</summary>
public class location_aulaTable : MetaTableBase<location_aulaRow> {
	public location_aulaTable() : base("location_aula"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"capienza",createColumn("capienza",typeof(int),true,false)},
			{"capienzadis",createColumn("capienzadis",typeof(int),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"dotazioni",createColumn("dotazioni",typeof(string),true,false)},
			{"idaulakind",createColumn("idaulakind",typeof(int),true,false)},
			{"idlocation",createColumn("idlocation",typeof(int),false,false)},
			{"idlocation_struttura",createColumn("idlocation_struttura",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
		};
	}
}
}
