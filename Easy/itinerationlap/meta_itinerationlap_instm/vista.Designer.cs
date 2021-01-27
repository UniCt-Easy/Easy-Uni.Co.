
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
namespace meta_itinerationlap_instm {
public class itinerationlap_instmRow: MetaRow  {
	public itinerationlap_instmRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///A/R
	///</summary>
	public String ar{ 
		get {if (this["ar"]==DBNull.Value)return null; return  (String)this["ar"];}
		set {if (value==null) this["ar"]= DBNull.Value; else this["ar"]= value;}
	}
	public object arValue { 
		get{ return this["ar"];}
		set {if (value==null|| value==DBNull.Value) this["ar"]= DBNull.Value; else this["ar"]= value;}
	}
	public String arOriginal { 
		get {if (this["ar",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ar",DataRowVersion.Original];}
	}
	///<summary>
	///Località di Partenza
	///</summary>
	public Int32? idcity_departure{ 
		get {if (this["idcity_departure"]==DBNull.Value)return null; return  (Int32?)this["idcity_departure"];}
		set {if (value==null) this["idcity_departure"]= DBNull.Value; else this["idcity_departure"]= value;}
	}
	public object idcity_departureValue { 
		get{ return this["idcity_departure"];}
		set {if (value==null|| value==DBNull.Value) this["idcity_departure"]= DBNull.Value; else this["idcity_departure"]= value;}
	}
	public Int32? idcity_departureOriginal { 
		get {if (this["idcity_departure",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity_departure",DataRowVersion.Original];}
	}
	///<summary>
	///Località di Arrivo
	///</summary>
	public Int32? idcity_destination{ 
		get {if (this["idcity_destination"]==DBNull.Value)return null; return  (Int32?)this["idcity_destination"];}
		set {if (value==null) this["idcity_destination"]= DBNull.Value; else this["idcity_destination"]= value;}
	}
	public object idcity_destinationValue { 
		get{ return this["idcity_destination"];}
		set {if (value==null|| value==DBNull.Value) this["idcity_destination"]= DBNull.Value; else this["idcity_destination"]= value;}
	}
	public Int32? idcity_destinationOriginal { 
		get {if (this["idcity_destination",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity_destination",DataRowVersion.Original];}
	}
	public Int32? iditineration{ 
		get {if (this["iditineration"]==DBNull.Value)return null; return  (Int32?)this["iditineration"];}
		set {if (value==null) this["iditineration"]= DBNull.Value; else this["iditineration"]= value;}
	}
	public object iditinerationValue { 
		get{ return this["iditineration"];}
		set {if (value==null|| value==DBNull.Value) this["iditineration"]= DBNull.Value; else this["iditineration"]= value;}
	}
	public Int32? iditinerationOriginal { 
		get {if (this["iditineration",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iditineration",DataRowVersion.Original];}
	}
	///<summary>
	///Mezzo
	///</summary>
	public Int32? iditinerationlapvehiclekind{ 
		get {if (this["iditinerationlapvehiclekind"]==DBNull.Value)return null; return  (Int32?)this["iditinerationlapvehiclekind"];}
		set {if (value==null) this["iditinerationlapvehiclekind"]= DBNull.Value; else this["iditinerationlapvehiclekind"]= value;}
	}
	public object iditinerationlapvehiclekindValue { 
		get{ return this["iditinerationlapvehiclekind"];}
		set {if (value==null|| value==DBNull.Value) this["iditinerationlapvehiclekind"]= DBNull.Value; else this["iditinerationlapvehiclekind"]= value;}
	}
	public Int32? iditinerationlapvehiclekindOriginal { 
		get {if (this["iditinerationlapvehiclekind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iditinerationlapvehiclekind",DataRowVersion.Original];}
	}
	///<summary>
	///Kilometri
	///</summary>
	public Int32? km{ 
		get {if (this["km"]==DBNull.Value)return null; return  (Int32?)this["km"];}
		set {if (value==null) this["km"]= DBNull.Value; else this["km"]= value;}
	}
	public object kmValue { 
		get{ return this["km"];}
		set {if (value==null|| value==DBNull.Value) this["km"]= DBNull.Value; else this["km"]= value;}
	}
	public Int32? kmOriginal { 
		get {if (this["km",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["km",DataRowVersion.Original];}
	}
	public Int32? lapnumber{ 
		get {if (this["lapnumber"]==DBNull.Value)return null; return  (Int32?)this["lapnumber"];}
		set {if (value==null) this["lapnumber"]= DBNull.Value; else this["lapnumber"]= value;}
	}
	public object lapnumberValue { 
		get{ return this["lapnumber"];}
		set {if (value==null|| value==DBNull.Value) this["lapnumber"]= DBNull.Value; else this["lapnumber"]= value;}
	}
	public Int32? lapnumberOriginal { 
		get {if (this["lapnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["lapnumber",DataRowVersion.Original];}
	}
	#endregion

}
public class itinerationlap_instmTable : MetaTableBase<itinerationlap_instmRow> {
	public itinerationlap_instmTable() : base("itinerationlap_instm"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ar",createColumn("ar",typeof(string),true,false)},
			{"idcity_departure",createColumn("idcity_departure",typeof(int),true,false)},
			{"idcity_destination",createColumn("idcity_destination",typeof(int),true,false)},
			{"iditineration",createColumn("iditineration",typeof(int),false,false)},
			{"iditinerationlapvehiclekind",createColumn("iditinerationlapvehiclekind",typeof(int),true,false)},
			{"km",createColumn("km",typeof(int),true,false)},
			{"lapnumber",createColumn("lapnumber",typeof(int),false,false)},
		};
	}
}
}
