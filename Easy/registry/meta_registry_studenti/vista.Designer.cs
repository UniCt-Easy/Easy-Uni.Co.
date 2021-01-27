
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
namespace meta_registry_studenti {
public class registry_studentiRow: MetaRow  {
	public registry_studentiRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Autorizzazione all'istituto di accedere ai propri dati INPS
	///</summary>
	public String authinps{ 
		get {if (this["authinps"]==DBNull.Value)return null; return  (String)this["authinps"];}
		set {if (value==null) this["authinps"]= DBNull.Value; else this["authinps"]= value;}
	}
	public object authinpsValue { 
		get{ return this["authinps"];}
		set {if (value==null|| value==DBNull.Value) this["authinps"]= DBNull.Value; else this["authinps"]= value;}
	}
	public String authinpsOriginal { 
		get {if (this["authinps",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["authinps",DataRowVersion.Original];}
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
	///Codice Istituto
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
	///Tipologia per il diritto allo studio
	///</summary>
	public Int32? idstuddirittokind{ 
		get {if (this["idstuddirittokind"]==DBNull.Value)return null; return  (Int32?)this["idstuddirittokind"];}
		set {if (value==null) this["idstuddirittokind"]= DBNull.Value; else this["idstuddirittokind"]= value;}
	}
	public object idstuddirittokindValue { 
		get{ return this["idstuddirittokind"];}
		set {if (value==null|| value==DBNull.Value) this["idstuddirittokind"]= DBNull.Value; else this["idstuddirittokind"]= value;}
	}
	public Int32? idstuddirittokindOriginal { 
		get {if (this["idstuddirittokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstuddirittokind",DataRowVersion.Original];}
	}
	///<summary>
	///Tipologia per la prenotazione degli appelli
	///</summary>
	public Int32? idstudprenotkind{ 
		get {if (this["idstudprenotkind"]==DBNull.Value)return null; return  (Int32?)this["idstudprenotkind"];}
		set {if (value==null) this["idstudprenotkind"]= DBNull.Value; else this["idstudprenotkind"]= value;}
	}
	public object idstudprenotkindValue { 
		get{ return this["idstudprenotkind"];}
		set {if (value==null|| value==DBNull.Value) this["idstudprenotkind"]= DBNull.Value; else this["idstudprenotkind"]= value;}
	}
	public Int32? idstudprenotkindOriginal { 
		get {if (this["idstudprenotkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstudprenotkind",DataRowVersion.Original];}
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
///Tabella di specifica per gli studenti, il resto della anagrafica Ã¨ in registry
///</summary>
public class registry_studentiTable : MetaTableBase<registry_studentiRow> {
	public registry_studentiTable() : base("registry_studenti"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"authinps",createColumn("authinps",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"idstuddirittokind",createColumn("idstuddirittokind",typeof(int),true,false)},
			{"idstudprenotkind",createColumn("idstudprenotkind",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
		};
	}
}
}
