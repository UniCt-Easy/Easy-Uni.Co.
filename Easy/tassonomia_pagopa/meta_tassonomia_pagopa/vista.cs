
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace meta_tassonomia_pagopa {
public class tassonomia_pagopaRow: MetaRow  {
	public tassonomia_pagopaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 idtassonomia{ 
		get {return  (Int32)this["idtassonomia"];}
		set {this["idtassonomia"]= value;}
	}
	public object idtassonomiaValue { 
		get{ return this["idtassonomia"];}
		set {this["idtassonomia"]= value;}
	}
	public Int32 idtassonomiaOriginal { 
		get {return  (Int32)this["idtassonomia",DataRowVersion.Original];}
	}
	public Int32 versione{ 
		get {return  (Int32)this["versione"];}
		set {this["versione"]= value;}
	}
	public object versioneValue { 
		get{ return this["versione"];}
		set {this["versione"]= value;}
	}
	public Int32 versioneOriginal { 
		get {return  (Int32)this["versione",DataRowVersion.Original];}
	}
	public String causale{ 
		get {return  (String)this["causale"];}
		set {this["causale"]= value;}
	}
	public object causaleValue { 
		get{ return this["causale"];}
		set {this["causale"]= value;}
	}
	public String causaleOriginal { 
		get {return  (String)this["causale",DataRowVersion.Original];}
	}
	public String descrizione{ 
		get {return  (String)this["descrizione"];}
		set {this["descrizione"]= value;}
	}
	public object descrizioneValue { 
		get{ return this["descrizione"];}
		set {this["descrizione"]= value;}
	}
	public String descrizioneOriginal { 
		get {return  (String)this["descrizione",DataRowVersion.Original];}
	}
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
	public String cu{ 
		get {return  (String)this["cu"];}
		set {this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {this["cu"]= value;}
	}
	public String cuOriginal { 
		get {return  (String)this["cu",DataRowVersion.Original];}
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
	public String motivoriscossione{ 
		get {if (this["motivoriscossione"]==DBNull.Value)return null; return  (String)this["motivoriscossione"];}
		set {if (value==null) this["motivoriscossione"]= DBNull.Value; else this["motivoriscossione"]= value;}
	}
	public object motivoriscossioneValue { 
		get{ return this["motivoriscossione"];}
		set {if (value==null|| value==DBNull.Value) this["motivoriscossione"]= DBNull.Value; else this["motivoriscossione"]= value;}
	}
	public String motivoriscossioneOriginal { 
		get {if (this["motivoriscossione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motivoriscossione",DataRowVersion.Original];}
	}
	#endregion

}
public class tassonomia_pagopaTable : MetaTableBase<tassonomia_pagopaRow> {
	public tassonomia_pagopaTable() : base("tassonomia_pagopa"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idtassonomia",createColumn("idtassonomia",typeof(int),false,false)},
			{"versione",createColumn("versione",typeof(int),false,false)},
			{"causale",createColumn("causale",typeof(string),false,false)},
			{"descrizione",createColumn("descrizione",typeof(string),false,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"motivoriscossione",createColumn("motivoriscossione",typeof(string),true,false)},
		};
	}
}
}
