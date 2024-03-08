
/*
Easy
Copyright (C) 2024 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace meta_registryaddress {
public class registryaddressRow: MetaRow  {
	public registryaddressRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///attivo
	///</summary>
	public String active{ 
		get {if (this["active"]==DBNull.Value)return null; return  (String)this["active"];}
		set {if (value==null) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {if (value==null|| value==DBNull.Value) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public String activeOriginal { 
		get {if (this["active",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["active",DataRowVersion.Original];}
	}
	///<summary>
	///n. operazione
	///</summary>
	public String address{ 
		get {if (this["address"]==DBNull.Value)return null; return  (String)this["address"];}
		set {if (value==null) this["address"]= DBNull.Value; else this["address"]= value;}
	}
	public object addressValue { 
		get{ return this["address"];}
		set {if (value==null|| value==DBNull.Value) this["address"]= DBNull.Value; else this["address"]= value;}
	}
	public String addressOriginal { 
		get {if (this["address",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["address",DataRowVersion.Original];}
	}
	///<summary>
	///Annotazioni
	///</summary>
	public String annotations{ 
		get {if (this["annotations"]==DBNull.Value)return null; return  (String)this["annotations"];}
		set {if (value==null) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public object annotationsValue { 
		get{ return this["annotations"];}
		set {if (value==null|| value==DBNull.Value) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public String annotationsOriginal { 
		get {if (this["annotations",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["annotations",DataRowVersion.Original];}
	}
	///<summary>
	///Codice avv. postale
	///</summary>
	public String cap{ 
		get {if (this["cap"]==DBNull.Value)return null; return  (String)this["cap"];}
		set {if (value==null) this["cap"]= DBNull.Value; else this["cap"]= value;}
	}
	public object capValue { 
		get{ return this["cap"];}
		set {if (value==null|| value==DBNull.Value) this["cap"]= DBNull.Value; else this["cap"]= value;}
	}
	public String capOriginal { 
		get {if (this["cap",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cap",DataRowVersion.Original];}
	}
	///<summary>
	///data creazione
	///</summary>
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
	///<summary>
	///nome utente creazione
	///</summary>
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
	///Estero
	///	 N: Italia
	///	 S: Estero
	///</summary>
	public String flagforeign{ 
		get {if (this["flagforeign"]==DBNull.Value)return null; return  (String)this["flagforeign"];}
		set {if (value==null) this["flagforeign"]= DBNull.Value; else this["flagforeign"]= value;}
	}
	public object flagforeignValue { 
		get{ return this["flagforeign"];}
		set {if (value==null|| value==DBNull.Value) this["flagforeign"]= DBNull.Value; else this["flagforeign"]= value;}
	}
	public String flagforeignOriginal { 
		get {if (this["flagforeign",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagforeign",DataRowVersion.Original];}
	}
	///<summary>
	///tipo indirizzo (idaddress di tabella address)
	///</summary>
	public Int32 idaddresskind{ 
		get {return  (Int32)this["idaddresskind"];}
		set {this["idaddresskind"]= value;}
	}
	public object idaddresskindValue { 
		get{ return this["idaddresskind"];}
		set {this["idaddresskind"]= value;}
	}
	public Int32 idaddresskindOriginal { 
		get {return  (Int32)this["idaddresskind",DataRowVersion.Original];}
	}
	///<summary>
	///id citt√† (tabella geo_city)
	///</summary>
	public Int32? idcity{ 
		get {if (this["idcity"]==DBNull.Value)return null; return  (Int32?)this["idcity"];}
		set {if (value==null) this["idcity"]= DBNull.Value; else this["idcity"]= value;}
	}
	public object idcityValue { 
		get{ return this["idcity"];}
		set {if (value==null|| value==DBNull.Value) this["idcity"]= DBNull.Value; else this["idcity"]= value;}
	}
	public Int32? idcityOriginal { 
		get {if (this["idcity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity",DataRowVersion.Original];}
	}
	///<summary>
	///Id nazione (tabella geo_nation)
	///</summary>
	public Int32? idnation{ 
		get {if (this["idnation"]==DBNull.Value)return null; return  (Int32?)this["idnation"];}
		set {if (value==null) this["idnation"]= DBNull.Value; else this["idnation"]= value;}
	}
	public object idnationValue { 
		get{ return this["idnation"];}
		set {if (value==null|| value==DBNull.Value) this["idnation"]= DBNull.Value; else this["idnation"]= value;}
	}
	public Int32? idnationOriginal { 
		get {if (this["idnation",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnation",DataRowVersion.Original];}
	}
	///<summary>
	///id anagrafica (tabella registry)
	///</summary>
	public Int32 idreg{ 
		get {return  (Int32)this["idreg"];}
		set {this["idreg"]= value;}
	}
	public object idregValue { 
		get{ return this["idreg"];}
		set {this["idreg"]= value;}
	}
	public Int32 idregOriginal { 
		get {return  (Int32)this["idreg",DataRowVersion.Original];}
	}
	///<summary>
	///ubicazione
	///</summary>
	public String location{ 
		get {if (this["location"]==DBNull.Value)return null; return  (String)this["location"];}
		set {if (value==null) this["location"]= DBNull.Value; else this["location"]= value;}
	}
	public object locationValue { 
		get{ return this["location"];}
		set {if (value==null|| value==DBNull.Value) this["location"]= DBNull.Value; else this["location"]= value;}
	}
	public String locationOriginal { 
		get {if (this["location",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["location",DataRowVersion.Original];}
	}
	///<summary>
	///data ultima modifica
	///</summary>
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
	///<summary>
	///nome ultimo utente modifica
	///</summary>
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
	///Nome ufficio
	///</summary>
	public String officename{ 
		get {if (this["officename"]==DBNull.Value)return null; return  (String)this["officename"];}
		set {if (value==null) this["officename"]= DBNull.Value; else this["officename"]= value;}
	}
	public object officenameValue { 
		get{ return this["officename"];}
		set {if (value==null|| value==DBNull.Value) this["officename"]= DBNull.Value; else this["officename"]= value;}
	}
	public String officenameOriginal { 
		get {if (this["officename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["officename",DataRowVersion.Original];}
	}
	///<summary>
	///Ente di provenienza (per anagrafe prestazioni)
	///</summary>
	public String recipientagency{ 
		get {if (this["recipientagency"]==DBNull.Value)return null; return  (String)this["recipientagency"];}
		set {if (value==null) this["recipientagency"]= DBNull.Value; else this["recipientagency"]= value;}
	}
	public object recipientagencyValue { 
		get{ return this["recipientagency"];}
		set {if (value==null|| value==DBNull.Value) this["recipientagency"]= DBNull.Value; else this["recipientagency"]= value;}
	}
	public String recipientagencyOriginal { 
		get {if (this["recipientagency",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["recipientagency",DataRowVersion.Original];}
	}
	///<summary>
	///data inizio
	///</summary>
	public DateTime start{ 
		get {return  (DateTime)this["start"];}
		set {this["start"]= value;}
	}
	public object startValue { 
		get{ return this["start"];}
		set {this["start"]= value;}
	}
	public DateTime startOriginal { 
		get {return  (DateTime)this["start",DataRowVersion.Original];}
	}
	///<summary>
	///data fine
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
	#endregion

}
///<summary>
///Indirizzo di anagrafica
///</summary>
public class registryaddressTable : MetaTableBase<registryaddressRow> {
	public registryaddressTable() : base("registryaddress"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),true,false)},
			{"address",createColumn("address",typeof(string),true,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
			{"cap",createColumn("cap",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"flagforeign",createColumn("flagforeign",typeof(string),true,false)},
			{"idaddresskind",createColumn("idaddresskind",typeof(int),false,false)},
			{"idcity",createColumn("idcity",typeof(int),true,false)},
			{"idnation",createColumn("idnation",typeof(int),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"location",createColumn("location",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"officename",createColumn("officename",typeof(string),true,false)},
			{"recipientagency",createColumn("recipientagency",typeof(string),true,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
		};
	}
}
}
