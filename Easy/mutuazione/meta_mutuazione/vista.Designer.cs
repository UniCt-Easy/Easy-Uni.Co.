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
namespace meta_mutuazione {
public class mutuazioneRow: MetaRow  {
	public mutuazioneRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///<summary>
	///Canale mutuante
	///</summary>
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
	///<summary>
	///Canale mutuato
	///</summary>
	public Int32? idcanale_from{ 
		get {if (this["idcanale_from"]==DBNull.Value)return null; return  (Int32?)this["idcanale_from"];}
		set {if (value==null) this["idcanale_from"]= DBNull.Value; else this["idcanale_from"]= value;}
	}
	public object idcanale_fromValue { 
		get{ return this["idcanale_from"];}
		set {if (value==null|| value==DBNull.Value) this["idcanale_from"]= DBNull.Value; else this["idcanale_from"]= value;}
	}
	public Int32? idcanale_fromOriginal { 
		get {if (this["idcanale_from",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcanale_from",DataRowVersion.Original];}
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
	public Int32? idmutuazione{ 
		get {if (this["idmutuazione"]==DBNull.Value)return null; return  (Int32?)this["idmutuazione"];}
		set {if (value==null) this["idmutuazione"]= DBNull.Value; else this["idmutuazione"]= value;}
	}
	public object idmutuazioneValue { 
		get{ return this["idmutuazione"];}
		set {if (value==null|| value==DBNull.Value) this["idmutuazione"]= DBNull.Value; else this["idmutuazione"]= value;}
	}
	public Int32? idmutuazioneOriginal { 
		get {if (this["idmutuazione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idmutuazione",DataRowVersion.Original];}
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
	///Di riferimento per il canale
	///</summary>
	public String riferimento{ 
		get {if (this["riferimento"]==DBNull.Value)return null; return  (String)this["riferimento"];}
		set {if (value==null) this["riferimento"]= DBNull.Value; else this["riferimento"]= value;}
	}
	public object riferimentoValue { 
		get{ return this["riferimento"];}
		set {if (value==null|| value==DBNull.Value) this["riferimento"]= DBNull.Value; else this["riferimento"]= value;}
	}
	public String riferimentoOriginal { 
		get {if (this["riferimento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["riferimento",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.19 Mutuazione
///</summary>
public class mutuazioneTable : MetaTableBase<mutuazioneRow> {
	public mutuazioneTable() : base("mutuazione"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"aa",createColumn("aa",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idattivform",createColumn("idattivform",typeof(int),false,false)},
			{"idcanale",createColumn("idcanale",typeof(int),false,false)},
			{"idcanale_from",createColumn("idcanale_from",typeof(int),false,false)},
			{"idcorsostudio",createColumn("idcorsostudio",typeof(int),false,false)},
			{"iddidprog",createColumn("iddidprog",typeof(int),false,false)},
			{"iddidproganno",createColumn("iddidproganno",typeof(int),false,false)},
			{"iddidprogcurr",createColumn("iddidprogcurr",typeof(int),false,false)},
			{"iddidprogori",createColumn("iddidprogori",typeof(int),false,false)},
			{"iddidprogporzanno",createColumn("iddidprogporzanno",typeof(int),false,false)},
			{"idmutuazione",createColumn("idmutuazione",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"riferimento",createColumn("riferimento",typeof(string),false,false)},
		};
	}
}
}
