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
namespace meta_titolostudio {
public class titolostudioRow: MetaRow  {
	public titolostudioRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Anno accademco
	///</summary>
	public String aa{ 
		get {if (this["aa"]==DBNull.Value)return null; return  (String)this["aa"];}
		set {if (value==null) this["aa"]= DBNull.Value; else this["aa"]= value;}
	}
	public object aaValue { 
		get{ return this["aa"];}
		set {if (value==null|| value==DBNull.Value) this["aa"]= DBNull.Value; else this["aa"]= value;}
	}
	public String aaOriginal { 
		get {if (this["aa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["aa",DataRowVersion.Original];}
	}
	public String conseguito{ 
		get {if (this["conseguito"]==DBNull.Value)return null; return  (String)this["conseguito"];}
		set {if (value==null) this["conseguito"]= DBNull.Value; else this["conseguito"]= value;}
	}
	public object conseguitoValue { 
		get{ return this["conseguito"];}
		set {if (value==null|| value==DBNull.Value) this["conseguito"]= DBNull.Value; else this["conseguito"]= value;}
	}
	public String conseguitoOriginal { 
		get {if (this["conseguito",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["conseguito",DataRowVersion.Original];}
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
	///Data del conseguimento
	///</summary>
	public DateTime? data{ 
		get {if (this["data"]==DBNull.Value)return null; return  (DateTime?)this["data"];}
		set {if (value==null) this["data"]= DBNull.Value; else this["data"]= value;}
	}
	public object dataValue { 
		get{ return this["data"];}
		set {if (value==null|| value==DBNull.Value) this["data"]= DBNull.Value; else this["data"]= value;}
	}
	public DateTime? dataOriginal { 
		get {if (this["data",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["data",DataRowVersion.Original];}
	}
	public String giudizio{ 
		get {if (this["giudizio"]==DBNull.Value)return null; return  (String)this["giudizio"];}
		set {if (value==null) this["giudizio"]= DBNull.Value; else this["giudizio"]= value;}
	}
	public object giudizioValue { 
		get{ return this["giudizio"];}
		set {if (value==null|| value==DBNull.Value) this["giudizio"]= DBNull.Value; else this["giudizio"]= value;}
	}
	public String giudizioOriginal { 
		get {if (this["giudizio",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["giudizio",DataRowVersion.Original];}
	}
	///<summary>
	///Allegato
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
	///<summary>
	///Titolo ISTAT
	///</summary>
	public Int32? idistattitolistudio{ 
		get {if (this["idistattitolistudio"]==DBNull.Value)return null; return  (Int32?)this["idistattitolistudio"];}
		set {if (value==null) this["idistattitolistudio"]= DBNull.Value; else this["idistattitolistudio"]= value;}
	}
	public object idistattitolistudioValue { 
		get{ return this["idistattitolistudio"];}
		set {if (value==null|| value==DBNull.Value) this["idistattitolistudio"]= DBNull.Value; else this["idistattitolistudio"]= value;}
	}
	public Int32? idistattitolistudioOriginal { 
		get {if (this["idistattitolistudio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idistattitolistudio",DataRowVersion.Original];}
	}
	///<summary>
	///Studente
	///</summary>
	public Int32? idreg{ 
		get {if (this["idreg"]==DBNull.Value)return null; return  (Int32?)this["idreg"];}
		set {if (value==null) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public object idregValue { 
		get{ return this["idreg"];}
		set {if (value==null|| value==DBNull.Value) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public Int32? idregOriginal { 
		get {if (this["idreg",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg",DataRowVersion.Original];}
	}
	///<summary>
	///Istituto
	///</summary>
	public Int32? idreg_istituti{ 
		get {if (this["idreg_istituti"]==DBNull.Value)return null; return  (Int32?)this["idreg_istituti"];}
		set {if (value==null) this["idreg_istituti"]= DBNull.Value; else this["idreg_istituti"]= value;}
	}
	public object idreg_istitutiValue { 
		get{ return this["idreg_istituti"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_istituti"]= DBNull.Value; else this["idreg_istituti"]= value;}
	}
	public Int32? idreg_istitutiOriginal { 
		get {if (this["idreg_istituti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_istituti",DataRowVersion.Original];}
	}
	public Int32? idtitolostudio{ 
		get {if (this["idtitolostudio"]==DBNull.Value)return null; return  (Int32?)this["idtitolostudio"];}
		set {if (value==null) this["idtitolostudio"]= DBNull.Value; else this["idtitolostudio"]= value;}
	}
	public object idtitolostudioValue { 
		get{ return this["idtitolostudio"];}
		set {if (value==null|| value==DBNull.Value) this["idtitolostudio"]= DBNull.Value; else this["idtitolostudio"]= value;}
	}
	public Int32? idtitolostudioOriginal { 
		get {if (this["idtitolostudio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtitolostudio",DataRowVersion.Original];}
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
	public Int32? voto{ 
		get {if (this["voto"]==DBNull.Value)return null; return  (Int32?)this["voto"];}
		set {if (value==null) this["voto"]= DBNull.Value; else this["voto"]= value;}
	}
	public object votoValue { 
		get{ return this["voto"];}
		set {if (value==null|| value==DBNull.Value) this["voto"]= DBNull.Value; else this["voto"]= value;}
	}
	public Int32? votoOriginal { 
		get {if (this["voto",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["voto",DataRowVersion.Original];}
	}
	///<summary>
	///Lode
	///</summary>
	public String votolode{ 
		get {if (this["votolode"]==DBNull.Value)return null; return  (String)this["votolode"];}
		set {if (value==null) this["votolode"]= DBNull.Value; else this["votolode"]= value;}
	}
	public object votolodeValue { 
		get{ return this["votolode"];}
		set {if (value==null|| value==DBNull.Value) this["votolode"]= DBNull.Value; else this["votolode"]= value;}
	}
	public String votolodeOriginal { 
		get {if (this["votolode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["votolode",DataRowVersion.Original];}
	}
	///<summary>
	///Su
	///</summary>
	public Int32? votosu{ 
		get {if (this["votosu"]==DBNull.Value)return null; return  (Int32?)this["votosu"];}
		set {if (value==null) this["votosu"]= DBNull.Value; else this["votosu"]= value;}
	}
	public object votosuValue { 
		get{ return this["votosu"];}
		set {if (value==null|| value==DBNull.Value) this["votosu"]= DBNull.Value; else this["votosu"]= value;}
	}
	public Int32? votosuOriginal { 
		get {if (this["votosu",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["votosu",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.6.5 Titoli di Studio dello studente
///</summary>
public class titolostudioTable : MetaTableBase<titolostudioRow> {
	public titolostudioTable() : base("titolostudio"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"aa",createColumn("aa",typeof(string),false,false)},
			{"conseguito",createColumn("conseguito",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"data",createColumn("data",typeof(DateTime),false,false)},
			{"giudizio",createColumn("giudizio",typeof(string),true,false)},
			{"idattach",createColumn("idattach",typeof(int),true,false)},
			{"idistattitolistudio",createColumn("idistattitolistudio",typeof(int),false,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"idreg_istituti",createColumn("idreg_istituti",typeof(int),false,false)},
			{"idtitolostudio",createColumn("idtitolostudio",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"voto",createColumn("voto",typeof(int),true,false)},
			{"votolode",createColumn("votolode",typeof(string),true,false)},
			{"votosu",createColumn("votosu",typeof(int),true,false)},
		};
	}
}
}
