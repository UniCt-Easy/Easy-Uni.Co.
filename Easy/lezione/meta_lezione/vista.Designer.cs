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
namespace meta_lezione {
public class lezioneRow: MetaRow  {
	public lezioneRow(DataRowBuilder rb) : base(rb) {} 

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
	///<summary>
	///Affidamento
	///</summary>
	public Int32? idaffidamento{ 
		get {if (this["idaffidamento"]==DBNull.Value)return null; return  (Int32?)this["idaffidamento"];}
		set {if (value==null) this["idaffidamento"]= DBNull.Value; else this["idaffidamento"]= value;}
	}
	public object idaffidamentoValue { 
		get{ return this["idaffidamento"];}
		set {if (value==null|| value==DBNull.Value) this["idaffidamento"]= DBNull.Value; else this["idaffidamento"]= value;}
	}
	public Int32? idaffidamentoOriginal { 
		get {if (this["idaffidamento",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idaffidamento",DataRowVersion.Original];}
	}
	///<summary>
	///Attività formativa
	///</summary>
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
	///Aula
	///</summary>
	public Int32? idaula{ 
		get {if (this["idaula"]==DBNull.Value)return null; return  (Int32?)this["idaula"];}
		set {if (value==null) this["idaula"]= DBNull.Value; else this["idaula"]= value;}
	}
	public object idaulaValue { 
		get{ return this["idaula"];}
		set {if (value==null|| value==DBNull.Value) this["idaula"]= DBNull.Value; else this["idaula"]= value;}
	}
	public Int32? idaulaOriginal { 
		get {if (this["idaula",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idaula",DataRowVersion.Original];}
	}
	///<summary>
	///Canale
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
	///<summary>
	///Didattica programmata
	///</summary>
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
	///<summary>
	///Anno di corso
	///</summary>
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
	///<summary>
	///Curriculum
	///</summary>
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
	///<summary>
	///Orientamento
	///</summary>
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
	///<summary>
	///Porzione d'anno
	///</summary>
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
	///<summary>
	///Edificio
	///</summary>
	public Int32? idedificio{ 
		get {if (this["idedificio"]==DBNull.Value)return null; return  (Int32?)this["idedificio"];}
		set {if (value==null) this["idedificio"]= DBNull.Value; else this["idedificio"]= value;}
	}
	public object idedificioValue { 
		get{ return this["idedificio"];}
		set {if (value==null|| value==DBNull.Value) this["idedificio"]= DBNull.Value; else this["idedificio"]= value;}
	}
	public Int32? idedificioOriginal { 
		get {if (this["idedificio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idedificio",DataRowVersion.Original];}
	}
	///<summary>
	///Identificativo
	///</summary>
	public Int32? idlezione{ 
		get {if (this["idlezione"]==DBNull.Value)return null; return  (Int32?)this["idlezione"];}
		set {if (value==null) this["idlezione"]= DBNull.Value; else this["idlezione"]= value;}
	}
	public object idlezioneValue { 
		get{ return this["idlezione"];}
		set {if (value==null|| value==DBNull.Value) this["idlezione"]= DBNull.Value; else this["idlezione"]= value;}
	}
	public Int32? idlezioneOriginal { 
		get {if (this["idlezione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlezione",DataRowVersion.Original];}
	}
	///<summary>
	///Docente
	///</summary>
	public Int32? idreg_docenti{ 
		get {if (this["idreg_docenti"]==DBNull.Value)return null; return  (Int32?)this["idreg_docenti"];}
		set {if (value==null) this["idreg_docenti"]= DBNull.Value; else this["idreg_docenti"]= value;}
	}
	public object idreg_docentiValue { 
		get{ return this["idreg_docenti"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_docenti"]= DBNull.Value; else this["idreg_docenti"]= value;}
	}
	public Int32? idreg_docentiOriginal { 
		get {if (this["idreg_docenti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_docenti",DataRowVersion.Original];}
	}
	///<summary>
	///Sede
	///</summary>
	public Int32? idsede{ 
		get {if (this["idsede"]==DBNull.Value)return null; return  (Int32?)this["idsede"];}
		set {if (value==null) this["idsede"]= DBNull.Value; else this["idsede"]= value;}
	}
	public object idsedeValue { 
		get{ return this["idsede"];}
		set {if (value==null|| value==DBNull.Value) this["idsede"]= DBNull.Value; else this["idsede"]= value;}
	}
	public Int32? idsedeOriginal { 
		get {if (this["idsede",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsede",DataRowVersion.Original];}
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
	///Non svolta
	///</summary>
	public String nonsvolta{ 
		get {if (this["nonsvolta"]==DBNull.Value)return null; return  (String)this["nonsvolta"];}
		set {if (value==null) this["nonsvolta"]= DBNull.Value; else this["nonsvolta"]= value;}
	}
	public object nonsvoltaValue { 
		get{ return this["nonsvolta"];}
		set {if (value==null|| value==DBNull.Value) this["nonsvolta"]= DBNull.Value; else this["nonsvolta"]= value;}
	}
	public String nonsvoltaOriginal { 
		get {if (this["nonsvolta",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["nonsvolta",DataRowVersion.Original];}
	}
	public String stage{ 
		get {if (this["stage"]==DBNull.Value)return null; return  (String)this["stage"];}
		set {if (value==null) this["stage"]= DBNull.Value; else this["stage"]= value;}
	}
	public object stageValue { 
		get{ return this["stage"];}
		set {if (value==null|| value==DBNull.Value) this["stage"]= DBNull.Value; else this["stage"]= value;}
	}
	public String stageOriginal { 
		get {if (this["stage",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["stage",DataRowVersion.Original];}
	}
	///<summary>
	///Data e ora inizio
	///</summary>
	public DateTime? start{ 
		get {if (this["start"]==DBNull.Value)return null; return  (DateTime?)this["start"];}
		set {if (value==null) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public object startValue { 
		get{ return this["start"];}
		set {if (value==null|| value==DBNull.Value) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public DateTime? startOriginal { 
		get {if (this["start",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["start",DataRowVersion.Original];}
	}
	///<summary>
	///Data e ora fine
	///</summary>
	public DateTime? stop{ 
		get {if (this["stop"]==DBNull.Value)return null; return  (DateTime?)this["stop"];}
		set {if (value==null) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public object stopValue { 
		get{ return this["stop"];}
		set {if (value==null|| value==DBNull.Value) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public DateTime? stopOriginal { 
		get {if (this["stop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["stop",DataRowVersion.Original];}
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
	public String visita{ 
		get {if (this["visita"]==DBNull.Value)return null; return  (String)this["visita"];}
		set {if (value==null) this["visita"]= DBNull.Value; else this["visita"]= value;}
	}
	public object visitaValue { 
		get{ return this["visita"];}
		set {if (value==null|| value==DBNull.Value) this["visita"]= DBNull.Value; else this["visita"]= value;}
	}
	public String visitaOriginal { 
		get {if (this["visita",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["visita",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.23 Lezione
///</summary>
public class lezioneTable : MetaTableBase<lezioneRow> {
	public lezioneTable() : base("lezione"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"aa",createColumn("aa",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idaffidamento",createColumn("idaffidamento",typeof(int),false,false)},
			{"idattivform",createColumn("idattivform",typeof(int),false,false)},
			{"idaula",createColumn("idaula",typeof(int),false,false)},
			{"idcanale",createColumn("idcanale",typeof(int),false,false)},
			{"idcorsostudio",createColumn("idcorsostudio",typeof(int),false,false)},
			{"iddidprog",createColumn("iddidprog",typeof(int),false,false)},
			{"iddidproganno",createColumn("iddidproganno",typeof(int),false,false)},
			{"iddidprogcurr",createColumn("iddidprogcurr",typeof(int),false,false)},
			{"iddidprogori",createColumn("iddidprogori",typeof(int),false,false)},
			{"iddidprogporzanno",createColumn("iddidprogporzanno",typeof(int),false,false)},
			{"idedificio",createColumn("idedificio",typeof(int),false,false)},
			{"idlezione",createColumn("idlezione",typeof(int),false,false)},
			{"idreg_docenti",createColumn("idreg_docenti",typeof(int),false,false)},
			{"idsede",createColumn("idsede",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"nonsvolta",createColumn("nonsvolta",typeof(string),true,false)},
			{"stage",createColumn("stage",typeof(string),true,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"stop",createColumn("stop",typeof(DateTime),false,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"visita",createColumn("visita",typeof(string),true,false)},
		};
	}
}
}
