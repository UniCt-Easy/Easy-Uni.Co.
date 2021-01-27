
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace meta_contratto {
public class contrattoRow: MetaRow  {
	public contrattoRow(DataRowBuilder rb) : base(rb) {} 

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
	///Estremi del bando di contratto
	///</summary>
	public String estremibando{ 
		get {if (this["estremibando"]==DBNull.Value)return null; return  (String)this["estremibando"];}
		set {if (value==null) this["estremibando"]= DBNull.Value; else this["estremibando"]= value;}
	}
	public object estremibandoValue { 
		get{ return this["estremibando"];}
		set {if (value==null|| value==DBNull.Value) this["estremibando"]= DBNull.Value; else this["estremibando"]= value;}
	}
	public String estremibandoOriginal { 
		get {if (this["estremibando",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["estremibando",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
	///</summary>
	public Int32? idcontratto{ 
		get {if (this["idcontratto"]==DBNull.Value)return null; return  (Int32?)this["idcontratto"];}
		set {if (value==null) this["idcontratto"]= DBNull.Value; else this["idcontratto"]= value;}
	}
	public object idcontrattoValue { 
		get{ return this["idcontratto"];}
		set {if (value==null|| value==DBNull.Value) this["idcontratto"]= DBNull.Value; else this["idcontratto"]= value;}
	}
	public Int32? idcontrattoOriginal { 
		get {if (this["idcontratto",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcontratto",DataRowVersion.Original];}
	}
	///<summary>
	///Tipologia di contratto
	///</summary>
	public Int32? idcontrattokind{ 
		get {if (this["idcontrattokind"]==DBNull.Value)return null; return  (Int32?)this["idcontrattokind"];}
		set {if (value==null) this["idcontrattokind"]= DBNull.Value; else this["idcontrattokind"]= value;}
	}
	public object idcontrattokindValue { 
		get{ return this["idcontrattokind"];}
		set {if (value==null|| value==DBNull.Value) this["idcontrattokind"]= DBNull.Value; else this["idcontrattokind"]= value;}
	}
	public Int32? idcontrattokindOriginal { 
		get {if (this["idcontrattokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcontrattokind",DataRowVersion.Original];}
	}
	///<summary>
	///Docente
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
	///<summary>
	///Part Time
	///</summary>
	public String tempdef{ 
		get {if (this["tempdef"]==DBNull.Value)return null; return  (String)this["tempdef"];}
		set {if (value==null) this["tempdef"]= DBNull.Value; else this["tempdef"]= value;}
	}
	public object tempdefValue { 
		get{ return this["tempdef"];}
		set {if (value==null|| value==DBNull.Value) this["tempdef"]= DBNull.Value; else this["tempdef"]= value;}
	}
	public String tempdefOriginal { 
		get {if (this["tempdef",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tempdef",DataRowVersion.Original];}
	}
	///<summary>
	///Tempo indeterminato
	///</summary>
	public String tempindet{ 
		get {if (this["tempindet"]==DBNull.Value)return null; return  (String)this["tempindet"];}
		set {if (value==null) this["tempindet"]= DBNull.Value; else this["tempindet"]= value;}
	}
	public object tempindetValue { 
		get{ return this["tempindet"];}
		set {if (value==null|| value==DBNull.Value) this["tempindet"]= DBNull.Value; else this["tempindet"]= value;}
	}
	public String tempindetOriginal { 
		get {if (this["tempindet",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tempindet",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.21 Contratto
///</summary>
public class contrattoTable : MetaTableBase<contrattoRow> {
	public contrattoTable() : base("contratto"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"estremibando",createColumn("estremibando",typeof(string),true,false)},
			{"idcontratto",createColumn("idcontratto",typeof(int),false,false)},
			{"idcontrattokind",createColumn("idcontrattokind",typeof(int),false,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"tempdef",createColumn("tempdef",typeof(string),false,false)},
			{"tempindet",createColumn("tempindet",typeof(string),false,false)},
		};
	}
}
}
