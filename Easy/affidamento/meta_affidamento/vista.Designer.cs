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
namespace meta_affidamento {
public class affidamentoRow: MetaRow  {
	public affidamentoRow(DataRowBuilder rb) : base(rb) {} 

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
	///Frequenza obbligatoria
	///</summary>
	public String freqobbl{ 
		get {if (this["freqobbl"]==DBNull.Value)return null; return  (String)this["freqobbl"];}
		set {if (value==null) this["freqobbl"]= DBNull.Value; else this["freqobbl"]= value;}
	}
	public object freqobblValue { 
		get{ return this["freqobbl"];}
		set {if (value==null|| value==DBNull.Value) this["freqobbl"]= DBNull.Value; else this["freqobbl"]= value;}
	}
	public String freqobblOriginal { 
		get {if (this["freqobbl",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["freqobbl",DataRowVersion.Original];}
	}
	public String gratuito{ 
		get {if (this["gratuito"]==DBNull.Value)return null; return  (String)this["gratuito"];}
		set {if (value==null) this["gratuito"]= DBNull.Value; else this["gratuito"]= value;}
	}
	public object gratuitoValue { 
		get{ return this["gratuito"];}
		set {if (value==null|| value==DBNull.Value) this["gratuito"]= DBNull.Value; else this["gratuito"]= value;}
	}
	public String gratuitoOriginal { 
		get {if (this["gratuito",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["gratuito",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
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
	///Tipologia
	///</summary>
	public Int32? idaffidamentokind{ 
		get {if (this["idaffidamentokind"]==DBNull.Value)return null; return  (Int32?)this["idaffidamentokind"];}
		set {if (value==null) this["idaffidamentokind"]= DBNull.Value; else this["idaffidamentokind"]= value;}
	}
	public object idaffidamentokindValue { 
		get{ return this["idaffidamentokind"];}
		set {if (value==null|| value==DBNull.Value) this["idaffidamentokind"]= DBNull.Value; else this["idaffidamentokind"]= value;}
	}
	public Int32? idaffidamentokindOriginal { 
		get {if (this["idaffidamentokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idaffidamentokind",DataRowVersion.Original];}
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
	///<summary>
	///Tipo di erogazione
	///</summary>
	public Int32? iderogazkind{ 
		get {if (this["iderogazkind"]==DBNull.Value)return null; return  (Int32?)this["iderogazkind"];}
		set {if (value==null) this["iderogazkind"]= DBNull.Value; else this["iderogazkind"]= value;}
	}
	public object iderogazkindValue { 
		get{ return this["iderogazkind"];}
		set {if (value==null|| value==DBNull.Value) this["iderogazkind"]= DBNull.Value; else this["iderogazkind"]= value;}
	}
	public Int32? iderogazkindOriginal { 
		get {if (this["iderogazkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iderogazkind",DataRowVersion.Original];}
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
	///Orari di ricevimento
	///</summary>
	public String orariric{ 
		get {if (this["orariric"]==DBNull.Value)return null; return  (String)this["orariric"];}
		set {if (value==null) this["orariric"]= DBNull.Value; else this["orariric"]= value;}
	}
	public object orariricValue { 
		get{ return this["orariric"];}
		set {if (value==null|| value==DBNull.Value) this["orariric"]= DBNull.Value; else this["orariric"]= value;}
	}
	public String orariricOriginal { 
		get {if (this["orariric",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["orariric",DataRowVersion.Original];}
	}
	///<summary>
	///Oriari di ricevimento (EN)
	///</summary>
	public String orariric_en{ 
		get {if (this["orariric_en"]==DBNull.Value)return null; return  (String)this["orariric_en"];}
		set {if (value==null) this["orariric_en"]= DBNull.Value; else this["orariric_en"]= value;}
	}
	public object orariric_enValue { 
		get{ return this["orariric_en"];}
		set {if (value==null|| value==DBNull.Value) this["orariric_en"]= DBNull.Value; else this["orariric_en"]= value;}
	}
	public String orariric_enOriginal { 
		get {if (this["orariric_en",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["orariric_en",DataRowVersion.Original];}
	}
	public Int32? paridaffidamento{ 
		get {if (this["paridaffidamento"]==DBNull.Value)return null; return  (Int32?)this["paridaffidamento"];}
		set {if (value==null) this["paridaffidamento"]= DBNull.Value; else this["paridaffidamento"]= value;}
	}
	public object paridaffidamentoValue { 
		get{ return this["paridaffidamento"];}
		set {if (value==null|| value==DBNull.Value) this["paridaffidamento"]= DBNull.Value; else this["paridaffidamento"]= value;}
	}
	public Int32? paridaffidamentoOriginal { 
		get {if (this["paridaffidamento",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paridaffidamento",DataRowVersion.Original];}
	}
	///<summary>
	///Programma
	///</summary>
	public String prog{ 
		get {if (this["prog"]==DBNull.Value)return null; return  (String)this["prog"];}
		set {if (value==null) this["prog"]= DBNull.Value; else this["prog"]= value;}
	}
	public object progValue { 
		get{ return this["prog"];}
		set {if (value==null|| value==DBNull.Value) this["prog"]= DBNull.Value; else this["prog"]= value;}
	}
	public String progOriginal { 
		get {if (this["prog",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["prog",DataRowVersion.Original];}
	}
	///<summary>
	///Programma (EN)
	///</summary>
	public String prog_en{ 
		get {if (this["prog_en"]==DBNull.Value)return null; return  (String)this["prog_en"];}
		set {if (value==null) this["prog_en"]= DBNull.Value; else this["prog_en"]= value;}
	}
	public object prog_enValue { 
		get{ return this["prog_en"];}
		set {if (value==null|| value==DBNull.Value) this["prog_en"]= DBNull.Value; else this["prog_en"]= value;}
	}
	public String prog_enOriginal { 
		get {if (this["prog_en",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["prog_en",DataRowVersion.Original];}
	}
	///<summary>
	///Docente di riferimento per il canale
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
	///<summary>
	///Inizio
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
	///Fine
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
	public String testi{ 
		get {if (this["testi"]==DBNull.Value)return null; return  (String)this["testi"];}
		set {if (value==null) this["testi"]= DBNull.Value; else this["testi"]= value;}
	}
	public object testiValue { 
		get{ return this["testi"];}
		set {if (value==null|| value==DBNull.Value) this["testi"]= DBNull.Value; else this["testi"]= value;}
	}
	public String testiOriginal { 
		get {if (this["testi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["testi",DataRowVersion.Original];}
	}
	///<summary>
	///Testi (EN)
	///</summary>
	public String testi_en{ 
		get {if (this["testi_en"]==DBNull.Value)return null; return  (String)this["testi_en"];}
		set {if (value==null) this["testi_en"]= DBNull.Value; else this["testi_en"]= value;}
	}
	public object testi_enValue { 
		get{ return this["testi_en"];}
		set {if (value==null|| value==DBNull.Value) this["testi_en"]= DBNull.Value; else this["testi_en"]= value;}
	}
	public String testi_enOriginal { 
		get {if (this["testi_en",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["testi_en",DataRowVersion.Original];}
	}
	///<summary>
	///Indirizzo web del corso
	///</summary>
	public String urlcorso{ 
		get {if (this["urlcorso"]==DBNull.Value)return null; return  (String)this["urlcorso"];}
		set {if (value==null) this["urlcorso"]= DBNull.Value; else this["urlcorso"]= value;}
	}
	public object urlcorsoValue { 
		get{ return this["urlcorso"];}
		set {if (value==null|| value==DBNull.Value) this["urlcorso"]= DBNull.Value; else this["urlcorso"]= value;}
	}
	public String urlcorsoOriginal { 
		get {if (this["urlcorso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["urlcorso",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.18 Affidamento
///</summary>
public class affidamentoTable : MetaTableBase<affidamentoRow> {
	public affidamentoTable() : base("affidamento"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"freqobbl",createColumn("freqobbl",typeof(string),true,false)},
			{"gratuito",createColumn("gratuito",typeof(string),false,false)},
			{"idaffidamento",createColumn("idaffidamento",typeof(int),false,false)},
			{"idaffidamentokind",createColumn("idaffidamentokind",typeof(int),false,false)},
			{"idattivform",createColumn("idattivform",typeof(int),false,false)},
			{"idcanale",createColumn("idcanale",typeof(int),false,false)},
			{"iddidprog",createColumn("iddidprog",typeof(int),false,false)},
			{"iddidproganno",createColumn("iddidproganno",typeof(int),false,false)},
			{"iddidprogcurr",createColumn("iddidprogcurr",typeof(int),false,false)},
			{"iddidprogori",createColumn("iddidprogori",typeof(int),false,false)},
			{"iddidprogporzanno",createColumn("iddidprogporzanno",typeof(int),false,false)},
			{"iderogazkind",createColumn("iderogazkind",typeof(int),true,false)},
			{"idreg_docenti",createColumn("idreg_docenti",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"orariric",createColumn("orariric",typeof(string),true,false)},
			{"orariric_en",createColumn("orariric_en",typeof(string),true,false)},
			{"paridaffidamento",createColumn("paridaffidamento",typeof(int),true,false)},
			{"prog",createColumn("prog",typeof(string),true,false)},
			{"prog_en",createColumn("prog_en",typeof(string),true,false)},
			{"riferimento",createColumn("riferimento",typeof(string),false,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"testi",createColumn("testi",typeof(string),true,false)},
			{"testi_en",createColumn("testi_en",typeof(string),true,false)},
			{"urlcorso",createColumn("urlcorso",typeof(string),true,false)},
		};
	}
}
}
