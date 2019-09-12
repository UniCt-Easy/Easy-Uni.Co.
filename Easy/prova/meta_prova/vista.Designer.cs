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
namespace meta_prova {
public class provaRow: MetaRow  {
	public provaRow(DataRowBuilder rb) : base(rb) {} 

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
	///Data e ora
	///</summary>
	public DateTime? dataora{ 
		get {if (this["dataora"]==DBNull.Value)return null; return  (DateTime?)this["dataora"];}
		set {if (value==null) this["dataora"]= DBNull.Value; else this["dataora"]= value;}
	}
	public object dataoraValue { 
		get{ return this["dataora"];}
		set {if (value==null|| value==DBNull.Value) this["dataora"]= DBNull.Value; else this["dataora"]= value;}
	}
	public DateTime? dataoraOriginal { 
		get {if (this["dataora",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["dataora",DataRowVersion.Original];}
	}
	///<summary>
	///Commissione
	///</summary>
	public Int32? idcommiss{ 
		get {if (this["idcommiss"]==DBNull.Value)return null; return  (Int32?)this["idcommiss"];}
		set {if (value==null) this["idcommiss"]= DBNull.Value; else this["idcommiss"]= value;}
	}
	public object idcommissValue { 
		get{ return this["idcommiss"];}
		set {if (value==null|| value==DBNull.Value) this["idcommiss"]= DBNull.Value; else this["idcommiss"]= value;}
	}
	public Int32? idcommissOriginal { 
		get {if (this["idcommiss",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcommiss",DataRowVersion.Original];}
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
	///Codice
	///</summary>
	public Int32? idprova{ 
		get {if (this["idprova"]==DBNull.Value)return null; return  (Int32?)this["idprova"];}
		set {if (value==null) this["idprova"]= DBNull.Value; else this["idprova"]= value;}
	}
	public object idprovaValue { 
		get{ return this["idprova"];}
		set {if (value==null|| value==DBNull.Value) this["idprova"]= DBNull.Value; else this["idprova"]= value;}
	}
	public Int32? idprovaOriginal { 
		get {if (this["idprova",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idprova",DataRowVersion.Original];}
	}
	///<summary>
	///Questionario
	///</summary>
	public Int32? idquestionario{ 
		get {if (this["idquestionario"]==DBNull.Value)return null; return  (Int32?)this["idquestionario"];}
		set {if (value==null) this["idquestionario"]= DBNull.Value; else this["idquestionario"]= value;}
	}
	public object idquestionarioValue { 
		get{ return this["idquestionario"];}
		set {if (value==null|| value==DBNull.Value) this["idquestionario"]= DBNull.Value; else this["idquestionario"]= value;}
	}
	public Int32? idquestionarioOriginal { 
		get {if (this["idquestionario",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idquestionario",DataRowVersion.Original];}
	}
	///<summary>
	///Tipologia di valutazione
	///</summary>
	public Int32? idvalutazionekind{ 
		get {if (this["idvalutazionekind"]==DBNull.Value)return null; return  (Int32?)this["idvalutazionekind"];}
		set {if (value==null) this["idvalutazionekind"]= DBNull.Value; else this["idvalutazionekind"]= value;}
	}
	public object idvalutazionekindValue { 
		get{ return this["idvalutazionekind"];}
		set {if (value==null|| value==DBNull.Value) this["idvalutazionekind"]= DBNull.Value; else this["idvalutazionekind"]= value;}
	}
	public Int32? idvalutazionekindOriginal { 
		get {if (this["idvalutazionekind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idvalutazionekind",DataRowVersion.Original];}
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
	public String programma{ 
		get {if (this["programma"]==DBNull.Value)return null; return  (String)this["programma"];}
		set {if (value==null) this["programma"]= DBNull.Value; else this["programma"]= value;}
	}
	public object programmaValue { 
		get{ return this["programma"];}
		set {if (value==null|| value==DBNull.Value) this["programma"]= DBNull.Value; else this["programma"]= value;}
	}
	public String programmaOriginal { 
		get {if (this["programma",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["programma",DataRowVersion.Original];}
	}
	///<summary>
	///Denominazione
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
	#endregion

}
///<summary>
///2.4.35 Prove dâ€™esame
///</summary>
public class provaTable : MetaTableBase<provaRow> {
	public provaTable() : base("prova"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"dataora",createColumn("dataora",typeof(DateTime),true,false)},
			{"idcommiss",createColumn("idcommiss",typeof(int),true,false)},
			{"iddidprog",createColumn("iddidprog",typeof(int),true,false)},
			{"idprova",createColumn("idprova",typeof(int),false,false)},
			{"idquestionario",createColumn("idquestionario",typeof(int),true,false)},
			{"idvalutazionekind",createColumn("idvalutazionekind",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"programma",createColumn("programma",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
